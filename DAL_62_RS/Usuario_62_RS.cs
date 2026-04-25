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
    public class Usuario_62_RS
    {
        public Accesos_62_RS accesos_62_RS = new Accesos_62_RS();
        public int AltaUsuario_62_RS(BE_62_RS.Usuario_62_RS user_62_RS)
        {
            string sql_62_RS = @"INSERT INTO [Usuarios_62_RS] 
                       (IdIdioma_62_RS, nombre_62_RS, apellido_62_RS, email_62_RS, 
                        dni_62_RS, usu_62_RS, password_62_RS, estado_62_RS, Activo_62_RS) 
                       VALUES 
                       (@idIdioma, @nom, @ape, @mail, @dni, @usu, @pass, @est, @act)";

            SqlParameter[] parametros_62_RS = {
                // Suponiendo idioma 1 por defecto, o puedes agregarlo a BE.Usuario
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
            return accesos_62_RS.EscribirText(sql_62_RS, parametros_62_RS);
        }
    }
}
