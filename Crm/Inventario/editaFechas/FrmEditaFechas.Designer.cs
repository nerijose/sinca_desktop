namespace Crm.Inventario.editaFechas
{
    partial class FrmEditaFechas
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
            this.cmbProcesosTapada = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFinicio = new System.Windows.Forms.Label();
            this.lblFfin = new System.Windows.Forms.Label();
            this.dtpFI = new System.Windows.Forms.DateTimePicker();
            this.dtpFF = new System.Windows.Forms.DateTimePicker();
            this.btnNuevaFecha = new System.Windows.Forms.Button();
            this.lblMsjFechaFin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbProcesosTapada
            // 
            this.cmbProcesosTapada.FormattingEnabled = true;
            this.cmbProcesosTapada.Location = new System.Drawing.Point(167, 6);
            this.cmbProcesosTapada.Name = "cmbProcesosTapada";
            this.cmbProcesosTapada.Size = new System.Drawing.Size(143, 21);
            this.cmbProcesosTapada.TabIndex = 0;
            this.cmbProcesosTapada.SelectedValueChanged += new System.EventHandler(this.cmbProcesosTapada_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Editar periodo de:";
            // 
            // lblFinicio
            // 
            this.lblFinicio.AutoSize = true;
            this.lblFinicio.Location = new System.Drawing.Point(8, 56);
            this.lblFinicio.Name = "lblFinicio";
            this.lblFinicio.Size = new System.Drawing.Size(82, 13);
            this.lblFinicio.TabIndex = 2;
            this.lblFinicio.Text = "Fecha inicio de:";
            // 
            // lblFfin
            // 
            this.lblFfin.AutoSize = true;
            this.lblFfin.Location = new System.Drawing.Point(8, 110);
            this.lblFfin.Name = "lblFfin";
            this.lblFfin.Size = new System.Drawing.Size(63, 13);
            this.lblFfin.TabIndex = 3;
            this.lblFfin.Text = "Fech fin de:";
            // 
            // dtpFI
            // 
            this.dtpFI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFI.Location = new System.Drawing.Point(176, 50);
            this.dtpFI.Name = "dtpFI";
            this.dtpFI.Size = new System.Drawing.Size(86, 20);
            this.dtpFI.TabIndex = 4;
            // 
            // dtpFF
            // 
            this.dtpFF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFF.Location = new System.Drawing.Point(176, 108);
            this.dtpFF.Name = "dtpFF";
            this.dtpFF.Size = new System.Drawing.Size(86, 20);
            this.dtpFF.TabIndex = 5;
            // 
            // btnNuevaFecha
            // 
            this.btnNuevaFecha.Location = new System.Drawing.Point(129, 152);
            this.btnNuevaFecha.Name = "btnNuevaFecha";
            this.btnNuevaFecha.Size = new System.Drawing.Size(105, 23);
            this.btnNuevaFecha.TabIndex = 6;
            this.btnNuevaFecha.Text = "Actualizar fechas";
            this.btnNuevaFecha.UseVisualStyleBackColor = true;
            this.btnNuevaFecha.Click += new System.EventHandler(this.btnNuevaFecha_Click);
            // 
            // lblMsjFechaFin
            // 
            this.lblMsjFechaFin.AutoSize = true;
            this.lblMsjFechaFin.Location = new System.Drawing.Point(268, 112);
            this.lblMsjFechaFin.Name = "lblMsjFechaFin";
            this.lblMsjFechaFin.Size = new System.Drawing.Size(0, 13);
            this.lblMsjFechaFin.TabIndex = 7;
            // 
            // FrmEditaFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 187);
            this.Controls.Add(this.lblMsjFechaFin);
            this.Controls.Add(this.btnNuevaFecha);
            this.Controls.Add(this.dtpFF);
            this.Controls.Add(this.dtpFI);
            this.Controls.Add(this.lblFfin);
            this.Controls.Add(this.lblFinicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProcesosTapada);
            this.Name = "FrmEditaFechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditaFechas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbProcesosTapada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFinicio;
        private System.Windows.Forms.Label lblFfin;
        private System.Windows.Forms.DateTimePicker dtpFI;
        private System.Windows.Forms.DateTimePicker dtpFF;
        private System.Windows.Forms.Button btnNuevaFecha;
        private System.Windows.Forms.Label lblMsjFechaFin;
    }
}