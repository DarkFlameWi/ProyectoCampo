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
    public partial class Bitacora_62_RS : Form
    {
        SEG_62_RS.Bitacora_62_RS SEGBitacora_62_RS;
        BLL_62_RS.Bitcaora_62_RS BLLBitacora_62_RS;
        public Bitacora_62_RS()
        {
            InitializeComponent();

            SEGBitacora_62_RS = new SEG_62_RS.Bitacora_62_RS();
            BLLBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();
            CargarDatosBitacora_62_RS();
        }

        private void CargarDatosBitacora_62_RS()
        {
            try
            {
                DataTable dt_62_RS = BLLBitacora_62_RS.ListarBitacora_62_RS();
                DgvBit_62_RS.DataSource = dt_62_RS;
                if (DgvBit_62_RS.Columns.Count > 0)
                {
                    if (DgvBit_62_RS.Columns.Contains("IdBitacora_62_RS"))
                        DgvBit_62_RS.Columns["IdBitacora_62_RS"].Visible = false;

                    DgvBit_62_RS.Columns["Usu_62_RS"].HeaderText = "Login";
                    DgvBit_62_RS.Columns["FechaCambio_62_RS"].HeaderText = "Fecha";
                    DgvBit_62_RS.Columns["Descripcion_62_RS"].HeaderText = "Descripción";
                    DgvBit_62_RS.Columns["Modulo_62_RS"].HeaderText = "Modulo";
                    DgvBit_62_RS.Columns["Criticidad_62_RS"].HeaderText = "Criticidad";

                    //Separar a futuro Fecha y Hora
                    //Crear Evento
                }
                else
                {
                    MessageBox.Show("No hay bitácora registrada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error de Sistema: " + ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
