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
using static System.Net.Mime.MediaTypeNames;
//using System.Windows.Controls.Primitives;
using Microsoft.Office.Interop.Excel;
//using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Xml.Linq;
using System.Globalization;
using Microsoft.VisualBasic;

namespace Crm.Inventario
{
    public partial class FrmActaDetallada : Form
    {
        public FrmActaDetallada()
        { 
            InitializeComponent();
        }
        public string no_cliente;
        public string id_solicitud;
        public int tipo_dictaminacion;
        public int di_solicitud;
        public String codigo;
        public string parcial;
        int guardado = 0;
        string titulo_verificador = "";
        string titulo_verificador_capacitacion = "";
        DataSet dtsDatosGranel;
        String no_acta = "",inst_produccion = "0",inst_envasado = "0", inst_almacen="0", inst_bebidas="0";
        
        private void FrmActaDetallada_Load(object sender, EventArgs e)
        {
            //txtGranel.Text = "DE CONFORMIDAD CON EL APARTADO 4.1. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EL MAGUEY O AGAVE UTILIZADO EN LA PRODUCCIÓN DE MEZCAL SE ENCUENTRA INSCRITO EN EL REGISTRO DE PREDIOS DE AMMA Y SE CUENTA CON LA GUÍA DE MAGUEY RESPECTIVA, POR LO QUE SE ENCUENTRA MADURO Y PROVIENE DE ENTIDADES FEDERATIVAS, MUNICIPIOS Y REGIONES QUE SEÑALA LA DECLARACIÓN GENERAL DE PROTECCIÓN A LA DENOMINACIÓN DE ORIGEN “MEZCAL”, EN VIGOR.\r\nDE CONFORMIDAD CON LOS APARTADOS 4.2., 4.3., 4.4. Y 4.5. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EL MEZCAL EN SUS DIFERENTES CATEGORÍAS Y CLASES SE ENCUENTRAN EN CUMPLIMIENTO.\r\nDE CONFORMIDAD CON EL APARTADO 8. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EN LA PRODUCCIÓN DE MEZCAL EL PRODUCTOR NO HA ADULTERADO EL PRODUCTO EN NINGUNA DE SUS ETAPAS DE ELABORACIÓN MANTENIENDO LA TRAZABILIDAD Y EL BALANCE DE LOS MATERIALES.";

            cargar_generales();
            //cargar_granel();
        }

        /*private void cargar_granel()
        {
            dtsDatosGranel = new DataSet();
            dtsDatosGranel.Tables.Add("GRANEL");
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("NO. TANQUE", Type.GetType("System.String"));
           // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("LOTE", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("ESPECIE AGAVE", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("NO. DE GUIA", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("NO. ANALISIS FISICOQUIMICO", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dgvGranel.DataSource = dtsDatosGranel.Tables["GRANEL"];
           // dgvGranel.Columns[1].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT  DATE_FORMAT( granel_entrada.fecha, '%d/%m/%Y') as fecha,   granel_entrada.no_cliente,maestro_fabrica.fabrica,maestro_fabrica.estado,    granel_entrada.no_lote,    comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  granel_tanques.tanque) as tanque,    granel_entrada.fq,     granel_entrada.clase,    granel_entrada.categoria,     granel_entrada.abocante,     granel_entrada.ingrediente,    granel_entrada.lts_entrada,   granel_entrada.grado_alcoholico_entrada,    granel_entrada.lts_existentes,      granel_entrada.grado_alcoholico_existente,    verificadores.nombre as verificador       FROM  granel_entrada            LEFT JOIN existenciaplanta ON  granel_entrada.id_planta=existenciaplanta.id_plantas            LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  granel_entrada.id_comun=comun2.id_comun             INNER JOIN  granel_tanques ON  granel_entrada.id_granel_entrada= granel_tanques.id_granel_entrada            inner join maestro_fabrica on granel_entrada.id_fabrica= maestro_fabrica.id_fabrica              LEFT JOIN                ( SELECT  granel_ensamble.id_granel_entrada,               granel_ensamble.litros,               granel_ensamble.agave_coccion_kg,              comun.nombre               FROM  granel_ensamble               INNER JOIN existenciaplanta ON  granel_ensamble.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc,  granel_ensamble.agave_coccion_kg desc) TABLA  ON  granel_entrada.id_granel_entrada=TABLA.id_granel_entrada                LEFT JOIN  (   SELECT  granel_ensamble.id_granel_entrada,comun.nombre FROM  granel_ensamble INNER JOIN comun ON  granel_ensamble.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc  ) TABLA2 ON  granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada                 inner join verificadores on  granel_entrada.id_verificador= verificadores.id_us    where    granel_entrada.no_cliente='C0002' AND granel_entrada.fq NOT IN ('---',' ---')  GROUP BY  granel_entrada.id order by no_cliente");
            DataRow fila;
            dtsDatosGranel.Tables["GRANEL"].Rows.Clear();

            foreach (DataRow row in Datos.Tables[0].Rows)
            {            

                fila = dtsDatosGranel.Tables["GRANEL"].NewRow();
                fila["NO. TANQUE"] = Convert.ToString(row["tanque"]);
                //fila["ID"] = Convert.ToString(row["id"]);
                fila["LOTE"] = Convert.ToString(row["no_lote"]);

                if (Convert.ToString(row["maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey"]);
                }
                else if (Convert.ToString(row["maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey_sin"]);
                }
                else if (Convert.ToString(row["ensamble_maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey"]);
                }
                else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                }
                fila["NO. DE GUIA"] = Convert.ToString(row["no_lote"]);
                fila["NO. ANALISIS FISICOQUIMICO"] = Convert.ToString(row["fq"]);
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["VOLUMEN"] = Convert.ToString(row["lts_existentes"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico_existente"]);
                dtsDatosGranel.Tables["GRANEL"].Rows.Add(fila);
            }
        }*/
         
