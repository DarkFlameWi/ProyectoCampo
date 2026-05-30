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
        public int AltaFamilia_62_RS(string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                string sql_62_RS = "INSERT INTO Familias_62_RS (Nombre_62_RS, Descripcion_62_RS) VALUES (@nom, @desc)";
                SqlParameter[] p_62_RS = {
                    new SqlParameter("@nom", nombre_62_RS),
                    new SqlParameter("@desc", descripcion_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error técnico en DAL al crear Familia: " + ex_62_RS.Message);
            }
        }

        public int ModificarFamilia_62_RS(int idFamilia_62_RS, string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                string sql_62_RS = "UPDATE Familias_62_RS SET Nombre_62_RS = @nom, Descripcion_62_RS = @desc WHERE IdFamilia_62_RS = @id";
                SqlParameter[] p_62_RS = {
                    new SqlParameter("@nom", nombre_62_RS),
                    new SqlParameter("@desc", descripcion_62_RS),
                    new SqlParameter("@id", idFamilia_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error técnico en DAL al modificar Familia: " + ex_62_RS.Message);
            }
        }
        public int LimpiarPatentesDeFamilia_62_RS(int idFamilia_62_RS)
        {
            try
            {
                string sql_62_RS = "DELETE FROM Familia_Patente_62_RS WHERE IdFamilia_62_RS = @id";
                SqlParameter[] p_62_RS = { new SqlParameter("@id", idFamilia_62_RS) };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS) { throw new Exception("Error al limpiar patentes de la familia: " + ex_62_RS.Message); }
        }

        public int VincularPatenteAFamilia_62_RS(int idFamilia_62_RS, int idPatente_62_RS)
        {
            try
            {
                string sql_62_RS = "INSERT INTO Familia_Patente_62_RS (IdFamilia_62_RS, IdPatente_62_RS) VALUES (@idFam, @idPat)";
                SqlParameter[] p_62_RS = {
                    new SqlParameter("@idFam", idFamilia_62_RS),
                    new SqlParameter("@idPat", idPatente_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS) { throw new Exception("Error al vincular patente a familia: " + ex_62_RS.Message); }
        }

        public int AltaRol_62_RS(string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                string sql_62_RS = "INSERT INTO Roles_62_RS (Nombre_62_RS, Descripcion_62_RS) VALUES (@nom, @desc)";
                SqlParameter[] p_62_RS = {
                    new SqlParameter("@nom", nombre_62_RS),
                    new SqlParameter("@desc", descripcion_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error técnico en DAL al crear Rol: " + ex_62_RS.Message);
            }
        }
        public int ModificarRol_62_RS(int idRol_62_RS, string nombre_62_RS, string descripcion_62_RS)
        {
            try
            {
                string sql_62_RS = "UPDATE Roles_62_RS SET Nombre_62_RS = @nom, Descripcion_62_RS = @desc WHERE IdRol_62_RS = @id";
                SqlParameter[] p_62_RS = {
                    new SqlParameter("@nom", nombre_62_RS),
                    new SqlParameter("@desc", descripcion_62_RS),
                    new SqlParameter("@id", idRol_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error técnico en DAL al modificar Rol: " + ex_62_RS.Message);
            }
        }
        public int LimpiarFamiliasDeRol_62_RS(int idRol_62_RS)
        {
            try
            {
                string sql_62_RS = "DELETE FROM Rol_Familia_62_RS WHERE IdRol_62_RS = @id";
                SqlParameter[] p_62_RS = { new SqlParameter("@id", idRol_62_RS) };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS) { throw new Exception("Error al limpiar familias del rol: " + ex_62_RS.Message); }
        }

        public int VincularFamiliaARol_62_RS(int idRol_62_RS, int idFamilia_62_RS)
        {
            try
            {
                string sql_62_RS = "INSERT INTO Rol_Familia_62_RS (IdRol_62_RS, IdFamilia_62_RS) VALUES (@idRol, @idFam)";
                SqlParameter[] p_62_RS = {
                    new SqlParameter("@idRol", idRol_62_RS),
                    new SqlParameter("@idFam", idFamilia_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS) { throw new Exception("Error al vincular familia a rol: " + ex_62_RS.Message); }
        }
        public int LimpiarPatentesDeRol_62_RS(int idRol_62_RS)
        {
            try
            {
                string sql_62_RS = "DELETE FROM Rol_Patente_62_RS WHERE IdRol_62_RS = @id";
                SqlParameter[] p_62_RS = { new SqlParameter("@id", idRol_62_RS) };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS) { throw new Exception("Error al limpiar patentes del rol: " + ex_62_RS.Message); }
        }
        public int VincularPatenteARol_62_RS(int idRol_62_RS, int idPatente_62_RS)
        {
            try
            {
                string sql_62_RS = "INSERT INTO Rol_Patente_62_RS (IdRol_62_RS, IdPatente_62_RS) VALUES (@idRol, @idPat)";
                SqlParameter[] p_62_RS = {
                    new SqlParameter("@idRol", idRol_62_RS),
                    new SqlParameter("@idPat", idPatente_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS) { throw new Exception("Error al vincular patente a rol: " + ex_62_RS.Message); }
        }

        public List<Patente_62_RS> ObtenerPatentes_62_RS()
        {
            List<Patente_62_RS> lista_62_RS = new List<Patente_62_RS>();
            try
            {
                string query = "SELECT IdPatente_62_RS, Nombre_62_RS FROM Patentes_62_RS";
                DataTable dt = accesos_62_RS.LeerText_62_RS(query);

                foreach (DataRow dr in dt.Rows)
                {
                    var patente = new Patente_62_RS(dr["Nombre_62_RS"].ToString())
                    {
                        Id_62_RS = Convert.ToInt32(dr["IdPatente_62_RS"])
                    };
                    lista_62_RS.Add(patente);
                }
                return lista_62_RS;
            }
            catch (Exception ex) { throw new Exception("Error al obtener patentes: " + ex.Message); }
        }

        public List<Familia_62_RS> ObtenerFamilias_62_RS()
        {
            List<Familia_62_RS> lista_62_RS = new List<Familia_62_RS>();
            try
            {
                string queryFam = "SELECT IdFamilia_62_RS, Nombre_62_RS FROM Familias_62_RS";
                DataTable dtFam = accesos_62_RS.LeerText_62_RS(queryFam);

                foreach (DataRow drFam in dtFam.Rows)
                {
                    var familia = new Familia_62_RS(drFam["Nombre_62_RS"].ToString())
                    {
                        Id_62_RS = Convert.ToInt32(drFam["IdFamilia_62_RS"])
                    };
                    string queryPat = @"SELECT p.IdPatente_62_RS, p.Nombre_62_RS 
                                       FROM Familia_Patente_62_RS fp
                                       INNER JOIN Patentes_62_RS p ON fp.IdPatente_62_RS = p.IdPatente_62_RS
                                       WHERE fp.IdFamilia_62_RS = @idFam";

                    SqlParameter[] p_62_RS = { new SqlParameter("@idFam", familia.Id_62_RS) };
                    DataTable dtPat = accesos_62_RS.LeerText_62_RS(queryPat, p_62_RS);
                    foreach (DataRow drPat in dtPat.Rows)
                    {
                        var patenteHija = new Patente_62_RS(drPat["Nombre_62_RS"].ToString())
                        {
                            Id_62_RS = Convert.ToInt32(drPat["IdPatente_62_RS"])
                        };
                        familia.AgregarHijo_62_RS(patenteHija);
                    }

                    lista_62_RS.Add(familia);
                }
                return lista_62_RS;
            }
            catch (Exception ex) { throw new Exception("Error al obtener familias: " + ex.Message); }
        }

        public Rol_62_RS ObtenerRolUsuario_62_RS(int idRol_62_RS)
        {
            try
            {
                string queryRol = "SELECT Nombre_62_RS FROM Roles_62_RS WHERE IdRol_62_RS = @idRol";
                SqlParameter[] pRol = { new SqlParameter("@idRol", idRol_62_RS) };
                DataTable dtRol = accesos_62_RS.LeerText_62_RS(queryRol, pRol);

                if (dtRol == null || dtRol.Rows.Count == 0) return null;

                var rolCompleto = new Rol_62_RS(dtRol.Rows[0]["Nombre_62_RS"].ToString())
                {
                    Id_62_RS = idRol_62_RS
                };
                string queryPatDirectas = @"SELECT p.IdPatente_62_RS, p.Nombre_62_RS 
                                           FROM Rol_Patente_62_RS rp
                                           INNER JOIN Patentes_62_RS p ON rp.IdPatente_62_RS = p.IdPatente_62_RS
                                           WHERE rp.IdRol_62_RS = @idRol";

                DataTable dtPat = accesos_62_RS.LeerText_62_RS(queryPatDirectas, pRol);
                foreach (DataRow drPat in dtPat.Rows)
                {
                    var patenteDirecta = new Patente_62_RS(drPat["Nombre_62_RS"].ToString())
                    {
                        Id_62_RS = Convert.ToInt32(drPat["IdPatente_62_RS"])
                    };
                    rolCompleto.AgregarHijo_62_RS(patenteDirecta);
                }
                string queryFamDelRol = @"SELECT f.IdFamilia_62_RS, f.Nombre_62_RS 
                                         FROM Rol_Familia_62_RS rf
                                         INNER JOIN Familias_62_RS f ON rf.IdFamilia_62_RS = f.IdFamilia_62_RS
                                         WHERE rf.IdRol_62_RS = @idRol";

                DataTable dtFam = accesos_62_RS.LeerText_62_RS(queryFamDelRol, pRol);
                foreach (DataRow drFam in dtFam.Rows)
                {
                    int idFamilia = Convert.ToInt32(drFam["IdFamilia_62_RS"]);
                    Familia_62_RS familiaCargada = ObtenerFamiliaPorId_62_RS(idFamilia);

                    if (familiaCargada != null)
                    {
                        rolCompleto.AgregarHijo_62_RS(familiaCargada);
                    }
                }

                return rolCompleto;
            }
            catch (Exception ex) { throw new Exception("Error al armar el árbol de permisos del rol: " + ex.Message); }
        }

        private Familia_62_RS ObtenerFamiliaPorId_62_RS(int idFamilia_62_RS)
        {
            string queryFam = "SELECT Nombre_62_RS FROM Familias_62_RS WHERE IdFamilia_62_RS = @id";
            SqlParameter[] p = { new SqlParameter("@id", idFamilia_62_RS) };
            DataTable dtFam = accesos_62_RS.LeerText_62_RS(queryFam, p);

            if (dtFam == null || dtFam.Rows.Count == 0) return null;

            var familia = new Familia_62_RS(dtFam.Rows[0]["Nombre_62_RS"].ToString())
            {
                Id_62_RS = idFamilia_62_RS
            };

            string queryPat = @"SELECT p.IdPatente_62_RS, p.Nombre_62_RS 
                               FROM Familia_Patente_62_RS fp
                               INNER JOIN Patentes_62_RS p ON fp.IdPatente_62_RS = p.IdPatente_62_RS
                               WHERE fp.IdFamilia_62_RS = @id";

            DataTable dtPat = accesos_62_RS.LeerText_62_RS(queryPat, p);
            foreach (DataRow drPat in dtPat.Rows)
            {
                var patenteHija = new Patente_62_RS(drPat["Nombre_62_RS"].ToString())
                {
                    Id_62_RS = Convert.ToInt32(drPat["IdPatente_62_RS"])
                };
                familia.AgregarHijo_62_RS(patenteHija);
            }

            return familia;
        }
        public DataTable ListarRolesBase_62_RS()
        {
            try
            {
                string query = "SELECT IdRol_62_RS, Nombre_62_RS, Descripcion_62_RS FROM Roles_62_RS";
                return accesos_62_RS.LeerText_62_RS(query);
            }
            catch (Exception ex) { throw new Exception("Error al listar roles: " + ex.Message); }
        }
    }
}
