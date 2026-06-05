using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace DAL_62_RS
{
    public class BackupRestore_62_RS
    {
        private string cnnBase_62_RS = @"Data Source=.\SQLEXPRESS;Initial Catalog=ProyectoCampo_62_RS;Integrated Security=True;TrustServerCertificate=True";
        private string cnnMaster_62_RS = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";
        public void GenerarBackup_62_RS(string rutaCompleta_62_RS)
        {            string query_62_RS = "BACKUP DATABASE [ProyectoCampo_62_RS] TO DISK = @ruta WITH NOFORMAT, NOINIT, NAME = N'Backup-Completo', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

            using (SqlConnection conexion_62_RS = new SqlConnection(cnnBase_62_RS))
            {
                using (SqlCommand comando_62_RS = new SqlCommand(query_62_RS, conexion_62_RS))
                {
                    comando_62_RS.Parameters.AddWithValue("@ruta", rutaCompleta_62_RS);
                    conexion_62_RS.Open();
                    comando_62_RS.ExecuteNonQuery();
                }
            }
        }
        public void GenerarRestore_62_RS(string rutaBackup_62_RS)
        {
            using (SqlConnection conexionMaster_62_RS = new SqlConnection(cnnMaster_62_RS))
            {
                conexionMaster_62_RS.Open();
                string sqlSingleUser_62_RS = "ALTER DATABASE [ProyectoCampo_62_RS] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                using (SqlCommand cmdSingle_62_RS = new SqlCommand(sqlSingleUser_62_RS, conexionMaster_62_RS))
                {
                    cmdSingle_62_RS.ExecuteNonQuery();
                }
                string sqlRestore_62_RS = "RESTORE DATABASE [ProyectoCampo_62_RS] FROM DISK = @ruta WITH REPLACE";
                using (SqlCommand cmdRestore_62_RS = new SqlCommand(sqlRestore_62_RS, conexionMaster_62_RS))
                {
                    cmdRestore_62_RS.Parameters.AddWithValue("@ruta", rutaBackup_62_RS);
                    cmdRestore_62_RS.ExecuteNonQuery();
                }
                string sqlMultiUser_62_RS = "ALTER DATABASE [ProyectoCampo_62_RS] SET MULTI_USER";
                using (SqlCommand cmdMulti_62_RS = new SqlCommand(sqlMultiUser_62_RS, conexionMaster_62_RS))
                {
                    cmdMulti_62_RS.ExecuteNonQuery();
                }
            }
        }

    }
}