        private void cargar_generales()
        {
            try
            {
                //ConexionMysql.llenaCombo(ref cbInspector, "SELECT nombre FROM verificadores WHERE id_us='" + Usuario.IdUsuario + "' AND status<>0", "nombre", "nombre");
                ConexionMysql.llenaCombo(ref cbInspector, "SELECT nombre FROM verificadores WHERE status<>0", "nombre", "nombre");
                ConexionMysql.llenaCombo(ref cbInspectorCapacitacion, "SELECT 'NINGUNO' as nombre UNION SELECT nombre FROM verificadores WHERE status<>0", "nombre", "nombre");
                ConexionMysql.llenaCombo(ref cbIdentificacion1, "SELECT tipo FROM sinca.tipoidentificacion", "tipo", "tipo");
                ConexionMysql.llenaCombo(ref cbIdentificacionTestigo2, "SELECT tipo FROM sinca.tipoidentificacion", "tipo", "tipo");
               
                //Cargar datos
                DataSet Datos = new DataSet();
                if (di_solicitud==0)
                {
                    if (id_solicitud=="" || id_solicitud==null || id_solicitud=="0")
                        {
                            ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado,areas,visita_de,tipo_registro,s.no_control,calle_ins,colonia_ins,num_ins,estado_ins,municipio_ins,cp_ins,pais,s.rfc,s.telefonos,s.correos, hora_apertura,DATE_FORMAT(fecha_apertura, '%d/%m/%Y') as fecha_apertura,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, visita_de,id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,no_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta WHERE s.id='" + di_solicitud + "' LIMIT 1");
                        }
                    else
                        {
                        String parcial = ConexionMysql.regresaCampoConsulta("Select parcial FROM sinca.sol_ocui WHERE id_solicitud='" + id_solicitud + "'");
                        if (parcial != "1")
                            {
                                ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado,areas,visita_de,tipo_registro,s.no_control,calle_ins,colonia_ins,num_ins,estado_ins,municipio_ins,cp_ins,pais,s.rfc,s.telefonos,s.correos, hora_apertura,DATE_FORMAT(fecha_apertura, '%d/%m/%Y') as fecha_apertura,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, visita_de,id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,no_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta WHERE s.id_solicitud='" + id_solicitud + "' LIMIT 1");
                            }
                            else
                            {
                            ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado,areas,tipo_registro,visita_de,s.no_control,calle_ins,colonia_ins,num_ins,estado_ins,municipio_ins,cp_ins,pais,s.rfc,s.telefonos,s.correos, hora_apertura,DATE_FORMAT(fecha_apertura, '%d/%m/%Y') as fecha_apertura,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, visita_de,id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,no_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta WHERE s.id='" + di_solicitud + "' LIMIT 1");
                        }                           
                        }
                }
                else
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado,areas,tipo_registro,visita_de,s.no_control,calle_ins,colonia_ins,num_ins,estado_ins,municipio_ins,cp_ins,pais,s.rfc,s.telefonos,s.correos, hora_apertura,DATE_FORMAT(fecha_apertura, '%d/%m/%Y') as fecha_apertura,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, visita_de,id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,no_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta WHERE s.id='" + di_solicitud + "' LIMIT 1");
                }
                

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        
                        di_solicitud = Convert.ToInt32(row["id"]);
                        String testigos = ConexionMysql.regresaCampoConsulta("Select testigos FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                        string fecha = Convert.ToString(row["fecha_apertura"]);
                        string hora = Convert.ToString(row["hora_apertura"]);
                        //Console.WriteLine(hora);
                        dtpFechaActa.Value = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        dtpHoraActa.Value = DateTime.ParseExact(hora, "HH:mm:ss", CultureInfo.InvariantCulture);
                        guardado = 1;
                        pbGuardado.Show();
                        pbGuardado2.Show();
                        no_acta = Convert.ToString(row["no_acta"]);

                        txtNoCredencial.Text = Convert.ToString(row["credencial_acreditado"]);
                        txtCredencialCapacitacion.Text = Convert.ToString(row["credencial_capacitacion"]);
                        txtRazonSocial.Text = Convert.ToString(row["razon_social"]);
                        txtNoEscrito.Text = Convert.ToString(row["no_escrito_comision"]);
                        txtResponsable.Text = Convert.ToString(row["responsable"]);
                        txtNoInforme.Text = Convert.ToString(row["no_informe"]);
                        cbDiligencia.Text = Convert.ToString(row["acepta_diligencia"]);
                        txtTestigo1.Text = Convert.ToString(row["testigo1"]);
                        txtNoIdentificacion1.Text = Convert.ToString(row["no_identificacion1"]);
                        cbIdentificacion1.SelectedValue = Convert.ToString(row["identificacion1"]);
                        txtEdad1.Text = Convert.ToString(row["edad1"]);
                        txtDomicilioTestigo1.Text = Convert.ToString(row["domicilio1"]);
                        txtTestigo2.Text = Convert.ToString(row["testigo2"]);
                        cbIdentificacionTestigo2.SelectedValue = Convert.ToString(row["identificacion2"]);
                        txtNoIdentificacion2.Text = Convert.ToString(row["no_identificacion2"]);
                        txtEdad2.Text = Convert.ToString(row["edad2"]);
                        txtDomicilio2.Text = Convert.ToString(row["domicilio2"]);
                        txtSolicitud.Text = Convert.ToString(row["solicitud"]);
                        cbVisitasPeriodicas.Text = Convert.ToString(row["acepta_visitas"]);
                        txtActividades.Text = Convert.ToString(row["actividades_de"]);
                        txtTexto.Text = Convert.ToString(row["texto"]);
                        cbVisitasDe.Text= Convert.ToString(row["visita_de"]);

                        cbInspectorCapacitacion.SelectedValue = Convert.ToString(row["inspector_capacitacion"]);
                        cbInspector.SelectedValue = Convert.ToString(row["inspector_acreditado"]);

                        txtRFC.Text = Convert.ToString(row["rfc"]);
                        txtNoControl.Text = Convert.ToString(row["no_control"]);

                        txtCalle.Text = Convert.ToString(row["calle_ins"]);
                        txtColonia.Text = Convert.ToString(row["colonia_ins"]);
                        txtNumero.Text = Convert.ToString(row["num_ins"]);
                        txtEstado.Text = Convert.ToString(row["estado_ins"]);
                        txtMunicipio.Text = Convert.ToString(row["municipio_ins"]);
                        txtCodPostal.Text = Convert.ToString(row["cp_ins"]);

                        txtSigAreas.Text = Convert.ToString(row["areas"]);

                        cbTipo.Text = Convert.ToString(row["tipo_registro"]);

                        if (testigos == null || testigos == "" || testigos == "0" || testigos == "NULL")
                        {
                            pbTestigos.Hide();
                        }
                        else
                        {
                            pbTestigos.Show();
                        }
                        

                    }
                }
                else
                {

                    dtpFechaActa.Value = DateTime.Now;
                    dtpHoraActa.Value = DateTime.Now;
                    pbGuardado.Hide();
                    pbGuardado2.Hide();

                    cbDiligencia.SelectedIndex = 0;
                    cbVisitasPeriodicas.SelectedIndex = 0;

                    txtTexto.Text = "EN LA APERTURA DEL ACTA NO SE ENCONTRÓ NINGUNA PERSONA QUIEN FUNGIERA COMO TESTIGO. \r\nSE LE OTORGA EL SIGUIENTE NÚMERO DE FOLIO PARA PRODUCTO A GRANEL DE LA UNIDAD DE PRODUCCIÓN Y/O ENVASADO:___________\r\nCADA ÁREA SE ENCUENTRA DELIMITADA Y CON SEÑALAMIENTOS CORRECTOS, ASÍ COMO TAMBIÉN SE OBSERVA QUE EL EQUIPO DE __________ SE ENCUENTRA EN BUENAS CONDICIONES Y LIMPIAS.\r\nSE OBSERVA QUE SU MATERIAL ES SUFICIENTE PARA ____________________ EL PRODUCTO.\r\nEL C. ____________________________________, AFIRMA QUE TIENE _______ AÑOS DE EXPERIENCIA EN EL ÁREA DE PRODUCCIÓN DE MEZCAL Y CUENTA CON LOS CONOCIMIENTOS PRÁCTICOS Y TEÓRICOS PARA REALIZAR EL TRABAJO.\r\nEN LA APERTURA DEL ACTA NO SE ENCONTRÓ PRODUCTO A GRANEL, ENVASADO, ENVASADO TERMINADO, O EN MADURACIÓN. \r\nDURANTE LA VISITA SE CONSTATÓ QUE LA EMPRESA SE ENCUENTRA PRODUCIENDO MEZCAL. \r\nDE ACUERDO A LA INFORMACIÓN RECABADA EN EL INFORME _________ PARA DICTAMEN DE INSTALACIONES CON NUMERO _______ SE DETERMINA QUE LA CATEGORÍA A PRODUCIR ES: ________________.\r\nDE ACUERDO A LA INFORMACIÓN RECABADA EN EL INFORME PARA DICTAMEN DE INSTALACIONES SE DETERMINA QUE LA EMPRESA TIENE LA CAPACIDAD DE PRODUCIR MÁS DE UNA CATEGORÍA LAS CUALES SON: ________________ Y ____________  PARA LO CUAL SE LE HACE SABER AL RESPONSABLE QUE DEBE CONTAR CON BITÁCORAS DE PRODUCCIÓN DIFERENCIADAS Y SISTEMAS QUE PERMITAN LA DISCRIMINACIÓN DE AMBOS PROCESOS, PUDIENDO SER; CALENDARIOS O PLANES DE TRABAJO, DIFERENCIAR EQUIPOS QUE PUDIERAN SER UTILIZADOS EN AMBOS PROCESOS O CUALQUIER OTRO SISTEMA QUE PERMITA DIFERENCIAR LAS PRODUCCIONES. \r\nDURANTE LA VISITA DE INSPECCIÓN, LA CONSTATACIÓN OCULAR Y A TRAVÉS DE LAS BITÁCORAS SE ENCONTRARON INCONSISTENCIAS EN EL CUMPLIMIENTO CON LOS REQUISITOS ESTABLECIDOS EN EL ESQUEMA DE EVALUACIÓN DE LA CONFORMIDAD DE LA NOM-MEZCAL, MISMAS QUE SE DESCRIBEN EN LA PRESENTE. \r\nDE ACUERDO A LA INFORMACIÓN RECABADA EN EL INFORME PARA DICTAMEN DE INSTALACIONES SE DETERMINA QUE LA EMPRESA TIENE LA CAPACIDAD DE ENVASAR: __MEZCAL______________ Y ___BEBIDAS QUE CONTIENEN MEZCAL_________  PARA LO CUAL SE LE HACE SABER AL RESPONSABLE QUE DEBE CONTAR CON BITÁCORAS DE ENVASADOS DIFERENCIADAS Y SISTEMAS QUE PERMITAN LA DISCRIMINACIÓN DE AMBOS PROCESOS, PUDIENDO SER; CALENDARIOS O PLANES DE TRABAJO, DIFERENCIAR EQUIPOS QUE PUDIERAN SER UTILIZADOS EN AMBOS PROCESOS O CUALQUIER OTRO SISTEMA QUE PERMITA DIFERENCIAR LOS ENVASADOS. ";
                    //txtGranel.Text = "DE CONFORMIDAD CON EL APARTADO 4.1. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EL MAGUEY O AGAVE UTILIZADO EN LA PRODUCCIÓN DE MEZCAL SE ENCUENTRA INSCRITO EN EL REGISTRO DE PREDIOS DE AMMA Y SE CUENTA CON LA GUÍA DE MAGUEY RESPECTIVA, POR LO QUE SE ENCUENTRA MADURO Y PROVIENE DE ENTIDADES FEDERATIVAS, MUNICIPIOS Y REGIONES QUE SEÑALA LA DECLARACIÓN GENERAL DE PROTECCIÓN A LA DENOMINACIÓN DE ORIGEN “MEZCAL”, EN VIGOR.\r\nDE CONFORMIDAD CON LOS APARTADOS 4.2., 4.3., 4.4. Y 4.5. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EL MEZCAL EN SUS DIFERENTES CATEGORÍAS Y CLASES SE ENCUENTRAN EN CUMPLIMIENTO.\r\nDE CONFORMIDAD CON EL APARTADO 8. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EN LA PRODUCCIÓN DE MEZCAL EL PRODUCTOR NO HA ADULTERADO EL PRODUCTO EN NINGUNA DE SUS ETAPAS DE ELABORACIÓN MANTENIENDO LA TRAZABILIDAD Y EL BALANCE DE LOS MATERIALES.";


                    //Cargar datos solicitud
                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  IF(`produccion`='S',1,0) as produccion, IF(`envasado`='S',1,0) as envasado, IF(`almacen` ='S',1,0) as almacen, IF(`comercializadorbcm`='S',1,0) as bebidas,IF(`comercializador`='S',1,0) as comercializador FROM sinca.`at_solicitudes_det_actividades` WHERE id_solicitud='" + id_solicitud + "' LIMIT 1");

                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        inst_produccion = Convert.ToString(row["produccion"]);
                        inst_envasado = Convert.ToString(row["envasado"]);
                        inst_almacen = (Convert.ToString(row["almacen"])=="1" || Convert.ToString(row["comercializador"])=="1")?"1":"0";
                        inst_bebidas = Convert.ToString(row["bebidas"]);

                    }

