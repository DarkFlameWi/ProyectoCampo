using SEG_62_RS;
using SEG_62_RS.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_RS;

namespace BLL_62_RS
{
    public class Usuario_62_RS
    {
        SEG_62_RS.Usuario_62_RS usuario_62_RS = new SEG_62_RS.Usuario_62_RS();
        DAL_62_RS.Usuario_62_RS usuarioDAL_62_RS = new DAL_62_RS.Usuario_62_RS();
        BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();
        private int intentosFallidos_62_RS = 0;
        

        private string Traducir(string clave)
        {
            return SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS[clave];
        }
        public string Login_62_RS(string txtUser_62_RS, string txtPass_62_RS)
        {
            try
            {
                string passHasheada_62_RS = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(txtPass_62_RS);
                SEG_62_RS.Usuario_62_RS usuario_62_RS = usuarioDAL_62_RS.ValidarAcceso_62_RS(txtUser_62_RS, passHasheada_62_RS);
                if (SingletonSession_62_RS.Instancia_62_RS.EstaAutenticado_62_RS())
                {
                    throw new Exception(Traducir("Exc_BLL_SesionActiva"));
                }
                if (usuario_62_RS == null)
                {
                    intentosFallidos_62_RS++;
                    if (intentosFallidos_62_RS >= 3)
                    {
                        BloquearUsuarioPorNombre_62_RS(txtUser_62_RS);
                        bllBitacora_62_RS.InsertarBitacora_62_RS(txtUser_62_RS, "Bloquear Usuario", "Usuario", "1");
                        intentosFallidos_62_RS = 0;
                        throw new Exception(Traducir("Exc_BLL_BloqueoIntentos"));

                    }
                    throw new Exception(Traducir("Exc_BLL_CredencialesInvalidas") + intentosFallidos_62_RS + Traducir("Exc_BLL_CredencialesInvalidas_Fin"));
                }
                if (!usuario_62_RS.Activo_62_RS) throw new Exception(Traducir("Exc_BLL_CuentaDesactivada"));
                if (usuario_62_RS.Estado_62_RS) throw new Exception(Traducir("Exc_BLL_CuentaBloqueada"));
                intentosFallidos_62_RS = 0;
                SingletonSession_62_RS.Instancia_62_RS.IniciarSesion_62_RS(usuario_62_RS);
                return "¡Bienvenido/a!";
            }
            catch (Exception ex_62_RS) { throw ex_62_RS; }
        }
        public void logout_62_RS()
        {
            if (!SingletonSession_62_RS.Instancia_62_RS.EstaAutenticado_62_RS())

            {
                throw new Exception(Traducir("Exc_BLL_SinSesion"));
            }

            else

            {
             string nombreUsuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS;
             bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario_62_RS, "Cierre de sesión", "Usuario", "1");
                SingletonSession_62_RS.Instancia_62_RS.CerrarSesion_62_RS();
            }
        }
        private void BloquearUsuarioPorNombre_62_RS(string nombreUsuario_62_RS)
        {
            SEG_62_RS.Usuario_62_RS usuarioABloquear = usuarioDAL_62_RS.ObtenerUsuarioPorNombre_62_RS(nombreUsuario_62_RS);

            if (usuarioABloquear != null)
            {
                usuarioABloquear.Estado_62_RS = true;
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                usuarioABloquear.Dvh_62_RS = motorDV.CalcularDVH_62_RS(usuarioABloquear);
                usuarioDAL_62_RS.BloquearUsuario_62_RS(nombreUsuario_62_RS, (int)usuarioABloquear.Dvh_62_RS);
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
            }
        }
        public int AltaUsuario_62_RS(SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            try
            {
                user_62_RS.Activo_62_RS = true;
                user_62_RS.Estado_62_RS = false;
                user_62_RS.UsU_62_RS = user_62_RS.Nombre_62_RS + user_62_RS.Apellido_62_RS;
                string passProvisoria_62_RS = user_62_RS.DNI_62_RS + user_62_RS.Apellido_62_RS;
                user_62_RS.Password_62_RS = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(passProvisoria_62_RS);
                if(usuarioDAL_62_RS.Verificar_62_RS(user_62_RS,1) > 0)
                {
                    throw new Exception(Traducir("Exc_BLL_DniExistente"));
                }
                string nombreUsuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS;
                int idGenerado = usuarioDAL_62_RS.AltaUsuario_62_RS(user_62_RS);
                user_62_RS.IdUsuario_62_RS = idGenerado;
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                int dvhCalculado = motorDV.CalcularDVH_62_RS(user_62_RS);
                usuarioDAL_62_RS.ActualizarDVH_62_RS(idGenerado, dvhCalculado);
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
                bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario_62_RS, "Crear Usuario", "Administracion", "1");
                return idGenerado;
            }
            catch (Exception ex)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorAltaUsu") + ex.Message);
            }
        }
        public DataTable ListarUsuario_62_RS(int tipousuario)
        {
            try
            {
                DataTable dt_62_RS = usuarioDAL_62_RS.ListarUsuarios_62_RS(tipousuario);

                if (dt_62_RS == null || dt_62_RS.Rows.Count == 0)
                {
                    
                }
                return dt_62_RS;
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorListarUsu") + ex_62_RS.Message);
            }
        }
        public void ModificarUsuario_62_RS(SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            try
            {
                user_62_RS.UsU_62_RS = user_62_RS.Nombre_62_RS + user_62_RS.Apellido_62_RS;
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                user_62_RS.Dvh_62_RS = motorDV.CalcularDVH_62_RS(user_62_RS);
                if (usuarioDAL_62_RS.ModificarDatos_62_RS(user_62_RS) == 0)
                {
                    throw new Exception(Traducir("Exc_BLL_ModificarSinRegistro"));
                }
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
                string nombreUsuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS;
                bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario_62_RS, "Modificar Usuario", "Administracion", "1");
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception(Traducir("Exc_BLL_LogicaNegocio") + ex_62_RS.Message);
            }
        }
        public void DesbloquearUsuario_62_RS(int id_62_RS, SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            if (usuarioDAL_62_RS.Verificar_62_RS(user_62_RS, 2) == 0)
            {
                throw new Exception(Traducir("Exc_BLL_UsuNoBloqueado"));
            }

            SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();

            user_62_RS.Estado_62_RS = false;
            user_62_RS.Dvh_62_RS = motorDV.CalcularDVH_62_RS(user_62_RS);
            usuarioDAL_62_RS.ModificarEstado_62_RS(id_62_RS, "estado_62_RS", 0, (int)user_62_RS.Dvh_62_RS);
            string NuevoPass_62_RS = user_62_RS.DNI_62_RS + user_62_RS.Apellido_62_RS;
            string Actual_62_Rs = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(NuevoPass_62_RS);
            user_62_RS.Password_62_RS = Actual_62_Rs;
            user_62_RS.Dvh_62_RS = motorDV.CalcularDVH_62_RS(user_62_RS);
            int filasAfectadas = usuarioDAL_62_RS.ActualizarClave_62_RS(user_62_RS.UsU_62_RS, Actual_62_Rs, (int)user_62_RS.Dvh_62_RS);
            BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
            gestorDvv.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
            if (filasAfectadas > 0)
            {
                string nombreUsuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS;
                bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario_62_RS, "Desbloquear Usuario", "Administracion", "1");
            }
            else
            {
                throw new Exception(Traducir("Exc_BLL_ErrorBDClave"));
            }
        }
        public void AlternarActivo_62_RS(SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            user_62_RS.Activo_62_RS = !user_62_RS.Activo_62_RS;
            SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
            user_62_RS.Dvh_62_RS = motorDV.CalcularDVH_62_RS(user_62_RS);
            int valorParaDAL_62_RS = user_62_RS.Activo_62_RS ? 1 : 0;
            usuarioDAL_62_RS.ModificarEstado_62_RS(user_62_RS.IdUsuario_62_RS, "Activo_62_RS", valorParaDAL_62_RS, (int)user_62_RS.Dvh_62_RS); string nombreUsuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS;
            BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
            gestorDvv.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
            bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario_62_RS, "Activar/Desactivar Usuario", "Administracion", "1");
        }
        public int ActualizarClave_62_RS(string valorActual_62_RS, string ValorNuevo_62_RS, string ValorRepetido_62_RS)
        {
            if (string.IsNullOrEmpty(valorActual_62_RS) || string.IsNullOrEmpty(ValorNuevo_62_RS) || string.IsNullOrEmpty(ValorRepetido_62_RS))
                throw new Exception(Traducir("Exc_BLL_CamposObligatorios"));
            var usu_62_RS = SEG_62_RS.Singleton.SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;
            string Actual_62_Rs = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(valorActual_62_RS);
            if (Actual_62_Rs != usu_62_RS.Password_62_RS)
                throw new Exception(Traducir("Exc_BLL_ClaveActualInco"));
            if (ValorNuevo_62_RS != ValorRepetido_62_RS)
                throw new Exception(Traducir("Exc_BLL_ClaveRepeticionInco"));
            if (valorActual_62_RS == ValorNuevo_62_RS)
                throw new Exception(Traducir("Exc_BLL_ClaveIgualActual"));
            string nuevaHasheada_62_RS = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(ValorNuevo_62_RS);
            string passwordAnterior_62_RS = usu_62_RS.Password_62_RS;
            usu_62_RS.Password_62_RS = nuevaHasheada_62_RS;
            SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
            int nuevoDvh = motorDV.CalcularDVH_62_RS(usu_62_RS);
            usu_62_RS.Dvh_62_RS = nuevoDvh;
            int filasAfectadas = usuarioDAL_62_RS.ActualizarClave_62_RS(usu_62_RS.UsU_62_RS, nuevaHasheada_62_RS, nuevoDvh);

            if (filasAfectadas > 0)
            {
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
                string nombreUsuario_62_RS = usu_62_RS.UsU_62_RS;
                bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario_62_RS, "Cambio de clave", "Usuario", "1");
            }
            else
            {
                usu_62_RS.Password_62_RS = passwordAnterior_62_RS;
                throw new Exception(Traducir("Exc_BLL_ErrorBDClave"));
            }

            return filasAfectadas;
        }
        public void ActualizarIdiomaUsuario_62_RS(int idUsuario_62_RS, int idIdioma_62_RS)
        {
            try
            {
                var usu_62_RS = SEG_62_RS.Singleton.SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;
                int idiomaAnterior = usu_62_RS.IdIdioma;
                usu_62_RS.IdIdioma = idIdioma_62_RS;
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                int nuevoDvh = motorDV.CalcularDVH_62_RS(usu_62_RS);
                usu_62_RS.Dvh_62_RS = nuevoDvh;
                if (usuarioDAL_62_RS.ActualizarIdiomaUsuario_62_RS(idUsuario_62_RS, idIdioma_62_RS, nuevoDvh) == 0)
                {

                    usu_62_RS.IdIdioma = idiomaAnterior;
                    throw new Exception(Traducir("Exc_BLL_ActualizarIdiomaSinRegistro"));
                }
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
                string nombreUsuario_62_RS = usu_62_RS.UsU_62_RS;
                bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario_62_RS, "Cambio de Idioma", "Usuario", "1");
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorLogicaIdioma") + ex_62_RS.Message);
            }
        }
    }
}
