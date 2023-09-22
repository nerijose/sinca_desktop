namespace Crm.Inventario
{
    partial class FrmCompletarTapda
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
            this.CmbNoPredio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbMaguey = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPredioDesconocido = new System.Windows.Forms.TextBox();
            this.TxtExistencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtExtraccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CmbMagueyNoRegistrado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DtaAgaveCompletarTapada = new System.Windows.Forms.DataGridView();
            this.BtnAgregarAgaveCocido = new System.Windows.Forms.Button();
            this.TxtCampo = new System.Windows.Forms.TextBox();
            this.ChekMagueyComprado = new System.Windows.Forms.CheckBox();
            this.TxtNoGuia = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.TxtNoPredio = new System.Windows.Forms.TextBox();
            this.chkGuiaAntigua = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbEspecieMaguey = new System.Windows.Forms.ComboBox();
            this.chkGuiaCrm = new System.Windows.Forms.CheckBox();
            this.chkGuiaAmma = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPredioCrm = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveCompletarTapada)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbNoPredio
            // 
            this.CmbNoPredio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbNoPredio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNoPredio.FormattingEnabled = true;
            this.CmbNoPredio.Location = new System.Drawing.Point(112, 165);
            this.CmbNoPredio.Name = "CmbNoPredio";
            this.CmbNoPredio.Size = new System.Drawing.Size(96, 21);
            this.CmbNoPredio.TabIndex = 318;
            this.CmbNoPredio.Visible = false;
            this.CmbNoPredio.SelectedIndexChanged += new System.EventHandler(this.CmbNoPredio_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 319;
            this.label1.Text = "No Predio :";
            // 
            // CmbMaguey
            // 
            this.CmbMaguey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbMaguey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaguey.DropDownWidth = 300;
            this.CmbMaguey.FormattingEnabled = true;
            this.CmbMaguey.Location = new System.Drawing.Point(112, 251);
            this.CmbMaguey.Name = "CmbMaguey";
            this.CmbMaguey.Size = new System.Drawing.Size(277, 21);
            this.CmbMaguey.TabIndex = 321;
            this.CmbMaguey.SelectedIndexChanged += new System.EventHandler(this.CmbMaguey_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 325;
            this.label3.Text = "Maguey :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 324;
            this.label2.Text = "Predio :";
            // 
            // TxtPredioDesconocido
            // 
            this.TxtPredioDesconocido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtPredioDesconocido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtPredioDesconocido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtPredioDesconocido.Location = new System.Drawing.Point(112, 193);
            this.TxtPredioDesconocido.MaxLength = 9;
            this.TxtPredioDesconocido.Name = "TxtPredioDesconocido";
            this.TxtPredioDesconocido.ReadOnly = true;
            this.TxtPredioDesconocido.Size = new System.Drawing.Size(277, 20);
            this.TxtPredioDesconocido.TabIndex = 320;
            // 
            // TxtExistencia
            // 
            this.TxtExistencia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtExistencia.Location = new System.Drawing.Point(112, 289);
            this.TxtExistencia.Name = "TxtExistencia";
            this.TxtExistencia.ReadOnly = true;
            this.TxtExistencia.Size = new System.Drawing.Size(96, 20);
            this.TxtExistencia.TabIndex = 322;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 323;
            this.label6.Text = "Existencia :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(358, 54);
            this.label4.TabIndex = 327;
            this.label4.Text = "Esta producción fue guardada sin asignarle un maguey,\r\nes momento de hacerlo. Sel" +
    "ecciona el predio y  maguey\r\nque se utilizó para esta producción.";
            // 
            // TxtExtraccion
            // 
            this.TxtExtraccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtExtraccion.Location = new System.Drawing.Point(112, 370);
            this.TxtExtraccion.MaxLength = 9;
            this.TxtExtraccion.Name = "TxtExtraccion";
            this.TxtExtraccion.ReadOnly = true;
            this.TxtExtraccion.Size = new System.Drawing.Size(96, 20);
            this.TxtExtraccion.TabIndex = 328;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 329;
            this.label5.Text = "No piñas :";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(215, 478);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 326;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Crm.Properties.Resources.sprout;
            this.pictureBox1.Location = new System.Drawing.Point(352, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 125);
            this.pictureBox1.TabIndex = 316;
            this.pictureBox1.TabStop = false;
            // 
            // CmbMagueyNoRegistrado
            // 
            this.CmbMagueyNoRegistrado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbMagueyNoRegistrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMagueyNoRegistrado.FormattingEnabled = true;
            this.CmbMagueyNoRegistrado.Location = new System.Drawing.Point(112, 334);
            this.CmbMagueyNoRegistrado.Name = "CmbMagueyNoRegistrado";
            this.CmbMagueyNoRegistrado.Size = new System.Drawing.Size(277, 21);
            this.CmbMagueyNoRegistrado.TabIndex = 330;
            this.CmbMagueyNoRegistrado.SelectedIndexChanged += new System.EventHandler(this.CmbMagueyNoRegistrado_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 18);
            this.label7.TabIndex = 331;
            this.label7.Text = "Maguey :";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(109, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 18);
            this.label8.TabIndex = 332;
            this.label8.Text = "Maguey no registrado";
            // 
            // DtaAgaveCompletarTapada
            // 
            this.DtaAgaveCompletarTapada.AllowUserToAddRows = false;
            this.DtaAgaveCompletarTapada.AllowUserToDeleteRows = false;
            this.DtaAgaveCompletarTapada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaAgaveCompletarTapada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaAgaveCompletarTapada.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaAgaveCompletarTapada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DtaAgaveCompletarTapada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaAgaveCompletarTapada.Location = new System.Drawing.Point(112, 397);
            this.DtaAgaveCompletarTapada.Name = "DtaAgaveCompletarTapada";
            this.DtaAgaveCompletarTapada.ReadOnly = true;
            this.DtaAgaveCompletarTapada.Size = new System.Drawing.Size(277, 71);
            this.DtaAgaveCompletarTapada.TabIndex = 333;
            this.DtaAgaveCompletarTapada.TabStop = false;
            this.DtaAgaveCompletarTapada.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaAgaveCompletarTapada_CellDoubleClick);
            // 
            // BtnAgregarAgaveCocido
            // 
            this.BtnAgregarAgaveCocido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAgregarAgaveCocido.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarAgaveCocido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarAgaveCocido.FlatAppearance.BorderSize = 0;
            this.BtnAgregarAgaveCocido.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarAgaveCocido.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarAgaveCocido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarAgaveCocido.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarAgaveCocido.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarAgaveCocido.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnAgregarAgaveCocido.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarAgaveCocido.Location = new System.Drawing.Point(228, 361);
            this.BtnAgregarAgaveCocido.Name = "BtnAgregarAgaveCocido";
            this.BtnAgregarAgaveCocido.Size = new System.Drawing.Size(26, 28);
            this.BtnAgregarAgaveCocido.TabIndex = 334;
            this.BtnAgregarAgaveCocido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarAgaveCocido.UseVisualStyleBackColor = false;
            this.BtnAgregarAgaveCocido.Click += new System.EventHandler(this.BtnAgregarAgaveCocido_Click);
            // 
            // TxtCampo
            // 
            this.TxtCampo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtCampo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtCampo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtCampo.Location = new System.Drawing.Point(112, 334);
            this.TxtCampo.MaxLength = 9;
            this.TxtCampo.Name = "TxtCampo";
            this.TxtCampo.ReadOnly = true;
            this.TxtCampo.Size = new System.Drawing.Size(277, 20);
            this.TxtCampo.TabIndex = 335;
            // 
            // ChekMagueyComprado
            // 
            this.ChekMagueyComprado.AutoSize = true;
            this.ChekMagueyComprado.Location = new System.Drawing.Point(215, 292);
            this.ChekMagueyComprado.Name = "ChekMagueyComprado";
            this.ChekMagueyComprado.Size = new System.Drawing.Size(115, 17);
            this.ChekMagueyComprado.TabIndex = 336;
            this.ChekMagueyComprado.Text = "Maguey Comprado";
            this.ChekMagueyComprado.UseVisualStyleBackColor = true;
            this.ChekMagueyComprado.CheckedChanged += new System.EventHandler(this.ChekMagueyComprado_CheckedChanged);
            // 
            // TxtNoGuia
            // 
            this.TxtNoGuia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoGuia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtNoGuia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtNoGuia.Location = new System.Drawing.Point(113, 106);
            this.TxtNoGuia.MaxLength = 9;
            this.TxtNoGuia.Name = "TxtNoGuia";
            this.TxtNoGuia.Size = new System.Drawing.Size(127, 20);
            this.TxtNoGuia.TabIndex = 449;
            this.TxtNoGuia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoGuia_KeyDown);
            this.TxtNoGuia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoGuia_KeyPress);
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.Location = new System.Drawing.Point(47, 107);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(64, 18);
            this.label81.TabIndex = 450;
            this.label81.Text = "No Guía :";
            // 
            // TxtNoPredio
            // 
            this.TxtNoPredio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoPredio.Location = new System.Drawing.Point(113, 166);
            this.TxtNoPredio.Name = "TxtNoPredio";
            this.TxtNoPredio.ReadOnly = true;
            this.TxtNoPredio.Size = new System.Drawing.Size(127, 20);
            this.TxtNoPredio.TabIndex = 451;
            // 
            // chkGuiaAntigua
            // 
            this.chkGuiaAntigua.AutoSize = true;
            this.chkGuiaAntigua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGuiaAntigua.ForeColor = System.Drawing.Color.ForestGreen;
            this.chkGuiaAntigua.Location = new System.Drawing.Point(339, 285);
            this.chkGuiaAntigua.Name = "chkGuiaAntigua";
            this.chkGuiaAntigua.Size = new System.Drawing.Size(69, 30);
            this.chkGuiaAntigua.TabIndex = 452;
            this.chkGuiaAntigua.Text = "Guia \r\nAntigua";
            this.chkGuiaAntigua.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label9.Location = new System.Drawing.Point(22, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 16);
            this.label9.TabIndex = 453;
            this.label9.Text = "Especie de maguey:";
            // 
            // cmbEspecieMaguey
            // 
            this.cmbEspecieMaguey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecieMaguey.FormattingEnabled = true;
            this.cmbEspecieMaguey.Location = new System.Drawing.Point(170, 220);
            this.cmbEspecieMaguey.Name = "cmbEspecieMaguey";
            this.cmbEspecieMaguey.Size = new System.Drawing.Size(255, 21);
            this.cmbEspecieMaguey.TabIndex = 454;
            // 
            // chkGuiaCrm
            // 
            this.chkGuiaCrm.AutoSize = true;
            this.chkGuiaCrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGuiaCrm.ForeColor = System.Drawing.Color.OliveDrab;
            this.chkGuiaCrm.Location = new System.Drawing.Point(87, 65);
            this.chkGuiaCrm.Name = "chkGuiaCrm";
            this.chkGuiaCrm.Size = new System.Drawing.Size(101, 17);
            this.chkGuiaCrm.TabIndex = 455;
            this.chkGuiaCrm.Text = "Guía Externa";
            this.chkGuiaCrm.UseVisualStyleBackColor = true;
            // 
            // chkGuiaAmma
            // 
            this.chkGuiaAmma.AutoSize = true;
            this.chkGuiaAmma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGuiaAmma.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkGuiaAmma.Location = new System.Drawing.Point(202, 63);
            this.chkGuiaAmma.Name = "chkGuiaAmma";
            this.chkGuiaAmma.Size = new System.Drawing.Size(100, 19);
            this.chkGuiaAmma.TabIndex = 456;
            this.chkGuiaAmma.Text = "Guía AMMA";
            this.chkGuiaAmma.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(12, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 30);
            this.label10.TabIndex = 457;
            this.label10.Text = "Nombre\r\npredio externo:";
            // 
            // txtPredioCrm
            // 
            this.txtPredioCrm.BackColor = System.Drawing.SystemColors.Window;
            this.txtPredioCrm.Location = new System.Drawing.Point(113, 139);
            this.txtPredioCrm.Name = "txtPredioCrm";
            this.txtPredioCrm.Size = new System.Drawing.Size(276, 20);
            this.txtPredioCrm.TabIndex = 458;
            // 
            // FrmCompletarTapda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 516);
            this.Controls.Add(this.txtPredioCrm);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkGuiaAmma);
            this.Controls.Add(this.chkGuiaCrm);
            this.Controls.Add(this.cmbEspecieMaguey);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkGuiaAntigua);
            this.Controls.Add(this.TxtNoPredio);
            this.Controls.Add(this.TxtNoGuia);
            this.Controls.Add(this.label81);
            this.Controls.Add(this.ChekMagueyComprado);
            this.Controls.Add(this.TxtCampo);
            this.Controls.Add(this.DtaAgaveCompletarTapada);
            this.Controls.Add(this.BtnAgregarAgaveCocido);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CmbMagueyNoRegistrado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtExtraccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.CmbMaguey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtPredioDesconocido);
            this.Controls.Add(this.TxtExistencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbNoPredio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCompletarTapda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Completar producción";
            this.Load += new System.EventHandler(this.FrmCompletarTapda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveCompletarTapada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox CmbNoPredio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbMaguey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPredioDesconocido;
        private System.Windows.Forms.TextBox TxtExistencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtExtraccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbMagueyNoRegistrado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DtaAgaveCompletarTapada;
        private System.Windows.Forms.Button BtnAgregarAgaveCocido;
        private System.Windows.Forms.TextBox TxtCampo;
        private System.Windows.Forms.CheckBox ChekMagueyComprado;
        private System.Windows.Forms.TextBox TxtNoGuia;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.TextBox TxtNoPredio;
        private System.Windows.Forms.CheckBox chkGuiaAntigua;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbEspecieMaguey;
        private System.Windows.Forms.CheckBox chkGuiaCrm;
        private System.Windows.Forms.CheckBox chkGuiaAmma;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPredioCrm;
    }
}