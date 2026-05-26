using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using SEG_62_RS;

namespace DAL_62_RS
{
    public class Usuario_62_RS
    {
        public Accesos_62_RS accesos_62_RS = new Accesos_62_RS();
        public int AltaUsuario_62_RS(SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            string sql_62_RS = null;
            try
            {
                sql_62_RS = @"INSERT INTO [Usuarios_62_RS] 
                       (IdIdioma_62_RS, nombre_62_RS, apellido_62_RS, email_62_RS, 
                        dni_62_RS, usu_62_RS, password_62_RS, estado_62_RS, Activo_62_RS) 
                       VALUES 
                       (@idIdioma, @nom, @ape, @mail, @dni, @usu, @pass, @est, @act)";

                SqlParameter[] parametros_62_RS = {
                new SqlParameter("@idIdioma", 1),
                new SqlParameter("@nom", user_62_RS.Nombre_62_RS),
                new SqlParameter("@ape", user_62_RS.Apellido_62_RS),
                new SqlParameter("@mail", user_62_RS.Email_62_RS),
                new SqlParameter("@dni", user_62_RS.DNI_62_RS),
                new SqlParameter("@usu", user_62_RS.UsU_62_RS),
                new SqlParameter("@pass", user_62_RS.Password_62_RS),
                new SqlParameter("@est", user_62_RS.Estado_62_RS),
                new SqlParameter("@act", user_62_RS.Activo_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, parametros_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error técnico en DAL al modificar: " + ex_62_RS.Message);
            }
        }

        public int Verificar_62_RS(SEG_62_RS.Usuario_62_RS user_62_RS, int tipo)
        {
            try
            {
                string sql_62_RS = null;
                if (tipo == 1)
                {
                    //EXISTENCIA
                    sql_62_RS = @"SELECT COUNT(*) FROM Usuarios_62_RS WHERE dni_62_RS = @dni";
                }
                if (tipo == 2)
                {
                    //BLOQUEO
                    sql_62_RS = @"SELECT COUNT(*) FROM Usuarios_62_RS WHERE dni_62_RS = @dni AND estado_62_RS = 1";
                }
                SqlParameter[] parametros_62_RS = {
                new SqlParameter("@dni", user_62_RS.DNI_62_RS),
                };
                return accesos_62_RS.Verificar_62_RS(sql_62_RS, parametros_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error técnico en DAL al modificar: " + ex_62_RS.Message);
            }
        }

        public int ModificarDatos_62_RS(SEG_62_RS.Usuario_62_RS user_62_RS)
        {
            try
            {
                string sql_62_RS = @"UPDATE [Usuarios_62_RS] 
                                SET nombre_62_RS = @nom, apellido_62_RS = @ape, email_62_RS = @mail, usu_62_RS = @usu 
                                WHERE idusuario_62_RS = @id";
                SqlParameter[] parametros_62_RS = {
                new SqlParameter("@nom", user_62_RS.Nombre_62_RS),
                new SqlParameter("@ape", user_62_RS.Apellido_62_RS),
                new SqlParameter("@mail", user_62_RS.Email_62_RS),
                new SqlParameter("@usu", user_62_RS.UsU_62_RS),
                new SqlParameter("@id", user_62_RS.IdUsuario_62_RS)
            };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, parametros_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception("Error técnico en DAL al modificar: " + ex_62_RS.Message);
            }
        }

        public int ModificarEstado_62_RS(int user_62_RS, string col_62_RS, int val_62_RS)
        {
            try
            {
                string sql_62_RS = $"UPDATE [Usuarios_62_RS] SET {col_62_RS} = @v WHERE idusuario_62_RS = @id";
                SqlParameter[] p_62_RS = {
                new SqlParameter("@v", val_62_RS),
                new SqlParameter("@id", user_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
            }
            catch (Exception ex_62_RS)
            {
                throw new Exception($"Error técnico en DAL al actualizar {col_62_RS}: " + ex_62_RS.Message);
            }
        }

        public int ModificarBit_62_RS(int id_62_RS, string columna_62_RS, int valor_62_RS)
        {
            string sql_62_RS = $"UPDATE [Usuarios_62_RS] SET {columna_62_RS} = @val WHERE idusuario_62_RS = @id";
            SqlParameter[] p_62_RS = {
            new SqlParameter("@val", valor_62_RS),
            new SqlParameter("@id", id_62_RS)
        };
            return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
        }

        public DataTable ListarUsuarios_62_RS(int tipousuario)
        {
            try
            {
                string query_62_RS = null;
                if (tipousuario == 0)
                {
                    query_62_RS = "SELECT idusuario_62_RS, IdIdioma_62_RS, nombre_62_RS, apellido_62_RS, email_62_RS, dni_62_RS, usu_62_RS, estado_62_RS, Activo_62_RS FROM Usuarios_62_RS";

                }
                if (tipousuario == 1)
                {
                    query_62_RS = "SELECT idusuario_62_RS, IdIdioma_62_RS, nombre_62_RS, apellido_62_RS, email_62_RS, dni_62_RS, usu_62_RS, estado_62_RS, Activo_62_RS FROM Usuarios_62_RS WHERE Activo_62_RS = 1";
                }
                return accesos_62_RS.LeerText_62_RS(query_62_RS);
            }
            catch (SqlException ex_62_RS)
            {
                throw new Exception("Error técnico en la base de datos al intentar listar usuarios. Detalle: " + ex_62_RS.Message);
            }
        }
        public SEG_62_RS.Usuario_62_RS ValidarAcceso_62_RS(string user_62_RS, string pass_62_RS)
        {
            try
            {
                string query_62_RS = "SELECT * FROM Usuarios_62_RS WHERE usu_62_RS = @u AND password_62_RS = @p";
                SqlParameter[] p_62_RS = {
            new SqlParameter("@u", user_62_RS),
            new SqlParameter("@p", pass_62_RS)
        };

                DataTable dt_62_RS = accesos_62_RS.LeerText_62_RS(query_62_RS, p_62_RS);

                if (dt_62_RS != null && dt_62_RS.Rows.Count > 0)
                {
                    DataRow dr_62_RS = dt_62_RS.Rows[0];
                    return new SEG_62_RS.Usuario_62_RS
                    {
                        IdUsuario_62_RS = Convert.ToInt32(dr_62_RS["idusuario_62_RS"]),
                        Nombre_62_RS = dr_62_RS["nombre_62_RS"].ToString(),
                        Apellido_62_RS = dr_62_RS["apellido_62_RS"].ToString(),
                        Email_62_RS = dr_62_RS["email_62_RS"].ToString(),
                        UsU_62_RS = dr_62_RS["usu_62_RS"].ToString(),
                        Password_62_RS = dr_62_RS["password_62_RS"].ToString(),
                        DNI_62_RS = dr_62_RS["dni_62_RS"].ToString(),
                        Estado_62_RS = Convert.ToBoolean(dr_62_RS["estado_62_RS"]),
                        Activo_62_RS = Convert.ToBoolean(dr_62_RS["Activo_62_RS"]),
                        IdIdioma = Convert.ToInt32(dr_62_RS["IdIdioma_62_RS"])
                    };
                }
                return null;
            }
            catch (Exception ex_62_RS) { throw new Exception("Error en DAL: " + ex_62_RS.Message); }
        }

        public void BloquearUsuario_62_RS(string usu_62_RS)
        {
            string sql = "UPDATE Usuarios_62_RS SET estado_62_RS = @est WHERE usu_62_RS = @u";
            SqlParameter[] p = {
        new SqlParameter("@est", true),
        new SqlParameter("@u", usu_62_RS)
    };
            accesos_62_RS.EscribirText_62_RS(sql, p);
        }

        public int ActualizarClave_62_RS(string usu_62_RS, string nuevaClave_62_RS)
        {
            try
            {
                string sql_62_RS = "UPDATE Usuarios_62_RS SET password_62_RS = @pass WHERE usu_62_RS = @usu";
                SqlParameter[] p_62_RS = { 
                    new SqlParameter("@usu", usu_62_RS),
                    new SqlParameter("@pass", nuevaClave_62_RS)
                };
                return accesos_62_RS.EscribirText_62_RS(sql_62_RS, p_62_RS);
                
            }
            catch (Exception ex) { throw ex; }
        }
    }


}

