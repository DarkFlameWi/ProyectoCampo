using SEG_62_RS.Singleton;
using SEG_62_RS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace GUI_62_RS
{
    public partial class Administracion_62_RS : Form
    {
        public Administracion_62_RS()
        {
            InitializeComponent();
            TsslUsu_62_RS.Text = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.usu_62_RS;

        }
        BLL_62_RS.Usuario_62_RS SEGusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
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
                BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();

                string nombreUsuario = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.usu_62_RS;
                bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario, "Cierre de sesión", "Seguridad", "1");
                try
                {
                    SEGusuario_62_RS.logout_62_RS();
                    this.Close();
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn_62_RS login = new LogIn_62_RS();
            login.MdiParent = this;
            login.Show();
        }

        private void Administracion_62_RS_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmacion_62_RS = MessageBox.Show("¿Está seguro que desea salir?", "Cerrar Sesión",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion_62_RS == DialogResult.Yes)
            {
                try
                {
                    BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();

                string nombreUsuario = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.usu_62_RS;
                bllBitacora_62_RS.InsertarBitacora_62_RS(nombreUsuario, "Cierre de sesión", "Seguridad", "1");
               
                    SEGusuario_62_RS.logout_62_RS();
                    Environment.Exit(0);
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                e.Cancel = true;
            }


        }
    }
}
