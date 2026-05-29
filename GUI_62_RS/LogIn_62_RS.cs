using SEG_62_RS;
using SEG_62_RS.Observer;
using SEG_62_RS.Singleton;
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
    public partial class LogIn_62_RS : Form, IObservadorIdioma_62_RS
    {
        public LogIn_62_RS()
        {
            InitializeComponent();
            BLL_62_RS.Idioma_62_RS bllIdioma = new BLL_62_RS.Idioma_62_RS();
            var idiomaPorDefecto = bllIdioma.CargarIdioma_62_RS("es-AR");
            SingletonSession_62_RS.Instancia_62_RS.CambiarIdioma_62_RS(idiomaPorDefecto);
            SingletonSession_62_RS.Instancia_62_RS.SuscribirObservador_62_RS(this);
            CmbIdioma_62_RS.Items.Clear();
            CmbIdioma_62_RS.Items.Add("Español");
            CmbIdioma_62_RS.Items.Add("English");
            {
                CmbIdioma_62_RS.SelectedIndex = 0;
            }
        }
        BLL_62_RS.Usuario_62_RS SEGUsuario_62_RS = new BLL_62_RS.Usuario_62_RS();
        BLL_62_RS.Bitcaora_62_RS bllBitacora_62_RS = new BLL_62_RS.Bitcaora_62_RS();

        private void BtnIniciarSesion_62_RS_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = TxtUsuario_62_RS.Text;
            var traducciones = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS;

            if (string.IsNullOrWhiteSpace(TxtUsuario_62_RS.Text) || string.IsNullOrWhiteSpace(TxtContra_62_RS.Text))
            {
                MessageBox.Show(traducciones["Msg_Login_CredencialesVacias"], traducciones["Msg_Login_Atencion"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                string mensaje_62_RS = SEGUsuario_62_RS.Login_62_RS(TxtUsuario_62_RS.Text, TxtContra_62_RS.Text);
                string contra = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.DNI_62_RS + SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.Apellido_62_RS;
                string contraHash = Encriptacion_62_RS.EncriptarSHA256_62_RS(contra);
                if (SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.Password_62_RS == contraHash)
                {
                    MessageBox.Show(mensaje_62_RS, traducciones["Msg_Login_CambiarClave"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CambiarClave_62_RS cambiar = new CambiarClave_62_RS();
                    cambiar.Show();
                    this.Hide();
                }
                else
                {
                    int idIdiomaUsuario = SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS.IdIdioma;
                    string codigoCultura = "es-AR";
                    if (idIdiomaUsuario == 1)
                    {
                        codigoCultura = "es-AR";
                    }
                    else if (idIdiomaUsuario == 2)
                    {
                        codigoCultura = "en-US";
                    }
                    BLL_62_RS.Idioma_62_RS bllIdioma = new BLL_62_RS.Idioma_62_RS();
                    var idiomaCargado = bllIdioma.CargarIdioma_62_RS(codigoCultura);
                    SingletonSession_62_RS.Instancia_62_RS.CambiarIdioma_62_RS(idiomaCargado);
                    traducciones = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS;
                    MessageBox.Show(mensaje_62_RS, traducciones["Msg_Login_Bienvenido_Titulo"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bllBitacora_62_RS.InsertarBitacora_62_RS(usuarioIngresado, "Inicio de sesión exitoso", "Usuario", "1");
                    Administracion_62_RS admin = new Administracion_62_RS();
                    admin.FormClosed += (sender, args) =>
                    {
                        if (SingletonSession_62_RS.Instancia_62_RS.Usuario_62_RS == null)
                        {
                            this.Show();
                        }
                        else
                        {
                            this.Close();
                        }
                    };
                    admin.Show();
                    this.Hide();
                }
            }
            catch (Exception ex_62_RS)
            {
                traducciones = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS;
                MessageBox.Show(ex_62_RS.Message, traducciones["Msg_Login_ErrorTitulo"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtContra_62_RS.Clear();
                TxtContra_62_RS.Focus();
            }

        }

        private void CmbIdioma_62_RS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIdioma_62_RS.SelectedItem == null) return;

            string seleccion = CmbIdioma_62_RS.SelectedItem.ToString();
            string codigoCultura = "es-AR";
            if (seleccion == "English")
            {
                codigoCultura = "en-US";
            }

            try
            {
                BLL_62_RS.Idioma_62_RS bllIdioma = new BLL_62_RS.Idioma_62_RS();
                var nuevoIdioma = bllIdioma.CargarIdioma_62_RS(codigoCultura);
                SingletonSession_62_RS.Instancia_62_RS.CambiarIdioma_62_RS(nuevoIdioma);
            }
            catch (Exception ex)
            {
                var traducciones = SingletonSession_62_RS.Instancia_62_RS.IdiomaActual_62_RS.Traducciones_62_RS;
                MessageBox.Show(traducciones["Msg_Login_ErrorIdioma"] + ex.Message, traducciones["Msg_Login_Error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void LogIn_62_RS_FormClosed(object sender, FormClosedEventArgs e)
        {
            SingletonSession_62_RS.Instancia_62_RS.DesuscribirObservador_62_RS(this);
        }
    }
}
