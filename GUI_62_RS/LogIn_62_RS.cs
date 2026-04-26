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
        BLL_62_RS.Usuario_62_RS bllUsuario_62_RS = new BLL_62_RS.Usuario_62_RS();

        private void BtnIniciarSesion_62_RS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUsuario_62_RS.Text) || string.IsNullOrWhiteSpace(TxtContra_62_RS.Text))
            {
                MessageBox.Show("Por favor, ingrese sus credenciales.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string mensaje_62_RS = bllUsuario_62_RS.Login_62_RS(TxtUsuario_62_RS.Text, TxtContra_62_RS.Text);
                MessageBox.Show(mensaje_62_RS, "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show(ex_62_RS.Message, "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiamos solo la clave para que el usuario reintente
                TxtContra_62_RS.Clear();
                TxtContra_62_RS.Focus();
            }

        }
    }
}
