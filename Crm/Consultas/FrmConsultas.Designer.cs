namespace Crm.Consultas
{
    partial class FrmConsultas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtaTabla = new System.Windows.Forms.DataGridView();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.fecha1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbNoCliente = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnExel = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnEnvasadoGranel = new System.Windows.Forms.Button();
            this.BtnGranel = new System.Windows.Forms.Button();
            this.BtnEnvasado = new System.Windows.Forms.Button();
            this.BtnProduccion = new System.Windows.Forms.Button();
            this.LblValor = new System.Windows.Forms.Label();
            this.btnAlmacenGranel = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtaTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // DtaTabla
            // 
            this.DtaTabla.AllowUserToAddRows = false;
            this.DtaTabla.AllowUserToDeleteRows = false;
            this.DtaTabla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtaTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtaTabla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DtaTabla.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaTabla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtaTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaTabla.EnableHeadersVisualStyles = false;
            this.DtaTabla.Location = new System.Drawing.Point(16, 237);
            this.DtaTabla.Name = "DtaTabla";
            this.DtaTabla.ReadOnly = true;
            this.DtaTabla.Size = new System.Drawing.Size(939, 494);
            this.DtaTabla.TabIndex = 0;
            this.DtaTabla.TabStop = false;
            // 
            // fecha2
            // 
            this.fecha2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fecha2.Location = new System.Drawing.Point(644, 185);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(182, 20);
            this.fecha2.TabIndex = 290;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(566, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 18);
            this.label13.TabIndex = 291;
            this.label13.Text = "Fecha fin :";
            // 
            // fecha1
            // 
            this.fecha1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fecha1.Location = new System.Drawing.Point(342, 187);
            this.fecha1.Name = "fecha1";
            this.fecha1.Size = new System.Drawing.Size(182, 20);
            this.fecha1.TabIndex = 292;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 293;
            this.label1.Text = "Fecha inicio :";
            // 
            // CmbNoCliente
            // 
            this.CmbNoCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbNoCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbNoCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CmbNoCliente.FormattingEnabled = true;
            this.CmbNoCliente.Location = new System.Drawing.Point(102, 186);
            this.CmbNoCliente.Name = "CmbNoCliente";
            this.CmbNoCliente.Size = new System.Drawing.Size(127, 21);
            this.CmbNoCliente.TabIndex = 294;
            this.CmbNoCliente.SelectedIndexChanged += new System.EventHandler(this.CmbNoCliente_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 18);
            this.label7.TabIndex = 295;
            this.label7.Text = "No Cliente :";
            // 
            // BtnExel
            // 
            this.BtnExel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnExel.BackColor = System.Drawing.Color.Transparent;
            this.BtnExel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExel.FlatAppearance.BorderSize = 0;
            this.BtnExel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnExel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnExel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExel.ForeColor = System.Drawing.Color.Black;
            this.BtnExel.Image = global::Crm.Properties.Resources.icon__2_;
            this.BtnExel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExel.Location = new System.Drawing.Point(342, 789);
            this.BtnExel.Name = "BtnExel";
            this.BtnExel.Size = new System.Drawing.Size(131, 58);
            this.BtnExel.TabIndex = 297;
            this.BtnExel.Text = "Generar Excel";
            this.BtnExel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnExel.UseVisualStyleBackColor = false;
            this.BtnExel.Click += new System.EventHandler(this.BtnExel_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.FlatAppearance.BorderSize = 0;
            this.BtnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = global::Crm.Properties.Resources.search__2_;
            this.BtnBuscar.Location = new System.Drawing.Point(841, 173);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(40, 38);
            this.BtnBuscar.TabIndex = 296;
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnEnvasadoGranel
            // 
            this.BtnEnvasadoGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEnvasadoGranel.BackColor = System.Drawing.Color.Transparent;
            this.BtnEnvasadoGranel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnvasadoGranel.FlatAppearance.BorderSize = 0;
            this.BtnEnvasadoGranel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnEnvasadoGranel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnEnvasadoGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnvasadoGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnvasadoGranel.ForeColor = System.Drawing.Color.Black;
            this.BtnEnvasadoGranel.Image = global::Crm.Properties.Resources.tank_wagon;
            this.BtnEnvasadoGranel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEnvasadoGranel.Location = new System.Drawing.Point(513, 43);
            this.BtnEnvasadoGranel.Name = "BtnEnvasadoGranel";
            this.BtnEnvasadoGranel.Size = new System.Drawing.Size(85, 100);
            this.BtnEnvasadoGranel.TabIndex = 288;
            this.BtnEnvasadoGranel.Text = "Granel Envasado";
            this.BtnEnvasadoGranel.UseVisualStyleBackColor = false;
            this.BtnEnvasadoGranel.Click += new System.EventHandler(this.BtnEnvasadoGranel_Click);
            // 
            // BtnGranel
            // 
            this.BtnGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGranel.BackColor = System.Drawing.Color.Transparent;
            this.BtnGranel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGranel.FlatAppearance.BorderSize = 0;
            this.BtnGranel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnGranel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGranel.ForeColor = System.Drawing.Color.Black;
            this.BtnGranel.Image = global::Crm.Properties.Resources.tank_wagon;
            this.BtnGranel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnGranel.Location = new System.Drawing.Point(298, 43);
            this.BtnGranel.Name = "BtnGranel";
            this.BtnGranel.Size = new System.Drawing.Size(65, 58);
            this.BtnGranel.TabIndex = 286;
            this.BtnGranel.Text = "Granel";
            this.BtnGranel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGranel.UseVisualStyleBackColor = false;
            this.BtnGranel.Click += new System.EventHandler(this.BtnGranel_Click);
            // 
            // BtnEnvasado
            // 
            this.BtnEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEnvasado.BackColor = System.Drawing.Color.Transparent;
            this.BtnEnvasado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnvasado.FlatAppearance.BorderSize = 0;
            this.BtnEnvasado.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnEnvasado.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnEnvasado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnvasado.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnvasado.ForeColor = System.Drawing.Color.Black;
            this.BtnEnvasado.Image = global::Crm.Properties.Resources.stock;
            this.BtnEnvasado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEnvasado.Location = new System.Drawing.Point(605, 43);
            this.BtnEnvasado.Name = "BtnEnvasado";
            this.BtnEnvasado.Size = new System.Drawing.Size(83, 58);
            this.BtnEnvasado.TabIndex = 287;
            this.BtnEnvasado.Text = "Envasado";
            this.BtnEnvasado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEnvasado.UseVisualStyleBackColor = false;
            this.BtnEnvasado.Click += new System.EventHandler(this.BtnEnvasado_Click);
            // 
            // BtnProduccion
            // 
            this.BtnProduccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnProduccion.BackColor = System.Drawing.Color.Transparent;
            this.BtnProduccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProduccion.FlatAppearance.BorderSize = 0;
            this.BtnProduccion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnProduccion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProduccion.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProduccion.ForeColor = System.Drawing.Color.Black;
            this.BtnProduccion.Image = global::Crm.Properties.Resources.agave__1_;
            this.BtnProduccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnProduccion.Location = new System.Drawing.Point(176, 42);
            this.BtnProduccion.Name = "BtnProduccion";
            this.BtnProduccion.Size = new System.Drawing.Size(92, 58);
            this.BtnProduccion.TabIndex = 285;
            this.BtnProduccion.Text = "Producción";
            this.BtnProduccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnProduccion.UseVisualStyleBackColor = false;
            this.BtnProduccion.Click += new System.EventHandler(this.BtnProduccion_Click);
            // 
            // LblValor
            // 
            this.LblValor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblValor.AutoSize = true;
            this.LblValor.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValor.Location = new System.Drawing.Point(421, 125);
            this.LblValor.Name = "LblValor";
            this.LblValor.Size = new System.Drawing.Size(32, 18);
            this.LblValor.TabIndex = 298;
            this.LblValor.Text = "......";
            // 
            // btnAlmacenGranel
            // 
            this.btnAlmacenGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAlmacenGranel.BackColor = System.Drawing.Color.Transparent;
            this.btnAlmacenGranel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlmacenGranel.FlatAppearance.BorderSize = 0;
            this.btnAlmacenGranel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnAlmacenGranel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnAlmacenGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlmacenGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlmacenGranel.ForeColor = System.Drawing.Color.Black;
            this.btnAlmacenGranel.Image = global::Crm.Properties.Resources.warehouse3;
            this.btnAlmacenGranel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlmacenGranel.Location = new System.Drawing.Point(405, 43);
            this.btnAlmacenGranel.Name = "btnAlmacenGranel";
            this.btnAlmacenGranel.Size = new System.Drawing.Size(83, 72);
            this.btnAlmacenGranel.TabIndex = 446;
            this.btnAlmacenGranel.Text = "Almacen Granel";
            this.btnAlmacenGranel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlmacenGranel.UseVisualStyleBackColor = false;
            this.btnAlmacenGranel.Click += new System.EventHandler(this.btnAlmacenGranel_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.btnAlmacen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlmacen.FlatAppearance.BorderSize = 0;
            this.btnAlmacen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnAlmacen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlmacen.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlmacen.ForeColor = System.Drawing.Color.Black;
            this.btnAlmacen.Image = global::Crm.Properties.Resources.warehouse3;
            this.btnAlmacen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlmacen.Location = new System.Drawing.Point(721, 42);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(80, 73);
            this.btnAlmacen.TabIndex = 445;
            this.btnAlmacen.Text = "Almacen Envasado";
            this.btnAlmacen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlmacen.UseVisualStyleBackColor = false;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // FrmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1039, 788);
            this.Controls.Add(this.btnAlmacenGranel);
            this.Controls.Add(this.btnAlmacen);
            this.Controls.Add(this.LblValor);
            this.Controls.Add(this.BtnExel);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.CmbNoCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fecha1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fecha2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BtnEnvasadoGranel);
            this.Controls.Add(this.BtnGranel);
            this.Controls.Add(this.BtnEnvasado);
            this.Controls.Add(this.BtnProduccion);
            this.Controls.Add(this.DtaTabla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.FrmConsultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtaTabla;
        private System.Windows.Forms.Button BtnEnvasadoGranel;
        private System.Windows.Forms.Button BtnGranel;
        private System.Windows.Forms.Button BtnEnvasado;
        private System.Windows.Forms.Button BtnProduccion;
        private System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker fecha1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbNoCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnExel;
        private System.Windows.Forms.Label LblValor;
        private System.Windows.Forms.Button btnAlmacenGranel;
        private System.Windows.Forms.Button btnAlmacen;
    }
}