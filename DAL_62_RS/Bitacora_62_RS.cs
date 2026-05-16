using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
namespace DAL_62_RS
{
    public class Bitacora_62_RS
    {
        public Accesos_62_RS accesos_62_RS = new Accesos_62_RS();

        public int insertarbitacora_62_RS(SEG_62_RS.Bitacora_62_RS BT_62_RS)
        {
            int FA = 0;

            SqlParameter[] sqlParameter = new SqlParameter[5];
            sqlParameter[0] = new SqlParameter("@Usu_62_RS", BT_62_RS.Usu_62_RS);
            sqlParameter[1] = new SqlParameter("@FechaCambio_62_RS",BT_62_RS.FechaCambio_62_RS);
            sqlParameter[2] = new SqlParameter("@Descripcion_62_RS", BT_62_RS.Descripcion_62_RS);
            sqlParameter[3] = new SqlParameter("@Modulo_62_RS",BT_62_RS.Modulo_62_RS);
            sqlParameter[4] = new SqlParameter("@Criticidad_62_RS", BT_62_RS.Criticidad_62_RS);
            FA = accesos_62_RS.escribir("CargarBitacora_62_RS", sqlParameter);
            return FA;
        }

        public DataTable ListarBitacora_62_RS()
        {
            try
            {
                string query_62_RS = "SELECT IdBitacora_62_RS, Usu_62_RS, FechaCambio_62_RS, Descripcion_62_RS, Modulo_62_RS, Criticidad_62_RS FROM Bitacora_62_RS";
                return accesos_62_RS.LeerText_62_RS(query_62_RS);
            }
            catch (SqlException ex_62_RS)
            {
                throw new Exception("Error técnico en la base de datos al intentar listar usuarios. Detalle: " + ex_62_RS.Message);
            }
        }
    }
}
