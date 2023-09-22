namespace Crm.Inventario
{
    partial class FrmTerminarCoccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.DataTimeInicioMolienda = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.DataTimeFinalCoccion = new System.Windows.Forms.DateTimePicker();
            this.ChekMolienda = new System.Windows.Forms.CheckBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.CmbMolienda = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ChekCoccion = new System.Windows.Forms.CheckBox();
            this.TxtTapada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtArt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtKgAgaveCocido = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.BtnAgregarAgaveCocido = new System.Windows.Forms.Button();
            this.DtaAgaveCocido = new System.Windows.Forms.DataGridView();
            this.CmbAgaveCocido = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.GroupCocido = new System.Windows.Forms.GroupBox();
            this.GroupCocidoSobrante = new System.Windows.Forms.GroupBox();
            this.TxtKgAgaveCocidoSobrante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbAgaveCocidoSobrante = new System.Windows.Forms.ComboBox();
            this.DtaAgaveCocidoSobrante = new System.Windows.Forms.DataGridView();
            this.BtnAgregarAgaveCocidoSobrante = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveCocido)).BeginInit();
            this.GroupCocido.SuspendLayout();
            this.GroupCocidoSobrante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveCocidoSobrante)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 18);
            this.label1.TabIndex = 264;
            this.label1.Text = "Inicia  periodo de molienda :";
            // 
            // DataTimeInicioMolienda
            // 
            this.DataTimeInicioMolienda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataTimeInicioMolienda.Location = new System.Drawing.Point(206, 494);
            this.DataTimeInicioMolienda.Name = "DataTimeInicioMolienda";
            this.DataTimeInicioMolienda.Size = new System.Drawing.Size(211, 20);
            this.DataTimeInicioMolienda.TabIndex = 263;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(187, 18);
            this.label13.TabIndex = 262;
            this.label13.Text = "Finaliza periodo de cocción :";
            // 
            // DataTimeFinalCoccion
            // 
            this.DataTimeFinalCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataTimeFinalCoccion.Location = new System.Drawing.Point(207, 32);
            this.DataTimeFinalCoccion.Name = "DataTimeFinalCoccion";
            this.DataTimeFinalCoccion.Size = new System.Drawing.Size(210, 20);
            this.DataTimeFinalCoccion.TabIndex = 261;
            // 
            // ChekMolienda
            // 
            this.ChekMolienda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekMolienda.AutoSize = true;
            this.ChekMolienda.Location = new System.Drawing.Point(210, 475);
            this.ChekMolienda.Name = "ChekMolienda";
            this.ChekMolienda.Size = new System.Drawing.Size(136, 17);
            this.ChekMolienda.TabIndex = 266;
            this.ChekMolienda.Text = "Inicia Periodo Molienda";
            this.ChekMolienda.UseVisualStyleBackColor = true;
            this.ChekMolienda.Click += new System.EventHandler(this.ChekMolienda_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(220, 564);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 268;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // CmbMolienda
            // 
            this.CmbMolienda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbMolienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMolienda.FormattingEnabled = true;
            this.CmbMolienda.Location = new System.Drawing.Point(204, 526);
            this.CmbMolienda.Name = "CmbMolienda";
            this.CmbMolienda.Size = new System.Drawing.Size(212, 21);
            this.CmbMolienda.TabIndex = 269;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(77, 527);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 18);
            this.label15.TabIndex = 270;
            this.label15.Text = "Tipo de molienda :";
            // 
            // ChekCoccion
            // 
            this.ChekCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekCoccion.AutoSize = true;
            this.ChekCoccion.Location = new System.Drawing.Point(210, 13);
            this.ChekCoccion.Name = "ChekCoccion";
            this.ChekCoccion.Size = new System.Drawing.Size(142, 17);
            this.ChekCoccion.TabIndex = 271;
            this.ChekCoccion.Text = "Finaliza Periodo Cocción";
            this.ChekCoccion.UseVisualStyleBackColor = true;
            this.ChekCoccion.Click += new System.EventHandler(this.ChekCoccion_Click);
            // 
            // TxtTapada
            // 
            this.TxtTapada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTapada.Location = new System.Drawing.Point(207, 413);
            this.TxtTapada.MaxLength = 9;
            this.TxtTapada.Name = "TxtTapada";
            this.TxtTapada.Size = new System.Drawing.Size(139, 20);
            this.TxtTapada.TabIndex = 277;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(142, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 276;
            this.label4.Text = "Tapada :";
            // 
            // TxtArt
            // 
            this.TxtArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtArt.Location = new System.Drawing.Point(207, 441);
            this.TxtArt.MaxLength = 9;
            this.TxtArt.Name = "TxtArt";
            this.TxtArt.Size = new System.Drawing.Size(139, 20);
            this.TxtArt.TabIndex = 278;
            this.TxtArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtArt_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(152, 442);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 18);
            this.label8.TabIndex = 279;
            this.label8.Text = "% ART :";
            // 
            // TxtKgAgaveCocido
            // 
            this.TxtKgAgaveCocido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtKgAgaveCocido.Location = new System.Drawing.Point(183, 51);
            this.TxtKgAgaveCocido.MaxLength = 9;
            this.TxtKgAgaveCocido.Name = "TxtKgAgaveCocido";
            this.TxtKgAgaveCocido.Size = new System.Drawing.Size(143, 20);
            this.TxtKgAgaveCocido.TabIndex = 284;
            this.TxtKgAgaveCocido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKgAgaveCocido_KeyPress);
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(98, 51);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(85, 18);
            this.label26.TabIndex = 285;
            this.label26.Text = "Kg maguey :";
            // 
            // BtnAgregarAgaveCocido
            // 
            this.BtnAgregarAgaveCocido.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.BtnAgregarAgaveCocido.Location = new System.Drawing.Point(336, 46);
            this.BtnAgregarAgaveCocido.Name = "BtnAgregarAgaveCocido";
            this.BtnAgregarAgaveCocido.Size = new System.Drawing.Size(26, 28);
            this.BtnAgregarAgaveCocido.TabIndex = 283;
            this.BtnAgregarAgaveCocido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarAgaveCocido.UseVisualStyleBackColor = false;
            this.BtnAgregarAgaveCocido.Click += new System.EventHandler(this.BtnAgregarAgaveCocido_Click);
            // 
            // DtaAgaveCocido
            // 
            this.DtaAgaveCocido.AllowUserToAddRows = false;
            this.DtaAgaveCocido.AllowUserToDeleteRows = false;
            this.DtaAgaveCocido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtaAgaveCocido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaAgaveCocido.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaAgaveCocido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaAgaveCocido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DtaAgaveCocido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaAgaveCocido.Location = new System.Drawing.Point(184, 80);
            this.DtaAgaveCocido.Name = "DtaAgaveCocido";
            this.DtaAgaveCocido.ReadOnly = true;
            this.DtaAgaveCocido.Size = new System.Drawing.Size(256, 71);
            this.DtaAgaveCocido.TabIndex = 282;
            this.DtaAgaveCocido.TabStop = false;
            this.DtaAgaveCocido.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaAgaveCocido_CellDoubleClick);
            // 
            // CmbAgaveCocido
            // 
            this.CmbAgaveCocido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbAgaveCocido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAgaveCocido.FormattingEnabled = true;
            this.CmbAgaveCocido.Location = new System.Drawing.Point(183, 24);
            this.CmbAgaveCocido.Name = "CmbAgaveCocido";
            this.CmbAgaveCocido.Size = new System.Drawing.Size(257, 21);
            this.CmbAgaveCocido.TabIndex = 280;
            this.CmbAgaveCocido.SelectedIndexChanged += new System.EventHandler(this.CmbAgaveCocido_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(72, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(111, 18);
            this.label33.TabIndex = 281;
            this.label33.Text = "Maguey cocido :";
            // 
            // GroupCocido
            // 
            this.GroupCocido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GroupCocido.Controls.Add(this.TxtKgAgaveCocido);
            this.GroupCocido.Controls.Add(this.label33);
            this.GroupCocido.Controls.Add(this.CmbAgaveCocido);
            this.GroupCocido.Controls.Add(this.DtaAgaveCocido);
            this.GroupCocido.Controls.Add(this.BtnAgregarAgaveCocido);
            this.GroupCocido.Controls.Add(this.label26);
            this.GroupCocido.Location = new System.Drawing.Point(20, 64);
            this.GroupCocido.Name = "GroupCocido";
            this.GroupCocido.Size = new System.Drawing.Size(446, 157);
            this.GroupCocido.TabIndex = 292;
            this.GroupCocido.TabStop = false;
            this.GroupCocido.Text = "Maguey cocido";
            // 
            // GroupCocidoSobrante
            // 
            this.GroupCocidoSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GroupCocidoSobrante.Controls.Add(this.TxtKgAgaveCocidoSobrante);
            this.GroupCocidoSobrante.Controls.Add(this.label2);
            this.GroupCocidoSobrante.Controls.Add(this.CmbAgaveCocidoSobrante);
            this.GroupCocidoSobrante.Controls.Add(this.DtaAgaveCocidoSobrante);
            this.GroupCocidoSobrante.Controls.Add(this.BtnAgregarAgaveCocidoSobrante);
            this.GroupCocidoSobrante.Controls.Add(this.label3);
            this.GroupCocidoSobrante.Location = new System.Drawing.Point(20, 236);
            this.GroupCocidoSobrante.Name = "GroupCocidoSobrante";
            this.GroupCocidoSobrante.Size = new System.Drawing.Size(446, 157);
            this.GroupCocidoSobrante.TabIndex = 293;
            this.GroupCocidoSobrante.TabStop = false;
            this.GroupCocidoSobrante.Text = "Maguey cocido sobrante";
            // 
            // TxtKgAgaveCocidoSobrante
            // 
            this.TxtKgAgaveCocidoSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtKgAgaveCocidoSobrante.Location = new System.Drawing.Point(183, 53);
            this.TxtKgAgaveCocidoSobrante.MaxLength = 9;
            this.TxtKgAgaveCocidoSobrante.Name = "TxtKgAgaveCocidoSobrante";
            this.TxtKgAgaveCocidoSobrante.Size = new System.Drawing.Size(143, 20);
            this.TxtKgAgaveCocidoSobrante.TabIndex = 284;
            this.TxtKgAgaveCocidoSobrante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKgAgaveCocidoSobrante_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 281;
            this.label2.Text = "Maguey cocido sobrante :";
            // 
            // CmbAgaveCocidoSobrante
            // 
            this.CmbAgaveCocidoSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbAgaveCocidoSobrante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAgaveCocidoSobrante.FormattingEnabled = true;
            this.CmbAgaveCocidoSobrante.Location = new System.Drawing.Point(184, 23);
            this.CmbAgaveCocidoSobrante.Name = "CmbAgaveCocidoSobrante";
            this.CmbAgaveCocidoSobrante.Size = new System.Drawing.Size(256, 21);
            this.CmbAgaveCocidoSobrante.TabIndex = 280;
            this.CmbAgaveCocidoSobrante.SelectedIndexChanged += new System.EventHandler(this.CmbAgaveCocidoSobrante_SelectedIndexChanged);
            // 
            // DtaAgaveCocidoSobrante
            // 
            this.DtaAgaveCocidoSobrante.AllowUserToAddRows = false;
            this.DtaAgaveCocidoSobrante.AllowUserToDeleteRows = false;
            this.DtaAgaveCocidoSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtaAgaveCocidoSobrante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaAgaveCocidoSobrante.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaAgaveCocidoSobrante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaAgaveCocidoSobrante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DtaAgaveCocidoSobrante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaAgaveCocidoSobrante.Location = new System.Drawing.Point(184, 82);
            this.DtaAgaveCocidoSobrante.Name = "DtaAgaveCocidoSobrante";
            this.DtaAgaveCocidoSobrante.ReadOnly = true;
            this.DtaAgaveCocidoSobrante.Size = new System.Drawing.Size(256, 69);
            this.DtaAgaveCocidoSobrante.TabIndex = 282;
            this.DtaAgaveCocidoSobrante.TabStop = false;
            this.DtaAgaveCocidoSobrante.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaAgaveCocidoSobrante_CellDoubleClick);
            // 
            // BtnAgregarAgaveCocidoSobrante
            // 
            this.BtnAgregarAgaveCocidoSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAgregarAgaveCocidoSobrante.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarAgaveCocidoSobrante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarAgaveCocidoSobrante.FlatAppearance.BorderSize = 0;
            this.BtnAgregarAgaveCocidoSobrante.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarAgaveCocidoSobrante.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarAgaveCocidoSobrante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarAgaveCocidoSobrante.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarAgaveCocidoSobrante.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarAgaveCocidoSobrante.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnAgregarAgaveCocidoSobrante.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarAgaveCocidoSobrante.Location = new System.Drawing.Point(336, 48);
            this.BtnAgregarAgaveCocidoSobrante.Name = "BtnAgregarAgaveCocidoSobrante";
            this.BtnAgregarAgaveCocidoSobrante.Size = new System.Drawing.Size(26, 28);
            this.BtnAgregarAgaveCocidoSobrante.TabIndex = 283;
            this.BtnAgregarAgaveCocidoSobrante.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarAgaveCocidoSobrante.UseVisualStyleBackColor = false;
            this.BtnAgregarAgaveCocidoSobrante.Click += new System.EventHandler(this.BtnAgregarAgaveCocidoSobrante_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 285;
            this.label3.Text = "Kg maguey :";
            // 
            // FrmTerminarCoccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 609);
            this.Controls.Add(this.GroupCocidoSobrante);
            this.Controls.Add(this.GroupCocido);
            this.Controls.Add(this.TxtArt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtTapada);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChekCoccion);
            this.Controls.Add(this.CmbMolienda);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.ChekMolienda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataTimeInicioMolienda);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DataTimeFinalCoccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTerminarCoccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Termina Cocción";
            this.Load += new System.EventHandler(this.FrmTerminarCoccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveCocido)).EndInit();
            this.GroupCocido.ResumeLayout(false);
            this.GroupCocido.PerformLayout();
            this.GroupCocidoSobrante.ResumeLayout(false);
            this.GroupCocidoSobrante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveCocidoSobrante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DataTimeInicioMolienda;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DataTimeFinalCoccion;
        private System.Windows.Forms.CheckBox ChekMolienda;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.ComboBox CmbMolienda;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ChekCoccion;
        private System.Windows.Forms.TextBox TxtTapada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtArt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtKgAgaveCocido;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button BtnAgregarAgaveCocido;
        private System.Windows.Forms.DataGridView DtaAgaveCocido;
        private System.Windows.Forms.ComboBox CmbAgaveCocido;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox GroupCocido;
        private System.Windows.Forms.GroupBox GroupCocidoSobrante;
        private System.Windows.Forms.TextBox TxtKgAgaveCocidoSobrante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbAgaveCocidoSobrante;
        private System.Windows.Forms.DataGridView DtaAgaveCocidoSobrante;
        private System.Windows.Forms.Button BtnAgregarAgaveCocidoSobrante;
        private System.Windows.Forms.Label label3;

    }
}