namespace GUI_62_RS
{
    partial class CambiarIdioma_62_RS
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
            TxtUsu_62_RS = new TextBox();
            LblIdioma_62_RS = new Label();
            cmbIdioma_62_RS = new ComboBox();
            BtnIdioma_62_RS = new Button();
            SuspendLayout();
            // 
            // TxtUsu_62_RS
            // 
            TxtUsu_62_RS.Enabled = false;
            TxtUsu_62_RS.Location = new Point(32, 12);
            TxtUsu_62_RS.Name = "TxtUsu_62_RS";
            TxtUsu_62_RS.Size = new Size(178, 23);
            TxtUsu_62_RS.TabIndex = 0;
            // 
            // LblIdioma_62_RS
            // 
            LblIdioma_62_RS.AutoSize = true;
            LblIdioma_62_RS.Location = new Point(32, 53);
            LblIdioma_62_RS.Name = "LblIdioma_62_RS";
            LblIdioma_62_RS.Size = new Size(134, 15);
            LblIdioma_62_RS.TabIndex = 1;
            LblIdioma_62_RS.Text = "Eliga el idioma deseado:";
            // 
            // cmbIdioma_62_RS
            // 
            cmbIdioma_62_RS.FormattingEnabled = true;
            cmbIdioma_62_RS.Location = new Point(32, 71);
            cmbIdioma_62_RS.Name = "cmbIdioma_62_RS";
            cmbIdioma_62_RS.Size = new Size(178, 23);
            cmbIdioma_62_RS.TabIndex = 2;
            // 
            // BtnIdioma_62_RS
            // 
            BtnIdioma_62_RS.Location = new Point(32, 104);
            BtnIdioma_62_RS.Name = "BtnIdioma_62_RS";
            BtnIdioma_62_RS.Size = new Size(178, 62);
            BtnIdioma_62_RS.TabIndex = 3;
            BtnIdioma_62_RS.Text = "Cambiar Idioma";
            BtnIdioma_62_RS.UseVisualStyleBackColor = true;
            BtnIdioma_62_RS.Click += BtnIdioma_62_RS_Click;
            // 
            // CambiarIdioma_62_RS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 178);
            Controls.Add(BtnIdioma_62_RS);
            Controls.Add(cmbIdioma_62_RS);
            Controls.Add(LblIdioma_62_RS);
            Controls.Add(TxtUsu_62_RS);
            Name = "CambiarIdioma_62_RS";
            Text = "Cambio de idioma";
            FormClosed += CambiarIdioma_62_RS_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtUsu_62_RS;
        private Label LblIdioma_62_RS;
        private ComboBox cmbIdioma_62_RS;
        private Button BtnIdioma_62_RS;
    }
}