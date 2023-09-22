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

namespace Crm.Inventario
{
    public partial class FrmNuevoEnvasado : Form
    {
        public FrmNuevoEnvasado()
        {
            InitializeComponent();
        }


        public string tipo_instalacion = "";
        public string id_almacen_envasado = "";

        public string no_cliente;
        public string id_envasadora = "";

        DataTable DtaMaguey;
        DataTable DtaLoteGranel;
        Validacion valida = new Validacion();
        DataSet dtsHologramas;
        string id_max_envasado_entrada;
        string id_max_envasado_ensamble;
        string id_max_hologramas;

        string id_max_almacen_envasado_entrada;
        string id_max_almacen_envasado_ensamble;
        string id_max_almacen_hologramas;

        //obtencion de los id para todas las entradas a envasado 
        public void ObtenerIdMaximoEnvasadoEntrada()
        {
            id_max_envasado_entrada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_entrada,4)) )   FROM envasado_entrada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasado_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasado_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasado_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasado_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }



        //obtencion de los id para todas las entradas a envasado ensamble 
        public void ObtenerIdMaximoEnvasadoEnsamble()
        {
            id_max_envasado_ensamble = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_ensamble,4)) )   FROM envasado_ensamble where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasado_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasado_ensamble = Usuario.IdUsuario + "-1";
                }

            }
            else
            {
                int suma = int.Parse(id_max_envasado_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasado_ensamble = Usuario.IdUsuario + "-" + suma;
                }

            }
        }


        //obtencion de los id para todas las entradas a hologramas
        public void ObtenerIdMaximoEntradaHologramas()
        {
            id_max_hologramas = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_holograma,4)) )   FROM envasado_holograma where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_hologramas == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_hologramas = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_hologramas = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_hologramas) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_hologramas = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_hologramas = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        /// ======== para almacen -----

        //obtencion de los id para todas las entradas a almacen envasado 
        public void ObtenerIdMaximoAlmacenEnvasadoEntrada()
        {
            id_max_almacen_envasado_entrada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_envasado_entrada,4)) )   FROM almacen_envasado_entrada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_envasado_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_envasado_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_envasado_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_envasado_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }



        //obtencion de los id para todas las entradas a almacen envasado ensamble 
        public void ObtenerIdMaximoAlmacenEnvasadoEnsamble()
        {
            id_max_almacen_envasado_ensamble = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_envasado_ensamble,4)) )   FROM almacen_envasado_ensamble where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_envasado_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_envasado_ensamble = Usuario.IdUsuario + "-1";
                }

            }
            else
            {
                int suma = int.Parse(id_max_almacen_envasado_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_envasado_ensamble = Usuario.IdUsuario + "-" + suma;
                }

            }
        }


        //obtencion de los id para todas las entradas a hologramas
        public void ObtenerIdMaximoalmacenEntradaHologramas()
        {
            id_max_almacen_hologramas = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_envasado_holograma,4)) )   FROM almacen_envasado_holograma where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_hologramas == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_hologramas = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_hologramas = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_hologramas) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_hologramas = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_hologramas = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void FrmNuevoEnvasado_Load(object sender, EventArgs e)
        {
            CmbCategoria.Items.Insert(0, "---Elije una opcion---");
            CmbCategoria.Items.Insert(1, "Mezcal");
            CmbCategoria.Items.Insert(2, "Mezcal Artesanal");
            CmbCategoria.Items.Insert(3, "Mezcal Ancestral");

            CmbCategoria.SelectedIndex = 0;

            /*CmbClase.Items.Insert(0, "Joven");
            CmbClase.Items.Insert(1, "Reposado");
            CmbClase.Items.Insert(1, "Añejo");*/
            CmbClase.Items.Insert(0, "---Elije una opcion---");
            CmbClase.Items.Insert(1, "Blanco o Joven");
            CmbClase.Items.Insert(2, "Reposado");
            CmbClase.Items.Insert(3, "Añejo");
            CmbClase.Items.Insert(4, "Abocado con");
            CmbClase.Items.Insert(5, "Destilado con");
            CmbClase.Items.Insert(6, "Madurado en vidrio");

            CmbClase.SelectedIndex = 0;



            lblEtiquetadocomo.Enabled = false;
            cmbEtiquetadocomo.Enabled = false;

            ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca FROM marcas  where no_cliente ='" + no_cliente + "'", "id", "marca");



            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,CONCAT (comun.nombre,' (',especie.genespecie,')') as nombre FROM comun INNER JOIN especie ON especie.id_especie=comun.id_especie WHERE comun.status=1 ORDER BY comun.nombre ASC", "id_comun", "nombre");
            ConexionMysql.llenaCombo(ref CmbUnidadDeMedida, "SELECT  distinct medida FROM cat_presentacion", "medida", "medida");
            addTablaMaguey();
            addTablaLotesGranel();
            addTablaHologramas();



            if (tipo_instalacion == "envasadora")
            {
                ConexionMysql.llenaCombo(ref CmbEnvasadora, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + no_cliente + "'", "id_envasadora", "envasadora");
                if (id_envasadora != "")
                {
                    CmbEnvasadora.SelectedValue = id_envasadora;
                }
            }
            else if (tipo_instalacion == "almacen_envasado")
            {

                ConexionMysql.llenaCombo(ref CmbEnvasadora, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + no_cliente + "' AND tipo_almacen=2", "id_almacen", "almacen");
                if (id_almacen_envasado != "")
                {
                    CmbEnvasadora.SelectedValue = id_almacen_envasado;
                }


            }



        }



        private void addTablaMaguey()
        {
            DtaMaguey = new DataTable();
            DtaMaguey.Columns.Add("ID_COMUN", Type.GetType("System.String"));
            DtaMaguey.Columns.Add("NOMBRE", Type.GetType("System.String"));
            DtaMaguey.Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaMagueyGuardar.DataSource = DtaMaguey;
            DtaMagueyGuardar.Columns[0].Visible = false;
        }


        private void addTablaLotesGranel()
        {
            DtaLoteGranel = new DataTable();
            DtaLoteGranel.Columns.Add("NO_LOTE", Type.GetType("System.String"));
            DtaLoteGranel.Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaLoteGranelGuardar.DataSource = DtaLoteGranel;
        }

        private void addTablaHologramas()
        {
            dtsHologramas = new DataSet();
            dtsHologramas.Tables.Add("HOLOGRAMAS");
            dtsHologramas.Tables["HOLOGRAMAS"].Columns.Add("INICIO", Type.GetType("System.String"));
            dtsHologramas.Tables["HOLOGRAMAS"].Columns.Add("FIN", Type.GetType("System.String"));
            dtsHologramas.Tables["HOLOGRAMAS"].Columns.Add("SERIE", Type.GetType("System.String"));
            dtsHologramas.Tables["HOLOGRAMAS"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaHologramas.DataSource = dtsHologramas.Tables["HOLOGRAMAS"];

        }


        private void BtnAgregarMaguey_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbMaguey.Text == "")
                {
                    MessageBox.Show("No ha seleccionado ningun maguey");
                    return;
                }
                DataRow fila = DtaMaguey.NewRow();
                fila["ID_COMUN"] = CmbMaguey.SelectedValue.ToString();
                fila["NOMBRE"] = CmbMaguey.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                DtaMaguey.Rows.Add(fila);

                string produccion = "";
                string coma = "";
                for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                {
                    produccion += coma + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value;
                    coma = ",";
                }
               // ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,nombre FROM comun WHERE  ID_COMUN NOT IN(" + produccion + ") ", "id_comun", "nombre");
                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,CONCAT (comun.nombre,' (',especie.genespecie,')') as nombre FROM comun INNER JOIN especie ON especie.id_especie=comun.id_especie WHERE comun.status=1 AND ID_COMUN NOT IN(" + produccion + ")  ORDER BY comun.nombre ASC", "id_comun", "nombre");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        //esta funciones ´para agregar la imagen a las tablas
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
        private void CmbMaguey_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DtaMagueyGuardar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaMagueyGuardar.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaMagueyGuardar.Rows.RemoveAt(e.RowIndex);
                    DtaMaguey.AcceptChanges();
                    CmbMaguey.DataSource = null;
                    if (DtaMagueyGuardar.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                        {
                            produccion += coma + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value;
                            coma = ",";
                        }
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,nombre FROM comun WHERE ID_COMUN NOT IN(" + produccion + ") ", "id_comun", "nombre");
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,nombre FROM comun ", "id_comun", "nombre");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CmbUnidadDeMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbMedidaBotella.DataSource = null;
            ConexionMysql.llenaCombo(ref CmbMedidaBotella, "SELECT cantidad FROM cat_presentacion  where medida ='" + CmbUnidadDeMedida.SelectedValue + "'", "cantidad", "cantidad");
        }

        private void BtnAgregarLoteGranel_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtLoteGranel.Text == "")
                {
                    MessageBox.Show("No ha introducido un numero de lote a granel");
                    return;
                }
                DataRow fila = DtaLoteGranel.NewRow();
                fila["NO_LOTE"] = TxtLoteGranel.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                DtaLoteGranel.Rows.Add(fila);
                TxtLoteGranel.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtaLoteGranelGuardar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaLoteGranelGuardar.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaLoteGranelGuardar.Rows.RemoveAt(e.RowIndex);
                    DtaLoteGranel.AcceptChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //---- agregar la opcion de envasado nuenvo no terminado
            int ResComparacionFechas = DateTime.Compare(DtaFechaEnvasadoini.Value, DtaFechaEnvasadofin.Value);
            if (ResComparacionFechas > 0)
            {
                MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio del envasado");
                return;
            }
            if (DtaMagueyGuardar.RowCount == 0)
            {
                MessageBox.Show("No ha ingresado maguey");
                return;
            }
            if (DtaLoteGranelGuardar.RowCount == 0)
            {
                MessageBox.Show("No ha ingresado lote a granel");
                TxtLoteGranel.Focus();
                return;
            }
            if (CmbMarca.SelectedValue == null)
            {
                MessageBox.Show("No has seleccionado una marca");
                return;
            }
            if (TxtNoLoteEnvasado.Text == "")
            {
                MessageBox.Show("No ha ingresado lote de envasado");
                TxtNoLoteEnvasado.Focus();
                return;
            }
            if (TxtClaveFqEnvasado.Text == "" || TxtClaveFqEnvasado.Text == " ")
            {
                MessageBox.Show("No ha introducido un FQ");
                TxtClaveFqEnvasado.Focus();
                return;
            }
            if (TxtGradoAlcoholicoEtiqueta.Text == "" || TxtGradoAlcoholicoEtiqueta.Text == "0")
            {
                MessageBox.Show("No ha introducido un grado alcohólico de la etiqueta");
                TxtGradoAlcoholicoEtiqueta.Focus();
                return;
            }
            if (TxtNoBotellas.Text == "")
            {
                MessageBox.Show("No ha ingresado numero de botellas");
                TxtNoBotellas.Focus();
                return;
            }
            if (TxtGradoAlcoholico.Text == "")
            {
                MessageBox.Show("No ha ingresado grado alcohólico");
                TxtGradoAlcoholico.Focus();
                return;
            }
            if (CmbEnvasadora.SelectedValue == null)
            {
                MessageBox.Show("No tienes envasadora");
                return;
            }
            if (CmbCategoria.Text == "---Elije una opcion---")
            {
                MessageBox.Show("No ha seleccionado categoria");
                return;
            }

            if (CmbClase.Text == "---Elije una opcion---")
            {
                MessageBox.Show("No ha seleccionado clase");
                return;
            }


            if (CmbClase.Text == "Blanco o Joven")
            {
                if (cmbEtiquetadocomo.Text == "---Elije una opcion---")
                {

                    MessageBox.Show("No ha elegido el tipo de etiquetado");
                    return;
                }
            }


            if (CmbClase.Text == "Abocado con" || CmbClase.Text == "Destilado con")
            {
                if (
                        TxtIngredienteEnvasado.Text == "")
                {

                    MessageBox.Show("No ha ingresado un ingrediente");
                    return;
                }
            }


            if (ChekOstenta.Toggled == false)
            {
                if (DtaHologramas.RowCount == 0)
                {
                    MessageBox.Show("Introduce un rango de hologramas");
                    TxtHologramaInicio.Focus();
                    return;
                }
            }

            string tipo_destinoF = "";
            if (tipo_instalacion == "envasadora")
            {
                if (chkEnvasadoNacional.Checked == true)
                {
                    tipo_destinoF = "NAC";
                }
                else
                if (chkEnvasadoExportacion.Checked == true)
                {
                    tipo_destinoF = "EXP";
                }
                else
                if (chkEnvasadoIndefinido.Checked == true)
                {
                    tipo_destinoF = "IND";
                }
                else
                {
                    MessageBox.Show("Debes ingresar un destino, si no lo conoces, selecciona IND (Indefinido)");
                    return;
                }
            }

                string tipo_lote = "";

            if (!rdBtnRP.Checked)
            {
                if (!rdBtnSF.Checked)
                {

                    if (!RdBtnLN.Checked)
                    {
                        MessageBox.Show("Favor de seleccionar tipo de Lote");
                        return;
                    }
                    else { tipo_lote = "LN"; }
                }
                else
                {
                    tipo_lote = "SF";
                }
            }
            else
            {
                tipo_lote = "RP";
            }


            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos." + Environment.NewLine + "¿Seguro de realizar el registro?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {



                if (tipo_instalacion == "envasadora")
                {
                    ObtenerIdMaximoEnvasadoEntrada();
                    if (DtaMagueyGuardar.RowCount == 1 && DtaLoteGranelGuardar.RowCount == 1)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada(id_envasado_entrada,id_envasadora,id_marca,no_cliente,tipo_destino,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_comun,no_lote_granel,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,tipo_ingreso,actualizado) VALUES('" + id_max_envasado_entrada + "','" + CmbEnvasadora.SelectedValue + "', '" + (CmbMarca.SelectedValue == null ? 0 : CmbMarca.SelectedValue) + "','" + no_cliente + "', '" + tipo_destinoF + "' ,now()" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",'" + DtaLoteGranelGuardar.Rows[0].Cells["NO_LOTE"].Value.ToString() + "',0,'" + TxtNoLoteEnvasado.Text + "' ,'" + TxtClaveFqEnvasado.Text + "' , '" + CmbClase.Text + "' , '" + CmbCategoria.Text + "','','" + TxtIngredienteEnvasado.Text + "','" + cmbEtiquetadocomo.Text + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + ",0, " + TxtGradoAlcoholico.Text + "," + TxtGradoAlcoholicoEtiqueta.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',0)") == "Error") //-- se agrego fecha_movimiento
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada(id_envasado_entrada,id_envasadora,id_marca,no_cliente,tipo_destino,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,tipo_ingreso,actualizado) VALUES('" + id_max_envasado_entrada + "','" + CmbEnvasadora.SelectedValue + "', '" + (CmbMarca.SelectedValue == null ? 0 : CmbMarca.SelectedValue) + "','" + no_cliente + "','" + tipo_destinoF + "',now()" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLoteEnvasado.Text + "' ,'" + TxtClaveFqEnvasado.Text + "' , '" + CmbClase.Text + "' , '" + CmbCategoria.Text + "','','" + TxtIngredienteEnvasado.Text + "','" + cmbEtiquetadocomo.Text + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + ",0, " + TxtGradoAlcoholico.Text + "," + TxtGradoAlcoholicoEtiqueta.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',0)") == "Error")//-- se agrego fecha_movimiento
                        {
                            return;
                        }

                        for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble,id_envasado_entrada,id_comun,id_verificador) VALUES( '" + id_max_envasado_ensamble + "','" + id_max_envasado_entrada + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }

                        for (int x = 0; x < DtaLoteGranelGuardar.Rows.Count; x++)
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble,id_envasado_entrada,no_lote_granel,id_verificador) VALUES( '" + id_max_envasado_ensamble + "','" + id_max_envasado_entrada + "' ,'" + DtaLoteGranelGuardar.Rows[x].Cells["NO_LOTE"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }

                    }



                    if (ChekOstenta.Toggled == true)
                    {
                        ObtenerIdMaximoEntradaHologramas();
                        string no_cliente = CmbMarca.SelectedValue.ToString();
                        no_cliente = no_cliente.Substring(0, 5);

                        string cve_marca = CmbMarca.SelectedValue.ToString();
                        cve_marca = cve_marca.Substring(6, 1);
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada,holograma_inicio, holograma_fin, id_verificador, actualizado) VALUES( '" + id_max_hologramas + "','" + id_max_envasado_entrada + "','" + TxtHologramaInicio.Text + "' , '" + TxtHologramaFin.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }

                    }
                    else
                    {
                        for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                        {
                            ObtenerIdMaximoEntradaHologramas();

                            string no_cliente = CmbMarca.SelectedValue.ToString();
                            no_cliente = no_cliente.Substring(0, 5);

                            string cve_marca = CmbMarca.SelectedValue.ToString();
                            cve_marca = cve_marca.Substring(6, 1);

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_hologramas + "','" + id_max_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + DtaHologramas.Rows[x].Cells["INICIO"].Value + "' , '" + DtaHologramas.Rows[x].Cells["FIN"].Value + "','" + DtaHologramas.Rows[x].Cells["SERIE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }

                    }

                } /// fin de tipo para envasadora
                else if (tipo_instalacion == "almacen_envasado")
                {


                    ObtenerIdMaximoAlmacenEnvasadoEntrada();
                    if (DtaMagueyGuardar.RowCount == 1 && DtaLoteGranelGuardar.RowCount == 1)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_entrada(id_almacen_envasado_entrada,id_almacen,id_marca,no_cliente,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_comun,no_lote_granel,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,tipo_ingreso,actualizado) VALUES('" + id_max_almacen_envasado_entrada + "','" + CmbEnvasadora.SelectedValue + "', '" + (CmbMarca.SelectedValue == null ? 0 : CmbMarca.SelectedValue) + "','" + no_cliente + "',now()" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",'" + DtaLoteGranelGuardar.Rows[0].Cells["NO_LOTE"].Value.ToString() + "',0,'" + TxtNoLoteEnvasado.Text + "' ,'" + TxtClaveFqEnvasado.Text + "' , '" + CmbClase.Text + "' , '" + CmbCategoria.Text + "','','" + TxtIngredienteEnvasado.Text + "','" + cmbEtiquetadocomo.Text + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + ",0, " + TxtGradoAlcoholico.Text + "," + TxtGradoAlcoholicoEtiqueta.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',0)") == "Error") //-- se agrego fecha_movimiento
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_entrada(id_almacen_envasado_entrada,id_almacen,id_marca,no_cliente,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,actualizado) VALUES('" + id_max_almacen_envasado_entrada + "','" + CmbEnvasadora.SelectedValue + "', '" + (CmbMarca.SelectedValue == null ? 0 : CmbMarca.SelectedValue) + "','" + no_cliente + "',now()" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLoteEnvasado.Text + "' ,'" + TxtClaveFqEnvasado.Text + "' , '" + CmbClase.Text + "' , '" + CmbCategoria.Text + "','','" + TxtIngredienteEnvasado.Text + "','" + cmbEtiquetadocomo.Text + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + ",0, " + TxtGradoAlcoholico.Text + "," + TxtGradoAlcoholicoEtiqueta.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',0)") == "Error")//-- se agrego fecha_movimiento
                        {
                            return;
                        }

                        for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_ensamble(id_almacen_envasado_ensamble,id_almacen_envasado_entrada,id_comun,id_verificador) VALUES( '" + id_max_almacen_envasado_ensamble + "','" + id_max_almacen_envasado_entrada + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }

                        for (int x = 0; x < DtaLoteGranelGuardar.Rows.Count; x++)
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_ensamble(id_almacen_envasado_ensamble,id_almacen_envasado_entrada,no_lote_granel,id_verificador) VALUES( '" + id_max_envasado_ensamble + "','" + id_max_almacen_envasado_entrada + "' ,'" + DtaLoteGranelGuardar.Rows[x].Cells["NO_LOTE"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }

                    }



                    if (ChekOstenta.Toggled == true)
                    {
                        ObtenerIdMaximoEntradaHologramas();
                        string no_cliente = CmbMarca.SelectedValue.ToString();
                        no_cliente = no_cliente.Substring(0, 5);

                        string cve_marca = CmbMarca.SelectedValue.ToString();
                        cve_marca = cve_marca.Substring(6, 1);
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma, id_almacen_envasado_entrada,holograma_inicio, holograma_fin, id_verificador, actualizado) VALUES( '" + id_max_almacen_hologramas + "','" + id_max_almacen_envasado_entrada + "','" + TxtHologramaInicio.Text + "' , '" + TxtHologramaFin.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }

                    }
                    else
                    {
                        for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                        {
                            ObtenerIdMaximoEntradaHologramas();

                            string no_cliente = CmbMarca.SelectedValue.ToString();
                            no_cliente = no_cliente.Substring(0, 5);

                            string cve_marca = CmbMarca.SelectedValue.ToString();
                            cve_marca = cve_marca.Substring(6, 1);

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_almacen_hologramas + "','" + id_max_almacen_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + DtaHologramas.Rows[x].Cells["INICIO"].Value + "' , '" + DtaHologramas.Rows[x].Cells["FIN"].Value + "','" + DtaHologramas.Rows[x].Cells["SERIE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }

                    }




                }


                ConexionMysql.transCompleta();
                MessageBox.Show("Éxito"); cmbEtiquetadocomo.Items.Clear();
                this.Close();
            }
        }



        private void TxtNoBotellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtGradoAlcoholico_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoAlcoholico.Text);
        }

        private void CmbEnvasadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEnvasadora.SelectedValue != null)
            {
                if (tipo_instalacion == "envasadora")
                {
                    TxtResponsableEnvasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + CmbEnvasadora.SelectedValue + "'");
                }
                else if (tipo_instalacion == "almacen_envasado")
                {

                    TxtResponsableEnvasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  almacen_encargado  WHERE id_almacen='" + CmbEnvasadora.SelectedValue + "'");


                }
            }
        }

        private void BtnAgragarHolograma_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtHologramaInicio.Text == "")
                {
                    MessageBox.Show("Ingresa un inicio de holograma");
                    TxtHologramaInicio.Focus();
                    return;
                }

                if (TxtHologramaFin.Text == "")
                {
                    MessageBox.Show("Introduce un fin de holograma");
                    TxtHologramaFin.Focus();
                    return;
                }
                if (TxtSerie.Text == "")
                {
                    MessageBox.Show("Introduce una serie");
                    TxtSerie.Focus();
                    return;
                }

                if (TxtHologramaInicio.Text == "0")
                {
                    MessageBox.Show("Introduce un valor diferente de 0");
                    TxtHologramaInicio.Focus();
                    return;
                }
                if (TxtHologramaFin.Text == "0")
                {
                    MessageBox.Show("Introduce un valor diferente de 0");
                    TxtHologramaFin.Focus();
                    return;
                }
                if (CmbMarca.SelectedValue == null)
                {
                    MessageBox.Show("No has selecionado una marca ");
                    TxtHologramaFin.Focus();
                    return;
                }

                int holograma_inicio;
                int holograma_fin;

                string no_cliente = CmbMarca.SelectedValue.ToString();
                no_cliente = no_cliente.Substring(0, 5);

                string cve_marca = CmbMarca.SelectedValue.ToString();
                cve_marca = cve_marca.Substring(6, 1);

                DataSet Datos = new DataSet();

                ///// --- BUSCA SI EXISTE  OLOGRAMAS OCUPADOS DE ESA MARCA EN ENVASASO HOLOGRAMAS 
                //if (tipo_instalacion == "envasadora")
                // {

                ConexionMysql.llenaDataset(ref Datos, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,5) = em.no_cliente and  SUBSTRING(ee.id_marca,7,1)=em.cve_marca  where eh.no_cliente='" + no_cliente + "' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "'");

                /* }
                 else if (tipo_instalacion == "almacen_envasado")
                 {

                     ConexionMysql.llenaDataset(ref Datos, "select aeh.holograma_inicio,aeh.holograma_fin, aee.no_lote, em.marca,aee.contenido_por_botella,aee.unidad_medida from envasado_holograma aeh inner join almacen_envasado_entrada aee on aeh.id_envasado_entrada = aee.id_almacen_envasado_entrada inner join marcas em on  SUBSTRING(aee.id_marca,1,4) = em.no_cliente and  SUBSTRING(aee.id_marca,6,1)=em.cve_marca  where aeh.no_cliente='" + no_cliente + "' and aeh.cve_marca='" + cve_marca + "' and aeh.serie='" + TxtSerie.Text.ToUpper() + "'");

                 }*/





                foreach (DataRow row in Datos.Tables[0].Rows)
                {



                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);



                    string lote = "Tipo de instalacion :  Envasadora" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

                    if (int.Parse(TxtHologramaInicio.Text) >= holograma_inicio && int.Parse(TxtHologramaInicio.Text) <= holograma_fin)
                    {
                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos  para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(TxtHologramaFin.Text) >= holograma_inicio && int.Parse(TxtHologramaFin.Text) <= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(TxtHologramaInicio.Text) <= holograma_inicio && int.Parse(TxtHologramaFin.Text) >= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }



                ///// --- BUSCA SI EXISTE  HOLOGRAMAS OCUPADOS DE LA  MARCA EN ALMACEN DE ENVASASO HOLOGRAMAS 

                DataSet Datos3 = new DataSet();

                ConexionMysql.llenaDataset(ref Datos3, "select aeh.holograma_inicio,aeh.holograma_fin, aee.no_lote, em.marca,aee.contenido_por_botella,aee.unidad_medida from almacen_envasado_holograma aeh inner join almacen_envasado_entrada aee on aeh.id_almacen_envasado_entrada = aee.id_almacen_envasado_entrada inner join marcas em on  SUBSTRING(aee.id_marca,1,5) = em.no_cliente and  SUBSTRING(aee.id_marca,7,1)=em.cve_marca  where aeh.no_cliente='" + no_cliente + "' and aeh.cve_marca='" + cve_marca + "' and aeh.serie='" + TxtSerie.Text.ToUpper() + "'");



                foreach (DataRow row in Datos3.Tables[0].Rows)
                {



                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);



                    string lote = "Tipo de instalacion :  Almacen  de Envasado" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

                    if (int.Parse(TxtHologramaInicio.Text) >= holograma_inicio && int.Parse(TxtHologramaInicio.Text) <= holograma_fin)
                    {
                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos  para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(TxtHologramaFin.Text) >= holograma_inicio && int.Parse(TxtHologramaFin.Text) <= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(TxtHologramaInicio.Text) <= holograma_inicio && int.Parse(TxtHologramaFin.Text) >= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }








                DataSet Datos2 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos2, " select   MAX(ff1) AS ff1 from hologramas_salida where no_cliente='" + no_cliente + "' and cliente_crm = '' and marca='" + cve_marca + "' and serie='" + TxtSerie.Text + "' ");

                if (Datos2.Tables[0].Rows.Count > 0)
                {



                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {

                        if (DBNull.Value.Equals(row["ff1"]))
                        {
                            MessageBox.Show("No se ah encontrado registro alguno de hologramas para la marca : " + Environment.NewLine + CmbMarca.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        holograma_fin = Convert.ToInt32(row["ff1"]);


                        if (int.Parse(TxtHologramaFin.Text) > holograma_fin)
                        {
                            MessageBox.Show("No puedes introducir este rango ya que el rango final entregado al asociado es " + Environment.NewLine + "Entregado: " + holograma_fin.ToString() + Environment.NewLine + "Introducido: " + TxtHologramaFin.Text);
                            return;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("No se tiene registro de hologramas entregados");
                    return;

                }
                DataRow fila = dtsHologramas.Tables["HOLOGRAMAS"].NewRow();
                fila["INICIO"] = TxtHologramaInicio.Text;
                fila["FIN"] = TxtHologramaFin.Text;
                fila["SERIE"] = TxtSerie.Text.ToUpper();
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsHologramas.Tables["HOLOGRAMAS"].Rows.Add(fila);
                TxtHologramaInicio.Text = "";
                TxtHologramaFin.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnInformacionHolograma_MouseEnter(object sender, EventArgs e)
        {
            int suma_botellas = 0;
            if (DtaHologramas.Rows.Count >= 1)
            {

                for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                {
                    suma_botellas += ((int.Parse(DtaHologramas.Rows[x].Cells["FIN"].Value.ToString()) - int.Parse(DtaHologramas.Rows[x].Cells["INICIO"].Value.ToString())) + 1);
                }

                if (suma_botellas < 0)
                {
                    TxtMensajeBotellas.Text = "Error en rango de hologramas";
                }
                else
                {
                    TxtMensajeBotellas.Text = suma_botellas.ToString() + " Botellas";
                }

                TxtMensajeBotellas.Visible = true;
            }
        }

        private void BtnInformacionHolograma_MouseLeave(object sender, EventArgs e)
        {
            TxtMensajeBotellas.Visible = false;
        }

        private void TxtHologramaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtHologramaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloLetras(e);
        }

        private void ChekOstenta_ToggledChanged()
        {
            if (ChekOstenta.Toggled == true)
            {
                TxtHologramaInicio.ReadOnly = true;
                TxtHologramaFin.ReadOnly = true;
                TxtSerie.ReadOnly = true;
                BtnAgragarHolograma.Enabled = false;
                TxtHologramaInicio.Text = "Si ostenta";
                TxtHologramaFin.Text = "Si ostenta";
                TxtSerie.Text = "";
                dtsHologramas.Clear();
            }
            else
            {
                TxtHologramaInicio.ReadOnly = false;
                TxtHologramaFin.ReadOnly = false;
                TxtSerie.ReadOnly = false;
                BtnAgragarHolograma.Enabled = true;
                TxtHologramaInicio.Text = "";
                TxtHologramaFin.Text = "";
                TxtSerie.Text = "";
            }
        }

        private void TxtGradoAlcoholicoEtiqueta_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoAlcoholicoEtiqueta.Text);
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }


        private void CmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbClase.Text == "Blanco o Joven")
            {

                lblEtiquetadocomo.Enabled = true;
                cmbEtiquetadocomo.Enabled = true;
                cmbEtiquetadocomo.Items.Insert(0, "---Elije una opcion---");
                cmbEtiquetadocomo.Items.Insert(1, "Blanco");
                cmbEtiquetadocomo.Items.Insert(2, "Joven");
                cmbEtiquetadocomo.SelectedIndex = 0;

                lbltituloIngrediente.Enabled = false;
                TxtIngredienteEnvasado.Enabled = false;



            }
            else if (CmbClase.Text == "Abocado con" || CmbClase.Text == "Destilado con")
            {
                lbltituloIngrediente.Enabled = true;
                TxtIngredienteEnvasado.Enabled = true;

                lblEtiquetadocomo.Enabled = false;
                cmbEtiquetadocomo.Enabled = false;
                cmbEtiquetadocomo.Items.Clear();
            }
            else
            {
                TxtIngredienteEnvasado.Text = "";
                lbltituloIngrediente.Enabled = false;
                TxtIngredienteEnvasado.Enabled = false;


                lblEtiquetadocomo.Enabled = false;
                cmbEtiquetadocomo.Enabled = false;
                cmbEtiquetadocomo.Items.Clear();
            }

            
        }

        private void DtaHologramas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaHologramas.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaHologramas.Rows.RemoveAt(e.RowIndex);
                    dtsHologramas.Tables["HOLOGRAMAS"].AcceptChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
