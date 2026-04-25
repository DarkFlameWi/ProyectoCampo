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

        public int insertarbitacora_62_RS(BE_62_RS.Bitacora_62_RS BT_62_RS)
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
        
    }
}
