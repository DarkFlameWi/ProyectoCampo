using SEG_62_RS;
using SEG_62_RS.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_62_RS
{
    public partial class LogIn_62_RS : Form
    {
        public LogIn_62_RS()
        {
            InitializeComponent();
        }
        BLL_62_RS.Usuario_62_RS SEGUsuario_62_RS = new BLL_62_RS.Usuario_62_RS();
        BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();

        private void BtnIniciarSesion_62_RS_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = TxtUsuario_62_RS.Text;

            if (string.IsNullOrWhiteSpace(TxtUsuario_62_RS.Text) || string.IsNullOrWhiteSpace(TxtContra_62_RS.Text))
            {
                MessageBox.Show("Por favor, ingrese sus credenciales.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                string mensaje_62_RS = SEGUsuario_62_RS.Login_62_RS(TxtUsuario_62_RS.Text, TxtContra_62_RS.Text);

                MessageBox.Show(mensaje_62_RS, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bllBitacora_62_RS.InsertarBitacora_62_RS(usuarioIngresado, "Inicio de sesión exitoso", "Seguridad", "1");
                Administracion_62_RS admin = new Administracion_62_RS();
                admin.FormClosed += (sender, args) => 
                {
                    if (SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS == null)
                    {
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                };
                admin.Show();
                this.Hide();
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show(ex_62_RS.Message, "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // bllBitacora_62_RS.InsertarBitacora_62_RS(usuarioIngresado, "Intento de inicio de sesión fallido", "Seguridad", "5");
                TxtContra_62_RS.Clear();
                TxtContra_62_RS.Focus();
            }

        }
    }
}
