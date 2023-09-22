namespace Crm.Inventario
{
    partial class FrmAgaveSobrante
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtaAgaveSobrante = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveSobrante)).BeginInit();
            this.SuspendLayout();
            // 
            // DtaAgaveSobrante
            // 
            this.DtaAgaveSobrante.AllowUserToAddRows = false;
            this.DtaAgaveSobrante.AllowUserToDeleteRows = false;
            this.DtaAgaveSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtaAgaveSobrante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaAgaveSobrante.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaAgaveSobrante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaAgaveSobrante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtaAgaveSobrante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaAgaveSobrante.EnableHeadersVisualStyles = false;
            this.DtaAgaveSobrante.Location = new System.Drawing.Point(1, 0);
            this.DtaAgaveSobrante.Name = "DtaAgaveSobrante";
            this.DtaAgaveSobrante.ReadOnly = true;
            this.DtaAgaveSobrante.Size = new System.Drawing.Size(332, 195);
            this.DtaAgaveSobrante.TabIndex = 312;
            this.DtaAgaveSobrante.TabStop = false;
            this.DtaAgaveSobrante.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaAgaveSobrante_CellContentClick);
            this.DtaAgaveSobrante.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaAgaveSobrante_CellDoubleClick);
            // 
            // FrmAgaveSobrante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 195);
            this.Controls.Add(this.DtaAgaveSobrante);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAgaveSobrante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agave Sobrante";
            this.Load += new System.EventHandler(this.FrmAgaveSobrante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaAgaveSobrante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtaAgaveSobrante;

    }
}