                    //Cargar datos solicitud
                    DataSet Datos5 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos5, "SELECT num_solicitud,razon_social,acta,verificador,verificador2, (SELECT count(id_solicitud) FROM sinca.`sol_ocui` so WHERE nombre_solicitud LIKE '%AMPLIACIÓN%' AND s.id_solicitud=so.id_solicitud) as tipo FROM sinca.sol_ocui s WHERE s.id_solicitud='" + id_solicitud + "' LIMIT 1");
                    foreach (DataRow row in Datos5.Tables[0].Rows)
                    {
                        txtSolicitud.Text = Convert.ToString(row["num_solicitud"]);
                        no_acta = Convert.ToString(row["acta"]);
                        if (Convert.ToString(row["verificador2"]) == "")
                        {
                            cbInspectorCapacitacion.SelectedValue = "NINGUNO";
                        }
                        else
                        {
                            cbInspectorCapacitacion.SelectedValue = Convert.ToString(row["verificador2"]);
                        }
                            
                        cbInspector.SelectedValue = Convert.ToString(row["verificador"]);

                        txtNoCredencial.Text = ConexionMysql.regresaCampoConsulta("Select credencial FROM verificadores WHERE nombre='" + Convert.ToString(row["verificador"]) + "'");
                        txtCredencialCapacitacion.Text = ConexionMysql.regresaCampoConsulta("Select credencial FROM verificadores WHERE nombre='" + Convert.ToString(row["verificador2"]) + "'");
                        titulo_verificador = ConexionMysql.regresaCampoConsulta("Select titulo FROM verificadores WHERE nombre='" + Convert.ToString(row["verificador"]) + "'");
                        titulo_verificador_capacitacion = ConexionMysql.regresaCampoConsulta("Select titulo FROM verificadores WHERE nombre='" + Convert.ToString(row["verificador2"]) + "'");

                        Console.WriteLine("Select credencial FROM verificadores WHERE nombre='" + Convert.ToString(row["verificador2"]) + "'");

                        if (inst_produccion=="1" && inst_envasado=="1" && inst_almacen=="1")
                        {
                            if (Convert.ToString(row["tipo"])=="1")
                            {
                                cbVisitasDe.Text=("Ampliación, Dictamen de Instalación y Seguimiento en la Producción, Envasado y Comercialización del Mezcal");
                            }
                            else
                            {
                                cbVisitasDe.Text = ("Dictamen de Instalación y Seguimiento en la Producción, Envasado y Comercialización del Mezcal");
                            }
                        }else if (inst_produccion == "0" && inst_envasado == "1" && inst_almacen == "1")
                        {
                            if (Convert.ToString(row["tipo"]) == "1")
                            {
                                cbVisitasDe.Text = ("Ampliación, Dictamen de Instalación y Seguimiento en el Envasado y Comercialización del Mezcal");
                            }
                            else
                            {
                                cbVisitasDe.Text = ("Dictamen de Instalación y Seguimiento en el Envasado y Comercialización del Mezcal");
                            }
                        }
                        else if (inst_produccion == "1" && inst_envasado == "0" && inst_almacen == "1")
                        {
                            if (Convert.ToString(row["tipo"]) == "1")
                            {
                                cbVisitasDe.Text = ("Ampliación, Dictamen de Instalación y Seguimiento en la Producción y Comercialización del Mezcal");
                            }
                            else
                            {
                                cbVisitasDe.Text = ("Dictamen de Instalación y Seguimiento en la Producción y Comercialización del Mezcal");
                            }
                        }
                        else if (inst_produccion == "1" && inst_envasado == "1" && inst_almacen == "0")
                        {
                            if (Convert.ToString(row["tipo"]) == "1")
                            {
                                cbVisitasDe.Text = ("Ampliación, Dictamen de Instalación y Seguimiento en la Producción y Envasado del Mezcal");
                            }
                            else
                            {
                                cbVisitasDe.Text = ("Dictamen de Instalación y Seguimiento en la Producción y Envasado del Mezcal");
                            }
                        }
                        else if (inst_produccion == "1" && inst_envasado == "0" && inst_almacen == "0")
                        {
                            if (Convert.ToString(row["tipo"]) == "1")
                            {
                                cbVisitasDe.Text = ("Ampliación, Dictamen de Instalación y Seguimiento en la Producción del Mezcal");
                            }
                            else
                            {
                                cbVisitasDe.Text = ("Dictamen de Instalación y Seguimiento en la Producción del Mezcal");
                            }
                        }
                        else if (inst_produccion == "0" && inst_envasado == "1" && inst_almacen == "0")
                        {
                            if (Convert.ToString(row["tipo"]) == "1")
                            {
                                cbVisitasDe.Text = ("Ampliación, Dictamen de Instalación y Seguimiento en el Envasado del Mezcal");
                            }
                            else
                            {
                                cbVisitasDe.Text = ("Dictamen de Instalación y Seguimiento en el Envasado del Mezcal");
                            }
                        }
                        else if (inst_produccion == "0" && inst_envasado == "0" && inst_almacen == "1")
                        {
                            if (Convert.ToString(row["tipo"]) == "1")
                            {
                                cbVisitasDe.Text = ("Ampliación, Dictamen de Instalación y Seguimiento en el Almacén de Producto Terminado del Mezcal");
                            }
                            else
                            {
                                cbVisitasDe.Text = ("Dictamen de Instalación y Seguimiento en el Almacén de Producto Terminado del Mezcal");
                            }
                        }


                    }

