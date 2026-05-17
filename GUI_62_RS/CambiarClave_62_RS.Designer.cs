namespace GUI_62_RS
{
    partial class CambiarClave_62_RS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblContraActual_62_RS = new Label();
            LblContraNueva_62_RS = new Label();
            LblRepContra_62_RS = new Label();
            BtnCambiarContra_62_RS = new Button();
            TxtContraActual_62_RS = new TextBox();
            TxtContraNueva_62_RS = new TextBox();
            TxtRepContra_62_RS = new TextBox();
            SuspendLayout();
            // 
            // lblContraActual_62_RS
            // 
            lblContraActual_62_RS.AutoSize = true;
            lblContraActual_62_RS.Location = new Point(14, 23);
            lblContraActual_62_RS.Name = "lblContraActual_62_RS";
            lblContraActual_62_RS.Size = new Size(132, 20);
            lblContraActual_62_RS.TabIndex = 0;
            lblContraActual_62_RS.Text = "Contraseña Actual:";
            // 
            // LblContraNueva_62_RS
            // 
            LblContraNueva_62_RS.AutoSize = true;
            LblContraNueva_62_RS.Location = new Point(14, 63);
            LblContraNueva_62_RS.Name = "LblContraNueva_62_RS";
            LblContraNueva_62_RS.Size = new Size(132, 20);
            LblContraNueva_62_RS.TabIndex = 1;
            LblContraNueva_62_RS.Text = "Contraseña Nueva:";
            // 
            // LblRepContra_62_RS
            // 
            LblRepContra_62_RS.AutoSize = true;
            LblRepContra_62_RS.Location = new Point(10, 107);
            LblRepContra_62_RS.Name = "LblRepContra_62_RS";
            LblRepContra_62_RS.Size = new Size(138, 20);
            LblRepContra_62_RS.TabIndex = 2;
            LblRepContra_62_RS.Text = "Repetir Contraseña:";
            // 
            // BtnCambiarContra_62_RS
            // 
            BtnCambiarContra_62_RS.Location = new Point(71, 173);
            BtnCambiarContra_62_RS.Margin = new Padding(3, 4, 3, 4);
            BtnCambiarContra_62_RS.Name = "BtnCambiarContra_62_RS";
            BtnCambiarContra_62_RS.Size = new Size(181, 80);
            BtnCambiarContra_62_RS.TabIndex = 3;
            BtnCambiarContra_62_RS.Text = "Cambiar Contraseña";
            BtnCambiarContra_62_RS.UseVisualStyleBackColor = true;
            BtnCambiarContra_62_RS.Click += BtnCambiarContra_62_RS_Click;
            // 
            // TxtContraActual_62_RS
            // 
            TxtContraActual_62_RS.Location = new Point(152, 23);
            TxtContraActual_62_RS.Margin = new Padding(3, 4, 3, 4);
            TxtContraActual_62_RS.Name = "TxtContraActual_62_RS";
            TxtContraActual_62_RS.Size = new Size(166, 27);
            TxtContraActual_62_RS.TabIndex = 4;
            // 
            // TxtContraNueva_62_RS
            // 
            TxtContraNueva_62_RS.Location = new Point(152, 63);
            TxtContraNueva_62_RS.Margin = new Padding(3, 4, 3, 4);
            TxtContraNueva_62_RS.Name = "TxtContraNueva_62_RS";
            TxtContraNueva_62_RS.Size = new Size(166, 27);
            TxtContraNueva_62_RS.TabIndex = 5;
            // 
            // TxtRepContra_62_RS
            // 
            TxtRepContra_62_RS.Location = new Point(152, 107);
            TxtRepContra_62_RS.Margin = new Padding(3, 4, 3, 4);
            TxtRepContra_62_RS.Name = "TxtRepContra_62_RS";
            TxtRepContra_62_RS.Size = new Size(166, 27);
            TxtRepContra_62_RS.TabIndex = 6;
            // 
            // CambiarClave_62_RS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 288);
            Controls.Add(TxtRepContra_62_RS);
            Controls.Add(TxtContraNueva_62_RS);
            Controls.Add(TxtContraActual_62_RS);
            Controls.Add(BtnCambiarContra_62_RS);
            Controls.Add(LblRepContra_62_RS);
            Controls.Add(LblContraNueva_62_RS);
            Controls.Add(lblContraActual_62_RS);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CambiarClave_62_RS";
            Text = "CambiarClave_62_RS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContraActual_62_RS;
        private Label LblContraNueva_62_RS;
        private Label LblRepContra_62_RS;
        private Button BtnCambiarContra_62_RS;
        private TextBox TxtContraActual_62_RS;
        private TextBox TxtContraNueva_62_RS;
        private TextBox TxtRepContra_62_RS;
    }
}