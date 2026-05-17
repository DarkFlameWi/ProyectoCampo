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
using SEG_62_RS;
using Microsoft.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace GUI_62_RS
{
    public partial class Usuario_62_RS : Form
    {
        SEG_62_RS.Usuario_62_RS SEGusuario_62_RS;
        BLL_62_RS.Usuario_62_RS BLLusuario_62_RS;
        private int idSeleccionado_62_RS = 0;
        private int idFuncion_62_RS = 0;
        private int tipousuario = 1;

        public Usuario_62_RS()
        {
            InitializeComponent();

            SEGusuario_62_RS = new SEG_62_RS.Usuario_62_RS();
            BLLusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
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
            txtDni_62_RS.Enabled = false;
            TxtApellido_62_RS.Enabled = false;
            TxtNombre_62_RS.Enabled = false;
            TxtEmail_62_RS.Enabled = false;
            TxtRol_62_RS.Enabled = false;
            TxtLogIn_62_RS.Enabled = false;
            TxtBloqueado_62_RS.Enabled = false;
            TxtActivo_62_RS.Enabled = false;

            try
            {
                DataTable dt_62_RS = BLLusuario_62_RS.ListarUsuario_62_RS(tipousuario);
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
                    MessageBox.Show("No hay usuarios registrados actualmente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error de Sistema: " + ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarDgv_62_RS()
        {
            try
            {
                DatosUnabler();
                DgvUsu_62_RS.DataSource = BLLusuario_62_RS.ListarUsuario_62_RS(tipousuario);
                
                if (DgvUsu_62_RS.Columns.Contains("idusuario_62_RS"))
                    DgvUsu_62_RS.Columns["idusuario_62_RS"].Visible = false;

                idSeleccionado_62_RS = 0;
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error al actualizar la lista: " + ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void BtnCrear_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = "Se eligió la función Crear.";
            Limpiar();
            idFuncion_62_RS = 1;
            BtnCrear_62_RS.Enabled = false;
            GroupBox.Enabled = true;

            DatosEnabler(1, 1, 1);

            BtnAplicar_62_RS.Enabled = true;
            BtnCancelar_62_RS.Enabled = true;
        }
        private void BtnDesbloquear_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = "Se eligió la función Desbloquear.";
            idFuncion_62_RS = 2;
            BtnDesbloquear_62_RS.Enabled = false;
            BtnAplicar_62_RS.Enabled = true;
            BtnCancelar_62_RS.Enabled = true;
        }
        private void BtnModificar_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = "Se eligió la función Modificar.";
            idFuncion_62_RS = 3;
            BtnModificar_62_RS.Enabled = false;
            GroupBox.Enabled = true;

            DatosEnabler(1, 1, 0);

            BtnAplicar_62_RS.Enabled = true;
            BtnCancelar_62_RS.Enabled = true;
        }

        private void BtnActivar_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = "Se eligió la función Activar.";
            idFuncion_62_RS = 4;
            BtnActivar_62_RS.Enabled = false;
            BtnAplicar_62_RS.Enabled = true;
            BtnCancelar_62_RS.Enabled = true;
        }

        private void DgvUsu_62_RS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DatosUnabler();
                if (e.RowIndex >= 0)
                {
                    idSeleccionado_62_RS = Convert.ToInt32(DgvUsu_62_RS.Rows[e.RowIndex].Cells["idusuario_62_RS"].Value);
                    TxtNombre_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["nombre_62_RS"].Value.ToString();
                    TxtApellido_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["apellido_62_RS"].Value.ToString();
                    TxtEmail_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["email_62_RS"].Value.ToString();
                    txtDni_62_RS.Text = DgvUsu_62_RS.Rows[e.RowIndex].Cells["dni_62_RS"].Value.ToString();

                    GroupBox.Enabled = false;
                    BtnAplicar_62_RS.Enabled = false;
                    BtnDesbloquear_62_RS.Enabled = true;
                    BtnModificar_62_RS.Enabled = true;
                    BtnActivar_62_RS.Enabled = true;
                }
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show("Error al seleccionar el usuario: " + ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_62_RS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAplicar_62_RS_Click(object sender, EventArgs e)
        {
            //APLICA SEGÚN FUNCIÓN
            if (idFuncion_62_RS == 1)
            {
                //CREAR
                try
                {
                    if (string.IsNullOrWhiteSpace(txtDni_62_RS.Text) || string.IsNullOrWhiteSpace(TxtNombre_62_RS.Text) ||
                        string.IsNullOrWhiteSpace(TxtApellido_62_RS.Text) || string.IsNullOrWhiteSpace(TxtEmail_62_RS.Text))
                    {
                        MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    SEGusuario_62_RS = new SEG_62_RS.Usuario_62_RS
                    {
                        DNI_62_RS = txtDni_62_RS.Text,
                        Nombre_62_RS = TxtNombre_62_RS.Text,
                        Apellido_62_RS = TxtApellido_62_RS.Text,
                        Email_62_RS = TxtEmail_62_RS.Text
                    };
                    BLLusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
                    BLLusuario_62_RS.AltaUsuario_62_RS(SEGusuario_62_RS);
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error de base de datos: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Clear();
                }
                finally
                {
                    ActualizarDgv_62_RS();
                    TxtMensaje_62_RS.Text = "Se creó el usuario.";
                }
            }
            else if (idFuncion_62_RS == 2)
            {
                //DESBLOQUEAR
                try
                {
                    if (idSeleccionado_62_RS == 0) throw new Exception("Seleccione un usuario de la grilla.");

                    BLLusuario_62_RS.DesbloquearUsuario_62_RS(idSeleccionado_62_RS);
                    MessageBox.Show("El usuario ha sido desbloqueado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Clear();
                }
                finally
                {
                    ActualizarDgv_62_RS();
                    TxtMensaje_62_RS.Text = "Se desbloqueó el usuario.";
                }
            }
            else if (idFuncion_62_RS == 3)
            {
                //MODIFICAR
                if (idSeleccionado_62_RS == 0)
                {
                    MessageBox.Show("Debe seleccionar un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    var objUser_62_RS = new SEG_62_RS.Usuario_62_RS
                    {
                        IdUsuario_62_RS = idSeleccionado_62_RS,
                        Nombre_62_RS = TxtNombre_62_RS.Text,
                        Apellido_62_RS = TxtApellido_62_RS.Text,
                        Email_62_RS = TxtEmail_62_RS.Text
                    };

                    BLLusuario_62_RS.ModificarUsuario_62_RS(objUser_62_RS);
                    MessageBox.Show("Usuario actualizado con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Clear();
                }
                finally
                {
                    ActualizarDgv_62_RS();
                    TxtMensaje_62_RS.Text = "Se modificó el usuario.";
                }
            }
            else if (idFuncion_62_RS == 4)
            {
                //ACTIVAR DESACTIVAR
                try
                {
                    if (idSeleccionado_62_RS == 0) throw new Exception("Seleccione un usuario de la grilla.");

                    int actual_62_RS = Convert.ToInt32(DgvUsu_62_RS.CurrentRow.Cells["Activo_62_RS"].Value);

                    BLLusuario_62_RS.AlternarActivo_62_RS(idSeleccionado_62_RS, actual_62_RS);
                    MessageBox.Show("Estado de actividad modificado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Clear();
                }
                finally
                {
                    ActualizarDgv_62_RS();
                    TxtMensaje_62_RS.Text = "Se activó el usuario.";
                }
            }
            GroupBox.Enabled = false;
            BtnCrear_62_RS.Enabled = true;
            BtnActivar_62_RS.Enabled = false;
            BtnDesbloquear_62_RS.Enabled = false;
            BtnModificar_62_RS.Enabled = false;
            BtnAplicar_62_RS.Enabled = false;
            BtnCancelar_62_RS.Enabled = false;
        }

        private void BtnCancelar_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = "Proceso cancelado.";
            Limpiar();
            DatosUnabler();
            GroupBox.Enabled = false;
            BtnCrear_62_RS.Enabled = true;
            BtnActivar_62_RS.Enabled = false;
            BtnDesbloquear_62_RS.Enabled = false;
            BtnModificar_62_RS.Enabled = false;
            BtnAplicar_62_RS.Enabled = false;
            BtnCancelar_62_RS.Enabled = false;
        }

        private void DatosEnabler(int email, int rol, int demas)
        {
            if (email == 1)
            {
                TxtEmail_62_RS.Enabled = true;
            }
            if (rol == 1)
            {
                TxtRol_62_RS.Enabled = true;
            }
            if (demas == 1)
            {
                txtDni_62_RS.Enabled = true;
                TxtApellido_62_RS.Enabled = true;
                TxtNombre_62_RS.Enabled = true;
            }
            return;
        }

        private void DatosUnabler()
        {
            txtDni_62_RS.Enabled = false;
            TxtApellido_62_RS.Enabled = false;
            TxtNombre_62_RS.Enabled = false;
            TxtEmail_62_RS.Enabled = false;
            TxtRol_62_RS.Enabled = false;
            TxtLogIn_62_RS.Enabled = false;
            TxtBloqueado_62_RS.Enabled = false;
            TxtActivo_62_RS.Enabled = false;
        }

        private void RbActivo_62_RS_CheckedChanged(object sender, EventArgs e)
        {
            tipousuario = 1;
            ActualizarDgv_62_RS();
        }

        private void RbTodo_62_RS_CheckedChanged(object sender, EventArgs e)
        {
            tipousuario = 0;
           ActualizarDgv_62_RS();
        }
    }
}
