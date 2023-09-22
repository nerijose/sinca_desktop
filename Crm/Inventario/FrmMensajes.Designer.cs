namespace Crm.Inventario
{
    partial class FrmMensajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMensajes));
            this.TxtMensaje = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.TxtMensajes = new System.Windows.Forms.RichTextBox();
            this.BtnGuardarMensaje = new System.Windows.Forms.Button();
            this.ImgPromocion = new System.Windows.Forms.PictureBox();
            this.label35 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkDeleteProduction = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPromocion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtMensaje
            // 
            this.TxtMensaje.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtMensaje.Location = new System.Drawing.Point(87, 275);
            this.TxtMensaje.Name = "TxtMensaje";
            this.TxtMensaje.Size = new System.Drawing.Size(550, 20);
            this.TxtMensaje.TabIndex = 216;
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(12, 275);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(69, 18);
            this.label37.TabIndex = 215;
            this.label37.Text = "Mensaje :";
            // 
            // TxtMensajes
            // 
            this.TxtMensajes.BackColor = System.Drawing.SystemColors.Window;
            this.TxtMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtMensajes.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMensajes.Location = new System.Drawing.Point(12, 45);
            this.TxtMensajes.Name = "TxtMensajes";
            this.TxtMensajes.ReadOnly = true;
            this.TxtMensajes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.TxtMensajes.ShowSelectionMargin = true;
            this.TxtMensajes.Size = new System.Drawing.Size(631, 212);
            this.TxtMensajes.TabIndex = 214;
            this.TxtMensajes.Text = "";
            // 
            // BtnGuardarMensaje
            // 
            this.BtnGuardarMensaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuardarMensaje.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardarMensaje.FlatAppearance.BorderSize = 0;
            this.BtnGuardarMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarMensaje.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarMensaje.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarMensaje.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardarMensaje.Location = new System.Drawing.Point(302, 306);
            this.BtnGuardarMensaje.Name = "BtnGuardarMensaje";
            this.BtnGuardarMensaje.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardarMensaje.TabIndex = 212;
            this.BtnGuardarMensaje.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardarMensaje.UseVisualStyleBackColor = false;
            this.BtnGuardarMensaje.Click += new System.EventHandler(this.BtnGuardarMensaje_Click);
            // 
            // ImgPromocion
            // 
            this.ImgPromocion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ImgPromocion.Image = global::Crm.Properties.Resources.speech_bubble__1_;
            this.ImgPromocion.Location = new System.Drawing.Point(567, 6);
            this.ImgPromocion.Name = "ImgPromocion";
            this.ImgPromocion.Size = new System.Drawing.Size(32, 33);
            this.ImgPromocion.TabIndex = 330;
            this.ImgPromocion.TabStop = false;
            this.ImgPromocion.Visible = false;
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(290, 14);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(101, 18);
            this.label35.TabIndex = 332;
            this.label35.Text = "Observaciones";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(611, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 33);
            this.pictureBox1.TabIndex = 333;
            this.pictureBox1.TabStop = false;
            // 
            // chkDeleteProduction
            // 
            this.chkDeleteProduction.AutoSize = true;
            this.chkDeleteProduction.ForeColor = System.Drawing.Color.Red;
            this.chkDeleteProduction.Location = new System.Drawing.Point(15, 22);
            this.chkDeleteProduction.Name = "chkDeleteProduction";
            this.chkDeleteProduction.Size = new System.Drawing.Size(129, 17);
            this.chkDeleteProduction.TabIndex = 334;
            this.chkDeleteProduction.Text = "Eliminar la producción";
            this.chkDeleteProduction.UseVisualStyleBackColor = true;
            // 
            // FrmMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 349);
            this.Controls.Add(this.chkDeleteProduction);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.ImgPromocion);
            this.Controls.Add(this.TxtMensaje);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.TxtMensajes);
            this.Controls.Add(this.BtnGuardarMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMensajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Observaciones";
            this.Load += new System.EventHandler(this.FrmMensajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgPromocion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtMensaje;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.RichTextBox TxtMensajes;
        private System.Windows.Forms.Button BtnGuardarMensaje;
        private System.Windows.Forms.PictureBox ImgPromocion;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkDeleteProduction;
    }
}