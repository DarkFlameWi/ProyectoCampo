using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
            CmbModulo_62_RS.Items.AddRange(new string[] { "Todos", "Seguridad", "Administración", "Ventas", "Inventario" });
            CmbCriti_62_RS.Items.AddRange(new string[] { "Todos", "1", "2", "3", "4", "5" });
            CmbEvento_62_RS.Items.AddRange(new string[] { "Todos", "Inicio de sesión exitoso", "Cierre de sesión", "Crear usuario", "Desbloquear Usuario", "Modificar  usuario", "Eliminar  usuario", "Cambio de clave", "Bloquear Usuario" });
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

        private void BtnSalir_62_RS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvBit_62_RS_SelectionChanged(object sender, EventArgs e)
        {
            /*  if (DgvBit_62_RS.CurrentRow != null)
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
              }*/
            UsuarioEjecucion_62_Rs();
        }

        private void UsuarioEjecucion_62_Rs()
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
        private void BtnAplicar_62_RS_Click(object sender, EventArgs e)
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
            UsuarioEjecucion_62_Rs();
        }

        private int filaActualImpresion = 0;

        private void BtnImprimir_62_RS_Click(object sender, EventArgs e)
        {
            Imprimir_62_RS();
        }

        private void Imprimir_62_RS()
        {
            PrintDocument doc = new PrintDocument();
            PrintDialog dialog = new PrintDialog();

            doc.DefaultPageSettings.Landscape = true;
            dialog.Document = doc;
            dialog.UseEXDialog = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DgvBit_62_RS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                filaActualImpresion = 0;

                //doc.BeginPrint += new PrintEventHandler(ContenidoImprimir_62_RS);
                doc.PrintPage += new PrintPageEventHandler(ContenidoImprimir_62_RS);
                doc.Print();
            }
        }

        private void ContenidoImprimir_62_RS(object sender, PrintPageEventArgs e)
        {
            Font fuenteTitulo = new Font("Arial", 24, FontStyle.Bold);
            Font fuenteCabecera = new Font("Arial", 10, FontStyle.Bold);
            Font fuenteCeldas = new Font("Arial", 10, FontStyle.Regular);

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int altoFila = 25;
            if (filaActualImpresion == 0)
            {
                string titulo = "REPORTE DE BITÁCOTA";
                e.Graphics.DrawString(titulo, fuenteTitulo, Brushes.Black, x, y);
                y += 40;
            }

            foreach (DataGridViewColumn col in DgvBit_62_RS.Columns)
            {
                if (col.Visible)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, x, y, col.Width, altoFila);
                    e.Graphics.DrawRectangle(Pens.Black, x, y, col.Width, altoFila);
                    e.Graphics.DrawString(col.HeaderText, fuenteCabecera, Brushes.Black, x + 2, y + 4);
                    x += col.Width;
                }
            }

            y += altoFila;


            while (filaActualImpresion < DgvBit_62_RS.Rows.Count)
            {
                DataGridViewRow row = DgvBit_62_RS.Rows[filaActualImpresion];

                if (row.IsNewRow)
                {
                    filaActualImpresion++;
                    continue;
                }

                if (y + altoFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                x = e.MarginBounds.Left;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x, y, cell.OwningColumn.Width, altoFila);
                        string valor = cell.Value?.ToString() ?? "";
                        e.Graphics.DrawString(valor, fuenteCeldas, Brushes.Black, x + 2, y + 4);
                        x += cell.OwningColumn.Width;
                    }
                }

                y += altoFila;
                filaActualImpresion++;
            }
            e.HasMorePages = false;
        }

        private void BtnLimpiar_62_RS_Click(object sender, EventArgs e)
        {
            LimpiarCampos_62_RS();

        }
    }
}
