namespace GUI_62_RS
{
    partial class Bitacora_62_RS
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
            label1 = new Label();
            DgvBit_62_RS = new DataGridView();
            BtnSalir_62_RS = new Button();
            label2 = new Label();
            label3 = new Label();
            TxtNombre_62_RS = new TextBox();
            TxtApellido_62_RS = new TextBox();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            DtpFecFin_62_RS = new DateTimePicker();
            CmbCriti_62_RS = new ComboBox();
            CmbEvento_62_RS = new ComboBox();
            CmbModulo_62_RS = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            CmbLogin_62_RS = new ComboBox();
            DtpFecIni_62_RS = new DateTimePicker();
            panel20 = new Panel();
            panel19 = new Panel();
            panel18 = new Panel();
            BtnLimpiar_62_RS = new Button();
            BtnAplicar_62_RS = new Button();
            BtnImprimir_62_RS = new Button();
            panel1 = new Panel();
            panel12 = new Panel();
            panel10 = new Panel();
            panel11 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            panel2 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel13 = new Panel();
            panel14 = new Panel();
            panel15 = new Panel();
            panel17 = new Panel();
            panel16 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DgvBit_62_RS).BeginInit();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel15.SuspendLayout();
            panel17.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(215, 26);
            label1.TabIndex = 0;
            label1.Text = "BITACORA DE EVENTOS";
            // 
            // DgvBit_62_RS
            // 
            DgvBit_62_RS.AllowUserToAddRows = false;
            DgvBit_62_RS.AllowUserToDeleteRows = false;
            DgvBit_62_RS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvBit_62_RS.Dock = DockStyle.Fill;
            DgvBit_62_RS.Location = new Point(0, 62);
            DgvBit_62_RS.Name = "DgvBit_62_RS";
            DgvBit_62_RS.RowHeadersWidth = 51;
            DgvBit_62_RS.ShowEditingIcon = false;
            DgvBit_62_RS.Size = new Size(737, 183);
            DgvBit_62_RS.TabIndex = 1;
            DgvBit_62_RS.SelectionChanged += DgvBit_62_RS_SelectionChanged;
            // 
            // BtnSalir_62_RS
            // 
            BtnSalir_62_RS.Location = new Point(3, 10);
            BtnSalir_62_RS.Name = "BtnSalir_62_RS";
            BtnSalir_62_RS.Size = new Size(174, 49);
            BtnSalir_62_RS.TabIndex = 2;
            BtnSalir_62_RS.Text = "SALIR";
            BtnSalir_62_RS.UseVisualStyleBackColor = true;
            BtnSalir_62_RS.Click += BtnSalir_62_RS_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(108, 12);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(343, 13);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 4;
            label3.Text = "Apellido:";
            // 
            // TxtNombre_62_RS
            // 
            TxtNombre_62_RS.Enabled = false;
            TxtNombre_62_RS.Location = new Point(169, 9);
            TxtNombre_62_RS.Name = "TxtNombre_62_RS";
            TxtNombre_62_RS.Size = new Size(155, 23);
            TxtNombre_62_RS.TabIndex = 5;
            // 
            // TxtApellido_62_RS
            // 
            TxtApellido_62_RS.Enabled = false;
            TxtApellido_62_RS.Location = new Point(420, 10);
            TxtApellido_62_RS.Name = "TxtApellido_62_RS";
            TxtApellido_62_RS.Size = new Size(174, 23);
            TxtApellido_62_RS.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Controls.Add(panel20);
            groupBox1.Controls.Add(panel19);
            groupBox1.Controls.Add(panel18);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(20, 280);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(737, 84);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(DtpFecFin_62_RS, 5, 0);
            tableLayoutPanel1.Controls.Add(CmbCriti_62_RS, 5, 1);
            tableLayoutPanel1.Controls.Add(CmbEvento_62_RS, 3, 1);
            tableLayoutPanel1.Controls.Add(CmbModulo_62_RS, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Controls.Add(label6, 2, 0);
            tableLayoutPanel1.Controls.Add(label7, 2, 1);
            tableLayoutPanel1.Controls.Add(label8, 4, 0);
            tableLayoutPanel1.Controls.Add(label9, 4, 1);
            tableLayoutPanel1.Controls.Add(CmbLogin_62_RS, 1, 0);
            tableLayoutPanel1.Controls.Add(DtpFecIni_62_RS, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.ImeMode = ImeMode.On;
            tableLayoutPanel1.Location = new Point(14, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(705, 62);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // DtpFecFin_62_RS
            // 
            DtpFecFin_62_RS.Format = DateTimePickerFormat.Short;
            DtpFecFin_62_RS.Location = new Point(588, 3);
            DtpFecFin_62_RS.Name = "DtpFecFin_62_RS";
            DtpFecFin_62_RS.Size = new Size(111, 23);
            DtpFecFin_62_RS.TabIndex = 17;
            // 
            // CmbCriti_62_RS
            // 
            CmbCriti_62_RS.FormattingEnabled = true;
            CmbCriti_62_RS.Location = new Point(588, 34);
            CmbCriti_62_RS.Name = "CmbCriti_62_RS";
            CmbCriti_62_RS.Size = new Size(111, 23);
            CmbCriti_62_RS.TabIndex = 15;
            // 
            // CmbEvento_62_RS
            // 
            CmbEvento_62_RS.FormattingEnabled = true;
            CmbEvento_62_RS.Location = new Point(354, 34);
            CmbEvento_62_RS.Name = "CmbEvento_62_RS";
            CmbEvento_62_RS.Size = new Size(111, 23);
            CmbEvento_62_RS.TabIndex = 14;
            // 
            // CmbModulo_62_RS
            // 
            CmbModulo_62_RS.FormattingEnabled = true;
            CmbModulo_62_RS.Location = new Point(120, 34);
            CmbModulo_62_RS.Name = "CmbModulo_62_RS";
            CmbModulo_62_RS.Size = new Size(111, 23);
            CmbModulo_62_RS.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 0;
            label4.Text = "LOGIN:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 31);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 1;
            label5.Text = "MODULO:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(237, 0);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 2;
            label6.Text = "FECHA INICIO:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(237, 31);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 3;
            label7.Text = "EVENTO:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(471, 0);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 4;
            label8.Text = "FECHA FIN:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(471, 31);
            label9.Name = "label9";
            label9.Size = new Size(69, 15);
            label9.TabIndex = 5;
            label9.Text = "CRITICIDAD";
            // 
            // CmbLogin_62_RS
            // 
            CmbLogin_62_RS.FormattingEnabled = true;
            CmbLogin_62_RS.Location = new Point(120, 3);
            CmbLogin_62_RS.Name = "CmbLogin_62_RS";
            CmbLogin_62_RS.Size = new Size(111, 23);
            CmbLogin_62_RS.TabIndex = 12;
            // 
            // DtpFecIni_62_RS
            // 
            DtpFecIni_62_RS.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            DtpFecIni_62_RS.Format = DateTimePickerFormat.Custom;
            DtpFecIni_62_RS.Location = new Point(354, 3);
            DtpFecIni_62_RS.Name = "DtpFecIni_62_RS";
            DtpFecIni_62_RS.Size = new Size(111, 23);
            DtpFecIni_62_RS.TabIndex = 16;
            // 
            // panel20
            // 
            panel20.Dock = DockStyle.Fill;
            panel20.Location = new Point(14, 19);
            panel20.Margin = new Padding(3, 2, 3, 2);
            panel20.Name = "panel20";
            panel20.Size = new Size(705, 62);
            panel20.TabIndex = 3;
            // 
            // panel19
            // 
            panel19.Dock = DockStyle.Right;
            panel19.Location = new Point(719, 19);
            panel19.Margin = new Padding(3, 2, 3, 2);
            panel19.Name = "panel19";
            panel19.Size = new Size(15, 62);
            panel19.TabIndex = 2;
            // 
            // panel18
            // 
            panel18.Dock = DockStyle.Left;
            panel18.Location = new Point(3, 19);
            panel18.Margin = new Padding(3, 2, 3, 2);
            panel18.Name = "panel18";
            panel18.Size = new Size(11, 62);
            panel18.TabIndex = 1;
            // 
            // BtnLimpiar_62_RS
            // 
            BtnLimpiar_62_RS.Location = new Point(10, 4);
            BtnLimpiar_62_RS.Name = "BtnLimpiar_62_RS";
            BtnLimpiar_62_RS.Size = new Size(174, 49);
            BtnLimpiar_62_RS.TabIndex = 8;
            BtnLimpiar_62_RS.Text = "LIMPIAR";
            BtnLimpiar_62_RS.UseVisualStyleBackColor = true;
            BtnLimpiar_62_RS.Click += BtnLimpiar_62_RS_Click;
            // 
            // BtnAplicar_62_RS
            // 
            BtnAplicar_62_RS.Location = new Point(3, 3);
            BtnAplicar_62_RS.Name = "BtnAplicar_62_RS";
            BtnAplicar_62_RS.Size = new Size(174, 49);
            BtnAplicar_62_RS.TabIndex = 9;
            BtnAplicar_62_RS.Text = "APLICAR";
            BtnAplicar_62_RS.UseVisualStyleBackColor = true;
            BtnAplicar_62_RS.Click += BtnAplicar_62_RS_Click;
            // 
            // BtnImprimir_62_RS
            // 
            BtnImprimir_62_RS.Location = new Point(8, 4);
            BtnImprimir_62_RS.Name = "BtnImprimir_62_RS";
            BtnImprimir_62_RS.Size = new Size(174, 49);
            BtnImprimir_62_RS.TabIndex = 10;
            BtnImprimir_62_RS.Text = "IMPRIMIR";
            BtnImprimir_62_RS.UseVisualStyleBackColor = true;
            BtnImprimir_62_RS.Click += BtnImprimir_62_RS_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel12);
            panel1.Controls.Add(panel10);
            panel1.Controls.Add(panel11);
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(panel8);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 364);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(779, 60);
            panel1.TabIndex = 11;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(481, 0);
            panel12.Margin = new Padding(3, 2, 3, 2);
            panel12.Name = "panel12";
            panel12.Size = new Size(110, 60);
            panel12.TabIndex = 15;
            // 
            // panel10
            // 
            panel10.Controls.Add(BtnAplicar_62_RS);
            panel10.Dock = DockStyle.Left;
            panel10.Location = new Point(297, 0);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(184, 60);
            panel10.TabIndex = 13;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Left;
            panel11.Location = new Point(190, 0);
            panel11.Margin = new Padding(3, 2, 3, 2);
            panel11.Name = "panel11";
            panel11.Size = new Size(107, 60);
            panel11.TabIndex = 14;
            // 
            // panel9
            // 
            panel9.Controls.Add(BtnImprimir_62_RS);
            panel9.Dock = DockStyle.Right;
            panel9.Location = new Point(591, 0);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(188, 60);
            panel9.TabIndex = 12;
            // 
            // panel8
            // 
            panel8.Controls.Add(BtnLimpiar_62_RS);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(190, 60);
            panel8.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(DgvBit_62_RS);
            panel2.Controls.Add(panel6);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(737, 245);
            panel2.TabIndex = 12;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(737, 62);
            panel6.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.Controls.Add(BtnSalir_62_RS);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(558, 0);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(179, 62);
            panel7.TabIndex = 3;
            // 
            // panel13
            // 
            panel13.Dock = DockStyle.Left;
            panel13.Location = new Point(0, 0);
            panel13.Margin = new Padding(3, 2, 3, 2);
            panel13.Name = "panel13";
            panel13.Size = new Size(20, 364);
            panel13.TabIndex = 13;
            // 
            // panel14
            // 
            panel14.Dock = DockStyle.Right;
            panel14.Location = new Point(757, 0);
            panel14.Margin = new Padding(3, 2, 3, 2);
            panel14.Name = "panel14";
            panel14.Size = new Size(22, 364);
            panel14.TabIndex = 14;
            // 
            // panel15
            // 
            panel15.Controls.Add(panel17);
            panel15.Controls.Add(panel16);
            panel15.Dock = DockStyle.Bottom;
            panel15.Location = new Point(20, 245);
            panel15.Margin = new Padding(3, 2, 3, 2);
            panel15.Name = "panel15";
            panel15.Size = new Size(737, 35);
            panel15.TabIndex = 15;
            // 
            // panel17
            // 
            panel17.Controls.Add(label2);
            panel17.Controls.Add(TxtNombre_62_RS);
            panel17.Controls.Add(TxtApellido_62_RS);
            panel17.Controls.Add(label3);
            panel17.Dock = DockStyle.Fill;
            panel17.Location = new Point(25, 0);
            panel17.Margin = new Padding(3, 2, 3, 2);
            panel17.Name = "panel17";
            panel17.Size = new Size(712, 35);
            panel17.TabIndex = 8;
            // 
            // panel16
            // 
            panel16.Dock = DockStyle.Left;
            panel16.Location = new Point(0, 0);
            panel16.Margin = new Padding(3, 2, 3, 2);
            panel16.Name = "panel16";
            panel16.Size = new Size(25, 35);
            panel16.TabIndex = 7;
            // 
            // Bitacora_62_RS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 424);
            Controls.Add(panel2);
            Controls.Add(panel15);
            Controls.Add(groupBox1);
            Controls.Add(panel14);
            Controls.Add(panel13);
            Controls.Add(panel1);
            Name = "Bitacora_62_RS";
            Text = "Bitacora_62_RS";
            FormClosed += Bitacora_62_RS_FormClosed;
            ((System.ComponentModel.ISupportInitialize)DgvBit_62_RS).EndInit();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView DgvBit_62_RS;
        private Button BtnSalir_62_RS;
        private Label label2;
        private Label label3;
        private TextBox TxtNombre_62_RS;
        private TextBox TxtApellido_62_RS;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button BtnLimpiar_62_RS;
        private Button BtnAplicar_62_RS;
        private Button BtnImprimir_62_RS;
        private Panel panel1;
        private Panel panel2;
        private Panel panel6;
        private Panel panel10;
        private Panel panel12;
        private Panel panel11;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel20;
        private Panel panel19;
        private Panel panel18;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Panel panel17;
        private Panel panel16;
        private DateTimePicker DtpFecFin_62_RS;
        private ComboBox CmbCriti_62_RS;
        private ComboBox CmbEvento_62_RS;
        private ComboBox CmbModulo_62_RS;
        private ComboBox CmbLogin_62_RS;
        private DateTimePicker DtpFecIni_62_RS;
    }
}