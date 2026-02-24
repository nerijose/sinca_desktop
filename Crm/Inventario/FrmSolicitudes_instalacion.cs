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
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using Crm.Inventario;
using System.Reflection;

namespace Crm
{
    public partial class FrmSolicitudes_instalacion : Form
    {
        public FrmSolicitudes_instalacion()
        {
            InitializeComponent();
        }
        public string no_cliente;
        public string id_solicitud;
        DataSet dtsDatosSolicitudes;
        DataSet dtsDatosHistorial;
        DataSet dtsDatos;
        public string di_solicitud;

        private void FrmSolicitudes_instalacion_Load(object sender, EventArgs e)
        {
            /*ConexionMysql.llenaCombo(ref CmbNoClienteEnvasado, "SELECT no_cliente FROM clientes", "no_cliente", "no_cliente");


            if (Usuario.No_Cliente != "0")
            {
                CmbNoClienteEnvasado.SelectedValue = Usuario.No_Cliente;
            }
            ConexionMysql.llenaCombo(ref CmbUnidadDeMedida, "SELECT  distinct medida FROM cat_presentacion", "medida", "medida");
            tabControl4.SelectedTab = tabPage14;*/
            TxTNoClienteSeleccion.Focus();

            try {
                ConexionMysql.conecta();
                AutoCompleteStringCollection ListaClientes = new AutoCompleteStringCollection();
                DataSet DatosClientes = new DataSet();
                ConexionMysql.llenaDataset(ref DatosClientes, "select no_cliente from clientes ");
                foreach (DataRow row in DatosClientes.Tables[0].Rows)
                {
                    ListaClientes.Add(row[0].ToString());
                }
                TxTNoClienteSeleccion.AutoCompleteCustomSource = ListaClientes;
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            
            //addTablaSolicitudes();
            mostrarSolicitudes();
            mostrarSolicitudesProceso();

        }

        private void iTalk_Label1_Click(object sender, EventArgs e)
        {

        }

        private void addTablaSolicitudes()
        {
            dtsDatosSolicitudes = new DataSet();
            dtsDatosSolicitudes.Tables.Add("SOLICITUDES");
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("NUM. SOLICITUD", Type.GetType("System.String"));
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("ID", Type.GetType("System.String"));
            //dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("PARCIAL", Type.GetType("System.String"));
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("CLIENTE", Type.GetType("System.String"));
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("RAZÓN SOCIAL", Type.GetType("System.String"));
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("FECHA PROGRAMADA", Type.GetType("System.String"));
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Columns.Add("CONTINUAR", Type.GetType("System.Byte[]"));
            dgSolicitudes.DataSource = dtsDatosSolicitudes.Tables["SOLICITUDES"];
            dgSolicitudes.Columns[1].Visible = false;
            //dgSolicitudes.Columns[2].Visible = false;
            dgSolicitudes.Columns[4].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT s.id_solicitud,s.num_solicitud,s.fecha,s.cliente,s.razon_social, UPPER(s.nombre_solicitud), s.fecha_programada, s.estatus, (SELECT status FROM sinca.di_solicitud WHERE id_solicitud=s.id_solicitud LIMIT 1) as sta FROM sinca.sol_ocui s LEFT JOIN(SELECT id_solicitud,COUNT(id) as num FROM sinca.sol_ocui_docs WHERE descargado = 'S' GROUP BY id_solicitud) AS success ON success.id_solicitud = s.id_solicitud LEFT JOIN( SELECT id_solicitud,COUNT(id) as num FROM sinca.sol_ocui_docs WHERE descargado <> 'S' GROUP BY id_solicitud) AS fail ON fail.id_solicitud = s.id_solicitud WHERE s.nombre_solicitud LIKE '%DICTAMEN DE INSTALACIÓN Y SEGUIMIENTO%' AND s.cliente='" + no_cliente + "' AND ((SELECT status FROM sinca.di_solicitud WHERE id_solicitud=s.id_solicitud LIMIT 1) IS NULL || s.parcial=1) ORDER BY s.fecha_programada DESC");
            DataRow fila;
            dtsDatosSolicitudes.Tables["SOLICITUDES"].Rows.Clear();
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                fila = dtsDatosSolicitudes.Tables["SOLICITUDES"].NewRow();
                fila["NUM. SOLICITUD"] = Convert.ToString(row["num_solicitud"]);
                fila["ID"] = Convert.ToString(row["id_solicitud"]);
                //fila["DI_SOLICITUD"] = Convert.ToString(row["id_solicitud"]);
                fila["CLIENTE"] = Convert.ToString(row["cliente"]);
                fila["RAZÓN SOCIAL"] = Convert.ToString(row["razon_social"]);
                fila["FECHA"] = Convert.ToString(row["fecha"]);
                fila["FECHA PROGRAMADA"] = Convert.ToString(row["fecha_programada"]);
                fila["CONTINUAR"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                dtsDatosSolicitudes.Tables["SOLICITUDES"].Rows.Add(fila);
            }
            
        }

        private void mostrarSolicitudesProceso()
        {
            dtsDatos = new DataSet();
            dtsDatos.Tables.Add("SOLICITUDES_P");
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("NUM. SOLICITUD", Type.GetType("System.String"));
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("ID", Type.GetType("System.String"));
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("ID_SOLICITUD", Type.GetType("System.String"));
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("CLIENTE", Type.GetType("System.String"));
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("RAZÓN SOCIAL", Type.GetType("System.String"));
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("FECHA REGISTRO", Type.GetType("System.String"));
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("TIPO DICTAMINACION", Type.GetType("System.String"));
            dtsDatos.Tables["SOLICITUDES_P"].Columns.Add("CONTINUAR", Type.GetType("System.Byte[]"));
            dgvContinuarSolicitud.DataSource = dtsDatos.Tables["SOLICITUDES_P"];
            dgvContinuarSolicitud.Columns[1].Visible = false;
            dgvContinuarSolicitud.Columns[2].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,s.solicitud,s.fecha_registro,s.no_control,s.id_solicitud,s.razon_social, tipo_dictaminacion, status " +
                "FROM sinca.di_solicitud s WHERE s.status=1 ORDER BY s.id DESC");
            DataRow fila;
            dtsDatos.Tables["SOLICITUDES_P"].Rows.Clear();

            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                String tipo = "";
                switch (Convert.ToString(row["tipo_dictaminacion"]))
                {
                    case "1":
                        tipo = "CON NO. SOLICITUD Y NO. CLIENTE";
                        break;
                    case "2":
                        tipo = "CON NO. CLIENTE";
                        break;
                    case "3":
                        tipo = "SIN DATOS";
                        break;
                    default:
                        break;
                }

                fila = dtsDatos.Tables["SOLICITUDES_P"].NewRow();
                fila["NUM. SOLICITUD"] = Convert.ToString(row["solicitud"]);
                fila["ID"] = Convert.ToString(row["id"]);
                fila["ID_SOLICITUD"] = Convert.ToString(row["id_solicitud"]);
                fila["CLIENTE"] = Convert.ToString(row["no_control"]);
                fila["RAZÓN SOCIAL"] = Convert.ToString(row["razon_social"]);
                fila["FECHA REGISTRO"] = Convert.ToString(row["fecha_registro"]);
                fila["TIPO DICTAMINACION"] = tipo;
                fila["CONTINUAR"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                dtsDatos.Tables["SOLICITUDES_P"].Rows.Add(fila);
            }

        }

