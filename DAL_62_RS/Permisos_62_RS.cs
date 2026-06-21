using Microsoft.Data.SqlClient;
using SEG_62_RS.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL_62_RS
{
    public class Permisos_62_RS
    {
        public Accesos_62_RS accesos_62_RS = new Accesos_62_RS();
        // ROLES
        public int AltaRol_62_RS(string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                string sql = "INSERT INTO Roles_62_RS (Nombre_62_RS, Descripcion_62_RS) VALUES (@nom, @desc); SELECT SCOPE_IDENTITY();";
                SqlParameter[] p = { new SqlParameter("@nom", nombre_62_RS), new SqlParameter("@desc", descripcion_62_RS) };
                return accesos_62_RS.EscribirYDevolverId_62_RS(sql, p);
            }
            catch (Exception ex) { throw new Exception("Error al crear Rol: " + ex.Message); }
        }

        public int ContarUsuariosConRol_62_RS(int idRol_62_RS)
        {
            string sql = "SELECT COUNT(*) FROM Usuarios_62_RS WHERE IdRol_62_RS = @id";
            SqlParameter[] p = { new SqlParameter("@id", idRol_62_RS) };

            DataTable dt = accesos_62_RS.LeerText_62_RS(sql, p);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }

        public void BajaRol_62_RS(int idRol_62_RS)
        {
            try
            {
                string sql = @"
                    DELETE FROM Rol_Patente_62_RS WHERE IdRol_62_RS = @id;
                    DELETE FROM Rol_Familia_62_RS WHERE IdRol_62_RS = @id;
                    DELETE FROM Roles_62_RS WHERE IdRol_62_RS = @id;";

                SqlParameter[] p = { new SqlParameter("@id", idRol_62_RS) };
                accesos_62_RS.EscribirText_62_RS(sql, p);
            }
            catch (Exception ex) { throw new Exception("Error al eliminar físicamente el Rol: " + ex.Message); }
        }
        public void ActualizarDVH_Rol_62_RS(int idRol, int dvh)
        {
            string sql = "UPDATE Roles_62_RS SET Dvh_62_RS = @dvh WHERE IdRol_62_RS = @id";
            SqlParameter[] p = { new SqlParameter("@dvh", dvh), new SqlParameter("@id", idRol) };
            accesos_62_RS.EscribirText_62_RS(sql, p);
        }

        // familias
        public int AltaFamilia_62_RS(string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                string sql = "INSERT INTO Familias_62_RS (Nombre_62_RS, Descripcion_62_RS) VALUES (@nom, @desc); SELECT SCOPE_IDENTITY();";
                SqlParameter[] p = { new SqlParameter("@nom", nombre_62_RS), new SqlParameter("@desc", descripcion_62_RS) };
                return accesos_62_RS.EscribirYDevolverId_62_RS(sql, p);
            }
            catch (Exception ex) { throw new Exception("Error al crear Familia: " + ex.Message); }
        }

        public void BajaFamilia_62_RS(int idFamilia_62_RS)
        {
            try
            {
                string sql = @"
                    DELETE FROM Familia_Patente_62_RS WHERE IdFamilia_62_RS = @id;
                    DELETE FROM Familia_Familia_62_RS WHERE IdFamiliaPadre = @id OR IdFamiliaHija = @id;
                    DELETE FROM Rol_Familia_62_RS WHERE IdFamilia_62_RS = @id;
                    DELETE FROM Familias_62_RS WHERE IdFamilia_62_RS = @id;";

                SqlParameter[] p = { new SqlParameter("@id", idFamilia_62_RS) };
                accesos_62_RS.EscribirText_62_RS(sql, p);
            }
            catch (Exception ex) { throw new Exception("Error al eliminar físicamente la Familia: " + ex.Message); }
        }
        public void ActualizarDVH_Familia_62_RS(int idFamilia, int dvh)
        {
            string sql = "UPDATE Familias_62_RS SET Dvh_62_RS = @dvh WHERE IdFamilia_62_RS = @id";
            SqlParameter[] p = { new SqlParameter("@dvh", dvh), new SqlParameter("@id", idFamilia) };
            accesos_62_RS.EscribirText_62_RS(sql, p);
        }
        // RELACIONES
        public int VincularPatenteARol_62_RS(int idRol_62_RS, int idPatente_62_RS) =>
     accesos_62_RS.EscribirText_62_RS("INSERT INTO Rol_Patente_62_RS (IdRol_62_RS, IdPatente_62_RS) VALUES (@idRol, @idPat)", new[] { new SqlParameter("@idRol", idRol_62_RS), new SqlParameter("@idPat", idPatente_62_RS) });

        public int VincularFamiliaARol_62_RS(int idRol_62_RS, int idFamilia_62_RS) =>
            accesos_62_RS.EscribirText_62_RS("INSERT INTO Rol_Familia_62_RS (IdRol_62_RS, IdFamilia_62_RS) VALUES (@idRol, @idFam)", new[] { new SqlParameter("@idRol", idRol_62_RS), new SqlParameter("@idFam", idFamilia_62_RS) });

        public int VincularPatenteAFamilia_62_RS(int idFamilia_62_RS, int idPatente_62_RS) =>
            accesos_62_RS.EscribirText_62_RS("INSERT INTO Familia_Patente_62_RS (IdFamilia_62_RS, IdPatente_62_RS) VALUES (@idFam, @idPat)", new[] { new SqlParameter("@idFam", idFamilia_62_RS), new SqlParameter("@idPat", idPatente_62_RS) });

        public int VincularFamiliaAFamilia_62_RS(int idFamiliaPadre_62_RS, int idFamiliaHija_62_RS) =>
            accesos_62_RS.EscribirText_62_RS("INSERT INTO Familia_Familia_62_RS (IdFamiliaPadre, IdFamiliaHija) VALUES (@idPadre, @idHija)", new[] { new SqlParameter("@idPadre", idFamiliaPadre_62_RS), new SqlParameter("@idHija", idFamiliaHija_62_RS) });

        public int RevocarPatenteDeRol_62_RS(int idRol_62_RS, int idPatente_62_RS) =>
            accesos_62_RS.EscribirText_62_RS("DELETE FROM Rol_Patente_62_RS WHERE IdRol_62_RS = @idRol AND IdPatente_62_RS = @idPat", new[] { new SqlParameter("@idRol", idRol_62_RS), new SqlParameter("@idPat", idPatente_62_RS) });

        public int RevocarFamiliaDeRol_62_RS(int idRol_62_RS, int idFamilia_62_RS) =>
            accesos_62_RS.EscribirText_62_RS("DELETE FROM Rol_Familia_62_RS WHERE IdRol_62_RS = @idRol AND IdFamilia_62_RS = @idFam", new[] { new SqlParameter("@idRol", idRol_62_RS), new SqlParameter("@idFam", idFamilia_62_RS) });

        public int RevocarPatenteDeFamilia_62_RS(int idFamilia_62_RS, int idPatente_62_RS) =>
            accesos_62_RS.EscribirText_62_RS("DELETE FROM Familia_Patente_62_RS WHERE IdFamilia_62_RS = @idFam AND IdPatente_62_RS = @idPat", new[] { new SqlParameter("@idFam", idFamilia_62_RS), new SqlParameter("@idPat", idPatente_62_RS) });

        public int RevocarFamiliaDeFamilia_62_RS(int idFamiliaPadre_62_RS, int idFamiliaHija_62_RS) =>
            accesos_62_RS.EscribirText_62_RS("DELETE FROM Familia_Familia_62_RS WHERE IdFamiliaPadre = @idPadre AND IdFamiliaHija = @idHija", new[] { new SqlParameter("@idPadre", idFamiliaPadre_62_RS), new SqlParameter("@idHija", idFamiliaHija_62_RS) });
      
        
        // // LISTAS
        public DataTable ListarRolesBase_62_RS()
        {
            return accesos_62_RS.LeerText_62_RS("SELECT IdRol_62_RS, Nombre_62_RS, Descripcion_62_RS FROM Roles_62_RS");
        }
        public List<Patente_62_RS> ObtenerPatentes_62_RS()
        {
            var lista = new List<Patente_62_RS>();
            DataTable dt = accesos_62_RS.LeerText_62_RS("SELECT IdPatente_62_RS, Nombre_62_RS FROM Patentes_62_RS");

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Patente_62_RS(dr["Nombre_62_RS"].ToString()) { Id_62_RS = Convert.ToInt32(dr["IdPatente_62_RS"]) });
            }
            return lista;
        }

        public List<Familia_62_RS> ObtenerFamilias_62_RS()
        {
            var lista = new List<Familia_62_RS>();
            DataTable dtFam = accesos_62_RS.LeerText_62_RS("SELECT IdFamilia_62_RS FROM Familias_62_RS");

            foreach (DataRow drFam in dtFam.Rows)
            {
                Familia_62_RS familiaCompleta = ObtenerFamiliaPorId_62_RS(Convert.ToInt32(drFam["IdFamilia_62_RS"]));
                if (familiaCompleta != null) lista.Add(familiaCompleta);
            }
            return lista;
        }

        public Familia_62_RS ObtenerFamiliaPorId_62_RS(int idFamilia_62_RS)
        {
            DataTable dtFam = accesos_62_RS.LeerText_62_RS(
                            "SELECT Nombre_62_RS FROM Familias_62_RS WHERE IdFamilia_62_RS = @id",
                            new[] { new SqlParameter("@id", idFamilia_62_RS) });

            if (dtFam == null || dtFam.Rows.Count == 0) return null;

            var familia = new Familia_62_RS(dtFam.Rows[0]["Nombre_62_RS"].ToString()) { Id_62_RS = idFamilia_62_RS };

            string qPatentes = @"SELECT p.IdPatente_62_RS, p.Nombre_62_RS FROM Familia_Patente_62_RS fp
                                 INNER JOIN Patentes_62_RS p ON fp.IdPatente_62_RS = p.IdPatente_62_RS WHERE fp.IdFamilia_62_RS = @id";

            foreach (DataRow dr in accesos_62_RS.LeerText_62_RS(qPatentes, new[] { new SqlParameter("@id", idFamilia_62_RS) }).Rows)
            {
                familia.AgregarHijo_62_RS(new Patente_62_RS(dr["Nombre_62_RS"].ToString()) { Id_62_RS = Convert.ToInt32(dr["IdPatente_62_RS"]) });
            }
            string qFamilias = "SELECT IdFamiliaHija FROM Familia_Familia_62_RS WHERE IdFamiliaPadre = @id";
            foreach (DataRow dr in accesos_62_RS.LeerText_62_RS(qFamilias, new[] { new SqlParameter("@id", idFamilia_62_RS) }).Rows)
            {
                Familia_62_RS subFamilia = ObtenerFamiliaPorId_62_RS(Convert.ToInt32(dr["IdFamiliaHija"]));
                if (subFamilia != null) familia.AgregarHijo_62_RS(subFamilia);
            }

            return familia;
        }
        public Rol_62_RS ObtenerRolUsuario_62_RS(int idRol_62_RS)
        {
            DataTable dtRol = accesos_62_RS.LeerText_62_RS(
                "SELECT Nombre_62_RS FROM Roles_62_RS WHERE IdRol_62_RS = @id",
                new[] { new SqlParameter("@id", idRol_62_RS) });

            if (dtRol == null || dtRol.Rows.Count == 0) return null;

            var rol = new Rol_62_RS(dtRol.Rows[0]["Nombre_62_RS"].ToString()) { Id_62_RS = idRol_62_RS };
            string qPatentes = @"SELECT p.IdPatente_62_RS, p.Nombre_62_RS FROM Rol_Patente_62_RS rp
                                 INNER JOIN Patentes_62_RS p ON rp.IdPatente_62_RS = p.IdPatente_62_RS WHERE rp.IdRol_62_RS = @id";

            foreach (DataRow dr in accesos_62_RS.LeerText_62_RS(qPatentes, new[] { new SqlParameter("@id", idRol_62_RS) }).Rows)
            {
                rol.AgregarHijo_62_RS(new Patente_62_RS(dr["Nombre_62_RS"].ToString()) { Id_62_RS = Convert.ToInt32(dr["IdPatente_62_RS"]) });
            }
            string qFamilias = "SELECT IdFamilia_62_RS FROM Rol_Familia_62_RS WHERE IdRol_62_RS = @id";
            foreach (DataRow dr in accesos_62_RS.LeerText_62_RS(qFamilias, new[] { new SqlParameter("@id", idRol_62_RS) }).Rows)
            {
                Familia_62_RS fam = ObtenerFamiliaPorId_62_RS(Convert.ToInt32(dr["IdFamilia_62_RS"]));
                if (fam != null) rol.AgregarHijo_62_RS(fam);
            }

            return rol;
        }
    }
}
