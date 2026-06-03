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
            LblMainIdioma_62_RS = new Label();
            CmbIdioma_62_RS = new ComboBox();
            SuspendLayout();
            // 
            // TxtUsuario_62_RS
            // 
            TxtUsuario_62_RS.Location = new Point(146, 72);
            TxtUsuario_62_RS.Margin = new Padding(3, 4, 3, 4);
            TxtUsuario_62_RS.Name = "TxtUsuario_62_RS";
            TxtUsuario_62_RS.Size = new Size(175, 27);
            TxtUsuario_62_RS.TabIndex = 1;
            // 
            // TxtContra_62_RS
            // 
            TxtContra_62_RS.Location = new Point(146, 126);
            TxtContra_62_RS.Margin = new Padding(3, 4, 3, 4);
            TxtContra_62_RS.Name = "TxtContra_62_RS";
            TxtContra_62_RS.PasswordChar = '●';
            TxtContra_62_RS.Size = new Size(175, 27);
            TxtContra_62_RS.TabIndex = 2;
            // 
            // BtnIniciarSesion_62_RS
            // 
            BtnIniciarSesion_62_RS.Location = new Point(9, 163);
            BtnIniciarSesion_62_RS.Margin = new Padding(3, 4, 3, 4);
            BtnIniciarSesion_62_RS.Name = "BtnIniciarSesion_62_RS";
            BtnIniciarSesion_62_RS.Size = new Size(312, 117);
            BtnIniciarSesion_62_RS.TabIndex = 3;
            BtnIniciarSesion_62_RS.Text = "Iniciar Sesion";
            BtnIniciarSesion_62_RS.UseVisualStyleBackColor = true;
            BtnIniciarSesion_62_RS.Click += BtnIniciarSesion_62_RS_Click;
            // 
            // LblUsuario_62_RS
            // 
            LblUsuario_62_RS.AutoSize = true;
            LblUsuario_62_RS.Location = new Point(9, 75);
            LblUsuario_62_RS.Name = "LblUsuario_62_RS";
            LblUsuario_62_RS.Size = new Size(62, 20);
            LblUsuario_62_RS.TabIndex = 3;
            LblUsuario_62_RS.Text = "Usuario:";
            // 
            // LblContra_62_RS
            // 
            LblContra_62_RS.AutoSize = true;
            LblContra_62_RS.Location = new Point(9, 129);
            LblContra_62_RS.Name = "LblContra_62_RS";
            LblContra_62_RS.Size = new Size(86, 20);
            LblContra_62_RS.TabIndex = 4;
            LblContra_62_RS.Text = "Contraseña:";
            // 
            // LblMainIdioma_62_RS
            // 
            LblMainIdioma_62_RS.AutoSize = true;
            LblMainIdioma_62_RS.Location = new Point(9, 19);
            LblMainIdioma_62_RS.Name = "LblMainIdioma_62_RS";
            LblMainIdioma_62_RS.Size = new Size(59, 20);
            LblMainIdioma_62_RS.TabIndex = 5;
            LblMainIdioma_62_RS.Text = "Idioma:";
            // 
            // CmbIdioma_62_RS
            // 
            CmbIdioma_62_RS.FormattingEnabled = true;
            CmbIdioma_62_RS.Location = new Point(146, 16);
            CmbIdioma_62_RS.Margin = new Padding(3, 4, 3, 4);
            CmbIdioma_62_RS.Name = "CmbIdioma_62_RS";
            CmbIdioma_62_RS.Size = new Size(175, 28);
            CmbIdioma_62_RS.TabIndex = 4;
            CmbIdioma_62_RS.SelectedIndexChanged += CmbIdioma_62_RS_SelectedIndexChanged;
            // 
            // LogIn_62_RS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 290);
            Controls.Add(CmbIdioma_62_RS);
            Controls.Add(LblMainIdioma_62_RS);
            Controls.Add(LblContra_62_RS);
            Controls.Add(LblUsuario_62_RS);
            Controls.Add(BtnIniciarSesion_62_RS);
            Controls.Add(TxtContra_62_RS);
            Controls.Add(TxtUsuario_62_RS);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "LogIn_62_RS";
            ShowIcon = false;
            Text = "Iniciar sesión";
            FormClosed += LogIn_62_RS_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtUsuario_62_RS;
        private TextBox TxtContra_62_RS;
        private Button BtnIniciarSesion_62_RS;
        private Label LblUsuario_62_RS;
        private Label LblContra_62_RS;
        private Label LblMainIdioma_62_RS;
        private ComboBox CmbIdioma_62_RS;
    }
}