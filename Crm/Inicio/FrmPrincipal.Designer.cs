namespace Crm.Inicio
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNameUser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnMinimizar = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnCambioUsuario = new System.Windows.Forms.Button();
            this.menu_lateral = new System.Windows.Forms.Panel();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnPlanDeTrabajo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExtraccionAgave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.BtnMensajes = new System.Windows.Forms.Button();
            this.BtnInventario = new System.Windows.Forms.Button();
            this.BtnConsulta = new System.Windows.Forms.Button();
            this.BtnSubida = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Lblcargandobase = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.LblSubiendo = new System.Windows.Forms.Label();
            this.backgroundWorker_Subida = new System.ComponentModel.BackgroundWorker();
            this.Panelcontainer = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.carga = new System.Windows.Forms.PictureBox();
            this.Progresbar = new iTalk_ProgressBar();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menu_lateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carga)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lblNameUser);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.BtnMinimizar);
            this.panel3.Controls.Add(this.BtnCerrar);
            this.panel3.Controls.Add(this.BtnCambioUsuario);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(250, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(861, 47);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Crm.Properties.Resources.Menu32_32;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(12, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 36);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Crm.Properties.Resources.agave__2_;
            this.pictureBox1.Location = new System.Drawing.Point(326, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lblNameUser
            // 
            this.lblNameUser.AllowDrop = true;
            this.lblNameUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameUser.AutoEllipsis = true;
            this.lblNameUser.BackColor = System.Drawing.SystemColors.Control;
            this.lblNameUser.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameUser.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNameUser.Location = new System.Drawing.Point(437, 15);
            this.lblNameUser.Name = "lblNameUser";
            this.lblNameUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNameUser.Size = new System.Drawing.Size(273, 18);
            this.lblNameUser.TabIndex = 19;
            this.lblNameUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(372, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "SInCa";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimizar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinimizar.FlatAppearance.BorderSize = 0;
            this.BtnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimizar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMinimizar.ForeColor = System.Drawing.Color.White;
            this.BtnMinimizar.Image = global::Crm.Properties.Resources.Minimizar32_32;
            this.BtnMinimizar.Location = new System.Drawing.Point(760, 3);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(35, 38);
            this.BtnMinimizar.TabIndex = 8;
            this.BtnMinimizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMinimizar.UseVisualStyleBackColor = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
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
            this.BtnCerrar.Image = global::Crm.Properties.Resources.Cerrar32_32;
            this.BtnCerrar.Location = new System.Drawing.Point(801, 3);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(35, 38);
            this.BtnCerrar.TabIndex = 6;
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // BtnCambioUsuario
            // 
            this.BtnCambioUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCambioUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCambioUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCambioUsuario.FlatAppearance.BorderSize = 0;
            this.BtnCambioUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnCambioUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnCambioUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCambioUsuario.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambioUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnCambioUsuario.Image = global::Crm.Properties.Resources.Cambio_Sesion32_32;
            this.BtnCambioUsuario.Location = new System.Drawing.Point(715, 3);
            this.BtnCambioUsuario.Name = "BtnCambioUsuario";
            this.BtnCambioUsuario.Size = new System.Drawing.Size(44, 41);
            this.BtnCambioUsuario.TabIndex = 7;
            this.BtnCambioUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCambioUsuario.UseVisualStyleBackColor = false;
            this.BtnCambioUsuario.Click += new System.EventHandler(this.BtnCambioUsuario_Click);
            // 
            // menu_lateral
            // 
            this.menu_lateral.BackColor = System.Drawing.Color.SteelBlue;
            this.menu_lateral.Controls.Add(this.btnAdministrador);
            this.menu_lateral.Controls.Add(this.label2);
            this.menu_lateral.Controls.Add(this.BtnPlanDeTrabajo);
            this.menu_lateral.Controls.Add(this.label1);
            this.menu_lateral.Controls.Add(this.BtnExtraccionAgave);
            this.menu_lateral.Controls.Add(this.button1);
            this.menu_lateral.Controls.Add(this.btnBitacora);
            this.menu_lateral.Controls.Add(this.BtnMensajes);
            this.menu_lateral.Controls.Add(this.BtnInventario);
            this.menu_lateral.Controls.Add(this.BtnConsulta);
            this.menu_lateral.Controls.Add(this.BtnSubida);
            this.menu_lateral.Controls.Add(this.BtnActualizar);
            this.menu_lateral.Controls.Add(this.pictureBox3);
            this.menu_lateral.Controls.Add(this.pictureBox5);
            this.menu_lateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu_lateral.Location = new System.Drawing.Point(0, 0);
            this.menu_lateral.Name = "menu_lateral";
            this.menu_lateral.Size = new System.Drawing.Size(250, 788);
            this.menu_lateral.TabIndex = 18;
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdministrador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministrador.FlatAppearance.BorderSize = 0;
            this.btnAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrador.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrador.ForeColor = System.Drawing.Color.White;
            this.btnAdministrador.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministrador.Image")));
            this.btnAdministrador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministrador.Location = new System.Drawing.Point(3, 691);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(246, 45);
            this.btnAdministrador.TabIndex = 23;
            this.btnAdministrador.Text = "Administrador";
            this.btnAdministrador.UseVisualStyleBackColor = false;
            this.btnAdministrador.Visible = false;
            this.btnAdministrador.Click += new System.EventHandler(this.btnAdministrador_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(89, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "SInCa v3.02.23";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BtnPlanDeTrabajo
            // 
            this.BtnPlanDeTrabajo.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnPlanDeTrabajo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPlanDeTrabajo.FlatAppearance.BorderSize = 0;
            this.BtnPlanDeTrabajo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.BtnPlanDeTrabajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlanDeTrabajo.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlanDeTrabajo.ForeColor = System.Drawing.Color.White;
            this.BtnPlanDeTrabajo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPlanDeTrabajo.Location = new System.Drawing.Point(4, 444);
            this.BtnPlanDeTrabajo.Name = "BtnPlanDeTrabajo";
            this.BtnPlanDeTrabajo.Size = new System.Drawing.Size(246, 45);
            this.BtnPlanDeTrabajo.TabIndex = 4;
            this.BtnPlanDeTrabajo.Text = "Plan de Trabajo";
            this.BtnPlanDeTrabajo.UseVisualStyleBackColor = false;
            this.BtnPlanDeTrabajo.Visible = false;
            this.BtnPlanDeTrabajo.Click += new System.EventHandler(this.BtnPlanDeTrabajo_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(201, 70);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(31, 18);
            this.label1.TabIndex = 20;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // BtnExtraccionAgave
            // 
            this.BtnExtraccionAgave.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnExtraccionAgave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExtraccionAgave.FlatAppearance.BorderSize = 0;
            this.BtnExtraccionAgave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.BtnExtraccionAgave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExtraccionAgave.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExtraccionAgave.ForeColor = System.Drawing.Color.White;
            this.BtnExtraccionAgave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExtraccionAgave.Location = new System.Drawing.Point(4, 514);
            this.BtnExtraccionAgave.Name = "BtnExtraccionAgave";
            this.BtnExtraccionAgave.Size = new System.Drawing.Size(246, 45);
            this.BtnExtraccionAgave.TabIndex = 5;
            this.BtnExtraccionAgave.Text = "Extraccion de Maguey";
            this.BtnExtraccionAgave.UseVisualStyleBackColor = false;
            this.BtnExtraccionAgave.Visible = false;
            this.BtnExtraccionAgave.Click += new System.EventHandler(this.BtnExtraccionAgave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(4, 567);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "Informe de producto";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBitacora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBitacora.FlatAppearance.BorderSize = 0;
            this.btnBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitacora.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBitacora.ForeColor = System.Drawing.Color.White;
            this.btnBitacora.Image = ((System.Drawing.Image)(resources.GetObject("btnBitacora.Image")));
            this.btnBitacora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBitacora.Location = new System.Drawing.Point(4, 629);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(246, 45);
            this.btnBitacora.TabIndex = 11;
            this.btnBitacora.Text = "Bitácora";
            this.btnBitacora.UseVisualStyleBackColor = false;
            this.btnBitacora.Visible = false;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // BtnMensajes
            // 
            this.BtnMensajes.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnMensajes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMensajes.FlatAppearance.BorderSize = 0;
            this.BtnMensajes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.BtnMensajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMensajes.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMensajes.ForeColor = System.Drawing.Color.White;
            this.BtnMensajes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMensajes.Location = new System.Drawing.Point(4, 386);
            this.BtnMensajes.Name = "BtnMensajes";
            this.BtnMensajes.Size = new System.Drawing.Size(246, 45);
            this.BtnMensajes.TabIndex = 9;
            this.BtnMensajes.Text = "Mensaje";
            this.BtnMensajes.UseVisualStyleBackColor = false;
            this.BtnMensajes.Visible = false;
            this.BtnMensajes.Click += new System.EventHandler(this.BtnMensajes_Click);
            // 
            // BtnInventario
            // 
            this.BtnInventario.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnInventario.FlatAppearance.BorderSize = 0;
            this.BtnInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BtnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInventario.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInventario.ForeColor = System.Drawing.Color.White;
            this.BtnInventario.Image = global::Crm.Properties.Resources.warehouse;
            this.BtnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInventario.Location = new System.Drawing.Point(4, 209);
            this.BtnInventario.Name = "BtnInventario";
            this.BtnInventario.Size = new System.Drawing.Size(246, 45);
            this.BtnInventario.TabIndex = 7;
            this.BtnInventario.Text = " Inventario";
            this.BtnInventario.UseMnemonic = false;
            this.BtnInventario.UseVisualStyleBackColor = false;
            this.BtnInventario.Click += new System.EventHandler(this.BtnInventario_Click);
            // 
            // BtnConsulta
            // 
            this.BtnConsulta.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnConsulta.FlatAppearance.BorderSize = 0;
            this.BtnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BtnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConsulta.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsulta.ForeColor = System.Drawing.Color.White;
            this.BtnConsulta.Image = global::Crm.Properties.Resources.icon__2_;
            this.BtnConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConsulta.Location = new System.Drawing.Point(4, 325);
            this.BtnConsulta.Name = "BtnConsulta";
            this.BtnConsulta.Size = new System.Drawing.Size(246, 45);
            this.BtnConsulta.TabIndex = 8;
            this.BtnConsulta.Text = "Consulta";
            this.BtnConsulta.UseVisualStyleBackColor = false;
            this.BtnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // BtnSubida
            // 
            this.BtnSubida.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSubida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSubida.FlatAppearance.BorderSize = 0;
            this.BtnSubida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BtnSubida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubida.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubida.ForeColor = System.Drawing.Color.White;
            this.BtnSubida.Image = global::Crm.Properties.Resources.upload;
            this.BtnSubida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubida.Location = new System.Drawing.Point(4, 260);
            this.BtnSubida.Name = "BtnSubida";
            this.BtnSubida.Size = new System.Drawing.Size(246, 45);
            this.BtnSubida.TabIndex = 6;
            this.BtnSubida.Text = "Subida";
            this.BtnSubida.UseVisualStyleBackColor = false;
            this.BtnSubida.Click += new System.EventHandler(this.BtnSubida_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnActualizar.FlatAppearance.BorderSize = 0;
            this.BtnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.ForeColor = System.Drawing.Color.White;
            this.BtnActualizar.Image = global::Crm.Properties.Resources.repeat__1_;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(4, 156);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(246, 45);
            this.BtnActualizar.TabIndex = 3;
            this.BtnActualizar.Text = "Actualizar BD";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = global::Crm.Properties.Resources.agave__2_;
            this.pictureBox3.Location = new System.Drawing.Point(22, 47);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Crm.Properties.Resources.Menu32_32;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Location = new System.Drawing.Point(3, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(39, 36);
            this.pictureBox5.TabIndex = 21;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // Lblcargandobase
            // 
            this.Lblcargandobase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lblcargandobase.AutoSize = true;
            this.Lblcargandobase.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblcargandobase.Location = new System.Drawing.Point(348, 535);
            this.Lblcargandobase.Name = "Lblcargandobase";
            this.Lblcargandobase.Size = new System.Drawing.Size(313, 18);
            this.Lblcargandobase.TabIndex = 104;
            this.Lblcargandobase.Text = "Actualizando base de datos por favor espere ......";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // LblSubiendo
            // 
            this.LblSubiendo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblSubiendo.AutoSize = true;
            this.LblSubiendo.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubiendo.Location = new System.Drawing.Point(486, 535);
            this.LblSubiendo.Name = "LblSubiendo";
            this.LblSubiendo.Size = new System.Drawing.Size(175, 18);
            this.LblSubiendo.TabIndex = 110;
            this.LblSubiendo.Text = "Subiendo información ......";
            // 
            // backgroundWorker_Subida
            // 
            this.backgroundWorker_Subida.WorkerReportsProgress = true;
            this.backgroundWorker_Subida.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Subida_DoWork);
            this.backgroundWorker_Subida.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_Subida_ProgressChanged);
            this.backgroundWorker_Subida.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Subida_RunWorkerCompleted);
            // 
            // Panelcontainer
            // 
            this.Panelcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panelcontainer.Location = new System.Drawing.Point(250, 47);
            this.Panelcontainer.Name = "Panelcontainer";
            this.Panelcontainer.Padding = new System.Windows.Forms.Padding(3);
            this.Panelcontainer.Size = new System.Drawing.Size(861, 741);
            this.Panelcontainer.TabIndex = 112;
            this.Panelcontainer.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::Crm.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(348, 298);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(415, 193);
            this.pictureBox2.TabIndex = 106;
            this.pictureBox2.TabStop = false;
            // 
            // carga
            // 
            this.carga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.carga.Image = global::Crm.Properties.Resources.loader;
            this.carga.Location = new System.Drawing.Point(478, 133);
            this.carga.Name = "carga";
            this.carga.Size = new System.Drawing.Size(155, 159);
            this.carga.TabIndex = 109;
            this.carga.TabStop = false;
            // 
            // Progresbar
            // 
            this.Progresbar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Progresbar.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.Progresbar.Location = new System.Drawing.Point(662, 496);
            this.Progresbar.Maximum = ((long)(100));
            this.Progresbar.MinimumSize = new System.Drawing.Size(100, 100);
            this.Progresbar.Name = "Progresbar";
            this.Progresbar.ProgressColor1 = System.Drawing.Color.Green;
            this.Progresbar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.Progresbar.ProgressShape = iTalk_ProgressBar._ProgressShape.Round;
            this.Progresbar.Size = new System.Drawing.Size(100, 100);
            this.Progresbar.TabIndex = 107;
            this.Progresbar.Text = "iTalk_ProgressBar1";
            this.Progresbar.Value = ((long)(0));
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1111, 788);
            this.Controls.Add(this.Panelcontainer);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Progresbar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.carga);
            this.Controls.Add(this.LblSubiendo);
            this.Controls.Add(this.Lblcargandobase);
            this.Controls.Add(this.menu_lateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menu_lateral.ResumeLayout(false);
            this.menu_lateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnMinimizar;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Button BtnCambioUsuario;
        private System.Windows.Forms.Panel menu_lateral;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnPlanDeTrabajo;
        private System.Windows.Forms.Button BtnExtraccionAgave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnSubida;
        private System.Windows.Forms.Label Lblcargandobase;
        private System.Windows.Forms.PictureBox pictureBox2;
        private iTalk_ProgressBar Progresbar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.PictureBox carga;
        private System.Windows.Forms.Button BtnInventario;
        private System.Windows.Forms.Label LblSubiendo;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Subida;
        private System.Windows.Forms.Button BtnConsulta;
        private System.Windows.Forms.Button BtnMensajes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Panelcontainer;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Label lblNameUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Label label1;
    }
}