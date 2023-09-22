namespace Crm.Inventario.editar
{
    partial class FrmCambioNombre
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
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.lblNoLoteActual = new System.Windows.Forms.Label();
            this.txtNuevoNoLote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Black;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnGuardar.Location = new System.Drawing.Point(172, 82);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(45, 39);
            this.BtnGuardar.TabIndex = 520;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // lblNoLoteActual
            // 
            this.lblNoLoteActual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoLoteActual.AutoSize = true;
            this.lblNoLoteActual.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoLoteActual.Location = new System.Drawing.Point(197, 15);
            this.lblNoLoteActual.Name = "lblNoLoteActual";
            this.lblNoLoteActual.Size = new System.Drawing.Size(24, 18);
            this.lblNoLoteActual.TabIndex = 517;
            this.lblNoLoteActual.Text = "....";
            // 
            // txtNuevoNoLote
            // 
            this.txtNuevoNoLote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNuevoNoLote.CausesValidation = false;
            this.txtNuevoNoLote.Location = new System.Drawing.Point(197, 45);
            this.txtNuevoNoLote.MaxLength = 80;
            this.txtNuevoNoLote.Name = "txtNuevoNoLote";
            this.txtNuevoNoLote.Size = new System.Drawing.Size(203, 20);
            this.txtNuevoNoLote.TabIndex = 515;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 516;
            this.label3.Text = "Nuevo No de Lote :";
            // 
            // label49
            // 
            this.label49.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(127, 15);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(64, 18);
            this.label49.TabIndex = 513;
            this.label49.Text = "No Lote :";
            // 
            // FrmCambioNombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 140);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.lblNoLoteActual);
            this.Controls.Add(this.txtNuevoNoLote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label49);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCambioNombre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCambioNombre";
            this.Load += new System.EventHandler(this.FrmCambioNombre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label lblNoLoteActual;
        private System.Windows.Forms.TextBox txtNuevoNoLote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label49;
    }
}