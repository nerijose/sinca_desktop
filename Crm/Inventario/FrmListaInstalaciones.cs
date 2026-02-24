using System;
using System.Data;
using System.Windows.Forms;
using Crm.Utilerias;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace Crm.Inventario
{
    public partial class FrmListaInstalaciones : Form
    {
        public string no_cliente;
        public string id_solicitud;
        public int tipo_dictaminacion;
        public int di_solicitud;
        public String codigo;
        DataSet dtsInstalaciones;
        public string doc_bp,doc_acta,doc_informe;
        public FrmListaInstalaciones()
        {
            InitializeComponent();
        }

        private void FrmListaInstalaciones_Load(object sender, EventArgs e)
        {
            DataSet Datos2 = new DataSet();
            if (di_solicitud == 0)
            {
                //di_solicitud = int.Parse(ConexionMysql.regresaCampoConsulta("Select id FROM sinca.`di_solicitud` WHERE codigo='" + codigo + "'"));
                ConexionMysql.llenaDataset(ref Datos2, "Select id FROM sinca.`di_solicitud` WHERE codigo='" + codigo + "'");

                foreach (DataRow row in Datos2.Tables[0].Rows)
                {
                    di_solicitud = int.Parse(Convert.ToString(row["id"]));
                }
            }
            addTablaInstalaciones();
            verificar_documentos();
        }
        private void verificar_documentos()
        {
            DataSet Datos2 = new DataSet();
            ConexionMysql.llenaDataset(ref Datos2, "SELECT `doc_bp`,`doc_acta`,`doc_informe` FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "' LIMIT 1");

            foreach (DataRow row in Datos2.Tables[0].Rows)
            {
                doc_bp = Convert.ToString(row["doc_bp"]);
                doc_acta = Convert.ToString(row["doc_acta"]);
                doc_informe = Convert.ToString(row["doc_informe"]);
            }

            if (doc_bp != "1")
            {
                btnVerBuenasPracticas.Hide();
            }
            if (doc_acta != "1")
            {
                btnVerActa.Hide();
            }
            if (doc_informe != "1")
            {
                btnVerInforme.Hide();
            }
        }

        private void addTablaInstalaciones()
        {
            dtsInstalaciones = new DataSet();
            dtsInstalaciones.Tables.Add("INSTALACIONES");
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("TIPO", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("ID", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("ALIAS", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("CALLE", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("NUM.", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("COLONIA", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("MUNICIPIO", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("ESTADO", Type.GetType("System.String"));
            dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("RESPONSABLE", Type.GetType("System.String"));
            //dtsInstalaciones.Tables["INSTALACIONES"].Columns.Add("EDITAR", Type.GetType("System.Byte[]"));
            dgvInstalacionesSolicitud.DataSource = dtsInstalaciones.Tables["INSTALACIONES"];
            dgvInstalacionesSolicitud.Columns[1].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT i.`id`, `tipo`, `alias`, `calle`, `noexterior`, `nointerior`, `colonia`, `cp`, `referencia`, `telefono`, " +
                    "`fax`, `correo`, `responsable`, `numero`, `latitud`, `longitud`, `es_propiedad`, `es_notariado`, `status`, `granel`, `maduracion`, " +
                    "`producto_terminado`,i.paraje, i.municipio,i.estado,`tipo_prop`, `edad_maestro`, `escolaridad_mestro`, `telefono_maestro`, `correo_maestro` FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si " +
                    "ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "'");
            DataRow fila;
            dtsInstalaciones.Tables["INSTALACIONES"].Rows.Clear();
            string tipo_instalacion="";
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                switch (Convert.ToString(row["tipo"]))
                {
                    case "1":
                        tipo_instalacion = "Fabrica";
                        break;
                    case "2":
                        tipo_instalacion = "Envasadora";
                        break;
                    case "3":
                        tipo_instalacion = "Bodega";
                        break;
                    case "4":
                        tipo_instalacion = "Vivero";
                        break;
                }
                fila = dtsInstalaciones.Tables["INSTALACIONES"].NewRow();
                fila["TIPO"] = tipo_instalacion;
                fila["ID"] = Convert.ToString(row["id"]);
                fila["ALIAS"] = Convert.ToString(row["alias"]);
                fila["CALLE"] = Convert.ToString(row["calle"]);
                fila["NUM."] = Convert.ToString(row["noexterior"]);
                fila["COLONIA"] = Convert.ToString(row["colonia"]);
                fila["MUNICIPIO"] = Convert.ToString(row["municipio"]);
                fila["ESTADO"] = Convert.ToString(row["estado"]);
                fila["RESPONSABLE"] = Convert.ToString(row["responsable"]);
                //fila["EDITAR"] = ConvertImageToByteArray(Properties.Resources.edit, System.Drawing.Imaging.ImageFormat.Png);
                dtsInstalaciones.Tables["INSTALACIONES"].Rows.Add(fila);
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

        private void btnVerActa_Click(object sender, EventArgs e)
        {

            String acta = ConexionMysql.regresaCampoConsulta("Select doc_acta FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

            if (acta == "1")
            {
                string filePath = "C:/xampp/htdocs/doc/pdf/acta/acta" + di_solicitud + ".pdf";
                Process.Start(filePath);

            }
            else
            {
                MessageBox.Show("No se ha generado el acta, pulsa en generar");
            }
        }

        private void btnGenerarBuenasPracticas_Click(object sender, EventArgs e)
        {
            //string url = "https://localhost/doc/bpm.php?s="+di_solicitud;
            string url = "https://localhost/doc/bpm.php?s=" + di_solicitud;
            Process.Start(url);
            btnVerBuenasPracticas.Show();
            /*if (ConexionMysql.insUpd_transaccion("UPDATE sinca.`di_solicitud` SET `doc_bp` = '1' WHERE `di_solicitud`.`id` ='" + di_solicitud + "'") == "Error")
            {
                return;
            }*/
            //MessageBox.Show("UPDATE sinca.di_solicitud SET doc_bp='1' Where id='" + di_solicitud + "'");
            Console.WriteLine("UPDATE sinca.`di_solicitud` SET `doc_bp` = '1' WHERE `di_solicitud`.`id` ='" + di_solicitud + "'");
        }

        private void btnVerBuenasPracticas_Click(object sender, EventArgs e)
        {
            //string filePath = "C:/xampp/htdocs/doc/"+doc_acta;
            String bpm = ConexionMysql.regresaCampoConsulta("Select doc_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

            if (bpm == "1")
            {
                string filePath = "C:/xampp/htdocs/doc/pdf/bpm/bpm"+ di_solicitud + ".pdf";
                Process.Start(filePath);

            }
            else
            {
                MessageBox.Show("No se ha generado el documento de buenas practicas, pulsa en generar");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerarActaDetallada_Click(object sender, EventArgs e)
        {
            string url = "https://localhost/doc/acta.php?s=" + di_solicitud;
            Process.Start(url);

            btnVerActa.Show();

            /*if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET doc_acta='1' Where id='" + di_solicitud + "'") == "Error")
            {
                return;
            }*/
        }

        private void btnVerInforme_Click(object sender, EventArgs e)
        {
            String informe = ConexionMysql.regresaCampoConsulta("Select doc_informe FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

            if (informe == "1")
            {
                string filePath = "C:/xampp/htdocs/doc/pdf/informe/informe" + di_solicitud + ".pdf";
                Process.Start(filePath);
            }
            else
            {
                MessageBox.Show("No se ha generado el informe, pulsa en generar");
            }
        }

        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {
            string url = "https://localhost/doc/informe.php?s=" + di_solicitud;
            Process.Start(url);

            btnVerInforme.Show();

            /*if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET doc_informe='1' Where id='" + di_solicitud + "'") == "Error")
            {
                return;
            }*/
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro que desea terminar la solicitud?", "Si la terminas no podras hacer cambios posteriormente", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String informe = ConexionMysql.regresaCampoConsulta("Select doc_informe FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String acta = ConexionMysql.regresaCampoConsulta("Select doc_acta FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String bpm = ConexionMysql.regresaCampoConsulta("Select doc_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

                if (informe == "1" && acta == "1" && bpm == "1")
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET status='2' Where id='" + di_solicitud + "'") == "Error")
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Faltan documentos por generar");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //this.Close();
            }
        }

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            FrmVerificarSolicitud frm = new FrmVerificarSolicitud();
            frm.di_solicitud = di_solicitud;
            frm.ShowDialog();
        }

        private void dgvInstalacionesSolicitud_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvInstalacionesSolicitud.Columns[e.ColumnIndex].Name == "EDITAR")
                {
                    /*FrmMovimienEnvasadoNoTerminado frm = new FrmMovimienEnvasadoNoTerminado();

                   frm.id_envasado_entrada = dgSolicitudes.Rows[e.RowIndex].Cells["ID_PRODUCCION_ENVASADO"].Value.ToString();
                   frm.botellas_existentes = dgSolicitudes.Rows[e.RowIndex].Cells["BOTELLAS"].Value.ToString();
                   frm.no_lote = dgSolicitudes.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                   frm.litros_existentes = dgSolicitudes.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                   frm.unidad_medida = dgSolicitudes.Rows[e.RowIndex].Cells["MEDIDA"].Value.ToString();
                   frm.presentacion = dgSolicitudes.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                   frm.grado_alcoholico = dgSolicitudes.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                   frm.clase = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                   frm.fq = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                   frm.no_cliente = CmbNoClienteEnvasado.SelectedValue.ToString();
                   frm.tipo_instalacion = "envasado";
                   frm.ShowDialog();
                   CmbNoClienteEnvasado_SelectedIndexChanged(sender, e);*/

                    //MessageBox.Show(dgSolicitudes.Rows[e.RowIndex].Cells["ID"].Value.ToString(),"Prueba id Solicitud");
                    FrmEditarInstalacion frm = new FrmEditarInstalacion();
                    frm.no_cliente = no_cliente;
                    frm.id_solicitud = id_solicitud;
                    frm.id_instalacion = dgvInstalacionesSolicitud.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    frm.ShowDialog();
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iTalk_HeaderLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
