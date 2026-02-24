using Crm.Utilerias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crm.Inventario
{
    public partial class FrmBuenasPracticas : Form
    {
        public FrmBuenasPracticas()
        {
            InitializeComponent();
        }
        public string no_cliente;
        public string id_solicitud;
        public int tipo_dictaminacion;
        public int di_solicitud;
        public String codigo;
        int bp_id = 0;
        int guardado = 0;

        String inst_produccion = "1", inst_envasado = "1", inst_almacen = "1", inst_bebidas = "1";

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                string hora = dtpHora.Value.ToString("HH:mm");
                String id_acta = ConexionMysql.regresaCampoConsulta("Select id_acta FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                

                //String id_bp = ConexionMysql.regresaCampoConsulta("Select id_informe FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String testigos = ConexionMysql.regresaCampoConsulta("Select testigos FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_testigos SET testigo1='" + txtTestigo1.Text + "', testigo2='" + txtTestigo2.Text + "', " +
                    " modifico='" + Usuario.IdUsuario + "', fecha_modificacion=NOW() Where id='" + testigos + "'") == "Error")
                {
                    return;
                }
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET fecha_informe='" + fecha + "', hora_informe='" + hora + "', " +
                    " razon_social='" + txtRazonSocial.Text + "', no_escrito_comision='" + txtEscrito.Text + "',  registro='" + Usuario.IdUsuario + "',no_acta='" + txtActa.Text + "' Where id='" + di_solicitud + "'") == "Error")
                {
                    return;
                }

                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        void SaveData()
        {
            //Add code to process your data
            for (int i = 0; i <= 500; i++)
                Thread.Sleep(10); //Simulator
        }
        private void FrmBuenasPracticas_Load(object sender, EventArgs e)
        {
            try { 
                if (di_solicitud == 0)
                {
                    di_solicitud = int.Parse(ConexionMysql.regresaCampoConsulta("Select id FROM sinca.`di_solicitud` WHERE codigo='" + codigo + "'"));
                }
                cargar_generales();
                mostrar_guardados();
                mostrar_respuestas();
                verificar_instalaciones();   
            } catch (Exception ex)
            {
                MessageBox.Show("Debes guardar los datos de la apertura de acta para poder continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void verificar_instalaciones()
        {
            DataSet Datos2 = new DataSet();
            ConexionMysql.llenaDataset(ref Datos2, "SELECT productor as produccion, envasador as envasado, `comercializador`as almacen, bebidas_con as bebidas FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "' LIMIT 1");
            Console.WriteLine("SELECT productor as produccion, envasador as envasado, `comercializador`as almacen, bebidas_con as bebidas FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "' LIMIT 1");
            foreach (DataRow row in Datos2.Tables[0].Rows)
            {
                inst_produccion = Convert.ToString(row["produccion"]);
                inst_envasado = Convert.ToString(row["envasado"]);
                inst_almacen = Convert.ToString(row["almacen"]);
                inst_bebidas = Convert.ToString(row["bebidas"]);
            }

            if(inst_produccion == "0")
            {
                lblP1.Hide();
                lblP2.Hide();
                lblP3.Hide();
                lblP4.Hide();
                lblP5.Hide();

                cbProduccion1.Hide();
                cbProduccion4.Hide();
                cbProduccion5.Hide();
                cbProduccion6.Hide();
                cbProduccion7.Hide();
                cbProduccion8.Hide();
                cbProduccion9.Hide();
                cbProduccion10.Hide();
                cbProduccion11.Hide();
                cbProduccion12.Hide();
                cbProduccion13.Hide();
                cbProduccion14.Hide();
                cbProduccion15.Hide();
                cbProduccion19.Hide();
                cbProduccion20.Hide();
                cbProduccion21.Hide();
                cbProduccion22.Hide();
                cbProduccion23.Hide();
                cbProduccion24.Hide();
                cbProduccion25.Hide();
                cbProduccion33.Hide();
                cbProduccion34.Hide();
                cbProduccion35.Hide();
                cbProduccion36.Hide();
                cbProduccion37.Hide();
                cbProduccion38.Hide();
                cbProduccion39.Hide();
                cbProduccion40.Hide();
                cbProduccion41.Hide();
                cbProduccion42.Hide();
                cbProduccion43.Hide();
                cbProduccion44.Hide();
                cbProduccion45.Hide();
                cbProduccion46.Hide();
                cbProduccion47.Hide();
                cbProduccion48.Hide();
                cbProduccion49.Hide();
                cbProduccion50.Hide();
                cbProduccion51.Hide();
                cbProduccion52.Hide();
                cbProduccion53.Hide();
                cbProduccion54.Hide();
                cbProduccion55.Hide();
                cbProduccion56.Hide();
                cbProduccion57.Hide();
                cbProduccion58.Hide();
                cbProduccion59.Hide();
            }

            if (inst_envasado == "0")
            {
                lblE1.Hide();
                lblE2.Hide();
                lblE3.Hide();
                lblE4.Hide();
                lblE5.Hide();

                cbEnvasado1.Hide();
                cbEnvasado2.Hide();
                cbEnvasado3.Hide();
                cbEnvasado4.Hide();
                cbEnvasado5.Hide();
                cbEnvasado6.Hide();
                cbEnvasado7.Hide();
                cbEnvasado8.Hide();
                cbEnvasado9.Hide();
                cbEnvasado10.Hide();
                cbEnvasado11.Hide();
                cbEnvasado12.Hide();
                cbEnvasado13.Hide();
                cbEnvasado14.Hide();
                cbEnvasado15.Hide();
                cbEnvasado16.Hide();
                cbEnvasado17.Hide();
                cbEnvasado18.Hide();
                cbEnvasado19.Hide();
                cbEnvasado20.Hide();
                cbEnvasado21.Hide();
                cbEnvasado22.Hide();
                cbEnvasado23.Hide();
                cbEnvasado24.Hide();
                cbEnvasado25.Hide();
                cbEnvasado26.Hide();
                cbEnvasado27.Hide();
                cbEnvasado28.Hide();
                cbEnvasado29.Hide();
                cbEnvasado30.Hide();
                cbEnvasado31.Hide();
                cbEnvasado32.Hide();
                cbEnvasado33.Hide();
                cbEnvasado34.Hide();
                cbEnvasado35.Hide();
                cbEnvasado36.Hide();
                cbEnvasado37.Hide();
                cbEnvasado38.Hide();
                cbEnvasado39.Hide();
                cbEnvasado40.Hide();
                cbEnvasado41.Hide();
                cbEnvasado42.Hide();
                cbEnvasado43.Hide();
                cbEnvasado44.Hide();
                cbEnvasado45.Hide();
                cbEnvasado46.Hide();
                cbEnvasado47.Hide();
                cbEnvasado48.Hide();
                cbEnvasado49.Hide();
                cbEnvasado50.Hide();
                cbEnvasado51.Hide();
                cbEnvasado52.Hide();
                cbEnvasado53.Hide();
                cbEnvasado54.Hide();
                cbEnvasado55.Hide();
                cbEnvasado56.Hide();
                cbEnvasado57.Hide();
                cbEnvasado58.Hide();
                cbEnvasado59.Hide();
            }
            if (inst_almacen == "0")
            {
                lblA1.Hide();
                lblA2.Hide();
                lblA3.Hide();
                lblA4.Hide();
                lblA5.Hide();

                cbAlmacen1.Hide();
                cbAlmacen5.Hide();
                cbAlmacen11.Hide();
                cbAlmacen12.Hide();
                cbAlmacen13.Hide();
                cbAlmacen15.Hide();
                cbAlmacen16.Hide();
                cbAlmacen17.Hide();
                cbAlmacen19.Hide();
                cbAlmacen40.Hide();
                cbAlmacen41.Hide();
                cbAlmacen42.Hide();
                cbAlmacen43.Hide();
                cbAlmacen44.Hide();
                cbAlmacen45.Hide();
                cbAlmacen46.Hide();
                cbAlmacen47.Hide();
                cbAlmacen49.Hide();
                cbAlmacen53.Hide();
                cbAlmacen54.Hide();
                cbAlmacen55.Hide();
                cbAlmacen56.Hide();
                cbAlmacen57.Hide();
                cbAlmacen58.Hide();
            }

            if (inst_almacen == "1" && inst_envasado == "0" && inst_produccion == "0")
            {
                //tabParte3.Hide();
                tabsBuenasPracticas.TabPages.Remove(tabParte3);
                tabParte4.Text = "Parte 3";
                tabParte5.Text = "Parte 4";
            }
        }

        private void mostrar_respuestas()
        {
            String[,] respuestas = new String[3,59];

            String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
            int puntos_produccion = 0;
            int puntos_envasado = 0;
            int puntos_almacen = 0;
            DataSet Datos2 = new DataSet();
            ConexionMysql.llenaDataset(ref Datos2, "SELECT `id_enunciado`, `produccion`, `envasado`, `almacen`, `fecha_modificación` FROM sinca.`di_bp_respuestas` WHERE `id_bp`='" + id_bp + "' ORDER BY id_enunciado ASC");
            int x = 0;
            foreach (DataRow row in Datos2.Tables[0].Rows)
            {
                respuestas[0, x] = Convert.ToString(row["produccion"]);
                respuestas[1, x] = Convert.ToString(row["envasado"]);
                respuestas[2, x] = Convert.ToString(row["almacen"]);
                /*puntos_produccion += Convert.ToInt32(row["produccion"]);
                puntos_envasado += Convert.ToInt32(row["envasado"]);
                puntos_almacen += Convert.ToInt32(row["almacen"]);*/
                //puntos_almacen = Convert.ToInt32(respuestas[2, x]); 

                 try
                 {
                    if (!(Convert.ToInt32(row["produccion"])==3))
                    {
                        puntos_produccion += Convert.ToInt32(row["produccion"]);
                    }                   
                 }
                 catch (Exception ex)
                 {
                     //Console.WriteLine(ex);
                 }
                 try
                {
                    if (!(Convert.ToInt32(row["envasado"]) == 3))
                    {
                        puntos_envasado += Convert.ToInt32(row["envasado"]);
                    }
                 }
                 catch (Exception ex)
                 {
                     //Console.WriteLine(ex);
                 }
                 try
                 {
                    if (!(Convert.ToInt32(row["almacen"]) == 3))
                    {
                        puntos_almacen += Convert.ToInt32(row["almacen"]);
                    }
                 }
                 catch (Exception ex)
                 {
                    // Console.WriteLine(ex);
                 }
                x++;
            }

            if (puntos_produccion == 94)
            {
                lblResultadoUP.Text = "INSTALACIÓN EN CUMPLIMIENTO PREFERENTE";
            }
            else if (puntos_produccion > 47 && puntos_produccion < 94)
            {
                lblResultadoUP.Text = "INSTALACIÓN EN CUMPLIMIENTO";
            }
            else
            {
                lblResultadoUP.Text = "INSTALACIÓN EN INCUMPLIMIENTO";
                if (puntos_produccion == 0)
                {
                    lblResultadoUP.Text = "---";
                }
            }
            if (puntos_envasado == 118)
            {
                lblResultadoUE.Text = "INSTALACIÓN EN CUMPLIMIENTO PREFERENTE";
            }
            else if (puntos_envasado > 59 && puntos_envasado < 117)
            {
                lblResultadoUE.Text = "INSTALACIÓN EN CUMPLIMIENTO";
            }
            else
            {
                lblResultadoUE.Text = "INSTALACIÓN EN INCUMPLIMIENTO";
                if (puntos_envasado == 0)
                {
                    lblResultadoUE.Text = "---";
                }
            }
            if (puntos_almacen == 48)
            {
                lblResultadoUA.Text = "INSTALACIÓN EN CUMPLIMIENTO PREFERENTE";
            }
            else if (puntos_almacen > 24 && puntos_almacen < 47)
            {
                lblResultadoUA.Text = "INSTALACIÓN EN CUMPLIMIENTO";
            }
            else
            {
                lblResultadoUA.Text = "INSTALACIÓN EN INCUMPLIMIENTO";
                if (puntos_almacen == 0)
                {
                    lblResultadoUA.Text = "---";
                }
            }

            txtPuntajeProduccion.Text = puntos_produccion.ToString();
            txtPuntajeEnvasado.Text = puntos_envasado.ToString();
            txtPuntajeAlmacen.Text = puntos_almacen.ToString();


            cbProduccion1.Text = tipo(respuestas[0, 0]);
            cbEnvasado1.Text = tipo(respuestas[1, 0]);
            cbAlmacen1.Text = tipo(respuestas[2, 0]);
            cbEnvasado2.Text = tipo(respuestas[1, 1]);
            cbEnvasado3.Text = tipo(respuestas[1, 2]);
            cbProduccion4.Text = tipo(respuestas[0, 3]);
            cbEnvasado4.Text = tipo(respuestas[1, 3]);
            cbProduccion5.Text = tipo(respuestas[0, 4]);
            cbEnvasado5.Text = tipo(respuestas[1, 4]);
            cbAlmacen5.Text = tipo(respuestas[2, 4]);
            cbProduccion6.Text = tipo(respuestas[0, 5]);
            cbEnvasado6.Text = tipo(respuestas[1, 5]);
            cbProduccion7.Text = tipo(respuestas[0, 6]);
            cbEnvasado7.Text = tipo(respuestas[1, 6]);
            cbProduccion8.Text = tipo(respuestas[0, 7]);
            cbEnvasado8.Text = tipo(respuestas[1, 7]);
            cbProduccion9.Text = tipo(respuestas[0, 8]);
            cbEnvasado9.Text = tipo(respuestas[1, 8]);

            cbProduccion59.Text = tipo(respuestas[0, 9]);
            cbEnvasado59.Text = tipo(respuestas[1, 9]);

            cbProduccion10.Text = tipo(respuestas[0, 10]);
            cbEnvasado10.Text = tipo(respuestas[1, 10]);
            cbProduccion11.Text = tipo(respuestas[0, 11]);
            cbEnvasado11.Text = tipo(respuestas[1, 11]);
            cbAlmacen11.Text = tipo(respuestas[0, 11]);
            
            cbProduccion12.Text = tipo(respuestas[0, 12]);
            cbEnvasado12.Text = tipo(respuestas[1, 12]);
            cbAlmacen12.Text = tipo(respuestas[2, 12]);
            cbProduccion13.Text = tipo(respuestas[0, 13]);
            cbEnvasado13.Text = tipo(respuestas[1, 13]);
            cbAlmacen13.Text = tipo(respuestas[2, 13]);
            cbProduccion14.Text = tipo(respuestas[0, 14]);
            cbEnvasado14.Text = tipo(respuestas[1, 14]);
            cbProduccion15.Text = tipo(respuestas[0, 15]);
            cbEnvasado15.Text = tipo(respuestas[1, 15]);
            cbAlmacen15.Text = tipo(respuestas[2, 15]); 
            cbEnvasado16.Text = tipo(respuestas[1, 16]);
            cbAlmacen16.Text = tipo(respuestas[2, 16]);
            cbEnvasado17.Text = tipo(respuestas[1, 17]);
            cbAlmacen17.Text = tipo(respuestas[2, 17]);
            cbEnvasado18.Text = tipo(respuestas[1, 18]);
            cbProduccion19.Text = tipo(respuestas[0, 19]);
            cbEnvasado19.Text = tipo(respuestas[1, 19]);
            cbAlmacen19.Text = tipo(respuestas[2, 19]);
            cbProduccion20.Text = tipo(respuestas[0, 20]);
            cbEnvasado20.Text = tipo(respuestas[1, 20]);
            cbProduccion21.Text = tipo(respuestas[0, 21]);
            cbEnvasado21.Text = tipo(respuestas[1, 21]);
            cbProduccion22.Text = tipo(respuestas[0, 22]);
            cbEnvasado22.Text = tipo(respuestas[1, 22]);

            cbProduccion23.Text = tipo(respuestas[0, 23]);
            cbEnvasado23.Text = tipo(respuestas[1, 23]);
            cbProduccion24.Text = tipo(respuestas[0, 24]);
            cbEnvasado24.Text = tipo(respuestas[1, 24]);
            cbProduccion25.Text = tipo(respuestas[0, 25]);
            cbEnvasado25.Text = tipo(respuestas[1, 25]);
            cbEnvasado26.Text = tipo(respuestas[1, 26]);
            cbEnvasado27.Text = tipo(respuestas[1, 27]);
            cbEnvasado28.Text = tipo(respuestas[1, 28]);
            cbEnvasado29.Text = tipo(respuestas[1, 29]);
            cbEnvasado30.Text = tipo(respuestas[1, 30]);
            cbEnvasado31.Text = tipo(respuestas[1, 31]);
            cbEnvasado32.Text = tipo(respuestas[1, 32]);
            cbProduccion33.Text = tipo(respuestas[0, 33]);
            cbEnvasado33.Text = tipo(respuestas[1, 33]);
            cbProduccion34.Text = tipo(respuestas[0, 34]);
            cbEnvasado34.Text = tipo(respuestas[1, 34]);

            cbProduccion35.Text = tipo(respuestas[0, 35]);
            cbEnvasado35.Text = tipo(respuestas[1, 35]);
            cbProduccion36.Text = tipo(respuestas[0, 36]);
            cbEnvasado36.Text = tipo(respuestas[1, 36]);
            cbProduccion37.Text = tipo(respuestas[0, 37]);
            cbEnvasado37.Text = tipo(respuestas[1, 37]);
            cbProduccion38.Text = tipo(respuestas[0, 38]);
            cbEnvasado38.Text = tipo(respuestas[1, 38]);
            cbProduccion39.Text = tipo(respuestas[0, 39]);
            cbEnvasado39.Text = tipo(respuestas[1, 39]);
            cbProduccion40.Text = tipo(respuestas[0, 40]);
            cbEnvasado40.Text = tipo(respuestas[1, 40]);
            cbAlmacen40.Text = tipo(respuestas[2, 40]);
            cbProduccion41.Text = tipo(respuestas[0, 41]);
            cbEnvasado41.Text = tipo(respuestas[1, 41]);
            cbAlmacen41.Text = tipo(respuestas[2, 41]);
            cbProduccion42.Text = tipo(respuestas[0, 42]);
            cbEnvasado42.Text = tipo(respuestas[1, 42]);
            cbAlmacen42.Text = tipo(respuestas[2, 42]);
            cbProduccion43.Text = tipo(respuestas[0, 43]);
            cbEnvasado43.Text = tipo(respuestas[1, 43]);
            cbAlmacen43.Text = tipo(respuestas[2, 43]);
            cbProduccion44.Text = tipo(respuestas[0, 44]);
            cbEnvasado44.Text = tipo(respuestas[1, 44]);
            cbAlmacen44.Text = tipo(respuestas[2, 44]);
            cbProduccion45.Text = tipo(respuestas[0, 45]);
            cbEnvasado45.Text = tipo(respuestas[1, 45]);
            cbAlmacen45.Text = tipo(respuestas[2, 45]);
            cbProduccion46.Text = tipo(respuestas[0, 46]);
            cbEnvasado46.Text = tipo(respuestas[1, 46]);
            cbAlmacen46.Text = tipo(respuestas[2, 46]);

            cbProduccion47.Text = tipo(respuestas[0, 47]);
            cbEnvasado47.Text = tipo(respuestas[1, 47]);
            cbAlmacen47.Text = tipo(respuestas[2, 47]);
            cbProduccion48.Text = tipo(respuestas[0, 48]);
            cbEnvasado48.Text = tipo(respuestas[1, 48]);
            cbProduccion49.Text = tipo(respuestas[0, 49]);
            cbEnvasado49.Text = tipo(respuestas[1, 49]);
            cbAlmacen49.Text = tipo(respuestas[2, 49]);
            cbProduccion50.Text = tipo(respuestas[0, 50]);
            cbEnvasado50.Text = tipo(respuestas[1, 49]);;
            cbProduccion51.Text = tipo(respuestas[0, 51]);
            cbEnvasado51.Text = tipo(respuestas[1, 51]);
            cbProduccion52.Text = tipo(respuestas[0, 52]);
            cbEnvasado52.Text = tipo(respuestas[1, 52]);
            cbProduccion53.Text = tipo(respuestas[0, 53]);
            cbEnvasado53.Text = tipo(respuestas[1, 53]);
            cbAlmacen53.Text = tipo(respuestas[2, 53]);
            cbProduccion54.Text = tipo(respuestas[0, 54]);
            cbEnvasado54.Text = tipo(respuestas[1, 54]);
            cbAlmacen54.Text = tipo(respuestas[2, 54]);
            cbProduccion55.Text = tipo(respuestas[0, 55]);
            cbEnvasado55.Text = tipo(respuestas[1, 55]);
            cbAlmacen55.Text = tipo(respuestas[2, 55]);
            cbProduccion56.Text = tipo(respuestas[0, 56]);
            cbEnvasado56.Text = tipo(respuestas[1, 56]);
            cbAlmacen56.Text = tipo(respuestas[2, 56]);
            cbProduccion57.Text = tipo(respuestas[0, 57]);
            cbEnvasado57.Text = tipo(respuestas[1, 57]);
            cbAlmacen57.Text = tipo(respuestas[2, 57]);
            cbProduccion58.Text = tipo(respuestas[0, 58]);
            cbEnvasado58.Text = tipo(respuestas[1, 58]);
            cbAlmacen58.Text = tipo(respuestas[2, 58]);


        }

        private void mostrar_guardados()
        {
            try
            {
                String id_bp  = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String parte1 = ConexionMysql.regresaCampoConsulta("Select parte1 FROM sinca.`di_datos_buenas_practicas` WHERE id='" + id_bp + "'");
                String parte2 = ConexionMysql.regresaCampoConsulta("Select parte2 FROM sinca.`di_datos_buenas_practicas` WHERE id='" + id_bp + "'");
                String parte3 = ConexionMysql.regresaCampoConsulta("Select parte3 FROM sinca.`di_datos_buenas_practicas` WHERE id='" + id_bp + "'");
                String parte4 = ConexionMysql.regresaCampoConsulta("Select parte4 FROM sinca.`di_datos_buenas_practicas` WHERE id='" + id_bp + "'");
                String parte5 = ConexionMysql.regresaCampoConsulta("Select parte5 FROM sinca.`di_datos_buenas_practicas` WHERE id='" + id_bp + "'");
                if (parte1 == "0")
                {
                    pbParte1.Hide();
                }
                if (parte2 == "0")
                {
                    pbParte2.Hide();
                }
                if (parte3 == "0")
                {
                    pbParte3.Hide();
                }
                if (parte4 == "0")
                {
                    pbParte4.Hide();
                }
                if (parte5 == "0")
                {
                    pbParte5.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_generales()
        {
            try
            {
                //ConexionMysql.llenaCombo(ref cbInspector, "SELECT nombre FROM verificadores WHERE id_us='" + Usuario.IdUsuario + "' AND status<>0", "nombre", "nombre");

                //Cargar datos
                DataSet Datos = new DataSet();

                if (id_solicitud == "" || id_solicitud == null || id_solicitud == "0")
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado, id_bp,no_acta, bp.`produccion`, bp.`envasado`, bp.`almacen`, bp.`observaciones_inspector`, bp.`observaciones_responsable`,tipo_registro,envasa_bebidas,mezcal,bebidas_con,acepta_evaluacion,s.id_informe,di.`informeP`, di.`InformeE`, di.`InformeA`, di.`actaP`, di.`actaE`, di.`actaA`,s.no_control,calle,colonia,noexterior,estado,municipio,cp,pais,s.rfc,s.telefonos,s.correos, hora_bp,DATE_FORMAT(fecha_bp, '%d/%m/%Y') as fecha_bp,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,di.id as id_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta LEFT JOIN sinca.di_datos_informe di ON di.id=s.id_informe LEFT JOIN sinca.di_datos_buenas_practicas bp ON bp.id=s.id_bp  WHERE s.id='" + di_solicitud + "' LIMIT 1");
                }
                else
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado,id_bp,no_acta, bp.`produccion`, bp.`envasado`, bp.`almacen`, bp.`observaciones_inspector`, bp.`observaciones_responsable`,tipo_registro,envasa_bebidas,mezcal,bebidas_con,acepta_evaluacion,s.id_informe,di.`informeP`, di.`InformeE`, di.`InformeA`, di.`actaP`, di.`actaE`, di.`actaA`,s.no_control,calle,colonia,noexterior,estado,municipio,cp,pais,s.rfc,s.telefonos,s.correos, hora_bp,DATE_FORMAT(fecha_bp, '%d/%m/%Y') as fecha_bp,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,di.id as id_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta LEFT JOIN sinca.di_datos_informe di ON di.id=s.id_informe LEFT JOIN sinca.di_datos_buenas_practicas bp ON bp.id=s.id_bp  WHERE s.id_solicitud='" + id_solicitud + "' LIMIT 1");
                }

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        di_solicitud = Convert.ToInt32(row["id"]);
                        bp_id = Convert.ToInt32(row["id_bp"]);

                        try
                        {
                            string fecha = Convert.ToString(row["fecha_bp"]);
                            string hora = Convert.ToString(row["hora_bp"]);
                            dtpFecha.Value = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            dtpHora.Value = DateTime.ParseExact(hora, "HH:mm:ss", CultureInfo.InvariantCulture);
                            guardado = 1;
                        }
                        catch
                        {                       
                            dtpFecha.Value = DateTime.Now;
                            dtpHora.Value = DateTime.Now;
                        }

                        txtRazonSocial.Text = Convert.ToString(row["razon_social"]);
                        txtEscrito.Text = Convert.ToString(row["no_escrito_comision"]);
                        txtTestigo1.Text = Convert.ToString(row["testigo1"]);
                        txtTestigo2.Text = Convert.ToString(row["testigo2"]);
                        txtInforme.Text = Convert.ToString(row["no_informe"]);

                        txtObservacionesInspector.Text = Convert.ToString(row["observaciones_inspector"]);
                        txtObservacionesResponsable.Text = Convert.ToString(row["observaciones_responsable"]);
                        txtActa.Text = Convert.ToString(row["no_acta"]);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

                if (ConexionMysql.insUpd_transaccion("DELETE FROM sinca.`di_bp_respuestas` WHERE `id_enunciado` BETWEEN 1 AND 12 AND  id_bp='" + id_bp + "'") == "Error")
                {
                    return;
                }
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_bp_respuestas`(`id_bp`, `id_enunciado`, `produccion`, `envasado`, `almacen`) " +
                    "VALUES ('" + id_bp + "','" + 1 + "','" + num(cbProduccion1.Text) + "','" + num(cbEnvasado1.Text) + "','" + num(cbAlmacen1.Text) + "')," +
                    "('" + id_bp + "','" + 2 + "','0','" + num(cbEnvasado2.Text) + "','0')," +
                    "('" + id_bp + "','" + 3 + "','0','" + num(cbEnvasado3.Text) + "','0')," +
                    "('" + id_bp + "','" + 4 + "','" + num(cbProduccion4.Text) + "','" + num(cbEnvasado4.Text) + "','0')," +
                    "('" + id_bp + "','" + 5 + "','" + num(cbProduccion5.Text) + "','" + num(cbEnvasado5.Text) + "','" + num(cbAlmacen5.Text) + "')," +
                    "('" + id_bp + "','" + 6 + "','" + num(cbProduccion6.Text) + "','" + num(cbEnvasado6.Text) + "','0')," +
                    "('" + id_bp + "','" + 7 + "','" + num(cbProduccion7.Text) + "','" + num(cbEnvasado7.Text) + "','0')," +
                    "('" + id_bp + "','" + 8 + "','" + num(cbProduccion8.Text) + "','" + num(cbEnvasado8.Text) + "','0')," +
                    "('" + id_bp + "','" + 9 + "','" + num(cbProduccion9.Text) + "','" + num(cbEnvasado9.Text) + "','0')," +
                    "('" + id_bp + "','" + 10 + "','" + num(cbProduccion59.Text) + "','" + num(cbEnvasado59.Text) + "','0')," +
                    "('" + id_bp + "','" + 11 + "','" + num(cbProduccion10.Text) + "','" + num(cbEnvasado10.Text) + "','0')," +
                    "('" + id_bp + "','" + 12 + "','" + num(cbProduccion11.Text) + "','" + num(cbEnvasado11.Text) + "','" + num(cbAlmacen11.Text) + "')") == "Error")
                   {
                      return;
                   }
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_buenas_practicas SET parte1='1' Where id='" + id_bp + "'") == "Error")
                  {
                     return;
                  }
                pbParte1.Show();

                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrar_respuestas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int num(string respuesta)
        {
            int num = 0;
            switch (respuesta.Trim())
            {
                case "Cumple Preferentemente":
                    num = 2;
                    break;
                case "Cumple":
                    num = 1;
                    break;
                case "No cumple":
                    num = 0;
                    break;
                case "No aplica":
                    num = 3;
                    break;
                default:
                    num = 0;
                    break;

            }

           // Console.WriteLine(num + " " + respuesta);

            return num;
        }
        private String tipo(string respuesta)
        {
            String num = "";

            switch (respuesta)
            {
                case "2":
                    num = "Cumple Preferentemente";
                    break;
                case "1":
                    num = "Cumple";
                    break;
                case "0":
                    num = "No cumple";
                    break;

            }

            //Console.WriteLine(num + " " + respuesta);

            return num;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

                if (ConexionMysql.insUpd_transaccion("DELETE FROM sinca.`di_bp_respuestas` WHERE `id_enunciado` BETWEEN 13 AND 24 AND  id_bp='" + id_bp + "'") == "Error")
                {
                    return;
                }
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_bp_respuestas`(`id_bp`, `id_enunciado`, `produccion`, `envasado`, `almacen`) " +
                    "VALUES ('" + id_bp + "','" + 13 + "','" + num(cbProduccion12.Text) + "','" + num(cbEnvasado12.Text) + "','" + num(cbAlmacen12.Text) + "')," +
                    "('" + id_bp + "','" + 14 + "','" + num(cbProduccion13.Text) + "','" + num(cbEnvasado13.Text) + "','" + num(cbAlmacen13.Text) + "')," +
                    "('" + id_bp + "','" + 15 + "','" + num(cbProduccion14.Text) + "','" + num(cbEnvasado14.Text) + "','')," +
                    "('" + id_bp + "','" + 16 + "','" + num(cbProduccion15.Text) + "','" + num(cbEnvasado15.Text) + "','" + num(cbAlmacen15.Text) + "')," +
                    "('" + id_bp + "','" + 17 + "','','" + num(cbEnvasado16.Text) + "','" + num(cbAlmacen16.Text) + "')," +
                    "('" + id_bp + "','" + 18 + "','','" + num(cbEnvasado17.Text) + "','" + num(cbAlmacen17.Text) + "')," +
                    "('" + id_bp + "','" + 19 + "','','" + num(cbEnvasado18.Text) + "','')," +
                    "('" + id_bp + "','" + 20 + "','" + num(cbProduccion19.Text) + "','" + num(cbEnvasado19.Text) + "','" + num(cbAlmacen19.Text) + "')," +
                    "('" + id_bp + "','" + 21 + "','" + num(cbProduccion20.Text) + "','" + num(cbEnvasado20.Text) + "','')," +
                    "('" + id_bp + "','" + 22 + "','" + num(cbProduccion21.Text) + "','" + num(cbEnvasado21.Text) + "','')," +
                    "('" + id_bp + "','" + 23 + "','" + num(cbProduccion22.Text) + "','" + num(cbEnvasado22.Text) + "','')," +
                    "('" + id_bp + "','" + 24 + "','" + num(cbProduccion23.Text) + "','" + num(cbEnvasado23.Text) + "','')") == "Error")
                {
                    return;
                }
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_buenas_practicas SET parte2='1' Where id='" + id_bp + "'") == "Error")
                {
                    return;
                }
                pbParte2.Show();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrar_respuestas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

            if (ConexionMysql.insUpd_transaccion("DELETE FROM sinca.`di_bp_respuestas` WHERE `id_enunciado` BETWEEN 25 AND 35 AND  id_bp='" + id_bp + "'") == "Error")
            {
                return;
            }
            if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_bp_respuestas`(`id_bp`, `id_enunciado`, `produccion`, `envasado`, `almacen`) " +
                "VALUES ('" + id_bp + "','" + 25 + "','" + num(cbProduccion24.Text) + "','" + num(cbEnvasado24.Text) + "','')," +
                "('" + id_bp + "','" + 26 + "','" + num(cbProduccion25.Text) + "','" + num(cbEnvasado25.Text) + "','')," +
                "('" + id_bp + "','" + 27 + "','','" + num(cbEnvasado26.Text) + "','')," +
                "('" + id_bp + "','" + 28 + "','','" + num(cbEnvasado27.Text) + "','')," +
                "('" + id_bp + "','" + 29 + "','','" + num(cbEnvasado28.Text) + "','')," +
                "('" + id_bp + "','" + 30 + "','','" + num(cbEnvasado29.Text) + "','')," +
                "('" + id_bp + "','" + 31 + "','','" + num(cbEnvasado30.Text) + "','')," +
                "('" + id_bp + "','" + 32 + "','','" + num(cbEnvasado31.Text) + "','')," +
                "('" + id_bp + "','" + 33 + "','','" + num(cbEnvasado32.Text) + "','')," +
                "('" + id_bp + "','" + 34 + "','" + num(cbProduccion33.Text) + "','" + num(cbEnvasado33.Text) + "','')," +
                "('" + id_bp + "','" + 35 + "','" + num(cbProduccion34.Text) + "','" + num(cbEnvasado34.Text) + "','')") == "Error")
            {
                return;
            }
            if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_buenas_practicas SET parte3='1' Where id='" + id_bp + "'") == "Error")
            {
                return;
            }
            pbParte3.Show();


            ConexionMysql.transCompleta();
            MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mostrar_respuestas();
        }

        private void tabParte3_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_Label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
            if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_buenas_practicas SET resultado='1', observaciones_inspector='" + txtObservacionesInspector.Text + "' , observaciones_responsable = '" + txtObservacionesResponsable.Text + "' Where id='" + id_bp + "'") == "Error")
            {
                return;
            }
            ConexionMysql.transCompleta();
            MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pbResultado.Show();
        }

        private void pbResultado_Click(object sender, EventArgs e)
        {

        }

        private void cbProduccion11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

            if (ConexionMysql.insUpd_transaccion("DELETE FROM sinca.`di_bp_respuestas` WHERE `id_enunciado` BETWEEN 36 AND 48 AND  id_bp='" + id_bp + "'") == "Error")
            {
                return;
            }
            if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_bp_respuestas`(`id_bp`, `id_enunciado`, `produccion`, `envasado`, `almacen`) " +
                "VALUES ('" + id_bp + "','" + 36 + "','" + num(cbProduccion35.Text) + "','" + num(cbEnvasado35.Text) + "','')," +
                "('" + id_bp + "','" + 37 + "','" + num(cbProduccion36.Text) + "','" + num(cbEnvasado36.Text) + "','')," +
                "('" + id_bp + "','" + 38 + "','" + num(cbProduccion37.Text) + "','" + num(cbEnvasado37.Text) + "','')," +
                "('" + id_bp + "','" + 39 + "','" + num(cbProduccion38.Text) + "','" + num(cbEnvasado38.Text) + "','')," +
                "('" + id_bp + "','" + 40 + "','" + num(cbProduccion39.Text) + "','" + num(cbEnvasado39.Text) + "','')," +
                "('" + id_bp + "','" + 41 + "','" + num(cbProduccion40.Text) + "','" + num(cbEnvasado40.Text) + "','" + num(cbAlmacen40.Text) + "')," +
                "('" + id_bp + "','" + 42 + "','" + num(cbProduccion41.Text) + "','" + num(cbEnvasado41.Text) + "','" + num(cbAlmacen41.Text) + "')," +
                "('" + id_bp + "','" + 43 + "','" + num(cbProduccion42.Text) + "','" + num(cbEnvasado42.Text) + "','" + num(cbAlmacen42.Text) + "')," +
                "('" + id_bp + "','" + 44 + "','" + num(cbProduccion43.Text) + "','" + num(cbEnvasado43.Text) + "','" + num(cbAlmacen43.Text) + "')," +
                "('" + id_bp + "','" + 45 + "','" + num(cbProduccion44.Text) + "','" + num(cbEnvasado44.Text) + "','" + num(cbAlmacen44.Text) + "')," +
                "('" + id_bp + "','" + 46 + "','" + num(cbProduccion45.Text) + "','" + num(cbEnvasado45.Text) + "','" + num(cbAlmacen45.Text) + "')," +
                "('" + id_bp + "','" + 47 + "','" + num(cbProduccion46.Text) + "','" + num(cbEnvasado46.Text) + "','" + num(cbAlmacen46.Text) + "')," +
                "('" + id_bp + "','" + 48 + "','" + num(cbProduccion47.Text) + "','" + num(cbEnvasado47.Text) + "','" + num(cbAlmacen47.Text) + "')") == "Error")
            {
                return;
            }
            if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_buenas_practicas SET parte4='1' Where id='" + id_bp + "'") == "Error")
            {
                return;
            }
            pbParte4.Show();


            ConexionMysql.transCompleta();
            MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            mostrar_respuestas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

            if (ConexionMysql.insUpd_transaccion("DELETE FROM sinca.`di_bp_respuestas` WHERE `id_enunciado` BETWEEN 49 AND 59 AND  id_bp='" + id_bp + "'") == "Error")
            {
                return;
            }
            if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_bp_respuestas`(`id_bp`, `id_enunciado`, `produccion`, `envasado`, `almacen`) " +
                "VALUES ('" + id_bp + "','" + 49 + "','" + num(cbProduccion48.Text) + "','" + num(cbEnvasado48.Text) + "','')," +
                "('" + id_bp + "','" + 50 + "','" + num(cbProduccion49.Text) + "','" + num(cbEnvasado49.Text) + "','" + num(cbAlmacen49.Text) + "')," +
                "('" + id_bp + "','" + 51 + "','" + num(cbProduccion50.Text) + "','" + num(cbEnvasado50.Text) + "','')," +
                "('" + id_bp + "','" + 52 + "','" + num(cbProduccion51.Text) + "','" + num(cbEnvasado51.Text) + "','')," +
                "('" + id_bp + "','" + 53 + "','" + num(cbProduccion52.Text) + "','" + num(cbEnvasado52.Text) + "','')," +
                "('" + id_bp + "','" + 54 + "','" + num(cbProduccion53.Text) + "','" + num(cbEnvasado53.Text) + "','" + num(cbAlmacen53.Text) + "')," +
                "('" + id_bp + "','" + 55 + "','" + num(cbProduccion54.Text) + "','" + num(cbEnvasado54.Text) + "','" + num(cbAlmacen54.Text) + "')," +
                "('" + id_bp + "','" + 56 + "','" + num(cbProduccion55.Text) + "','" + num(cbEnvasado55.Text) + "','" + num(cbAlmacen55.Text) + "')," +
                "('" + id_bp + "','" + 57 + "','" + num(cbProduccion56.Text) + "','" + num(cbEnvasado56.Text) + "','" + num(cbAlmacen56.Text) + "')," +
                "('" + id_bp + "','" + 58 + "','" + num(cbProduccion57.Text) + "','" + num(cbEnvasado57.Text) + "','" + num(cbAlmacen57.Text) + "')," +
                "('" + id_bp + "','" + 59 + "','" + num(cbProduccion58.Text) + "','" + num(cbEnvasado58.Text) + "','" + num(cbAlmacen58.Text) + "')") == "Error")
            {
                return;
            }

            if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_buenas_practicas SET parte5='1' Where id='" + id_bp + "'") == "Error")
            {
                return;
            }
            pbParte5.Show();

            ConexionMysql.transCompleta();
            MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            mostrar_respuestas();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
            if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_buenas_practicas SET resultado='1', observaciones_inspector='" + txtObservacionesInspector.Text + "' , observaciones_responsable = '" + txtObservacionesResponsable.Text + "' Where id='" + id_bp + "'") == "Error")
            {
                return;
            }
            pbResultado.Show();*/
        }

       /* private void obtener_resultados()
        {
            String id_bp = ConexionMysql.regresaCampoConsulta("Select id_bp FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

            DataSet Datos2 = new DataSet();
            ConexionMysql.llenaDataset(ref Datos2, "SELECT `id_enunciado`, `produccion`, `envasado`, `almacen`, `fecha_modificación` FROM sinca.`di_bp_respuestas` WHERE `id_bp`='" + id_bp + "' ORDER BY id_enunciado ASC");
            int puntos_produccion = 0;
            int puntos_envasado = 0;
            int puntos_almacen = 0;
            foreach (DataRow row in Datos2.Tables[0].Rows)
            {

                try
                {
                    puntos_produccion += Convert.ToInt32(row["produccion"]);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                try
                {
                    puntos_envasado += Convert.ToInt32(row["envasado"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                try
                {
                    puntos_almacen += Convert.ToInt32(row["almacen"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            if (puntos_produccion == 94) {
				lblResultadoUP.Text = "INSTALACIÓN EN CUMPLIMIENTO PREFERENTE";
            }else if (puntos_produccion > 47 && puntos_produccion < 94) {
                lblResultadoUP.Text = "INSTALACIÓN EN CUMPLIMIENTO";
            }else
            {
                lblResultadoUP.Text = "INSTALACIÓN EN INCUMPLIMIENTO";
            }
            if (puntos_envasado == 118) {
                lblResultadoUE.Text = "INSTALACIÓN EN CUMPLIMIENTO PREFERENTE";
            }else if (puntos_envasado > 59 && puntos_envasado < 117) {
                lblResultadoUE.Text = "INSTALACIÓN EN CUMPLIMIENTO";
            }else
            {
                lblResultadoUE.Text = "INSTALACIÓN EN INCUMPLIMIENTO";
            }
            if (puntos_almacen == 48) {
				lblResultadoUA.Text = "INSTALACIÓN EN CUMPLIMIENTO PREFERENTE";
            }else if (puntos_almacen > 24 && puntos_almacen < 47) {
                lblResultadoUA.Text = "INSTALACIÓN EN CUMPLIMIENTO";
            }else
            {
                lblResultadoUA.Text = "INSTALACIÓN EN INCUMPLIMIENTO";
            }

            txtPuntajeProduccion.Text =puntos_produccion.ToString();
            txtPuntajeEnvasado.Text = puntos_envasado.ToString();
            txtPuntajeAlmacen.Text = puntos_almacen.ToString();

        }*/
    }
}
