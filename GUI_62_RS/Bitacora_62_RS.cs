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
            CargarCmb();
        }
        void LimpiarCampos_62_RS()
        {
            TxtNombre_62_RS.Text = "";
            TxtApellido_62_RS.Text = "";
            CmbCriti_62_RS.SelectedIndex = -1;
            CmbModulo_62_RS.SelectedIndex = -1;
            CmbEvento_62_RS.SelectedIndex = -1;
            CmbLogin_62_RS.SelectedIndex = -1;
            DtpFecFin_62_RS.Value = DateTime.Now;
            DtpFecIni_62_RS.Value = DateTime.Now.AddDays(-3);
        }
        void CargarCmb()
        {
            CmbModulo_62_RS.Items.AddRange(new string[] { "Todos","Seguridad", "Administración", "Ventas", "Inventario" });
            CmbCriti_62_RS.Items.AddRange(new string[] { "Todos","1", "2", "3", "4", "5" });
            CmbEvento_62_RS.Items.AddRange(new string[] { "Todos","Inicio de sesión exitoso", "Cierre de sesión", "Crear usuario", "Desbloquear Usuario", "Modificar  usuario", "Eliminar  usuario","Cambio de clave","Bloquear Usuario" });
            DtpFecIni_62_RS.Value = DateTime.Now.AddDays(-3);
            DtpFecFin_62_RS.Value = DateTime.Now;
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
                    if (DgvBit_62_RS.Columns.Contains("Nombre_62_RS"))
                        DgvBit_62_RS.Columns["Nombre_62_RS"].Visible = false;
                    if (DgvBit_62_RS.Columns.Contains("Apellido_62_RS"))
                        DgvBit_62_RS.Columns["Apellido_62_RS"].Visible = false;

                    DgvBit_62_RS.Columns["Usu_62_RS"].HeaderText = "Login";
                    DgvBit_62_RS.Columns["Fecha_62_RS"].HeaderText = "Fecha";
                    DgvBit_62_RS.Columns["Hora_62_RS"].HeaderText = "Hora";
                    DgvBit_62_RS.Columns["Descripcion_62_RS"].HeaderText = "Evento";
                    DgvBit_62_RS.Columns["Modulo_62_RS"].HeaderText = "Modulo";
                    DgvBit_62_RS.Columns["Criticidad_62_RS"].HeaderText = "Criticidad";
                    
                    if (CmbLogin_62_RS.Items.Count == 0)
                    {
                        DataView view = new DataView(dt_62_RS);
                        DataTable dtUsuariosUnicos = view.ToTable(true, "Usu_62_RS");
                        CmbLogin_62_RS.Items.Clear();
                        CmbLogin_62_RS.Items.Add("Todos");
                        foreach (DataRow row in dtUsuariosUnicos.Rows)
                        {
                            CmbLogin_62_RS.Items.Add(row["Usu_62_RS"].ToString());
                        }
                    }
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

        private void DgvBit_62_RS_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvBit_62_RS.CurrentRow != null)
            {
                if (DgvBit_62_RS.Columns.Contains("Nombre_62_RS") && DgvBit_62_RS.Columns.Contains("Apellido_62_RS"))
                {
                    TxtNombre_62_RS.Text = DgvBit_62_RS.CurrentRow.Cells["Nombre_62_RS"].Value?.ToString() ?? "";
                    TxtApellido_62_RS.Text = DgvBit_62_RS.CurrentRow.Cells["Apellido_62_RS"].Value?.ToString() ?? "";
                }
            }
            else
            {
                TxtNombre_62_RS.Text = "Sin usuario seleccionado";
                TxtApellido_62_RS.Text = "Sin usuario seleccionado";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string login = CmbLogin_62_RS.SelectedItem?.ToString() ?? "Todos";
                string modulo = CmbModulo_62_RS.SelectedItem?.ToString() ?? "Todos";
                string evento = CmbEvento_62_RS.SelectedItem?.ToString() ?? "Todos";
                string criticidad = CmbCriti_62_RS.SelectedItem?.ToString() ?? "Todos";
                DateTime desde = DtpFecIni_62_RS.Value;
                DateTime hasta = DtpFecFin_62_RS.Value;
                DataTable dtFiltrado = BLLBitacora_62_RS.FiltrarBitacora_62_RS(login, modulo, evento, criticidad, desde, hasta);
                DgvBit_62_RS.DataSource = dtFiltrado;
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error al filtrar la bitácora: " + ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimpiarCampos_62_RS();
        }
    }
}
