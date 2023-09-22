namespace Crm.Inventario
{
    partial class FrmEnsamblePredio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TxtAgaveEntranteKg = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtAgaveCoccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbMaguey = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbNoPredio = new System.Windows.Forms.ComboBox();
            this.TxtPredio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtExtraccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtExistencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnAgregarProduccion = new System.Windows.Forms.Button();
            this.DtaEnsamble = new System.Windows.Forms.DataGridView();
            this.CmbCoccion = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtTapada = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.DataFechaInicioCoccion = new System.Windows.Forms.DateTimePicker();
            this.lblNo_Usuario = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.ChekMagueyComprado = new System.Windows.Forms.CheckBox();
            this.ChekAgaveSobrante = new System.Windows.Forms.CheckBox();
            this.TxtArt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtMaestroMezcalero = new System.Windows.Forms.TextBox();
            this.CmbFabrica = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.TxtNoGuia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtNoPredio = new System.Windows.Forms.TextBox();
            this.chkGuiaAntigua = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtaEnsamble)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtAgaveEntranteKg
            // 
            this.TxtAgaveEntranteKg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtAgaveEntranteKg.Location = new System.Drawing.Point(664, 56);
            this.TxtAgaveEntranteKg.MaxLength = 9;
            this.TxtAgaveEntranteKg.Name = "TxtAgaveEntranteKg";
            this.TxtAgaveEntranteKg.Size = new System.Drawing.Size(127, 20);
            this.TxtAgaveEntranteKg.TabIndex = 298;
            this.TxtAgaveEntranteKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAgaveEntranteKg_KeyPress);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(516, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 18);
            this.label12.TabIndex = 302;
            this.label12.Text = "Maguey  entrante (Kg) :";
            // 
            // TxtAgaveCoccion
            // 
            this.TxtAgaveCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtAgaveCoccion.Location = new System.Drawing.Point(664, 82);
            this.TxtAgaveCoccion.MaxLength = 9;
            this.TxtAgaveCoccion.Name = "TxtAgaveCoccion";
            this.TxtAgaveCoccion.Size = new System.Drawing.Size(127, 20);
            this.TxtAgaveCoccion.TabIndex = 299;
            this.TxtAgaveCoccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAgaveCoccion_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(512, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 18);
            this.label4.TabIndex = 301;
            this.label4.Text = "Maguey  a cocción (Kg) :";
            // 
            // CmbMaguey
            // 
            this.CmbMaguey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbMaguey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaguey.DropDownWidth = 300;
            this.CmbMaguey.FormattingEnabled = true;
            this.CmbMaguey.Location = new System.Drawing.Point(208, 182);
            this.CmbMaguey.Name = "CmbMaguey";
            this.CmbMaguey.Size = new System.Drawing.Size(232, 21);
            this.CmbMaguey.TabIndex = 290;
            this.CmbMaguey.SelectedIndexChanged += new System.EventHandler(this.CmbMaguey_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 297;
            this.label3.Text = "Maguey :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 296;
            this.label2.Text = "Predio :";
            // 
            // CmbNoPredio
            // 
            this.CmbNoPredio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbNoPredio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNoPredio.FormattingEnabled = true;
            this.CmbNoPredio.Location = new System.Drawing.Point(210, 128);
            this.CmbNoPredio.Name = "CmbNoPredio";
            this.CmbNoPredio.Size = new System.Drawing.Size(127, 21);
            this.CmbNoPredio.TabIndex = 288;
            this.CmbNoPredio.Visible = false;
            this.CmbNoPredio.SelectedIndexChanged += new System.EventHandler(this.CmbNoPredio_SelectedIndexChanged);
            // 
            // TxtPredio
            // 
            this.TxtPredio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtPredio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtPredio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtPredio.Location = new System.Drawing.Point(208, 156);
            this.TxtPredio.MaxLength = 9;
            this.TxtPredio.Name = "TxtPredio";
            this.TxtPredio.ReadOnly = true;
            this.TxtPredio.Size = new System.Drawing.Size(232, 20);
            this.TxtPredio.TabIndex = 289;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 295;
            this.label1.Text = "No Predio :";
            // 
            // TxtExtraccion
            // 
            this.TxtExtraccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtExtraccion.Location = new System.Drawing.Point(208, 235);
            this.TxtExtraccion.MaxLength = 9;
            this.TxtExtraccion.Name = "TxtExtraccion";
            this.TxtExtraccion.Size = new System.Drawing.Size(127, 20);
            this.TxtExtraccion.TabIndex = 292;
            this.TxtExtraccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtExtraccion_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(137, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 294;
            this.label5.Text = "No piñas :";
            // 
            // TxtExistencia
            // 
            this.TxtExistencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtExistencia.Location = new System.Drawing.Point(208, 208);
            this.TxtExistencia.Name = "TxtExistencia";
            this.TxtExistencia.ReadOnly = true;
            this.TxtExistencia.Size = new System.Drawing.Size(127, 20);
            this.TxtExistencia.TabIndex = 291;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 293;
            this.label6.Text = "Existencia :";
            // 
            // BtnAgregarProduccion
            // 
            this.BtnAgregarProduccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAgregarProduccion.BackColor = System.Drawing.Color.Transparent;
            this.BtnAgregarProduccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregarProduccion.FlatAppearance.BorderSize = 0;
            this.BtnAgregarProduccion.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarProduccion.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAgregarProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarProduccion.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarProduccion.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProduccion.Image = global::Crm.Properties.Resources.down_arrow;
            this.BtnAgregarProduccion.Location = new System.Drawing.Point(418, 226);
            this.BtnAgregarProduccion.Name = "BtnAgregarProduccion";
            this.BtnAgregarProduccion.Size = new System.Drawing.Size(39, 41);
            this.BtnAgregarProduccion.TabIndex = 304;
            this.BtnAgregarProduccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAgregarProduccion.UseVisualStyleBackColor = false;
            this.BtnAgregarProduccion.Click += new System.EventHandler(this.BtnAgregarProduccion_Click);
            // 
            // DtaEnsamble
            // 
            this.DtaEnsamble.AllowUserToAddRows = false;
            this.DtaEnsamble.AllowUserToDeleteRows = false;
            this.DtaEnsamble.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtaEnsamble.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtaEnsamble.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtaEnsamble.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaEnsamble.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DtaEnsamble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaEnsamble.EnableHeadersVisualStyles = false;
            this.DtaEnsamble.Location = new System.Drawing.Point(52, 272);
            this.DtaEnsamble.Name = "DtaEnsamble";
            this.DtaEnsamble.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaEnsamble.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DtaEnsamble.Size = new System.Drawing.Size(776, 215);
            this.DtaEnsamble.TabIndex = 305;
            this.DtaEnsamble.TabStop = false;
            this.DtaEnsamble.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaEnsamble_CellDoubleClick);
            // 
            // CmbCoccion
            // 
            this.CmbCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbCoccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCoccion.FormattingEnabled = true;
            this.CmbCoccion.Location = new System.Drawing.Point(418, 526);
            this.CmbCoccion.Name = "CmbCoccion";
            this.CmbCoccion.Size = new System.Drawing.Size(212, 21);
            this.CmbCoccion.TabIndex = 310;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(301, 527);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 18);
            this.label15.TabIndex = 311;
            this.label15.Text = "Tipo de cocción :";
            // 
            // TxtTapada
            // 
            this.TxtTapada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTapada.Location = new System.Drawing.Point(418, 500);
            this.TxtTapada.MaxLength = 15;
            this.TxtTapada.Name = "TxtTapada";
            this.TxtTapada.Size = new System.Drawing.Size(127, 20);
            this.TxtTapada.TabIndex = 308;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(327, 500);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 18);
            this.label14.TabIndex = 309;
            this.label14.Text = "Producción :";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(243, 552);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 18);
            this.label13.TabIndex = 307;
            this.label13.Text = "Inicio periodo de cocción :";
            // 
            // DataFechaInicioCoccion
            // 
            this.DataFechaInicioCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataFechaInicioCoccion.Location = new System.Drawing.Point(418, 554);
            this.DataFechaInicioCoccion.Name = "DataFechaInicioCoccion";
            this.DataFechaInicioCoccion.Size = new System.Drawing.Size(212, 20);
            this.DataFechaInicioCoccion.TabIndex = 306;
            // 
            // lblNo_Usuario
            // 
            this.lblNo_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNo_Usuario.AutoSize = true;
            this.lblNo_Usuario.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo_Usuario.Location = new System.Drawing.Point(472, 19);
            this.lblNo_Usuario.Name = "lblNo_Usuario";
            this.lblNo_Usuario.Size = new System.Drawing.Size(20, 18);
            this.lblNo_Usuario.TabIndex = 315;
            this.lblNo_Usuario.Text = "...";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(380, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 314;
            this.label7.Text = "No Asociado";
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
            this.BtnGuardar.Location = new System.Drawing.Point(417, 594);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(39, 39);
            this.BtnGuardar.TabIndex = 316;
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // ChekMagueyComprado
            // 
            this.ChekMagueyComprado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekMagueyComprado.AutoSize = true;
            this.ChekMagueyComprado.Location = new System.Drawing.Point(341, 209);
            this.ChekMagueyComprado.Name = "ChekMagueyComprado";
            this.ChekMagueyComprado.Size = new System.Drawing.Size(115, 17);
            this.ChekMagueyComprado.TabIndex = 317;
            this.ChekMagueyComprado.Text = "Maguey Comprado";
            this.ChekMagueyComprado.UseVisualStyleBackColor = true;
            this.ChekMagueyComprado.CheckedChanged += new System.EventHandler(this.ChekMagueyComprado_CheckedChanged);
            // 
            // ChekAgaveSobrante
            // 
            this.ChekAgaveSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekAgaveSobrante.AutoSize = true;
            this.ChekAgaveSobrante.Location = new System.Drawing.Point(665, 33);
            this.ChekAgaveSobrante.Name = "ChekAgaveSobrante";
            this.ChekAgaveSobrante.Size = new System.Drawing.Size(108, 17);
            this.ChekAgaveSobrante.TabIndex = 318;
            this.ChekAgaveSobrante.Text = "Maguey sobrante";
            this.ChekAgaveSobrante.UseVisualStyleBackColor = true;
            this.ChekAgaveSobrante.CheckedChanged += new System.EventHandler(this.ChekAgaveSobrante_CheckedChanged);
            // 
            // TxtArt
            // 
            this.TxtArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtArt.Location = new System.Drawing.Point(664, 109);
            this.TxtArt.MaxLength = 9;
            this.TxtArt.Name = "TxtArt";
            this.TxtArt.Size = new System.Drawing.Size(127, 20);
            this.TxtArt.TabIndex = 319;
            this.TxtArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtArt_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(609, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 18);
            this.label8.TabIndex = 320;
            this.label8.Text = "% ART :";
            // 
            // TxtMaestroMezcalero
            // 
            this.TxtMaestroMezcalero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtMaestroMezcalero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtMaestroMezcalero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtMaestroMezcalero.Location = new System.Drawing.Point(210, 80);
            this.TxtMaestroMezcalero.MaxLength = 9;
            this.TxtMaestroMezcalero.Name = "TxtMaestroMezcalero";
            this.TxtMaestroMezcalero.ReadOnly = true;
            this.TxtMaestroMezcalero.Size = new System.Drawing.Size(212, 20);
            this.TxtMaestroMezcalero.TabIndex = 328;
            // 
            // CmbFabrica
            // 
            this.CmbFabrica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbFabrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFabrica.FormattingEnabled = true;
            this.CmbFabrica.Location = new System.Drawing.Point(210, 53);
            this.CmbFabrica.Name = "CmbFabrica";
            this.CmbFabrica.Size = new System.Drawing.Size(212, 21);
            this.CmbFabrica.TabIndex = 326;
            this.CmbFabrica.SelectedIndexChanged += new System.EventHandler(this.CmbFabrica_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(147, 56);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(61, 18);
            this.label38.TabIndex = 327;
            this.label38.Text = "Fabrica :";
            // 
            // label39
            // 
            this.label39.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(69, 79);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(138, 18);
            this.label39.TabIndex = 325;
            this.label39.Text = "Maestro mezcalero :";
            // 
            // TxtNoGuia
            // 
            this.TxtNoGuia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoGuia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtNoGuia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtNoGuia.Location = new System.Drawing.Point(210, 104);
            this.TxtNoGuia.MaxLength = 9;
            this.TxtNoGuia.Name = "TxtNoGuia";
            this.TxtNoGuia.Size = new System.Drawing.Size(127, 20);
            this.TxtNoGuia.TabIndex = 329;
            this.TxtNoGuia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNoGuia_KeyDown);
            this.TxtNoGuia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNoGuia_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(140, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 330;
            this.label9.Text = "No Guia :";
            // 
            // TxtNoPredio
            // 
            this.TxtNoPredio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoPredio.Location = new System.Drawing.Point(210, 129);
            this.TxtNoPredio.Name = "TxtNoPredio";
            this.TxtNoPredio.ReadOnly = true;
            this.TxtNoPredio.Size = new System.Drawing.Size(127, 20);
            this.TxtNoPredio.TabIndex = 450;
            // 
            // chkGuiaAntigua
            // 
            this.chkGuiaAntigua.AutoSize = true;
            this.chkGuiaAntigua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGuiaAntigua.ForeColor = System.Drawing.Color.LimeGreen;
            this.chkGuiaAntigua.Location = new System.Drawing.Point(462, 208);
            this.chkGuiaAntigua.Name = "chkGuiaAntigua";
            this.chkGuiaAntigua.Size = new System.Drawing.Size(43, 17);
            this.chkGuiaAntigua.TabIndex = 451;
            this.chkGuiaAntigua.Text = "GA";
            this.chkGuiaAntigua.UseVisualStyleBackColor = true;
            // 
            // FrmEnsamblePredio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 638);
            this.Controls.Add(this.chkGuiaAntigua);
            this.Controls.Add(this.TxtNoPredio);
            this.Controls.Add(this.TxtNoGuia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtMaestroMezcalero);
            this.Controls.Add(this.CmbFabrica);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.TxtArt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ChekAgaveSobrante);
            this.Controls.Add(this.ChekMagueyComprado);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.lblNo_Usuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbCoccion);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TxtTapada);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DataFechaInicioCoccion);
            this.Controls.Add(this.DtaEnsamble);
            this.Controls.Add(this.BtnAgregarProduccion);
            this.Controls.Add(this.TxtAgaveEntranteKg);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtAgaveCoccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbMaguey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbNoPredio);
            this.Controls.Add(this.TxtPredio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtExtraccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtExistencia);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEnsamblePredio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ensamble";
            this.Load += new System.EventHandler(this.FrmEnsamblePredio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaEnsamble)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtAgaveEntranteKg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtAgaveCoccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbMaguey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbNoPredio;
        private System.Windows.Forms.TextBox TxtPredio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtExtraccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtExistencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnAgregarProduccion;
        private System.Windows.Forms.DataGridView DtaEnsamble;
        private System.Windows.Forms.ComboBox CmbCoccion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtTapada;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker DataFechaInicioCoccion;
        private System.Windows.Forms.Label lblNo_Usuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.CheckBox ChekMagueyComprado;
        private System.Windows.Forms.CheckBox ChekAgaveSobrante;
        private System.Windows.Forms.TextBox TxtArt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtMaestroMezcalero;
        private System.Windows.Forms.ComboBox CmbFabrica;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox TxtNoGuia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtNoPredio;
        private System.Windows.Forms.CheckBox chkGuiaAntigua;
    }
}