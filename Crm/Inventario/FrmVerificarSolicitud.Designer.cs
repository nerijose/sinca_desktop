namespace Crm.Inventario
{
    partial class FrmVerificarSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerificarSolicitud));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFabrica = new System.Windows.Forms.CheckBox();
            this.cbEnvasadora = new System.Windows.Forms.CheckBox();
            this.cbAlmacen = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbParcial = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona las actividades a realizar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Verifica atentamente las actividades seleccionadas, en caso \r\nde requerirse puede" +
    "s agregar o quitar opciones";
            // 
            // cbFabrica
            // 
            this.cbFabrica.AutoSize = true;
            this.cbFabrica.Location = new System.Drawing.Point(27, 22);
            this.cbFabrica.Name = "cbFabrica";
            this.cbFabrica.Size = new System.Drawing.Size(124, 17);
            this.cbFabrica.TabIndex = 2;
            this.cbFabrica.Text = "Dictamen de Fabrica";
            this.cbFabrica.UseVisualStyleBackColor = true;
            // 
            // cbEnvasadora
            // 
            this.cbEnvasadora.AutoSize = true;
            this.cbEnvasadora.Location = new System.Drawing.Point(27, 46);
            this.cbEnvasadora.Name = "cbEnvasadora";
            this.cbEnvasadora.Size = new System.Drawing.Size(146, 17);
            this.cbEnvasadora.TabIndex = 3;
            this.cbEnvasadora.Text = "Dictamen de Envasadora";
            this.cbEnvasadora.UseVisualStyleBackColor = true;
            // 
            // cbAlmacen
            // 
            this.cbAlmacen.AutoSize = true;
            this.cbAlmacen.Location = new System.Drawing.Point(27, 70);
            this.cbAlmacen.Name = "cbAlmacen";
            this.cbAlmacen.Size = new System.Drawing.Size(130, 17);
            this.cbAlmacen.TabIndex = 4;
            this.cbAlmacen.Text = "Dictamen de Almacén";
            this.cbAlmacen.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbEnvasadora);
            this.groupBox1.Controls.Add(this.cbAlmacen);
            this.groupBox1.Controls.Add(this.cbFabrica);
            this.groupBox1.Location = new System.Drawing.Point(-1, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instalaciones a dictaminar";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbParcial);
            this.groupBox2.Location = new System.Drawing.Point(-1, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 45);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solicitud parcial";
            // 
            // cbParcial
            // 
            this.cbParcial.AutoSize = true;
            this.cbParcial.Location = new System.Drawing.Point(27, 22);
            this.cbParcial.Name = "cbParcial";
            this.cbParcial.Size = new System.Drawing.Size(35, 17);
            this.cbParcial.TabIndex = 2;
            this.cbParcial.Text = "Si";
            this.cbParcial.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(414, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "NOTA: solicitud parcial aplica cuando no se realizaran todas las actividades \r\nas" +
    "iganadas por el ORGANISMO DE CERTIFICACIÓN";
            // 
            // btnContinuar
            // 
            this.btnContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuar.Location = new System.Drawing.Point(171, 309);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(85, 27);
            this.btnContinuar.TabIndex = 8;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // FrmVerificarSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 363);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVerificarSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPORTANTE";
            this.Load += new System.EventHandler(this.FrmVerificarSolicitud_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbFabrica;
        private System.Windows.Forms.CheckBox cbEnvasadora;
        private System.Windows.Forms.CheckBox cbAlmacen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbParcial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnContinuar;
    }
}