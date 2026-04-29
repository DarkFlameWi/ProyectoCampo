using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_62_RS;
using BE_62_RS;
using SEG_62_RS;
using Microsoft.Data.SqlClient;

namespace GUI_62_RS
{
    public partial class Usuario_62_RS : Form
    {
        BE_62_RS.Usuario_62_RS BEusuario_62_RS;
        SEG_62_RS.Usuario_62_RS SEGusuario_62_RS;
        private int idSeleccionado_62_RS = 0;
        public Usuario_62_RS()
        {
            InitializeComponent();

            BEusuario_62_RS = new BE_62_RS.Usuario_62_RS();
            SEGusuario_62_RS = new SEG_62_RS.Usuario_62_RS();

            CargarDatosUsuarios_62_RS();
        }


        public void Limpiar()
        {
            txtDni_62_RS.Text = "";
            TxtNombre_62_RS.Text = "";
            TxtApellido_62_RS.Text = "";
            TxtEmail_62_RS.Text = "";
            TxtRol_62_RS.Text = "";
            TxtLogIn_62_RS.Text = "";
            TxtBloqueado_62_RS.Text = "";
            TxtActivo_62_RS.Text = "";
            idSeleccionado_62_RS = 0;
        }
        private void CargarDatosUsuarios_62_RS()
        {
            try
            {
                DataTable dt_62_RS = SEGusuario_62_RS.ListarUsuario_62_RS();
                LblCantUsu_62_RS.Text = dt_62_RS.Rows.Count.ToString();
                DgvUsu_62_RS.DataSource = dt_62_RS;
                if (DgvUsu_62_RS.Columns.Count > 0)
                {
                    if (DgvUsu_62_RS.Columns.Contains("idusuario_62_RS"))
                        DgvUsu_62_RS.Columns["idusuario_62_RS"].Visible = false;

                    DgvUsu_62_RS.Columns["nombre_62_RS"].HeaderText = "Nombre";
                    DgvUsu_62_RS.Columns["apellido_62_RS"].HeaderText = "Apellido";
                    DgvUsu_62_RS.Columns["email_62_RS"].HeaderText = "Correo Electrónico";
                    DgvUsu_62_RS.Columns["dni_62_RS"].HeaderText = "D.N.I.";
                    DgvUsu_62_RS.Columns["usu_62_RS"].HeaderText = "Usuario";
                    DgvUsu_62_RS.Columns["estado_62_RS"].HeaderText = "Bloqueado";
                    DgvUsu_62_RS.Columns["Activo_62_RS"].HeaderText = "Activo";
                }
                else
                {
                    MessageBox.Show("No hay usuarios registrados actualmente.");
                }
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error de Sistema: " + ex_62_RS.Message);
            }
        }
        private void ActualizarDgv_62_RS()
        {
            try
            {
                DgvUsu_62_RS.DataSource = SEGusuario_62_RS.ListarUsuario_62_RS();
                if (DgvUsu_62_RS.Columns.Contains("idusuario_62_RS"))
                    DgvUsu_62_RS.Columns["idusuario_62_RS"].Visible = false;

                idSeleccionado_62_RS = 0;
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error al actualizar la lista: " + ex_62_RS.Message);
            }
        }
        private void BtnCrear_62_RS_Click(object sender, EventArgs e)
        {
            BtnCrear_62_RS.Enabled = false;

            try
            {
                if (string.IsNullOrWhiteSpace(txtDni_62_RS.Text) || string.IsNullOrWhiteSpace(TxtNombre_62_RS.Text) ||
                    string.IsNullOrWhiteSpace(TxtApellido_62_RS.Text) || string.IsNullOrWhiteSpace(TxtEmail_62_RS.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                    return;
                }
                BEusuario_62_RS = new BE_62_RS.Usuario_62_RS
                {
                    DNI_62_RS = txtDni_62_RS.Text,
                    Nombre_62_RS = TxtNombre_62_RS.Text,
                    Apellido_62_RS = TxtApellido_62_RS.Text,
                    Email_62_RS = TxtEmail_62_RS.Text
                };
                SEGusuario_62_RS = new SEG_62_RS.Usuario_62_RS();
                SEGusuario_62_RS.AltaUsuario_62_RS(BEusuario_62_RS);
                MessageBox.Show("Usuario creado exitosamente.");
                Limpiar();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error de base de datos: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el usuario: " + ex.Message);
            }
            finally
            {
                BtnCrear_62_RS.Enabled = true;
                ActualizarDgv_62_RS();
            }

        }
        private void BtnModificar_62_RS_Click(object sender, EventArgs e)
        {
            if (idSeleccionado_62_RS == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var objUser_62_RS = new BE_62_RS.Usuario_62_RS
                {
                    IdUsuario_62_RS = idSeleccionado_62_RS,
                    Nombre_62_RS = TxtNombre_62_RS.Text,
                    Apellido_62_RS = TxtApellido_62_RS.Text,
                    Email_62_RS = TxtEmail_62_RS.Text
                };

                SEGusuario_62_RS.ModificarUsuario_62_RS(objUser_62_RS);
                MessageBox.Show("Usuario actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show(ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ActualizarDgv_62_RS();
            }

        }

        private void DgvUsu_62_RS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    idSeleccionado_62_RS = Convert.ToInt32(DgvUsu_62_RS.Rows[e.RowIndex].Cells["idusuario_62_RS"].Value);
                    TxtNombre_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["nombre_62_RS"].Value.ToString();
                    TxtApellido_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["apellido_62_RS"].Value.ToString();
                    TxtEmail_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["email_62_RS"].Value.ToString();
                    txtDni_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["dni_62_RS"].Value.ToString();
                }
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error al seleccionar el usuario: " + ex_62_RS.Message);
            }

        }

        private void BtnDesbloquear_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado_62_RS == 0) throw new Exception("Seleccione un usuario de la grilla.");

                SEGusuario_62_RS.DesbloquearUsuario_62_RS(idSeleccionado_62_RS);
                MessageBox.Show("El usuario ha sido desbloqueado.", "Éxito");
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show(ex_62_RS.Message);
            }
            finally
            {
                ActualizarDgv_62_RS();
            }
        }

        private void BtnActivar_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado_62_RS == 0) throw new Exception("Seleccione un usuario de la grilla.");

                int actual_62_RS = Convert.ToInt32(DgvUsu_62_RS.CurrentRow.Cells["Activo_62_RS"].Value);

                SEGusuario_62_RS.AlternarActivo_62_RS(idSeleccionado_62_RS, actual_62_RS);
                MessageBox.Show("Estado de actividad modificado.");
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show(ex_62_RS.Message);
            }
            finally
            {
                ActualizarDgv_62_RS();
            }
        }

        private void BtnSalir_62_RS_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
