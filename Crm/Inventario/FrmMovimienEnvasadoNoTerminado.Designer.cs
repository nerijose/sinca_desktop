namespace Crm.Inventario
{
    partial class FrmMovimienEnvasadoNoTerminado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMovimienEnvasadoNoTerminado));
            this.LblMaquilaCliente = new System.Windows.Forms.Label();
            this.LblCliente = new System.Windows.Forms.Label();
            this.TxtClaveFqEnvasado = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.ChekMaquila = new System.Windows.Forms.CheckBox();
            this.CmbMarca = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnAgragarHolograma = new System.Windows.Forms.Button();
            this.DtaHologramas = new System.Windows.Forms.DataGridView();
            this.label36 = new System.Windows.Forms.Label();
            this.TxtHologramaFin = new System.Windows.Forms.TextBox();
            this.TxtHologramaInicio = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.TxtSerie = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.BtnInformacionHolograma = new System.Windows.Forms.Button();
            this.TxtBotellas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtGradoAlcoholicoEtiqueta = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.DtaFechaEnvasadofin = new System.Windows.Forms.DateTimePicker();
            this.txtNoLoteEnvasado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbNuevoNoLoteEnvasado = new System.Windows.Forms.CheckBox();
            this.btnReenvasado = new System.Windows.Forms.Button();
            this.btnTerminarEnvasado = new System.Windows.Forms.Button();
            this.pnlReenvasado = new System.Windows.Forms.Panel();
            this.TxtObservacionesReproceso = new System.Windows.Forms.RichTextBox();
            this.lblobservaciones = new System.Windows.Forms.Label();
            this.lblNoLote = new System.Windows.Forms.Label();
            this.lblTituloPanelReenvasado = new System.Windows.Forms.Label();
            this.txtNoBotellasReenvasado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardarReenvasado = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlTerminarEnvasado = new System.Windows.Forms.Panel();
            this.chkHologramasAnteriores = new System.Windows.Forms.CheckBox();
            this.cmbEtiquetadocomo = new System.Windows.Forms.ComboBox();
            this.lblEtiquetadocomo = new System.Windows.Forms.Label();
            this.TxtMensajeBotellas = new iTalk_ChatBubble_L();
            this.BtnSalida = new System.Windows.Forms.Button();
            this.pnlSalida = new System.Windows.Forms.Panel();
            this.txtTipoSalida = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rchtxtObservaciones = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNoLoteSalida = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoBotellasSalida = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardarSalida = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtaHologramas)).BeginInit();
            this.pnlReenvasado.SuspendLayout();
            this.pnlTerminarEnvasado.SuspendLayout();
            this.pnlSalida.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblMaquilaCliente
            // 
            this.LblMaquilaCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblMaquilaCliente.AutoSize = true;
            this.LblMaquilaCliente.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMaquilaCliente.Location = new System.Drawing.Point(319, 33);
            this.LblMaquilaCliente.Name = "LblMaquilaCliente";
            this.LblMaquilaCliente.Size = new System.Drawing.Size(20, 18);
            this.LblMaquilaCliente.TabIndex = 422;
            this.LblMaquilaCliente.Text = "...";
            this.LblMaquilaCliente.Visible = false;
            // 
            // LblCliente
            // 
            this.LblCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.Location = new System.Drawing.Point(236, 33);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(80, 18);
            this.LblCliente.TabIndex = 421;
            this.LblCliente.Text = "No cliente :";
            this.LblCliente.Visible = false;
            // 
            // TxtClaveFqEnvasado
            // 
            this.TxtClaveFqEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtClaveFqEnvasado.Location = new System.Drawing.Point(240, 149);
            this.TxtClaveFqEnvasado.MaxLength = 50;
            this.TxtClaveFqEnvasado.Name = "TxtClaveFqEnvasado";
            this.TxtClaveFqEnvasado.Size = new System.Drawing.Size(214, 20);
            this.TxtClaveFqEnvasado.TabIndex = 3;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(165, 150);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 18);
            this.label28.TabIndex = 414;
            this.label28.Text = "Clave FQ :";
            // 
            // ChekMaquila
            // 
            this.ChekMaquila.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChekMaquila.AutoSize = true;
            this.ChekMaquila.Location = new System.Drawing.Point(460, 92);
            this.ChekMaquila.Name = "ChekMaquila";
            this.ChekMaquila.Size = new System.Drawing.Size(63, 17);
            this.ChekMaquila.TabIndex = 2;
            this.ChekMaquila.Text = "Maquila";
            this.ChekMaquila.UseVisualStyleBackColor = true;
            this.ChekMaquila.CheckedChanged += new System.EventHandler(this.ChekMaquila_CheckedChanged);
            // 
            // CmbMarca
            // 
            this.CmbMarca.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMarca.DropDownWidth = 300;
            this.CmbMarca.FormattingEnabled = true;
            this.CmbMarca.Location = new System.Drawing.Point(240, 90);
            this.CmbMarca.Name = "CmbMarca";
            this.CmbMarca.Size = new System.Drawing.Size(214, 21);
            this.CmbMarca.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(179, 89);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 18);
            this.label27.TabIndex = 410;
            this.label27.Text = "Marca :";
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
            this.BtnGuardar.Location = new System.Drawing.Point(327, 332);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 11;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
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
            this.BtnAgragarHolograma.Location = new System.Drawing.Point(459, 255);
            this.BtnAgragarHolograma.Name = "BtnAgragarHolograma";
            this.BtnAgragarHolograma.Size = new System.Drawing.Size(26, 28);
            this.BtnAgragarHolograma.TabIndex = 9;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaHologramas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtaHologramas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaHologramas.EnableHeadersVisualStyles = false;
            this.DtaHologramas.Location = new System.Drawing.Point(240, 255);
            this.DtaHologramas.Name = "DtaHologramas";
            this.DtaHologramas.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaHologramas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtaHologramas.Size = new System.Drawing.Size(214, 67);
            this.DtaHologramas.TabIndex = 7;
            this.DtaHologramas.TabStop = false;
            this.DtaHologramas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaHologramas_CellDoubleClick);
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(332, 230);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(28, 18);
            this.label36.TabIndex = 427;
            this.label36.Text = "<->";
            // 
            // TxtHologramaFin
            // 
            this.TxtHologramaFin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtHologramaFin.Location = new System.Drawing.Point(366, 230);
            this.TxtHologramaFin.MaxLength = 7;
            this.TxtHologramaFin.Name = "TxtHologramaFin";
            this.TxtHologramaFin.Size = new System.Drawing.Size(87, 20);
            this.TxtHologramaFin.TabIndex = 7;
            this.TxtHologramaFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHologramaFin_KeyPress);
            // 
            // TxtHologramaInicio
            // 
            this.TxtHologramaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtHologramaInicio.Location = new System.Drawing.Point(240, 230);
            this.TxtHologramaInicio.MaxLength = 7;
            this.TxtHologramaInicio.Name = "TxtHologramaInicio";
            this.TxtHologramaInicio.Size = new System.Drawing.Size(89, 20);
            this.TxtHologramaInicio.TabIndex = 6;
            this.TxtHologramaInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHologramaInicio_KeyPress);
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(143, 230);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(91, 18);
            this.label37.TabIndex = 425;
            this.label37.Text = "Hologramas :";
            // 
            // TxtSerie
            // 
            this.TxtSerie.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtSerie.Location = new System.Drawing.Point(505, 234);
            this.TxtSerie.MaxLength = 1;
            this.TxtSerie.Name = "TxtSerie";
            this.TxtSerie.Size = new System.Drawing.Size(27, 20);
            this.TxtSerie.TabIndex = 8;
            this.TxtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSerie_KeyPress);
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(459, 234);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(49, 18);
            this.label69.TabIndex = 429;
            this.label69.Text = "Serie :";
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
            this.BtnInformacionHolograma.Location = new System.Drawing.Point(457, 289);
            this.BtnInformacionHolograma.Name = "BtnInformacionHolograma";
            this.BtnInformacionHolograma.Size = new System.Drawing.Size(28, 25);
            this.BtnInformacionHolograma.TabIndex = 10;
            this.BtnInformacionHolograma.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnInformacionHolograma.UseVisualStyleBackColor = false;
            this.BtnInformacionHolograma.MouseEnter += new System.EventHandler(this.BtnInformacionHolograma_MouseEnter);
            this.BtnInformacionHolograma.MouseLeave += new System.EventHandler(this.BtnInformacionHolograma_MouseLeave);
            // 
            // TxtBotellas
            // 
            this.TxtBotellas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtBotellas.Location = new System.Drawing.Point(240, 175);
            this.TxtBotellas.MaxLength = 30;
            this.TxtBotellas.Name = "TxtBotellas";
            this.TxtBotellas.Size = new System.Drawing.Size(214, 20);
            this.TxtBotellas.TabIndex = 4;
            this.TxtBotellas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBotellas_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 437;
            this.label1.Text = "Botellas :";
            // 
            // TxtGradoAlcoholicoEtiqueta
            // 
            this.TxtGradoAlcoholicoEtiqueta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtGradoAlcoholicoEtiqueta.Location = new System.Drawing.Point(240, 202);
            this.TxtGradoAlcoholicoEtiqueta.MaxLength = 5;
            this.TxtGradoAlcoholicoEtiqueta.Name = "TxtGradoAlcoholicoEtiqueta";
            this.TxtGradoAlcoholicoEtiqueta.Size = new System.Drawing.Size(49, 20);
            this.TxtGradoAlcoholicoEtiqueta.TabIndex = 5;
            this.TxtGradoAlcoholicoEtiqueta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGradoAlcoholicoEtiqueta_KeyPress);
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(120, 202);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(114, 18);
            this.label29.TabIndex = 438;
            this.label29.Text = "°Alcohólico etiq :";
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(98, 67);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(136, 18);
            this.label62.TabIndex = 448;
            this.label62.Text = "Fecha Envasado Fin :";
            // 
            // DtaFechaEnvasadofin
            // 
            this.DtaFechaEnvasadofin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DtaFechaEnvasadofin.Location = new System.Drawing.Point(240, 65);
            this.DtaFechaEnvasadofin.Name = "DtaFechaEnvasadofin";
            this.DtaFechaEnvasadofin.Size = new System.Drawing.Size(207, 20);
            this.DtaFechaEnvasadofin.TabIndex = 449;
            // 
            // txtNoLoteEnvasado
            // 
            this.txtNoLoteEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoLoteEnvasado.Location = new System.Drawing.Point(240, 120);
            this.txtNoLoteEnvasado.MaxLength = 50;
            this.txtNoLoteEnvasado.Name = "txtNoLoteEnvasado";
            this.txtNoLoteEnvasado.Size = new System.Drawing.Size(214, 20);
            this.txtNoLoteEnvasado.TabIndex = 450;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 451;
            this.label2.Text = "No Lote :";
            // 
            // chbNuevoNoLoteEnvasado
            // 
            this.chbNuevoNoLoteEnvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chbNuevoNoLoteEnvasado.AutoSize = true;
            this.chbNuevoNoLoteEnvasado.Location = new System.Drawing.Point(462, 122);
            this.chbNuevoNoLoteEnvasado.Name = "chbNuevoNoLoteEnvasado";
            this.chbNuevoNoLoteEnvasado.Size = new System.Drawing.Size(105, 17);
            this.chbNuevoNoLoteEnvasado.TabIndex = 452;
            this.chbNuevoNoLoteEnvasado.Text = "Cambiar No Lote";
            this.chbNuevoNoLoteEnvasado.UseVisualStyleBackColor = true;
            this.chbNuevoNoLoteEnvasado.CheckedChanged += new System.EventHandler(this.chbNuevoNoLoteEnvasado_CheckedChanged);
            // 
            // btnReenvasado
            // 
            this.btnReenvasado.BackColor = System.Drawing.Color.Transparent;
            this.btnReenvasado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReenvasado.FlatAppearance.BorderSize = 0;
            this.btnReenvasado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReenvasado.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReenvasado.ForeColor = System.Drawing.Color.Black;
            this.btnReenvasado.Image = global::Crm.Properties.Resources.bottle1;
            this.btnReenvasado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReenvasado.Location = new System.Drawing.Point(334, 4);
            this.btnReenvasado.Name = "btnReenvasado";
            this.btnReenvasado.Size = new System.Drawing.Size(94, 58);
            this.btnReenvasado.TabIndex = 453;
            this.btnReenvasado.Text = "Reenvasado";
            this.btnReenvasado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReenvasado.UseVisualStyleBackColor = false;
            this.btnReenvasado.Click += new System.EventHandler(this.btnReenvasado_Click);
            // 
            // btnTerminarEnvasado
            // 
            this.btnTerminarEnvasado.BackColor = System.Drawing.Color.Transparent;
            this.btnTerminarEnvasado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminarEnvasado.FlatAppearance.BorderSize = 0;
            this.btnTerminarEnvasado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminarEnvasado.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminarEnvasado.ForeColor = System.Drawing.Color.Black;
            this.btnTerminarEnvasado.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminarEnvasado.Image")));
            this.btnTerminarEnvasado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTerminarEnvasado.Location = new System.Drawing.Point(187, 0);
            this.btnTerminarEnvasado.Name = "btnTerminarEnvasado";
            this.btnTerminarEnvasado.Size = new System.Drawing.Size(141, 62);
            this.btnTerminarEnvasado.TabIndex = 454;
            this.btnTerminarEnvasado.Text = "Terminar envasado";
            this.btnTerminarEnvasado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTerminarEnvasado.UseVisualStyleBackColor = false;
            this.btnTerminarEnvasado.Click += new System.EventHandler(this.btnTerminarEnvasado_Click);
            // 
            // pnlReenvasado
            // 
            this.pnlReenvasado.Controls.Add(this.TxtObservacionesReproceso);
            this.pnlReenvasado.Controls.Add(this.lblobservaciones);
            this.pnlReenvasado.Controls.Add(this.lblNoLote);
            this.pnlReenvasado.Controls.Add(this.lblTituloPanelReenvasado);
            this.pnlReenvasado.Controls.Add(this.txtNoBotellasReenvasado);
            this.pnlReenvasado.Controls.Add(this.label4);
            this.pnlReenvasado.Controls.Add(this.btnGuardarReenvasado);
            this.pnlReenvasado.Controls.Add(this.label3);
            this.pnlReenvasado.Location = new System.Drawing.Point(47, 65);
            this.pnlReenvasado.Name = "pnlReenvasado";
            this.pnlReenvasado.Size = new System.Drawing.Size(610, 369);
            this.pnlReenvasado.TabIndex = 455;
            // 
            // TxtObservacionesReproceso
            // 
            this.TxtObservacionesReproceso.Location = new System.Drawing.Point(203, 127);
            this.TxtObservacionesReproceso.Name = "TxtObservacionesReproceso";
            this.TxtObservacionesReproceso.Size = new System.Drawing.Size(283, 78);
            this.TxtObservacionesReproceso.TabIndex = 459;
            this.TxtObservacionesReproceso.Text = "";
            // 
            // lblobservaciones
            // 
            this.lblobservaciones.AutoSize = true;
            this.lblobservaciones.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblobservaciones.Location = new System.Drawing.Point(89, 127);
            this.lblobservaciones.Name = "lblobservaciones";
            this.lblobservaciones.Size = new System.Drawing.Size(108, 18);
            this.lblobservaciones.TabIndex = 460;
            this.lblobservaciones.Text = "Observaciones :";
            // 
            // lblNoLote
            // 
            this.lblNoLote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoLote.AutoSize = true;
            this.lblNoLote.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoLote.Location = new System.Drawing.Point(203, 70);
            this.lblNoLote.Name = "lblNoLote";
            this.lblNoLote.Size = new System.Drawing.Size(24, 18);
            this.lblNoLote.TabIndex = 458;
            this.lblNoLote.Text = "....";
            // 
            // lblTituloPanelReenvasado
            // 
            this.lblTituloPanelReenvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTituloPanelReenvasado.AutoSize = true;
            this.lblTituloPanelReenvasado.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanelReenvasado.Location = new System.Drawing.Point(249, 11);
            this.lblTituloPanelReenvasado.Name = "lblTituloPanelReenvasado";
            this.lblTituloPanelReenvasado.Size = new System.Drawing.Size(84, 18);
            this.lblTituloPanelReenvasado.TabIndex = 457;
            this.lblTituloPanelReenvasado.Text = "Reenvasado";
            // 
            // txtNoBotellasReenvasado
            // 
            this.txtNoBotellasReenvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoBotellasReenvasado.Location = new System.Drawing.Point(203, 96);
            this.txtNoBotellasReenvasado.MaxLength = 30;
            this.txtNoBotellasReenvasado.Name = "txtNoBotellasReenvasado";
            this.txtNoBotellasReenvasado.Size = new System.Drawing.Size(214, 20);
            this.txtNoBotellasReenvasado.TabIndex = 455;
            this.txtNoBotellasReenvasado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoBotellasReenvasado_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(131, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 456;
            this.label4.Text = "Botellas :";
            // 
            // btnGuardarReenvasado
            // 
            this.btnGuardarReenvasado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardarReenvasado.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarReenvasado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarReenvasado.FlatAppearance.BorderSize = 0;
            this.btnGuardarReenvasado.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnGuardarReenvasado.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnGuardarReenvasado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarReenvasado.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarReenvasado.ForeColor = System.Drawing.Color.White;
            this.btnGuardarReenvasado.Image = global::Crm.Properties.Resources.disquette;
            this.btnGuardarReenvasado.Location = new System.Drawing.Point(273, 238);
            this.btnGuardarReenvasado.Name = "btnGuardarReenvasado";
            this.btnGuardarReenvasado.Size = new System.Drawing.Size(39, 39);
            this.btnGuardarReenvasado.TabIndex = 454;
            this.btnGuardarReenvasado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarReenvasado.UseVisualStyleBackColor = false;
            this.btnGuardarReenvasado.Click += new System.EventHandler(this.btnGuardarReenvasado_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(133, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 452;
            this.label3.Text = "No Lote :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(276, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 456;
            this.label6.Text = "Terminar envasado";
            // 
            // pnlTerminarEnvasado
            // 
            this.pnlTerminarEnvasado.Controls.Add(this.chkHologramasAnteriores);
            this.pnlTerminarEnvasado.Controls.Add(this.cmbEtiquetadocomo);
            this.pnlTerminarEnvasado.Controls.Add(this.lblEtiquetadocomo);
            this.pnlTerminarEnvasado.Controls.Add(this.label6);
            this.pnlTerminarEnvasado.Controls.Add(this.label27);
            this.pnlTerminarEnvasado.Controls.Add(this.chbNuevoNoLoteEnvasado);
            this.pnlTerminarEnvasado.Controls.Add(this.CmbMarca);
            this.pnlTerminarEnvasado.Controls.Add(this.label2);
            this.pnlTerminarEnvasado.Controls.Add(this.ChekMaquila);
            this.pnlTerminarEnvasado.Controls.Add(this.txtNoLoteEnvasado);
            this.pnlTerminarEnvasado.Controls.Add(this.label28);
            this.pnlTerminarEnvasado.Controls.Add(this.DtaFechaEnvasadofin);
            this.pnlTerminarEnvasado.Controls.Add(this.TxtClaveFqEnvasado);
            this.pnlTerminarEnvasado.Controls.Add(this.label62);
            this.pnlTerminarEnvasado.Controls.Add(this.LblCliente);
            this.pnlTerminarEnvasado.Controls.Add(this.TxtGradoAlcoholicoEtiqueta);
            this.pnlTerminarEnvasado.Controls.Add(this.LblMaquilaCliente);
            this.pnlTerminarEnvasado.Controls.Add(this.label29);
            this.pnlTerminarEnvasado.Controls.Add(this.BtnGuardar);
            this.pnlTerminarEnvasado.Controls.Add(this.TxtBotellas);
            this.pnlTerminarEnvasado.Controls.Add(this.label37);
            this.pnlTerminarEnvasado.Controls.Add(this.label1);
            this.pnlTerminarEnvasado.Controls.Add(this.TxtHologramaInicio);
            this.pnlTerminarEnvasado.Controls.Add(this.TxtMensajeBotellas);
            this.pnlTerminarEnvasado.Controls.Add(this.TxtHologramaFin);
            this.pnlTerminarEnvasado.Controls.Add(this.BtnInformacionHolograma);
            this.pnlTerminarEnvasado.Controls.Add(this.label36);
            this.pnlTerminarEnvasado.Controls.Add(this.TxtSerie);
            this.pnlTerminarEnvasado.Controls.Add(this.DtaHologramas);
            this.pnlTerminarEnvasado.Controls.Add(this.label69);
            this.pnlTerminarEnvasado.Controls.Add(this.BtnAgragarHolograma);
            this.pnlTerminarEnvasado.Location = new System.Drawing.Point(12, 68);
            this.pnlTerminarEnvasado.Name = "pnlTerminarEnvasado";
            this.pnlTerminarEnvasado.Size = new System.Drawing.Size(681, 373);
            this.pnlTerminarEnvasado.TabIndex = 457;
            // 
            // chkHologramasAnteriores
            // 
            this.chkHologramasAnteriores.AutoSize = true;
            this.chkHologramasAnteriores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHologramasAnteriores.ForeColor = System.Drawing.Color.Maroon;
            this.chkHologramasAnteriores.Location = new System.Drawing.Point(138, 279);
            this.chkHologramasAnteriores.Name = "chkHologramasAnteriores";
            this.chkHologramasAnteriores.Size = new System.Drawing.Size(96, 30);
            this.chkHologramasAnteriores.TabIndex = 460;
            this.chkHologramasAnteriores.Text = "Hologramas \r\nanteriores";
            this.chkHologramasAnteriores.UseVisualStyleBackColor = true;
            this.chkHologramasAnteriores.Visible = false;
            // 
            // cmbEtiquetadocomo
            // 
            this.cmbEtiquetadocomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbEtiquetadocomo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEtiquetadocomo.DropDownWidth = 300;
            this.cmbEtiquetadocomo.FormattingEnabled = true;
            this.cmbEtiquetadocomo.Location = new System.Drawing.Point(420, 202);
            this.cmbEtiquetadocomo.Name = "cmbEtiquetadocomo";
            this.cmbEtiquetadocomo.Size = new System.Drawing.Size(121, 21);
            this.cmbEtiquetadocomo.TabIndex = 459;
            // 
            // lblEtiquetadocomo
            // 
            this.lblEtiquetadocomo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEtiquetadocomo.AutoSize = true;
            this.lblEtiquetadocomo.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiquetadocomo.Location = new System.Drawing.Point(294, 203);
            this.lblEtiquetadocomo.Name = "lblEtiquetadocomo";
            this.lblEtiquetadocomo.Size = new System.Drawing.Size(122, 18);
            this.lblEtiquetadocomo.TabIndex = 458;
            this.lblEtiquetadocomo.Text = "Etiquetado como :";
            // 
            // TxtMensajeBotellas
            // 
            this.TxtMensajeBotellas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtMensajeBotellas.BackColor = System.Drawing.Color.Transparent;
            this.TxtMensajeBotellas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TxtMensajeBotellas.BubbleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(206)))), ((int)(((byte)(215)))));
            this.TxtMensajeBotellas.DrawBubbleArrow = true;
            this.TxtMensajeBotellas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMensajeBotellas.Location = new System.Drawing.Point(445, 255);
            this.TxtMensajeBotellas.Name = "TxtMensajeBotellas";
            this.TxtMensajeBotellas.Size = new System.Drawing.Size(112, 57);
            this.TxtMensajeBotellas.TabIndex = 435;
            this.TxtMensajeBotellas.Visible = false;
            // 
            // BtnSalida
            // 
            this.BtnSalida.BackColor = System.Drawing.Color.Transparent;
            this.BtnSalida.FlatAppearance.BorderSize = 0;
            this.BtnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalida.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalida.ForeColor = System.Drawing.Color.Black;
            this.BtnSalida.Image = global::Crm.Properties.Resources.logout;
            this.BtnSalida.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSalida.Location = new System.Drawing.Point(435, 4);
            this.BtnSalida.Name = "BtnSalida";
            this.BtnSalida.Size = new System.Drawing.Size(57, 58);
            this.BtnSalida.TabIndex = 458;
            this.BtnSalida.Text = "Salida";
            this.BtnSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalida.UseVisualStyleBackColor = false;
            this.BtnSalida.Click += new System.EventHandler(this.BtnSalida_Click);
            // 
            // pnlSalida
            // 
            this.pnlSalida.Controls.Add(this.txtTipoSalida);
            this.pnlSalida.Controls.Add(this.label11);
            this.pnlSalida.Controls.Add(this.rchtxtObservaciones);
            this.pnlSalida.Controls.Add(this.label5);
            this.pnlSalida.Controls.Add(this.lblNoLoteSalida);
            this.pnlSalida.Controls.Add(this.label8);
            this.pnlSalida.Controls.Add(this.txtNoBotellasSalida);
            this.pnlSalida.Controls.Add(this.label9);
            this.pnlSalida.Controls.Add(this.btnGuardarSalida);
            this.pnlSalida.Controls.Add(this.label10);
            this.pnlSalida.Location = new System.Drawing.Point(88, 74);
            this.pnlSalida.Name = "pnlSalida";
            this.pnlSalida.Size = new System.Drawing.Size(536, 363);
            this.pnlSalida.TabIndex = 459;
            // 
            // txtTipoSalida
            // 
            this.txtTipoSalida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTipoSalida.Location = new System.Drawing.Point(204, 122);
            this.txtTipoSalida.MaxLength = 30;
            this.txtTipoSalida.Name = "txtTipoSalida";
            this.txtTipoSalida.Size = new System.Drawing.Size(214, 20);
            this.txtTipoSalida.TabIndex = 461;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(111, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 18);
            this.label11.TabIndex = 462;
            this.label11.Text = "Tipo Salida :";
            // 
            // rchtxtObservaciones
            // 
            this.rchtxtObservaciones.Location = new System.Drawing.Point(203, 153);
            this.rchtxtObservaciones.Name = "rchtxtObservaciones";
            this.rchtxtObservaciones.Size = new System.Drawing.Size(283, 78);
            this.rchtxtObservaciones.TabIndex = 459;
            this.rchtxtObservaciones.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 460;
            this.label5.Text = "Observaciones :";
            // 
            // lblNoLoteSalida
            // 
            this.lblNoLoteSalida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoLoteSalida.AutoSize = true;
            this.lblNoLoteSalida.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoLoteSalida.Location = new System.Drawing.Point(203, 70);
            this.lblNoLoteSalida.Name = "lblNoLoteSalida";
            this.lblNoLoteSalida.Size = new System.Drawing.Size(24, 18);
            this.lblNoLoteSalida.TabIndex = 458;
            this.lblNoLoteSalida.Text = "....";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(229, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 457;
            this.label8.Text = "Salida";
            // 
            // txtNoBotellasSalida
            // 
            this.txtNoBotellasSalida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNoBotellasSalida.Location = new System.Drawing.Point(203, 96);
            this.txtNoBotellasSalida.MaxLength = 30;
            this.txtNoBotellasSalida.Name = "txtNoBotellasSalida";
            this.txtNoBotellasSalida.Size = new System.Drawing.Size(214, 20);
            this.txtNoBotellasSalida.TabIndex = 455;
            this.txtNoBotellasSalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoBotellasSalida_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(131, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 18);
            this.label9.TabIndex = 456;
            this.label9.Text = "Botellas :";
            // 
            // btnGuardarSalida
            // 
            this.btnGuardarSalida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardarSalida.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarSalida.FlatAppearance.BorderSize = 0;
            this.btnGuardarSalida.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnGuardarSalida.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnGuardarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSalida.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarSalida.ForeColor = System.Drawing.Color.White;
            this.btnGuardarSalida.Image = global::Crm.Properties.Resources.disquette;
            this.btnGuardarSalida.Location = new System.Drawing.Point(236, 273);
            this.btnGuardarSalida.Name = "btnGuardarSalida";
            this.btnGuardarSalida.Size = new System.Drawing.Size(39, 39);
            this.btnGuardarSalida.TabIndex = 454;
            this.btnGuardarSalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarSalida.UseVisualStyleBackColor = false;
            this.btnGuardarSalida.Click += new System.EventHandler(this.btnGuardarSalida_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(133, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 18);
            this.label10.TabIndex = 452;
            this.label10.Text = "No Lote :";
            // 
            // FrmMovimienEnvasadoNoTerminado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 459);
            this.Controls.Add(this.BtnSalida);
            this.Controls.Add(this.btnTerminarEnvasado);
            this.Controls.Add(this.btnReenvasado);
            this.Controls.Add(this.pnlTerminarEnvasado);
            this.Controls.Add(this.pnlSalida);
            this.Controls.Add(this.pnlReenvasado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMovimienEnvasadoNoTerminado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento Envasado";
            this.Load += new System.EventHandler(this.FrmMovimienEnvasadoNoTerminado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaHologramas)).EndInit();
            this.pnlReenvasado.ResumeLayout(false);
            this.pnlReenvasado.PerformLayout();
            this.pnlTerminarEnvasado.ResumeLayout(false);
            this.pnlTerminarEnvasado.PerformLayout();
            this.pnlSalida.ResumeLayout(false);
            this.pnlSalida.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMaquilaCliente;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.TextBox TxtClaveFqEnvasado;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox ChekMaquila;
        private System.Windows.Forms.ComboBox CmbMarca;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnAgragarHolograma;
        private System.Windows.Forms.DataGridView DtaHologramas;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox TxtHologramaFin;
        private System.Windows.Forms.TextBox TxtHologramaInicio;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox TxtSerie;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button BtnInformacionHolograma;
        private iTalk_ChatBubble_L TxtMensajeBotellas;
        private System.Windows.Forms.TextBox TxtBotellas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtGradoAlcoholicoEtiqueta;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.DateTimePicker DtaFechaEnvasadofin;
        private System.Windows.Forms.TextBox txtNoLoteEnvasado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbNuevoNoLoteEnvasado;
        private System.Windows.Forms.Button btnReenvasado;
        private System.Windows.Forms.Button btnTerminarEnvasado;
        private System.Windows.Forms.Panel pnlReenvasado;
        private System.Windows.Forms.TextBox txtNoBotellasReenvasado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardarReenvasado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTituloPanelReenvasado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNoLote;
        private System.Windows.Forms.Panel pnlTerminarEnvasado;
        private System.Windows.Forms.RichTextBox TxtObservacionesReproceso;
        private System.Windows.Forms.Label lblobservaciones;
        private System.Windows.Forms.Button BtnSalida;
        private System.Windows.Forms.Panel pnlSalida;
        private System.Windows.Forms.RichTextBox rchtxtObservaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNoLoteSalida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNoBotellasSalida;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGuardarSalida;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTipoSalida;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblEtiquetadocomo;
        private System.Windows.Forms.ComboBox cmbEtiquetadocomo;
        private System.Windows.Forms.CheckBox chkHologramasAnteriores;
    }
}