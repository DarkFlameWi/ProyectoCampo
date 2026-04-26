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
    public partial class Administracion_62_RS : Form
    {
        public Administracion_62_RS()
        {
            InitializeComponent();
        }
        BLL_62_RS.Usuario_62_RS BLLusuario_62_RS = new BLL_62_RS.Usuario_62_RS();

        private void Administracion_62_RS_Load(object sender, EventArgs e)
        {

        }

        private void PerfilrestoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario_62_RS usuario_62_RS = new Usuario_62_RS();
            usuario_62_RS.MdiParent = this;
            usuario_62_RS.Show();

        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitacora_62_RS bitacora_62_RS = new Bitacora_62_RS();
            bitacora_62_RS.MdiParent = this;
            bitacora_62_RS.Show();
        }

        private void backUpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void digVerificacorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarClave_62_RS cambiarClave_62_RS = new CambiarClave_62_RS();
            cambiarClave_62_RS.MdiParent = this;
            cambiarClave_62_RS.Show();
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmacion_62_RS = MessageBox.Show("¿Está seguro que desea salir?", "Cerrar Sesión",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion_62_RS == DialogResult.Yes)
            {
                try
                {
                    BLLusuario_62_RS.logout_62_RS();

                    Application.Restart();
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message);
                }
            }
        }

    }
}
