namespace Crm.Inventario.editar
{
    partial class FrmCambioTanques
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNoLoteActual = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnAgregarTanque = new System.Windows.Forms.Button();
            this.TxtTanque = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCambioNombre = new System.Windows.Forms.Button();
            this.DtaTanques = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtaTanques)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoLoteActual
            // 
            this.lblNoLoteActual.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoLoteActual.AutoSize = true;
            this.lblNoLoteActual.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoLoteActual.Location = new System.Drawing.Point(94, 11);
            this.lblNoLoteActual.Name = "lblNoLoteActual";
            this.lblNoLoteActual.Size = new System.Drawing.Size(24, 18);
            this.lblNoLoteActual.TabIndex = 519;
            this.lblNoLoteActual.Text = "....";
            // 
            // label49
            // 
            this.label49.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(19, 11);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(64, 18);
            this.label49.TabIndex = 518;
            this.label49.Text = "No Lote :";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Black;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnGuardar.Location = new System.Drawing.Point(174, 215);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(45, 39);
            this.BtnGuardar.TabIndex = 524;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnAgregarTanque
            // 
            this.BtnAgregarTanque.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAgregarTanque.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarTanque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarTanque.FlatAppearance.BorderSize = 0;
            this.BtnAgregarTanque.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarTanque.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarTanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarTanque.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarTanque.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarTanque.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnAgregarTanque.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregarTanque.Location = new System.Drawing.Point(311, 17);
            this.BtnAgregarTanque.Name = "BtnAgregarTanque";
            this.BtnAgregarTanque.Size = new System.Drawing.Size(33, 38);
            this.BtnAgregarTanque.TabIndex = 528;
            this.BtnAgregarTanque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarTanque.UseVisualStyleBackColor = false;
            this.BtnAgregarTanque.Click += new System.EventHandler(this.BtnAgregarTanque_Click);
            // 
            // TxtTanque
            // 
            this.TxtTanque.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtTanque.Location = new System.Drawing.Point(155, 28);
            this.TxtTanque.MaxLength = 20;
            this.TxtTanque.Name = "TxtTanque";
            this.TxtTanque.Size = new System.Drawing.Size(155, 20);
            this.TxtTanque.TabIndex = 526;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(73, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 18);
            this.label18.TabIndex = 527;
            this.label18.Text = "No tanque :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCambioNombre);
            this.groupBox2.Controls.Add(this.DtaTanques);
            this.groupBox2.Controls.Add(this.BtnAgregarTanque);
            this.groupBox2.Controls.Add(this.TxtTanque);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(19, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 175);
            this.groupBox2.TabIndex = 527;
            this.groupBox2.TabStop = false;
            // 
            // BtnCambioNombre
            // 
            this.BtnCambioNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCambioNombre.BackColor = System.Drawing.Color.Transparent;
            this.BtnCambioNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCambioNombre.FlatAppearance.BorderSize = 0;
            this.BtnCambioNombre.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnCambioNombre.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnCambioNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambioNombre.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambioNombre.ForeColor = System.Drawing.Color.White;
            this.BtnCambioNombre.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnCambioNombre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCambioNombre.Location = new System.Drawing.Point(316, 17);
            this.BtnCambioNombre.Name = "BtnCambioNombre";
            this.BtnCambioNombre.Size = new System.Drawing.Size(33, 40);
            this.BtnCambioNombre.TabIndex = 529;
            this.BtnCambioNombre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCambioNombre.UseVisualStyleBackColor = false;
            this.BtnCambioNombre.Click += new System.EventHandler(this.BtnCambioNombre_Click);
            // 
            // DtaTanques
            // 
            this.DtaTanques.AllowUserToAddRows = false;
            this.DtaTanques.AllowUserToDeleteRows = false;
            this.DtaTanques.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaTanques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaTanques.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaTanques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaTanques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtaTanques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtaTanques.DefaultCellStyle = dataGridViewCellStyle2;
            this.DtaTanques.EnableHeadersVisualStyles = false;
            this.DtaTanques.Location = new System.Drawing.Point(22, 61);
            this.DtaTanques.Name = "DtaTanques";
            this.DtaTanques.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaTanques.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DtaTanques.Size = new System.Drawing.Size(347, 97);
            this.DtaTanques.TabIndex = 523;
            this.DtaTanques.TabStop = false;
            this.DtaTanques.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaTanques_CellDoubleClick);
            // 
            // FrmCambioTanques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 270);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.lblNoLoteActual);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCambioTanques";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCambioTanques";
            this.Load += new System.EventHandler(this.FrmCambioTanques_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtaTanques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoLoteActual;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnAgregarTanque;
        private System.Windows.Forms.TextBox TxtTanque;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DtaTanques;
        private System.Windows.Forms.Button BtnCambioNombre;
    }
}