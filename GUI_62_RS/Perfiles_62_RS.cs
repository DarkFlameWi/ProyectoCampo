using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEG_62_RS.Composite;
using SEG_62_RS.Observer;
using SEG_62_RS.Singleton;

namespace GUI_62_RS
{
    public partial class Perfiles_62_RS : Form, IObservadorIdioma_62_RS
    {
        BLL_62_RS.Permisos_62_RS bllPermisos_62_RS;
        private int idFamiliaSeleccionada_62_RS = 0;
        private int idRolSeleccionado_62_RS = 0;
        public Perfiles_62_RS()
        {
            InitializeComponent();
            bllPermisos_62_RS = new BLL_62_RS.Permisos_62_RS();
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            ActualizarIdioma_62_RS(SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS);
            AplicarSeguridad_62_RS();
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
        private string Traducir(string clave)
        {
            return SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS[clave];
        }
        private void Perfiles_62_RS_Load(object sender, EventArgs e)
        {
            CargarListasBase_62_RS();
        }
        private void CargarListasBase_62_RS()
        {
            try
            {
                LbFamilias_62_RS.DataSource = null;
                LbFamilias_62_RS.DataSource = bllPermisos_62_RS.ObtenerFamilias_62_RS();
                LbFamilias_62_RS.DisplayMember = "Nombre_62_RS";
                LbFamilias_62_RS.ValueMember = "Id_62_RS";

                LbRol_62_RS.DataSource = null;
                LbRol_62_RS.DataSource = bllPermisos_62_RS.ListarRolesBase_62_RS();
                LbRol_62_RS.DisplayMember = "Nombre_62_RS";
                LbRol_62_RS.ValueMember = "IdRol_62_RS";

                LlenarTreeAsignador_62_RS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarTreeAsignador_62_RS()
        {
            TvFamiliaPatente_62_RS.Nodes.Clear();
            TvConfigFamilia_62_RS.Nodes.Clear();

            TreeNode nodoFamiliasRol = new TreeNode(Traducir("TvNode_FamiliasDisp"));
            TreeNode nodoPatentesRol = new TreeNode(Traducir("TvNode_PatentesDisp"));

            TreeNode nodoFamiliasFam = new TreeNode(Traducir("TvNode_FamiliasDisp"));
            TreeNode nodoPatentesFam = new TreeNode(Traducir("TvNode_PatentesDisp"));

            foreach (var fam in bllPermisos_62_RS.ObtenerFamilias_62_RS())
            {
                nodoFamiliasRol.Nodes.Add(new TreeNode(fam.Nombre_62_RS) { Tag = fam });
                nodoFamiliasFam.Nodes.Add(new TreeNode(fam.Nombre_62_RS) { Tag = fam });
            }

            foreach (var pat in bllPermisos_62_RS.ObtenerPatentes_62_RS())
            {
                nodoPatentesRol.Nodes.Add(new TreeNode(pat.Nombre_62_RS) { Tag = pat });
                nodoPatentesFam.Nodes.Add(new TreeNode(pat.Nombre_62_RS) { Tag = pat });
            }

            TvFamiliaPatente_62_RS.Nodes.Add(nodoFamiliasRol);
            TvFamiliaPatente_62_RS.Nodes.Add(nodoPatentesRol);
            TvFamiliaPatente_62_RS.ExpandAll();

            TvConfigFamilia_62_RS.Nodes.Add(nodoFamiliasFam);
            TvConfigFamilia_62_RS.Nodes.Add(nodoPatentesFam);
            TvConfigFamilia_62_RS.ExpandAll();
        }
        private void DibujarArbol_62_RS(TreeNode nodoPadre, IList<Permiso_62_RS> permisosHijos)
        {
            foreach (var permiso in permisosHijos)
            {
                TreeNode nuevoNodo = new TreeNode(permiso.Nombre_62_RS);
                nuevoNodo.Tag = permiso.Id_62_RS;
                if (permiso.ObtenerHijos_62_RS().Count > 0)
                {
                    DibujarArbol_62_RS(nuevoNodo, permiso.ObtenerHijos_62_RS());
                }
                nodoPadre.Nodes.Add(nuevoNodo);
            }
        }
        private List<Permiso_62_RS> ObtenerPermisosTildados_62_RS(TreeView tvAsignador)
        {
            List<Permiso_62_RS> elegidos = new List<Permiso_62_RS>();
            foreach (TreeNode nodoRaiz in tvAsignador.Nodes)
            {
                foreach (TreeNode nodoHijo in nodoRaiz.Nodes)
                {
                    if (nodoHijo.Checked && nodoHijo.Tag != null)
                    {
                        elegidos.Add((Permiso_62_RS)nodoHijo.Tag);
                    }
                }
            }
            return elegidos;
        }
        private void MarcarNodosAsignados_62_RS(TreeView tvAsignador, IList<Permiso_62_RS> asignadosDirectos)
        {
            foreach (TreeNode raiz in tvAsignador.Nodes)
            {
                foreach (TreeNode hijo in raiz.Nodes)
                {
                    hijo.Checked = false;
                    if (hijo.Tag != null)
                    {
                        var permisoNodo = (Permiso_62_RS)hijo.Tag;
                        if (asignadosDirectos.Any(a => a.Id_62_RS == permisoNodo.Id_62_RS && a.GetType() == permisoNodo.GetType()))
                        {
                            hijo.Checked = true;
                        }
                    }
                }
            }
        }
        private void AplicarSeguridad_62_RS()
        {
            var usuarioActivo = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS;

            if (usuarioActivo != null && usuarioActivo.Rol_62_RS != null)
            {
                bool puedeNuevaFam = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(30);
                bool puedeCancelarFam = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(32);
                bool puedeConfigurarFam = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(33);
                bool puedeAltaRol = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(34);
                bool puedeBajaRol = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(35);
                bool puedeModificarRol = usuarioActivo.Rol_62_RS.ValidarPermiso_62_RS(36);

                BtnNuevo_62_RS.Enabled = puedeNuevaFam;
                BtnCancelar_62_RS.Enabled = puedeCancelarFam;
                BtnConfigurarFami_62_RS.Enabled = puedeConfigurarFam;
                BtnAltaRol_62_RS.Enabled = puedeAltaRol;
                BtnBajaRol_62_RS.Enabled = puedeBajaRol;
                BtnModificarRol_62_RS.Enabled = puedeModificarRol;
            }
            else
            {
                BtnNuevo_62_RS.Enabled = false;
                BtnCancelar_62_RS.Enabled = false;
                BtnConfigurarFami_62_RS.Enabled = false;
                BtnAltaRol_62_RS.Enabled = false;
                BtnBajaRol_62_RS.Enabled = false;
                BtnModificarRol_62_RS.Enabled = false;
            }
        }



        private void LbFamilias_62_RS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbFamilias_62_RS.SelectedItem == null) return;
            if (LbFamilias_62_RS.SelectedItem is Familia_62_RS familia)
            {
                idFamiliaSeleccionada_62_RS = familia.Id_62_RS;
                TxtNombreFamilia_62_RS.Text = familia.Nombre_62_RS;
                TxtDescFamilia_62_RS.Text = Traducir("Txt_FamDescDefecto");

                MarcarNodosAsignados_62_RS(TvConfigFamilia_62_RS, familia.ObtenerHijos_62_RS());
                TvPermisosFamilia_62_RS.Nodes.Clear();
                TreeNode nodoRaiz = new TreeNode(familia.Nombre_62_RS);
                DibujarArbol_62_RS(nodoRaiz, familia.ObtenerHijos_62_RS());
                TvPermisosFamilia_62_RS.Nodes.Add(nodoRaiz);
                TvPermisosFamilia_62_RS.ExpandAll();
            }
        }
        private void BtnNuevo_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                bllPermisos_62_RS.AltaFamilia_62_RS(TxtNombreFamilia_62_RS.Text, TxtDescFamilia_62_RS.Text);
                MessageBox.Show(Traducir("Msg_Perf_FamGuardada"), Traducir("Msg_Usu_SistemaTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNombreFamilia_62_RS.Clear();
                TxtDescFamilia_62_RS.Clear();
                idFamiliaSeleccionada_62_RS = 0;
                CargarListasBase_62_RS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfigurarFami_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                if (idFamiliaSeleccionada_62_RS == 0 || !(LbFamilias_62_RS.SelectedItem is Familia_62_RS familiaSel))
                {
                    MessageBox.Show(Traducir("Msg_Perf_SeleccioneFam"), Traducir("Msg_Usu_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<Permiso_62_RS> permisosDeseados = ObtenerPermisosTildados_62_RS(TvConfigFamilia_62_RS);
                bllPermisos_62_RS.SincronizarPermisosFamilia_62_RS(familiaSel, permisosDeseados);

                MessageBox.Show(Traducir("Msg_Perf_FamConfigurada"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListasBase_62_RS();
                LbFamilias_62_RS.SelectedValue = familiaSel.Id_62_RS;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Perf_ConflictoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LbFamilias_62_RS_SelectedIndexChanged(sender, e);
            }
        }
        private void BtnCancelar_62_RS_Click(object sender, EventArgs e)
        {
            if (idFamiliaSeleccionada_62_RS == 0) return;

            var confirm = MessageBox.Show(Traducir("Msg_Perf_ConfirmarBaja"), Traducir("Msg_Perf_ConfirmarBajaTit"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning); if (confirm == DialogResult.Yes)
            {
                try
                {
                    bllPermisos_62_RS.BajaFamilia_62_RS(idFamiliaSeleccionada_62_RS);
                    MessageBox.Show(Traducir("Msg_Perf_FamEliminada"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNombreFamilia_62_RS.Clear();
                    TxtDescFamilia_62_RS.Clear();
                    idFamiliaSeleccionada_62_RS = 0;
                    CargarListasBase_62_RS();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }




        private void LbRol_62_RS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbRol_62_RS.SelectedValue == null || !(LbRol_62_RS.SelectedValue is int)) return;
            try
            {
                int idRol = (int)LbRol_62_RS.SelectedValue;
                Rol_62_RS rolCompleto = bllPermisos_62_RS.ObtenerRolUsuario_62_RS(idRol);

                TvPermisosRol_62_RS.Nodes.Clear();

                if (rolCompleto != null)
                {
                    TxtNombreRol_62_RS.Text = rolCompleto.Nombre_62_RS;
                    idRolSeleccionado_62_RS = rolCompleto.Id_62_RS;
                    MarcarNodosAsignados_62_RS(TvFamiliaPatente_62_RS, rolCompleto.ObtenerHijos_62_RS());
                    TreeNode nodoRaiz = new TreeNode(rolCompleto.Nombre_62_RS);
                    DibujarArbol_62_RS(nodoRaiz, rolCompleto.ObtenerHijos_62_RS());
                    TvPermisosRol_62_RS.Nodes.Add(nodoRaiz);
                    TvPermisosRol_62_RS.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnAltaRol_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                bllPermisos_62_RS.AltaRol_62_RS(TxtNombreRol_62_RS.Text, TxtDescRol_62_RS.Text);
                MessageBox.Show(Traducir("Msg_Perf_RolGuardado"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information); TxtNombreRol_62_RS.Clear();
                TxtDescRol_62_RS.Clear();
                CargarListasBase_62_RS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Usu_ErrorTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnBajaRol_62_RS_Click(object sender, EventArgs e)
        {
            if (idRolSeleccionado_62_RS == 0) return;

            try
            {
                bool afectaUsuarios = bllPermisos_62_RS.RolTieneUsuariosAsignados_62_RS(idRolSeleccionado_62_RS);
                string mensajeAviso = afectaUsuarios ? Traducir("Msg_Perf_AvisoRolUsuarios") : Traducir("Msg_Perf_AvisoRolSimple");
                var confirm = MessageBox.Show(mensajeAviso, Traducir("Msg_Perf_ConfirmarBajaTit"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    bllPermisos_62_RS.BajaRol_62_RS(idRolSeleccionado_62_RS);
                    MessageBox.Show(Traducir("Msg_Perf_RolEliminado"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtNombreRol_62_RS.Clear();
                    TxtDescRol_62_RS.Clear();
                    idRolSeleccionado_62_RS = 0;
                    CargarListasBase_62_RS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Perf_ErrorEliminar"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnModificarRol_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                if (idRolSeleccionado_62_RS == 0 || LbRol_62_RS.SelectedValue == null)
                {
                    MessageBox.Show(Traducir("Msg_Perf_SeleccioneRol"), Traducir("Msg_Usu_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idRol = (int)LbRol_62_RS.SelectedValue;
                Rol_62_RS rolSeleccionado = new Rol_62_RS(((DataRowView)LbRol_62_RS.SelectedItem)["Nombre_62_RS"].ToString()) { Id_62_RS = idRol };

                List<Permiso_62_RS> permisosDeseados = ObtenerPermisosTildados_62_RS(TvFamiliaPatente_62_RS);

                bllPermisos_62_RS.SincronizarPermisosRol_62_RS(rolSeleccionado, permisosDeseados);

                MessageBox.Show(Traducir("Msg_Perf_RolConfigurado"), Traducir("Msg_Usu_ExitoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListasBase_62_RS();

                LbRol_62_RS.SelectedValue = idRol;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Perf_ConflictoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LbRol_62_RS_SelectedIndexChanged(sender, e);
            }
        }
        private void Perfiles_62_RS_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);
        }


    }
}
