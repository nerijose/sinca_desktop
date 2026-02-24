using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crm.Utilerias;
using Crm.functions;
using System.Runtime.InteropServices;
using System.Reflection.Emit;

namespace Crm.Inventario
{
    public partial class FrmInstalaciones : Form
    {
        public FrmInstalaciones()
        {
            InitializeComponent();
        }
        public string no_cliente;
        public string id_solicitud;
        public int tipo_dictaminacion;
        public int di_solicitud;
        public String codigo;
        public string parcial;
        public int caso;
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        string prueba = "l";

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        /*private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }*/

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInstalaciones_Click(object sender, EventArgs e)
        {
            mostrarInicio();
        }

        public void actualizar(String sol)
        {
            //di_solicitud=sol;
            /*prueba = sol;
            MessageBox.Show(di_solicitud+"  "+ prueba);
            btnInstalaciones.Text = sol;*/
        }

        public Boolean verificar_guardado()
        {
            Boolean resultado = true;
            /*Console.WriteLine("Select id FROM sinca.`di_solicitud` WHERE codigo = '" + codigo + "'");
            //String guardado = ConexionMysql.regresaCampoConsulta("Select guardado FROM sinca.`di_solicitud` WHERE <>0");
            String guardado = Convert.ToString(ConexionMysql.regresaCampoConsulta("Select id FROM sinca.`di_solicitud` WHERE codigo='" + codigo + "'"));
            Console.WriteLine(guardado);
            if (caso == 0 && guardado == "") {
                resultado = false;
            }*/

            return resultado;
        }

        public void mostrarInicio()
        {
            if (verificar_guardado())
            {
                //brirFormulario<FrmListaInstalaciones>();
                btnInstalaciones.BackColor = Color.FromArgb(12, 61, 92);
                btnInforme.BackColor = Color.FromArgb(4, 41, 68);
                btnActaApertura.BackColor = Color.FromArgb(4, 41, 68);
                btnBuenasPracticas.BackColor = Color.FromArgb(4, 41, 68);
                btnActaCierre.BackColor = Color.FromArgb(4, 41, 68);
                //lblTituloInstalacion.Text = "Generar Documentos";

                FrmListaInstalaciones formulario;
                formulario = new FrmListaInstalaciones();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.no_cliente = no_cliente;
                formulario.codigo = codigo;
                formulario.id_solicitud = id_solicitud;
                formulario.di_solicitud = di_solicitud;
                formulario.tipo_dictaminacion = tipo_dictaminacion;
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
                formulario.Show();
            }
        }

        /*private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }*/

        private void btnInforme_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<FrmDictamen>();
            //Informe
            if (verificar_guardado())
            {
                btnInforme.BackColor = Color.FromArgb(12, 61, 92);
                btnInstalaciones.BackColor = Color.FromArgb(4, 41, 68);
                btnActaApertura.BackColor = Color.FromArgb(4, 41, 68);
                btnBuenasPracticas.BackColor = Color.FromArgb(4, 41, 68);
                btnActaCierre.BackColor = Color.FromArgb(4, 41, 68);
                //lblTituloInstalacion.Text = "Informe para dictamen de Instalaciones";

                FrmDictamen formulario;
                formulario = new FrmDictamen();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.no_cliente = no_cliente;
                formulario.id_solicitud = id_solicitud;
                formulario.di_solicitud = di_solicitud;
                formulario.codigo = codigo;
                formulario.tipo_dictaminacion = tipo_dictaminacion;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                MessageBox.Show("Debes guardar los datos de la apertura de acta para poder continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void FrmInstalaciones_Load(object sender, EventArgs e)
        {
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            cargar_acta();
        }

        private void cargar_acta()
        {
            //Apertura de acta
            btnActaApertura.BackColor = Color.FromArgb(12, 61, 92);
            btnInstalaciones.BackColor = Color.FromArgb(4, 41, 68);
            btnInforme.BackColor = Color.FromArgb(4, 41, 68);
            btnBuenasPracticas.BackColor = Color.FromArgb(4, 41, 68);
            btnActaCierre.BackColor = Color.FromArgb(4, 41, 68);
            //lblTituloInstalacion.Text = "Apertura de Acta";

            FrmActaDetallada formulario;
            formulario = new FrmActaDetallada();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelformularios.Controls.Add(formulario);
            panelformularios.Tag = formulario;
            formulario.no_cliente = no_cliente;
            formulario.codigo = codigo;
            formulario.di_solicitud = di_solicitud;
            formulario.id_solicitud = id_solicitud;
            formulario.tipo_dictaminacion = tipo_dictaminacion;
            formulario.Show();
            formulario.BringToFront();
            formulario.FormClosed += new FormClosedEventHandler(CloseForms);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //buenas practicas
            if (verificar_guardado())
            {
                btnBuenasPracticas.BackColor = Color.FromArgb(12, 61, 92);
                btnInstalaciones.BackColor = Color.FromArgb(4, 41, 68);
                btnInforme.BackColor = Color.FromArgb(4, 41, 68);
                btnActaApertura.BackColor = Color.FromArgb(4, 41, 68);
                btnActaCierre.BackColor = Color.FromArgb(4, 41, 68);
                //lblTituloInstalacion.Text = "Buenas Practicas de Manufactura";

                FrmBuenasPracticas formulario;
                formulario = new FrmBuenasPracticas();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.no_cliente = no_cliente;
                formulario.codigo = codigo;
                formulario.id_solicitud = id_solicitud;
                formulario.di_solicitud = di_solicitud;
                formulario.tipo_dictaminacion = tipo_dictaminacion;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                MessageBox.Show("Debes guardar los datos de la apertura de acta para poder continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            //Cierre acta
            if (verificar_guardado())
            {
                btnActaCierre.BackColor = Color.FromArgb(12, 61, 92);
                btnInstalaciones.BackColor = Color.FromArgb(4, 41, 68);
                btnInforme.BackColor = Color.FromArgb(4, 41, 68);
                btnBuenasPracticas.BackColor = Color.FromArgb(4, 41, 68);
                btnActaApertura.BackColor = Color.FromArgb(4, 41, 68);
                //lblTituloInstalacion.Text = "Cierre de Acta";

                FrmCierreActaDetallado formulario;
                formulario = new FrmCierreActaDetallado();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.no_cliente = no_cliente;
                formulario.codigo = codigo;
                formulario.id_solicitud = id_solicitud;
                formulario.di_solicitud = di_solicitud;
                formulario.tipo_dictaminacion = tipo_dictaminacion;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                MessageBox.Show("Debes guardar los datos de la apertura de acta para poder continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            /*btnInstalaciones.BackColor = Color.FromArgb(4, 41, 68);
            btnInforme.BackColor = Color.FromArgb(4, 41, 68);
            btnActa.BackColor = Color.FromArgb(4, 41, 68);
            btnBuenas.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["FrmListaInstalaciones"] == null)
                btnInstalaciones.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["FrmDictamen"] == null)
                btnInforme.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["FrmActaDetallada"] == null)
                btnActa.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["FrmBuenasPracticas"] == null)
                btnBuenas.BackColor = Color.FromArgb(4, 41, 68);*/
        }

    }
}
