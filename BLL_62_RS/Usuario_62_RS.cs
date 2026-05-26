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
        public string Login_62_RS(string txtUser_62_RS, string txtPass_62_RS)
        {
            try
            {
                string passHasheada_62_RS = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(txtPass_62_RS);
                SEG_62_RS.Usuario_62_RS usuario_62_RS = usuarioDAL_62_RS.ValidarAcceso_62_RS(txtUser_62_RS, passHasheada_62_RS);
                if (SingletonSession_62_RS.Instancia_62_RS.EstaAutenticado_62_RS())
                {
                    throw new Exception("Ya existe una sesión activa. Debe cerrar la sesión actual para iniciar una nueva.");
                }
                if (usuario_62_RS == null)
                {
                    intentosFallidos_62_RS++;
                    if (intentosFallidos_62_RS >= 3)
                    {
                        BloquearUsuarioPorNombre_62_RS(txtUser_62_RS);
                        throw new Exception("Has superado los 3 intentos. El usuario ha sido bloqueado por seguridad.");
                        bllBitacora_62_RS.InsertarBitacora_62_RS(txtUser_62_RS, "Bloquear Usuario", "Seguridad", "1");
                        intentosFallidos_62_RS = 0;

                    }
                    throw new Exception($"Credenciales incorrectas. Intento {intentosFallidos_62_RS} de 3.");
                }
                if (!usuario_62_RS.Activo_62_RS) throw new Exception("Cuenta desactivada.");
                if (usuario_62_RS.Estado_62_RS) throw new Exception("Cuenta bloqueada.");
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
                throw new Exception("No hay una sesión activa.");
            }

            else

            {
                SingletonSession_62_RS.Instancia_62_RS.CerrarSesion_62_RS();
            }
        }

        private void BloquearUsuarioPorNombre_62_RS(string nombreUsuario_62_RS)
        {
            usuarioDAL_62_RS.BloquearUsuario_62_RS(nombreUsuario_62_RS);
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
                    throw new Exception("El DNI introducido ya existe.");
                }
                return usuarioDAL_62_RS.AltaUsuario_62_RS(user_62_RS);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el usuario: " + ex.Message);
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
                throw new Exception("Error al procesar la lista de usuarios: " + ex_62_RS.Message);
            }
        }

        public void ModificarUsuario_62_RS(SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            try
            {
                user_62_RS.UsU_62_RS = user_62_RS.Nombre_62_RS + user_62_RS.Apellido_62_RS;

                if (usuarioDAL_62_RS.ModificarDatos_62_RS(user_62_RS) == 0)
                {
                    throw new Exception("No se encontró el registro para modificar.");
                }
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Lógica de Negocio: " + ex_62_RS.Message);
            }
        }

        public void DesbloquearUsuario_62_RS(int id_62_RS, SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            if (usuarioDAL_62_RS.Verificar_62_RS(user_62_RS, 2) == 0)
            {
                throw new Exception("El usuario no se encuentra bloqueado.");
            }
            usuarioDAL_62_RS.ModificarEstado_62_RS(id_62_RS, "estado_62_RS", 0);
            string NuevoPass_62_RS = user_62_RS.DNI_62_RS + user_62_RS.Apellido_62_RS;

            string Actual_62_Rs = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(NuevoPass_62_RS);
            int filasAfectadas = usuarioDAL_62_RS.ActualizarClave_62_RS(user_62_RS.UsU_62_RS, Actual_62_Rs);
            if (filasAfectadas > 0)
            {
                user_62_RS.Password_62_RS = Actual_62_Rs;
            }
            else
            {
                throw new Exception("No se pudo actualizar la clave en la base de datos.");
            }
        }

        public void AlternarActivo_62_RS(int id_62_RS, int valorActual_62_RS)
        {
            int nuevoVal_62_RS = (valorActual_62_RS == 1) ? 0 : 1;
            usuarioDAL_62_RS.ModificarEstado_62_RS(id_62_RS, "Activo_62_RS", nuevoVal_62_RS);
        }

        public int ActualizarClave_62_RS(string valorActual_62_RS, string ValorNuevo_62_RS, string ValorRepetido_62_RS)
        {
            if (string.IsNullOrEmpty(valorActual_62_RS) || string.IsNullOrEmpty(ValorNuevo_62_RS) || string.IsNullOrEmpty(ValorRepetido_62_RS))
                throw new Exception("Todos los campos son obligatorios.");

            var usu_62_RS = SEG_62_RS.Singleton.SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;
            string Actual_62_Rs = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(valorActual_62_RS);
            if (Actual_62_Rs != usu_62_RS.Password_62_RS)
                throw new Exception("La clave actual es incorrecta.");
            if (ValorNuevo_62_RS != ValorRepetido_62_RS)
                throw new Exception("La nueva clave y su repetición no coinciden.");
            if (valorActual_62_RS == ValorNuevo_62_RS)
                throw new Exception("La nueva clave no puede ser igual a la actual.");
            string nuevaHasheada_62_RS = SEG_62_RS.Encriptacion_62_RS.EncriptarSHA256_62_RS(ValorNuevo_62_RS);
            int filasAfectadas = usuarioDAL_62_RS.ActualizarClave_62_RS(usu_62_RS.UsU_62_RS, nuevaHasheada_62_RS);
            if (filasAfectadas > 0)
            {
                usu_62_RS.Password_62_RS = nuevaHasheada_62_RS;
            }
            else
            {
                throw new Exception("No se pudo actualizar la clave en la base de datos.");
            }
            return filasAfectadas;
        }
    }
}
