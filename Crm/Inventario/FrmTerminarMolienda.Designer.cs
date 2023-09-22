namespace Crm.Inventario
{
    partial class FrmTerminarMolienda
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
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.ChekFormulacion = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataTimeInicioFormulacion = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.DataTimeFinalMolienda = new System.Windows.Forms.DateTimePicker();
            this.ChekMolienda = new System.Windows.Forms.CheckBox();
            this.TxtArt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(228, 277);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 274;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // ChekFormulacion
            // 
            this.ChekFormulacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekFormulacion.AutoSize = true;
            this.ChekFormulacion.Location = new System.Drawing.Point(226, 58);
            this.ChekFormulacion.Name = "ChekFormulacion";
            this.ChekFormulacion.Size = new System.Drawing.Size(150, 17);
            this.ChekFormulacion.TabIndex = 273;
            this.ChekFormulacion.Text = "Inicia Periodo Formulacion";
            this.ChekFormulacion.UseVisualStyleBackColor = true;
            this.ChekFormulacion.CheckedChanged += new System.EventHandler(this.ChekFormulacion_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 18);
            this.label1.TabIndex = 272;
            this.label1.Text = "Inicia  periodo de formulacion :";
            // 
            // DataTimeInicioFormulacion
            // 
            this.DataTimeInicioFormulacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataTimeInicioFormulacion.Location = new System.Drawing.Point(223, 77);
            this.DataTimeInicioFormulacion.Name = "DataTimeInicioFormulacion";
            this.DataTimeInicioFormulacion.Size = new System.Drawing.Size(211, 20);
            this.DataTimeInicioFormulacion.TabIndex = 271;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(197, 18);
            this.label13.TabIndex = 270;
            this.label13.Text = "Finaliza periodo de molienda :";
            // 
            // DataTimeFinalMolienda
            // 
            this.DataTimeFinalMolienda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataTimeFinalMolienda.Location = new System.Drawing.Point(224, 27);
            this.DataTimeFinalMolienda.Name = "DataTimeFinalMolienda";
            this.DataTimeFinalMolienda.Size = new System.Drawing.Size(210, 20);
            this.DataTimeFinalMolienda.TabIndex = 269;
            // 
            // ChekMolienda
            // 
            this.ChekMolienda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekMolienda.AutoSize = true;
            this.ChekMolienda.Location = new System.Drawing.Point(227, 8);
            this.ChekMolienda.Name = "ChekMolienda";
            this.ChekMolienda.Size = new System.Drawing.Size(146, 17);
            this.ChekMolienda.TabIndex = 275;
            this.ChekMolienda.Text = "Finaliza Periodo Molienda";
            this.ChekMolienda.UseVisualStyleBackColor = true;
            this.ChekMolienda.CheckedChanged += new System.EventHandler(this.ChekMolienda_CheckedChanged);
            // 
            // TxtArt
            // 
            this.TxtArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtArt.Location = new System.Drawing.Point(223, 245);
            this.TxtArt.MaxLength = 9;
            this.TxtArt.Name = "TxtArt";
            this.TxtArt.Size = new System.Drawing.Size(139, 20);
            this.TxtArt.TabIndex = 280;
            this.TxtArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtArt_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(168, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 18);
            this.label8.TabIndex = 281;
            this.label8.Text = "% ART :";
            // 
            // FrmTerminarMolienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 322);
            this.Controls.Add(this.TxtArt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ChekMolienda);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.ChekFormulacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataTimeInicioFormulacion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DataTimeFinalMolienda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTerminarMolienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "  Terminar Molienda";
            this.Load += new System.EventHandler(this.FrmTerminarMolienda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.CheckBox ChekFormulacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DataTimeInicioFormulacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DataTimeFinalMolienda;
        private System.Windows.Forms.CheckBox ChekMolienda;
        private System.Windows.Forms.TextBox TxtArt;
        private System.Windows.Forms.Label label8;

    }
}