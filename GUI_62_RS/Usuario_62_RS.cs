using Microsoft.Data.SqlClient;
using SEG_62_RS;
using SEG_62_RS.Singleton;
using SEG_62_RS.Observer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_62_RS
{
    public partial class Usuario_62_RS : Form, IObservadorIdioma_62_RS
    {
        SEG_62_RS.Usuario_62_RS SEGusuario_62_RS;
        BLL_62_RS.Usuario_62_RS BLLusuario_62_RS;
        BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS;
        private BLL_62_RS.Permisos_62_RS bllPermisos_62_RS = new BLL_62_RS.Permisos_62_RS();
        private int idSeleccionado_62_RS = 0;
        private int idFuncion_62_RS = 0;
        private int tipousuario = 1;

        public Usuario_62_RS()
        {
            InitializeComponent();

            SEGusuario_62_RS = new SEG_62_RS.Usuario_62_RS();
            BLLusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
            CargarDatosUsuarios_62_RS();
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            ActualizarIdioma_62_RS(SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS);
            CargarComboRoles_62_RS();
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
        public void Limpiar()
        {
            txtDni_62_RS.Text = "";
            TxtNombre_62_RS.Text = "";
            TxtApellido_62_RS.Text = "";
            TxtEmail_62_RS.Text = "";
            CmbRoles_62_RS.Text = "";
            TxtLogIn_62_RS.Text = "";
            TxtBloqueado_62_RS.Text = "";
            TxtActivo_62_RS.Text = "";
            idSeleccionado_62_RS = 0;
        }
        private void CargarDatosUsuarios_62_RS()
        {
            DatosUnabler_62_RS();
            try
            {
                DataTable dt_62_RS = BLLusuario_62_RS.ListarUsuario_62_RS(tipousuario);
                LblCantUsu_62_RS.Text = dt_62_RS.Rows.Count.ToString();
                DgvUsu_62_RS.DataSource = dt_62_RS;
                if (DgvUsu_62_RS.Columns.Count > 0)
                {
                    if (DgvUsu_62_RS.Columns.Contains("idusuario_62_RS"))
                        DgvUsu_62_RS.Columns["idusuario_62_RS"].Visible = false;

                    DgvUsu_62_RS.Columns["nombre_62_RS"].HeaderText = Traducir("DgvCol_Usu_Nombre");
                    DgvUsu_62_RS.Columns["apellido_62_RS"].HeaderText = Traducir("DgvCol_Usu_Apellido");
                    DgvUsu_62_RS.Columns["email_62_RS"].HeaderText = Traducir("DgvCol_Usu_Email");
                    DgvUsu_62_RS.Columns["dni_62_RS"].HeaderText = Traducir("DgvCol_Usu_DNI");
                    DgvUsu_62_RS.Columns["usu_62_RS"].HeaderText = Traducir("DgvCol_Usu_Usuario");
                    DgvUsu_62_RS.Columns["estado_62_RS"].HeaderText = Traducir("DgvCol_Usu_Bloqueado");
                    DgvUsu_62_RS.Columns["Activo_62_RS"].HeaderText = Traducir("DgvCol_Usu_Activo");
                    DgvUsu_62_RS.Columns["IdRol_62_RS"].HeaderText = Traducir("DgvCol_Usu_Rol");
                }
                else
                {
                    MessageBox.Show(Traducir("Msg_Usu_SinRegistros"), Traducir("Msg_Usu_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show(Traducir("Msg_Usu_ErrorSistema") + ex_62_RS.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarDgv_62_RS()
        {
            try
            {
                DatosUnabler_62_RS();
                DgvUsu_62_RS.DataSource = BLLusuario_62_RS.ListarUsuario_62_RS(tipousuario);
                if (DgvUsu_62_RS.Columns.Contains("idusuario_62_RS"))
                    DgvUsu_62_RS.Columns["idusuario_62_RS"].Visible = false;

                idSeleccionado_62_RS = 0;
            }
            catch (Exception ex_62_RS)
            {
                MessageBox.Show(Traducir("Msg_Usu_ErrorActualizar") + ex_62_RS.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void DatosUnabler_62_RS()
        {
            txtDni_62_RS.Enabled = false;
            TxtApellido_62_RS.Enabled = false;
            TxtNombre_62_RS.Enabled = false;
            TxtEmail_62_RS.Enabled = false;
            CmbRoles_62_RS.Enabled = false;
            TxtLogIn_62_RS.Enabled = false;
            TxtBloqueado_62_RS.Enabled = false;
            TxtActivo_62_RS.Enabled = false;
        }
        private void DatosEnabler_62_RS(int email, int rol, int demas)
        {
            if (email == 1)
            {
                TxtEmail_62_RS.Enabled = true;
            }
            if (rol == 1)
            {
                CmbRoles_62_RS.Enabled = true;
            }
            if (demas == 1)
            {
                txtDni_62_RS.Enabled = true;
                TxtApellido_62_RS.Enabled = true;
                TxtNombre_62_RS.Enabled = true;
            }
            return;
        }
        void BtnRestore_62_RS(int tipo)
        {
            if (tipo == 0)
            {
                GroupBox.Enabled = false;
                BtnCrear_62_RS.Enabled = true;
                BtnActivar_62_RS.Enabled = false;
                BtnDesbloquear_62_RS.Enabled = false;
                BtnModificar_62_RS.Enabled = false;
                BtnAplicar_62_RS.Enabled = false;
                BtnCancelar_62_RS.Enabled = false;
            }
            if (tipo == 1)
            {
                BtnCrear_62_RS.Enabled = false;
                BtnActivar_62_RS.Enabled = false;
                BtnDesbloquear_62_RS.Enabled = false;
                BtnModificar_62_RS.Enabled = false;
                BtnAplicar_62_RS.Enabled = true;
                BtnCancelar_62_RS.Enabled = true;
            }
        }
        public void ActualizarIdioma_62_RS(Idioma_62_RS idioma)
        {
            if (idioma == null || idioma.Traducciones_62_RS == null || idioma.Traducciones_62_RS.Count == 0)
                return;

            if (idioma.Traducciones_62_RS.ContainsKey(this.Name))
                this.Text = idioma.Traducciones_62_RS[this.Name];
            TraducirControles_62_RS(this.Controls, idioma);
            if (DgvUsu_62_RS.DataSource != null)
            {
                CargarDatosUsuarios_62_RS();
            }
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
        private void CargarComboRoles_62_RS()
        {
            try
            {
                DataTable dtRoles = bllPermisos_62_RS.ListarRolesBase_62_RS();
                CmbRoles_62_RS.DataSource = dtRoles;
                CmbRoles_62_RS.DisplayMember = "Nombre_62_RS";
                CmbRoles_62_RS.ValueMember = "IdRol_62_RS";
                CmbRoles_62_RS.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AplicarSeguridad_62_RS()
        {
            var usuarioActivo = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;

            if (usuarioActivo != null && usuarioActivo.Rol_62_RS != null)
            {
                bool puedeCrear = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(6);
                bool puedeModificar = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(7);
                bool puedeDesbloquear = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(8);
                bool puedeActivar = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(9);

                BtnCrear_62_RS.Enabled = puedeCrear;
                BtnModificar_62_RS.Enabled = puedeModificar;
                BtnDesbloquear_62_RS.Enabled = puedeDesbloquear;
                BtnActivar_62_RS.Enabled = puedeActivar;
            }
            else
            {
                BtnCrear_62_RS.Enabled = false;
                BtnModificar_62_RS.Enabled = false;
                BtnDesbloquear_62_RS.Enabled = false;
                BtnActivar_62_RS.Enabled = false;
            }
        }



        private void BtnCrear_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = Traducir("Msg_Usu_TxtCrear");
            Limpiar();
            idFuncion_62_RS = 1;
            BtnCrear_62_RS.Enabled = false;
            GroupBox.Enabled = true;
            DatosEnabler_62_RS(1, 1, 1);
            BtnRestore_62_RS(1);
        }
        private void BtnDesbloquear_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = Traducir("Msg_Usu_TxtDesbloquear"); 
            DatosUnabler_62_RS();
            idFuncion_62_RS = 2;
            BtnRestore_62_RS(1);
        }
        private void BtnModificar_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = Traducir("Msg_Usu_TxtModificar"); 
            DatosUnabler_62_RS();
            idFuncion_62_RS = 3;
            BtnModificar_62_RS.Enabled = false;
            GroupBox.Enabled = true;
            DatosEnabler_62_RS(1, 1, 0);
            BtnRestore_62_RS(1);
        }
        private void BtnActivar_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = Traducir("Msg_Usu_TxtActivar");
            DatosUnabler_62_RS();
            idFuncion_62_RS = 4;
            BtnRestore_62_RS(1);
        }
        private void DgvUsu_62_RS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DatosUnabler_62_RS();
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
                MessageBox.Show(Traducir("Msg_Usu_ErrorSeleccionar") + ex_62_RS.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSalir_62_RS_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAplicar_62_RS_Click(object sender, EventArgs e)
        {
            BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();
            //APLICA SEGÚN FUNCIÓN
            if (idFuncion_62_RS == 1)
            {
                //CREAR
                try
                {
                    if (string.IsNullOrWhiteSpace(txtDni_62_RS.Text) || string.IsNullOrWhiteSpace(TxtNombre_62_RS.Text) ||
                        string.IsNullOrWhiteSpace(TxtApellido_62_RS.Text) || string.IsNullOrWhiteSpace(TxtEmail_62_RS.Text))
                    {
                        MessageBox.Show(Traducir("Msg_Usu_CamposVacios"), Traducir("Msg_Usu_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning); BtnRestore_62_RS(0);
                        return;
                    }
                    SEGusuario_62_RS = new SEG_62_RS.Usuario_62_RS
                    {
                        DNI_62_RS = txtDni_62_RS.Text,
                        Nombre_62_RS = TxtNombre_62_RS.Text,
                        Apellido_62_RS = TxtApellido_62_RS.Text,
                        Email_62_RS = TxtEmail_62_RS.Text,
                        IdRol_62_RS = Convert.ToInt32(CmbRoles_62_RS.SelectedValue)
                    };
                    BLLusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
                    BLLusuario_62_RS.AltaUsuario_62_RS(SEGusuario_62_RS);
                    MessageBox.Show(Traducir("Msg_Usu_ExitoCreacion"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information); Limpiar();
                    TxtMensaje_62_RS.Text = Traducir("Msg_Usu_CreacionExitosa");
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(Traducir("Msg_Usu_ErrorBD") + sqlEx.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error); TxtMensaje_62_RS.Text = sqlEx.Message;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Traducir("Msg_Usu_ErrorCrear") + ex.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Text = ex.Message;
                }
                finally
                {
                    ActualizarDgv_62_RS();
                }
            }
            else if (idFuncion_62_RS == 2)
            {
                //DESBLOQUEAR
                try
                {
                    if (idSeleccionado_62_RS == 0) throw new Exception(Traducir("Msg_Usu_ValidacionSelect"));
                    var objUser_62_RS = new SEG_62_RS.Usuario_62_RS
                    {
                        IdUsuario_62_RS = idSeleccionado_62_RS,
                        DNI_62_RS = txtDni_62_RS.Text,
                        Nombre_62_RS = TxtNombre_62_RS.Text,
                        Apellido_62_RS = TxtApellido_62_RS.Text,
                        Email_62_RS = TxtEmail_62_RS.Text
                    };

                    BLLusuario_62_RS.ModificarUsuario_62_RS(objUser_62_RS);
                    BLLusuario_62_RS.DesbloquearUsuario_62_RS(idSeleccionado_62_RS, objUser_62_RS);
                    MessageBox.Show(Traducir("Msg_Usu_ExitoDesbloqueo"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtMensaje_62_RS.Text = Traducir("Msg_Usu_DesbloqueoExitoso");
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Text = ex_62_RS.Message;
                }
                finally
                {
                    ActualizarDgv_62_RS();
                }
            }
            else if (idFuncion_62_RS == 3)
            {
                //MODIFICAR
                if (idSeleccionado_62_RS == 0)
                {
                    MessageBox.Show(Traducir("Msg_Usu_ValidacionLista"), Traducir("Msg_Usu_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BtnRestore_62_RS(0);
                    return;
                }
                try
                {
                    var objUser_62_RS = new SEG_62_RS.Usuario_62_RS
                    {
                        IdUsuario_62_RS = idSeleccionado_62_RS,
                        Nombre_62_RS = TxtNombre_62_RS.Text,
                        Apellido_62_RS = TxtApellido_62_RS.Text,
                        Email_62_RS = TxtEmail_62_RS.Text,
                        IdRol_62_RS = Convert.ToInt32(CmbRoles_62_RS.SelectedValue)
                    };

                    BLLusuario_62_RS.ModificarUsuario_62_RS(objUser_62_RS);
                    MessageBox.Show(Traducir("Msg_Usu_ExitoModificacion"), Traducir("Msg_Usu_SistemaTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtMensaje_62_RS.Text = Traducir("Msg_Usu_ModificacionExitosa");
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Text = ex_62_RS.Message;
                }
                finally
                {
                    ActualizarDgv_62_RS();
                }
            }
            else if (idFuncion_62_RS == 4)
            {
                //ACTIVAR DESACTIVAR
                try
                {
                    if (idSeleccionado_62_RS == 0) throw new Exception(Traducir("Msg_Usu_ValidacionSelect"));
                    int actual_62_RS = Convert.ToInt32(DgvUsu_62_RS.CurrentRow.Cells["Activo_62_RS"].Value);

                    BLLusuario_62_RS.AlternarActivo_62_RS(idSeleccionado_62_RS, actual_62_RS);
                    MessageBox.Show(Traducir("Msg_Usu_ExitoActividad"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtMensaje_62_RS.Text = Traducir("Msg_Usu_ActividadExitosa");
                }
                catch (Exception ex_62_RS)
                {
                    MessageBox.Show(ex_62_RS.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMensaje_62_RS.Text = ex_62_RS.Message;
                }
                finally
                {
                    ActualizarDgv_62_RS();
                }
            }
            BtnRestore_62_RS(0);
        }
        private void BtnCancelar_62_RS_Click(object sender, EventArgs e)
        {
            TxtMensaje_62_RS.Text = Traducir("Msg_Usu_Cancelado"); Limpiar();
            DatosUnabler_62_RS();
            BtnRestore_62_RS(0);
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
        private void Usuario_62_RS_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);

        }
    }

}
