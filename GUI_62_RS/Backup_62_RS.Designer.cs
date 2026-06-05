namespace GUI_62_RS
{
    partial class Backup_62_RS
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
            RbBackup_62_RS = new RadioButton();
            RbRestore_62_RS = new RadioButton();
            TxtRuta_62_RS = new TextBox();
            BtnBuscar_62_RS = new Button();
            BtnEjecutar_62_RS = new Button();
            LblDirectorio_62_RS = new Label();
            SuspendLayout();
            // 
            // RbBackup_62_RS
            // 
            RbBackup_62_RS.AutoSize = true;
            RbBackup_62_RS.Location = new Point(12, 39);
            RbBackup_62_RS.Name = "RbBackup_62_RS";
            RbBackup_62_RS.Size = new Size(64, 19);
            RbBackup_62_RS.TabIndex = 0;
            RbBackup_62_RS.TabStop = true;
            RbBackup_62_RS.Text = "Backup";
            RbBackup_62_RS.UseVisualStyleBackColor = true;
            RbBackup_62_RS.CheckedChanged += RbBackup_62_RS_CheckedChanged;
            // 
            // RbRestore_62_RS
            // 
            RbRestore_62_RS.AutoSize = true;
            RbRestore_62_RS.Location = new Point(12, 64);
            RbRestore_62_RS.Name = "RbRestore_62_RS";
            RbRestore_62_RS.Size = new Size(64, 19);
            RbRestore_62_RS.TabIndex = 1;
            RbRestore_62_RS.TabStop = true;
            RbRestore_62_RS.Text = "Restore";
            RbRestore_62_RS.UseVisualStyleBackColor = true;
            RbRestore_62_RS.CheckedChanged += RbRestore_62_RS_CheckedChanged;
            // 
            // TxtRuta_62_RS
            // 
            TxtRuta_62_RS.Location = new Point(112, 50);
            TxtRuta_62_RS.Name = "TxtRuta_62_RS";
            TxtRuta_62_RS.Size = new Size(201, 23);
            TxtRuta_62_RS.TabIndex = 2;
            // 
            // BtnBuscar_62_RS
            // 
            BtnBuscar_62_RS.Location = new Point(319, 43);
            BtnBuscar_62_RS.Name = "BtnBuscar_62_RS";
            BtnBuscar_62_RS.Size = new Size(110, 34);
            BtnBuscar_62_RS.TabIndex = 3;
            BtnBuscar_62_RS.Text = "Buscar";
            BtnBuscar_62_RS.UseVisualStyleBackColor = true;
            BtnBuscar_62_RS.Click += BtnBuscar_62_RS_Click;
            // 
            // BtnEjecutar_62_RS
            // 
            BtnEjecutar_62_RS.Location = new Point(136, 93);
            BtnEjecutar_62_RS.Name = "BtnEjecutar_62_RS";
            BtnEjecutar_62_RS.Size = new Size(159, 57);
            BtnEjecutar_62_RS.TabIndex = 4;
            BtnEjecutar_62_RS.Text = "Ejecutar";
            BtnEjecutar_62_RS.UseVisualStyleBackColor = true;
            BtnEjecutar_62_RS.Click += BtnEjecutar_62_RS_Click;
            // 
            // LblDirectorio_62_RS
            // 
            LblDirectorio_62_RS.AutoSize = true;
            LblDirectorio_62_RS.Location = new Point(121, 21);
            LblDirectorio_62_RS.Name = "LblDirectorio_62_RS";
            LblDirectorio_62_RS.Size = new Size(59, 15);
            LblDirectorio_62_RS.TabIndex = 5;
            LblDirectorio_62_RS.Text = "Directorio";
            // 
            // Backup_62_RS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 176);
            Controls.Add(LblDirectorio_62_RS);
            Controls.Add(BtnEjecutar_62_RS);
            Controls.Add(BtnBuscar_62_RS);
            Controls.Add(TxtRuta_62_RS);
            Controls.Add(RbRestore_62_RS);
            Controls.Add(RbBackup_62_RS);
            Name = "Backup_62_RS";
            Text = "Gestión de Copias de Seguridad";
            FormClosed += Backup_62_RS_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton RbBackup_62_RS;
        private RadioButton RbRestore_62_RS;
        private TextBox TxtRuta_62_RS;
        private Button BtnBuscar_62_RS;
        private Button BtnEjecutar_62_RS;
        private Label LblDirectorio_62_RS;
    }
}