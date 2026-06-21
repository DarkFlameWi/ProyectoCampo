using DAL_62_RS;
using SEG_62_RS.Composite;
using SEG_62_RS.Excepciones;
using SEG_62_RS.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_62_RS
{
    public class Permisos_62_RS
    {
        private DAL_62_RS.Permisos_62_RS dalPermisos_62_RS = new DAL_62_RS.Permisos_62_RS();
        private BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();
        private string Traducir(string clave)
        {
            var idiomaActual = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS;
            if (idiomaActual != null && idiomaActual.Traducciones_62_RS.ContainsKey(clave))
            {
                return idiomaActual.Traducciones_62_RS[clave];
            }
            return clave;
        }
 

        public List<Patente_62_RS> ObtenerPatentes_62_RS()
        {
            return dalPermisos_62_RS.ObtenerPatentes_62_RS();
        }
        public List<Familia_62_RS> ObtenerFamilias_62_RS()
        {
            return dalPermisos_62_RS.ObtenerFamilias_62_RS();
        }
        public Rol_62_RS ObtenerRolUsuario_62_RS(int idRol_62_RS)
        {
            return dalPermisos_62_RS.ObtenerRolUsuario_62_RS(idRol_62_RS);
        }
        public DataTable ListarRolesBase_62_RS()
        {
            return dalPermisos_62_RS.ListarRolesBase_62_RS();
        }

        // Métodos para gestión de Familias
        public void AltaFamilia_62_RS(string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre_62_RS))
                    throw new Exception(Traducir("Exc_BLL_NombreVacio"));

                string usuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                Familia_62_RS familiaObj = new Familia_62_RS(nombre_62_RS)
                {
                    Descripcion_62_RS = descripcion_62_RS
                };

                int nuevoId = dalPermisos_62_RS.AltaFamilia_62_RS(nombre_62_RS, descripcion_62_RS);
                familiaObj.Id_62_RS = nuevoId;
                int dvhCalculado = motorDV.CalcularDVH_62_RS(familiaObj);
                dalPermisos_62_RS.ActualizarDVH_Familia_62_RS(nuevoId, dvhCalculado);
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Familias_62_RS");
                bllBitacora_62_RS.InsertarBitacora_62_RS(usuario_62_RS, "Alta de Familia: " + nombre_62_RS, "Administracion", "2");
            }
            catch (Exception ex) { throw new Exception(Traducir("Exc_BLL_ErrorFam") + ex.Message); }
        }

        public void BajaFamilia_62_RS(int idFamilia_62_RS)
        {
            try
            {
                dalPermisos_62_RS.BajaFamilia_62_RS(idFamilia_62_RS);
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Familias_62_RS");

                string usuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                bllBitacora_62_RS.InsertarBitacora_62_RS(usuario_62_RS, Traducir("Bit_BajaFam") + " Física ID: " + idFamilia_62_RS, "Administracion", "2");
            }
            catch (Exception ex) { throw new Exception(Traducir("Exc_BLL_ErrorFam") + ex.Message); }
        }
        public void SincronizarPermisosFamilia_62_RS(Familia_62_RS familiaBase, List<Permiso_62_RS> permisosDeseados)
        {
            try
            {
                Familia_62_RS familiaActual = dalPermisos_62_RS.ObtenerFamiliaPorId_62_RS(familiaBase.Id_62_RS);
                if (familiaActual == null) throw new Exception("La familia no existe. Guarde la familia primero.");
                foreach (var permisoActual in familiaActual.ObtenerHijos_62_RS())
                {
                    bool sigueTildado = permisosDeseados.Any(p => p.Id_62_RS == permisoActual.Id_62_RS && p.GetType() == permisoActual.GetType());
                    if (!sigueTildado)
                    {
                        if (permisoActual is Familia_62_RS)
                            dalPermisos_62_RS.RevocarFamiliaDeFamilia_62_RS(familiaBase.Id_62_RS, permisoActual.Id_62_RS);
                        else
                            dalPermisos_62_RS.RevocarPatenteDeFamilia_62_RS(familiaBase.Id_62_RS, permisoActual.Id_62_RS);
                    }
                }
                Familia_62_RS familiaValidacion = new Familia_62_RS(familiaBase.Nombre_62_RS) { Id_62_RS = familiaBase.Id_62_RS };
                foreach (var p in familiaActual.ObtenerHijos_62_RS().Where(act => permisosDeseados.Any(des => des.Id_62_RS == act.Id_62_RS && des.GetType() == act.GetType())))
                    familiaValidacion.AgregarHijo_62_RS(p);
                foreach (var permisoNuevo in permisosDeseados)
                {
                    bool yaLoTenia = familiaActual.ObtenerHijos_62_RS().Any(p => p.Id_62_RS == permisoNuevo.Id_62_RS && p.GetType() == permisoNuevo.GetType());
                    if (!yaLoTenia)
                    {
                        familiaValidacion.AgregarHijo_62_RS(permisoNuevo);
                        if (permisoNuevo is Familia_62_RS)
                            dalPermisos_62_RS.VincularFamiliaAFamilia_62_RS(familiaBase.Id_62_RS, permisoNuevo.Id_62_RS);
                        else
                            dalPermisos_62_RS.VincularPatenteAFamilia_62_RS(familiaBase.Id_62_RS, permisoNuevo.Id_62_RS);
                    }
                }

                string usuario = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                bllBitacora_62_RS.InsertarBitacora_62_RS(usuario, Traducir("Bit_ConfigFam") + familiaBase.Id_62_RS, "Administracion", "3");
            }
            catch (PermisoDuplicadoExcepcion_62_RS exDup)
            {
                throw new Exception(Traducir("Exc_Comp_PermisoDuplicado") + exDup.NombrePermiso_62_RS);
            }
            catch (OperacionInvalidaExcepcion_62_RS)
            {
                throw new Exception(Traducir("Exc_Comp_OperacionInvalida"));
            }
        }



        public void AltaRol_62_RS(string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre_62_RS))
                    throw new Exception(Traducir("Exc_BLL_NombreVacio"));

                string usuario_62_RS = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                SEG_62_RS.DigitoVerificador_62_RS motorDV = new SEG_62_RS.DigitoVerificador_62_RS();
                Rol_62_RS rolObj = new Rol_62_RS(nombre_62_RS)
                {
                    Descripcion_62_RS = descripcion_62_RS
                };
                int nuevoId = dalPermisos_62_RS.AltaRol_62_RS(nombre_62_RS, descripcion_62_RS);
                rolObj.Id_62_RS = nuevoId;
                int dvhCalculado = motorDV.CalcularDVH_62_RS(rolObj);
                dalPermisos_62_RS.ActualizarDVH_Rol_62_RS(nuevoId, dvhCalculado);

                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Roles_62_RS");
                bllBitacora_62_RS.InsertarBitacora_62_RS(usuario_62_RS, "Alta de Rol: " + nombre_62_RS, "Administracion", "2");
            }
            catch (Exception ex) { throw new Exception(Traducir("Exc_BLL_ErrorRol") + ex.Message); }
        }
        public bool RolTieneUsuariosAsignados_62_RS(int idRol_62_RS)
        {
            return dalPermisos_62_RS.ContarUsuariosConRol_62_RS(idRol_62_RS) > 0;
        }
        public void BajaRol_62_RS(int idRol_62_RS)
        {
            try
            {
                var usuActual = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;
                if (usuActual != null && usuActual.IdRol_62_RS == idRol_62_RS)
                {
                    throw new Exception("Seguridad: No puede eliminar el rol que tiene asignado actualmente en su sesión.");
                }
                if (RolTieneUsuariosAsignados_62_RS(idRol_62_RS))
                {
                    BLL_62_RS.Usuario_62_RS bllUsu = new BLL_62_RS.Usuario_62_RS();
                    DataTable dtUsuarios = bllUsu.ListarUsuario_62_RS(0);

                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        if (row["IdRol_62_RS"] != DBNull.Value && Convert.ToInt32(row["IdRol_62_RS"]) == idRol_62_RS)
                        {
                            SEG_62_RS.Usuario_62_RS usuModificado = new SEG_62_RS.Usuario_62_RS
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
                                IdRol_62_RS = 0
                            };
                            bllUsu.ModificarUsuario_62_RS(usuModificado);
                        }
                    }
                    BLL_62_RS.DVV_62_RS gestorDvvUsu = new BLL_62_RS.DVV_62_RS();
                    gestorDvvUsu.RecalcularDVVTabla_62_RS("Usuarios_62_RS");
                }
                dalPermisos_62_RS.BajaRol_62_RS(idRol_62_RS);
                BLL_62_RS.DVV_62_RS gestorDvv = new BLL_62_RS.DVV_62_RS();
                gestorDvv.RecalcularDVVTabla_62_RS("Roles_62_RS");

                bllBitacora_62_RS.InsertarBitacora_62_RS(usuActual?.UsU_62_RS ?? "Sistema", "Baja Física de Rol ID: " + idRol_62_RS, "Administracion", "2");
            }
            catch (Exception ex) { throw new Exception(Traducir("Exc_BLL_ErrorRol") + ex.Message); }
        }

        public void SincronizarPermisosRol_62_RS(Rol_62_RS rolBase, List<Permiso_62_RS> permisosDeseados)
        {
            try
            {
                Rol_62_RS rolActual = dalPermisos_62_RS.ObtenerRolUsuario_62_RS(rolBase.Id_62_RS);
                if (rolActual == null) throw new Exception("El rol no existe. Guarde el rol primero.");

                foreach (var permisoActual in rolActual.ObtenerHijos_62_RS())
                {
                    bool sigueTildado = permisosDeseados.Any(p => p.Id_62_RS == permisoActual.Id_62_RS && p.GetType() == permisoActual.GetType());
                    if (!sigueTildado)
                    {
                        if (permisoActual is Familia_62_RS)
                            dalPermisos_62_RS.RevocarFamiliaDeRol_62_RS(rolBase.Id_62_RS, permisoActual.Id_62_RS);
                        else
                            dalPermisos_62_RS.RevocarPatenteDeRol_62_RS(rolBase.Id_62_RS, permisoActual.Id_62_RS);
                    }
                }

                Rol_62_RS rolValidacion = new Rol_62_RS(rolBase.Nombre_62_RS) { Id_62_RS = rolBase.Id_62_RS };

                foreach (var p in rolActual.ObtenerHijos_62_RS().Where(act => permisosDeseados.Any(des => des.Id_62_RS == act.Id_62_RS && des.GetType() == act.GetType())))
                    rolValidacion.AgregarHijo_62_RS(p);

                foreach (var permisoNuevo in permisosDeseados)
                {
                    bool yaLoTenia = rolActual.ObtenerHijos_62_RS().Any(p => p.Id_62_RS == permisoNuevo.Id_62_RS && p.GetType() == permisoNuevo.GetType());
                    if (!yaLoTenia)
                    {
                        rolValidacion.AgregarHijo_62_RS(permisoNuevo);

                        if (permisoNuevo is Familia_62_RS)
                            dalPermisos_62_RS.VincularFamiliaARol_62_RS(rolBase.Id_62_RS, permisoNuevo.Id_62_RS);
                        else
                            dalPermisos_62_RS.VincularPatenteARol_62_RS(rolBase.Id_62_RS, permisoNuevo.Id_62_RS);
                    }
                }

                string usuario = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS?.UsU_62_RS ?? "Sistema";
                bllBitacora_62_RS.InsertarBitacora_62_RS(usuario, Traducir("Bit_ConfigRol") + rolBase.Id_62_RS, "Administracion", "3");
            }
            catch (PermisoDuplicadoExcepcion_62_RS exDup)
            {
                throw new Exception(Traducir("Exc_Comp_PermisoDuplicado") + exDup.NombrePermiso_62_RS);
            }
            catch (OperacionInvalidaExcepcion_62_RS)
            {
                throw new Exception(Traducir("Exc_Comp_OperacionInvalida"));
            }
        }
    }
}
