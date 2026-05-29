using SEG_62_RS.Singleton;
using SEG_62_RS.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_62_RS
{
    public partial class CambiarClave_62_RS : Form, IObservadorIdioma_62_RS
    {
        public CambiarClave_62_RS()
        {
            InitializeComponent();
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            ActualizarIdioma_62_RS(SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS);
        }

        BLL_62_RS.Usuario_62_RS SEGusuario_62_RS = new BLL_62_RS.Usuario_62_RS();

        private void BtnCambiarContra_62_RS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtContraNueva_62_RS.Text) || string.IsNullOrWhiteSpace(TxtRepContra_62_RS.Text) || string.IsNullOrWhiteSpace(TxtContraActual_62_RS.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TxtContraNueva_62_RS.Text != TxtRepContra_62_RS.Text)
            {
                MessageBox.Show("la contraseña actual y nueva deben ser iguales");
                return;
            }
            try
            {
                SEGusuario_62_RS.ActualizarClave_62_RS(TxtContraActual_62_RS.Text, TxtContraNueva_62_RS.Text, TxtRepContra_62_RS.Text);
                MessageBox.Show("Clave cambiada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SingletonSession_62_RS.Instancia_62_RS.CerrarSesion_62_RS();
                Application.Restart();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (ctrl.HasChildren)
                {
                    TraducirControles_62_RS(ctrl.Controls, idioma);
                }
            }
        }

        private void CambiarClave_62_RS_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);
        }
    }
}
