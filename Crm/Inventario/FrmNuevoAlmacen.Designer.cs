namespace Crm.Inventario
{
    partial class FrmNuevoAlmacen
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
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResponsableBodega = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNuevaBodega = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolioUnicoGranel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmbEstado
            // 
            this.CmbEstado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(206, 106);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(203, 21);
            this.CmbEstado.TabIndex = 280;
            this.CmbEstado.SelectedIndexChanged += new System.EventHandler(this.CmbEstado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 284;
            this.label1.Text = "Estado :";
            // 
            // txtResponsableBodega
            // 
            this.txtResponsableBodega.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtResponsableBodega.Location = new System.Drawing.Point(206, 54);
            this.txtResponsableBodega.MaxLength = 80;
            this.txtResponsableBodega.Name = "txtResponsableBodega";
            this.txtResponsableBodega.Size = new System.Drawing.Size(203, 20);
            this.txtResponsableBodega.TabIndex = 279;
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
            this.BtnGuardar.Location = new System.Drawing.Point(233, 212);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 42);
            this.BtnGuardar.TabIndex = 281;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(107, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 18);
            this.label12.TabIndex = 283;
            this.label12.Text = "Responsable :";
            // 
            // txtNuevaBodega
            // 
            this.txtNuevaBodega.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNuevaBodega.Location = new System.Drawing.Point(206, 25);
            this.txtNuevaBodega.MaxLength = 80;
            this.txtNuevaBodega.Name = "txtNuevaBodega";
            this.txtNuevaBodega.Size = new System.Drawing.Size(203, 20);
            this.txtNuevaBodega.TabIndex = 278;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 282;
            this.label4.Text = "Bodega :";
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbMunicipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMunicipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Location = new System.Drawing.Point(206, 134);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(203, 21);
            this.cmbMunicipio.TabIndex = 285;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 286;
            this.label2.Text = "Municipio :";
            // 
            // txtFolioUnicoGranel
            // 
            this.txtFolioUnicoGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFolioUnicoGranel.CausesValidation = false;
            this.txtFolioUnicoGranel.Location = new System.Drawing.Point(206, 80);
            this.txtFolioUnicoGranel.MaxLength = 80;
            this.txtFolioUnicoGranel.Name = "txtFolioUnicoGranel";
            this.txtFolioUnicoGranel.Size = new System.Drawing.Size(203, 20);
            this.txtFolioUnicoGranel.TabIndex = 255;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 288;
            this.label3.Text = "Folio unico de granel :";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLocalidad.Location = new System.Drawing.Point(206, 161);
            this.txtLocalidad.MaxLength = 80;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(203, 20);
            this.txtLocalidad.TabIndex = 500;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(127, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 290;
            this.label5.Text = "Localidad :";
            // 
            // FrmNuevoAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 272);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFolioUnicoGranel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMunicipio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResponsableBodega);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNuevaBodega);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNuevoAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Almacen";
            this.Load += new System.EventHandler(this.FrmNuevaAlmacen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResponsableBodega;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNuevaBodega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolioUnicoGranel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label5;
    }
}