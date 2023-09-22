namespace Crm.Inventario
{
    partial class FrmNewMaestroMezcalero
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
            this.TxtMaestro = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFabrica = new System.Windows.Forms.Label();
            this.lblNocliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtMaestro
            // 
            this.TxtMaestro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtMaestro.Location = new System.Drawing.Point(193, 83);
            this.TxtMaestro.MaxLength = 80;
            this.TxtMaestro.Name = "TxtMaestro";
            this.TxtMaestro.Size = new System.Drawing.Size(203, 20);
            this.TxtMaestro.TabIndex = 508;
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
            this.BtnGuardar.Location = new System.Drawing.Point(223, 123);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 42);
            this.BtnGuardar.TabIndex = 510;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(52, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 18);
            this.label12.TabIndex = 512;
            this.label12.Text = "Maestro mezcalero :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 511;
            this.label4.Text = "Fabrica :";
            // 
            // lblFabrica
            // 
            this.lblFabrica.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFabrica.AutoSize = true;
            this.lblFabrica.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFabrica.Location = new System.Drawing.Point(193, 57);
            this.lblFabrica.Name = "lblFabrica";
            this.lblFabrica.Size = new System.Drawing.Size(28, 18);
            this.lblFabrica.TabIndex = 513;
            this.lblFabrica.Text = ".....";
            // 
            // lblNocliente
            // 
            this.lblNocliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNocliente.AutoSize = true;
            this.lblNocliente.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNocliente.Location = new System.Drawing.Point(193, 26);
            this.lblNocliente.Name = "lblNocliente";
            this.lblNocliente.Size = new System.Drawing.Size(24, 18);
            this.lblNocliente.TabIndex = 515;
            this.lblNocliente.Text = "....";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 514;
            this.label3.Text = "Cliente :";
            // 
            // FrmNewMaestroMezcalero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 178);
            this.Controls.Add(this.lblNocliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFabrica);
            this.Controls.Add(this.TxtMaestro);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNewMaestroMezcalero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Maestro Mezcalero";
            this.Load += new System.EventHandler(this.FrmNewMaestroMezcalero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtMaestro;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFabrica;
        private System.Windows.Forms.Label lblNocliente;
        private System.Windows.Forms.Label label3;
    }
}