namespace Crm.Inventario
{
    partial class FrmNuevoEnvasado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtaMagueyGuardar = new System.Windows.Forms.DataGridView();
            this.CmbMaguey = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNoBotellas = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.CmbUnidadDeMedida = new System.Windows.Forms.ComboBox();
            this.CmbMarca = new System.Windows.Forms.ComboBox();
            this.CmbMedidaBotella = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.TxtClaveFqEnvasado = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.TxtNoLoteEnvasado = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnAgregarMaguey = new System.Windows.Forms.Button();
            this.BtnAgregarLoteGranel = new System.Windows.Forms.Button();
            this.DtaLoteGranelGuardar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtLoteGranel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbltituloIngrediente = new System.Windows.Forms.Label();
            this.CmbCategoria = new System.Windows.Forms.ComboBox();
            this.CmbClase = new System.Windows.Forms.ComboBox();
            this.TxtGradoAlcoholico = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtResponsableEnvasadora = new System.Windows.Forms.TextBox();
            this.CmbEnvasadora = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.BtnInformacionHolograma = new System.Windows.Forms.Button();
            this.TxtSerie = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.BtnAgragarHolograma = new System.Windows.Forms.Button();
            this.DtaHologramas = new System.Windows.Forms.DataGridView();
            this.label36 = new System.Windows.Forms.Label();
            this.TxtHologramaFin = new System.Windows.Forms.TextBox();
            this.TxtHologramaInicio = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.DtaFechaEnvasadofin = new System.Windows.Forms.DateTimePicker();
            this.DtaFechaEnvasadoini = new System.Windows.Forms.DateTimePicker();
            this.label62 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.TxtGradoAlcoholicoEtiqueta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIngredienteEnvasado = new System.Windows.Forms.TextBox();
            this.cmbEtiquetadocomo = new System.Windows.Forms.ComboBox();
            this.lblEtiquetadocomo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbLoteAnterior = new System.Windows.Forms.RadioButton();
            this.RdBtnLN = new System.Windows.Forms.RadioButton();
            this.rdBtnSF = new System.Windows.Forms.RadioButton();
            this.rdBtnRP = new System.Windows.Forms.RadioButton();
            this.chkHologramasAnteriores = new System.Windows.Forms.CheckBox();
            this.TxtMensajeBotellas = new iTalk_ChatBubble_L();
            this.ChekOstenta = new iTalk_Toggle();
            this.chkEnvasadoIndefinido = new System.Windows.Forms.CheckBox();
            this.chkEnvasadoExportacion = new System.Windows.Forms.CheckBox();
            this.chkEnvasadoNacional = new System.Windows.Forms.CheckBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DtaMagueyGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaLoteGranelGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaHologramas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtaMagueyGuardar
            // 
            this.DtaMagueyGuardar.AllowUserToAddRows = false;
            this.DtaMagueyGuardar.AllowUserToDeleteRows = false;
            this.DtaMagueyGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaMagueyGuardar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaMagueyGuardar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaMagueyGuardar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaMagueyGuardar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtaMagueyGuardar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtaMagueyGuardar.DefaultCellStyle = dataGridViewCellStyle2;
            this.DtaMagueyGuardar.EnableHeadersVisualStyles = false;
            this.DtaMagueyGuardar.Location = new System.Drawing.Point(147, 86);
            this.DtaMagueyGuardar.Name = "DtaMagueyGuardar";
            this.DtaMagueyGuardar.ReadOnly = true;
            this.DtaMagueyGuardar.Size = new System.Drawing.Size(216, 63);
            this.DtaMagueyGuardar.TabIndex = 5;
            this.DtaMagueyGuardar.TabStop = false;
            this.DtaMagueyGuardar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaMagueyGuardar_CellDoubleClick);
            // 
            // CmbMaguey
            // 
            this.CmbMaguey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbMaguey.DropDownHeight = 300;
            this.CmbMaguey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaguey.DropDownWidth = 400;
            this.CmbMaguey.FormattingEnabled = true;
            this.CmbMaguey.IntegralHeight = false;
            this.CmbMaguey.Location = new System.Drawing.Point(147, 57);
            this.CmbMaguey.Name = "CmbMaguey";
            this.CmbMaguey.Size = new System.Drawing.Size(190, 21);
            this.CmbMaguey.TabIndex = 3;
            this.CmbMaguey.SelectedIndexChanged += new System.EventHandler(this.CmbMaguey_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 328;
            this.label3.Text = "Maguey :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TxtNoBotellas
            // 
            this.TxtNoBotellas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoBotellas.Location = new System.Drawing.Point(521, 58);
            this.TxtNoBotellas.MaxLength = 11;
            this.TxtNoBotellas.Name = "TxtNoBotellas";
            this.TxtNoBotellas.Size = new System.Drawing.Size(216, 20);
            this.TxtNoBotellas.TabIndex = 14;
            this.TxtNoBotellas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoBotellas_KeyPress);
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(379, 58);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(139, 18);
            this.label35.TabIndex = 358;
            this.label35.Text = "Numero de botellas :";
            // 
            // CmbUnidadDeMedida
            // 
            this.CmbUnidadDeMedida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbUnidadDeMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnidadDeMedida.FormattingEnabled = true;
            this.CmbUnidadDeMedida.Location = new System.Drawing.Point(147, 339);
            this.CmbUnidadDeMedida.Name = "CmbUnidadDeMedida";
            this.CmbUnidadDeMedida.Size = new System.Drawing.Size(86, 21);
            this.CmbUnidadDeMedida.TabIndex = 12;
            this.CmbUnidadDeMedida.SelectedIndexChanged += new System.EventHandler(this.CmbUnidadDeMedida_SelectedIndexChanged);
            // 
            // CmbMarca
            // 
            this.CmbMarca.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMarca.FormattingEnabled = true;
            this.CmbMarca.Location = new System.Drawing.Point(147, 261);
            this.CmbMarca.Name = "CmbMarca";
            this.CmbMarca.Size = new System.Drawing.Size(216, 21);
            this.CmbMarca.TabIndex = 9;
            // 
            // CmbMedidaBotella
            // 
            this.CmbMedidaBotella.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbMedidaBotella.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMedidaBotella.FormattingEnabled = true;
            this.CmbMedidaBotella.Location = new System.Drawing.Point(285, 340);
            this.CmbMedidaBotella.Name = "CmbMedidaBotella";
            this.CmbMedidaBotella.Size = new System.Drawing.Size(78, 21);
            this.CmbMedidaBotella.TabIndex = 13;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(16, 339);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(129, 18);
            this.label25.TabIndex = 354;
            this.label25.Text = "Unidad de medida :";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(235, 340);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 18);
            this.label29.TabIndex = 353;
            this.label29.Text = "Cont :";
            this.label29.Click += new System.EventHandler(this.label29_Click);
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(90, 260);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 18);
            this.label27.TabIndex = 352;
            this.label27.Text = "Marca :";
            // 
            // TxtClaveFqEnvasado
            // 
            this.TxtClaveFqEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtClaveFqEnvasado.Location = new System.Drawing.Point(147, 314);
            this.TxtClaveFqEnvasado.MaxLength = 100;
            this.TxtClaveFqEnvasado.Name = "TxtClaveFqEnvasado";
            this.TxtClaveFqEnvasado.Size = new System.Drawing.Size(216, 20);
            this.TxtClaveFqEnvasado.TabIndex = 11;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(76, 315);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 18);
            this.label28.TabIndex = 351;
            this.label28.Text = "Clave FQ :";
            // 
            // TxtNoLoteEnvasado
            // 
            this.TxtNoLoteEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoLoteEnvasado.Location = new System.Drawing.Point(147, 289);
            this.TxtNoLoteEnvasado.MaxLength = 100;
            this.TxtNoLoteEnvasado.Name = "TxtNoLoteEnvasado";
            this.TxtNoLoteEnvasado.Size = new System.Drawing.Size(216, 20);
            this.TxtNoLoteEnvasado.TabIndex = 10;
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(84, 290);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(61, 18);
            this.label32.TabIndex = 349;
            this.label32.Text = "No lote :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Crm.Properties.Resources.stock__1_;
            this.pictureBox1.Location = new System.Drawing.Point(772, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 131);
            this.pictureBox1.TabIndex = 362;
            this.pictureBox1.TabStop = false;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(434, 414);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 28;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnAgregarMaguey
            // 
            this.BtnAgregarMaguey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAgregarMaguey.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarMaguey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarMaguey.FlatAppearance.BorderSize = 0;
            this.BtnAgregarMaguey.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarMaguey.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarMaguey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarMaguey.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarMaguey.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarMaguey.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnAgregarMaguey.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregarMaguey.Location = new System.Drawing.Point(338, 46);
            this.BtnAgregarMaguey.Name = "BtnAgregarMaguey";
            this.BtnAgregarMaguey.Size = new System.Drawing.Size(25, 33);
            this.BtnAgregarMaguey.TabIndex = 4;
            this.BtnAgregarMaguey.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarMaguey.UseVisualStyleBackColor = false;
            this.BtnAgregarMaguey.Click += new System.EventHandler(this.BtnAgregarMaguey_Click);
            // 
            // BtnAgregarLoteGranel
            // 
            this.BtnAgregarLoteGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAgregarLoteGranel.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarLoteGranel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarLoteGranel.FlatAppearance.BorderSize = 0;
            this.BtnAgregarLoteGranel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarLoteGranel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarLoteGranel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarLoteGranel.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarLoteGranel.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarLoteGranel.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnAgregarLoteGranel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAgregarLoteGranel.Location = new System.Drawing.Point(338, 151);
            this.BtnAgregarLoteGranel.Name = "BtnAgregarLoteGranel";
            this.BtnAgregarLoteGranel.Size = new System.Drawing.Size(25, 32);
            this.BtnAgregarLoteGranel.TabIndex = 7;
            this.BtnAgregarLoteGranel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarLoteGranel.UseVisualStyleBackColor = false;
            this.BtnAgregarLoteGranel.Click += new System.EventHandler(this.BtnAgregarLoteGranel_Click);
            // 
            // DtaLoteGranelGuardar
            // 
            this.DtaLoteGranelGuardar.AllowUserToAddRows = false;
            this.DtaLoteGranelGuardar.AllowUserToDeleteRows = false;
            this.DtaLoteGranelGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaLoteGranelGuardar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaLoteGranelGuardar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaLoteGranelGuardar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaLoteGranelGuardar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DtaLoteGranelGuardar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaLoteGranelGuardar.EnableHeadersVisualStyles = false;
            this.DtaLoteGranelGuardar.Location = new System.Drawing.Point(147, 190);
            this.DtaLoteGranelGuardar.Name = "DtaLoteGranelGuardar";
            this.DtaLoteGranelGuardar.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaLoteGranelGuardar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DtaLoteGranelGuardar.Size = new System.Drawing.Size(216, 63);
            this.DtaLoteGranelGuardar.TabIndex = 8;
            this.DtaLoteGranelGuardar.TabStop = false;
            this.DtaLoteGranelGuardar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaLoteGranelGuardar_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 364;
            this.label1.Text = "Lote granel :";
            // 
            // TxtLoteGranel
            // 
            this.TxtLoteGranel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtLoteGranel.Location = new System.Drawing.Point(147, 164);
            this.TxtLoteGranel.MaxLength = 100;
            this.TxtLoteGranel.Name = "TxtLoteGranel";
            this.TxtLoteGranel.Size = new System.Drawing.Size(190, 20);
            this.TxtLoteGranel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(467, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 371;
            this.label4.Text = "Clase :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(439, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 369;
            this.label5.Text = "Categoria :";
            // 
            // lbltituloIngrediente
            // 
            this.lbltituloIngrediente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbltituloIngrediente.AutoSize = true;
            this.lbltituloIngrediente.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltituloIngrediente.Location = new System.Drawing.Point(429, 213);
            this.lbltituloIngrediente.Name = "lbltituloIngrediente";
            this.lbltituloIngrediente.Size = new System.Drawing.Size(90, 18);
            this.lbltituloIngrediente.TabIndex = 375;
            this.lbltituloIngrediente.Text = "Ingrediente :";
            // 
            // CmbCategoria
            // 
            this.CmbCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategoria.FormattingEnabled = true;
            this.CmbCategoria.Location = new System.Drawing.Point(521, 161);
            this.CmbCategoria.Name = "CmbCategoria";
            this.CmbCategoria.Size = new System.Drawing.Size(216, 21);
            this.CmbCategoria.TabIndex = 18;
            // 
            // CmbClase
            // 
            this.CmbClase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClase.FormattingEnabled = true;
            this.CmbClase.Location = new System.Drawing.Point(521, 188);
            this.CmbClase.Name = "CmbClase";
            this.CmbClase.Size = new System.Drawing.Size(216, 21);
            this.CmbClase.TabIndex = 19;
            this.CmbClase.SelectedIndexChanged += new System.EventHandler(this.CmbClase_SelectedIndexChanged);
            // 
            // TxtGradoAlcoholico
            // 
            this.TxtGradoAlcoholico.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtGradoAlcoholico.Location = new System.Drawing.Point(521, 84);
            this.TxtGradoAlcoholico.MaxLength = 11;
            this.TxtGradoAlcoholico.Name = "TxtGradoAlcoholico";
            this.TxtGradoAlcoholico.Size = new System.Drawing.Size(216, 20);
            this.TxtGradoAlcoholico.TabIndex = 15;
            this.TxtGradoAlcoholico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGradoAlcoholico_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(394, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 18);
            this.label7.TabIndex = 382;
            this.label7.Text = "Grado alcohólico :";
            // 
            // TxtResponsableEnvasadora
            // 
            this.TxtResponsableEnvasadora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtResponsableEnvasadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtResponsableEnvasadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtResponsableEnvasadora.Location = new System.Drawing.Point(521, 137);
            this.TxtResponsableEnvasadora.MaxLength = 9;
            this.TxtResponsableEnvasadora.Name = "TxtResponsableEnvasadora";
            this.TxtResponsableEnvasadora.ReadOnly = true;
            this.TxtResponsableEnvasadora.Size = new System.Drawing.Size(216, 20);
            this.TxtResponsableEnvasadora.TabIndex = 17;
            // 
            // CmbEnvasadora
            // 
            this.CmbEnvasadora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbEnvasadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEnvasadora.FormattingEnabled = true;
            this.CmbEnvasadora.Location = new System.Drawing.Point(521, 110);
            this.CmbEnvasadora.Name = "CmbEnvasadora";
            this.CmbEnvasadora.Size = new System.Drawing.Size(216, 21);
            this.CmbEnvasadora.TabIndex = 16;
            this.CmbEnvasadora.SelectedIndexChanged += new System.EventHandler(this.CmbEnvasadora_SelectedIndexChanged);
            // 
            // label56
            // 
            this.label56.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(431, 113);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(87, 18);
            this.label56.TabIndex = 390;
            this.label56.Text = "Envasadora :";
            // 
            // label57
            // 
            this.label57.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(422, 139);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(95, 18);
            this.label57.TabIndex = 388;
            this.label57.Text = "Responsable :";
            // 
            // BtnInformacionHolograma
            // 
            this.BtnInformacionHolograma.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnInformacionHolograma.BackColor = System.Drawing.Color.Transparent;
            this.BtnInformacionHolograma.FlatAppearance.BorderSize = 0;
            this.BtnInformacionHolograma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInformacionHolograma.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInformacionHolograma.ForeColor = System.Drawing.Color.White;
            this.BtnInformacionHolograma.Image = global::Crm.Properties.Resources.info__1_;
            this.BtnInformacionHolograma.Location = new System.Drawing.Point(746, 364);
            this.BtnInformacionHolograma.Name = "BtnInformacionHolograma";
            this.BtnInformacionHolograma.Size = new System.Drawing.Size(28, 25);
            this.BtnInformacionHolograma.TabIndex = 26;
            this.BtnInformacionHolograma.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnInformacionHolograma.UseVisualStyleBackColor = false;
            this.BtnInformacionHolograma.MouseEnter += new System.EventHandler(this.BtnInformacionHolograma_MouseEnter);
            this.BtnInformacionHolograma.MouseLeave += new System.EventHandler(this.BtnInformacionHolograma_MouseLeave);
            // 
            // TxtSerie
            // 
            this.TxtSerie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtSerie.Location = new System.Drawing.Point(798, 302);
            this.TxtSerie.MaxLength = 1;
            this.TxtSerie.Name = "TxtSerie";
            this.TxtSerie.Size = new System.Drawing.Size(27, 20);
            this.TxtSerie.TabIndex = 24;
            this.TxtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSerie_KeyPress);
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(743, 303);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(49, 18);
            this.label69.TabIndex = 439;
            this.label69.Text = "Serie :";
            // 
            // BtnAgragarHolograma
            // 
            this.BtnAgragarHolograma.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAgragarHolograma.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgragarHolograma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgragarHolograma.FlatAppearance.BorderSize = 0;
            this.BtnAgragarHolograma.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgragarHolograma.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgragarHolograma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgragarHolograma.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgragarHolograma.ForeColor = System.Drawing.Color.White;
            this.BtnAgragarHolograma.Image = global::Crm.Properties.Resources.import__3_;
            this.BtnAgragarHolograma.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgragarHolograma.Location = new System.Drawing.Point(746, 331);
            this.BtnAgragarHolograma.Name = "BtnAgragarHolograma";
            this.BtnAgragarHolograma.Size = new System.Drawing.Size(26, 28);
            this.BtnAgragarHolograma.TabIndex = 25;
            this.BtnAgragarHolograma.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgragarHolograma.UseVisualStyleBackColor = false;
            this.BtnAgragarHolograma.Click += new System.EventHandler(this.BtnAgragarHolograma_Click);
            // 
            // DtaHologramas
            // 
            this.DtaHologramas.AllowUserToAddRows = false;
            this.DtaHologramas.AllowUserToDeleteRows = false;
            this.DtaHologramas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaHologramas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaHologramas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaHologramas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaHologramas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DtaHologramas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaHologramas.EnableHeadersVisualStyles = false;
            this.DtaHologramas.Location = new System.Drawing.Point(521, 326);
            this.DtaHologramas.Name = "DtaHologramas";
            this.DtaHologramas.ReadOnly = true;
            this.DtaHologramas.Size = new System.Drawing.Size(214, 67);
            this.DtaHologramas.TabIndex = 27;
            this.DtaHologramas.TabStop = false;
            this.DtaHologramas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaHologramas_CellDoubleClick);
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(614, 300);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(28, 18);
            this.label36.TabIndex = 446;
            this.label36.Text = "<->";
            // 
            // TxtHologramaFin
            // 
            this.TxtHologramaFin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtHologramaFin.Location = new System.Drawing.Point(648, 300);
            this.TxtHologramaFin.MaxLength = 7;
            this.TxtHologramaFin.Name = "TxtHologramaFin";
            this.TxtHologramaFin.Size = new System.Drawing.Size(87, 20);
            this.TxtHologramaFin.TabIndex = 23;
            this.TxtHologramaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtHologramaFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHologramaFin_KeyPress);
            // 
            // TxtHologramaInicio
            // 
            this.TxtHologramaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtHologramaInicio.Location = new System.Drawing.Point(519, 300);
            this.TxtHologramaInicio.MaxLength = 7;
            this.TxtHologramaInicio.Name = "TxtHologramaInicio";
            this.TxtHologramaInicio.Size = new System.Drawing.Size(89, 20);
            this.TxtHologramaInicio.TabIndex = 22;
            this.TxtHologramaInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtHologramaInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHologramaInicio_KeyPress);
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(425, 300);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(91, 18);
            this.label37.TabIndex = 445;
            this.label37.Text = "Hologramas :";
            // 
            // label66
            // 
            this.label66.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(422, 29);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(28, 18);
            this.label66.TabIndex = 448;
            this.label66.Text = "<->";
            // 
            // DtaFechaEnvasadofin
            // 
            this.DtaFechaEnvasadofin.Location = new System.Drawing.Point(455, 26);
            this.DtaFechaEnvasadofin.Name = "DtaFechaEnvasadofin";
            this.DtaFechaEnvasadofin.Size = new System.Drawing.Size(207, 20);
            this.DtaFechaEnvasadofin.TabIndex = 2;
            // 
            // DtaFechaEnvasadoini
            // 
            this.DtaFechaEnvasadoini.Location = new System.Drawing.Point(209, 26);
            this.DtaFechaEnvasadoini.Name = "DtaFechaEnvasadoini";
            this.DtaFechaEnvasadoini.Size = new System.Drawing.Size(207, 20);
            this.DtaFechaEnvasadoini.TabIndex = 1;
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(95, 28);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(111, 18);
            this.label62.TabIndex = 447;
            this.label62.Text = "Fecha Envasado:";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(748, 279);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(44, 13);
            this.label70.TabIndex = 450;
            this.label70.Text = "Ostenta";
            // 
            // TxtGradoAlcoholicoEtiqueta
            // 
            this.TxtGradoAlcoholicoEtiqueta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtGradoAlcoholicoEtiqueta.Location = new System.Drawing.Point(147, 367);
            this.TxtGradoAlcoholicoEtiqueta.MaxLength = 5;
            this.TxtGradoAlcoholicoEtiqueta.Name = "TxtGradoAlcoholicoEtiqueta";
            this.TxtGradoAlcoholicoEtiqueta.Size = new System.Drawing.Size(216, 20);
            this.TxtGradoAlcoholicoEtiqueta.TabIndex = 14;
            this.TxtGradoAlcoholicoEtiqueta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGradoAlcoholicoEtiqueta_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 452;
            this.label2.Text = "°Alcohólico etiq :";
            // 
            // TxtIngredienteEnvasado
            // 
            this.TxtIngredienteEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtIngredienteEnvasado.Enabled = false;
            this.TxtIngredienteEnvasado.Location = new System.Drawing.Point(519, 214);
            this.TxtIngredienteEnvasado.MaxLength = 70;
            this.TxtIngredienteEnvasado.Multiline = true;
            this.TxtIngredienteEnvasado.Name = "TxtIngredienteEnvasado";
            this.TxtIngredienteEnvasado.Size = new System.Drawing.Size(218, 49);
            this.TxtIngredienteEnvasado.TabIndex = 454;
            // 
            // cmbEtiquetadocomo
            // 
            this.cmbEtiquetadocomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbEtiquetadocomo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEtiquetadocomo.DropDownWidth = 400;
            this.cmbEtiquetadocomo.FormattingEnabled = true;
            this.cmbEtiquetadocomo.Location = new System.Drawing.Point(521, 269);
            this.cmbEtiquetadocomo.Name = "cmbEtiquetadocomo";
            this.cmbEtiquetadocomo.Size = new System.Drawing.Size(214, 21);
            this.cmbEtiquetadocomo.TabIndex = 456;
            // 
            // lblEtiquetadocomo
            // 
            this.lblEtiquetadocomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEtiquetadocomo.AutoSize = true;
            this.lblEtiquetadocomo.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetadocomo.Location = new System.Drawing.Point(388, 270);
            this.lblEtiquetadocomo.Name = "lblEtiquetadocomo";
            this.lblEtiquetadocomo.Size = new System.Drawing.Size(122, 18);
            this.lblEtiquetadocomo.TabIndex = 455;
            this.lblEtiquetadocomo.Text = "Etiquetado como :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.rdbLoteAnterior);
            this.groupBox1.Controls.Add(this.RdBtnLN);
            this.groupBox1.Controls.Add(this.rdBtnSF);
            this.groupBox1.Controls.Add(this.rdBtnRP);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(772, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 127);
            this.groupBox1.TabIndex = 506;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Lote :";
            // 
            // rdbLoteAnterior
            // 
            this.rdbLoteAnterior.AutoSize = true;
            this.rdbLoteAnterior.Font = new System.Drawing.Font("Candara", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLoteAnterior.ForeColor = System.Drawing.Color.Maroon;
            this.rdbLoteAnterior.Location = new System.Drawing.Point(6, 97);
            this.rdbLoteAnterior.Name = "rdbLoteAnterior";
            this.rdbLoteAnterior.Size = new System.Drawing.Size(100, 19);
            this.rdbLoteAnterior.TabIndex = 300;
            this.rdbLoteAnterior.TabStop = true;
            this.rdbLoteAnterior.Text = "Lote Anterior";
            this.rdbLoteAnterior.UseVisualStyleBackColor = true;
            this.rdbLoteAnterior.Visible = false;
            // 
            // RdBtnLN
            // 
            this.RdBtnLN.AutoSize = true;
            this.RdBtnLN.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdBtnLN.Location = new System.Drawing.Point(6, 74);
            this.RdBtnLN.Name = "RdBtnLN";
            this.RdBtnLN.Size = new System.Drawing.Size(94, 19);
            this.RdBtnLN.TabIndex = 299;
            this.RdBtnLN.TabStop = true;
            this.RdBtnLN.Text = "Lote Normal";
            this.RdBtnLN.UseVisualStyleBackColor = true;
            // 
            // rdBtnSF
            // 
            this.rdBtnSF.AutoSize = true;
            this.rdBtnSF.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnSF.Location = new System.Drawing.Point(5, 51);
            this.rdBtnSF.Name = "rdBtnSF";
            this.rdBtnSF.Size = new System.Drawing.Size(100, 19);
            this.rdBtnSF.TabIndex = 298;
            this.rdBtnSF.TabStop = true;
            this.rdBtnSF.Text = "Saldo a  Favor";
            this.rdBtnSF.UseVisualStyleBackColor = true;
            // 
            // rdBtnRP
            // 
            this.rdBtnRP.AutoSize = true;
            this.rdBtnRP.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnRP.Location = new System.Drawing.Point(5, 29);
            this.rdBtnRP.Name = "rdBtnRP";
            this.rdBtnRP.Size = new System.Drawing.Size(40, 19);
            this.rdBtnRP.TabIndex = 297;
            this.rdBtnRP.TabStop = true;
            this.rdBtnRP.Text = "RP";
            this.rdBtnRP.UseVisualStyleBackColor = true;
            // 
            // chkHologramasAnteriores
            // 
            this.chkHologramasAnteriores.AutoSize = true;
            this.chkHologramasAnteriores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHologramasAnteriores.ForeColor = System.Drawing.Color.LimeGreen;
            this.chkHologramasAnteriores.Location = new System.Drawing.Point(426, 331);
            this.chkHologramasAnteriores.Name = "chkHologramasAnteriores";
            this.chkHologramasAnteriores.Size = new System.Drawing.Size(92, 30);
            this.chkHologramasAnteriores.TabIndex = 507;
            this.chkHologramasAnteriores.Text = "Hologramas\r\nanteriores";
            this.chkHologramasAnteriores.UseVisualStyleBackColor = true;
            this.chkHologramasAnteriores.Visible = false;
            // 
            // TxtMensajeBotellas
            // 
            this.TxtMensajeBotellas.BackColor = System.Drawing.Color.Transparent;
            this.TxtMensajeBotellas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TxtMensajeBotellas.BubbleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(206)))), ((int)(((byte)(215)))));
            this.TxtMensajeBotellas.DrawBubbleArrow = true;
            this.TxtMensajeBotellas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMensajeBotellas.Location = new System.Drawing.Point(727, 326);
            this.TxtMensajeBotellas.Name = "TxtMensajeBotellas";
            this.TxtMensajeBotellas.Size = new System.Drawing.Size(112, 57);
            this.TxtMensajeBotellas.TabIndex = 442;
            this.TxtMensajeBotellas.Visible = false;
            // 
            // ChekOstenta
            // 
            this.ChekOstenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChekOstenta.Location = new System.Drawing.Point(798, 274);
            this.ChekOstenta.Name = "ChekOstenta";
            this.ChekOstenta.Size = new System.Drawing.Size(41, 23);
            this.ChekOstenta.TabIndex = 449;
            this.ChekOstenta.Text = "iTalk_Toggle1";
            this.ChekOstenta.Toggled = false;
            this.ChekOstenta.Type = iTalk_Toggle._Type.YesNo;
            this.ChekOstenta.ToggledChanged += new iTalk_Toggle.ToggledChangedEventHandler(this.ChekOstenta_ToggledChanged);
            // 
            // chkEnvasadoIndefinido
            // 
            this.chkEnvasadoIndefinido.AutoSize = true;
            this.chkEnvasadoIndefinido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnvasadoIndefinido.Location = new System.Drawing.Point(147, 414);
            this.chkEnvasadoIndefinido.Name = "chkEnvasadoIndefinido";
            this.chkEnvasadoIndefinido.Size = new System.Drawing.Size(48, 17);
            this.chkEnvasadoIndefinido.TabIndex = 508;
            this.chkEnvasadoIndefinido.Text = "IND";
            this.chkEnvasadoIndefinido.UseVisualStyleBackColor = true;
            // 
            // chkEnvasadoExportacion
            // 
            this.chkEnvasadoExportacion.AutoSize = true;
            this.chkEnvasadoExportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnvasadoExportacion.Location = new System.Drawing.Point(201, 414);
            this.chkEnvasadoExportacion.Name = "chkEnvasadoExportacion";
            this.chkEnvasadoExportacion.Size = new System.Drawing.Size(50, 17);
            this.chkEnvasadoExportacion.TabIndex = 509;
            this.chkEnvasadoExportacion.Text = "EXP";
            this.chkEnvasadoExportacion.UseVisualStyleBackColor = true;
            // 
            // chkEnvasadoNacional
            // 
            this.chkEnvasadoNacional.AutoSize = true;
            this.chkEnvasadoNacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnvasadoNacional.Location = new System.Drawing.Point(255, 414);
            this.chkEnvasadoNacional.Name = "chkEnvasadoNacional";
            this.chkEnvasadoNacional.Size = new System.Drawing.Size(51, 17);
            this.chkEnvasadoNacional.TabIndex = 510;
            this.chkEnvasadoNacional.Text = "NAC";
            this.chkEnvasadoNacional.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(171, 392);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(130, 19);
            this.materialLabel1.TabIndex = 511;
            this.materialLabel1.Text = "DESTINO PREVIO:";
            // 
            // FrmNuevoEnvasado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 469);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.chkEnvasadoNacional);
            this.Controls.Add(this.chkEnvasadoExportacion);
            this.Controls.Add(this.chkEnvasadoIndefinido);
            this.Controls.Add(this.chkHologramasAnteriores);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbEtiquetadocomo);
            this.Controls.Add(this.lblEtiquetadocomo);
            this.Controls.Add(this.TxtIngredienteEnvasado);
            this.Controls.Add(this.TxtGradoAlcoholicoEtiqueta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.ChekOstenta);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.DtaFechaEnvasadofin);
            this.Controls.Add(this.DtaFechaEnvasadoini);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.TxtHologramaFin);
            this.Controls.Add(this.TxtHologramaInicio);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.BtnInformacionHolograma);
            this.Controls.Add(this.TxtSerie);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.BtnAgragarHolograma);
            this.Controls.Add(this.DtaHologramas);
            this.Controls.Add(this.TxtResponsableEnvasadora);
            this.Controls.Add(this.CmbEnvasadora);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.TxtGradoAlcoholico);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbClase);
            this.Controls.Add(this.CmbCategoria);
            this.Controls.Add(this.lbltituloIngrediente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtLoteGranel);
            this.Controls.Add(this.BtnAgregarLoteGranel);
            this.Controls.Add(this.DtaLoteGranelGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtNoBotellas);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.CmbUnidadDeMedida);
            this.Controls.Add(this.CmbMarca);
            this.Controls.Add(this.CmbMedidaBotella);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.TxtClaveFqEnvasado);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.TxtNoLoteEnvasado);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnAgregarMaguey);
            this.Controls.Add(this.DtaMagueyGuardar);
            this.Controls.Add(this.CmbMaguey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMensajeBotellas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNuevoEnvasado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo envasado";
            this.Load += new System.EventHandler(this.FrmNuevoEnvasado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaMagueyGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaLoteGranelGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtaHologramas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnAgregarMaguey;
        private System.Windows.Forms.DataGridView DtaMagueyGuardar;
        private System.Windows.Forms.ComboBox CmbMaguey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNoBotellas;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox CmbUnidadDeMedida;
        private System.Windows.Forms.ComboBox CmbMarca;
        private System.Windows.Forms.ComboBox CmbMedidaBotella;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox TxtClaveFqEnvasado;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox TxtNoLoteEnvasado;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnAgregarLoteGranel;
        private System.Windows.Forms.DataGridView DtaLoteGranelGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtLoteGranel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbltituloIngrediente;
        private System.Windows.Forms.ComboBox CmbCategoria;
        private System.Windows.Forms.ComboBox CmbClase;
        private System.Windows.Forms.TextBox TxtGradoAlcoholico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtResponsableEnvasadora;
        private System.Windows.Forms.ComboBox CmbEnvasadora;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button BtnInformacionHolograma;
        private System.Windows.Forms.TextBox TxtSerie;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button BtnAgragarHolograma;
        private System.Windows.Forms.DataGridView DtaHologramas;
        private iTalk_ChatBubble_L TxtMensajeBotellas;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox TxtHologramaFin;
        private System.Windows.Forms.TextBox TxtHologramaInicio;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.DateTimePicker DtaFechaEnvasadofin;
        private System.Windows.Forms.DateTimePicker DtaFechaEnvasadoini;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label70;
        private iTalk_Toggle ChekOstenta;
        private System.Windows.Forms.TextBox TxtGradoAlcoholicoEtiqueta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtIngredienteEnvasado;
        private System.Windows.Forms.ComboBox cmbEtiquetadocomo;
        private System.Windows.Forms.Label lblEtiquetadocomo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdBtnLN;
        private System.Windows.Forms.RadioButton rdBtnSF;
        private System.Windows.Forms.RadioButton rdBtnRP;
        private System.Windows.Forms.RadioButton rdbLoteAnterior;
        private System.Windows.Forms.CheckBox chkHologramasAnteriores;
        private System.Windows.Forms.CheckBox chkEnvasadoIndefinido;
        private System.Windows.Forms.CheckBox chkEnvasadoExportacion;
        private System.Windows.Forms.CheckBox chkEnvasadoNacional;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}