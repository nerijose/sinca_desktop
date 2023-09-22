namespace Crm.ExtraccionAgave
{
    partial class FrmExtraccionAgave
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
            this.TxtNoCliente = new System.Windows.Forms.TextBox();
            this.LblNoCliente = new System.Windows.Forms.Label();
            this.TxtNoGuia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNoPredio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtParaje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtExtraccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtExistencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbMaguey = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtNoClienteRecibe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtNombreRecibe = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DtaExtraccion = new System.Windows.Forms.DataGridView();
            this.BtnExtraccion = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtaExtraccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtNoCliente
            // 
            this.TxtNoCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoCliente.Location = new System.Drawing.Point(108, 103);
            this.TxtNoCliente.Name = "TxtNoCliente";
            this.TxtNoCliente.ReadOnly = true;
            this.TxtNoCliente.Size = new System.Drawing.Size(127, 20);
            this.TxtNoCliente.TabIndex = 0;
            // 
            // LblNoCliente
            // 
            this.LblNoCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblNoCliente.AutoSize = true;
            this.LblNoCliente.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNoCliente.Location = new System.Drawing.Point(21, 103);
            this.LblNoCliente.Name = "LblNoCliente";
            this.LblNoCliente.Size = new System.Drawing.Size(81, 18);
            this.LblNoCliente.TabIndex = 64;
            this.LblNoCliente.Text = "No Cliente :";
            // 
            // TxtNoGuia
            // 
            this.TxtNoGuia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoGuia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtNoGuia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtNoGuia.Location = new System.Drawing.Point(108, 51);
            this.TxtNoGuia.MaxLength = 9;
            this.TxtNoGuia.Name = "TxtNoGuia";
            this.TxtNoGuia.Size = new System.Drawing.Size(127, 20);
            this.TxtNoGuia.TabIndex = 1;
            this.TxtNoGuia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoGuia_KeyDown);
            this.TxtNoGuia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoGuia_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 67;
            this.label1.Text = "No Guia :";
            // 
            // TxtNoPredio
            // 
            this.TxtNoPredio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoPredio.Location = new System.Drawing.Point(108, 77);
            this.TxtNoPredio.Name = "TxtNoPredio";
            this.TxtNoPredio.ReadOnly = true;
            this.TxtNoPredio.Size = new System.Drawing.Size(127, 20);
            this.TxtNoPredio.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 69;
            this.label2.Text = "No Predio :";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNombre.Location = new System.Drawing.Point(108, 129);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.ReadOnly = true;
            this.TxtNombre.Size = new System.Drawing.Size(206, 20);
            this.TxtNombre.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 71;
            this.label3.Text = "Nombre :";
            // 
            // TxtParaje
            // 
            this.TxtParaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtParaje.Location = new System.Drawing.Point(108, 155);
            this.TxtParaje.Name = "TxtParaje";
            this.TxtParaje.ReadOnly = true;
            this.TxtParaje.Size = new System.Drawing.Size(206, 20);
            this.TxtParaje.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 73;
            this.label4.Text = "Paraje :";
            // 
            // TxtExtraccion
            // 
            this.TxtExtraccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtExtraccion.Location = new System.Drawing.Point(108, 246);
            this.TxtExtraccion.MaxLength = 9;
            this.TxtExtraccion.Name = "TxtExtraccion";
            this.TxtExtraccion.Size = new System.Drawing.Size(127, 20);
            this.TxtExtraccion.TabIndex = 3;
            this.TxtExtraccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtExtraccion_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 18);
            this.label5.TabIndex = 77;
            this.label5.Text = "Extracción :";
            // 
            // TxtExistencia
            // 
            this.TxtExistencia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtExistencia.Location = new System.Drawing.Point(108, 216);
            this.TxtExistencia.Name = "TxtExistencia";
            this.TxtExistencia.ReadOnly = true;
            this.TxtExistencia.Size = new System.Drawing.Size(127, 20);
            this.TxtExistencia.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 76;
            this.label6.Text = "Existencia :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 18);
            this.label7.TabIndex = 78;
            this.label7.Text = "Maguey :";
            // 
            // CmbMaguey
            // 
            this.CmbMaguey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbMaguey.FormattingEnabled = true;
            this.CmbMaguey.Location = new System.Drawing.Point(108, 185);
            this.CmbMaguey.Name = "CmbMaguey";
            this.CmbMaguey.Size = new System.Drawing.Size(207, 21);
            this.CmbMaguey.TabIndex = 2;
            this.CmbMaguey.SelectedIndexChanged += new System.EventHandler(this.CmbMaguey_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(180, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 18);
            this.label8.TabIndex = 82;
            this.label8.Text = "Cliente Recibe";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtDireccion.Location = new System.Drawing.Point(108, 532);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(206, 20);
            this.TxtDireccion.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 534);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 18);
            this.label9.TabIndex = 94;
            this.label9.Text = "Dirección :";
            // 
            // TxtNoClienteRecibe
            // 
            this.TxtNoClienteRecibe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoClienteRecibe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtNoClienteRecibe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtNoClienteRecibe.Location = new System.Drawing.Point(108, 480);
            this.TxtNoClienteRecibe.Name = "TxtNoClienteRecibe";
            this.TxtNoClienteRecibe.Size = new System.Drawing.Size(127, 20);
            this.TxtNoClienteRecibe.TabIndex = 5;
            this.TxtNoClienteRecibe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoClienteRecibe_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 480);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 18);
            this.label10.TabIndex = 93;
            this.label10.Text = "No Cliente :";
            // 
            // TxtNombreRecibe
            // 
            this.TxtNombreRecibe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNombreRecibe.Location = new System.Drawing.Point(108, 506);
            this.TxtNombreRecibe.Name = "TxtNombreRecibe";
            this.TxtNombreRecibe.ReadOnly = true;
            this.TxtNombreRecibe.Size = new System.Drawing.Size(206, 20);
            this.TxtNombreRecibe.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 506);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 18);
            this.label11.TabIndex = 92;
            this.label11.Text = "Nombre :";
            // 
            // DtaExtraccion
            // 
            this.DtaExtraccion.AllowUserToAddRows = false;
            this.DtaExtraccion.AllowUserToDeleteRows = false;
            this.DtaExtraccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaExtraccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaExtraccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaExtraccion.Location = new System.Drawing.Point(45, 321);
            this.DtaExtraccion.Name = "DtaExtraccion";
            this.DtaExtraccion.ReadOnly = true;
            this.DtaExtraccion.Size = new System.Drawing.Size(364, 104);
            this.DtaExtraccion.TabIndex = 97;
            this.DtaExtraccion.TabStop = false;
            this.DtaExtraccion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaExtraccion_CellDoubleClick);
            // 
            // BtnExtraccion
            // 
            this.BtnExtraccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnExtraccion.BackColor = System.Drawing.Color.Transparent;
            this.BtnExtraccion.FlatAppearance.BorderSize = 0;
            this.BtnExtraccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExtraccion.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExtraccion.ForeColor = System.Drawing.Color.White;
            this.BtnExtraccion.Image = global::Crm.Properties.Resources.down_arrow;
            this.BtnExtraccion.Location = new System.Drawing.Point(208, 274);
            this.BtnExtraccion.Name = "BtnExtraccion";
            this.BtnExtraccion.Size = new System.Drawing.Size(39, 39);
            this.BtnExtraccion.TabIndex = 4;
            this.BtnExtraccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnExtraccion.UseVisualStyleBackColor = false;
            this.BtnExtraccion.Click += new System.EventHandler(this.BtnExtraccion_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(188, 582);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Image = global::Crm.Properties.Resources.cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(233, 582);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(39, 39);
            this.BtnCancelar.TabIndex = 8;
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Crm.Properties.Resources.agave__2_;
            this.pictureBox1.Location = new System.Drawing.Point(320, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 129);
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // FrmExtraccionAgave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 643);
            this.Controls.Add(this.BtnExtraccion);
            this.Controls.Add(this.DtaExtraccion);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtNoClienteRecibe);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtNombreRecibe);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CmbMaguey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtExtraccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtExistencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtParaje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNoPredio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtNoGuia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtNoCliente);
            this.Controls.Add(this.LblNoCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmExtraccionAgave";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extracción de maguey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmExtraccionAgave_FormClosing);
            this.Load += new System.EventHandler(this.FrmExtraccionAgave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaExtraccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtNoCliente;
        private System.Windows.Forms.Label LblNoCliente;
        private System.Windows.Forms.TextBox TxtNoGuia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtNoPredio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtParaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtExtraccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtExistencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbMaguey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtNoClienteRecibe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtNombreRecibe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView DtaExtraccion;
        private System.Windows.Forms.Button BtnExtraccion;
    }
}