        private void mostrarSolicitudes()
        {
            dtsDatosHistorial = new DataSet();
            dtsDatosHistorial.Tables.Add("SOLICITUDES_H");
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Columns.Add("NUM. SOLICITUD", Type.GetType("System.String"));
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Columns.Add("ID", Type.GetType("System.String"));
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Columns.Add("CLIENTE", Type.GetType("System.String"));
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Columns.Add("RAZÓN SOCIAL", Type.GetType("System.String"));
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Columns.Add("FECHA REGISTRO", Type.GetType("System.String"));
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Columns.Add("TIPO DICTAMINACION", Type.GetType("System.String"));
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Columns.Add("VER", Type.GetType("System.Byte[]"));
            dgvHistorial.DataSource = dtsDatosHistorial.Tables["SOLICITUDES_H"];
            dgvHistorial.Columns[1].Visible = false;
            //dgvHistorial.Columns[2].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,s.solicitud,s.fecha_registro,s.no_control,s.razon_social, tipo_dictaminacion, status " +
                "FROM sinca.di_solicitud s WHERE s.status=2");
            DataRow fila;
            dtsDatosHistorial.Tables["SOLICITUDES_H"].Rows.Clear();

            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                String tipo = "";
               switch (Convert.ToString(row["tipo_dictaminacion"]))
                {
                    case "1":
                        tipo = "CON NO. SOLICITUD Y NO. CLIENTE";
                        break;
                    case "2":
                         tipo = "CON NO. CLIENTE";
                        break;
                    case "3":
                         tipo = "SIN DATOS";
                        break;
                    default:
                        break;
                }

