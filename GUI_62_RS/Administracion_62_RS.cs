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
            AplicarSeguridad_62_RS();
        }


        private void PerfilrestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Perfiles_62_RS perfiles_62_RS = new Perfiles_62_RS();
            perfiles_62_RS.MdiParent = this;
            perfiles_62_RS.Show();
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
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup_62_RS backup_62_RS = new Backup_62_RS();
            backup_62_RS.MdiParent = this;
            backup_62_RS.Show();

        }
        private void digVerificacorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVV_62_RS digitoVerificador_62_RS = new DVV_62_RS();
            digitoVerificador_62_RS.MdiParent = this;
            digitoVerificador_62_RS.Show();
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
        private void AplicarSeguridad_62_RS()
        {
            var usuarioActivo = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;

            if (usuarioActivo != null && usuarioActivo.Rol_62_RS != null)
            {

                //ADMIN
                bool verAdminPadre = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(1);
                bool verUsuarios = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(2);
                bool verBitacora = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(3);
                bool verPerfiles = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(11);
                bool verRestore = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(12);
                bool verDigito = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(13);

                UsuariosToolStripMenuItem.Visible = verUsuarios;
                bitacoraToolStripMenuItem.Visible = verBitacora;
                PerfilrestoolStripMenuItem.Visible = verPerfiles;
                restoreToolStripMenuItem.Visible = verRestore;
                digVerificacorToolStripMenuItem.Visible = verDigito;

                adminToolStripMenuItem.Visible = (verAdminPadre || verUsuarios || verBitacora || verPerfiles || verRestore || verDigito);

                //PREFERENCIAS DE USUARIO
                bool verIdioma = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(4);
                bool verClave = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(5);

                cambiarIdiomaToolStripMenuItem.Visible = verIdioma;
                cambiarClaveToolStripMenuItem.Visible = verClave;

                usuarioToolStripMenuItem.Visible = (verIdioma || verClave);


                //MAESTROS
                bool verProd = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(14);
                bool verCli = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(15);
                bool verProv = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(16);

                productosToolStripMenuItem.Visible = verProd;
                clientesToolStripMenuItem.Visible = verCli;
                proovedoresToolStripMenuItem.Visible = verProv;

                maestroToolStripMenuItem.Visible = (verProd || verCli || verProv);

                //VENTAS
                bool verCarrito = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(17);
                bool verFacturar = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(18);
                bool verDespachar = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(19);

                carritoToolStripMenuItem.Visible = verCarrito;
                facturarToolStripMenuItem.Visible = verFacturar;
                despacharToolStripMenuItem.Visible = verDespachar;

                ventasToolStripMenuItem.Visible = (verCarrito || verFacturar || verDespachar);

                //COMPRAS
                bool verSoli = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(20);
                bool verOrden = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(21);
                bool verRecep = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(22);

                solicitudToolStripMenuItem.Visible = verSoli;
                ordenCompraToolStripMenuItem.Visible = verOrden;
                recepcionToolStripMenuItem.Visible = verRecep;

                comprasToolStripMenuItem.Visible = (verSoli || verOrden || verRecep);

                //REPORTES
                bool verRepVen = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(23);
                bool verRepCom = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(24);

                reporteVentasToolStripMenuItem.Visible = verRepVen;
                reporteComprasToolStripMenuItem.Visible = verRepCom;

                reportesToolStripMenuItem.Visible = (verRepVen || verRepCom);
            }
            else
            {
                adminToolStripMenuItem.Visible = false;
                maestroToolStripMenuItem.Visible = false;
                ventasToolStripMenuItem.Visible = false;
                comprasToolStripMenuItem.Visible = false;
                reportesToolStripMenuItem.Visible = false;
                usuarioToolStripMenuItem.Visible = false;
            }
        }
    }
}
