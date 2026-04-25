namespace GUI_62_RS
{
    partial class LogIn_62_RS
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
            TxtUsuario_62_RS = new TextBox();
            TxtContra_62_RS = new TextBox();
            BtnIniciarSesion_62_RS = new Button();
            LblUsuario_62_RS = new Label();
            LblContra_62_RS = new Label();
            LblIdioma_62_RS = new Label();
            CmbIdioma_62_RS = new ComboBox();
            SuspendLayout();
            // 
            // TxtUsuario_62_RS
            // 
            TxtUsuario_62_RS.Location = new Point(84, 54);
            TxtUsuario_62_RS.Name = "TxtUsuario_62_RS";
            TxtUsuario_62_RS.Size = new Size(130, 23);
            TxtUsuario_62_RS.TabIndex = 0;
            // 
            // TxtContra_62_RS
            // 
            TxtContra_62_RS.Location = new Point(84, 96);
            TxtContra_62_RS.Name = "TxtContra_62_RS";
            TxtContra_62_RS.Size = new Size(130, 23);
            TxtContra_62_RS.TabIndex = 1;
            // 
            // BtnIniciarSesion_62_RS
            // 
            BtnIniciarSesion_62_RS.Location = new Point(22, 150);
            BtnIniciarSesion_62_RS.Name = "BtnIniciarSesion_62_RS";
            BtnIniciarSesion_62_RS.Size = new Size(192, 71);
            BtnIniciarSesion_62_RS.TabIndex = 2;
            BtnIniciarSesion_62_RS.Text = "Iniciar Sesion";
            BtnIniciarSesion_62_RS.UseVisualStyleBackColor = true;
            // 
            // LblUsuario_62_RS
            // 
            LblUsuario_62_RS.AutoSize = true;
            LblUsuario_62_RS.Location = new Point(8, 57);
            LblUsuario_62_RS.Name = "LblUsuario_62_RS";
            LblUsuario_62_RS.Size = new Size(50, 15);
            LblUsuario_62_RS.TabIndex = 3;
            LblUsuario_62_RS.Text = "Usuario:";
            // 
            // LblContra_62_RS
            // 
            LblContra_62_RS.AutoSize = true;
            LblContra_62_RS.Location = new Point(8, 99);
            LblContra_62_RS.Name = "LblContra_62_RS";
            LblContra_62_RS.Size = new Size(70, 15);
            LblContra_62_RS.TabIndex = 4;
            LblContra_62_RS.Text = "Contraseña:";
            // 
            // LblIdioma_62_RS
            // 
            LblIdioma_62_RS.AutoSize = true;
            LblIdioma_62_RS.Location = new Point(8, 15);
            LblIdioma_62_RS.Name = "LblIdioma_62_RS";
            LblIdioma_62_RS.Size = new Size(47, 15);
            LblIdioma_62_RS.TabIndex = 5;
            LblIdioma_62_RS.Text = "Idioma:";
            // 
            // CmbIdioma_62_RS
            // 
            CmbIdioma_62_RS.FormattingEnabled = true;
            CmbIdioma_62_RS.Location = new Point(84, 12);
            CmbIdioma_62_RS.Name = "CmbIdioma_62_RS";
            CmbIdioma_62_RS.Size = new Size(130, 23);
            CmbIdioma_62_RS.TabIndex = 6;
            // 
            // LogIn_62_RS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 233);
            Controls.Add(CmbIdioma_62_RS);
            Controls.Add(LblIdioma_62_RS);
            Controls.Add(LblContra_62_RS);
            Controls.Add(LblUsuario_62_RS);
            Controls.Add(BtnIniciarSesion_62_RS);
            Controls.Add(TxtContra_62_RS);
            Controls.Add(TxtUsuario_62_RS);
            Name = "LogIn_62_RS";
            Text = "LogIn_62_RS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtUsuario_62_RS;
        private TextBox TxtContra_62_RS;
        private Button BtnIniciarSesion_62_RS;
        private Label LblUsuario_62_RS;
        private Label LblContra_62_RS;
        private Label LblIdioma_62_RS;
        private ComboBox CmbIdioma_62_RS;
    }
}