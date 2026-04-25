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
            lblContraActual_62_RS.Location = new Point(12, 17);
            lblContraActual_62_RS.Name = "lblContraActual_62_RS";
            lblContraActual_62_RS.Size = new Size(107, 15);
            lblContraActual_62_RS.TabIndex = 0;
            lblContraActual_62_RS.Text = "Contraseña Actual:";
            // 
            // LblContraNueva_62_RS
            // 
            LblContraNueva_62_RS.AutoSize = true;
            LblContraNueva_62_RS.Location = new Point(12, 47);
            LblContraNueva_62_RS.Name = "LblContraNueva_62_RS";
            LblContraNueva_62_RS.Size = new Size(107, 15);
            LblContraNueva_62_RS.TabIndex = 1;
            LblContraNueva_62_RS.Text = "Contraseña Nueva:";
            // 
            // LblRepContra_62_RS
            // 
            LblRepContra_62_RS.AutoSize = true;
            LblRepContra_62_RS.Location = new Point(9, 80);
            LblRepContra_62_RS.Name = "LblRepContra_62_RS";
            LblRepContra_62_RS.Size = new Size(110, 15);
            LblRepContra_62_RS.TabIndex = 2;
            LblRepContra_62_RS.Text = "Repetir Contraseña:";
            // 
            // BtnCambiarContra_62_RS
            // 
            BtnCambiarContra_62_RS.Location = new Point(62, 130);
            BtnCambiarContra_62_RS.Name = "BtnCambiarContra_62_RS";
            BtnCambiarContra_62_RS.Size = new Size(158, 60);
            BtnCambiarContra_62_RS.TabIndex = 3;
            BtnCambiarContra_62_RS.Text = "Cambiar Contraseña";
            BtnCambiarContra_62_RS.UseVisualStyleBackColor = true;
            // 
            // TxtContraActual_62_RS
            // 
            TxtContraActual_62_RS.Location = new Point(133, 17);
            TxtContraActual_62_RS.Name = "TxtContraActual_62_RS";
            TxtContraActual_62_RS.Size = new Size(146, 23);
            TxtContraActual_62_RS.TabIndex = 4;
            // 
            // TxtContraNueva_62_RS
            // 
            TxtContraNueva_62_RS.Location = new Point(133, 47);
            TxtContraNueva_62_RS.Name = "TxtContraNueva_62_RS";
            TxtContraNueva_62_RS.Size = new Size(146, 23);
            TxtContraNueva_62_RS.TabIndex = 5;
            // 
            // TxtRepContra_62_RS
            // 
            TxtRepContra_62_RS.Location = new Point(133, 80);
            TxtRepContra_62_RS.Name = "TxtRepContra_62_RS";
            TxtRepContra_62_RS.Size = new Size(146, 23);
            TxtRepContra_62_RS.TabIndex = 6;
            // 
            // CambiarClave_62_RS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 216);
            Controls.Add(TxtRepContra_62_RS);
            Controls.Add(TxtContraNueva_62_RS);
            Controls.Add(TxtContraActual_62_RS);
            Controls.Add(BtnCambiarContra_62_RS);
            Controls.Add(LblRepContra_62_RS);
            Controls.Add(LblContraNueva_62_RS);
            Controls.Add(lblContraActual_62_RS);
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