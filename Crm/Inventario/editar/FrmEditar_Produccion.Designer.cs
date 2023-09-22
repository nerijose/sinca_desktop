namespace Crm.Inventario.editar
{
    partial class FrmEditar_Produccion
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
            this.iTalk_Panel1 = new iTalk_Panel();
            this.iTalk_Label1 = new iTalk_Label();
            this.iTalk_Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iTalk_Panel1
            // 
            this.iTalk_Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.iTalk_Panel1.Controls.Add(this.iTalk_Label1);
            this.iTalk_Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_Panel1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_Panel1.Name = "iTalk_Panel1";
            this.iTalk_Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.iTalk_Panel1.Size = new System.Drawing.Size(442, 373);
            this.iTalk_Panel1.TabIndex = 0;
            this.iTalk_Panel1.Text = "iTalk_Panel1";
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.AutoSize = true;
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.iTalk_Label1.Location = new System.Drawing.Point(147, 9);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(90, 19);
            this.iTalk_Label1.TabIndex = 0;
            this.iTalk_Label1.Text = "Producción";
            // 
            // FrmEditar_Produccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 373);
            this.Controls.Add(this.iTalk_Panel1);
            this.Name = "FrmEditar_Produccion";
            this.Text = "Form1";
            this.iTalk_Panel1.ResumeLayout(false);
            this.iTalk_Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk_Panel iTalk_Panel1;
        private iTalk_Label iTalk_Label1;


    }
}