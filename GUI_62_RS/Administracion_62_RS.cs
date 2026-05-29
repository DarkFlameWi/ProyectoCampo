using SEG_62_RS.Singleton;
using SEG_62_RS.Observer;
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
    public partial class Administracion_62_RS : Form, IObservadorIdioma_62_RS
    {
        public Administracion_62_RS()
        {
            InitializeComponent();
            TsslUsu_62_RS.Text = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS;

        }
        BLL_62_RS.Usuario_62_RS SEGusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
        private void Administracion_62_RS_Load(object sender, EventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            ActualizarIdioma_62_RS(SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS);
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
            CambiarIdioma_62_RS cambiarIdioma_62_RS = new CambiarIdioma_62_RS();
            cambiarIdioma_62_RS.MdiParent = this;
            cambiarIdioma_62_RS.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn_62_RS login = new LogIn_62_RS();
            login.MdiParent = this;
            login.Show();
        }

        private void Administracion_62_RS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS == null)
            {
                return;
            }
            var traducciones = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS;

            var confirmacion_62_RS = MessageBox.Show(traducciones["Msg_Admin_CerrarSesion_Texto"], traducciones["Msg_Admin_CerrarSesion_Titulo"],
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion_62_RS == DialogResult.Yes)
            {
                try
                {
                    if (SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS != null)
                    {
                        SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);
                        SEGusuario_62_RS.logout_62_RS();
                    }
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, traducciones["Msg_Admin_ErrorCerrarSesion_Titulo"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                e.Cancel = true;
            }

        }

        public void ActualizarIdioma_62_RS(Idioma_62_RS idioma)
        {
            if (idioma == null || idioma.Traducciones_62_RS == null || idioma.Traducciones_62_RS.Count == 0)
                return;
            if (idioma.Traducciones_62_RS.ContainsKey(this.Name))
                this.Text = idioma.Traducciones_62_RS[this.Name];
            TraducirControles_62_RS(this.Controls, idioma);
        }
        private void TraducirControles_62_RS(Control.ControlCollection controles, Idioma_62_RS idioma)
        {
            foreach (Control ctrl in controles)
            {
                if (idioma.Traducciones_62_RS.ContainsKey(ctrl.Name))
                {
                    ctrl.Text = idioma.Traducciones_62_RS[ctrl.Name];
                }
                if (ctrl is MenuStrip menuStrip)
                {
                    TraducirItemsMenu_62_RS(menuStrip.Items, idioma);
                }
                if (ctrl.HasChildren)
                {
                    TraducirControles_62_RS(ctrl.Controls, idioma);
                }
            }
        }
        private void TraducirItemsMenu_62_RS(ToolStripItemCollection items, Idioma_62_RS idioma)
        {
            foreach (ToolStripItem item in items)
            {
                if (idioma.Traducciones_62_RS.ContainsKey(item.Name))
                {
                    item.Text = idioma.Traducciones_62_RS[item.Name];
                }
                if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
                {
                    TraducirItemsMenu_62_RS(menuItem.DropDownItems, idioma);
                }
            }
        }
    }
}
