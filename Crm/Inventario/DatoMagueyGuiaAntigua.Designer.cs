namespace Crm.Inventario
{
    partial class DatoMagueyGuiaAntigua
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatoMagueyAntiguo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dato del maguey:";
            // 
            // txtDatoMagueyAntiguo
            // 
            this.txtDatoMagueyAntiguo.Location = new System.Drawing.Point(108, 19);
            this.txtDatoMagueyAntiguo.Name = "txtDatoMagueyAntiguo";
            this.txtDatoMagueyAntiguo.ReadOnly = true;
            this.txtDatoMagueyAntiguo.Size = new System.Drawing.Size(374, 20);
            this.txtDatoMagueyAntiguo.TabIndex = 1;
            // 
            // DatoMagueyGuiaAntigua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 60);
            this.Controls.Add(this.txtDatoMagueyAntiguo);
            this.Controls.Add(this.label1);
            this.Name = "DatoMagueyGuiaAntigua";
            this.Text = "DatoMagueyGuiaAntigua";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatoMagueyAntiguo;
    }
}