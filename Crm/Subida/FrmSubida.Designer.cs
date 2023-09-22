namespace Crm.Subida
{
    partial class FrmSubida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubida));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.GifSubida = new System.Windows.Forms.PictureBox();
            this.DtaMagueyPendiente = new System.Windows.Forms.DataGridView();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BackgroundWorkerSubidaMaguey = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GifSubida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaMagueyPendiente)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1034, 582);
            this.tabControl1.TabIndex = 68;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.GifSubida);
            this.tabPage1.Controls.Add(this.DtaMagueyPendiente);
            this.tabPage1.Controls.Add(this.BtnGuardar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1026, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Extracciones de maguey";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(387, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 18);
            this.label8.TabIndex = 111;
            this.label8.Text = "Extracciones de maguey por actualizar";
            // 
            // GifSubida
            // 
            this.GifSubida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GifSubida.Image = global::Crm.Properties.Resources.loading2;
            this.GifSubida.Location = new System.Drawing.Point(445, -20);
            this.GifSubida.Name = "GifSubida";
            this.GifSubida.Size = new System.Drawing.Size(136, 89);
            this.GifSubida.TabIndex = 113;
            this.GifSubida.TabStop = false;
            // 
            // DtaMagueyPendiente
            // 
            this.DtaMagueyPendiente.AllowUserToAddRows = false;
            this.DtaMagueyPendiente.AllowUserToDeleteRows = false;
            this.DtaMagueyPendiente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaMagueyPendiente.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaMagueyPendiente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaMagueyPendiente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtaMagueyPendiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaMagueyPendiente.Location = new System.Drawing.Point(90, 73);
            this.DtaMagueyPendiente.Name = "DtaMagueyPendiente";
            this.DtaMagueyPendiente.ReadOnly = true;
            this.DtaMagueyPendiente.Size = new System.Drawing.Size(844, 404);
            this.DtaMagueyPendiente.TabIndex = 97;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuardar.Image")));
            this.BtnGuardar.Location = new System.Drawing.Point(480, 483);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(72, 70);
            this.BtnGuardar.TabIndex = 96;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1026, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Actualizar 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BackgroundWorkerSubidaMaguey
            // 
            this.BackgroundWorkerSubidaMaguey.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerSubidaMaguey_DoWork);
            this.BackgroundWorkerSubidaMaguey.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerSubidaMaguey_ProgressChanged);
            this.BackgroundWorkerSubidaMaguey.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerSubidaMaguey_RunWorkerCompleted);
            // 
            // FrmSubida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 582);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSubida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subida de información";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSubida_FormClosing);
            this.Load += new System.EventHandler(this.FrmSubida_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GifSubida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaMagueyPendiente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.DataGridView DtaMagueyPendiente;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerSubidaMaguey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox GifSubida;

    }
}