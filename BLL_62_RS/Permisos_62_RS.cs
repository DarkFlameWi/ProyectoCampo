using DAL_62_RS;
using SEG_62_RS.Composite;
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
        public void GuardarFamilia_62_RS(int id_62_RS, string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre_62_RS))
                    throw new Exception(Traducir("Exc_BLL_NombreVacio"));

                if (id_62_RS == 0) // Es un Alta
                {
                    dalPermisos_62_RS.AltaFamilia_62_RS(nombre_62_RS, descripcion_62_RS);
                    bllBitacora_62_RS.InsertarBitacora_62_RS(SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS, "Alta de Familia: " + nombre_62_RS, "Permisos", "2");
                }
                else // Es una Modificación
                {
                    dalPermisos_62_RS.ModificarFamilia_62_RS(id_62_RS, nombre_62_RS, descripcion_62_RS);
                    bllBitacora_62_RS.InsertarBitacora_62_RS(SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS, "Modificación de Familia: " + nombre_62_RS, "Permisos", "2");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorFam") + ex.Message);
            }
        }

        public void ConfigurarFamilia_62_RS(Familia_62_RS familiaBase, List<Patente_62_RS> patentesAAsignar)
        {
            try
            {
                Familia_62_RS familiaTemp = new Familia_62_RS(familiaBase.Nombre_62_RS) { Id_62_RS = familiaBase.Id_62_RS };

                foreach (var patente in patentesAAsignar)
                {
                    familiaTemp.AgregarHijo_62_RS(patente);
                }

                dalPermisos_62_RS.LimpiarPatentesDeFamilia_62_RS(familiaBase.Id_62_RS);

                foreach (var patente in patentesAAsignar)
                {
                    dalPermisos_62_RS.VincularPatenteAFamilia_62_RS(familiaBase.Id_62_RS, patente.Id_62_RS);
                }

                bllBitacora_62_RS.InsertarBitacora_62_RS(SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS, Traducir("Bit_ConfigFam") + familiaBase.Id_62_RS, "Permisos", "3");
            }
            catch (Exception ex)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorConfigFam") + ex.Message);
            }
        }

        public void GuardarRol_62_RS(int id_62_RS, string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre_62_RS))
                    throw new Exception(Traducir("Exc_BLL_NombreVacio"));

                if (id_62_RS == 0) // Alta
                {
                    dalPermisos_62_RS.AltaRol_62_RS(nombre_62_RS, descripcion_62_RS);
                    bllBitacora_62_RS.InsertarBitacora_62_RS(SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS, "Alta de Rol: " + nombre_62_RS, "Permisos", "2");
                }
                else // Modificación
                {
                    dalPermisos_62_RS.ModificarRol_62_RS(id_62_RS, nombre_62_RS, descripcion_62_RS);
                    bllBitacora_62_RS.InsertarBitacora_62_RS(SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS, "Modificación de Rol: " + nombre_62_RS, "Permisos", "2");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorRol") + ex.Message);
            }
        }

        public void ConfigurarRol_62_RS(Rol_62_RS rolBase, List<Permiso_62_RS> permisosAAsignar)
        {
            try
            {
                Rol_62_RS rolTemp = new Rol_62_RS(rolBase.Nombre_62_RS) { Id_62_RS = rolBase.Id_62_RS };

                foreach (var permiso in permisosAAsignar)
                {
                    rolTemp.AgregarHijo_62_RS(permiso);
                }
                dalPermisos_62_RS.LimpiarFamiliasDeRol_62_RS(rolBase.Id_62_RS);
                dalPermisos_62_RS.LimpiarPatentesDeRol_62_RS(rolBase.Id_62_RS);
                foreach (var permiso in permisosAAsignar)
                {
                    if (permiso is Familia_62_RS)
                    {
                        dalPermisos_62_RS.VincularFamiliaARol_62_RS(rolBase.Id_62_RS, permiso.Id_62_RS);
                    }
                    else if (permiso is Patente_62_RS)
                    {
                        dalPermisos_62_RS.VincularPatenteARol_62_RS(rolBase.Id_62_RS, permiso.Id_62_RS);
                    }
                }
                bllBitacora_62_RS.InsertarBitacora_62_RS(SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS, Traducir("Bit_ConfigRol") + rolBase.Id_62_RS, "Permisos", "3");
            }
            catch (Exception ex)
            {
                throw new Exception(Traducir("Exc_BLL_ErrorConfigRol") + ex.Message);
            }
        }

    }
}
