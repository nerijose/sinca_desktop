namespace Crm.Administrador
{
    partial class FrmAdministrador
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerDBRestura = new System.ComponentModel.BackgroundWorker();
            this.iTalk_Label1 = new iTalk_Label();
            this.iTalk_TabControl1 = new iTalk_TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnBackups = new iTalk_Button_2();
            this.btnalters = new iTalk_Button_2();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblporcentaje = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVerificadoresList = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRestauraDatos = new iTalk_Button_2();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Btnfor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.iTalk_TabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Crm.Properties.Resources.management128;
            this.pictureBox1.Location = new System.Drawing.Point(1035, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorkerDBRestura
            // 
            this.backgroundWorkerDBRestura.WorkerReportsProgress = true;
            this.backgroundWorkerDBRestura.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDBRestura_DoWork);
            this.backgroundWorkerDBRestura.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDBRestura_ProgressChanged);
            this.backgroundWorkerDBRestura.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDBRestura_RunWorkerCompleted);
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iTalk_Label1.AutoSize = true;
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_Label1.ForeColor = System.Drawing.Color.Green;
            this.iTalk_Label1.Location = new System.Drawing.Point(392, 46);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(334, 36);
            this.iTalk_Label1.TabIndex = 25;
            this.iTalk_Label1.Text = "Administracion del sistema";
            // 
            // iTalk_TabControl1
            // 
            this.iTalk_TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.iTalk_TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_TabControl1.Controls.Add(this.tabPage3);
            this.iTalk_TabControl1.Controls.Add(this.tabPage4);
            this.iTalk_TabControl1.Controls.Add(this.tabPage1);
            this.iTalk_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.iTalk_TabControl1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_TabControl1.ItemSize = new System.Drawing.Size(44, 135);
            this.iTalk_TabControl1.Location = new System.Drawing.Point(-1, 140);
            this.iTalk_TabControl1.Multiline = true;
            this.iTalk_TabControl1.Name = "iTalk_TabControl1";
            this.iTalk_TabControl1.SelectedIndex = 0;
            this.iTalk_TabControl1.Size = new System.Drawing.Size(1211, 649);
            this.iTalk_TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.iTalk_TabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage3.Controls.Add(this.Btnfor);
            this.tabPage3.Controls.Add(this.BtnBackups);
            this.tabPage3.Controls.Add(this.btnalters);
            this.tabPage3.Location = new System.Drawing.Point(139, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1068, 641);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Alters";
            // 
            // BtnBackups
            // 
            this.BtnBackups.BackColor = System.Drawing.Color.Transparent;
            this.BtnBackups.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.BtnBackups.ForeColor = System.Drawing.Color.White;
            this.BtnBackups.Image = null;
            this.BtnBackups.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBackups.Location = new System.Drawing.Point(384, 69);
            this.BtnBackups.Name = "BtnBackups";
            this.BtnBackups.Size = new System.Drawing.Size(166, 40);
            this.BtnBackups.TabIndex = 1;
            this.BtnBackups.Text = "Backup";
            this.BtnBackups.TextAlignment = System.Drawing.StringAlignment.Center;
            this.BtnBackups.Click += new System.EventHandler(this.BtnBackups_Click);
            // 
            // btnalters
            // 
            this.btnalters.BackColor = System.Drawing.Color.Transparent;
            this.btnalters.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnalters.ForeColor = System.Drawing.Color.White;
            this.btnalters.Image = null;
            this.btnalters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnalters.Location = new System.Drawing.Point(880, 37);
            this.btnalters.Name = "btnalters";
            this.btnalters.Size = new System.Drawing.Size(166, 40);
            this.btnalters.TabIndex = 0;
            this.btnalters.Text = "Cargar alters";
            this.btnalters.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnalters.Click += new System.EventHandler(this.btnalters_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage4.Controls.Add(this.lblporcentaje);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.cmbVerificadoresList);
            this.tabPage4.Controls.Add(this.progressBar1);
            this.tabPage4.Controls.Add(this.btnRestauraDatos);
            this.tabPage4.Location = new System.Drawing.Point(139, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1068, 641);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Restaurar db ";
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // lblporcentaje
            // 
            this.lblporcentaje.AutoSize = true;
            this.lblporcentaje.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblporcentaje.Location = new System.Drawing.Point(277, 235);
            this.lblporcentaje.Name = "lblporcentaje";
            this.lblporcentaje.Size = new System.Drawing.Size(30, 23);
            this.lblporcentaje.TabIndex = 4;
            this.lblporcentaje.Text = "....";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Verificador :";
            // 
            // cmbVerificadoresList
            // 
            this.cmbVerificadoresList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerificadoresList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVerificadoresList.FormattingEnabled = true;
            this.cmbVerificadoresList.Location = new System.Drawing.Point(281, 83);
            this.cmbVerificadoresList.Name = "cmbVerificadoresList";
            this.cmbVerificadoresList.Size = new System.Drawing.Size(440, 23);
            this.cmbVerificadoresList.TabIndex = 2;
            this.cmbVerificadoresList.SelectedIndexChanged += new System.EventHandler(this.cmbVerificadoresList_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(281, 303);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(440, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btnRestauraDatos
            // 
            this.btnRestauraDatos.BackColor = System.Drawing.Color.Transparent;
            this.btnRestauraDatos.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnRestauraDatos.ForeColor = System.Drawing.Color.White;
            this.btnRestauraDatos.Image = null;
            this.btnRestauraDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestauraDatos.Location = new System.Drawing.Point(400, 154);
            this.btnRestauraDatos.Name = "btnRestauraDatos";
            this.btnRestauraDatos.Size = new System.Drawing.Size(166, 40);
            this.btnRestauraDatos.TabIndex = 0;
            this.btnRestauraDatos.Text = "Restaura Datos";
            this.btnRestauraDatos.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRestauraDatos.Click += new System.EventHandler(this.btnRestauraDatos_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage1.Location = new System.Drawing.Point(139, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(1068, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config.";
            // 
            // Btnfor
            // 
            this.Btnfor.Location = new System.Drawing.Point(410, 247);
            this.Btnfor.Name = "Btnfor";
            this.Btnfor.Size = new System.Drawing.Size(75, 23);
            this.Btnfor.TabIndex = 2;
            this.Btnfor.Text = "button1";
            this.Btnfor.UseVisualStyleBackColor = true;
            this.Btnfor.Click += new System.EventHandler(this.Btnfor_Click);
            // 
            // FrmAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 788);
            this.Controls.Add(this.iTalk_Label1);
            this.Controls.Add(this.iTalk_TabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmAdministrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración";
            this.Load += new System.EventHandler(this.FrmAdministrador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.iTalk_TabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private iTalk_TabControl iTalk_TabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private iTalk_Button_2 btnalters;
        private System.Windows.Forms.PictureBox pictureBox1;
        private iTalk_Label iTalk_Label1;
        private iTalk_Button_2 btnRestauraDatos;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDBRestura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVerificadoresList;
        private System.Windows.Forms.Label lblporcentaje;
        private iTalk_Button_2 BtnBackups;
        private System.Windows.Forms.Button Btnfor;
    }
}