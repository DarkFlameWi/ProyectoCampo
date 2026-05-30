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
        public Perfiles_62_RS()
        {
            InitializeComponent();
            bllPermisos_62_RS = new BLL_62_RS.Permisos_62_RS();
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            ActualizarIdioma_62_RS(SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS);
        }
        private int idFamiliaSeleccionada_62_RS = 0;
        private int idRolSeleccionado_62_RS = 0;
        private string Traducir(string clave)
        {
            return SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS[clave];
        }
        private void Perfiles_62_RS_Load(object sender, EventArgs e)
        {

        }
        private void BtnNuevo_62_RS_Click(object sender, EventArgs e)
        {
            idFamiliaSeleccionada_62_RS = 0;
            TxtNombreFamilia_62_RS.Clear();
            TxtDescFamilia_62_RS.Clear();
            TxtNombreFamilia_62_RS.Focus();
            for (int i = 0; i < ChklPatentes_62_RS.Items.Count; i++)
                ChklPatentes_62_RS.SetItemChecked(i, false);
        }
        private void CargarListasBase_62_RS()
        {
            try
            {
                LbFamilias_62_RS.DataSource = bllPermisos_62_RS.ObtenerFamilias_62_RS();
                LbFamilias_62_RS.DisplayMember = "Nombre_62_RS";
                LbFamilias_62_RS.ValueMember = "Id_62_RS";

                LbRol_62_RS.DataSource = bllPermisos_62_RS.ListarRolesBase_62_RS();
                LbRol_62_RS.DisplayMember = "Nombre_62_RS";
                LbRol_62_RS.ValueMember = "IdRol_62_RS";

                ChklPatentes_62_RS.DataSource = bllPermisos_62_RS.ObtenerPatentes_62_RS();
                ChklPatentes_62_RS.DisplayMember = "Nombre_62_RS";
                ChklPatentes_62_RS.ValueMember = "Id_62_RS";

                LlenarTreeAsignador_62_RS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void LlenarTreeAsignador_62_RS()
        {
            TvFamiliaPatente_62_RS.Nodes.Clear();
            TreeNode nodoFamilias = new TreeNode(Traducir("TvNode_FamiliasDisp"));
            TreeNode nodoPatentes = new TreeNode(Traducir("TvNode_PatentesDisp"));
            foreach (var fam in bllPermisos_62_RS.ObtenerFamilias_62_RS())
            {
                TreeNode n = new TreeNode(fam.Nombre_62_RS);
                n.Tag = fam;
                nodoFamilias.Nodes.Add(n);
            }
            foreach (var pat in bllPermisos_62_RS.ObtenerPatentes_62_RS())
            {
                TreeNode n = new TreeNode(pat.Nombre_62_RS);
                n.Tag = pat;
                nodoPatentes.Nodes.Add(n);
            }

            TvFamiliaPatente_62_RS.Nodes.Add(nodoFamilias);
            TvFamiliaPatente_62_RS.Nodes.Add(nodoPatentes);
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


        private void LbRol_62_RS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbRol_62_RS.SelectedValue == null || !(LbRol_62_RS.SelectedValue is int)) return;
            try
            {
                int idRolSeleccionado = (int)LbRol_62_RS.SelectedValue;
                Rol_62_RS rolCompleto = bllPermisos_62_RS.ObtenerRolUsuario_62_RS(idRolSeleccionado);
                TvPermisosRol_62_RS.Nodes.Clear();
                if (rolCompleto != null)
                {
                    TreeNode nodoRaiz = new TreeNode(rolCompleto.Nombre_62_RS);
                    DibujarArbol_62_RS(nodoRaiz, rolCompleto.ObtenerHijos_62_RS());
                    TvPermisosRol_62_RS.Nodes.Add(nodoRaiz);
                    TvPermisosRol_62_RS.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Perfiles_62_RS_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);
        }

        private void LbFamilias_62_RS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbFamilias_62_RS.SelectedItem is Familia_62_RS familia)
            {
                idFamiliaSeleccionada_62_RS = familia.Id_62_RS;
                TxtNombreFamilia_62_RS.Text = familia.Nombre_62_RS;
                TxtDescFamilia_62_RS.Text = Traducir("Txt_FamDescDefecto");
                for (int i = 0; i < ChklPatentes_62_RS.Items.Count; i++)
                {
                    ChklPatentes_62_RS.SetItemChecked(i, false);
                }
                foreach (var patenteAsignada in familia.ObtenerHijos_62_RS())
                {
                    for (int i = 0; i < ChklPatentes_62_RS.Items.Count; i++)
                    {
                        Patente_62_RS patLista = (Patente_62_RS)ChklPatentes_62_RS.Items[i];
                        if (patLista.Id_62_RS == patenteAsignada.Id_62_RS)
                        {
                            ChklPatentes_62_RS.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        private void BtnGuardar_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                bllPermisos_62_RS.GuardarFamilia_62_RS(idFamiliaSeleccionada_62_RS, TxtNombreFamilia_62_RS.Text, TxtDescFamilia_62_RS.Text);
                MessageBox.Show(Traducir("Msg_Perf_FamGuardada"), "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListasBase_62_RS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Perf_ErrorCargar"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfigurarFami_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                if (LbFamilias_62_RS.SelectedItem is Familia_62_RS familiaSel)
                {
                    List<Patente_62_RS> patentesElegidas = new List<Patente_62_RS>();
                    foreach (Patente_62_RS patente in ChklPatentes_62_RS.CheckedItems)
                    {
                        patentesElegidas.Add(patente);
                    }
                    bllPermisos_62_RS.ConfigurarFamilia_62_RS(familiaSel, patentesElegidas);
                    MessageBox.Show(Traducir("Msg_Perf_FamConfigurada"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListasBase_62_RS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Perf_ErrorCargar"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnAltaRol_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                bllPermisos_62_RS.GuardarRol_62_RS(0, TxtNombreRol_62_RS.Text, TxtDescRol_62_RS.Text);
                MessageBox.Show(Traducir("Msg_Perf_RolGuardado"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNombreRol_62_RS.Clear();
                TxtDescRol_62_RS.Clear();
                CargarListasBase_62_RS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Perf_RolConfigurado"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnBajaRol_62_RS_Click(object sender, EventArgs e)
        {
            TxtNombreRol_62_RS.Clear();
            TxtDescRol_62_RS.Clear();
            idRolSeleccionado_62_RS = 0;

        }

        private void BtnModificarRol_62_RS_Click(object sender, EventArgs e)
        {
            try
            {
                if (LbRol_62_RS.SelectedValue == null) return;
                int idRol = (int)LbRol_62_RS.SelectedValue;
                Rol_62_RS rolSeleccionado = new Rol_62_RS(((DataRowView)LbRol_62_RS.SelectedItem)["Nombre_62_RS"].ToString()) { Id_62_RS = idRol };
                List<Permiso_62_RS> permisosElegidos = new List<Permiso_62_RS>();
                foreach (TreeNode nodoRaiz in TvFamiliaPatente_62_RS.Nodes)
                {
                    foreach (TreeNode nodoHijo in nodoRaiz.Nodes)
                    {
                        if (nodoHijo.Checked)
                        {
                            Permiso_62_RS permisoTildado = (Permiso_62_RS)nodoHijo.Tag;
                            permisosElegidos.Add(permisoTildado);
                        }
                    }
                }

                bllPermisos_62_RS.ConfigurarRol_62_RS(rolSeleccionado, permisosElegidos);
                MessageBox.Show(Traducir("Msg_Perf_RolConfigurado"), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LbRol_62_RS_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir("Msg_Perf_ConflictoTitulo"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