                fila = dtsDatosHistorial.Tables["SOLICITUDES_H"].NewRow();
                fila["NUM. SOLICITUD"] = Convert.ToString(row["solicitud"]);
                fila["ID"] = Convert.ToString(row["id"]);
                fila["CLIENTE"] = Convert.ToString(row["no_control"]);
                fila["RAZÓN SOCIAL"] = Convert.ToString(row["razon_social"]);
                fila["FECHA REGISTRO"] = Convert.ToString(row["fecha_registro"]);
                fila["TIPO DICTAMINACION"] = tipo;
                fila["VER"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                dtsDatosHistorial.Tables["SOLICITUDES_H"].Rows.Add(fila);
            }

        }
        public static byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
            return Ret;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private String codigo()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        private void dgSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgSolicitudes.Columns[e.ColumnIndex].Name == "CONTINUAR")
                {
                    FrmInstalaciones frm = new FrmInstalaciones();
                    frm.no_cliente = no_cliente;
                    frm.tipo_dictaminacion = 1;
                    frm.id_solicitud = dgSolicitudes.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    frm.caso = 0;
                    frm.codigo = codigo();
                    frm.di_solicitud = 0;
                    frm.parcial= "0";
                    frm.ShowDialog();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*if (Usuario.No_Cliente == "0")
            {
                MessageBox.Show("No has seleccionado un cliente");
                TxTNoClienteSeleccion.Focus();
                return;
            }*/
        private void TxTNoClienteSeleccion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ConexionMysql.conecta();
                if (e.KeyCode == Keys.Enter)
                {
                    lblRazonSocial.Text = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM  clientes  WHERE no_cliente='" + TxTNoClienteSeleccion.Text + "'");
                    if (TxTNoClienteSeleccion.Text == "")
                    {
                        MessageBox.Show("Numero de cliente no encontrado");
                        lblRazonSocial.Text = "......";
                    }
                    else
                    {
                        Usuario.No_Cliente = TxTNoClienteSeleccion.Text;
                        no_cliente = TxTNoClienteSeleccion.Text;
                        addTablaSolicitudes();
                    }
                }
                else
                {
                    lblRazonSocial.Text = "......";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSinSolicitud_Click(object sender, EventArgs e)
        {
            if (Usuario.No_Cliente == "0" || TxTNoClienteSeleccion.Text == "")
            {
                MessageBox.Show("No has seleccionado un cliente");
                TxTNoClienteSeleccion.Focus();
            }
            else
            {
                FrmInstalaciones frm = new FrmInstalaciones();
                frm.no_cliente = TxTNoClienteSeleccion.Text;
                frm.tipo_dictaminacion = 3;
                frm.id_solicitud = "0";
                frm.caso = 0;
                frm.codigo=codigo();
                frm.di_solicitud = 0;
                frm.ShowDialog();
                frm.parcial = "0";
                this.Close();
            }
            
        }

        private void btnSinCliente_Click(object sender, EventArgs e)
        {
            FrmInstalaciones frm = new FrmInstalaciones();
            frm.no_cliente = "0";
            frm.tipo_dictaminacion = 2;
            frm.id_solicitud = "0";
            frm.caso = 0;
            frm.di_solicitud = 0;
            frm.codigo = codigo();
            frm.parcial = "0";
            frm.ShowDialog();
            this.Close();
        }

        private void TxTNoClienteSeleccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvHistorial.Columns[e.ColumnIndex].Name == "CONTINUAR")
                {
                    FrmInstalaciones frm = new FrmInstalaciones();
                    frm.no_cliente = no_cliente;
                    frm.tipo_dictaminacion = 1;
                    frm.id_solicitud = dgvHistorial.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    frm.di_solicitud = int.Parse(dgvHistorial.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    frm.caso = 0;
                    //frm.di_solicitud = dgSolicitudes.Rows[e.RowIndex].Cells["DI_SOLICITUD"].Value.ToString();
                    frm.ShowDialog();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvContinuarSolicitud_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvContinuarSolicitud.Columns[e.ColumnIndex].Name == "CONTINUAR")
                {
                    FrmInstalaciones frm = new FrmInstalaciones();
                    frm.no_cliente = dgvContinuarSolicitud.Rows[e.RowIndex].Cells["CLIENTE"].Value.ToString(); ;
                    frm.tipo_dictaminacion = 1;
                    frm.id_solicitud = dgvContinuarSolicitud.Rows[e.RowIndex].Cells["ID_SOLICITUD"].Value.ToString();
                    frm.di_solicitud = int.Parse(dgvContinuarSolicitud.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    frm.caso = 0;
                    //frm.di_solicitud = dgSolicitudes.Rows[e.RowIndex].Cells["DI_SOLICITUD"].Value.ToString();
                    frm.ShowDialog();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
