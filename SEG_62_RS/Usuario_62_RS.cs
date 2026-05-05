using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_RS
{
    public class Usuario_62_RS:Iusuario_62_RS
    {
		private int idusuario_62_RS;
		public int IdUsuario_62_RS
        {
			get { return idusuario_62_RS; }
			set { idusuario_62_RS = value; }
		}

		private int ididioma;
		public int IdIdioma
		{
			get { return ididioma; }
			set { ididioma = value; }
		}

		private string dni_62_RS;
		public string DNI_62_RS
        {
			get { return dni_62_RS; }
			set { dni_62_RS = value; }
		}

		private string nombre_62_RS;
		public string Nombre_62_RS
        {
			get { return nombre_62_RS; }
			set { nombre_62_RS = value; }
		}

		private string apellido_62_RS;
		public string Apellido_62_RS
        {
			get { return apellido_62_RS; }
			set { apellido_62_RS = value; }
		}
		
		private string email_62_RS;
		public string Email_62_RS
        {
			get { return email_62_RS; }
			set { email_62_RS = value; }
		}
		
		private bool activo_62_RS;
		public bool Activo_62_RS
        {
			get { return activo_62_RS; }
			set { activo_62_RS = value; }
		}
		
		private bool estado_62_RS;
		public bool Estado_62_RS
        {
			get { return estado_62_RS; }
			set { estado_62_RS = value; }
		}

		private string usu_62_RS;
		public string UsU_62_RS
        {
			get { return usu_62_RS; }
			set { usu_62_RS = value; }
		}

		private string password_62_RS;
		public string Password_62_RS
        {
			get { return password_62_RS; }
			set { password_62_RS = value; }
		}


		int Iusuario_62_RS.IdUsuario_62_RS { get { return IdUsuario_62_RS; } set { IdUsuario_62_RS = value; } }
		string Iusuario_62_RS.usu_62_RS { get { return usu_62_RS; } set { usu_62_RS = value; } }
		string Iusuario_62_RS.password_62_RS { get { return password_62_RS; } set { password_62_RS = value; } }	


    }
}
