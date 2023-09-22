namespace Crm.Inventario
{
    partial class FrmMovimientosVidrio
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
            this.DtaTanques = new System.Windows.Forms.DataGridView();
            this.TxtTanque = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtGradoAlcoholico = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNoLote = new System.Windows.Forms.TextBox();
            this.TxtLitros = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblEspecie = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblFq = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblIngrediente = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblTimevidrio = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LblGradoAlcoholico = new System.Windows.Forms.Label();
            this.ll = new System.Windows.Forms.Label();
            this.LblLitros = new System.Windows.Forms.Label();
            this.kk = new System.Windows.Forms.Label();
            this.LblFolio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblCategoria = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblClase = new System.Windows.Forms.Label();
            this.LblFechaIngreso = new System.Windows.Forms.Label();
            this.LblFechaSalida = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoLote = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnAgregarTanque = new System.Windows.Forms.Button();
            this.BtnGuardarVidrioAGranel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblContenedores = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNVidrio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtaTanques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DtaTanques
            // 
            this.DtaTanques.AllowUserToAddRows = false;
            this.DtaTanques.AllowUserToDeleteRows = false;
            this.DtaTanques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaTanques.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaTanques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaTanques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtaTanques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaTanques.Location = new System.Drawing.Point(280, 416);
            this.DtaTanques.Name = "DtaTanques";
            this.DtaTanques.ReadOnly = true;
            this.DtaTanques.Size = new System.Drawing.Size(190, 74);
            this.DtaTanques.TabIndex = 373;
            this.DtaTanques.TabStop = false;
            this.DtaTanques.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaTanques_CellDoubleClick);
            // 
            // TxtTanque
            // 
            this.TxtTanque.Location = new System.Drawing.Point(280, 390);
            this.TxtTanque.MaxLength = 9;
            this.TxtTanque.Name = "TxtTanque";
            this.TxtTanque.Size = new System.Drawing.Size(155, 20);
            this.TxtTanque.TabIndex = 371;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(280, 369);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 18);
            this.label18.TabIndex = 372;
            this.label18.Text = "No tanque";
            // 
            // TxtGradoAlcoholico
            // 
            this.TxtGradoAlcoholico.Location = new System.Drawing.Point(186, 422);
            this.TxtGradoAlcoholico.Name = "TxtGradoAlcoholico";
            this.TxtGradoAlcoholico.Size = new System.Drawing.Size(85, 20);
            this.TxtGradoAlcoholico.TabIndex = 370;
            this.TxtGradoAlcoholico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGradoAlcoholico_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 369;
            this.label4.Text = "Grado alcoholico :";
            // 
            // TxtNoLote
            // 
            this.TxtNoLote.Location = new System.Drawing.Point(186, 452);
            this.TxtNoLote.Name = "TxtNoLote";
            this.TxtNoLote.Size = new System.Drawing.Size(85, 20);
            this.TxtNoLote.TabIndex = 367;
            // 
            // TxtLitros
            // 
            this.TxtLitros.Location = new System.Drawing.Point(186, 393);
            this.TxtLitros.Name = "TxtLitros";
            this.TxtLitros.Size = new System.Drawing.Size(86, 20);
            this.TxtLitros.TabIndex = 366;
            this.TxtLitros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLitros_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(121, 452);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 18);
            this.label13.TabIndex = 365;
            this.label13.Text = "No lote :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(131, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 18);
            this.label10.TabIndex = 364;
            this.label10.Text = "Litros :";
            // 
            // LblEspecie
            // 
            this.LblEspecie.AutoSize = true;
            this.LblEspecie.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEspecie.Location = new System.Drawing.Point(186, 210);
            this.LblEspecie.Name = "LblEspecie";
            this.LblEspecie.Size = new System.Drawing.Size(20, 18);
            this.LblEspecie.TabIndex = 362;
            this.LblEspecie.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(121, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 361;
            this.label8.Text = "Especie :";
            // 
            // LblFq
            // 
            this.LblFq.AutoSize = true;
            this.LblFq.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFq.Location = new System.Drawing.Point(186, 265);
            this.LblFq.Name = "LblFq";
            this.LblFq.Size = new System.Drawing.Size(20, 18);
            this.LblFq.TabIndex = 360;
            this.LblFq.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(116, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 18);
            this.label7.TabIndex = 359;
            this.label7.Text = "Clave FQ :";
            // 
            // LblIngrediente
            // 
            this.LblIngrediente.AutoSize = true;
            this.LblIngrediente.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIngrediente.Location = new System.Drawing.Point(186, 236);
            this.LblIngrediente.Name = "LblIngrediente";
            this.LblIngrediente.Size = new System.Drawing.Size(20, 18);
            this.LblIngrediente.TabIndex = 358;
            this.LblIngrediente.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(95, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 18);
            this.label9.TabIndex = 357;
            this.label9.Text = "Ingrediente :";
            // 
            // LblTimevidrio
            // 
            this.LblTimevidrio.AutoSize = true;
            this.LblTimevidrio.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimevidrio.Location = new System.Drawing.Point(186, 133);
            this.LblTimevidrio.Name = "LblTimevidrio";
            this.LblTimevidrio.Size = new System.Drawing.Size(20, 18);
            this.LblTimevidrio.TabIndex = 356;
            this.LblTimevidrio.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(63, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 18);
            this.label12.TabIndex = 355;
            this.label12.Text = "Tiempo en vidrio :";
            // 
            // LblGradoAlcoholico
            // 
            this.LblGradoAlcoholico.AutoSize = true;
            this.LblGradoAlcoholico.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGradoAlcoholico.Location = new System.Drawing.Point(186, 344);
            this.LblGradoAlcoholico.Name = "LblGradoAlcoholico";
            this.LblGradoAlcoholico.Size = new System.Drawing.Size(20, 18);
            this.LblGradoAlcoholico.TabIndex = 354;
            this.LblGradoAlcoholico.Text = "...";
            // 
            // ll
            // 
            this.ll.AutoSize = true;
            this.ll.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll.Location = new System.Drawing.Point(64, 344);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(121, 18);
            this.ll.TabIndex = 353;
            this.ll.Text = "Grado alcoholico :";
            // 
            // LblLitros
            // 
            this.LblLitros.AutoSize = true;
            this.LblLitros.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLitros.Location = new System.Drawing.Point(186, 318);
            this.LblLitros.Name = "LblLitros";
            this.LblLitros.Size = new System.Drawing.Size(20, 18);
            this.LblLitros.TabIndex = 352;
            this.LblLitros.Text = "...";
            // 
            // kk
            // 
            this.kk.AutoSize = true;
            this.kk.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kk.Location = new System.Drawing.Point(134, 318);
            this.kk.Name = "kk";
            this.kk.Size = new System.Drawing.Size(51, 18);
            this.kk.TabIndex = 351;
            this.kk.Text = "Litros :";
            // 
            // LblFolio
            // 
            this.LblFolio.AutoSize = true;
            this.LblFolio.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFolio.Location = new System.Drawing.Point(186, 292);
            this.LblFolio.Name = "LblFolio";
            this.LblFolio.Size = new System.Drawing.Size(20, 18);
            this.LblFolio.TabIndex = 350;
            this.LblFolio.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 349;
            this.label6.Text = "Folio :";
            // 
            // LblCategoria
            // 
            this.LblCategoria.AutoSize = true;
            this.LblCategoria.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCategoria.Location = new System.Drawing.Point(186, 182);
            this.LblCategoria.Name = "LblCategoria";
            this.LblCategoria.Size = new System.Drawing.Size(20, 18);
            this.LblCategoria.TabIndex = 348;
            this.LblCategoria.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(109, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 347;
            this.label5.Text = "Categoria :";
            // 
            // LblClase
            // 
            this.LblClase.AutoSize = true;
            this.LblClase.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClase.Location = new System.Drawing.Point(186, 155);
            this.LblClase.Name = "LblClase";
            this.LblClase.Size = new System.Drawing.Size(20, 18);
            this.LblClase.TabIndex = 346;
            this.LblClase.Text = "...";
            // 
            // LblFechaIngreso
            // 
            this.LblFechaIngreso.AutoSize = true;
            this.LblFechaIngreso.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaIngreso.Location = new System.Drawing.Point(186, 77);
            this.LblFechaIngreso.Name = "LblFechaIngreso";
            this.LblFechaIngreso.Size = new System.Drawing.Size(20, 18);
            this.LblFechaIngreso.TabIndex = 345;
            this.LblFechaIngreso.Text = "...";
            // 
            // LblFechaSalida
            // 
            this.LblFechaSalida.AutoSize = true;
            this.LblFechaSalida.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaSalida.Location = new System.Drawing.Point(186, 107);
            this.LblFechaSalida.Name = "LblFechaSalida";
            this.LblFechaSalida.Size = new System.Drawing.Size(20, 18);
            this.LblFechaSalida.TabIndex = 344;
            this.LblFechaSalida.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 343;
            this.label3.Text = "Fecha de salida :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 342;
            this.label2.Text = "Fecha de ingreso :";
            // 
            // lblNoLote
            // 
            this.lblNoLote.AutoSize = true;
            this.lblNoLote.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoLote.Location = new System.Drawing.Point(186, 22);
            this.lblNoLote.Name = "lblNoLote";
            this.lblNoLote.Size = new System.Drawing.Size(20, 18);
            this.lblNoLote.TabIndex = 341;
            this.lblNoLote.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 340;
            this.label1.Text = "Clase :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(105, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 339;
            this.label11.Text = "No de lote :";
            // 
            // BtnAgregarTanque
            // 
            this.BtnAgregarTanque.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarTanque.BackgroundImage = global::Crm.Properties.Resources.download__2_;
            this.BtnAgregarTanque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnAgregarTanque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarTanque.FlatAppearance.BorderSize = 0;
            this.BtnAgregarTanque.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarTanque.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarTanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarTanque.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarTanque.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarTanque.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregarTanque.Location = new System.Drawing.Point(437, 380);
            this.BtnAgregarTanque.Name = "BtnAgregarTanque";
            this.BtnAgregarTanque.Size = new System.Drawing.Size(33, 36);
            this.BtnAgregarTanque.TabIndex = 374;
            this.BtnAgregarTanque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarTanque.UseVisualStyleBackColor = false;
            this.BtnAgregarTanque.Click += new System.EventHandler(this.BtnAgregarTanque_Click);
            // 
            // BtnGuardarVidrioAGranel
            // 
            this.BtnGuardarVidrioAGranel.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardarVidrioAGranel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardarVidrioAGranel.FlatAppearance.BorderSize = 0;
            this.BtnGuardarVidrioAGranel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardarVidrioAGranel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardarVidrioAGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarVidrioAGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarVidrioAGranel.ForeColor = System.Drawing.Color.Transparent;
            this.BtnGuardarVidrioAGranel.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardarVidrioAGranel.Location = new System.Drawing.Point(249, 520);
            this.BtnGuardarVidrioAGranel.Name = "BtnGuardarVidrioAGranel";
            this.BtnGuardarVidrioAGranel.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardarVidrioAGranel.TabIndex = 368;
            this.BtnGuardarVidrioAGranel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardarVidrioAGranel.UseVisualStyleBackColor = false;
            this.BtnGuardarVidrioAGranel.Click += new System.EventHandler(this.BtnGuardarVidrioAGranel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Crm.Properties.Resources.bottle__1_1;
            this.pictureBox1.Location = new System.Drawing.Point(366, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 131);
            this.pictureBox1.TabIndex = 363;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LblContenedores
            // 
            this.LblContenedores.AutoSize = true;
            this.LblContenedores.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblContenedores.Location = new System.Drawing.Point(186, 49);
            this.LblContenedores.Name = "LblContenedores";
            this.LblContenedores.Size = new System.Drawing.Size(20, 18);
            this.LblContenedores.TabIndex = 376;
            this.LblContenedores.Text = "...";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(61, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 18);
            this.label15.TabIndex = 375;
            this.label15.Text = "No contenedores :";
            // 
            // txtNVidrio
            // 
            this.txtNVidrio.Location = new System.Drawing.Point(186, 482);
            this.txtNVidrio.MaxLength = 9;
            this.txtNVidrio.Name = "txtNVidrio";
            this.txtNVidrio.Size = new System.Drawing.Size(85, 20);
            this.txtNVidrio.TabIndex = 377;
            this.txtNVidrio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNVidrio_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 482);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(183, 18);
            this.label14.TabIndex = 378;
            this.label14.Text = "No contenedores a liberar : ";
            // 
            // FrmMovimientosVidrio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 571);
            this.Controls.Add(this.txtNVidrio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.LblContenedores);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.BtnAgregarTanque);
            this.Controls.Add(this.DtaTanques);
            this.Controls.Add(this.TxtTanque);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.TxtGradoAlcoholico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnGuardarVidrioAGranel);
            this.Controls.Add(this.TxtNoLote);
            this.Controls.Add(this.TxtLitros);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblEspecie);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblFq);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblIngrediente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LblTimevidrio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.LblGradoAlcoholico);
            this.Controls.Add(this.ll);
            this.Controls.Add(this.LblLitros);
            this.Controls.Add(this.kk);
            this.Controls.Add(this.LblFolio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblCategoria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblClase);
            this.Controls.Add(this.LblFechaIngreso);
            this.Controls.Add(this.LblFechaSalida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNoLote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMovimientosVidrio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos Vidrio";
            this.Load += new System.EventHandler(this.FrmMovimientosVidrio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaTanques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAgregarTanque;
        private System.Windows.Forms.DataGridView DtaTanques;
        private System.Windows.Forms.TextBox TxtTanque;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtGradoAlcoholico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnGuardarVidrioAGranel;
        private System.Windows.Forms.TextBox TxtNoLote;
        private System.Windows.Forms.TextBox TxtLitros;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblEspecie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblFq;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblIngrediente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblTimevidrio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LblGradoAlcoholico;
        private System.Windows.Forms.Label ll;
        private System.Windows.Forms.Label LblLitros;
        private System.Windows.Forms.Label kk;
        private System.Windows.Forms.Label LblFolio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblCategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblClase;
        private System.Windows.Forms.Label LblFechaIngreso;
        private System.Windows.Forms.Label LblFechaSalida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoLote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblContenedores;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNVidrio;
        private System.Windows.Forms.Label label14;
    }
}