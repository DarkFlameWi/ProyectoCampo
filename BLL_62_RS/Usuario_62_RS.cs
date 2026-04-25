using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_RS;
using SEG_62_RS.Singleton;
using SEG_62_RS;
using DAL_62_RS;
namespace BLL_62_RS
{
    public class Usuario_62_RS
    {
        BE_62_RS.Usuario_62_RS usuario_62_RS;
        DAL_62_RS.Usuario_62_RS usuarioDAL_62_RS;

        public string login_62_RS(string usu_62_RS, string password_62_RS)
        {
            if (SingletonSession_62_RS.Instancia_62_RS.EstaAutenticado_62_RS())
            {
                throw new Exception("Ya hay una sesión activa.");
            }
            else
            {
                //  SingletonSession_62_RS.Instancia_62_RS.IniciarSesion_62_RS(usu_62_RS); traer encriptado de la BD
                return "Inicio de sesión exitoso.";

            }
        }

        public void logout_62_RS()
        {
            if (!SingletonSession_62_RS.Instancia_62_RS.EstaAutenticado_62_RS())
            {
                throw new Exception("No hay una sesión activa.");
            }
            else
            {
                SingletonSession_62_RS.Instancia_62_RS.CerrarSesion_62_RS();
            }
        }

        public int AltaUsuario_62_RS(BE_62_RS.Usuario_62_RS user_62_RS)
        {
            try
            {
                user_62_RS.Activo_62_RS = true;
                user_62_RS.Estado_62_RS = false;
                user_62_RS.UsU_62_RS = user_62_RS.Nombre_62_RS + user_62_RS.Apellido_62_RS;
                string passProvisoria_62_RS = user_62_RS.DNI_62_RS + user_62_RS.Apellido_62_RS;
                user_62_RS.Password_62_RS = SEG_62_RS.Encriptacion_62_RS.EncriptarMD5_62_RS(passProvisoria_62_RS);
                return usuarioDAL_62_RS.AltaUsuario_62_RS(user_62_RS);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el usuario: " + ex.Message);
            }
        }
    }
}
