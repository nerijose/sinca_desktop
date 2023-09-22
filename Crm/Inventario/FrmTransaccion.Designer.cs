namespace Crm.Inventario
{
    partial class FrmTransaccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtNoClienteEnvia = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.CmbLote = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbLNombreCliente = new System.Windows.Forms.Label();
            this.CmbTipoInstalacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbInstalacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNoTransaccion = new System.Windows.Forms.TextBox();
            this.TxtNoLote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnAgregarTanque = new System.Windows.Forms.Button();
            this.DtaTanques = new System.Windows.Forms.DataGridView();
            this.TxtTanque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbDocumental = new System.Windows.Forms.RadioButton();
            this.rdbSitio = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TxtNoLitrosExtraccion = new System.Windows.Forms.TextBox();
            this.lblLitros = new System.Windows.Forms.Label();
            this.txtNBotellas = new System.Windows.Forms.TextBox();
            this.lblBotellas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaTanques)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNoClienteEnvia
            // 
            this.TxtNoClienteEnvia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtNoClienteEnvia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtNoClienteEnvia.Location = new System.Drawing.Point(28, 26);
            this.TxtNoClienteEnvia.MaxLength = 9;
            this.TxtNoClienteEnvia.Name = "TxtNoClienteEnvia";
            this.TxtNoClienteEnvia.Size = new System.Drawing.Size(111, 20);
            this.TxtNoClienteEnvia.TabIndex = 1;
            this.TxtNoClienteEnvia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoClienteEnvia_KeyDown);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(28, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 18);
            this.label18.TabIndex = 374;
            this.label18.Text = "No Cliente Envia";
            // 
            // CmbLote
            // 
            this.CmbLote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLote.FormattingEnabled = true;
            this.CmbLote.Location = new System.Drawing.Point(171, 184);
            this.CmbLote.Name = "CmbLote";
            this.CmbLote.Size = new System.Drawing.Size(356, 21);
            this.CmbLote.TabIndex = 4;
            this.CmbLote.SelectedIndexChanged += new System.EventHandler(this.CmbLote_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(105, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 18);
            this.label9.TabIndex = 379;
            this.label9.Text = "N° lote :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Crm.Properties.Resources.truck__3_;
            this.pictureBox1.Location = new System.Drawing.Point(524, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 131);
            this.pictureBox1.TabIndex = 380;
            this.pictureBox1.TabStop = false;
            // 
            // LbLNombreCliente
            // 
            this.LbLNombreCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbLNombreCliente.AutoSize = true;
            this.LbLNombreCliente.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbLNombreCliente.Location = new System.Drawing.Point(147, 28);
            this.LbLNombreCliente.Name = "LbLNombreCliente";
            this.LbLNombreCliente.Size = new System.Drawing.Size(28, 18);
            this.LbLNombreCliente.TabIndex = 381;
            this.LbLNombreCliente.Text = ".....";
            // 
            // CmbTipoInstalacion
            // 
            this.CmbTipoInstalacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbTipoInstalacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoInstalacion.FormattingEnabled = true;
            this.CmbTipoInstalacion.Location = new System.Drawing.Point(171, 111);
            this.CmbTipoInstalacion.Name = "CmbTipoInstalacion";
            this.CmbTipoInstalacion.Size = new System.Drawing.Size(209, 21);
            this.CmbTipoInstalacion.TabIndex = 2;
            this.CmbTipoInstalacion.SelectedIndexChanged += new System.EventHandler(this.CmbTipoInstalacion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 383;
            this.label1.Text = "Tipo de instalación :";
            // 
            // CmbInstalacion
            // 
            this.CmbInstalacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbInstalacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInstalacion.FormattingEnabled = true;
            this.CmbInstalacion.Location = new System.Drawing.Point(171, 147);
            this.CmbInstalacion.Name = "CmbInstalacion";
            this.CmbInstalacion.Size = new System.Drawing.Size(356, 21);
            this.CmbInstalacion.TabIndex = 3;
            this.CmbInstalacion.SelectedIndexChanged += new System.EventHandler(this.CmbInstalacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 385;
            this.label2.Text = "Instalación :";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(309, 442);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 10;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 390;
            this.label3.Text = "N° traslado :";
            // 
            // TxtNoTransaccion
            // 
            this.TxtNoTransaccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNoTransaccion.Location = new System.Drawing.Point(171, 256);
            this.TxtNoTransaccion.MaxLength = 50;
            this.TxtNoTransaccion.Name = "TxtNoTransaccion";
            this.TxtNoTransaccion.Size = new System.Drawing.Size(213, 20);
            this.TxtNoTransaccion.TabIndex = 5;
            // 
            // TxtNoLote
            // 
            this.TxtNoLote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNoLote.Location = new System.Drawing.Point(169, 292);
            this.TxtNoLote.MaxLength = 50;
            this.TxtNoLote.Name = "TxtNoLote";
            this.TxtNoLote.Size = new System.Drawing.Size(213, 20);
            this.TxtNoLote.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 18);
            this.label4.TabIndex = 392;
            this.label4.Text = "N° lote :";
            // 
            // BtnAgregarTanque
            // 
            this.BtnAgregarTanque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAgregarTanque.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarTanque.FlatAppearance.BorderSize = 0;
            this.BtnAgregarTanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarTanque.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarTanque.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarTanque.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnAgregarTanque.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregarTanque.Location = new System.Drawing.Point(345, 318);
            this.BtnAgregarTanque.Name = "BtnAgregarTanque";
            this.BtnAgregarTanque.Size = new System.Drawing.Size(33, 34);
            this.BtnAgregarTanque.TabIndex = 8;
            this.BtnAgregarTanque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarTanque.UseVisualStyleBackColor = false;
            this.BtnAgregarTanque.Click += new System.EventHandler(this.BtnAgregarTanque_Click);
            // 
            // DtaTanques
            // 
            this.DtaTanques.AllowUserToAddRows = false;
            this.DtaTanques.AllowUserToDeleteRows = false;
            this.DtaTanques.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtaTanques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaTanques.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaTanques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaTanques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtaTanques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaTanques.EnableHeadersVisualStyles = false;
            this.DtaTanques.Location = new System.Drawing.Point(171, 355);
            this.DtaTanques.Name = "DtaTanques";
            this.DtaTanques.ReadOnly = true;
            this.DtaTanques.Size = new System.Drawing.Size(207, 63);
            this.DtaTanques.TabIndex = 9;
            this.DtaTanques.TabStop = false;
            this.DtaTanques.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaTanques_CellDoubleClick);
            // 
            // TxtTanque
            // 
            this.TxtTanque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTanque.Location = new System.Drawing.Point(171, 327);
            this.TxtTanque.MaxLength = 50;
            this.TxtTanque.Name = "TxtTanque";
            this.TxtTanque.Size = new System.Drawing.Size(172, 20);
            this.TxtTanque.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 395;
            this.label5.Text = "N° tanque :";
            // 
            // rdbDocumental
            // 
            this.rdbDocumental.AutoSize = true;
            this.rdbDocumental.Location = new System.Drawing.Point(171, 74);
            this.rdbDocumental.Name = "rdbDocumental";
            this.rdbDocumental.Size = new System.Drawing.Size(82, 17);
            this.rdbDocumental.TabIndex = 399;
            this.rdbDocumental.Text = "Documental";
            this.rdbDocumental.UseVisualStyleBackColor = true;
            // 
            // rdbSitio
            // 
            this.rdbSitio.AutoSize = true;
            this.rdbSitio.Location = new System.Drawing.Point(288, 73);
            this.rdbSitio.Name = "rdbSitio";
            this.rdbSitio.Size = new System.Drawing.Size(61, 17);
            this.rdbSitio.TabIndex = 400;
            this.rdbSitio.Text = "En Sitio";
            this.rdbSitio.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 18);
            this.label6.TabIndex = 401;
            this.label6.Text = "Tipo de Transacción :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TxtNoLitrosExtraccion
            // 
            this.TxtNoLitrosExtraccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNoLitrosExtraccion.Location = new System.Drawing.Point(171, 222);
            this.TxtNoLitrosExtraccion.MaxLength = 50;
            this.TxtNoLitrosExtraccion.Name = "TxtNoLitrosExtraccion";
            this.TxtNoLitrosExtraccion.Size = new System.Drawing.Size(143, 20);
            this.TxtNoLitrosExtraccion.TabIndex = 402;
            this.TxtNoLitrosExtraccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoLitrosExtraccion_KeyPress);
            // 
            // lblLitros
            // 
            this.lblLitros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLitros.AutoSize = true;
            this.lblLitros.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLitros.Location = new System.Drawing.Point(112, 222);
            this.lblLitros.Name = "lblLitros";
            this.lblLitros.Size = new System.Drawing.Size(51, 18);
            this.lblLitros.TabIndex = 403;
            this.lblLitros.Text = "Litros :";
            // 
            // txtNBotellas
            // 
            this.txtNBotellas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNBotellas.Location = new System.Drawing.Point(395, 222);
            this.txtNBotellas.MaxLength = 50;
            this.txtNBotellas.Name = "txtNBotellas";
            this.txtNBotellas.Size = new System.Drawing.Size(103, 20);
            this.txtNBotellas.TabIndex = 404;
            this.txtNBotellas.TextChanged += new System.EventHandler(this.txtNBotellas_TextChanged);
            this.txtNBotellas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNBotellas_KeyPress);
            // 
            // lblBotellas
            // 
            this.lblBotellas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBotellas.AutoSize = true;
            this.lblBotellas.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBotellas.Location = new System.Drawing.Point(325, 222);
            this.lblBotellas.Name = "lblBotellas";
            this.lblBotellas.Size = new System.Drawing.Size(66, 18);
            this.lblBotellas.TabIndex = 405;
            this.lblBotellas.Text = "Botellas :";
            // 
            // FrmTransaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 494);
            this.Controls.Add(this.txtNBotellas);
            this.Controls.Add(this.lblBotellas);
            this.Controls.Add(this.TxtNoLitrosExtraccion);
            this.Controls.Add(this.lblLitros);
            this.Controls.Add(this.rdbDocumental);
            this.Controls.Add(this.rdbSitio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnAgregarTanque);
            this.Controls.Add(this.DtaTanques);
            this.Controls.Add(this.TxtTanque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtNoLote);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNoTransaccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.CmbInstalacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbTipoInstalacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbLNombreCliente);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CmbLote);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtNoClienteEnvia);
            this.Controls.Add(this.label18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTransaccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transacción ";
            this.Load += new System.EventHandler(this.FrmTraslado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaTanques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtNoClienteEnvia;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CmbLote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbLNombreCliente;
        private System.Windows.Forms.ComboBox CmbTipoInstalacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbInstalacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNoTransaccion;
        private System.Windows.Forms.TextBox TxtNoLote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnAgregarTanque;
        private System.Windows.Forms.DataGridView DtaTanques;
        private System.Windows.Forms.TextBox TxtTanque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbDocumental;
        private System.Windows.Forms.RadioButton rdbSitio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TxtNoLitrosExtraccion;
        private System.Windows.Forms.Label lblLitros;
        private System.Windows.Forms.TextBox txtNBotellas;
        private System.Windows.Forms.Label lblBotellas;
    }
}