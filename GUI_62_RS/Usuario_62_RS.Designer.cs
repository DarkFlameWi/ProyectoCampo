namespace GUI_62_RS
{
    partial class Usuario_62_RS
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
            RbActivo_62_RS = new RadioButton();
            RbTodo_62_RS = new RadioButton();
            LblUsuario_62_RS = new Label();
            LblNumUsu_62_RS = new Label();
            LblCantUsu_62_RS = new Label();
            DgvUsu_62_RS = new DataGridView();
            BtnCrear_62_RS = new Button();
            BtnDesbloquear_62_RS = new Button();
            BtnModificar_62_RS = new Button();
            BtnActivar_62_RS = new Button();
            BtnAplicar_62_RS = new Button();
            BtnCancelar_62_RS = new Button();
            BtnSalir_62_RS = new Button();
            GroupBox = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            TxtActivo_62_RS = new TextBox();
            TxtBloqueado_62_RS = new TextBox();
            TxtLogIn_62_RS = new TextBox();
            TxtRol_62_RS = new TextBox();
            TxtEmail_62_RS = new TextBox();
            TxtNombre_62_RS = new TextBox();
            TxtApellido_62_RS = new TextBox();
            LblDni_62_RS = new Label();
            LblApellido_62_RS = new Label();
            LblNombre_62_RS = new Label();
            LblEmail_62_RS = new Label();
            LblRol_62_RS = new Label();
            LblLogIn_62_RS = new Label();
            LblBloqueado_62_RS = new Label();
            LblActivo_62_RS = new Label();
            txtDni_62_RS = new TextBox();
            TxtMensaje_62_RS = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DgvUsu_62_RS).BeginInit();
            GroupBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // RbActivo_62_RS
            // 
            RbActivo_62_RS.AutoSize = true;
            RbActivo_62_RS.Location = new Point(126, 24);
            RbActivo_62_RS.Name = "RbActivo_62_RS";
            RbActivo_62_RS.Size = new Size(72, 19);
            RbActivo_62_RS.TabIndex = 1;
            RbActivo_62_RS.TabStop = true;
            RbActivo_62_RS.Text = "ACTIVOS";
            RbActivo_62_RS.UseVisualStyleBackColor = true;
            // 
            // RbTodo_62_RS
            // 
            RbTodo_62_RS.AutoSize = true;
            RbTodo_62_RS.Location = new Point(238, 24);
            RbTodo_62_RS.Name = "RbTodo_62_RS";
            RbTodo_62_RS.Size = new Size(62, 19);
            RbTodo_62_RS.TabIndex = 2;
            RbTodo_62_RS.TabStop = true;
            RbTodo_62_RS.Text = "TODOS";
            RbTodo_62_RS.UseVisualStyleBackColor = true;
            // 
            // LblUsuario_62_RS
            // 
            LblUsuario_62_RS.AutoSize = true;
            LblUsuario_62_RS.Location = new Point(23, 26);
            LblUsuario_62_RS.Name = "LblUsuario_62_RS";
            LblUsuario_62_RS.Size = new Size(62, 15);
            LblUsuario_62_RS.TabIndex = 3;
            LblUsuario_62_RS.Text = "USUARIOS";
            // 
            // LblNumUsu_62_RS
            // 
            LblNumUsu_62_RS.AutoSize = true;
            LblNumUsu_62_RS.Location = new Point(318, 26);
            LblNumUsu_62_RS.Name = "LblNumUsu_62_RS";
            LblNumUsu_62_RS.Size = new Size(118, 15);
            LblNumUsu_62_RS.TabIndex = 4;
            LblNumUsu_62_RS.Text = "Número de Usuarios:";
            // 
            // LblCantUsu_62_RS
            // 
            LblCantUsu_62_RS.AutoSize = true;
            LblCantUsu_62_RS.Location = new Point(438, 28);
            LblCantUsu_62_RS.Name = "LblCantUsu_62_RS";
            LblCantUsu_62_RS.Size = new Size(38, 15);
            LblCantUsu_62_RS.TabIndex = 5;
            LblCantUsu_62_RS.Text = "label3";
            // 
            // DgvUsu_62_RS
            // 
            DgvUsu_62_RS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvUsu_62_RS.Location = new Point(23, 72);
            DgvUsu_62_RS.Name = "DgvUsu_62_RS";
            DgvUsu_62_RS.RowHeadersWidth = 51;
            DgvUsu_62_RS.Size = new Size(453, 150);
            DgvUsu_62_RS.TabIndex = 6;
            DgvUsu_62_RS.CellClick += DgvUsu_62_RS_CellClick;
            // 
            // BtnCrear_62_RS
            // 
            BtnCrear_62_RS.Location = new Point(501, 25);
            BtnCrear_62_RS.Name = "BtnCrear_62_RS";
            BtnCrear_62_RS.Size = new Size(121, 60);
            BtnCrear_62_RS.TabIndex = 7;
            BtnCrear_62_RS.Text = "Crear";
            BtnCrear_62_RS.UseVisualStyleBackColor = true;
            BtnCrear_62_RS.Click += BtnCrear_62_RS_Click;
            // 
            // BtnDesbloquear_62_RS
            // 
            BtnDesbloquear_62_RS.Location = new Point(501, 91);
            BtnDesbloquear_62_RS.Name = "BtnDesbloquear_62_RS";
            BtnDesbloquear_62_RS.Size = new Size(121, 72);
            BtnDesbloquear_62_RS.TabIndex = 8;
            BtnDesbloquear_62_RS.Text = "Desbloquear";
            BtnDesbloquear_62_RS.UseVisualStyleBackColor = true;
            BtnDesbloquear_62_RS.Click += BtnDesbloquear_62_RS_Click;
            // 
            // BtnModificar_62_RS
            // 
            BtnModificar_62_RS.Location = new Point(501, 169);
            BtnModificar_62_RS.Name = "BtnModificar_62_RS";
            BtnModificar_62_RS.Size = new Size(121, 67);
            BtnModificar_62_RS.TabIndex = 9;
            BtnModificar_62_RS.Text = "Modificar";
            BtnModificar_62_RS.UseVisualStyleBackColor = true;
            BtnModificar_62_RS.Click += BtnModificar_62_RS_Click;
            // 
            // BtnActivar_62_RS
            // 
            BtnActivar_62_RS.Location = new Point(501, 242);
            BtnActivar_62_RS.Name = "BtnActivar_62_RS";
            BtnActivar_62_RS.Size = new Size(121, 67);
            BtnActivar_62_RS.TabIndex = 10;
            BtnActivar_62_RS.Text = "Act. / Desact.";
            BtnActivar_62_RS.UseVisualStyleBackColor = true;
            BtnActivar_62_RS.Click += BtnActivar_62_RS_Click;
            // 
            // BtnAplicar_62_RS
            // 
            BtnAplicar_62_RS.Location = new Point(501, 315);
            BtnAplicar_62_RS.Name = "BtnAplicar_62_RS";
            BtnAplicar_62_RS.Size = new Size(121, 66);
            BtnAplicar_62_RS.TabIndex = 11;
            BtnAplicar_62_RS.Text = "Aplicar";
            BtnAplicar_62_RS.UseVisualStyleBackColor = true;
            // 
            // BtnCancelar_62_RS
            // 
            BtnCancelar_62_RS.Location = new Point(501, 387);
            BtnCancelar_62_RS.Name = "BtnCancelar_62_RS";
            BtnCancelar_62_RS.Size = new Size(121, 61);
            BtnCancelar_62_RS.TabIndex = 12;
            BtnCancelar_62_RS.Text = "Cancelar";
            BtnCancelar_62_RS.UseVisualStyleBackColor = true;
            // 
            // BtnSalir_62_RS
            // 
            BtnSalir_62_RS.Location = new Point(501, 453);
            BtnSalir_62_RS.Name = "BtnSalir_62_RS";
            BtnSalir_62_RS.Size = new Size(121, 50);
            BtnSalir_62_RS.TabIndex = 13;
            BtnSalir_62_RS.Text = "Salir";
            BtnSalir_62_RS.UseVisualStyleBackColor = true;
            // 
            // GroupBox
            // 
            GroupBox.Controls.Add(tableLayoutPanel1);
            GroupBox.Location = new Point(23, 228);
            GroupBox.Name = "GroupBox";
            GroupBox.Size = new Size(277, 261);
            GroupBox.TabIndex = 14;
            GroupBox.TabStop = false;
            GroupBox.Text = "DATOS:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(TxtActivo_62_RS, 1, 7);
            tableLayoutPanel1.Controls.Add(TxtBloqueado_62_RS, 1, 6);
            tableLayoutPanel1.Controls.Add(TxtLogIn_62_RS, 1, 5);
            tableLayoutPanel1.Controls.Add(TxtRol_62_RS, 1, 4);
            tableLayoutPanel1.Controls.Add(TxtEmail_62_RS, 1, 3);
            tableLayoutPanel1.Controls.Add(TxtNombre_62_RS, 1, 2);
            tableLayoutPanel1.Controls.Add(TxtApellido_62_RS, 1, 1);
            tableLayoutPanel1.Controls.Add(LblDni_62_RS, 0, 0);
            tableLayoutPanel1.Controls.Add(LblApellido_62_RS, 0, 1);
            tableLayoutPanel1.Controls.Add(LblNombre_62_RS, 0, 2);
            tableLayoutPanel1.Controls.Add(LblEmail_62_RS, 0, 3);
            tableLayoutPanel1.Controls.Add(LblRol_62_RS, 0, 4);
            tableLayoutPanel1.Controls.Add(LblLogIn_62_RS, 0, 5);
            tableLayoutPanel1.Controls.Add(LblBloqueado_62_RS, 0, 6);
            tableLayoutPanel1.Controls.Add(LblActivo_62_RS, 0, 7);
            tableLayoutPanel1.Controls.Add(txtDni_62_RS, 1, 0);
            tableLayoutPanel1.Location = new Point(6, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(271, 233);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtActivo_62_RS
            // 
            TxtActivo_62_RS.Location = new Point(138, 206);
            TxtActivo_62_RS.Name = "TxtActivo_62_RS";
            TxtActivo_62_RS.Size = new Size(130, 23);
            TxtActivo_62_RS.TabIndex = 15;
            // 
            // TxtBloqueado_62_RS
            // 
            TxtBloqueado_62_RS.Location = new Point(138, 177);
            TxtBloqueado_62_RS.Name = "TxtBloqueado_62_RS";
            TxtBloqueado_62_RS.Size = new Size(130, 23);
            TxtBloqueado_62_RS.TabIndex = 14;
            // 
            // TxtLogIn_62_RS
            // 
            TxtLogIn_62_RS.Location = new Point(138, 148);
            TxtLogIn_62_RS.Name = "TxtLogIn_62_RS";
            TxtLogIn_62_RS.Size = new Size(130, 23);
            TxtLogIn_62_RS.TabIndex = 13;
            // 
            // TxtRol_62_RS
            // 
            TxtRol_62_RS.Location = new Point(138, 119);
            TxtRol_62_RS.Name = "TxtRol_62_RS";
            TxtRol_62_RS.Size = new Size(130, 23);
            TxtRol_62_RS.TabIndex = 12;
            // 
            // TxtEmail_62_RS
            // 
            TxtEmail_62_RS.Location = new Point(138, 90);
            TxtEmail_62_RS.Name = "TxtEmail_62_RS";
            TxtEmail_62_RS.Size = new Size(130, 23);
            TxtEmail_62_RS.TabIndex = 11;
            // 
            // TxtNombre_62_RS
            // 
            TxtNombre_62_RS.Location = new Point(138, 61);
            TxtNombre_62_RS.Name = "TxtNombre_62_RS";
            TxtNombre_62_RS.Size = new Size(130, 23);
            TxtNombre_62_RS.TabIndex = 10;
            // 
            // TxtApellido_62_RS
            // 
            TxtApellido_62_RS.Location = new Point(138, 32);
            TxtApellido_62_RS.Name = "TxtApellido_62_RS";
            TxtApellido_62_RS.Size = new Size(130, 23);
            TxtApellido_62_RS.TabIndex = 9;
            // 
            // LblDni_62_RS
            // 
            LblDni_62_RS.AutoSize = true;
            LblDni_62_RS.Location = new Point(3, 0);
            LblDni_62_RS.Name = "LblDni_62_RS";
            LblDni_62_RS.Size = new Size(30, 15);
            LblDni_62_RS.TabIndex = 0;
            LblDni_62_RS.Text = "DNI:";
            // 
            // LblApellido_62_RS
            // 
            LblApellido_62_RS.AutoSize = true;
            LblApellido_62_RS.Location = new Point(3, 29);
            LblApellido_62_RS.Name = "LblApellido_62_RS";
            LblApellido_62_RS.Size = new Size(59, 15);
            LblApellido_62_RS.TabIndex = 1;
            LblApellido_62_RS.Text = "Apellidos:";
            // 
            // LblNombre_62_RS
            // 
            LblNombre_62_RS.AutoSize = true;
            LblNombre_62_RS.Location = new Point(3, 58);
            LblNombre_62_RS.Name = "LblNombre_62_RS";
            LblNombre_62_RS.Size = new Size(59, 15);
            LblNombre_62_RS.TabIndex = 2;
            LblNombre_62_RS.Text = "Nombres:";
            // 
            // LblEmail_62_RS
            // 
            LblEmail_62_RS.AutoSize = true;
            LblEmail_62_RS.Location = new Point(3, 87);
            LblEmail_62_RS.Name = "LblEmail_62_RS";
            LblEmail_62_RS.Size = new Size(39, 15);
            LblEmail_62_RS.TabIndex = 3;
            LblEmail_62_RS.Text = "Email:";
            // 
            // LblRol_62_RS
            // 
            LblRol_62_RS.AutoSize = true;
            LblRol_62_RS.Location = new Point(3, 116);
            LblRol_62_RS.Name = "LblRol_62_RS";
            LblRol_62_RS.Size = new Size(27, 15);
            LblRol_62_RS.TabIndex = 4;
            LblRol_62_RS.Text = "Rol:";
            // 
            // LblLogIn_62_RS
            // 
            LblLogIn_62_RS.AutoSize = true;
            LblLogIn_62_RS.Location = new Point(3, 145);
            LblLogIn_62_RS.Name = "LblLogIn_62_RS";
            LblLogIn_62_RS.Size = new Size(40, 15);
            LblLogIn_62_RS.TabIndex = 5;
            LblLogIn_62_RS.Text = "LogIn:";
            // 
            // LblBloqueado_62_RS
            // 
            LblBloqueado_62_RS.AutoSize = true;
            LblBloqueado_62_RS.Location = new Point(3, 174);
            LblBloqueado_62_RS.Name = "LblBloqueado_62_RS";
            LblBloqueado_62_RS.Size = new Size(67, 15);
            LblBloqueado_62_RS.TabIndex = 6;
            LblBloqueado_62_RS.Text = "Bloqueado:";
            // 
            // LblActivo_62_RS
            // 
            LblActivo_62_RS.AutoSize = true;
            LblActivo_62_RS.Location = new Point(3, 203);
            LblActivo_62_RS.Name = "LblActivo_62_RS";
            LblActivo_62_RS.Size = new Size(44, 15);
            LblActivo_62_RS.TabIndex = 7;
            LblActivo_62_RS.Text = "Activo:";
            // 
            // txtDni_62_RS
            // 
            txtDni_62_RS.Location = new Point(138, 3);
            txtDni_62_RS.Name = "txtDni_62_RS";
            txtDni_62_RS.Size = new Size(130, 23);
            txtDni_62_RS.TabIndex = 8;
            // 
            // TxtMensaje_62_RS
            // 
            TxtMensaje_62_RS.Location = new Point(318, 242);
            TxtMensaje_62_RS.Multiline = true;
            TxtMensaje_62_RS.Name = "TxtMensaje_62_RS";
            TxtMensaje_62_RS.Size = new Size(158, 168);
            TxtMensaje_62_RS.TabIndex = 15;
            // 
            // Usuario_62_RS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 512);
            Controls.Add(TxtMensaje_62_RS);
            Controls.Add(GroupBox);
            Controls.Add(BtnSalir_62_RS);
            Controls.Add(BtnCancelar_62_RS);
            Controls.Add(BtnAplicar_62_RS);
            Controls.Add(BtnActivar_62_RS);
            Controls.Add(BtnModificar_62_RS);
            Controls.Add(BtnDesbloquear_62_RS);
            Controls.Add(BtnCrear_62_RS);
            Controls.Add(DgvUsu_62_RS);
            Controls.Add(LblCantUsu_62_RS);
            Controls.Add(LblNumUsu_62_RS);
            Controls.Add(LblUsuario_62_RS);
            Controls.Add(RbTodo_62_RS);
            Controls.Add(RbActivo_62_RS);
            Name = "Usuario_62_RS";
            Text = "Usuario";
            ((System.ComponentModel.ISupportInitialize)DgvUsu_62_RS).EndInit();
            GroupBox.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton RbActivo_62_RS;
        private RadioButton RbTodo_62_RS;
        private Label LblUsuario_62_RS;
        private Label LblNumUsu_62_RS;
        private Label LblCantUsu_62_RS;
        private DataGridView DgvUsu_62_RS;
        private Button BtnCrear_62_RS;
        private Button BtnDesbloquear_62_RS;
        private Button BtnModificar_62_RS;
        private Button BtnActivar_62_RS;
        private Button BtnAplicar_62_RS;
        private Button BtnCancelar_62_RS;
        private Button BtnSalir_62_RS;
        private GroupBox GroupBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LblDni_62_RS;
        private Label LblApellido_62_RS;
        private Label LblNombre_62_RS;
        private Label LblEmail_62_RS;
        private Label LblRol_62_RS;
        private Label LblLogIn_62_RS;
        private Label LblBloqueado_62_RS;
        private Label LblActivo_62_RS;
        private TextBox TxtActivo_62_RS;
        private TextBox TxtBloqueado_62_RS;
        private TextBox TxtLogIn_62_RS;
        private TextBox TxtRol_62_RS;
        private TextBox TxtEmail_62_RS;
        private TextBox TxtNombre_62_RS;
        private TextBox TxtApellido_62_RS;
        private TextBox txtDni_62_RS;
        private TextBox TxtMensaje_62_RS;
    }
}