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
    public partial class DVV_62_RS : Form
    {
        public DVV_62_RS()
        {
            InitializeComponent();
        }

        private void BtnRecalcular_62_RS_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
        "¿Está seguro que desea recalcular todos los dígitos de la base de datos?\n\nEsta acción tomará los datos actuales (aunque estén alterados) como válidos y restablecerá la integridad del sistema.",
        "Confirmación Crítica",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    BLL_62_RS.DVV_62_RS gestorIntegridad = new BLL_62_RS.DVV_62_RS();
                    gestorIntegridad.RecalcularTodosLosDigitos_62_RS();

                    MessageBox.Show("Dígitos verificadores recalculados con éxito. El sistema vuelve a estar seguro.", "Integridad Restablecida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en Recálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnRestore_62_RS_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_62_RS_Click(object sender, EventArgs e)
        {

        }
    }
}
