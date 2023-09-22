namespace Crm.Inventario
{
    partial class FrmTerminarFormulacion
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
            this.ChekDestilacion = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataTimeInicioDestilacion = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.DataTimeFinalFormulacion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtVolumen = new System.Windows.Forms.TextBox();
            this.CmbFermentacion = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbTipoDestilacion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.ChekFermentacion = new System.Windows.Forms.CheckBox();
            this.TxtArt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChekDestilacion
            // 
            this.ChekDestilacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekDestilacion.AutoSize = true;
            this.ChekDestilacion.Location = new System.Drawing.Point(277, 157);
            this.ChekDestilacion.Name = "ChekDestilacion";
            this.ChekDestilacion.Size = new System.Drawing.Size(145, 17);
            this.ChekDestilacion.TabIndex = 279;
            this.ChekDestilacion.Text = "Inicia Periodo Destilación";
            this.ChekDestilacion.UseVisualStyleBackColor = true;
            this.ChekDestilacion.CheckedChanged += new System.EventHandler(this.ChekDestilacion_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 278;
            this.label1.Text = "Inicia  periodo de destilación :";
            // 
            // DataTimeInicioDestilacion
            // 
            this.DataTimeInicioDestilacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataTimeInicioDestilacion.Location = new System.Drawing.Point(273, 176);
            this.DataTimeInicioDestilacion.Name = "DataTimeInicioDestilacion";
            this.DataTimeInicioDestilacion.Size = new System.Drawing.Size(211, 20);
            this.DataTimeInicioDestilacion.TabIndex = 277;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(58, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(215, 18);
            this.label13.TabIndex = 276;
            this.label13.Text = "Finaliza periodo de formulación :";
            // 
            // DataTimeFinalFormulacion
            // 
            this.DataTimeFinalFormulacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataTimeFinalFormulacion.Location = new System.Drawing.Point(274, 71);
            this.DataTimeFinalFormulacion.Name = "DataTimeFinalFormulacion";
            this.DataTimeFinalFormulacion.Size = new System.Drawing.Size(210, 20);
            this.DataTimeFinalFormulacion.TabIndex = 275;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 18);
            this.label2.TabIndex = 281;
            this.label2.Text = "Volumen total del mosto :";
            // 
            // TxtVolumen
            // 
            this.TxtVolumen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtVolumen.Location = new System.Drawing.Point(273, 122);
            this.TxtVolumen.Name = "TxtVolumen";
            this.TxtVolumen.Size = new System.Drawing.Size(100, 20);
            this.TxtVolumen.TabIndex = 282;
            this.TxtVolumen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtVolumen_KeyPress);
            // 
            // CmbFermentacion
            // 
            this.CmbFermentacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbFermentacion.FormattingEnabled = true;
            this.CmbFermentacion.Location = new System.Drawing.Point(273, 96);
            this.CmbFermentacion.Name = "CmbFermentacion";
            this.CmbFermentacion.Size = new System.Drawing.Size(212, 21);
            this.CmbFermentacion.TabIndex = 285;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(119, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(151, 18);
            this.label15.TabIndex = 286;
            this.label15.Text = "Tipo de fermentación :";
            // 
            // CmbTipoDestilacion
            // 
            this.CmbTipoDestilacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbTipoDestilacion.DropDownWidth = 350;
            this.CmbTipoDestilacion.FormattingEnabled = true;
            this.CmbTipoDestilacion.Location = new System.Drawing.Point(272, 202);
            this.CmbTipoDestilacion.Name = "CmbTipoDestilacion";
            this.CmbTipoDestilacion.Size = new System.Drawing.Size(212, 21);
            this.CmbTipoDestilacion.TabIndex = 287;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(135, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 288;
            this.label3.Text = "Tipo de destilación :";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(256, 274);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 291;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // ChekFermentacion
            // 
            this.ChekFermentacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekFermentacion.AutoSize = true;
            this.ChekFermentacion.Location = new System.Drawing.Point(277, 52);
            this.ChekFermentacion.Name = "ChekFermentacion";
            this.ChekFermentacion.Size = new System.Drawing.Size(160, 17);
            this.ChekFermentacion.TabIndex = 292;
            this.ChekFermentacion.Text = "Finaliza  Periodo formulación";
            this.ChekFermentacion.UseVisualStyleBackColor = true;
            this.ChekFermentacion.Click += new System.EventHandler(this.ChekFermentacion_Click);
            // 
            // TxtArt
            // 
            this.TxtArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtArt.Location = new System.Drawing.Point(272, 229);
            this.TxtArt.MaxLength = 9;
            this.TxtArt.Name = "TxtArt";
            this.TxtArt.Size = new System.Drawing.Size(101, 20);
            this.TxtArt.TabIndex = 293;
            this.TxtArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtArt_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(217, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 18);
            this.label8.TabIndex = 294;
            this.label8.Text = "% ART :";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar.ForeColor = System.Drawing.Color.White;
            this.BtnCerrar.Image = global::Crm.Properties.Resources.cancel;
            this.BtnCerrar.Location = new System.Drawing.Point(511, 1);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(36, 36);
            this.BtnCerrar.TabIndex = 295;
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Visible = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FrmTerminarFormulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 324);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.TxtArt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ChekFermentacion);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.CmbTipoDestilacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbFermentacion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TxtVolumen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChekDestilacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataTimeInicioDestilacion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DataTimeFinalFormulacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmTerminarFormulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Terminar Formulación";
            this.Load += new System.EventHandler(this.FrmTerminarFormulacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChekDestilacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DataTimeInicioDestilacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DataTimeFinalFormulacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtVolumen;
        private System.Windows.Forms.ComboBox CmbFermentacion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CmbTipoDestilacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.CheckBox ChekFermentacion;
        private System.Windows.Forms.TextBox TxtArt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnCerrar;
    }
}