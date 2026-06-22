using SEG_62_RS.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_62_RS
{
    public class DVV_62_RS
    {
        private DAL_62_RS.DVV_62_RS dalDvv_62_RS = new DAL_62_RS.DVV_62_RS();



        public void RecalcularDVVTabla_62_RS(string nombreTabla_62_RS)
        {
            try
            {
                List<int> listaDvhs = dalDvv_62_RS.ObtenerTodosLosDVH_62_RS(nombreTabla_62_RS);
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                int sumaTotalDvv = motorDV.CalcularDVV_62_RS(listaDvhs);
                dalDvv_62_RS.ActualizarSumaDVV_62_RS(nombreTabla_62_RS, sumaTotalDvv);
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo de integridad al recalcular DVV: " + ex.Message);
            }
        }

        public List<SEG_62_RS.Infraccion_62_RS> VerificarIntegridadGlobal_62_RS()
        {
            List<SEG_62_RS.Infraccion_62_RS> listaErrores = new List<SEG_62_RS.Infraccion_62_RS>();

            try
            {
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();


                //Usuarios_62_RS
                try
                {
                    BLL_62_RS.Usuario_62_RS bllUsu = new BLL_62_RS.Usuario_62_RS();
                    DataTable dtUsuarios = bllUsu.ListarUsuario_62_RS(0);
                    int sumaDvhCalculadaUsuarios = 0;

                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        SEG_62_RS.Usuario_62_RS usu = new SEG_62_RS.Usuario_62_RS
                        {
                            IdUsuario_62_RS = Convert.ToInt32(row["idusuario_62_RS"]),
                            IdIdioma = Convert.ToInt32(row["IdIdioma_62_RS"]),
                            Nombre_62_RS = row["nombre_62_RS"].ToString(),
                            Apellido_62_RS = row["apellido_62_RS"].ToString(),
                            Email_62_RS = row["email_62_RS"].ToString(),
                            DNI_62_RS = row["dni_62_RS"].ToString(),
                            UsU_62_RS = row["usu_62_RS"].ToString(),
                            Password_62_RS = row["password_62_RS"].ToString(),
                            Estado_62_RS = Convert.ToBoolean(row["estado_62_RS"]),
                            Activo_62_RS = Convert.ToBoolean(row["Activo_62_RS"]),
                            IdRol_62_RS = row["IdRol_62_RS"] != DBNull.Value ? Convert.ToInt32(row["IdRol_62_RS"]) : 0,
                            Dvh_62_RS = Convert.ToInt32(row["Dvh_62_RS"])
                        };

                        int dvhEnVivo = motorDV.CalcularDVH_62_RS(usu);
                        if (dvhEnVivo != usu.Dvh_62_RS)
                        {
                            listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Usuarios_62_RS", IdRegistro_62_RS = usu.IdUsuario_62_RS.ToString(), TipoError_62_RS = "Horizontal (Fila Alterada)" });
                        }
                        sumaDvhCalculadaUsuarios += dvhEnVivo;
                    }

                    int dvvGuardadoUsu = dalDvv_62_RS.ObtenerDvvGuardado_62_RS("Usuarios_62_RS");
                    if (sumaDvhCalculadaUsuarios != dvvGuardadoUsu)
                    {
                        listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Usuarios_62_RS", IdRegistro_62_RS = "COLUMNA", TipoError_62_RS = "Vertical (Suma total no coincide)" });
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error validando Usuarios: " + ex.Message); }

                // Roles_62_RS
                try
                {
                    BLL_62_RS.Permisos_62_RS bllPermisos = new BLL_62_RS.Permisos_62_RS();
                    DataTable dtRoles = bllPermisos.ListarRolesBase_62_RS();
                    int sumaDvhCalculadaRoles = 0;

                    foreach (DataRow row in dtRoles.Rows)
                    {
                        SEG_62_RS.Composite.Rol_62_RS rol = new SEG_62_RS.Composite.Rol_62_RS(row["Nombre_62_RS"].ToString())
                        {
                            Id_62_RS = Convert.ToInt32(row["IdRol_62_RS"]),
                            Descripcion_62_RS = row["Descripcion_62_RS"].ToString(),
                            Dvh_62_RS = Convert.ToInt32(row["Dvh_62_RS"])
                        };

                        int dvhEnVivo = motorDV.CalcularDVH_62_RS(rol);
                        if (dvhEnVivo != rol.Dvh_62_RS)
                        {
                            listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Roles_62_RS", IdRegistro_62_RS = rol.Id_62_RS.ToString(), TipoError_62_RS = "Horizontal (Fila Alterada)" });
                        }
                        sumaDvhCalculadaRoles += dvhEnVivo;
                    }

                    int dvvGuardadoRoles = dalDvv_62_RS.ObtenerDvvGuardado_62_RS("Roles_62_RS");
                    if (sumaDvhCalculadaRoles != dvvGuardadoRoles)
                    {
                        listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Roles_62_RS", IdRegistro_62_RS = "COLUMNA", TipoError_62_RS = "Vertical (Suma total no coincide)" });
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error validando Roles: " + ex.Message); }


                //Familias_62_RS
                try
                {
                    BLL_62_RS.Permisos_62_RS bllPermisos = new BLL_62_RS.Permisos_62_RS();
                    List<SEG_62_RS.Composite.Familia_62_RS> listaFamilias = bllPermisos.ObtenerFamilias_62_RS();
                    int sumaDvhCalculadaFamilias = 0;

                    foreach (var familia in listaFamilias)
                    {
                        int dvhEnVivo = motorDV.CalcularDVH_62_RS(familia);
                        if (dvhEnVivo != familia.Dvh_62_RS)
                        {
                            listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Familias_62_RS", IdRegistro_62_RS = familia.Id_62_RS.ToString(), TipoError_62_RS = "Horizontal (Fila Alterada)" });
                        }
                        sumaDvhCalculadaFamilias += dvhEnVivo;
                    }

                    int dvvGuardadoFamilias = dalDvv_62_RS.ObtenerDvvGuardado_62_RS("Familias_62_RS");
                    if (sumaDvhCalculadaFamilias != dvvGuardadoFamilias)
                    {
                        listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Familias_62_RS", IdRegistro_62_RS = "COLUMNA", TipoError_62_RS = "Vertical (Suma total no coincide)" });
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error validando Familias: " + ex.Message); }

                // Bitacora_62_RS
                try
                {
                    BLL_62_RS.Bitcaora_62_RS bllBitacora = new BLL_62_RS.Bitcaora_62_RS();
                    DataTable dtBitacora = bllBitacora.ListarTodaBitacoraParaDVV_62_RS();

                    int sumaDvhCalculadaBitacora = 0;

                    foreach (DataRow row in dtBitacora.Rows)
                    {
                        SEG_62_RS.Bitacora_62_RS bit = new SEG_62_RS.Bitacora_62_RS
                        {
                            IdBitacora_62_RS = Convert.ToInt32(row["IdBitacora_62_RS"]),
                            Usu_62_RS = row["Usu_62_RS"].ToString(),
                            FechaCambio_62_RS = Convert.ToDateTime(row["FechaCambio_62_RS"]),
                            Descripcion_62_RS = row["Descripcion_62_RS"].ToString(),
                            Modulo_62_RS = row["Modulo_62_RS"].ToString(),
                            Criticidad_62_RS = row["Criticidad_62_RS"].ToString(),
                            Dvh_62_RS = Convert.ToInt32(row["Dvh_62_RS"])
                        };

                        int dvhEnVivo = motorDV.CalcularDVH_62_RS(bit);
                        if (dvhEnVivo != bit.Dvh_62_RS)
                        {
                            listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Bitacora_62_RS", IdRegistro_62_RS = bit.IdBitacora_62_RS.ToString(), TipoError_62_RS = "Horizontal (Fila Alterada)" });
                        }
                        sumaDvhCalculadaBitacora += dvhEnVivo;
                    }

                    int dvvGuardadoBitacora = dalDvv_62_RS.ObtenerDvvGuardado_62_RS("Bitacora_62_RS");
                    if (sumaDvhCalculadaBitacora != dvvGuardadoBitacora)
                    {
                        listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "Bitacora_62_RS", IdRegistro_62_RS = "COLUMNA", TipoError_62_RS = "Vertical (Suma total no coincide)" });
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error validando Bitácora: " + ex.Message); }

                return listaErrores;
            }
            catch (Exception ex)
            {
                listaErrores.Add(new SEG_62_RS.Infraccion_62_RS { Tabla_62_RS = "SISTEMA", IdRegistro_62_RS = "N/A", TipoError_62_RS = "Falla técnica general: " + ex.Message });
                return listaErrores;
            }
        }

        public void RecalcularTodosLosDigitos_62_RS()
        {
            try
            {
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                DAL_62_RS.Usuario_62_RS dalUsu = new DAL_62_RS.Usuario_62_RS();
                DAL_62_RS.Permisos_62_RS dalPermisos = new DAL_62_RS.Permisos_62_RS();
                DAL_62_RS.Bitacora_62_RS dalBitacora = new DAL_62_RS.Bitacora_62_RS();

                //RECALCULAR USUARIOS
                BLL_62_RS.Usuario_62_RS bllUsu = new BLL_62_RS.Usuario_62_RS();
                DataTable dtUsuarios = bllUsu.ListarUsuario_62_RS(0);
                foreach (DataRow row in dtUsuarios.Rows)
                {
                    SEG_62_RS.Usuario_62_RS usu = new SEG_62_RS.Usuario_62_RS
                    {
                        IdUsuario_62_RS = Convert.ToInt32(row["idusuario_62_RS"]),
                        IdIdioma = Convert.ToInt32(row["IdIdioma_62_RS"]),
                        Nombre_62_RS = row["nombre_62_RS"].ToString(),
                        Apellido_62_RS = row["apellido_62_RS"].ToString(),
                        Email_62_RS = row["email_62_RS"].ToString(),
                        DNI_62_RS = row["dni_62_RS"].ToString(),
                        UsU_62_RS = row["usu_62_RS"].ToString(),
                        Password_62_RS = row["password_62_RS"].ToString(),
                        Estado_62_RS = Convert.ToBoolean(row["estado_62_RS"]),
                        Activo_62_RS = Convert.ToBoolean(row["Activo_62_RS"]),
                        IdRol_62_RS = row["IdRol_62_RS"] != DBNull.Value ? Convert.ToInt32(row["IdRol_62_RS"]) : 0
                    };
                    int nuevoDvh = motorDV.CalcularDVH_62_RS(usu);
                    dalUsu.ActualizarDVH_62_RS(usu.IdUsuario_62_RS, nuevoDvh);
                }

                //RECALCULAR ROLES
                BLL_62_RS.Permisos_62_RS bllPermisos = new BLL_62_RS.Permisos_62_RS();
                DataTable dtRoles = bllPermisos.ListarRolesBase_62_RS();
                foreach (DataRow row in dtRoles.Rows)
                {
                    SEG_62_RS.Composite.Rol_62_RS rol = new SEG_62_RS.Composite.Rol_62_RS(row["Nombre_62_RS"].ToString())
                    {
                        Id_62_RS = Convert.ToInt32(row["IdRol_62_RS"]),
                        Descripcion_62_RS = row["Descripcion_62_RS"].ToString()
                    };
                    int nuevoDvh = motorDV.CalcularDVH_62_RS(rol);
                    dalPermisos.ActualizarDVH_Rol_62_RS(rol.Id_62_RS, nuevoDvh);
                }

                //RECALCULAR FAMILIAS
                List<SEG_62_RS.Composite.Familia_62_RS> listaFamilias = bllPermisos.ObtenerFamilias_62_RS();
                foreach (var familia in listaFamilias)
                {
                    int nuevoDvh = motorDV.CalcularDVH_62_RS(familia);
                    dalPermisos.ActualizarDVH_Familia_62_RS(familia.Id_62_RS, nuevoDvh);
                }

                //RECALCULAR BITÁCORA
                BLL_62_RS.Bitcaora_62_RS bllBitacoraBll = new BLL_62_RS.Bitcaora_62_RS();
                DataTable dtBitacora = bllBitacoraBll.ListarTodaBitacoraParaDVV_62_RS();
                foreach (DataRow row in dtBitacora.Rows)
                {
                    SEG_62_RS.Bitacora_62_RS bit = new SEG_62_RS.Bitacora_62_RS
                    {
                        IdBitacora_62_RS = Convert.ToInt32(row["IdBitacora_62_RS"]),
                        Usu_62_RS = row["Usu_62_RS"].ToString(),
                        FechaCambio_62_RS = Convert.ToDateTime(row["FechaCambio_62_RS"]),
                        Descripcion_62_RS = row["Descripcion_62_RS"].ToString(),
                        Modulo_62_RS = row["Modulo_62_RS"].ToString(),
                        Criticidad_62_RS = row["Criticidad_62_RS"].ToString()
                    };
                    int nuevoDvh = motorDV.CalcularDVH_62_RS(bit);
                    dalBitacora.ActualizarDVH_62_RS(bit.IdBitacora_62_RS, nuevoDvh);
                }

                //RECALCULAR VERTICALES (DVV) DE TODAS LAS TABLAS
                this.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
                this.RecalcularDVVTabla_62_RS("Roles_62_RS");
                this.RecalcularDVVTabla_62_RS("Familias_62_RS");
                this.RecalcularDVVTabla_62_RS("Bitacora_62_RS");

                //REGISTRO EN BITÁCORA DEL EVENTO DE SEGURIDAD
                string admin = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                bllBitacoraBll.InsertarBitacora_62_RS(admin, "Recálculo masivo de DVH y DVV", "Seguridad", "3");
            }
            catch (Exception ex)
            {
                throw new Exception("Error crítico al recalcular toda la base de datos: " + ex.Message);
            }
        }
    }
}