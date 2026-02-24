namespace Crm.Inventario
{
    partial class FrmListaInstalaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaInstalaciones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInstalacionesSolicitud = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerarActaDetallada = new iTalk_Button_2();
            this.btnVerActa = new iTalk_Button_1();
            this.btnGenerarInforme = new iTalk_Button_2();
            this.btnGenerarBuenasPracticas = new iTalk_Button_2();
            this.btnVerInforme = new iTalk_Button_1();
            this.btnVerBuenasPracticas = new iTalk_Button_1();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.iTalk_HeaderLabel1 = new iTalk_HeaderLabel();
            this.iTalk_Button_11 = new iTalk_Button_1();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstalacionesSolicitud)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 451);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvInstalacionesSolicitud, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.iTalk_HeaderLabel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.91067F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.5122F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.73615F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(799, 451);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // dgvInstalacionesSolicitud
            // 
            this.dgvInstalacionesSolicitud.AllowUserToAddRows = false;
            this.dgvInstalacionesSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInstalacionesSolicitud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstalacionesSolicitud.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInstalacionesSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstalacionesSolicitud.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvInstalacionesSolicitud.Location = new System.Drawing.Point(3, 56);
            this.dgvInstalacionesSolicitud.Name = "dgvInstalacionesSolicitud";
            this.dgvInstalacionesSolicitud.Size = new System.Drawing.Size(793, 81);
            this.dgvInstalacionesSolicitud.TabIndex = 5;
            this.dgvInstalacionesSolicitud.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstalacionesSolicitud_CellContentClick_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.Controls.Add(this.btnGenerarActaDetallada, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnVerActa, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGenerarInforme, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGenerarBuenasPracticas, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnVerInforme, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnVerBuenasPracticas, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTerminar, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.iTalk_Button_11, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 143);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(793, 93);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // btnGenerarActaDetallada
            // 
            this.btnGenerarActaDetallada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarActaDetallada.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerarActaDetallada.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarActaDetallada.ForeColor = System.Drawing.Color.White;
            this.btnGenerarActaDetallada.Image = null;
            this.btnGenerarActaDetallada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarActaDetallada.Location = new System.Drawing.Point(3, 3);
            this.btnGenerarActaDetallada.Name = "btnGenerarActaDetallada";
            this.btnGenerarActaDetallada.Size = new System.Drawing.Size(205, 28);
            this.btnGenerarActaDetallada.TabIndex = 9;
            this.btnGenerarActaDetallada.Text = "Generar Acta detallada";
            this.btnGenerarActaDetallada.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGenerarActaDetallada.Click += new System.EventHandler(this.btnGenerarActaDetallada_Click);
            // 
            // btnVerActa
            // 
            this.btnVerActa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerActa.BackColor = System.Drawing.Color.Transparent;
            this.btnVerActa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVerActa.Image = ((System.Drawing.Image)(resources.GetObject("btnVerActa.Image")));
            this.btnVerActa.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerActa.Location = new System.Drawing.Point(214, 3);
            this.btnVerActa.Name = "btnVerActa";
            this.btnVerActa.Size = new System.Drawing.Size(46, 28);
            this.btnVerActa.TabIndex = 16;
            this.btnVerActa.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnVerActa.Click += new System.EventHandler(this.btnVerActa_Click);
            // 
            // btnGenerarInforme
            // 
            this.btnGenerarInforme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarInforme.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerarInforme.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarInforme.ForeColor = System.Drawing.Color.White;
            this.btnGenerarInforme.Image = null;
            this.btnGenerarInforme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarInforme.Location = new System.Drawing.Point(529, 3);
            this.btnGenerarInforme.Name = "btnGenerarInforme";
            this.btnGenerarInforme.Size = new System.Drawing.Size(205, 28);
            this.btnGenerarInforme.TabIndex = 10;
            this.btnGenerarInforme.Text = "Generar Informe";
            this.btnGenerarInforme.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGenerarInforme.Click += new System.EventHandler(this.btnGenerarInforme_Click);
            // 
            // btnGenerarBuenasPracticas
            // 
            this.btnGenerarBuenasPracticas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarBuenasPracticas.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerarBuenasPracticas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarBuenasPracticas.ForeColor = System.Drawing.Color.White;
            this.btnGenerarBuenasPracticas.Image = null;
            this.btnGenerarBuenasPracticas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarBuenasPracticas.Location = new System.Drawing.Point(266, 3);
            this.btnGenerarBuenasPracticas.Name = "btnGenerarBuenasPracticas";
            this.btnGenerarBuenasPracticas.Size = new System.Drawing.Size(205, 28);
            this.btnGenerarBuenasPracticas.TabIndex = 11;
            this.btnGenerarBuenasPracticas.Text = "Generar Buenas Practicas";
            this.btnGenerarBuenasPracticas.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGenerarBuenasPracticas.Click += new System.EventHandler(this.btnGenerarBuenasPracticas_Click);
            // 
            // btnVerInforme
            // 
            this.btnVerInforme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerInforme.BackColor = System.Drawing.Color.Transparent;
            this.btnVerInforme.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVerInforme.Image = ((System.Drawing.Image)(resources.GetObject("btnVerInforme.Image")));
            this.btnVerInforme.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerInforme.Location = new System.Drawing.Point(740, 3);
            this.btnVerInforme.Name = "btnVerInforme";
            this.btnVerInforme.Size = new System.Drawing.Size(50, 28);
            this.btnVerInforme.TabIndex = 18;
            this.btnVerInforme.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnVerInforme.Click += new System.EventHandler(this.btnVerInforme_Click);
            // 
            // btnVerBuenasPracticas
            // 
            this.btnVerBuenasPracticas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerBuenasPracticas.BackColor = System.Drawing.Color.Transparent;
            this.btnVerBuenasPracticas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVerBuenasPracticas.Image = ((System.Drawing.Image)(resources.GetObject("btnVerBuenasPracticas.Image")));
            this.btnVerBuenasPracticas.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerBuenasPracticas.Location = new System.Drawing.Point(477, 3);
            this.btnVerBuenasPracticas.Name = "btnVerBuenasPracticas";
            this.btnVerBuenasPracticas.Size = new System.Drawing.Size(46, 28);
            this.btnVerBuenasPracticas.TabIndex = 17;
            this.btnVerBuenasPracticas.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnVerBuenasPracticas.Click += new System.EventHandler(this.btnVerBuenasPracticas_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.BackColor = System.Drawing.Color.Green;
            this.btnTerminar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTerminar.Location = new System.Drawing.Point(266, 53);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(205, 37);
            this.btnTerminar.TabIndex = 19;
            this.btnTerminar.Text = "Terminar Solicitud";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // iTalk_HeaderLabel1
            // 
            this.iTalk_HeaderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_HeaderLabel1.AutoSize = true;
            this.iTalk_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel1.Location = new System.Drawing.Point(3, 0);
            this.iTalk_HeaderLabel1.Name = "iTalk_HeaderLabel1";
            this.iTalk_HeaderLabel1.Size = new System.Drawing.Size(793, 53);
            this.iTalk_HeaderLabel1.TabIndex = 1;
            this.iTalk_HeaderLabel1.Text = "Datos de la solicitud";
            this.iTalk_HeaderLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iTalk_HeaderLabel1.Click += new System.EventHandler(this.iTalk_HeaderLabel1_Click);
            // 
            // iTalk_Button_11
            // 
            this.iTalk_Button_11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_Button_11.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.iTalk_Button_11.Image = global::Crm.Properties.Resources.edit__2_;
            this.iTalk_Button_11.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iTalk_Button_11.Location = new System.Drawing.Point(214, 53);
            this.iTalk_Button_11.Name = "iTalk_Button_11";
            this.iTalk_Button_11.Size = new System.Drawing.Size(46, 37);
            this.iTalk_Button_11.TabIndex = 20;
            this.iTalk_Button_11.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_11.Click += new System.EventHandler(this.iTalk_Button_11_Click);
            // 
            // FrmListaInstalaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmListaInstalaciones";
            this.Text = "FrmNuevaInstalación";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.FrmListaInstalaciones_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstalacionesSolicitud)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private iTalk_HeaderLabel iTalk_HeaderLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvInstalacionesSolicitud;
        private iTalk_Button_2 btnGenerarActaDetallada;
        private iTalk_Button_2 btnGenerarBuenasPracticas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private iTalk_Button_2 btnGenerarInforme;
        private iTalk_Button_1 btnVerInforme;
        private iTalk_Button_1 btnVerBuenasPracticas;
        private iTalk_Button_1 btnVerActa;
        private System.Windows.Forms.Button btnTerminar;
        private iTalk_Button_1 iTalk_Button_11;
    }
}