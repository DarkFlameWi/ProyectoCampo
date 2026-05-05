using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI_62_RS
{
    public partial class CambiarClave_62_RS : Form
    {
        public CambiarClave_62_RS()
        {
            InitializeComponent();
        }

        BLL_62_RS.Usuario_62_RS SEGusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
        private void BtnCambiarContra_62_RS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtContraNueva_62_RS.Text) || string.IsNullOrWhiteSpace(TxtRepContra_62_RS.Text)|| string.IsNullOrWhiteSpace(TxtContraActual_62_RS.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ( TxtContraNueva_62_RS.Text != TxtRepContra_62_RS.Text)
            {
                 MessageBox.Show("la contraseña actual y nueva deben ser iguales");
                return;
            }
            try
            {
                SEGusuario_62_RS.ActualizarClave_62_RS(TxtContraActual_62_RS.Text, TxtContraNueva_62_RS.Text, TxtRepContra_62_RS.Text);
                MessageBox.Show("Clave cambiada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
