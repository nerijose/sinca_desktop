using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//-- permite la lactura de archivos externos
using Crm.Utilerias;

namespace Crm.Administrador
{
    public partial class FrmAdministrador : Form
    {   //----- System.Diagnostics.Process.Start("CMD.exe", "/K help");  

        public FrmAdministrador()
        {
            InitializeComponent();
            ConexionMysql.conecta();
        }
        Boolean bandera = false;
        string usrVeriDB = "";
        private void btnalters_Click(object sender, EventArgs e)
        {

            try
            {
                string fileName = Directory.GetCurrentDirectory().ToString() + @"/Adminscrips\nuevos_alters_reveca2_2019.txt";
                MessageBox.Show("abriendo");
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                string inst = reader.ReadToEnd();
                ConexionMysql.insUpd(inst);
                MessageBox.Show(" insertados con exito");
                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnRestauraDatos_Click(object sender, EventArgs e)
        {
            try
            {

                /* @adnto si esta abierto el canal se podrá
            * realizar la descarga, no importando la hora, se podría sintetizar en un if con un or */
                //MessageBox.Show(" else, activado!=0 \n canal abierto descargando ... ");
                this.progressBar1.Value = 0;
                this.progressBar1.Increment(0);
                lblporcentaje.Visible = true;
                progressBar1.Visible = true;

                //este metodo ejecuta el trabajo del backgroundworker funciones en segundo plano
                backgroundWorkerDBRestura.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                progressBar1.Visible = false;
                lblporcentaje.Visible = false;
            }




            /* try
             {


                 string ruta = Directory.GetCurrentDirectory().ToString() + @"/Scrip\rvk.txt";


                 string line1;
                 string line2;
                 string line3;
                 string line4;
                 string[] coord = new string[4];

                 StreamReader lee = new StreamReader(ruta, true);

                 string line = "";

                 for (int r = 0; r < 4; r++)
                 {
                     line = lee.ReadLine();
                     coord[r] = Convert.ToString(line);
                 }

                 line1 = coord[0];
                 line2 = coord[1];
                 line3 = coord[2];
                 line4 = coord[3];

                 // Console.WriteLine(desencriptar(line1));
                 // Console.WriteLine(desencriptar(line2));
                 //onsole.WriteLine(desencriptar(line3));
                 // Console.WriteLine(desencriptar(line4));


                 // lee.Close();
                 //Console.WriteLine(Actual);




                 // "Database=" + desencriptar(line1) + ";Data Source=" + desencriptar(line2) + ";User Id=" + desencriptar(line3) + ";Password=" + desencriptar(line4) + ";CharSet=utf8;";


                 string fecha = DateTime.Now.ToString("yyyyMMdd_hh:mm:ss.F");
                 string rutadir = @"C:\Program Files (x86)\dumpreveca2\";


                 string inst = "mysqldump --u " + desencriptar(line3) + " --password=" + desencriptar(line4) + " " + desencriptar(line1) + " produccion_entrada produccion_ensamble > " + @"C:\Program Files (x86)\dumpreveca2\" + Usuario.IdUsuario + "_reveca2_" + fecha + ".sql";
                 ConexionMysql.insUpd(inst);
                 MessageBox.Show(" copia con exito");

             }
             catch (Exception ex)
             {

                 MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }*/






        }
        /// <summary>
        /// / lo aplicas con un archivo .bat para realizar el dump
        /// </summary>
        /*  DialogResult result = MessageBox.Show("Deseas realizar un respaldo de la base de datos?", "Respaldar base de datos", MessageBoxButtons.YesNo);
          if (result == DialogResult.Yes)
          {
              this.Respaldo();
          }
          else if (result == DialogResult.No)
          {

          }
      }


      public void Respaldo()
      {
          System.Diagnostics.Process.Start(@"/Adminscrips\dumpsreveca2.bat");
           
        
      }
      */

        static string desencriptar(string o)
        {


            string l = "";

            string cadena = o;
            char[] arreglo = cadena.ToCharArray();

            for (int i = 0; i < cadena.Length; i++)
            {

                arreglo[i] = (char)(arreglo[i] - (char)11);
                l += arreglo[i];


            }




            return l;

        }

        private void backgroundWorkerDBRestura_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bandera = false;
                //reporta el progreso a una barra de carga 
                backgroundWorkerDBRestura.ReportProgress(0);

                ConexionMysql.conecta();//--ReVeCa
                ConexionMysqlRemota.conecta();//--crmreg
                ConexionMysqlRemota2.conecta();//--siig

                backgroundWorkerDBRestura.ReportProgress(1);


                if (BajaMensajesRegistros() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(2);

                if (BajaFqHistorial() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(3);


                if (BajaSalidaHolgramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(4);

                if (ActualizarNuevasGuiasDeExtraccion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(5);

                if (ActualizarEspecieTabla() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                backgroundWorkerDBRestura.ReportProgress(7);

                if (ActualizarExistenciaPlantas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(10);

                if (ActualizarParajes() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(12);

                if (ActualizaClientes() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(15);

                if (ActualizaVerificadores() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                backgroundWorkerDBRestura.ReportProgress(17);

                if (ActualizaMarcas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(18);

                if (ActualizaEstatusGuiasYExistenciaPlantas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(20);

                if (ActualizaCatPresentacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                backgroundWorkerDBRestura.ReportProgress(22);

                if (ActualizarEspecieDeMaguey() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(24);



                if (ActualizaAnios() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(26);

                if (ActualizaEdadesPlantas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(28);


                if (ActualizaTiposInstalacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(30);

                if (ActualizaInstalacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(32);

                if (ActualizaClientesInstalaciones() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(34);


                if (ActualizaEstados() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(35);

                if (ActualizaMunicipios() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(37);
                if (BajaEnvasadoEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(39);
                if (BajaEnvasadoHologramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                backgroundWorkerDBRestura.ReportProgress(42);
                if (BajaAlmacenEnvasadoEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(44);
                if (BajaAlmacenEnvasadoEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(46);
                if (BajaAlmacenEnvasadoMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(49);
                if (BajaAlmacenEncargado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(52);
                if (BajaAlmacenEnvasadoHologramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(54);
                if (BajaAlmacenGranelEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(58);
                if (BajaAlmacenGranelEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(60);
                if (BajaAlmacenGranelMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(61);
                if (BajaAlmacenGranelTanque() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(62);
                if (BajaAlmacenGranelSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(64);
                if (BajaMaestroMezcalero() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(66);
                if (BajaEnvasadoSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                backgroundWorkerDBRestura.ReportProgress(68);
                if (BajaTransacciones() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(69);
                if (BajaIdsProduccion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(70);
                if (ActualizaLocalidades() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(71);

                if (ActualizaRelacionCpEstado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(72);


                if (ActualizaRutaVerificador() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(73);

                if (ActualizaCatMolienda() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(74);

                if (ActualizaRutaClientes() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(75);


                if (ActualizaRutaZona() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(76);

                if (ActualizaCatCoccion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(77);


                if (ActualizaCatFermentacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(78);


                if (ActualizaCatDestilacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(79);

                if (BajaEnvasadoEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(80);
                if (BajaEnvasadoMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(81);
                if (BajaEnvasadoEncargado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(82);
                if (BajaExistenciaPlantaComprada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(83);
                if (BajaGranelEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(84);
                if (BajaGranelEnsambleEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(85);
                if (BajaGranelEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(86);
                if (BajaGranelEntradaEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(87);
                if (BajaGranelMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(88);
                if (BajaGranelMovimientosEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(89);
                if (BajaGranelSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(90);
                if (BajaGranelTanque() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(91);
                if (BajaGranelTanqueEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(92);
                if (BajaMaestroFabrica() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(93);
                if (BajaAgaveCocidoSobrante() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(94);
                if (BajaAgaveSobrante() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(95);
                if (BajaProduccionEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(96);
                if (BajaProduccionEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(97);
                if (BajaProduccionPuntasColas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorkerDBRestura.ReportProgress(98);
                if (BajaProduccionSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(99);
                if (BajaDeInformacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorkerDBRestura.ReportProgress(100);

                bandera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void backgroundWorkerDBRestura_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblporcentaje.Text = "Restaurando datos" + Environment.NewLine + "Completando " + Convert.ToString(progressBar1.Value) + " %."; //--- imprime el porcentaje de la instalacion

            lblporcentaje.ForeColor = Color.DarkRed;
        }

        private void backgroundWorkerDBRestura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bandera == true)
            {
                MessageBox.Show("Base de datos actualizada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblporcentaje.Visible = false;
                progressBar1.Visible = false;
                // carga.Visible = false;
            }
            else
            {
                lblporcentaje.Visible = false;
                progressBar1.Visible = false;
                //carga.Visible = false;
            }
            ConexionMysql.cierraConexion();
            ConexionMysqlRemota.cierraConexion();
            ConexionMysqlRemota2.cierraConexion();
        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>>>>>>>>>>>Baja informacion<<<<<<<<<<<<~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // actualiza guias de extracion
        public Boolean ActualizarNuevasGuiasDeExtraccion()
        {
            try
            {
                /*  string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_extraccion) AS id_max FROM cextracciones");
                  if (id_max_local == "")
                  {
                      id_max_local = "0";
                  }*/
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sep = "";
                string values_guias = "";
                string sql_ins_guias = "INSERT INTO cextracciones (id_extraccion,id_paraje,status,fecha) VALUES";
                DataSet GuiasExtraccion = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref GuiasExtraccion, "SELECT id_extraccion,id_paraje,status,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha FROM cextracciones where id_extraccion>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref GuiasExtraccion, "SELECT id_extraccion,id_paraje,status,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha FROM cextracciones");

                if (GuiasExtraccion.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in GuiasExtraccion.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select id_extraccion FROM cextracciones where id_extraccion=" + Convert.ToString(row["id_extraccion"]));

                    ConexionMysql.insUpd_transaccion("SET GLOBAL max_allowed_packet = 32*1024*1024;");
                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {

                        bandera_update = true;


                        if (ConexionMysql.insUpd_transaccion("UPDATE cextracciones SET  id_extraccion =" + Convert.ToString(row["id_extraccion"]) + ",id_paraje =" + Convert.ToString(row["id_paraje"]) + ", status =" + Convert.ToString(row["status"]) + ", fecha ='" + Convert.ToString(row["fecha"]) + "' WHERE id_extraccion=" + Convert.ToString(row["id_extraccion"])) == "Error")
                            return false;


                    }
                    else
                    {

                        bandera_insert = true;

                        string id_extraccion = Convert.ToString(row["id_extraccion"]);
                        string id_paraje = Convert.ToString(row["id_paraje"]);
                        string status = Convert.ToString(row["status"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        values_guias += sep + "(" + id_extraccion + "," + id_paraje + "," + status + ",'" + fecha + "')";
                        sep = ",";
                    }
                }
                sql_ins_guias += values_guias + ";";
                /* if (ConexionMysql.insUpd_transaccion(sql_ins_guias) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins_guias) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        // actualiza existencia plantas
        public Boolean ActualizarExistenciaPlantas()
        {
            try
            {
                /*string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_plantas) AS id_max FROM existenciaplanta");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }*/

                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins_plantas = "INSERT INTO existenciaplanta (id_plantas,id_comun,id_paraje,edad,cantidadini,existenciaplantas,regmaguey) VALUES";
                DataSet NuevasPlantas = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref NuevasPlantas, "SELECT  id_plantas,id_comun,id_paraje,edad,cantidadini,existenciaplantas,regmaguey FROM existenciaplanta where id_plantas>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref NuevasPlantas, "SELECT  id_plantas,id_comun,id_paraje,if (edad='' or edad is null,0,edad) as edad,cantidadini,existenciaplantas,regmaguey FROM existenciaplanta");
                if (NuevasPlantas.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in NuevasPlantas.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select id_plantas from existenciaplanta where id_plantas=" + Convert.ToString(row["id_plantas"]));

                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {

                        //MessageBox.Show("UPDATE existenciaplanta SET id_comun=" + Convert.ToString(row["id_comun"]) + ", edad='" + Convert.ToString(row["edad"]) + "', existenciaplantas=" + Convert.ToString(row["existenciaplantas"]) + " WHERE id_plantas=" + Convert.ToString(row["id_plantas"]));
                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta SET id_comun=" + Convert.ToString(row["id_comun"]) + ", edad='" + Convert.ToString(row["edad"]) + "', existenciaplantas=" + Convert.ToString(row["existenciaplantas"]) + " WHERE id_plantas=" + Convert.ToString(row["id_plantas"])) == "Error")
                            return false;


                    }
                    else
                    {

                        bandera_insert = true;
                        string id_plantas = Convert.ToString(row["id_plantas"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_paraje = Convert.ToString(row["id_paraje"]);
                        string edad = Convert.ToString(row["edad"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string regmaguey = Convert.ToString(row["regmaguey"]);

                        values += sep + "(" + id_plantas + "," + id_comun + "," + id_paraje + ",'" + edad + "'," + cantidadini + "," + existenciaplantas + ",'" + regmaguey + "')";
                        sep = ",";
                    }
                }


                sql_ins_plantas += values + ";";
                /* if (ConexionMysql.insUpd_transaccion(sql_ins_plantas) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/

                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins_plantas) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        // actualiza especie d emaguey comun
        public Boolean ActualizarEspecieDeMaguey()
        {
            try
            {
                /*string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_comun) AS id_max FROM comun");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }*/
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sep = "";
                string values = "";
                string sql_ins_comun = "INSERT INTO comun (id_comun,id_especie,nombre,status) VALUES";
                DataSet Datos = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref Datos, "SELECT  id_comun,id_especie,nombre FROM comun where id_comun>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref Datos, "SELECT  id_comun,id_especie,nombre,status FROM comun");

                if (Datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in Datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_comun from comun where id_comun=" + Convert.ToString(row["id_comun"]));

                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE comun SET id_comun =" + Convert.ToString(row["id_comun"]) + ",id_especie =" + Convert.ToString(row["id_especie"]) + ",nombre ='" + Convert.ToString(row["nombre"]) + "',status='"+Convert.ToString(row["status"])+"' WHERE id_comun=" + Convert.ToString(row["id_comun"])) == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_especie = Convert.ToString(row["id_especie"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string status = Convert.ToString(row["status"]);

                        values += sep + "(" + id_comun + "," + id_especie + ",'" + nombre + "','"+status+"')";
                        sep = ",";
                    }
                }
                sql_ins_comun += values + ";";
                /*if (ConexionMysql.insUpd_transaccion(sql_ins_comun) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/

                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins_comun) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        public Boolean ActualizarEspecieTabla()
        {
            try
            {
                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_especie) AS id_max FROM especie");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/

                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sep = "";
                string values = "";
                string sql_ins_comun = "INSERT INTO especie (id_especie, genespecie, variante) VALUES";
                DataSet Datos = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref Datos, "SELECT  id_especie, genespecie, variante FROM especie where id_especie>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref Datos, "SELECT  id_especie, genespecie, variante FROM especie ");
                if (Datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in Datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_especie from especie where id_especie=" + Convert.ToString(row["id_especie"]));

                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE especie SET id_especie = " + Convert.ToString(row["id_especie"]) + ", genespecie ='" + Convert.ToString(row["genespecie"]) + "', variante ='" + Convert.ToString(row["variante"]) + "' WHERE id_especie=" + Convert.ToString(row["id_especie"])) == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;
                        string id_especie = Convert.ToString(row["id_especie"]);
                        string id_genespecie = Convert.ToString(row["genespecie"]);
                        string variante = Convert.ToString(row["variante"]);

                        values += sep + "(" + id_especie + "," + id_genespecie + ",'" + variante + "')";
                        sep = ",";
                    }
                }
                sql_ins_comun += values + ";";
                /*if (ConexionMysql.insUpd_transaccion(sql_ins_comun) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins_comun) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// actualiza los parajes
        public Boolean ActualizarParajes()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_paraje) AS id_max FROM paraje");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO paraje (id_paraje,id_cliente,paraje,nombrep) VALUES";
                DataSet NuevosParajes = new DataSet();
                ConexionMysqlRemota.llenaDataset(ref NuevosParajes, "SELECT  id_paraje,id_cliente,paraje,nombrep FROM paraje where id_paraje > " + id_max_local + " ");
                if (NuevosParajes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosParajes.Tables[0].Rows)
                {

                    string id_paraje = Convert.ToString(row["id_paraje"]);
                    string id_cliente = Convert.ToString(row["id_cliente"]);
                    string paraje = Convert.ToString(row["paraje"]);
                    string nombre = Convert.ToString(row["nombrep"]);
                    values += sep + "(" + id_paraje + ",'" + id_cliente + "','" + paraje + "','" + nombre + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        /// actualiza los clientes
        public Boolean ActualizaClientes()
        {
            try
            {
                /*@adnto aquí considero que el máximo sea diferente al cliente 9999*/

                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(no_cliente) AS id_max FROM clientes where no_cliente!=9999");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/
                //string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT no_cliente FROM clientes where no_cliente!=9999");



                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO clientes (no_cliente,nombre,cp) VALUES";
                DataSet NuevosClientes = new DataSet();
                /*@adnto aquí considero que actualice los clientes mayores al máximo (de la consulta de arriba) y excluyendo al 9999*/
                /*r@lew sea modifico para que agrege el codigo postal del cliente desde la tabla domicilio*/
                //ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT clientes.no_cliente as no_cliente,clientes.nombre as nombre, domicilio.cp as cp FROM clientes inner join domicilio on clientes.no_cliente=domicilio.no_cliente where clientes.no_cliente>" + id_max_local + " and domicilio.estatus=1 and clientes.no_cliente != 9999 order by clientes.no_cliente asc;");

                //-- esta valida por el ide del consulta de id maximo---ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT no_cliente,nombre,cp FROM clientes where no_cliente>" + id_max_local + " and no_cliente != 9999");
                ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT no_cliente,nombre,cp FROM clientes where no_cliente != 9999");

                /*-----/ r@le----- la consulta de abajo se puede descomentar y la de arriba comentar para poder traer desde la base de datos el codigo postal de todos los cleintes */
                /*SELECT clientes.no_cliente,clientes.nombre,domicilio.cp FROM clientes inner join domicilio on clientes.no_cliente=domicilio.no_cliente where clientes.no_cliente>" + id_max_local + " and domicilio.estatus=1 and clientes.no_cliente != 9999*/
                if (NuevosClientes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosClientes.Tables[0].Rows)
                {

                    string id_cliente = ConexionMysql.regresaCampoConsulta("SELECT no_cliente FROM clientes where no_cliente ='" + Convert.ToString(row["no_cliente"]) + "' and no_cliente!=9999");

                    if (id_cliente == "") //-- si no encuientra coincidencia entra e incerta los datos
                    {
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string cp = Convert.ToString(row["cp"]);

                        values += sep + "('" + no_cliente + "','" + nombre + "','" + cp + "')";
                        sep = ",";



                    }
                    /* else{
                         values = "0";
                     }*/
                    // else { return true; }


                }


                if (values != "")// ---  Si encuentra el valorque no es vacio entra e inserta los nuevos valores...
                {
                    sql_ins += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//---- fin de actualiza clientes

        public Boolean ActualizaVerificadores()
        {
            try
            {
                Console.WriteLine("actualiza verificadores si no esta correcto el password");
                string sep = "";
                string values = "";
                string sql = "INSERT INTO verificadores (id_us, nombre, dpto, login, password, cve_us, status,actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();

                //ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_entrada, no_cliente, id_fabrica, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha , id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado from rv_granel_entrada ");

                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_us, nombre, dpto, login, password, cve_us, status,actualizado from verificadores ");

                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows) // itera los registros de la consulta remota de verificadores
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_us from verificadores where id_us='" + Convert.ToString(row["id_us"]) + "'");
                    //string id = ConexionMysql.regresaCampoConsulta("select  id_granel_entrada from  granel_entrada where id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'");
                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {
                        if (Convert.ToString(row["actualizado"]) == "0") // if campo actualizado en bd remota es actualizado=0
                        {
                            bandera_update = true;
                            //id_us, nombre, dpto, login, password, cve_us, status
                            if (ConexionMysql.insUpd_transaccion("UPDATE verificadores SET nombre='" + Convert.ToString(row["nombre"]) + "', dpto='" + Convert.ToString(row["dpto"]) + "', login='" + Convert.ToString(row["login"]) + "', password='" + Convert.ToString(row["password"]) + "', cve_us='" + Convert.ToString(row["cve_us"]) + "', status='" + Convert.ToString(row["status"]) + "' WHERE id_us='" + Convert.ToString(row["id_us"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else // si fuera "", o sea q no encontro id q coincidiera tendrá q insertar el registro nuevo. 
                    {
                        //id_us, nombre, dpto, login, password, cve_us, status
                        bandera_insert = true;
                        string id_us = Convert.ToString(row["id_us"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string dpto = Convert.ToString(row["dpto"]);
                        string login = Convert.ToString(row["login"]);
                        string password = Convert.ToString(row["password"]);
                        string cve_us = Convert.ToString(row["cve_us"]);
                        string status = Convert.ToString(row["status"]);

                        values += sep + "('" + id_us + "','" + nombre + "','" + dpto + "','" + login + "','" + password + "','" + cve_us + "','" + status + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    // para insertar valores
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }


        /// actualiza las marcas
        public Boolean ActualizaMarcas()
        {
            try
            {
                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM marcas");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO marcas (id,no_cliente,cve_marca,marca,serie,sinc,label) VALUES";
                DataSet NuevasMarcas = new DataSet();
                // ConexionMysqlRemota2.llenaDataset(ref NuevasMarcas, "SELECT id,no_cliente,cve_marca,marca,serie,sinc,label FROM marcas where id >" + id_max_local + "");
                ConexionMysqlRemota2.llenaDataset(ref NuevasMarcas, "SELECT id,no_cliente,cve_marca,marca,serie,sinc,label FROM marcas ");

                if (NuevasMarcas.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevasMarcas.Tables[0].Rows)
                {
                    string ids = ConexionMysql.regresaCampoConsulta("select id from marcas where id =" + Convert.ToString(row["id"]));

                    if (ids != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE marcas SET id =" + Convert.ToString(row["id"]) + ", no_cliente ='" + Convert.ToString(row["no_cliente"]) + "', cve_marca ='" + Convert.ToString(row["cve_marca"]) + "', marca ='" + Convert.ToString(row["marca"]) + "', serie ='" + Convert.ToString(row["serie"]) + "', sinc ='" + Convert.ToString(row["sinc"]) + "',label ='" + Convert.ToString(row["label"]) + "' WHERE id=" + Convert.ToString(row["id"])) == "Error")
                            return false;


                    }
                    else
                    {


                        bandera_insert = true;

                        string id = Convert.ToString(row["id"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cve_marca = Convert.ToString(row["cve_marca"]);
                        string marca = Convert.ToString(row["marca"]);
                        string serie = Convert.ToString(row["serie"]);
                        string sinc = Convert.ToString(row["sinc"]);
                        string label = Convert.ToString(row["label"]);
                        values += sep + "(" + id + ",'" + no_cliente + "','" + cve_marca + "','" + marca + "','" + serie + "','" + sinc + "','" + label + "')";
                        sep = ",";
                    }
                }
                sql_ins += values + ";";
                /* if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualizacion de estatus guias y existencias de plantas
        public Boolean ActualizaEstatusGuiasYExistenciaPlantas()
        {
            try
            {
                DataSet HistorialExtracciones = new DataSet();
                ///--- seleciona las extracciones que estan en crmreg --
                ConexionMysqlRemota.llenaDataset(ref HistorialExtracciones, "SELECT no_guia,id_plantas,extraccion, DATE_FORMAT(fecha_realizo, '%Y-%m-%d %H:%i:%s') as fecha  FROM historial_extraccion_verificadores");
                if (HistorialExtracciones.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in HistorialExtracciones.Tables[0].Rows)
                {
                    string no_guia = Convert.ToString(row["no_guia"]);
                    string id_planta = Convert.ToString(row["id_plantas"]);
                    string extraccion = Convert.ToString(row["extraccion"]);
                    string fecha = Convert.ToString(row["fecha"]);

                    /// --- selecciona las extracciones del la base de datos local reveca2 -- 
                    string res = ConexionMysql.regresaCampoConsulta("SELECT * FROM actualizacion_extracciones where no_guia=" + no_guia + " and id_plantas=" + id_planta + " and fecha='" + fecha + "' ");
                    //// si no encientra el regiatro de la esxtraccion entra aqui e ingresa los valores nuevos
                    if (res == "")
                    {
                        //--- actualiza la tabla de actualizacion_extracciones 
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( " + no_guia + "," + id_planta + "," + extraccion + ",'" + fecha + "')") == "Error")
                            return false;
                        ///-- En el casso de que la extraccion sea con guia entra ene el if <if (no_guia != 0)> y actualiza el estatus de la guia
                        if (no_guia != "0")
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE  cextracciones SET status=0  WHERE id_extraccion =" + no_guia) == "Error")
                                return false;
                        }
                        /// --- actualiza la cantidad de piñas en la existencia de la planta
                        //-- Checar si es factible  if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + extraccion + "  WHERE id_plantas =" + id_planta + "") == "Error")
                        //--  return false;

                        //  ConexionMysql.transCompleta();
                    } // -- fin de if(res=="")  
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE actualizacion_extracciones SET no_guia=" + no_guia + ",id_plantas=" + id_planta + ",extraccion=" + extraccion + ",fecha='" + fecha + "' where no_guia=" + no_guia) == "Error")
                            return false;


                        if (no_guia != "0")
                        {

                            /// -- verificara el numero de guia en su estatus  por si se cambio a no utilizada -- 
                            string status_guia = ConexionMysqlRemota.regresaCampoConsulta("SELECT status FROM cextracciones where id_extraccion=" + no_guia + "");
                            if (ConexionMysql.insUpd_transaccion("UPDATE  cextracciones SET status=" + status_guia + "  WHERE id_extraccion =" + no_guia + "") == "Error")
                                return false;
                        }


                        ConexionMysql.transCompleta();
                    }
                }// -- fin del for      
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// actualiza los años sumados
        public Boolean ActualizaAnios()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM anios_sumados");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO anios_sumados (id,id_plantas,anios) VALUES";
                DataSet NuevosAnios = new DataSet();
                ConexionMysqlRemota.llenaDataset(ref NuevosAnios, "SELECT id,id_plantas,anios FROM anios_sumados where id>" + id_max_local + "");
                if (NuevosAnios.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosAnios.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string id_plantas = Convert.ToString(row["id_plantas"]);
                    string anios = Convert.ToString(row["anios"]);

                    values += sep + "(" + id + "," + id_plantas + "," + anios + ")";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //actualiza edades del de maguey
        public Boolean ActualizaEdadesPlantas()
        {
            try
            {
                DataSet AniosSumados = new DataSet();
                ConexionMysql.llenaDataset(ref AniosSumados, "SELECT * FROM  anios_sumados where estatus=0");
                if (AniosSumados.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in AniosSumados.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta SET edad=edad+" + row["anios"] + " where id_plantas=" + row["id_plantas"] + "") == "Error")
                            return false;

                        if (ConexionMysql.insUpd_transaccion("UPDATE anios_sumados SET estatus=1 where id=" + row["id"] + "") == "Error")
                            return false;

                        ConexionMysql.transCompleta();
                    }

                }

                DataSet AniosSumadosRemotos = new DataSet();
                ConexionMysqlRemota.llenaDataset(ref AniosSumadosRemotos, "SELECT * FROM  anios_sumados");
                if (AniosSumadosRemotos.Tables[0].Rows.Count != 0)
                {
                    //int f = AniosSumadosRemotos.Tables[0].Rows.Count;

                    // MessageBox.Show("" + f);
                    foreach (DataRow row1 in AniosSumadosRemotos.Tables[0].Rows)
                    {

                        DataSet AniosSumados2 = new DataSet();
                        ConexionMysql.llenaDataset(ref AniosSumados2, "SELECT * FROM  anios_sumados where id=" + row1["id"] + "  and estatus=1 and anios!=" + row1["anios"] + " ");


                        if (AniosSumados2.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow row2 in AniosSumados2.Tables[0].Rows)
                            {
                                if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta SET edad=edad+1 where id_plantas=" + row2["id_plantas"] + "") == "Error")
                                    return false;

                                if (ConexionMysql.insUpd_transaccion("UPDATE anios_sumados SET anios=" + row1["anios"] + " where id=" + row2["id"] + "") == "Error")
                                    return false;

                                ConexionMysql.transCompleta();

                            }

                        }


                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// actualiza Tipos de instalaciones
        public Boolean ActualizaTiposInstalacion()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM tipos_instalaciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO tipos_instalaciones (id,descripcion) VALUES";
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,descripcion FROM tipos_instalaciones where id>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string descripcion = Convert.ToString(row["descripcion"]);

                    values += sep + "(" + id + ",'" + descripcion + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        /// actualiza instalaciones 
        public Boolean ActualizaInstalacion()
        {
            try
            {
                /*string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM instalaciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO instalaciones (id,tipo,alias,calle,colonia,responsable) VALUES";
                DataSet NuevosDatos = new DataSet();
                // ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,tipo,alias,calle,colonia,responsable FROM instalaciones where id>" + id_max_local + "");
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,tipo,alias,calle,colonia,responsable FROM instalaciones");

                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {

                    string ids = ConexionMysql.regresaCampoConsulta("SELECT id FROM instalaciones WHERE id =" + Convert.ToString(row["id"]));

                    if (ids != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;



                        if (ConexionMysql.insUpd_transaccion("UPDATE instalaciones SET id=" + Convert.ToString(row["id"]) + ", tipo =" + Convert.ToString(row["tipo"]) + ",alias ='" + Convert.ToString(row["alias"]) + "', calle ='" + Convert.ToString(row["calle"]) + "', colonia='" + Convert.ToString(row["colonia"]) + "',responsable ='" + Convert.ToString(row["responsable"]) + "' WHERE id='" + Convert.ToString(row["id"]) + "'") == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;


                        string id = Convert.ToString(row["id"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string alias = Convert.ToString(row["alias"]);
                        string calle = Convert.ToString(row["calle"]);
                        string colonia = Convert.ToString(row["colonia"]);
                        string responsable = Convert.ToString(row["responsable"]);
                        values += sep + "(" + id + "," + tipo + ",'" + alias + "','" + calle + "','" + colonia + "','" + responsable + "')";
                        sep = ",";
                    }
                }
                sql_ins += values + ";";
                /* if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }







        /// actualiza la relacion clientes instalaciones
        public Boolean ActualizaClientesInstalaciones()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta(" select count(*) from clientes_instalaciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO clientes_instalaciones (cliente,instalacion) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "CALL INSTALACIONES_CLIENTES('" + id_max_local + "')");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string cliente = Convert.ToString(row["cliente"]);
                    string instalacion = Convert.ToString(row["instalacion"]);

                    values += sep + "('" + cliente + "'," + instalacion + ")";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }






        /// actualiza los estados
        public Boolean ActualizaEstados()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(clave) AS id_max FROM estados");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO estados (clave,nombre,codigo) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT clave,nombre,codigo FROM estados where clave>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string clave = Convert.ToString(row["clave"]);
                    string nombre = Convert.ToString(row["nombre"]);
                    string codigo = Convert.ToString(row["codigo"]);

                    values += sep + "(" + clave + ",'" + nombre + "','" + codigo + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        /// actualiza los municipio
        public Boolean ActualizaMunicipios()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM municipios");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO municipios (id,clave,estado,nombre) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,clave,estado,nombre FROM municipios where id>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string clave = Convert.ToString(row["clave"]);
                    string estado = Convert.ToString(row["estado"]);
                    string nombre = Convert.ToString(row["nombre"]);

                    values += sep + "(" + id + "," + clave + "," + estado + ",'" + nombre + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// actualiza localidades
        public Boolean ActualizaLocalidades()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM localidades");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO localidades (id,MunicipioID,localidad) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,MunicipioID,localidad FROM localidades where id>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string MunicipioID = Convert.ToString(row["MunicipioID"]);
                    string localidad = Convert.ToString(row["localidad"]);


                    values += sep + "(" + id + "," + MunicipioID + ",'" + localidad + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        /// actualiza ruta_verificador
        public Boolean ActualizaRutaVerificador()
        {
            try
            {
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_ruta_verificador,id_ruta,id_personal,fecha_inicio,fecha_fin FROM r_rutas_verificadores where id_personal=" + Usuario.IdUsuario + " and estado=1");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {

                    string id = Convert.ToString(row["id_ruta_verificador"]);
                    string id_ruta = Convert.ToString(row["id_ruta"]);
                    string id_personal = Convert.ToString(row["id_personal"]);
                    DateTime fecha_inicio = Convert.ToDateTime(Convert.ToString(row["fecha_inicio"]));
                    DateTime fecha_fin = Convert.ToDateTime(Convert.ToString(row["fecha_fin"]));


                    DataSet NuevosDatos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref NuevosDatos2, "SELECT id_ruta_verificador,id_ruta,id_personal,fecha_inicio,fecha_fin FROM rutas_verificadores");
                    if (NuevosDatos2.Tables[0].Rows.Count == 0)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO rutas_verificadores(id_ruta_verificador,id_ruta,id_personal,fecha_inicio,fecha_fin) VALUES (" + id + "," + id_ruta + "," + id_personal + ",'" + fecha_inicio.ToString("yyyy-MM-dd") + "','" + fecha_fin.ToString("yyyy-MM-dd") + "')") == "Error")
                            return false;
                        ConexionMysql.transCompleta();
                    }
                    else
                    {
                        string resultado = ConexionMysql.regresaCampoConsulta("SELECT id_ruta_verificador FROM rutas_verificadores where id_ruta_verificador=" + id + "");
                        if (resultado == "")
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE rutas_verificadores SET id_ruta_verificador=" + id + ",id_ruta=" + id_ruta + ",id_personal=" + id_personal + ",fecha_inicio='" + fecha_inicio.ToString("yyyy-MM-dd") + "',fecha_fin='" + fecha_fin.ToString("yyyy-MM-dd") + "'") == "Error")
                                return false;
                            ConexionMysql.transCompleta();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }






        /// actualiza ruta_clientes que clientes tiene la ruta
        public Boolean ActualizaRutaClientes()
        {
            try
            {
                string id_ruta_valor = ConexionMysql.regresaCampoConsulta("SELECT id_ruta FROM rutas_verificadores");
                if (id_ruta_valor == "")
                {
                    id_ruta_valor = "0";
                }




                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO rutas_clientes(id_ruta_cliente,id_ruta,no_cliente,dia,id_instalacion) VALUES ";

                ConexionMysql.insUpd("DELETE FROM rutas_clientes");

                //datos remotos
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT * FROM r_rutas_clientes where id_ruta=" + id_ruta_valor + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {


                    string id = Convert.ToString(row["id_ruta_cliente"]);
                    string id_ruta = Convert.ToString(row["id_ruta"]);
                    string no_cliente = Convert.ToString(row["no_cliente"]);
                    string dia = Convert.ToString(row["dia"]);
                    string id_instalacion = Convert.ToString(row["id_instalacion"]);

                    values += sep + "(" + id + "," + id_ruta + ",'" + no_cliente + "','" + dia + "','" + id_instalacion + "')";
                    sep = ",";
                }

                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// actualiza ruta_zonas actualiza las zonas que tiene la ruta
        public Boolean ActualizaRutaZona()
        {
            try
            {
                string id_ruta_valor = ConexionMysql.regresaCampoConsulta("SELECT id_ruta FROM rutas_clientes");
                if (id_ruta_valor == "")
                {
                    id_ruta_valor = "0";
                }

                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO rutas_zonas(id_ruta_zona,id_ruta,id_localidad) VALUES ";

                ConexionMysql.insUpd("DELETE FROM rutas_zonas");

                //datos remotos
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT * FROM r_rutas_zonas where id_ruta=" + id_ruta_valor + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_ruta_zona"]);
                    string id_ruta = Convert.ToString(row["id_ruta"]);
                    string id_localidad = Convert.ToString(row["id_localidad"]);


                    values += sep + "(" + id + "," + id_ruta + "," + id_localidad + ")";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// agrega nuevos datos al catalogo de coccion
        public Boolean ActualizaCatCoccion()
        {
            try
            {
                /*string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_coccion) AS id_max FROM cat_coccion");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO cat_coccion (id_coccion,coccion) VALUES";
                DataSet NuevosDatos = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_coccion,coccion FROM cat_coccion where id_coccion>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_coccion,coccion FROM cat_coccion ");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {

                    string ids = ConexionMysql.regresaCampoConsulta("select id_coccion from cat_coccion where id_coccion =" + Convert.ToString(row["id_coccion"]));

                    if (ids != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE cat_coccion SET coccion ='" + Convert.ToString(row["coccion"]) + "' where id_coccion=" + Convert.ToString(row["id_coccion"])) == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;
                        string id = Convert.ToString(row["id_coccion"]);
                        string coccion = Convert.ToString(row["coccion"]);

                        values += sep + "(" + id + ",'" + coccion + "')";
                        sep = ",";
                    }
                }
                sql_ins += values + ";";

                /* if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// agrega nuevos datos al catalogo de molienda
        public Boolean ActualizaCatMolienda()
        {
            try
            {
                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_molienda) AS id_max FROM cat_molienda");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO cat_molienda (id_molienda,molienda) VALUES";
                DataSet NuevosDatos = new DataSet();

                // ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_molienda,molienda FROM cat_molienda where id_molienda>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_molienda,molienda FROM cat_molienda");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {


                    string ids = ConexionMysql.regresaCampoConsulta("SELECT id_molienda FROM cat_molienda where id_molienda=" + Convert.ToString(row["id_molienda"]));

                    if (ids != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE cat_molienda SET molienda ='" + Convert.ToString(row["molienda"]) + "' WHERE id_molienda=" + Convert.ToString(row["id_molienda"])) == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;
                        string id = Convert.ToString(row["id_molienda"]);
                        string molienda = Convert.ToString(row["molienda"]);

                        values += sep + "(" + id + ",'" + molienda + "')";
                        sep = ",";
                    }
                }
                sql_ins += values + ";";
                /*if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// agrega nuevos datos al catalogo de fermentacion
        public Boolean ActualizaCatFermentacion()
        {
            try
            {
                /*string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_fermentacion) AS id_max FROM cat_fermentacion");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO cat_fermentacion (id_fermentacion,fermentacion) VALUES";
                DataSet NuevosDatos = new DataSet();

                //ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_fermentacion,fermentacion FROM cat_fermentacion where id_fermentacion>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_fermentacion,fermentacion FROM cat_fermentacion");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string ids = ConexionMysql.regresaCampoConsulta("SELECT id_fermentacion,fermentacion FROM cat_fermentacion where id_fermentacion=" + Convert.ToString(row["id_fermentacion"]));

                    if (ids != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE cat_fermentacion SET fermentacion ='" + Convert.ToString(row["fermentacion"]) + "' WHERE id_fermentacion=" + Convert.ToString(row["id_fermentacion"])) == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;

                        string id = Convert.ToString(row["id_fermentacion"]);
                        string fermentacion = Convert.ToString(row["fermentacion"]);

                        values += sep + "(" + id + ",'" + fermentacion + "')";
                        sep = ",";
                    }
                }
                sql_ins += values + ";";
                /* if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// agrega nuevos datos al catalogo de destilacion
        public Boolean ActualizaCatDestilacion()
        {
            try    //// --- nos quedamos aqui --- !!!
            {
                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_destilacion) AS id_max FROM cat_destilacion");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO cat_destilacion (id_destilacion,destilacion) VALUES";
                DataSet NuevosDatos = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_destilacion,destilacion FROM cat_destilacion where id_destilacion>" + id_max_local + "");
                ConexionMysqlRemota.llenaDataset(ref NuevosDatos, "SELECT id_destilacion,destilacion FROM cat_destilacion");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string ids = ConexionMysql.regresaCampoConsulta("SELECT id_destilacion FROM cat_destilacion where id_destilacion=" + Convert.ToString(row["id_destilacion"]));

                    if (ids != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE cat_destilacion SET destilacion ='" + Convert.ToString(row["destilacion"]) + "' WHERE id_destilacion=" + Convert.ToString(row["id_destilacion"])) == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;

                        string id = Convert.ToString(row["id_destilacion"]);
                        string destilacion = Convert.ToString(row["destilacion"]);

                        values += sep + "(" + id + ",'" + destilacion + "')";
                        sep = ",";
                    }
                }
                sql_ins += values + ";";
                /*
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// actuliza relacion cp estado
        public Boolean ActualizaRelacionCpEstado()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM relacion_cp_estado");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO relacion_cp_estado (id,clave_estado,cp) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,estado,cp FROM asentamientos where id >" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string clave_estado = Convert.ToString(row["estado"]);
                    string cp = Convert.ToString(row["cp"]);

                    values += sep + "(" + id + "," + clave_estado + ",'" + cp + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// actuliza relacion cp estado
        public Boolean ActualizaCatPresentacion()
        {
            try
            {
                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_presentacion) AS id_max FROM cat_presentacion");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO cat_presentacion (id_presentacion,cantidad, medida) VALUES";
                DataSet NuevosDatos = new DataSet();
                //ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_presentacion,cantidad, medida FROM cat_presentacion where id_presentacion >" + id_max_local + "");
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_presentacion,cantidad, medida FROM cat_presentacion");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {

                    string ids = ConexionMysql.regresaCampoConsulta("SELECT id_presentacion FROM cat_presentacion where id_presentacion =" + Convert.ToString(row["id_presentacion"]));

                    if (ids != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {


                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE cat_presentacion SET id_presentacion =" + Convert.ToString(row["id_presentacion"]) + ",cantidad = " + Convert.ToString(row["cantidad"]) + ",medida ='" + Convert.ToString(row["medida"]) + "' WHERE id_presentacion=" + Convert.ToString(row["id_presentacion"])) == "Error")
                            return false;


                    }
                    else
                    {
                        bandera_insert = true;


                        string id = Convert.ToString(row["id_presentacion"]);
                        string cantidad = Convert.ToString(row["cantidad"]);
                        string medida = Convert.ToString(row["medida"]);

                        values += sep + "(" + id + "," + cantidad + ",'" + medida + "')";
                        sep = ",";
                    }
                }
                sql_ins += values + ";";
                /*if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //--- baja  los id producciones
        public Boolean BajaIdsProduccion()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO ids_producciones (id_producciones, tipo_instalacion, id_produccion_entrada, id_lote, id_verificador,actualizado) VALUES";

                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                //--ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_producciones, tipo_instalacion, id_produccion_entrada, id_lote, id_verificador, actualizado from rv_ids_producciones WHERE actualizado=0");
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_producciones, tipo_instalacion, id_produccion_entrada, id_lote, id_verificador, actualizado from rv_ids_producciones");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_producciones from  ids_producciones where id_producciones='" + Convert.ToString(row["id_producciones"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;


                        values_update += sep_update + "'" + Convert.ToString(row["id_producciones"]) + "'";
                        sep_update = ",";

                        if (ConexionMysql.insUpd_transaccion("UPDATE  ids_producciones SET  id_producciones ='" + Convert.ToString(row["id_producciones"]) + "', tipo_instalacion ='" + Convert.ToString(row["tipo_instalacion"]) + "', id_produccion_entrada ='" + Convert.ToString(row["id_produccion_entrada"]) + "', id_lote ='" + Convert.ToString(row["id_lote"]) + "', id_verificador ='" + Convert.ToString(row["id_verificador"]) + "' WHERE id_producciones='" + Convert.ToString(row["id_producciones"]) + "'") == "Error")
                            return false;

                    }
                    else
                    {

                        bandera_insert = true;

                        string id_producciones = Convert.ToString(row["id_producciones"]);
                        string tipo_instalacion = Convert.ToString(row["tipo_instalacion"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_lote = Convert.ToString(row["id_lote"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_producciones + "','" + tipo_instalacion + "','" + id_produccion_entrada + "','" + id_lote + "','" + id_verificador + "',1)";
                        sep = ",";




                    }

                }

                sql += values + ";";



                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //Baja la tabla envasado entrada
        public Boolean BajaAlmacenEnvasadoEntrada()
        {
            try
            {
                string sep = "";
                string values = "";


                string sql = "INSERT INTO almacen_envasado_entrada (id_almacen_envasado_entrada,id_almacen_envasado_entrada_salio, id_marca, no_cliente, id_almacen,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso,actualizado) VALUES";

                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_entrada,id_almacen_envasado_entrada_salio,id_marca, no_cliente, id_almacen,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado_ini,'%Y-%m-%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin,'%Y-%m-%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso from rv_almacen_envasado_entrada");


              //  ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_entrada,id_envasado_entrada_salio, id_marca, no_cliente, id_envasadora,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado,'%Y-%m-%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin,'%Y-%m-%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales, botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,actualizado from rv_envasado_entrada ");


                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_entrada from  almacen_envasado_entrada where id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "'");
                    if (id != "")
                    {///-- Entra si encuentra coinsidencias y actualiza...
                        bandera_update = true;

                       // if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_entrada SET  id_marca='" + Convert.ToString(row["id_marca"]) + "',fq='" + Convert.ToString(row["fq"]) + "', fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',etiquetado_como='" + Convert.ToString(row["etiquetado_como"]) + "', litros='" + Convert.ToString(row["litros"]) + "',botellas_iniciales='" + Convert.ToString(row["botellas_iniciales"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "' WHERE id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "' ") == "Error")
                          //  return false;

                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_entrada SET id_almacen_envasado_entrada_salio='" + Convert.ToString(row["id_almacen_envasado_entrada_salio"]) + "',id_marca='" + Convert.ToString(row["id_marca"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',fecha_envasado_ini='" + Convert.ToString(row["fecha_envasado_ini"]) + "',fecha_envasado_fin='" + Convert.ToString(row["fecha_envasado_fin"]) + "',id_almacen='" + Convert.ToString(row["id_almacen"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',etiquetado_como='" + Convert.ToString(row["etiquetado_como"]) + "',unidad_medida='" + Convert.ToString(row["unidad_medida"]) + "',contenido_por_botella='" + Convert.ToString(row["contenido_por_botella"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',grado_alcoholico_etiqueta='" + Convert.ToString(row["grado_alcoholico_etiqueta"]) + "',botellas_iniciales='" + Convert.ToString(row["botellas_iniciales"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',holograma_inicio='" + Convert.ToString(row["holograma_inicio"]) + "',holograma_fin='" + Convert.ToString(row["holograma_fin"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',actualizado=1  WHERE id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "' ") == "Error")
                            return false;



                    }
                    else
                    {
                        /// -- Si no encuentra coincidencia entra y hace un insert...

                        bandera_insert = true;
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_almacen_envasado_entrada_salio = Convert.ToString(row["id_almacen_envasado_entrada_salio"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_envasado_ini = Convert.ToString(row["fecha_envasado_ini"]);
                        string fecha_envasado_fin = Convert.ToString(row["fecha_envasado_fin"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string etiquetado_como = Convert.ToString(row["etiquetado_como"]);
                        string unidad_medida = Convert.ToString(row["unidad_medida"]);
                        string contenido_por_botella = Convert.ToString(row["contenido_por_botella"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string grado_alcoholico_etiqueta = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        string botellas_iniciales = Convert.ToString(row["botellas_iniciales"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);

                        ///-- genera la cadena de los insert---
                        values += sep + "('" + id_almacen_envasado_entrada + "','" + id_almacen_envasado_entrada_salio + "','" + id_marca + "','" + no_cliente + "','" + id_almacen + "','" + fecha_movimiento + "','" + fecha + "','" + fecha_envasado_ini + "','" + fecha_envasado_fin + "','" + id_comun + "','" + no_lote_granel + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + etiquetado_como +"','" + unidad_medida + "','" + contenido_por_botella + "','" + litros + "','" + grado_alcoholico + "','" + grado_alcoholico_etiqueta + "','" + botellas_iniciales + "','" + botellas + "','" + botellas_existentes + "','" + holograma_inicio + "','" + holograma_fin + "','" + id_verificador + "','"+tipo_ingreso+"',1)";
                        sep = ",";


                    }
                }

                ///-- establese la cadena de los insert
                sql += values + ";";

                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//-- fin Suvidaalmacenenvasado





        //sube la tabla almacen envasado ensamble
        public Boolean BajaAlmacenEnvasadoEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_envasado_ensamble (id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador,actualizado) VALUES";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;

                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador from rv_almacen_envasado_ensamble");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_ensamble from  almacen_envasado_ensamble where id_almacen_envasado_ensamble='" + Convert.ToString(row["id_almacen_envasado_ensamble"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_ensamble SET  id_almacen_envasado_entrada= '" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',litros='" + Convert.ToString(row["litros"]) + "'   WHERE id_almacen_envasado_ensamble='" + Convert.ToString(row["id_almacen_envasado_ensamble"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen_envasado_ensamble = Convert.ToString(row["id_almacen_envasado_ensamble"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_envasado_ensamble + "','" + id_almacen_envasado_entrada + "','" + id_comun + "','" + no_lote_granel + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";


                    }

                }




                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {
                    sql += values + ";";

                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen envasado Movimientos
        public Boolean BajaAlmacenEnvasadoMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";

                string sql = "INSERT INTO almacen_envasado_movimientos (id_almacen_envasado_movimientos, id_almacen_envasado_entrada, id_almacen_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, fecha, id_verificador, actualizado, observaciones) VALUES";

                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_movimientos, id_almacen_envasado_entrada, id_almacen_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, id_verificador, observaciones from rv_almacen_envasado_movimientos ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_movimientos from  almacen_envasado_movimientos where id_almacen_envasado_movimientos='" + Convert.ToString(row["id_almacen_envasado_movimientos"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_movimientos SET  tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',cajas='" + Convert.ToString(row["cajas"]) + "',botellas_por_cajas='" + Convert.ToString(row["botellas_por_cajas"]) + "' WHERE id_almacen_envasado_movimientos='" + Convert.ToString(row["id_almacen_envasado_movimientos"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen_envasado_movimientos = Convert.ToString(row["id_almacen_envasado_movimientos"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_almacen_env_mov_salio = Convert.ToString(row["id_almacen_env_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string destino = Convert.ToString(row["destino"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string cajas = Convert.ToString(row["cajas"]);
                        string botellas_por_cajas = Convert.ToString(row["botellas_por_cajas"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        values += sep + "('" + id_almacen_envasado_movimientos + "','" + id_almacen_envasado_entrada + "','" + id_almacen_env_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + botellas + "','" + botellas_existentes + "','" + cajas + "','" + botellas_por_cajas + "','" + fecha + "','" + id_verificador + "',1,'" + observaciones + "')";
                        sep = ",";


                    }
                }
                sql += values + ";";



                if (bandera_update == true && bandera_insert == false)
                {

                    ConexionMysql.transCompleta();
                    return true;
                }
                else
                {


                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla  almacen encargado
        public Boolean BajaAlmacenEncargado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_encargado (id_almacen, no_cliente, almacen, encargado,folio_unico_granel,estado,municipio,localidad, id_verificador,tipo_almacen, actualizado,fecha) VALUES";

                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen, no_cliente, almacen, encargado,folio_unico_granel,estado,municipio,localidad, id_verificador,tipo_almacen  from rv_almacen_encargado");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen from  almacen_encargado where id_almacen='" + Convert.ToString(row["id_almacen"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_encargado SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',almacen='" + Convert.ToString(row["almacen"]) + "',encargado='" + Convert.ToString(row["encargado"]) + "',folio_unico_granel='" + Convert.ToString(row["folio_unico_granel"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "',tipo_almacen='" + Convert.ToString(row["tipo_almacen"]) + "'  WHERE id_almacen='" + Convert.ToString(row["id_almacen"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string almacen = Convert.ToString(row["almacen"]);
                        string encargado = Convert.ToString(row["encargado"]);
                        string folio_unico_granel = Convert.ToString(row["folio_unico_granel"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_almacen = Convert.ToString(row["tipo_almacen"]);



                        values += sep + "('" + id_almacen + "','" + no_cliente + "','" + almacen + "','" + encargado + "','" + folio_unico_granel + "','" + estado + "','" + municipio + "','" + localidad + "','" + id_verificador + "','" + tipo_almacen + "',1)";
                        sep = ",";


                    }
                }
                sql += values + ";";



                if (bandera_update == true && bandera_insert == false)
                {

                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen_envasado_hologramas
        public Boolean BajaAlmacenEnvasadoHologramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_envasado_holograma (id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca,holograma_inicio, holograma_fin,serie,tipo_instalacion,id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie,tipo_instalacion, id_verificador from rv_almacen_envasado_holograma");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_holograma from  almacen_envasado_holograma where id_almacen_envasado_holograma='" + Convert.ToString(row["id_almacen_envasado_holograma"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_holograma SET  id_almacen_envasado_entrada= '" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',cve_marca='" + Convert.ToString(row["cve_marca"]) + "',holograma_inicio='" + Convert.ToString(row["holograma_inicio"]) + "',holograma_fin='" + Convert.ToString(row["holograma_fin"]) + "',serie='" + Convert.ToString(row["serie"]) + "',tipo_instalacion='" + Convert.ToString(row["tipo_instalacion"]) + "'   WHERE id_almacen_envasado_holograma='" + Convert.ToString(row["id_almacen_envasado_holograma"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen_envasado_holograma = Convert.ToString(row["id_almacen_envasado_holograma"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cve_marca = Convert.ToString(row["cve_marca"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string serie = Convert.ToString(row["serie"]);
                        string tipo_instalacion = Convert.ToString(row["tipo_instalacion"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_envasado_holograma + "','" + id_almacen_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + holograma_inicio + "','" + holograma_fin + "','" + serie + "','" + tipo_instalacion + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }


                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }








        //sube la tabla almacen granel ensamble
        public Boolean BajaAlmacenGranelEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_ensamble (id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES";

                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from rv_almacen_granel_ensamble");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_granel_ensamble from  almacen_granel_ensamble where id_almacen_granel_ensamble='" + Convert.ToString(row["id_almacen_granel_ensamble"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_granel_ensamble SET  id_comun='" + Convert.ToString(row["id_comun"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_almacen_granel_ensamble='" + Convert.ToString(row["id_almacen_granel_ensamble"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;

                        string id_almacen_granel_ensamble = Convert.ToString(row["id_almacen_granel_ensamble"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_almacen_granel_entrada_salio = Convert.ToString(row["id_almacen_granel_entrada_salio"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_ensamble + "','" + id_almacen_granel_entrada + "','" + id_almacen_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";

                    }

                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen_granel_entrada
        public Boolean BajaAlmacenGranelEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_entrada (id_almacen_granel_entrada, no_cliente, id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,fecha_movimiento, id_verificador, actualizado) VALUES";
                //string update = "UPDATE almacen_granel_entrada SET actualizado=1 WHERE id_almacen_granel_entrada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_entrada, no_cliente, id_almacen,  DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_almacen_granel_entrada");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    /* @adnto en el foreach recorre los resultados de todos aquellos registros de la tabla local granel_entrada
                     * que el campo actualizado tenga=0 en cada iteración obtiene obtiene el id del registro
                     * consulta el id en la tabla del servidor, si existe ese id  */

                    string id = ConexionMysql.regresaCampoConsulta("select id_almacen_granel_entrada from  almacen_granel_entrada where id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "'");
                    if (id != "")
                    {
                        /* @adnto si trae algó la cadena de id, quiere decir q el id existe en el servidor
                         * entonces quiere decir q tendrá q actualizar se en el servidor */

                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_granel_entrada   SET   no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_almacen='" + Convert.ToString(row["id_almacen"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',lts_entrada='" + Convert.ToString(row["lts_entrada"]) + "',grado_alcoholico_entrada='" + Convert.ToString(row["grado_alcoholico_entrada"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "'   WHERE id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "' ") == "Error")
                            return false;


                    }
                    else
                    {
                        /* @dnto si no encuentra coincidencia con algún id entonces tendrá q hacer una insercción   */
                        bandera_insert = true;

                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string tipo_producto = Convert.ToString(row["tipo_ingreso"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_entrada + "','" + no_cliente + "','" + id_almacen + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + tipo_producto + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }


                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


        }



        //Baja la tabla almacen_granel_movimientos
        public Boolean BajaAlmacenGranelMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos, id_almacen_granel_entrada, id_almacen_granel_entrada_sal, id_almacen_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, fecha,fecha_movimiento, id_verificador, actualizado) VALUES";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_movimientos, id_almacen_granel_entrada, id_almacen_granel_entrada_sal, id_almacen_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_almacen_granel_movimientos");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_almacen_granel_movimientos from  almacen_granel_movimientos where id_almacen_granel_movimientos='" + Convert.ToString(row["id_almacen_granel_movimientos"]) + "'");
                    if (id != "")
                    {
                        /*@adnto si existe el id quiere decir que ya existe el registro por lo tanto lo que se debe de hacer es solamente actualizar en el servidor (UPDATE) */
                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_granel_movimientos SET id_almacen_granel_entrada_sal='" + Convert.ToString(row["id_almacen_granel_entrada_sal"]) + "', id_almacen_gran_mov_salio='" + Convert.ToString(row["id_almacen_gran_mov_salio"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "', no_lote='" + Convert.ToString(row["no_lote"]) + "', folio='" + Convert.ToString(row["folio"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',merma_litros='" + Convert.ToString(row["merma_litros"]) + "',numero_de_contenedores_iniciales='" + Convert.ToString(row["numero_de_contenedores_iniciales"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',fecha= '" + Convert.ToString(row["fecha"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "' WHERE id_almacen_granel_movimientos='" + Convert.ToString(row["id_almacen_granel_movimientos"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        /*@adnto cuando no encuentra el id quiere decir q no existe ese registro y q debera ser tomado como nuevo e insertarlo en el servidor. */
                        bandera_insert = true;
                        string id_almacen_granel_movimientos = Convert.ToString(row["id_almacen_granel_movimientos"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_almacen_granel_entrada_sal = Convert.ToString(row["id_almacen_granel_entrada_sal"]);
                        string id_almacen_gran_mov_salio = Convert.ToString(row["id_almacen_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string tipo_cobro = Convert.ToString(row["tipo_cobro"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_anteriores = Convert.ToString(row["lts_anteriores"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_movimientos + "','" + id_almacen_granel_entrada + "','" + id_almacen_granel_entrada_sal + "','" + id_almacen_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + tipo_cobro + "','" + observaciones + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";



                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }



        //sube la tabla almacen granel tanque 
        public Boolean BajaAlmacenGranelTanque()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                string sql = "INSERT INTO almacen_granel_tanques (id_tanque, id_almacen_granel_entrada, tanque, id_verificador, actualizado) VALUES";

                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_tanque, id_almacen_granel_entrada, tanque, id_verificador, actualizado from rv_almacen_granel_tanques");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_tanque from  almacen_granel_tanques where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_tanques SET  tanque='" + Convert.ToString(row["tanque"]) + "'   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;



                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_tanque + "','" + id_almacen_granel_entrada + "','" + tanque + "','" + id_verificador + "',1)";
                        sep = ",";

                    }

                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        public Boolean BajaAlmacenGranelSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_salida (id_almacen_granel_salida, id_almacen_granel_entrada, id_solicitud,id_granel_entrada, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador) VALUES";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_salida, id_almacen_granel_entrada, id_solicitud,id_granel_entrada, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado from rv_almacen_granel_salida");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_granel_salida from  almacen_granel_salida where id_granel_salida='" + Convert.ToString(row["id_almacen_granel_salida"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_salida SET  id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico=  '" + Convert.ToString(row["grado_alcoholico"]) + "'     WHERE id_almacen_granel_salida='" + Convert.ToString(row["id_almacen_granel_salida"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;


                        string id_almacen_granel_salida = Convert.ToString(row["id_almacen_granel_salida"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_salida + "','" + id_almacen_granel_entrada + "','" + id_solicitud + "','" + id_granel_entrada + "','" + id_granel_entrada_envasado + "','" + id_envasado_entrada + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1)";
                        sep = ",";
                        values_update += sep_update + "'" + id_almacen_granel_salida + "'";
                        sep_update = ",";

                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //baja la tabla maestros_mezcaleros
        public Boolean BajaMaestroMezcalero()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql = "INSERT INTO rv_maestro_fabrica (id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha, activo, actualizado) VALUES";

                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, activo, actualizado from rv_maestros_mezcaleros");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_maestros_mezcaleros from  maestros_mezcaleros where id_maestros_mezcaleros='" + Convert.ToString(row["id_maestros_mezcaleros"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE  maestros_mezcaleros SET  n_maestro_mezcalero='" + Convert.ToString(row["n_maestro_mezcalero"]) + "' ,id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "', activo='" + Convert.ToString(row["activo"]) + "'   WHERE id_maestros_mezcaleros='" + Convert.ToString(row["id_maestros_mezcaleros"]) + "'") == "Error")
                            return false;

                    }
                    else
                    {

                        bandera_insert = true;
                        string id_maestros_mezcaleros = Convert.ToString(row["id_maestros_mezcaleros"]);
                        string n_maestro_mezcalero = Convert.ToString(row["n_maestro_mezcalero"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string activo = Convert.ToString(row["activo"]);
                        values += sep + "('" + id_maestros_mezcaleros + "','" + n_maestro_mezcalero + "','" + id_fabrica + "','" + id_verificador + "','" + fecha + "','" + activo + "',1)";
                        sep = ",";

                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        public Boolean BajaEnvasadoSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO envasado_salida (id_envasado_salida, id_envasado_entrada, id_almacen_envasado_entrada, id_granel_entrada_envasado, id_envasado_mov_salida, litros, botellas, grado_alcoholico, tipo_salida, observaciones, id_verificador, fecha, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_salida, id_envasado_entrada, id_almacen_envasado_entrada, id_granel_entrada_envasado, id_envasado_mov_salida, litros, botellas, grado_alcoholico, tipo_salida, observaciones, id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, actualizado from rv_envasado_salida");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_salida from  envasado_salida where id_envasado_salida='" + Convert.ToString(row["id_envasado_salida"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE  envasado_salida SET  id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "' ,id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "', id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', id_envasado_mov_salida='" + Convert.ToString(row["id_envasado_mov_salida"]) + "', litros='" + Convert.ToString(row["litros"]) + "', botellas='" + Convert.ToString(row["botellas"]) + "', grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "', tipo_salida='" + Convert.ToString(row["tipo_salida"]) + "', observaciones='" + Convert.ToString(row["observaciones"]) + "'   WHERE id_envasado_salida='" + Convert.ToString(row["id_envasado_salida"]) + "'") == "Error")
                            return false;

                    }
                    else
                    {

                        bandera_insert = true;

                        string id_envasado_salida = Convert.ToString(row["id_envasado_salida"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_envasado_mov_salida = Convert.ToString(row["id_envasado_mov_salida"]);
                        string litros = Convert.ToString(row["litros"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string tipo_salida = Convert.ToString(row["tipo_salida"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);

                        values += sep + "('" + id_envasado_salida + "','" + id_envasado_entrada + "','" + id_almacen_envasado_entrada + "','" + id_granel_entrada_envasado + "','" + id_envasado_mov_salida + "','" + litros + "','" + botellas + "','" + grado_alcoholico + "','" + tipo_salida + "','" + observaciones + "','" + id_verificador + "','" + fecha + "',1)";
                        sep = ",";


                    }

                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }








        public Boolean BajaMensajesRegistros()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO mensajes_registros (id_mensaje, id_registro, tipo, mensaje, fecha, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_mensaje, id_registro, tipo, mensaje, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_verificador, actualizado from rv_mensajes_registros ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_mensaje from  mensajes_registros where id_mensaje='" + Convert.ToString(row["id_mensaje"]) + "'");
                    if (id != "")
                    {
                        /*  if (Convert.ToString(row["actualizado"]) == "0")
                          {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE mensajes_registros SET mensaje='" + Convert.ToString(row["mensaje"]) + "', id_verificador='" + Convert.ToString(row["id_verificador"]) + "' WHERE id_mensaje='" + Convert.ToString(row["id_mensaje"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_mensaje = Convert.ToString(row["id_mensaje"]);
                        string id_registro = Convert.ToString(row["id_registro"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string mensaje = Convert.ToString(row["mensaje"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_mensaje + "','" + id_registro + "','" + tipo + "','" + mensaje + "','" + fecha + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        public Boolean BajaFqHistorial()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO fq_historial (id_fq, id_produccion, tipo, fq, litros, grado_alcoholico, observacion, id_verificador, actualizado, fecha) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_fq, id_produccion, tipo, fq, litros, grado_alcoholico, observacion, id_verificador, actualizado,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha  from rv_fq_historial ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_fq from  fq_historial where id_fq='" + Convert.ToString(row["id_fq"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE fq_historial SET fq='" + Convert.ToString(row["fq"]) + "', id_produccion='" + Convert.ToString(row["id_produccion"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "', litros='" + Convert.ToString(row["litros"]) + "' WHERE id_fq='" + Convert.ToString(row["id_fq"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {

                        bandera_insert = true;
                        string id_fq = Convert.ToString(row["id_fq"]);
                        string id_produccion = Convert.ToString(row["id_produccion"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string fq = Convert.ToString(row["fq"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string observacion = Convert.ToString(row["observacion"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);


                        values += sep + "('" + id_fq + "','" + id_produccion + "','" + tipo + "','" + fq + "','" + litros + "','" + grado_alcoholico + "','" + observacion + "','" + id_verificador + "',1,'" + fecha + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //baja las salidas de los hologramas entregados
        public Boolean BajaSalidaHolgramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO hologramas_salida (id_salidas, no_cliente, marca, serie,edo, fi1, ff1, se1) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_salidas, no_cliente, marca, serie,edo, fi1, ff1, se1,actualizado from h_salidas ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_salidas from  hologramas_salida where id_salidas='" + Convert.ToString(row["id_salidas"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE hologramas_salida SET fi1='" + Convert.ToString(row["fi1"]) + "', ff1='" + Convert.ToString(row["ff1"]) + "',se1='" + Convert.ToString(row["se1"]) + "' WHERE id_salidas='" + Convert.ToString(row["id_salidas"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_salidas = Convert.ToString(row["id_salidas"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string marca = Convert.ToString(row["marca"]);
                        string serie = Convert.ToString(row["serie"]);
                        string edo = Convert.ToString(row["edo"]);
                        string fi1 = Convert.ToString(row["fi1"]);
                        string ff1 = Convert.ToString(row["ff1"]);
                        string se1 = Convert.ToString(row["se1"]);


                        values += sep + "('" + id_salidas + "','" + no_cliente + "','" + marca + "','" + serie + "','" + edo + "','" + fi1 + "','" + ff1 + "','" + se1 + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //baja transaciones
        public Boolean BajaTransacciones()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO transacciones (id_transaccion, id_granel_entrada, id_granel_entrada_recibe, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe, id_envasado_entrada, id_envasado_entrada_recibe, no_traslado, id_verificador, actualizado, tipo_transaccion) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_transaccion, id_granel_entrada, id_granel_entrada_recibe, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe, id_envasado_entrada, id_envasado_entrada_recibe, no_traslado, id_verificador, actualizado, tipo_transaccion from rv_transacciones ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_transaccion from  transacciones where id_transaccion='" + Convert.ToString(row["id_transaccion"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE transacciones SET    no_traslado='" + Convert.ToString(row["no_traslado"]) + "', id_envasado_entrada_recibe='" + Convert.ToString(row["id_envasado_entrada_recibe"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',id_granel_entrada_envasado_recibe='" + Convert.ToString(row["id_granel_entrada_envasado_recibe"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "',id_granel_entrada_recibe='" + Convert.ToString(row["id_granel_entrada_recibe"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',actualizado=1, " + "tipo_transaccion='" + Convert.ToString(row["tipo_transaccion"]) + "' WHERE id_transaccion='" + Convert.ToString(row["id_transaccion"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_transaccion = Convert.ToString(row["id_transaccion"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_recibe = Convert.ToString(row["id_granel_entrada_recibe"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_envasado_recibe = Convert.ToString(row["id_granel_entrada_envasado_recibe"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_envasado_entrada_recibe = Convert.ToString(row["id_envasado_entrada_recibe"]);
                        string no_traslado = Convert.ToString(row["no_traslado"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_transaccion = Convert.ToString(row["tipo_transaccion"]);

                        values += sep + "('" + id_transaccion + "','" + id_granel_entrada + "','" + id_granel_entrada_recibe + "','" + id_granel_entrada_envasado + "','" + id_granel_entrada_envasado_recibe + "','" + id_envasado_entrada + "','" + id_envasado_entrada_recibe + "','" + no_traslado + "','" + id_verificador + "',1, '" + tipo_transaccion + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }






        //actauliza  los valores de la tabla envasao entrada
        public Boolean BajaEnvasadoEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_entrada (id_envasado_entrada,id_envasado_entrada_salio, id_marca, no_cliente, id_envasadora,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso,actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_entrada,id_envasado_entrada_salio, id_marca, no_cliente, id_envasadora,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado,'%Y-%m-%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin,'%Y-%m-%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales, botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso,actualizado from rv_envasado_entrada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_entrada from  envasado_entrada where id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET id_envasado_entrada_salio='" + Convert.ToString(row["id_envasado_entrada_salio"]) + "',id_marca='" + Convert.ToString(row["id_marca"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',fecha_envasado_ini='" + Convert.ToString(row["fecha_envasado_ini"]) + "',fecha_envasado_fin='" + Convert.ToString(row["fecha_envasado_fin"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) +"',etiquetado_como='" + Convert.ToString(row["etiquetado_como"]) + "',unidad_medida='" + Convert.ToString(row["unidad_medida"]) + "',contenido_por_botella='" + Convert.ToString(row["contenido_por_botella"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',grado_alcoholico_etiqueta='" + Convert.ToString(row["grado_alcoholico_etiqueta"]) + "',botellas_iniciales='" + Convert.ToString(row["botellas_iniciales"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',holograma_inicio='" + Convert.ToString(row["holograma_inicio"]) + "',holograma_fin='" + Convert.ToString(row["holograma_fin"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',actualizado=1  WHERE id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_envasado_entrada_salio = Convert.ToString(row["id_envasado_entrada_salio"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);//-- se agreg0
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_envasado_ini = Convert.ToString(row["fecha_envasado_ini"]);
                        string fecha_envasado_fin = Convert.ToString(row["fecha_envasado_fin"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string etiquetado_como = Convert.ToString(row["etiquetado_como"]);
                        string unidad_medida = Convert.ToString(row["unidad_medida"]);
                        string contenido_por_botella = Convert.ToString(row["contenido_por_botella"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string grado_alcoholico_etiqueta = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        string botellas_iniciales = Convert.ToString(row["botellas_iniciales"]);//-- se agego
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);

                        values += sep + "('" + id_envasado_entrada + "','" + id_envasado_entrada_salio + "','" + id_marca + "','" + no_cliente + "','" + id_envasadora + "','" + fecha_movimiento + "','" + fecha + "','" + fecha_envasado_ini + "','" + fecha_envasado_fin + "','" + id_comun + "','" + no_lote_granel + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + etiquetado_como +"','" + unidad_medida + "','" + contenido_por_botella + "','" + litros + "','" + grado_alcoholico + "','" + grado_alcoholico_etiqueta + "','" + botellas_iniciales + "','" + botellas + "','" + botellas_existentes + "','" + holograma_inicio + "','" + holograma_fin + "','" + id_verificador + "','"+tipo_ingreso+"',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//--- Fin de BajaEnvasadoEntrada



        //actualiza los valores d ela tabla envasado movimientos
        public Boolean BajaEnvasadoMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_movimientos (id_envasado_movimientos, id_envasado_entrada, id_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, fecha, id_verificador, actualizado, observaciones) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_movimientos, id_envasado_entrada, id_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas,  DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, id_verificador, actualizado, observaciones from rv_envasado_movimientos ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_movimientos from  envasado_movimientos where id_envasado_movimientos='" + Convert.ToString(row["id_envasado_movimientos"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos SET  id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',id_env_mov_salio='" + Convert.ToString(row["id_env_mov_salio"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_solicitud='" + Convert.ToString(row["id_solicitud"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',cajas='" + Convert.ToString(row["cajas"]) + "',botellas_por_cajas='" + Convert.ToString(row["botellas_por_cajas"]) + "',actualizado=1,observaciones='" + Convert.ToString(row["observaciones"]) + "' WHERE id_envasado_movimientos ='" + Convert.ToString(row["id_envasado_movimientos"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_movimientos = Convert.ToString(row["id_envasado_movimientos"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_env_mov_salio = Convert.ToString(row["id_env_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string destino = Convert.ToString(row["destino"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string cajas = Convert.ToString(row["cajas"]);
                        string botellas_por_cajas = Convert.ToString(row["botellas_por_cajas"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        values += sep + "('" + id_envasado_movimientos + "','" + id_envasado_entrada + "','" + id_env_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + botellas + "','" + botellas_existentes + "','" + cajas + "','" + botellas_por_cajas + "','" + fecha + "','" + id_verificador + "',1,'" + observaciones + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        //actualiza los valores d ela tabla envasado encargado
        public Boolean BajaEnvasadoEncargado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasadora_encargado (id_envasadora, no_cliente, envasadora, encargado,estado, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasadora, no_cliente, envasadora, encargado, estado,id_verificador, actualizado from rv_envasadora_encargado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasadora from  envasadora_encargado where id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasadora_encargado SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',envasadora='" + Convert.ToString(row["envasadora"]) + "',encargado='" + Convert.ToString(row["encargado"]) + "',estado='" + Convert.ToString(row["estado"]) + "' WHERE id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string envasadora = Convert.ToString(row["envasadora"]);
                        string encargado = Convert.ToString(row["encargado"]);
                        string estado = Convert.ToString(row["estado"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_envasadora + "','" + no_cliente + "','" + envasadora + "','" + encargado + "','" + estado + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de existencia_planta comprada
        public Boolean BajaExistenciaPlantaComprada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO existenciaplanta_comprada (id_existenciaplanta_comprada, id_planta, no_cliente, cantidadini, existenciaplantas, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_existenciaplanta_comprada, id_planta, no_cliente, cantidadini, existenciaplantas, id_verificador, actualizado from rv_existenciaplanta_comprada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_existenciaplanta_comprada from  existenciaplanta_comprada where id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta_comprada SET  existenciaplantas='" + Convert.ToString(row["existenciaplantas"]) + "' WHERE id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_existenciaplanta_comprada = Convert.ToString(row["id_existenciaplanta_comprada"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_existenciaplanta_comprada + "','" + id_planta + "','" + no_cliente + "','" + cantidadini + "','" + existenciaplantas + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_ensamble 
        public Boolean BajaGranelEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_ensamble (id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from rv_granel_ensamble ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_ensamble from  granel_ensamble where id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_ensamble SET id_granel_entrada ='"+ Convert.ToString(row["id_granel_entrada"])+"',  id_comun='" + Convert.ToString(row["id_comun"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_ensamble = Convert.ToString(row["id_granel_ensamble"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_salio = Convert.ToString(row["id_granel_entrada_salio"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_granel_ensamble + "','" + id_granel_entrada + "','" + id_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_ensamble_envasado
        public Boolean BajaGranelEnsambleEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_ensamble_envasado (id_granel_ensamble, id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_ensamble, id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from rv_granel_ensamble_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_ensamble from  granel_ensamble_envasado where id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_ensamble_envasado SET  id_granel_entrada_envasado ='"+Convert.ToString(row["id_granel_entrada_envasado"])+"',id_comun='" + Convert.ToString(row["id_comun"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_ensamble = Convert.ToString(row["id_granel_ensamble"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_salio = Convert.ToString(row["id_granel_entrada_envasado_salio"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_granel_ensamble + "','" + id_granel_entrada + "','" + id_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores de granel_entrada
        public Boolean BajaGranelEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_entrada (id_granel_entrada, no_cliente, id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador,tipo_ingreso,actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_entrada, no_cliente, id_fabrica, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha , id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') AS fecha_movimiento, id_verificador,tipo_ingreso, actualizado from rv_granel_entrada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_entrada from  granel_entrada where id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'");
                    if (id != "")
                    {
                        /*  if (Convert.ToString(row["actualizado"]) == "0")
                          {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada   SET   no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',lts_entrada='" + Convert.ToString(row["lts_entrada"]) + "',grado_alcoholico_entrada='" + Convert.ToString(row["grado_alcoholico_entrada"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',tipo_ingreso='"+Convert.ToString(row["tipo_ingreso"])+"'   WHERE id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);

                        values += sep + "('" + id_granel_entrada + "','" + no_cliente + "','" + id_fabrica + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + fecha_movimiento + "','" + id_verificador + "','"+tipo_ingreso+"',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_entrada_envasado
        public Boolean BajaGranelEntradaEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_entrada_envasado (id_granel_entrada_envasado, no_cliente, id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador,tipo_ingreso, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_entrada_envasado, no_cliente, id_envasadora, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha , id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') AS fecha_movimiento, id_verificador,tipo_ingreso, actualizado from rv_granel_entrada_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_entrada_envasado from  granel_entrada_envasado where id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada_envasado   SET   no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',lts_entrada='" + Convert.ToString(row["lts_entrada"]) + "',grado_alcoholico_entrada='" + Convert.ToString(row["grado_alcoholico_entrada"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',tipo_ingreso='"+Convert.ToString(row["tipo_ingreso"])+"'   WHERE id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);

                        values += sep + "('" + id_granel_entrada + "','" + no_cliente + "','" + id_envasadora + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + fecha_movimiento + "','" + id_verificador + "','"+tipo_ingreso+"',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }






        //actualiza los valores de granel_movimientos
        public Boolean BajaGranelMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_movimientos (id_granel_movimientos, id_granel_entrada, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico,lts_anteriores,litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, fecha,fecha_movimiento, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_movimientos, id_granel_entrada, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_granel_movimientos ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_movimientos from  granel_movimientos where id_granel_movimientos='" + Convert.ToString(row["id_granel_movimientos"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_movimientos SET id_granel_entrada_sal='" + Convert.ToString(row["id_granel_entrada_sal"]) + "', id_gran_mov_salio='" + Convert.ToString(row["id_gran_mov_salio"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "', no_lote='" + Convert.ToString(row["no_lote"]) + "', folio='" + Convert.ToString(row["folio"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',merma_litros='" + Convert.ToString(row["merma_litros"]) + "',numero_de_contenedores_iniciales='" + Convert.ToString(row["numero_de_contenedores_iniciales"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',fecha= '" + Convert.ToString(row["fecha"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "'WHERE id_granel_movimientos='" + Convert.ToString(row["id_granel_movimientos"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_movimientos = Convert.ToString(row["id_granel_movimientos"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_sal = Convert.ToString(row["id_granel_entrada_sal"]);
                        string id_gran_mov_salio = Convert.ToString(row["id_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_anteriores= Convert.ToString(row["lts_anteriores"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_granel_movimientos + "','" + id_granel_entrada + "','" + id_granel_entrada_sal + "','" + id_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores de granel_movimientos_envasado
        public Boolean BajaGranelMovimientosEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado, id_granel_entrada_envasado, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico,lts_anteriores litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, fecha,fecha_movimiento, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_movimientos_envasado, id_granel_entrada_envasado, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_granel_movimientos_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_movimientos_envasado from  granel_movimientos_envasado where id_granel_movimientos_envasado='" + Convert.ToString(row["id_granel_movimientos_envasado"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;

                        ///--- en proceso
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_movimientos_envasado SET  id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', id_granel_entrada_sal='" + Convert.ToString(row["id_granel_entrada_sal"]) + "', id_gran_mov_salio='" + Convert.ToString(row["id_gran_mov_salio"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "', destino='" + Convert.ToString(row["destino"]) + "', no_lote='" + Convert.ToString(row["no_lote"]) + "', folio='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',merma_litros='" + Convert.ToString(row["merma_litros"]) + "', numero_de_contenedores_iniciales='" + Convert.ToString(row["numero_de_contenedores_iniciales"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',fecha= '" + Convert.ToString(row["fecha"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "'     WHERE id_granel_movimientos_envasado='" + Convert.ToString(row["id_granel_movimientos_envasado"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_movimientos = Convert.ToString(row["id_granel_movimientos_envasado"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_sal = Convert.ToString(row["id_granel_entrada_sal"]);
                        string id_gran_mov_salio = Convert.ToString(row["id_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_anteriores = Convert.ToString(row["lts_anteriores"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_granel_movimientos + "','" + id_granel_entrada + "','" + id_granel_entrada_sal + "','" + id_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //actualiza los valores de granel_salida
        public Boolean BajaGranelSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_salida (id_granel_salida, id_granel_entrada, id_solicitud, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_salida, id_granel_entrada, id_solicitud, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado from rv_granel_salida ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_salida from  granel_salida where id_granel_salida='" + Convert.ToString(row["id_granel_salida"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_salida SET  id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico=  '" + Convert.ToString(row["grado_alcoholico"]) + "'     WHERE id_granel_salida='" + Convert.ToString(row["id_granel_salida"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_salida = Convert.ToString(row["id_granel_salida"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_granel_salida + "','" + id_granel_entrada + "','" + id_solicitud + "','" + id_granel_entrada_envasado + "','" + id_envasado_entrada + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_tanques
        public Boolean BajaGranelTanque()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_tanques (id_tanque, id_granel_entrada, tanque, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_tanque, id_granel_entrada, tanque, id_verificador, actualizado from rv_granel_tanques ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_tanque from  granel_tanques where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_tanques SET id_granel_entrada ='" + Convert.ToString(row["id_granel_entrada"]) + "', tanque='" + Convert.ToString(row["tanque"]) + "'   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_tanque + "','" + id_granel_entrada + "','" + tanque + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //actualiza los valores de granel_tanques_envasado
        public Boolean BajaGranelTanqueEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_tanques_envasado (id_tanque, id_granel_entrada_envasado, tanque, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_tanque, id_granel_entrada_envasado, tanque, id_verificador, actualizado from rv_granel_tanques_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_tanque from  granel_tanques_envasado where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE granel_tanques_envasado SET id_granel_entrada_envasado ='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "',tanque='" + Convert.ToString(row["tanque"]) + "'   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_tanque + "','" + id_granel_entrada + "','" + tanque + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //actualiza los valores de maestro fabrica
        public Boolean BajaMaestroFabrica()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO maestro_fabrica (id_fabrica, no_cliente, fabrica,maestro,folio_unico_granel,estado,municipio,localidad,id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_fabrica, no_cliente, fabrica, maestro,folio_unico_granel,estado,municipio,localidad,id_verificador, actualizado from rv_maestro_fabrica ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_fabrica from  maestro_fabrica where id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE maestro_fabrica SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',fabrica='" + Convert.ToString(row["fabrica"]) + "',maestro='" + Convert.ToString(row["maestro"]) + "',folio_unico_granel='" + Convert.ToString(row["folio_unico_granel"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "'   WHERE id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string fabrica = Convert.ToString(row["fabrica"]);
                        string maestro = Convert.ToString(row["maestro"]);
                        string folio_unico_granel = Convert.ToString(row["folio_unico_granel"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_fabrica + "','" + no_cliente + "','" + fabrica + "','" + maestro + "','" + folio_unico_granel + "','" + estado + "','" + municipio + "','" + localidad + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de agave cocido sobrante
        public Boolean BajaAgaveCocidoSobrante()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_agave_cocido_sobrante (id_agave_cocido_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_predio, id_planta, agave_cocido_kg, porcentaje_art, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_agave_cocido_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_predio, id_planta, agave_cocido_kg, porcentaje_art, id_verificador, actualizado from rv_produccion_agave_cocido_sobrante ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_agave_cocido_sobrante from  produccion_agave_cocido_sobrante where id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_cocido_sobrante SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',agave_cocido_kg='" + Convert.ToString(row["agave_cocido_kg"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "'   WHERE id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;


                        string id_agave_cocido_sobrante = Convert.ToString(row["id_agave_cocido_sobrante"]);
                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_cocido_kg = Convert.ToString(row["agave_cocido_kg"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_agave_cocido_sobrante + "','" + id_ensamble_union + "','" + id_produccion_entrada + "','" + no_cliente + "','" + id_predio + "','" + id_planta + "','" + agave_cocido_kg + "','" + porcentaje_art + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores de agave sobrante
        public Boolean BajaAgaveSobrante()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_agave_sobrante (id_agave_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_planta, agave_kg, porcentaje_art, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_agave_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_planta, agave_kg, porcentaje_art, id_verificador, actualizado from rv_produccion_agave_sobrante ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_agave_sobrante from  produccion_agave_sobrante where id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_sobrante SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',agave_kg='" + Convert.ToString(row["agave_kg"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "'   WHERE id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;


                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);

                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_agave_sobrante + "','" + id_ensamble_union + "','" + id_produccion_entrada + "','" + no_cliente + "','" + id_planta + "','" + agave_kg + "','" + porcentaje_art + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores produccion ensamble
        public Boolean BajaProduccionEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_ensamble ( id_ensamble_union, id_produccion_entrada, id_agave_sobrante, id_agave_cocido_sobrante, id_predio, id_planta, no_pinas_agave, agave_kg, agave_coccion_kg, porcentaje_art, tipo, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_ensamble_union, id_produccion_entrada, id_agave_sobrante, id_agave_cocido_sobrante, id_predio, id_planta, no_pinas_agave, agave_kg, agave_coccion_kg, porcentaje_art, tipo, id_verificador, actualizado from rv_produccion_ensamble ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_ensamble_union from  produccion_ensamble where id_ensamble_union='" + Convert.ToString(row["id_ensamble_union"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_ensamble SET  id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "',id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_ensamble_union='" + Convert.ToString(row["id_ensamble_union"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string id_agave_cocido_sobrante = Convert.ToString(row["id_agave_cocido_sobrante"]);

                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);

                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);

                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_ensamble_union + "','" + id_produccion_entrada + "','" + id_agave_sobrante + "','" + id_agave_cocido_sobrante + "','" + id_predio + "','" + id_planta + "','" + no_pinas_agave + "','" + agave_kg + "','" + agave_coccion_kg + "','" + porcentaje_art + "','" + tipo + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores produccion entrada
        public Boolean BajaProduccionEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_entrada (id_produccion_entrada, id_proc_entr_sal, id_agave_sobrante, no_cliente, id_fabrica,id_maestro_mezcalero, id_predio, id_planta, tapada, no_pinas_agave, agave_kg, agave_coccion_kg, id_coccion, periodo_coccion_inicio, periodo_coccion_fin, porcentaje_art, id_molienda, periodo_molienda_inicio, periodo_molienda_fin, periodo_formulacion_inicio, id_fermentacion, periodo_formulacion_fin, volumen_mosto, periodo_destilacion_inicio, id_destilacion, periodo_destilacion_fin, destilaciones_realizadas, lts_producidos, grado_alcoholico, lts_existentes, litros_puntas, grados_puntas, litros_colas, grados_colas,destilado_con,id_verificador, fecha, estatus, tipo, rendimiento,fecha_rendimiento, observaciones_rendimiento, id_verifico_rendimiento, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_produccion_entrada, id_proc_entr_sal, id_agave_sobrante, no_cliente, id_fabrica,id_maestro_mezcalero, id_predio, id_planta, tapada, no_pinas_agave, agave_kg, agave_coccion_kg, id_coccion,  DATE_FORMAT(periodo_coccion_inicio,'%Y-%m-%d') as periodo_coccion_inicio,  DATE_FORMAT(periodo_coccion_fin,'%Y-%m-%d') as periodo_coccion_fin, porcentaje_art, id_molienda,DATE_FORMAT(periodo_molienda_inicio,'%Y-%m-%d') as periodo_molienda_inicio  , DATE_FORMAT(periodo_molienda_fin,'%Y-%m-%d') as periodo_molienda_fin ,  DATE_FORMAT(periodo_formulacion_inicio,'%Y-%m-%d') as periodo_formulacion_inicio, id_fermentacion,  DATE_FORMAT(periodo_formulacion_fin,'%Y-%m-%d') as periodo_formulacion_fin, volumen_mosto,  DATE_FORMAT(periodo_destilacion_inicio,'%Y-%m-%d') as periodo_destilacion_inicio, id_destilacion,  DATE_FORMAT(periodo_destilacion_fin,'%Y-%m-%d') as periodo_destilacion_fin, destilaciones_realizadas, lts_producidos, grado_alcoholico, lts_existentes, litros_puntas, grados_puntas, litros_colas, grados_colas,destilado_con,id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, estatus, tipo, rendimiento,DATE_FORMAT(fecha_rendimiento,'%Y-%m-%d') as fecha_rendimiento, observaciones_rendimiento, id_verifico_rendimiento, actualizado from rv_produccion_entrada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_produccion_entrada from  produccion_entrada where id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET id_proc_entr_sal= '" + Convert.ToString(row["id_proc_entr_sal"]) + "',id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "',id_maestro_mezcalero='" + Convert.ToString(row["id_maestro_mezcalero"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',tapada='" + Convert.ToString(row["tapada"]) + "',no_pinas_agave='" + Convert.ToString(row["no_pinas_agave"]) + "',agave_kg='" + Convert.ToString(row["agave_kg"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_coccion='" + Convert.ToString(row["id_coccion"]) + "',periodo_coccion_inicio='" + Convert.ToString(row["periodo_coccion_inicio"]) + "',periodo_coccion_fin='" + Convert.ToString(row["periodo_coccion_fin"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_molienda='" + Convert.ToString(row["id_molienda"]) + "',periodo_molienda_inicio='" + Convert.ToString(row["periodo_molienda_inicio"]) + "',periodo_molienda_fin='" + Convert.ToString(row["periodo_molienda_fin"]) + "',periodo_formulacion_inicio='" + Convert.ToString(row["periodo_formulacion_inicio"]) + "',id_fermentacion='" + Convert.ToString(row["id_fermentacion"]) + "',periodo_formulacion_fin='" + Convert.ToString(row["periodo_formulacion_fin"]) + "',volumen_mosto='" + Convert.ToString(row["volumen_mosto"]) + "',periodo_destilacion_inicio='" + Convert.ToString(row["periodo_destilacion_inicio"]) + "',id_destilacion='" + Convert.ToString(row["id_destilacion"]) + "',periodo_destilacion_fin='" + Convert.ToString(row["periodo_destilacion_fin"]) + "',destilaciones_realizadas='" + Convert.ToString(row["destilaciones_realizadas"]) + "',lts_producidos='" + Convert.ToString(row["lts_producidos"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',litros_puntas='" + Convert.ToString(row["litros_puntas"]) + "',grados_puntas='" + Convert.ToString(row["grados_puntas"]) + "',litros_colas='" + Convert.ToString(row["litros_colas"]) + "',grados_colas='" + Convert.ToString(row["grados_colas"]) + "',destilado_con='" + Convert.ToString(row["destilado_con"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',estatus='" + Convert.ToString(row["estatus"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',rendimiento='" + Convert.ToString(row["rendimiento"]) + "',fecha_rendimiento='" + Convert.ToString(row["fecha_rendimiento"]) + "',observaciones_rendimiento='" + Convert.ToString(row["observaciones_rendimiento"]) + "',id_verifico_rendimiento='" + Convert.ToString(row["id_verifico_rendimiento"]) + "'    WHERE id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_proc_entr_sal = Convert.ToString(row["id_proc_entr_sal"]);
                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string id_maestro_mezcalero = Convert.ToString(row["id_maestro_mezcalero"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string tapada = Convert.ToString(row["tapada"]);
                        string no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_coccion = Convert.ToString(row["id_coccion"]);
                        string periodo_coccion_inicio = Convert.ToString(row["periodo_coccion_inicio"]);
                        string periodo_coccion_fin = Convert.ToString(row["periodo_coccion_fin"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_molienda = Convert.ToString(row["id_molienda"]);
                        string periodo_molienda_inicio = Convert.ToString(row["periodo_molienda_inicio"]);
                        string periodo_molienda_fin = Convert.ToString(row["periodo_molienda_fin"]);
                        string periodo_formulacion_inicio = Convert.ToString(row["periodo_formulacion_inicio"]);
                        string id_fermentacion = Convert.ToString(row["id_fermentacion"]);
                        string periodo_formulacion_fin = Convert.ToString(row["periodo_formulacion_fin"]);
                        string volumen_mosto = Convert.ToString(row["volumen_mosto"]);
                        string periodo_destilacion_inicio = Convert.ToString(row["periodo_destilacion_inicio"]);
                        string id_destilacion = Convert.ToString(row["id_destilacion"]);
                        string periodo_destilacion_fin = Convert.ToString(row["periodo_destilacion_fin"]);
                        string destilaciones_realizadas = Convert.ToString(row["destilaciones_realizadas"]);
                        string lts_producidos = Convert.ToString(row["lts_producidos"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string litros_puntas = Convert.ToString(row["litros_puntas"]);
                        string grados_puntas = Convert.ToString(row["grados_puntas"]);
                        string litros_colas = Convert.ToString(row["litros_colas"]);
                        string grados_colas = Convert.ToString(row["grados_colas"]);
                        string destilado_con = Convert.ToString(row["destilado_con"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string estatus = Convert.ToString(row["estatus"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string rendimiento = Convert.ToString(row["rendimiento"]);
                        string fecha_rendimiento = Convert.ToString(row["fecha_rendimiento"]);
                        string observaciones_rendimiento = Convert.ToString(row["observaciones_rendimiento"]);
                        string id_verifico_rendimiento = Convert.ToString(row["id_verifico_rendimiento"]);


                        values += sep + "('" + id_produccion_entrada + "','" + id_proc_entr_sal + "','" + id_agave_sobrante + "','" + no_cliente + "','" + id_fabrica + "','" + id_maestro_mezcalero + "','" + id_predio + "','" + id_planta + "','" + tapada + "','" + no_pinas_agave + "','" + agave_kg + "','" + agave_coccion_kg + "','" + id_coccion + "','" + periodo_coccion_inicio + "','" + periodo_coccion_fin + "','" + porcentaje_art + "','" + id_molienda + "','" + periodo_molienda_inicio + "','" + periodo_molienda_fin + "','" + periodo_formulacion_inicio + "','" + id_fermentacion + "','" + periodo_formulacion_fin + "','" + volumen_mosto + "','" + periodo_destilacion_inicio + "','" + id_destilacion + "','" + periodo_destilacion_fin + "','" + destilaciones_realizadas + "','" + lts_producidos + "','" + grado_alcoholico + "','" + lts_existentes + "','" + litros_puntas + "','" + grados_puntas + "','" + litros_colas + "','" + grados_colas + "','" + destilado_con + "','" + id_verificador + "','" + fecha + "','" + estatus + "','" + tipo + "','" + rendimiento + "','" + fecha_rendimiento + "','" + observaciones_rendimiento + "','" + id_verifico_rendimiento + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }






        //actualiza los valores produccion entrada
        public Boolean BajaProduccionPuntasColas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_puntas_colas (id_produccion_puntas_colas, no_cliente, tipo, litros, grado_alcoholico, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_produccion_puntas_colas, no_cliente, tipo, litros, grado_alcoholico, id_verificador, actualizado from rv_produccion_puntas_colas ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_produccion_puntas_colas from  produccion_puntas_colas where id_produccion_puntas_colas='" + Convert.ToString(row["id_produccion_puntas_colas"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_puntas_colas SET  no_cliente= '" + Convert.ToString(row["no_cliente"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "'   WHERE id_produccion_puntas_colas='" + Convert.ToString(row["id_produccion_puntas_colas"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_produccion_puntas_colas = Convert.ToString(row["id_produccion_puntas_colas"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_produccion_puntas_colas + "','" + no_cliente + "','" + tipo + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores produccion entrada
        public Boolean BajaProduccionSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_salida (id_produccion_salida, id_produccion_entrada, id_solicitud, id_granel_entrada, litros, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_produccion_salida, id_produccion_entrada, id_solicitud, id_granel_entrada, litros, id_verificador, actualizado from rv_produccion_salida ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_produccion_salida from  produccion_salida where id_produccion_salida='" + Convert.ToString(row["id_produccion_salida"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_salida SET  id_produccion_entrada= '" + Convert.ToString(row["id_produccion_entrada"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',litros='" + Convert.ToString(row["litros"]) + "'   WHERE id_produccion_salida='" + Convert.ToString(row["id_produccion_salida"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_produccion_salida = Convert.ToString(row["id_produccion_salida"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string litros = Convert.ToString(row["litros"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_produccion_salida + "','" + id_produccion_entrada + "','" + id_solicitud + "','" + id_granel_entrada + "','" + litros + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        //actualiza los valores envasado ensamble
        public Boolean BajaEnvasadoEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_ensamble (id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado from rv_envasado_ensamble ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_ensamble from  envasado_ensamble where id_envasado_ensamble='" + Convert.ToString(row["id_envasado_ensamble"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_ensamble SET  id_envasado_entrada= '" + Convert.ToString(row["id_envasado_entrada"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',litros='" + Convert.ToString(row["litros"]) + "' WHERE id_envasado_ensamble='" + Convert.ToString(row["id_envasado_ensamble"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_ensamble = Convert.ToString(row["id_envasado_ensamble"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_envasado_ensamble + "','" + id_envasado_entrada + "','" + id_comun + "','" + no_lote_granel + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores envasado holopgramas
        public Boolean BajaEnvasadoHologramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_holograma (id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie,id_verificador, actualizado from rv_envasado_holograma");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_envasado_holograma from  envasado_holograma where id_envasado_holograma='" + Convert.ToString(row["id_envasado_holograma"]) + "'");
                    if (id != "")
                    {
                        /*  if (Convert.ToString(row["actualizado"]) == "0")
                          {*/
                        bandera_update = true;
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_holograma SET  id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',cve_marca='" + Convert.ToString(row["cve_marca"]) + "',holograma_inicio='" + Convert.ToString(row["holograma_inicio"]) + "',holograma_fin='" + Convert.ToString(row["holograma_fin"]) + "',serie='" + Convert.ToString(row["serie"]) + "'   WHERE id_envasado_holograma='" + Convert.ToString(row["id_envasado_holograma"]) + "' ") == "Error")
                            return false;
                        // }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_holograma = Convert.ToString(row["id_envasado_holograma"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cve_marca = Convert.ToString(row["cve_marca"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string serie = Convert.ToString(row["serie"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_envasado_holograma + "','" + id_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + holograma_inicio + "','" + holograma_fin + "','" + serie + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        // baja informacion
        public Boolean BajaDeInformacion()
        {
            try
            {
                if (ConexionMysqlRemota2.insUpd_transaccion("INSERT INTO rv_subida_bajada (id_verificador, tipo, fecha) VALUES(" + usrVeriDB + ",'Bajada de informacion',now()) ") == "Error")
                {
                    return false;
                }

                if (ConexionMysql.insUpd_transaccion("INSERT INTO subida_bajada (id_verificador, tipo, fecha) VALUES(" + usrVeriDB + ",'Bajada de informacion',now()) ") == "Error")
                {
                    return false;
                }

                ConexionMysqlRemota2.transCompleta();
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        } //--->>>>>-Fin baja informacion

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void FrmAdministrador_Load(object sender, EventArgs e)
        {

            progressBar1.Visible = false;
            lblporcentaje.Visible = false;
            try
            {
                ConexionMysql.llenaCombo(ref cmbVerificadoresList, "SELECT  nombre,id_us  FROM verificadores where status <>0", "id_us", "nombre");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // return false;
            }
        }

        private void cmbVerificadoresList_SelectedIndexChanged(object sender, EventArgs e)
        {
            usrVeriDB = cmbVerificadoresList.SelectedValue.ToString();
        }

        private void BtnBackups_Click(object sender, EventArgs e)
        {

            try
            {


                string ruta = Directory.GetCurrentDirectory().ToString() + @"/Scrip\rvk.txt";


                string line1;
                string line2;
                string line3;
                string line4;
                string[] coord = new string[4];

                StreamReader lee = new StreamReader(ruta, true);

                string line = "";

                for (int r = 0; r < 4; r++)
                {
                    line = lee.ReadLine();
                    coord[r] = Convert.ToString(line);
                }

                line1 = coord[0];
                line2 = coord[1];
                line3 = coord[2];
                line4 = coord[3];

                // Console.WriteLine(desencriptar(line1));
                // Console.WriteLine(desencriptar(line2));
                //onsole.WriteLine(desencriptar(line3));
                // Console.WriteLine(desencriptar(line4));


                // lee.Close();
                //Console.WriteLine(Actual);




                // "Database=" + desencriptar(line1) + ";Data Source=" + desencriptar(line2) + ";User Id=" + desencriptar(line3) + ";Password=" + desencriptar(line4) + ";CharSet=utf8;";


                string fecha = DateTime.Now.ToString("yyyyMMdd_hh:mm:ss.F");
                string rutadir = @"C:\Program Files (x86)\dumpreveca2\";


                string inst = "mysqldump --u " + desencriptar(line3) + " --password=" + desencriptar(line4) + " " + desencriptar(line1) + " produccion_entrada produccion_ensamble > " + @"C:\Program Files (x86)\dumpreveca2\" + Usuario.IdUsuario + "_reveca2_" + fecha + ".sql";
                //ConexionMysql.insUpd(inst);


                //  System.Diagnostics.Process.Start("CMD.exe", "/K  cd /xampp/mysql/bin"+inst); //---  ejecuta la consulta
                //System.Diagnostics.Process.Start("CMD.exe", "cd /xampp/mysql/bin"); //---  ejecuta la consulta

                /*System.Diagnostics.Process.Start("cmd.exe", "www.northwindtraders.com");

                // Start a Web page using a browser associated with .html and .asp files.
                System.Diagnostics.Process.Start("IExplore.exe", "C:\\myPath\\myFile.htm");
                System.Diagnostics.Process.Start("IExplore.exe", "C:\\myPath\\myFile.asp");
                    */


              //  System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
                //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;

                //System.Diagnostics.Process.Start(startInfo);
                // startInfo.Arguments = "cd /xampp/mysql/bin";
               // startInfo.Arguments = "www.northwindtraders.com";
                //startInfo.Arguments = inst;

              //  System.Diagnostics.Process.Start(startInfo);

                /* System.Diagnostics.Process cmd = new  System.Diagnostics.Process(); //---  ejecuta la consulta
                  cmd.StartInfo.FileName = "cmd.exe" ;
                 
                 cmd.StartInfo.RedirectStandardInput = true;
                 cmd.StartInfo.RedirectStandardOutput = true;
                 cmd.StartInfo.CreateNoWindow = false;
                 cmd.StartInfo.UseShellExecute = false;
                 cmd.Start();

                cmd.StandardInput.WriteLine("cd /xampp/mysql/bin");
                cmd.StandardInput.Flush();
                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                    Console.Read();*/


                // MessageBox.Show(" copia con exito");

                /*  System.Diagnostics.Process process = new System.Diagnostics.Process(); 
                          System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                         // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; 
                          startInfo.FileName = "cmd.exe";
                          startInfo.RedirectStandardInput = true;
                          startInfo.RedirectStandardOutput = true;
                          startInfo.CreateNoWindow = false;
                         startInfo.UseShellExecute = false;
                          //startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
                         startInfo.Arguments = "/K cd /xampp/mysql/bin";
                          //startInfo.Arguments =  inst;
                           //startInfo.StandardInput.WriteLine("echo Oscar");; 
                          process.StartInfo = startInfo; 
                          process.Start();
                        */




                /*  System.Diagnostics.Process cmd = new System.Diagnostics.Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = false;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    cmd.StandardInput.WriteLine("cd /xampp/mysql/bin");
                    cmd.StandardInput.Flush();
    //cmd.StandardInput.Close();
                    //cmd.WaitForExit();
                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                    Console.Read();*/





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void Btnfor_Click(object sender, EventArgs e)
        {
            for (int f = 0; f < 5; f++)
            {


                if (f==3){

                    MessageBox.Show("Aviso Importante"+f, "mdfieuf");
                    // break;
                    return;


                }
                MessageBox.Show("Aviso Importante" + f);

            }







        }



    }
}
