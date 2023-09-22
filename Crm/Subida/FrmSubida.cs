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

namespace Crm.Subida
{
    public partial class FrmSubida : Form
    {
        public FrmSubida()
        {
            InitializeComponent();
        }

        private void FrmSubida_Load(object sender, EventArgs e)
        {
            ConexionMysql.conecta();
            LLenaTablaMagueyPendiente();
            GifSubida.Visible = false;

        }

        public void LLenaTablaMagueyPendiente()
        {    
         try
          {
            DtaMagueyPendiente.DataSource = null;
            DataSet datos = new DataSet();
            ConexionMysql.llenaDataset(ref datos,"SELECT retiro_plantas_pendientes.no_guia AS NO_GUIA,paraje.nombrep AS CLIENTE_ENVIA,comun.nombre as MAGUEY,retiro_plantas_pendientes.extraccion AS EXTRACCION,clientes.nombre AS CLIENTE_RECIBE,retiro_plantas_pendientes.direccion_cliente_recibe AS DIRECCION from retiro_plantas_pendientes INNER JOIN existenciaplanta ON retiro_plantas_pendientes.id_plantas=existenciaplanta.id_plantas INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  INNER JOIN paraje ON existenciaplanta.id_paraje= paraje.id_paraje   INNER JOIN clientes ON retiro_plantas_pendientes.no_cliente_recibe=clientes.no_cliente  WHERE actualizado=0  and retiro_plantas_pendientes.id_verificador="+Usuario.IdUsuario+"");
            DtaMagueyPendiente.DataSource = datos.Tables[0];
          }
         catch (Exception ex)
          {
            MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
            GifSubida.Visible = true;
            BackgroundWorkerSubidaMaguey.RunWorkerAsync();      
            }
         catch (Exception ex)
          {
            MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

        }

        private void BackgroundWorkerSubidaMaguey_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ConexionMysqlRemota.conecta();                       
                DataSet RetiroPlantasPendientes = new DataSet();
                ConexionMysql.llenaDataset(ref RetiroPlantasPendientes, "SELECT * FROM retiro_plantas_pendientes  WHERE actualizado=0 and id_verificador=" + Usuario.IdUsuario + "");
                if (DtaMagueyPendiente.Rows.Count != 0)
                {
                    foreach (DataRow row in RetiroPlantasPendientes.Tables[0].Rows)
                    {
                        string extraccion = Convert.ToString(row["extraccion"]);
                        string id_planta = Convert.ToString(row["id_plantas"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string no_cliente_envia = Convert.ToString(row["no_cliente_envia"]);
                        string no_cliente_recibe = Convert.ToString(row["no_cliente_recibe"]);
                        string direccion_cliente_recibe = Convert.ToString(row["direccion_cliente_recibe"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        DateTime fecha = Convert.ToDateTime(Convert.ToString(row["fecha"]));

                        if (ConexionMysqlRemota.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + extraccion + "  WHERE id_plantas =" + id_planta + "") == "Error")
                            return;

                        if (ConexionMysqlRemota.insUpd_transaccion("INSERT INTO historial_extraccion_verificadores (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,direccion_cliente_recibe,fecha_subio,fecha_realizo,id_verificador) VALUES( " + no_guia + "," + id_planta + ",'" + no_cliente_envia + "','" + no_cliente_recibe + "'," + extraccion + ",'" + direccion_cliente_recibe + "',now(),'" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Usuario.IdUsuario + ")") == "Error")
                            return;

                        if (ConexionMysql.insUpd_transaccion("UPDATE  retiro_plantas_pendientes SET actualizado=1  WHERE id_plantas =" + id_planta + " and id_verificador=" + Usuario.IdUsuario + "") == "Error")
                            return;
                    }
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota.transCompleta();
                    MessageBox.Show("Extracciones enviadas", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);              
                }                
                else
                {
                    MessageBox.Show("No tienes extracciones por actualizar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                }
            }
            catch (Exception ex)
            {         
               MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);         
            }
        }

        private void BackgroundWorkerSubidaMaguey_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BackgroundWorkerSubidaMaguey_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GifSubida.Visible = false;
            LLenaTablaMagueyPendiente();
            ConexionMysqlRemota.cierraConexion();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmSubida_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConexionMysql.cierraConexion();
        }


    }
}
