using System.Drawing;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.chkGuiaExterna = new System.Windows.Forms.CheckBox();
            this.CmbTipoMaguey = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grpInformacionGeneral = new System.Windows.Forms.GroupBox();
            this.grpSeleccionMaguey = new System.Windows.Forms.GroupBox();
            this.grpDatosProduccion = new System.Windows.Forms.GroupBox();
            this.grpEnsambleActual = new System.Windows.Forms.GroupBox();
            this.grpConfiguracionFinal = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtaEnsamble)).BeginInit();
            this.grpInformacionGeneral.SuspendLayout();
            this.grpSeleccionMaguey.SuspendLayout();
            this.grpDatosProduccion.SuspendLayout();
            this.grpEnsambleActual.SuspendLayout();
            this.grpConfiguracionFinal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtAgaveEntranteKg
            // 
            this.TxtAgaveEntranteKg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtAgaveEntranteKg.Location = new System.Drawing.Point(188, 19);
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
            this.label12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(25, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 18);
            this.label12.TabIndex = 302;
            this.label12.Text = "Maguey  entrante (Kg) :";
            // 
            // TxtAgaveCoccion
            // 
            this.TxtAgaveCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtAgaveCoccion.Location = new System.Drawing.Point(613, 17);
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
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 18);
            this.label4.TabIndex = 301;
            this.label4.Text = "Maguey  a cocción (Kg) :";
            // 
            // CmbMaguey
            // 
            this.CmbMaguey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbMaguey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMaguey.DropDownWidth = 300;
            this.CmbMaguey.FormattingEnabled = true;
            this.CmbMaguey.Location = new System.Drawing.Point(545, 21);
            this.CmbMaguey.Name = "CmbMaguey";
            this.CmbMaguey.Size = new System.Drawing.Size(232, 21);
            this.CmbMaguey.TabIndex = 290;
            this.CmbMaguey.SelectedIndexChanged += new System.EventHandler(this.CmbMaguey_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 297;
            this.label3.Text = "Maguey :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 296;
            this.label2.Text = "Predio :";
            // 
            // CmbNoPredio
            // 
            this.CmbNoPredio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbNoPredio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNoPredio.FormattingEnabled = true;
            this.CmbNoPredio.Location = new System.Drawing.Point(345, 75);
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
            this.TxtPredio.Location = new System.Drawing.Point(192, 103);
            this.TxtPredio.MaxLength = 30;
            this.TxtPredio.Name = "TxtPredio";
            this.TxtPredio.ReadOnly = true;
            this.TxtPredio.Size = new System.Drawing.Size(232, 20);
            this.TxtPredio.TabIndex = 289;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 295;
            this.label1.Text = "No Predio :";
            // 
            // TxtExtraccion
            // 
            this.TxtExtraccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtExtraccion.Location = new System.Drawing.Point(545, 74);
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
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(474, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 294;
            this.label5.Text = "No piñas :";
            // 
            // TxtExistencia
            // 
            this.TxtExistencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtExistencia.Location = new System.Drawing.Point(545, 47);
            this.TxtExistencia.Name = "TxtExistencia";
            this.TxtExistencia.ReadOnly = true;
            this.TxtExistencia.Size = new System.Drawing.Size(127, 20);
            this.TxtExistencia.TabIndex = 291;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(463, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 18);
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
            this.BtnAgregarProduccion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarProduccion.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProduccion.Image = global::Crm.Properties.Resources.down_arrow;
            this.BtnAgregarProduccion.Location = new System.Drawing.Point(365, 37);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaEnsamble.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DtaEnsamble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtaEnsamble.EnableHeadersVisualStyles = false;
            this.DtaEnsamble.Location = new System.Drawing.Point(28, 18);
            this.DtaEnsamble.Name = "DtaEnsamble";
            this.DtaEnsamble.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtaEnsamble.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DtaEnsamble.Size = new System.Drawing.Size(776, 175);
            this.DtaEnsamble.TabIndex = 305;
            this.DtaEnsamble.TabStop = false;
            this.DtaEnsamble.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtaEnsamble_CellDoubleClick);
            // 
            // CmbCoccion
            // 
            this.CmbCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbCoccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCoccion.FormattingEnabled = true;
            this.CmbCoccion.Location = new System.Drawing.Point(545, 14);
            this.CmbCoccion.Name = "CmbCoccion";
            this.CmbCoccion.Size = new System.Drawing.Size(212, 21);
            this.CmbCoccion.TabIndex = 310;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(428, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 18);
            this.label15.TabIndex = 311;
            this.label15.Text = "Tipo de cocción :";
            // 
            // TxtTapada
            // 
            this.TxtTapada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTapada.Location = new System.Drawing.Point(154, 14);
            this.TxtTapada.MaxLength = 15;
            this.TxtTapada.Name = "TxtTapada";
            this.TxtTapada.Size = new System.Drawing.Size(127, 20);
            this.TxtTapada.TabIndex = 308;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(63, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 18);
            this.label14.TabIndex = 309;
            this.label14.Text = "Producción :";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(190, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 18);
            this.label13.TabIndex = 307;
            this.label13.Text = "Inicio periodo de cocción :";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // DataFechaInicioCoccion
            // 
            this.DataFechaInicioCoccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataFechaInicioCoccion.Location = new System.Drawing.Point(365, 50);
            this.DataFechaInicioCoccion.Name = "DataFechaInicioCoccion";
            this.DataFechaInicioCoccion.Size = new System.Drawing.Size(212, 20);
            this.DataFechaInicioCoccion.TabIndex = 306;
            // 
            // lblNo_Usuario
            // 
            this.lblNo_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNo_Usuario.AutoSize = true;
            this.lblNo_Usuario.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo_Usuario.Location = new System.Drawing.Point(472, -51);
            this.lblNo_Usuario.Name = "lblNo_Usuario";
            this.lblNo_Usuario.Size = new System.Drawing.Size(20, 18);
            this.lblNo_Usuario.TabIndex = 315;
            this.lblNo_Usuario.Text = "...";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(380, -51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 18);
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
            this.BtnGuardar.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Image = global::Crm.Properties.Resources.disquette;
            this.BtnGuardar.Location = new System.Drawing.Point(385, 628);
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
            this.ChekMagueyComprado.Location = new System.Drawing.Point(571, 107);
            this.ChekMagueyComprado.Name = "ChekMagueyComprado";
            this.ChekMagueyComprado.Size = new System.Drawing.Size(115, 17);
            this.ChekMagueyComprado.TabIndex = 317;
            this.ChekMagueyComprado.Text = "Maguey Comprado";
            this.ChekMagueyComprado.UseVisualStyleBackColor = true;
            this.ChekMagueyComprado.Visible = false;
            this.ChekMagueyComprado.CheckedChanged += new System.EventHandler(this.ChekMagueyComprado_CheckedChanged);
            // 
            // ChekAgaveSobrante
            // 
            this.ChekAgaveSobrante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChekAgaveSobrante.AutoSize = true;
            this.ChekAgaveSobrante.Location = new System.Drawing.Point(449, 107);
            this.ChekAgaveSobrante.Name = "ChekAgaveSobrante";
            this.ChekAgaveSobrante.Size = new System.Drawing.Size(108, 17);
            this.ChekAgaveSobrante.TabIndex = 318;
            this.ChekAgaveSobrante.Text = "Maguey sobrante";
            this.ChekAgaveSobrante.UseVisualStyleBackColor = true;
            this.ChekAgaveSobrante.Visible = false;
            this.ChekAgaveSobrante.CheckedChanged += new System.EventHandler(this.ChekAgaveSobrante_CheckedChanged);
            // 
            // TxtArt
            // 
            this.TxtArt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtArt.Location = new System.Drawing.Point(188, 45);
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
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 320;
            this.label8.Text = "% ART :";
            // 
            // TxtMaestroMezcalero
            // 
            this.TxtMaestroMezcalero.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtMaestroMezcalero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtMaestroMezcalero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtMaestroMezcalero.Location = new System.Drawing.Point(560, 34);
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
            this.CmbFabrica.Location = new System.Drawing.Point(138, 31);
            this.CmbFabrica.Name = "CmbFabrica";
            this.CmbFabrica.Size = new System.Drawing.Size(212, 21);
            this.CmbFabrica.TabIndex = 326;
            this.CmbFabrica.SelectedIndexChanged += new System.EventHandler(this.CmbFabrica_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(75, 34);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(59, 18);
            this.label38.TabIndex = 327;
            this.label38.Text = "Fabrica :";
            // 
            // label39
            // 
            this.label39.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(419, 33);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(134, 18);
            this.label39.TabIndex = 325;
            this.label39.Text = "Maestro mezcalero :";
            // 
            // TxtNoGuia
            // 
            this.TxtNoGuia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoGuia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtNoGuia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtNoGuia.Location = new System.Drawing.Point(190, 49);
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
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(120, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 330;
            this.label9.Text = "No Guia :";
            // 
            // TxtNoPredio
            // 
            this.TxtNoPredio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtNoPredio.Location = new System.Drawing.Point(190, 74);
            this.TxtNoPredio.Name = "TxtNoPredio";
            this.TxtNoPredio.ReadOnly = true;
            this.TxtNoPredio.Size = new System.Drawing.Size(127, 20);
            this.TxtNoPredio.TabIndex = 450;
            // 
            // chkGuiaExterna
            // 
            this.chkGuiaExterna.AutoSize = true;
            this.chkGuiaExterna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGuiaExterna.ForeColor = System.Drawing.Color.LimeGreen;
            this.chkGuiaExterna.Location = new System.Drawing.Point(714, 85);
            this.chkGuiaExterna.Name = "chkGuiaExterna";
            this.chkGuiaExterna.Size = new System.Drawing.Size(101, 17);
            this.chkGuiaExterna.TabIndex = 451;
            this.chkGuiaExterna.Text = "Guía Externa";
            this.chkGuiaExterna.UseVisualStyleBackColor = true;
            this.chkGuiaExterna.Visible = false;
            this.chkGuiaExterna.CheckedChanged += new System.EventHandler(this.chkGuiaAntigua_CheckedChanged);
            // 
            // CmbTipoMaguey
            // 
            this.CmbTipoMaguey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbTipoMaguey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoMaguey.DropDownWidth = 300;
            this.CmbTipoMaguey.FormattingEnabled = true;
            this.CmbTipoMaguey.Location = new System.Drawing.Point(190, 19);
            this.CmbTipoMaguey.Name = "CmbTipoMaguey";
            this.CmbTipoMaguey.Size = new System.Drawing.Size(232, 21);
            this.CmbTipoMaguey.TabIndex = 452;
            this.CmbTipoMaguey.SelectedIndexChanged += new System.EventHandler(this.CmbTipoMaguey_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(71, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 18);
            this.label10.TabIndex = 453;
            this.label10.Text = "Tipo de Maguey:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // grpInformacionGeneral
            // 
            this.grpInformacionGeneral.Controls.Add(this.CmbFabrica);
            this.grpInformacionGeneral.Controls.Add(this.label38);
            this.grpInformacionGeneral.Controls.Add(this.TxtMaestroMezcalero);
            this.grpInformacionGeneral.Controls.Add(this.label39);
            this.grpInformacionGeneral.Location = new System.Drawing.Point(20, 15);
            this.grpInformacionGeneral.Name = "grpInformacionGeneral";
            this.grpInformacionGeneral.Size = new System.Drawing.Size(830, 70);
            this.grpInformacionGeneral.TabIndex = 454;
            this.grpInformacionGeneral.TabStop = false;
            this.grpInformacionGeneral.Text = "Información General";
            // 
            // grpSeleccionMaguey
            // 
            this.grpSeleccionMaguey.Controls.Add(this.CmbTipoMaguey);
            this.grpSeleccionMaguey.Controls.Add(this.chkGuiaExterna);
            this.grpSeleccionMaguey.Controls.Add(this.label10);
            this.grpSeleccionMaguey.Controls.Add(this.ChekMagueyComprado);
            this.grpSeleccionMaguey.Controls.Add(this.TxtNoPredio);
            this.grpSeleccionMaguey.Controls.Add(this.TxtNoGuia);
            this.grpSeleccionMaguey.Controls.Add(this.CmbNoPredio);
            this.grpSeleccionMaguey.Controls.Add(this.ChekAgaveSobrante);
            this.grpSeleccionMaguey.Controls.Add(this.label6);
            this.grpSeleccionMaguey.Controls.Add(this.label9);
            this.grpSeleccionMaguey.Controls.Add(this.TxtExistencia);
            this.grpSeleccionMaguey.Controls.Add(this.label5);
            this.grpSeleccionMaguey.Controls.Add(this.TxtExtraccion);
            this.grpSeleccionMaguey.Controls.Add(this.label1);
            this.grpSeleccionMaguey.Controls.Add(this.TxtPredio);
            this.grpSeleccionMaguey.Controls.Add(this.label2);
            this.grpSeleccionMaguey.Controls.Add(this.label3);
            this.grpSeleccionMaguey.Controls.Add(this.CmbMaguey);
            this.grpSeleccionMaguey.Location = new System.Drawing.Point(20, 96);
            this.grpSeleccionMaguey.Name = "grpSeleccionMaguey";
            this.grpSeleccionMaguey.Size = new System.Drawing.Size(830, 140);
            this.grpSeleccionMaguey.TabIndex = 455;
            this.grpSeleccionMaguey.TabStop = false;
            this.grpSeleccionMaguey.Text = "Selección de Maguey";
            // 
            // grpDatosProduccion
            // 
            this.grpDatosProduccion.Controls.Add(this.label4);
            this.grpDatosProduccion.Controls.Add(this.BtnAgregarProduccion);
            this.grpDatosProduccion.Controls.Add(this.TxtAgaveCoccion);
            this.grpDatosProduccion.Controls.Add(this.label12);
            this.grpDatosProduccion.Controls.Add(this.TxtArt);
            this.grpDatosProduccion.Controls.Add(this.TxtAgaveEntranteKg);
            this.grpDatosProduccion.Controls.Add(this.label8);
            this.grpDatosProduccion.Location = new System.Drawing.Point(20, 247);
            this.grpDatosProduccion.Name = "grpDatosProduccion";
            this.grpDatosProduccion.Size = new System.Drawing.Size(830, 84);
            this.grpDatosProduccion.TabIndex = 456;
            this.grpDatosProduccion.TabStop = false;
            this.grpDatosProduccion.Text = "Datos de Producción";
            // 
            // grpEnsambleActual
            // 
            this.grpEnsambleActual.Controls.Add(this.DtaEnsamble);
            this.grpEnsambleActual.Location = new System.Drawing.Point(20, 337);
            this.grpEnsambleActual.Name = "grpEnsambleActual";
            this.grpEnsambleActual.Size = new System.Drawing.Size(830, 200);
            this.grpEnsambleActual.TabIndex = 457;
            this.grpEnsambleActual.TabStop = false;
            this.grpEnsambleActual.Text = "Ensamble Actual";
            // 
            // grpConfiguracionFinal
            // 
            this.grpConfiguracionFinal.Controls.Add(this.CmbCoccion);
            this.grpConfiguracionFinal.Controls.Add(this.DataFechaInicioCoccion);
            this.grpConfiguracionFinal.Controls.Add(this.label13);
            this.grpConfiguracionFinal.Controls.Add(this.label14);
            this.grpConfiguracionFinal.Controls.Add(this.TxtTapada);
            this.grpConfiguracionFinal.Controls.Add(this.label15);
            this.grpConfiguracionFinal.Location = new System.Drawing.Point(20, 545);
            this.grpConfiguracionFinal.Name = "grpConfiguracionFinal";
            this.grpConfiguracionFinal.Size = new System.Drawing.Size(830, 79);
            this.grpConfiguracionFinal.TabIndex = 458;
            this.grpConfiguracionFinal.TabStop = false;
            this.grpConfiguracionFinal.Text = "Configuración Final";
            // 
            // FrmEnsamblePredio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 678);
            this.Controls.Add(this.lblNo_Usuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpInformacionGeneral);
            this.Controls.Add(this.grpSeleccionMaguey);
            this.Controls.Add(this.grpDatosProduccion);
            this.Controls.Add(this.grpEnsambleActual);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.grpConfiguracionFinal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEnsamblePredio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ensamble";
            this.Load += new System.EventHandler(this.FrmEnsamblePredio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtaEnsamble)).EndInit();
            this.grpInformacionGeneral.ResumeLayout(false);
            this.grpInformacionGeneral.PerformLayout();
            this.grpSeleccionMaguey.ResumeLayout(false);
            this.grpSeleccionMaguey.PerformLayout();
            this.grpDatosProduccion.ResumeLayout(false);
            this.grpDatosProduccion.PerformLayout();
            this.grpEnsambleActual.ResumeLayout(false);
            this.grpConfiguracionFinal.ResumeLayout(false);
            this.grpConfiguracionFinal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AplicarEstilosGroupBox()
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    groupBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
                    groupBox.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }
        }

        // Mejorar DataGridView
        private void MejorarDataGridView()
        {
            this.DtaEnsamble.BackgroundColor = System.Drawing.Color.White;
            this.DtaEnsamble.BorderStyle = BorderStyle.FixedSingle;
            this.DtaEnsamble.EnableHeadersVisualStyles = false;

            // Estilo para encabezados
            this.DtaEnsamble.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.DtaEnsamble.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DtaEnsamble.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);

            // Estilo para filas alternas
            this.DtaEnsamble.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
        }

        // Mejorar botones
        private void MejorarBotones()
        {
            this.BtnAgregarProduccion.FlatStyle = FlatStyle.Flat;
            this.BtnAgregarProduccion.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnAgregarProduccion.ForeColor = System.Drawing.Color.White;
            this.BtnAgregarProduccion.FlatAppearance.BorderSize = 0;

            this.BtnGuardar.FlatStyle = FlatStyle.Flat;
            this.BtnGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
        }

        private ToolTip toolTip;

        private void InicializarToolTips()
        {
            toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.CmbTipoMaguey, "Seleccione el tipo de maguey para el ensamble");
            toolTip.SetToolTip(this.TxtNoGuia, "Ingrese el número de guía o presione Enter para buscar");
            toolTip.SetToolTip(this.TxtArt, "Porcentaje ART (Azúcares Reductores Totales)");
            toolTip.SetToolTip(this.BtnAgregarProduccion, "Agregar maguey al ensamble actual");
            toolTip.SetToolTip(this.BtnGuardar, "Guardar ensamble completo");
        }

        private void ConfigurarValidacionesVisuales()
        {
            // Campos requeridos
            Color colorCampoRequerido = Color.LightCyan;

            this.TxtTapada.BackColor = colorCampoRequerido;
            this.CmbFabrica.BackColor = colorCampoRequerido;
            this.CmbCoccion.BackColor = colorCampoRequerido;
        }

        // Método para validar campos antes de guardar
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(TxtTapada.Text))
            {
                MessageBox.Show("El nombre de la tapada es requerido", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtTapada.Focus();
                return false;
            }

            if (CmbFabrica.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una fábrica", "Validación",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbFabrica.Focus();
                return false;
            }

            return true;
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
        private System.Windows.Forms.CheckBox chkGuiaExterna;
        private System.Windows.Forms.ComboBox CmbTipoMaguey;
        private System.Windows.Forms.Label label10;
        private GroupBox grpInformacionGeneral;
        private GroupBox grpSeleccionMaguey;
        private GroupBox grpDatosProduccion;
        private GroupBox grpEnsambleActual;
        private GroupBox grpConfiguracionFinal;
    }
}