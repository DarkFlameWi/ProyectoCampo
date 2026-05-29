using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEG_62_RS.Singleton;
using SEG_62_RS.Observer;

namespace GUI_62_RS
{
    public partial class CambiarIdioma_62_RS : Form, IObservadorIdioma_62_RS
    {

        public CambiarIdioma_62_RS()
        {
            InitializeComponent();
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            ActualizarIdioma_62_RS(SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS);
            TxtUsu_62_RS.Text = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.UsU_62_RS;
            var traducciones = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS;
            cmbIdioma_62_RS.Items.Clear();
            cmbIdioma_62_RS.Items.Add(traducciones.ContainsKey("Cmb_Opcion_Esp") ? traducciones["Cmb_Opcion_Esp"] : "Español");
            cmbIdioma_62_RS.Items.Add(traducciones.ContainsKey("Cmb_Opcion_Ing") ? traducciones["Cmb_Opcion_Ing"] : "Inglés");
        }

        private void BtnIdioma_62_RS_Click(object sender, EventArgs e)
        {
            if (cmbIdioma_62_RS.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un idioma / Please select a language.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string seleccion = cmbIdioma_62_RS.SelectedItem.ToString();
            int idIdioma = 1;
            string codigoCultura = "es-AR";
            if (seleccion == "Inglés" || seleccion == "English")
            {
                idIdioma = 2;
                codigoCultura = "en-US";
            }
            else
            {
                idIdioma = 1;
                codigoCultura = "es-AR";
            }

            try
            {
                BLL_62_RS.Idioma_62_RS bllIdioma = new BLL_62_RS.Idioma_62_RS();
                var nuevoIdioma = bllIdioma.CargarIdioma_62_RS(codigoCultura);
                SingletonSession_62_RS.Instancia_62_RS.CambiarIdioma_62_RS(nuevoIdioma);
                var usuarioSesion = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;
                usuarioSesion.IdIdioma = idIdioma;
                BLL_62_RS.Usuario_62_RS bllUsuario = new BLL_62_RS.Usuario_62_RS();
                bllUsuario.ActualizarIdiomaUsuario_62_RS(usuarioSesion.IdUsuario_62_RS, idIdioma);
                MessageBox.Show("Idioma actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CambiarIdioma_62_RS_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);
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
    }
}
