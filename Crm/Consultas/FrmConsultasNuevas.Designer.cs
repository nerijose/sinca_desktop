namespace Crm.Consultas
{
    partial class FrmConsultasNuevas
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
            this.DtaTabla = new System.Windows.Forms.DataGridView();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.fecha1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExel = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnEnvasadoGranel = new System.Windows.Forms.Button();
            this.BtnGranel = new System.Windows.Forms.Button();
            this.BtnEnvasado = new System.Windows.Forms.Button();
            this.BtnProduccion = new System.Windows.Forms.Button();
            this.LblValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtaTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // DtaTabla
            // 
            this.DtaTabla.AllowUserToAddRows = false;
            this.DtaTabla.AllowUserToDeleteRows = false;
            this.DtaTabla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaTabla.Location = new System.Drawing.Point(53, 231);
            this.DtaTabla.Name = "DtaTabla";
            this.DtaTabla.ReadOnly = true;
            this.DtaTabla.Size = new System.Drawing.Size(1198, 446);
            this.DtaTabla.TabIndex = 0;
            this.DtaTabla.TabStop = false;
            // 
            // fecha2
            // 
            this.fecha2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fecha2.Location = new System.Drawing.Point(688, 188);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(182, 20);
            this.fecha2.TabIndex = 290;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(610, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 18);
            this.label13.TabIndex = 291;
            this.label13.Text = "Fecha fin :";
            // 
            // fecha1
            // 
            this.fecha1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fecha1.Location = new System.Drawing.Point(386, 190);
            this.fecha1.Name = "fecha1";
            this.fecha1.Size = new System.Drawing.Size(182, 20);
            this.fecha1.TabIndex = 292;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 293;
            this.label1.Text = "Fecha inicio :";
            // 
            // BtnExel
            // 
            this.BtnExel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnExel.BackColor = System.Drawing.Color.Transparent;
            this.BtnExel.FlatAppearance.BorderSize = 0;
            this.BtnExel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExel.ForeColor = System.Drawing.Color.Black;
            this.BtnExel.Image = global::Crm.Properties.Resources.icon__2_;
            this.BtnExel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExel.Location = new System.Drawing.Point(551, 701);
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
            this.BtnBuscar.FlatAppearance.BorderSize = 0;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Black;
            this.BtnBuscar.Image = global::Crm.Properties.Resources.search__2_;
            this.BtnBuscar.Location = new System.Drawing.Point(885, 173);
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
            this.BtnEnvasadoGranel.FlatAppearance.BorderSize = 0;
            this.BtnEnvasadoGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnvasadoGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnvasadoGranel.ForeColor = System.Drawing.Color.Black;
            this.BtnEnvasadoGranel.Image = global::Crm.Properties.Resources.stock;
            this.BtnEnvasadoGranel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEnvasadoGranel.Location = new System.Drawing.Point(784, 24);
            this.BtnEnvasadoGranel.Name = "BtnEnvasadoGranel";
            this.BtnEnvasadoGranel.Size = new System.Drawing.Size(108, 102);
            this.BtnEnvasadoGranel.TabIndex = 288;
            this.BtnEnvasadoGranel.Text = "Inventarios de Mezcal ya envasado";
            this.BtnEnvasadoGranel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEnvasadoGranel.UseVisualStyleBackColor = false;
            this.BtnEnvasadoGranel.Click += new System.EventHandler(this.BtnEnvasadoGranel_Click);
            // 
            // BtnGranel
            // 
            this.BtnGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGranel.BackColor = System.Drawing.Color.Transparent;
            this.BtnGranel.FlatAppearance.BorderSize = 0;
            this.BtnGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGranel.ForeColor = System.Drawing.Color.Black;
            this.BtnGranel.Image = global::Crm.Properties.Resources.tank_wagon;
            this.BtnGranel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnGranel.Location = new System.Drawing.Point(469, 23);
            this.BtnGranel.Name = "BtnGranel";
            this.BtnGranel.Size = new System.Drawing.Size(91, 84);
            this.BtnGranel.TabIndex = 286;
            this.BtnGranel.Text = "Inventario de mezcal";
            this.BtnGranel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGranel.UseVisualStyleBackColor = false;
            this.BtnGranel.Click += new System.EventHandler(this.BtnGranel_Click);
            // 
            // BtnEnvasado
            // 
            this.BtnEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEnvasado.BackColor = System.Drawing.Color.Transparent;
            this.BtnEnvasado.FlatAppearance.BorderSize = 0;
            this.BtnEnvasado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnvasado.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnvasado.ForeColor = System.Drawing.Color.Black;
            this.BtnEnvasado.Image = global::Crm.Properties.Resources.stock;
            this.BtnEnvasado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEnvasado.Location = new System.Drawing.Point(649, 24);
            this.BtnEnvasado.Name = "BtnEnvasado";
            this.BtnEnvasado.Size = new System.Drawing.Size(139, 101);
            this.BtnEnvasado.TabIndex = 287;
            this.BtnEnvasado.Text = "Producción del producto envasado terminado";
            this.BtnEnvasado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEnvasado.UseVisualStyleBackColor = false;
            this.BtnEnvasado.Click += new System.EventHandler(this.BtnEnvasado_Click);
            // 
            // BtnProduccion
            // 
            this.BtnProduccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnProduccion.BackColor = System.Drawing.Color.Transparent;
            this.BtnProduccion.FlatAppearance.BorderSize = 0;
            this.BtnProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProduccion.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProduccion.ForeColor = System.Drawing.Color.Black;
            this.BtnProduccion.Image = global::Crm.Properties.Resources.agave__1_;
            this.BtnProduccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnProduccion.Location = new System.Drawing.Point(377, 23);
            this.BtnProduccion.Name = "BtnProduccion";
            this.BtnProduccion.Size = new System.Drawing.Size(92, 84);
            this.BtnProduccion.TabIndex = 285;
            this.BtnProduccion.Text = "Producto verificado";
            this.BtnProduccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnProduccion.UseVisualStyleBackColor = false;
            this.BtnProduccion.Click += new System.EventHandler(this.BtnProduccion_Click);
            // 
            // LblValor
            // 
            this.LblValor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblValor.AutoSize = true;
            this.LblValor.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValor.Location = new System.Drawing.Point(584, 148);
            this.LblValor.Name = "LblValor";
            this.LblValor.Size = new System.Drawing.Size(32, 18);
            this.LblValor.TabIndex = 298;
            this.LblValor.Text = "......";
            // 
            // FrmConsultasNuevas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 810);
            this.Controls.Add(this.LblValor);
            this.Controls.Add(this.BtnExel);
            this.Controls.Add(this.BtnBuscar);
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
            this.Name = "FrmConsultasNuevas";
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
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnExel;
        private System.Windows.Forms.Label LblValor;
    }
}