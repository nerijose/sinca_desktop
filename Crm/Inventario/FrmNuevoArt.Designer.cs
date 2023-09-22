namespace Crm.Inventario
{
    partial class FrmNuevoArt
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
            this.TxtArt = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.BtnGuardarGranel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtArt
            // 
            this.TxtArt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtArt.Location = new System.Drawing.Point(80, 18);
            this.TxtArt.MaxLength = 100;
            this.TxtArt.Name = "TxtArt";
            this.TxtArt.Size = new System.Drawing.Size(158, 20);
            this.TxtArt.TabIndex = 287;
            this.TxtArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtArt_KeyPress);
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(17, 18);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(52, 18);
            this.label33.TabIndex = 288;
            this.label33.Text = "% ART :";
            // 
            // BtnGuardarGranel
            // 
            this.BtnGuardarGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuardarGranel.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardarGranel.FlatAppearance.BorderSize = 0;
            this.BtnGuardarGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarGranel.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarGranel.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardarGranel.Location = new System.Drawing.Point(108, 49);
            this.BtnGuardarGranel.Name = "BtnGuardarGranel";
            this.BtnGuardarGranel.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardarGranel.TabIndex = 289;
            this.BtnGuardarGranel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardarGranel.UseVisualStyleBackColor = false;
            this.BtnGuardarGranel.Click += new System.EventHandler(this.BtnGuardarGranel_Click);
            // 
            // FrmNuevoArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 100);
            this.Controls.Add(this.BtnGuardarGranel);
            this.Controls.Add(this.TxtArt);
            this.Controls.Add(this.label33);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNuevoArt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo art";
            this.Load += new System.EventHandler(this.FrmNuevoArt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtArt;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button BtnGuardarGranel;

    }
}