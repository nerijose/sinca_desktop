namespace Crm.Inventario
{
    partial class FrmClienteMaquila
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
            this.label2 = new System.Windows.Forms.Label();
            this.LblAsociado = new System.Windows.Forms.Label();
            this.TxtNoAsociado = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 288;
            this.label2.Text = "Cliente :";
            // 
            // LblAsociado
            // 
            this.LblAsociado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblAsociado.AutoSize = true;
            this.LblAsociado.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAsociado.Location = new System.Drawing.Point(98, 54);
            this.LblAsociado.Name = "LblAsociado";
            this.LblAsociado.Size = new System.Drawing.Size(36, 18);
            this.LblAsociado.TabIndex = 287;
            this.LblAsociado.Text = ".......";
            // 
            // TxtNoAsociado
            // 
            this.TxtNoAsociado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoAsociado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtNoAsociado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtNoAsociado.Location = new System.Drawing.Point(98, 14);
            this.TxtNoAsociado.MaxLength = 9;
            this.TxtNoAsociado.Name = "TxtNoAsociado";
            this.TxtNoAsociado.Size = new System.Drawing.Size(91, 20);
            this.TxtNoAsociado.TabIndex = 285;
            this.TxtNoAsociado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoAsociado_KeyDown);
            this.TxtNoAsociado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoAsociado_KeyPress);
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(11, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(81, 18);
            this.label26.TabIndex = 286;
            this.label26.Text = "No Cliente :";
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
            this.BtnGuardar.Location = new System.Drawing.Point(222, 98);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 289;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmClienteMaquila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 140);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblAsociado);
            this.Controls.Add(this.TxtNoAsociado);
            this.Controls.Add(this.label26);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmClienteMaquila";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente maquila";
            this.Load += new System.EventHandler(this.FrmClienteMaquila_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblAsociado;
        private System.Windows.Forms.TextBox TxtNoAsociado;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button BtnGuardar;

    }
}