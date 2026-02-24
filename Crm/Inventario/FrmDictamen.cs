using Crm.functions;
using Crm.Utilerias;
using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Security.Policy;

//using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
//using TextBox = System.Windows.Controls.TextBox;

namespace Crm.Inventario
{
    public partial class FrmDictamen : Form
    {
        public static FrmDictamen instance;
        String id_max_fabrica;
        string id_max_envasadora;
        string id_max_almacen;
        public PictureBox pMaestro, pRecepcion1, pRecepcion2, pCoccion1, pCoccion2, pMolienda1, pMolienda2, pFermentacion1, pFermentacion2, pDestilacion1, pDestilacion2, pAlmacen1, pAlmacen2, pExterior, pInterior, pMaduracion1, pMaduracion2;
        public PictureBox pProductoEGranel, pLavadoBotellas, pLlenado, pTaponado, pVistaInterior, pVistaExterior, pAlmacenE, pMarcas, pAlmacenInsumos, pOtrosE,pLineaE,pMaduracionE,pGranelE;
        public PictureBox pAlmacenB, pLavadoB,pLlenadoB, pTaponadoB, pEnvasadoB, pMarcasB, pAlSaborizantesB, pFormulacionB;
        public PictureBox pInteriorA, pExteriorA, pTerminado1, pTerminado2, pTerminado3, pTerminado4, pGranel1A, pGranel2A, pMaduracion1A, pMaduracion2A, pMaduracion3A, pMaduracion4A, pCarga1A, pCarga2A, pCarga3A, pCarga4A, pRecipientes1A , pRecipientes2A, pRecipientes3A, pRecipientes4A, pInfraestructura, pGramelA1, pGramelA2, pGramelA3, pGramelA4, pAlmacenA1, pAlmacenA2, pAlmacenA3, pAlmacenA4;
        public PictureBox pLaboratorio,pSanitarios,pEstacionamiento,pOficinas, pHerramientas, pCarga, pOtros1, pOtros2;
        public FrmDictamen()
        {
            InitializeComponent();
            CargarToolTips();
            instance = this;
            pLaboratorio = pbLaboratorioAD;
            pSanitarios = pbSanitariosAD;
            pEstacionamiento = pbEstacionamiento;
            pOficinas = pbOficinas;
            pHerramientas = pbHerramientas;
            pCarga = pbCargaAD;
            pOtros1 = pbOtros1AD;
            pOtros2 = pbOtros2AD;

            pMaestro = pbMaestro;
            pRecepcion1 = pbRecepcion1;
            pRecepcion2 = pbRecepcion2;
            pCoccion1 = pbCoccion1;
            pCoccion2 = pbCoccion2;
            pMolienda1 = pbMolienda1;
            pMolienda2 = pbMolienda2;
            pFermentacion1 = pbFermentacion1;
            pFermentacion2 = pbFermentacion2;
            pDestilacion1 = pbDestilacion1;
            pDestilacion2 = pbDestilacion2;
            pAlmacen1 = pbAlmacen1;
            pAlmacen2 = pbAlmacen2;
            pExterior = pbExterior_produccion;
            pInterior = pbInteriorProduccion;
            pMaduracion1 = pbMaduracion1Produccion;
            pMaduracion2 = pbMAduracion2Produccion;

            pProductoEGranel = pbEProductoGranel;
            pLavadoBotellas = pbLavadoBotellas;
            pLlenado = pbLlenado;
            pTaponado = pbTaponado;
            pVistaInterior = pbVistaInteriorE;
            pVistaExterior = pbVistaExteriorE;
            pAlmacenE = pbAlmacenPT;
            pMarcas = pbMarcas;
            pAlmacenInsumos = pbAlmacenInsumos;
            pOtrosE = pbOtrosE;
            pLineaE = pbLineaEnvasado;
            pMaduracionE = pbMaduracionE;
            pGranelE = pbAreaGranelE;

            pAlmacenB = pbAlmacenGranelB;
            pLavadoB = pbLavadoB;
            pLlenadoB = pbLlenadoB;
            pTaponadoB = pbTaponadoB;
            pEnvasadoB = pbEnvasadoB;
            pMarcasB = pbMarcasB;
            pAlSaborizantesB = pbSaborizantes;
            pFormulacionB = pbFormulacion;

            pTerminado3 = pbTerminado3FA;
            pTerminado4 = pbTerminado4FA;
            pTerminado1 = pbTerminado1FA;
            pTerminado2 = pbTerminado2FA;
            pMaduracion1A = pbMaduracion1FA;
            pMaduracion2A = pbMaduracion2FA;
            pMaduracion3A = pbMaduracion3FA;
            pMaduracion4A = pbMaduracion4FA;
            pCarga1A = pbCarga1FA;
            pCarga2A = pbCarga2FA;
            pCarga3A = pbCarga3FA;
            pCarga4A = pbCarga4FA;
            pRecipientes1A = pbRecipientes1FA;
            pRecipientes2A = pbRecipientes2FA;
            pRecipientes3A = pbRecipientes3FA;
            pRecipientes4A = pbRecipientes4FA;
            pInfraestructura = pbInfraestructuraA;
            pGramelA1 = pbGranelA1;
            pGramelA2 = pbGranelA2;
            pGramelA3 = pbGranelA3;
            pGramelA4 = pbGranelA4;
            pAlmacenA1 = pbAlmacenA1;
            pAlmacenA2 = pbAlmacenA2;
            pAlmacenA3 = pbAlmacenA3;
            pAlmacenA4 = pbAlmacenA4;
        }
        public string no_cliente;
        public string id_solicitud;
        public int tipo_dictaminacion;
        public int di_solicitud;
        public String codigo;
        int guardado = 0;
        int id_acta = 0;
        int id_informe = 0;
        int id_produccion = 0;
        int id_envasado = 0;
        int id_almacen = 0;

        //produccion
        int id_recepcion = 0;
        int id_coccion = 0;
        int id_molienda = 0;
        int id_fermentacion = 0;
        int id_destilacion = 0;
        int id_almacen_produccion = 0;

        //envasado
        int id_cumplimientos = 0;
        int id_nom070 = 0;
        int id_nmx = 0;
        int almacen_envasado = 0;
        int id_almacen_envasado = 0;
        int id_linea_envasado = 0;
        int id_linea_envasado_bc = 0;

        //almacen
        int id_infraestructura_almacen = 0;
        int id_mad_almacen=0;

        int tab_rep = 0;

