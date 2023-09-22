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
    public partial class FrmAgaveSobrante : Form
    {
        public FrmAgaveSobrante()
        {
            InitializeComponent();
        }
        public string no_cliente = "";
        public string agave_kg = "";
        public string predio = "";
        public string planta = "";
        public string id = "";
        public string art = "";
        public string produccion = "";


        private void FrmAgaveSobrante_Load(object sender, EventArgs e)
        {
            if (no_cliente == "")
            {
                MessageBox.Show("No haz seleccionado ningun usuario");
            }
            else
            {
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT  produccion_agave_sobrante.id_produccion_entrada,existenciaplanta.id_paraje,produccion_agave_sobrante.id_planta,produccion_agave_sobrante.id_agave_sobrante,comun.nombre as MAGUEY,ROUND (produccion_agave_sobrante.AGAVE_KG,2) as AGAVE_KG ,produccion_agave_sobrante.porcentaje_art as ART FROM produccion_agave_sobrante LEFT JOIN existenciaplanta ON produccion_agave_sobrante.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun WHERE produccion_agave_sobrante.no_cliente='" + no_cliente + "'  and produccion_agave_sobrante.agave_kg > 0");
                DtaAgaveSobrante.DataSource = datos.Tables[0];

                DtaAgaveSobrante.Columns["id_agave_sobrante"].Visible = false;
                DtaAgaveSobrante.Columns["id_produccion_entrada"].Visible = false;
                DtaAgaveSobrante.Columns["id_paraje"].Visible = false;
                DtaAgaveSobrante.Columns["id_planta"].Visible = false;
            }
           
        }

        private void DtaAgaveSobrante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               if (e.RowIndex < 0)
                   return;
               agave_kg = DtaAgaveSobrante.Rows[e.RowIndex].Cells["AGAVE_KG"].Value.ToString();
               id = DtaAgaveSobrante.Rows[e.RowIndex].Cells["id_agave_sobrante"].Value.ToString();
               predio = DtaAgaveSobrante.Rows[e.RowIndex].Cells["id_paraje"].Value.ToString();
               planta = DtaAgaveSobrante.Rows[e.RowIndex].Cells["id_planta"].Value.ToString();
               art = DtaAgaveSobrante.Rows[e.RowIndex].Cells["ART"].Value.ToString();
               produccion = DtaAgaveSobrante.Rows[e.RowIndex].Cells["id_produccion_entrada"].Value.ToString();
               this.Close();
                                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtaAgaveSobrante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
