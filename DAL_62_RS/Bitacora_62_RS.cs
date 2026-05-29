using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using SEG_62_RS.Singleton;
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
            FA = accesos_62_RS.escribir_62_RS("CargarBitacora_62_RS", sqlParameter);
            return FA;
        }

        public DataTable ListarBitacora_62_RS()
        {
            try
            {
                string query_62_RS = " SELECT b.IdBitacora_62_RS, b.Usu_62_RS, CONVERT(varchar(10), b.FechaCambio_62_RS, 120) AS Fecha_62_RS, CONVERT(varchar(8), b.FechaCambio_62_RS, 108) AS Hora_62_RS, b.Descripcion_62_RS, b.Modulo_62_RS, b.Criticidad_62_RS, u.Nombre_62_RS, u.Apellido_62_RS FROM Bitacora_62_RS b  INNER JOIN Usuarios_62_RS u ON b.Usu_62_RS = u.usu_62_RS WHERE b.FechaCambio_62_RS >= GETDATE() - 3 order by FechaCambio_62_RS desc";
                return accesos_62_RS.LeerText_62_RS(query_62_RS);
            }
            catch (SqlException ex_62_RS)
            {
                string msjListar = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS["Exc_DAL_ErrorListarBitacora"];
                throw new Exception(msjListar + ex_62_RS.Message);
            }
        }

        public DataTable FiltrarBitacora_62_RS(string login, string modulo, string evento, string criticidad, DateTime desde, DateTime hasta)
        {
            try
            {
                DateTime fechaDesde = desde.Date;
                DateTime fechaHasta = hasta.Date.AddDays(1).AddTicks(-1);
                string query_62_RS = @"SELECT b.IdBitacora_62_RS, b.Usu_62_RS, CONVERT(varchar(10), b.FechaCambio_62_RS, 120) AS Fecha_62_RS,
                                              CONVERT(varchar(8), b.FechaCambio_62_RS, 108) AS Hora_62_RS, 
                                              b.Descripcion_62_RS, b.Modulo_62_RS, b.Criticidad_62_RS, 
                                              u.Nombre_62_RS, u.Apellido_62_RS 
                                       FROM Bitacora_62_RS b 
                                       INNER JOIN Usuarios_62_RS u ON b.Usu_62_RS = u.usu_62_RS 
                                       WHERE b.FechaCambio_62_RS BETWEEN @Desde AND @Hasta";

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Desde", fechaDesde),
                    new SqlParameter("@Hasta", fechaHasta)
                };

                if (login != "Todos" && !string.IsNullOrEmpty(login))
                {
                    query_62_RS += " AND b.Usu_62_RS = @Login";
                    parametros.Add(new SqlParameter("@Login", login));
                }

                if (modulo != "Todos" && !string.IsNullOrEmpty(modulo))
                {
                    query_62_RS += " AND b.Modulo_62_RS = @Modulo";
                    parametros.Add(new SqlParameter("@Modulo", modulo));
                }

                if (evento != "Todos" && !string.IsNullOrEmpty(evento))
                {
                    query_62_RS += " AND b.Descripcion_62_RS = @Evento";
                    parametros.Add(new SqlParameter("@Evento", evento));
                }

                if (criticidad != "Todos" && !string.IsNullOrEmpty(criticidad))
                {
                    query_62_RS += " AND b.Criticidad_62_RS = @Criticidad";
                    parametros.Add(new SqlParameter("@Criticidad", criticidad));
                }
                return accesos_62_RS.LeerText_62_RS(query_62_RS, parametros.ToArray());
            }
            catch (SqlException ex_62_RS)
            {
                string msjFiltrar = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS["Exc_DAL_ErrorFiltrarBitacora"];
                throw new Exception(msjFiltrar + ex_62_RS.Message);
            }
        }
    }
}
