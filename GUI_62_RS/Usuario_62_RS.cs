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
        public Usuario_62_RS()
        {
            InitializeComponent();
        }
        BE_62_RS.Usuario_62_RS BEusuario_62_RS;
        BLL_62_RS.Usuario_62_RS BLLusuario_62_RS;

   
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
                BLLusuario_62_RS = new BLL_62_RS.Usuario_62_RS();
                BLLusuario_62_RS.AltaUsuario_62_RS(BEusuario_62_RS);
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
            }

        }
        private void BtnModificar_62_RS_Click(object sender, EventArgs e)
        {

        }


    }
}
