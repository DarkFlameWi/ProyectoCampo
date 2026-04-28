using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL_62_RS
{
    public class Accesos_62_RS
    {
        public SqlConnection Conexion = new SqlConnection();
        private SqlTransaction transaccion_62_RS;

        public void abrir()
        {
            //Notebook HORACIO
            Conexion.ConnectionString = @"Data Source=HORACIO;Initial Catalog=ProyectoCampo_62_RS;Integrated Security=True;TrustServerCertificate=True";

            //PC HORACIO
            //Conexion.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ProyectoCampo_62_RS;Integrated Security=True;TrustServerCertificate=True";
            //PC HANS
            //Conexion.ConnectionString = @"Data Source=DESKTOP-RG128MN;Initial Catalog=ProyectoCampo_62_RS;Integrated Security=True;TrustServerCertificate=True";

            try
            {
                Conexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexión: " + ex.Message);
            }
        }

        public void cerrar()
        {
            try
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }

        public int escribir(string consulta, SqlParameter[] param)
        {
            int filasafectadas = 0;

            abrir();

            try
            {
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        comando.Parameters.Add(p);
                    }
                    filasafectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                cerrar();
            }
            return filasafectadas;
        }

        public DataTable leer(string consulta, SqlParameter[] param)
        {
            DataTable dataTable = new DataTable();
            abrir();
            try
            {
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter p in param)
                    {
                        comando.Parameters.Add(p);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                cerrar();
            }
            return dataTable;

        }


        public int EscribirText(string query, SqlParameter[] parametros)
        {
            abrir();
            SqlCommand cmd = new SqlCommand(query, Conexion);
            cmd.CommandType = CommandType.Text;
            if (parametros != null) cmd.Parameters.AddRange(parametros);

            transaccion_62_RS = Conexion.BeginTransaction();
            cmd.Transaction = transaccion_62_RS;
            try
            {
                int filasafectadas_62_RS = cmd.ExecuteNonQuery();
                transaccion_62_RS.Commit();
                return filasafectadas_62_RS;
            }
            catch (Exception ex)
            {
                transaccion_62_RS.Rollback();
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                cerrar();
            }
        }
        public DataTable LeerText_62_RS(string consulta_62_RS, SqlParameter[] parametros_62_RS = null)
        {
            DataTable tabla_62_RS = new DataTable();
            abrir();

            try
            {
                using (SqlCommand cmd_62_RS = new SqlCommand(consulta_62_RS, Conexion))
                {
                    cmd_62_RS.CommandType = CommandType.Text;

                    if (parametros_62_RS != null)
                    {
                        cmd_62_RS.Parameters.AddRange(parametros_62_RS);
                    }

                    using (SqlDataAdapter adaptador_62_RS = new SqlDataAdapter(cmd_62_RS))
                    {
                        adaptador_62_RS.Fill(tabla_62_RS);
                    }
                }
                return tabla_62_RS;
            }
            catch (SqlException ex_62_RS)
            {
                throw new Exception("Error en la lectura de datos (SQL): " + ex_62_RS.Message);
            }
            finally
            {
                cerrar();
            }
        }
    }
}
