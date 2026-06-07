using SEG_62_RS.Observer;
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
    public partial class Backup_62_RS : Form, IObservadorIdioma_62_RS
    {
        private BLL_62_RS.BackupRestore_62_RS bllBackup_62_RS;
        public Backup_62_RS()
        {
            InitializeComponent();
            bllBackup_62_RS = new BLL_62_RS.BackupRestore_62_RS();
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            ActualizarIdioma_62_RS(SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS);
            AplicarSeguridad_62_RS();
        }
        private string Traducir(string clave)
        {
            var idiomaActual = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS;
            if (idiomaActual != null && idiomaActual.Traducciones_62_RS.ContainsKey(clave))
            {
                return idiomaActual.Traducciones_62_RS[clave];
            }
            return clave;
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
                if (ctrl.HasChildren)
                {
                    TraducirControles_62_RS(ctrl.Controls, idioma);
                }
            }
        }
        private void AplicarSeguridad_62_RS()
        {
            var usuarioActivo = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;

            if (usuarioActivo != null && usuarioActivo.Rol_62_RS != null)
            {
                bool puedeBuscar = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(25);
                bool puedeEjecutar = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(26);
                BtnBuscar_62_RS.Enabled = puedeBuscar;
                BtnEjecutar_62_RS.Enabled = puedeEjecutar;
            }
            else
            {
                BtnBuscar_62_RS.Enabled = false;
                BtnEjecutar_62_RS.Enabled = false;
            }
        }



        private void Backup_62_RS_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);
        }

        private void RbBackup_62_RS_CheckedChanged(object sender, EventArgs e)
        {
            if (RbBackup_62_RS.Checked) TxtRuta_62_RS.Clear();

        }

        private void RbRestore_62_RS_CheckedChanged(object sender, EventArgs e)
        {
            if (RbRestore_62_RS.Checked) TxtRuta_62_RS.Clear();
        }

        private void BtnBuscar_62_RS_Click(object sender, EventArgs e)
        {
            string rutaPorDefecto_62_RS = @"C:\Backups_Proyecto\";

            if (RbBackup_62_RS.Checked)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Seleccione el directorio donde se guardará la copia de seguridad";
                    fbd.SelectedPath = rutaPorDefecto_62_RS;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        TxtRuta_62_RS.Text = fbd.SelectedPath;
                    }
                }
            }
            else if (RbRestore_62_RS.Checked)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Seleccione el archivo de respaldo";
                    ofd.Filter = "SQL Server Backup Files (*.bak)|*.bak|All files (*.*)|*.*";
                    ofd.InitialDirectory = rutaPorDefecto_62_RS;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        TxtRuta_62_RS.Text = ofd.FileName;
                    }
                }
            }
            else
            {
                MessageBox.Show(Traducir("Msg_Bkp_SeleccioneOpcion"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEjecutar_62_RS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtRuta_62_RS.Text))
            {
                MessageBox.Show(Traducir("Msg_Bkp_RutaVacia"), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (RbBackup_62_RS.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    bllBackup_62_RS.RealizarBackup_62_RS(TxtRuta_62_RS.Text);
                    this.Cursor = Cursors.Default;

                    MessageBox.Show(Traducir("Msg_Bkp_ExitoBackup"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtRuta_62_RS.Clear();
                }
                else if (RbRestore_62_RS.Checked)
                {
                    DialogResult dialogResult = MessageBox.Show(Traducir("Msg_Bkp_ConfirmarRestore"), Traducir("Msg_Bkp_ConfirmarTitulo"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        bllBackup_62_RS.RealizarRestore_62_RS(TxtRuta_62_RS.Text);
                        this.Cursor = Cursors.Default;

                        MessageBox.Show(Traducir("Msg_Bkp_ExitoRestore"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtRuta_62_RS.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
