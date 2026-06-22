namespace GUI_62_RS
{
    partial class DVV_62_RS
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
            dataGridView1 = new DataGridView();
            BtnRecalcular_62_RS = new Button();
            BtnRestore_62_RS = new Button();
            BtnSalir_62_RS = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(440, 205);
            dataGridView1.TabIndex = 0;
            // 
            // BtnRecalcular_62_RS
            // 
            BtnRecalcular_62_RS.Location = new Point(12, 223);
            BtnRecalcular_62_RS.Name = "BtnRecalcular_62_RS";
            BtnRecalcular_62_RS.Size = new Size(116, 71);
            BtnRecalcular_62_RS.TabIndex = 1;
            BtnRecalcular_62_RS.Text = "Recalcular";
            BtnRecalcular_62_RS.UseVisualStyleBackColor = true;
            BtnRecalcular_62_RS.Click += BtnRecalcular_62_RS_Click;
            // 
            // BtnRestore_62_RS
            // 
            BtnRestore_62_RS.Location = new Point(171, 223);
            BtnRestore_62_RS.Name = "BtnRestore_62_RS";
            BtnRestore_62_RS.Size = new Size(116, 71);
            BtnRestore_62_RS.TabIndex = 2;
            BtnRestore_62_RS.Text = "Restore";
            BtnRestore_62_RS.UseVisualStyleBackColor = true;
            BtnRestore_62_RS.Click += BtnRestore_62_RS_Click;
            // 
            // BtnSalir_62_RS
            // 
            BtnSalir_62_RS.Location = new Point(336, 223);
            BtnSalir_62_RS.Name = "BtnSalir_62_RS";
            BtnSalir_62_RS.Size = new Size(116, 71);
            BtnSalir_62_RS.TabIndex = 3;
            BtnSalir_62_RS.Text = "SALIR";
            BtnSalir_62_RS.UseVisualStyleBackColor = true;
            BtnSalir_62_RS.Click += BtnSalir_62_RS_Click;
            // 
            // DVV_62_RS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 303);
            Controls.Add(BtnSalir_62_RS);
            Controls.Add(BtnRestore_62_RS);
            Controls.Add(BtnRecalcular_62_RS);
            Controls.Add(dataGridView1);
            Name = "DVV_62_RS";
            Text = "DVV_62_RS";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button BtnRecalcular_62_RS;
        private Button BtnRestore_62_RS;
        private Button BtnSalir_62_RS;
    }
}