        DataSet dtsDatosRecepcion;
        DataSet dtsDatCoccion;
        DataSet dtsDatMolienda;
        DataSet dtsDatFermentacion;
        DataSet dtsDatDestilacion;
        DataSet dtsAlmacenProduccion;
        DataSet dtsAlmacenEnvasado;
        DataSet dtsLineaEnvasado;
        DataSet dtsLineaEnvasadoBebidas;
        DataSet dtsAlmacen;
        DataSet dtsAlmacenMad;
        DataSet dtsEspecie;
        private void FrmDictamen_Load(object sender, EventArgs e)
        {
            try
                {
                if (di_solicitud == 0)
                {
                    di_solicitud =  int.Parse(ConexionMysql.regresaCampoConsulta("Select id FROM sinca.`di_solicitud` WHERE codigo='" + codigo + "'"));
                }
                id_solicitud = ConexionMysql.regresaCampoConsulta("Select id_solicitud FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                //MessageBox.Show(id_solicitud.ToString());
                cargar_generales();
                verificar_instalaciones();
                cargar_instalaciones();
                cargar_fotos_areas();
                ConexionMysql.conecta();
                AutoCompleteStringCollection ListaMunicipios = new AutoCompleteStringCollection();
                DataSet DatosMunicipios = new DataSet();
                ConexionMysql.llenaDataset(ref DatosMunicipios, "select nombre from municipios ");
                foreach (DataRow row in DatosMunicipios.Tables[0].Rows)
                {
                    ListaMunicipios.Add(row[0].ToString());
                }
                /*AutoCompleteStringCollection ListaPostal = new AutoCompleteStringCollection();
                DataSet DatosPostal = new DataSet();
                ConexionMysql.llenaDataset(ref DatosPostal, "select localidad from localidades ");
                foreach (DataRow row in DatosPostal.Tables[0].Rows)
                {
                    ListaPostal.Add(row[0].ToString());
                }*/
                AutoCompleteStringCollection ListaEstado = new AutoCompleteStringCollection();
                DataSet DatosEstados = new DataSet();
                ConexionMysql.llenaDataset(ref DatosEstados, "select nombre from estados ");
                foreach (DataRow row in DatosEstados.Tables[0].Rows)
                {
                    ListaEstado.Add(row[0].ToString());
                }
                /*AutoCompleteStringCollection ListaColonias = new AutoCompleteStringCollection();
                DataSet DatosColonias = new DataSet();
                ConexionMysql.llenaDataset(ref DatosColonias, "select localidad from localidades");
                foreach (DataRow row in DatosColonias.Tables[0].Rows)
                {
                    ListaColonias.Add(row[0].ToString());
                }*/

                /*txtCodpostalP.AutoCompleteCustomSource = ListaPostal;
                txtCodPE.AutoCompleteCustomSource = ListaPostal;
                txtCodPA.AutoCompleteCustomSource = ListaPostal;*/

                txtMunicipioP.AutoCompleteCustomSource = ListaMunicipios;
                txtMunicipioE.AutoCompleteCustomSource = ListaMunicipios;
                txtMunicipioA.AutoCompleteCustomSource = ListaMunicipios;

                txtEstadoP.AutoCompleteCustomSource = ListaEstado;
                txtEstadoE.AutoCompleteCustomSource = ListaEstado;
                txtEstadoA.AutoCompleteCustomSource = ListaEstado;

                /*txtColoniaP.AutoCompleteCustomSource = ListaColonias;
                txtColoniaE.AutoCompleteCustomSource = ListaColonias;
                txtColoniaA.AutoCompleteCustomSource = ListaColonias;*/
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargar_instalaciones()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT i.`id`, `tipo`, `alias`, `calle`, localidad ,`noexterior`, `nointerior`, `colonia`, `cp`, `referencia`, `telefono`, " +
                    "`fax`, `correo`, `responsable`, `numero`, `latitud`, `longitud`, `es_propiedad`, `es_notariado`, `status`, `granel`, `maduracion`, " +
                    "`producto_terminado`,i.paraje, i.municipio,i.estado,`tipo_prop`, `edad_maestro`, `escolaridad_mestro`, `telefono_maestro`, `correo_maestro`,maestro1,maestro2,rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si " +
                    "ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "'");
                foreach (DataRow row in Datos.Tables[0].Rows) {
                    /* estado = ConexionMysql.regresaCampoConsulta("SELECT e.nombre FROM `estados` e INNER JOIN municipios m ON m.estado=e.clave WHERE m.id = '" + Convert.ToString(row["municipio"]) + "'");
                    String municipio = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM `municipios` WHERE id = '" + Convert.ToString(row["municipio"]) + "'");*/
                    switch (row["tipo"].ToString())
                    {
                        case "1":
                            if (row["maduracion"].ToString() == "1") cbxMaduracionP.Checked = true;
                            txtAliasP.Text = Convert.ToString(row["alias"]);
                            txtNoExteriorP.Text = Convert.ToString(row["noexterior"]);
                            txtNoInteriorP.Text = Convert.ToString(row["nointerior"]);
                            txtCodpostalP.Text = Convert.ToString(row["cp"]);
                            txtCalleP.Text = Convert.ToString(row["calle"]);
                            txtParajeP.Text = Convert.ToString(row["paraje"]);
                            txtColoniaP.Text = Convert.ToString(row["colonia"]);
                            txtEstadoP.Text = Convert.ToString(row["estado"]);
                            txtMunicipioP.Text = Convert.ToString(row["municipio"]);
                            txtLocalidadP.Text = Convert.ToString(row["localidad"]);

                            /*txtEstadoP.Text = Convert.ToString(estado);
                            txtMunicipioP.Text = Convert.ToString(municipio);*/
                            txtReferenciasP.Text = Convert.ToString(row["referencia"]);
                            txtTelefonoP.Text = Convert.ToString(row["telefono"]);
                            txtCorreoP.Text = Convert.ToString(row["correo"]);
                            txtResponsableP.Text = Convert.ToString(row["responsable"]);
                            txtLatitudP.Text = Convert.ToString(row["latitud"]);
                            txtLongitudP.Text = Convert.ToString(row["longitud"]);
                            cbTipIns.Text = Convert.ToString(row["tipo_prop"]);
                            txtEdadMaestro.Text = Convert.ToString(row["edad_maestro"]);
                            txtMaestro1.Text = Convert.ToString(row["maestro1"]);
                            txtMaestro2.Text = Convert.ToString(row["maestro2"]);
                            //txtEscolaridadMaestro.Text = Convert.ToString(row["escolaridad_mestro"]);
                            txtTelefonoMaestro.Text = Convert.ToString(row["telefono_maestro"]);
                            //txtCorreoMaestro.Text = Convert.ToString(row["correo_maestro"]);
                            String folio= ConexionMysql.regresaCampoConsulta("SELECT `folio_unico_granel` FROM maestro_fabrica WHERE `id_fabrica`='" + row["rv_instalaciones"].ToString() + "'");
                            txtFolioUnico.Text = folio;
                            String maestro = ConexionMysql.regresaCampoConsulta("SELECT `n_maestro_mezcalero` FROM maestros_mezcaleros WHERE `id_fabrica`='" + row["rv_instalaciones"].ToString() + "'");
                            //Console.WriteLine(folio);
                            txtMaestro1.Text = maestro;
                            id_produccion = Convert.ToInt32(row["id"]);
                            if (row["rv_instalaciones"].ToString()=="")
                            {
                                pbProd.Hide();
                            }
                            else
                            {
                                pbProd.Show();
                            }
                            break;
                        case "2":
                            if (row["maduracion"].ToString() == "1") cbxMaduracionE.Checked = true;
                            txtAliasE.Text = Convert.ToString(row["alias"]);
                            txtExteriorE.Text = Convert.ToString(row["noexterior"]);
                            txtInteriorE.Text = Convert.ToString(row["nointerior"]);
                            txtCodPE.Text = Convert.ToString(row["cp"]);
                            txtCalleE.Text = Convert.ToString(row["calle"]);
                            txtParajeE.Text = Convert.ToString(row["paraje"]);
                            txtColoniaE.Text = Convert.ToString(row["colonia"]);
                            txtEstadoE.Text = Convert.ToString(row["estado"]);
                            txtMunicipioE.Text = Convert.ToString(row["municipio"]);
                            txtReferenciaE.Text = Convert.ToString(row["referencia"]);
                            txtTelefonoE.Text = Convert.ToString(row["telefono"]);
                            txtCorreoE.Text = Convert.ToString(row["correo"]);
                            txtResponsableE.Text = Convert.ToString(row["responsable"]);
                            txtLatitudE.Text = Convert.ToString(row["latitud"]);
                            txtLongitudE.Text = Convert.ToString(row["longitud"]);
                            txtEdadEnvasado.Text = Convert.ToString(row["edad_maestro"]);
                            id_envasado = Convert.ToInt32(row["id"]);
                            cbtipoEnv.Text = Convert.ToString(row["tipo_prop"]);
                            txtLocalidadE.Text = Convert.ToString(row["localidad"]);
                            txtFolioUnicoEnv.Text = ConexionMysql.regresaCampoConsulta("SELECT `folio_unico_granel` FROM envasadora_encargado WHERE `id_envasadora`='" + row["rv_instalaciones"].ToString() + "'");
                            //txtResponsableE.Text = ConexionMysql.regresaCampoConsulta("SELECT `folio_unico_granel` FROM envasadora_encargado WHERE `id_envasadora`='" + row["rv_instalaciones"].ToString() + "'");

                            if (row["rv_instalaciones"].ToString() == "")
                            {
                                pbEnvasado.Hide();
                            }
                            else
                            {
                                pbEnvasado.Show();
                            }
                            break;
                        case "3":
                            if (row["maduracion"].ToString() == "1") cbxMaduracionA.Checked = true;
                            if (row["granel"].ToString() == "1") cbxGranelA.Checked = true;
                            if (row["producto_terminado"].ToString() == "1") cbxTerminadoA.Checked = true;
                            txtAliasA.Text = Convert.ToString(row["alias"]);
                            txtExteriorA.Text = Convert.ToString(row["noexterior"]);
                            txtInteriorA.Text = Convert.ToString(row["nointerior"]);
                            txtCodPA.Text = Convert.ToString(row["cp"]);
                            txtCalleA.Text = Convert.ToString(row["calle"]);
                            txtParajeA.Text = Convert.ToString(row["paraje"]);
                            txtColoniaA.Text = Convert.ToString(row["colonia"]);
                            txtEstadoA.Text = Convert.ToString(row["estado"]);
                            txtMunicipioA.Text = Convert.ToString(row["municipio"]);
                            txtReferenciaA.Text = Convert.ToString(row["referencia"]);
                            txtTelefonoA.Text = Convert.ToString(row["telefono"]);
                            txtCorreoA.Text = Convert.ToString(row["correo"]);
                            txtResponsableA.Text = Convert.ToString(row["responsable"]);
                            txtLatitudA.Text = Convert.ToString(row["latitud"]);
                            txtLongitudA.Text = Convert.ToString(row["longitud"]);
                            id_almacen = Convert.ToInt32(row["id"]);
                            txtLocalidadA.Text = Convert.ToString(row["localidad"]);
                            cbTipoAlm.Text = Convert.ToString(row["tipo_prop"]);
                            txtEdadAlmacen.Text = Convert.ToString(row["edad_maestro"]);
                            break;
                        case "4":

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void verificar_instalaciones()
        {
            try
            {
                /*tabProduccion.Hide();
                tabEnvasado.Hide();
                tabUAlmacen.Hide();
                if (id_solicitud == "" || id_solicitud == null || id_solicitud == "0")
                {
                    tabProduccion.Show();
                    tabEnvasado.Show();
                    tabUAlmacen.Show();
                    MessageBox.Show("se muestran todos");
                }*/

                int fabrica = 0;
                int envasadora = 0;
                int almacen = 0;

                DataSet Datos = new DataSet();
                /*ConexionMysql.llenaDataset(ref Datos, "SELECT i.`id`, `tipo`, `alias`, `calle`, `noexterior`, `nointerior`, `colonia`, `cp`, `referencia`, `telefono`, " +
                    "`fax`, `correo`, `responsable`, `numero`, `latitud`, `longitud`, `es_propiedad`, `es_notariado`, `status`, `granel`, `maduracion`, " +
                    "`producto_terminado`,i.paraje, i.municipio,i.estado FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si " +
                    "ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "'");*/
                ConexionMysql.llenaDataset(ref Datos, "SELECT productor, envasador, comercializador FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                foreach (DataRow row in Datos.Tables[0].Rows)
                {
                    if (row["productor"].ToString() == "0" && row["envasador"].ToString() == "0" && row["comercializador"].ToString() == "0")
                    {
                        tabProduccion.Show();
                        tabEnvasado.Show();
                        tabUAlmacen.Show();
                    }
                    else
                    {
                        if (row["envasador"].ToString() == "0")
                        {
                            tabDictamen.TabPages.Remove(tabEnvasado);
                        }
                        else
                        {
                            tabEnvasado.Show();
                        }
                        if (row["comercializador"].ToString() == "0")
                        {
                            tabDictamen.TabPages.Remove(tabUAlmacen);
                        }
                        else
                        {
                            tabUAlmacen.Show();
                        }
                        if (row["productor"].ToString() == "0")
                        {
                            tabDictamen.TabPages.Remove(tabProduccion);
                        }
                        else
                        {
                            tabProduccion.Show();
                        }
                    }                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    ConexionMysql.llenaDataset(ref Datos, "SELECT s.cumple_produccion,s.id,guardado,tipo_registro,envasa_bebidas,cat_ancestral,cat_artesanal,cat_mezcal,mezcal,bebidas_con,acepta_evaluacion,s.id_informe,di.`informeP`, di.`InformeE`, di.`InformeA`, di.`actaP`, di.`actaE`, di.`actaA`,s.no_control,calle,colonia,noexterior,estado,municipio,cp,pais,s.rfc,s.telefonos,s.correos, hora_informe,DATE_FORMAT(fecha_informe, '%d/%m/%Y') as fecha_informe,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,di.id as id_acta,localidad FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta LEFT JOIN sinca.di_datos_informe di ON di.id=s.id_informe WHERE s.id='" + di_solicitud + "' LIMIT 1");
                }
                else
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT s.cumple_produccion,s.envasa_bebidas,cat_ancestral,cat_artesanal,cat_mezcal, s.id,guardado,tipo_registro,envasa_bebidas,mezcal,bebidas_con,acepta_evaluacion,s.id_informe,di.`informeP`, di.`InformeE`, di.`InformeA`, di.`actaP`, di.`actaE`, di.`actaA`,s.no_control,calle,colonia,noexterior,estado,municipio,cp,pais,s.rfc,s.telefonos,s.correos, hora_informe,DATE_FORMAT(fecha_informe, '%d/%m/%Y') as fecha_informe,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,di.id as id_acta,localidad FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta LEFT JOIN sinca.di_datos_informe di ON di.id=s.id_informe WHERE s.id_solicitud='" + id_solicitud + "' LIMIT 1");
                }

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        di_solicitud = Convert.ToInt32(row["id"]);
                        id_informe = Convert.ToInt32(row["id_informe"]);

                       if (id_informe == 0)
                        {
                            dtpFecha.Value = DateTime.Now;
                            dtpHora.Value = DateTime.Now;
                            pbGuardado.Hide();

                            DataSet Datos3 = new DataSet();
                            //Console.WriteLine("SELECT d.calle, d.noexterior, d.nointerior, d.paraje, d.colonia, d.cp, m.nombre as municipio, e.nombre as estado,d.id FROM sinca.domicilio d LEFT JOIN municipios m ON m.id=d.municipio LEFT JOIN estados e ON e.clave=m.estado WHERE d.no_cliente='" + no_cliente + "'");
                            ConexionMysql.llenaDataset(ref Datos3, "SELECT d.id, d.calle, d.noexterior, d.nointerior, d.paraje, d.colonia, d.cp, m.nombre as municipio, e.nombre as estado FROM sinca.domicilio d LEFT JOIN municipios m ON m.id=d.municipio LEFT JOIN estados e ON e.clave=m.estado WHERE d.no_cliente='" + no_cliente + "'");
                           // Console.WriteLine("SELECT d.id, d.calle, d.noexterior, d.nointerior, d.paraje, d.colonia, d.cp, m.nombre as municipio, e.nombre as estado FROM sinca.domicilio d LEFT JOIN municipios m ON m.id = d.municipio LEFT JOIN estados e ON e.clave = m.estado WHERE d.no_cliente = '" + no_cliente + "'");
                            foreach (DataRow row2 in Datos3.Tables[0].Rows)
                            {
                                String municipio = ConexionMysql.regresaCampoConsulta("SELECT m.nombre FROM sinca.`domicilio` d INNER JOIN clientes_instalaciones ci ON ci.instalacion=d.id INNER JOIN municipios m ON m.id = d.municipio INNER JOIN estados e ON e.clave=m.estado WHERE d.id='" + row2["id"].ToString() + "'");
                                String estado = ConexionMysql.regresaCampoConsulta("SELECT e.nombre FROM sinca.domicilio d INNER JOIN clientes_instalaciones ci ON ci.instalacion=d.id INNER JOIN municipios m ON m.id = d.municipio INNER JOIN estados e ON e.clave=m.estado WHERE d.id='" + row2["id"].ToString() + "'");

                                txtCalle.Text = Convert.ToString(row2["calle"]);
                                txtColonia.Text = Convert.ToString(row2["colonia"]);
                                txtNumero.Text = Convert.ToString(row2["noexterior"]);
                                txtEstado.Text = estado;
                                txtMunicipio.Text = municipio;
                                txtCodPostal.Text = Convert.ToString(row2["cp"]);
                                //Console.WriteLine("Calle: " + Convert.ToString(row["calle"]) + ", " + Convert.ToString(row["noexterior"]) + ", " + Convert.ToString(row["colonia"]) + ", " + Convert.ToString(row["municipio"]) + ", " + Convert.ToString(row["estado"]) + ", C.P. " + Convert.ToString(row["cp"]));
                            }
                        }
                        else
                        {
                            string fecha = Convert.ToString(row["fecha_informe"]);
                            string hora = Convert.ToString(row["hora_informe"]);
                            dtpFecha.Value = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            dtpHora.Value = DateTime.ParseExact(hora, "HH:mm:ss", CultureInfo.InvariantCulture);
                            pbGuardado.Show();
                                guardado = 1;
                            txtCalle.Text = Convert.ToString(row["calle"]);
                            txtColonia.Text = Convert.ToString(row["colonia"]);
                            txtNumero.Text = Convert.ToString(row["noexterior"]);
                            txtEstado.Text = Convert.ToString(row["estado"]); ;
                            txtMunicipio.Text = Convert.ToString(row["municipio"]);
                            txtCodPostal.Text = Convert.ToString(row["cp"]);
                            txtCorreos.Text = Convert.ToString(row["correos"]);
                            txtTelefonos.Text = Convert.ToString(row["telefonos"]);
                            txtPais.Text = Convert.ToString(row["pais"]);
                            txtLocalidadFiscal.Text = Convert.ToString(row["localidad"]);
                        }

                        id_acta = Convert.ToInt32(row["id_acta"]);
                        txtEscrito.Text = Convert.ToString(row["no_escrito_comision"]);
                        cbDiligencia.Text = Convert.ToString(row["acepta_diligencia"]);
                        txtSolicitud.Text = Convert.ToString(row["solicitud"]);
                        
                        cbCumpleProduccion.Text= Convert.ToString(row["cumple_produccion"]);
                        cbEnvasaBebidas.Text= Convert.ToString(row["envasa_bebidas"]);
                        cbEvaluacion.Text= Convert.ToString(row["acepta_evaluacion"]);
                        txtNoP.Text = Convert.ToString(row["informeP"]);
                        txtNoE.Text = Convert.ToString(row["InformeE"]);
                        txtNoA.Text = Convert.ToString(row["InformeA"]);
                        txtActaP.Text = Convert.ToString(row["actaP"]);
                        txtActaE.Text = Convert.ToString(row["actaE"]);
                        txtActaA.Text = Convert.ToString(row["actaA"]);



                        if (int.Parse(row["mezcal"].ToString()) == 1)
                        {
                            cbxMezcal.Checked = true;
                        }
                        else
                        {
                            cbxMezcal.Checked = false;
                        }
                         if (int.Parse(row["bebidas_con"].ToString()) == 1)
                        {
                            cbxBebidas.Checked = true;
                        }
                        else
                        {
                            cbxBebidas.Checked = false;
                        }


                        if (int.Parse(row["cat_ancestral"].ToString()) == 1)
                        {
                            cbAncestral.Checked = true;
                        }
                        else
                        {
                            cbAncestral.Checked = false;
                        }
                        if (int.Parse(row["cat_artesanal"].ToString()) == 1)
                        {
                            cbArtesamal.Checked = true;
                        }
                        else
                        {
                            cbArtesamal.Checked = false;
                        }
                        if (int.Parse(row["cat_mezcal"].ToString()) == 1)
                        {
                            cbMezcal.Checked = true;
                        }
                        else
                        {
                            cbMezcal.Checked = false;
                        }

                        //txtCredencial.Text = Convert.ToString(row["credencial_acreditado"]);
                    }
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarToolTips()
        {
            //Recepcion de Agave
            this.tpTipo.SetToolTip(this.lblTipo, "Anotar el número y tipo de equipo. Por ejemplo: Báscula, herramientas");
            this.tpTipo.SetToolTip(this.lblCapacidad, "Anotar que capacidad tiene el equipo (valor cuantitativo y la unidad de medida). Por ejemplo:\r\n500 kg\r\nOjo: escribir las unidades de medida apropiadamente, sin pluralizar, sin puntos, según corresponda en mayúsculas o minúsculas");
            this.tpTipo.SetToolTip(this.lblCaracteristicas, "Describa el equipo. Por ejemplo: materiales de fabricación, características particulares, nivel de deterioro, tiempo de vida útil, si es apropiado para el fin que se utiliza.");
            this.tpTipo.SetToolTip(this.lblCondicion, "Buena\r\nRegular\r\nMala");
            this.tpTipo.SetToolTip(this.lblDescripcion, "Describir el espacio: Por ejemplo, si esta techado, si tiene piso,  paredes, de que materiales es el techado, el piso, las paredes, \r\nsi las instalaciones se encuentran deterioradas, a que distancia está de las demás instalaciones,  si el espacio está delimitado, si se observa limpio, si se observa fauna nociva, \r\nsi está lejos de tiraderos de basura o fuentes de contaminación.");
            this.tpTipo.SetToolTip(this.lblPorcentaje3, "En un año, ¿qué % de su producción la obtuvo con este agave?. Si es la única especie de agave que utiliza le corresponde un 100%. \r\nLa suma de los % de todas las especies de agave utilizadas debe dar el 100%.");
            this.tpTipo.SetToolTip(this.lblMezclas, "Indicar si la empresa elabora lotes de Mezcal producto de la mezcla de 2 o más tipos de maguey.\r\n- Si\r\n- No");
            this.tpTipo.SetToolTip(this.lblMaduro1, "Indicar si el maguey que ocupa la empresa para elaborar Mezcal se encuentra maduro");
           
            this.tpTipo.SetToolTip(this.lblRegistro, "Indicar si la empresa utiliza maguey registrado ante AMMA u otro organismo.\r\n- Si\r\n- No");
            this.tpTipo.SetToolTip(this.lblMetodo1, "Describa como realizan la inspección del maguey para determinar que ya se encuentra maduro");
            this.tpTipo.SetToolTip(this.lblMetodo2, "Describa cómo realizan el pesado de las piñas de maguey");
            this.tpTipo.SetToolTip(this.lblMetodo3, "Indicar si la empresa realiza el muestreo de agave crudo (quien y como realiza el muestreo, condiciones en que se almacena la muestra o en el peor de los casos por que no realiza el muestreo)");
            this.tpTipo.SetToolTip(this.lblMetodo4, "Describir como se realiza la jima del maguey");
            this.tpTipo.SetToolTip(this.lblMetodo5, "En caso de haber, hacer observaciones de lo detectado en esta etapa del proceso");

            //Cocción
            this.tpTipo.SetToolTip(this.lblCapacidadCoccion, "Anotar que capacidad tiene el equipo (valor cuantitativo y la unidad de medida). Por ejemplo:\r\n5000 kg\r\nOjo: escribir las unidades de medida apropiadamente, sin pluralizar, sin puntos, según corresponda en mayúsculas o minúsculas");
            this.tpTipo.SetToolTip(this.lblCaracteristicasCoccion, "Describa el equipo. Por ejemplo: materiales de fabricación, características particulares, nivel de deterioro,\r\n tiempo de vida útil, si es apropiado para el fin que se utiliza.");
            this.tpTipo.SetToolTip(this.lblCondicionCoccion, "BUENO\r\nREGULAR \r\nMALO");
            this.tpTipo.SetToolTip(this.lblDescripcionCoccion, "Describir el espacio: Por ejemplo, si esta techado, si tiene piso,  paredes, de que materiales es el techado, el piso, \r\nlas paredes, si las instalaciones se encuentran deterioradas, a que distancia está de las demás instalaciones,  si el espacio está delimitado, si se observa limpio, si se observa \r\nfauna nociva, si está lejos de tiraderos de basura o fuentes de contaminación.\r\n");
            this.tpTipo.SetToolTip(this.lblMetodo1Coccion, "Indicar la frecuencia de limpieza y los utensilios utilizados para llevar a cabo dicha actividad");
            this.tpTipo.SetToolTip(this.lblMetodo2Coccion, "Indique la fuente de calor del equipo (leña, gas, vapor de agua, etc.) y el tiempo de precalentamiento");
            this.tpTipo.SetToolTip(this.lblMetodo3Coccion, "Indicar por cuanto tiempo permanece el maguey dentro del horno para asegurar una cocción completa");
            this.tpTipo.SetToolTip(this.lblMetodo4Coccion, "En caso de haber, hacer observaciones de lo detectado en esta etapa del proceso");

            //Molienda
            this.tpTipo.SetToolTip(this.lblTipoMolienda, "Marque con una X la opción correspondiente");
            this.tpTipo.SetToolTip(this.lblCapacidadMolienda, "Anotar que capacidad tiene el equipo (valor cuantitativo y la unidad de medida). Por ejemplo:\r\n1500 kg/h\r\n1500 kg/día\r\nOjo: escribir las unidades de medida apropiadamente, sin pluralizar, sin puntos, según corresponda en mayúsculas o minúsculas");
            this.tpTipo.SetToolTip(this.lblCondicionMolienda, "Buena\r\nRegular\r\nMala");
            this.tpTipo.SetToolTip(this.txtDescripcionMolienda, "Describir el espacio: Por ejemplo, si esta techado, si tiene piso,  paredes, de que materiales es el techado,\r\n el piso, las paredes, si las instalaciones se encuentran deterioradas, a que distancia está de las demás instalaciones,  si el espacio está delimitado, si se observa limpio, \r\nsi se observa fauna nociva, si está lejos de tiraderos de basura o fuentes de contaminación.");
            this.tpTipo.SetToolTip(this.lblMetodo1Molienda, "Describa como se realiza el picado de agave, utensilios utilizados para tal fin");
            this.tpTipo.SetToolTip(this.lblMetodo2Molienda, "Describir como se realiza la molienda, tiempo que tarda en moler x cantidad de maguey y como determinan cuando el maguey ya está perfectamente molido para proceder a la vaciado en tinas");
            this.tpTipo.SetToolTip(this.lblMetodo3Molienda, "En caso de haber, hacer observaciones de lo detectado en esta etapa del proceso");

            //Fermentación
            this.tpTipo.SetToolTip(this.lblTipoFermentacion, "Marque con una X la opción correspondiente");
            this.tpTipo.SetToolTip(this.lblCapacidadFermentacion, "Anotar que capacidad tiene el equipo (valor cuantitativo y la unidad de medida). Por ejemplo:\r\n1500 kg/h\r\n1500 kg/día\r\nOjo: escribir las unidades de medida apropiadamente, sin pluralizar, sin puntos, según corresponda en mayúsculas o minúsculas");
            this.tpTipo.SetToolTip(this.lblCaracteristicasFermentacion, "Describa el equipo. Por ejemplo: materiales de fabricación, características particulares, nivel de deterioro, tiempo de vida útil, si es apropiado para el fin que se utiliza.");
            this.tpTipo.SetToolTip(this.lblCondicionFermentacion, "BUENO\r\nREGULAR \r\nMALO");
            this.tpTipo.SetToolTip(this.lblDescripcionFermentacion, "Describir el espacio: Por ejemplo, si esta techado, si tiene piso,  paredes, de que materiales es el techado, el piso, las paredes,\r\n si las instalaciones se encuentran deterioradas, a que distancia está de las demás instalaciones,  si el espacio está delimitado, si se observa limpio, si se observa fauna nociva,\r\n si está lejos de tiraderos de basura o fuentes de contaminación.");
            this.tpTipo.SetToolTip(this.lblMetodo1Fermentacion, "Describa cómo se realiza la formulación (tiempo de reposo, que volumen de agua se le adiciona, características del agua empleada (fría, caliente, etc). De qué manera y por cuanto tiempo mezclan el formulado para dejarlo lo más homogéneo posible");
            this.tpTipo.SetToolTip(this.lblMetodo2Fermentacion, "Indique cuanto tiempo después de haberse llevado a cabo la formulación, permanece el mosto en tinas de fermentación. Como se determina que la fermentación ha terminado para poder proceder a la destilación");
            this.tpTipo.SetToolTip(this.lblMetodo3Fermentacion, "En caso de haber, hacer observaciones de lo detectado en esta etapa del proceso");

            //Destilación
            /* this.tpTipo.SetToolTip(this.rbDirecto, "Calentamiento directo, con leña o gas");
             this.tpTipo.SetToolTip(this.rbIndirecto, "Calentamiento indirecto a vapor (caldera)");*/
            this.tpTipo.SetToolTip(this.lbltipoDestilacion, "Marque con una X la opción correspondiente");
            this.tpTipo.SetToolTip(this.lblCapacidadDestilacion, "Anotar que capacidad tiene el equipo (valor cuantitativo y la unidad de medida). Por ejemplo:\r\n1500 kg/h\r\n1500 kg/día\r\nOjo: escribir las unidades de medida apropiadamente, sin pluralizar, sin puntos, según corresponda en mayúsculas o minúsculas");
            this.tpTipo.SetToolTip(this.lblCaracteristicasDestilacion, "Describa el equipo. Por ejemplo: materiales de fabricación, características particulares, nivel de deterioro, tiempo de vida útil, si es apropiado para el fin que se utiliza.");
            this.tpTipo.SetToolTip(this.lblCondicionDestilacion, "Buena\r\nRegular\r\nMala");
            this.tpTipo.SetToolTip(this.lblDescripcionDestilacion, "Describir el espacio: Por ejemplo, si esta techado, si tiene piso,  paredes, de que materiales es el techado, el piso, las paredes, si las \r\ninstalaciones se encuentran deterioradas, a que distancia está de las demás instalaciones,  si el espacio está delimitado, si se observa limpio, si se observa fauna nociva, \r\nsi está lejos de tiraderos de basura o fuentes de contaminación.");
            this.tpTipo.SetToolTip(this.lblMetodo1Destilacion, "Indicar cuantas destilaciones se realizan y a qué velocidad (volumen/tiempo). Indicar si realizan cortes (puntas, cuerpo y colas)");
            this.tpTipo.SetToolTip(this.lblMetodo2Destilacion, "En caso de haber, hacer observaciones de lo detectado en esta etapa del proceso");

            //Almacen de Granel
            this.tpTipo.SetToolTip(this.lblTipoAlmacen, "- Ánforas\r\n- Tambos\r\n- Tanques\r\n- Etc.");
            this.tpTipo.SetToolTip(this.lblCondicionAlmacen, "Buena\r\nRegular\r\nMala");
            this.tpTipo.SetToolTip(this.lblCapacidadAlmacen, "Anotar que capacidad tiene el equipo (valor cuantitativo y la unidad de medida). Por ejemplo:\r\n300 L\r\nOjo: escribir las unidades de medida apropiadamente, sin pluralizar, sin puntos, según corresponda en mayúsculas o minúsculas");
            this.tpTipo.SetToolTip(this.lblCaracteristicasAlmacen, "Describa el equipo. Por ejemplo: materiales de fabricación, características particulares, nivel de deterioro, tiempo de vida útil, si es apropiado para el fin que se utiliza.");
            this.tpTipo.SetToolTip(this.lblDescripcionAlmacen, "Describir el espacio: Por ejemplo, si esta techado, si tiene piso,  paredes, de que materiales es el techado, \r\nel piso, las paredes, si las instalaciones se encuentran deterioradas, a que distancia está de las demás instalaciones,  si el espacio está delimitado, si se observa limpio, si se observa fauna nociva, si está lejos de \r\ntiraderos de basura o fuentes de contaminación.");


        }

        private void mostrarAgregarImagen(String columna, String tabla)
        {
            FrmAgregarImagen frm = new FrmAgregarImagen();
            frm.no_cliente=no_cliente;
            frm.di_solicitud=di_solicitud;
            frm.texto = columna;
            frm.tabla = tabla;
            frm.ShowDialog();
        }

        private void btnMaestro_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maestro", "di_inf_fotos_produccion");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
            try
            {

                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                string hora = dtpHora.Value.ToString("HH:mm");
                String id_acta = ConexionMysql.regresaCampoConsulta("Select id_acta FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String id_informe = ConexionMysql.regresaCampoConsulta("Select id_informe FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String testigos = ConexionMysql.regresaCampoConsulta("Select testigos FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");

                if (guardado == 1)
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_informe SET informeP='" + txtNoP.Text + "', informeE='" + txtNoE.Text + "', informeA='" + txtNoA.Text + "', actaP='" + txtActaP.Text + "', actaE='" + txtActaE.Text + "', actaA='" + txtActaA.Text + "' Where id='" + id_informe + "'") == "Error")
                    {
                        return;
                    }
                }
                else
                {
                    String no_sol = ConexionMysql.regresaCampoConsulta("Select solicitud FROM sinca.`di_solicitud` WHERE id='" + id_solicitud + "'");

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_datos_informe`(`modificacion`, `informeP`, `InformeE`, `InformeA`, `actaP`, `actaE`, `actaA`) " +
                        "VALUES('" + Usuario.IdUsuario + "','" + txtNoP.Text + "','" + txtNoE.Text + "','" + txtNoA.Text + "','" + txtActaP.Text + "','" + txtActaE.Text + "','" + txtActaA.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_informe = ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();");
                    guardado = 1;
                    pbGuardado.Show();

                }
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET acepta_diligencia='" + cbDiligencia.GetItemText(cbDiligencia.SelectedItem) + "', fecha_modificacion=NOW(), usuario='" + Usuario.IdUsuario + "' WHERE id='" + id_acta + "'") == "Error")
                {
                    return;
                }
               /* if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_testigos SET testigo1='" + txtTestigo1.Text + "', testigo2='" + txtTestigo2.Text + "', " +
                    " modifico='" + Usuario.IdUsuario + "', fecha_modificacion=NOW() Where id='" + testigos + "'") == "Error")
                {
                    return;
                }*/
                int mezcal=0;
                int bebidas_con=0;
                int ancestral = 0;
                int artesanal = 0;
                int Cmezcal = 0;

                if (cbxMezcal.Checked == true) mezcal = 1;
                if (cbxBebidas.Checked == true) bebidas_con = 1;

                if (cbAncestral.Checked == true) ancestral = 1;
                if (cbArtesamal.Checked == true) artesanal = 1;
                if (cbMezcal.Checked == true) Cmezcal = 1;
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET fecha_informe='" + fecha + "', hora_informe='" + hora + "', cumple_produccion='"+cbCumpleProduccion.Text+ "', calle='" + txtCalle.Text + "', colonia='" + txtColonia.Text + "', cp='" + txtCodPostal.Text + "', noexterior='" + txtNumero.Text + "', municipio='" + txtMunicipio.Text + "', estado='" + txtEstado.Text + "',pais='" + txtPais.Text + "',telefonos='" + txtTelefonos.Text + "',correos='" + txtCorreos.Text + "'," +
                    " no_escrito_comision='" + txtEscrito.Text + "',  registro='" + Usuario.IdUsuario + "',solicitud='" + txtSolicitud.Text + "', localidad='" + txtLocalidadFiscal.Text +
                    "', id_informe='" + id_informe + "',envasa_bebidas='" + cbEnvasaBebidas.Text + "', cat_ancestral='" + ancestral + "', cat_artesanal='" + artesanal + "', cat_mezcal='" + Cmezcal + "',mezcal='" + mezcal+ "', acepta_evaluacion='"+cbEvaluacion.Text+"',bebidas_con='" + bebidas_con+"' Where id='" + di_solicitud + "'") == "Error")
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

        public String ObtenerIdMaximoFabrica()
        {
            String id_max_fabrica = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_fabrica,4)) )   FROM maestro_fabrica where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_fabrica == "" || id_max_fabrica == null)
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_fabrica = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_fabrica = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_fabrica) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_fabrica = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_fabrica = Usuario.IdUsuario + "-" + suma;
                }
            }
            return id_max_fabrica;
        }

        private void btnActualizarPro_Click(object sender, EventArgs e)
        {
            String maduracion = "0";
            try
            {
                if (cbxMaduracionP.Checked) maduracion = "1";
                /*String estado = ConexionMysql.regresaCampoConsulta("SELECT clave FROM `estados` WHERE nombre = '" + txtEstadoP.Text.Trim() + "'");
                String municipio = ConexionMysql.regresaCampoConsulta("SELECT id FROM `municipios` WHERE nombre = '" + txtMunicipioP.Text.Trim() + "' and estado = '" + estado + "'");*/
                if (id_produccion == 0)
                {
                    String rv_instalacion = "";

                    if (txtAliasP.Text == "")
                    {
                        MessageBox.Show("Ingrese una fabrica");
                        txtAliasP.Focus();
                        return;
                    }

                    if (txtMaestro1.Text == "")
                    {
                        MessageBox.Show("Ingrese un maestro mezcalero");
                        return;
                    }

                    if (txtEstadoP.Text == "")
                    {
                        MessageBox.Show("Debe seleccionar un estado");
                        return;
                    }
                    if (txtColoniaP.Text == "")
                    {
                        MessageBox.Show("Ingrese una localidad");
                        return;
                    }
                    rv_instalacion = ObtenerIdMaximoFabrica();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  maestro_fabrica(no_cliente,id_fabrica,fabrica,folio_unico_granel,estado,municipio,localidad,id_verificador) VALUES('" + no_cliente + "' ,'" + rv_instalacion + "','" + txtAliasP.Text + "','" + txtFolioUnico.Text + "','" + txtEstadoP.Text + "','" + txtMunicipioP.Text + "','" + txtColoniaP.Text + "'," + Usuario.IdUsuario + ")") == "Error")
                    {
                        return;
                    }

                   /* Console.WriteLine("INSERT INTO  maestro_fabrica(no_cliente,id_fabrica,fabrica,folio_unico_granel,estado,municipio,localidad,id_verificador) VALUES('" + no_cliente + "' ,'" + rv_instalacion + "','" + txtAliasP.Text + "','" + txtFolioUnico.Text + "','" + txtEstadoP.Text + "','" + txtMunicipioP.Text + "','" + txtColoniaP.Text + "'," + Usuario.IdUsuario + ")");

                    Console.WriteLine(rv_instalacion);*/

                    string id_max_maestro_mezcalero = IdMaximo.ObtenerIdMaximoMaestroMezcalero();

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  maestros_mezcaleros(id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha,activo,actualizado) VALUES('" + id_max_maestro_mezcalero + "' ,'" + txtMaestro1.Text + "','" + rv_instalacion + "'," + Usuario.IdUsuario + ",now(),1,0)") == "Error")
                    {
                        return;
                    }


                    //ConexionMysql.transCompleta();
                    // MessageBox.Show("Fabrica guardada");

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_instalaciones(tipo, alias, calle, noexterior, nointerior, colonia, municipio, cp, referencia, " +
                        "telefono, correo, responsable, latitud, longitud,paraje,granel,maduracion,producto_terminado,estado, `tipo_prop`, `edad_maestro`, `telefono_maestro`, rv_instalaciones,maestro1,maestro2,localidad) " +
                        "VALUES('1', '" + txtAliasP.Text + "', '" + txtCalleP.Text + "', '" + txtNoExteriorP.Text + "', '" + txtNoInteriorP.Text + "', '" + txtColoniaP.Text + "', " +
                        "'" + txtMunicipioP.Text + "', '" + txtCodpostalP.Text + "', '" + txtReferenciasP.Text + "', '" + txtTelefonoP.Text + "', '" + txtCorreoP.Text + "', '" + txtResponsableP.Text + "', " +
                        "'" + txtLatitudP.Text + "', '" + txtLongitudP.Text + "','" + txtParajeP.Text + "', '1', '" + maduracion + "', '0', '" + txtEstadoP.Text + "','"+ cbTipIns.Text+ "','"+ txtEdadMaestro.Text + "','"+txtTelefonoMaestro.Text+"','"+ id_max_fabrica + "','"+txtMaestro1.Text+"','"+txtMaestro2.Text+"','"+txtLocalidadA.Text+"')") == "Error")
                    { 
                        return;
                    }
                    id_produccion = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_solicitud_instalacion(solicitud, instalacion) VALUES('" + di_solicitud + "', '" + id_produccion + "')") == "Error")
                    {
                        return;
                    }
                    /*if (ConexionMysql.insUpd_transaccion("INSERT INTO maestros_mezcaleros(id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha, activo,actualizado) VALUES ('" + id_max_maestros_mezcaleros + "','" + TxtMaestro.Text + "','" + id_fabrica + "'," + Usuario.IdUsuario + ",now(),1,0);") == "Error")
                    {
                        return;
                    }*/

                    //id_produccion = 1;
                    pbProd.Show();

                    //Console.WriteLine("Se crea la instalacion");

                }
                else
                {
                    string rv_instalacion = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.di_instalaciones where id='" + id_produccion + "'");

                    if (rv_instalacion == "" || rv_instalacion == null)
                    {
                        Console.WriteLine("es null o vacio " + rv_instalacion);
                        if (txtAliasP.Text == "")
                        {
                            MessageBox.Show("Ingrese una fabrica");
                            txtAliasP.Focus();
                            return;
                        }

                        if (txtMaestro1.Text == "")
                        {
                            MessageBox.Show("Ingrese un maestro mezcalero");
                            return;
                        }

                        if (txtEstadoP.Text == "")
                        {
                            MessageBox.Show("Debe seleccionar un estado");
                            return;
                        }
                        if (txtColoniaP.Text == "")
                        {
                            MessageBox.Show("Ingrese una localidad");
                            return;
                        }
                        rv_instalacion = ObtenerIdMaximoFabrica();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  maestro_fabrica(no_cliente,id_fabrica,fabrica,folio_unico_granel,estado,municipio,localidad,id_verificador) VALUES('" + no_cliente + "' ,'" + rv_instalacion + "','" + txtAliasP.Text + "','" + txtFolioUnico.Text + "','" + txtEstadoP.Text + "','" + txtMunicipioP.Text + "','" + txtColoniaP.Text + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }

                        Console.WriteLine(rv_instalacion);

                        string id_max_maestro_mezcalero = IdMaximo.ObtenerIdMaximoMaestroMezcalero();

                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  maestros_mezcaleros(id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha,activo,actualizado) VALUES('" + id_max_maestro_mezcalero + "' ,'" + txtMaestro1.Text + "','" + rv_instalacion + "'," + Usuario.IdUsuario + ",now(),1,0)") == "Error")
                        {
                            return;
                        }
                    }

                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_instalaciones SET alias='" + txtAliasP.Text + "', calle='" + txtCalleP.Text + "', noexterior='" + txtNoExteriorP.Text + "'," +
                        "nointerior='" + txtNoInteriorP.Text + "', colonia='" + txtColoniaP.Text + "', municipio='" + txtMunicipioP.Text + "',estado='" + txtEstadoP.Text + "', cp='" + txtCodpostalP.Text + "', referencia='" + txtReferenciasP.Text + "', responsable='" + txtResponsableP.Text + "'," +
                        "telefono='" + txtTelefonoP.Text + "', correo='" + txtCorreoP.Text + "', latitud='" + txtLatitudP.Text + "', longitud='" + txtLongitudP.Text + "', paraje='" + txtParajeP.Text + "', maduracion='" + maduracion + "',`tipo_prop`='"+cbTipIns.Text+"',`edad_maestro`='"+txtEdadMaestro.Text+"',`telefono_maestro`='"+txtTelefonoMaestro.Text+"', rv_instalaciones='" + rv_instalacion + "', maestro1='"+txtMaestro1.Text+"', maestro2='"+txtMaestro2.Text+"', localidad='" + txtLocalidadP.Text + "'  WHERE id='" + id_produccion + "'") == "Error")
                    {
                        return;
                    }

                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMunicipioP_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                /*ConexionMysql.conecta();
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
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String maduracion = "0";
            String rv_instalacion = "";
            try
            {
                if (cbxMaduracionE.Checked) maduracion = "1";
                /*String estado = ConexionMysql.regresaCampoConsulta("SELECT clave FROM `estados` WHERE nombre = '" + txtEstadoE.Text.Trim() + "'");
                String municipio = ConexionMysql.regresaCampoConsulta("SELECT id FROM `municipios` WHERE nombre = '" + txtMunicipioE.Text.Trim() + "' and estado = '" + estado + "'");*/
                if (id_envasado == 0)
                {
                    if (txtAliasE.Text == "")
                    {
                        MessageBox.Show("Ingrese una envasadora");
                        txtAliasE.Focus();
                        return;
                    }
                    if (txtResponsableE.Text == "")
                    {
                        MessageBox.Show("Ingrese un responsable");
                        txtResponsableE.Focus();
                        return;
                    }
                    if (txtEstadoE.Text == "")
                    {
                        MessageBox.Show("Debe seleccionar un estado");
                        return;
                    }

                    if (txtColoniaE.Text == "")
                    {
                        MessageBox.Show("Ingrese una localidad");
                        return;
                    }

                    ObtenerIdMaximoEnvasadora();
                    //MessageBox.Show(EnvasadoraExterna.ToString()) ;
                    //return;
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasadora_encargado(no_cliente,encargado,id_envasadora,envasadora,folio_unico_granel,estado,municipio,localidad,id_verificador) VALUES('" + no_cliente + "' ,'" + txtResponsableE.Text + "','" + id_max_envasadora + "','" + txtAliasE.Text + "','" + txtFolioUnicoEnv.Text + "','" + txtEstadoE.Text + "','" + txtMunicipioE.Text + "','" + txtColoniaE.Text + "'," + Usuario.IdUsuario + ")") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_instalaciones(tipo, alias, calle, noexterior, nointerior, colonia, municipio, cp, referencia, " +
                        "telefono, correo, responsable, latitud, longitud,paraje,granel,maduracion,producto_terminado,estado,tipo_prop,edad_maestro,rv_instalaciones, localidad) " +
                        "VALUES('2', '" + txtAliasE.Text + "', '" + txtCalleE.Text + "', '" + txtExteriorE.Text + "', '" + txtInteriorE.Text + "', '" + txtColoniaE.Text + "', " +
                        "'" + txtMunicipioE.Text + "', '" + txtCodPE.Text + "', '" + txtReferenciaE.Text + "', '" + txtTelefonoE.Text + "', '" + txtCorreoE.Text + "', '" + txtResponsableE.Text + "', " +
                        "'" + txtLatitudE.Text + "', '" + txtLongitudE.Text + "','" + txtParajeE.Text + "', '1', '" + maduracion + "', '0','" + txtEstadoE.Text + "','" + cbtipoEnv.Text + "','" + txtEdadEnvasado.Text + "','" + id_max_envasadora + "','" + txtLocalidadE.Text + "')") == "Error")
                    {
                        return;
                    }

                    id_envasado = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_solicitud_instalacion(solicitud, instalacion) VALUES('" + di_solicitud + "', '" + id_envasado + "')") == "Error")
                    {
                        return;
                    }
                    pbEnvasado.Show();
                }
                else
                {
                    rv_instalacion = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.di_instalaciones where id='" + id_envasado + "'");
                    if (rv_instalacion == "" || rv_instalacion == null)
                    {
                        if (txtAliasE.Text == "")
                        {
                            MessageBox.Show("Ingrese una envasadora");
                            txtAliasE.Focus();
                            return;
                        }
                        if (txtResponsableE.Text == "")
                        {
                            MessageBox.Show("Ingrese un responsable");
                            txtResponsableE.Focus();
                            return;
                        }
                        if (txtEstadoE.Text == "")
                        {
                            MessageBox.Show("Debe seleccionar un estado");
                            return;
                        }

                        if (txtColoniaE.Text == "")
                        {
                            MessageBox.Show("Ingrese una localidad");
                            return;
                        }

                        ObtenerIdMaximoEnvasadora();
                        //MessageBox.Show(EnvasadoraExterna.ToString()) ;
                        //return;
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasadora_encargado(no_cliente,encargado,id_envasadora,envasadora,folio_unico_granel,estado,municipio,localidad,id_verificador) VALUES('" + no_cliente + "' ,'" + txtResponsableE.Text + "','" + id_max_envasadora + "','" + txtAliasE.Text + "','" + txtFolioUnicoEnv.Text + "','" + txtEstadoE.Text + "','" + txtMunicipioE.Text + "','" + txtColoniaE.Text + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                        rv_instalacion = id_max_envasadora;
                    }
                    
                   if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_instalaciones SET alias='" + txtAliasE.Text + "', calle='" + txtCalleE.Text + "', noexterior='" + txtExteriorE.Text + "'," +
                        "nointerior='" + txtInteriorE.Text + "', colonia='" + txtColoniaE.Text + "', municipio='" + txtMunicipioE.Text + "', estado='" + txtEstadoE.Text + "', cp='" + txtCodPE.Text + "', referencia='" + txtReferenciaE.Text + "', responsable='" + txtResponsableE.Text + "'," +
                        "telefono='" + txtTelefonoE.Text + "', correo='" + txtCorreoE.Text + "', latitud='" + txtLatitudE.Text + "', longitud='" + txtLongitudE.Text + "', paraje='" + txtParajeE.Text + "', maduracion='" + maduracion + "', tipo_prop='" + cbtipoEnv.Text + "', edad_maestro='" + txtEdadEnvasado.Text + "', rv_instalaciones='" + id_max_envasadora + "', localidad='" + txtLocalidadE.Text + "'  WHERE id='" + id_envasado + "'") == "Error")
                    {
                        return;
                    }

                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbEnvasado.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ObtenerIdMaximoEnvasadora()
        {
            id_max_envasadora = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasadora,4)) )   FROM envasadora_encargado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasadora == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasadora = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasadora = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasadora) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasadora = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasadora = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)//almacen
        {
            String maduracion = "0";
            String granel = "0";
            String producto_terminado = "0";
            try
            {
                if (cbxMaduracionA.Checked) maduracion = "1";
                if (cbxGranelA.Checked) granel = "1";
                if (cbxTerminadoA.Checked) producto_terminado = "1";
                /*String estado = ConexionMysql.regresaCampoConsulta("SELECT clave FROM `estados` WHERE nombre = '" + txtEstadoA.Text.Trim() + "'");
                String municipio = ConexionMysql.regresaCampoConsulta("SELECT id FROM `municipios` WHERE nombre = '" + txtMunicipioA.Text.Trim() + "' and estado = '" + estado + "'");*/
                if (id_almacen == 0)
                {

                    /*if (txtAliasA.Text == "")
                    {
                        MessageBox.Show("Ingrese una Almacen");
                        txtAliasA.Focus();
                        return;
                    }
                    if (txtResponsableA.Text == "")
                    {
                        MessageBox.Show("Ingrese un responsable");
                        txtResponsableA.Focus();
                        return;
                    }
                    if (txtEstadoA.Text == "")
                    {
                        MessageBox.Show("Debe seleccionar un estado");
                        return;
                    }
                   return;
                    }
                    if (txtColoniaA.Text == "")
                    {
                        MessageBox.Show("Ingrese una localidad");
                        return;
                    }


                    ObtenerIdMaximoBodega();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_encargado(no_cliente,encargado,id_almacen,almacen,folio_unico_granel,estado,municipio,localidad,id_verificador,tipo_almacen) VALUES('" + no_cliente + "' ,'" + txtResponsableA.Text + "','" + id_max_almacen + "','" + txtAliasA.Text + "','" + txtFolioUnicoAlm.Text + "','" + txtEstadoA.Text + "','" + txtFolioUnicoAlm.Text + "','" + txtColoniaA.Text + "'," + Usuario.IdUsuario + "," + cbTipoAlm.Text + ")") == "Error")
                    {
                        return;
                    }*/

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_instalaciones(tipo, alias, calle, noexterior, nointerior, colonia, municipio, cp, referencia, " +
                        "telefono, correo, responsable, latitud, longitud,paraje,granel,maduracion,producto_terminado,estado,tipo_prop,localidad,edad_maestro) " +
                        "VALUES('3', '" + txtAliasA.Text + "', '" + txtCalleA.Text + "', '" + txtExteriorA.Text + "', '" + txtInteriorA.Text + "', '" + txtColoniaA.Text + "', " +
                        "'" + txtMunicipioA.Text + "', '" + txtCodPA.Text + "', '" + txtReferenciaA.Text + "', '" + txtTelefonoA.Text + "', '" + txtCorreoA.Text + "', '" + txtResponsableA.Text + "', " +
                        "'" + txtLatitudA.Text + "', '" + txtLongitudA.Text + "','" + txtParajeA.Text + "', '" + granel + "', '" + maduracion + "', '" + producto_terminado + "','" + txtEstadoA.Text + "','" + cbTipoAlm.Text + "', '" + txtLocalidadA.Text + "', '" + txtEdadAlmacen.Text + "')") == "Error")
                    {
                        return;
                    }

                    id_almacen = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.di_solicitud_instalacion(solicitud, instalacion) VALUES('" + di_solicitud + "', '" + id_almacen + "')") == "Error")
                    {
                        return;
                    }
                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_instalaciones SET alias='" + txtAliasA.Text + "', calle='" + txtCalleA.Text + "', noexterior='" + txtExteriorA.Text + "'," +
                        "nointerior='" + txtInteriorA.Text + "', colonia='" + txtColoniaA.Text + "', municipio='" + txtMunicipioA.Text + "', estado='" + txtEstadoA.Text + "', cp='" + txtCodPA.Text + "', referencia='" + txtReferenciaA.Text + "', responsable='" + txtResponsableA.Text + "'," +
                        "telefono='" + txtTelefonoA.Text + "', correo='" + txtCorreoA.Text + "', latitud='" + txtLatitudA.Text + "', longitud='" + txtLongitudA.Text + "', paraje='" + txtParajeA.Text + "', maduracion='" + maduracion + "', tipo_prop='" + cbTipoAlm.Text + "', localidad='" + txtLocalidadA.Text + "', edad_maestro='" + txtEdadAlmacen.Text + "'  WHERE id='" + id_almacen + "'") == "Error")
                    {
                        return;
                    }
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ObtenerIdMaximoBodega()
        {
            id_max_almacen = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen,4)) )   FROM almacen_encargado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//Guardar recepcion
        {
            try {

                float area = float.Parse(txtLargo.Text) * float.Parse(txtAncho.Text);

                if (id_recepcion == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_recepcion_agave`(`largo`, `ancho`, `area`, `descripcion`, `mezclas`, `registro`, `inspeccion_pinas`, `pesado_pinas`, `muestreo`, `corte_pinas`, `comentarios`, `id_solicitud`) " +
                        "VALUES ('" + txtLargo.Text + "', '" + txtAncho.Text + "', '" + area + "', '" + txtDescripcion.Text + "', '" + cbMezclas.Text + "','" + cbRegistro.Text + "','" + txtMetodo1.Text + "','" + txtMetodo2.Text + "','" + txtMetodo3.Text + "','" + txtMetodo4.Text + "','" + txtMetodo5.Text + "','" + di_solicitud + "')") == "Error")
                    {
                        return;
                    }
                    int id_recepcion = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));
                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_recepcion_agave SET largo='" + txtLargo.Text + "',ancho='" + txtAncho.Text + "'," +
                        "area='" + area + "',descripcion='" + txtDescripcion.Text + "', " +
                        "`mezclas`='" + cbMezclas.Text + "'," +
                        "`registro`='" + cbRegistro.Text + "', `inspeccion_pinas`='" + txtMetodo1.Text + "', " +
                        "`pesado_pinas`='" + txtMetodo2.Text + "', `muestreo`='" + txtMetodo3.Text + "', `corte_pinas`='" + txtMetodo4.Text + "', `comentarios`='" + txtMetodo5.Text + "' WHERE id_solicitud='" + di_solicitud + "'") == "Error")
                    {
                        return;
                    }

                }
                imgRecepcion.Show();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iTalk_TabControl1_Click(object sender, EventArgs e)
        {

            switch (tabContenidoProduccion.SelectedTab.Text.Trim())
            {
                case "Datos Generales":
                    Console.WriteLine("Datos Generales");
                    cargar_instalaciones();
                    break;
                case "Recepción de Agave":
                    Console.WriteLine("Recepción de Agave");
                    cargar_recepcion();
                    cargar_recepcion_tabla();
                    cargar_especies();
                    break;
                case "Cocción":
                    cargar_coccion();
                    cargar_tabla_coccion();
                    Console.WriteLine("Cocción");
                    break;
                case "Molienda":
                    cargar_molienda();
                    cargar_tabla_molienda();
                    Console.WriteLine("Molienda");
                    break;
                case "Fermentación":
                    cargar_tabla_fermentacion();
                    cargar_fermentacion();
                    Console.WriteLine("Fermentación");
                    break;
                case "Destilación":
                    cargar_tabla_destilacion();
                    cargar_destilacion();
                    Console.WriteLine("Destilación");
                    break;
                case "Almacen de granel o maduración":
                    cargar_tabla_almacen_produccion();
                    cargar_almacen_granel();
                    Console.WriteLine("Almacen de granel");
                    break;
                case "Evidencia Fotografica":
                    Cargar_fotos_produccion(di_solicitud, no_cliente);
                    Console.WriteLine("Evidencia Fotografica");
                    break;
                default:
                    MessageBox.Show(tabContenidoProduccion.SelectedTab.Text.Trim());
                    break;
            }
            //MessageBox.Show(tabContenidoProduccion.SelectedTab.Text);

        }

        private void cargar_destilacion()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `largo`, `ancho`, `area`, `forma`, `descripcion`, `destilacion`, `comentarios`, `fecha` FROM sinca.`di_inf_destilacion` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoDestilacion.Text = row["largo"].ToString();
                        txtAnchoDestilacion.Text = row["ancho"].ToString();
                        cbForma.Text = row["forma"].ToString();
                        txtDescripcionDestilacion.Text = row["descripcion"].ToString();
                        /*cbTipoDestilacion.Text = row["tipo"].ToString();
                        txtCapacidadDestilacion.Text = row["capacidad"].ToString();
                        txtCaracteristicasDestilacion.Text = row["caracteristicas"].ToString();
                        cbCondicionDestilacion.Text = row["condicion"].ToString();*/
                        txtMetodo1Destilacion.Text = row["destilacion"].ToString();
                        txtMetodo2Destilacion.Text = row["comentarios"].ToString();

                        id_destilacion = int.Parse(row["id"].ToString());
                        imgDestilacion.Show();
                    }
                }
                else
                {
                    imgDestilacion.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_almacen_granel()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `largo`, `ancho`, `area`, `descripcion`, `fecha`, `id_solicitud` FROM sinca.`di_inf_granel_produccion`WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoAlmacen.Text = row["largo"].ToString();
                        txtAnchoAlmacen.Text = row["ancho"].ToString();
                        txtDescripcionAlmacen.Text = row["descripcion"].ToString();

                        id_almacen_produccion = int.Parse(row["id"].ToString());
                        imgAlmacenProd.Show();
                    }
                }
                else
                {
                    imgAlmacenProd.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_fermentacion()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `largo`, `ancho`, " +
                    "`area`, `descripcion`, `formulacion`, `tiempo`, `comentarios`, `fecha` FROM sinca.`di_inf_fermetacion` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                       /* cbTipoFermantacion.Text = row["tipo"].ToString();
                        txtCantidadFermentacion.Text = row["cantidad"].ToString();
                        txtCapacidadFermentacion.Text = row["capacidad"].ToString();
                        txtCaracteristicasFermentacion.Text = row["caracteristicas"].ToString();
                        cbCondicionFermentacion.Text = row["condicion"].ToString();*/
                        txtLargoFermentacion.Text = row["largo"].ToString();
                        txtAnchoFermentacion.Text = row["ancho"].ToString();
                        txtMetodo1Fermentacion.Text = row["formulacion"].ToString();
                        txtMetodo2Fermentacion.Text = row["tiempo"].ToString();
                        txtMetodo3Fermentacion.Text = row["comentarios"].ToString();

                        id_fermentacion = int.Parse(row["id"].ToString());
                        imgFermentacion.Show();
                    }
                }
                else
                {
                    imgFermentacion.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_molienda()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `largo`, `ancho`, " +
                    "`area`, `descripcion`, `picado`, `molienda`, `comentarios`, `fecha` FROM sinca.`di_inf_molienda` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        /*cbTipoMolienda.Text = row["tipo"].ToString();
                        txtCantidadMolienda.Text = row["cantidad"].ToString();
                        txtCapacidadMolienda.Text = row["capacidad"].ToString();
                        txtCaracteristicasMolienda.Text = row["caracteristicas"].ToString();
                        cbCondicionMolienda.Text = row["condicion"].ToString();*/
                        txtLargoMolienda.Text = row["largo"].ToString();
                        txtAnchoMolienda.Text = row["ancho"].ToString();
                        txtDescripcionMolienda.Text = row["descripcion"].ToString();
                        txtMetodo1Molienda.Text = row["picado"].ToString();
                        txtMetodo2Molienda.Text = row["molienda"].ToString();
                        txtMetodo3Molienda.Text = row["comentarios"].ToString();

                        id_molienda = int.Parse(row["id"].ToString());
                        imgMolienta.Show();
                    }
                }
                else
                {
                    imgMolienta.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_coccion()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `largo`, `ancho`, `area`, `cabezas`, `jugos`, `descripcion`, `limpieza`, `calentamiento`, `tiempo`, `comentarios`, `fecha` FROM sinca.`di_inf_coccion` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoCoccion.Text = row["largo"].ToString();
                        txtAnchoCoccion.Text = row["ancho"].ToString();
                        txtDescripcionCoccion.Text = row["descripcion"].ToString();
                        cbCabezas.Text = row["cabezas"].ToString();
                        cbJugos.Text = row["jugos"].ToString();
                        /*cbTipoCoccion.Text = row["tipo"].ToString();
                        txtCantidadCoccion.Text = row["cantidad"].ToString();
                        txtCapacidad.Text = row["capacidad"].ToString();
                        txtCaracteristicasCoccion.Text = row["caracteristicas"].ToString();
                        cbCondicionCoccion.Text = row["condicion"].ToString();*/
                        txtMetodo1Coccion.Text = row["limpieza"].ToString();
                        txtMetodo2Coccion.Text = row["calentamiento"].ToString();
                        txtMetodo3Coccion.Text = row["tiempo"].ToString();
                        txtMetodo4Coccion.Text = row["comentarios"].ToString();
                        id_coccion = int.Parse(row["id"].ToString());
                        imgCoccion.Show();
                    }
                }
                else
                {
                    imgCoccion.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_recepcion()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_informe`, `largo`, `ancho`, `area`, `descripcion`, `especie1`, `especie2`, `especie3`,especie4, " +
                    "`porcentaje1`, `porcentaje2`, `porcentaje3`, porcentaje4,`mezclas`, `maduro1`, `maduro2`, `maduro3`,maduro4 ,`registro`, `inspeccion_pinas`, `pesado_pinas`, `muestreo`, `corte_pinas`, `comentarios`, `fecha`, `id_solicitud` FROM sinca.`di_inf_recepcion_agave` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargo.Text = row["largo"].ToString();
                        txtAncho.Text = row["ancho"].ToString();
                        txtDescripcion.Text = row["descripcion"].ToString();
                        
                        
                        txtMetodo1.Text = row["inspeccion_pinas"].ToString();
                        txtMetodo2.Text = row["pesado_pinas"].ToString();
                        txtMetodo3.Text = row["muestreo"].ToString();
                        txtMetodo4.Text = row["corte_pinas"].ToString();
                        txtMetodo5.Text = row["comentarios"].ToString();
                        cbMezclas.Text = row["mezclas"].ToString();
                       
                        cbRegistro.Text = row["registro"].ToString();
                        id_recepcion = int.Parse(row["id"].ToString());
                        imgRecepcion.Show();
                    }
                }
                else
                {
                    imgRecepcion.Hide();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cargar_tabla_almacen_produccion()
        {
            try
            {
                dtsAlmacenProduccion = new DataSet();
                dtsAlmacenProduccion.Tables.Add("ALMACEN_PRODUCCION");
                dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Columns.Add("ID", Type.GetType("System.String"));
                dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvAlmacen.DataSource = dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"];
                dgvAlmacen.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_granel_produccion` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                Console.WriteLine("SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_granel_produccion` WHERE `id_solicitud`= '" + di_solicitud + "'");
                // dtsDatosRecepcion.Tables["RECEPCION"].Rows.Clear(); DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsAlmacenProduccion.Tables["ALMACEN_PRODUCCION"].Rows.Add(fila);
                }
                /*DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Action";
                buttonColumn.Name = "Delete";
                buttonColumn.Text = "Eliminar";
                buttonColumn.UseColumnTextForButtonValue = true; // Set to true to use Text property for the button
                dvgRecepcion.Columns.Add(buttonColumn);*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_especies()
        {
            try
            {
                dtsEspecie = new DataSet();
                dtsEspecie.Tables.Add("ESPECIE");
                dtsEspecie.Tables["ESPECIE"].Columns.Add("ESPECIE", Type.GetType("System.String"));
                dtsEspecie.Tables["ESPECIE"].Columns.Add("ID", Type.GetType("System.String"));
                dtsEspecie.Tables["ESPECIE"].Columns.Add("PORCENTAJE", Type.GetType("System.String"));
                dtsEspecie.Tables["ESPECIE"].Columns.Add("MADURO", Type.GetType("System.String"));
                dtsEspecie.Tables["ESPECIE"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvEspecieEmpleada.DataSource = dtsEspecie.Tables["ESPECIE"];
                dgvEspecieEmpleada.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `especie`, `porcentaje`, `maduro`, `di_solicitud`, `fecha` FROM sinca.`di_especies_empleadas` WHERE `di_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsEspecie.Tables["ESPECIE"].NewRow();
                    fila["ESPECIE"] = Convert.ToString(row["especie"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["PORCENTAJE"] = Convert.ToString(row["porcentaje"]);
                    fila["MADURO"] = Convert.ToString(row["maduro"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsEspecie.Tables["ESPECIE"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cargar_recepcion_tabla()
        {
            try
            {
                dtsDatosRecepcion = new DataSet();
                dtsDatosRecepcion.Tables.Add("RECEPCION");
                dtsDatosRecepcion.Tables["RECEPCION"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsDatosRecepcion.Tables["RECEPCION"].Columns.Add("ID", Type.GetType("System.String"));
                dtsDatosRecepcion.Tables["RECEPCION"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsDatosRecepcion.Tables["RECEPCION"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsDatosRecepcion.Tables["RECEPCION"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsDatosRecepcion.Tables["RECEPCION"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsDatosRecepcion.Tables["RECEPCION"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dvgRecepcion.DataSource = dtsDatosRecepcion.Tables["RECEPCION"];
                dvgRecepcion.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_recepcion_agave` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                Console.WriteLine("SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_recepcion_agave` WHERE `id_solicitud`= '" + di_solicitud + "'");
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsDatosRecepcion.Tables["RECEPCION"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsDatosRecepcion.Tables["RECEPCION"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_tabla_coccion()
        {
            try
            {
                dtsDatCoccion = new DataSet();
                dtsDatCoccion.Tables.Add("COCCION");
                dtsDatCoccion.Tables["COCCION"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsDatCoccion.Tables["COCCION"].Columns.Add("ID", Type.GetType("System.String"));
                dtsDatCoccion.Tables["COCCION"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsDatCoccion.Tables["COCCION"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsDatCoccion.Tables["COCCION"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsDatCoccion.Tables["COCCION"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsDatCoccion.Tables["COCCION"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvCoccion.DataSource = dtsDatCoccion.Tables["COCCION"];
                dgvCoccion.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_coccion` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsDatCoccion.Tables["COCCION"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsDatCoccion.Tables["COCCION"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_tabla_molienda()
        {
            try
            {
                dtsDatMolienda = new DataSet();
                dtsDatMolienda.Tables.Add("MOLIENDA");
                dtsDatMolienda.Tables["MOLIENDA"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsDatMolienda.Tables["MOLIENDA"].Columns.Add("ID", Type.GetType("System.String"));
                dtsDatMolienda.Tables["MOLIENDA"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsDatMolienda.Tables["MOLIENDA"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsDatMolienda.Tables["MOLIENDA"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsDatMolienda.Tables["MOLIENDA"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsDatMolienda.Tables["MOLIENDA"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvMolienda.DataSource = dtsDatMolienda.Tables["MOLIENDA"];
                dgvMolienda.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_molienda` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsDatMolienda.Tables["MOLIENDA"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsDatMolienda.Tables["MOLIENDA"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_tabla_fermentacion()
        {
            try
            {
                dtsDatFermentacion = new DataSet();
                dtsDatFermentacion.Tables.Add("FERMENTACION");
                dtsDatFermentacion.Tables["FERMENTACION"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsDatFermentacion.Tables["FERMENTACION"].Columns.Add("ID", Type.GetType("System.String"));
                dtsDatFermentacion.Tables["FERMENTACION"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsDatFermentacion.Tables["FERMENTACION"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsDatFermentacion.Tables["FERMENTACION"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsDatFermentacion.Tables["FERMENTACION"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsDatFermentacion.Tables["FERMENTACION"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvFermentacion.DataSource = dtsDatFermentacion.Tables["FERMENTACION"];
                dgvFermentacion.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_fermentacion` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsDatFermentacion.Tables["FERMENTACION"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsDatFermentacion.Tables["FERMENTACION"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_tabla_destilacion()
        {
            try
            {
                dtsDatDestilacion = new DataSet();
                dtsDatDestilacion.Tables.Add("DESTILACION");
                dtsDatDestilacion.Tables["DESTILACION"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsDatDestilacion.Tables["DESTILACION"].Columns.Add("ID", Type.GetType("System.String"));
                dtsDatDestilacion.Tables["DESTILACION"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsDatDestilacion.Tables["DESTILACION"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsDatDestilacion.Tables["DESTILACION"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsDatDestilacion.Tables["DESTILACION"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsDatDestilacion.Tables["DESTILACION"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvDestilacion.DataSource = dtsDatDestilacion.Tables["DESTILACION"];
                dgvDestilacion.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_destilacion` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsDatDestilacion.Tables["DESTILACION"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsDatDestilacion.Tables["DESTILACION"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void dvgRecepcion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dvgRecepcion.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_recepcion(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

      

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_recepcion_agave`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + txtTipo.Text + "', '" + txtCantidad.Text + "', '" + txtCapacidad.Text + "', '" + txtCaracteristicas.Text + "', '" + cbCondicion.Text + "')") == "Error")
                {
                    return;
                }
                txtTipo.Text = "";
                txtCantidad.Text = "";
                txtCapacidad.Text = "";
                txtCaracteristicas.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_recepcion_tabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }
        
        private void eliminar_especie(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_especies_empleadas` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_especies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }
        private void eliminar_recepcion(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_recepcion_agave` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_recepcion_tabla();
            } catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void txtMetodo1Coccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCoccion_Click(object sender, EventArgs e)
        {
            try
            {

                float area = float.Parse(txtLargoCoccion.Text) * float.Parse(txtAnchoCoccion.Text);

                if (id_coccion == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_coccion`( `id_solicitud`, `largo`, `ancho`, `area`, `cabezas`, `jugos`, `descripcion`, " +
                        " `limpieza`, `calentamiento`, `tiempo`, `comentarios`)" +
                        " VALUES ('" + di_solicitud + "','" + txtLargoCoccion.Text + "','" + txtAnchoCoccion.Text + "','" + area + "','" + cbCabezas.Text + "','" + cbJugos.Text + "','" + txtDescripcionCoccion.Text + "'," +
                        "'" + txtMetodo1Coccion.Text + "','" + txtMetodo2Coccion.Text + "','" + txtMetodo3Coccion.Text + "','" + txtMetodo4Coccion.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_coccion = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_coccion SET largo='" + txtLargoCoccion.Text + "', ancho='" + txtAnchoCoccion.Text + "',area='" + area + "',cabezas='" + cbCabezas.Text + "',jugos='" + cbJugos.Text + "',descripcion='" + txtDescripcionCoccion.Text + "'," +
                        "limpieza='" + txtMetodo1Coccion.Text + "',calentamiento='" + txtMetodo2Coccion.Text + "',tiempo='" + txtMetodo3Coccion.Text + "',comentarios='" + txtMetodo4Coccion.Text + "' where id='" + id_coccion + "'") == "Error")
                    {
                        return;
                    }


                }
                cargar_coccion();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMolienda_Click(object sender, EventArgs e)
        {
            try
            {

                float area = float.Parse(txtLargoMolienda.Text) * float.Parse(txtAnchoMolienda.Text);

                if (id_molienda == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_molienda`(`id_solicitud`, `largo`, `ancho`, `area`, `descripcion`, `picado`, `molienda`, `comentarios`) " +
                        "VALUES ('" + di_solicitud + "','" +  txtLargoMolienda.Text + "','" + txtAnchoMolienda.Text + "','" + area + "','" + txtDescripcionMolienda.Text + "','" + txtMetodo1Molienda.Text + "','" + txtMetodo2Molienda.Text + "','" + txtMetodo3Molienda.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_molienda = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_molienda SET largo='" + txtLargoMolienda.Text + "',ancho='" + txtAnchoMolienda.Text + "',area='" + area + "',descripcion='" + txtDescripcionMolienda.Text + "',picado='" + txtMetodo1Molienda.Text + "',molienda='" + txtMetodo2Molienda.Text + "',comentarios='" + txtMetodo3Molienda.Text + "' WHERE id='" + id_molienda + "'") == "Error")
                    {
                        return;
                    }


                }
                cargar_molienda();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFermentacion_Click(object sender, EventArgs e)
        {
            try
            {

                float area = float.Parse(txtLargoFermentacion.Text) * float.Parse(txtAnchoFermentacion.Text);

                if (id_fermentacion == 0)
                {

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_fermetacion`(`id_solicitud`, `largo`, `ancho`, `area`, `descripcion`, `formulacion`, `tiempo`, `comentarios`)" +
                        " VALUES ('" + di_solicitud + "','" +  txtLargoFermentacion.Text + "','" + txtAnchoFermentacion.Text + "','" + area + "','" + txtDescripcionFermentacion.Text + "','" +
                        "" + txtMetodo1Fermentacion.Text + "','" + txtMetodo2Fermentacion.Text + "','" + txtMetodo3Fermentacion.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_fermentacion = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {
                    Console.WriteLine();
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_fermetacion SET largo='" + txtLargoFermentacion.Text + "',ancho='" + txtAnchoFermentacion.Text + "',area='" + area + "',descripcion='" + txtDescripcionFermentacion.Text + "',formulacion='" + txtMetodo1Fermentacion.Text + "',tiempo='" + txtMetodo2Fermentacion.Text + "', comentarios  ='" + txtMetodo3Fermentacion.Text + "'Where id='" + id_fermentacion + "'") == "Error")
                    {
                        return;
                    }


                }
                cargar_fermentacion();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel59_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDestilacion_Click(object sender, EventArgs e)
        {
            try
            {

                float area = float.Parse(txtLargoDestilacion.Text) * float.Parse(txtAnchoDestilacion.Text);

                if (id_destilacion == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_destilacion`(`id_solicitud`, `largo`, `ancho`, `area`, `forma`, `descripcion`, `destilacion`, `comentarios`) " +
                        "VALUES ('" + di_solicitud + "','" + txtLargoDestilacion.Text + "','" + txtAnchoDestilacion.Text + "','" + area + "','" + cbForma.Text + "','" + txtDescripcionDestilacion.Text + "','" +
                        txtMetodo1Destilacion.Text + "','" + txtMetodo2Destilacion.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_destilacion = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_destilacion SET largo='" + txtLargoDestilacion.Text + "',ancho='" + txtAnchoDestilacion.Text + "',area='" + area + "',forma='" + cbForma.Text + "',descripcion='" + txtDescripcionDestilacion.Text + "',destilacion='" + txtMetodo1Destilacion.Text + "',comentarios='" + txtMetodo2Destilacion.Text + "' Where id='" + id_destilacion + "'") == "Error")
                    {
                        return;
                    }
                }
                cargar_destilacion();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarAlmacen_Click(object sender, EventArgs e)
        {

            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_granel_produccion`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + txttipoAlmacen.Text + "', '" + txtCantidadAlmacen.Text + "', '" + txtCapacidadAlmacen.Text + "', '" + txtCaracteristicasAlmacen.Text + "', '" + cbCondicionAlmacen.Text + "')") == "Error")
                {
                    return;
                }
                txttipoAlmacen.Text = "";
                txtCantidadAlmacen.Text = "";
                txtCapacidadAlmacen.Text = "";
                txtCaracteristicasAlmacen.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_almacen_produccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }
        private void eliminar_almacen_produccion(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_granel_produccion` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_almacen_produccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void dgvAlmacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvAlmacen.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_almacen_produccion(dgvAlmacen.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlmacenProd_Click(object sender, EventArgs e)
        {
            try
            {

                float area = float.Parse(txtLargoAlmacen.Text) * float.Parse(txtAnchoAlmacen.Text);

                if (id_almacen_produccion == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_granel_produccion`(`id_solicitud`,`largo`, `ancho`, `area`, `descripcion`) " +
                        "VALUES (" + di_solicitud + ", '" + txtLargoAlmacen.Text + "', '" + txtAnchoAlmacen.Text + "', '" + area + "', '" + txtDescripcionAlmacen.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_almacen_produccion = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_granel_produccion SET largo='" + txtLargoAlmacen.Text + "',ancho='" + txtAnchoAlmacen.Text + "',area='" + area + "',descripcion='" + txtDescripcionAlmacen.Text + "' WHERE id='" + id_almacen_produccion + "'") == "Error")
                    {
                        return;
                    }


                }
                cargar_almacen_granel();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarCumplimientos_Click(object sender, EventArgs e)
        {
            try
            {

                if (id_cumplimientos == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_cumplimientos`(observacionextra,`observacion1`, `cumple1`, `observacion2`, `cumple2`, `observacion3`, `cumple3`, `observacion4`, `cumple4`, `observacion5`, `id_solicitud`)" +
                        " VALUES ('" + cbCumplimientoExtra.Text + "','" + txtOCumplimiento1.Text + "', '" + cbCumplimiento1.Text + "', '" + txtOCumplimiento2.Text + "', '" + cbCumplimiento2.Text + "', '" + txtOCumplimiento3.Text + "', '" + cbCumplimiento3.Text + "', '" + txtOCumplimiento4.Text + "', '" + cbCumplimiento4.Text + "', '" + txtOCumplimiento5.Text + "', " + di_solicitud + ")") == "Error")
                    {
                        return;
                    }
                    id_cumplimientos = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_cumplimientos SET observacionextra='" + cbCumplimientoExtra.Text + "', observacion1='" + txtOCumplimiento1.Text + "',cumple1='" + cbCumplimiento1.Text + "',cumple2='" + cbCumplimiento2.Text + "',cumple3='" + cbCumplimiento3.Text + "',observacion2='" + txtOCumplimiento2.Text + "',observacion3='" + txtOCumplimiento3.Text + "',observacion4='" + txtOCumplimiento4.Text + "', cumple4='" + cbCumplimiento4.Text + "', observacion5='" + txtOCumplimiento5.Text + "' WHERE id='" + id_cumplimientos + "'") == "Error")
                    {
                        return;
                    }


                }
                cargar_cumplimientos();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLavadoBotellas_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("lavado", "di_inf_fotos_envasado");
        }

        private void btnLlenado_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("llenado", "di_inf_fotos_envasado");
        }

        private void btnTaponado_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("taponado", "di_inf_fotos_envasado");
        }

        private void btnVistaInteriorE_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("general_interior", "di_inf_fotos_envasado");
        }

        private void btnVistaExteriorE_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("general_exterior", "di_inf_fotos_envasado");
        }

        private void btnAlmacenPTE_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen_terminado", "di_inf_fotos_envasado");
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("marcas", "di_inf_fotos_envasado");
        }

        private void btnAlmacenInsumos_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen_insumos", "di_inf_fotos_envasado");
        }

        private void btnOtrosE_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("otros", "di_inf_fotos_envasado");
        }



        private void btnAlmacenGranelB_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen_granel", "di_inf_fotos_envasado_bc");
        }

        private void btnLavadoB_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("lavado", "di_inf_fotos_envasado_bc");
        }

        private void btnLlenadoB_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("llenado", "di_inf_fotos_envasado_bc");
        }

        private void btnTaponadoB_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("taponado", "di_inf_fotos_envasado_bc");
        }

        private void btnEnvasadoB_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("linea", "di_inf_fotos_envasado_bc");
        }

        private void btnMarcasB_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("marca", "di_inf_fotos_envasado_bc");
        }

        private void btnSaborizantes_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen_insumos", "di_inf_fotos_envasado_bc");
        }

        private void btnFormulacion_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("formulacion", "di_inf_fotos_envasado_bc");
        }

        private void btnInteriorFA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen1", "di_inf_fotos_almacen");
        }

        private void btnExteriorFA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("terminado4", "di_inf_fotos_almacen");
        }

        private void btnTerminado1FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("terminado1", "di_inf_fotos_almacen");
        }

        private void btnTerminado2FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("terminado2", "di_inf_fotos_almacen");
        }

        private void btnGranel1FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga3", "di_inf_fotos_almacen");
        }

        private void btnGranel2FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga4", "di_inf_fotos_almacen");
        }

        private void btnMaduracion1FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maduracion1", "di_inf_fotos_almacen");
        }

        private void btnMaduracion2FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maduracion2", "di_inf_fotos_almacen");
        }

        private void btnCarga1FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga1", "di_inf_fotos_almacen");
        }

        private void btnCarga2FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga2", "di_inf_fotos_almacen");
        }

        private void btnRecipíentes1FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("recipiente1", "di_inf_fotos_almacen");
        }

        private void btnRecipientes2FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("recipiente2", "di_inf_fotos_almacen");
        }

        private void btnLaboratorioAD_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("laboratorio", "di_inf_areas_comunes");
        }

        private void btnSanitariosAD_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("sanitarios", "di_inf_areas_comunes");
        }

        private void btnEstacionamiento_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("estacionamiento", "di_inf_areas_comunes");
        }

        private void btnOficinas_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("oficinas", "di_inf_areas_comunes");
        }

        private void btnHerramientas_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("herramientas", "di_inf_areas_comunes");
        }

        private void btnCargaAD_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga", "di_inf_areas_comunes");
        }

        private void btnOtros1AD_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("otros1", "di_inf_areas_comunes");
        }

        private void btnOtros2AD_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("otros2", "di_inf_areas_comunes");
        }

        private void tabContenidoEnvasado_Click(object sender, EventArgs e)
        {
            switch (tabContenidoEnvasado.SelectedTab.Text.Trim())
            {
                case "Datos Generales":
                    Console.WriteLine("Datos Generales envasado");
                    cargar_instalaciones();
                    break;
                case "Cumplimientos":
                    Console.WriteLine("Cumplimientos");
                    cargar_cumplimientos();
                    break;
                case "NOM 070 P1":
                    cargar_070();
                    Console.WriteLine("NOM 070 P1");
                    break;
                case "NOM 070 P2":
                    cargar_nmx();
                    Console.WriteLine("NOM 070 P2");
                    break;
                case "Almacen de granel o maduración":
                    cargar_almacen_envasado();
                    cargar_tabla_almacen_envasado();
                    Console.WriteLine("Fermentación");
                    break;
                case "Linea de envasado":
                    cargar_linea_envasado();
                    cargar_tabla_linea_envasado();
                    Console.WriteLine("Destilación");
                    break;
                case "Linea envasado bebidas con":
                    cargar_linea_envasado_bc();
                    cargar_tabla_linea_envasado_bc();
                    Console.WriteLine("Linea envasado bebidas con");
                    break;
                case "Evidencia fotografica":
                    cargar_fotos_envasado();
                    Console.WriteLine("Evidencia Fotografica");
                    break;
                case "Fotos bebidas con":
                    cargar_fotos_envasado_bc();
                    Console.WriteLine("Fotos bebidas con");
                    break;
                default:
                    MessageBox.Show(tabContenidoEnvasado.SelectedTab.Text.Trim());
                    break;
            }
        }
        private void cargar_cumplimientos()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `observacion1`, `cumple1`, `observacion2`, `cumple2`, `observacion3`, `cumple3`, `observacion4`, `cumple4`, `observacion5`, `id_solicitud`, `fecha`, observacionextra FROM sinca.`di_inf_cumplimientos` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        cbCumplimientoExtra.Text = row["observacionextra"].ToString();
                        txtOCumplimiento1.Text = row["observacion1"].ToString();
                        cbCumplimiento1.Text = row["cumple1"].ToString();
                        txtOCumplimiento2.Text = row["observacion2"].ToString();
                        cbCumplimiento2.Text = row["cumple2"].ToString();
                        txtOCumplimiento3.Text = row["observacion3"].ToString();
                        cbCumplimiento3.Text = row["cumple3"].ToString();
                        txtOCumplimiento4.Text = row["observacion4"].ToString();
                        cbCumplimiento4.Text = row["cumple4"].ToString();
                        txtOCumplimiento5.Text = row["observacion5"].ToString();

                        id_cumplimientos = int.Parse(row["id"].ToString());
                        imgCumplimientos.Show();
                    }
                }
                else
                {
                    imgCumplimientos.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNom070_Click(object sender, EventArgs e)
        {
            try
            {

                if (id_nom070 == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_nom070`(`id_solicitud`, `cumple1`, `observaciones1`, `cumple2`, `observaciones2`," +
                        " `cumple3`, `observaciones3`, `cumple4`, `observaciones4`, `cumple5`, `observaciones5`, `cumple6`,observaciones6, `cumple7`, `observaciones7`) " +
                        "VALUES ('" + di_solicitud + "','" + cbNom1.Text + "','" + txtONom1.Text + "','" + cbNom2.Text + "','" + txtONom2.Text + "','" + cbNom3.Text + "','" + txtONom3.Text + "'," +
                        "'" + cbNom4.Text + "','" + txtONom4.Text + "','" + cbNom5.Text + "','" + txtONom5.Text + "','" + cbNom6.Text + "','" + txtONom6.Text + "','" + cbNom7.Text + "','" + txtONom7.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_nom070 = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_nom070 SET cumple1='" + cbNom1.Text + "',cumple2='" + cbNom2.Text + "',cumple3='" + cbNom3.Text + "'," +
                        "cumple4='" + cbNom4.Text + "',cumple5='" + cbNom5.Text + "',cumple6='" + cbNom6.Text + "',cumple7='" + cbNom7.Text + "',observaciones1='" + txtONom1.Text + "'," +
                        "observaciones2='" + txtONom2.Text + "',observaciones3='" + txtONom3.Text + "',observaciones4='" + txtONom4.Text + "',observaciones5='" + txtONom5.Text + "'," +
                        "observaciones6='" + txtONom6.Text + "',observaciones7='" + txtONom7.Text + "' WHERE id='" + id_nom070 + "'") == "Error")
                    {
                        return;
                    }


                }
                cargar_070();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_070()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `cumple1`, `observaciones1`, `cumple2`, `observaciones2`, `cumple3`, `observaciones3`, " +
                    "`cumple4`, `observaciones4`, `cumple5`, `observaciones5`,observaciones6, `cumple6`, `observaciones7`, `cumple7`, `fecha` FROM sinca.`di_inf_nom070`  WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        cbNom1.Text = row["cumple1"].ToString();
                        txtONom1.Text = row["observaciones1"].ToString();
                        cbNom2.Text = row["cumple2"].ToString();
                        txtONom2.Text = row["observaciones2"].ToString();
                        cbNom3.Text = row["cumple3"].ToString();
                        txtONom3.Text = row["observaciones3"].ToString();
                        cbNom4.Text = row["cumple4"].ToString();
                        txtONom4.Text = row["observaciones4"].ToString();
                        cbNom5.Text = row["cumple5"].ToString();
                        txtONom5.Text = row["observaciones5"].ToString();
                        cbNom6.Text = row["cumple6"].ToString();
                        txtONom6.Text = row["observaciones6"].ToString();
                        cbNom7.Text = row["cumple7"].ToString();
                        txtONom7.Text = row["observaciones7"].ToString();

                        id_nom070 = int.Parse(row["id"].ToString());
                        imgNom070.Show();
                    }
                }
                else
                {
                    imgNom070.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvDestilacion.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_destilacion(dgvDestilacion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_destilacion(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_destilacion` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_destilacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarCoccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_coccion`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + cbTipoCoccion.Text + "', '" + txtCantidadCoccion.Text + "', '" + txtCapacidadCoccion.Text + "', '" + txtCaracteristicasCoccion.Text + "', '" + cbCondicionCoccion.Text + "')") == "Error")
                {
                    return;
                }
                cbTipoCoccion.Text = "";
                txtCantidadCoccion.Text = "";
                txtCapacidadCoccion.Text = "";
                txtCaracteristicasCoccion.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_coccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void btnAgregarMolienda_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_molienda`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + cbTipoMolienda.Text + "', '" + txtCantidadMolienda.Text + "', '" + txtCapacidadMolienda.Text + "', '" + txtCaracteristicasMolienda.Text + "', '" + cbCondicionMolienda.Text + "')") == "Error")
                {
                    return;
                }
                cbTipoMolienda.Text = "";
                txtCantidadMolienda.Text = "";
                txtCapacidadMolienda.Text = "";
                txtCaracteristicasMolienda.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_molienda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void btnAgregarFermentacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_fermentacion`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + cbTipoFermantacion.Text + "', '" + txtCantidadFermentacion.Text + "', '" + txtCapacidadFermentacion.Text + "', '" + txtCaracteristicasFermentacion.Text + "', '" + cbCondicionFermentacion.Text + "')") == "Error")
                {
                    return;
                }
                cbTipoFermantacion.Text = "";
                txtCantidadFermentacion.Text = "";
                txtCapacidadFermentacion.Text = "";
                txtCaracteristicasFermentacion.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_fermentacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void btnAgregarDestilacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_destilacion`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + cbTipoDestilacion.Text + "', '" + txtCantidadDestilacion.Text + "', '" + txtCapacidadDestilacion.Text + "', '" + txtCaracteristicasDestilacion.Text + "', '" + cbCondicionDestilacion.Text + "')") == "Error")
                {
                    return;
                }
                cbTipoDestilacion.Text = "";
                txtCantidadDestilacion.Text = "";
                txtCapacidadDestilacion.Text = "";
                txtCaracteristicasDestilacion.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_destilacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void dgvCoccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvCoccion.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_coccion(dgvCoccion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_coccion(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_coccion` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_coccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void dgvMolienda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvMolienda.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_molienda(dgvMolienda.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_molienda(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_molienda` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_molienda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void dgvFermentacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvFermentacion.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_fermentacion(dgvFermentacion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_fermentacion(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_fermentacion` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_fermentacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }




        private void cargar_nmx()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `cumple1`, `observacion1`, `cumple2`, `observacion2`, `cumple3`, `observacion3`," +
                    " `cumple4`, `observacion4`, `cumple5`, `observacion5`, `fecha` FROM sinca.`di_inf_nom070p2` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        cbNMX1.Text = row["cumple1"].ToString();
                        txtONMX1.Text = row["observacion1"].ToString();
                        cbNMX2.Text = row["cumple2"].ToString();
                        txtONMX2.Text = row["observacion2"].ToString();
                        cbNMX3.Text = row["cumple3"].ToString();
                        txtONMX3.Text = row["observacion3"].ToString();
                        cbNMX4.Text = row["cumple4"].ToString();
                        txtONMX4.Text = row["observacion4"].ToString();
                        cbNMX5.Text = row["cumple5"].ToString();
                        txtONMX5.Text = row["observacion5"].ToString();

                        id_nmx = int.Parse(row["id"].ToString());
                        imgNmx052.Show();
                    }
                }
                else
                {
                    imgNmx052.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarAM_Click(object sender, EventArgs e)
        {
            try
            {
                float area = float.Parse(txtLargoAM.Text) * float.Parse(txtAnchoAM.Text);
                if (id_mad_almacen == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_almacen_mad`(`id_solicitud`, `largo`, `ancho`, `area`, `descripcion`)" +
                        "VALUES (" + di_solicitud + ", '" + txtLargoAM.Text + "', '" + txtAnchoAM.Text + "', '" + area + "', '" + txtDescAM.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_mad_almacen = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));
                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_almacen_mad SET largo='" + txtLargoAM.Text + "',ancho='" + txtAnchoAM.Text + "',area='" + area + "'," +
                        "descripcion='" + txtDescAM.Text + "' WHERE id='" + id_mad_almacen + "'") == "Error")
                    {
                        return;
                    }
                }
                cargar_maduracion_almacen();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_almacen_mad`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + txtTipoAM.Text + "', '" + txtCantidadAM.Text + "', '" + txtCapacidadAM.Text + "', '" + txtCaracteristicasAM.Text + "', '" + cbCondicionAM.Text + "')") == "Error")
                {
                    return;
                }
                txtTipoAM.Text = "";
                txtCantidadAM.Text = "";
                txtCapacidadAM.Text = "";
                txtCaracteristicasAM.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_almacen_mad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEspecie_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_especies_empleadas`(`especie`, `porcentaje`, `maduro`, di_solicitud) " +
                    "VALUES ('" + txtEspecie1.Text + "', '" + txtPorcentaje1.Text + "', '" + cbMaduro1.Text + "', '" + di_solicitud + "')") == "Error")
                {
                    return;
                }
                txtEspecie1.Text = "";
                txtPorcentaje1.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_especies();
                //cargar_recepcion_tabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void dgvEspecieEmpleada_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvEspecieEmpleada.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_especie(dgvEspecieEmpleada.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarga1FA_Click_1(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga1", "di_inf_fotos_almacen");
        }

        private void btnCarga3FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga3", "di_inf_fotos_almacen");
        }

        private void btnCarga4FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("carga4", "di_inf_fotos_almacen");
        }

        private void cbNom3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFolioUnico_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel68_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMaduracionE_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maduracion", "di_inf_fotos_envasado");
        }

        private void btnAreaGranelE_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("granel", "di_inf_fotos_envasado");
        }

        private void btnAlmacenA1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen1", "di_inf_fotos_almacen");
        }

        private void btnAlmacenA2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen2", "di_inf_fotos_almacen");
        }

        private void btnAlmacenA3_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen3", "di_inf_fotos_almacen");
        }

        private void btnAlmacenA4_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen4", "di_inf_fotos_almacen");
        }

        private void btnGranelA1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("granel1", "di_inf_fotos_almacen");
        }

        private void btnGranelA2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("granel2", "di_inf_fotos_almacen");
        }

        private void btnGranelA3_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("granel3", "di_inf_fotos_almacen");
        }

        private void btnGranelA4_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("granel4", "di_inf_fotos_almacen");
        }

        private void btnInfraestructuraA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("infraestructura", "di_inf_fotos_almacen");
        }

        private void btnLineaEnvaado_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("linea", "di_inf_fotos_envasado");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("vista_interior", "di_inf_fotos_produccion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("vista_exterior", "di_inf_fotos_produccion");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maduracion1", "di_inf_fotos_produccion");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maduracion2", "di_inf_fotos_produccion");
        }

        private void tabCaratula_Click(object sender, EventArgs e)
        {

        }

        private void btnNmx052_Click(object sender, EventArgs e)
        {
            try
            {

                if (id_nmx == 0)
                {

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_nom070p2`(`id_solicitud`, `cumple1`, `observacion1`, `cumple2`, `observacion2`, `cumple3`, " +
                        "`observacion3`, `cumple4`, `observacion4`, `cumple5`, `observacion5`) " +
                        "VALUES ('" + di_solicitud + "', '" + cbNMX1.Text + "', '" + txtONMX1.Text + "', '" + cbNMX2.Text + "', '" + txtONMX2.Text + "', '" + cbNMX3.Text + "', '" + txtONMX3.Text + "', '" + cbNMX4.Text + "', '" + txtONMX4.Text + "', '" + cbNMX5.Text + "', '" + txtONMX5.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_nmx = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_nom070p2 SET cumple1='" + cbNMX1.Text + "',cumple2='" + cbNMX2.Text + "',cumple3='" + cbNMX3.Text + "'," +
                        "cumple4='" + cbNMX4.Text + "',cumple5='" + cbNMX5.Text + "',observacion1='" + txtONMX1.Text + "',observacion2='" + txtONMX2.Text + "',observacion3='" + txtONMX3.Text + "',observacion4='" + txtONMX4.Text + "',observacion5='" + txtONMX5.Text + "'  WHERE id='" + id_nmx + "'") == "Error")
                    {
                        return;
                    }
                }
                cargar_nmx();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlmacenEnvasado_Click(object sender, EventArgs e)
        {
            try
            {

                float area = float.Parse(txtLargoAE.Text) * float.Parse(txtAnchoAE.Text);

                if (id_almacen_envasado == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_granel_envasado`(`id_solicitud`,`largo`, `ancho`, `area`, `descripcion`) " +
                        "VALUES (" + di_solicitud + ", '" + txtLargoAE.Text + "', '" + txtAnchoAE.Text + "', '" + area + "', '" + txtDescripcionAE.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_almacen_envasado = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_granel_envasado SET largo='" + txtLargoAE.Text + "',ancho='" + txtAnchoAE.Text + "',area='" + area + "',descripcion='" + txtDescripcionAE.Text + "' WHERE id='" + id_almacen_envasado + "'") == "Error")
                    {
                        return;
                    }

                }
                cargar_almacen_envasado();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatosAM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvDatosAM.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        eliminar_registro_almacen_mad(dgvDatosAM.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerminado3FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("terminado3", "di_inf_fotos_almacen");
        }

        private void btnMaduracion3FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maduracion3", "di_inf_fotos_almacen");
        }

        private void btnMaduracion4FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("maduracion4", "di_inf_fotos_almacen");
        }

        private void btnRecipientes3FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("recipiente3", "di_inf_fotos_almacen");
        }

        private void btnRecipientes4FA_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("recipiente4", "di_inf_fotos_almacen");
        }

        private void btnEAlmacenAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_granel_envasado`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + txtEAlmacenTipo.Text + "', '" + txtEAlmacenCantidad.Text + "', '" + txtEAlmacenCapacidad.Text + "', '" + txtEAlmacenCaracteristicas.Text + "', '" + cbEAlmacenCondicion.Text + "')") == "Error")
                {
                    return;
                }
                txtEAlmacenTipo.Text = "";
                txtEAlmacenCantidad.Text = "";
                txtEAlmacenCapacidad.Text = "";
                txtEAlmacenCaracteristicas.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_almacen_envasado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void cargar_tabla_almacen_envasado()
        {
            try
            {
                dtsAlmacenEnvasado = new DataSet();
                dtsAlmacenEnvasado.Tables.Add("ALMACEN_ENVASADO");
                dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Columns.Add("ID", Type.GetType("System.String"));
                dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvAlmacenE.DataSource = dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"];
                dgvAlmacenE.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_granel_envasado` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                Console.WriteLine("SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_granel_produccion` WHERE `id_solicitud`= '" + di_solicitud + "'");
                // dtsDatosRecepcion.Tables["RECEPCION"].Rows.Clear(); DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsAlmacenEnvasado.Tables["ALMACEN_ENVASADO"].Rows.Add(fila);
                }
                /*DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Action";
                buttonColumn.Name = "Delete";
                buttonColumn.Text = "Eliminar";
                buttonColumn.UseColumnTextForButtonValue = true; // Set to true to use Text property for the button
                dvgRecepcion.Columns.Add(buttonColumn);*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_almacen_envasado()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `largo`, `ancho`, `area`, `descripcion`, `fecha`, `id_solicitud` FROM sinca.`di_inf_granel_envasado` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoAE.Text = row["largo"].ToString();
                        txtAnchoAE.Text = row["ancho"].ToString();
                        txtDescripcionAE.Text = row["descripcion"].ToString();

                        id_almacen_envasado = int.Parse(row["id"].ToString());
                        imgAlmacenEnvasado.Show();
                    }
                }
                else
                {
                    imgAlmacenEnvasado.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_almacen_envasado(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_granel_envasado` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_almacen_envasado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void dgvAlmacenE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvAlmacenE.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //MessageBox.Show(dvgRecepcion.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        eliminar_almacen_envasado(dgvAlmacenE.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLinea_Click(object sender, EventArgs e)
        {
            try
            {

                float area = float.Parse(txtLargoEE.Text) * float.Parse(txtAnchoEE.Text);

                if (id_linea_envasado == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_linea_envasado`(`id_solicitud`, `largo`, `ancho`, `area`, `descripcion`, `lavado`, `llenado`, `taponado`, `comentarios`)" +
                        "VALUES (" + di_solicitud + ", '" + txtLargoEE.Text + "', '" + txtAnchoEE.Text + "', '" + area + "', '" + txtDescripcionEE.Text + "'," +
                        " '" + txtMetodo1EE.Text + "', '" + txtMetodo2EE.Text + "', '" + txtMetodo3EE.Text + "', '" + txtMetodo4EE.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_linea_envasado = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));

                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_linea_envasado SET largo='" + txtLargoEE.Text + "',ancho='" + txtAnchoEE.Text + "',area='" + area + "'," +
                        "descripcion='" + txtDescripcionEE.Text + "', lavado='" + txtMetodo1EE.Text + "', llenado='" + txtMetodo2EE.Text + "', taponado='" + txtMetodo3EE.Text + "', comentarios='" + txtMetodo4EE.Text + "' WHERE id='" + id_linea_envasado + "'") == "Error")
                    {
                        return;
                    }


                }
                cargar_linea_envasado();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_linea_envasado()
        {
            try
            {
                DataSet Datos = new DataSet();
                Console.WriteLine("SELECT `id`, `largo`, `ancho`, `area`, `descripcion`, `lavado`, `llenado`, `taponado`, `comentarios`, `fecha`, `id_solicitud` FROM sinca.`di_inf_linea_envasado` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `largo`, `ancho`, `area`, `descripcion`, `lavado`, `llenado`, `taponado`, `comentarios`, `fecha`, `id_solicitud` FROM sinca.`di_inf_linea_envasado` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoEE.Text = row["largo"].ToString();
                        txtAnchoEE.Text = row["ancho"].ToString();
                        txtDescripcionEE.Text = row["descripcion"].ToString();
                        txtMetodo1EE.Text = row["lavado"].ToString();
                        txtMetodo2EE.Text = row["llenado"].ToString();
                        txtMetodo3EE.Text = row["taponado"].ToString();
                        txtMetodo4EE.Text = row["comentarios"].ToString();

                        id_linea_envasado = int.Parse(row["id"].ToString());
                        imgLinea.Show();
                    }
                }
                else
                {
                    imgLinea.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_tabla_linea_envasado()
        {
            try
            {
                dtsLineaEnvasado = new DataSet();
                dtsLineaEnvasado.Tables.Add("LINEA_ENVASADO");
                dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Columns.Add("ID", Type.GetType("System.String"));
                dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvEE.DataSource = dtsLineaEnvasado.Tables["LINEA_ENVASADO"];
                dgvEE.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`,`tipo`,`cantidad`,`capacidad`,`caracteristicas`,`condicion` FROM sinca.`di_inf_tabla_linea_envasado` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsLineaEnvasado.Tables["LINEA_ENVASADO"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsLineaEnvasado.Tables["LINEA_ENVASADO"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarEE_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_linea_envasado`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + txtTipoEE.Text + "', '" + txtCantidadEE.Text + "', '" + txtCapacidadEE.Text + "', '" + txtCaracteristicasEE.Text + "', '" + rbCondicionEE.Text + "')") == "Error")
                {
                    return;
                }
                txtTipoEE.Text = "";
                txtCantidadEE.Text = "";
                txtCapacidadEE.Text = "";
                txtCaracteristicasEE.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_linea_envasado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void dgvEE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvEE.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        eliminar_linea_envasado(dgvEE.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_linea_envasado(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_linea_envasado` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_linea_envasado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void eliminar_linea_envasado_bc(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_linea_envasado_bc` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_linea_envasado_bc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void cargar_tabla_linea_envasado_bc()
        {
            try
            {
                dtsLineaEnvasadoBebidas = new DataSet();
                dtsLineaEnvasadoBebidas.Tables.Add("LINEA_ENVASADOB");
                dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Columns.Add("ID", Type.GetType("System.String"));
                dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvEEB.DataSource = dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"];
                dgvEEB.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`, `fecha` FROM sinca.`di_inf_tabla_linea_envasado_bc` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsLineaEnvasadoBebidas.Tables["LINEA_ENVASADOB"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLineaBebidas_Click(object sender, EventArgs e)
        {
            try
            {
                float area = float.Parse(txtLargoEEB.Text) * float.Parse(txtAnchoEEB.Text);
                if (id_linea_envasado_bc == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_linea_envasado_bc`(`id_solicitud`, `largo`, `ancho`, `area`, `descripcion`, `lavado`, `llenado`, `taponado`, `comentarios`)" +
                        "VALUES (" + di_solicitud + ", '" + txtLargoEEB.Text + "', '" + txtAnchoEEB.Text + "', '" + area + "', '" + txtDescripcionEEB.Text + "'," +
                        " '" + txtMetodo1EEB.Text + "', '" + txtMetodo2EEB.Text + "', '" + txtMetodo3EEB.Text + "', '" + txtMetodo4EEB.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_linea_envasado_bc = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));
                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_linea_envasado_bc SET largo='" + txtLargoEEB.Text + "',ancho='" + txtAnchoEEB.Text + "',area='" + area + "'," +
                        "descripcion='" + txtDescripcionEEB.Text + "', lavado='" + txtMetodo1EEB.Text + "', llenado='" + txtMetodo2EEB.Text + "', taponado='" + txtMetodo3EEB.Text + "', comentarios='" + txtMetodo4EEB.Text + "' WHERE id='" + id_linea_envasado_bc + "'") == "Error")
                    {
                        return;
                    }
                }
                cargar_linea_envasado_bc();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarEEB_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_linea_envasado_bc`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + txtTipoEEB.Text + "', '" + txtCantidadEEB.Text + "', '" + txtCapacidadEEB.Text + "', '" + txtCaracteristicasEEB.Text + "', '" + cbCondicionEEB.Text + "')") == "Error")
                {
                    return;
                }
                txtTipoEEB.Text = "";
                txtCantidadEEB.Text = "";
                txtCapacidadEEB.Text = "";
                txtCaracteristicasEEB.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_linea_envasado_bc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void btnRecepcion2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("recepcion2", "di_inf_fotos_produccion");
        }

        private void btnCoccion1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("coccion1", "di_inf_fotos_produccion");
        }

        private void btnCoccion2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("coccion2", "di_inf_fotos_produccion");
        }

        private void btnMolienda1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("molienda1", "di_inf_fotos_produccion");
        }

        private void btnMolienda2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("molienda2", "di_inf_fotos_produccion");
        }

        private void btnFermentacion1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("fermentacion1", "di_inf_fotos_produccion");
        }

        private void btnFermentacion2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("fermentacion2", "di_inf_fotos_produccion");
        }

        private void btnDestilacion1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("destilacion1", "di_inf_fotos_produccion");
        }

        private void btnDestilacion2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("destilacion2", "di_inf_fotos_produccion");
        }

        private void btnAlmacen1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen1", "di_inf_fotos_produccion");
        }

        private void btnAlmacen2_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen2", "di_inf_fotos_produccion");
        }

        private void btnProductoEGranel_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("almacen_granel", "di_inf_fotos_envasado");
        }

        private void dgvEEB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvEEB.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        eliminar_linea_envasado_bc(dgvEEB.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_linea_envasado_bc()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `largo`, `ancho`, `area`, `descripcion`, `lavado`, `llenado`, `taponado`, `comentarios`, `fecha`, `id_solicitud` FROM sinca.`di_inf_linea_envasado_bc` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoEEB.Text = row["largo"].ToString();
                        txtAnchoEEB.Text = row["ancho"].ToString();
                        txtDescripcionEEB.Text = row["descripcion"].ToString();
                        txtMetodo1EEB.Text = row["lavado"].ToString();
                        txtMetodo2EEB.Text = row["llenado"].ToString();
                        txtMetodo3EEB.Text = row["taponado"].ToString();
                        txtMetodo4EEB.Text = row["comentarios"].ToString();

                        id_linea_envasado_bc = int.Parse(row["id"].ToString());
                        imgLineaBebidas.Show();
                    }
                }
                else
                {
                    imgLineaBebidas.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAreaI_Click(object sender, EventArgs e)
        {
            try
            {
                float area = float.Parse(txtLargoAI.Text) * float.Parse(txtAnchoAI.Text);
                if (id_infraestructura_almacen == 0)
                {
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_almacen_pt`(`id_solicitud`, `largo`, `ancho`, `area`, `descripcion`)" +
                        "VALUES (" + di_solicitud + ", '" + txtLargoAI.Text + "', '" + txtAnchoAI.Text + "', '" + area + "', '" + txtDescripcionAI.Text + "')") == "Error")
                    {
                        return;
                    }
                    id_infraestructura_almacen = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT LAST_INSERT_ID();"));
                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_inf_almacen_pt SET largo='" + txtLargoAI.Text + "',ancho='" + txtAnchoAI.Text + "',area='" + area + "'," +
                        "descripcion='" + txtDescripcionAI.Text + "' WHERE id='" + id_infraestructura_almacen + "'") == "Error")
                    {
                        return;
                    }
                }
                cargar_infraestructura_almacen();
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAgregarAI_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO sinca.`di_inf_tabla_almacen_pt`( `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`) " +
                    "VALUES ('" + di_solicitud + "', '" + txtTipoAI.Text + "', '" + txtCantidadAI.Text + "', '" + txtCapacidadAI.Text + "', '" + txtCaracteristicasAI.Text + "', '" + txtCondicionAI.Text + "')") == "Error")
                {
                    return;
                }
                txtTipoAI.Text = "";
                txtCantidadAI.Text = "";
                txtCapacidadAI.Text = "";
                txtCaracteristicasAI.Text = "";
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar_tabla_almacen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar " + ex);
            }
        }

        private void cargar_tabla_almacen_mad()
        {
            try
            {
                dtsAlmacenMad = new DataSet();
                dtsAlmacenMad.Tables.Add("ALMACEN_MAD");
                dtsAlmacenMad.Tables["ALMACEN_MAD"].Columns.Add("ID", Type.GetType("System.String"));
                dtsAlmacenMad.Tables["ALMACEN_MAD"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsAlmacenMad.Tables["ALMACEN_MAD"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsAlmacenMad.Tables["ALMACEN_MAD"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsAlmacenMad.Tables["ALMACEN_MAD"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsAlmacenMad.Tables["ALMACEN_MAD"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvDatosAM.DataSource = dtsAlmacenMad.Tables["ALMACEN_MAD"];
                dgvDatosAM.Columns[0].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`, `fecha` FROM sinca.`di_inf_tabla_almacen_mad` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsAlmacenMad.Tables["ALMACEN_MAD"].NewRow();
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsAlmacenMad.Tables["ALMACEN_MAD"].Rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_tabla_almacen()
        {
            try
            {
                dtsAlmacen = new DataSet();
                dtsAlmacen.Tables.Add("ALMACEN");
                dtsAlmacen.Tables["ALMACEN"].Columns.Add("TIPO", Type.GetType("System.String"));
                dtsAlmacen.Tables["ALMACEN"].Columns.Add("ID", Type.GetType("System.String"));
                dtsAlmacen.Tables["ALMACEN"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
                dtsAlmacen.Tables["ALMACEN"].Columns.Add("CAPACIDAD", Type.GetType("System.String"));
                dtsAlmacen.Tables["ALMACEN"].Columns.Add("CARACTERISTICAS", Type.GetType("System.String"));
                dtsAlmacen.Tables["ALMACEN"].Columns.Add("CONDICION", Type.GetType("System.String"));
                dtsAlmacen.Tables["ALMACEN"].Columns.Add("ELIMINAR", Type.GetType("System.Byte[]"));
                dgvAI.DataSource = dtsAlmacen.Tables["ALMACEN"];
                dgvAI.Columns[1].Visible = false;

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `tipo`, `cantidad`, `capacidad`, `caracteristicas`, `condicion`, `fecha` FROM sinca.`di_inf_tabla_almacen_pt` WHERE `id_solicitud`= '" + di_solicitud + "'");
                DataRow fila;
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    fila = dtsAlmacen.Tables["ALMACEN"].NewRow();
                    fila["TIPO"] = Convert.ToString(row["tipo"]);
                    fila["ID"] = Convert.ToString(row["id"]);
                    fila["CANTIDAD"] = Convert.ToString(row["cantidad"]);
                    fila["CAPACIDAD"] = Convert.ToString(row["capacidad"]);
                    fila["CARACTERISTICAS"] = Convert.ToString(row["caracteristicas"]);
                    fila["CONDICION"] = Convert.ToString(row["condicion"]);
                    fila["ELIMINAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    dtsAlmacen.Tables["ALMACEN"].Rows.Add(fila);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void eliminar_registro_almacen(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_almacen_pt` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_almacen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void eliminar_registro_almacen_mad(string id)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("delete from sinca.`di_inf_tabla_almacen_mad` WHERE id='" + id + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Eliminado");
                cargar_tabla_almacen_mad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar " + ex);
            }

        }

        private void dgvAI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dgvAI.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    if (MessageBox.Show("¿Estas seguro de eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        eliminar_registro_almacen(dgvAI.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabsAlmacen_Click(object sender, EventArgs e)
        {
            switch (tabsAlmacen.SelectedTab.Text.Trim())
            {
                case "Datos Generales":
                    Console.WriteLine("Datos Generales Almacen");
                    cargar_instalaciones();
                    break;
                case "Producto Terminado":
                    Console.WriteLine("Pro term");
                    cargar_infraestructura_almacen();
                    cargar_tabla_almacen();
                    break;
                case "Maduracion o Granel":
                    Console.WriteLine("granel");
                    cargar_maduracion_almacen();
                    cargar_tabla_almacen_mad();
                    break;
                case "Evidencia fotografica":
                    //cargar_evidencia_almacen();
                    cargar_fotos_almacen();
                    Console.WriteLine("Evidencia fotografica");
                    break;
                case "Evidencia Fotografica 2":
                    //cargar_evidencia_almacen();
                    cargar_fotos_almacen();
                    Console.WriteLine("Evidencia fotografica");
                    break;
                default:
                    MessageBox.Show(tabsAlmacen.SelectedTab.Text.Trim());
                    break;
            }
        }
        private void cargar_infraestructura_almacen()
        {
            try
            {
                DataSet Datos = new DataSet();
               ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `largo`, `ancho`, `area`, `descripcion`, `fecha`, `id_solicitud` FROM sinca.`di_inf_almacen_pt` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoAI.Text = row["largo"].ToString();
                        txtAnchoAI.Text = row["ancho"].ToString();
                        txtDescripcionAI.Text = row["descripcion"].ToString();

                        id_infraestructura_almacen = int.Parse(row["id"].ToString());
                        imgAlmacenI.Show();
                    }
                }
                else
                {
                    imgAlmacenI.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cargar_maduracion_almacen()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `largo`, `ancho`, `area`, `descripcion`, `fecha`, `id_solicitud` FROM sinca.`di_inf_almacen_mad` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        txtLargoAM.Text = row["largo"].ToString();
                        txtAnchoAM.Text = row["ancho"].ToString();
                        txtDescAM.Text = row["descripcion"].ToString();

                        id_mad_almacen = int.Parse(row["id"].ToString());
                        pbAlmacenAM.Show();
                    }
                }
                else
                {
                    pbAlmacenAM.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cargar_fotos_produccion(int sol, String cliente)
        {
            try
            {
                DataSet Datos = new DataSet();
               ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `maestro`, `recepcion1`, `recepcion2`, `coccion1`, `coccion2`, `fermentacion1`, `fermentacion2`, `destilacion1`, `destilacion2`, `almacen1`, `almacen2`, `fecha`, molienda1, molienda2,vista_interior,vista_exterior,maduracion1, maduracion2 FROM sinca.`di_inf_fotos_produccion` WHERE id_solicitud='" + sol + "' LIMIT 1");

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        //Console.WriteLine("C:/xampp/htdocs/doc/img/" + cliente + "/C9990281.jpeg");
                        //pbMaestro.Image = System.Drawing.Image.FromFile("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["maestro"].ToString());
                        if (row["maestro"] != null && row["maestro"].ToString() != "") pbMaestro.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["maestro"].ToString());
                        if (row["recepcion1"] != null && row["recepcion1"].ToString() != "") pbRecepcion1.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["recepcion1"].ToString());
                        if (row["recepcion2"] != null && row["recepcion2"].ToString() != "") pbRecepcion2.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["recepcion2"].ToString());
                        if (row["coccion1"] != null && row["coccion1"].ToString() != "") pbCoccion1.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["coccion1"].ToString());
                        if (row["coccion2"] != null && row["coccion2"].ToString() != "") pbCoccion2.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["coccion2"].ToString());
                        if (row["fermentacion1"] != null && row["fermentacion1"].ToString() != "") pbFermentacion1.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["fermentacion1"].ToString());
                        if (row["fermentacion2"] != null && row["fermentacion2"].ToString() != "") pbFermentacion2.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["fermentacion2"].ToString());
                        if (row["destilacion1"] != null && row["destilacion1"].ToString() != "") pbDestilacion1.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["destilacion1"].ToString());
                        if (row["destilacion2"] != null && row["destilacion2"].ToString() != "") pbDestilacion2.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["destilacion2"].ToString());
                        if (row["almacen1"] != null && row["almacen1"].ToString() != "") pbAlmacen1.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["almacen1"].ToString());
                        if (row["almacen2"] != null && row["almacen2"].ToString() != "") pbAlmacen2.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["almacen2"].ToString());
                        if (row["molienda1"] != null && row["molienda1"].ToString() != "") pbMolienda1.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["molienda1"].ToString());
                        if (row["molienda2"] != null && row["molienda2"].ToString() != "") pbMolienda2.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["molienda2"].ToString());

                        if (row["vista_interior"] != null && row["vista_interior"].ToString() != "") pbInteriorProduccion.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["vista_interior"].ToString());
                        if (row["vista_exterior"] != null && row["vista_exterior"].ToString() != "") pbExterior_produccion.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["vista_exterior"].ToString());
                        if (row["maduracion1"] != null && row["maduracion1"].ToString() != "") pbMaduracion1Produccion.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["maduracion1"].ToString());
                        if (row["maduracion2"] != null && row["maduracion2"].ToString() != "") pbMAduracion2Produccion.Load("C:/xampp/htdocs/doc/img/" + cliente + "/" + row["maduracion2"].ToString());

                        //pbMaestro.Image = System.Drawing.Image.FromFile("C:/xampp/htdocs/doc/img/" + no_cliente + "/C9990281.jpeg");
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargar_fotos_envasado()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`,maduracion,granel, `almacen_granel`, `lavado`, `llenado`, `taponado`, `general_interior`, `general_exterior`, `almacen_terminado`, `marcas`, `almacen_insumos`, `otros`, `fecha`,linea FROM sinca.`di_inf_fotos_envasado` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (row["almacen_granel"] != null && row["almacen_granel"].ToString() != "") pbEProductoGranel.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen_granel"].ToString());
                        if (row["lavado"] != null && row["lavado"].ToString() != "") pbLavadoBotellas.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["lavado"].ToString());
                        if (row["llenado"] != null && row["llenado"].ToString() != "") pbLlenado.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["llenado"].ToString());
                        if (row["taponado"] != null && row["taponado"].ToString() != "") pbTaponado.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["taponado"].ToString());
                        if (row["general_interior"] != null && row["general_interior"].ToString() != "") pbVistaInteriorE.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["general_interior"].ToString());
                        if (row["general_exterior"] != null && row["general_exterior"].ToString() != "") pbVistaExteriorE.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["general_exterior"].ToString());
                        if (row["almacen_terminado"] != null && row["almacen_terminado"].ToString() != "") pbAlmacenPT.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen_terminado"].ToString());
                        if (row["marcas"] != null && row["marcas"].ToString() != "") pbMarcas.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["marcas"].ToString());
                        if (row["almacen_insumos"] != null && row["almacen_insumos"].ToString() != "") pbAlmacenInsumos.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen_insumos"].ToString());
                        if (row["otros"] != null && row["otros"].ToString() != "") pbOtrosE.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["otros"].ToString());
                        if (row["maduracion"] != null && row["maduracion"].ToString() != "") pbMaduracionE.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["maduracion"].ToString());
                        if (row["granel"] != null && row["granel"].ToString() != "") pbAreaGranelE.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["granel"].ToString());
                        if (row["linea"] != null && row["linea"].ToString() != "") pbLineaEnvasado.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["linea"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargar_fotos_envasado_bc()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `almacen_granel`, `lavado`, `llenado`, `taponado`, `linea`, `marca`, `almacen_insumos`, `formulacion`, `fecha` FROM sinca.`di_inf_fotos_envasado_bc`  WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (row["almacen_granel"] != null && row["almacen_granel"].ToString() != "") pbAlmacenGranelB.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen_granel"].ToString());
                        if (row["lavado"] != null && row["lavado"].ToString() != "") pbLavadoB.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["lavado"].ToString());
                        if (row["llenado"] != null && row["llenado"].ToString() != "") pbLlenadoB.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["llenado"].ToString());
                        if (row["taponado"] != null && row["taponado"].ToString() != "") pbTaponadoB.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["taponado"].ToString());
                        if (row["linea"] != null && row["linea"].ToString() != "") pbEnvasadoB.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["linea"].ToString());
                        if (row["marca"] != null && row["marca"].ToString() != "") pbMarcasB.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["marca"].ToString());
                        if (row["almacen_insumos"] != null && row["almacen_insumos"].ToString() != "") pbSaborizantes.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen_insumos"].ToString());
                        if (row["formulacion"] != null && row["formulacion"].ToString() != "") pbFormulacion.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["formulacion"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargar_fotos_almacen()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `terminado1`, `terminado2`, `terminado3`, `terminado4`, `maduracion1`, `maduracion2`, `maduracion3`, `maduracion4`, `carga1`, `carga2`, `carga3`, `carga4`, `recipiente1`, `recipiente2`, `recipiente3`, `recipiente4`, `fecha`,infraestructura, granel1, granel2, granel3, granel4 ,almacen1, almacen2, almacen3, almacen4 FROM sinca.`di_inf_fotos_almacen`  WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (row["terminado1"] != null && row["terminado1"].ToString() != "") pbTerminado1FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["terminado1"].ToString());
                        if (row["terminado2"] != null && row["terminado2"].ToString() != "") pbTerminado2FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["terminado2"].ToString());
                        if (row["terminado3"] != null && row["terminado3"].ToString() != "") pbTerminado3FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["terminado3"].ToString());
                        if (row["terminado4"] != null && row["terminado4"].ToString() != "") pbTerminado4FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["terminado4"].ToString());
                        if (row["maduracion1"] != null && row["maduracion1"].ToString() != "") pbMaduracion1FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["maduracion1"].ToString());
                        if (row["maduracion2"] != null && row["maduracion2"].ToString() != "") pbMaduracion2FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["maduracion2"].ToString());
                        if (row["maduracion3"] != null && row["maduracion3"].ToString() != "") pbMaduracion3FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["maduracion3"].ToString());
                        if (row["maduracion4"] != null && row["maduracion4"].ToString() != "") pbMaduracion4FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["maduracion4"].ToString());
                        if (row["carga1"] != null && row["carga1"].ToString() != "") pbCarga1FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["carga1"].ToString());
                        if (row["carga2"] != null && row["carga2"].ToString() != "") pbCarga2FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["carga2"].ToString());
                        if (row["carga3"] != null && row["carga3"].ToString() != "") pbCarga3FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["carga3"].ToString());
                        if (row["carga4"] != null && row["carga4"].ToString() != "") pbCarga4FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["carga4"].ToString());
                        if (row["recipiente1"] != null && row["recipiente1"].ToString() != "") pbRecipientes1FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["recipiente1"].ToString());
                        if (row["recipiente2"] != null && row["recipiente2"].ToString() != "") pbRecipientes2FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["recipiente2"].ToString());
                        if (row["recipiente3"] != null && row["recipiente3"].ToString() != "") pbRecipientes3FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["recipiente3"].ToString());
                        if (row["recipiente4"] != null && row["recipiente4"].ToString() != "") pbRecipientes4FA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["recipiente4"].ToString());
                        if (row["infraestructura"] != null && row["infraestructura"].ToString() != "") pbInfraestructuraA.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["infraestructura"].ToString());

                        if (row["granel1"] != null && row["granel1"].ToString() != "") pbGranelA1.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["granel1"].ToString());
                        if (row["granel2"] != null && row["granel2"].ToString() != "") pbGranelA2.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["granel2"].ToString());
                        if (row["granel3"] != null && row["granel3"].ToString() != "") pbGranelA3.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["granel3"].ToString());
                        if (row["granel4"] != null && row["granel4"].ToString() != "") pbGranelA4.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["granel4"].ToString());
                        if (row["almacen1"] != null && row["almacen1"].ToString() != "") pbAlmacenA1.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen1"].ToString());
                        if (row["almacen2"] != null && row["almacen2"].ToString() != "") pbAlmacenA2.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen2"].ToString());
                        if (row["almacen3"] != null && row["almacen3"].ToString() != "") pbAlmacenA3.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen3"].ToString());
                        if (row["almacen4"] != null && row["almacen4"].ToString() != "") pbAlmacenA4.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["almacen4"].ToString());  

                    }
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargar_fotos_areas()
        {
            try
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT `id`, `id_solicitud`, `laboratorio`, `sanitarios`, `estacionamiento`, `oficinas`, `herramientas`, `carga`, `otros1`, `otros2`, `fecha` FROM sinca.`di_inf_areas_comunes` WHERE id_solicitud='" + di_solicitud + "' LIMIT 1");

                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (row["laboratorio"] != null && row["laboratorio"].ToString() != "") pbLaboratorioAD.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["laboratorio"].ToString());
                        if (row["sanitarios"] != null && row["sanitarios"].ToString() != "") pbSanitariosAD.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["sanitarios"].ToString());
                        if (row["estacionamiento"] != null && row["estacionamiento"].ToString() != "") pbEstacionamiento.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["estacionamiento"].ToString());
                        if (row["oficinas"] != null && row["oficinas"].ToString() != "") pbOficinas.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["oficinas"].ToString());
                        if (row["herramientas"] != null && row["herramientas"].ToString() != "") pbHerramientas.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["herramientas"].ToString());
                        if (row["carga"] != null && row["carga"].ToString() != "") pbCargaAD.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["carga"].ToString());
                        if (row["otros1"] != null && row["otros1"].ToString() != "") pbOtros1AD.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["otros1"].ToString());
                        if (row["otros2"] != null && row["otros2"].ToString() != "") pbOtros2AD.Load("C:/xampp/htdocs/doc/img/" + no_cliente + "/" + row["otros2"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /* private void btnGuardarEvidenciaFotografica_Click(object sender, EventArgs e)
        {
            try
            {               
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET cumple_produccion='" + cbCumpleProduccion.Text + "' WHERE id='" + di_solicitud + "'") == "Error")
                {
                    return;
                };
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void btnRecepcion1_Click(object sender, EventArgs e)
        {
            mostrarAgregarImagen("recepcion1", "di_inf_fotos_produccion");
        }

    }
}