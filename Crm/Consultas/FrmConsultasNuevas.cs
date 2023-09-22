using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Crm.Utilerias;


namespace Crm.Consultas
{
    public partial class FrmConsultasNuevas : Form
    {
        public FrmConsultasNuevas()
        {
            InitializeComponent();
        }

        DataSet dtsProduccion;
        DataSet dtsGranelFabrica;
        DataSet dtsEnvasadoExistente;
        DataSet dtsEnvasado;

        Boolean BanderaProduccion = false;
        Boolean BanderaGranelFabrica = false;
        Boolean BanderaEnvasadoExistente = false;
        Boolean BanderaEnvasado = false;

        public string id;


        private void addTablaProduccion()
        {
            dtsProduccion = new DataSet();
            dtsProduccion.Tables.Add("PRODUCCION");
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO_PREDIO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("%_ART", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("KG_PINAS_COCCION", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("REFERIDO_45", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("PRODUCTO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("VERIFICADOR1", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("VERIFICADOR2", Type.GetType("System.String"));
            DtaTabla.DataSource = dtsProduccion.Tables["PRODUCCION"];

        }

        private void addTablaGranelFabrica()
        {
            dtsGranelFabrica = new DataSet();
            dtsGranelFabrica.Tables.Add("GRANEL_FABRICA");
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("NO_TANQUE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("PRODUCTO", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("LOTE_GRANEL", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("GRADO_ALCOHOLICO", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            DtaTabla.DataSource = dtsGranelFabrica.Tables["GRANEL_FABRICA"];

        }




        private void addTablaEnvasado()
        {
            dtsEnvasado = new DataSet();
            dtsEnvasado.Tables.Add("ENVASADO");
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("NO_LOTE_GRANEL", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("NO_LOTE_ENVASADO", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("PRODUCTO", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("GRADO_ALCOHOLICO", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("NO_BOTELLAS", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("CAJAS", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));              
            DtaTabla.DataSource = dtsEnvasado.Tables["ENVASADO"];

        }

        private void addTablaEnvasadoExistente()
        {
            dtsEnvasadoExistente = new DataSet();
            dtsEnvasadoExistente.Tables.Add("ENVASADO");
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("NO_LOTE_GRANEL", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("NO_LOTE_ENVASADO", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("PRODUCTO", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("GRADO_ALCOHOLICO", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("NO_BOTELLAS", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("CAJAS", Type.GetType("System.String"));
            dtsEnvasadoExistente.Tables["ENVASADO"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            DtaTabla.DataSource = dtsEnvasadoExistente.Tables["ENVASADO"];

        }



        // genera el exel
        public void ExportarDataGridViewExcel(DataGridView grd)
        {
            try
            {

                SaveFileDialog archivo = new SaveFileDialog();
                archivo.Filter = "Excel (*.xls)|*.xls";
                archivo.FileName = "Reporte ReVeCa " + DateTime.Now.Date.ToShortDateString().Replace('/', '-');

                if (BanderaProduccion == true)
                {

                    if (archivo.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;

                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libroDeTrabajo = aplicacion.Workbooks.Add();
                        hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);

                        hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
                        hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
                        hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
                        hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
                        hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
                        hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
                        hojaDeTrabajo.Cells[1, "G"] = grd.Columns[6].HeaderText;
                        hojaDeTrabajo.Cells[1, "H"] = grd.Columns[7].HeaderText;
                        hojaDeTrabajo.Cells[1, "I"] = grd.Columns[8].HeaderText;
                        hojaDeTrabajo.Cells[1, "J"] = grd.Columns[9].HeaderText;
                        hojaDeTrabajo.Cells[1, "K"] = grd.Columns[10].HeaderText;
                        hojaDeTrabajo.Cells[1, "L"] = grd.Columns[11].HeaderText;
                        hojaDeTrabajo.Cells[1, "M"] = grd.Columns[12].HeaderText;
                        hojaDeTrabajo.Cells[1, "N"] = grd.Columns[13].HeaderText;
                    


                        hojaDeTrabajo.Columns[1].AutoFit();
                        hojaDeTrabajo.Columns[1].NumberFormat = "@";
                        hojaDeTrabajo.Columns[2].AutoFit();
                        hojaDeTrabajo.Columns[3].AutoFit();
                        hojaDeTrabajo.Columns[4].AutoFit();
                        hojaDeTrabajo.Columns[5].AutoFit();
                        hojaDeTrabajo.Columns[6].AutoFit();
                        hojaDeTrabajo.Columns[7].AutoFit();
                        hojaDeTrabajo.Columns[8].AutoFit();
                        hojaDeTrabajo.Columns[9].AutoFit();
                        hojaDeTrabajo.Columns[10].AutoFit();
                        hojaDeTrabajo.Columns[11].AutoFit();
                        hojaDeTrabajo.Columns[11].NumberFormat = "@";
                        hojaDeTrabajo.Columns[12].AutoFit();
                        hojaDeTrabajo.Columns[13].AutoFit();
                        hojaDeTrabajo.Columns[14].AutoFit();



                        hojaDeTrabajo.Name = "Reporte";
                        //Recorremos el DataGridView rellenando la hoja de trabajo
                        for (int i = 0; i < grd.Rows.Count; i++)
                        {
                            for (int j = 0; j < grd.Columns.Count; j++)
                            {
                                if (grd.Rows[i].Cells[j].Value != null)
                                {
                                    hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                        }
                        libroDeTrabajo.SaveAs(archivo.FileName,
                            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libroDeTrabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Reporte generado con éxito");
                    }
                }
                else if (BanderaGranelFabrica == true )
                {
                    if (archivo.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;

                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libroDeTrabajo = aplicacion.Workbooks.Add();
                        hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);

                        hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
                        hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
                        hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
                        hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
                        hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
                        hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
                        hojaDeTrabajo.Cells[1, "G"] = grd.Columns[6].HeaderText;
                        hojaDeTrabajo.Cells[1, "H"] = grd.Columns[7].HeaderText;
                        hojaDeTrabajo.Cells[1, "I"] = grd.Columns[8].HeaderText;
                        hojaDeTrabajo.Cells[1, "J"] = grd.Columns[9].HeaderText;
                        hojaDeTrabajo.Cells[1, "K"] = grd.Columns[10].HeaderText;
                        hojaDeTrabajo.Cells[1, "L"] = grd.Columns[11].HeaderText;
                        hojaDeTrabajo.Cells[1, "M"] = grd.Columns[12].HeaderText;





                        hojaDeTrabajo.Columns[1].AutoFit();
                        hojaDeTrabajo.Columns[1].NumberFormat = "@";
                        hojaDeTrabajo.Columns[2].AutoFit();
                        hojaDeTrabajo.Columns[3].AutoFit();
                        hojaDeTrabajo.Columns[4].NumberFormat = "@";
                        hojaDeTrabajo.Columns[4].AutoFit();
                        hojaDeTrabajo.Columns[5].AutoFit();
                        hojaDeTrabajo.Columns[6].AutoFit();
                        hojaDeTrabajo.Columns[7].AutoFit();
                        hojaDeTrabajo.Columns[8].AutoFit();
                        hojaDeTrabajo.Columns[9].AutoFit();
                        hojaDeTrabajo.Columns[10].AutoFit();
                        hojaDeTrabajo.Columns[11].AutoFit();
                        hojaDeTrabajo.Columns[12].AutoFit();
                        hojaDeTrabajo.Columns[13].AutoFit();
 



                        hojaDeTrabajo.Name = "Reporte";
                        //Recorremos el DataGridView rellenando la hoja de trabajo
                        for (int i = 0; i < grd.Rows.Count; i++)
                        {
                            for (int j = 0; j < grd.Columns.Count; j++)
                            {
                                if (grd.Rows[i].Cells[j].Value != null)
                                {
                                    hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                        }
                        libroDeTrabajo.SaveAs(archivo.FileName,
                            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libroDeTrabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Reporte generado con éxito");

                    }
                }
                if (BanderaEnvasado == true || BanderaEnvasadoExistente == true)
                {

                    if (archivo.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;

                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libroDeTrabajo = aplicacion.Workbooks.Add();
                        hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);

                        hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
                        hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
                        hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
                        hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
                        hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
                        hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
                        hojaDeTrabajo.Cells[1, "G"] = grd.Columns[6].HeaderText;
                        hojaDeTrabajo.Cells[1, "H"] = grd.Columns[7].HeaderText;
                        hojaDeTrabajo.Cells[1, "I"] = grd.Columns[8].HeaderText;
                        hojaDeTrabajo.Cells[1, "J"] = grd.Columns[9].HeaderText;
                        hojaDeTrabajo.Cells[1, "K"] = grd.Columns[10].HeaderText;
                        hojaDeTrabajo.Cells[1, "L"] = grd.Columns[11].HeaderText;
                        hojaDeTrabajo.Cells[1, "M"] = grd.Columns[12].HeaderText;
                        hojaDeTrabajo.Cells[1, "N"] = grd.Columns[13].HeaderText;
                        hojaDeTrabajo.Cells[1, "O"] = grd.Columns[14].HeaderText;
                       



                        hojaDeTrabajo.Columns[1].AutoFit();
                        hojaDeTrabajo.Columns[1].NumberFormat = "@";
                        hojaDeTrabajo.Columns[2].AutoFit();
                        hojaDeTrabajo.Columns[3].AutoFit();
                        hojaDeTrabajo.Columns[4].NumberFormat = "@";
                        hojaDeTrabajo.Columns[4].AutoFit();
                        hojaDeTrabajo.Columns[5].AutoFit();
                        hojaDeTrabajo.Columns[6].AutoFit();
                        hojaDeTrabajo.Columns[7].AutoFit();
                        hojaDeTrabajo.Columns[8].AutoFit();
                        hojaDeTrabajo.Columns[9].AutoFit();
                        hojaDeTrabajo.Columns[10].AutoFit();
                        hojaDeTrabajo.Columns[11].AutoFit();
                        hojaDeTrabajo.Columns[12].AutoFit();
                        hojaDeTrabajo.Columns[13].AutoFit();
                        hojaDeTrabajo.Columns[14].AutoFit();
                        hojaDeTrabajo.Columns[15].AutoFit();



                        hojaDeTrabajo.Name = "Reporte";
                        //Recorremos el DataGridView rellenando la hoja de trabajo
                        for (int i = 0; i < grd.Rows.Count; i++)
                        {
                            for (int j = 0; j < grd.Columns.Count; j++)
                            {
                                if (grd.Rows[i].Cells[j].Value != null)
                                {
                                    hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                                }
                            }
                        }
                        libroDeTrabajo.SaveAs(archivo.FileName,
                            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libroDeTrabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Reporte generado con éxito");
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }

        }

        //al presionar produccion 
        private void BtnProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                addTablaProduccion();
                LblValor.Text = "Producción";
                BanderaProduccion = true;
                BanderaGranelFabrica = false;
                BanderaEnvasadoExistente = false;
                BanderaEnvasado = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // al presionar granel de fabrica
        private void BtnGranel_Click(object sender, EventArgs e)
        {
            try
            {
                addTablaGranelFabrica();
                LblValor.Text = "Graneles";
                BanderaProduccion = false;
                BanderaGranelFabrica = true;
                BanderaEnvasadoExistente = false;
                BanderaEnvasado = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //al presionar granel envasado
        private void BtnEnvasadoGranel_Click(object sender, EventArgs e)
        {
            try
            {
                addTablaEnvasadoExistente();
                LblValor.Text = "Envasado existente";
                BanderaProduccion = false;
                BanderaGranelFabrica = false;
                BanderaEnvasadoExistente = true;
                BanderaEnvasado = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //al presionar envasado
        private void BtnEnvasado_Click(object sender, EventArgs e)
        {
            try
            {
                addTablaEnvasado();
                LblValor.Text = "Envasado producido";
                BanderaProduccion = false;
                BanderaGranelFabrica = false;
                BanderaEnvasadoExistente = false;
                BanderaEnvasado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExel_Click(object sender, EventArgs e)
        {
            if (DtaTabla.RowCount == 0)
            {
                MessageBox.Show("No hay registros para exportar");
                return;
            }

            ExportarDataGridViewExcel(DtaTabla);
        }

        private void FrmConsultas_Load(object sender, EventArgs e)
        {
            ConexionMysql.conecta();
            ConexionMysqlRemota2.conecta();

        }


        public string ObtieneCategoriaMezcal()
        {
            string CategoriaMezcal = "";
            string CategoriaMezcalComparar = "";
            string id_produccion = "";
            string id_coccion = "";
            string id_molienda = "";
            string id_fermentacion = "";
            string id_destilacion = "";



            id_produccion = id;


            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT id_coccion,id_molienda,id_fermentacion,id_destilacion FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'  ");
            //ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT id_coccion,id_molienda,id_fermentacion,id_destilacion FROM rv_produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'  ");
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                id_coccion = Convert.ToString(row["id_coccion"]);
                id_molienda = Convert.ToString(row["id_molienda"]);
                id_fermentacion = Convert.ToString(row["id_fermentacion"]);
                id_destilacion = Convert.ToString(row["id_destilacion"]);

                if (id_coccion == "3")
                {
                    CategoriaMezcal = "Mezcal";
                }
                else if (id_coccion == "2")
                {
                    if (id_molienda == "1" || id_molienda == "2" || id_molienda == "3" || id_molienda == "6")
                    {
                        if (id_fermentacion == "1" || id_fermentacion == "2" || id_fermentacion == "4" || id_fermentacion == "5" || id_fermentacion == "6" || id_fermentacion == "7" || id_fermentacion == "8")
                        {
                            if (id_destilacion == "1" || id_destilacion == "2" || id_destilacion == "3")
                            {
                                CategoriaMezcal = "Mezcal";
                            }
                            else
                            {
                                CategoriaMezcal = "Mezcal Artesanal";
                            }
                        }
                        else if (id_fermentacion == "3")
                        {
                            CategoriaMezcal = "Mezcal";
                        }
                    }
                    else if (id_molienda == "5" || id_molienda == "4")
                    {
                        CategoriaMezcal = "Mezcal";
                    }
                }
                else if (id_coccion == "1")
                {
                    if (id_molienda == "1" || id_molienda == "6")
                    {
                        if (id_fermentacion == "1" || id_fermentacion == "2" || id_fermentacion == "4" || id_fermentacion == "5" || id_fermentacion == "6" || id_fermentacion == "7" || id_fermentacion == "8")
                        {
                            if (id_destilacion == "12" || id_destilacion == "13")
                            {
                                CategoriaMezcal = "Mezcal Ancestral";
                            }
                            else if (id_destilacion == "1" || id_destilacion == "2" || id_destilacion == "3")
                            {
                                CategoriaMezcal = "Mezcal";
                            }
                            else
                            {
                                CategoriaMezcal = "Mezcal Artesanal";
                            }
                        }
                        else
                        {
                            CategoriaMezcal = "Mezcal";
                        }
                    }
                    else if (id_molienda == "2" || id_molienda == "3")
                    {
                        if (id_fermentacion == "1" || id_fermentacion == "2" || id_fermentacion == "4" || id_fermentacion == "5" || id_fermentacion == "6" || id_fermentacion == "7" || id_fermentacion == "8")
                        {
                            if (id_destilacion == "1" || id_destilacion == "2" || id_destilacion == "3")
                            {
                                CategoriaMezcal = "Mezcal";
                            }
                            else
                            {
                                CategoriaMezcal = "Mezcal Artesanal";
                            }
                        }
                        else
                        {
                            CategoriaMezcal = "Mezcal";
                        }
                    }
                    else if (id_molienda == "4" || id_molienda == "5")
                    {
                        CategoriaMezcal = "Mezcal";
                    }
                }
        
            }

            if (CategoriaMezcalComparar != "")
            {
                if (CategoriaMezcal == "Mezcal Artesanal")
                {
                    if (CategoriaMezcalComparar == "Mezcal")
                    {
                        CategoriaMezcal = CategoriaMezcalComparar;
                    }
                }
                else if (CategoriaMezcal == "Mezcal Ancestral")
                {
                    if (CategoriaMezcalComparar == "Mezcal")
                    {
                        CategoriaMezcal = CategoriaMezcalComparar;
                    }
                    else if (CategoriaMezcalComparar == "Mezcal Artesanal")
                    {
                        CategoriaMezcal = CategoriaMezcalComparar;
                    }
                }
            }
            return CategoriaMezcal;
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                if (BanderaProduccion == false && BanderaGranelFabrica == false && BanderaEnvasadoExistente == false && BanderaEnvasado == false)
                {
                    MessageBox.Show("Seleccione que decea consultar");
                    return;
                }

                int ResComparacionFechas = DateTime.Compare(fecha1.Value, fecha2.Value);
                if (ResComparacionFechas > 0)
                {
                    MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio");
                }


                if (BanderaProduccion == true)
                {

                   DataSet Datos = new DataSet();
                  // ConexionMysql.llenaDataset(ref Datos, "SELECT  produccion_entrada.id_produccion_entrada,DATE_FORMAT(produccion_entrada.fecha, '%d/%m/%Y') as fecha,produccion_entrada.no_cliente,produccion_entrada.tapada,produccion_entrada.id_predio,GROUP_CONCAT(DISTINCT TABLA.id_predio order by TABLA.agave_coccion_kg desc) as id_predio_ensamble,comun.nombre as maguey,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey, produccion_entrada.agave_coccion_kg,produccion_entrada.porcentaje_art, produccion_entrada.lts_producidos,produccion_entrada.grado_alcoholico,granel_entrada.no_lote,granel_entrada.fq,granel_entrada.clase,veri1.nombre as nom1,veri2.nombre as nom2 from  produccion_entrada  LEFT JOIN existenciaplanta ON  produccion_entrada.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN (SELECT   produccion_ensamble.id_produccion_entrada,comun.nombre as maguey,produccion_ensamble.agave_coccion_kg,produccion_ensamble. id_predio   FROM  produccion_ensamble   INNER JOIN existenciaplanta ON  produccion_ensamble.id_planta=existenciaplanta.id_plantas INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun) TABLA ON  produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada inner join verificadores as veri1 on  produccion_entrada.id_verificador= veri1.id_us left join verificadores as veri2 on  produccion_entrada.id_verifico_rendimiento= veri2.id_us  LEFT JOIN produccion_salida ON produccion_entrada.id_produccion_entrada=produccion_salida.id_produccion_entrada LEFT join granel_entrada ON produccion_salida.id_granel_entrada=granel_entrada.id_granel_entrada where   produccion_entrada.periodo_destilacion_fin  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "' and produccion_entrada.estatus=5 and produccion_entrada.no_cliente!=0   and produccion_entrada.lts_producidos!=0 GROUP BY  produccion_entrada.id_produccion_entrada  order by no_cliente ");
                   ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT  rv_produccion_entrada.categoria,DATE_FORMAT(rv_produccion_entrada.fecha, '%d/%m/%Y') as fecha,rv_produccion_entrada.no_cliente,rv_produccion_entrada.tapada,rv_produccion_entrada.id_predio,GROUP_CONCAT(DISTINCT TABLA.id_predio order by TABLA.agave_coccion_kg desc) as id_predio_ensamble,comun.nombre as maguey,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey, rv_produccion_entrada.agave_coccion_kg, rv_produccion_entrada.porcentaje_art, rv_produccion_entrada.lts_producidos, rv_produccion_entrada.grado_alcoholico from   rv_produccion_entrada LEFT JOIN existenciaplanta ON  rv_produccion_entrada.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN  (SELECT   rv_produccion_ensamble.id_produccion_entrada,comun.nombre as maguey,rv_produccion_ensamble.agave_coccion_kg,rv_produccion_ensamble. id_predio  FROM  rv_produccion_ensamble    INNER JOIN existenciaplanta ON  rv_produccion_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun) TABLA ON  rv_produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada  where   rv_produccion_entrada.estatus=5 and rv_produccion_entrada.no_cliente!=0  and rv_produccion_entrada.lts_producidos!=0 and LENGTH (rv_produccion_entrada.no_cliente)=4  GROUP BY  rv_produccion_entrada.id_produccion_entrada  order by no_cliente");
                   //ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT DISTINCT rv_produccion_entrada.no_cliente,rv_maestro_fabrica.fabrica,       rv_maestro_fabrica.maestro,       rv_maestro_fabrica.estado,       cat_coccion.coccion, cat_coccion.id_coccion,       cat_molienda.molienda,cat_molienda.id_molienda,       cat_fermentacion.fermentacion, cat_fermentacion.id_fermentacion,       cat_destilacion.destilacion,cat_destilacion.id_destilacion       FROM rv_produccion_entrada       INNER JOIN rv_maestro_fabrica ON rv_produccion_entrada.id_fabrica=rv_maestro_fabrica.id_fabrica       INNER JOIN cat_coccion ON rv_produccion_entrada.id_coccion=cat_coccion.id_coccion       INNER JOIN cat_molienda ON rv_produccion_entrada.id_molienda=cat_molienda.id_molienda       INNER JOIN cat_fermentacion  ON rv_produccion_entrada.id_fermentacion=cat_fermentacion.id_fermentacion       INNER JOIN cat_destilacion ON rv_produccion_entrada.id_destilacion=cat_destilacion.id_destilacion       order by rv_produccion_entrada.no_cliente");
                  
                    DataRow fila;
                    dtsProduccion.Tables["PRODUCCION"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {

                        //fila = dtsProduccion.Tables["PRODUCCION"].NewRow();
                       
                
                        //fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);

                        //fila["NO_PREDIO"] = Convert.ToString(row["fabrica"]);

                        //fila["%_ART"] = Convert.ToString(row["maestro"]);
                        //fila["KG_PINAS_COCCION"] = Convert.ToString(row["coccion"]);
                        //fila["REFERIDO_45"] = Convert.ToString(row["molienda"]);
                        //fila["PRODUCTO"] = Convert.ToString(row["fermentacion"]);
                        //fila["CATEGORIA"] = Convert.ToString(row["destilacion"]);




                        //string CategoriaMezcal = "";
                        //string id_coccion = Convert.ToString(row["id_coccion"]);
                        //string id_molienda = Convert.ToString(row["id_molienda"]);
                        //string id_fermentacion = Convert.ToString(row["id_fermentacion"]);
                        //string id_destilacion = Convert.ToString(row["id_destilacion"]);

                        //if (id_coccion == "3")
                        //{
                        //    CategoriaMezcal = "Mezcal";
                        //}
                        //else if (id_coccion == "2")
                        //{
                        //    if (id_molienda == "1" || id_molienda == "2" || id_molienda == "3" || id_molienda == "6")
                        //    {
                        //        if (id_fermentacion == "1" || id_fermentacion == "2" || id_fermentacion == "4" || id_fermentacion == "5" || id_fermentacion == "6" || id_fermentacion == "7" || id_fermentacion == "8")
                        //        {
                        //            if (id_destilacion == "1" || id_destilacion == "2" || id_destilacion == "3")
                        //            {
                        //                CategoriaMezcal = "Mezcal";
                        //            }
                        //            else
                        //            {
                        //                CategoriaMezcal = "Mezcal Artesanal";
                        //            }
                        //        }
                        //        else if (id_fermentacion == "3")
                        //        {
                        //            CategoriaMezcal = "Mezcal";
                        //        }
                        //    }
                        //    else if (id_molienda == "5" || id_molienda == "4")
                        //    {
                        //        CategoriaMezcal = "Mezcal";
                        //    }
                        //}
                        //else if (id_coccion == "1")
                        //{
                        //    if (id_molienda == "1" || id_molienda == "6")
                        //    {
                        //        if (id_fermentacion == "1" || id_fermentacion == "2" || id_fermentacion == "4" || id_fermentacion == "5" || id_fermentacion == "6" || id_fermentacion == "7" || id_fermentacion == "8")
                        //        {
                        //            if (id_destilacion == "12" || id_destilacion == "13")
                        //            {
                        //                CategoriaMezcal = "Mezcal Ancestral";
                        //            }
                        //            else if (id_destilacion == "1" || id_destilacion == "2" || id_destilacion == "3")
                        //            {
                        //                CategoriaMezcal = "Mezcal";
                        //            }
                        //            else
                        //            {
                        //                CategoriaMezcal = "Mezcal Artesanal";
                        //            }
                        //        }
                        //        else
                        //        {
                        //            CategoriaMezcal = "Mezcal";
                        //        }
                        //    }
                        //    else if (id_molienda == "2" || id_molienda == "3")
                        //    {
                        //        if (id_fermentacion == "1" || id_fermentacion == "2" || id_fermentacion == "4" || id_fermentacion == "5" || id_fermentacion == "6" || id_fermentacion == "7" || id_fermentacion == "8")
                        //        {
                        //            if (id_destilacion == "1" || id_destilacion == "2" || id_destilacion == "3")
                        //            {
                        //                CategoriaMezcal = "Mezcal";
                        //            }
                        //            else
                        //            {
                        //                CategoriaMezcal = "Mezcal Artesanal";
                        //            }
                        //        }
                        //        else
                        //        {
                        //            CategoriaMezcal = "Mezcal";
                        //        }
                        //    }
                        //    else if (id_molienda == "4" || id_molienda == "5")
                        //    {
                        //        CategoriaMezcal = "Mezcal";
                        //    }
                        //}





                        //fila["CLASE"] = CategoriaMezcal;


                        //fila["NO_LOTE"] = Convert.ToString(row["estado"]);

                        //dtsProduccion.Tables["PRODUCCION"].Rows.Add(fila);











                        fila = dtsProduccion.Tables["PRODUCCION"].NewRow();
                        //id = Convert.ToString(row["id_produccion_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        if (Convert.ToString(row["id_predio_ensamble"]) == "")
                        {
                            fila["NO_PREDIO"] = Convert.ToString(row["id_predio"]);
                        }
                        else
                        {
                            fila["NO_PREDIO"] = Convert.ToString(row["id_predio_ensamble"]);
                        }
                        fila["%_ART"] = Convert.ToString(row["porcentaje_art"]);
                        if (Convert.ToString(row["ensamble_maguey"]) == "")
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["maguey"]);
                        }
                        else
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        fila["KG_PINAS_COCCION"] = Convert.ToString(row["agave_coccion_kg"]);
                        double referido45;
                        referido45 = ((Math.Round(double.Parse(Convert.ToString(row["lts_producidos"])), 2) * Math.Round(double.Parse(Convert.ToString(row["grado_alcoholico"])), 2)) / 45);
                        //fila["REFERIDO_45"] = (Math.Round(referido45, 2));
                        fila["REFERIDO_45"] = Convert.ToString(row["lts_producidos"]);

                        string categoria = ObtieneCategoriaMezcal();
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        //if (Convert.ToString(row["no_lote"]) != "")
                        //{
                        //    fila["CLASE"] = Convert.ToString(row["clase"]);
                        //    fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        //    fila["FQ"] = Convert.ToString(row["fq"]);
                        //}
                        //else
                        //{
                            fila["CLASE"] = "Joven";
                            fila["NO_LOTE"] = Convert.ToString(row["tapada"]);
                            fila["FQ"] = Convert.ToString(row["grado_alcoholico"]); ;
                        //}

                        //fila["VERIFICADOR1"] = Convert.ToString(row["nom1"]);
                        //fila["VERIFICADOR2"] = Convert.ToString(row["nom2"]);
                        dtsProduccion.Tables["PRODUCCION"].Rows.Add(fila);
                    }
                }
                else if (BanderaGranelFabrica == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT * from (select verificadores.nombre,rv_produccion_salida.id_granel_entrada as valor,rv_granel_entrada.id_granel_entrada,DATE_FORMAT(rv_granel_entrada.fecha_subio, '%d/%m/%Y') as fecha,DATE_FORMAT(rv_granel_entrada.fecha, '%d/%m/%Y') as fecha2,rv_granel_entrada.no_cliente,GROUP_CONCAT(DISTINCT rv_granel_tanques.tanque) as tanque,comun.nombre as maguey,comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin,rv_granel_entrada.categoria, rv_granel_entrada.clase,rv_granel_entrada.ingrediente,rv_granel_entrada.fq, rv_granel_entrada.no_lote, rv_granel_entrada.lts_existentes,rv_granel_entrada.grado_alcoholico_existente     FROM rv_granel_entrada  INNER JOIN verificadores ON rv_granel_entrada.id_verificador=verificadores.id_us     LEFT JOIN existenciaplanta ON rv_granel_entrada.id_planta=existenciaplanta.id_plantas      LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON rv_granel_entrada.id_comun=comun2.id_comun  INNER JOIN rv_granel_tanques ON rv_granel_entrada.id_granel_entrada=rv_granel_tanques.id_granel_entrada     LEFT JOIN       ( SELECT rv_granel_ensamble.id_granel_entrada, rv_granel_ensamble.litros, rv_granel_ensamble.agave_coccion_kg, comun.nombre   FROM rv_granel_ensamble   INNER JOIN existenciaplanta ON rv_granel_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by rv_granel_ensamble.id_granel_entrada asc,rv_granel_ensamble.litros desc, rv_granel_ensamble.agave_coccion_kg desc) TABLA  ON rv_granel_entrada.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN  (   SELECT rv_granel_ensamble.id_granel_entrada,comun.nombre FROM rv_granel_ensamble INNER JOIN comun ON rv_granel_ensamble.id_comun=comun.id_comun  order by rv_granel_ensamble.id_granel_entrada asc  ) TABLA2 ON rv_granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada left  join  rv_produccion_salida on rv_granel_entrada.id_granel_entrada=rv_produccion_salida.id_granel_entrada  where    rv_granel_entrada.fecha_subio  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "'   and rv_granel_entrada.no_cliente!=0  and rv_granel_entrada.lts_existentes!=0  GROUP BY rv_granel_entrada.id order by no_cliente)tabla1 UNION  SELECT * from (select  verificadores.nombre,rv_granel_salida.id_granel_entrada as valor,rv_granel_entrada_envasado.id_granel_entrada_envasado as id_granel_entrada ,DATE_FORMAT(rv_granel_entrada_envasado.fecha_subio, '%d/%m/%Y') as fecha,DATE_FORMAT(rv_granel_entrada_envasado.fecha, '%d/%m/%Y') as fecha2,rv_granel_entrada_envasado.no_cliente,GROUP_CONCAT(DISTINCT rv_granel_tanques_envasado.tanque) as tanque,comun.nombre as maguey,comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey_sin,rv_granel_entrada_envasado.categoria, rv_granel_entrada_envasado.clase,rv_granel_entrada_envasado.ingrediente,rv_granel_entrada_envasado.fq, rv_granel_entrada_envasado.no_lote, rv_granel_entrada_envasado.lts_existentes,rv_granel_entrada_envasado.grado_alcoholico_existente     FROM rv_granel_entrada_envasado  INNER JOIN verificadores ON rv_granel_entrada_envasado.id_verificador=verificadores.id_us      LEFT JOIN existenciaplanta ON rv_granel_entrada_envasado.id_planta=existenciaplanta.id_plantas      LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun      LEFT JOIN comun as comun2 ON rv_granel_entrada_envasado.id_comun=comun2.id_comun      INNER JOIN rv_granel_tanques_envasado ON rv_granel_entrada_envasado.id_granel_entrada_envasado=rv_granel_tanques_envasado.id_granel_entrada_envasado     LEFT JOIN       ( SELECT rv_granel_ensamble_envasado.id_granel_entrada_envasado,     rv_granel_ensamble_envasado.litros,     rv_granel_ensamble_envasado.agave_coccion_kg,     comun.nombre               FROM rv_granel_ensamble_envasado               INNER JOIN existenciaplanta ON rv_granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by rv_granel_ensamble_envasado.id_granel_entrada_envasado asc,rv_granel_ensamble_envasado.litros desc, rv_granel_ensamble_envasado.agave_coccion_kg desc) TABLA  ON rv_granel_entrada_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado                 LEFT JOIN  (   SELECT rv_granel_ensamble_envasado.id_granel_entrada_envasado,comun.nombre FROM rv_granel_ensamble_envasado INNER JOIN comun ON rv_granel_ensamble_envasado.id_comun=comun.id_comun  order by rv_granel_ensamble_envasado.id_granel_entrada_envasado asc  ) TABLA2 ON rv_granel_entrada_envasado.id_granel_entrada_envasado=TABLA2.id_granel_entrada_envasado left  join  rv_granel_salida on rv_granel_entrada_envasado.id_granel_entrada_envasado=rv_granel_salida.id_granel_entrada_envasado left join rv_granel_entrada on  rv_granel_salida.id_granel_entrada=rv_granel_entrada.id_granel_entrada where  rv_granel_entrada_envasado.fecha_subio  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and  '" + fecha2.Value.ToString("yyyy-MM-dd") + "'   and rv_granel_entrada_envasado.no_cliente!=0  and rv_granel_entrada_envasado.lts_existentes!=0  GROUP BY rv_granel_entrada_envasado.id order by no_cliente)tabla2;");
                   // ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT * from (select rv_produccion_salida.id_granel_entrada as valor,rv_granel_entrada.id_granel_entrada,DATE_FORMAT(rv_granel_entrada.fecha_subio, '%d/%m/%Y') as fecha,DATE_FORMAT(rv_granel_entrada.fecha, '%d/%m/%Y') as fecha2,rv_granel_entrada.no_cliente,GROUP_CONCAT(DISTINCT rv_granel_tanques.tanque) as tanque,comun.nombre as maguey,comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin,rv_granel_entrada.categoria, rv_granel_entrada.clase,rv_granel_entrada.ingrediente,rv_granel_entrada.fq, rv_granel_entrada.no_lote, rv_granel_entrada.lts_existentes,rv_granel_entrada.grado_alcoholico_existente     FROM rv_granel_entrada      LEFT JOIN existenciaplanta ON rv_granel_entrada.id_planta=existenciaplanta.id_plantas      LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON rv_granel_entrada.id_comun=comun2.id_comun  INNER JOIN rv_granel_tanques ON rv_granel_entrada.id_granel_entrada=rv_granel_tanques.id_granel_entrada     LEFT JOIN       ( SELECT rv_granel_ensamble.id_granel_entrada, rv_granel_ensamble.litros, rv_granel_ensamble.agave_coccion_kg, comun.nombre   FROM rv_granel_ensamble   INNER JOIN existenciaplanta ON rv_granel_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by rv_granel_ensamble.id_granel_entrada asc,rv_granel_ensamble.litros desc, rv_granel_ensamble.agave_coccion_kg desc) TABLA  ON rv_granel_entrada.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN  (   SELECT rv_granel_ensamble.id_granel_entrada,comun.nombre FROM rv_granel_ensamble INNER JOIN comun ON rv_granel_ensamble.id_comun=comun.id_comun  order by rv_granel_ensamble.id_granel_entrada asc  ) TABLA2 ON rv_granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada left  join  rv_produccion_salida on rv_granel_entrada.id_granel_entrada=rv_produccion_salida.id_granel_entrada  where    rv_granel_entrada.fecha_subio='0000-00-00' and rv_granel_entrada.no_cliente!=0  and rv_granel_entrada.lts_existentes!=0  GROUP BY rv_granel_entrada.id order by no_cliente)tabla1 UNION  SELECT * from (select  rv_granel_salida.id_granel_entrada as valor,rv_granel_entrada_envasado.id_granel_entrada_envasado as id_granel_entrada ,DATE_FORMAT(rv_granel_entrada_envasado.fecha_subio, '%d/%m/%Y') as fecha,DATE_FORMAT(rv_granel_entrada_envasado.fecha, '%d/%m/%Y') as fecha2,rv_granel_entrada_envasado.no_cliente,GROUP_CONCAT(DISTINCT rv_granel_tanques_envasado.tanque) as tanque,comun.nombre as maguey,comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey_sin,rv_granel_entrada_envasado.categoria, rv_granel_entrada_envasado.clase,rv_granel_entrada_envasado.ingrediente,rv_granel_entrada_envasado.fq, rv_granel_entrada_envasado.no_lote, rv_granel_entrada_envasado.lts_existentes,rv_granel_entrada_envasado.grado_alcoholico_existente     FROM rv_granel_entrada_envasado      LEFT JOIN existenciaplanta ON rv_granel_entrada_envasado.id_planta=existenciaplanta.id_plantas      LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun      LEFT JOIN comun as comun2 ON rv_granel_entrada_envasado.id_comun=comun2.id_comun      INNER JOIN rv_granel_tanques_envasado ON rv_granel_entrada_envasado.id_granel_entrada_envasado=rv_granel_tanques_envasado.id_granel_entrada_envasado     LEFT JOIN       ( SELECT rv_granel_ensamble_envasado.id_granel_entrada_envasado,     rv_granel_ensamble_envasado.litros,     rv_granel_ensamble_envasado.agave_coccion_kg,     comun.nombre               FROM rv_granel_ensamble_envasado               INNER JOIN existenciaplanta ON rv_granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by rv_granel_ensamble_envasado.id_granel_entrada_envasado asc,rv_granel_ensamble_envasado.litros desc, rv_granel_ensamble_envasado.agave_coccion_kg desc) TABLA  ON rv_granel_entrada_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado                 LEFT JOIN  (   SELECT rv_granel_ensamble_envasado.id_granel_entrada_envasado,comun.nombre FROM rv_granel_ensamble_envasado INNER JOIN comun ON rv_granel_ensamble_envasado.id_comun=comun.id_comun  order by rv_granel_ensamble_envasado.id_granel_entrada_envasado asc  ) TABLA2 ON rv_granel_entrada_envasado.id_granel_entrada_envasado=TABLA2.id_granel_entrada_envasado left  join  rv_granel_salida on rv_granel_entrada_envasado.id_granel_entrada_envasado=rv_granel_salida.id_granel_entrada_envasado left join rv_granel_entrada on  rv_granel_salida.id_granel_entrada=rv_granel_entrada.id_granel_entrada where  rv_granel_entrada_envasado.fecha_subio ='0000-00-00'   and rv_granel_entrada_envasado.no_cliente!=0  and rv_granel_entrada_envasado.lts_existentes!=0  GROUP BY rv_granel_entrada_envasado.id order by no_cliente)tabla2;");
                    
                    DataRow fila;
                    dtsGranelFabrica.Tables["GRANEL_FABRICA"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
            
                        fila = dtsGranelFabrica.Tables["GRANEL_FABRICA"].NewRow();



                     
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["NO_TANQUE"] = Convert.ToString(row["tanque"]);
                        fila["PRODUCTO"] = "Mezcal 100% agave";
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["ensamble_maguey_sin"]);
                        }
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["FQ"] = Convert.ToString(row["fq"]);
                        fila["LOTE_GRANEL"] = Convert.ToString(row["no_lote"]);
                        fila["VOLUMEN"] = Convert.ToString(row["lts_existentes"]);
                        fila["GRADO_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["VERIFICADOR"] = Convert.ToString(row["nombre"]);
                        dtsGranelFabrica.Tables["GRANEL_FABRICA"].Rows.Add(fila);
                        }

                    
                }


                else if (BanderaEnvasado == true)
                {
                    DataSet Datos = new DataSet();
                    //ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT verificadores.nombre,  DATE_FORMAT(rv_envasado_entrada.fecha, '%d/%m/%Y') as fecha ,  rv_envasado_entrada.no_cliente,  marcas.marca,  rv_envasado_entrada.no_lote_granel,  GROUP_CONCAT(DISTINCT rv_envasado_ensamble.no_lote_granel order by rv_envasado_ensamble.id_envasado_entrada ASC ) as no_lote_granel_sin ,  GROUP_CONCAT(DISTINCT TABLA3.no_lote  ) as no_lote_GRANEL_RAS ,  rv_envasado_entrada.no_lote,  rv_envasado_entrada.fq,  rv_envasado_entrada.categoria,  rv_envasado_entrada.clase,  rv_envasado_entrada.ingrediente,  rv_envasado_entrada.abocante,  rv_envasado_entrada.unidad_medida,   rv_envasado_entrada.contenido_por_botella,  rv_envasado_entrada.grado_alcoholico,  rv_envasado_entrada.botellas,   rv_envasado_entrada.botellas_existentes FROM rv_envasado_entrada   LEFT JOIN existenciaplanta ON rv_envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON rv_envasado_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT rv_envasado_ensamble.id_envasado_entrada,rv_envasado_ensamble.litros,rv_envasado_ensamble.agave_coccion_kg,comun.nombre  FROM rv_envasado_ensamble INNER JOIN existenciaplanta ON rv_envasado_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by rv_envasado_ensamble.id_envasado_entrada asc, rv_envasado_ensamble.litros desc, rv_envasado_ensamble.agave_coccion_kg desc)  TABLA  ON rv_envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada  LEFT JOIN  ( SELECT rv_envasado_ensamble.id_envasado_entrada,comun.nombre   FROM rv_envasado_ensamble  INNER JOIN comun ON rv_envasado_ensamble.id_comun=comun.id_comun   order by rv_envasado_ensamble.id_envasado_entrada asc)  TABLA2  ON rv_envasado_entrada.id_envasado_entrada=TABLA2.id_envasado_entrada left join rv_envasado_ensamble on rv_envasado_entrada.id_envasado_entrada=rv_envasado_ensamble.id_envasado_entrada LEFT JOIN marcas ON SUBSTRING(rv_envasado_entrada.id_marca,1,4) =marcas.no_cliente and  SUBSTRING(rv_envasado_entrada.id_marca,6,1)=marcas.cve_marca left join ( select rv_granel_entrada_envasado.no_lote ,rv_envasado_entrada.id_envasado_entrada from rv_envasado_entrada inner join  rv_granel_salida on rv_envasado_entrada.id_envasado_entrada=rv_granel_salida.id_envasado_entrada  inner join rv_granel_entrada_envasado on rv_granel_salida.id_granel_entrada_envasado=rv_granel_entrada_envasado.id_granel_entrada_envasado ) TABLA3 ON rv_envasado_entrada.id_envasado_entrada=TABLA3.id_envasado_entrada inner join verificadores on rv_envasado_entrada.id_verificador= verificadores.id_us where   rv_envasado_entrada.fecha  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and  '" + fecha2.Value.ToString("yyyy-MM-dd") + "' and   rv_envasado_entrada.no_cliente!=0 and  LENGTH (rv_envasado_entrada.no_cliente)=4 GROUP BY rv_envasado_entrada.id_envasado_entrada order by no_cliente");
                    ConexionMysqlRemota2.llenaDataset(ref Datos, " SELECT GROUP_CONCAT( concat(tabla.destino,'=',tabla.botellas,'  ') ) as destino ,rv_envasado_entrada.id_envasado_entrada ,rv_envasado_entrada.grado_alcoholico,rv_envasado_entrada.categoria,rv_envasado_entrada.clase,rv_envasado_entrada.no_cliente,rv_envasadora_encargado.estado, marcas.marca,rv_envasado_entrada.unidad_medida,rv_envasado_entrada.contenido_por_botella,rv_envasado_entrada.botellas FROM rv_envasado_entrada    LEFT JOIN marcas ON SUBSTRING(rv_envasado_entrada.id_marca,1,4) =marcas.no_cliente and  SUBSTRING(rv_envasado_entrada.id_marca,6,1)=marcas.cve_marca inner join rv_envasadora_encargado on rv_envasado_entrada.id_envasadora=rv_envasadora_encargado.id_envasadora left join (select  id_envasado_entrada,  destino,  sum(botellas_existentes) as botellas from   rv_envasado_movimientos  where tipo='salida' and destino='Nacional'   group by id_envasado_entrada  union   select  id_envasado_entrada,  destino,  sum(botellas_existentes) as botellas   from   rv_envasado_movimientos  where tipo='salida' and destino='Exportación'  group by id_envasado_entrada  ) tabla  on rv_envasado_entrada.id_envasado_entrada=tabla.id_envasado_entrada  where LENGTH (rv_envasado_entrada.no_cliente)=4  GROUP BY rv_envasado_entrada.id_envasado_entrada  order by rv_envasado_entrada.no_cliente ");
                   
                   
                    
                    
                    DataRow fila;
                    dtsEnvasado.Tables["ENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsEnvasado.Tables["ENVASADO"].NewRow();
                        //fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["MARCA"] = Convert.ToString(row["marca"]);
                        //if (Convert.ToString(row["no_lote_granel"]) != "")
                        //{
                        //   fila["NO_LOTE_GRANEL"] = Convert.ToString(row["no_lote_granel"]);
                        //}
                        //else if (Convert.ToString(row["no_lote_granel_sin"]) != "")
                        //{
                        //   fila["NO_LOTE_GRANEL"] = Convert.ToString(row["no_lote_granel_sin"]);
                        //}
                        //else if (Convert.ToString(row["no_lote_GRANEL_RAS"]) != "")
                        //{
                        //    fila["NO_LOTE_GRANEL"] = Convert.ToString(row["no_lote_GRANEL_RAS"]);
                        //}
                        //else
                        //{
                        //    fila["NO_LOTE_GRANEL"] = "SIN LOTE";
                        //}

                        //fila["NO_LOTE_ENVASADO"] = Convert.ToString(row["no_lote"]);
                        fila["FQ"] = Convert.ToString(row["estado"]);
                        //fila["PRODUCTO"] ="Mezcal 100% Agave";
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        //fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["CAPACIDAD"] = Convert.ToString(row["contenido_por_botella"]) + "-" + Convert.ToString(row["unidad_medida"]);
                        fila["GRADO_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["NO_BOTELLAS"] = Convert.ToString(row["botellas"]);
                        //fila["CAJAS"] = "";

                        double conversion = 0;
                       
                        if (Convert.ToString(row["unidad_medida"])=="Mililitros")
                        {
                            conversion = Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2) / 1000;
                            fila["CAJAS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * conversion;
                        }
                        else if (Convert.ToString(row["unidad_medida"]) == "Litros")
                        {
                            fila["CAJAS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2);
                        }
                        else if (Convert.ToString(row["unidad_medida"]) == "Centilitro")
                        {
                            conversion = Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2) / 100;
                            fila["CAJAS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * conversion;
                        }

                        fila["VERIFICADOR"] = Convert.ToString(row["destino"]);
                        dtsEnvasado.Tables["ENVASADO"].Rows.Add(fila);
                    }
                }

                else if (BanderaEnvasadoExistente == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysqlRemota2.llenaDataset(ref Datos, "  SELECT  verificadores.nombre, DATE_FORMAT(rv_envasado_entrada.fecha, '%d/%m/%Y') as fecha ,  rv_envasado_entrada.no_cliente,  marcas.marca,  rv_envasado_entrada.no_lote_granel,  GROUP_CONCAT(DISTINCT rv_envasado_ensamble.no_lote_granel order by rv_envasado_ensamble.id_envasado_entrada ASC ) as no_lote_granel_sin ,  GROUP_CONCAT(DISTINCT TABLA3.no_lote  ) as no_lote_GRANEL_RAS ,  rv_envasado_entrada.no_lote,  rv_envasado_entrada.fq,  rv_envasado_entrada.categoria,  rv_envasado_entrada.clase,  rv_envasado_entrada.ingrediente,  rv_envasado_entrada.abocante,  rv_envasado_entrada.unidad_medida,   rv_envasado_entrada.contenido_por_botella,  rv_envasado_entrada.grado_alcoholico,  rv_envasado_entrada.botellas,   rv_envasado_entrada.botellas_existentes FROM rv_envasado_entrada  LEFT JOIN existenciaplanta ON rv_envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON rv_envasado_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT rv_envasado_ensamble.id_envasado_entrada,rv_envasado_ensamble.litros,rv_envasado_ensamble.agave_coccion_kg,comun.nombre  FROM rv_envasado_ensamble INNER JOIN existenciaplanta ON rv_envasado_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by rv_envasado_ensamble.id_envasado_entrada asc, rv_envasado_ensamble.litros desc, rv_envasado_ensamble.agave_coccion_kg desc)  TABLA  ON rv_envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada  LEFT JOIN  ( SELECT rv_envasado_ensamble.id_envasado_entrada,comun.nombre   FROM rv_envasado_ensamble  INNER JOIN comun ON rv_envasado_ensamble.id_comun=comun.id_comun   order by rv_envasado_ensamble.id_envasado_entrada asc)  TABLA2  ON rv_envasado_entrada.id_envasado_entrada=TABLA2.id_envasado_entrada left join rv_envasado_ensamble on rv_envasado_entrada.id_envasado_entrada=rv_envasado_ensamble.id_envasado_entrada LEFT JOIN marcas ON SUBSTRING(rv_envasado_entrada.id_marca,1,4) =marcas.no_cliente and  SUBSTRING(rv_envasado_entrada.id_marca,6,1)=marcas.cve_marca left join ( select rv_granel_entrada_envasado.no_lote ,rv_envasado_entrada.id_envasado_entrada from rv_envasado_entrada inner join  rv_granel_salida on rv_envasado_entrada.id_envasado_entrada=rv_granel_salida.id_envasado_entrada  inner join rv_granel_entrada_envasado on rv_granel_salida.id_granel_entrada_envasado=rv_granel_entrada_envasado.id_granel_entrada_envasado ) TABLA3 ON rv_envasado_entrada.id_envasado_entrada=TABLA3.id_envasado_entrada inner join verificadores on rv_envasado_entrada.id_verificador= verificadores.id_us where   rv_envasado_entrada.fecha_subio  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and  '" + fecha2.Value.ToString("yyyy-MM-dd") + "' and   rv_envasado_entrada.no_cliente!=0 and rv_envasado_entrada.botellas_existentes!=0  and  LENGTH (rv_envasado_entrada.no_cliente)=4 GROUP BY rv_envasado_entrada.id_envasado_entrada order by no_cliente");
                    DataRow fila;
                    dtsEnvasadoExistente.Tables["ENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsEnvasadoExistente.Tables["ENVASADO"].NewRow();
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["MARCA"] = Convert.ToString(row["marca"]);
                        if (Convert.ToString(row["no_lote_granel"]) != "")
                        {
                            fila["NO_LOTE_GRANEL"] = Convert.ToString(row["no_lote_granel"]);
                        }
                        else if (Convert.ToString(row["no_lote_granel_sin"]) != "")
                        {
                            fila["NO_LOTE_GRANEL"] = Convert.ToString(row["no_lote_granel_sin"]);
                        }
                        else if (Convert.ToString(row["no_lote_GRANEL_RAS"]) != "")
                        {
                            fila["NO_LOTE_GRANEL"] = Convert.ToString(row["no_lote_GRANEL_RAS"]);
                        }
                        else
                        {
                            fila["NO_LOTE_GRANEL"] = "SIN LOTE";
                        }
                        fila["NO_LOTE_ENVASADO"] = Convert.ToString(row["no_lote"]);
                        fila["FQ"] = Convert.ToString(row["fq"]);
                        fila["PRODUCTO"] = "Mezcal 100% Agave";
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["CAPACIDAD"] = Convert.ToString(row["contenido_por_botella"]) + "-" + Convert.ToString(row["unidad_medida"]);
                        fila["GRADO_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["NO_BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                        fila["CAJAS"] = "";
                        fila["VERIFICADOR"] = Convert.ToString(row["nombre"]);
                        dtsEnvasadoExistente.Tables["ENVASADO"].Rows.Add(fila);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