                    //Cargar datos cliente
                    DataSet Datos4 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos4, "SELECT `no_cliente`,`rfc`,`nombre`,tipo_persona,telefono,correo FROM `clientes` WHERE `no_cliente`='" + no_cliente + "' LIMIT 1");
                    foreach (DataRow row in Datos4.Tables[0].Rows)
                    {
                        txtRazonSocial.Text = Convert.ToString(row["nombre"]);
                        txtRFC.Text = Convert.ToString(row["rfc"]);
                        txtNoControl.Text = Convert.ToString(row["no_cliente"]);
                        if(Convert.ToString(row["tipo_persona"]) == "1")
                        {
                            cbTipo.SelectedIndex = 0;
                        }
                        else
                        {
                            cbTipo.SelectedIndex = 1;
                        }  
                    }

                    DataSet Datos3 = new DataSet();
                    //ConexionMysql.llenaDataset(ref Datos3, "SELECT d.calle, d.noexterior, d.nointerior, d.paraje, d.colonia, d.cp, m.nombre as municipio, e.nombre as estado FROM sinca.domicilio d LEFT JOIN municipios m ON m.id=d.municipio LEFT JOIN estados e ON e.clave=m.estado WHERE d.no_cliente='" + no_cliente + "'");
                    ConexionMysql.llenaDataset(ref Datos3, "SELECT i.id, `calle`, `noexterior`, `colonia`,cp FROM sinca.`at_solicitudes_instalaciones` si INNER JOIN sinca2.instalaciones i ON i.id=si.id_instalacion WHERE si.id_solicitud='" + id_solicitud + "'");

                    foreach (DataRow row in Datos3.Tables[0].Rows)
                    {
                        String municipio = ConexionMysql.regresaCampoConsulta("SELECT m.nombre FROM `instalaciones` i INNER JOIN clientes_instalaciones ci ON ci.instalacion=i.id INNER JOIN municipios m ON m.id = i.municipio INNER JOIN estados e ON e.clave=m.estado WHERE i.id='" + row["id"].ToString() + "'");
                        String estado = ConexionMysql.regresaCampoConsulta("SELECT e.nombre FROM `instalaciones` i INNER JOIN clientes_instalaciones ci ON ci.instalacion=i.id INNER JOIN municipios m ON m.id = i.municipio INNER JOIN estados e ON e.clave=m.estado WHERE i.id='" + row["id"].ToString() + "'");

                        txtCalle.Text = Convert.ToString(row["calle"]);
                        txtColonia.Text = Convert.ToString(row["colonia"]);
                        txtNumero.Text = Convert.ToString(row["noexterior"]);
                        txtEstado.Text = estado;
                        txtMunicipio.Text = municipio;
                        txtCodPostal.Text = Convert.ToString(row["cp"]);
                        //txtDomicilio.Text = Convert.ToString(row["calle"]) + ", " + Convert.ToString(row["noexterior"]) + ", " + Convert.ToString(row["colonia"]) + ", " + Convert.ToString(row["municipio"]) + ", " + Convert.ToString(row["estado"]) + ", C.P. " + Convert.ToString(row["cp"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    

        }

        private void txtActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                string fecha = dtpFechaActa.Value.ToString("yyyy-MM-dd");
                string fecha_escrito = dtpFecha_escrito.Value.ToString("yyyy-MM-dd");
                string hora = dtpHoraActa.Value.ToString("HH:mm");
                if (guardado == 1)
                {
                    String id_acta = ConexionMysql.regresaCampoConsulta("Select id_acta FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                    String testigos = ConexionMysql.regresaCampoConsulta("Select testigos FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                    //Console.WriteLine("UPDATE sinca.di_datos_acta SET acepta_diligencia='" + cbDiligencia.GetItemText(cbDiligencia.SelectedItem) + "', fecha_modificacion=NOW(), usuario='" + Usuario.IdUsuario + "' WHERE id='" + id_acta + "'");
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET acepta_diligencia='"+ cbDiligencia.GetItemText(cbDiligencia.SelectedItem) + "', fecha_modificacion=NOW(), usuario='"+ Usuario.IdUsuario + "' WHERE id='"+ id_acta+ "'") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET fecha_apertura='"+fecha+"', hora_apertura='"+hora+"', inspector_acreditado='"+ cbInspector.Text + "', credencial_acreditado='"+txtNoCredencial.Text+"', " +
                        "inspector_capacitacion='" + cbInspectorCapacitacion.Text + "', credencial_capacitacion='"+txtCredencialCapacitacion.Text+"', razon_social='"+txtRazonSocial.Text+"', no_escrito_comision='"+txtNoEscrito.Text+"', " +
                        "responsable='"+txtResponsable.Text+"', no_informe='"+txtNoInforme.Text+"', registro='"+ Usuario.IdUsuario + "',solicitud='" + txtSolicitud.Text + "',no_control='"+txtNoControl.Text+"',rfc='"+txtRFC.Text+"'," +
                        "calle_ins='"+txtCalle.Text+"',colonia_ins='"+txtColonia.Text+ "',fecha_escrito='" + fecha_escrito + "', num_ins='" + txtNumero.Text+"',estado_ins='"+txtEstado.Text+"',municipio_ins='"+txtMunicipio.Text+ "',localidad_ins='"+txtLocalidadIns.Text+"',cp_ins='" + txtCodPostal.Text+"',tipo_registro='"+ cbTipo.Text + "'" +
                        "Where id='" + di_solicitud + "'") == "Error")
                    {
                        return;
                    }
                  
                    pbTestigos.Show(); 
                                     
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    pbTestigos.Hide();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_datos_acta(acepta_diligencia, fecha_modificacion, usuario, texto) " +
                        "VALUES('" + cbDiligencia.GetItemText(cbDiligencia.SelectedItem) + "',NOW(),'"+ Usuario.IdUsuario + "','" + txtTexto.Text + "')") == "Error")
                    {
                        return;
                    }
                    String id_acta = ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();");

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_datos_buenas_practicas(usuario) VALUES('" + Usuario.IdUsuario + "')") == "Error")
                    {
                        return;
                    }
                    String id_bp = ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();");
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_solicitud(id_solicitud,solicitud, fecha_apertura, hora_apertura, id_acta,fecha_escrito," +
                        " inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, no_escrito_comision, " +
                        "responsable, no_informe, guardado, registro,rfc,no_control,tipo_dictaminacion,calle_ins,colonia_ins,num_ins,estado_ins,municipio_ins,cp_ins,id_bp,no_acta,productor,envasador,comercializador,bebidas_con,tipo_registro,status,codigo,titulo_inspector,titulo_capacitacion,localidad_ins) VALUES " +
                        "('" + id_solicitud + "','" + txtSolicitud.Text + "','" + fecha + "','" + hora + "','" + id_acta + "','" + fecha_escrito + "','" + cbInspector.Text + "','" + txtNoCredencial.Text + "'," +
                        "'" + cbInspectorCapacitacion.Text + "','" + txtCredencialCapacitacion.Text + "','" + txtRazonSocial.Text + "'," +
                        "'" + txtNoEscrito.Text + "','" + txtResponsable.Text + "','" + txtNoInforme.Text + "','1','" + "1" + "','" + txtRFC.Text + "','" + no_cliente + "','"+tipo_dictaminacion+"','"+txtCalle.Text+"','"+txtColonia.Text+"','"+txtNumero.Text+"','"+txtEstado.Text+"','"+txtMunicipio.Text+"','"+txtCodPostal.Text+"','"+id_bp+"','"+no_acta+"','"+inst_produccion+"','"+inst_envasado+"','"+inst_almacen+"','"+inst_bebidas+"','"+cbTipo.Text+"','1','"+codigo+"','"+titulo_verificador+"','"+titulo_verificador_capacitacion+"','"+txtLocalidadIns.Text+"')") == "Error")
                    {
                        return;
                    }

                    di_solicitud = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT i.id FROM sinca.`at_solicitudes_instalaciones` si " +
                        "INNER JOIN sinca2.instalaciones i ON i.id=si.id_instalacion WHERE si.id_solicitud='" + id_solicitud + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        //String municipio = ConexionMysql.regresaCampoConsulta("SELECT m.nombre FROM `instalaciones` i INNER JOIN clientes_instalaciones ci ON ci.instalacion=i.id INNER JOIN municipios m ON m.id = i.municipio INNER JOIN estados e ON e.clave=m.estado WHERE i.id='" + row["id"].ToString() + "'");
                        //String estado = ConexionMysql.regresaCampoConsulta("SELECT e.nombre FROM `instalaciones` i INNER JOIN clientes_instalaciones ci ON ci.instalacion=i.id INNER JOIN municipios m ON m.id = i.municipio INNER JOIN estados e ON e.clave=m.estado WHERE i.id='" + row["id"].ToString() + "'");
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_instalaciones`(`tipo`, `alias`, `calle`, `noexterior`, `nointerior`, `colonia`, " +
                            "`cp`, `referencia`, `telefono`, `correo`, `responsable`, `numero`, `latitud`, `longitud`, `granel`, `maduracion`, " +
                            "`producto_terminado`,rv_instalaciones, localidad) SELECT `tipo`, `alias`, '"+ txtCalle.Text + "', '"+txtNumero.Text+ "', `nointerior`, '"+ txtColonia.Text+"', '"+ txtCodPostal.Text+"', `referencia`, `telefono`, " +
                            "`correo`, `responsable`, `numero`, `latitud`, `longitud`, `granel`, `maduracion`," +
                            " `producto_terminado`,rv_instalaciones,'"+txtLocalidadIns.Text+"' FROM `instalaciones` WHERE id='" + row["id"].ToString() + "'") == "Error")
                        {
                            return;
                        }

                        int id_instalacion = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                        if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_solicitud_instalacion`(`instalacion`, `solicitud`)VALUES ('" + id_instalacion + "','" + di_solicitud + "')") == "Error")
                        {
                            return;
                        }
                         
                        if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_instalaciones SET `municipio`='" + txtMunicipio.Text + "',estado ='" + txtEstado.Text + "' WHERE id='" + id_instalacion + "'") == "Error")
                        {
                            return;
                        }

                    }

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_inf_fotos_produccion(id_solicitud) VALUES('" + di_solicitud + "')") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_inf_fotos_almacen(id_solicitud) VALUES('" + di_solicitud + "')") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_inf_fotos_envasado(id_solicitud) VALUES('" + di_solicitud + "')") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_inf_fotos_envasado_bc(id_solicitud) VALUES('" + di_solicitud + "')") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_inf_areas_comunes(id_solicitud) VALUES('" + di_solicitud + "')") == "Error")
                    {
                        return;
                    }

                    ConexionMysql.transCompleta();
                    guardado = 1;
                    pbGuardado.Show();

                    FrmInstalaciones formulario;
                    formulario = new FrmInstalaciones();
                    //formulario.ShowDialog();

                    //formulario.actualizar(Convert.ToString(di_solicitud));

                    MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String testigos = ConexionMysql.regresaCampoConsulta("Select testigos FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

                if (testigos == null || testigos == "" || testigos == "0" || testigos == "NULL")
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_testigos(testigo1, identificacion1, no_identificacion1, edad1, domicilio1," +
                                " testigo2, identificacion2, no_identificacion2, edad2, domicilio2, modifico, fecha_modificacion) VALUES " +
                              "('" + txtTestigo1.Text + "','" + cbIdentificacion1.Text + "','" + txtNoIdentificacion1.Text + "','" + txtEdad1.Text + "','" + txtDomicilioTestigo1.Text + "'," +
                              "'" + txtTestigo2.Text + "','" + cbIdentificacionTestigo2.Text + "','" + txtNoIdentificacion2.Text + "','" + txtEdad2.Text + "','" + txtDomicilio2.Text + "','" + Usuario.IdUsuario + "',NOW())") == "Error")
                    {
                        return;
                    }

                    String id_testigos = ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();");

                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET testigos='" + id_testigos + "' Where id='" + di_solicitud + "'") == "Error")
                    {
                        return;
                    }

                    pbTestigos.Show();
                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_testigos SET testigo1='" + txtTestigo1.Text + "', identificacion1='" + cbIdentificacion1.Text + "'," +
                               " no_identificacion1='" + txtNoIdentificacion1.Text + "', edad1='" + txtEdad1.Text + "', domicilio1='" + txtDomicilioTestigo1.Text + "', testigo2='" + txtTestigo2.Text + "', " +
                               "identificacion2='" + cbIdentificacionTestigo2.Text + "', no_identificacion2='" + txtNoIdentificacion2.Text + "', edad2='" + txtEdad2.Text + "', " +
                               "domicilio2='" + txtDomicilio2.Text + "', modifico='" + Usuario.IdUsuario + "', fecha_modificacion=NOW() Where id='" + testigos + "'") == "Error")
                    {
                        return;
                    }
                    pbTestigos.Show();
                }

                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_Label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmInstalaciones formulario;
            formulario = new FrmInstalaciones();

            formulario.actualizar("prueba");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGranel_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_Label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String id_acta = ConexionMysql.regresaCampoConsulta("Select id_acta FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                //Console.WriteLine("Select id_acta FROM sinca.`di_solicitud` WHERE id='" + id_solicitud + "'");
                //Console.WriteLine("UPDATE sinca.di_datos_acta SET acepta_visitas = '" + cbVisitas.Text + "', actividades_de = '" + txtActividades.Text + "', texto = '" + txtTexto.Text + "', usuario = '" + Usuario.IdUsuario + "', fecha_modificacion = NOW() WHERE id = '" + id_acta + "'");
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET areas='" + txtSigAreas.Text + "', acepta_visitas='" + cbVisitasPeriodicas.Text + "', actividades_de='" + txtActividades.Text + "', texto='" + txtTexto.Text + "', usuario='" + Usuario.IdUsuario + "', fecha_modificacion=NOW(), visita_de='"+cbVisitasDe.Text+"' WHERE id='" + id_acta + "'") == "Error")
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbGuardado2.Show();
                }
                ConexionMysql.transCompleta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizarComplementarios_Click(object sender, EventArgs e)
        {
            try
            {
                String id_acta = ConexionMysql.regresaCampoConsulta("Select id_acta FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                //Console.WriteLine("Select id_acta FROM sinca.`di_solicitud` WHERE id='" + id_solicitud + "'");
                //Console.WriteLine("UPDATE sinca.di_datos_acta SET acepta_visitas = '" + cbVisitas.Text + "', actividades_de = '" + txtActividades.Text + "', texto = '" + txtTexto.Text + "', usuario = '" + Usuario.IdUsuario + "', fecha_modificacion = NOW() WHERE id = '" + id_acta + "'");
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET acepta_visitas='" + cbVisitasPeriodicas.Text + "', actividades_de='" + txtActividades.Text + "', texto='" + txtTexto.Text + "', usuario='" + Usuario.IdUsuario + "', fecha_modificacion=NOW(), visita_de='" + cbVisitasDe.Text + "' WHERE id='" + id_acta + "'") == "Error")
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbGuardado2.Show();
                }
                ConexionMysql.transCompleta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbIdentificacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExpedida1.Text = ConexionMysql.regresaCampoConsulta("SELECT institucion FROM sinca.tipoidentificacion WHERE tipo='" + cbIdentificacion1.GetItemText(cbIdentificacion1.SelectedItem) + "'");
        }

        private void cbIdentificacionTestigo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExpedida2.Text = ConexionMysql.regresaCampoConsulta("SELECT institucion FROM sinca.tipoidentificacion WHERE tipo='" + cbIdentificacionTestigo2.GetItemText(cbIdentificacionTestigo2.SelectedItem) + "'");
        }

    }

}