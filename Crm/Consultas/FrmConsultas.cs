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
    public partial class FrmConsultas : Form
    {
        public FrmConsultas()
        {
            InitializeComponent();
        }

        DataSet dtsProduccion;
        DataSet dtsGranelFabrica;
        DataSet dtsGranelEnvasado;
        DataSet dtsEnvasado;
        DataSet dtsAlmacenGranel;
        DataSet dtsAlmacenEnvasado;

        Boolean BanderaProduccion = false;
        Boolean BanderaGranelFabrica = false;
        Boolean BanderaGranelEnvasado = false;
        Boolean BanderaEnvasado = false;
        Boolean BanderaAlmacenGranel = false;
        Boolean BanderaAlmacenEnvasado = false;


        private void addTablaProduccion()
        {
            dtsProduccion = new DataSet();
            dtsProduccion.Tables.Add("PRODUCCION");
            //dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FABRICA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("ESTADO_DE_FABRICA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("TAPADA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO_PREDIO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO_PINAS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("KG_PINAS_COCCION", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("%_ART", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_COCCION_INICIO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_COCCION_FIN", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_MOLINEDA_INICIO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_MOLINEDA_FIN", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_FORMULACION_INICIO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_FORMULACION_FIN", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_DESTILACION_INICIO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_DESTILACION_FIN", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("DESTILACIONES_REALIZADAS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("LITROS_PRODUCIDOS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("GRADO_ALCOHOLICO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("LITROS_EXISTENTES", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("PROCESO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            DtaTabla.DataSource = dtsProduccion.Tables["PRODUCCION"];

        }

        private void addTablaGranelFabrica()
        {
            dtsGranelFabrica = new DataSet();
            dtsGranelFabrica.Tables.Add("GRANEL_FABRICA");
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("FABRICA", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("ESTADO_DE_FABRICA", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("LITROS_ENTRADA", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("GRADO_ALCOHOLICO_ENTRADA", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("LITROS_EXISTENTES", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("GRADO_ALCOHOLICO_EXISTENTE", Type.GetType("System.String"));
            dtsGranelFabrica.Tables["GRANEL_FABRICA"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            DtaTabla.DataSource = dtsGranelFabrica.Tables["GRANEL_FABRICA"];

        }


        private void addTablaGranelEnvasado()
        {
            dtsGranelEnvasado = new DataSet();
            dtsGranelEnvasado.Tables.Add("GRANEL_ENVASADO");
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("ENVASADORA", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("ESTADO_DE_FABRICA", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("LITROS_ENTRADA", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("GRADO_ALCOHOLICO_ENTRADA", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("LITROS_EXISTENTES", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("GRADO_ALCOHOLICO_EXISTENTE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            DtaTabla.DataSource = dtsGranelEnvasado.Tables["GRANEL_ENVASADO"];

        }

        private void addTablaEnvasado()
        {
            dtsEnvasado = new DataSet();
            dtsEnvasado.Tables.Add("ENVASADO");
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("FECHA_INI", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("FECHA_FIN", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("ENVASADORA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("ESTADO_DE_FABRICA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("NO_LOTE_GRANEL", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("UNIDAD_DE_MEDIDA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("CONTENIDO_POR_BOTELLA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("LITROS_UTILIZADOS", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("BOTELLAS_INICIALES", Type.GetType("System.String")); //--Agregada
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("BOTELLAS_EXISTENTES", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("GRADO_ALCOHOLICO", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("HOLOGRAMA_INICIO", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("HOLOGRAMA_FIN", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsEnvasado.Tables["ENVASADO"].Columns.Add("ENVASADO_TERMINADO", Type.GetType("System.String"));//-- AGREGADA
            DtaTabla.DataSource = dtsEnvasado.Tables["ENVASADO"];

        }




        private void addTablaAlmacenGranel()
        {
            dtsAlmacenGranel = new DataSet();
            dtsAlmacenGranel.Tables.Add("ALMACEN_GRANEL");
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("ALMACEN", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("ESTADO_DE_ALMACEN", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("LITROS_ENTRADA", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("GRADO_ALCOHOLICO_ENTRADA", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("LITROS_EXISTENTES", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("GRADO_ALCOHOLICO_EXISTENTE", Type.GetType("System.String"));
            dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            DtaTabla.DataSource = dtsAlmacenGranel.Tables["ALMACEN_GRANEL"];

        }


        private void addTablaAlmacenEnvasado()
        {
            dtsAlmacenEnvasado = new DataSet();
            dtsAlmacenEnvasado.Tables.Add("ALMACENENVASADO");
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("NO_CLIENTE", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("FECHA_INI", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("FECHA_FIN", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("ALMACEN", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("ESTADO_DE_ALMACEN", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("NO_LOTE_GRANEL", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("ESPECIE_MAGUEY", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("UNIDAD_DE_MEDIDA", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("CONTENIDO_POR_BOTELLA", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("LITROS_UTILIZADOS", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("BOTELLAS_INICIALES", Type.GetType("System.String")); //--Agregada
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("BOTELLAS_EXISTENTES", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("GRADO_ALCOHOLICO", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("HOLOGRAMA_INICIO", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("HOLOGRAMA_FIN", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("VERIFICADOR", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Columns.Add("ENVASADO_TERMINADO", Type.GetType("System.String"));//-- AGREGADA
            DtaTabla.DataSource = dtsAlmacenEnvasado.Tables["ALMACENENVASADO"];

        }




        // genera el exel
        public void ExportarDataGridViewExcel(DataGridView grd)
        {
            try
            {

                SaveFileDialog archivo = new SaveFileDialog();
                archivo.Filter = "Excel (*.xls)|*.xls";
                archivo.FileName = "Reporte SInCa " + DateTime.Now.Date.ToShortDateString().Replace('/', '-');

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
                        hojaDeTrabajo.Cells[1, "O"] = grd.Columns[14].HeaderText;
                        hojaDeTrabajo.Cells[1, "P"] = grd.Columns[15].HeaderText;
                        hojaDeTrabajo.Cells[1, "Q"] = grd.Columns[16].HeaderText;
                        hojaDeTrabajo.Cells[1, "R"] = grd.Columns[17].HeaderText;
                        hojaDeTrabajo.Cells[1, "S"] = grd.Columns[18].HeaderText;
                        hojaDeTrabajo.Cells[1, "T"] = grd.Columns[19].HeaderText;
                        hojaDeTrabajo.Cells[1, "U"] = grd.Columns[20].HeaderText;
                        hojaDeTrabajo.Cells[1, "V"] = grd.Columns[21].HeaderText;
                        hojaDeTrabajo.Cells[1, "W"] = grd.Columns[22].HeaderText;




                        hojaDeTrabajo.Columns[1].AutoFit();
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
                        hojaDeTrabajo.Columns[10].NumberFormat = "@";
                        hojaDeTrabajo.Columns[11].AutoFit();
                        hojaDeTrabajo.Columns[11].NumberFormat = "@";
                        hojaDeTrabajo.Columns[12].AutoFit();
                        hojaDeTrabajo.Columns[12].NumberFormat = "@";
                        hojaDeTrabajo.Columns[13].AutoFit();
                        hojaDeTrabajo.Columns[13].NumberFormat = "@";
                        hojaDeTrabajo.Columns[14].AutoFit();
                        hojaDeTrabajo.Columns[14].NumberFormat = "@";
                        hojaDeTrabajo.Columns[15].AutoFit();
                        hojaDeTrabajo.Columns[15].NumberFormat = "@";
                        hojaDeTrabajo.Columns[16].AutoFit();
                        hojaDeTrabajo.Columns[16].NumberFormat = "@";
                        hojaDeTrabajo.Columns[17].AutoFit();
                        hojaDeTrabajo.Columns[17].NumberFormat = "@";
                        hojaDeTrabajo.Columns[18].AutoFit();
                        hojaDeTrabajo.Columns[18].NumberFormat = "@";
                        hojaDeTrabajo.Columns[19].AutoFit();
                        hojaDeTrabajo.Columns[19].NumberFormat = "@";
                        hojaDeTrabajo.Columns[20].AutoFit();
                        hojaDeTrabajo.Columns[21].AutoFit();
                        hojaDeTrabajo.Columns[22].AutoFit();
                        hojaDeTrabajo.Columns[23].AutoFit();



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
                else if (BanderaGranelFabrica == true || BanderaGranelEnvasado == true || BanderaAlmacenGranel == true)
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
                        hojaDeTrabajo.Cells[1, "P"] = grd.Columns[15].HeaderText;




                        hojaDeTrabajo.Columns[1].AutoFit();
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
                        hojaDeTrabajo.Columns[16].AutoFit();



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
                if (BanderaEnvasado == true || BanderaAlmacenEnvasado == true)
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
                        hojaDeTrabajo.Cells[1, "P"] = grd.Columns[15].HeaderText;
                        hojaDeTrabajo.Cells[1, "Q"] = grd.Columns[16].HeaderText;
                        hojaDeTrabajo.Cells[1, "R"] = grd.Columns[17].HeaderText;
                        hojaDeTrabajo.Cells[1, "S"] = grd.Columns[18].HeaderText;
                        hojaDeTrabajo.Cells[1, "T"] = grd.Columns[19].HeaderText;
                        hojaDeTrabajo.Cells[1, "U"] = grd.Columns[20].HeaderText;
                        hojaDeTrabajo.Cells[1, "V"] = grd.Columns[21].HeaderText;
                        hojaDeTrabajo.Cells[1, "W"] = grd.Columns[22].HeaderText;
                        hojaDeTrabajo.Cells[1, "X"] = grd.Columns[23].HeaderText;
                        hojaDeTrabajo.Cells[1, "Y"] = grd.Columns[24].HeaderText;//--- Agregada
                        hojaDeTrabajo.Cells[1, "Z"] = grd.Columns[25].HeaderText;//--- Agregada
                        //hojaDeTrabajo.Cells[1, "AA"] = grd.Columns[26].HeaderText;



                        hojaDeTrabajo.Columns[1].AutoFit();
                        hojaDeTrabajo.Columns[2].AutoFit();
                        hojaDeTrabajo.Columns[2].NumberFormat = "@";
                        hojaDeTrabajo.Columns[3].AutoFit();
                        hojaDeTrabajo.Columns[3].NumberFormat = "@";
                        hojaDeTrabajo.Columns[4].AutoFit();
                        hojaDeTrabajo.Columns[4].NumberFormat = "@";
                        hojaDeTrabajo.Columns[5].AutoFit();
                        hojaDeTrabajo.Columns[6].AutoFit();
                        hojaDeTrabajo.Columns[7].NumberFormat = "@";
                        hojaDeTrabajo.Columns[7].AutoFit();
                        hojaDeTrabajo.Columns[8].AutoFit();
                        hojaDeTrabajo.Columns[8].NumberFormat = "@";
                        hojaDeTrabajo.Columns[9].AutoFit();
                        hojaDeTrabajo.Columns[10].AutoFit();
                        hojaDeTrabajo.Columns[11].AutoFit();
                        hojaDeTrabajo.Columns[12].AutoFit();
                        hojaDeTrabajo.Columns[13].AutoFit();
                        hojaDeTrabajo.Columns[14].AutoFit();
                        hojaDeTrabajo.Columns[15].AutoFit();
                        hojaDeTrabajo.Columns[16].AutoFit();
                        hojaDeTrabajo.Columns[17].AutoFit();
                        hojaDeTrabajo.Columns[18].AutoFit();
                        hojaDeTrabajo.Columns[19].AutoFit();
                        hojaDeTrabajo.Columns[20].AutoFit();
                        hojaDeTrabajo.Columns[21].AutoFit();
                        hojaDeTrabajo.Columns[22].AutoFit();
                        hojaDeTrabajo.Columns[23].AutoFit();
                        hojaDeTrabajo.Columns[24].AutoFit();
                        hojaDeTrabajo.Columns[25].AutoFit();//--- Agregada
                        hojaDeTrabajo.Columns[26].AutoFit();
                        hojaDeTrabajo.Columns[26].NumberFormat = "@";
                        //hojaDeTrabajo.Columns[27].AutoFit();//--- Agregada




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
                BanderaGranelEnvasado = false;
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
                LblValor.Text = "Granel Fabrica";
                BanderaProduccion = false;
                BanderaGranelFabrica = true;
                BanderaGranelEnvasado = false;
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
                addTablaGranelEnvasado();
                LblValor.Text = "Granel Envasado";
                BanderaProduccion = false;
                BanderaGranelFabrica = false;
                BanderaGranelEnvasado = true;
                BanderaEnvasado = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEnvasado_Click(object sender, EventArgs e)
        {
            try
            {
                addTablaEnvasado();
                LblValor.Text = "Envasado";
                BanderaProduccion = false;
                BanderaGranelFabrica = false;
                BanderaGranelEnvasado = false;
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
            // ConexionMysql.llenaCombo(ref CmbNoCliente, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
            ConexionMysql.llenaComboAutocomplit(ref CmbNoCliente, "select no_cliente from clientes ", "no_cliente", "no_cliente");
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (BanderaProduccion == false && BanderaGranelFabrica == false && BanderaGranelEnvasado == false && BanderaEnvasado == false && BanderaAlmacenGranel == false && BanderaAlmacenEnvasado == false)
                {
                    MessageBox.Show("Seleccione que desea consultar");
                    return;
                }

                if (CmbNoCliente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente");
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
                    //-- Selecciona el rango de fecha de periodo_coccion_inicio <,DATE_FORMAT(produccion_entrada.fecha, '%d/%m/%Y') as fecha>
                    ConexionMysql.llenaDataset(ref Datos, "SELECT produccion_entrada.no_cliente,maestro_fabrica.fabrica,maestro_fabrica.estado,produccion_entrada.tapada,produccion_entrada.id_predio,GROUP_CONCAT(DISTINCT TABLA.id_predio order by TABLA.agave_coccion_kg desc) as id_predio_ensamble,comun.nombre as maguey,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey, produccion_entrada.no_pinas_agave, produccion_entrada.agave_coccion_kg,DATE_FORMAT(produccion_entrada.periodo_coccion_inicio, '%d/%m/%Y') as periodo_coccion_inicio,DATE_FORMAT(produccion_entrada.periodo_coccion_fin, '%d/%m/%Y') as periodo_coccion_fin,  produccion_entrada.porcentaje_art, DATE_FORMAT( produccion_entrada.periodo_molienda_inicio, '%d/%m/%Y') as periodo_molienda_inicio , DATE_FORMAT( produccion_entrada.periodo_molienda_fin, '%d/%m/%Y') as periodo_molienda_fin,DATE_FORMAT( produccion_entrada.periodo_formulacion_inicio, '%d/%m/%Y') as periodo_formulacion_inicio ,   DATE_FORMAT( produccion_entrada.periodo_formulacion_fin, '%d/%m/%Y') as periodo_formulacion_fin   , DATE_FORMAT( produccion_entrada.periodo_destilacion_inicio, '%d/%m/%Y') as periodo_destilacion_inicio    ,DATE_FORMAT( produccion_entrada.periodo_destilacion_fin, '%d/%m/%Y') as periodo_destilacion_fin       ,produccion_entrada.destilaciones_realizadas,produccion_entrada.lts_producidos,produccion_entrada.grado_alcoholico,produccion_entrada.lts_existentes , produccion_entrada.estatus,verificadores.nombre as verificador from  produccion_entrada LEFT JOIN existenciaplanta ON  produccion_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun inner join  maestro_fabrica on  produccion_entrada.id_fabrica=  maestro_fabrica.id_fabrica  LEFT JOIN (SELECT   produccion_ensamble.id_produccion_entrada,           comun.nombre as maguey,            produccion_ensamble.agave_coccion_kg,           produccion_ensamble. id_predio           FROM  produccion_ensamble           INNER JOIN existenciaplanta ON  produccion_ensamble.id_planta=existenciaplanta.id_plantas            INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun)TABLA            ON  produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada inner join verificadores on  produccion_entrada.id_verificador= verificadores.id_us  where    produccion_entrada.no_cliente='" + CmbNoCliente.SelectedValue + "'  and  produccion_entrada.periodo_coccion_inicio  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "'  GROUP BY  produccion_entrada.id_produccion_entrada  order by no_cliente ");
                    DataRow fila;
                    dtsProduccion.Tables["PRODUCCION"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProduccion.Tables["PRODUCCION"].NewRow();
                        //fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["FABRICA"] = Convert.ToString(row["fabrica"]);
                        fila["ESTADO_DE_FABRICA"] = Convert.ToString(row["estado"]);
                        fila["TAPADA"] = Convert.ToString(row["tapada"]);
                        if (Convert.ToString(row["id_predio_ensamble"]) == "")
                        {
                            fila["NO_PREDIO"] = Convert.ToString(row["id_predio"]);
                        }
                        else
                        {
                            fila["NO_PREDIO"] = Convert.ToString(row["id_predio_ensamble"]);
                        }
                        if (Convert.ToString(row["ensamble_maguey"]) == "")
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["maguey"]);
                        }
                        else
                        {
                            fila["ESPECIE_MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        fila["NO_PINAS"] = Convert.ToString(row["no_pinas_agave"]);
                        fila["KG_PINAS_COCCION"] = Convert.ToString(row["agave_coccion_kg"]);
                        fila["%_ART"] = Convert.ToString(row["porcentaje_art"]);
                        fila["FECHA_COCCION_INICIO"] = Convert.ToString(row["periodo_coccion_inicio"]);
                        fila["FECHA_COCCION_FIN"] = Convert.ToString(row["periodo_coccion_fin"]);
                        fila["FECHA_MOLINEDA_INICIO"] = Convert.ToString(row["periodo_molienda_inicio"]);
                        fila["FECHA_MOLINEDA_FIN"] = Convert.ToString(row["periodo_molienda_fin"]);
                        fila["FECHA_FORMULACION_INICIO"] = Convert.ToString(row["periodo_formulacion_inicio"]);
                        fila["FECHA_FORMULACION_FIN"] = Convert.ToString(row["periodo_formulacion_fin"]);
                        fila["FECHA_DESTILACION_INICIO"] = Convert.ToString(row["periodo_destilacion_inicio"]);
                        fila["FECHA_DESTILACION_FIN"] = Convert.ToString(row["periodo_destilacion_fin"]);
                        fila["DESTILACIONES_REALIZADAS"] = Convert.ToString(row["destilaciones_realizadas"]);
                        fila["LITROS_PRODUCIDOS"] = Convert.ToString(row["lts_producidos"]);
                        fila["GRADO_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["LITROS_EXISTENTES"] = Convert.ToString(row["lts_existentes"]);

                        fila["VERIFICADOR"] = Convert.ToString(row["verificador"]);


                        if (Convert.ToString(row["estatus"]) == "1")
                        {
                            fila["PROCESO"] = "Coccion";
                        }
                        else if (Convert.ToString(row["estatus"]) == "2")
                        {
                            fila["PROCESO"] = "Molienda";
                        }
                        else if (Convert.ToString(row["estatus"]) == "3")
                        {
                            fila["PROCESO"] = "Formulacion";
                        }
                        else if (Convert.ToString(row["estatus"]) == "4")
                        {
                            fila["PROCESO"] = "Destilacion";
                        }
                        else if (Convert.ToString(row["estatus"]) == "5")
                        {
                            fila["PROCESO"] = "Producido";
                        }

                        dtsProduccion.Tables["PRODUCCION"].Rows.Add(fila);
                    }
                }
                else if (BanderaGranelFabrica == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  DATE_FORMAT( granel_entrada.fecha, '%d/%m/%Y') as fecha,   granel_entrada.no_cliente,maestro_fabrica.fabrica,maestro_fabrica.estado,    granel_entrada.no_lote,    comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  granel_tanques.tanque) as tanque,    granel_entrada.fq,     granel_entrada.clase,    granel_entrada.categoria,     granel_entrada.abocante,     granel_entrada.ingrediente,    granel_entrada.lts_entrada,   granel_entrada.grado_alcoholico_entrada,    granel_entrada.lts_existentes,      granel_entrada.grado_alcoholico_existente,    verificadores.nombre as verificador       FROM  granel_entrada            LEFT JOIN existenciaplanta ON  granel_entrada.id_planta=existenciaplanta.id_plantas            LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  granel_entrada.id_comun=comun2.id_comun             INNER JOIN  granel_tanques ON  granel_entrada.id_granel_entrada= granel_tanques.id_granel_entrada            inner join maestro_fabrica on granel_entrada.id_fabrica= maestro_fabrica.id_fabrica              LEFT JOIN                ( SELECT  granel_ensamble.id_granel_entrada,               granel_ensamble.litros,               granel_ensamble.agave_coccion_kg,              comun.nombre               FROM  granel_ensamble               INNER JOIN existenciaplanta ON  granel_ensamble.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc,  granel_ensamble.agave_coccion_kg desc) TABLA  ON  granel_entrada.id_granel_entrada=TABLA.id_granel_entrada                LEFT JOIN  (   SELECT  granel_ensamble.id_granel_entrada,comun.nombre FROM  granel_ensamble INNER JOIN comun ON  granel_ensamble.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc  ) TABLA2 ON  granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada                 inner join verificadores on  granel_entrada.id_verificador= verificadores.id_us    where    granel_entrada.no_cliente='" + CmbNoCliente.SelectedValue + "'  and  granel_entrada.fecha  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "'       GROUP BY  granel_entrada.id order by no_cliente ");
                    DataRow fila;
                    dtsGranelFabrica.Tables["GRANEL_FABRICA"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsGranelFabrica.Tables["GRANEL_FABRICA"].NewRow();
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["FABRICA"] = Convert.ToString(row["fabrica"]);
                        fila["ESTADO_DE_FABRICA"] = Convert.ToString(row["estado"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);

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
                        fila["TANQUE"] = Convert.ToString(row["tanque"]);
                        fila["FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS_ENTRADA"] = Convert.ToString(row["lts_entrada"]);
                        fila["GRADO_ALCOHOLICO_ENTRADA"] = Convert.ToString(row["grado_alcoholico_entrada"]);
                        fila["LITROS_EXISTENTES"] = Convert.ToString(row["lts_existentes"]);
                        fila["GRADO_ALCOHOLICO_EXISTENTE"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["VERIFICADOR"] = Convert.ToString(row["verificador"]);
                        dtsGranelFabrica.Tables["GRANEL_FABRICA"].Rows.Add(fila);
                    }
                }
                else if (BanderaGranelEnvasado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT    DATE_FORMAT( granel_entrada_envasado.fecha, '%d/%m/%Y') as fecha,   granel_entrada_envasado.no_cliente,   envasadora_encargado.envasadora,    envasadora_encargado.estado,    granel_entrada_envasado.no_lote,     comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  granel_tanques_envasado.tanque) as tanque ,    granel_entrada_envasado.fq,     granel_entrada_envasado.clase,    granel_entrada_envasado.categoria,     granel_entrada_envasado.abocante,     granel_entrada_envasado.ingrediente,  granel_entrada_envasado.lts_entrada,   granel_entrada_envasado.grado_alcoholico_entrada,        granel_entrada_envasado.lts_existentes,      granel_entrada_envasado.grado_alcoholico_existente,    verificadores.nombre as verificador         FROM  granel_entrada_envasado            LEFT JOIN existenciaplanta ON  granel_entrada_envasado.id_planta=existenciaplanta.id_plantas             LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  granel_entrada_envasado.id_comun=comun2.id_comun             INNER JOIN  granel_tanques_envasado ON  granel_entrada_envasado.id_granel_entrada_envasado= granel_tanques_envasado.id_granel_entrada_envasado             inner join envasadora_encargado on granel_entrada_envasado.id_envasadora= envasadora_encargado.id_envasadora              LEFT JOIN                ( SELECT  granel_ensamble_envasado.id_granel_entrada_envasado,               granel_ensamble_envasado.litros,               granel_ensamble_envasado.agave_coccion_kg,              comun.nombre               FROM  granel_ensamble_envasado               INNER JOIN existenciaplanta ON  granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc,  granel_ensamble_envasado.agave_coccion_kg desc) TABLA  ON  granel_entrada_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado                LEFT JOIN  (   SELECT  granel_ensamble_envasado.id_granel_entrada_envasado,comun.nombre FROM  granel_ensamble_envasado INNER JOIN comun ON  granel_ensamble_envasado.id_comun=comun.id_comun  order by  granel_ensamble_envasado.id_granel_entrada_envasado asc  ) TABLA2 ON  granel_entrada_envasado.id_granel_entrada_envasado=TABLA2.id_granel_entrada_envasado                  inner join verificadores on  granel_entrada_envasado.id_verificador= verificadores.id_us     where    granel_entrada_envasado.no_cliente='" + CmbNoCliente.SelectedValue + "'  and  granel_entrada_envasado.fecha  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "'            GROUP BY  granel_entrada_envasado.id order by no_cliente");
                    DataRow fila;
                    dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].NewRow();
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["ENVASADORA"] = Convert.ToString(row["envasadora"]);
                        fila["ESTADO_DE_FABRICA"] = Convert.ToString(row["estado"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);

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
                        fila["TANQUE"] = Convert.ToString(row["tanque"]);
                        fila["FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS_ENTRADA"] = Convert.ToString(row["lts_entrada"]);
                        fila["GRADO_ALCOHOLICO_ENTRADA"] = Convert.ToString(row["grado_alcoholico_entrada"]);
                        fila["LITROS_EXISTENTES"] = Convert.ToString(row["lts_existentes"]);
                        fila["GRADO_ALCOHOLICO_EXISTENTE"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["VERIFICADOR"] = Convert.ToString(row["verificador"]);
                        dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Rows.Add(fila);
                    }
                }
                else if( BanderaAlmacenGranel == true){

                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  DATE_FORMAT( almacen_granel_entrada.fecha, '%d/%m/%Y') as fecha,   almacen_granel_entrada.no_cliente,almacen_encargado.almacen,almacen_encargado.estado,    almacen_granel_entrada.no_lote,    comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_granel_entrada ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_almacen_granel_entrada ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  almacen_granel_tanques.tanque) as tanque,    almacen_granel_entrada.fq,     almacen_granel_entrada.clase,    almacen_granel_entrada.categoria,     almacen_granel_entrada.abocante,     almacen_granel_entrada.ingrediente,    almacen_granel_entrada.lts_entrada,   almacen_granel_entrada.grado_alcoholico_entrada,    almacen_granel_entrada.lts_existentes,      almacen_granel_entrada.grado_alcoholico_existente,    verificadores.nombre as verificador       FROM  almacen_granel_entrada            LEFT JOIN existenciaplanta ON  almacen_granel_entrada.id_planta=existenciaplanta.id_plantas            LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  almacen_granel_entrada.id_comun=comun2.id_comun             INNER JOIN  almacen_granel_tanques ON  almacen_granel_entrada.id_almacen_granel_entrada= almacen_granel_tanques.id_almacen_granel_entrada            inner join almacen_encargado on almacen_granel_entrada.id_almacen= almacen_encargado.id_almacen              LEFT JOIN                ( SELECT  almacen_granel_ensamble.id_almacen_granel_entrada,               almacen_granel_ensamble.litros,               almacen_granel_ensamble.agave_coccion_kg,              comun.nombre               FROM  almacen_granel_ensamble               INNER JOIN existenciaplanta ON  almacen_granel_ensamble.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  almacen_granel_ensamble.id_almacen_granel_entrada asc, almacen_granel_ensamble.litros desc,  almacen_granel_ensamble.agave_coccion_kg desc) TABLA  ON  almacen_granel_entrada.id_almacen_granel_entrada=TABLA.id_almacen_granel_entrada                LEFT JOIN  (   SELECT  almacen_granel_ensamble.id_almacen_granel_entrada,comun.nombre FROM  almacen_granel_ensamble INNER JOIN comun ON  almacen_granel_ensamble.id_comun=comun.id_comun  order by  almacen_granel_ensamble.id_almacen_granel_entrada asc  ) TABLA2 ON  almacen_granel_entrada.id_almacen_granel_entrada=TABLA2.id_almacen_granel_entrada                 inner join verificadores on  almacen_granel_entrada.id_verificador= verificadores.id_us    where    almacen_granel_entrada.no_cliente='" + CmbNoCliente.SelectedValue + "'  and  almacen_granel_entrada.fecha  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "'  and almacen_encargado.tipo_almacen=1      GROUP BY almacen_granel_entrada.id order by no_cliente ");
                    DataRow fila;
                    dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].NewRow();
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["AlMACEN"] = Convert.ToString(row["almacen"]);
                        fila["ESTADO_DE_ALMACEN"] = Convert.ToString(row["estado"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);

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
                        fila["TANQUE"] = Convert.ToString(row["tanque"]);
                        fila["FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS_ENTRADA"] = Convert.ToString(row["lts_entrada"]);
                        fila["GRADO_ALCOHOLICO_ENTRADA"] = Convert.ToString(row["grado_alcoholico_entrada"]);
                        fila["LITROS_EXISTENTES"] = Convert.ToString(row["lts_existentes"]);
                        fila["GRADO_ALCOHOLICO_EXISTENTE"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["VERIFICADOR"] = Convert.ToString(row["verificador"]);
                        dtsAlmacenGranel.Tables["ALMACEN_GRANEL"].Rows.Add(fila);
                    }
                
                
                
                
                }
                else if (BanderaEnvasado == true)
                //Se agregaron las botellas inicales
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT   DATE_FORMAT( envasado_entrada.fecha_envasado_ini, '%d/%m/%Y') as fecha_ini, DATE_FORMAT( envasado_entrada.fecha_envasado_fin, '%d/%m/%Y') as fecha_fin,   envasado_entrada.no_cliente,      envasadora_encargado.envasadora,    envasadora_encargado.estado,  DATE_FORMAT( envasado_entrada.fecha, '%d/%m/%Y') as fecha ,   envasado_entrada.no_lote,   marcas.marca,   envasado_entrada.no_lote_granel,  GROUP_CONCAT(DISTINCT  envasado_ensamble.no_lote_granel order by  envasado_ensamble.id_envasado_entrada ASC ) as no_lote_granel_sin ,  GROUP_CONCAT(DISTINCT TABLA3.no_lote  ) as no_lote_GRANEL_RAS ,   envasado_entrada.fq,   envasado_entrada.clase,   envasado_entrada.categoria,   envasado_entrada.abocante,   envasado_entrada.ingrediente,  comun.nombre as maguey,  comun2.nombre as maguey_sin,  GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_envasado_entrada ASC ) as ensamble_maguey ,  GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_envasado_entrada ASC ) as ensamble_maguey_sin ,   envasado_entrada.unidad_medida,    envasado_entrada.contenido_por_botella,   envasado_entrada.litros as litros_utilizados, envasado_entrada.botellas_iniciales,  envasado_entrada.botellas,    envasado_entrada.botellas_existentes,    envasado_entrada.grado_alcoholico,   envasado_entrada.holograma_inicio,   envasado_entrada.holograma_fin,  verificadores.nombre as verificador, CASE envasado_entrada.id_marca when NULL then 'No terminado' when 0  then 'No Terminado' when '' then 'No Terminado' ELSE 'Terminado' END as envasado_terminado FROM  envasado_entrada   LEFT JOIN existenciaplanta ON  envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON  envasado_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT  envasado_ensamble.id_envasado_entrada, envasado_ensamble.litros, envasado_ensamble.agave_coccion_kg,comun.nombre  FROM  envasado_ensamble INNER JOIN existenciaplanta ON  envasado_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by  envasado_ensamble.id_envasado_entrada asc,  envasado_ensamble.litros desc,  envasado_ensamble.agave_coccion_kg desc)  TABLA  ON  envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada  LEFT JOIN  ( SELECT  envasado_ensamble.id_envasado_entrada,comun.nombre  FROM  envasado_ensamble  INNER JOIN comun ON  envasado_ensamble.id_comun=comun.id_comun   order by  envasado_ensamble.id_envasado_entrada asc)  TABLA2  ON  envasado_entrada.id_envasado_entrada=TABLA2.id_envasado_entrada left join  envasado_ensamble on  envasado_entrada.id_envasado_entrada= envasado_ensamble.id_envasado_entrada LEFT JOIN marcas ON SUBSTRING(envasado_entrada.id_marca,1,4) =marcas.no_cliente and  SUBSTRING(envasado_entrada.id_marca,6,1)=marcas.cve_marca left join ( select  granel_entrada_envasado.no_lote , envasado_entrada.id_envasado_entrada from  envasado_entrada inner join   granel_salida on  envasado_entrada.id_envasado_entrada= granel_salida.id_envasado_entrada inner join  granel_entrada_envasado on  granel_salida.id_granel_entrada_envasado= granel_entrada_envasado.id_granel_entrada_envasado ) TABLA3 ON  envasado_entrada.id_envasado_entrada=TABLA3.id_envasado_entrada  inner join envasadora_encargado on envasado_entrada.id_envasadora= envasadora_encargado.id_envasadora  inner join verificadores on  envasado_entrada.id_verificador= verificadores.id_us     where    envasado_entrada.no_cliente='" + CmbNoCliente.SelectedValue + "'  and  envasado_entrada.fecha  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "'  GROUP BY envasado_entrada.id_envasado_entrada order by envasado_entrada.id_marca =0 DESC");
                    //-- envasado_entrada.id_envasado_entrada order by no_cliente
                    DataRow fila;
                    dtsEnvasado.Tables["ENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {

                        fila = dtsEnvasado.Tables["ENVASADO"].NewRow();
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["FECHA_INI"] = Convert.ToString(row["fecha_ini"]);
                        fila["FECHA_FIN"] = Convert.ToString(row["fecha_fin"]);
                        fila["ENVASADORA"] = Convert.ToString(row["envasadora"]);
                        fila["ESTADO_DE_FABRICA"] = Convert.ToString(row["estado"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
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
                        fila["MARCA"] = Convert.ToString(row["marca"]);
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
                        fila["FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["UNIDAD_DE_MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CONTENIDO_POR_BOTELLA"] = Convert.ToString(row["contenido_por_botella"]);

                        double conversion = 0;

                        if (Convert.ToString(row["unidad_medida"]) == "Mililitros")
                        {
                            conversion = Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2) / 1000;
                            fila["LITROS_UTILIZADOS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * conversion;
                        }
                        else if (Convert.ToString(row["unidad_medida"]) == "Litros")
                        {
                            fila["LITROS_UTILIZADOS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2);
                        }
                        else if (Convert.ToString(row["unidad_medida"]) == "Centilitro")
                        {
                            conversion = Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2) / 100;
                            fila["LITROS_UTILIZADOS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * conversion;
                        }






                        fila["BOTELLAS_INICIALES"] = Convert.ToString(row["botellas_iniciales"]);//--Agregada
                        fila["BOTELLAS"] = Convert.ToString(row["botellas"]);
                        fila["BOTELLAS_EXISTENTES"] = Convert.ToString(row["botellas_existentes"]);

                        fila["GRADO_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["HOLOGRAMA_INICIO"] = Convert.ToString(row["holograma_inicio"]);
                        fila["HOLOGRAMA_FIN"] = Convert.ToString(row["holograma_fin"]);
                        fila["VERIFICADOR"] = Convert.ToString(row["verificador"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["ENVASADO_TERMINADO"] = Convert.ToString(row["envasado_terminado"]);
                        dtsEnvasado.Tables["ENVASADO"].Rows.Add(fila);
                    }



                }
                else if (BanderaAlmacenEnvasado == true)
                {

                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT   DATE_FORMAT( almacen_envasado_entrada.fecha_envasado_ini, '%d/%m/%Y') as fecha_ini, DATE_FORMAT( almacen_envasado_entrada.fecha_envasado_fin, '%d/%m/%Y') as fecha_fin,   almacen_envasado_entrada.no_cliente,      almacen_encargado.almacen,    almacen_encargado.estado,  DATE_FORMAT( almacen_envasado_entrada.fecha, '%d/%m/%Y') as fecha ,   almacen_envasado_entrada.no_lote,   marcas.marca,   almacen_envasado_entrada.no_lote_granel,  GROUP_CONCAT(DISTINCT  almacen_envasado_ensamble.no_lote_granel order by  almacen_envasado_ensamble.id_almacen_envasado_entrada ASC ) as no_lote_granel_sin ,  GROUP_CONCAT(DISTINCT TABLA3.no_lote  ) as no_lote_GRANEL_RAS ,   almacen_envasado_entrada.fq,   almacen_envasado_entrada.clase,   almacen_envasado_entrada.categoria,   almacen_envasado_entrada.abocante,   almacen_envasado_entrada.ingrediente,  comun.nombre as maguey,  comun2.nombre as maguey_sin,  GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_envasado_entrada ASC ) as ensamble_maguey ,  GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_almacen_envasado_entrada ASC ) as ensamble_maguey_sin ,   almacen_envasado_entrada.unidad_medida,    almacen_envasado_entrada.contenido_por_botella,   almacen_envasado_entrada.litros as litros_utilizados, almacen_envasado_entrada.botellas_iniciales,  almacen_envasado_entrada.botellas,    almacen_envasado_entrada.botellas_existentes,    almacen_envasado_entrada.grado_alcoholico,   almacen_envasado_entrada.holograma_inicio,   almacen_envasado_entrada.holograma_fin,  verificadores.nombre as verificador, CASE almacen_envasado_entrada.id_marca when NULL then 'No terminado' when 0  then 'No Terminado' when '' then 'No Terminado' ELSE 'Terminado' END as envasado_terminado FROM  almacen_envasado_entrada   LEFT JOIN existenciaplanta ON  almacen_envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON  almacen_envasado_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT  almacen_envasado_ensamble.id_almacen_envasado_entrada, almacen_envasado_ensamble.litros, almacen_envasado_ensamble.agave_coccion_kg,comun.nombre  FROM  almacen_envasado_ensamble INNER JOIN existenciaplanta ON  almacen_envasado_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by  almacen_envasado_ensamble.id_almacen_envasado_entrada asc,  almacen_envasado_ensamble.litros desc,  almacen_envasado_ensamble.agave_coccion_kg desc)  TABLA  ON  almacen_envasado_entrada.id_almacen_envasado_entrada=TABLA.id_almacen_envasado_entrada  LEFT JOIN  ( SELECT  almacen_envasado_ensamble.id_almacen_envasado_entrada,comun.nombre  FROM  almacen_envasado_ensamble  INNER JOIN comun ON  almacen_envasado_ensamble.id_comun=comun.id_comun   order by  almacen_envasado_ensamble.id_almacen_envasado_entrada asc)  TABLA2  ON  almacen_envasado_entrada.id_almacen_envasado_entrada=TABLA2.id_almacen_envasado_entrada left join  almacen_envasado_ensamble on  almacen_envasado_entrada.id_almacen_envasado_entrada= almacen_envasado_ensamble.id_almacen_envasado_entrada LEFT JOIN marcas ON SUBSTRING(almacen_envasado_entrada.id_marca,1,4) =marcas.no_cliente and  SUBSTRING(almacen_envasado_entrada.id_marca,6,1)=marcas.cve_marca left join ( SELECT granel_entrada_envasado.no_lote,almacen_envasado_entrada.id_almacen_envasado_entrada FROM  almacen_envasado_entrada INNER JOIN envasado_salida ON envasado_salida.id_almacen_envasado_entrada = almacen_envasado_entrada.id_almacen_envasado_entrada INNER JOIN envasado_entrada ON envasado_entrada.id_envasado_entrada = envasado_salida.id_envasado_entrada INNER JOIN granel_salida ON granel_salida.id_envasado_entrada = envasado_entrada.id_envasado_entrada INNER JOIN granel_entrada_envasado ON granel_entrada_envasado.id_granel_entrada_envasado = granel_salida.id_granel_entrada_envasado ) TABLA3 ON  almacen_envasado_entrada.id_almacen_envasado_entrada=TABLA3.id_almacen_envasado_entrada  inner join almacen_encargado on almacen_envasado_entrada.id_almacen  collate utf8_unicode_ci = almacen_encargado.id_almacen  inner join verificadores on  almacen_envasado_entrada.id_verificador= verificadores.id_us     where  almacen_encargado.tipo_almacen=2 and   almacen_envasado_entrada.no_cliente='" + CmbNoCliente.SelectedValue + "'  and  almacen_envasado_entrada.fecha  BETWEEN '" + fecha1.Value.ToString("yyyy-MM-dd") + "'  and '" + fecha2.Value.ToString("yyyy-MM-dd") + "'  GROUP BY almacen_envasado_entrada.id_almacen_envasado_entrada order by almacen_envasado_entrada.id_marca =0 DESC");
                    //-- envasado_entrada.id_envasado_entrada order by no_cliente
                    DataRow fila;
                    dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {

                        fila = dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].NewRow();
                        fila["NO_CLIENTE"] = Convert.ToString(row["no_cliente"]);
                        fila["FECHA_INI"] = Convert.ToString(row["fecha_ini"]);
                        fila["FECHA_FIN"] = Convert.ToString(row["fecha_fin"]);
                        fila["ALMACEN"] = Convert.ToString(row["almacen"]);
                        fila["ESTADO_DE_ALMACEN"] = Convert.ToString(row["estado"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
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
                        fila["MARCA"] = Convert.ToString(row["marca"]);
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
                        fila["FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["UNIDAD_DE_MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CONTENIDO_POR_BOTELLA"] = Convert.ToString(row["contenido_por_botella"]);

                        double conversion = 0;

                        if (Convert.ToString(row["unidad_medida"]) == "Mililitros")
                        {
                            conversion = Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2) / 1000;
                            fila["LITROS_UTILIZADOS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * conversion;
                        }
                        else if (Convert.ToString(row["unidad_medida"]) == "Litros")
                        {
                            fila["LITROS_UTILIZADOS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2);
                        }
                        else if (Convert.ToString(row["unidad_medida"]) == "Centilitro")
                        {
                            conversion = Math.Round(double.Parse(Convert.ToString(row["contenido_por_botella"])), 2) / 100;
                            fila["LITROS_UTILIZADOS"] = Math.Round(double.Parse(Convert.ToString(row["botellas"])), 2) * conversion;
                        }






                        fila["BOTELLAS_INICIALES"] = Convert.ToString(row["botellas_iniciales"]);//--Agregada
                        fila["BOTELLAS"] = Convert.ToString(row["botellas"]);
                        fila["BOTELLAS_EXISTENTES"] = Convert.ToString(row["botellas_existentes"]);

                        fila["GRADO_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["HOLOGRAMA_INICIO"] = Convert.ToString(row["holograma_inicio"]);
                        fila["HOLOGRAMA_FIN"] = Convert.ToString(row["holograma_fin"]);
                        fila["VERIFICADOR"] = Convert.ToString(row["verificador"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["ENVASADO_TERMINADO"] = Convert.ToString(row["envasado_terminado"]);
                        dtsAlmacenEnvasado.Tables["ALMACENENVASADO"].Rows.Add(fila);
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CmbNoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BanderaProduccion == true)
            {
                dtsProduccion.Clear();
            }
            else if (BanderaGranelFabrica == true)
            {
                dtsGranelFabrica.Clear();
            }
            else if (BanderaGranelEnvasado == true)
            {
                dtsGranelEnvasado.Clear();
            }
            else if (BanderaEnvasado == true)
            {
                dtsEnvasado.Clear();
            }

        }

        private void btnAlmacenGranel_Click(object sender, EventArgs e)
        {
            try
            {
                addTablaAlmacenGranel();
                LblValor.Text = "Almacen de Granel ";
                BanderaProduccion = false;
                BanderaGranelFabrica = false;
                BanderaGranelEnvasado = false;
                BanderaEnvasado = false;
                BanderaAlmacenGranel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            try
            {
                 addTablaAlmacenEnvasado();
                LblValor.Text = "Almacen de Envasado";
                BanderaProduccion = false;
                BanderaGranelFabrica = false;
                BanderaGranelEnvasado = false;
                BanderaEnvasado = false;
                BanderaAlmacenEnvasado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }









}
