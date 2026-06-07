using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace DAL_62_RS
{
    public class DVV_62_RS
    {
        private Accesos_62_RS accesos_62_RS = new Accesos_62_RS();

        public List<int> ObtenerTodosLosDVH_62_RS(string nombreTabla_62_RS)
        {
            List<int> listaDVH = new List<int>();
            try
            {

                string sql = $"SELECT Dvh_62_RS FROM [{nombreTabla_62_RS}] WHERE Dvh_62_RS IS NOT NULL";

                DataTable dt = accesos_62_RS.LeerText_62_RS(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    listaDVH.Add(Convert.ToInt32(dr["Dvh_62_RS"]));
                }

                return listaDVH;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener DVHs de la tabla {nombreTabla_62_RS}: {ex.Message}");
            }
        }
        public void ActualizarSumaDVV_62_RS(string nombreTabla_62_RS, int nuevoDvv_62_RS)
        {
            try
            {
                string sql = "UPDATE DVV_62_RS SET ValorDvv_62_RS = @dvv WHERE NombreTabla_62_RS = @tabla";
                SqlParameter[] p = {
                    new SqlParameter("@dvv", nuevoDvv_62_RS),
                    new SqlParameter("@tabla", nombreTabla_62_RS)
                };
                if (accesos_62_RS.EscribirText_62_RS(sql, p) == 0)
                {
                    string sqlInsert = "INSERT INTO DVV_62_RS (NombreTabla_62_RS, ValorDvv_62_RS) VALUES (@tabla, @dvv)";
                    accesos_62_RS.EscribirText_62_RS(sqlInsert, p);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la tabla DVV: " + ex.Message);
            }
        }
    }
}
