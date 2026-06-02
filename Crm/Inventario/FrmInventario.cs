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
using Crm.Inventario.Dialogs;
using Crm.functions;
using Crm.Inventario.editaFechas;
using Crm.Inventario.mermasHologramas;
using static System.Net.Mime.MediaTypeNames;

namespace Crm.Inventario
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {

            InitializeComponent();
            this.Size = new System.Drawing.Size(1080, 768); // tamaño inicial
            this.StartPosition = FormStartPosition.CenterScreen;
            ConexionMysql.conecta();
            Usuario.No_Cliente = "0";
            Usuario.EnvasadoraSeleccionada = "0";
            Usuario.FabricaSeleccionada = "0";
            //llenamos los clientes para la seleecion 
            AutoCompleteStringCollection ListaClientes = new AutoCompleteStringCollection();
            DataSet DatosClientes = new DataSet();
            ConexionMysql.llenaDataset(ref DatosClientes, "select no_cliente from clientes ");
            foreach (DataRow row in DatosClientes.Tables[0].Rows)
            {
                ListaClientes.Add(row[0].ToString());
            }
            TxTNoClienteSeleccion.AutoCompleteCustomSource = ListaClientes;



            BtnProduccion.Visible = false;
            BtnGranel.Visible = false;
            BtnEnvasadoGranel.Visible = false;
            BtnEnvasado.Visible = false;
            btnAlmacen.Visible = false;
            btnAlmacenGranel.Visible = false;

            PanelGranel.Visible = false;
            PanelProduccion.Visible = false;
            PanelEnvasado.Visible = false;
            PanelGranelEnvasado.Visible = false;
            pnlAlmacendeGraneles.Visible = false;
            pnlAlmacen.Visible = false;
            addTablasCoccion();
            addTablasMolienda();
            addTablasFormulacion();
            addTablasDestilacion();
            addTablasProduccion();



            Usuario.IdRuta = ConexionMysql.regresaCampoConsulta("SELECT id_ruta FROM rutas_verificadores");



        }

        #region DECLARACION DE VARIABLES
        //--Observaciones
        string id_max_observaciones;
        public string id_produccion = "";




        //produccion
        string id_max_produccion_entrada = "";
        string id_max_agave_sobrante = "";
        string id_max_produccion_salida = "";

        //granel
        string id_max_granel_entrada = "";
        string id_max_granel_ensamble = "";
        string id_max_granel_salida = "";
        string id_max_granel_tanque = "";
        string id_max_loteSinMov = "";//lotes si moviminetos tabla checked_lotes_gf

        //granel envasado
        string id_max_granel_entrada_envasado = "";
        string id_max_granel_ensamble_envasado = "";
        string id_max_granel_tanque_envasado = "";
        string id_max_loteSinMovGE = "";//lotes si moviminetos tabla checked_lotes_ge

        //envasado
        string id_max_envasado_entrada = "";
        string id_max_envasado_ensamble = "";
        string id_max_hologramas = "";
        string id_max_loteSinMovENV = "";// lotes sin movimientos en tabla checked_lotes_en


        ///Almacen de graneles
        string id_max_almacen_granel_entrada = "";
        string id_max_almacen_granel_ensamble = "";
        string id_max_almacen_granel_tanque = "";



        ///Almacen de Envasasado
        string id_max_almacen_envasado_entrada = "";
        string id_max_almacen_envasado_ensamble = "";
        string id_max_almacen_hologramas = "";



        //produccion 
        DataSet dtsCoccion;
        DataSet dtsMolienda;
        DataSet dtsFormulacion;
        DataSet dtsDestilacion;
        DataSet dtsProduccion;
        Validacion valida = new Validacion();
        Boolean BanderaCoccion = false;
        Boolean BanderaMolienda = false;
        Boolean BanderaFormulacion = false;
        Boolean BanderaDestilacion = false;
        Boolean BanderaProduccion = false;
        string id_predio_agave_sobrante = "";
        string id_plnata_agave_sobrante = "";
        string id_produccion_entrada_sobrante = "";
        string id_agave_sobrante = "";
        string id_predio_comprado = "";
        string porcen_art_sobrante = "";

        string no_guia = "";

        string id_maestro_mezcalero = "";
        string banderaGuiaExterna = "";


        //agranel 
        DataSet dtsProductoAgranel;
        DataSet dtsProductoBarrica;
        DataSet dtsProductoVidrio;
        DataSet dtsProduccionParaGuardarAgranel;
        DataSet dtsTanques;
        string litros = "";
        string tapada = "";
        string grado_alcoholico = "";
        string id_planta = "";
        string planta_externa="";
        string id_predio = "";
        string agave_coccion_kg = "";
        //add to gcrm ensamble
        string gcrm= "";
        Boolean BanderaGranel = false;
        Boolean BanderaBarrica = false;
        Boolean BanderaVidrio = false;
        string TxtAbocado = "";

        Boolean BanderaNoFolioFabrica = false;







        //agranel  envasado
        DataSet dtsProductoAgranelEnvasado;
        DataSet dtsProductoBarricaEnvasado;
        DataSet dtsProductoVidrioEnvasado;
        DataSet dtsProduccionParaGuardarAgranelEnvasado;
        DataSet dtsTanquesEnvasado;
        Boolean BanderaGranelEnvasado = false;
        Boolean BanderaBarricaEnvasado = false;
        Boolean BanderaVidrioEnvasado = false;
        string no_lote = "";
        Boolean granel_envasadoBandera = false;

        Boolean BanderaNoFolioEnvasadora = false;




        //envasado 
        DataSet dtsEnvasado;
        DataSet dtsProductoEnvasadoNoTerminado;
        DataSet dtsProductoEnvasado;
        DataSet dtsProductoEnvasadoSalio;
        DataSet dtsHologramas;
        string fqenvasado;
        string id_comun_envasado;
        string litrosGranelparaenvasado;
        string no_lote_granel;
        string grado_alcoholico_granel;
        string categoriamezcalenvasado;
        string clasemezcalenvasado;
        string ingredienteenvasado;
        string abocanteenvasado;
        string id_plantaenvasado;
        string id_predioenvasado;
        string agave_coccion_kg_envasado;
        string no_cliente_maquila;
        string id_max_envasado_salida;
        Boolean BanderaEnvasado = false;
        Boolean BanderaEnvasadoNoTerminado = false;
        Boolean BanderaEnvasadoSalio = false;
        Boolean envasadoBandera = false;


        ///-- Almacen Graneles
        DataSet dtsProductoAgranelAlmacen;
        DataSet dtsProductoBarricaAlmacen;
        DataSet dtsProductoVidrioAlmacen;
        DataSet dtsProduccionParaGuardarAlmacenAgranel;
        DataSet dtsTanquesAlmacenAgranel;
        Boolean BanderaGranelAlmacen = false;
        Boolean BanderaBarricaAlmacen = false;
        Boolean BanderaVidrioAlmacen = false;
        string litros_Granel_FabricaEnvasado = "";
        string grado_alcoholico_Granel = "";
        string no_lote_Granel = "";


        ///--Almacen Envasado
        DataSet dtsAlmacen_Envasado;
        DataSet dtsProductoAlmacenEnvasadoNoTerminado;
        DataSet dtsProductoAlmacenEnvasado;
        DataSet dtsProductoAlmacenEnvasadoSalio;
        DataSet dtsHologramasparaAlmacen;
        string botellasEnvasadoparaAlmacenenvasado;
        string fqalmacen_envasado;
        string id_comun_almacen_envasado;
        string no_lote_envasado;
        string grado_alcoholico_envasado;
        string categoriamezcalAlmacenenvasado;
        string clasemezcalAlmacenenvasado;
        string ingredienteAlmacenenvasado;
        string abocanteAlmacenenvasado;
        string id_plantaAlmacenenvasado;
        string id_predioAlmacenenvasado;
        string contenidoporbotella;
        string marca_envasado;
        string grado_alcoholico_etiqueta_envasado;
        string unidad_medida;
        Boolean BanderaAlmacenEnvasado = false;
        Boolean BanderaAlmacenEnvasadoNoTerminado = false;
        Boolean BanderaAlmacenEnvasadoSalio = false;
        //Boolean envasadoBandera = false;
        //string no_cliente_maquila;
        /* Boolean Almacen_GFabrica = false;
         Boolean Almacen_GEnvasado = false;
         Boolean Almacen_envasado = false;
         */
        #endregion


        #region OBETENER IDS MÁXIMOS
        //obtencion de los id para todas las producciones 
        public void ObtenerIdMaximoProduccionEntrada()
        {
            id_max_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_produccion_entrada,4)) )   FROM produccion_entrada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_produccion_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_produccion_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_produccion_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_produccion_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_produccion_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_produccion_entrada = Usuario.IdUsuario + "-" + suma;
                }

                //char delimiter = '-';
                //string[] substrings = id_max_produccion_entrada.Split(delimiter);
                //int suma = int.Parse(substrings[1]) + 1;
                //id_max_produccion_entrada = Usuario.IdUsuario+"-"+suma.ToString();
            }
        }


        //obtencion de los id para agave sobrante
        public void ObtenerIdMaximoAgaveSobrante()
        {
            id_max_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_agave_sobrante,4)) )  FROM produccion_agave_sobrante where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_agave_sobrante == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_agave_sobrante = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_agave_sobrante = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_agave_sobrante) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_agave_sobrante = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_agave_sobrante = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para agave sobrante
        public void ObtenerIdMaximoProduccionSalida()
        {
            id_max_produccion_salida = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_produccion_salida,4)) )  FROM produccion_salida where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_produccion_salida == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_produccion_salida = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_produccion_salida = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_produccion_salida) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_produccion_salida = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_produccion_salida = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //TODO: OBETENER LOS ID PARA LOS INSERT DE LOTES QUE SE VERIFICARON SIN MOVIMIENTOS O EN STOCK --NOVIEMBRE 2020 checked_lotes_gf
        public void ObtenerIdMaximoLotesSinMovimiento()
        {
            #region
            id_max_loteSinMov = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_checked_lotegf,4)) ) FROM checked_lotes_gf " +
                "where verificador_id =" + Usuario.IdUsuario + " ");
            if (id_max_loteSinMov == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_loteSinMov = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_loteSinMov = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_loteSinMov) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_loteSinMov = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_loteSinMov = Usuario.IdUsuario + "-" + suma;
                }
            }
            #endregion
        }


        //obtencion de los id para todas las entradas a granel 
        public void ObtenerIdMaximoGranelEntrada()
        {
            id_max_granel_entrada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_entrada,4)) )   FROM granel_entrada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todas las ensambles  granel 
        public void ObtenerIdMaximoGranelEnsamble()
        {
            id_max_granel_ensamble = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_ensamble,4)) )   FROM granel_ensamble where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_ensamble = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_ensamble = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todas graneles salida
        public void ObtenerIdMaximoGranelSalida()
        {
            id_max_granel_salida = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_salida,4)) )   FROM granel_salida where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_salida == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_salida = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_salida = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_salida) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_salida = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_salida = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todos los tanques entrada
        public void ObtenerIdMaximoGraneTanque()
        {
            id_max_granel_tanque = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM granel_tanques where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_tanque == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_tanque = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_tanque) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_tanque = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todas las entradas a granel envasado
        public void ObtenerIdMaximoGranelEntradaEnvasado()
        {
            id_max_granel_entrada_envasado = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_entrada_envasado,4)) )   FROM granel_entrada_envasado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_entrada_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_entrada_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_entrada_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_entrada_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //TODO: OBETENER LOS ID PARA LOS INSERT DE LOTES QUE SE VERIFICARON SIN MOVIMIENTOS O EN STOCK --NOVIEMBRE 2020 checked_lotes_ge
        public void ObtenerIdMaximoLotesSinMovimientoGE()
        {
            #region
            id_max_loteSinMovGE = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_checked_lotege,4)) ) FROM checked_lotes_ge " +
                "where verificador_id =" + Usuario.IdUsuario + " ");
            if (id_max_loteSinMovGE == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_loteSinMovGE = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_loteSinMovGE = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_loteSinMovGE) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_loteSinMovGE = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_loteSinMovGE = Usuario.IdUsuario + "-" + suma;
                }
            }
            #endregion
        }

        //obtencion de los id para todas las entradas a granel ensamble  envasado
        public void ObtenerIdMaximoGranelEnsambleEnvasado()
        {
            id_max_granel_ensamble_envasado = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_ensamble,4)) )   FROM granel_ensamble_envasado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_ensamble_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_ensamble_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_ensamble_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_ensamble_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todos los tanques_envasado entrada
        public void ObtenerIdMaximoGranelTanqueEnvasado()
        {
            id_max_granel_tanque_envasado = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM granel_tanques_envasado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_tanque_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_tanque_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_tanque_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_tanque_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //TODO: OBTENER EL ID COMPUESTO MAXIMO DE LA TABLA LOTES SIN MOVIMIENTOS DE ENVASADO---2020
        public void ObtenerIdMaximoLotesSinMovimientoENV()
        {
            #region
            id_max_loteSinMovENV = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_checked_loteEN,4)) ) FROM checked_lotes_en " +
                "where verificador_id =" + Usuario.IdUsuario + " ");
            if (id_max_loteSinMovENV == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_loteSinMovENV = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_loteSinMovENV = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_loteSinMovENV) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_loteSinMovENV = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_loteSinMovENV = Usuario.IdUsuario + "-" + suma;
                }
            }
            #endregion
        }

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


        ///----======= para almacenes ---
        //obtencion de los id para todas las entradas a granel envasado
        public void ObtenerIdMaximoAlmacenGranelEntrada()
        {
            id_max_almacen_granel_entrada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_granel_entrada,4)) )   FROM almacen_granel_entrada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_granel_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel ensamble  envasado
        public void ObtenerIdMaximoAlmacenGranelEnsamble()
        {
            id_max_almacen_granel_ensamble = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_granel_ensamble,4)) )   FROM almacen_granel_ensamble where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_granel_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_ensamble = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_ensamble = Usuario.IdUsuario + "-" + suma;
                }
            }
        }




        //obtencion de los id para todos los tanques_envasado entrada
        public void ObtenerIdMaximoAlmacenGranelTanque()
        {
            id_max_almacen_granel_tanque = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM almacen_granel_tanques where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_granel_tanque == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_tanque = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_tanque = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_tanque) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_tanque = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_tanque = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todas las entradas a envasado 
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



        //obtencion de los id para todas las entradas a envasado ensamble 
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
        public void ObtenerIdMaximoAlmacenEntradaHologramas()
        {
            id_max_almacen_hologramas = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_envasado_holograma,4)) )   FROM almacen_envasado_holograma where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_hologramas == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_hologramas = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_hologramas = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_hologramas) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_hologramas = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_hologramas = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        /// <summary>
        /// obtiene el id maximo de envasado salida
        /// </summary>
        public void ObtenerIdMaximoEnvasadoSalida()
        {
            id_max_envasado_salida = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_salida,4)) )   FROM envasado_salida where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasado_salida == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_salida = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasado_salida = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasado_salida) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_salida = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasado_salida = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        #endregion



        private void EstilizarDataGridViews()
        {
            foreach (Control c in this.Controls)
            {
                AplicarEstiloADataGridViewsRecursivo(c);
            }
        }

        private void AplicarEstiloADataGridViewsRecursivo(Control parent)
        {
            if (parent is DataGridView)
            {
                DataGridView dgv = (DataGridView)parent;
                dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke;
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(41, 53, 65);
                dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(37, 46, 59);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
                dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            }
            
            foreach (Control c in parent.Controls)
            {
                AplicarEstiloADataGridViewsRecursivo(c);
            }
        }

        //--Inicio del FormInventario 
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            EstilizarDataGridViews();
            //==r@le-- el codigo de ese handler se instancio en el Frminventario()

            /* ConexionMysql.conecta();
             Usuario.No_Cliente = "0";
             Usuario.EnvasadoraSeleccionada = "0";
             Usuario.FabricaSeleccionada = "0";
             //llenamos los clientes para la seleecion 
             AutoCompleteStringCollection ListaClientes = new AutoCompleteStringCollection();
             DataSet DatosClientes = new DataSet();
             ConexionMysql.llenaDataset(ref DatosClientes, "select no_cliente from clientes ");
             foreach (DataRow row in DatosClientes.Tables[0].Rows)
             {
                 ListaClientes.Add(row[0].ToString());
             }
             TxTNoClienteSeleccion.AutoCompleteCustomSource = ListaClientes;



             BtnProduccion.Visible = false;
             BtnGranel.Visible = false;
             BtnEnvasadoGranel.Visible = false;
             BtnEnvasado.Visible = false;

             PanelGranel.Visible = false;
             PanelProduccion.Visible = false;
             PanelEnvasado.Visible = false;
             PanelGranelEnvasado.Visible = false;
             addTablasCoccion();
             addTablasMolienda();
             addTablasFormulacion();
             addTablasDestilacion();
             addTablasProduccion();

             Usuario.IdRuta = ConexionMysql.regresaCampoConsulta("SELECT id_ruta FROM rutas_verificadores");*/
        }

        //al presionar produccion
        #region MENUS DE PROCESOS DE MEZCAL
        private void BtnProduccion_Click(object sender, EventArgs e)
        {
            PanelProduccion.Visible = true;
            PanelGranel.Visible = false;
            PanelGranelEnvasado.Visible = false;
            PanelEnvasado.Visible = false;
            pnlAlmacendeGraneles.Visible = false;
            pnlAlmacen.Visible = false;




            granel_envasadoBandera = false;
            envasadoBandera = false;
            //ConexionMysql.llenaCombo(ref CmbNoCliente, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
            //r@le-> la conslta anterior toma los clientes de ruta clientes ahora los tomara directamente de la tabla clientes
            ConexionMysql.llenaCombo(ref CmbNoCliente, "SELECT no_cliente FROM clientes", "no_cliente", "no_cliente");

            if (Usuario.No_Cliente != "0")
            {
                CmbNoCliente.SelectedValue = Usuario.No_Cliente;
            }

            ConexionMysql.llenaCombo(ref CmbCoccion, "SELECT id_coccion,coccion FROM cat_coccion", "id_coccion", "coccion");
            tabControl1.SelectedTab = tabPage1;
            BanderaCoccion = true;
            BanderaMolienda = false;
            BanderaFormulacion = false;
            BanderaDestilacion = false;
            BanderaProduccion = false;
            CmbFabrica_SelectedIndexChanged(null, null);

            // Refactorización UX: Ocultar masivamente controles para FrmEnsamblePredio
            OcultarControlesProduccion();
        }

        // Variables para la refactorización de Producción
        private System.Windows.Forms.Button btnConfigurarEnsamble;
        public FrmEnsamblePredio frmEnsambleInstancia; // Instancia para guardar los datos configurados

        private void OcultarControlesProduccion()
        {
            // Ocultamos controles viejos
            BtnEnsamblePredio.Visible = false;
            BtnExtraccion.Visible = false;
            ChekMagueyComprado.Visible = false;
            chkGuiaAntigua.Visible = false;
            ChekAgaveSobrante.Visible = false;
            label81.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            TxtNoGuia.Visible = false;
            TxtNoPredio.Visible = false;
            TxtPredio.Visible = false;
            CmbMaguey.Visible = false;
            TxtExistencia.Visible = false;
            TxtExtraccion.Visible = false;
            label12.Visible = false;
            label4.Visible = false;
            label8.Visible = false;
            TxtAgaveEntranteKg.Visible = false;
            TxtAgaveCoccion.Visible = false;
            TxtArt.Visible = false;

            // Inyectamos el botón de Configuración si no existe
            if (btnConfigurarEnsamble == null)
            {
                btnConfigurarEnsamble = new System.Windows.Forms.Button();
                btnConfigurarEnsamble.Text = "⚙️ Asignar Guías / Predios";
                btnConfigurarEnsamble.Size = new System.Drawing.Size(260, 45);
                btnConfigurarEnsamble.Location = new System.Drawing.Point(50, 70); 
                btnConfigurarEnsamble.BackColor = System.Drawing.Color.DarkSeaGreen;
                btnConfigurarEnsamble.ForeColor = System.Drawing.Color.White;
                btnConfigurarEnsamble.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnConfigurarEnsamble.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                btnConfigurarEnsamble.Cursor = System.Windows.Forms.Cursors.Hand;
                btnConfigurarEnsamble.Click += BtnConfigurarEnsamble_Click;
                
                // Mover los controles restantes de PanelProduccion (Tapada, Coccion) para que no se vean amontonados
                // Nota: Asumimos que los campos finales están en un groupBox o libres, los movemos visualmente.
                
                PanelProduccion.Controls.Add(btnConfigurarEnsamble);
                btnConfigurarEnsamble.BringToFront();
                
                // Reordenamiento de foco y navegación (TabIndex)
                btnConfigurarEnsamble.TabIndex = 1;
                TxtTapada.TabIndex = 2;
                CmbCoccion.TabIndex = 3;
                DataFechaInicioCoccion.TabIndex = 4;
                CmbFabrica.TabIndex = 5;
                BtnAgregarProduccion.TabIndex = 6;
            }
        }

        private void BtnConfigurarEnsamble_Click(object sender, EventArgs e)
        {
            if (frmEnsambleInstancia == null || frmEnsambleInstancia.IsDisposed)
            {
                frmEnsambleInstancia = new FrmEnsamblePredio();
            }
            frmEnsambleInstancia.ShowDialog();
        }

        //al presionar el boton de granel 
        private void BtnGranel_Click(object sender, EventArgs e)
        {
            PanelGranel.Visible = true;
            PanelProduccion.Visible = false;
            PanelGranelEnvasado.Visible = false;
            PanelEnvasado.Visible = false;
            pnlAlmacen.Visible = false;
            pnlAlmacendeGraneles.Visible = false;



            txtIngredienteGF.Enabled = false;
            lbltituloIGF.Enabled = false;
            addTablaProductoAgranel();
            addTablaProductoBarrica();
            addTablaProductoVidrio();
            addTablaProduccionParaGuardarAgranel();
            addTablaTanques();
            TxtLitrosParaGuardarAgranel.Text = "";
            TxtTanque.Text = "";
            TxtNoLote.Text = "";
            TxtAbocado = "";
            txtIngredienteGF.Text = "";
            lblFolioGranel.Text = "-- S/N Folio --";
            //TxtIngrediente.Text = "";
            TxtFQ.Text = "";
            BanderaGranel = true;
            BanderaBarrica = false;
            BanderaVidrio = false;
            granel_envasadoBandera = false;
            envasadoBandera = false;
            //ConexionMysql.llenaCombo(ref CmbNoClienteGranel, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
            //r@le-> la conslta anterior toma los clientes de ruta clientes ahora los tomara directamente de la tabla clientes
            ConexionMysql.llenaCombo(ref CmbNoClienteGranel, "SELECT no_cliente FROM clientes", "no_cliente", "no_cliente");
            if (Usuario.No_Cliente != "0")
            {
                CmbNoClienteGranel.SelectedValue = Usuario.No_Cliente;
            }
            tabControl2.SelectedTab = tabPage7;

        }



        //al presionarl el boton de granel envasado
        private void BtnEnvasadoGranel_Click(object sender, EventArgs e)
        {
            PanelGranelEnvasado.Visible = true;
            PanelProduccion.Visible = false;
            PanelGranel.Visible = false;
            PanelEnvasado.Visible = false;
            pnlAlmacendeGraneles.Visible = false;
            pnlAlmacen.Visible = false;




            addTablaProductoAgranelEnvasado();
            addTablaProductoBarricaEnvasado();
            addTablaProductoVidrioEnvasado();
            addTablaProduccionParaGuardarAgranelEnvasado();
            addTablaTanquesEnvasado();
            TxtLitrosParaGuardarAgranelEnvasado.Text = "";
            TxtTanqueEnvasado.Text = "";
            TxtNoLoteEnva.Text = "";
            lblFolioGranelEnvasado.Text = "-- S/N Folio --";
            //TxtAbocadoEnvasado.Text = "";
            TxtIngredienteEnvasado.Text = "";
            TxtFQEnvasado.Text = "";
            BanderaGranelEnvasado = true;
            BanderaBarricaEnvasado = false;
            BanderaVidrioEnvasado = false;
            granel_envasadoBandera = true;
            envasadoBandera = false;
            //ConexionMysql.llenaCombo(ref CmbNoClienteGranelEnvasado, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
            //r@le-> la conslta anterior toma los clientes de ruta clientes ahora los tomara directamente de la tabla clientes
            ConexionMysql.llenaCombo(ref CmbNoClienteGranelEnvasado, "SELECT no_cliente FROM clientes", "no_cliente", "no_cliente");
            if (Usuario.No_Cliente != "0")
            {
                CmbNoClienteGranelEnvasado.SelectedValue = Usuario.No_Cliente;
            }
            tabControl5.SelectedTab = tabPage11;


            chkAbocadoEnvasado.Toggled = false;

            TxtIngredienteEnvasado.Enabled = false;
            lblIngrediente.Enabled = false;
        }



        //al presionarl el boton de ENVASADO
        private void BtnEnvasado_Click(object sender, EventArgs e)
        {
            PanelEnvasado.Visible = true;

            PanelProduccion.Visible = false;
            PanelGranel.Visible = false;
            PanelGranelEnvasado.Visible = false;
            pnlAlmacendeGraneles.Visible = false;
            pnlAlmacen.Visible = false;


            RbtnFabrica.Checked = false;
            RbtnEnvasadora.Checked = true;
            CmbFabricaEnvasadora.Enabled = false;
            TxtMaestroMezcaleroEnvasadora.Enabled = false;
            addTablaGranelParaGuardarEnvasado();
            addTablaProductoEnvasado();
            addTablaProductoEnvasadoSalio();
            addTablaProductoEnvasadoNoTerminado();
            addTablaHologramas();
            BanderaEnvasado = false;
            BanderaEnvasadoSalio = false;
            BanderaEnvasadoNoTerminado = true;
            granel_envasadoBandera = false;
            envasadoBandera = true;


            lblEtiquetadocomo.Enabled = false;
            cmbEtiquetadocomo.Enabled = false;

            //ConexionMysql.llenaCombo(ref CmbNoClienteEnvasado, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
            //r@le-> la conslta anterior toma los clientes de ruta clientes ahora los tomara directamente de la tabla clientes
            ConexionMysql.llenaCombo(ref CmbNoClienteEnvasado, "SELECT no_cliente FROM clientes", "no_cliente", "no_cliente");


            if (Usuario.No_Cliente != "0")
            {
                CmbNoClienteEnvasado.SelectedValue = Usuario.No_Cliente;
            }
            ConexionMysql.llenaCombo(ref CmbUnidadDeMedida, "SELECT  distinct medida FROM cat_presentacion", "medida", "medida");
            tabControl4.SelectedTab = tabPage14;



            //CmbLoteGranel.AutoCompleteCustomSource = LoadAutoComplete();
            //CmbLoteGranel.AutoCompleteMode = AutoCompleteMode.Suggest;
            //CmbLoteGranel.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        #endregion


        /////////////////////////////////////////////////////////////////////////////////////---\\====PRODUCCION======\\---//////////////////////////////////////////////////////////////////////////////////////////////
        #region PRODUCCIÓN
        //desconocer el origen de  la planta
        private void ChekDesconosco_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekDesconosco.Checked == true)
            {
                TxtNoGuia.Enabled = false;
                TxtNoPredio.Enabled = false;
                CmbNoPredio.Enabled = false;
                TxtNoGuia.Text = "";
                TxtNoPredio.Text = "";
                TxtPredio.Text = "";
                CmbNoPredio.DataSource = null;
                CmbMaguey.Enabled = false;
                CmbMaguey.DataSource = null;
                TxtExistencia.Text = "";
                ChekMagueyComprado.Enabled = false;
                ChekAgaveSobrante.Enabled = false;
                BtnExtraccion.Enabled = false;
            }
            else
            {
                TxtNoGuia.Enabled = true;
                TxtNoPredio.Enabled = true;
                CmbNoPredio.Enabled = true;
                CmbMaguey.Enabled = true;
                ChekMagueyComprado.Enabled = true;
                ChekAgaveSobrante.Enabled = true;
                /*-- Deshabilitado por agregar en numero de guia -- */
                // --  ConexionMysql.llenaCombo(ref CmbNoPredio, "SELECT id_paraje FROM paraje where id_cliente='" + CmbNoCliente.SelectedValue + "'", "id_paraje", "id_paraje");
                CmbFabrica_SelectedIndexChanged(sender, e);
                BtnExtraccion.Enabled = true;
            }

        }

        //al seleccionar fabrica carga la info
        private void CmbFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChekMagueyComprado.Checked = false;
            ChekDesconosco.Checked = false;
            ChekAgaveSobrante.Checked = false;
            dtsCoccion.Tables["COCCION"].Rows.Clear();
            dtsMolienda.Tables["MOLIENDA"].Rows.Clear();
            dtsFormulacion.Tables["FORMULACION"].Rows.Clear();
            dtsDestilacion.Tables["DESTILACION"].Rows.Clear();
            dtsProduccion.Tables["PRODUCCION"].Rows.Clear();
            if (CmbFabrica.SelectedValue != null)
            {
                //-- TxtMaestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT if(maestro = '' or maestro is null,(SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'),maestro) as maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabrica.SelectedValue + "'");

                TxtMaestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'");

                id_maestro_mezcalero = ConexionMysql.regresaCampoConsulta("SELECT mm.id_maestros_mezcaleros FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'");


                //carga los datos de coccion
                if (BanderaCoccion == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT produccion_entrada.tipo,DATE_FORMAT(produccion_entrada.periodo_molienda_inicio, '%d/%m/%Y') as periodo_molienda_inicio,   cat_coccion.coccion,produccion_entrada.tapada,produccion_entrada.id_produccion_entrada,DATE_FORMAT(produccion_entrada.fecha, '%d/%m/%Y') as fecha,paraje.paraje,PREDIOE.predio,IF(produccion_entrada.id_predio LIKE 'P%' or produccion_entrada.id_predio = '" + 0 +"' ,'AMMA','CRM') AS origen,comun.nombre as maguey,comun2.nombre AS maguey_comun,produccion_entrada.no_pinas_agave,produccion_entrada.agave_kg,produccion_entrada.agave_coccion_kg,DATE_FORMAT(produccion_entrada.periodo_coccion_inicio, '%d/%m/%Y') as periodo_coccion_inicio,DATE_FORMAT(produccion_entrada.periodo_coccion_fin, '%d/%m/%Y') as periodo_coccion_fin,produccion_entrada.porcentaje_art,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey,GROUP_CONCAT( TABLA.no_pinas_agave order by TABLA.agave_coccion_kg desc SEPARATOR ' - ') as ensamble_no_pinas_agave,GROUP_CONCAT( TABLA.agave_kg order by TABLA.agave_coccion_kg desc SEPARATOR ' - ') as ensamble_agave_kg,GROUP_CONCAT( TABLA.agave_coccion_kg order by TABLA.agave_coccion_kg desc SEPARATOR ' - ') as ensamble_agave_coccion_kg FROM produccion_entrada LEFT JOIN paraje ON produccion_entrada.id_predio=paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN existenciaplanta ON produccion_entrada.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_coccion ON produccion_entrada.id_coccion=cat_coccion.id_coccion  LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada, paraje.paraje, comun.nombre as maguey, produccion_ensamble.no_pinas_agave, produccion_ensamble.agave_kg, produccion_ensamble.agave_coccion_kg, produccion_ensamble.porcentaje_art  FROM produccion_ensamble LEFT JOIN paraje ON paraje.id_paraje=produccion_ensamble.id_predio  INNER JOIN existenciaplanta ON produccion_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada where produccion_entrada.id_fabrica='" + CmbFabrica.SelectedValue + "' AND (produccion_entrada.periodo_coccion_fin='0000-00-00' or produccion_entrada.estatus=1)  GROUP BY produccion_entrada.id  ");
                    DataRow fila;
                    dtsCoccion.Tables["COCCION"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsCoccion.Tables["COCCION"].NewRow();
                        fila["ID_PRODUCCION"] = Convert.ToString(row["id_produccion_entrada"]);
                        
                        fila["NO_PRODUCCION"] = Convert.ToString(row["tapada"]);
                        fila["COCCION"] = Convert.ToString(row["coccion"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        string id = Convert.ToString(row["id_produccion_entrada"]);
                        string C_origenTapada = Convert.ToString(row["origen"]);
                        string tipoTapada = Convert.ToString(row["tipo"]);
                        string maguey = Convert.ToString(row["maguey"]);

                        if (C_origenTapada == "AMMA")
                        {
                            //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA 
                            if (Convert.ToString(row["paraje"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_paraje"]) == "")
                            {
                                fila["PREDIO"] = Convert.ToString(row["predio"]);
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                            }
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }
                                                
                       //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_maguey"]) == "")
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                            }
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }
                        }// fin del IF que valida si es guía AMMA y ahora va a entrar a buscar los datos de especie crm y predios
                        else
                        {
                            if(C_origenTapada == "CRM"){ 
                            DataSet Datoscrm = new DataSet();
                            ConexionMysql.llenaDataset(ref Datoscrm, "SELECT reveca2_paraje.paraje,PREDIOE.predio,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey FROM produccion_entrada LEFT JOIN reveca2_paraje ON produccion_entrada.id_predio=reveca2_paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN reveca2_existenciaplanta ON produccion_entrada.id_planta=reveca2_existenciaplanta.id_plantas  LEFT JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_coccion ON produccion_entrada.id_coccion=cat_coccion.id_coccion  LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada, reveca2_paraje.paraje, comun.nombre as maguey, produccion_ensamble.no_pinas_agave, produccion_ensamble.agave_kg, produccion_ensamble.agave_coccion_kg, produccion_ensamble.porcentaje_art  FROM produccion_ensamble LEFT JOIN reveca2_paraje ON reveca2_paraje.id_paraje=produccion_ensamble.id_predio  INNER JOIN reveca2_existenciaplanta ON produccion_ensamble.id_planta=reveca2_existenciaplanta.id_plantas  INNER JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada WHERE produccion_entrada.id_produccion_entrada='" + id + "'");
                            
                            foreach (DataRow filacrm in Datoscrm.Tables[0].Rows)
                                {
                                    if (Convert.ToString(filacrm["paraje"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_paraje"]) == "")
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["predio"]);
                                        }
                                        else
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["ensamble_paraje"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["PREDIO"] = Convert.ToString(filacrm["paraje"]);
                                    }

                                    //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                                    if (Convert.ToString(filacrm["maguey"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_maguey"]) == "")
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["maguey_comun"]);
                                        }
                                        else
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["ensamble_maguey"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["MAGUEY"] = Convert.ToString(filacrm["maguey"]);
                                    }

                                }
                            }
                        }


                        // DATOS NOMALES QUE NO AFECTA SI SON GUIAS CRM O NO
                        if (Convert.ToString(row["no_pinas_agave"]) == "0")
                        {
                            fila["NUMERO_PIÑAS"] = Convert.ToString(row["ensamble_no_pinas_agave"]);
                        }
                        else
                        {
                            fila["NUMERO_PIÑAS"] = Convert.ToString(row["no_pinas_agave"]);
                        }
                        if (Convert.ToString(row["agave_kg"]) == "0")
                        {
                            fila["MAGUEY_ENTRANTE"] = Convert.ToString(row["ensamble_agave_kg"]);
                        }
                        else
                        {
                            fila["MAGUEY_ENTRANTE"] = Convert.ToString(row["agave_kg"]);
                        }
                        if (Convert.ToString(row["agave_coccion_kg"]) == "0")
                        {
                            fila["MAGUEY_COCCION"] = Convert.ToString(row["ensamble_agave_coccion_kg"]);
                        }
                        else
                        {
                            fila["MAGUEY_COCCION"] = Convert.ToString(row["agave_coccion_kg"]);
                        }


                        fila["ART"] = Convert.ToString(row["porcentaje_art"]);


                        fila["FECHA_INICIO"] = Convert.ToString(row["periodo_coccion_inicio"]);
                        fila["FECHA_INICIO_MOLIENDA"] = Convert.ToString(row["periodo_molienda_inicio"]);
                        fila["FECHA_FIN"] = Convert.ToString(row["periodo_coccion_fin"]);
                        fila["TIPO"] = Convert.ToString(row["tipo"]);
                        //MessageBox.Show(fila["MAGUEY"].ToString());
                        if (tipoTapada == "1" && fila["MAGUEY"].ToString()=="")
                        {
                            string guiaTapada = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM produccion_entrada  WHERE id_produccion_entrada='" + id + "'");
                            if (guiaTapada == "0")
                            {

                                fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.internet__1_, System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }                        
                        else
                        {
                            fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.management128, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        //fila["MSJ"] = ConvertImageToByteArray(Properties.Resources.speech_bubble__4_, System.Drawing.Imaging.ImageFormat.Png);
                        fila["OBS."] = ConvertImageToByteArray(Properties.Resources.eye__12_, System.Drawing.Imaging.ImageFormat.Png);
                        fila["MOLIENDA"] = ConvertImageToByteArray(Properties.Resources.send, System.Drawing.Imaging.ImageFormat.Png);
                        // fila["OBSERVACIONES"] = ConvertImageToByteArray(Properties.Resources.eye__12_, System.Drawing.Imaging.ImageFormat.Png);

                        dtsCoccion.Tables["COCCION"].Rows.Add(fila);
                    }
                }

                //carga los datos de molienda
                else if (BanderaMolienda == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  produccion_entrada.tipo,produccion_entrada.porcentaje_art,DATE_FORMAT(produccion_entrada.periodo_formulacion_inicio, '%d/%m/%Y') as periodo_formulacion_inicio,cat_molienda.molienda,produccion_entrada.tapada,produccion_entrada.id_produccion_entrada,DATE_FORMAT(produccion_entrada.fecha, '%d/%m/%Y') as fecha,paraje.paraje,PREDIOE.predio,IF(produccion_entrada.id_predio LIKE 'P%' or produccion_entrada.id_predio = '" + 0 + "' ,'AMMA','CRM') AS origen,comun.nombre as maguey,comun2.nombre AS maguey_comun,DATE_FORMAT(produccion_entrada.periodo_molienda_inicio, '%d/%m/%Y') as periodo_molienda_inicio,DATE_FORMAT(produccion_entrada.periodo_molienda_fin, '%d/%m/%Y') as periodo_molienda_fin,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey FROM produccion_entrada LEFT JOIN paraje ON produccion_entrada.id_predio=paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN existenciaplanta ON produccion_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_molienda ON produccion_entrada.id_molienda=cat_molienda.id_molienda LEFT JOIN (SELECT  produccion_ensamble.id_produccion_entrada,paraje.paraje,comun.nombre as maguey , produccion_ensamble.agave_coccion_kg FROM produccion_ensamble INNER JOIN paraje ON paraje.id_paraje=produccion_ensamble.id_predio INNER JOIN existenciaplanta ON produccion_ensamble.id_planta=existenciaplanta.id_plantas INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada where produccion_entrada.id_fabrica='" + CmbFabrica.SelectedValue + "' AND  (produccion_entrada.periodo_molienda_fin='0000-00-00' or produccion_entrada.estatus=2)  and  produccion_entrada.estatus <> 1 GROUP BY produccion_entrada.id ");

                    DataRow fila;
                    dtsMolienda.Tables["MOLIENDA"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsMolienda.Tables["MOLIENDA"].NewRow();
                        fila["ID_PRODUCCION"] = Convert.ToString(row["id_produccion_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_PRODUCCION"] = Convert.ToString(row["tapada"]);
                        fila["MOLIENDA"] = Convert.ToString(row["molienda"]);
                        fila["ART"] = Convert.ToString(row["porcentaje_art"]);
                        fila["TIPO"] = Convert.ToString(row["tipo"]);
                        string tipoTapada = Convert.ToString(row["tipo"]);
                        string maguey = Convert.ToString(row["maguey"]);
                        #region CÓDIGO COMO ESTABA ANTES DE MODIFICAR POR GUIAS EXTERNAS
                        /*
                        if (Convert.ToString(row["paraje"]) == "")
                        {
                            fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }*/
                        #endregion

                        //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA

                        /*if (Convert.ToString(row["paraje"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_paraje"]) == "")
                            {
                                fila["PREDIO"] = Convert.ToString(row["predio"]);
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                            }
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }

                        //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_maguey"]) == "")
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                            }
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }
                        */
                        string id = Convert.ToString(row["id_produccion_entrada"]);
                        string C_origenTapada = Convert.ToString(row["origen"]);

                        if (C_origenTapada == "AMMA")
                        {
                            //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA 
                            if (Convert.ToString(row["paraje"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_paraje"]) == "")
                                {
                                    fila["PREDIO"] = Convert.ToString(row["predio"]);
                                }
                                else
                                {
                                    fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                                }
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["paraje"]);
                            }

                            //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                            if (Convert.ToString(row["maguey"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_maguey"]) == "")
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                                }
                                else
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                                }
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                            }
                        }// fin del IF que valida si es guía AMMA y ahora va a entrar a buscar los datos de especie crm y predios
                        else
                        {
                            if (C_origenTapada == "CRM")
                            {
                                DataSet Datoscrm = new DataSet();
                                ConexionMysql.llenaDataset(ref Datoscrm, "SELECT reveca2_paraje.paraje,PREDIOE.predio,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey FROM produccion_entrada LEFT JOIN reveca2_paraje ON produccion_entrada.id_predio=reveca2_paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN reveca2_existenciaplanta ON produccion_entrada.id_planta=reveca2_existenciaplanta.id_plantas  LEFT JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_coccion ON produccion_entrada.id_coccion=cat_coccion.id_coccion  LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada, reveca2_paraje.paraje, comun.nombre as maguey, produccion_ensamble.no_pinas_agave, produccion_ensamble.agave_kg, produccion_ensamble.agave_coccion_kg, produccion_ensamble.porcentaje_art  FROM produccion_ensamble LEFT JOIN reveca2_paraje ON reveca2_paraje.id_paraje=produccion_ensamble.id_predio  INNER JOIN reveca2_existenciaplanta ON produccion_ensamble.id_planta=reveca2_existenciaplanta.id_plantas  INNER JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada WHERE produccion_entrada.id_produccion_entrada='" + id + "'");

                                foreach (DataRow filacrm in Datoscrm.Tables[0].Rows)
                                {
                                    if (Convert.ToString(filacrm["paraje"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_paraje"]) == "")
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["predio"]);
                                        }
                                        else
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["ensamble_paraje"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["PREDIO"] = Convert.ToString(filacrm["paraje"]);
                                    }

                                    //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                                    if (Convert.ToString(filacrm["maguey"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_maguey"]) == "")
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["maguey_comun"]);
                                        }
                                        else
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["ensamble_maguey"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["MAGUEY"] = Convert.ToString(filacrm["maguey"]);
                                    }

                                }
                            }
                        }

                        fila["FECHA_INICIO"] = Convert.ToString(row["periodo_molienda_inicio"]);
                        fila["FECHA_INICIO_FORMULACION"] = Convert.ToString(row["periodo_formulacion_inicio"]);
                        fila["FECHA_FIN"] = Convert.ToString(row["periodo_molienda_fin"]);
                        //fila["MSJ"] = ConvertImageToByteArray(Properties.Resources.speech_bubble__4_, System.Drawing.Imaging.ImageFormat.Png);

                        if (tipoTapada == "1" && fila["MAGUEY"].ToString() == "")
                        {
                            string guiaTapada = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM produccion_entrada  WHERE id_produccion_entrada='" + id + "'");
                            if (guiaTapada == "0")
                            {

                                fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.internet__1_, System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                        else
                        {
                            fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.management128, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        fila["OBS."] = ConvertImageToByteArray(Properties.Resources.eye__12_, System.Drawing.Imaging.ImageFormat.Png);
                        fila["FORMULACION"] = ConvertImageToByteArray(Properties.Resources.send, System.Drawing.Imaging.ImageFormat.Png);
                        dtsMolienda.Tables["MOLIENDA"].Rows.Add(fila);
                    }
                }

                //carga los datos de formulacion
                else if (BanderaFormulacion == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT produccion_entrada.tipo,produccion_entrada.porcentaje_art,DATE_FORMAT(produccion_entrada.periodo_destilacion_inicio, '%d/%m/%Y') as periodo_destilacion_inicio,cat_fermentacion.fermentacion,produccion_entrada.tapada,produccion_entrada.volumen_mosto,produccion_entrada.id_produccion_entrada,DATE_FORMAT(produccion_entrada.fecha, '%d/%m/%Y') as fecha,paraje.paraje,PREDIOE.predio,IF(produccion_entrada.id_predio LIKE 'P%' or produccion_entrada.id_predio = '" + 0 + "' ,'AMMA','CRM') AS origen,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey,DATE_FORMAT(produccion_entrada.periodo_formulacion_inicio, '%d/%m/%Y') as periodo_formulacion_inicio,DATE_FORMAT(produccion_entrada.periodo_formulacion_fin, '%d/%m/%Y') as periodo_formulacion_fin  FROM produccion_entrada LEFT JOIN paraje ON produccion_entrada.id_predio=paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN existenciaplanta ON produccion_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun LEFT JOIN cat_fermentacion ON produccion_entrada.id_fermentacion=cat_fermentacion.id_fermentacion LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada,paraje.paraje,comun.nombre as maguey,produccion_ensamble.agave_coccion_kg  FROM produccion_ensamble INNER JOIN paraje ON paraje.id_paraje=produccion_ensamble.id_predio INNER JOIN existenciaplanta ON produccion_ensamble.id_planta=existenciaplanta.id_plantas INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada where produccion_entrada.id_fabrica='" + CmbFabrica.SelectedValue + "' AND  (produccion_entrada.periodo_formulacion_fin='0000-00-00' or produccion_entrada.estatus=3) and  produccion_entrada.estatus  NOT IN (1,2)  GROUP BY produccion_entrada.id");

                    DataRow fila;
                    dtsFormulacion.Tables["FORMULACION"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsFormulacion.Tables["FORMULACION"].NewRow();
                        fila["ID_PRODUCCION"] = Convert.ToString(row["id_produccion_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_PRODUCCION"] = Convert.ToString(row["tapada"]);
                        fila["ART"] = Convert.ToString(row["porcentaje_art"]);
                        fila["TIPO"] = Convert.ToString(row["tipo"]);
                        string tipoTapada = Convert.ToString(row["tipo"]);
                        string maguey = Convert.ToString(row["maguey"]);

                        #region CODIGO COMO ESTABA ANTES DE MODIFICAR POR TEMA DE GUIAS EXTERNAS PARA QUE MUESTRE EL PREDIO Y MAGUEY DE ESE TIPO DE TAPADAS
                        /*
                        if (Convert.ToString(row["paraje"]) == "")
                        {
                            fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }
                        */
                        #endregion

                        //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA
                        /*
                        if (Convert.ToString(row["paraje"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_paraje"]) == "")
                            {
                                fila["PREDIO"] = Convert.ToString(row["predio"]);
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                            }
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }

                        //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_maguey"]) == "")
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                            }
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }*/

                        string id = Convert.ToString(row["id_produccion_entrada"]);
                        string C_origenTapada = Convert.ToString(row["origen"]);

                        if (C_origenTapada == "AMMA")
                        {
                            //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA 
                            if (Convert.ToString(row["paraje"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_paraje"]) == "")
                                {
                                    fila["PREDIO"] = Convert.ToString(row["predio"]);
                                }
                                else
                                {
                                    fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                                }
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["paraje"]);
                            }

                            //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                            if (Convert.ToString(row["maguey"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_maguey"]) == "")
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                                }
                                else
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                                }
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                            }
                        }// fin del IF que valida si es guía AMMA y ahora va a entrar a buscar los datos de especie crm y predios
                        else
                        {
                            if (C_origenTapada == "CRM")
                            {
                                DataSet Datoscrm = new DataSet();
                                ConexionMysql.llenaDataset(ref Datoscrm, "SELECT reveca2_paraje.paraje,PREDIOE.predio,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey FROM produccion_entrada LEFT JOIN reveca2_paraje ON produccion_entrada.id_predio=reveca2_paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN reveca2_existenciaplanta ON produccion_entrada.id_planta=reveca2_existenciaplanta.id_plantas  LEFT JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_coccion ON produccion_entrada.id_coccion=cat_coccion.id_coccion  LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada, reveca2_paraje.paraje, comun.nombre as maguey, produccion_ensamble.no_pinas_agave, produccion_ensamble.agave_kg, produccion_ensamble.agave_coccion_kg, produccion_ensamble.porcentaje_art  FROM produccion_ensamble LEFT JOIN reveca2_paraje ON reveca2_paraje.id_paraje=produccion_ensamble.id_predio  INNER JOIN reveca2_existenciaplanta ON produccion_ensamble.id_planta=reveca2_existenciaplanta.id_plantas  INNER JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada WHERE produccion_entrada.id_produccion_entrada='" + id + "'");

                                foreach (DataRow filacrm in Datoscrm.Tables[0].Rows)
                                {
                                    if (Convert.ToString(filacrm["paraje"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_paraje"]) == "")
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["predio"]);
                                        }
                                        else
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["ensamble_paraje"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["PREDIO"] = Convert.ToString(filacrm["paraje"]);
                                    }

                                    //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                                    if (Convert.ToString(filacrm["maguey"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_maguey"]) == "")
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["maguey_comun"]);
                                        }
                                        else
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["ensamble_maguey"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["MAGUEY"] = Convert.ToString(filacrm["maguey"]);
                                    }

                                }
                            }
                        }


                        fila["FECHA_INICIO"] = Convert.ToString(row["periodo_formulacion_inicio"]);
                        fila["FECHA_INICIO_DESTILACION"] = Convert.ToString(row["periodo_destilacion_inicio"]);
                        fila["FECHA_FIN"] = Convert.ToString(row["periodo_formulacion_fin"]);
                        fila["FERMENTACION"] = Convert.ToString(row["fermentacion"]);
                        fila["VOLUMEN"] = Convert.ToString(row["volumen_mosto"]);
                        // fila["MSJ"] = ConvertImageToByteArray(Properties.Resources.speech_bubble__4_, System.Drawing.Imaging.ImageFormat.Png);
                        
                        // FUNCIÓN PARA ADJUNTAR EL SIMBOLO DE MAGUEY DIFERENTE DEPENDIENDO DEL ESTADO DE LA PRODUCCIÓN
                        if (tipoTapada == "1" && fila["MAGUEY"].ToString() == "")
                        {
                            string guiaTapada = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM produccion_entrada  WHERE id_produccion_entrada='" + id + "'");
                            if (guiaTapada == "0")
                            {

                                fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.internet__1_, System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                        else
                        {
                            fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.management128, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        fila["OBS."] = ConvertImageToByteArray(Properties.Resources.eye__12_, System.Drawing.Imaging.ImageFormat.Png);
                        fila["DESTILACION"] = ConvertImageToByteArray(Properties.Resources.send, System.Drawing.Imaging.ImageFormat.Png);
                        dtsFormulacion.Tables["FORMULACION"].Rows.Add(fila);
                    }
                }

                //carga los datos de destilacion
                else if (BanderaDestilacion == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  produccion_entrada.tipo,produccion_entrada.porcentaje_art,produccion_entrada.tapada,produccion_entrada.id_produccion_entrada,DATE_FORMAT(produccion_entrada.fecha, '%d/%m/%Y') as fecha,paraje.paraje,PREDIOE.predio,IF(produccion_entrada.id_predio LIKE 'P%' or produccion_entrada.id_predio = '" + 0 + "' ,'AMMA','CRM') AS origen,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey,DATE_FORMAT(produccion_entrada.periodo_destilacion_inicio, '%d/%m/%Y') as periodo_destilacion_inicio,cat_destilacion.destilacion FROM produccion_entrada LEFT JOIN paraje ON produccion_entrada.id_predio=paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN existenciaplanta ON produccion_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_destilacion ON produccion_entrada.id_destilacion=cat_destilacion.id_destilacion  LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada,paraje.paraje,comun.nombre as maguey,produccion_ensamble.agave_coccion_kg  FROM produccion_ensamble INNER JOIN paraje ON paraje.id_paraje=produccion_ensamble.id_predio INNER JOIN existenciaplanta ON produccion_ensamble.id_planta=existenciaplanta.id_plantas INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada where produccion_entrada.id_fabrica='" + CmbFabrica.SelectedValue + "' AND   (produccion_entrada.periodo_destilacion_fin='0000-00-00' or produccion_entrada.estatus=4) and  produccion_entrada.estatus  NOT IN (1,2,3) GROUP BY produccion_entrada.id ");

                    DataRow fila;
                    dtsDestilacion.Tables["DESTILACION"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsDestilacion.Tables["DESTILACION"].NewRow();
                        fila["ID_PRODUCCION"] = Convert.ToString(row["id_produccion_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_PRODUCCION"] = Convert.ToString(row["tapada"]);
                        fila["ART"] = Convert.ToString(row["porcentaje_art"]);
                        fila["TIPO"] = Convert.ToString(row["tipo"]);
                        string tipoTapada = Convert.ToString(row["tipo"]);
                        string maguey = Convert.ToString(row["maguey"]);
                        #region METODO COMO ESTABA ANTES DE MODIFICAR POR TEMAS DE GUIAS EXTERNAS Y MUESTRE LA INFO DE ESAS TAPADAS
                        /*
                        if (Convert.ToString(row["paraje"]) == "")
                        {
                            fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }*/
                        #endregion

                        //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA
                        /*if (Convert.ToString(row["paraje"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_paraje"]) == "")
                            {
                                fila["PREDIO"] = Convert.ToString(row["predio"]);
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                            }
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }

                        //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_maguey"]) == "")
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                            }
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }*/
                        string id = Convert.ToString(row["id_produccion_entrada"]);
                        string C_origenTapada = Convert.ToString(row["origen"]);

                        if (C_origenTapada == "AMMA")
                        {
                            //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA 
                            if (Convert.ToString(row["paraje"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_paraje"]) == "")
                                {
                                    fila["PREDIO"] = Convert.ToString(row["predio"]);
                                }
                                else
                                {
                                    fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                                }
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["paraje"]);
                            }

                            //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                            if (Convert.ToString(row["maguey"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_maguey"]) == "")
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                                }
                                else
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                                }
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                            }
                        }// fin del IF que valida si es guía AMMA y ahora va a entrar a buscar los datos de especie crm y predios
                        else
                        {
                            if (C_origenTapada == "CRM")
                            {
                                DataSet Datoscrm = new DataSet();
                                ConexionMysql.llenaDataset(ref Datoscrm, "SELECT reveca2_paraje.paraje,PREDIOE.predio,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey FROM produccion_entrada LEFT JOIN reveca2_paraje ON produccion_entrada.id_predio=reveca2_paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN reveca2_existenciaplanta ON produccion_entrada.id_planta=reveca2_existenciaplanta.id_plantas  LEFT JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_coccion ON produccion_entrada.id_coccion=cat_coccion.id_coccion  LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada, reveca2_paraje.paraje, comun.nombre as maguey, produccion_ensamble.no_pinas_agave, produccion_ensamble.agave_kg, produccion_ensamble.agave_coccion_kg, produccion_ensamble.porcentaje_art  FROM produccion_ensamble LEFT JOIN reveca2_paraje ON reveca2_paraje.id_paraje=produccion_ensamble.id_predio  INNER JOIN reveca2_existenciaplanta ON produccion_ensamble.id_planta=reveca2_existenciaplanta.id_plantas  INNER JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada WHERE produccion_entrada.id_produccion_entrada='" + id + "'");

                                foreach (DataRow filacrm in Datoscrm.Tables[0].Rows)
                                {
                                    if (Convert.ToString(filacrm["paraje"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_paraje"]) == "")
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["predio"]);
                                        }
                                        else
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["ensamble_paraje"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["PREDIO"] = Convert.ToString(filacrm["paraje"]);
                                    }

                                    //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                                    if (Convert.ToString(filacrm["maguey"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_maguey"]) == "")
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["maguey_comun"]);
                                        }
                                        else
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["ensamble_maguey"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["MAGUEY"] = Convert.ToString(filacrm["maguey"]);
                                    }

                                }
                            }
                        }




                        fila["FECHA_INICIO_DES"] = Convert.ToString(row["periodo_destilacion_inicio"]);
                        fila["DESTILACION"] = Convert.ToString(row["destilacion"]);
                        //fila["MSJ"] = ConvertImageToByteArray(Properties.Resources.speech_bubble__4_, System.Drawing.Imaging.ImageFormat.Png);

                        if (tipoTapada == "1" && fila["MAGUEY"].ToString() == "")
                        {
                            string guiaTapada = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM produccion_entrada  WHERE id_produccion_entrada='" + id + "'");
                            if (guiaTapada == "0")
                            {

                                fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.internet__1_, System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                        else
                        {
                            fila["ADD GUIA"] = ConvertImageToByteArray(Properties.Resources.management128, System.Drawing.Imaging.ImageFormat.Png);
                        }

                        fila["OBS."] = ConvertImageToByteArray(Properties.Resources.eye__12_, System.Drawing.Imaging.ImageFormat.Png);
                        fila["PRODUCCION"] = ConvertImageToByteArray(Properties.Resources.send, System.Drawing.Imaging.ImageFormat.Png);
                        dtsDestilacion.Tables["DESTILACION"].Rows.Add(fila);
                    }
                }


                //carga los datos de PRODUCCION
                else if (BanderaProduccion == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  produccion_entrada.litros_puntas,produccion_entrada.grados_puntas,produccion_entrada.litros_colas,produccion_entrada.grados_colas,produccion_entrada.rendimiento,produccion_entrada.agave_coccion_kg,produccion_entrada.lts_producidos,produccion_entrada.tipo,produccion_entrada.porcentaje_art, produccion_entrada.tapada,produccion_entrada.lts_existentes,produccion_entrada.grado_alcoholico,produccion_entrada.id_produccion_entrada,DATE_FORMAT(produccion_entrada.fecha, '%d/%m/%Y') as fecha,paraje.paraje,PREDIOE.predio,IF(produccion_entrada.id_predio LIKE 'P%' or produccion_entrada.id_predio = '" + 0 + "' ,'AMMA','CRM') AS origen,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey,DATE_FORMAT(produccion_entrada.periodo_destilacion_fin, '%d/%m/%Y') as periodo_destilacion_fin,produccion_entrada.destilado_con  FROM produccion_entrada LEFT JOIN paraje ON produccion_entrada.id_predio=paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN existenciaplanta ON produccion_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada,paraje.paraje,comun.nombre as maguey,produccion_ensamble.agave_coccion_kg FROM produccion_ensamble INNER JOIN paraje ON paraje.id_paraje=produccion_ensamble.id_predio INNER JOIN existenciaplanta ON produccion_ensamble.id_planta=existenciaplanta.id_plantas INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada where produccion_entrada.id_fabrica='" + CmbFabrica.SelectedValue + "' AND estatus=5 and lts_existentes > 0 GROUP BY produccion_entrada.id ");

                    DataRow fila;
                    dtsProduccion.Tables["PRODUCCION"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProduccion.Tables["PRODUCCION"].NewRow();

                        fila["LITRO_PUNTAS"] = Convert.ToString(row["litros_puntas"]);
                        fila["GRADO_PUNTAS"] = Convert.ToString(row["grados_puntas"]);
                        fila["LITRO_COLAS"] = Convert.ToString(row["litros_colas"]);
                        fila["GRADO_COLAS"] = Convert.ToString(row["grados_colas"]);
                        fila["ID_PRODUCCION"] = Convert.ToString(row["id_produccion_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_PRODUCCION"] = Convert.ToString(row["tapada"]);
                        fila["TIPO"] = Convert.ToString(row["tipo"]);
                        fila["ART"] = Convert.ToString(row["porcentaje_art"]);
                        fila["LTS_PRODUCIDOS_REALES"] = Convert.ToString(row["lts_producidos"]);
                        fila["KG_AGAVE"] = Convert.ToString(row["agave_coccion_kg"]);
                        fila["ART"] = Convert.ToString(row["porcentaje_art"]);

                        #region METODO COMO ESTABA ANTES DE MODIFICAR POR EL TEMA DE GUIAS EXTERNAS PARA QUE MUESTRE LOS DATOS DE LAS TAPADAS
                        /*
                        if (Convert.ToString(row["paraje"]) == "")
                        {
                            fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }
                        */
                        #endregion

                        //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA
                        /*
                        if (Convert.ToString(row["paraje"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_paraje"]) == "")
                            {
                                fila["PREDIO"] = Convert.ToString(row["predio"]);
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                            }
                        }
                        else
                        {
                            fila["PREDIO"] = Convert.ToString(row["paraje"]);
                        }

                        //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                        if (Convert.ToString(row["maguey"]) == "")
                        {
                            if (Convert.ToString(row["ensamble_maguey"]) == "")
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                            }
                        }
                        else
                        {
                            fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                        }*/


                        string id = Convert.ToString(row["id_produccion_entrada"]);
                        string C_origenTapada = Convert.ToString(row["origen"]);
                        // MessageBox.Show(C_origenTapada);
                        if (C_origenTapada == "AMMA")
                        {
                            //SE MODIFICA ESTA PARTE PARA QUE PUEDA AHORA MOSTRAR DATOS DE LAS TAPADAS CON GUIAS EXTERNAS DONDE EL PREDIO ESTÁ EN OTRA TABLA 
                            if (Convert.ToString(row["paraje"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_paraje"]) == "")
                                {
                                    fila["PREDIO"] = Convert.ToString(row["predio"]);
                                }
                                else
                                {
                                    fila["PREDIO"] = Convert.ToString(row["ensamble_paraje"]);
                                }
                            }
                            else
                            {
                                fila["PREDIO"] = Convert.ToString(row["paraje"]);
                            }

                            //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                            if (Convert.ToString(row["maguey"]) == "")
                            {
                                if (Convert.ToString(row["ensamble_maguey"]) == "")
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["maguey_comun"]);
                                }
                                else
                                {
                                    fila["MAGUEY"] = Convert.ToString(row["ensamble_maguey"]);
                                }
                            }
                            else
                            {
                                fila["MAGUEY"] = Convert.ToString(row["maguey"]);
                            }
                        }// fin del IF que valida si es guía AMMA y ahora va a entrar a buscar los datos de especie crm y predios
                        else
                        {
                            if (C_origenTapada == "CRM")
                            {
                                DataSet Datoscrm = new DataSet();
                                ConexionMysql.llenaDataset(ref Datoscrm, "SELECT reveca2_paraje.paraje,PREDIOE.predio,comun.nombre as maguey,comun2.nombre AS maguey_comun,GROUP_CONCAT(DISTINCT TABLA.paraje) as ensamble_paraje,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey FROM produccion_entrada LEFT JOIN reveca2_paraje ON produccion_entrada.id_predio=reveca2_paraje.id_paraje LEFT JOIN (SELECT gd.id_produccion_entrada, gd.predio FROM guias_desconocidas AS gd)PREDIOE ON produccion_entrada.id_produccion_entrada = PREDIOE.id_produccion_entrada LEFT JOIN reveca2_existenciaplanta ON produccion_entrada.id_planta=reveca2_existenciaplanta.id_plantas  LEFT JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun AS comun2 ON produccion_entrada.id_comun = comun2.id_comun INNER JOIN cat_coccion ON produccion_entrada.id_coccion=cat_coccion.id_coccion  LEFT JOIN (SELECT produccion_ensamble.id_produccion_entrada, reveca2_paraje.paraje, comun.nombre as maguey, produccion_ensamble.no_pinas_agave, produccion_ensamble.agave_kg, produccion_ensamble.agave_coccion_kg, produccion_ensamble.porcentaje_art  FROM produccion_ensamble LEFT JOIN reveca2_paraje ON reveca2_paraje.id_paraje=produccion_ensamble.id_predio  INNER JOIN reveca2_existenciaplanta ON produccion_ensamble.id_planta=reveca2_existenciaplanta.id_plantas  INNER JOIN comun ON reveca2_existenciaplanta.id_comun=comun.id_comun)TABLA ON produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada WHERE produccion_entrada.id_produccion_entrada='" + id + "'");

                                foreach (DataRow filacrm in Datoscrm.Tables[0].Rows)
                                {
                                    if (Convert.ToString(filacrm["paraje"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_paraje"]) == "")
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["predio"]);
                                        }
                                        else
                                        {
                                            fila["PREDIO"] = Convert.ToString(filacrm["ensamble_paraje"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["PREDIO"] = Convert.ToString(filacrm["paraje"]);
                                    }

                                    //SE MODIFICA PARA QUE PUEDA MOSTRAR DATOS DE MAGUEY CON BASE AL COMUN DE LAS TAPADAS CON GUIA EXTERNA QUE SON LAS QUE LLEVARAN ESE DATO
                                    if (Convert.ToString(filacrm["maguey"]) == "")
                                    {
                                        if (Convert.ToString(filacrm["ensamble_maguey"]) == "")
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["maguey_comun"]);
                                        }
                                        else
                                        {
                                            fila["MAGUEY"] = Convert.ToString(filacrm["ensamble_maguey"]);
                                        }
                                    }
                                    else
                                    {
                                        fila["MAGUEY"] = Convert.ToString(filacrm["maguey"]);
                                    }

                                }
                            }
                        }



                        fila["FECHA_FIN"] = Convert.ToString(row["periodo_destilacion_fin"]);

                        fila["LTS_PRODUCIDOS"] = Convert.ToString(row["lts_existentes"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);

                        if (Convert.ToString(row["destilado_con"]) != "")
                        {

                            fila["DESTILADO_CON"] = Convert.ToString(row["destilado_con"]);// --- Agregado 
                        }
                        else { fila["DESTILADO_CON"] = "----"; }

                        fila["RENDIMIENTO_ESTATUS"] = Convert.ToString(row["rendimiento"]);
                        //fila["MSJ"] = ConvertImageToByteArray(Properties.Resources.speech_bubble__4_, System.Drawing.Imaging.ImageFormat.Png);
                        fila["OBS."] = ConvertImageToByteArray(Properties.Resources.eye__12_, System.Drawing.Imaging.ImageFormat.Png);
                        if (Convert.ToString(row["rendimiento"]) == "0")
                        {
                            fila["RENDIMIENTO"] = ConvertImageToByteArray(Properties.Resources.clipboard, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else if (Convert.ToString(row["rendimiento"]) == "1")
                        {
                            fila["RENDIMIENTO"] = ConvertImageToByteArray(Properties.Resources.checked__1_, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else if (Convert.ToString(row["rendimiento"]) == "2")
                        {
                            fila["RENDIMIENTO"] = ConvertImageToByteArray(Properties.Resources.cancelar, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        // fila["OBSERVACIONES"] = ConvertImageToByteArray(Properties.Resources.eye__12_, System.Drawing.Imaging.ImageFormat.Png);


                        dtsProduccion.Tables["PRODUCCION"].Rows.Add(fila);
                    }
                }

            }

        }



        //agregar maestro fabrica
        private void BtnAgregarMaestroMezcal_Click(object sender, EventArgs e)
        {
            FrmNuevoMaestroFabrica frm = new FrmNuevoMaestroFabrica();
            frm.no_cliente = CmbNoCliente.SelectedValue.ToString();
            frm.ShowDialog();


            ConexionMysql.llenaCombo(ref CmbFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoCliente.SelectedValue + "'", "id_fabrica", "fabrica");
            if (Usuario.FabricaSeleccionada != "0")
            {
                CmbFabrica.SelectedValue = Usuario.FabricaSeleccionada;
            }
        }


        //al seleccionar un tap pone en true la bandera para cargar sus datos
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {

                BanderaCoccion = true;
                BanderaMolienda = false;
                BanderaFormulacion = false;
                BanderaDestilacion = false;
                BanderaProduccion = false;
                CmbFabrica_SelectedIndexChanged(null, null);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {

                BanderaCoccion = false;
                BanderaMolienda = true;
                BanderaFormulacion = false;
                BanderaDestilacion = false;
                BanderaProduccion = false;
                CmbFabrica_SelectedIndexChanged(null, null);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                BanderaCoccion = false;
                BanderaMolienda = false;
                BanderaFormulacion = true;
                BanderaDestilacion = false;
                BanderaProduccion = false;
                CmbFabrica_SelectedIndexChanged(null, null);

            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                BanderaCoccion = false;
                BanderaMolienda = false;
                BanderaFormulacion = false;
                BanderaDestilacion = true;
                BanderaProduccion = false;
                CmbFabrica_SelectedIndexChanged(null, null);

            }
            else if (tabControl1.SelectedTab == tabPage6)
            {
                BanderaCoccion = false;
                BanderaMolienda = false;
                BanderaFormulacion = false;
                BanderaDestilacion = false;
                BanderaProduccion = true;
                CmbFabrica_SelectedIndexChanged(null, null);

            }
        }

        //al presionar ensamble abre nuevo formulario
        private void BtnEnsamblePredio_Click(object sender, EventArgs e)
        {
            FrmEnsamblePredio frm = new FrmEnsamblePredio();
            if (CmbNoCliente.SelectedValue != null)
            {
                frm.no_cliente = CmbNoCliente.SelectedValue.ToString();
            }
            frm.ShowDialog();
            tabControl1.SelectedTab = tabPage1;
            BanderaCoccion = true;
            BanderaMolienda = false;
            BanderaFormulacion = false;
            BanderaDestilacion = false;
            BanderaProduccion = false;
            CmbFabrica_SelectedIndexChanged(null, null);
        }



        //al chequear el agave sobrante abre nueva ventana 
        private void ChekAgaveSobrante_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekAgaveSobrante.Checked == true)
            {
                CmbNoCliente.Enabled = false;
                CmbNoPredio.Enabled = false;
                BtnEnsamblePredio.Enabled = false;
                CmbMaguey.Enabled = false;
                TxtExtraccion.Enabled = false;
                BtnExtraccion.Enabled = false;
                TxtAgaveEntranteKg.Enabled = false;
                ChekMagueyComprado.Enabled = false;
                ChekDesconosco.Enabled = false;
                ChekMagueyComprado.Enabled = false;
                FrmAgaveSobrante frm = new FrmAgaveSobrante();
                if (CmbNoCliente.SelectedValue != null)
                {
                    frm.no_cliente = CmbNoCliente.SelectedValue.ToString();
                }
                frm.ShowDialog();
                if (frm.agave_kg == "")
                {
                    CmbNoCliente.Enabled = true;
                    CmbNoPredio.Enabled = true;
                    BtnEnsamblePredio.Enabled = true;
                    CmbMaguey.Enabled = true;
                    TxtExtraccion.Enabled = true;
                    BtnExtraccion.Enabled = true;
                    TxtAgaveEntranteKg.Enabled = true;
                    ChekAgaveSobrante.Checked = false;
                    ChekMagueyComprado.Enabled = true;
                    TxtAgaveEntranteKg.Text = "";
                    id_predio_agave_sobrante = "";
                    id_plnata_agave_sobrante = "";
                    id_produccion_entrada_sobrante = "";
                    id_agave_sobrante = "";
                    porcen_art_sobrante = "";
                }
                else
                {
                    TxtAgaveEntranteKg.Text = frm.agave_kg;
                    id_predio_agave_sobrante = frm.predio;
                    id_plnata_agave_sobrante = frm.planta;
                    id_produccion_entrada_sobrante = frm.produccion;
                    id_agave_sobrante = frm.id;
                    porcen_art_sobrante = frm.art;
                    if (porcen_art_sobrante != "0")
                    {
                        TxtArt.Text = porcen_art_sobrante;
                        TxtArt.Enabled = false;
                    }
                }
            }
            else
            {
                CmbNoCliente.Enabled = true;
                CmbNoPredio.Enabled = true;
                BtnEnsamblePredio.Enabled = true;
                CmbMaguey.Enabled = true;
                TxtExtraccion.Enabled = true;
                BtnExtraccion.Enabled = true;
                TxtAgaveEntranteKg.Enabled = true;
                ChekMagueyComprado.Enabled = true;
                TxtAgaveEntranteKg.Text = "";
                id_predio_agave_sobrante = "";
                id_plnata_agave_sobrante = "";
                id_produccion_entrada_sobrante = "";
                id_agave_sobrante = "";
                porcen_art_sobrante = "";
                TxtArt.Text = "";
                TxtArt.Enabled = true;
                ChekDesconosco.Enabled = true;
                ChekMagueyComprado.Enabled = true;

            }
        }


        //al seleccionar un numero de cliente carga los parajes asociados a ese cliente y los movimientos de produccion dependiendo que tab se presiono
        private void CmbNoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbFabrica.DataSource = null;
                TxtMaestroMezcalero.Text = "";
                CmbNoPredio.DataSource = null;
                if (CmbNoCliente.DataSource != null)
                {    /* -- la consulta selecciona el predio del asociado -- */
                    // -- ConexionMysql.llenaCombo(ref CmbNoPredio, "SELECT id_paraje FROM paraje where id_cliente='" + CmbNoCliente.SelectedValue + "'", "id_paraje", "id_paraje");
                    ConexionMysql.llenaCombo(ref CmbFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoCliente.SelectedValue + "'", "id_fabrica", "fabrica");
                    if (Usuario.FabricaSeleccionada != "0")
                    {
                        CmbFabrica.SelectedValue = Usuario.FabricaSeleccionada;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //al precionar carga maguey comprado :) 
        private void ChekMagueyComprado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekMagueyComprado.Checked == true)
            {
                TxtNoGuia.Enabled = false;
                TxtNoPredio.Enabled = false;
                CmbNoPredio.Enabled = false;
                TxtNoGuia.Text = "";
                TxtNoPredio.Text = "";
                TxtPredio.Text = "";
                CmbMaguey.DataSource = null;

                CmbNoPredio.DataSource = null;
                ChekDesconosco.Enabled = false;
                ChekAgaveSobrante.Enabled = false;

                if (chkGuiaAntigua.Checked == true)
                { 
                // ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas WHERE   existenciaplanta_comprada.no_cliente='" + CmbNoCliente.SelectedValue + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + CmbNoCliente.SelectedValue + "'");
                //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta, CONCAT(comun.nombre,'  ',existenciaplanta.edad,  '  años (', especie.genespecie,')') AS Maguey FROM existenciaplanta INNER JOIN comun ON existenciaplanta.id_comun = comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta = existenciaplanta.id_plantas inner join especie on comun.id_especie=especie.id_especie WHERE  existenciaplanta_comprada.no_cliente = '" + CmbNoCliente.SelectedValue + "' AND existenciaplanta.edad >= 5 AND existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta, CONCAT(comun.nombre,'  ',reveca2_existenciaplanta.edad,  '  años (', especie.genespecie,')') AS Maguey FROM reveca2_existenciaplanta INNER JOIN comun ON reveca2_existenciaplanta.id_comun = comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta = reveca2_existenciaplanta.id_plantas inner join especie on comun.id_especie=especie.id_especie WHERE  reveca2_existenciaplanta_comprada.no_cliente = '" + clienteCrm + "' AND reveca2_existenciaplanta.edad >= 5 AND reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                }
                else
                {
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta, CONCAT(comun.nombre,'  ',existenciaplanta.edad,  '  años (', especie.genespecie,')') AS Maguey FROM existenciaplanta INNER JOIN comun ON existenciaplanta.id_comun = comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta = existenciaplanta.id_plantas inner join especie on comun.id_especie=especie.id_especie WHERE  existenciaplanta_comprada.no_cliente = '" + CmbNoCliente.SelectedValue + "' AND existenciaplanta.edad >= 5 AND existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                }
            }
            else
            {

                TxtNoGuia.Enabled = true;
                TxtNoPredio.Enabled = true;
                CmbMaguey.DataSource = null;
                CmbNoPredio.Enabled = true;
                ChekDesconosco.Enabled = true;
                ChekAgaveSobrante.Enabled = true;
                /*-- Deshabilitado por agregar el numero de guia de maguey -- */
                // -- ConexionMysql.llenaCombo(ref CmbNoPredio, "SELECT id_paraje FROM paraje where id_cliente='" + CmbNoCliente.SelectedValue + "'", "id_paraje", "id_paraje");
                CmbFabrica_SelectedIndexChanged(sender, e);

            }
        }


        //crea la tabla de produccion
        private void addTablasCoccion()
        {
            dtsCoccion = new DataSet();
            dtsCoccion.Tables.Add("COCCION");
            dtsCoccion.Tables["COCCION"].Columns.Add("ID_PRODUCCION", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("FECHA_INICIO_MOLIENDA", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("TIPO", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("NO_PRODUCCION", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("COCCION", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("PREDIO", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("MAGUEY", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("NUMERO_PIÑAS", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("MAGUEY_ENTRANTE", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("MAGUEY_COCCION", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("ART", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("FECHA_INICIO", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("FECHA_FIN", Type.GetType("System.String"));
            dtsCoccion.Tables["COCCION"].Columns.Add("ADD GUIA", Type.GetType("System.Byte[]"));
            //dtsCoccion.Tables["COCCION"].Columns.Add("MSJ", Type.GetType("System.Byte[]"));
            dtsCoccion.Tables["COCCION"].Columns.Add("OBS.", Type.GetType("System.Byte[]"));
            dtsCoccion.Tables["COCCION"].Columns.Add("MOLIENDA", Type.GetType("System.Byte[]"));
            //dtsCoccion.Tables["COCCION"].Columns.Add("OBSERVACIONES", Type.GetType("System.Byte[]"));
            DtaCoccion.DataSource = dtsCoccion.Tables["COCCION"];
            DtaCoccion.Columns[0].Visible = false;
            DtaCoccion.Columns[1].Visible = false;
            DtaCoccion.Columns[2].Visible = false;
        }

        //abre la ventana para realizar extraccion de maguey
        private void BtnExtraccion_Click(object sender, EventArgs e)
        {
            FrmExtraccionAgaveDos Frm = new FrmExtraccionAgaveDos();
            Frm.no_cliente = CmbNoCliente.SelectedValue.ToString();
            Frm.ShowDialog();
            tabControl1.SelectedTab = tabPage1;
            BanderaCoccion = true;
            BanderaMolienda = false;
            BanderaFormulacion = false;
            BanderaDestilacion = false;
            BanderaProduccion = false;
            CmbFabrica_SelectedIndexChanged(null, null);
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



        //al seleccionar un numero de predio carga el nombre y existencia de maguey del mismo
        private void CmbNoPredio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbMaguey.DataSource = null;
                TxtPredio.Text = "";
                if (CmbNoPredio.DataSource != null)
                {
                    TxtPredio.Text = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  paraje  WHERE id_paraje=" + CmbNoPredio.SelectedValue + "");
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //al seleccionar un maguey mostrar su existencia 
        private void CmbMaguey_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TxtExistencia.Text = "";
                TxtExtraccion.Text = "";
                if (CmbMaguey.DataSource != null)
                {
                    if (ChekMagueyComprado.Checked == true)
                    {
                        if (chkGuiaAntigua.Checked == true) {
                            string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + CmbNoCliente.SelectedValue + "'");
                            //TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + CmbNoCliente.SelectedValue + "' and existenciaplantas > 0");
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + clienteCrm + "' and existenciaplantas > 0");

                            //no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + CmbNoCliente.SelectedValue + "' and existenciaplantas > 0");
                            no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + clienteCrm + "' and existenciaplantas > 0");
                            //id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  reveca2_existenciaplanta inner join reveca2_existenciaplanta_comprada on reveca2_existenciaplanta_comprada.id_planta=reveca2_existenciaplanta.id_plantas WHERE reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                            //id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta inner join existenciaplanta_comprada on existenciaplanta_comprada.id_planta=existenciaplanta.id_plantas WHERE existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");

                        }
                        else
                        { 
                        TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + CmbNoCliente.SelectedValue + "' and existenciaplantas > 0");

                        no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + CmbNoCliente.SelectedValue + "' and existenciaplantas > 0");
                        //id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                        id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta inner join existenciaplanta_comprada on existenciaplanta_comprada.id_planta=existenciaplanta.id_plantas WHERE existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                        }
                    }
                    else
                    {
                        if(TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                        {
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            id_predio_comprado = "";
                        }
                        else { 
                        TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                        id_predio_comprado = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtAgaveEntranteKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtAgaveEntranteKg.Text);
        }

        private void TxtExtraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtAgaveCoccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtAgaveCoccion.Text);
        }
        private void TxtArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtArt.Text);
        }

        //agrega produccion para su coccion (Refactorizado para usar FrmEnsamblePredio)
        private void BtnAgregarProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmEnsambleInstancia == null || frmEnsambleInstancia.IsDisposed)
                {
                    MessageBox.Show("No ha configurado guías o predios. Haga clic en '⚙️ Asignar Guías / Predios' primero.");
                    return;
                }

                if (TxtTapada.Text == "")
                {
                    MessageBox.Show("No ha introducido el nombre de la tapada");
                    return;
                }
                
                if (CmbCoccion.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una cocción.");
                    return;
                }

                string id_fabrica = null;
                if (CmbFabrica.SelectedValue != null)
                {
                    id_fabrica = CmbFabrica.SelectedValue.ToString();
                }

                // Llamar al guardado masivo público en FrmEnsamblePredio
                frmEnsambleInstancia.PublicGuardar(TxtTapada.Text, CmbCoccion.SelectedValue.ToString(), DataFechaInicioCoccion.Value, id_fabrica);
                
                // Limpiar instancia si guardó con éxito (el form se oculta internamente)
                if(frmEnsambleInstancia.DialogResult == DialogResult.OK)
                {
                    frmEnsambleInstancia = null;
                    TxtTapada.Text = "";
                    TxtAgaveEntranteKg.Text = ""; // Por si acaso
                    addTablasProduccion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //agrega una produccion normal
        public void ProduccionNormal()
        {
            try
            {
                if (CmbNoCliente.SelectedValue == null)
                {
                    MessageBox.Show("No tienes numero de cliente disponible para seleccion");
                    return;
                }

                if (CmbMaguey.SelectedValue != null)
                {
                    if (TxtExistencia.Text == "")
                    {
                        MessageBox.Show("No tienes existencia de maguey");
                        return;
                    }
                    if (TxtExtraccion.Text == "0")
                    {
                        MessageBox.Show("No puede extraer 0 piñas");
                        return;
                    }
                    if (TxtExtraccion.Text == "")
                    {
                        MessageBox.Show("No ha introduccido extracción de piñas");
                        return;
                    }
                    int existencia = int.Parse(TxtExistencia.Text);
                    int extraccion = int.Parse(TxtExtraccion.Text);

                    if (existencia < extraccion)
                    {
                        MessageBox.Show("Existencia insificiente");
                        return;
                    }

                }

                if (CmbFabrica.SelectedValue == null)
                {
                    MessageBox.Show("No tienes fabrica disponible para seleccion");
                    return;
                }


                if (TxtAgaveEntranteKg.Text == "")
                {
                    MessageBox.Show("No ha introduccido Kg de agave entrante");
                    return;
                }
                if (TxtAgaveCoccion.Text == "")
                {
                    MessageBox.Show("No ha introduccido Kg de agave a cocción");
                    return;
                }
                if (TxtAgaveEntranteKg.Text == ".")
                {
                    MessageBox.Show("Introduce un valor de agave entrante(KG) real");
                    return;
                }
                if (TxtAgaveCoccion.Text == ".")
                {
                    MessageBox.Show("Introduce un valor de agave a cocción(KG) real");
                    return;
                }
                double entrada = Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2);
                double salida = Math.Round(double.Parse(TxtAgaveCoccion.Text), 2);

                if (entrada < salida)
                {
                    MessageBox.Show("Kg de agave insificiente");
                    return;
                }
                if (TxtArt.Text == ".")
                {
                    MessageBox.Show("Introduce un valor ART real");
                    return;
                }
                if (TxtArt.Text == "")
                {
                    TxtArt.Text = "0";
                }
                if (TxtTapada.Text == "")
                {
                    MessageBox.Show("No ha introduccido el nombre de la tapada");
                    return;
                }

                if (CmbCoccion.SelectedValue == null)
                {
                    MessageBox.Show("No tienes cocciones precargadas, actualiza la base de datos");
                    return;
                }
                DateTime local = DateTime.Now;
                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");

                //================================================================>>> Confirmacion de datos a ingresar <<<============
                string dto = "";
                string tipo = label10.Text;
                string f = CmbNoCliente.Text;
                string o = CmbFabrica.Text;
                string p = "----";
                string pp = "----";
                string p3 = "----";
                string q = "----";
                string q1 = "----";
                string q2 = "----";
                string um = "----";
                string cont = "----";
                string a = "----";
                string c = "----";
                string b = "----";


                if (ChekDesconosco.Checked == true)
                {
                    q1 = TxtExtraccion.Text;
                    q2 = TxtAgaveEntranteKg.Text;
                    um = TxtAgaveCoccion.Text;
                    cont = TxtArt.Text;
                    a = TxtTapada.Text;
                    c = CmbCoccion.Text;
                    b = DataFechaInicioCoccion.Text;
                }
                else
                {

                    p = TxtNoPredio.Text;
                    pp = TxtPredio.Text;
                    p3 = CmbMaguey.Text;
                    q = TxtExistencia.Text;
                    q1 = TxtExtraccion.Text;
                    q2 = TxtAgaveEntranteKg.Text;
                    um = TxtAgaveCoccion.Text;
                    cont = TxtArt.Text;
                    a = TxtTapada.Text;
                    c = CmbCoccion.Text;
                    b = DataFechaInicioCoccion.Text;
                }

                dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + q + "!" + q1 + "!" + q2 + "!" + um + "!" + cont + "!" + a + "!" + c + "!" + b;

                MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
                msg.produccionok(dto);
                msg.ShowDialog();

                if (msg.DialogResult == DialogResult.Cancel) { return; }
                else
                {


                    ObtenerIdMaximoProduccionEntrada();

                    //Agregar valores de guias externas dependiendo si está chekeado produccion desconocida


                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_entrada(id_fabrica,id_maestro_mezcalero,id_produccion_entrada,no_cliente,id_predio,id_planta,no_guia,tapada,no_pinas_agave,agave_kg,agave_coccion_kg,id_coccion,periodo_coccion_inicio,porcentaje_art,id_verificador,fecha,estatus,tipo) VALUES( '" + CmbFabrica.SelectedValue + "','" + id_maestro_mezcalero + "','" + id_max_produccion_entrada + "','" + CmbNoCliente.SelectedValue + "','" + (TxtNoPredio.Text == "" ? "0" : TxtNoPredio.Text) + "'," + (CmbMaguey.SelectedValue == null ? 0 : CmbMaguey.SelectedValue) + ",'" + (TxtNoGuia.Text == "" ? "0" : TxtNoGuia.Text) + "','" + TxtTapada.Text + "' , " + TxtExtraccion.Text + "," + TxtAgaveEntranteKg.Text + "," + TxtAgaveCoccion.Text + "," + CmbCoccion.SelectedValue + ",'" + DataFechaInicioCoccion.Value.ToString("yyyy-MM-dd") + "'," + TxtArt.Text + "," + Usuario.IdUsuario + ",'" + fecha + "',1,1)") == "Error")
                    {
                        return;
                    }

                    // entra si hay agave sobrante
                    if (Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) > Math.Round(double.Parse(TxtAgaveCoccion.Text), 2))
                    {
                        //agave sobrante id
                        ObtenerIdMaximoAgaveSobrante();

                        double sobrante = Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) - Math.Round(double.Parse(TxtAgaveCoccion.Text), 2);
                        //valida si no se tiene maguye 
                        if (CmbMaguey.SelectedValue != null)
                        {
                            if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                            {
                                                            
                            string resultado = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_agave_sobrante  WHERE no_cliente='" + CmbNoCliente.SelectedValue + "'  and id_planta=" + CmbMaguey.SelectedValue + "");
                            if (resultado != "")
                            {
                                //calcula el art si se sabe cuanto tiene los dos agaves sobrantes  para actualizar el agave sobrante 
                                if (resultado != "0" && TxtArt.Text != "0")
                                {
                                    string kg_agave_crudo = ConexionMysql.regresaCampoConsulta("SELECT agave_kg FROM  produccion_agave_sobrante  WHERE no_cliente='" + CmbNoCliente.SelectedValue + "'  and id_planta=" + CmbMaguey.SelectedValue + " ");
                                    double suma = Math.Round(double.Parse(kg_agave_crudo), 2) * Math.Round(double.Parse(resultado), 2);
                                    suma += Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) * Math.Round(double.Parse(TxtArt.Text), 2);
                                    double resultado1 = suma / (Math.Round(double.Parse(kg_agave_crudo), 2) + Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2));
                                    resultado = Math.Round(resultado1, 2).ToString();
                                }
                                else
                                {
                                    resultado = "0";
                                }

                                if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET  agave_kg= agave_kg +" + sobrante + ",porcentaje_art=" + resultado + ",actualizado=0 WHERE no_cliente='" + CmbNoCliente.SelectedValue + "' and id_planta=" + CmbMaguey.SelectedValue + "") == "Error")
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_agave_sobrante(id_agave_sobrante,no_cliente,id_planta,agave_kg,porcentaje_art,id_verificador) VALUES('" + id_max_agave_sobrante + "','" + CmbNoCliente.SelectedValue + "'," + CmbMaguey.SelectedValue + "," + sobrante + "," + TxtArt.Text + "," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                            }
                            else 
                            {
                               
                                string clienteCRM = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + CmbNoCliente.SelectedValue.ToString() + "'");
                                string resultado = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  reveca2.produccion_agave_sobrante  WHERE no_cliente='" + clienteCRM + "'  and id_planta=" + CmbMaguey.SelectedValue + "");
                                if (resultado != "")
                                {
                                    //calcula el art si se sabe cuanto tiene los dos agaves sobrantes  para actualizar el agave sobrante 
                                    if (resultado != "0" && TxtArt.Text != "0")
                                    {
                                        string kg_agave_crudo = ConexionMysql.regresaCampoConsulta("SELECT agave_kg FROM  reveca2.produccion_agave_sobrante  WHERE no_cliente='" + clienteCRM + "'  and id_planta=" + CmbMaguey.SelectedValue + " ");
                                        double suma = Math.Round(double.Parse(kg_agave_crudo), 2) * Math.Round(double.Parse(resultado), 2);
                                        suma += Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) * Math.Round(double.Parse(TxtArt.Text), 2);
                                        double resultado1 = suma / (Math.Round(double.Parse(kg_agave_crudo), 2) + Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2));
                                        resultado = Math.Round(resultado1, 2).ToString();
                                    }
                                    else
                                    {
                                        resultado = "0";
                                    }

                                    if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2.produccion_agave_sobrante SET  agave_kg= agave_kg +" + sobrante + ",porcentaje_art=" + resultado + ",actualizado=0 WHERE no_cliente='" + clienteCRM + "' and id_planta=" + CmbMaguey.SelectedValue + "") == "Error")
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_agave_sobrante(id_agave_sobrante,no_cliente,id_planta,agave_kg,porcentaje_art,id_verificador) VALUES('" + id_max_agave_sobrante + "','" + CmbNoCliente.SelectedValue + "'," + CmbMaguey.SelectedValue + "," + sobrante + "," + TxtArt.Text + "," + Usuario.IdUsuario + ")") == "Error")
                                    {
                                        return;
                                    }
                                }
                            }

                    }
                        else
                        {
                           // if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_agave_sobrante(id_agave_sobrante,id_produccion_entrada,no_cliente,id_planta,agave_kg,porcentaje_art,id_verificador) VALUES( '" + id_max_agave_sobrante + "','" + id_max_produccion_entrada + "',  '" + CmbNoCliente.SelectedValue + "',0," + sobrante + "," + TxtArt.Text + "," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }

                        }



                    }


                    if (CmbMaguey.SelectedValue != null)
                    {

                        //string clienteEnvia = ConexionMysql.regresaCampoConsulta("SELECT p.id_paraje, p.id_cliente FROM reveca2.cextracciones as g inner join reveca2.paraje as p on p.id_paraje = g.id_paraje where g.id_extraccion = '" + +"'");

                        if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G") {

                            string clienteEnvia = ConexionMysql.regresaCampoConsulta("SELECT p.id_cliente FROM cextracciones as g inner join paraje as p on p.id_paraje = g.id_paraje where g.id_extraccion = '" + TxtNoGuia.Text +"'");

                            if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + TxtExtraccion.Text + "  WHERE id_plantas =" + CmbMaguey.SelectedValue + "") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES('" + (TxtNoGuia.Text == "" ? "0" : TxtNoGuia.Text) + "'," + CmbMaguey.SelectedValue + ",'" + clienteEnvia + "','" + CmbNoCliente.SelectedValue + "'," + TxtExtraccion.Text + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES('" + (TxtNoGuia.Text == "" ? "0" : TxtNoGuia.Text) + "'," + CmbMaguey.SelectedValue + "," + TxtExtraccion.Text + ",'" + fecha + "')") == "Error")
                        {
                            return;
                        }
                        }
                        else// etapa de guía CRM
                        {

                            string clienteEnvia = ConexionMysql.regresaCampoConsulta("SELECT p.id_cliente FROM reveca2_cextracciones as g inner join reveca2_paraje as p on p.id_paraje = g.id_paraje where g.id_extraccion = '" + TxtNoGuia.Text +"'");

                            if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta SET existenciaplantas=existenciaplantas-" + TxtExtraccion.Text + "  WHERE id_plantas =" + CmbMaguey.SelectedValue + "") == "Error")
                            {
                                return;
                            }
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO reveca2_retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES('" + (TxtNoGuia.Text == "" ? "0" : TxtNoGuia.Text) + "'," + CmbMaguey.SelectedValue + ",'" + clienteEnvia + "','" + CmbNoCliente.SelectedValue + "'," + TxtExtraccion.Text + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  reveca2_actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES('" + (TxtNoGuia.Text == "" ? "0" : TxtNoGuia.Text) + "'," + CmbMaguey.SelectedValue + "," + TxtExtraccion.Text + ",'" + fecha + "')") == "Error")
                            {
                                return;
                            }

                        }
                    }

              
                    ConexionMysql.transCompleta();
                    // Veri_movimientos.produccion = true;
                    TxtExtraccion.Text = "";
                    TxtAgaveEntranteKg.Text = "";
                    TxtAgaveCoccion.Text = "";
                    TxtArt.Text = "";
                    TxtTapada.Text = "";
                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";
                    MessageBox.Show("Produccion Guardada");
                    tabControl1.SelectedTab = tabPage1;
                    BanderaCoccion = true;
                    BanderaMolienda = false;
                    BanderaFormulacion = false;
                    BanderaDestilacion = false;
                    BanderaProduccion = false;
                    CmbFabrica_SelectedIndexChanged(null, null);
                    CmbNoPredio_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //agrega una produccion de agave sobrante 
        public void ProduccionAgaveSobrante()
        {
            try
            {
                if (CmbFabrica.SelectedValue == null)
                {
                    MessageBox.Show("No tienes fabrica disponible para seleccion");
                    return;
                }

                if (TxtAgaveEntranteKg.Text == "")
                {
                    MessageBox.Show("No ha introduccido Kg de agave entrante");
                    return;
                }
                if (TxtAgaveCoccion.Text == "")
                {
                    MessageBox.Show("No ha introduccido Kg de agave a cocción");
                    return;
                }
                if (TxtAgaveEntranteKg.Text == ".")
                {
                    MessageBox.Show("Introduce un valor de agave entrante(KG) real");
                    return;
                }
                if (TxtAgaveCoccion.Text == ".")
                {
                    MessageBox.Show("Introduce un valor de agave a cocción(KG) real");
                    return;
                }

                double entrada = Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2);
                double salida = Math.Round(double.Parse(TxtAgaveCoccion.Text), 2);
                if (entrada < salida)
                {
                    MessageBox.Show("Kg de agave insificiente");
                    return;
                }
                if (TxtArt.Text == ".")
                {
                    MessageBox.Show("Introduce un valor ART real");
                    return;
                }
                if (TxtArt.Text == "")
                {
                    TxtArt.Text = "0";
                }
                if (TxtTapada.Text == "")
                {
                    MessageBox.Show("No ha introduccido el nombre de la tapada");
                    return;
                }
                if (CmbCoccion.SelectedValue == null)
                {
                    MessageBox.Show("No tienes cocciones precargadas, actualiza la base de datos");
                    return;
                }

                DateTime local = DateTime.Now;
                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");

                //================================================================>>> Confirmacion de datos a ingresar <<<============
                string tipo = label10.Text;
                string f = CmbNoCliente.Text;
                string o = CmbFabrica.Text;
                string p = CmbNoPredio.Text;
                string pp = TxtPredio.Text;
                string p3 = CmbMaguey.Text;
                string q = TxtExistencia.Text;

                string q2 = TxtAgaveEntranteKg.Text;
                string um = TxtAgaveCoccion.Text;
                string cont = TxtArt.Text;
                string a = TxtTapada.Text;

                string c = CmbCoccion.Text;
                string b = DataFechaInicioCoccion.Text;



                /* DialogResult r = MsgBxGranelenvasado.Show("Cliente: " + f + "\nFabrica: " + o + "\nNo Predio: " + p + "\nPredio: " + pp + " \nMaguey : "
               + p3 + "\nExistencias : " + q +  "\nMaguey entrante(Kg): " + q2 + "\nMaguey a cocción(Kg): " + um + "\n%ART: " + cont + "\nTapada: " + a
               + "\nTipo de cocción: " + c + "\nInicio periodo de cocción: " + b, "---", "Aceptar", "Cancelar");


                 */


                string dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + q + "!" + "----" + "!" + q2 + "!" + um + "!" + cont + "!" + a + "!" + c + "!" + b;

                MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
                msg.produccionok(dto);
                msg.ShowDialog();

                if (msg.DialogResult == DialogResult.Cancel) { return; }
                else
                {



                    ObtenerIdMaximoProduccionEntrada();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_entrada(id_fabrica,id_maestro_mezcalero,id_produccion_entrada,id_agave_sobrante,no_cliente,id_predio,id_planta,tapada,no_pinas_agave,agave_kg,agave_coccion_kg,id_coccion,periodo_coccion_inicio,porcentaje_art,id_verificador,fecha,estatus,tipo) VALUES('" + CmbFabrica.SelectedValue + "','" + id_maestro_mezcalero + "','" + id_max_produccion_entrada + "','" + (id_plnata_agave_sobrante == "0" ? id_agave_sobrante : "") + "','" + CmbNoCliente.SelectedValue + "','" + (id_predio_agave_sobrante == "" ? "0" : id_predio_agave_sobrante) + "'," + id_plnata_agave_sobrante + ",'" + TxtTapada.Text + "' , 0," + TxtAgaveEntranteKg.Text + "," + TxtAgaveCoccion.Text + "," + CmbCoccion.SelectedValue + ",'" + DataFechaInicioCoccion.Value.ToString("yyyy-MM-dd") + "'," + TxtArt.Text + "," + Usuario.IdUsuario + ",'" + fecha + "',1,4)") == "Error")
                    {
                        return;
                    }

                    double sobrante = Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) - Math.Round(double.Parse(TxtAgaveCoccion.Text), 2);


                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET  agave_kg= ROUND(" + sobrante + ",2),actualizado=0 WHERE id_agave_sobrante='" + id_agave_sobrante + "' ") == "Error")
                    {
                        return;
                    }





                    ConexionMysql.transCompleta();
                    TxtExtraccion.Text = "";
                    TxtAgaveEntranteKg.Text = "";
                    TxtAgaveCoccion.Text = "";
                    TxtArt.Text = "";
                    TxtTapada.Text = "";
                    ChekAgaveSobrante.Checked = false;
                    CmbNoCliente.Enabled = true;
                    CmbNoPredio.Enabled = true;
                    BtnEnsamblePredio.Enabled = true;
                    CmbMaguey.Enabled = true;
                    TxtExtraccion.Enabled = true;
                    BtnExtraccion.Enabled = true;
                    TxtAgaveEntranteKg.Enabled = true;
                    id_predio_agave_sobrante = "";
                    id_plnata_agave_sobrante = "";
                    id_produccion_entrada_sobrante = "";
                    id_agave_sobrante = "";
                    porcen_art_sobrante = "";
                    TxtArt.Enabled = true;


                    MessageBox.Show("Producción Guardada");
                    tabControl1.SelectedTab = tabPage1;
                    BanderaCoccion = true;
                    BanderaMolienda = false;
                    BanderaFormulacion = false;
                    BanderaDestilacion = false;
                    BanderaProduccion = false;
                    CmbFabrica_SelectedIndexChanged(null, null);
                    CmbNoPredio_SelectedIndexChanged(null, null);
                    // Veri_movimientos.produccion = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        //agrega una produccion de agave comprado
        public void ProduccionAgaveComprado()
        {
            try
            {
                if (CmbNoCliente.SelectedValue == null)
                {
                    MessageBox.Show("No tienes numero de cliente disponible para seleccion");
                    return;
                }

                if (CmbMaguey.SelectedValue == null)
                {
                    MessageBox.Show("No tienes maguey");
                    return;
                }

                if (TxtExistencia.Text == "")
                {
                    MessageBox.Show("No tienes existencia de maguey");
                    return;
                }
                if (TxtExtraccion.Text == "0")
                {
                    MessageBox.Show("No puede extraer 0 piñas");
                    return;
                }
                if (TxtExtraccion.Text == "")
                {
                    MessageBox.Show("No ha introduccido extracción de piñas");
                    return;
                }

                if (CmbFabrica.SelectedValue == null)
                {
                    MessageBox.Show("No tienes fabrica disponible para seleccion");
                    return;
                }
                int existencia = int.Parse(TxtExistencia.Text);
                int extraccion = int.Parse(TxtExtraccion.Text);

                if (existencia < extraccion)
                {
                    MessageBox.Show("Existencia insificiente");
                    return;
                }
                if (TxtAgaveEntranteKg.Text == "")
                {
                    MessageBox.Show("No ha introduccido Kg de agave entrante");
                    return;
                }
                if (TxtAgaveCoccion.Text == "")
                {
                    MessageBox.Show("No ha introduccido Kg de agave a cocción");
                    return;
                }
                if (TxtAgaveEntranteKg.Text == ".")
                {
                    MessageBox.Show("Introduce un valor de agave entrante(KG) real");
                    return;
                }
                if (TxtAgaveCoccion.Text == ".")
                {
                    MessageBox.Show("Introduce un valor de agave a cocción(KG) real");
                    return;
                }
                double entrada = Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2);
                double salida = Math.Round(double.Parse(TxtAgaveCoccion.Text), 2);

                if (entrada < salida)
                {
                    MessageBox.Show("Kg de agave insificiente");
                    return;
                }
                if (TxtArt.Text == ".")
                {
                    MessageBox.Show("Introduce un valor ART real");
                    return;
                }
                if (TxtArt.Text == "")
                {
                    TxtArt.Text = "0";
                }
                if (TxtTapada.Text == "")
                {
                    MessageBox.Show("No ha introduccido el nombre de la tapada");
                    return;
                }

                if (CmbCoccion.SelectedValue == null)
                {
                    MessageBox.Show("No tienes cocciones precargadas, actualiza la base de datos");
                    return;
                }
                DateTime local = DateTime.Now;
                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");

                //================================================================>>> Confirmacion de datos a ingresar <<<============
                string tipo = label10.Text;
                string f = CmbNoCliente.Text;
                string o = CmbFabrica.Text;
                //string p = CmbNoPredio.Text;
                //string pp = TxtPredio.Text;
                string p3 = CmbMaguey.Text;
                string q = TxtExistencia.Text;
                string q1 = TxtExtraccion.Text;
                string q2 = TxtAgaveEntranteKg.Text;
                string um = TxtAgaveCoccion.Text;
                string cont = TxtArt.Text;
                string a = TxtTapada.Text;

                string c = CmbCoccion.Text;
                string b = DataFechaInicioCoccion.Text;

                string id_planta_comprada = "";
                if (chkGuiaAntigua.Checked == true)
                {
                    id_planta_comprada = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    //MessageBox.Show(id_planta_comprada);
                }
                else
                {
                    id_planta_comprada = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                }
                
                string resultado = "";
                string clienteCRM = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + CmbNoCliente.SelectedValue.ToString() + "'");
                string dto = f + "!" + o + "!" + "----" + "!" + "----" + "!" + p3 + "!" + q + "!" + q1 + "!" + q2 + "!" + um + "!" + cont + "!" + a + "!" + c + "!" + b;

                MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
                msg.produccionok(dto);
                msg.ShowDialog();

               
                //string id_planta_comprada = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");

                if (msg.DialogResult == DialogResult.Cancel) { return; }
                else
                {
                    
                    //--Planta comprada
                    ObtenerIdMaximoProduccionEntrada();
                    //MessageBox.Show(id_planta_comprada);
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_entrada(id_fabrica,id_maestro_mezcalero,id_produccion_entrada,no_cliente,id_predio,id_planta,no_guia,tapada,no_pinas_agave,agave_kg,agave_coccion_kg,id_coccion,periodo_coccion_inicio,porcentaje_art,id_verificador,fecha,estatus,tipo) VALUES('" + CmbFabrica.SelectedValue + "','" + id_maestro_mezcalero + "','" + id_max_produccion_entrada + "','" + CmbNoCliente.SelectedValue + "','" + id_predio_comprado + "'," + id_planta_comprada + ",'" + no_guia + "','" + TxtTapada.Text + "' , " + TxtExtraccion.Text + "," + TxtAgaveEntranteKg.Text + "," + TxtAgaveCoccion.Text + "," + CmbCoccion.SelectedValue + ",'" + DataFechaInicioCoccion.Value.ToString("yyyy-MM-dd") + "'," + TxtArt.Text + "," + Usuario.IdUsuario + ",'" + fecha + "',1,3)") == "Error")
                    {
                        return;
                    }

                    //controla si hay agave sobrante de una produccio comprada  
                    if (Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) > Math.Round(double.Parse(TxtAgaveCoccion.Text), 2))
                    {
                        //agave sobrante id
                        ObtenerIdMaximoAgaveSobrante();

                        double sobrante = Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) - Math.Round(double.Parse(TxtAgaveCoccion.Text), 2);

                        if (chkGuiaAntigua.Checked== true)
                        {
                        resultado = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  reveca2.produccion_agave_sobrante  WHERE no_cliente='" + clienteCRM + "'  and id_planta=" + id_planta_comprada + " ");
                        }
                        else
                        {
                          resultado = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_agave_sobrante  WHERE no_cliente='" + CmbNoCliente.SelectedValue + "'  and id_planta=" + id_planta_comprada + " ");
                        }


                        if (resultado != "")
                        {
                            if(chkGuiaAntigua.Checked== false)
                            {

                            
                            //calcula el art si se sabe cuanto tiene los dos agaves sobrantes  para actualizar el agave sobrante 
                            if (resultado != "0" && TxtArt.Text != "0")
                            {
                                string kg_agave_crudo = ConexionMysql.regresaCampoConsulta("SELECT agave_kg FROM  produccion_agave_sobrante  WHERE no_cliente='" + CmbNoCliente.SelectedValue + "'  and id_planta=" + id_planta_comprada + " ");
                                double suma = Math.Round(double.Parse(kg_agave_crudo), 2) * Math.Round(double.Parse(resultado), 2);
                                suma += Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) * Math.Round(double.Parse(TxtArt.Text), 2);
                                double resultado1 = suma / (Math.Round(double.Parse(kg_agave_crudo), 2) + Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2));
                                resultado = Math.Round(resultado1, 2).ToString();
                            }
                            else
                            {
                                resultado = "0";
                            }

                            if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET  agave_kg= agave_kg +" + sobrante + ",porcentaje_art=" + resultado + ",actualizado=0 WHERE no_cliente='" + CmbNoCliente.SelectedValue + "' and id_planta=" + id_planta_comprada + "") == "Error")
                            {
                                return;
                            }

                            }

                            else 
                            {
                                //calcula el art si se sabe cuanto tiene los dos agaves sobrantes  para actualizar el agave sobrante 
                                if (resultado != "0" && TxtArt.Text != "0")
                                {
                                    string kg_agave_crudo = ConexionMysql.regresaCampoConsulta("SELECT agave_kg FROM  reveca2.produccion_agave_sobrante  WHERE no_cliente='" + clienteCRM + "'  and id_planta=" + id_planta_comprada + " ");
                                    double suma = Math.Round(double.Parse(kg_agave_crudo), 2) * Math.Round(double.Parse(resultado), 2);
                                    suma += Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2) * Math.Round(double.Parse(TxtArt.Text), 2);
                                    double resultado1 = suma / (Math.Round(double.Parse(kg_agave_crudo), 2) + Math.Round(double.Parse(TxtAgaveEntranteKg.Text), 2));
                                    resultado = Math.Round(resultado1, 2).ToString();
                                }
                                else
                                {
                                    resultado = "0";
                                }

                                if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2.produccion_agave_sobrante SET  agave_kg= agave_kg +" + sobrante + ",porcentaje_art=" + resultado + ",actualizado=0 WHERE no_cliente='" + clienteCRM + "' and id_planta=" + id_planta_comprada + "") == "Error")
                                {
                                    return;
                                }
                            }

                        }
                        else
                        {
                           /* if (chkGuiaAntigua.Checked == true)
                            {
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  reveca2.produccion_agave_sobrante(id_agave_sobrante,no_cliente,id_planta,agave_kg,id_verificador) VALUES('" + id_max_agave_sobrante + "','" + clienteCRM + "'," + id_planta_comprada + "," + sobrante + "," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                            else
                            {*/

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_agave_sobrante(id_agave_sobrante,no_cliente,id_planta,agave_kg,id_verificador) VALUES('" + id_max_agave_sobrante + "','" + CmbNoCliente.SelectedValue + "'," + id_planta_comprada + "," + sobrante + "," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                            //}
                        }
                    }


                    if(chkGuiaAntigua.Checked== true)
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + TxtExtraccion.Text + ", actualizado=0  WHERE id_existenciaplanta_comprada ='" + CmbMaguey.SelectedValue + "' and no_cliente='" + clienteCRM + "'") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                       if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + TxtExtraccion.Text + ", actualizado=0  WHERE id_existenciaplanta_comprada ='" + CmbMaguey.SelectedValue + "' and no_cliente='" + CmbNoCliente.SelectedValue + "'") == "Error")
                    {
                        return;
                    }//--Fin planta comprada
                    }


                    ConexionMysql.transCompleta();
                    TxtExtraccion.Text = "";
                    TxtAgaveEntranteKg.Text = "";
                    TxtAgaveCoccion.Text = "";
                    TxtArt.Text = "";
                    TxtTapada.Text = "";
                    MessageBox.Show("Producción Guardada");
                    tabControl1.SelectedTab = tabPage1;
                    BanderaCoccion = true;
                    BanderaMolienda = false;
                    BanderaFormulacion = false;
                    BanderaDestilacion = false;
                    BanderaProduccion = false;
                    CmbFabrica_SelectedIndexChanged(null, null);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //abre formulario para terminar la fecha de coccion he inicia la fecha de molienda
        private void DtaCoccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaCoccion.Columns[e.ColumnIndex].Name == "MOLIENDA")
                {
                    FrmTerminarCoccion form = new FrmTerminarCoccion();
                    form.id_produccion = DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.fecha_inicio_coccion = DtaCoccion.Rows[e.RowIndex].Cells["FECHA_INICIO"].Value.ToString();
                    form.fecha_inicio_molienda = DtaCoccion.Rows[e.RowIndex].Cells["FECHA_INICIO_MOLIENDA"].Value.ToString();
                    form.fecha_fin_coccion = DtaCoccion.Rows[e.RowIndex].Cells["FECHA_FIN"].Value.ToString();
                    form.tapada = DtaCoccion.Rows[e.RowIndex].Cells["NO_PRODUCCION"].Value.ToString();
                    form.art = DtaCoccion.Rows[e.RowIndex].Cells["ART"].Value.ToString();
                    form.tipo_produccion = DtaCoccion.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();
                    form.no_cliente = CmbNoCliente.SelectedValue.ToString();
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }
                //if (DtaCoccion.Columns[e.ColumnIndex].Name == "MSJ")
                if (DtaCoccion.Columns[e.ColumnIndex].Name == "OBS.")
                {
                    FrmMensajes form = new FrmMensajes();
                    form.id_produccion = DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.origen = "produccion";
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }

                //EDITAR LAS FECHAS DE COOCION
                if (DtaCoccion.Columns[e.ColumnIndex].Name == "FECHA_INICIO")
                {
                    FrmEditaFechas periodos = new FrmEditaFechas();
                    periodos.id_produccion = DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    periodos.id_tap = "Coccion";
                    periodos.llenaCombo();
                    periodos.ShowDialog();
                }

                if (DtaCoccion.Columns[e.ColumnIndex].Name == "PREDIO")
                {
                    DatosPredioAntiguo form = new DatosPredioAntiguo();
                    form.idTapada = DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerPredio();
                    form.ShowDialog();
                    //CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaCoccion.Columns[e.ColumnIndex].Name == "MAGUEY")
              {
                  DatoMagueyGuiaAntigua form = new DatoMagueyGuiaAntigua();
                    form.idTapada = DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerMaguey();
                    form.ShowDialog();
              }

                if (DtaCoccion.Columns[e.ColumnIndex].Name == "ADD GUIA")// FUNCIÓN PARA PODER COMPLETAR LA GUIA DE TAPADAS EN CUALQUIER PROCESO
                {
                    Boolean banderaguia = false;
                    string tipo_tapada = DtaCoccion.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();

                    if (tipo_tapada == "1" || tipo_tapada == "4")
                    {
                        string guia_externa = ConexionMysql.regresaCampoConsulta("SELECT gcrm FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                        if (guia_externa == "0")
                        {
                            string id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta == "0")
                            {
                                banderaguia = true;
                            }
                        }
                        else
                        {
                            string id_planta_comun = ConexionMysql.regresaCampoConsulta("SELECT id_comun FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta_comun == "0")
                            {
                                banderaguia = true;
                            }
                        }
                    }

                    if (banderaguia == true)
                    {
                        FrmCompletarTapda form = new FrmCompletarTapda();
                        form.no_cliente = CmbNoCliente.SelectedValue.ToString();
                        form.id_produccion = DtaCoccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                        form.tipo_tapada = tipo_tapada;
                        form.ShowDialog();

                        CmbFabrica_SelectedIndexChanged(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Esta producción ya cuenta con una guía.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
        ////////////////////////////////////////////////////////////////////////////////////---\\====(Fin PRODUCCION)======\\---//////////////////////////////////////////////////////////////////////////////////////////////

        #region TABLAS DEL PROCESO DE PRODUCCION(MOLIENDA, FORMULACIÓN,DESTILACIÓN,PRODUCCIÓN)
        ///////////////////////////////////////////////////////////////////////////---\\===(tap molienda)===\\---//////////////////////////////////////////////////////////////////////////////////////////

        //crea la tabla de molienda
        private void addTablasMolienda()
        {
            dtsMolienda = new DataSet();
            dtsMolienda.Tables.Add("MOLIENDA");
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("ID_PRODUCCION", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("ART", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("FECHA_INICIO_FORMULACION", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("NO_PRODUCCION", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("MOLIENDA", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("PREDIO", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("MAGUEY", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("FECHA_INICIO", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("FECHA_FIN", Type.GetType("System.String"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("ADD GUIA", Type.GetType("System.Byte[]"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("OBS.", Type.GetType("System.Byte[]"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("FORMULACION", Type.GetType("System.Byte[]"));
            dtsMolienda.Tables["MOLIENDA"].Columns.Add("TIPO", Type.GetType("System.String"));
            DtaMolienda.DataSource = dtsMolienda.Tables["MOLIENDA"];
            
            // dtsMolienda.Tables["MOLIENDA"].Columns.Add("Observaciones", Type.GetType("System.Byte[]"));
            DtaMolienda.Columns[1].Visible = false;
            DtaMolienda.Columns[2].Visible = false;
            DtaMolienda.Columns[3].Visible = false;
            DtaMolienda.Columns[13].Visible = false;
        }


        private void DtaMolienda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaMolienda.Columns[e.ColumnIndex].Name == "FORMULACION")
                {
                    FrmTerminarMolienda form = new FrmTerminarMolienda();
                    form.id_produccion = DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.fecha_inicio_molienda = DtaMolienda.Rows[e.RowIndex].Cells["FECHA_INICIO"].Value.ToString();
                    form.fecha_inicio_formulacion = DtaMolienda.Rows[e.RowIndex].Cells["FECHA_INICIO_FORMULACION"].Value.ToString();
                    form.fecha_fin_molienda = DtaMolienda.Rows[e.RowIndex].Cells["FECHA_FIN"].Value.ToString();
                    form.art = DtaMolienda.Rows[e.RowIndex].Cells["ART"].Value.ToString();
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaMolienda.Columns[e.ColumnIndex].Name == "OBS.")
                {
                    FrmMensajes form = new FrmMensajes();
                    form.id_produccion = DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.origen = "produccion";
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaMolienda.Columns[e.ColumnIndex].Name == "PREDIO")
                {
                    DatosPredioAntiguo form = new DatosPredioAntiguo();
                    form.idTapada = DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerPredio();
                    form.ShowDialog();
                    //CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaMolienda.Columns[e.ColumnIndex].Name == "MAGUEY")
                {
                    DatoMagueyGuiaAntigua form = new DatoMagueyGuiaAntigua();
                    form.idTapada = DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerMaguey();
                    form.ShowDialog();
                }

                //EDITAR LAS FECHAS DE MOLIENDA
                if (DtaMolienda.Columns[e.ColumnIndex].Name == "FECHA_INICIO")
                {
                    FrmEditaFechas periodos = new FrmEditaFechas();
                    periodos.id_produccion = DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    periodos.id_tap = "Molienda";
                    periodos.llenaCombo();
                    periodos.ShowDialog();
                }

                if (DtaMolienda.Columns[e.ColumnIndex].Name == "ADD GUIA")// FUNCIÓN PARA PODER COMPLETAR LA GUIA DE TAPADAS EN CUALQUIER PROCESO
                {
                    Boolean banderaguia = false;
                    string tipo_tapada = DtaMolienda.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();

                    if (tipo_tapada == "1" || tipo_tapada == "4")
                    {
                        string guia_externa = ConexionMysql.regresaCampoConsulta("SELECT gcrm FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                        if (guia_externa == "0")
                        {
                            string id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta == "0")
                            {
                                banderaguia = true;
                            }
                        }
                        else
                        {
                            string id_planta_comun = ConexionMysql.regresaCampoConsulta("SELECT id_comun FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta_comun == "0")
                            {
                                banderaguia = true;
                            }
                        }
                    }

                    if (banderaguia == true)
                    {
                        FrmEnsamblePredio form = new FrmEnsamblePredio();
                        form.no_cliente = CmbNoCliente.SelectedValue.ToString();
                        form.id_produccion_existente = DtaMolienda.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                        form.modo_completar_tapada = true;
                        form.ShowDialog();

                        CmbFabrica_SelectedIndexChanged(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Esta producción ya cuenta con una guía.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //=============================================================================[[[[[[--{Fin Tap Molienda}--]]]]]]========================================================

        ///////////////////////////////////////////////////////////////////////////---\\===(tab formulacion)===\\---////////////////////////////////////////////////////////////////////////////////////////////////

        //crea la tabla de formulacion
        private void addTablasFormulacion()
        {
            dtsFormulacion = new DataSet();
            dtsFormulacion.Tables.Add("FORMULACION");
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("ID_PRODUCCION", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("FECHA_INICIO_DESTILACION", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("ART", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("NO_PRODUCCION", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("PREDIO", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("MAGUEY", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("FECHA_INICIO", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("FECHA_FIN", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("FERMENTACION", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("ADD GUIA", Type.GetType("System.Byte[]"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("OBS.", Type.GetType("System.Byte[]"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("DESTILACION", Type.GetType("System.Byte[]"));
            dtsFormulacion.Tables["FORMULACION"].Columns.Add("TIPO", Type.GetType("System.String"));
            DtaFormulacion.DataSource = dtsFormulacion.Tables["FORMULACION"];
            DtaFormulacion.Columns[1].Visible = false;
            DtaFormulacion.Columns[2].Visible = false;
            DtaFormulacion.Columns[3].Visible = false;
            DtaFormulacion.Columns[14].Visible = false;
        }

        private void DtaFormulacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaFormulacion.Columns[e.ColumnIndex].Name == "DESTILACION")
                {
                    FrmTerminarFormulacion form = new FrmTerminarFormulacion();
                    form.id_produccion = DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.fecha_inicio_formulacion = DtaFormulacion.Rows[e.RowIndex].Cells["FECHA_INICIO"].Value.ToString();
                    form.fecha_inicio_destilacion = DtaFormulacion.Rows[e.RowIndex].Cells["FECHA_INICIO_DESTILACION"].Value.ToString();
                    form.fecha_fin_formulacion = DtaFormulacion.Rows[e.RowIndex].Cells["FECHA_FIN"].Value.ToString();
                    form.volumen = DtaFormulacion.Rows[e.RowIndex].Cells["VOLUMEN"].Value.ToString();
                    form.fermentacion = DtaFormulacion.Rows[e.RowIndex].Cells["FERMENTACION"].Value.ToString();
                    form.art = DtaFormulacion.Rows[e.RowIndex].Cells["ART"].Value.ToString();
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaFormulacion.Columns[e.ColumnIndex].Name == "OBS.")
                {
                    FrmMensajes form = new FrmMensajes();
                    form.id_produccion = DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.origen = "produccion";
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }

                if (DtaFormulacion.Columns[e.ColumnIndex].Name == "PREDIO")
                {
                    DatosPredioAntiguo form = new DatosPredioAntiguo();
                    form.idTapada = DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerPredio();
                    form.ShowDialog();
                    //CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaFormulacion.Columns[e.ColumnIndex].Name == "MAGUEY")
                {
                    DatoMagueyGuiaAntigua form = new DatoMagueyGuiaAntigua();
                    form.idTapada = DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerMaguey();
                    form.ShowDialog();
                }

                //EDITAR LAS FECHAS DE FORMULACION
                if (DtaFormulacion.Columns[e.ColumnIndex].Name == "FECHA_INICIO")
                {
                    FrmEditaFechas periodos = new FrmEditaFechas();
                    periodos.id_produccion = DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    periodos.id_tap = "Formulacion";
                    periodos.llenaCombo();
                    periodos.ShowDialog();
                }

                if (DtaFormulacion.Columns[e.ColumnIndex].Name == "ADD GUIA")// FUNCIÓN PARA PODER COMPLETAR LA GUIA DE TAPADAS EN CUALQUIER PROCESO
                {
                    Boolean banderaguia = false;
                    string tipo_tapada = DtaFormulacion.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();

                    if (tipo_tapada == "1" || tipo_tapada == "4")
                    {
                        string guia_externa = ConexionMysql.regresaCampoConsulta("SELECT gcrm FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                        if (guia_externa == "0")
                        {
                            string id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta == "0")
                            {
                                banderaguia = true;
                            }
                        }
                        else
                        {
                            string id_planta_comun = ConexionMysql.regresaCampoConsulta("SELECT id_comun FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta_comun == "0")
                            {
                                banderaguia = true;
                            }
                        }
                    }

                    if (banderaguia == true)
                    {
                        FrmEnsamblePredio form = new FrmEnsamblePredio();
                        form.no_cliente = CmbNoCliente.SelectedValue.ToString();
                        form.id_produccion_existente = DtaFormulacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                        form.modo_completar_tapada = true;
                        form.ShowDialog();

                        CmbFabrica_SelectedIndexChanged(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Esta producción ya cuenta con una guía.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //=============================================================================[[[[[[--{Fin Tap formulacion}--]]]]]]========================================================

        ////////////////////////////////////////////////////////////////////////////////////////////---\\===(TAP DESTILACION)===\\---/////////////////////////////////////////////////////////////////////////////////////////////////

        //crea la tabla de destilacion
        private void addTablasDestilacion()
        {
            dtsDestilacion = new DataSet();
            dtsDestilacion.Tables.Add("DESTILACION");
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("ID_PRODUCCION", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("ART", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("NO_PRODUCCION", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("PREDIO", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("MAGUEY", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("DESTILACION", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("FECHA_INICIO_DES", Type.GetType("System.String"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("ADD GUIA", Type.GetType("System.Byte[]"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("OBS.", Type.GetType("System.Byte[]"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("PRODUCCION", Type.GetType("System.Byte[]"));
            dtsDestilacion.Tables["DESTILACION"].Columns.Add("TIPO", Type.GetType("System.String"));
            DtaDestilacion.DataSource = dtsDestilacion.Tables["DESTILACION"];
            DtaDestilacion.Columns[1].Visible = false;
            DtaDestilacion.Columns[2].Visible = false;
            DtaDestilacion.Columns[11].Visible = false;
        }

        private void DtaDestilacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaDestilacion.Columns[e.ColumnIndex].Name == "PRODUCCION")
                {
                    FrmTerminarDestilacion form = new FrmTerminarDestilacion();
                    form.id_produccion = DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.fecha_inicio_destilacion = DtaDestilacion.Rows[e.RowIndex].Cells["FECHA_INICIO_DES"].Value.ToString();
                    form.tapada = DtaDestilacion.Rows[e.RowIndex].Cells["NO_PRODUCCION"].Value.ToString();
                    form.art = DtaDestilacion.Rows[e.RowIndex].Cells["ART"].Value.ToString();
                    form.no_cliente = CmbNoCliente.Text;
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaDestilacion.Columns[e.ColumnIndex].Name == "OBS.")
                {
                    FrmMensajes form = new FrmMensajes();
                    form.id_produccion = DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.origen = "produccion";
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }

                if (DtaDestilacion.Columns[e.ColumnIndex].Name == "PREDIO")
                {
                    DatosPredioAntiguo form = new DatosPredioAntiguo();
                    form.idTapada = DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerPredio();
                    form.ShowDialog();
                    //CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaDestilacion.Columns[e.ColumnIndex].Name == "MAGUEY")
                {
                    DatoMagueyGuiaAntigua form = new DatoMagueyGuiaAntigua();
                    form.idTapada = DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerMaguey();
                    form.ShowDialog();
                }

                //EDITAR LAS FECHAS DE DESTILACION
                if (DtaDestilacion.Columns[e.ColumnIndex].Name == "FECHA_INICIO_DES")
                {
                    FrmEditaFechas periodos = new FrmEditaFechas();
                    periodos.id_produccion = DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    periodos.id_tap = "Destilacion";
                    periodos.llenaCombo();
                    periodos.ShowDialog();
                }

                if (DtaDestilacion.Columns[e.ColumnIndex].Name == "ADD GUIA")// FUNCIÓN PARA PODER COMPLETAR LA GUIA DE TAPADAS EN CUALQUIER PROCESO
                {
                    Boolean banderaguia = false;
                    string tipo_tapada = DtaDestilacion.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();

                    if (tipo_tapada == "1" || tipo_tapada == "4")
                    {
                        string guia_externa = ConexionMysql.regresaCampoConsulta("SELECT gcrm FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                        if (guia_externa == "0")
                        {
                            string id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta == "0")
                            {
                                banderaguia = true;
                            }
                        }
                        else
                        {
                            string id_planta_comun = ConexionMysql.regresaCampoConsulta("SELECT id_comun FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta_comun == "0")
                            {
                                banderaguia = true;
                            }
                        }
                    }

                    if (banderaguia == true)
                    {
                        FrmEnsamblePredio form = new FrmEnsamblePredio();
                        form.no_cliente = CmbNoCliente.SelectedValue.ToString();
                        form.id_produccion_existente = DtaDestilacion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                        form.modo_completar_tapada = true;
                        form.ShowDialog();

                        CmbFabrica_SelectedIndexChanged(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Esta producción ya cuenta con una guía.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //=============================================================================[[[[[[--{Fin Tap Destilacion}--]]]]]]========================================================

        //////////////////////////////////////////////////////////////////////////////////////////---\\===(TAP PRODUCCION)===\\---/////////////////////////////////////////////////////////////////////////////

        //crea la tabla de PRODUCCION
        private void addTablasProduccion()
        {
            dtsProduccion = new DataSet();
            dtsProduccion.Tables.Add("PRODUCCION");
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("ID_PRODUCCION", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("TIPO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("ART", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("LTS_PRODUCIDOS_REALES", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("KG_AGAVE", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("RENDIMIENTO_ESTATUS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("LITRO_PUNTAS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("GRADO_PUNTAS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("LITRO_COLAS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("GRADO_COLAS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO_PRODUCCION", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("PREDIO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("MAGUEY", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("FECHA_FIN", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("LTS_PRODUCIDOS", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("DESTILADO_CON", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("OBS.", Type.GetType("System.Byte[]"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("RENDIMIENTO", Type.GetType("System.Byte[]"));
            // dtsProduccion.Tables["PRODUCCION"].Columns.Add("OBSERVACIONES", Type.GetType("System.Byte[]"));
            DtaProduccion.DataSource = dtsProduccion.Tables["PRODUCCION"];
            DtaProduccion.Columns[1].Visible = false;
            DtaProduccion.Columns[2].Visible = false;
            DtaProduccion.Columns[3].Visible = false;
            DtaProduccion.Columns[4].Visible = false;
            DtaProduccion.Columns[5].Visible = false;
            DtaProduccion.Columns[6].Visible = false;
            DtaProduccion.Columns[7].Visible = false;
            DtaProduccion.Columns[8].Visible = false;
            DtaProduccion.Columns[9].Visible = false;
            DtaProduccion.Columns[10].Visible = false;

        }

        private void DtaProduccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProduccion.Columns[e.ColumnIndex].Name == "RENDIMIENTO")
                {
                    //bandera para saber si la tapada esta incompleta falta id_planta
                    Boolean bandera = false;

                    // si no hay art lo pide 
                    string art = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                    if (art == "0")
                    {
                        FrmNuevoArt frm = new FrmNuevoArt();
                        frm.id = DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                        frm.ShowDialog();
                        return;
                    }


                    string tipo_tapada = DtaProduccion.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();

                    if (tipo_tapada == "1" || tipo_tapada == "4")
                    {
                        string guia_externa = ConexionMysql.regresaCampoConsulta("SELECT gcrm FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                        if (guia_externa == "0")
                        {
                            string id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta == "0")
                            {
                                bandera = true;
                            }
                        }
                        //Aquí voy a agregar si es tapada conn guia externa por la columna gcrm si tiene 1 que se vaya a buscar comun ahí mismo.
                        //Voy a comentar la linea de abajo para que se haga con base a si es guia externa no como se ha hecho siempre
                       /* string id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                        if (id_planta == "0")
                        {
                            bandera = true;
                        }*/
                       else
                        {
                            string id_planta_comun = ConexionMysql.regresaCampoConsulta("SELECT id_comun FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                            if (id_planta_comun == "0")
                            {
                                bandera = true;
                            }
                        }    
                    }
                    else if (tipo_tapada == "2")
                    {
                        DataSet Datos = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos, "SELECT id_agave_sobrante,id_agave_cocido_sobrante,id_planta from produccion_ensamble where id_produccion_entrada='" + DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString() + "' ");
                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            if (Convert.ToString(row["id_agave_sobrante"]) != "")
                            {
                                bandera = true;
                                break;
                            }
                            else if (Convert.ToString(row["id_agave_cocido_sobrante"]) != "")
                            {
                                bandera = true;
                                break;
                            }
                            else if (Convert.ToString(row["id_planta"]) == "0")
                            {
                                bandera = true;
                                break;
                            }
                        }
                    }

                    if (bandera == true)
                    {
                        FrmEnsamblePredio form = new FrmEnsamblePredio();
                        form.no_cliente = CmbNoCliente.SelectedValue.ToString();
                        form.id_produccion_existente = DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                        form.modo_completar_tapada = true;
                        form.ShowDialog();

                        CmbFabrica_SelectedIndexChanged(null, null);

                    }
                    else
                    {
                        FrmRendimientoTapada form = new FrmRendimientoTapada();
                        form.id_produccion = DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                        form.tapada = DtaProduccion.Rows[e.RowIndex].Cells["NO_PRODUCCION"].Value.ToString();
                        form.tipo = DtaProduccion.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();
                        form.art = DtaProduccion.Rows[e.RowIndex].Cells["ART"].Value.ToString();
                        form.litros_producidos = DtaProduccion.Rows[e.RowIndex].Cells["LTS_PRODUCIDOS_REALES"].Value.ToString();
                        form.agave_cocido = Math.Round(double.Parse(DtaProduccion.Rows[e.RowIndex].Cells["KG_AGAVE"].Value.ToString()), 2);
                        form.rendimiento_estatus = DtaProduccion.Rows[e.RowIndex].Cells["RENDIMIENTO_ESTATUS"].Value.ToString();
                        form.grado_alcoholico = DtaProduccion.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                        form.litros_puntas = DtaProduccion.Rows[e.RowIndex].Cells["LITRO_PUNTAS"].Value.ToString();
                        form.grados_puntas = DtaProduccion.Rows[e.RowIndex].Cells["GRADO_PUNTAS"].Value.ToString();
                        form.litros_colas = DtaProduccion.Rows[e.RowIndex].Cells["LITRO_COLAS"].Value.ToString();
                        form.grados_colas = DtaProduccion.Rows[e.RowIndex].Cells["GRADO_COLAS"].Value.ToString();
                        form.ShowDialog();
                        CmbFabrica_SelectedIndexChanged(null, null);
                    }
                }
                if (DtaProduccion.Columns[e.ColumnIndex].Name == "OBS.")
                {
                    FrmMensajes form = new FrmMensajes();
                    form.id_produccion = DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.origen = "produccion";
                    form.ShowDialog();
                    CmbFabrica_SelectedIndexChanged(null, null);
                }
                /* if (DtaProduccion.Columns[e.ColumnIndex].Name == "OBSERVACIONES")
                 {
                     Inventario.Obsevaciones.Observaciones form = new Inventario.Obsevaciones.Observaciones();
                     form.id_produccion = DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                     form.ShowDialog();
                     //CmbFabrica_SelectedIndexChanged(null, null);
                 }*/

                if (DtaProduccion.Columns[e.ColumnIndex].Name == "PREDIO")
                {
                    DatosPredioAntiguo form = new DatosPredioAntiguo();
                    form.idTapada = DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerPredio();
                    form.ShowDialog();
                    //CmbFabrica_SelectedIndexChanged(null, null);
                }
                if (DtaProduccion.Columns[e.ColumnIndex].Name == "MAGUEY")
                {
                    DatoMagueyGuiaAntigua form = new DatoMagueyGuiaAntigua();
                    form.idTapada = DtaProduccion.Rows[e.RowIndex].Cells["ID_PRODUCCION"].Value.ToString();
                    form.ObtenerMaguey();
                    form.ShowDialog();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //=============================================================================[[[[[[--{Fin Tap Produccion}--]]]]]]========================================================

        #endregion


        /////////////////////////////////////////////////////////////////////////////////////GRANEL//////////////////////////////////////////////////////////////////////////////////////////////////

        #region GRANEL DE FÁBRICA
        //agregamos granel sin saber procedencia
        private void BtnAgregarGranel_Click(object sender, EventArgs e)
        {
            if (CmbFabricaGranelFabrica.Items.Count == 0)
            {
                MessageBox.Show("No tienes una fábrica de destino, agrega una para poder realizar el movimiento");
                return;
            }
            FrmGranelNuevo frm = new FrmGranelNuevo();
            frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
            frm.tipo = "fabrica";
            frm.id_fabrica = CmbFabricaGranelFabrica.SelectedValue.ToString();
            frm.ShowDialog();
            CmbNoClienteGranel_SelectedIndexChanged(sender, e);
        }


        //boton para una transaccion 
        private void BtnTransaccionGranelFabrica_Click(object sender, EventArgs e)
        {
            FrmTransaccion frm = new FrmTransaccion();
            frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
            if (CmbFabricaGranelFabrica.Items.Count == 0)
            {
                MessageBox.Show("No tienes una fábrica de destino, agrega una para poder realizar el movimiento");
                return;
            }
            frm.id_instalacion = CmbFabricaGranelFabrica.SelectedValue.ToString();
            frm.tipo_instalacion = "granelfabrica";
            frm.ShowDialog();
            CmbFabricaGranelFabrica_SelectedIndexChanged(sender, e);
        }



        //agrega nueva fabrica  desde granel fabrica
        private void BtnNuevaFabricaDesdeGranelFabrica_Click(object sender, EventArgs e)
        {
            FrmNuevoMaestroFabrica frm = new FrmNuevoMaestroFabrica();
            frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
            frm.ShowDialog();
            ConexionMysql.llenaCombo(ref CmbFabricaGranelFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteGranel.SelectedValue.ToString() + "'", "id_fabrica", "fabrica");
            if (Usuario.FabricaSeleccionada != "0")
            {
                CmbFabricaGranelFabrica.SelectedValue = Usuario.FabricaSeleccionada;
            }

        }



        //al seleccionar el cliente carga la fabricas
        private void CmbNoClienteGranel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbFabricaGranelFabrica.DataSource = null;
                TxtMestroMezcaleroGranelFabrica.Text = "";

                ConexionMysql.llenaCombo(ref CmbFabricaGranelFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteGranel.SelectedValue + "'", "id_fabrica", "fabrica");

                lblFolioGranel.Text = "....";
                if (Usuario.FabricaSeleccionada != "0")
                {
                    CmbFabricaGranelFabrica.SelectedValue = Usuario.FabricaSeleccionada;
                    //---  se agrego este query para que al momento de que no tenga un folio no arretre el folio del   ConexionMysql.llenaCombo que se ejecuta primero

                    lblFolioGranel.Text = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM maestro_fabrica where id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "';");
                }
                else { lblFolioGranel.Text = "...."; }

                string Foliogranel = ConexionMysql.regresaCampoConsulta("SELECT folio_granel FROM  clientes  where no_cliente='" + CmbNoClienteGranel.SelectedValue + "'  ");

                if (Foliogranel == "")
                {
                    string estado = ConexionMysql.regresaCampoConsulta("SELECT estados.codigo from estados inner join relacion_cp_estado on  estados.clave=relacion_cp_estado.clave_estado inner join clientes on relacion_cp_estado.cp=clientes.cp  where clientes.no_cliente='" + CmbNoClienteGranel.SelectedValue + "'");
                    string Folio = ConexionMysql.regresaCampoConsulta("SELECT max(id_folio) FROM  folios ");
                    string foliogranel = "";
                    if (Folio == "")
                    {
                        Folio = "1";
                        foliogranel = Usuario.IdUsuario + "00000" + Folio + "GN" + estado;
                    }
                    else
                    {
                        int NuevoFolio = 0;
                        string cero = "";
                        NuevoFolio = int.Parse(Folio) + 1;
                        if (NuevoFolio.ToString().Length == 1)
                        {
                            cero = "00000";
                        }
                        else if (NuevoFolio.ToString().Length == 2)
                        {
                            cero = "0000";
                        }
                        else if (NuevoFolio.ToString().Length == 3)
                        {
                            cero = "000";
                        }
                        else if (NuevoFolio.ToString().Length == 4)
                        {
                            cero = "00";
                        }
                        else if (NuevoFolio.ToString().Length == 5)
                        {
                            cero = "0";
                        }

                        foliogranel = Usuario.IdUsuario + cero + NuevoFolio + "GR" + estado;
                    }
                    /* if (ConexionMysql.insUpd_transaccion("INSERT INTO folios(folio,actualizado) values ('" + foliogranel + "',0) ") == "Error")
                     {
                         return;
                     }
                     if (ConexionMysql.insUpd_transaccion("UPDATE clientes SET  folio_granel ='" + foliogranel + "' WHERE no_cliente='" + CmbNoClienteGranel.SelectedValue + "' ") == "Error")
                     {
                         return;
                     }*/

                    //ConexionMysql.transCompleta();
                }
                else
                {
                    //lblFolioGranel.Text = Foliogranel;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        //al seleccionar fabrica carga los inventarios
        private void CmbFabricaGranelFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                dtsProduccionParaGuardarAgranel.Clear();
                TxtLitrosParaGuardarAgranel.Text = "";
                CmbProduccion.DataSource = null;
                dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Rows.Clear();
                dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Rows.Clear();
                dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Rows.Clear();

                if (CmbFabricaGranelFabrica.SelectedValue != null)
                {


                    //-- TxtMestroMezcaleroGranelFabrica.Text = ConexionMysql.regresaCampoConsulta("SELECT if(maestro = '' or maestro is null,(SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'),maestro) as maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'");

                    TxtMestroMezcaleroGranelFabrica.Text = ConexionMysql.regresaCampoConsulta("SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'");


                    ///--- Selecciona el folio unico de granel si no tiene pide ingresarlo.. 
                    lblFolioGranel.Text = "-- S/N Folio --";


                    ///-- checar esta parte bien trae el primer cliente ... 

                    // ---  if (Convert.ToString(Usuario.No_Cliente) == Convert.ToString(CmbNoClienteGranel.SelectedValue))
                    // Convert.ToString (Usuario.FabricaSeleccionada) == Convert.ToString(CmbFabricaGranelFabrica.SelectedValue))
                    // ---  {
                    string noFolioGranelUnico = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM maestro_fabrica  WHERE id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "' AND no_cliente='" + CmbNoClienteGranel.SelectedValue + "';");


                    ///-- si es vacio el registro entra 
                    if (noFolioGranelUnico == "")
                    {
                        btnIngresarNoFolioGFabrica.Visible = true;
                        lblFolioGranel.Text = "-- S/N Folio --";



                    }
                    else
                    {
                        btnIngresarNoFolioGFabrica.Visible = false;
                        lblFolioGranel.Text = noFolioGranelUnico;

                    }


                    // ---  } ///--- fin de el if(Convert.ToString(Usuario.No_Cliente) == Convert.ToString(CmbNoClienteGranel.SelectedValue))

                    lblFolioGranel.ForeColor = Color.Red;





                    ConexionMysql.llenaComboAutocomplit(ref CmbProduccion, "SELECT  CONCAT(tapada,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico) As produccion,id_produccion_entrada   FROM produccion_entrada  where no_cliente='" + CmbNoClienteGranel.SelectedValue + "' AND id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "' and estatus=5 AND lts_existentes > 0 and rendimiento=1 order by id_produccion_entrada asc", "id_produccion_entrada", "produccion");
                    /*ConexionMysql.llenaCombo(ref CmbProduccion, "SELECT  CONCAT('Tapada : ',tapada,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico) As produccion,id_produccion_entrada   FROM produccion_entrada  where no_cliente='" + CmbNoClienteGranel.SelectedValue + "' AND id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "' and estatus=5 AND lts_existentes > 0 and rendimiento=1 order by id_produccion_entrada asc", "id_produccion_entrada", "produccion");*/





                    if (BanderaGranel == true)
                    {
                        DataSet Datos = new DataSet();
                        // ConexionMysql.llenaDataset(ref Datos, "SELECT  granel_entrada.clase, granel_entrada.id_granel_entrada, DATE_FORMAT(granel_entrada.fecha, '%d/%m/%Y') as fecha , granel_entrada.no_lote, granel_entrada.fq, granel_entrada.categoria, granel_entrada.abocante, granel_entrada.ingrediente, granel_entrada.lts_existentes, granel_entrada.grado_alcoholico_existente,  comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin, GROUP_CONCAT(DISTINCT granel_tanques.tanque) as tanque  FROM granel_entrada  LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun INNER JOIN granel_tanques ON granel_entrada.id_granel_entrada=granel_tanques.id_granel_entrada LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc,granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc) TABLA  ON granel_entrada.id_granel_entrada=TABLA.id_granel_entrada LEFT JOIN  (   SELECT granel_ensamble.id_granel_entrada,comun.nombre FROM granel_ensamble INNER JOIN comun ON granel_ensamble.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc  ) TABLA2 ON granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada WHERE granel_entrada.id_fabrica= '" + CmbFabricaGranelFabrica.SelectedValue + "' and granel_entrada.lts_existentes > 0 GROUP BY granel_entrada.id ");
                        //Se comenta la linea de abajo para probar una consulta sin entrar a revisar los ensambles para especies, y mejor se crea un store procedure para subconsulta de cada lote
                        //ConexionMysql.llenaDataset(ref Datos, "SELECT  granel_entrada.clase,  granel_entrada.id_granel_entrada,DATE_FORMAT(granel_entrada.fecha, '%d/%m/%Y') AS fecha,  granel_entrada.no_lote, granel_entrada.fq,  granel_entrada.categoria,   granel_entrada.abocante, granel_entrada.ingrediente,  granel_entrada.lts_existentes,   granel_entrada.grado_alcoholico_existente, comun.nombre AS maguey, comun2.nombre AS maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,   GROUP_CONCAT(DISTINCT TABLA.nombre  ORDER BY TABLA.id_granel_entrada ASC) AS ensamble_maguey,  GROUP_CONCAT(DISTINCT granel_tanques.tanque) AS tanque FROM   granel_entrada LEFT JOIN  existenciaplanta ON granel_entrada.id_planta = existenciaplanta.id_plantas  LEFT JOIN   comun ON existenciaplanta.id_comun = comun.id_comun    LEFT JOIN    comun AS comun2 ON granel_entrada.id_comun = comun2.id_comun  INNER JOIN   granel_tanques ON granel_entrada.id_granel_entrada = granel_tanques.id_granel_entrada  LEFT JOIN (SELECT  granel_ensamble.id_granel_entrada, granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun.nombre FROM  granel_ensamble  INNER JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun = comun.id_comun   ORDER BY granel_ensamble.id_granel_entrada ASC , granel_ensamble.litros DESC , granel_ensamble.agave_coccion_kg DESC) TABLA ON granel_entrada.id_granel_entrada = TABLA.id_granel_entrada LEFT JOIN (SELECT granel_ensamble.id_granel_entrada, granel_ensamble.id_planta,  granel_ensamble.id_predio,granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun3.nombre  FROM granel_ensamble  LEFT JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble.id_comun = comun3.id_comun ORDER BY granel_ensamble.litros DESC , granel_ensamble.agave_coccion_kg DESC) AS maguey ON granel_entrada.id_granel_entrada = maguey.id_granel_entrada WHERE    granel_entrada.id_fabrica = '" + CmbFabricaGranelFabrica.SelectedValue + "' AND granel_entrada.lts_existentes > 0 GROUP BY granel_entrada.id;");
                        ConexionMysql.llenaDataset(ref Datos, "SELECT granel_entrada.clase,granel_entrada.id_granel_entrada, DATE_FORMAT(granel_entrada.fecha, '%d/%m/%Y') AS fecha,granel_entrada.no_lote, granel_entrada.fq,  granel_entrada.categoria, granel_entrada.abocante, granel_entrada.ingrediente, granel_entrada.lts_existentes,  granel_entrada.grado_alcoholico_existente,  GROUP_CONCAT(DISTINCT granel_tanques.tanque) AS tanque FROM   granel_entrada       INNER JOIN   granel_tanques ON granel_entrada.id_granel_entrada = granel_tanques.id_granel_entrada WHERE    granel_entrada.id_fabrica = '" + CmbFabricaGranelFabrica.SelectedValue + "' AND granel_entrada.lts_existentes > 0 GROUP BY granel_entrada.id;");
                        DataRow fila;
                        dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Rows.Clear();
                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            fila = dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].NewRow();
                            fila["ID_PRODUCCION_GRANEL"] = Convert.ToString(row["id_granel_entrada"]);
                            fila["FECHA"] = Convert.ToString(row["fecha"]);
                            fila["NO_TANQUE"] = Convert.ToString(row["tanque"]);
                            fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);

                            String especieMaguey = ConexionMysql.regresaCampoConsulta("call maguey_granel_entrada2('" + Convert.ToString(row["id_granel_entrada"]) + "')");
                            fila["ESPECIE"] = especieMaguey;

                            /*if (Convert.ToString(row["maguey"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                            }
                            else if (Convert.ToString(row["maguey_sin"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                            }
                            else if (Convert.ToString(row["ensamble"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                            }
                            else if (Convert.ToString(row["ensamble_maguey"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                            }*/
                            /* else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                             {
                                 fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                             }*/


                            fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                            fila["CLASE"] = Convert.ToString(row["clase"]);
                            fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                            fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                            fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                            fila["LITROS"] = Convert.ToString(row["lts_existentes"]);
                            fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                            fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                            fila["VERIFICACION"] = ConvertImageToByteArray(Properties.Resources.checked__1_, System.Drawing.Imaging.ImageFormat.Png);


                            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Rows.Add(fila);
                        }
                    }
                    else if (BanderaBarrica == true)
                    {
                        DataSet Datos = new DataSet();
                        //ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos.numero_de_contenedores, granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN (   SELECT granel_ensamble.id_granel_entrada,comun.nombre FROM granel_ensamble INNER JOIN comun ON granel_ensamble.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc ) TABLA2 ON granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada WHERE granel_entrada.id_fabrica= '" + CmbFabricaGranelFabrica.SelectedValue + "' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino='barricas'  GROUP BY granel_movimientos.id_granel_movimientos ");
                        ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos.numero_de_contenedores, granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT maguey2.nombre ORDER BY maguey2.id_granel_entrada ASC) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN ( SELECT granel_ensamble.id_granel_entrada, granel_ensamble.id_planta,  granel_ensamble.id_predio,granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun3.nombre  FROM granel_ensamble  LEFT JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble.id_comun = comun3.id_comun) AS maguey2 ON granel_entrada.id_granel_entrada = maguey2.id_granel_entrada WHERE granel_entrada.id_fabrica= '" + CmbFabricaGranelFabrica.SelectedValue + "' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino='barricas'  GROUP BY granel_movimientos.id_granel_movimientos ");

                        DataRow fila;
                        dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Rows.Clear();
                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            fila = dtsProductoBarrica.Tables["PRODUCTOBARRICA"].NewRow();
                            fila["ID_GRANEL_MOVIMIENTOS"] = Convert.ToString(row["id_granel_movimientos"]);
                            fila["ID_PRODUCCION_GRANEL"] = Convert.ToString(row["id_granel_entrada"]);
                            fila["FECHA"] = Convert.ToString(row["fecha"]);
                            fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                            fila["NO_BARRICAS"] = Convert.ToString(row["numero_de_contenedores"]);
                            fila["FOLIO"] = Convert.ToString(row["folio"]);

                            if (Convert.ToString(row["ensamble"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                            }
                            else if (Convert.ToString(row["maguey"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                            }
                            else if (Convert.ToString(row["maguey_sin"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                            }

                            else if (Convert.ToString(row["ensamble_maguey"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                            }
                            /*else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                            }*/
                            fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                            fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                            fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                            fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                            fila["LITROS"] = Convert.ToString(row["litros_existentes"]);
                            fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                            fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);


                            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Rows.Add(fila);
                        }
                    }
                    else if (BanderaVidrio == true)
                    {
                        DataSet Datos = new DataSet();
                        //ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos.numero_de_contenedores,granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN (   SELECT granel_ensamble.id_granel_entrada,comun.nombre FROM granel_ensamble INNER JOIN comun ON granel_ensamble.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc ) TABLA2 ON granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada WHERE granel_entrada.id_fabrica= '" + CmbFabricaGranelFabrica.SelectedValue + "' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino='vidrio'  GROUP BY granel_movimientos.id_granel_movimientos  ");


                        ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos.numero_de_contenedores,granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN (   SELECT granel_ensamble.id_granel_entrada, granel_ensamble.id_planta,  granel_ensamble.id_predio, granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun3.nombre  FROM granel_ensamble  LEFT JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble.id_comun = comun3.id_comun ORDER BY granel_ensamble.litros DESC , granel_ensamble.agave_coccion_kg DESC) AS maguey ON granel_entrada.id_granel_entrada = maguey.id_granel_entrada WHERE granel_entrada.id_fabrica= '" + CmbFabricaGranelFabrica.SelectedValue + "' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino='vidrio'  GROUP BY granel_movimientos.id_granel_movimientos  ");


                        DataRow fila;
                        dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Rows.Clear();
                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            fila = dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].NewRow();
                            fila["ID_GRANEL_MOVIMIENTOS"] = Convert.ToString(row["id_granel_movimientos"]);
                            fila["ID_PRODUCCION_GRANEL"] = Convert.ToString(row["id_granel_entrada"]);
                            fila["FECHA"] = Convert.ToString(row["fecha"]);
                            fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                            fila["NO_CONTENEDORES"] = Convert.ToString(row["numero_de_contenedores"]);
                            fila["FOLIO"] = Convert.ToString(row["folio"]);

                            if (Convert.ToString(row["maguey"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                            }
                            else if (Convert.ToString(row["maguey_sin"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                            }
                            else if (Convert.ToString(row["ensamble"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                            }
                            else if (Convert.ToString(row["ensamble_maguey"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                            }
                            /*else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                            {
                                fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                            }*/
                            fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                            fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                            fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                            fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                            fila["LITROS"] = Convert.ToString(row["litros_existentes"]);
                            fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                            fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);


                            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Rows.Add(fila);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        //crea la tabla de  producto granel
        private void addTablaProductoAgranel()
        {
            dtsProductoAgranel = new DataSet();
            dtsProductoAgranel.Tables.Add("PRODUCTOAGRANEL");
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("ID_PRODUCCION_GRANEL", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("NO_TANQUE", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            dtsProductoAgranel.Tables["PRODUCTOAGRANEL"].Columns.Add("VERIFICACION", Type.GetType("System.Byte[]"));//verificación con botón ---LSM2020
            DtaProductoAgranel.DataSource = dtsProductoAgranel.Tables["PRODUCTOAGRANEL"];
            DtaProductoAgranel.Columns[1].Visible = false;
            //DtaProductoAgranel.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            //DtaProductoAgranel.Columns[8].Visible = false;
        }



        //crea la tabla de  producto en barrica
        private void addTablaProductoBarrica()
        {
            dtsProductoBarrica = new DataSet();
            dtsProductoBarrica.Tables.Add("PRODUCTOBARRICA");
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("ID_GRANEL_MOVIMIENTOS", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("ID_PRODUCCION_GRANEL", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("NO_BARRICAS", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("FOLIO", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoBarrica.Tables["PRODUCTOBARRICA"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoBarrica.DataSource = dtsProductoBarrica.Tables["PRODUCTOBARRICA"];
            DtaProductoBarrica.Columns[1].Visible = false;
           // DtaProductoBarrica.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            DtaProductoBarrica.Columns[2].Visible = false;
            //DtaProductoBarrica.Columns[9].Visible = false;
        }


        //crea la tabla de  producto en vidrio

        private void addTablaProductoVidrio()
        {
            dtsProductoVidrio = new DataSet();
            dtsProductoVidrio.Tables.Add("PRODUCTOVIDRIO");
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("ID_GRANEL_MOVIMIENTOS", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("ID_PRODUCCION_GRANEL", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("NO_CONTENEDORES", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("FOLIO", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoVidrio.Tables["PRODUCTOVIDRIO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoVidrio.DataSource = dtsProductoVidrio.Tables["PRODUCTOVIDRIO"];
            DtaProductoVidrio.Columns[1].Visible = false;
            //DtaProductoVidrio.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            DtaProductoVidrio.Columns[2].Visible = false;
            //DtaProductoVidrio.Columns[9].Visible = false;
        }


        // crear tabla de produccion  para guardar el registro agranel
        private void addTablaProduccionParaGuardarAgranel()
        {
            dtsProduccionParaGuardarAgranel = new DataSet();
            dtsProduccionParaGuardarAgranel.Tables.Add("PRODUCCIONPARAGUARDARAGRANEL");
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("TAPADA", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("ID_PRODUCCION", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("AGAVE_COCCION_KG", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Columns.Add("ID_COMUN", Type.GetType("System.String"));
            DtaProduccionParaGuardarAgranel.DataSource = dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"];
            DtaProduccionParaGuardarAgranel.Columns[1].Visible = false;
            DtaProduccionParaGuardarAgranel.Columns[2].Visible = false;
            DtaProduccionParaGuardarAgranel.Columns[3].Visible = false;
            DtaProduccionParaGuardarAgranel.Columns[4].Visible = false;
            DtaProduccionParaGuardarAgranel.Columns[8].Visible = false;
        }

        // crear tabla de produccion  para guardar el registro agranel
        private void addTablaTanques()
        {
            dtsTanques = new DataSet();
            dtsTanques.Tables.Add("TANQUES");
            dtsTanques.Tables["TANQUES"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanques.Tables["TANQUES"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaTanques.DataSource = dtsTanques.Tables["TANQUES"];
        }


        //boton para  agregar produccion para granel 
        private void BtnAgregarProduccionAgranel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbProduccion.SelectedValue == null)
                {
                    MessageBox.Show("No tienes producción para agregar");
                    return;
                }
                if (TxtLitrosParaGuardarAgranel.Text == "")
                {
                    MessageBox.Show("No ha introducido litros");
                    return;
                }
                if (Math.Round(double.Parse(litros), 2) < Math.Round(double.Parse(TxtLitrosParaGuardarAgranel.Text), 2))
                {
                    MessageBox.Show("Existencia insuficiente");
                    return;
                }
                DataRow fila = dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].NewRow();
                fila["TAPADA"] = tapada;
                fila["ID_PRODUCCION"] = CmbProduccion.SelectedValue;
                fila["ID_PLANTA"] = id_planta;
                fila["ID_PREDIO"] = id_predio;
                fila["AGAVE_COCCION_KG"] = agave_coccion_kg;
                fila["LITROS"] = TxtLitrosParaGuardarAgranel.Text;
                fila["%_ALCOHOLICO"] = grado_alcoholico;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                fila["ID_COMUN"] = planta_externa;
                dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Rows.Add(fila);
                TxtLitrosParaGuardarAgranel.Text = "";
                CmbProduccion.DataSource = null;

                string produccion = "";
                string coma = "";




                for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                {
                    produccion += coma + "'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "'";
                    coma = ",";
                }
                ConexionMysql.llenaComboAutocomplit(ref CmbProduccion, "SELECT  CONCAT(tapada,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico) As produccion,id_produccion_entrada   FROM produccion_entrada  where id_produccion_entrada NOT IN(" + produccion + ") AND id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'  and no_cliente='" + CmbNoClienteGranel.SelectedValue + "' AND estatus=5 AND lts_existentes > 0 and rendimiento=1 order by id_produccion_entrada asc", "id_produccion_entrada", "produccion");




                //==================================== Detecta si los lotes son de diferente clase y categoria  no permita la union  =======================
                if (DtaProduccionParaGuardarAgranel.Rows.Count > 1)
                {
                    string Dsingrediente = ingredienteGF();
                    string categoriamezcal = ObtieneCategoriaMezcal();
                    if (Dsingrediente.Equals("dif_clase"))
                    {


                        MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Rows.Clear();
                        return;
                    }

                    if (categoriamezcal.Equals("dif_categoria"))
                    {


                        MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes categorias,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Rows.Clear();
                        return;

                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        //al seleccionar una produccion carga datos litros,tapada,grado alcoholico
        private void CmbProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (CmbProduccion.DataSource == null)
                {
                    litros = "";
                    tapada = "";
                    grado_alcoholico = "";
                    id_planta = "";
                    id_predio = "";
                    agave_coccion_kg = "";
                    gcrm = "";


                }
                else
                {
                    litros = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                    tapada = ConexionMysql.regresaCampoConsulta("SELECT tapada FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                    grado_alcoholico = ConexionMysql.regresaCampoConsulta("SELECT grado_alcoholico FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                    
                    string bandera_guia_externa = ConexionMysql.regresaCampoConsulta("SELECT gcrm FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                    //MessageBox.Show("Valor guía externa= " + bandera_guia_externa + " Guia externa(1), no externa(0)");
                    if (bandera_guia_externa == "0")
                    {
                        id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                        id_predio = ConexionMysql.regresaCampoConsulta("SELECT id_predio FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                        gcrm = "0";
                        banderaGuiaExterna = "false";
                        planta_externa = "0";
                    }
                    //id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                    //id_predio = ConexionMysql.regresaCampoConsulta("SELECT id_predio FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                    else
                    if(bandera_guia_externa == "1")
                    {
                        planta_externa = ConexionMysql.regresaCampoConsulta("SELECT id_comun FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");
                        id_predio = "Predio externo";
                        id_planta = "0";
                        banderaGuiaExterna = "true";
                        gcrm = "1";
                    }
                    
                    agave_coccion_kg = ConexionMysql.regresaCampoConsulta("SELECT agave_coccion_kg FROM  produccion_entrada  WHERE id_produccion_entrada='" + CmbProduccion.SelectedValue + "'");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //al presionar doble clik quita produccion para guardar agranel
        private void DtaProduccionParaGuardarAgranel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProduccionParaGuardarAgranel.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaProduccionParaGuardarAgranel.Rows.RemoveAt(e.RowIndex);
                    dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].AcceptChanges();
                    CmbProduccion.DataSource = null;
                    if (DtaProduccionParaGuardarAgranel.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "'";

                            coma = ",";
                        }
                        ConexionMysql.llenaComboAutocomplit(ref CmbProduccion, "SELECT  CONCAT(tapada,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico) As produccion,id_produccion_entrada   FROM produccion_entrada  where id_produccion_entrada NOT IN(" + produccion + ") AND id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "' and no_cliente='" + CmbNoClienteGranel.SelectedValue + "' AND estatus=5 AND lts_existentes > 0 and rendimiento=1 order by id_produccion_entrada asc", "id_produccion_entrada", "produccion");
                    }
                    else
                    {
                        ConexionMysql.llenaComboAutocomplit(ref CmbProduccion, "SELECT  CONCAT(tapada,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico) As produccion,id_produccion_entrada   FROM produccion_entrada  where no_cliente='" + CmbNoClienteGranel.SelectedValue + "' AND id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "' AND estatus=5 AND lts_existentes > 0 and rendimiento=1 order by id_produccion_entrada asc", "id_produccion_entrada", "produccion");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // boton para agregar nombres de tanques
        private void BtnAgregarTanque_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtTanque.Text == "")
                {
                    MessageBox.Show("No ha introducido un nombre de tanque");
                    return;
                }
                DataRow fila = dtsTanques.Tables["TANQUES"].NewRow();
                fila["TANQUE"] = TxtTanque.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsTanques.Tables["TANQUES"].Rows.Add(fila);
                TxtTanque.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //boton para quitar tanques 
        private void DtaTanques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaTanques.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaTanques.Rows.RemoveAt(e.RowIndex);
                    dtsTanques.Tables["TANQUES"].AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //guardar producto agranel
        private void BtnGuardarGranel_Click(object sender, EventArgs e)
        {

            if (CmbFabricaGranelFabrica.SelectedValue == null)
            {
                MessageBox.Show("No ha seleccionado una fabrica");
                return;
            }

            if (DtaProduccionParaGuardarAgranel.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna produccion");
                return;
            }
            if (DtaTanques.Rows.Count == 0)
            {
                MessageBox.Show("No ha introduccido ningun tanque");
                return;
            }
            if (TxtNoLote.Text == "")
            {
                MessageBox.Show("No ha introduccido un lote");
                return;
            }
            DateTime local = DateTime.Now;
            string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");
            string categoriamezcal = ObtieneCategoriaMezcal();
            string clasemezcal = obtenerclase();
            string Dsingrediente = ingredienteGF();
            double litros = 0;
            double grado_alcoholico = 0;
            double grado_alcoholico_para_suma = 0;


            //================================ Define si las clase es diferente
            if (Dsingrediente.Equals("dif_clase"))
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (categoriamezcal.Equals("dif_categoria"))
            {


                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes categorias,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            //for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
            //{
            //    id_planta =int.Parse( DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PLANTA"].Value.ToString());
            //    litros += Math.Round(double.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value.ToString()),2);
            //}
            //================================================================>>> Confirmacion de datos a ingresar <<<============
            string tipo = label11.Text;
            string f = CmbNoClienteGranel.Text;
            string o = CmbFabricaGranelFabrica.Text;
            string p = "";
            string pp = "";
            string p3 = "";
            string comad = "";
            //--->>-Mustra la lista de los DatagredView
            for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
            {
                p += comad + "'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["TAPADA"].Value + "'\n";
                pp += comad + "'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value + "'\n";
                p3 += comad + "'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["%_ALCOHOLICO"].Value + "'\n";
                comad = "  ";
            }

            string q = "";

            //--->>-Mustra la lista de los DatagredView
            for (int x = 0; x < DtaTanques.Rows.Count; x++)
            {
                q += comad + "'" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'\n";


            }

            string t = TxtNoLote.Text;
            string a = "No";// TxtAbocado.Text;
            string b = "---";// TxtIngrediente.Text;

            if (chkAbocadoGF.Toggled == true)
            {

                if (txtIngredienteGF.Text == "")
                {
                    MessageBox.Show("Desbes escribir un ingrediente...");
                    return;
                }

                a = "Si";
                b = txtIngredienteGF.Text;

            }
            string c = TxtFQ.Text;


            string dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + q + "!" + t + "!" + a + "!" + c + "!" + b;
            /*  DialogResult r = MsgBxGranelenvasado.Show("No Cliente" + f + "\nEnvasadora: " + o + "\n\n --->- Tapada -<---" + "\nTapada:" + p + "\nLitros: " + pp + " \n% Alcoholico: "
                + p3 + "\n\n --->- Tanques -<---" + "\nTanques: " + q + "\n\nNo lote: " + t + "\nAbocado: " + a
                + "\nIngrediente: " + b + "\nClave FQ: " + c, "---", "Aceptar", "Cancelar");*/

            MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
            msg.granelfabricaok(dto);
            msg.ShowDialog();
            if (msg.DialogResult == DialogResult.Cancel) { return; }
            else
            {



                for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                {
                    litros += Math.Round(double.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                    grado_alcoholico_para_suma += Math.Round(double.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value.ToString()), 2) * Math.Round(double.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["%_ALCOHOLICO"].Value.ToString()), 2);
                }
                grado_alcoholico = grado_alcoholico_para_suma / litros;

                //obtenesmos el id maximo de la entrada a granel
                ObtenerIdMaximoGranelEntrada();

                if (DtaProduccionParaGuardarAgranel.Rows.Count == 1)
                {
                    int bandera_guia_ext = int.Parse(ConexionMysql.regresaCampoConsulta("SELECT gcrm FROM  produccion_entrada  WHERE id_produccion_entrada='" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PRODUCCION"].Value + "'"));
                    //=====-- si es una sola produccion entra aqui -- ===
                    //Y ENSEGUIDA VALIDA SI ESA TAPADA ES ENSMABLE O NO
                    if (DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() == "0" && bandera_guia_ext.ToString() == "0")
                    {
                        //============= -- si la produccion es un ensamble entra aqui-------------- =-=-=
                        /*if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES( '" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "','" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','Joven','" + categoriamezcal + "','" + TxtAbocado.Text + "','" + TxtIngrediente.Text + "'," + litros + "," + Math.Round(grado_alcoholico, 2) + "," + litros + "," + Math.Round(grado_alcoholico, 2) + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }*/
                        if (chkAbocadoGF.Toggled == true)
                        {///============= Si el check de abocado entra aqui valida los datos
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES( '" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "','" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','Abocado con','" + categoriamezcal + "','" + TxtAbocado + "','" + txtIngredienteGF.Text + "'," + litros + "," + Math.Round(grado_alcoholico, 2) + "," + litros + "," + Math.Round(grado_alcoholico, 2) + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES( '" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "','" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','" + clasemezcal + "','" + categoriamezcal + "','" + TxtAbocado + "','" + Dsingrediente + "'," + litros + "," + Math.Round(grado_alcoholico, 2) + "," + litros + "," + Math.Round(grado_alcoholico, 2) + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }

                        }


                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_fabrica','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PRODUCCION"].Value + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }

                        DataSet Datos = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos, "SELECT  id_predio,id_planta,agave_coccion_kg FROM produccion_ensamble where id_produccion_entrada='" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PRODUCCION"].Value + "'");
                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            ObtenerIdMaximoGranelEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_granel_ensamble + "','" + id_max_granel_entrada + "' ,'" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }
                    else
                       //==== --- si la produccion no es un ensamble entra aqui -- ===
                        //Esta validacion de abajo es para verificar si la tapada es de una guia externa entonces va a guardar ID COMUN en lugar de planta
                        if (DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() =="0" && bandera_guia_ext.ToString() == "1")
                        {
                            if (chkAbocadoGF.Toggled == true)
                            {///============= Si el check de abocado entra aqui valida los datos
                            
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_comun,id_solicitud,no_lote,id_planta,id_predio,agave_coccion_kg,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "','" + planta_externa + "',0,'" + TxtNoLote.Text + "' ,0,'" + id_predio +"','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["AGAVE_COCCION_KG"].Value.ToString() + "','" + TxtFQ.Text + "','Abocado con','" + categoriamezcal + "','" + TxtAbocado + "','" + txtIngredienteGF.Text + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }

                            }
                            else
                            {
                            //MessageBox.Show(planta_externa + " comun");
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_comun,id_solicitud,no_lote,id_planta,id_predio,agave_coccion_kg,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "','" + planta_externa + "',0,'" + TxtNoLote.Text + "' ,0,'" + id_predio + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["AGAVE_COCCION_KG"].Value.ToString() + "','" + TxtFQ.Text + "','" + clasemezcal + "','" + categoriamezcal + "','" + TxtAbocado + "','" + Dsingrediente + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }//=-=-=== Fin del if
                            }

                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_fabrica','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PRODUCCION"].Value + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }

                    #region ASÍ ESTABA EL CÓDIGO ANTES DE VALIDAR SI EL ORIGEN DEL LOTE ES POR UNA TAPADA CON GUIA EXTERNA    
                    /*
                            if (chkAbocadoGF.Toggled == true)
                        {///============= Si el check de abocado entra aqui valida los datos

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,id_planta,id_predio,agave_coccion_kg,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PREDIO"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["AGAVE_COCCION_KG"].Value.ToString() + "','" + TxtFQ.Text + "','Abocado con','" + categoriamezcal + "','" + TxtAbocado + "','" + txtIngredienteGF.Text + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }

                        }
                        else
                        {

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,id_planta,id_predio,agave_coccion_kg,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PREDIO"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["AGAVE_COCCION_KG"].Value.ToString() + "','" + TxtFQ.Text + "','" + clasemezcal + "','" + categoriamezcal + "','" + TxtAbocado + "','" + Dsingrediente + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }//=-=-=== Fin del if
                        }

                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_fabrica','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PRODUCCION"].Value + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }*/
                    #endregion


                    else

                        if (DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() != "0")
                        {
                            if (chkAbocadoGF.Toggled == true)
                            {///============= Si el check de abocado entra aqui valida los datos

                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,id_planta,id_predio,agave_coccion_kg,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PREDIO"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["AGAVE_COCCION_KG"].Value.ToString() + "','" + TxtFQ.Text + "','Abocado con','" + categoriamezcal + "','" + TxtAbocado + "','" + txtIngredienteGF.Text + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }

                            }
                            else
                            {

                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,id_planta,id_predio,agave_coccion_kg,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PREDIO"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["AGAVE_COCCION_KG"].Value.ToString() + "','" + TxtFQ.Text + "','" + clasemezcal + "','" + categoriamezcal + "','" + TxtAbocado + "','" + Dsingrediente + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }//=-=-=== Fin del if
                            }

                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_fabrica','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PRODUCCION"].Value + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }
                    
                }// FIN EL IF QUE VALIDA SI EL LOTE SE VA A FORMAR DE UNA SOLA TAPADA
                else
                {

                    if (chkAbocadoGF.Toggled == true)
                    {///============= Si el check de abocado entra aqui valida los datos

                        //=========== -- si es un ensamble de varias producciones entra aqui -----  ====
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','Abocado con','" + categoriamezcal + "','" + TxtAbocado + "','" + txtIngredienteGF.Text + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        //=========== -- si es un ensamble de varias producciones entra aqui -----  ====
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_fabrica,id_granel_entrada,no_cliente,fecha,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador) VALUES('" + CmbFabricaGranelFabrica.SelectedValue + "','" + id_max_granel_entrada + "', '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','" + clasemezcal + "','" + categoriamezcal + "','" + TxtAbocado + "','" + Dsingrediente + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + ",NOW()," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }

                    for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                    {
                        if (int.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PLANTA"].Value.ToString()) == 0 && int.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_COMUN"].Value.ToString()) == 0)
                        {
                            DataSet Datos = new DataSet();
                            ConexionMysql.llenaDataset(ref Datos, "SELECT id_predio,id_planta,agave_coccion_kg FROM produccion_ensamble where id_produccion_entrada='" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "'");
                            foreach (DataRow row in Datos.Tables[0].Rows)
                            {
                                ObtenerIdMaximoGranelEnsamble();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES('" + id_max_granel_ensamble + "', '" + id_max_granel_entrada + "' ,'" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }


                                ///--- inserta el id de la produccion---
                                string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_fabrica','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                                {
                                    return;
                                }

                            }
                        }
                        else //Para saber si es id de guías amma o crm antiguas
                        if (int.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PLANTA"].Value.ToString()) > 0 && int.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_COMUN"].Value.ToString()) == 0)
                        {
                            ObtenerIdMaximoGranelEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_granel_ensamble + "','" + id_max_granel_entrada + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["AGAVE_COCCION_KG"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                        //para saber si es guia exerna
                        else
                        if (int.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PLANTA"].Value.ToString()) == 0 && int.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_COMUN"].Value.ToString()) > 0)
                        {
                            
                            ObtenerIdMaximoGranelEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_granel_ensamble + "','" + id_max_granel_entrada + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_COMUN"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["AGAVE_COCCION_KG"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }
                }

                #region CODIGO COMENTADO POR EL CREADOR DEL MISMO
                //codigo comentado ya no se utilizo la variable ensamble y fue borrada
                //if (ensamble == true)
                //{
                //    if (DtaProduccionParaGuardarAgranel.Rows.Count == 1)
                //    {
                //        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(no_cliente,fecha,id_solicitud,no_lote,fq,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador) VALUES( '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + categoriamezcal + "','" + TxtAbocado.Text + "','" + TxtIngrediente.Text + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + "," + Usuario.IdUsuario + ")") == "Error")
                //        {
                //            return;
                //        }
                //        string id_granel_enetrada1 = ConexionMysql.regresaCampoConsulta("SELECT max(id_granel_entrada) as id FROM  granel_entrada");
                //        for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                //        {
                //            if (int.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PLANTA"].Value.ToString()) == 0)
                //            {
                //                DataSet Datos = new DataSet();
                //                ConexionMysql.llenaDataset(ref Datos, "SELECT  id_predio,id_planta FROM produccion_ensamble where id_produccion='" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "'");
                //                foreach (DataRow row in Datos.Tables[0].Rows)
                //                {
                //               row["id_predio"].ToString();
                //                row["id_planta"].ToString();
                //                }       
                //            }
                //            else
                //            {
                //                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_entrada,id_planta,id_predio) VALUES( '" + id_granel_enetrada1 + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "')") == "Error")
                //                {
                //                    return;
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("SERIA UN ENSAMBLDE DE DOS TAPADAS y ensable");
                //    }       
                //}
                //else
                //{
                //    if(DtaProduccionParaGuardarAgranel.Rows.Count==1)
                //    {
                //     if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(no_cliente,fecha,id_solicitud,no_lote,id_planta,id_predio,fq,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador) VALUES( '" + CmbNoClienteGranel.SelectedValue + "','" + fecha + "',0,'" + TxtNoLote.Text + "' ,'" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaProduccionParaGuardarAgranel.Rows[0].Cells["ID_PREDIO"].Value.ToString() + "',' " + TxtFQ.Text + "','" + categoriamezcal + "','" + TxtAbocado.Text + "','" + TxtIngrediente.Text + "'," + litros + "," + grado_alcoholico + "," + litros + "," + grado_alcoholico + "," + Usuario.IdUsuario + ")") == "Error")
                //     {
                //        return;
                //     }
                //    }
                //    else
                //    {
                //        MessageBox.Show("SERIA UN ENSAMBLDE DE DOS TAPADAS");
                //    }
                //}
                #endregion



                for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                {
                    ObtenerIdMaximoProduccionSalida();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_salida(id_produccion_salida,id_produccion_entrada,id_solicitud,id_granel_entrada,litros,id_verificador) VALUES( '" + id_max_produccion_salida + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "',0,'" + id_max_granel_entrada + "','" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                    {
                        return;
                    }
                    string litros_produccion = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  produccion_entrada WHERE  id_produccion_entrada='" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "'");
                    double existencia = Math.Round(double.Parse(litros_produccion), 2) - Math.Round(double.Parse(DtaProduccionParaGuardarAgranel.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET lts_existentes=" + existencia + " ,actualizado=0 WHERE id_produccion_entrada='" + DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value + "'") == "Error")
                    {
                        return;
                    }
                }

                for (int x = 0; x < DtaTanques.Rows.Count; x++)
                {
                    ObtenerIdMaximoGraneTanque();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques(id_tanque,id_granel_entrada,tanque,id_verificador,actualizado) VALUES('" + id_max_granel_tanque + "', '" + id_max_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                    {
                        return;
                    }
                }
                LimpiarGranel();
                ConexionMysql.transCompleta();
                MessageBox.Show("Exito");
                CmbNoClienteGranel_SelectedIndexChanged(sender, e);//Carga de nuevo el dtagridvew
            }
        }


        //limpia controles del formulario de granel
        public void LimpiarGranel()
        {
            dtsProduccionParaGuardarAgranel.Tables["PRODUCCIONPARAGUARDARAGRANEL"].Rows.Clear();
            dtsTanques.Tables["TANQUES"].Rows.Clear();
            TxtNoLote.Text = "";
            //TxtAbocado.Text = "";
            chkAbocadoGF.Toggled = false;
            txtIngredienteGF.Text = "";
            TxtFQ.Text = "";
        }

        //funcion para saber la categoria del mezcal
        public string ObtieneCategoriaMezcal()
        {
            string CategoriaMezcal = "";
            string CategoriaMezcalComparar = "";
            string id_produccion = "";
            string id_coccion = "";
            string id_molienda = "";
            string id_fermentacion = "";
            string id_destilacion = "";
            //string destilado_con = "";
            int mancetral = 0;
            int maartesanal = 0;
            int mzkl = 0;

            for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
            {

                id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();

                /* if (x > 0)
                 {
                     CategoriaMezcalComparar = CategoriaMezcal;
                 }*/

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT id_coccion,id_molienda,id_fermentacion,id_destilacion FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'  ");
                foreach (DataRow row in Datos.Tables[0].Rows)
                {
                    id_coccion = Convert.ToString(row["id_coccion"]);
                    id_molienda = Convert.ToString(row["id_molienda"]);
                    id_fermentacion = Convert.ToString(row["id_fermentacion"]);
                    id_destilacion = Convert.ToString(row["id_destilacion"]);
                    //destilado_con=Convert.ToString(row["destilado_con"]);





                    //if (destilado_con!="") {
                    //   CategoriaMezcal = "Destilado con";


                    // }
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
                        }//--- fin if (id_molienda == "1" || id_molienda == "2" || id_molienda == "3" || id_molienda == "6")
                        else if (id_molienda == "5" || id_molienda == "4")
                        {
                            CategoriaMezcal = "Mezcal";
                        }
                    }//-- Fin else if (id_coccion == "2")
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

                    // MessageBox.Show("la categoria es "+CategoriaMezcal);
                    ////mezcal ancestral
                    //if(id_destilacion=="12" || id_destilacion=="13" )
                    //{
                    //    if (id_fermentacion != "3")
                    //    {
                    //        if (id_molienda == "1" || id_molienda == "6")
                    //        {
                    //            if (id_coccion == "1")
                    //            {
                    //                CategoriaMezcal = "Mezcal Ancestral";
                    //            }
                    //        }
                    //    }
                    //}
                    ////mezcal artesanal
                    //else if (id_destilacion!="1" && id_destilacion!="2" && id_destilacion!="3" && id_destilacion!="12" && id_destilacion!="13")
                    //{
                    //    if (id_fermentacion != "3")
                    //    {
                    //        if(id_molienda!="4" && id_molienda!="5")
                    //        {
                    //            if(id_coccion=="1" || id_coccion=="2")
                    //            {
                    //                CategoriaMezcal = "Mezcal Artesanal";
                    //            }
                    //        }
                    //    }
                    //}
                    ////mezcal
                    //else if (id_destilacion != "12" && id_destilacion != "13")
                    //{
                    //    if (id_fermentacion == "1" || id_fermentacion == "2" || id_fermentacion == "3")
                    //    {
                    //        if (id_molienda!="6")
                    //        {
                    //            CategoriaMezcal = "Mezcal";
                    //        }
                    //    }
                    //}          




                }// fin del foreach--


                //MessageBox.Show("otro es " + CategoriaMezcalComparar);

                if (CategoriaMezcal == "Mezcal")
                {
                    mzkl++;
                }
                else if (CategoriaMezcal == "Mezcal Artesanal")
                {
                    maartesanal++;
                }
                else if (CategoriaMezcal == "Mezcal Ancestral")
                {
                    mancetral++;
                }

                /*  if (CategoriaMezcalComparar != "")
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
                  }*/

            }

            if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
            {

                CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
            {

                CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
            {

                CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
            {

                CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal > 0 && mancetral == 0 && mzkl == 0)
            {
                CategoriaMezcal = "Mezcal Artesanal";
            }
            else if (maartesanal == 0 && mancetral == 0 && mzkl > 0)
            {
                CategoriaMezcal = "Mezcal";
            }
            else if (maartesanal == 0 && mancetral > 0 && mzkl == 0)
            {
                CategoriaMezcal = "Mezcal Ancestral";
            }
            return CategoriaMezcal;
        }

        //======================= obtine la clase de mezcal desde la produccion
        public string obtenerclase()
        {
            string claseMezcal = "";
            //string ClaseMezcalComparar = "";

            string id_produccion = "";

            string destilado_con = "";



            if (DtaProduccionParaGuardarAgranel.Rows.Count == 1)
            {

                for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                {

                    id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();

                    /* if (x > 0)
                     {
                         ClaseMezcalComparar = claseMezcal;
                     }*/

                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT destilado_con FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'  ");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {

                        destilado_con = Convert.ToString(row["destilado_con"]);



                        if (destilado_con != "")
                        {

                            claseMezcal = "Destilado con";
                        }
                        else
                        {
                            claseMezcal = "Blanco o Joven";
                        }

                    }//-- Fin del foreach --

                }//-- Fin del for

            }
            else
            {

                for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                {

                    id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();

                    /* if (x > 0)
                     {
                         ClaseMezcalComparar = claseMezcal;
                     }*/

                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT destilado_con FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'  ");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {

                        destilado_con = Convert.ToString(row["destilado_con"]);



                        if (destilado_con != "")
                        {

                            claseMezcal = "Destilado con";
                        }
                        else
                        {
                            claseMezcal = "Blanco o Joven";
                        }

                    }//-- Fin del foreach --

                }//-- Fin del for

            }


            return claseMezcal;


        }//--- fin de clasemezcal

        //========================== Esta funcion trae el ingrediente con el que fue destilado ===========
        public string ingredienteGF()
        {

            string des_ingrediente = "";
            string ingredientecadena = "";

            int des_con = 0;
            int des_sin = 0;
            string sep = " ";
            string dif_clase = "dif_clase";

            for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
            {

                id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();

                /*if (x > 0)
                 {
                     ClaseMezcalComparar = claseMezcal;
                 }*/

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT destilado_con FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'  ");
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    des_ingrediente = Convert.ToString(row["destilado_con"]);



                    /* if (des_ingrediente != "")
                     {

                         des_ingrediente = "Destilado con";
                     }
                     else
                     {
                         des_ingrediente = "Joven";
                     }*/

                }//-- Fin del foreach --

                if (des_ingrediente != "")
                {
                    des_con++;

                    ingredientecadena += sep + " " + des_ingrediente;
                    sep = ",";
                    // MessageBox.Show("es : " + des_ingrediente + " " + des_con);
                }
                else
                {

                    des_sin++;


                }
            }//-- Fin del for


            if (des_con > 0 && des_sin == 0)
            {

                des_ingrediente = ingredientecadena;



            }
            else if (des_con == 0 && des_sin > 0)
            {


            }
            else if (des_con > 0 && des_sin > 0)
            {

                //MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!","¡¡Atento aviso!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                des_ingrediente = dif_clase;
            }
            return des_ingrediente;

            //Console.WriteLine("es : " + des_ingrediente);
            // MessageBox.Show("es : " + des_ingrediente);
            // return des_ingrediente;

        } //== fin de ingredienteGF


        //abrir los movimientos agranel
        private void DtaProductoAgranel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoAgranel.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosGranel frm = new FrmMovimientosGranel();
                    frm.id_granel_entrada = DtaProductoAgranel.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL"].Value.ToString();
                    frm.lts_existentes = DtaProductoAgranel.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico_existente = DtaProductoAgranel.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.no_lote = DtaProductoAgranel.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.categoria = DtaProductoAgranel.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.clase = DtaProductoAgranel.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.fq = DtaProductoAgranel.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    //frm.abocante = DtaProductoAgranel.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    //frm.ingrediente = DtaProductoAgranel.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
                    frm.id_fabrica = CmbFabricaGranelFabrica.SelectedValue.ToString();
                    frm.tipo = "fabrica";
                    frm.ShowDialog();
                    CmbNoClienteGranel_SelectedIndexChanged(sender, e);
                }
                else if (DtaProductoAgranel.Columns[e.ColumnIndex].Name == "NO_LOTE")
                {

                    /*editar.FrmCambioNombre frm = new editar.FrmCambioNombre();
                    frm.id_lote = DtaProductoAgranel.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL"].Value.ToString();
                    frm.no_lote_actual = DtaProductoAgranel.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.tipo = "fabrica";
                    frm.ShowDialog();
                    CmbNoClienteGranel_SelectedIndexChanged(sender, e);*/
                    MessageBox.Show("No se puede hacer el cambio del nombre del lote, revisalo con tu jefe inmediato");

                }
                else if (DtaProductoAgranel.Columns[e.ColumnIndex].Name == "NO_TANQUE")
                {

                    editar.FrmCambioTanques frm = new editar.FrmCambioTanques();
                    frm.id_lote = DtaProductoAgranel.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL"].Value.ToString();
                    frm.no_lote = DtaProductoAgranel.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.tipo = "fabrica";
                    frm.ShowDialog();
                    CmbNoClienteGranel_SelectedIndexChanged(sender, e);

                }

                //TODO: VERIFICACION DE LOTES SIN MOVIMIENTOS---LSM--NOVIEMBRE 2020
                else if (DtaProductoAgranel.Columns[e.ColumnIndex].Name == "VERIFICACION")
                {
                    String id_lote_granel = DtaProductoAgranel.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL"].Value.ToString();
                    String nombreLote = DtaProductoAgranel.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    int id_pkGF = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("Select id from granel_entrada where " +
                        "id_granel_entrada = '" + id_lote_granel + "' "));

                    ObtenerIdMaximoLotesSinMovimiento();
                    int result = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT COUNT(*) FROM modificaciones_inventario where " +
                        "id_tabla = '" + id_lote_granel + "' and n_tabla like 'granel_entrada' and date(fecha_ultima_modificacion) = date(now())"));

                    if (result <= 0)
                    {
                        DialogResult check = MessageBox.Show("¿Has verificado que el lote no ha tenido movimientos?", "¡Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (check == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (check == DialogResult.OK)
                        {

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  checked_lotes_gf(id_checked_lotegf,id_pkGF,id_granel_entrada,no_cliente,id_fabrica,no_lote," +
                                "fecha_ultima_verificacion,checked,verificador_id,actualizado) VALUES ('" + id_max_loteSinMov + "','" + id_pkGF + "', " +
                                "'" + id_lote_granel + "', '" + CmbNoCliente.SelectedValue + "','" + CmbFabricaGranelFabrica.SelectedValue + "', '" + nombreLote + "', date(now()), '1', " +
                                "" + Usuario.IdUsuario + ", '0')") == "Error")
                            {
                                return;
                            }

                            ConexionMysql.transCompleta();
                            MessageBox.Show("Lote verificado con éxito");
                        }
                    }
                    else if (result >= 1)
                    {
                        MessageBox.Show("Este lote ha tenido movimientos el día de hoy");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //al seleccionar un tab de producto a granel carga granel o barrica poniendo la bandera en true para cargar los datos
        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl2.SelectedTab == tabPage7)
            {
                BanderaGranel = true;
                BanderaBarrica = false;
                BanderaVidrio = false;
                CmbFabricaGranelFabrica_SelectedIndexChanged(null, null);
            }
            else if (tabControl2.SelectedTab == tabPage8)
            {
                BanderaGranel = false;
                BanderaBarrica = true;
                BanderaVidrio = false;
                CmbFabricaGranelFabrica_SelectedIndexChanged(null, null);
            }
            else if (tabControl2.SelectedTab == tabPage5)
            {
                BanderaGranel = false;
                BanderaBarrica = false;
                BanderaVidrio = true;
                CmbFabricaGranelFabrica_SelectedIndexChanged(null, null);
            }

        }
        //muestras lo movimientos que se puede hacer en barricas
        private void DtaProductoBarrica_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoBarrica.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosBarrica frm = new FrmMovimientosBarrica();
                    frm.fecha = DtaProductoBarrica.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
                    frm.id_granel_movimiento = DtaProductoBarrica.Rows[e.RowIndex].Cells["ID_GRANEL_MOVIMIENTOS"].Value.ToString();
                    frm.id_granel_produccion = DtaProductoBarrica.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL"].Value.ToString();
                    frm.folio = DtaProductoBarrica.Rows[e.RowIndex].Cells["FOLIO"].Value.ToString();
                    frm.no_lote = DtaProductoBarrica.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.no_barricas = DtaProductoBarrica.Rows[e.RowIndex].Cells["NO_BARRICAS"].Value.ToString();
                    frm.categoria = DtaProductoBarrica.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoBarrica.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoBarrica.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoBarrica.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.litros = DtaProductoBarrica.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoBarrica.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.maguey = DtaProductoBarrica.Rows[e.RowIndex].Cells["ESPECIE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
                    frm.tipo = "fabrica";
                    //"ESPECIE"
                    frm.ShowDialog();
                    CmbNoClienteGranel_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //muestras lo movimeintos que se puede hacer en vidrio
        private void DtaProductoVidrio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoVidrio.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosVidrio frm = new FrmMovimientosVidrio();
                    frm.fecha = DtaProductoVidrio.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
                    frm.id_granel_movimiento = DtaProductoVidrio.Rows[e.RowIndex].Cells["ID_GRANEL_MOVIMIENTOS"].Value.ToString();
                    frm.id_granel_produccion = DtaProductoVidrio.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL"].Value.ToString();
                    frm.folio = DtaProductoVidrio.Rows[e.RowIndex].Cells["FOLIO"].Value.ToString();
                    frm.no_lote = DtaProductoVidrio.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.no_contenedores = DtaProductoVidrio.Rows[e.RowIndex].Cells["NO_CONTENEDORES"].Value.ToString();
                    frm.categoria = DtaProductoVidrio.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoVidrio.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoVidrio.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoVidrio.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.litros = DtaProductoVidrio.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoVidrio.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.maguey = DtaProductoVidrio.Rows[e.RowIndex].Cells["ESPECIE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
                    frm.tipo = "fabrica";
                    frm.ShowDialog();
                    CmbNoClienteGranel_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
        //=============================================================================[[[[[[--{Fin Granel}--]]]]]]========================================================


        /////////////////////////////////////////////////////////////////////////////////////----- GRANEL ENVASADOOO -------//////////////////////////////////////////////////////////////////////////////////////////////////


        #region GRANEL DE ENVASADO

        //agregamos granel envasado  sin saber procedencia
        private void BtnAgregarGranelEnvasado_Click(object sender, EventArgs e)
        {
            if (CmbEnvasadora.Items.Count == 0)
            {
                MessageBox.Show("No tienes una envasadora de destino, agrega una para poder realizar el movimiento");
                return;
            }
            FrmGranelNuevo frm = new FrmGranelNuevo();
            frm.no_cliente = CmbNoClienteGranelEnvasado.SelectedValue.ToString();
            frm.tipo = "Envasado";
            frm.id_envasadora = CmbEnvasadora.SelectedValue.ToString();
            frm.ShowDialog();
            CmbNoClienteGranelEnvasado_SelectedIndexChanged(sender, e);

        }

        //boton para transaccion 
        private void BtnTransaccionGranelEnvasado_Click(object sender, EventArgs e)
        {
            FrmTransaccion frm = new FrmTransaccion();
            frm.no_cliente = CmbNoClienteGranelEnvasado.SelectedValue.ToString();
            if (CmbEnvasadora.Items.Count == 0)
            {
                MessageBox.Show("No tienes una envasadora de destino, agrega una para poder realizar el movimiento");
                return;
            }
            frm.id_instalacion = CmbEnvasadora.SelectedValue.ToString();
            frm.tipo_instalacion = "granelenvasado";
            frm.ShowDialog();
            CmbEnvasadora_SelectedIndexChanged(sender, e);
        }


        //agrega nueva envasadoa
        private void BtnNuevaEnvasadora_Click(object sender, EventArgs e)
        {
            FrmNuevaEnvasadora frm = new FrmNuevaEnvasadora();
            frm.no_cliente = CmbNoClienteGranelEnvasado.SelectedValue.ToString();
            frm.ShowDialog();
            ConexionMysql.llenaCombo(ref CmbEnvasadora, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'", "id_envasadora", "envasadora");
            if (Usuario.EnvasadoraSeleccionada != "0")
            {
                CmbEnvasadora.SelectedValue = Usuario.EnvasadoraSeleccionada;
            }
        }

        //al seleccionar el cliente carga inventario agranel envasado
        private void CmbNoClienteGranelEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtsProduccionParaGuardarAgranelEnvasado.Clear();
                dtsProductoAgranelEnvasado.Clear();
                dtsProductoBarricaEnvasado.Clear();
                dtsProductoVidrioEnvasado.Clear();
                //carga envasadora
                CmbEnvasadora.DataSource = null;
                TxtResponsableEnvasadora.Text = "";

                ConexionMysql.llenaCombo(ref CmbEnvasadora, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'", "id_envasadora", "envasadora");

                lblFolioGranelEnvasado.Text = "....";
                if (Usuario.EnvasadoraSeleccionada != "0")
                {
                    CmbEnvasadora.SelectedValue = Usuario.EnvasadoraSeleccionada;
                    //---  se agrego este query para que al momento de que no tenga un folio no arretre el folio del   ConexionMysql.llenaCombo que se ejecuta primero
                    lblFolioGranelEnvasado.Text = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM envasadora_encargado where id_envasadora='" + CmbEnvasadora.SelectedValue + "';");
                }
                else { lblFolioGranelEnvasado.Text = "...."; }

                //carga fabricas de graneles
                CmbFabricaGranelEnvasado.DataSource = null;
                TxtMestroMezcaleroGranelEnvasado.Text = "";

                ConexionMysql.llenaCombo(ref CmbFabricaGranelEnvasado, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'", "id_fabrica", "fabrica");
                if (Usuario.FabricaSeleccionada != "0")
                {
                    CmbFabricaGranelEnvasado.SelectedValue = Usuario.FabricaSeleccionada;
                }


                //-- string Foliogranel = ConexionMysql.regresaCampoConsulta("SELECT folio_granel FROM  clientes  where no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'  ");

                ////---Agregar el foliogranel al la tabla de  clientes  para y el campo que de folio_granel ----- 
                string Foliogranel = ConexionMysql.regresaCampoConsulta("SELECT folio_granel FROM  clientes  where no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'  ");

                if (Foliogranel == "")
                {
                    ///-- la consulta de abajo puede quedar que referencie en base a la grafica el estado y determinar si es de Denominacion de origen -- 
                    string estado = ConexionMysql.regresaCampoConsulta("SELECT estados.codigo from estados inner join relacion_cp_estado on  estados.clave=relacion_cp_estado.clave_estado inner join clientes on relacion_cp_estado.cp=clientes.cp  where clientes.no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'");
                    string Folio = ConexionMysql.regresaCampoConsulta("SELECT max(id_folio) FROM  folios ");
                    string foliogranel = "";
                    if (Folio == "")
                    {
                        Folio = "1";
                        foliogranel = Usuario.IdUsuario + "00000" + Folio + "GN" + estado;
                    }
                    else
                    {
                        int NuevoFolio = 0;
                        string cero = "";
                        NuevoFolio = int.Parse(Folio) + 1;
                        if (NuevoFolio.ToString().Length == 1)
                        {
                            cero = "00000";
                        }
                        else if (NuevoFolio.ToString().Length == 2)
                        {
                            cero = "0000";
                        }
                        else if (NuevoFolio.ToString().Length == 3)
                        {
                            cero = "000";
                        }
                        else if (NuevoFolio.ToString().Length == 4)
                        {
                            cero = "00";
                        }
                        else if (NuevoFolio.ToString().Length == 5)
                        {
                            cero = "0";
                        }

                        foliogranel = Usuario.IdUsuario + cero + NuevoFolio + "GR" + estado;
                    }
                    ///--- aqui no deberia de de ingresar Los folios
                    /*
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO folios(folio,actualizado) values ('" + foliogranel + "',0) ") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("UPDATE clientes SET  folio_granel ='" + foliogranel + "' WHERE no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "' ") == "Error")
                    {
                        return;
                    }*/

                    //ConexionMysql.transCompleta();
                }
                else
                {
                    //lblFolioGranelEnvasado.Text = Foliogranel;
                }

                // lblFolioGranelEnvasado.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //al seleccionar envasadora
        private void CmbEnvasadora_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbEnvasadora.SelectedValue != null)
            {
                TxtResponsableEnvasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + CmbEnvasadora.SelectedValue + "'");

                ///--- Selecciona el folio unico de granel si no tiene pide ingresarlo.. 
                lblFolioGranelEnvasado.Text = "-- S/N Folio --";
                string noFolioGranelUnico = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM envasadora_encargado WHERE id_envasadora='" + CmbEnvasadora.SelectedValue + "' AND no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "';");

                ///-- si es vacio el registro entra 
                if (noFolioGranelUnico == "")
                {

                    lblFolioGranelEnvasado.Text = "-- S/N Folio --";
                    btnIngresoNoFolioGEnvasado.Visible = true;

                }/// --- fin del if (noFolioGranelUnico)
                else
                {

                    lblFolioGranelEnvasado.Text = noFolioGranelUnico;
                    btnIngresoNoFolioGEnvasado.Visible = false;

                }

                lblFolioGranelEnvasado.ForeColor = Color.Red;


                TxtLitrosParaGuardarAgranelEnvasado.Text = "";

                if (BanderaGranelEnvasado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  granel_entrada_envasado.clase, granel_entrada_envasado.id_granel_entrada_envasado, DATE_FORMAT(granel_entrada_envasado.fecha, '%d/%m/%Y') as fecha , granel_entrada_envasado.no_lote, granel_entrada_envasado.fq, granel_entrada_envasado.categoria, granel_entrada_envasado.abocante, granel_entrada_envasado.ingrediente, ROUND(granel_entrada_envasado.lts_existentes,2) AS lts_existentes , granel_entrada_envasado.grado_alcoholico_existente,  comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT granel_tanques_envasado.tanque) as tanque  FROM granel_entrada_envasado  LEFT JOIN existenciaplanta ON granel_entrada_envasado.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON granel_entrada_envasado.id_comun=comun2.id_comun INNER JOIN granel_tanques_envasado ON granel_entrada_envasado.id_granel_entrada_envasado=granel_tanques_envasado.id_granel_entrada_envasado LEFT JOIN   ( SELECT granel_ensamble_envasado.id_granel_entrada_envasado,granel_ensamble_envasado.litros,granel_ensamble_envasado.agave_coccion_kg,comun.nombre FROM granel_ensamble_envasado INNER JOIN existenciaplanta ON granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble_envasado.id_granel_entrada_envasado asc,granel_ensamble_envasado.litros desc, granel_ensamble_envasado.agave_coccion_kg desc) TABLA  ON granel_entrada_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado LEFT JOIN  ( SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.id_planta,  granel_ensamble_envasado.id_predio,granel_ensamble_envasado.litros,granel_ensamble_envasado.agave_coccion_kg, comun3.nombre  FROM granel_ensamble_envasado  LEFT JOIN existenciaplanta ON granel_ensamble_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble_envasado.id_comun = comun3.id_comun ORDER BY granel_ensamble_envasado.litros DESC , granel_ensamble_envasado.agave_coccion_kg DESC) AS maguey ON granel_entrada_envasado.id_granel_entrada_envasado = maguey.id_granel_entrada_envasado WHERE granel_entrada_envasado.id_envasadora= '" + CmbEnvasadora.SelectedValue + "' and granel_entrada_envasado.lts_existentes > 0 GROUP BY granel_entrada_envasado.id ");
                    DataRow fila;
                    dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Rows.Clear();
                    
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].NewRow();
                        fila["ID_PRODUCCION_GRANEL_ENVASADO"] = Convert.ToString(row["id_granel_entrada_envasado"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_TANQUE"] = Convert.ToString(row["tanque"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);

                        string especieMaguey = ConexionMysql.regresaCampoConsulta("call maguey_granel_entrada_envasado('" + Convert.ToString(row["id_granel_entrada_envasado"]) + "')");
                        
                        fila["ESPECIE"] = especieMaguey;
                        
                        //-- en esta parte detecta si es que alguno de estos valores en diferente de vacio y toma el primer valor que cumpla la condicion
                        /*if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }*/

                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS"] = Convert.ToString(row["lts_existentes"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        fila["VERIFICAR"] = ConvertImageToByteArray(Properties.Resources.checked__1_, System.Drawing.Imaging.ImageFormat.Png);// BOTÓN VERIFICAR

                        dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Rows.Add(fila);
                    }
                }
                else if (BanderaBarricaEnvasado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos_envasado.numero_de_contenedores, granel_movimientos_envasado.id_granel_movimientos_envasado,granel_movimientos_envasado.id_granel_entrada_envasado,granel_movimientos_envasado.folio,DATE_FORMAT(granel_movimientos_envasado.fecha, '%d/%m/%Y') as fecha,granel_movimientos_envasado.no_lote,granel_entrada_envasado.fq,granel_entrada_envasado.categoria,granel_entrada_envasado.abocante,granel_entrada_envasado.ingrediente,granel_movimientos_envasado.litros_existentes,granel_movimientos_envasado.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble ,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey FROM granel_movimientos_envasado INNER JOIN granel_entrada_envasado ON granel_movimientos_envasado.id_granel_entrada_envasado=granel_entrada_envasado.id_granel_entrada_envasado LEFT JOIN existenciaplanta ON granel_entrada_envasado.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada_envasado.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble_envasado.id_granel_entrada_envasado,granel_ensamble_envasado.litros,granel_ensamble_envasado.agave_coccion_kg,comun.nombre FROM granel_ensamble_envasado INNER JOIN existenciaplanta ON granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc, granel_ensamble_envasado.agave_coccion_kg desc)  TABLA ON granel_movimientos_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado  LEFT JOIN (   SELECT granel_ensamble_envasado.id_granel_entrada_envasado,granel_ensamble_envasado.litros,granel_ensamble_envasado.agave_coccion_kg, granel_ensamble_envasado.id_planta,  granel_ensamble_envasado.id_predio, comun3.nombre  FROM granel_ensamble_envasado  LEFT JOIN existenciaplanta ON granel_ensamble_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble_envasado.id_comun = comun3.id_comun ORDER BY granel_ensamble_envasado.litros DESC , granel_ensamble_envasado.agave_coccion_kg DESC) AS maguey ON granel_entrada_envasado.id_granel_entrada_envasado = maguey.id_granel_entrada_envasado WHERE granel_entrada_envasado.id_envasadora= '" + CmbEnvasadora.SelectedValue + "' and granel_movimientos_envasado.litros_existentes > 0 and granel_movimientos_envasado.destino='barricas'  GROUP BY granel_movimientos_envasado.id_granel_movimientos_envasado ");
                    DataRow fila;
                    dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].NewRow();
                        fila["ID_GRANEL_MOVIMIENTOS_ENVASADO"] = Convert.ToString(row["id_granel_movimientos_envasado"]);
                        fila["ID_PRODUCCION_GRANEL_ENVASADO"] = Convert.ToString(row["id_granel_entrada_envasado"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        fila["FOLIO"] = Convert.ToString(row["folio"]);
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }

                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["NO_BARRICAS"] = Convert.ToString(row["numero_de_contenedores"]);
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS"] = Convert.ToString(row["litros_existentes"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);

                        dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Rows.Add(fila);
                    }
                }
                else if (BanderaVidrioEnvasado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos_envasado.numero_de_contenedores,granel_movimientos_envasado.id_granel_movimientos_envasado,granel_movimientos_envasado.id_granel_entrada_envasado,granel_movimientos_envasado.folio,DATE_FORMAT(granel_movimientos_envasado.fecha, '%d/%m/%Y') as fecha,granel_movimientos_envasado.no_lote,granel_entrada_envasado.fq,granel_entrada_envasado.categoria,granel_entrada_envasado.abocante,granel_entrada_envasado.ingrediente,granel_movimientos_envasado.litros_existentes,granel_movimientos_envasado.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey FROM granel_movimientos_envasado INNER JOIN granel_entrada_envasado ON granel_movimientos_envasado.id_granel_entrada_envasado=granel_entrada_envasado.id_granel_entrada_envasado LEFT JOIN existenciaplanta ON granel_entrada_envasado.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada_envasado.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble_envasado.id_granel_entrada_envasado,granel_ensamble_envasado.litros,granel_ensamble_envasado.agave_coccion_kg,comun.nombre FROM granel_ensamble_envasado INNER JOIN existenciaplanta ON granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc, granel_ensamble_envasado.agave_coccion_kg desc)  TABLA ON granel_movimientos_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado  LEFT JOIN (   SELECT granel_ensamble_envasado.id_granel_entrada_envasado,granel_ensamble_envasado.id_planta,  granel_ensamble_envasado.id_predio,granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun3.nombre  FROM granel_ensamble_envasado  LEFT JOIN existenciaplanta ON granel_ensamble_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble_envasado.id_comun = comun3.id_comun ORDER BY granel_ensamble_envasado.litros DESC , granel_ensamble_envasado.agave_coccion_kg DESC) AS maguey ON granel_entrada_envasado.id_granel_entrada_envasado = maguey.id_granel_entrada_envasado WHERE granel_entrada_envasado.id_envasadora= '" + CmbEnvasadora.SelectedValue + "' and granel_movimientos_envasado.litros_existentes > 0 and granel_movimientos_envasado.destino='vidrio'  GROUP BY granel_movimientos_envasado.id_granel_movimientos_envasado  ");
                    DataRow fila;
                    dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].NewRow();
                        fila["ID_GRANEL_MOVIMIENTOS_ENVASADO"] = Convert.ToString(row["id_granel_movimientos_envasado"]);
                        fila["ID_PRODUCCION_GRANEL_ENVASADO"] = Convert.ToString(row["id_granel_entrada_envasado"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        fila["FOLIO"] = Convert.ToString(row["folio"]);
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }

                        fila["NO_CONTENEDORES"] = Convert.ToString(row["numero_de_contenedores"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS"] = Convert.ToString(row["litros_existentes"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Rows.Add(fila);
                    }
                }

            }
        }





        //al  seleccionar  la fabrica carga los lotes para mostrar
        private void CmbFabricaGranelEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbLoteGranelParaEnvasado.DataSource = null;
            dtsProduccionParaGuardarAgranelEnvasado.Clear();
            if (CmbFabricaGranelEnvasado.SelectedValue != null)
            {
                ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranelParaEnvasado, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + CmbFabricaGranelEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");
                TxtMestroMezcaleroGranelEnvasado.Text = ConexionMysql.regresaCampoConsulta("SELECT maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabricaGranelEnvasado.SelectedValue + "'");
            }
        }





        //crea la tabla de  producto granel
        private void addTablaProductoAgranelEnvasado()
        {
            dtsProductoAgranelEnvasado = new DataSet();
            dtsProductoAgranelEnvasado.Tables.Add("PRODUCTOAGRANELENVASADO");
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("ID_PRODUCCION_GRANEL_ENVASADO", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("NO_TANQUE", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"].Columns.Add("VERIFICAR", Type.GetType("System.Byte[]"));//VERIFICACION DE MOV. BOTÓN
            DtaProductoAgranelEnvasado.DataSource = dtsProductoAgranelEnvasado.Tables["PRODUCTOAGRANELENVASADO"];
            DtaProductoAgranelEnvasado.Columns[1].Visible = false;
           // DtaProductoAgranelEnvasado.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            //DtaProductoAgranelEnvasado.Columns[8].Visible = false;
        }



        //crea la tabla de  producto en barrica
        private void addTablaProductoBarricaEnvasado()
        {
            dtsProductoBarricaEnvasado = new DataSet();
            dtsProductoBarricaEnvasado.Tables.Add("PRODUCTOBARRICAENVASADO");
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("ID_GRANEL_MOVIMIENTOS_ENVASADO", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("ID_PRODUCCION_GRANEL_ENVASADO", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("NO_BARRICAS", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("FOLIO", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoBarricaEnvasado.DataSource = dtsProductoBarricaEnvasado.Tables["PRODUCTOBARRICAENVASADO"];
            //DtaProductoBarricaEnvasado.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            DtaProductoBarricaEnvasado.Columns[1].Visible = false;
            DtaProductoBarricaEnvasado.Columns[2].Visible = false;
            //DtaProductoBarricaEnvasado.Columns[9].Visible = false;
        }


        //crea la tabla de  producto en vidrio

        private void addTablaProductoVidrioEnvasado()
        {
            dtsProductoVidrioEnvasado = new DataSet();
            dtsProductoVidrioEnvasado.Tables.Add("PRODUCTOVIDRIOENVASADO");
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("ID_GRANEL_MOVIMIENTOS_ENVASADO", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("ID_PRODUCCION_GRANEL_ENVASADO", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("NO_CONTENEDORES", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("FOLIO", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoVidrioEnvasado.DataSource = dtsProductoVidrioEnvasado.Tables["PRODUCTOVIDRIOENVASADO"];
            //DtaProductoVidrioEnvasado.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            DtaProductoVidrioEnvasado.Columns[1].Visible = false;
            DtaProductoVidrioEnvasado.Columns[2].Visible = false;
            //DtaProductoVidrioEnvasado.Columns[9].Visible = false;
        }


        // crear tabla de produccion  para guardar el registro agranel
        private void addTablaProduccionParaGuardarAgranelEnvasado()
        {
            dtsProduccionParaGuardarAgranelEnvasado = new DataSet();
            dtsProduccionParaGuardarAgranelEnvasado.Tables.Add("PRODUCCIONPARAGUARDARAGRANELENVASADO");
            dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Columns.Add("ID_GRANEL_ENTRADA", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaProduccionParaGuardarAgranelEnvasado.DataSource = dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"];
            DtaProduccionParaGuardarAgranelEnvasado.Columns[1].Visible = false;

        }

        // crear tabla de produccion  para guardar el registro agranel
        private void addTablaTanquesEnvasado()
        {
            dtsTanquesEnvasado = new DataSet();
            dtsTanquesEnvasado.Tables.Add("TANQUESENVASADO");
            dtsTanquesEnvasado.Tables["TANQUESENVASADO"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanquesEnvasado.Tables["TANQUESENVASADO"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaTanquesEnvasado.DataSource = dtsTanquesEnvasado.Tables["TANQUESENVASADO"];
        }


        //boton para  agregar produccion para granel  envasado
        private void BtnAgregarProduccionAgranelEnvasado_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbLoteGranelParaEnvasado.SelectedValue == null)
                {
                    MessageBox.Show("No tienes lotes para agregar");
                    return;
                }
                if (TxtLitrosParaGuardarAgranelEnvasado.Text == "")
                {
                    MessageBox.Show("No ha introducido litros");
                    return;
                }


                if (Math.Round(double.Parse(litros), 2) < Math.Round(double.Parse(TxtLitrosParaGuardarAgranelEnvasado.Text), 2))
                {
                    MessageBox.Show("Existencia insuficiente");
                    return;
                }
                DataRow fila = dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].NewRow();
                fila["NO_LOTE"] = no_lote;
                fila["ID_GRANEL_ENTRADA"] = CmbLoteGranelParaEnvasado.SelectedValue;
                fila["LITROS"] = TxtLitrosParaGuardarAgranelEnvasado.Text;
                fila["%_ALCOHOLICO"] = grado_alcoholico;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Rows.Add(fila);
                TxtLitrosParaGuardarAgranelEnvasado.Text = "";
                CmbLoteGranelParaEnvasado.DataSource = null;
                string produccion = "";
                string coma = "";
                for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                {
                    produccion += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'";
                    coma = ",";
                }


                ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranelParaEnvasado, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN (" + produccion + ") and  id_fabrica='" + CmbFabricaGranelEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");


                if (DtaProduccionParaGuardarAgranelEnvasado.Rows.Count > 1)
                {

                    genvasado();



                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void genvasado()
        {
            string CategoriaMezcal = "";
            string claseMezcal = "";

            int mzkl = 0;
            int maartesanal = 0;
            int mancetral = 0;

            int des_con = 0;
            int abocado_con = 0;
            int boj = 0;
            int madurado_vidrio = 0;
            int reposado = 0;
            int Añejo = 0;

            int s_klss = 0;



            if (granel_envasadoBandera == true)
            {
                for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                {
                    CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                    claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");


                    //MessageBox.Show("la categoria es : " + CategoriaMezcal);

                    if (CategoriaMezcal == "Mezcal")
                    {
                        mzkl++;
                    }
                    else if (CategoriaMezcal == "Mezcal Artesanal")
                    {
                        maartesanal++;
                    }
                    else if (CategoriaMezcal == "Mezcal Ancestral")
                    {
                        mancetral++;
                    }


                    if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven") { boj++; }
                    else if (claseMezcal == "Madurado en vidrio") { madurado_vidrio++; }
                    else if (claseMezcal == "Reposado") { reposado++; }
                    else if (claseMezcal == "Añejo") { Añejo++; }
                    else if (claseMezcal == "Abocado con") { abocado_con++; }
                    else if (claseMezcal == "Destilado con") { des_con++; }



                }//====FIn del for --- -

            }
            else if (envasadoBandera == true)
            {
                for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                {
                    CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                    claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");


                    //MessageBox.Show("la categoria es : " + CategoriaMezcal);

                    if (CategoriaMezcal == "Mezcal")
                    {
                        mzkl++;
                    }
                    else if (CategoriaMezcal == "Mezcal Artesanal")
                    {
                        maartesanal++;
                    }
                    else if (CategoriaMezcal == "Mezcal Ancestral")
                    {
                        mancetral++;
                    }


                    if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven") { boj++; }
                    else if (claseMezcal == "Madurado en vidrio") { madurado_vidrio++; }
                    else if (claseMezcal == "Reposado") { reposado++; }
                    else if (claseMezcal == "Añejo") { Añejo++; }
                    else if (claseMezcal == "Abocado con") { abocado_con++; }
                    else if (claseMezcal == "Destilado con") { des_con++; }



                }//====FIn del for --- -

            }


            int[] cadclase = { boj, madurado_vidrio, reposado, Añejo, abocado_con, des_con };

            //MessageBox.Show("es : " + cadclase);


            for (int g = 0; g < cadclase.Length; g++)
            {

                if (cadclase[g] > 0)
                {
                    s_klss++;
                    // if (cadclase[1] != 0) { }

                }

            }



            //MessageBox.Show(" esto representa : " + s_klss);
            //MessageBox.Show(" esto representa : " + klss);


            if (s_klss > 1)
            {

                claseMezcal = "Cls_dif";
            }
            /* else if (s_klss == 1)
             {
                 if (cadclase[0] > 0) { claseMezcal = "Blanco o Joven"; }
                 else if (cadclase[1] > 0) { claseMezcal = "Madurado en vidrio"; }
                 else if (cadclase[2] > 0) { claseMezcal = "Reposado"; }
                 else if (cadclase[3] > 0) { claseMezcal = "Añejo"; }
                 else if (cadclase[4] > 0) { claseMezcal = "Abocado con"; }
                 else if (cadclase[5] > 0) { claseMezcal = "Destilado con"; }
             }
             */

            if (claseMezcal == "Cls_dif")
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Rows.Clear();
                return;

            }


            //========= Mezcal categoria

            if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Rows.Clear();
                return;
                //CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
            {
                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Rows.Clear();
                return;

                //CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Rows.Clear();
                return;
                // CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Rows.Clear();
                return;
                // CategoriaMezcal = "dif_categoria";
            }
            /*else if (maartesanal > 0 && mancetral == 0 && mzkl == 0)
            {
                CategoriaMezcal = "Mezcal Artesanal";
            }
            else if (maartesanal == 0 && mancetral == 0 && mzkl > 0)
            {
                CategoriaMezcal = "Mezcal";
            }
            else if (maartesanal == 0 && mancetral > 0 && mzkl == 0)
            {
                CategoriaMezcal = "Mezcal Ancestral";
            }*/
        }// == fin de  genvasado()


        //al seleccionar una produccion carga datos litros,tapada,grado alcoholico
        private void CmbLoteGranelParaEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (CmbLoteGranelParaEnvasado.DataSource == null)
                {
                    litros = "";
                    grado_alcoholico = "";
                    no_lote = "";
                }
                else
                {
                    litros = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes FROM  granel_entrada  WHERE id_granel_entrada='" + CmbLoteGranelParaEnvasado.SelectedValue + "'");
                    grado_alcoholico = ConexionMysql.regresaCampoConsulta("SELECT grado_alcoholico_existente FROM  granel_entrada  WHERE id_granel_entrada='" + CmbLoteGranelParaEnvasado.SelectedValue + "'");
                    no_lote = ConexionMysql.regresaCampoConsulta("SELECT no_lote FROM  granel_entrada  WHERE id_granel_entrada='" + CmbLoteGranelParaEnvasado.SelectedValue + "'");
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //al presionar doble clik quita produccion para guardar agranel
        private void DtaProduccionParaGuardarAgranelEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProduccionParaGuardarAgranelEnvasado.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaProduccionParaGuardarAgranelEnvasado.Rows.RemoveAt(e.RowIndex);
                    dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].AcceptChanges();
                    CmbLoteGranelParaEnvasado.DataSource = null;
                    if (DtaProduccionParaGuardarAgranelEnvasado.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'";
                            coma = ",";
                        }

                        ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranelParaEnvasado, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN (" + produccion + ") and  id_fabrica='" + CmbFabricaGranelEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");

                    }
                    else
                    {

                        ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranelParaEnvasado, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where  id_fabrica='" + CmbFabricaGranelEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // boton para agregar nombres de tanques
        private void BtnAgregarTanqueEnvasado_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtTanqueEnvasado.Text == "")
                {
                    MessageBox.Show("No ha introducido un nombre de tanque");
                    TxtTanqueEnvasado.Focus();
                    return;
                }
                DataRow fila = dtsTanquesEnvasado.Tables["TANQUESENVASADO"].NewRow();
                fila["TANQUE"] = TxtTanqueEnvasado.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsTanquesEnvasado.Tables["TANQUESENVASADO"].Rows.Add(fila);
                TxtTanqueEnvasado.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //boton para quitar tanques 
        private void DtaTanquesEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaTanquesEnvasado.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaTanquesEnvasado.Rows.RemoveAt(e.RowIndex);
                    dtsTanquesEnvasado.Tables["TANQUESENVASADO"].AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //guardar producto agranel
        private void BtnGuardarGranelEnvasado_Click(object sender, EventArgs e)
        {

            try
            {

                if (CmbEnvasadora.SelectedValue == null)
                {
                    MessageBox.Show("No ha seleccionado ninguna fabrica");
                    return;
                }
                if (DtaProduccionParaGuardarAgranelEnvasado.Rows.Count == 0)
                {
                    MessageBox.Show("No ha seleccionado ningun lote");
                    return;
                }
                if (DtaTanquesEnvasado.Rows.Count == 0)
                {
                    MessageBox.Show("No ha introduccido ningun tanque");
                    return;
                }
                if (TxtNoLoteEnva.Text == "")
                {
                    MessageBox.Show("No ha introduccido un lote");
                    TxtNoLoteEnva.Focus();
                    return;
                }
                DateTime local = DateTime.Now;
                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");

                double litros = 0;
                double grado_alcoholico = 0;
                double grado_alcoholico_para_suma = 0;

                //================================================================>>> Confirmacion de datos a ingresar <<<============
                string tipo = label46.Text;
                string f = CmbNoClienteGranelEnvasado.Text;
                string o = CmbEnvasadora.Text;
                string p = "";

                string pp = "";
                string p3 = "";

                //string produccion = "";
                string coma = "";
                //--->>-Mustra la lista de los DatagredView
                for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                {
                    p += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["NO_LOTE"].Value + "'\n";
                    pp += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value + "'\n";
                    p3 += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value + "'\n";
                    coma = "  ";
                }


                string q = "";
                ;
                //--->>-Mustra la lista de los DatagredView
                for (int x = 0; x < DtaTanquesEnvasado.Rows.Count; x++)
                {
                    coma = "";
                    q += coma + "'" + DtaTanquesEnvasado.Rows[x].Cells["TANQUE"].Value + "'\n";
                    coma = "  ";
                }
                string t = TxtNoLoteEnva.Text;
                string a = "No";
                string b = ".....";

                //---Muestra en el modal ei es abocado o no
                if (chkAbocadoEnvasado.Toggled == true)
                {

                    if (TxtIngredienteEnvasado.Text == "")
                    {
                        MessageBox.Show("Desbes escribir un ingrediente...");
                        return;
                    }


                    a = "Si";
                    b = TxtIngredienteEnvasado.Text;
                }



                string c = TxtFQEnvasado.Text;


                /*   DialogResult r = MsgBxGranelenvasado.Show("No Cliente" + f + "\nEnvasadora: " + o + "\n\n --->-Lote Granel-<---" + "\nNo lote: " + p + "\n\nLitros: " + pp + " \n\n% Alcoholico: "
                    + p3 + "\n\n --->-Tanques-<---" + "\nTanques envasados: " + q + "\n\nNo lote: " + t + "\n\nAbocado: " + a
                    + "\n\nIngrediente: " + b + "\n\nClave FQ: " + c, "---", "Aceptar","Cancelar");
                  */


                // Inventario.Dialogs.Form1 d = new Dialogs.Form1();
                //d.ShowDialog();

                string dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + q + "!" + t + "!" + a + "!" + c + "!" + b;

                MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
                msg.granelEnvasadook(dto);
                msg.ShowDialog();

                if (msg.DialogResult == DialogResult.Cancel) { return; }
                else
                {

                    for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                    {
                        litros += Math.Round(double.Parse(DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                        grado_alcoholico_para_suma += Math.Round(double.Parse(DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2) * Math.Round(double.Parse(DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value.ToString()), 2);
                    }
                    grado_alcoholico = grado_alcoholico_para_suma / litros;

                    //obtenesmos el id maximo de la entrada a granel envasado
                    ObtenerIdMaximoGranelEntradaEnvasado();
                    if (DtaProduccionParaGuardarAgranelEnvasado.Rows.Count == 1)
                    {
                        DataSet Datos = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos, "SELECT  no_cliente, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente FROM granel_entrada where id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");




                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            //--- Valida si al ingresarlo se le agrega un abocante y le cambia la categoria---
                            if (chkAbocadoEnvasado.Toggled == true)
                            {
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + row["no_cliente"].ToString() + "','" + CmbEnvasadora.SelectedValue + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLoteEnva.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + TxtFQEnvasado.Text + "','Abocado con','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + TxtIngredienteEnvasado.Text + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "',NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                                {
                                    return;
                                }


                            }
                            else
                            {


                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + row["no_cliente"].ToString() + "','" + CmbEnvasadora.SelectedValue + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLoteEnva.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + TxtFQEnvasado.Text + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "',NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                                {
                                    return;
                                }
                            }
                        }

                        DataSet Datos2 = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {
                            ObtenerIdMaximoGranelEnsambleEnvasado();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES('" + id_max_granel_ensamble_envasado + "', '" + id_max_granel_entrada_envasado + "' ,'" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaProduccionParaGuardarAgranelEnvasado.Rows[0].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }


                        DataSet ids = new DataSet();
                        ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_fabrica'");

                        foreach (DataRow row in ids.Tables[0].Rows)
                        {
                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada_envasado + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }





                    } /// --- fin de (DtaProduccionParaGuardarAgranelEnvasado.Rows.Count == 1)
                    else
                    {
                        string CategoriaMezcalComparar = "";
                        string claseMezcalComparar = "";
                        string CategoriaMezcal = "";
                        string claseMezcal = "";

                        int mzkl = 0;
                        int maartesanal = 0;
                        int mancetral = 0;

                        int des_con = 0;
                        int abocado_con = 0;
                        int boj = 0;
                        int madurado_vidrio = 0;
                        int reposado = 0;
                        int Añejo = 0;

                        int s_klss = 0;

                        string TxtIngredienteEnvasadoDB = "";
                        string ingredientecadena = "";


                        string sep = "";


                        for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                        {
                            CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");


                            //MessageBox.Show("la categoria es : " + CategoriaMezcal);

                            if (CategoriaMezcal == "Mezcal")
                            {
                                mzkl++;
                            }
                            else if (CategoriaMezcal == "Mezcal Artesanal")
                            {
                                maartesanal++;
                            }
                            else if (CategoriaMezcal == "Mezcal Ancestral")
                            {
                                mancetral++;
                            }

                            //saca categoria
                            /* if (CategoriaMezcalComparar != "")
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
                            }*/
                            //  CategoriaMezcalComparar = CategoriaMezcal;

                            //MessageBox.Show("la categoria es : "+CategoriaMezcal);
                            //saca clase

                            //MessageBox.Show("la clase es : " + claseMezcal);
                            /*if (claseMezcalComparar != "")
                            {
                                if (claseMezcal == "Reposado")
                                {
                                    if (claseMezcalComparar == "Joven")
                                    {
                                        claseMezcal = claseMezcalComparar;
                                    }
                                }
                                else if (claseMezcal == "Añejo")
                                {
                                    if (claseMezcalComparar == "Joven")
                                    {
                                        claseMezcal = claseMezcalComparar;
                                    }
                                    else if (claseMezcalComparar == "Reposado")
                                    {
                                        claseMezcal = claseMezcalComparar;
                                    }
                                }
                            }
                            claseMezcalComparar = claseMezcal;*/
                            if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven") { boj++; }
                            else if (claseMezcal == "Madurado en vidrio") { madurado_vidrio++; }
                            else if (claseMezcal == "Reposado") { reposado++; }
                            else if (claseMezcal == "Añejo") { Añejo++; }
                            else if (claseMezcal == "Abocado con") { abocado_con++; }
                            else if (claseMezcal == "Destilado con") { des_con++; }



                        }//====FIn del for --- -

                        int[] cadclase = { boj, madurado_vidrio, reposado, Añejo, abocado_con, des_con };

                        //MessageBox.Show("es : " + cadclase);


                        for (int g = 0; g < cadclase.Length; g++)
                        {

                            if (cadclase[g] > 0)
                            {
                                s_klss++;
                                // if (cadclase[1] != 0) { }

                            }

                        }



                        // MessageBox.Show(" esto representa : " + s_klss);
                        //MessageBox.Show(" esto representa : " + klss);


                        if (s_klss > 1)
                        {

                            claseMezcal = "Cls_dif";
                        }
                        else if (s_klss == 1)
                        {
                            if (cadclase[0] > 0) { claseMezcal = "Blanco o Joven"; }
                            else if (cadclase[1] > 0) { claseMezcal = "Madurado en vidrio"; }
                            else if (cadclase[2] > 0) { claseMezcal = "Reposado"; }
                            else if (cadclase[3] > 0) { claseMezcal = "Añejo"; }
                            else if (cadclase[4] > 0) { claseMezcal = "Abocado con"; }
                            else if (cadclase[5] > 0) { claseMezcal = "Destilado con"; }
                        }
                        //MessageBox.Show("resultado : "+ claseMezcal);



                        if (claseMezcal == "Cls_dif")
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                        }

                        ///====================== -- INGREDIENTES -- ===================
                        ///entra si la clase es abocado con  o destilado con --- 

                        if (claseMezcal == "Abocado con" || claseMezcal == "Destilado con")
                        {

                            for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                            {
                                ingredientecadena = ConexionMysql.regresaCampoConsulta("SELECT ingrediente  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");

                                //if (des_ingrediente != "")
                                //{
                                //des_con++;

                                TxtIngredienteEnvasadoDB += sep + " " + ingredientecadena;
                                sep = ",";
                                // MessageBox.Show("es : " + TxtIngredienteEnvasadoDB );
                                //}


                            }



                        }



                        // MessageBox.Show("es final : " + TxtIngredienteEnvasadoDB);



                        //========= Mezcal categoria

                        if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            //CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
                        {
                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                            //CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            // CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            // CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral == 0 && mzkl == 0)
                        {
                            CategoriaMezcal = "Mezcal Artesanal";
                        }
                        else if (maartesanal == 0 && mancetral == 0 && mzkl > 0)
                        {
                            CategoriaMezcal = "Mezcal";
                        }
                        else if (maartesanal == 0 && mancetral > 0 && mzkl == 0)
                        {
                            CategoriaMezcal = "Mezcal Ancestral";
                        }

                        // MessageBox.Show("la categoria final es : " + CategoriaMezcal);

                        // MessageBox.Show("la clase es : " + claseMezcal);

                        if (chkAbocadoEnvasado.Toggled == true)
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + CmbNoClienteGranelEnvasado.SelectedValue + "','" + CmbEnvasadora.SelectedValue + "' ,now(),0,'" + TxtNoLoteEnva.Text + "','" + TxtFQEnvasado.Text + "','Abocado con','" + CategoriaMezcal + "','-' ,'" + TxtIngredienteEnvasado.Text + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "',NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + CmbNoClienteGranelEnvasado.SelectedValue + "','" + CmbEnvasadora.SelectedValue + "' ,now(),0,'" + TxtNoLoteEnva.Text + "','" + TxtFQEnvasado.Text + "','" + claseMezcal + "','" + CategoriaMezcal + "','-' ,'" + TxtIngredienteEnvasadoDB + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "',NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                            {
                                return;
                            }

                        }//Fin del else chkAbocadoEnvasado

                        for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                        {
                            DataSet Datos = new DataSet();
                            ConexionMysql.llenaDataset(ref Datos, "SELECT  id_planta,id_comun,id_predio,agave_coccion_kg FROM granel_entrada where id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            foreach (DataRow row in Datos.Tables[0].Rows)
                            {
                                if (row["id_planta"].ToString() == "0" && row["id_comun"].ToString() == "0")
                                {
                                    DataSet Datos2 = new DataSet();
                                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                                    foreach (DataRow row2 in Datos2.Tables[0].Rows)
                                    {
                                        ObtenerIdMaximoGranelEnsambleEnvasado();
                                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_granel_ensamble_envasado + "','" + id_max_granel_entrada_envasado + "' ,'" + row2["id_comun"].ToString() + "','" + row2["id_planta"].ToString() + "','" + row2["id_predio"].ToString() + "','" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value.ToString() + "','" + row2["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                        {
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ObtenerIdMaximoGranelEnsambleEnvasado();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_granel_ensamble_envasado + "','" + id_max_granel_entrada_envasado + "' ,'" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                    {
                                        return;
                                    }
                                }
                            }
                        }

                        ///----- para agregar los ids_produccion si son de varias producciones
                        for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                        {

                            DataSet ids = new DataSet();
                            ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_fabrica'");

                            foreach (DataRow row in ids.Tables[0].Rows)
                            {
                                ///--- inserta el id de la produccion---
                                string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada_envasado + "'," + Usuario.IdUsuario + ",0)") == "Error")
                                {
                                    return;
                                }
                            }
                        }


                    } /// --- fin de else (DtaProduccionParaGuardarAgranelEnvasado.Rows.Count > 1)



                    //marca la salida del producto y actualiza existencia de granel fabrica

                    for (int x = 0; x < DtaProduccionParaGuardarAgranelEnvasado.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGranelSalida();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_salida(id_granel_salida,id_granel_entrada,id_solicitud,id_granel_entrada_envasado,litros,grado_alcoholico,id_verificador) VALUES('" + id_max_granel_salida + "', '" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "',0,'" + id_max_granel_entrada_envasado + "','" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value + "','" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }

                        string litros_granel = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                        double existencia = Math.Round(double.Parse(litros_granel), 2) - Math.Round(double.Parse(DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada SET lts_existentes=" + existencia + ",actualizado=0 WHERE id_granel_entrada='" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanquesEnvasado.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGranelTanqueEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador,actualizado) VALUES( '" + id_max_granel_tanque_envasado + "','" + id_max_granel_entrada_envasado + "','" + DtaTanquesEnvasado.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }
                    LimpiarGranelEnvasado();
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Exito");
                    CmbNoClienteGranelEnvasado_SelectedIndexChanged(sender, e);

                    chkAbocadoEnvasado.Toggled = false;

                    TxtIngredienteEnvasado.Enabled = false;
                    lblIngrediente.Enabled = false;

                    //Veri_movimientos.produccion = true;

                }//-->>Fin del else de DialogResult--


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        //================================================================>>>Fin de Confirmacion de datos a ingresar <<<============
        //limpia controles del formulario de granel
        public void LimpiarGranelEnvasado()
        {
            dtsProduccionParaGuardarAgranelEnvasado.Tables["PRODUCCIONPARAGUARDARAGRANELENVASADO"].Rows.Clear();
            dtsTanquesEnvasado.Tables["TANQUESENVASADO"].Rows.Clear();
            TxtNoLoteEnva.Text = "";
            //TxtAbocadoEnvasado.Text = "";
            TxtIngredienteEnvasado.Text = "";
            TxtFQEnvasado.Text = "";
        }


        private void DtaProductoAgranelEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoAgranelEnvasado.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosGranel frm = new FrmMovimientosGranel();
                    frm.id_granel_entrada = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ENVASADO"].Value.ToString();
                    frm.lts_existentes = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico_existente = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.no_lote = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.categoria = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.clase = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.fq = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    //frm.abocante = DtaProductoAgranel.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    //frm.ingrediente = DtaProductoAgranel.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteGranelEnvasado.SelectedValue.ToString();
                    frm.id_envasadora = CmbEnvasadora.SelectedValue.ToString();
                    frm.tipo = "envasadora";
                    frm.ShowDialog();
                    CmbNoClienteGranelEnvasado_SelectedIndexChanged(sender, e);
                }
                else if (DtaProductoAgranelEnvasado.Columns[e.ColumnIndex].Name == "NO_LOTE")
                {

                    /*editar.FrmCambioNombre frm = new editar.FrmCambioNombre();
                    frm.id_lote = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ENVASADO"].Value.ToString();
                    frm.no_lote_actual = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.tipo = "g_envasado";
                    frm.ShowDialog();
                    CmbNoClienteGranelEnvasado_SelectedIndexChanged(sender, e);*/
                    MessageBox.Show("No se puede realizar el cambio del nombre del lote, revisalo con tu jefe inmediato");

                }
                else if (DtaProductoAgranelEnvasado.Columns[e.ColumnIndex].Name == "NO_TANQUE")
                {

                    editar.FrmCambioTanques frm = new editar.FrmCambioTanques();
                    frm.id_lote = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ENVASADO"].Value.ToString();
                    frm.no_lote = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.tipo = "g_envasado";
                    frm.ShowDialog();
                    CmbNoClienteGranelEnvasado_SelectedIndexChanged(sender, e);

                }

                // TODO: FUNCIONES A REALIZAR AL SELECCIONAR EL BOTÓN DE CHECKEO DE LOTES DE GRANEL ENVASADO
                else if (DtaProductoAgranelEnvasado.Columns[e.ColumnIndex].Name == "VERIFICAR")
                {
                    String id_lote_granel_envasado = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ENVASADO"].Value.ToString();
                    String nombreLoteGE = DtaProductoAgranelEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    int id_pkGE = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("Select id from granel_entrada_envasado where " +
                        "id_granel_entrada_envasado = '" + id_lote_granel_envasado + "' "));

                    ObtenerIdMaximoLotesSinMovimientoGE();
                    int resultGE = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT COUNT(*) FROM modificaciones_inventario_GE where " +
                        "id_tabla = '" + id_lote_granel_envasado + "' and n_tabla like 'granel_entrada_envasado' and date(fecha_ultima_modificacion) = date(now())"));

                    if (resultGE <= 0)
                    {
                        DialogResult check = MessageBox.Show("¿Has verificado que el lote de envasado no ha tenido movimientos?", "¡Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (check == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (check == DialogResult.OK)
                        {

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  checked_lotes_ge(id_checked_lotege,id_pkGE,id_granel_entrada_envasado,no_cliente,id_envasadora,no_lote," +
                                "fecha_ultima_verificacion,checked,verificador_id,actualizado) VALUES ('" + id_max_loteSinMovGE + "','" + id_pkGE + "', " +
                                "'" + id_lote_granel_envasado + "', '" + CmbNoCliente.SelectedValue + "','" + CmbEnvasadora.SelectedValue + "', '" + nombreLoteGE + "', NOW(), '1', " +
                                "" + Usuario.IdUsuario + ", '0')") == "Error")
                            {
                                return;
                            }

                            ConexionMysql.transCompleta();
                            MessageBox.Show("Lote verificado con éxito");
                        }
                    }
                    else if (resultGE >= 1)
                    {
                        MessageBox.Show("Este lote ha tenido movimientos el día de hoy");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //al seleccionar un tab de producto a granel carga granel o barrica poniendo la bandera en true para cargar los datos (envasado)
        private void tabControl5_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl5.SelectedTab == tabPage11)
            {
                BanderaGranelEnvasado = true;
                BanderaBarricaEnvasado = false;
                BanderaVidrioEnvasado = false;
                CmbEnvasadora_SelectedIndexChanged(null, null);
            }
            else if (tabControl5.SelectedTab == tabPage12)
            {
                BanderaGranelEnvasado = false;
                BanderaBarricaEnvasado = true;
                BanderaVidrioEnvasado = false;
                CmbEnvasadora_SelectedIndexChanged(null, null);
            }
            else if (tabControl5.SelectedTab == tabPage13)
            {
                BanderaGranelEnvasado = false;
                BanderaBarricaEnvasado = false;
                BanderaVidrioEnvasado = true;
                CmbEnvasadora_SelectedIndexChanged(null, null);
            }
        }


        //muestras lo movimientos que se puede hacer en barricas (envasado)
        private void DtaProductoBarricaEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoBarricaEnvasado.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosBarrica frm = new FrmMovimientosBarrica();
                    frm.fecha = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
                    frm.id_granel_movimiento = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["ID_GRANEL_MOVIMIENTOS_ENVASADO"].Value.ToString();
                    frm.id_granel_produccion = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ENVASADO"].Value.ToString();
                    frm.folio = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["FOLIO"].Value.ToString();
                    frm.no_barricas = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["NO_BARRICAS"].Value.ToString();
                    frm.no_lote = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.categoria = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.litros = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.maguey = DtaProductoBarricaEnvasado.Rows[e.RowIndex].Cells["ESPECIE"].Value.ToString();
                    frm.tipo = "envasadora";
                    frm.no_cliente = CmbNoClienteGranelEnvasado.SelectedValue.ToString();
                    //"ESPECIE"
                    frm.ShowDialog();
                    CmbNoClienteGranelEnvasado_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //muestras lo movimeintos que se puede hacer en vidrio
        private void DtaProductoVidrioEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoVidrioEnvasado.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosVidrio frm = new FrmMovimientosVidrio();
                    frm.fecha = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
                    frm.id_granel_movimiento = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["ID_GRANEL_MOVIMIENTOS_ENVASADO"].Value.ToString();
                    frm.id_granel_produccion = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ENVASADO"].Value.ToString();
                    frm.folio = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["FOLIO"].Value.ToString();
                    frm.no_lote = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.no_contenedores = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["NO_CONTENEDORES"].Value.ToString();
                    frm.categoria = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.litros = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.maguey = DtaProductoVidrioEnvasado.Rows[e.RowIndex].Cells["ESPECIE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteGranelEnvasado.SelectedValue.ToString();
                    frm.tipo = "envasadora";
                    frm.ShowDialog();
                    CmbNoClienteGranelEnvasado_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
        //=============================================================================>>----{Fin Granel Envasado}---<<========================================================



        ///////////////////////////////////////////////////////////////////////////// ENVASADO ///////////////////////////////////////////////////////////////////////////////////////

        #region ENVASADOS
        private void BtnAgregarEnvasado_Click(object sender, EventArgs e)
        {
            if (CmbEnvasadoraEnvasadora.Items.Count == 0)
            {
                MessageBox.Show("No tienes una envasadora de destino, agrega una para poder realizar el movimiento");
                return;
            }
            FrmNuevoEnvasado frm = new FrmNuevoEnvasado();
            frm.no_cliente = CmbNoClienteEnvasado.SelectedValue.ToString();
            frm.id_envasadora = CmbEnvasadoraEnvasadora.SelectedValue.ToString();
            frm.tipo_instalacion = "envasadora";
            frm.ShowDialog();
            CmbNoClienteEnvasado_SelectedIndexChanged(sender, e);
        }

        //boton para transaccion
        private void BtnTransaccionEnvasado_Click(object sender, EventArgs e)
        {
            FrmTransaccion frm = new FrmTransaccion();
            frm.no_cliente = CmbNoClienteEnvasado.SelectedValue.ToString();
            if (CmbEnvasadoraEnvasadora.Items.Count == 0)
            {
                MessageBox.Show("No tienes una envasadora de destino, agrega una para poder realizar el movimiento");
                return;
            }
            frm.id_instalacion = CmbEnvasadoraEnvasadora.SelectedValue.ToString();
            frm.tipo_instalacion = "envasado";
            frm.ShowDialog();
            CmbEnvasadoraEnvasadora_SelectedIndexChanged(null, null);

        }



        //nueva envasadora
        private void BtnEnvasadoNueva_Click(object sender, EventArgs e)
        {
            FrmNuevaEnvasadora frm = new FrmNuevaEnvasadora();
            frm.no_cliente = CmbNoClienteEnvasado.SelectedValue.ToString();
            frm.ShowDialog();
            ConexionMysql.llenaCombo(ref CmbEnvasadoraEnvasadora, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteEnvasado.SelectedValue + "'", "id_envasadora", "envasadora");
            if (Usuario.EnvasadoraSeleccionada != "0")
            {
                CmbEnvasadoraEnvasadora.SelectedValue = Usuario.EnvasadoraSeleccionada;
            }

        }


        //al seleccionar un tab de producto a granel carga granel o barrica poniendo la bandera en true para cargar los datos
        private void tabControl4_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl4.SelectedTab == tabPage15)
            {
                BanderaEnvasado = true;
                BanderaEnvasadoSalio = false;
                BanderaEnvasadoNoTerminado = false;
                CmbEnvasadoraEnvasadora_SelectedIndexChanged(null, null);
            }
            else if (tabControl4.SelectedTab == tabPage16)
            {
                BanderaEnvasado = false;
                BanderaEnvasadoSalio = true;
                BanderaEnvasadoNoTerminado = false;
                CmbEnvasadoraEnvasadora_SelectedIndexChanged(null, null);
            }
            else if (tabControl4.SelectedTab == tabPage14)
            {
                BanderaEnvasado = false;
                BanderaEnvasadoSalio = false;
                BanderaEnvasadoNoTerminado = true;
                CmbEnvasadoraEnvasadora_SelectedIndexChanged(null, null);
            }
        }



        //al seleccionar un cliente para envasado carga marca y envasadoras
        private void CmbNoClienteEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {

            dtsProductoEnvasado.Clear();
            dtsProductoEnvasadoNoTerminado.Clear();
            dtsProductoEnvasadoSalio.Clear();
            ChekMaquila.Checked = false;
            LblCliente.Visible = false;
            LblMaquilaCliente.Visible = false;
            CmbMarca.DataSource = null;
            ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca FROM marcas  where no_cliente ='" + CmbNoClienteEnvasado.SelectedValue + "' ORDER BY cve_marca ASC", "id", "marca");



            //carga envasadora
            CmbEnvasadoraEnvasadora.DataSource = null;
            CmbLoteGranel.DataSource = null;
            TxtResponsableEnvasadoraEnvasadora.Text = "";
            ConexionMysql.llenaCombo(ref CmbEnvasadoraEnvasadora, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteEnvasado.SelectedValue + "'", "id_envasadora", "envasadora");
            if (Usuario.EnvasadoraSeleccionada != "0")
            {
                CmbEnvasadoraEnvasadora.SelectedValue = Usuario.EnvasadoraSeleccionada;
            }

            CmbFabricaEnvasadora.DataSource = null;
            TxtMaestroMezcaleroEnvasadora.Text = "";
            if (RbtnFabrica.Checked == true)
            {
                ConexionMysql.llenaCombo(ref CmbFabricaEnvasadora, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteEnvasado.SelectedValue + "'", "id_fabrica", "fabrica");
                if (Usuario.FabricaSeleccionada != "0")
                {
                    CmbFabricaEnvasadora.SelectedValue = Usuario.FabricaSeleccionada;
                }
            }
        }


        // al selecionar una envasadora de envasado
        private void CmbEnvasadoraEnvasadora_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (CmbEnvasadoraEnvasadora.SelectedValue != null)
            {
                TxtResponsableEnvasadoraEnvasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'");

                limpia_envasado();


                CmbLoteGranel.DataSource = null;



                if (RbtnEnvasadora.Checked == true)
                {


                    ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado  FROM granel_entrada_envasado  where id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

                    /*  ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado  FROM granel_entrada_envasado  where id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");*/

                }
                else
                {
                    ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,' ','Litros : ',lts_existentes,'  ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + CmbFabricaEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada asc", "id_granel_entrada", "produccion");

                }






                if (BanderaEnvasadoNoTerminado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT envasado_entrada.id_envasado_entrada,envasado_entrada.no_cliente, DATE_FORMAT(envasado_entrada.fecha, '%d/%m/%Y') as fecha , envasado_entrada.no_lote, envasado_entrada.fq, envasado_entrada.clase, envasado_entrada.categoria, envasado_entrada.abocante, envasado_entrada.ingrediente, envasado_entrada.unidad_medida, envasado_entrada.contenido_por_botella, envasado_entrada.litros, envasado_entrada.grado_alcoholico, envasado_entrada.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_envasado_entrada ASC ) as ensamble_maguey   FROM envasado_entrada  LEFT JOIN existenciaplanta ON envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada,envasado_ensamble.litros,envasado_ensamble.agave_coccion_kg,comun.nombre  FROM envasado_ensamble  INNER JOIN existenciaplanta ON envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by envasado_ensamble.id_envasado_entrada asc, envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc)  TABLA  ON envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada   LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada, envasado_ensamble.id_planta,  envasado_ensamble.id_predio,envasado_ensamble.litros, envasado_ensamble.agave_coccion_kg, comun3.nombre  FROM envasado_ensamble  LEFT JOIN existenciaplanta ON envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR envasado_ensamble.id_comun = comun3.id_comun  order by envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc) AS maguey ON envasado_entrada.id_envasado_entrada = maguey.id_envasado_entrada  WHERE envasado_entrada.id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "' and envasado_entrada.botellas_existentes > 0  and envasado_entrada.id_marca='0' GROUP BY envasado_entrada.id_envasado_entrada ");
                    DataRow fila;
                    dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].NewRow();
                        fila["ID_PRODUCCION_ENVASADO"] = Convert.ToString(row["id_envasado_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);

                        string especieMaguey = ConexionMysql.regresaCampoConsulta("call maguey_envasado_entrada('" + Convert.ToString(row["id_envasado_entrada"]) + "')");
                        //string especieMaguey = "";
                        fila["ESPECIE"] = especieMaguey;

                        /*
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }*/

                        if (Convert.ToString(row["fq"]) != "")
                        {
                            fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        }
                        else { fila["CLAVE_FQ"] = "---"; }
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CANTIDAD"] = Convert.ToString(row["contenido_por_botella"]);
                        fila["LITROS"] = Convert.ToString(row["litros"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Rows.Add(fila);
                    }
                }


                else if (BanderaEnvasado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT marcas.marca,envasado_entrada.id_envasado_entrada,envasado_entrada.no_cliente, DATE_FORMAT(envasado_entrada.fecha, '%d/%m/%Y') as fecha , envasado_entrada.no_lote, envasado_entrada.fq, envasado_entrada.clase, envasado_entrada.categoria, envasado_entrada.abocante, envasado_entrada.ingrediente, envasado_entrada.unidad_medida, envasado_entrada.contenido_por_botella, envasado_entrada.litros, envasado_entrada.grado_alcoholico,envasado_entrada.grado_alcoholico_etiqueta, envasado_entrada.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,  GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_envasado_entrada ASC ) as ensamble_maguey   FROM envasado_entrada  LEFT JOIN existenciaplanta ON envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada,envasado_ensamble.litros,envasado_ensamble.agave_coccion_kg,comun.nombre  FROM envasado_ensamble  INNER JOIN existenciaplanta ON envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by envasado_ensamble.id_envasado_entrada asc, envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc)  TABLA  ON envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada   LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada, envasado_ensamble.id_planta,  envasado_ensamble.id_predio,envasado_ensamble.litros, envasado_ensamble.agave_coccion_kg, comun3.nombre  FROM envasado_ensamble  LEFT JOIN existenciaplanta ON envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR envasado_ensamble.id_comun = comun3.id_comun order by envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc) AS maguey ON envasado_entrada.id_envasado_entrada = maguey.id_envasado_entrada  INNER JOIN marcas ON SUBSTRING(envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(envasado_entrada.id_marca,7,2)=marcas.cve_marca  WHERE envasado_entrada.id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "' and envasado_entrada.botellas_existentes > 0 GROUP BY envasado_entrada.id_envasado_entrada ");
                    DataRow fila;
                    dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].NewRow();
                        fila["ID_PRODUCCION_ENVASADO"] = Convert.ToString(row["id_envasado_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["MARCA"] = Convert.ToString(row["marca"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);

                        string especieMaguey = ConexionMysql.regresaCampoConsulta("call maguey_envasado_entrada('" + Convert.ToString(row["id_envasado_entrada"]) + "')");
                        //string especieMaguey = "";
                        fila["ESPECIE"] = especieMaguey;
                        /*
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);

                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }*/

                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CANTIDAD"] = Convert.ToString(row["contenido_por_botella"]);
                        fila["LITROS"] = Convert.ToString(row["litros"]);
                        fila["%ALC_LOTE_GRA"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["%ALC_ETIQUETA"] = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        fila["BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        fila["VERIFICAR"] = ConvertImageToByteArray(Properties.Resources.checked__1_, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Rows.Add(fila);
                    }
                }
                else if (BanderaEnvasadoSalio == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT envasado_entrada.id_planta,envasado_entrada.id_predio,envasado_entrada.id_marca,marcas.marca,envasado_entrada.id_envasadora,envasado_movimientos.id_envasado_movimientos,envasado_movimientos.no_cliente, DATE_FORMAT(envasado_movimientos.fecha, '%d/%m/%Y') as fecha ,envasado_movimientos.destino,envasado_entrada.no_lote,envasado_entrada.fq,envasado_entrada.clase,envasado_entrada.categoria,envasado_entrada.abocante,envasado_entrada.ingrediente,envasado_entrada.unidad_medida,envasado_entrada.contenido_por_botella,envasado_entrada.litros,envasado_entrada.grado_alcoholico,envasado_movimientos.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin , GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble , GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_envasado_entrada ASC ) as ensamble_maguey  FROM envasado_entrada  inner  JOIN envasado_movimientos ON envasado_entrada.id_envasado_entrada=envasado_movimientos.id_envasado_entrada LEFT JOIN existenciaplanta ON envasado_entrada.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN ( SELECT envasado_ensamble.id_envasado_entrada,envasado_ensamble.litros,envasado_ensamble.agave_coccion_kg,comun.nombre  FROM envasado_ensamble  INNER JOIN existenciaplanta ON envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by envasado_ensamble.id_envasado_entrada asc, envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc) TABLA   ON envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada  LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada, envasado_ensamble.id_planta,  envasado_ensamble.id_predio,envasado_ensamble.litros, envasado_ensamble.agave_coccion_kg, comun3.nombre  FROM envasado_ensamble  LEFT JOIN existenciaplanta ON envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR envasado_ensamble.id_comun = comun3.id_comun order by envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc) AS maguey ON envasado_entrada.id_envasado_entrada = maguey.id_envasado_entrada   INNER JOIN marcas ON SUBSTRING(envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(envasado_entrada.id_marca,7,2)=marcas.cve_marca  WHERE envasado_entrada.id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "' and envasado_movimientos.tipo in('salida','cambio')  and envasado_movimientos.destino in('Nacional','Exportacion','Promocion') and envasado_movimientos.botellas_existentes > 0 GROUP BY envasado_movimientos.id_envasado_movimientos");
                    // ConexionMysql.llenaDataset(ref Datos, "SELECT * FROM view_envasado_salio WHERE id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'");

                    DataRow fila;
                    dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].NewRow();
                        fila["ID_ENVASADO_MOVIMIENTOS"] = Convert.ToString(row["id_envasado_movimientos"]);
                        fila["ID_MARCA"] = Convert.ToString(row["id_marca"]);
                        fila["ID_ENVASADORA"] = Convert.ToString(row["id_envasadora"]);
                        fila["ID_PLANTA"] = Convert.ToString(row["id_planta"]);
                        fila["ID_PREDIO"] = Convert.ToString(row["id_predio"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["MARCA"] = Convert.ToString(row["marca"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        fila["DESTINO"] = Convert.ToString(row["destino"]);

                        /*string especieMaguey = ConexionMysql.regresaCampoConsulta("call maguey_envasado_entrada('" + Convert.ToString(row["id_envasado_entrada"]) + "')");
                        fila["ESPECIE"] = especieMaguey;*/
                        
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }

                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CANTIDAD"] = Convert.ToString(row["contenido_por_botella"]);
                        fila["LITROS"] = Convert.ToString(row["litros"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Rows.Add(fila);
                    }
                }
            }
        }



        //al presionar radio buton fabrica
        private void RbtnFabrica_CheckedChanged(object sender, EventArgs e)
        {
            if (DtaGranelParaEnvasado.ColumnCount > 1)
            {
                dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Clear();
            }
            if (RbtnFabrica.Checked == false)
            {
                CmbFabricaEnvasadora.Enabled = false;
                TxtMaestroMezcaleroEnvasadora.Enabled = false;
                CmbFabricaEnvasadora.DataSource = null;
                TxtMaestroMezcaleroEnvasadora.Text = "";
                CmbFabricaEnvasadora.DataSource = null;
            }
            else
            {
                CmbFabricaEnvasadora.Enabled = true;
                TxtMaestroMezcaleroEnvasadora.Enabled = true;
                CmbFabricaEnvasadora.DataSource = null;
                TxtMaestroMezcaleroEnvasadora.Text = "";
                CmbFabricaEnvasadora.DataSource = null;
                ConexionMysql.llenaCombo(ref CmbFabricaEnvasadora, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteEnvasado.SelectedValue + "'", "id_fabrica", "fabrica");
                if (Usuario.FabricaSeleccionada != "0")
                {
                    CmbFabricaEnvasadora.SelectedValue = Usuario.FabricaSeleccionada;
                }
            }

        }

        //al presionar radio buton envasadora
        private void RbtnEnvasadora_CheckedChanged(object sender, EventArgs e)
        {
            if (DtaGranelParaEnvasado.ColumnCount > 1)
            {
                dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Clear();
            }
            if (RbtnEnvasadora.Checked == true)
            {
                ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");
            }
        }


        //al selecionar la fabrica
        private void CmbFabricaEnvasadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbLoteGranel.DataSource = null;
            if (CmbFabricaEnvasadora.SelectedValue != null)
            {
                ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + CmbFabricaEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada asc", "id_granel_entrada", "produccion");

                TxtMaestroMezcaleroEnvasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabricaEnvasadora.SelectedValue + "'");
            }
        }



        //crea la tabla de  producto envasado no terminado
        private void addTablaProductoEnvasadoNoTerminado()
        {
            dtsProductoEnvasadoNoTerminado = new DataSet();
            dtsProductoEnvasadoNoTerminado.Tables.Add("PRODUCTOENVASADONOTERMINADO");
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("ID_PRODUCCION_ENVASADO", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("MEDIDA", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoEnvasadoNoTerminado.DataSource = dtsProductoEnvasadoNoTerminado.Tables["PRODUCTOENVASADONOTERMINADO"];
            DtaProductoEnvasadoNoTerminado.Columns[1].Visible = false;
            //DtaProductoEnvasadoNoTerminado.Columns[7].Visible = false;
        }



        //crea la tabla de  producto envasado
        private void addTablaProductoEnvasado()
        {
            dtsProductoEnvasado = new DataSet();
            dtsProductoEnvasado.Tables.Add("PRODUCTOENVASADO");
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("ID_PRODUCCION_ENVASADO", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("MEDIDA", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("%ALC_LOTE_GRA", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("%ALC_ETIQUETA", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            dtsProductoEnvasado.Tables["PRODUCTOENVASADO"].Columns.Add("VERIFICAR", Type.GetType("System.Byte[]"));
            
            DtaProductoEnvasado.DataSource = dtsProductoEnvasado.Tables["PRODUCTOENVASADO"];
            DtaProductoEnvasado.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DtaProductoEnvasado.Columns[1].Visible = false;
            //DtaProductoEnvasado.Columns[8].Visible = false;
            DtaProductoEnvasado.Columns[17].Visible = false;
            DtaProductoEnvasado.Columns[14].HeaderText = "%Alc\netiqueta";
            DtaProductoEnvasado.Columns[13].HeaderText = "%Alc\nloteGranel";
            DtaProductoEnvasado.Columns[3].HeaderText = "No\nlote";

        }


        //crea la tabla de  producto envsado salio
        private void addTablaProductoEnvasadoSalio()
        {
            dtsProductoEnvasadoSalio = new DataSet();
            dtsProductoEnvasadoSalio.Tables.Add("PRODUCTOENVASADOSALIO");
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("ID_ENVASADO_MOVIMIENTOS", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("ID_ENVASADORA", Type.GetType("System.String"));//--- Agregado reciente mente
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("ID_MARCA", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("DESTINO", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("MEDIDA", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoEnvasadoSalio.DataSource = dtsProductoEnvasadoSalio.Tables["PRODUCTOENVASADOSALIO"];
            DtaProductoEnvasadoSalio.Columns[1].Visible = false;
            DtaProductoEnvasadoSalio.Columns[2].Visible = false;
            DtaProductoEnvasadoSalio.Columns[3].Visible = false;
            DtaProductoEnvasadoSalio.Columns[4].Visible = false;
            DtaProductoEnvasadoSalio.Columns[5].Visible = false;
            //DtaProductoEnvasadoSalio.Columns[13].Visible = false;
        }



        // crear tabla de granel  para guardar el envasado
        private void addTablaGranelParaGuardarEnvasado()
        {
            dtsEnvasado = new DataSet();
            dtsEnvasado.Tables.Add("GRANELPARAGUARDARENVASADO");
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("ID_GRANEL_ENTRADA", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("ID_COMUN", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("AGAVE_COCCION_KG", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaGranelParaEnvasado.DataSource = dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"];
            DtaGranelParaEnvasado.Columns[1].Visible = false;
            DtaGranelParaEnvasado.Columns[2].Visible = false;
            DtaGranelParaEnvasado.Columns[3].Visible = false;
            DtaGranelParaEnvasado.Columns[4].Visible = false;
            DtaGranelParaEnvasado.Columns[5].Visible = false;
            DtaGranelParaEnvasado.Columns[6].Visible = false;
            DtaGranelParaEnvasado.Columns[7].Visible = false;
            DtaGranelParaEnvasado.Columns[8].Visible = false;
            DtaGranelParaEnvasado.Columns[9].Visible = false;
            DtaGranelParaEnvasado.Columns[10].Visible = false;
        }


        //cra tabla para guardar los hologramas
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


        //guardar lotes agranel para envasado
        private void BtnAgregarGranelParaEnvasado_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbLoteGranel.SelectedValue == null)
                {
                    MessageBox.Show("No tienes lote agranel para agregar");
                    return;
                }
                if (TxtLitrosParaEnvasado.Text == "")
                {

                    MessageBox.Show("No ha introducido litros");
                    return;
                }

                if (Math.Round(double.Parse(litrosGranelparaenvasado), 2) < Math.Round(double.Parse(TxtLitrosParaEnvasado.Text), 2))
                {
                    MessageBox.Show("Existencia insificiente");
                    return;
                }


                DataRow fila = dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].NewRow();
                fila["NO_LOTE"] = no_lote_granel;
                fila["ID_GRANEL_ENTRADA"] = CmbLoteGranel.SelectedValue;
                fila["LITROS"] = TxtLitrosParaEnvasado.Text;
                fila["%_ALCOHOLICO"] = grado_alcoholico_granel;
                fila["FQ"] = fqenvasado;
                fila["CLASE"] = clasemezcalenvasado;
                fila["CATEGORIA"] = categoriamezcalenvasado;
                fila["ABOCANTE"] = abocanteenvasado;
                fila["INGREDIENTE"] = ingredienteenvasado;
                fila["ID_PLANTA"] = id_plantaenvasado;
                fila["ID_PREDIO"] = id_predioenvasado;
                fila["ID_COMUN"] = id_comun_envasado;
                fila["AGAVE_COCCION_KG"] = agave_coccion_kg_envasado;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].Rows.Add(fila);
                TxtLitrosParaEnvasado.Text = "";
                CmbLoteGranel.DataSource = null;

                string produccion = "";
                string coma = "";
                for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                {
                    produccion += coma + "'" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'";
                    coma = ",";
                }
                if (RbtnFabrica.Checked == true)
                {


                    ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN(" + produccion + ") and  id_fabrica='" + CmbFabricaEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada asc", "id_granel_entrada", "produccion");

                }
                else
                {


                    ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN(" + produccion + ") and  id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

                }


                if (DtaGranelParaEnvasado.Rows.Count > 1)
                {

                    genvasado();

                }




                if (DtaGranelParaEnvasado.Rows.Count == 1)
                {

                    TxtClaveFqEnvasado.Text = DtaGranelParaEnvasado.Rows[0].Cells["FQ"].Value.ToString();
                    TxtNoLoteEnvasado.Text = DtaGranelParaEnvasado.Rows[0].Cells["NO_LOTE"].Value.ToString();





                    if (DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() == "Blanco o Joven" || DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() == "Joven")
                    {

                        lblEtiquetadocomo.Enabled = true;
                        cmbEtiquetadocomo.Enabled = true;
                        cmbEtiquetadocomo.Items.Insert(0, "---Elije una opcion---");
                        cmbEtiquetadocomo.Items.Insert(1, "Blanco");
                        cmbEtiquetadocomo.Items.Insert(2, "Joven");
                        cmbEtiquetadocomo.SelectedIndex = 0;



                    }
                    else
                    {
                        //cmbEtiquetadocomo = clase;
                        //cmbEtiquetadocomo.Items.Add(clase);
                        lblEtiquetadocomo.Enabled = false;
                        cmbEtiquetadocomo.Enabled = false;

                    }



                }
                else
                {
                    TxtClaveFqEnvasado.Text = "";
                    TxtNoLoteEnvasado.Text = "";
                }


                //reporta las bottellas que puedes envasar
                double litros = 0;
                string medida = CmbMedidaBotella.Text;
                for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                {
                    litros += Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                }

                string cadena = calcula_botellas(litros, medida).ToString();
                char delimiter = '.';
                string[] substrings = cadena.Split(delimiter);
                if (substrings.Length == 1)
                {
                    TxtNoBotellas.Text = substrings[0];
                    TxtMerma.Text = "0 %";
                }
                else
                {
                    TxtNoBotellas.Text = substrings[0];
                    if (substrings[1].Length == 1)
                    {
                        TxtMerma.Text = substrings[1] + " %";
                    }
                    else
                    {
                        TxtMerma.Text = substrings[1].Substring(0, 2) + " %";
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //al selecionar un lotre agranel carga los litros existentes no lote y grado alcoholico etc
        private void CmbLoteGranel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbLoteGranel.DataSource == null)
                {
                    litrosGranelparaenvasado = "";
                    no_lote_granel = "";
                    grado_alcoholico_granel = "";
                    fqenvasado = "";
                    clasemezcalenvasado = "";
                    categoriamezcalenvasado = "";
                    abocanteenvasado = "";
                    ingredienteenvasado = "";
                    id_plantaenvasado = "";
                    id_predioenvasado = "";
                    id_comun_envasado = "";
                    agave_coccion_kg_envasado = "";
                }
                else
                {



                    DataSet Datos = new DataSet();
                    if (RbtnFabrica.Checked == true)
                    {
                        ConexionMysql.llenaDataset(ref Datos, "SELECT id_comun,fq,no_lote,lts_existentes,no_lote,grado_alcoholico_existente,clase,categoria,abocante,ingrediente,id_planta,id_predio,agave_coccion_kg FROM granel_entrada  WHERE id_granel_entrada='" + CmbLoteGranel.SelectedValue + "'");




                    }
                    else
                    {
                        ConexionMysql.llenaDataset(ref Datos, "SELECT id_comun,fq,no_lote,lts_existentes,no_lote,grado_alcoholico_existente,clase,categoria,abocante,ingrediente,id_planta,id_predio,agave_coccion_kg FROM granel_entrada_envasado  WHERE id_granel_entrada_envasado='" + CmbLoteGranel.SelectedValue + "'");




                    }
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fqenvasado = Convert.ToString(row["fq"]);
                        litrosGranelparaenvasado = Convert.ToString(row["lts_existentes"]);
                        no_lote_granel = Convert.ToString(row["no_lote"]);
                        grado_alcoholico_granel = Convert.ToString(row["grado_alcoholico_existente"]);
                        clasemezcalenvasado = Convert.ToString(row["clase"]);
                        categoriamezcalenvasado = Convert.ToString(row["categoria"]);
                        abocanteenvasado = Convert.ToString(row["abocante"]);
                        ingredienteenvasado = Convert.ToString(row["ingrediente"]);
                        id_plantaenvasado = Convert.ToString(row["id_planta"]);
                        id_predioenvasado = Convert.ToString(row["id_predio"]);
                        id_comun_envasado = Convert.ToString(row["id_comun"]);
                        agave_coccion_kg_envasado = Convert.ToString(row["agave_coccion_kg"]);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //al dar CLIK EN QUITAR, DE LA TABLA DE PRODUCTO AGRANEL PARA ENVASADO SE QUITARA
        private void DtaGranelParaEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaGranelParaEnvasado.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    TxtNoBotellas.Text = "";
                    TxtMerma.Text = "";
                    DtaGranelParaEnvasado.Rows.RemoveAt(e.RowIndex);
                    dtsEnvasado.Tables["GRANELPARAGUARDARENVASADO"].AcceptChanges();
                    CmbLoteGranel.DataSource = null;

                    if (DtaGranelParaEnvasado.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'";
                            coma = ",";
                        }

                        if (RbtnFabrica.Checked == true)
                        {
                            ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN(" + produccion + ") and  id_fabrica='" + CmbFabricaEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada asc", "id_granel_entrada", "produccion");

                        }
                        else
                        {
                            ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN(" + produccion + ") and  id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

                        }
                    }
                    else
                    {
                        if (RbtnFabrica.Checked == true)
                        {
                            ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where   id_fabrica='" + CmbFabricaEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada asc", "id_granel_entrada", "produccion");
                        }
                        else
                        {
                            ConexionMysql.llenaComboAutocomplit(ref CmbLoteGranel, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where  id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");
                        }


                        cmbEtiquetadocomo.Items.Clear();
                    }
                }
                if (DtaGranelParaEnvasado.Rows.Count == 1)
                {
                    TxtClaveFqEnvasado.Text = DtaGranelParaEnvasado.Rows[0].Cells["FQ"].Value.ToString();
                    TxtNoLoteEnvasado.Text = DtaGranelParaEnvasado.Rows[0].Cells["NO_LOTE"].Value.ToString();
                }
                else
                {
                    TxtClaveFqEnvasado.Text = "";
                    TxtNoLoteEnvasado.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //boton para guadar envasado
        private void BtnGuardarEnvasado_Click(object sender, EventArgs e)
        {
            if (CmbEnvasadoraEnvasadora.SelectedValue == null)
            {
                MessageBox.Show("No ha seleccionado ninguna envasadora");
                return;
            }
            string tipo_destinoF = "";
            if (DtaGranelParaEnvasado.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ninguna producción");
                return;
            }
            if (TxtNoLoteEnvasado.Text == "")
            {
                MessageBox.Show("Debes ingresar un numero de lote");
                TxtNoLoteEnvasado.Focus();
                return;
            }
            if (CmbUnidadDeMedida.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar una unidad de medida");
                return;
            }
            if (CmbMedidaBotella.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar un contenido por botella");
                return;
            }
            if (TxtNoBotellas.Text == "")
            {
                MessageBox.Show("Debes ingresar un numero de botellas");
                TxtNoBotellas.Focus();
                return;
            }
            int ResComparacionFechas = DateTime.Compare(DtaFechaEnvasadoini.Value, DtaFechaEnvasadofin.Value);
            if (ResComparacionFechas > 0)
            {
                MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio del envasado");
                return;
            }
           

            if (ChekNoTerminado.Toggled == true)
            {
                if (CmbMarca.SelectedValue == null)
                {
                    MessageBox.Show("No ha seleccionado ninguna marca");
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

               

                if (DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() == "Blanco o Joven" || DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() == "Joven")
                {

                    if (cmbEtiquetadocomo.Text == "---Elije una opcion---")
                    {
                        MessageBox.Show("Selecciona un tipo de Etiquetado");
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
                    //condicional para saber lo del rango con botellas
                    Boolean ms = validaRangoBotellas();
                    if (ms == true)
                    {
                        MessageBox.Show("Los hologramas ingresados no coinciden con el número de botellas");
                        return;
                    }
                }
            }

            //VERIFICACION DE DATOS PARA QUE SE SEPA DESDE EL MOMENTO DE GUARDAR EL ENVASADO EL DESTINO A DONDE VA
            #region TIPO DE DESTINO VALIDACION Y ASIGNACION DE VARIABLES
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
            #endregion
            //================================================================>>> Confirmacion de datos a ingresar <<<============


            string tipo = label31.Text;
            string f = CmbNoClienteEnvasado.Text;
            string o = CmbEnvasadoraEnvasadora.Text;
            string p = "";
            string pp = "";
            string p3 = "";
            string comad = "";
            //--->>-Mustra la lista de los DatagredView
            for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
            {
                p += comad + "'" + DtaGranelParaEnvasado.Rows[x].Cells["NO_LOTE"].Value + " ' \n";
                pp += comad + "'" + DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value + " '  \n";
                p3 += comad + "'" + DtaGranelParaEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value + " ' \n ";
                comad = "  ";
            }

            string q = "";
            string q1 = "";
            string q2 = "";
            //q = DtaTanquesEnvasado.CurrentRow.Cells[0].Value.ToString();
            string um = "----";
            string cont = "---";
            string a = "----";
            string t = TxtNoLoteEnvasado.Text;
            string c = "----";
            string b = "----";
            string nb = TxtNoBotellas.Text;
            string m = TxtMerma.Text;
            string fei = DtaFechaEnvasadoini.Text;
            string fef = DtaFechaEnvasadofin.Text;


            string tmdo = "";
            if (ChekNoTerminado.Toggled == true)
            {
                tmdo = "\tSi\t";
                um = CmbUnidadDeMedida.Text;
                cont = CmbMedidaBotella.Text;
                a = CmbMarca.Text;
                t = TxtNoLoteEnvasado.Text;
                c = TxtClaveFqEnvasado.Text;
                b = TxtGradoAlcoholicoEtiqueta.Text;

            }
            else
            {
                tmdo = "\tNo\t";
                c = TxtClaveFqEnvasado.Text;
                q = "----";
                q1 = "----";
                q2 = "----";
            }


            if (ChekOstenta.Toggled == true)
            {
                q = TxtHologramaInicio.Text;
                q1 = TxtHologramaFin.Text;
                q2 = "----";
            }
            else
            {
                //--->>-Mustra la lista de los DatagredView
                for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                {
                    q += comad + "'" + DtaHologramas.Rows[x].Cells["INICIO"].Value + " '  \n";
                    q1 += comad + "'" + DtaHologramas.Rows[x].Cells["FIN"].Value + " '  \n";
                    q2 += comad + "'" + DtaHologramas.Rows[x].Cells["SERIE"].Value + " '  \n";

                }

            }



            /* DialogResult r = MsgBxGranelenvasado.Show("Cliente: " + f + "\nEnvasadora: " + o + "\n\n--->-Lote Granel-<---" + "\nNo Lote: " + p + "\nLitros: " + pp + " \n% Alcoholico: "
               + p3 + "\n\n--->-Producto " + "  " + tmdo + "  "+"Terminado-<---" + "\nMarca: " + a + "\nNo lote: " + t + "\nClave FQ: " + c + "\nUnidad de medida: " + um + "    Cont: " + cont+ "\n°Alcohólico etiqueta: " + b  + "\nNo de botellas: " + nb + "    Merma: " + m 
               + "\n\n--->-Fecha envasado-<---" + "\nInicio: " + fei + "   Fin: " + fef + "\n\n--->-Hologramas-<---" + "\nInicio: " + q 
               +"\nFin: " + q1+"\nSerie: " + q2 ,"---", "Aceptar","Cancelar");
          */

            string dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + tmdo + "!" + a + "!" + t + "!" + c + "!" + um + "!" + cont + "!" + b + "!" + nb + "!" + m + "!" + fei + "!" + fef + "!" + q + "!" + q1 + "!" + q2;

            MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
            msg.Envasadook(dto);
            msg.ShowDialog();
            if (msg.DialogResult == DialogResult.Cancel) { return; }
            else
            {


                ObtenerIdMaximoEnvasadoEntrada();
                if (DtaGranelParaEnvasado.Rows.Count == 1)// compara si tiene un solo registro el DtaGranelParaEnvasado 
                {
                    if (int.Parse(DtaGranelParaEnvasado.Rows[0].Cells["ID_PLANTA"].Value.ToString()) == 0)
                    {
                        //--- entra si es un ensamble el lote   que proviene de granel --- 
                        
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada(id_envasado_entrada,id_envasadora,id_marca,no_cliente,tipo_destino,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_comun,no_lote_granel,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,verificador_termina,actualizado) VALUES('" + id_max_envasado_entrada + "', '" + CmbEnvasadoraEnvasadora.SelectedValue + "','" + (CmbMarca.SelectedValue == null ? 0 : CmbMarca.SelectedValue) + "','" + CmbNoClienteEnvasado.SelectedValue + "','" + tipo_destinoF + "',CASE id_marca WHEN '0' THEN '0000-00-00' ELSE now() END" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "'," + DtaGranelParaEnvasado.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",'" + DtaGranelParaEnvasado.Rows[0].Cells["NO_LOTE"].Value.ToString() + "',0,'" + TxtNoLoteEnvasado.Text + "','" + TxtClaveFqEnvasado.Text + "' , '" + DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() + "' , '" + DtaGranelParaEnvasado.Rows[0].Cells["CATEGORIA"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[0].Cells["ABOCANTE"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[0].Cells["INGREDIENTE"].Value.ToString() + "','" + cmbEtiquetadocomo.Text + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + "," + DtaGranelParaEnvasado.Rows[0].Cells["LITROS"].Value.ToString() + ", " + DtaGranelParaEnvasado.Rows[0].Cells["%_ALCOHOLICO"].Value.ToString() + ",'" + (TxtGradoAlcoholicoEtiqueta.Text == "" ? "0" : TxtGradoAlcoholicoEtiqueta.Text) + "'," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",CASE id_marca WHEN '0' THEN '0' ELSE '" + Usuario.IdUsuario + "' END" + ",0)") == "Error")//--- seagrego fecha movimineto y botellas_iniciales
                        {
                            //MessageBox.Show("voendo qu hace aqui 1");
                            return;
                        }
                        DataSet Datos = new DataSet();
                        if (RbtnFabrica.Checked == true)
                        {
                            ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='" + DtaGranelParaEnvasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                        }
                        else
                        {
                            ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + DtaGranelParaEnvasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                        }
                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble,id_envasado_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_envasado_ensamble + "','" + id_max_envasado_entrada + "' ,'" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaGranelParaEnvasado.Rows[0].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }//-- fin  if  int.Parse(DtaGranelParaEnvasado.Rows[0].Cells["ID_PLANTA"].Value.ToString()) == 0
                    else
                    {

                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada (id_envasado_entrada,id_envasadora,id_marca,no_cliente,tipo_destino,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_comun,no_lote_granel,id_solicitud,no_lote,id_planta,id_predio,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,verificador_termina,actualizado,holograma_inicio,holograma_fin) VALUES('" + id_max_envasado_entrada + "','" + CmbEnvasadoraEnvasadora.SelectedValue + "', '" + (CmbMarca.SelectedValue == null ? 0 : CmbMarca.SelectedValue) + "','" + CmbNoClienteEnvasado.SelectedValue + "','" + tipo_destinoF + "',CASE id_marca WHEN '0' THEN '0000-00-00' ELSE now() END" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "'," + DtaGranelParaEnvasado.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",'" + DtaGranelParaEnvasado.Rows[0].Cells["NO_LOTE"].Value.ToString() + "',0,'" + TxtNoLoteEnvasado.Text + "' ," + DtaGranelParaEnvasado.Rows[0].Cells["ID_PLANTA"].Value.ToString() + ",'" + DtaGranelParaEnvasado.Rows[0].Cells["ID_PREDIO"].Value.ToString() + "','" + TxtClaveFqEnvasado.Text + "' , '" + DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() + "' , '" + DtaGranelParaEnvasado.Rows[0].Cells["CATEGORIA"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[0].Cells["ABOCANTE"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[0].Cells["INGREDIENTE"].Value.ToString() + "','" + cmbEtiquetadocomo.Text + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + "," + DtaGranelParaEnvasado.Rows[0].Cells["LITROS"].Value.ToString() + ", " + DtaGranelParaEnvasado.Rows[0].Cells["%_ALCOHOLICO"].Value.ToString() + "," + (TxtGradoAlcoholicoEtiqueta.Text == "" ? "0" : TxtGradoAlcoholicoEtiqueta.Text) + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",CASE id_marca WHEN '0' THEN '0' ELSE '" + Usuario.IdUsuario + "' END" + ",0,'" + TxtHologramaInicio.Text + "','" + TxtHologramaFin.Text + "')") == "Error")//--- seagrego fecha movimineto y botellas_iniciales
                        {
                            //MessageBox.Show("voendo qu hace aqui 2");
                            return;
                        }
                    }///-- fin del else


                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaGranelParaEnvasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_envasado_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }




                }///--- fin del if de DtaGranelParaEnvasado.Rows.Count == 1
                else
                {
                    ///==== ENTRA SI ES UN ENSAMBLE MAS DE UNLOTE

                    string CategoriaMezcal = "";
                    string CategoriaMezcalComparar = "";
                    string claseMezcal = "";
                    string claseMezcalComparar = "";
                    double litros = 0;
                    double grado_alcoholico = 0;
                    double grado_alcoholico_para_suma = 0;
                    string Abocante = "";
                    string Ingrediente = "";
                    string coma = "";

                    for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                    {
                        if (x > 0)
                        {
                            CategoriaMezcalComparar = CategoriaMezcal;
                            claseMezcalComparar = claseMezcal;
                        }
                        claseMezcal = DtaGranelParaEnvasado.Rows[x].Cells["CLASE"].Value.ToString();
                        CategoriaMezcal = DtaGranelParaEnvasado.Rows[x].Cells["CATEGORIA"].Value.ToString();
                        Abocante += coma + DtaGranelParaEnvasado.Rows[x].Cells["ABOCANTE"].Value.ToString();
                        Ingrediente += coma + DtaGranelParaEnvasado.Rows[x].Cells["INGREDIENTE"].Value.ToString();
                        coma = "-";

                        //saca la categoria del mezcal
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

                        // saca la clase del mezcal
                        if (claseMezcal == "Reposado")
                        {
                            if (claseMezcalComparar == "Joven")
                            {
                                claseMezcal = claseMezcalComparar;
                            }
                        }
                        else if (claseMezcal == "Añejo")
                        {
                            if (claseMezcalComparar == "Joven")
                            {
                                claseMezcal = claseMezcalComparar;
                            }
                            else if (claseMezcalComparar == "Reposado")
                            {
                                claseMezcal = claseMezcalComparar;
                            }
                        }


                        litros += Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                        grado_alcoholico_para_suma += Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2) * Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value.ToString()), 2);
                    }

                    grado_alcoholico = grado_alcoholico_para_suma / litros;

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada(id_envasado_entrada,id_envasadora,id_marca,no_cliente,tipo_destino,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_solicitud,no_lote,id_planta,id_predio,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas,botellas_iniciales,botellas_existentes,id_verificador,verificador_termina,actualizado) VALUES( '" + id_max_envasado_entrada + "','" + CmbEnvasadoraEnvasadora.SelectedValue + "','" + CmbMarca.SelectedValue + "','" + CmbNoClienteEnvasado.SelectedValue + "','" + tipo_destinoF + "',CASE id_marca WHEN '0' THEN '0000-00-00' WHEN '' THEN '0000-00-00' ELSE now() END" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLoteEnvasado.Text + "',0,0,'" + TxtClaveFqEnvasado.Text + "' , '" + claseMezcal + "' , '" + CategoriaMezcal + "','" + Abocante + "','" + Ingrediente + "','" + cmbEtiquetadocomo.Text + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + "," + litros + ", " + Math.Round(grado_alcoholico, 2) + "," + (TxtGradoAlcoholicoEtiqueta.Text == "" ? "0" : TxtGradoAlcoholicoEtiqueta.Text) + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",CASE id_marca WHEN '0' THEN '0' ELSE '" + Usuario.IdUsuario + "' END" + ",0)") == "Error") //-- Se agrego fecha_movimiento y botellas iniciales
                    {
                        //MessageBox.Show("voendo qu hace aqui 3");
                        return;
                    }


                    for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                    {
                        if (int.Parse(DtaGranelParaEnvasado.Rows[x].Cells["ID_PLANTA"].Value.ToString()) == 0 && int.Parse(DtaGranelParaEnvasado.Rows[x].Cells["ID_COMUN"].Value.ToString()) == 0)
                        {
                            DataSet Datos = new DataSet();
                            if (RbtnFabrica.Checked == true)
                            {
                                ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            }
                            else
                            {
                                ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            }

                            foreach (DataRow row in Datos.Tables[0].Rows)
                            {
                                ObtenerIdMaximoEnvasadoEnsamble();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble,id_envasado_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES('" + id_max_envasado_ensamble + "', '" + id_max_envasado_entrada + "','" + row["id_comun"].ToString() + "' ,'" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble,id_envasado_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_envasado_ensamble + "','" + id_max_envasado_entrada + "' ,'" + DtaGranelParaEnvasado.Rows[x].Cells["ID_COMUN"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString() + "','" + DtaGranelParaEnvasado.Rows[x].Cells["AGAVE_COCCION_KG"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }

                    for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                    {
                        DataSet ids = new DataSet();
                        ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_envasado'");

                        foreach (DataRow row in ids.Tables[0].Rows)
                        {
                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_envasado_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }
                    }


                }///-- FIN DEL ELSE DE ENSAMBL DE VARIOS LOTES 

                // marca la salida del producto y actualiza existencia de granel



                for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                {
                    //Voy a deshabilitar esta parte para que no evalue un componente que no existe, además no es necesario que haga esta parte que alenta.
                    /*
                    if (RbtnFabrica.Checked == true)
                    {   ///--- SI EL LOTE PROCEDE DE FABRICA
                        ObtenerIdMaximoGranelSalida();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_salida(id_granel_salida,id_granel_entrada,id_solicitud,id_envasado_entrada,litros,grado_alcoholico,id_verificador) VALUES('" + id_max_granel_salida + "', '" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "',0,'" + id_max_envasado_entrada + "','" + DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value + "','" + DtaGranelParaEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                        string litros_granel = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                        double existencia = Math.Round(double.Parse(litros_granel), 2) - Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada SET lts_existentes=" + existencia + ",actualizado=0 WHERE id_granel_entrada='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {*/
                        //---- SI EL LOTE PROCEDE DEGRANEL ENVASADO

                        ObtenerIdMaximoGranelSalida();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_salida(id_granel_salida,id_granel_entrada_envasado,id_solicitud,id_envasado_entrada,litros,grado_alcoholico,id_verificador) VALUES( '" + id_max_granel_salida + "','" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "',0,'" + id_max_envasado_entrada + "','" + DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value + "','" + DtaGranelParaEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                        string litros_granel = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                        double existencia = Math.Round(double.Parse(litros_granel), 2) - Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);

                        ///---- actualiza los litros existentes en granel de envasado --
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=ROUND(" + existencia + ",2),actualizado=0 WHERE id_granel_entrada_envasado='" + DtaGranelParaEnvasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'") == "Error")
                        {
                            return;
                        }
                    //}

                }

                // introduce hologramas a el envasado

                if (ChekOstenta.Toggled == true)
                {
                    ObtenerIdMaximoEntradaHologramas();
                    string no_cliente = CmbMarca.SelectedValue.ToString();
                    no_cliente = no_cliente.Substring(0, 5);
                    string clienteCrm1 = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes where no_cliente = '" + no_cliente + "'");
                    string cve_marca = CmbMarca.SelectedValue.ToString();
                    int lenght = cve_marca.Length;
                    int mark = lenght == 7 ? 1 : 2;
                    cve_marca = cve_marca.Substring(6, mark);
                    //cve_marca = cve_marca.Substring(6, 2);
                   // MessageBox.Show(cve_marca);
                    if (chkHologramasAnteriores.Checked == true)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado,cliente_crm) VALUES( '" + id_max_hologramas + "','" + id_max_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + TxtHologramaInicio.Text + "' , '" + TxtHologramaFin.Text + "','" + TxtSerie.Text + "'," + Usuario.IdUsuario + ",0,'" + clienteCrm1 + "')") == "Error")
                        {
                            return;
                        }
                    }
                    else { 
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_hologramas + "','" + id_max_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + TxtHologramaInicio.Text + "' , '" + TxtHologramaFin.Text + "','" + TxtSerie.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                    {
                        return;
                    }
                    }
                }
                else
                {
                    if (chkHologramasAnteriores.Checked == true)
                    {
                        for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                        {
                            ObtenerIdMaximoEntradaHologramas();

                            string no_cliente = CmbMarca.SelectedValue.ToString();
                            no_cliente = no_cliente.Substring(0, 5);
                            string clienteCrm2 = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes where no_cliente = '" + no_cliente + "'");
                            //MessageBox.Show(no_cliente);
                            string cve_marca = CmbMarca.SelectedValue.ToString();
                            int lenght = cve_marca.Length;
                            int mark = lenght == 7 ? 1 : 2;
                            cve_marca = cve_marca.Substring(6, mark);
                            MessageBox.Show(cve_marca);
                            // 

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado, cliente_crm) VALUES( '" + id_max_hologramas + "','" + id_max_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + DtaHologramas.Rows[x].Cells["INICIO"].Value + "' , '" + DtaHologramas.Rows[x].Cells["FIN"].Value + "','" + DtaHologramas.Rows[x].Cells["SERIE"].Value + "'," + Usuario.IdUsuario + ",0,'" + clienteCrm2 + "')") == "Error")
                            {
                                return;
                            }
                        }

                    }
                    else 
                    { 
                        for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                    {
                        ObtenerIdMaximoEntradaHologramas();

                        string no_cliente = CmbMarca.SelectedValue.ToString();
                        no_cliente = no_cliente.Substring(0, 5);
                        //string clienteCrm2 = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes where no_cliente = '" + no_cliente + "'");
                        //MessageBox.Show(no_cliente);
                        string cve_marca = CmbMarca.SelectedValue.ToString();
                            int lenght = cve_marca.Length;
                            int mark = lenght == 7 ? 1 : 2;
                            cve_marca = cve_marca.Substring(6, mark);
                        //MessageBox.Show(cve_marca);

                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_hologramas + "','" + id_max_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + DtaHologramas.Rows[x].Cells["INICIO"].Value + "' , '" + DtaHologramas.Rows[x].Cells["FIN"].Value + "','" + DtaHologramas.Rows[x].Cells["SERIE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }
                    }
                }



                ConexionMysql.transCompleta();
                limpia_envasado();
                MessageBox.Show("Éxito");
                ChekNoTerminado.Toggled = true;
                CmbNoClienteEnvasado_SelectedIndexChanged(null, null);

            }

        }//-->>Fin de este boton


        //al seleccionar unidad de medida carga las presentaciones de  esa unidad
        private void CmbUnidadDeMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbMedidaBotella.DataSource = null;
            ConexionMysql.llenaCombo(ref CmbMedidaBotella, "SELECT cantidad FROM cat_presentacion  where medida ='" + CmbUnidadDeMedida.SelectedValue + "' order by cantidad desc ", "cantidad", "cantidad");
            //reporta las bottelas que puedes envasar
        }

        //para maracar si ostento o no ostenta
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

        //al presionar activa para cambiar el numero de lote de envasado

        private void ChekNoLoteEnvasado_ToggledChanged()
        {
            if (ChekNoLoteEnvasado.Toggled == true)
            {
                TxtNoLoteEnvasado.ReadOnly = false;
            }
            else
            {
                TxtNoLoteEnvasado.ReadOnly = true;
            }

        }

        // limpia campos del envasado
        public void limpia_envasado()
        {
            dtsEnvasado.Clear();
            dtsHologramas.Clear();
            TxtNoLoteEnvasado.Text = "";
            TxtClaveFqEnvasado.Text = "";
            TxtGradoAlcoholicoEtiqueta.Text = "";
            TxtNoBotellas.Text = "";
            TxtMerma.Text = "";
        }


        //al dar click a movimientos de la tabla envasado
        private void DtaProductoEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoEnvasado.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimienEnvasado frm = new FrmMovimienEnvasado();

                    frm.id_envasado_entrada = DtaProductoEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_ENVASADO"].Value.ToString();
                    frm.marca = DtaProductoEnvasado.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();
                    frm.no_lote = DtaProductoEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.clase = DtaProductoEnvasado.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.categoria = DtaProductoEnvasado.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoEnvasado.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoEnvasado.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoEnvasado.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.unidad_medida = DtaProductoEnvasado.Rows[e.RowIndex].Cells["MEDIDA"].Value.ToString();
                    frm.contenido_botella = DtaProductoEnvasado.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.botellas = DtaProductoEnvasado.Rows[e.RowIndex].Cells["BOTELLAS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoEnvasado.Rows[e.RowIndex].Cells["%ALC_LOTE_GRA"].Value.ToString();
                    frm.no_cliente = CmbNoClienteEnvasado.SelectedValue.ToString();
                    frm.tipo_instalacion = "envasado";
                    frm.ShowDialog();
                    CmbNoClienteEnvasado_SelectedIndexChanged(sender, e);
                }

                // TODO: FUNCIÓN QUE SE EJECUTA AL DAR CLICK EN EL BOTÓN PARA VERIFICAR LOS LOTES SIN MOVIMIENTO 2020
                else if (DtaProductoEnvasado.Columns[e.ColumnIndex].Name == "VERIFICAR")
                {
                    String id_lote_envasado = DtaProductoEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_ENVASADO"].Value.ToString();
                    String nombreLote = DtaProductoEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    String marcaEnvasado = DtaProductoEnvasado.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();
                    String id_marca = ConexionMysql.regresaCampoConsulta("Select id_marca from envasado_entrada where " +
                        "id_envasado_entrada = '" + id_lote_envasado + "' ");
                    int id_pkEN = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("Select id from envasado_entrada where " +
                        "id_envasado_entrada = '" + id_lote_envasado + "' "));

                    ObtenerIdMaximoLotesSinMovimientoENV();
                    int result = Convert.ToInt32(ConexionMysql.regresaCampoConsulta("SELECT COUNT(*) FROM modificaciones_inventario_EN where " +
                        "id_tabla = '" + id_lote_envasado + "' and n_tabla like 'envasado_entrada' and date(fecha_ultima_modificacion) = date(now())"));

                    if (result <= 0)
                    {
                        DialogResult check = MessageBox.Show("¿Has verificado que el lote no ha tenido movimientos?", "¡Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (check == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (check == DialogResult.OK)
                        {

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  checked_lotes_en(id_checked_loteEN,id_pkEN,id_envasado_entrada,no_cliente,marca,id_marca,id_envasadora,no_lote," +
                                "fecha_ultima_verificacion,checked,verificador_id,actualizado) VALUES ('" + id_max_loteSinMovENV + "','" + id_pkEN + "', " +
                                "'" + id_lote_envasado + "', '" + CmbNoCliente.SelectedValue + "','" + marcaEnvasado + "','" + id_marca + "','" + CmbEnvasadoraEnvasadora.SelectedValue + "', '" + nombreLote + "', NOW(), '1', " +
                                "" + Usuario.IdUsuario + ", '0')") == "Error")
                            {
                                return;
                            }

                            ConexionMysql.transCompleta();
                            MessageBox.Show("Lote verificado con éxito");
                        }
                    }
                    else if (result >= 1)
                    {
                        MessageBox.Show("Este lote ha tenido movimientos el día de hoy");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //valida campos
        private void TxtLitrosParaEnvasado_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosParaEnvasado.Text);
        }
        private void TxtGradoAlcoholicoEtiqueta_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoAlcoholicoEtiqueta.Text);
        }
        //valida campos
        private void TxtNoBotellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
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

        //al presionar movimientos en la tabla envasado salio
        private void DtaProductoEnvasadoSalio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoEnvasadoSalio.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientoEnvasadoSalio frm = new FrmMovimientoEnvasadoSalio();
                    frm.id_envasado_movimientos = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["ID_ENVASADO_MOVIMIENTOS"].Value.ToString();
                    frm.id_marca = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["ID_MARCA"].Value.ToString();
                    frm.id_envasadora = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["ID_ENVASADORA"].Value.ToString();
                    frm.id_planta = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["ID_PLANTA"].Value.ToString();
                    frm.id_predio = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["ID_PREDIO"].Value.ToString();
                    frm.marca = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();
                    frm.no_lote = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.clase = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.categoria = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.unidad_medida = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["MEDIDA"].Value.ToString();
                    frm.contenido_botella = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.botellas = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["BOTELLAS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.destino = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["DESTINO"].Value.ToString();
                    frm.litros = DtaProductoEnvasadoSalio.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.no_cliente = CmbNoClienteEnvasado.SelectedValue.ToString();
                    frm.tipo_instalacion = "envasado";
                    frm.ShowDialog();
                    CmbNoClienteEnvasado_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public double calcula_botellas(double litros, string medida)
        {
            try
            {

                double conversion = 0;
                double botellas = 0;

                if (CmbUnidadDeMedida.Text == "Mililitros")
                {
                    conversion = Math.Round(double.Parse(medida), 2) / 1000;
                    botellas = litros / conversion;

                }
                else if (CmbUnidadDeMedida.Text == "Litros")
                {
                    conversion = Math.Round(double.Parse(medida), 2);
                    botellas = litros / conversion;

                }
                else if (CmbUnidadDeMedida.Text == "Centilitro")
                {
                    conversion = Math.Round(double.Parse(medida), 2) / 100;
                    botellas = litros / conversion;
                }

                return botellas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        //al seleccionar medida de botellas para envasado
        private void CmbMedidaBotella_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reporta las bottelas que puedes envasar
            //MessageBox.Show("La cantidad seleccionada es: " + Convert.ToString(CmbMedidaBotella.SelectedValue) + Convert.ToString(CmbUnidadDeMedida.Text) , "Corrobora tu elección");
            if (DtaGranelParaEnvasado.Rows.Count > 0)
            {
                if (CmbMedidaBotella.Text != "")
                {
                    double litros = 0;
                    string medida = CmbMedidaBotella.Text;
                    
                    for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                    {
                        litros += Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                    }
                    string cadena = calcula_botellas(litros, medida).ToString();
                    char delimiter = '.';
                    string[] substrings = cadena.Split(delimiter);
                    if (substrings.Length == 1)
                    {
                        TxtNoBotellas.Text = substrings[0];
                        TxtMerma.Text = "0 %";
                    }
                    else
                    {
                        TxtNoBotellas.Text = substrings[0];
                        if (substrings[1].Length == 1)
                        {
                            TxtMerma.Text = substrings[1] + " %";
                        }
                        else
                        {
                            TxtMerma.Text = substrings[1].Substring(0, 2) + " %";
                        }
                    }
                }

            }
        }



        //clik a la maquilacion
        private void ChekMaquila_CheckedChanged(object sender, EventArgs e)
        {
            no_cliente_maquila = "";

            if (ChekMaquila.Checked == true)
            {
                FrmClienteMaquila frm = new FrmClienteMaquila();
                frm.ShowDialog();
                no_cliente_maquila = frm.no_cliente;
                if (no_cliente_maquila == "")
                {
                    ChekMaquila.Checked = false;
                    LblCliente.Visible = false;
                    LblMaquilaCliente.Visible = false;
                    return;
                }
                ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca FROM marcas  where no_cliente ='" + no_cliente_maquila + "'ORDER BY cve_marca ASC", "id", "marca");
                LblCliente.Visible = true;
                LblMaquilaCliente.Visible = true;
                LblMaquilaCliente.Text = no_cliente_maquila;
            }
            else
            {
                ChekMaquila.Checked = false;
                ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca  FROM marcas  where no_cliente ='" + CmbNoClienteEnvasado.SelectedValue + "' ORDER BY cve_marca ASC", "id", "marca");
                LblCliente.Visible = false;
                LblMaquilaCliente.Visible = false;
            }
        }


        //al dar doble clik en la tabla envasado salio
        private void DtaProductoEnvasadoNoTerminado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoEnvasadoNoTerminado.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimienEnvasadoNoTerminado frm = new FrmMovimienEnvasadoNoTerminado();

                    frm.id_envasado_entrada = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["ID_PRODUCCION_ENVASADO"].Value.ToString();
                    frm.botellas_existentes = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["BOTELLAS"].Value.ToString();
                    frm.no_lote = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.litros_existentes = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.unidad_medida = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["MEDIDA"].Value.ToString();
                    frm.presentacion = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.clase = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.fq = DtaProductoEnvasadoNoTerminado.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.no_cliente = CmbNoClienteEnvasado.SelectedValue.ToString();
                    frm.tipo_instalacion = "envasado";
                    frm.ShowDialog();
                    CmbNoClienteEnvasado_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        //se calcula el total de hologramas para poder comparar con la cantidad de botellas ingresadas
        public void ObtenerTotalHologramas()
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
                    //lblShowRangoH.Text = "Sin rango de hologramas";
                }
                else
                {
                    //lblShowRangoH.Text = suma_botellas.ToString() + " hologramas para";
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
                //Validación de hologramas versus botellas
                /*int hologramaInicial = int.Parse(TxtHologramaInicio.Text);
                int hologramaFinal = int.Parse(TxtHologramaFin.Text);
                int totalHologramas = ObtenerTotalHologramas(hologramaInicial, hologramaFinal);
                int totalBotellas = Convert.ToInt32(TxtNoBotellas.Text);
                if (totalBotellas != totalHologramas)
                {
                    MessageBox.Show("El rango de hologramas no coincide con el número de botellas ingresadas");
                    TxtHologramaInicio.Focus();
                    return;
                }*/

                // fin

                int holograma_inicio;
                int holograma_fin;
                int holograma_fin_amma;
                string no_cliente = CmbMarca.SelectedValue.ToString();
                no_cliente = no_cliente.Substring(0, 5);
               
                string cve_marca = CmbMarca.SelectedValue.ToString();
                int lenght = cve_marca.Length;
                int mark = lenght == 7 ? 1 : 2;
                cve_marca = cve_marca.Substring(6, mark);
                // cve_marca = cve_marca.Substring(6, 1);
               // MessageBox.Show(cve_marca);
                string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes where no_cliente = '" + no_cliente + "'");
               

                #region
                /*
                DataSet Datos2 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos2, " select   MAX(ff1) AS ff1 from hologramas_salida where no_cliente='" + no_cliente + "' and marca='" + cve_marca + "' and serie='" + TxtSerie.Text + "' ");
                // MessageBox.Show();
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
                */
                #endregion

                DataSet Datos = new DataSet();
                DataSet Datos1 = new DataSet();
                DataSet Datos3 = new DataSet();
                DataSet Datos2 = new DataSet();
                DataSet Datos4 = new DataSet();
                DataSet Datos5 = new DataSet();
                DataSet Datos6 = new DataSet();
                //ConexionMysql.llenaDataset(ref Datos, "select holograma_inicio,holograma_fin from envasado_holograma where no_cliente='" + no_cliente + "' and cve_marca='" + cve_marca + "' and serie='" + TxtSerie.Text.ToUpper() + "'");
                //-------------------------------------------------------------------------HOLOGRAMAS VIEJOS--------------------------------------------
                if (chkHologramasAnteriores.Checked == true)
                {
                
                    //string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes where no_cliente = '" + no_cliente + "'");
                    ConexionMysql.llenaDataset(ref Datos, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from reveca2.envasado_holograma eh inner join reveca2.envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join reveca2.marcas em on  SUBSTRING(ee.id_marca,1,4) = em.no_cliente and  eh.cve_marca=em.cve_marca where eh.no_cliente='" + clienteCrm + "' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "'");
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

                    // POR SI NO ENCUENTRA DE PASO VA A BUSCAR A SINCA2 PERO JALANDO SOLO DONDE HAYA CLIENTE CRM
                    ConexionMysql.llenaDataset(ref Datos1, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,5) = em.no_cliente and  eh.cve_marca=em.cve_marca where eh.no_cliente='" + no_cliente + "' AND eh.cliente_crm='" + clienteCrm + "'and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "'");
                    foreach (DataRow row in Datos1.Tables[0].Rows)
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

                    // BUSQUEDA EN ALMACEN DE ENVASADO
                    //DataSet Datos3 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos3, "select aeh.holograma_inicio,aeh.holograma_fin, aee.no_lote, em.marca,aee.contenido_por_botella,aee.unidad_medida from reveca2.almacen_envasado_holograma aeh inner join reveca2.almacen_envasado_entrada aee on aeh.id_almacen_envasado_entrada = aee.id_almacen_envasado_entrada inner join reveca2.marcas em on  SUBSTRING(aee.id_marca,1,4) = em.no_cliente and  SUBSTRING(aee.id_marca,6,1)=em.cve_marca  where aeh.no_cliente='" + clienteCrm + "' and aeh.cve_marca='" + cve_marca + "' and aeh.serie='" + TxtSerie.Text.ToUpper() + "'");
                    foreach (DataRow row in Datos3.Tables[0].Rows)
                    {

                        holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                        holograma_fin = Convert.ToInt32(row["holograma_fin"]);
                        string lote = "Tipo de instalacion :  Almacen de Envasado" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

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

                    //AHORA EN ALMACEN PERO DE SINCA2 PERO JALANDO SOLO DONDE HAYA CLIENTE CRM
                    ConexionMysql.llenaDataset(ref Datos4, "select aeh.holograma_inicio,aeh.holograma_fin, aee.no_lote, em.marca,aee.contenido_por_botella,aee.unidad_medida from almacen_envasado_holograma aeh inner join almacen_envasado_entrada aee on aeh.id_almacen_envasado_entrada = aee.id_almacen_envasado_entrada inner join marcas em on  SUBSTRING(aee.id_marca,1,5) = em.no_cliente and  SUBSTRING(aee.id_marca,7,1)=em.cve_marca where aeh.no_cliente='" + no_cliente + "' and aeh.cliente_crm='" + clienteCrm + "' and aeh.cve_marca='" + cve_marca + "' and aeh.serie='" + TxtSerie.Text.ToUpper() + "'");
                    foreach (DataRow row in Datos4.Tables[0].Rows)
                    {

                        holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                        holograma_fin = Convert.ToInt32(row["holograma_fin"]);
                        string lote = "Tipo de instalacion :  Almacen de Envasado" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

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


                    //VER SI SE ENTRAGRON O NO HOLOGRAMAS OCN EL RANGO INGRESADO TANTO EN HOLOGRAMAS_SALIDA_REVECA2 Y DE SINCA
                    //DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, " select   MAX(ff1) AS ff1 from reveca2.hologramas_salida where no_cliente='" + clienteCrm + "' and marca='" + cve_marca + "' and serie='" + TxtSerie.Text + "' ");
                    if (Datos2.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {

                            if (DBNull.Value.Equals(row["ff1"]))//Aqui es si no hay ese rango de esa marca en hologramas_salida reveca2 y entra a revisar en hologramas_salida sinca2
                            {
                                MessageBox.Show(row["ff1"].ToString());
                                ConexionMysql.llenaDataset(ref Datos5, " select   MAX(ff1) AS ff1a from hologramas_salida where no_cliente='" + no_cliente + "' and cliente_crm='" + clienteCrm + "' and marca='" + cve_marca + "' and serie='" + TxtSerie.Text + "' ");
                                if (Datos5.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow row2 in Datos5.Tables[0].Rows)
                                    {
                                        
                                        if (DBNull.Value.Equals(row2["ff1a"]))
                                        {
                                            MessageBox.Show("No se ha encontrado registro alguno de hologramas para la marca : " + Environment.NewLine + CmbMarca.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }
                                        
                                        holograma_fin_amma = Convert.ToInt32(row2["ff1a"]);
                                        //MessageBox.Show(holograma_fin_amma.ToString());
                                        if (int.Parse(TxtHologramaFin.Text) > holograma_fin_amma)
                                        {
                                            MessageBox.Show("No puedes introducir este rango ya que el rango final entregado al asociado es " + Environment.NewLine + "Entregado: " + holograma_fin_amma.ToString() + Environment.NewLine + "Introducido: " + TxtHologramaFin.Text);
                                            return;
                                        }


                                    }
                                    
                                }
                                
                                /*MessageBox.Show("No se ah encontrado registro alguno de hologramas para la marca : " + Environment.NewLine + CmbMarca.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;*/
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
                       // ConexionMysql.llenaDataset(ref Datos2, " select   MAX(ff1) AS ff1 from hologramas_salida where no_cliente='" + no_cliente + "' and cliente_crm='" + clienteCrm + "' and marca='" + cve_marca + "' and serie='" + TxtSerie.Text + "' ");
                                                
                        MessageBox.Show("No se tiene registro de hologramas entregados");
                        return;

                    }

                }//FIN DE HOLOGRAMAS VIEJOS



                // -------------------------------------------------------------------------HOLOGRAMAS NUEVOS AMMA -----------------------------------------
                else
                {
                     //MessageBox.Show(Convert.ToString("select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,5) = em.no_cliente and eh.cve_marca=em.cve_marca  where eh.no_cliente='" + no_cliente + "' AND eh.cliente_crm='' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "' and eh.holograma_inicio not like 'Si ostenta' "));
                    ConexionMysql.llenaDataset(ref Datos, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,5) = em.no_cliente and eh.cve_marca=em.cve_marca  where eh.no_cliente='" + no_cliente + "' AND eh.cliente_crm='' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "' and eh.holograma_inicio not like 'Si ostenta' ");
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);

                        //MessageBox.Show("xd");

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
                
                //DataSet Datos3 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos3, "select aeh.holograma_inicio,aeh.holograma_fin, aee.no_lote, em.marca,aee.contenido_por_botella,aee.unidad_medida from almacen_envasado_holograma aeh inner join almacen_envasado_entrada aee on aeh.id_almacen_envasado_entrada = aee.id_almacen_envasado_entrada inner join marcas em on  SUBSTRING(aee.id_marca,1,5) = em.no_cliente and  SUBSTRING(aee.id_marca,7,1)=em.cve_marca  where aeh.no_cliente='" + no_cliente + "' and aeh.cliente_crm='' and aeh.cve_marca='" + cve_marca + "' and aeh.serie='" + TxtSerie.Text.ToUpper() + "'");

                foreach (DataRow row in Datos3.Tables[0].Rows)
                {



                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);



                    string lote = "Tipo de instalacion :  Almacen de Envasado" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

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
                                
                //DataSet Datos2 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos2, " select   MAX(ff1) AS ff1 from hologramas_salida where no_cliente='" + no_cliente + "' and cliente_crm = '' and marca='" + cve_marca + "' and serie='" + TxtSerie.Text + "' ");
                if (Datos2.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {

                        if (DBNull.Value.Equals(row["ff1"]))
                        {
                            MessageBox.Show("No se ha encontrado registro alguno de hologramas para la marca : " + Environment.NewLine + CmbMarca.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }// FIN DE HOLOGRAMAS NUEVOS AMMA


                DataRow fila = dtsHologramas.Tables["HOLOGRAMAS"].NewRow();
                fila["INICIO"] = TxtHologramaInicio.Text;
                fila["FIN"] = TxtHologramaFin.Text;
                fila["SERIE"] = TxtSerie.Text.ToUpper();
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsHologramas.Tables["HOLOGRAMAS"].Rows.Add(fila);
                TxtHologramaInicio.Text = "";
                TxtHologramaFin.Text = "";
                //ObtenerTotalHologramas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void ChekNoTerminado_ToggledChanged()
        {
            if (ChekNoTerminado.Toggled == true)
            {


                txtbxobservacions.Enabled = true;
                CmbMarca.Enabled = true;
                ChekMaquila.Enabled = true;
                TxtClaveFqEnvasado.Enabled = true;
                TxtHologramaInicio.Enabled = true;
                TxtHologramaFin.Enabled = true;
                TxtSerie.Enabled = true;
                BtnAgragarHolograma.Enabled = true;
                ChekMaquila.Checked = false;
                ChekOstenta.Enabled = true;
                TxtGradoAlcoholicoEtiqueta.Enabled = true;
                ChekOstenta.Toggled = false;
                ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,marca FROM marcas  where no_cliente ='" + CmbNoClienteEnvasado.SelectedValue + "'", "id", "marca");




                if (DtaGranelParaEnvasado.Rows.Count != 0)
                {


                    if (DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() == "Blanco o Joven" || DtaGranelParaEnvasado.Rows[0].Cells["CLASE"].Value.ToString() == "Joven")
                    {

                        lblEtiquetadocomo.Enabled = true;
                        cmbEtiquetadocomo.Enabled = true;
                        cmbEtiquetadocomo.Items.Insert(0, "---Elije una opcion---");
                        cmbEtiquetadocomo.Items.Insert(1, "Blanco");
                        cmbEtiquetadocomo.Items.Insert(2, "Joven");
                        cmbEtiquetadocomo.SelectedIndex = 0;



                    }
                    else
                    {
                        //cmbEtiquetadocomo = clase;
                        //cmbEtiquetadocomo.Items.Add(clase);
                        lblEtiquetadocomo.Enabled = false;
                        cmbEtiquetadocomo.Enabled = false;
                        cmbEtiquetadocomo.Items.Clear();



                    }

                } //-- if (DtaGranelParaEnvasado.Rows.Count > 1)

                else
                {
                    lblEtiquetadocomo.Enabled = false;
                    cmbEtiquetadocomo.Enabled = false;
                    cmbEtiquetadocomo.Items.Clear();
                }



            }
            else
            {
                txtbxobservacions.Enabled = false;

                ChekMaquila.Checked = false;
                ChekMaquila.Enabled = false;
                CmbMarca.DataSource = null;
                CmbMarca.Enabled = false;
                //TxtClaveFqEnvasado.Text = "";
                TxtClaveFqEnvasado.Enabled = true;
                TxtHologramaInicio.Text = "";
                TxtHologramaInicio.Enabled = false;
                TxtHologramaFin.Text = "";
                TxtHologramaFin.Enabled = false;
                TxtSerie.Text = "";
                TxtSerie.Enabled = false;
                ChekOstenta.Enabled = false;
                ChekOstenta.Toggled = false;
                BtnAgragarHolograma.Enabled = false;
                dtsHologramas.Clear();
                TxtGradoAlcoholicoEtiqueta.Text = "";
                TxtGradoAlcoholicoEtiqueta.Enabled = false;
                lblEtiquetadocomo.Enabled = false;
                cmbEtiquetadocomo.Enabled = false;
                cmbEtiquetadocomo.Items.Clear();
            }


        }
        //Se validan los rangos ingresados de hologramas comparada con las botellas que se tienen
        public Boolean validaRangoBotellas()
        {
            Boolean msj = false;
            int suma_botellas = 0;
            if (DtaHologramas.Rows.Count >= 1)
            {

                for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                {
                    suma_botellas += ((int.Parse(DtaHologramas.Rows[x].Cells["FIN"].Value.ToString()) - int.Parse(DtaHologramas.Rows[x].Cells["INICIO"].Value.ToString())) + 1);
                }

            }
            int totalBotellas = Convert.ToInt32(TxtNoBotellas.Text);
            if (totalBotellas != suma_botellas)
            {
                msj = true;
            }
            return msj;

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
        #endregion
        //=============================================================================>>----{Fin Envasado}-----<<========================================================



        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>-------{inicio de todo Seleccion del cliente}------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #region SELECCION DE CLIENTE(INICIO DE TODO)
        private void TxTNoClienteSeleccion_KeyDown(object sender, KeyEventArgs e)
        {


            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LblClienteSeleccionado.Text = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM  clientes  WHERE no_cliente='" + TxTNoClienteSeleccion.Text + "'");
                    if (LblClienteSeleccionado.Text == "")
                    {
                        MessageBox.Show("Numero de cliente no encontrado");
                        LblClienteSeleccionado.Text = "......";
                        Usuario.No_Cliente = "0";
                        Usuario.EnvasadoraSeleccionada = "0";
                        Usuario.FabricaSeleccionada = "0";
                        Usuario.Bodega_GranelSeleccionada = "0";
                        Usuario.Bodega_EnvasadoSeleccionada = "0";
                        CmbEnvasadoraSeleccionada.DataSource = null;
                        CmbFabricaSeleccionada.DataSource = null;
                        cmbAlmacen_granelSelecionada.DataSource = null;
                        cmbAlmacen_EnvasadoSelecionada.DataSource = null;

                    }
                    else
                    {
                        Usuario.No_Cliente = TxTNoClienteSeleccion.Text;

                        ///----------- Selecciona la fabria a ocupar -------
                        CmbFabricaSeleccionada.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbFabricaSeleccionada, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + TxTNoClienteSeleccion.Text + "'", "id_fabrica", "fabrica");
                        if (CmbFabricaSeleccionada.Items.Count == 0)
                        {
                            Usuario.FabricaSeleccionada = "0";
                        }
                        ///------------------- Selecciona la envasadora a ocupar ------------
                        CmbEnvasadoraSeleccionada.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbEnvasadoraSeleccionada, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + TxTNoClienteSeleccion.Text + "'", "id_envasadora", "envasadora");
                        if (CmbEnvasadoraSeleccionada.Items.Count == 0)
                        {
                            Usuario.EnvasadoraSeleccionada = "0";
                        }

                        ///----------- Selecciona el almacen de granel a ocupar ------
                        cmbAlmacen_granelSelecionada.DataSource = null;
                        ConexionMysql.llenaCombo(ref cmbAlmacen_granelSelecionada, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + TxTNoClienteSeleccion.Text + "' AND tipo_almacen=1;", "id_almacen", "almacen");
                        if (cmbAlmacen_granelSelecionada.Items.Count == 0)
                        {

                            Usuario.Bodega_GranelSeleccionada = "0";
                        }
                        ///----------- Selecciona  el almacen de envasado a ocupar --------

                        cmbAlmacen_EnvasadoSelecionada.DataSource = null;
                        ConexionMysql.llenaCombo(ref  cmbAlmacen_EnvasadoSelecionada, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + TxTNoClienteSeleccion.Text + "' AND tipo_almacen=2;", "id_almacen", "almacen");

                        if (cmbAlmacen_EnvasadoSelecionada.Items.Count == 0)
                        {

                            Usuario.Bodega_EnvasadoSeleccionada = "0";
                        }
                    }
                }
                else
                {
                    LblClienteSeleccionado.Text = "......";
                    Usuario.No_Cliente = "0";
                    Usuario.EnvasadoraSeleccionada = "0";
                    Usuario.FabricaSeleccionada = "0";
                    Usuario.Bodega_GranelSeleccionada = "0";
                    Usuario.Bodega_EnvasadoSeleccionada = "0";
                    CmbEnvasadoraSeleccionada.DataSource = null;
                    CmbFabricaSeleccionada.DataSource = null;
                    cmbAlmacen_granelSelecionada.DataSource = null;
                    cmbAlmacen_EnvasadoSelecionada.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (Usuario.No_Cliente == "0")
            {
                MessageBox.Show("No has seleccionado un cliente");
                TxTNoClienteSeleccion.Focus();
                return;
            }
            if (CmbFabricaSeleccionada.Items.Count != 0)
            {
                Usuario.FabricaSeleccionada = CmbFabricaSeleccionada.SelectedValue.ToString();
            }

            if (CmbEnvasadoraSeleccionada.Items.Count != 0)
            {
                Usuario.EnvasadoraSeleccionada = CmbEnvasadoraSeleccionada.SelectedValue.ToString();
            }

            if (cmbAlmacen_granelSelecionada.Items.Count != 0)
            {
                Usuario.Bodega_GranelSeleccionada = cmbAlmacen_granelSelecionada.SelectedValue.ToString();
            }


            if (cmbAlmacen_EnvasadoSelecionada.Items.Count != 0)
            {
                Usuario.Bodega_EnvasadoSeleccionada = cmbAlmacen_EnvasadoSelecionada.SelectedValue.ToString();
            }


            PanelSeleccion.Visible = false;
            BtnProduccion_Click(sender, e);
            BtnProduccion.Visible = true;
            BtnGranel.Visible = true;
            btnAlmacenGranel.Visible = true;
            BtnEnvasadoGranel.Visible = true;
            BtnEnvasado.Visible = true;
            btnAlmacen.Visible = true;

        }

        private void PanelSeleccion_Paint(object sender, PaintEventArgs e)
        {
            //this.ActiveControl = TxTNoClienteSeleccion;
            //TxTNoClienteSeleccion.Focus();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*  ObtenerIdMaximoProduccionEntrada();
              MessageBox.Show("" + id_max_produccion_entrada);
              Inventario.Obsevaciones.Observaciones obs = new Inventario.Obsevaciones.Observaciones();
              obs.id_produccion = id_max_produccion_entrada;
              obs.ShowDialog();*/




        }
        #endregion
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>-------{Fin de inicio de todo Seleccion del cliente}------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>-------{   Observaciones  }------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #region OTROS METODOS SOBRE ALMACENES Y OTRAS HERRAMIENTAS

        public void ObtenerIdMaximoMensaje()
        {
            id_max_observaciones = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_observaciones,4)) )   FROM observaciones where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_observaciones == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_observaciones = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_observaciones = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_observaciones) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_observaciones = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_observaciones = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //r@le------funcion para agregar observaciones 
        public void observaciones()
        {

            if (txtObservaciones.Text == "")
            {
                MessageBox.Show("Desbes ecribir un mensaje");
                txtObservaciones.Focus();
                return;
            }
            ObtenerIdMaximoMensaje();
            if (ConexionMysql.insUpd_transaccion("INSERT INTO observaciones(id_observaciones,observaciones,  id_verificador, fecha,id_movimiento,actualizado) VALUES ('" + id_max_observaciones + "','" + txtObservaciones.Text + "'," + Usuario.IdUsuario + ",now(),'" + id_produccion + "'" + ",0)") == "Error")
            {

                MessageBox.Show("INSERT INTO observaciones(id_observaciones,observaciones,  id_verificador, fecha,id_movimiento,actualizado) VALUES ('" + id_max_observaciones + "','" + txtObservaciones.Text + "'," + Usuario.IdUsuario + ",now(),'" + id_produccion + "'" + ",0) == Error");

                return;
            }
            ConexionMysql.transCompleta();
            txtObservaciones.Text = "";
            /*string mensajes = "";
            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT verificadores.nombre,observaciones.observaciones,DATE_FORMAT(observaciones.fecha, '%d/%m/%Y') as fecha from observaciones INNER JOIN verificadores ON observaciones.id_verificador=verificadores.id_us where id_movimiento='" + id_produccion + "'  ");



             foreach (DataRow row in Datos.Tables[0].Rows)
             {
                 string nombre = row["nombre"].ToString();
                 string mensaje = row["observaciones"].ToString();
                 string fecha = row["fecha"].ToString();
                 mensajes += System.Environment.NewLine + fecha + "  " + nombre + " :  " + mensaje + System.Environment.NewLine;
             }
             rtxObservacones.Text = mensajes;
             rtxObservacones.SelectionStart = rtxObservacones.Text.Length;
             rtxObservacones.ScrollToCaret();*/

        }


        private void btnAlmacen_Click(object sender, EventArgs e)
        {


            pnlAlmacen.Visible = true;

            PanelProduccion.Visible = false;
            PanelGranel.Visible = false;
            PanelGranelEnvasado.Visible = false;
            PanelEnvasado.Visible = false;
            pnlAlmacendeGraneles.Visible = false;

            /*cmbTipoAlmacen.Items.Clear();
            cmbTipoAlmacen.Items.Insert(0, "---Elije una opcion---");
            cmbTipoAlmacen.Items.Insert(1, "Graneles");
            //cmbTipoAlmacen.Items.Insert(2, "Granel envasado");
            cmbTipoAlmacen.Items.Insert(2, "Envasado");
            cmbTipoAlmacen.SelectedIndex = 0;*/
            cmbMarcaEnvasadoparaAlmacen.DataSource = null;

            cmbMarcaEnvasadoparaAlmacen.Visible = true;
            cmbMarcaEnvasadoparaAlmacen.Enabled = false;
            txtMarcaEnvasado.Visible = false;
            chkMaquila.Enabled = false;
            chkCambioNoloteparaAlmacen.Toggled = false;


            TxtClaveFqAlmacen.Text = "";
            TxtNoLoteAlmacen.Text = "";
            txtMarcaEnvasado.Text = "";
            txtgradoAlcoholetiqueta.Text = "";
            txtUnidadMedida.Text = "";
            txtContenido.Text = "";
            txtTerminado.Text = "....";



            // RbtnFabrica.Checked = false;
            // RbtnEnvasadora.Checked = true;
            //  CmbFabricaEnvasadora.Enabled = false;
            // TxtMaestroMezcaleroEnvasadora.Enabled = false;
            addtablaEnvasadoparaAlmacenEnv();
            addTablaProductoAlmacenEnvasado();
            addTablaProductoAlmacenEnvasadoSalio();
            addTablaProductoAlmacenEnvasadoNoTerminado();
            addTablaHologramasparaAlmacen();
            BanderaAlmacenEnvasado = false;
            BanderaAlmacenEnvasadoSalio = false;
            BanderaAlmacenEnvasadoNoTerminado = true;

            LblAlmacenEtiquetadocomo.Enabled = false;
            CmbAlmacenEtiquetadocomo.Enabled = false;

            //ConexionMysql.llenaCombo(ref CmbNoClienteEnvasado, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
            //r@le-> la conslta anterior toma los clientes de ruta clientes ahora los tomara directamente de la tabla clientes
            ConexionMysql.llenaCombo(ref CmbNoClienteBodegaEnvasado, "SELECT no_cliente FROM clientes", "no_cliente", "no_cliente");


            if (Usuario.No_Cliente != "0")
            {
                CmbNoClienteBodegaEnvasado.SelectedValue = Usuario.No_Cliente;
            }
            /* ConexionMysql.llenaCombo(ref cmbBodegaEnvasado, "SELECT bodega_envasado,id_bodega_envasado FROM bodega_envasado_encargado where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "'", "id_bodega_envasado", "bodega");
             */

            tabControl3.SelectedTab = tabPage9;


        }





        private void CmbProduccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //---Funcion de busqueda en los datagridview
        //-granel de fabrica
        private void txtBuscaLote_TextChanged(object sender, EventArgs e)
        {

            if (BanderaGranel == true)
            {
                funcion_buscar(DtaProductoAgranel, txtBuscaLotee);

            }
            else if (BanderaBarrica == true)
            {

                funcion_buscar(DtaProductoBarrica, txtBuscaLotee);


            }
            else if (BanderaVidrio == true)
            {
                funcion_buscar(DtaProductoVidrio, txtBuscaLotee);

            }

        }//-- fin de txtBuscaLote_TextChanged
        //============ Buscar en envasado
        private void txtBuscarLoteEnvasado_TextChanged(object sender, EventArgs e)
        {
            if (BanderaEnvasadoNoTerminado == true)
            {
                funcion_buscar(DtaProductoEnvasadoNoTerminado, txtBuscarLoteEnvasado);

            }
            else if (BanderaEnvasado == true)
            {

                funcion_buscar(DtaProductoEnvasado, txtBuscarLoteEnvasado);

            }
            else if (BanderaEnvasadoSalio == true)
            {
                funcion_buscar(DtaProductoEnvasadoSalio, txtBuscarLoteEnvasado);

            }
        }


        //--- busca lote en granel del envasado
        private void txtBuscarLoteGEnvasado_TextChanged(object sender, EventArgs e)
        {

            if (BanderaGranelEnvasado == true)
            {
                funcion_buscar(DtaProductoAgranelEnvasado, txtBuscarLoteGEnvasado);

            }
            else if (BanderaBarricaEnvasado == true)
            {

                funcion_buscar(DtaProductoBarricaEnvasado, txtBuscarLoteGEnvasado);


            }
            else if (BanderaVidrioEnvasado == true)
            {
                funcion_buscar(DtaProductoVidrioEnvasado, txtBuscarLoteGEnvasado);

            }
        }




        //== Esta funcion es para buscar los lotes en el data gridview 
        public void funcion_buscar(DataGridView dtaN, TextBox txtBusca)
        {

            dtaN.CurrentCell = null;

            foreach (DataGridViewRow Row in dtaN.Rows)
            {

                Row.Visible = false;
                //Row.Selected = false;


            }

            foreach (DataGridViewRow Row in dtaN.Rows)
            {

                foreach (DataGridViewCell cell in Row.Cells)
                {
                    if ((cell.Value.ToString().ToUpper()).IndexOf(txtBusca.Text.ToUpper()) == 0)
                    {
                        //Row.Selected = true;
                        Row.Visible = true; //Activa las filas que coincidan con el caracter ingresado
                        //DtaProductoAgranel.CurrentCell = cell;
                        //MessageBox.Show(" " + "Queryable es");
                    }

                }
            }

        }

        private void txtbuscarLoteProduccion_TextChanged(object sender, EventArgs e)
        {

            if (BanderaCoccion == true)
            {
                funcion_buscar(DtaCoccion, txtbuscarLoteProduccion);

            }
            else if (BanderaMolienda == true)
            {

                funcion_buscar(DtaMolienda, txtbuscarLoteProduccion);

            }
            else if (BanderaFormulacion == true)
            {
                funcion_buscar(DtaFormulacion, txtbuscarLoteProduccion);

            }
            else if (BanderaDestilacion == true)
            {

                funcion_buscar(DtaDestilacion, txtbuscarLoteProduccion);

            }
            else if (BanderaProduccion == true)
            {
                funcion_buscar(DtaProduccion, txtbuscarLoteProduccion);

            }
        }

        private void chkAbocadoEnvasado_ToggledChanged()
        {
            if (chkAbocadoEnvasado.Toggled == true)
            {
                TxtIngredienteEnvasado.Enabled = true;
                lblIngrediente.Enabled = true;
            }
            else
            {
                TxtIngredienteEnvasado.Text = "";
                TxtIngredienteEnvasado.Enabled = false;
                lblIngrediente.Enabled = false;
            }
        }

        private void chkAbocadoGF_ToggledChanged()
        {
            if (chkAbocadoGF.Toggled == true)
            {
                txtIngredienteGF.Enabled = true;
                lbltituloIGF.Enabled = true;
            }
            else
            {
                txtIngredienteGF.Text = "";
                txtIngredienteGF.Enabled = false;
                lbltituloIGF.Enabled = false;
            }
        }

        #endregion

        
        ///=================================== Inicia Almacen de graneles =======================
        #region ALMACENES

        private void btnAlmacenGranel_Click(object sender, EventArgs e)
        {
            pnlAlmacendeGraneles.Visible = true;
            PanelProduccion.Visible = false;
            PanelGranel.Visible = false;
            PanelGranelEnvasado.Visible = false;
            PanelEnvasado.Visible = false;
            pnlAlmacen.Visible = false;


            rdoGranefabrica.Checked = true;
            rdoGranelEnvasado.Checked = false;

            addTablaProductoAgranelAlmacen();
            addTablaProductoBarricaAlmacen();
            addTablaProductoVidrioAlmacen();
            addTablaProduccionParaGuardarAlmacendeAgranel();
            addTablaTanquesAlmacenAgranel();
            txtLitrosparaAlmacenGraneles.Text = "";
            txtNoTanqueparaAlmacenGranel.Text = "";
            txtNoLoteAlmacenGranel.Text = "";
            txtClvFqAlmacenGranel.Text = "";
            //TxtIngredienteEnvasado.Text = "";
            //TxtFQEnvasado.Text = "";
            chkAbocadoAlmacen.Toggled = false;
            BanderaGranelAlmacen = true;
            BanderaBarricaAlmacen = false;
            BanderaVidrioAlmacen = false;
            //granel_envasadoBandera = true;
            //envasadoBandera = false;
            //ConexionMysql.llenaCombo(ref CmbNoClienteGranelEnvasado, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
            //r@le-> la conslta anterior toma los clientes de ruta clientes ahora los tomara directamente de la tabla clientes
            ConexionMysql.llenaCombo(ref CmbNoClienteAlmacenGranel, "SELECT no_cliente FROM clientes", "no_cliente", "no_cliente");
            if (Usuario.No_Cliente != "0")
            {
                CmbNoClienteAlmacenGranel.SelectedValue = Usuario.No_Cliente;
            }
            tabControl6.SelectedTab = tabPage18;


            //chkAbocadoEnvasado.Toggled = false;

            //TxtIngredienteEnvasado.Enabled = false;
            //lblIngrediente.Enabled = false;
        }


        //crea la tabla de  producto granel
        private void addTablaProductoAgranelAlmacen()
        {
            dtsProductoAgranelAlmacen = new DataSet();
            dtsProductoAgranelAlmacen.Tables.Add("PRODUCTOAGRANELALMACEN");
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("ID_PRODUCCION_GRANEL_ALMACEN", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("NO_TANQUE", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoAgranelAlmacen.DataSource = dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELaLMACEN"];
            DtaProductoAgranelAlmacen.Columns[1].Visible = false;
            DtaProductoAgranelAlmacen.Columns[8].Visible = false;
        }



        //crea la tabla de  producto en barrica
        private void addTablaProductoBarricaAlmacen()
        {
            dtsProductoBarricaAlmacen = new DataSet();
            dtsProductoBarricaAlmacen.Tables.Add("PRODUCTOBARRICAALMACEN");
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("ID_ALMACEN_GRANEL_MOVIMIENTOS", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("ID_PRODUCCION_GRANEL_ALMACEN", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("NO_BARRICAS", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("FOLIO", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoBarricaAlmacen.DataSource = dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"];
            DtaProductoBarricaAlmacen.Columns[1].Visible = false;
            DtaProductoBarricaAlmacen.Columns[2].Visible = false;
            DtaProductoBarricaAlmacen.Columns[9].Visible = false;
        }


        //crea la tabla de  producto en vidrio

        private void addTablaProductoVidrioAlmacen()
        {
            dtsProductoVidrioAlmacen = new DataSet();
            dtsProductoVidrioAlmacen.Tables.Add("PRODUCTOVIDRIOALMACEN");
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("ID_ALMACEN_GRANEL_MOVIMIENTOS", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("ID_PRODUCCION_GRANEL_ALMACEN", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("NO_CONTENEDORES", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("FOLIO", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoVidrioAlmacen.DataSource = dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"];
            DtaProductoVidrioAlmacen.Columns[1].Visible = false;
            DtaProductoVidrioAlmacen.Columns[2].Visible = false;
            DtaProductoVidrioAlmacen.Columns[10].Visible = false;
        }



        private void addTablaProduccionParaGuardarAlmacendeAgranel()
        {
            dtsProduccionParaGuardarAlmacenAgranel = new DataSet();
            dtsProduccionParaGuardarAlmacenAgranel.Tables.Add("PRODUCCIONPARAGUARDARALMACENAGRANEL");
            dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Columns.Add("ID_GRANEL_ENTRADA", Type.GetType("System.String"));
            dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaLoteGranelparaAlmacenGranel.DataSource = dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"];
            DtaLoteGranelparaAlmacenGranel.Columns[1].Visible = false;


        }

        private void addTablaTanquesAlmacenAgranel()
        {
            dtsTanquesAlmacenAgranel = new DataSet();
            dtsTanquesAlmacenAgranel.Tables.Add("TANQUESALMACENGRANEL");
            dtsTanquesAlmacenAgranel.Tables["TANQUESALMACENGRANEL"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanquesAlmacenAgranel.Tables["TANQUESALMACENGRANEL"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaTanqueAlmacenGranel.DataSource = dtsTanquesAlmacenAgranel.Tables["TANQUESALMACENGRANEL"];
        }

        private void CmbNoClienteAlmacenGranel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtsProductoAgranelAlmacen.Clear();
                dtsProductoVidrioAlmacen.Clear();
                dtsProductoBarricaAlmacen.Clear();
                dtsProduccionParaGuardarAlmacenAgranel.Clear();

                //carga envasadora
                CmbNoAlmacenGraneles.DataSource = null;
                txtNoResponsableAlmacenGraneles.Text = "";
                ConexionMysql.llenaCombo(ref CmbNoAlmacenGraneles, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + CmbNoClienteAlmacenGranel.SelectedValue + "' AND tipo_almacen=1", "id_almacen", "almacen");

                if (Usuario.Bodega_GranelSeleccionada != "0")
                {
                    CmbNoAlmacenGraneles.SelectedValue = Usuario.Bodega_GranelSeleccionada;
                }
                ///--- es para seleccionar el folio unico de granel fabrica y envasado --
                ///-- checar por que sicambia de fabrica debe de mostrar el granel de dicha fabrica o la que es de defecto---
                //   string noFolioGranelUnico = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM bodega_envasado_encargado where id_bodega_envasado='"+CmbNoAlmacenGraneles.SelectedValue+"';");

                lblFolioUnicoAlmacenGranel.Text = "...."; //noFolioGranelUnico;


                //carga fabricas
                CmbGranelfabricaEnvasado.DataSource = null;
                txtResponsableFabricaEnvasado.Text = "";
                if (rdoGranefabrica.Checked == true)
                {
                    //--- Es para seleccionar la fabrica de los Graneles de fabrica y envasaado
                    ConexionMysql.llenaCombo(ref CmbGranelfabricaEnvasado, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteAlmacenGranel.SelectedValue + "'", "id_fabrica", "fabrica");
                    if (Usuario.FabricaSeleccionada != "0")
                    {
                        CmbGranelfabricaEnvasado.SelectedValue = Usuario.FabricaSeleccionada;
                    }

                }
                else
                {
                    ConexionMysql.llenaCombo(ref CmbGranelfabricaEnvasado, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteAlmacenGranel.SelectedValue + "'", "id_envasadora", "envasadora");
                    if (Usuario.EnvasadoraSeleccionada != "0")
                    {
                        CmbGranelfabricaEnvasado.SelectedValue = Usuario.EnvasadoraSeleccionada;
                    }

                }


                //-- string Foliogranel = ConexionMysql.regresaCampoConsulta("SELECT folio_granel FROM  clientes  where no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'  ");

                ////---Agregar el foliogranel al la tabla de encargadofabrica para y el campo que de folio_granel ----- 
                /* string Foliogranel = ConexionMysql.regresaCampoConsulta("SELECT folio_granel FROM  clientes  where no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'  ");

                 if (Foliogranel == "")
                 {
                     ///-- la consulta de abajo puede quedar que referencie en base a la grafica el estado y determinar si es de Denominacion de origen -- 
                     string estado = ConexionMysql.regresaCampoConsulta("SELECT estados.codigo from estados inner join relacion_cp_estado on  estados.clave=relacion_cp_estado.clave_estado inner join clientes on relacion_cp_estado.cp=clientes.cp  where clientes.no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "'");
                     string Folio = ConexionMysql.regresaCampoConsulta("SELECT max(id_folio) FROM  folios ");
                     string foliogranel = "";
                     if (Folio == "")
                     {
                         Folio = "1";
                         foliogranel = Usuario.IdUsuario + "00000" + Folio + "GN" + estado;
                     }
                     else
                     {
                         int NuevoFolio = 0;
                         string cero = "";
                         NuevoFolio = int.Parse(Folio) + 1;
                         if (NuevoFolio.ToString().Length == 1)
                         {
                             cero = "00000";
                         }
                         else if (NuevoFolio.ToString().Length == 2)
                         {
                             cero = "0000";
                         }
                         else if (NuevoFolio.ToString().Length == 3)
                         {
                             cero = "000";
                         }
                         else if (NuevoFolio.ToString().Length == 4)
                         {
                             cero = "00";
                         }
                         else if (NuevoFolio.ToString().Length == 5)
                         {
                             cero = "0";
                         }

                         foliogranel = Usuario.IdUsuario + cero + NuevoFolio + "GR" + estado;
                     }*/
                ///--- aqui no deberia de de ingresar Los folios
                /*
                if (ConexionMysql.insUpd_transaccion("INSERT INTO folios(folio,actualizado) values ('" + foliogranel + "',0) ") == "Error")
                {
                    return;
                }
                if (ConexionMysql.insUpd_transaccion("UPDATE clientes SET  folio_granel ='" + foliogranel + "' WHERE no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "' ") == "Error")
                {
                    return;
                }*/
                //TxtFolioGranelEnvasado.Text = foliogranel;

                // ConexionMysql.transCompleta();
                //}
                //else
                //{
                //TxtFolioGranelEnvasado.Text = Foliogranel;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CmbNoAlmacenGraneles_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbNoAlmacenGraneles.SelectedValue != null)
            {


                ///--- es para deleccionar el folio unico de granel fabrica y envasado --
                ///-- checar por que sicambia de fabrica debe de mostrar el granel de dicha fabrica o la que es de defecto---
                string noFolioGranelUnico = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM almacen_encargado where id_almacen='" + CmbNoAlmacenGraneles.SelectedValue + "';");

                lblFolioUnicoAlmacenGranel.Text = noFolioGranelUnico;



                //carga fabricas
                //CmbFabricaGranelEnvasado.DataSource = null;
                // txtNoResponsableAlmacenGraneles.Text = "";

                txtNoResponsableAlmacenGraneles.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  almacen_encargado  WHERE id_almacen='" + CmbNoAlmacenGraneles.SelectedValue + "';");


                TxtLitrosParaGuardarAgranelEnvasado.Text = "";

                if (BanderaGranelAlmacen == true)
                {

                    //// ---- CHECAR LO DE LA ESPECIE QUE SE ORDENE POR LITROS
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  almacen_granel_entrada.clase, almacen_granel_entrada.id_almacen_granel_entrada, DATE_FORMAT(almacen_granel_entrada.fecha, '%d/%m/%Y') as fecha , almacen_granel_entrada.no_lote, almacen_granel_entrada.fq, almacen_granel_entrada.categoria, almacen_granel_entrada.abocante, almacen_granel_entrada.ingrediente, ROUND(almacen_granel_entrada.lts_existentes,2) AS lts_existentes , almacen_granel_entrada.grado_alcoholico_existente,  comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_granel_entrada ASC ) as ensamble_maguey, GROUP_CONCAT(DISTINCT almacen_granel_tanques.tanque) as tanque  FROM almacen_granel_entrada  LEFT JOIN existenciaplanta ON almacen_granel_entrada.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON almacen_granel_entrada.id_comun=comun2.id_comun INNER JOIN almacen_granel_tanques ON almacen_granel_entrada.id_almacen_granel_entrada=almacen_granel_tanques.id_almacen_granel_entrada LEFT JOIN   ( SELECT almacen_granel_ensamble.id_almacen_granel_entrada,almacen_granel_ensamble.litros,almacen_granel_ensamble.agave_coccion_kg,comun.nombre FROM almacen_granel_ensamble INNER JOIN existenciaplanta ON almacen_granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by almacen_granel_ensamble.id_almacen_granel_entrada asc,almacen_granel_ensamble.litros desc, almacen_granel_ensamble.agave_coccion_kg desc) TABLA  ON almacen_granel_entrada.id_almacen_granel_entrada=TABLA.id_almacen_granel_entrada LEFT JOIN  ( SELECT almacen_granel_ensamble.id_almacen_granel_entrada, almacen_granel_ensamble.id_planta,  almacen_granel_ensamble.id_predio,almacen_granel_ensamble.litros,almacen_granel_ensamble.agave_coccion_kg, comun3.nombre  FROM almacen_granel_ensamble  LEFT JOIN existenciaplanta ON almacen_granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR almacen_granel_ensamble.id_comun = comun3.id_comun ORDER BY almacen_granel_ensamble.litros DESC,almacen_granel_ensamble.agave_coccion_kg DESC) AS maguey ON almacen_granel_entrada.id_almacen_granel_entrada = maguey.id_almacen_granel_entrada WHERE almacen_granel_entrada.id_almacen= '" + CmbNoAlmacenGraneles.SelectedValue + "' and almacen_granel_entrada.lts_existentes > 0 GROUP BY almacen_granel_entrada.id ");
                    DataRow fila;
                    dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].NewRow();
                        fila["ID_PRODUCCION_GRANEL_ALMACEN"] = Convert.ToString(row["id_almacen_granel_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_TANQUE"] = Convert.ToString(row["tanque"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);


                        //string especie = "";
                        //string especie1 = Convert.ToString(row["maguey"]);
                        //string especie2 = Convert.ToString(row["maguey_sin"]);
                        //string especie3 = Convert.ToString(row["ensamble_maguey"]);
                        //string especie4 = Convert.ToString(row["ensamble_maguey_sin"]);

                        //if (especie1 != "")
                        //{
                        //    especie = especie1;
                        //}
                        //if (especie2 != "")
                        //{
                        //    String value = especie; 
                        //    Char delimiter = ',';
                        //    String[] substrings = value.Split(delimiter);
                        //    foreach (var substring in substrings)
                        //    {
                        //        Console.WriteLine(substring);

                        //        String value = especie;
                        //        Char delimiter = ',';
                        //        String[] substrings = value.Split(delimiter);
                        //        foreach (var substring in substrings)
                        //        {
                        //            Console.WriteLine(substring);
                        //        }
                        //    }
                        //}

                        //-- en esta parte detecta si es que alguno de estos valores en diferente de vacio y toma el primer valor que cumpla la condicion
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }



                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS"] = Convert.ToString(row["lts_existentes"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);

                        dtsProductoAgranelAlmacen.Tables["PRODUCTOAGRANELALMACEN"].Rows.Add(fila);
                    }
                }
                else if (BanderaBarricaAlmacen == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT almacen_granel_movimientos.numero_de_contenedores, almacen_granel_movimientos.id_almacen_granel_movimientos,almacen_granel_movimientos.id_almacen_granel_entrada,almacen_granel_movimientos.folio,DATE_FORMAT(almacen_granel_movimientos.fecha, '%d/%m/%Y') as fecha,almacen_granel_movimientos.no_lote,almacen_granel_entrada.fq,almacen_granel_entrada.categoria,almacen_granel_entrada.abocante,almacen_granel_entrada.ingrediente,almacen_granel_movimientos.litros_existentes,almacen_granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble ,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_granel_entrada ASC ) as ensamble_maguey FROM almacen_granel_movimientos INNER JOIN almacen_granel_entrada ON almacen_granel_movimientos.id_almacen_granel_entrada=almacen_granel_entrada.id_almacen_granel_entrada LEFT JOIN existenciaplanta ON almacen_granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON almacen_granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT almacen_granel_ensamble.id_almacen_granel_entrada,almacen_granel_ensamble.litros,almacen_granel_ensamble.agave_coccion_kg,comun.nombre FROM almacen_granel_ensamble INNER JOIN existenciaplanta ON almacen_granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by almacen_granel_ensamble.id_almacen_granel_entrada asc, almacen_granel_ensamble.litros desc, almacen_granel_ensamble.agave_coccion_kg desc)  TABLA ON almacen_granel_movimientos.id_almacen_granel_entrada=TABLA.id_almacen_granel_entrada  LEFT JOIN (SELECT almacen_granel_ensamble.id_almacen_granel_entrada, almacen_granel_ensamble.id_planta,  almacen_granel_ensamble.id_predio,almacen_granel_ensamble.litros,almacen_granel_ensamble.agave_coccion_kg, comun3.nombre  FROM almacen_granel_ensamble  LEFT JOIN existenciaplanta ON almacen_granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR almacen_granel_ensamble.id_comun = comun3.id_comun ORDER BY almacen_granel_ensamble.litros DESC,almacen_granel_ensamble.agave_coccion_kg DESC) AS maguey ON almacen_granel_entrada.id_almacen_granel_entrada = maguey.id_almacen_granel_entrada WHERE almacen_granel_entrada.id_almacen= '" + CmbNoAlmacenGraneles.SelectedValue + "' and almacen_granel_movimientos.litros_existentes > 0 and almacen_granel_movimientos.destino='barricas'  GROUP BY almacen_granel_movimientos.id_almacen_granel_movimientos");
                    DataRow fila;
                    dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].NewRow();
                        fila["ID_ALMACEN_GRANEL_MOVIMIENTOS"] = Convert.ToString(row["id_almacen_granel_movimientos"]);
                        fila["ID_PRODUCCION_GRANEL_ALMACEN"] = Convert.ToString(row["id_almacen_granel_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        fila["FOLIO"] = Convert.ToString(row["folio"]);
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }

                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["NO_BARRICAS"] = Convert.ToString(row["numero_de_contenedores"]);
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS"] = Convert.ToString(row["litros_existentes"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);

                        dtsProductoBarricaAlmacen.Tables["PRODUCTOBARRICAALMACEN"].Rows.Add(fila);

                    }
                }
                else if (BanderaVidrioAlmacen == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT almacen_granel_movimientos.numero_de_contenedores,almacen_granel_movimientos.id_almacen_granel_movimientos,almacen_granel_movimientos.id_almacen_granel_entrada,almacen_granel_movimientos.folio,DATE_FORMAT(almacen_granel_movimientos.fecha, '%d/%m/%Y') as fecha,almacen_granel_movimientos.no_lote,almacen_granel_entrada.fq,almacen_granel_entrada.categoria,almacen_granel_entrada.abocante,almacen_granel_entrada.ingrediente,almacen_granel_movimientos.litros_existentes,almacen_granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_granel_entrada ASC ) as ensamble_maguey FROM almacen_granel_movimientos INNER JOIN almacen_granel_entrada ON almacen_granel_movimientos.id_almacen_granel_entrada=almacen_granel_entrada.id_almacen_granel_entrada LEFT JOIN existenciaplanta ON almacen_granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON almacen_granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT almacen_granel_ensamble.id_almacen_granel_entrada,almacen_granel_ensamble.litros,almacen_granel_ensamble.agave_coccion_kg,comun.nombre FROM almacen_granel_ensamble INNER JOIN existenciaplanta ON almacen_granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by almacen_granel_ensamble.id_almacen_granel_entrada asc, almacen_granel_ensamble.litros desc, almacen_granel_ensamble.agave_coccion_kg desc)  TABLA ON almacen_granel_movimientos.id_almacen_granel_entrada=TABLA.id_almacen_granel_entrada  LEFT JOIN (   SELECT almacen_granel_ensamble.id_almacen_granel_entrada, almacen_granel_ensamble.id_planta,  almacen_granel_ensamble.id_predio,almacen_granel_ensamble.litros,almacen_granel_ensamble.agave_coccion_kg, comun3.nombre  FROM almacen_granel_ensamble  LEFT JOIN existenciaplanta ON almacen_granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR almacen_granel_ensamble.id_comun = comun3.id_comun ORDER BY almacen_granel_ensamble.litros DESC,almacen_granel_ensamble.agave_coccion_kg DESC) AS maguey ON almacen_granel_entrada.id_almacen_granel_entrada = maguey.id_almacen_granel_entrada WHERE almacen_granel_entrada.id_almacen= '" + CmbNoAlmacenGraneles.SelectedValue + "' and almacen_granel_movimientos.litros_existentes > 0 and almacen_granel_movimientos.destino='vidrio'  GROUP BY almacen_granel_movimientos.id_almacen_granel_movimientos");
                    DataRow fila;
                    dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].NewRow();
                        fila["ID_ALMACEN_GRANEL_MOVIMIENTOS"] = Convert.ToString(row["id_almacen_granel_movimientos"]);
                        fila["ID_PRODUCCION_GRANEL_ALMACEN"] = Convert.ToString(row["id_almacen_granel_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        fila["FOLIO"] = Convert.ToString(row["folio"]);
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }

                        fila["NO_CONTENEDORES"] = Convert.ToString(row["numero_de_contenedores"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["LITROS"] = Convert.ToString(row["litros_existentes"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico_existente"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoVidrioAlmacen.Tables["PRODUCTOVIDRIOALMACEN"].Rows.Add(fila);
                    }
                }

            }
        }

        private void btnNuevoAlmacenGranel_Click(object sender, EventArgs e)
        {

            FrmNuevoAlmacen bodega = new FrmNuevoAlmacen();
            bodega.no_cliente = CmbNoClienteAlmacenGranel.SelectedValue.ToString();
            bodega.tipo_bodega = "1";
            bodega.ShowDialog();


            ConexionMysql.llenaCombo(ref CmbNoAlmacenGraneles, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + CmbNoClienteAlmacenGranel.SelectedValue + "' AND tipo_almacen=1", "id_almacen", "almacen");
            if (Usuario.Bodega_GranelSeleccionada != "0")
            {
                CmbNoAlmacenGraneles.SelectedValue = Usuario.Bodega_GranelSeleccionada;
            }


        }

        private void CmbGranelfabricaEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {

            CmbLotedeGranelesparaAlmacen.DataSource = null;

            //dtsProduccionParaGuardarAlmacenAgranel.Clear();

            ///--- agregar la parte de  granel de envasado
            if (CmbGranelfabricaEnvasado.SelectedValue != null)
            {
                ///-- cuando el radio buton  de granel facbrica esta activo entra
                if (rdoGranefabrica.Checked == true)
                {
                    ConexionMysql.llenaComboAutocomplit(ref CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");

                    txtResponsableFabricaEnvasado.Text = ConexionMysql.regresaCampoConsulta("SELECT maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbGranelfabricaEnvasado.SelectedValue + "'");
                }
                else
                {
                    ///--- cuando el radiobutton de granel envasadop esta activo entra..
                    ConexionMysql.llenaComboAutocomplit(ref CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

                    txtResponsableFabricaEnvasado.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + CmbGranelfabricaEnvasado.SelectedValue + "'");

                }
            }



        }


        private void CmbLotedeGranelesparaAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (CmbLotedeGranelesparaAlmacen.DataSource == null)
                {
                    litros_Granel_FabricaEnvasado = "";
                    grado_alcoholico_Granel = "";
                    no_lote_Granel = "";
                }
                else
                {       /// --- si el radiobutton de granel fabrica esta activo entra
                    if (rdoGranefabrica.Checked == true)
                    {

                        litros_Granel_FabricaEnvasado = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes FROM  granel_entrada  WHERE id_granel_entrada='" + CmbLotedeGranelesparaAlmacen.SelectedValue + "'");
                        grado_alcoholico_Granel = ConexionMysql.regresaCampoConsulta("SELECT grado_alcoholico_existente FROM  granel_entrada  WHERE id_granel_entrada='" + CmbLotedeGranelesparaAlmacen.SelectedValue + "'");
                        no_lote_Granel = ConexionMysql.regresaCampoConsulta("SELECT no_lote FROM  granel_entrada  WHERE id_granel_entrada='" + CmbLotedeGranelesparaAlmacen.SelectedValue + "'");
                    }

                    else
                    {
                        /// --- si el radiobutton de Granel Envasado esta activo entra aqui

                        litros_Granel_FabricaEnvasado = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes FROM  granel_entrada_envasado  WHERE id_granel_entrada_envasado='" + CmbLotedeGranelesparaAlmacen.SelectedValue + "'");
                        grado_alcoholico_Granel = ConexionMysql.regresaCampoConsulta("SELECT grado_alcoholico_existente FROM  granel_entrada_envasado  WHERE id_granel_entrada_envasado='" + CmbLotedeGranelesparaAlmacen.SelectedValue + "'");
                        no_lote_Granel = ConexionMysql.regresaCampoConsulta("SELECT no_lote FROM  granel_entrada_envasado  WHERE id_granel_entrada_envasado='" + CmbLotedeGranelesparaAlmacen.SelectedValue + "'");


                    }



                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btbAgregarLitrosparaAlmacenGraneles_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbLotedeGranelesparaAlmacen.SelectedValue == null)
                {
                    MessageBox.Show("No tienes lotes para agregar");
                    return;
                }

                if (txtLitrosparaAlmacenGraneles.Text == "")
                {
                    MessageBox.Show("No ha introducido litros");
                    return;
                }


                if (Math.Round(double.Parse(litros_Granel_FabricaEnvasado), 2) < Math.Round(double.Parse(txtLitrosparaAlmacenGraneles.Text), 2))
                {
                    MessageBox.Show("Existencia insuficiente");
                    return;
                }

                DataRow fila = dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].NewRow();
                fila["NO_LOTE"] = no_lote_Granel;
                fila["ID_GRANEL_ENTRADA"] = CmbLotedeGranelesparaAlmacen.SelectedValue;
                fila["LITROS"] = txtLitrosparaAlmacenGraneles.Text;
                fila["%_ALCOHOLICO"] = grado_alcoholico_Granel;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Rows.Add(fila);
                txtLitrosparaAlmacenGraneles.Text = "";
                CmbLotedeGranelesparaAlmacen.DataSource = null;
                string produccion = "";
                string coma = "";
                for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                {
                    produccion += coma + "'" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'";
                    coma = ",";
                }

                if (rdoGranefabrica.Checked == true)
                {
                    ConexionMysql.llenaComboAutocomplit(ref CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN (" + produccion + ") and  id_fabrica='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");
                }
                else
                {

                    ConexionMysql.llenaComboAutocomplit(ref CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN (" + produccion + ") and  id_envasadora='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

                }


                if (DtaLoteGranelparaAlmacenGranel.Rows.Count > 1)
                {

                    clascategoriaparaAlmacen();


                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void clascategoriaparaAlmacen()
        {
            string CategoriaMezcal = "";
            string claseMezcal = "";

            int mzkl = 0;
            int maartesanal = 0;
            int mancetral = 0;

            int des_con = 0;
            int abocado_con = 0;
            int boj = 0;
            int madurado_vidrio = 0;
            int reposado = 0;
            int Añejo = 0;

            int s_klss = 0;


            ///-- si es el radiobutton de granel fabrica esta en true entra
            if (rdoGranefabrica.Checked == true)
            {
                for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                {

                    CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                    claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");




                    //MessageBox.Show("la categoria es : " + CategoriaMezcal);

                    if (CategoriaMezcal == "Mezcal")
                    {
                        mzkl++;
                    }
                    else if (CategoriaMezcal == "Mezcal Artesanal")
                    {
                        maartesanal++;
                    }
                    else if (CategoriaMezcal == "Mezcal Ancestral")
                    {
                        mancetral++;
                    }


                    if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven") { boj++; }
                    else if (claseMezcal == "Madurado en vidrio") { madurado_vidrio++; }
                    else if (claseMezcal == "Reposado") { reposado++; }
                    else if (claseMezcal == "Añejo") { Añejo++; }
                    else if (claseMezcal == "Abocado con") { abocado_con++; }
                    else if (claseMezcal == "Destilado con") { des_con++; }



                }//====FIn del for --- -

            }
            ///-- si es el radiobutton de granel Envasado esta en true entra
            else if (rdoGranelEnvasado.Checked == true)
            {
                for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                {
                    CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                    claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");


                    //MessageBox.Show("la categoria es : " + CategoriaMezcal);

                    if (CategoriaMezcal == "Mezcal")
                    {
                        mzkl++;
                    }
                    else if (CategoriaMezcal == "Mezcal Artesanal")
                    {
                        maartesanal++;
                    }
                    else if (CategoriaMezcal == "Mezcal Ancestral")
                    {
                        mancetral++;
                    }


                    if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven") { boj++; }
                    else if (claseMezcal == "Madurado en vidrio") { madurado_vidrio++; }
                    else if (claseMezcal == "Reposado") { reposado++; }
                    else if (claseMezcal == "Añejo") { Añejo++; }
                    else if (claseMezcal == "Abocado con") { abocado_con++; }
                    else if (claseMezcal == "Destilado con") { des_con++; }



                }//====FIn del for --- -

            }


            int[] cadclase = { boj, madurado_vidrio, reposado, Añejo, abocado_con, des_con };


            for (int g = 0; g < cadclase.Length; g++)
            {

                if (cadclase[g] > 0)
                {
                    s_klss++;


                }

            }






            if (s_klss > 1)
            {

                claseMezcal = "Cls_dif";
            }


            if (claseMezcal == "Cls_dif")
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Rows.Clear();
                return;

            }


            //========= Mezcal categoria

            if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Rows.Clear();
                return;

            }
            else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
            {
                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Rows.Clear();
                return;


            }
            else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Rows.Clear();
                return;

            }
            else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
            {

                MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Rows.Clear();
                return;

            }
        }



        private void txtLitrosparaAlmacenGraneles_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, txtLitrosparaAlmacenGraneles.Text);
        }



        private void DtaLoteGranelparaAlmacenGranel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaLoteGranelparaAlmacenGranel.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaLoteGranelparaAlmacenGranel.Rows.RemoveAt(e.RowIndex);
                    dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].AcceptChanges();
                    CmbLotedeGranelesparaAlmacen.DataSource = null;
                    if (DtaLoteGranelparaAlmacenGranel.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'";
                            coma = ",";
                        }

                        if (rdoGranefabrica.Checked == true)
                        {

                            ConexionMysql.llenaComboAutocomplit(ref  CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN (" + produccion + ") and  id_fabrica='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");
                        }
                        else
                        {

                            ConexionMysql.llenaComboAutocomplit(ref  CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN (" + produccion + ") and  id_envasadora='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

                        }

                    }
                    else
                    {

                        if (rdoGranefabrica.Checked == true)
                        {
                            ConexionMysql.llenaComboAutocomplit(ref  CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where  id_fabrica='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");
                        }
                        else
                        {

                            ConexionMysql.llenaComboAutocomplit(ref  CmbLotedeGranelesparaAlmacen, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='" + CmbGranelfabricaEnvasado.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnAgregarTanqueAlmacenGranel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoTanqueparaAlmacenGranel.Text == "")
                {
                    MessageBox.Show("No ha introducido un nombre de tanque");
                    txtNoTanqueparaAlmacenGranel.Focus();
                    return;
                }
                DataRow fila = dtsTanquesAlmacenAgranel.Tables["TANQUESALMACENGRANEL"].NewRow();
                fila["TANQUE"] = txtNoTanqueparaAlmacenGranel.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsTanquesAlmacenAgranel.Tables["TANQUESALMACENGRANEL"].Rows.Add(fila);
                txtNoTanqueparaAlmacenGranel.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtaTanqueAlmacenGranel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaTanqueAlmacenGranel.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaTanqueAlmacenGranel.Rows.RemoveAt(e.RowIndex);
                    dtsTanquesAlmacenAgranel.Tables["TANQUESALMACENGRANEL"].AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAbocadoAlmacen_ToggledChanged()
        {

            if (chkAbocadoAlmacen.Toggled == true)
            {
                txtIngredienteAlmacenGFE.Enabled = true;
                lblTituloIngredienteAmacen.Enabled = true;
            }
            else
            {
                txtIngredienteAlmacenGFE.Enabled = false;
                lblTituloIngredienteAmacen.Enabled = false;
                txtIngredienteAlmacenGFE.Text = "";
            }
        }


        private void limpiaAlmacenGraneles()
        {

            dtsTanquesAlmacenAgranel.Tables["TANQUESALMACENGRANEL"].Clear();

            txtNoLoteAlmacenGranel.Text = "";
            txtClvFqAlmacenGranel.Text = "";



        }


        private void BtnGuardarLoteAlmacenGranel_Click(object sender, EventArgs e)
        {
            try
            {

                if (CmbNoAlmacenGraneles.SelectedValue == null)
                {
                    MessageBox.Show("No ha seleccionado ninguna fabrica");
                    return;
                }
                if (DtaLoteGranelparaAlmacenGranel.Rows.Count == 0)
                {
                    MessageBox.Show("No ha seleccionado ningun lote");
                    return;
                }
                if (DtaTanqueAlmacenGranel.Rows.Count == 0)
                {
                    MessageBox.Show("No ha introduccido ningun tanque");
                    return;
                }
                if (txtNoLoteAlmacenGranel.Text == "")
                {
                    MessageBox.Show("No ha introduccido un lote");
                    txtNoLoteAlmacenGranel.Focus();
                    return;
                }

                DateTime local = DateTime.Now;
                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");

                double litros = 0;
                double grado_alcoholico = 0;
                double grado_alcoholico_para_suma = 0;

                //================================================================>>> Confirmacion de datos a ingresar <<<============
                string tipo = label115.Text;
                string f = CmbNoClienteAlmacenGranel.Text;
                string o = CmbNoAlmacenGraneles.Text;
                string p = "";

                string pp = "";
                string p3 = "";

                //string produccion = "";
                string coma = "";
                //--->>-Mustra la lista de los DatagredView
                for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                {
                    p += coma + "'" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["NO_LOTE"].Value + Environment.NewLine;
                    pp += coma + "'" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value + "'\n";
                    p3 += coma + "'" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["%_ALCOHOLICO"].Value + "'\n";
                    coma = "  ";
                }


                string q = "";
                ;
                //--->>-Mustra la lista de los DatagredView
                for (int x = 0; x < DtaTanqueAlmacenGranel.Rows.Count; x++)
                {
                    coma = "";
                    q += coma + "'" + DtaTanqueAlmacenGranel.Rows[x].Cells["TANQUE"].Value + "'\n";
                    coma = "  ";
                }
                string t = txtNoLoteAlmacenGranel.Text;
                string a = "No";
                string b = ".....";

                //---Muestra en el modal ei es abocado o no
                if (chkAbocadoAlmacen.Toggled == true)
                {

                    if (txtIngredienteAlmacenGFE.Text == "")
                    {
                        MessageBox.Show("Desbes escribir un ingrediente...");
                        return;
                    }


                    a = "Si";
                    b = txtIngredienteAlmacenGFE.Text;
                }



                string c = txtClvFqAlmacenGranel.Text;




                string dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + q + "!" + t + "!" + a + "!" + c + "!" + b;

                MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
                msg.granelEnvasadook(dto);
                msg.ShowDialog();

                if (msg.DialogResult == DialogResult.Cancel) { return; }
                else
                {
                    ///--- esta variable almacena el de done proviene el granel 1.-granel fabrica, 2.-granel envasado
                    int tipo_producto = 0;
                    if (rdoGranefabrica.Checked == true)
                    {
                        tipo_producto = 1;
                    }
                    else if (rdoGranelEnvasado.Checked == true)
                    {
                        tipo_producto = 2;
                    }


                    for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                    {
                      

                        litros += Math.Round(double.Parse(DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                        grado_alcoholico_para_suma += Math.Round(double.Parse(DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value.ToString()), 2) * Math.Round(double.Parse(DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["%_ALCOHOLICO"].Value.ToString()), 2);
                    }
                    grado_alcoholico = grado_alcoholico_para_suma / litros;

                    //obtenesmos el id maximo de la entrada a granel envasado

                    ObtenerIdMaximoAlmacenGranelEntrada();
                    if (DtaLoteGranelparaAlmacenGranel.Rows.Count == 1)
                    {


                        DataSet Datos = new DataSet();

                        if (rdoGranefabrica.Checked == true)
                        {
                           
                            ConexionMysql.llenaDataset(ref Datos, "SELECT  no_cliente, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente FROM granel_entrada where id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");

                            DataSet ids = new DataSet();

                            ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaLoteGranelparaAlmacenGranel.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_fabrica'");

                            foreach (DataRow row in ids.Tables[0].Rows)
                            {
                                ///--- inserta el id de la produccion---
                                string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_granel','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                                {
                                    return;
                                }
                            }




                        }
                        else
                        {

                            ConexionMysql.llenaDataset(ref Datos, "SELECT  no_cliente, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente FROM granel_entrada_envasado where id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");


                            DataSet ids = new DataSet();
                            ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaLoteGranelparaAlmacenGranel.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_envasado'");

                            foreach (DataRow row in ids.Tables[0].Rows)
                            {
                                ///--- inserta el id de la produccion---
                                string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_granel','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                                {
                                    return;
                                }
                            }





                        }

                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            //--- Valida si al ingresarlo se le agrega un abocante y le cambia la categoria---
                            if (chkAbocadoAlmacen.Toggled == true)
                            {
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,fecha_movimiento, id_verificador, actualizado) VALUES( '" + id_max_almacen_granel_entrada + "' ,'" + row["no_cliente"].ToString() + "','" + CmbNoAlmacenGraneles.SelectedValue + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + txtNoLoteAlmacenGranel.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + TxtFQEnvasado.Text + "','Abocado con','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + txtIngredienteAlmacenGFE.Text + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "'," + tipo_producto + ",NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                                {
                                    return;
                                }


                            }
                            else
                            {


                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,fecha_movimiento, id_verificador, actualizado) VALUES( '" + id_max_almacen_granel_entrada + "' ,'" + row["no_cliente"].ToString() + "','" + CmbNoAlmacenGraneles.SelectedValue + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + txtNoLoteAlmacenGranel.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + TxtFQEnvasado.Text + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "'," + tipo_producto + ",NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                                {
                                    return;
                                }
                            }
                        }

                        DataSet Datos2 = new DataSet();

                        if (rdoGranefabrica.Checked == true)
                        {
                            ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                        }
                        else
                        {

                            ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "'");

                        }
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {

                            ObtenerIdMaximoAlmacenGranelEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES('" + id_max_almacen_granel_ensamble + "', '" + id_max_almacen_granel_entrada + "' ,'" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaLoteGranelparaAlmacenGranel.Rows[0].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        string CategoriaMezcalComparar = "";
                        string claseMezcalComparar = "";
                        string CategoriaMezcal = "";
                        string claseMezcal = "";

                        int mzkl = 0;
                        int maartesanal = 0;
                        int mancetral = 0;

                        int des_con = 0;
                        int abocado_con = 0;
                        int boj = 0;
                        int madurado_vidrio = 0;
                        int reposado = 0;
                        int Añejo = 0;

                        int s_klss = 0;

                        string TxtIngredienteEnvasadoDB = "";
                        string ingredientecadena = "";


                        string sep = "";


                        for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                        {
                            if (rdoGranefabrica.Checked == true)
                            {
                                CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                                claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells
                                    ["ID_GRANEL_ENTRADA"].Value + "'");


                                DataSet ids = new DataSet();
                                ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_fabrica'");

                                foreach (DataRow row in ids.Tables[0].Rows)
                                {
                                    ///--- inserta el id de la produccion---
                                    string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_granel','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                                    {
                                        return;
                                    }
                                }



                            }
                            else
                            {

                                CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                                claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");



                                DataSet ids = new DataSet();
                                ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "' and tipo_instalacion='granel_fabrica'");

                                foreach (DataRow row in ids.Tables[0].Rows)
                                {
                                    ///--- inserta el id de la produccion---
                                    string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_granel','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                                    {
                                        return;
                                    }
                                }



                            }


                            //MessageBox.Show("la categoria es : " + CategoriaMezcal);

                            if (CategoriaMezcal == "Mezcal")
                            {
                                mzkl++;
                            }
                            else if (CategoriaMezcal == "Mezcal Artesanal")
                            {
                                maartesanal++;
                            }
                            else if (CategoriaMezcal == "Mezcal Ancestral")
                            {
                                mancetral++;
                            }


                            if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven") { boj++; }
                            else if (claseMezcal == "Madurado en vidrio") { madurado_vidrio++; }
                            else if (claseMezcal == "Reposado") { reposado++; }
                            else if (claseMezcal == "Añejo") { Añejo++; }
                            else if (claseMezcal == "Abocado con") { abocado_con++; }
                            else if (claseMezcal == "Destilado con") { des_con++; }



                        }//====FIn del for --- -

                        int[] cadclase = { boj, madurado_vidrio, reposado, Añejo, abocado_con, des_con };

                        //MessageBox.Show("es : " + cadclase);


                        for (int g = 0; g < cadclase.Length; g++)
                        {

                            if (cadclase[g] > 0)
                            {
                                s_klss++;
                                // if (cadclase[1] != 0) { }

                            }

                        }



                        // MessageBox.Show(" esto representa : " + s_klss);
                        //MessageBox.Show(" esto representa : " + klss);


                        if (s_klss > 1)
                        {

                            claseMezcal = "Cls_dif";
                        }
                        else if (s_klss == 1)
                        {
                            if (cadclase[0] > 0) { claseMezcal = "Blanco o Joven"; }
                            else if (cadclase[1] > 0) { claseMezcal = "Madurado en vidrio"; }
                            else if (cadclase[2] > 0) { claseMezcal = "Reposado"; }
                            else if (cadclase[3] > 0) { claseMezcal = "Añejo"; }
                            else if (cadclase[4] > 0) { claseMezcal = "Abocado con"; }
                            else if (cadclase[5] > 0) { claseMezcal = "Destilado con"; }
                        }
                        //MessageBox.Show("resultado : "+ claseMezcal);



                        if (claseMezcal == "Cls_dif")
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                        }

                        ///====================== -- INGREDIENTES -- ===================
                        ///entra si la clase es abocado con  o destilado con --- 

                        if (claseMezcal == "Abocado con" || claseMezcal == "Destilado con")
                        {

                            for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                            {


                                if (rdoGranefabrica.Checked == true)
                                {
                                    ingredientecadena = ConexionMysql.regresaCampoConsulta("SELECT ingrediente  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");

                                }
                                else
                                {

                                    ingredientecadena = ConexionMysql.regresaCampoConsulta("SELECT ingrediente  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                                }

                                //if (des_ingrediente != "")
                                //{
                                //des_con++;

                                TxtIngredienteEnvasadoDB += sep + " " + ingredientecadena;
                                sep = ",";
                                // MessageBox.Show("es : " + TxtIngredienteEnvasadoDB );
                                //}


                            }



                        }



                        // MessageBox.Show("es final : " + TxtIngredienteEnvasadoDB);



                        //========= Mezcal categoria

                        if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            //CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
                        {
                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                            //CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            // CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
                        {

                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            // CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral == 0 && mzkl == 0)
                        {
                            CategoriaMezcal = "Mezcal Artesanal";
                        }
                        else if (maartesanal == 0 && mancetral == 0 && mzkl > 0)
                        {
                            CategoriaMezcal = "Mezcal";
                        }
                        else if (maartesanal == 0 && mancetral > 0 && mzkl == 0)
                        {
                            CategoriaMezcal = "Mezcal Ancestral";
                        }

                        // MessageBox.Show("la categoria final es : " + CategoriaMezcal);

                        // MessageBox.Show("la clase es : " + claseMezcal);

                        if (chkAbocadoAlmacen.Toggled == true)
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen, fecha, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,fecha_movimiento, id_verificador, actualizado) VALUES( '" + id_max_almacen_granel_entrada + "' ,'" + CmbNoClienteAlmacenGranel.SelectedValue + "','" + CmbNoAlmacenGraneles.SelectedValue + "' ,now(),0,'" + txtNoLoteAlmacenGranel.Text + "','" + txtClvFqAlmacenGranel.Text + "','Abocado con','" + CategoriaMezcal + "','-' ,'" + txtIngredienteAlmacenGFE.Text + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "'," + tipo_producto + ",NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen, fecha, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes,grado_alcoholico_existente,tipo_ingreso,fecha_movimiento,id_verificador, actualizado) VALUES( '" + id_max_almacen_granel_entrada + "' ,'" + CmbNoClienteAlmacenGranel.SelectedValue + "','" + CmbNoAlmacenGraneles.SelectedValue + "' ,now(),0,'" + txtNoLoteAlmacenGranel.Text + "','" + txtClvFqAlmacenGranel.Text + "','" + claseMezcal + "','" + CategoriaMezcal + "','-' ,'" + TxtIngredienteEnvasadoDB + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "','" + litros + "','" + Math.Round(grado_alcoholico, 2) + "'," + tipo_producto + ",NOW(),'" + Usuario.IdUsuario + "',0)") == "Error")
                            {
                                return;
                            }

                        }//Fin del else chkAbocadoEnvasado

                        for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                        {
                            DataSet Datos = new DataSet();

                            if (rdoGranefabrica.Checked == true)
                            {
                                ConexionMysql.llenaDataset(ref Datos, "SELECT  id_planta,id_comun,id_predio,agave_coccion_kg FROM granel_entrada where id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            }
                            else
                            {
                                ConexionMysql.llenaDataset(ref Datos, "SELECT  id_planta,id_comun,id_predio,agave_coccion_kg FROM granel_entrada_envasado where id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            }


                            foreach (DataRow row in Datos.Tables[0].Rows)
                            {
                                if (row["id_planta"].ToString() == "0" && row["id_comun"].ToString() == "0")
                                {
                                    DataSet Datos2 = new DataSet();

                                    if (rdoGranefabrica.Checked == true)
                                    {

                                        ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                                    }
                                    else
                                    {

                                        ConexionMysql.llenaDataset(ref Datos2, "SELECT     id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");

                                    }


                                    foreach (DataRow row2 in Datos2.Tables[0].Rows)
                                    {
                                        ObtenerIdMaximoAlmacenGranelEnsamble();
                                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_almacen_granel_ensamble + "','" + id_max_almacen_granel_entrada + "' ,'" + row2["id_comun"].ToString() + "','" + row2["id_planta"].ToString() + "','" + row2["id_predio"].ToString() + "','" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value.ToString() + "','" + row2["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                        {
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    ObtenerIdMaximoAlmacenGranelEnsamble();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_almacen_granel_ensamble + "','" + id_max_almacen_granel_entrada + "' ,'" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }



                    //marca la salida del producto y actualiza existencia de granel fabrica

                    for (int x = 0; x < DtaLoteGranelparaAlmacenGranel.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGranelSalida();

                        if (rdoGranefabrica.Checked == true)
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_salida(id_granel_salida,id_granel_entrada,id_solicitud,id_almacen_granel_entrada,litros,grado_alcoholico,id_verificador) VALUES('" + id_max_granel_salida + "', '" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "',0,'" + id_max_almacen_granel_entrada + "','" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value + "','" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["%_ALCOHOLICO"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }

                            string litros_granel = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");



                            double existencia = Math.Round(double.Parse(litros_granel), 2) - Math.Round(double.Parse(DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value.ToString()), 2);

                            if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada SET lts_existentes=" + existencia + ",actualizado=0 WHERE id_granel_entrada='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            /// --  si el radiobutton esta activo entra aqui
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_salida(id_granel_salida,id_granel_entrada_envasado,id_solicitud,id_almacen_granel_entrada,litros,grado_alcoholico,id_verificador) VALUES('" + id_max_granel_salida + "', '" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "',0,'" + id_max_almacen_granel_entrada + "','" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value + "','" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["%_ALCOHOLICO"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }

                            string litros_granel = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");



                            double existencia = Math.Round(double.Parse(litros_granel), 2) - Math.Round(double.Parse(DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["LITROS"].Value.ToString()), 2);

                            if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=" + existencia + ",actualizado=0 WHERE id_granel_entrada_envasado='" + DtaLoteGranelparaAlmacenGranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'") == "Error")
                            {
                                return;
                            }
                        }


                    }/// --  fin del for -- 


                    for (int x = 0; x < DtaTanqueAlmacenGranel.Rows.Count; x++)
                    {
                        ObtenerIdMaximoAlmacenGranelTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,id_verificador) VALUES( '" + id_max_almacen_granel_tanque + "','" + id_max_almacen_granel_entrada + "','" + DtaTanqueAlmacenGranel.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }
                    //  LimpiarGranelEnvasado();
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Exito");


                    CmbNoClienteAlmacenGranel_SelectedIndexChanged(sender, e);

                    chkAbocadoAlmacen.Toggled = false;

                    txtIngredienteAlmacenGFE.Enabled = false;
                    lblTituloIngredienteAmacen.Enabled = false;

                    limpiaAlmacenGraneles();

                    //Veri_movimientos.produccion = true;

                }//-->>Fin del else de DialogResult--



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }///--- Fin BtnGuardarLoteAlmacenGranel_Click --- 


        private void btnTrasladoaAlmacenGraneles_Click(object sender, EventArgs e)
        {
            FrmTransaccion frm = new FrmTransaccion();
            frm.no_cliente = CmbNoClienteAlmacenGranel.SelectedValue.ToString();
            if (CmbNoAlmacenGraneles.Items.Count == 0)
            {
                MessageBox.Show("No tienes un almacen de destino, agrega una para poder realizar el movimiento");
                return;
            }
            frm.id_instalacion = CmbNoAlmacenGraneles.SelectedValue.ToString();
            frm.tipo_instalacion = "almacenG";
            frm.ShowDialog();
            CmbNoAlmacenGraneles_SelectedIndexChanged(null, null);
            CmbGranelfabricaEnvasado_SelectedIndexChanged(null, null);
        }

        private void btnNuevoLoteAlmacenGraneles_Click(object sender, EventArgs e)
        {
            if (CmbNoAlmacenGraneles.Items.Count == 0)
            {
                MessageBox.Show("No tienes un almacen de destino, agrega uno para poder realizar el movimiento");
                return;
            }
            FrmGranelNuevo frm = new FrmGranelNuevo();
            frm.no_cliente = CmbNoClienteAlmacenGranel.SelectedValue.ToString();
            frm.tipo = "almacen";
            frm.id_almacen = CmbNoAlmacenGraneles.SelectedValue.ToString();
            frm.ShowDialog();
            CmbNoClienteAlmacenGranel_SelectedIndexChanged(sender, e);
        }

        private void tabControl6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl6.SelectedTab == tabPage18)
            {
                BanderaGranelAlmacen = true;
                BanderaBarricaAlmacen = false;
                BanderaVidrioAlmacen = false;
                CmbNoAlmacenGraneles_SelectedIndexChanged(null, null);
            }
            else if (tabControl6.SelectedTab == tabPage19)
            {
                BanderaGranelAlmacen = false;
                BanderaBarricaAlmacen = true;
                BanderaVidrioAlmacen = false;
                CmbNoAlmacenGraneles_SelectedIndexChanged(null, null);
            }
            else if (tabControl6.SelectedTab == tabPage20)
            {
                BanderaGranelAlmacen = false;
                BanderaBarricaAlmacen = false;
                BanderaVidrioAlmacen = true;
                CmbNoAlmacenGraneles_SelectedIndexChanged(null, null);
            }
        }

        private void rdoGranelEnvasado_CheckedChanged(object sender, EventArgs e)
        {


            if (DtaLoteGranelparaAlmacenGranel.ColumnCount > 1)
            {

                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Clear();
            }
            /* if (rdoGranefabrica.Checked == false)
             {
                // CmbFabricaEnvasadora.Enabled = false;
                 TxtMaestroMezcaleroEnvasadora.Enabled = false;
                 CmbFabricaEnvasadora.DataSource = null;
                 TxtMaestroMezcaleroEnvasadora.Text = "";
                 CmbFabricaEnvasadora.DataSource = null;
             }*/
            if (rdoGranelEnvasado.Checked == true)
            {

                CmbGranelfabricaEnvasado.DataSource = null;
                txtResponsableFabricaEnvasado.Text = "";
                //CmbFabricaEnvasadora.DataSource = null;
                ConexionMysql.llenaCombo(ref CmbGranelfabricaEnvasado, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteAlmacenGranel.SelectedValue + "'", "id_envasadora", "envasadora");
                if (Usuario.EnvasadoraSeleccionada != "0")
                {
                    CmbGranelfabricaEnvasado.SelectedValue = Usuario.EnvasadoraSeleccionada;
                }
            }


        }

        private void rdoGranefabrica_CheckedChanged(object sender, EventArgs e)
        {



            if (DtaLoteGranelparaAlmacenGranel.ColumnCount > 1)
            {
                dtsProduccionParaGuardarAlmacenAgranel.Tables["PRODUCCIONPARAGUARDARALMACENAGRANEL"].Clear();
            }
            if (rdoGranefabrica.Checked == true)
            {

                CmbGranelfabricaEnvasado.DataSource = null;
                txtResponsableFabricaEnvasado.Text = "";
                ConexionMysql.llenaCombo(ref CmbGranelfabricaEnvasado, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteAlmacenGranel.SelectedValue + "'", "id_fabrica", "fabrica");
                if (Usuario.FabricaSeleccionada != "0")
                {
                    CmbGranelfabricaEnvasado.SelectedValue = Usuario.FabricaSeleccionada;
                }

            }
        }

        private void DtaProductoAgranelAlmacen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoAgranelAlmacen.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosGranel frm = new FrmMovimientosGranel();
                    frm.id_granel_entrada = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ALMACEN"].Value.ToString();
                    frm.lts_existentes = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico_existente = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.no_lote = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.categoria = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.clase = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.fq = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    //frm.abocante = DtaProductoAgranel.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    //frm.ingrediente = DtaProductoAgranel.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteAlmacenGranel.SelectedValue.ToString();
                    frm.id_almacen = CmbNoAlmacenGraneles.SelectedValue.ToString();
                    frm.tipo = "almacen";
                    frm.ShowDialog();
                    CmbNoClienteAlmacenGranel_SelectedIndexChanged(sender, e);
                }
                else if (DtaProductoAgranelAlmacen.Columns[e.ColumnIndex].Name == "NO_LOTE")
                {

                    editar.FrmCambioNombre frm = new editar.FrmCambioNombre();
                    frm.id_lote = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ALMACEN"].Value.ToString();
                    frm.no_lote_actual = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.tipo = "almacen";
                    frm.ShowDialog();
                    CmbNoClienteAlmacenGranel_SelectedIndexChanged(sender, e);

                }
                else if (DtaProductoAgranelAlmacen.Columns[e.ColumnIndex].Name == "NO_TANQUE")
                {

                    editar.FrmCambioTanques frm = new editar.FrmCambioTanques();
                    frm.id_lote = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ALMACEN"].Value.ToString();
                    frm.no_lote = DtaProductoAgranelAlmacen.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.tipo = "almacen";
                    frm.ShowDialog();
                    CmbNoClienteAlmacenGranel_SelectedIndexChanged(sender, e);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtaProductoBarricaAlmacen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoBarricaAlmacen.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosBarrica frm = new FrmMovimientosBarrica();
                    frm.fecha = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
                    frm.id_granel_movimiento = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["ID_ALMACEN_GRANEL_MOVIMIENTOS"].Value.ToString();
                    frm.id_granel_produccion = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ALMACEN"].Value.ToString();
                    frm.folio = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["FOLIO"].Value.ToString();
                    frm.no_lote = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.no_barricas = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["NO_BARRICAS"].Value.ToString();
                    frm.categoria = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.litros = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.maguey = DtaProductoBarricaAlmacen.Rows[e.RowIndex].Cells["ESPECIE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteAlmacenGranel.SelectedValue.ToString();
                    frm.tipo = "almacen";
                    //"ESPECIE"
                    frm.ShowDialog();
                    CmbNoClienteAlmacenGranel_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DtaProductoVidrioAlmacen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoVidrioAlmacen.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientosVidrio frm = new FrmMovimientosVidrio();
                    frm.fecha = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["FECHA"].Value.ToString();
                    frm.id_granel_movimiento = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["ID_ALMACEN_GRANEL_MOVIMIENTOS"].Value.ToString();
                    frm.id_granel_produccion = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["ID_PRODUCCION_GRANEL_ALMACEN"].Value.ToString();
                    frm.folio = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["FOLIO"].Value.ToString();
                    frm.no_lote = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.no_contenedores = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["NO_CONTENEDORES"].Value.ToString();
                    frm.categoria = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.litros = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.maguey = DtaProductoVidrioAlmacen.Rows[e.RowIndex].Cells["ESPECIE"].Value.ToString();
                    frm.no_cliente = CmbNoClienteAlmacenGranel.SelectedValue.ToString();
                    frm.tipo = "almacen";
                    frm.ShowDialog();
                    CmbNoClienteAlmacenGranel_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtBuscarloteEnAlmacenGranel_TextChanged(object sender, EventArgs e)
        {
            if (BanderaGranelAlmacen == true)
            {
                funcion_buscar(DtaProductoAgranelAlmacen, txtBuscarloteEnAlmacenGranel);

            }
            else if (BanderaBarricaAlmacen == true)
            {

                funcion_buscar(DtaProductoBarricaAlmacen, txtBuscarloteEnAlmacenGranel);

            }
            else if (BanderaVidrioAlmacen == true)
            {
                funcion_buscar(DtaProductoVidrioAlmacen, txtBuscarloteEnAlmacenGranel);

            }
        }

        /// =========================== Inicia Almacen de Envasado ================  
        private void CmbNoClienteBodegaEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtsAlmacen_Envasado.Clear();
            dtsProductoAlmacenEnvasado.Clear();
            dtsProductoAlmacenEnvasadoNoTerminado.Clear();
            dtsProductoAlmacenEnvasadoSalio.Clear();
            /* ChekMaquila.Checked = false;
             LblCliente.Visible = false;
             LblMaquilaCliente.Visible = false;*/
            cmbMarcaEnvasadoparaAlmacen.DataSource = null;
            //ConexionMysql.llenaCombo(ref cmbMarcaEnvasadoparaAlmacen, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,marca FROM marcas  where no_cliente ='" + CmbNoClienteBodegaEnvasado.SelectedValue + "' ORDER BY cve_marca ASC", "id", "marca");




            //}

            cmbBodegaEnvasado.DataSource = null;
            cmbLoteparaAlmacen_Envasado.DataSource = null;
            txtResponsableBodegaEnvasado.Text = "";


            //string tipoalmacen = "---Elije una opcion---";



            // cmbTipoAlmacen.Items.Insert(1, "Granel Fabrica");
            //cmbTipoAlmacen.Items.Insert(2, "Granel envasado");
            // cmbTipoAlmacen.Items.Insert(3, "Envasado");
            //cmbBodegaEnvasado.Items.Clear();

            /// ---- tipos de graneles 


            /*if (cmbTipoAlmacen.Text == "Graneles")
                {
                    lblTituloAlmacen.Text = "Granel";
                    /// cmbBodegaEnvasado.Items.Clear();
                    ConexionMysql.llenaCombo(ref cmbBodegaEnvasado, "SELECT bodega_envasado,id_bodega_envasado FROM bodega_envasado_encargado where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "' AND tipo_bodega=1", "id_bodega_envasado", "bodega_envasado");
                                    } 
            */
            /*else if( cmbTipoAlmacen.Text == "Granel envasado"){
            lblTituloAlmacen.Text = "Granel Envasado";
            //cmbBodegaEnvasado.Items.Clear();
            ConexionMysql.llenaCombo(ref cmbBodegaEnvasado, "SELECT bodega_envasado,id_bodega_envasado FROM bodega_envasado_encargado where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "' AND tipo_bodega=2", "id_bodega_envasado", "bodega_envasado");
                    
        }*/
            // else if (cmbTipoAlmacen.Text == "Envasado")
            // {
            // lblTituloAlmacen.Text = "Envasado";
            //cmbBodegaEnvasado.Items.Clear();
            ConexionMysql.llenaCombo(ref cmbBodegaEnvasado, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "' AND tipo_almacen=2", "id_almacen", "almacen");

            //}

            /********** if (cmbBodegaEnvasado.Items.Count == 0)
             {
                 Usuario.Bodega_EnvasadoSeleccionada = "0";
             }

             if (cmbBodegaEnvasado.Items.Count != 0)
             {
                 Usuario.Bodega_EnvasadoSeleccionada = cmbBodegaEnvasado.SelectedValue.ToString();
             }************/






            if (Usuario.Bodega_EnvasadoSeleccionada != "0")
            {
                cmbBodegaEnvasado.SelectedValue = Usuario.Bodega_EnvasadoSeleccionada;
            }


            /*ConexionMysql.llenaCombo(ref cmbBodegaEnvasado, "SELECT id_bodega_envasado,bodega_envasado FROM bodega_envasado_encargado where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "'", "id_bodega_envasado", "bodega_envasado");
            if (Usuario.Bodega_EnvasadoSeleccionada != "0")
            {
                cmbBodegaEnvasado.SelectedValue = Usuario.Bodega_EnvasadoSeleccionada;
            }*/

            cmbEnvasadoraAlmacen.DataSource = null;
            txtMaestroFabricaBodega.Text = "";

            txtMarcaEnvasado.Text = "";
            //if (RbtnFabrica.Checked == true)
            //{
            /********* ConexionMysql.llenaCombo(ref cmbFabricaBodega, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "'", "id_fabrica", "fabrica");
             if (Usuario.FabricaSeleccionada != "0")
             {
                 cmbFabricaBodega.SelectedValue = Usuario.FabricaSeleccionada;
             }
         ***************/

            ConexionMysql.llenaCombo(ref cmbEnvasadoraAlmacen, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "'", "id_envasadora", "envasadora");


            if (Usuario.EnvasadoraSeleccionada != "0")
            {
                cmbEnvasadoraAlmacen.SelectedValue = Usuario.EnvasadoraSeleccionada;
            }

        }


        private void cmbBodegaEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbBodegaEnvasado.SelectedValue != null)
            {
                txtResponsableBodegaEnvasado.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  almacen_encargado  WHERE id_almacen='" + cmbBodegaEnvasado.SelectedValue + "'");

                // limpia_envasado();

                //cmbLoteparaAlmacen_Envasado.DataSource = null;
                //MessageBox.Show("2-Escoge tipo almacen envasado: AE:" + BanderaAlmacenEnvasado + "|AES:" + BanderaAlmacenEnvasadoSalio + "|AENT:" + BanderaAlmacenEnvasadoNoTerminado);


                if (BanderaAlmacenEnvasadoNoTerminado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT almacen_envasado_entrada.id_almacen_envasado_entrada,almacen_envasado_entrada.no_cliente, DATE_FORMAT(almacen_envasado_entrada.fecha, '%d/%m/%Y') as fecha , almacen_envasado_entrada.no_lote, almacen_envasado_entrada.fq, almacen_envasado_entrada.clase, almacen_envasado_entrada.categoria, almacen_envasado_entrada.abocante, almacen_envasado_entrada.ingrediente, almacen_envasado_entrada.unidad_medida, almacen_envasado_entrada.contenido_por_botella, almacen_envasado_entrada.litros, almacen_envasado_entrada.grado_alcoholico,almacen_envasado_entrada.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,   GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_envasado_entrada ASC ) as ensamble_maguey FROM almacen_envasado_entrada  LEFT JOIN existenciaplanta ON almacen_envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON almacen_envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN  ( SELECT almacen_envasado_ensamble.id_almacen_envasado_entrada,almacen_envasado_ensamble.litros,almacen_envasado_ensamble.agave_coccion_kg,comun.nombre  FROM almacen_envasado_ensamble  INNER JOIN existenciaplanta ON almacen_envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by almacen_envasado_ensamble.id_almacen_envasado_entrada asc, almacen_envasado_ensamble.litros desc, almacen_envasado_ensamble.agave_coccion_kg desc)  TABLA  ON almacen_envasado_entrada.id_almacen_envasado_entrada=TABLA.id_almacen_envasado_entrada   LEFT JOIN  (SELECT almacen_envasado_ensamble.id_almacen_envasado_entrada,almacen_envasado_ensamble.id_planta,almacen_envasado_ensamble.id_predio,almacen_envasado_ensamble.litros,almacen_envasado_ensamble.agave_coccion_kg,comun3.nombre FROM almacen_envasado_ensamble LEFT JOIN existenciaplanta ON almacen_envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun OR almacen_envasado_ensamble.id_comun = comun3.id_comun ORDER BY almacen_envasado_ensamble.litros DESC , almacen_envasado_ensamble.agave_coccion_kg DESC) AS maguey ON almacen_envasado_entrada.id_almacen_envasado_entrada = maguey.id_almacen_envasado_entrada   WHERE almacen_envasado_entrada.id_almacen='" + cmbBodegaEnvasado.SelectedValue + "' and almacen_envasado_entrada.botellas_existentes > 0  and almacen_envasado_entrada.id_marca='0' GROUP BY almacen_envasado_entrada.id_almacen_envasado_entrada ");
                    DataRow fila;
                    dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].NewRow();
                        fila["ID_PRODUCCION_ENVASADO"] = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CANTIDAD"] = Convert.ToString(row["contenido_por_botella"]);
                        fila["LITROS"] = Convert.ToString(row["litros"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);

                        fila["BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Rows.Add(fila);
                    }
                }


                else if (BanderaAlmacenEnvasado == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT marcas.marca,almacen_envasado_entrada.id_almacen_envasado_entrada,almacen_envasado_entrada.no_cliente, DATE_FORMAT(almacen_envasado_entrada.fecha, '%d/%m/%Y') as fecha , almacen_envasado_entrada.no_lote, almacen_envasado_entrada.fq, almacen_envasado_entrada.clase, almacen_envasado_entrada.categoria, almacen_envasado_entrada.abocante, almacen_envasado_entrada.ingrediente, almacen_envasado_entrada.unidad_medida, almacen_envasado_entrada.contenido_por_botella, almacen_envasado_entrada.litros, almacen_envasado_entrada.grado_alcoholico, almacen_envasado_entrada.grado_alcoholico_etiqueta, almacen_envasado_entrada.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_envasado_entrada ASC ) as ensamble_maguey FROM almacen_envasado_entrada  LEFT JOIN existenciaplanta ON almacen_envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON almacen_envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN  ( SELECT almacen_envasado_ensamble.id_almacen_envasado_entrada,almacen_envasado_ensamble.litros,almacen_envasado_ensamble.agave_coccion_kg,comun.nombre  FROM almacen_envasado_ensamble  INNER JOIN existenciaplanta ON almacen_envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by almacen_envasado_ensamble.id_almacen_envasado_entrada asc, almacen_envasado_ensamble.litros desc, almacen_envasado_ensamble.agave_coccion_kg desc)  TABLA  ON almacen_envasado_entrada.id_almacen_envasado_entrada=TABLA.id_almacen_envasado_entrada   LEFT JOIN  (SELECT almacen_envasado_ensamble.id_almacen_envasado_entrada,almacen_envasado_ensamble.id_planta,almacen_envasado_ensamble.id_predio,almacen_envasado_ensamble.litros,almacen_envasado_ensamble.agave_coccion_kg,comun3.nombre FROM almacen_envasado_ensamble LEFT JOIN existenciaplanta ON almacen_envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun OR almacen_envasado_ensamble.id_comun = comun3.id_comun ORDER BY almacen_envasado_ensamble.litros DESC , almacen_envasado_ensamble.agave_coccion_kg DESC) AS maguey ON almacen_envasado_entrada.id_almacen_envasado_entrada = maguey.id_almacen_envasado_entrada  INNER JOIN marcas ON SUBSTRING(almacen_envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(almacen_envasado_entrada.id_marca,7,2)=marcas.cve_marca  WHERE almacen_envasado_entrada.id_almacen='" + cmbBodegaEnvasado.SelectedValue + "' and almacen_envasado_entrada.botellas_existentes > 0 GROUP BY almacen_envasado_entrada.id_almacen_envasado_entrada ");
                    
                    DataRow fila;
                    dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].NewRow();
                        fila["ID_PRODUCCION_ENVASADO"] = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["MARCA"] = Convert.ToString(row["marca"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CANTIDAD"] = Convert.ToString(row["contenido_por_botella"]);
                        fila["LITROS"] = Convert.ToString(row["litros"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["%_ALCOHOLICO_ETIQUETA"] = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        fila["BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Rows.Add(fila);
                    }
                }
                else if (BanderaAlmacenEnvasadoSalio == true)
                {
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "  SELECT almacen_envasado_entrada.id_planta,almacen_envasado_entrada.id_predio,almacen_envasado_entrada.id_marca,marcas.marca,almacen_envasado_entrada.id_almacen,almacen_envasado_movimientos.id_almacen_envasado_movimientos,almacen_envasado_movimientos.no_cliente, DATE_FORMAT(almacen_envasado_movimientos.fecha, '%d/%m/%Y') as fecha ,almacen_envasado_movimientos.destino,almacen_envasado_entrada.no_lote,almacen_envasado_entrada.fq,almacen_envasado_entrada.clase,almacen_envasado_entrada.categoria,almacen_envasado_entrada.abocante,almacen_envasado_entrada.ingrediente,almacen_envasado_entrada.unidad_medida,almacen_envasado_entrada.contenido_por_botella,almacen_envasado_entrada.litros,almacen_envasado_entrada.grado_alcoholico, almacen_envasado_entrada.grado_alcoholico_etiqueta,almacen_envasado_movimientos.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin,GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_almacen_envasado_entrada ASC ) as ensamble_maguey FROM almacen_envasado_entrada  inner  JOIN almacen_envasado_movimientos ON almacen_envasado_entrada.id_almacen_envasado_entrada=almacen_envasado_movimientos.id_almacen_envasado_entrada LEFT JOIN existenciaplanta ON almacen_envasado_entrada.id_planta=existenciaplanta.id_plantas  LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON almacen_envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN ( SELECT almacen_envasado_ensamble.id_almacen_envasado_entrada,almacen_envasado_ensamble.litros,almacen_envasado_ensamble.agave_coccion_kg,comun.nombre  FROM almacen_envasado_ensamble  INNER JOIN existenciaplanta ON almacen_envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by almacen_envasado_ensamble.id_almacen_envasado_entrada asc, almacen_envasado_ensamble.litros desc, almacen_envasado_ensamble.agave_coccion_kg desc) TABLA   ON almacen_envasado_entrada.id_almacen_envasado_entrada=TABLA.id_almacen_envasado_entrada  LEFT JOIN  (SELECT almacen_envasado_ensamble.id_almacen_envasado_entrada,almacen_envasado_ensamble.id_planta,almacen_envasado_ensamble.id_predio,almacen_envasado_ensamble.litros,almacen_envasado_ensamble.agave_coccion_kg,comun3.nombre FROM almacen_envasado_ensamble LEFT JOIN existenciaplanta ON almacen_envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun OR almacen_envasado_ensamble.id_comun = comun3.id_comun ORDER BY almacen_envasado_ensamble.litros DESC , almacen_envasado_ensamble.agave_coccion_kg DESC) AS maguey ON almacen_envasado_entrada.id_almacen_envasado_entrada = maguey.id_almacen_envasado_entrada   INNER JOIN marcas ON SUBSTRING(almacen_envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(almacen_envasado_entrada.id_marca,7,2)=marcas.cve_marca  WHERE almacen_envasado_entrada.id_almacen='" + cmbBodegaEnvasado.SelectedValue + "' and almacen_envasado_movimientos.tipo in('salida','cambio') and almacen_envasado_movimientos.destino in('Nacional','Exportacion','Promocion')  and almacen_envasado_movimientos.botellas_existentes > 0 GROUP BY almacen_envasado_movimientos.id_almacen_envasado_movimientos");
                    // ConexionMysql.llenaDataset(ref Datos, "SELECT * FROM view_envasado_salio WHERE id_envasadora='" + CmbEnvasadoraEnvasadora.SelectedValue + "'");

                    DataRow fila;
                    dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Rows.Clear();
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fila = dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].NewRow();
                        fila["ID_ALMACEN_ENVASADO_MOVIMIENTOS"] = Convert.ToString(row["id_almacen_envasado_movimientos"]);
                        fila["ID_MARCA"] = Convert.ToString(row["id_marca"]);
                        fila["ID_ALMACEN"] = Convert.ToString(row["id_almacen"]);
                        fila["ID_PLANTA"] = Convert.ToString(row["id_planta"]);
                        fila["ID_PREDIO"] = Convert.ToString(row["id_predio"]);
                        fila["FECHA"] = Convert.ToString(row["fecha"]);
                        fila["MARCA"] = Convert.ToString(row["marca"]);
                        fila["NO_LOTE"] = Convert.ToString(row["no_lote"]);
                        fila["DESTINO"] = Convert.ToString(row["destino"]);
                        if (Convert.ToString(row["maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey"]);
                        }
                        else if (Convert.ToString(row["maguey_sin"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["maguey_sin"]);
                        }
                        else if (Convert.ToString(row["ensamble"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble"]);
                        }
                        else if (Convert.ToString(row["ensamble_maguey"]) != "")
                        {
                            fila["ESPECIE"] = Convert.ToString(row["ensamble_maguey"]);
                        }
                        fila["CLAVE_FQ"] = Convert.ToString(row["fq"]);
                        fila["CLASE"] = Convert.ToString(row["clase"]);
                        fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                        fila["ABOCANTE"] = Convert.ToString(row["abocante"]);
                        fila["INGREDIENTE"] = Convert.ToString(row["ingrediente"]);
                        fila["MEDIDA"] = Convert.ToString(row["unidad_medida"]);
                        fila["CANTIDAD"] = Convert.ToString(row["contenido_por_botella"]);
                        fila["LITROS"] = Convert.ToString(row["litros"]);
                        fila["%_ALCOHOLICO"] = Convert.ToString(row["grado_alcoholico"]);
                        fila["%_ALCOHOLICO_ETIQUETA"] = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        fila["BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                        fila["MOVIMIENTOS"] = ConvertImageToByteArray(Properties.Resources.move, System.Drawing.Imaging.ImageFormat.Png);
                        dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Rows.Add(fila);
                    }
                }
            }
        }

        private void cmbEnvasadoraAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbLoteparaAlmacen_Envasado.DataSource = null;
            dtsAlmacen_Envasado.Clear();
            if (cmbEnvasadoraAlmacen.SelectedValue != null)
            {

                ConexionMysql.llenaComboAutocomplit(ref cmbLoteparaAlmacen_Envasado, "SELECT  CONCAT(no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' a ',if (grado_alcoholico_etiqueta is null OR grado_alcoholico_etiqueta ='0','0',grado_alcoholico_etiqueta) ,' % vol.')) As envasado, id_envasado_entrada   FROM envasado_entrada  where id_envasadora='" + cmbEnvasadoraAlmacen.SelectedValue + "'  AND botellas_existentes > 0  order by id_envasado_entrada asc", "id_envasado_entrada", "envasado");



                txtMaestroFabricaBodega.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + cmbEnvasadoraAlmacen.SelectedValue + "';");
            }

        }

        private void btnAgregarBodega_Click(object sender, EventArgs e)
        {
            FrmNuevoAlmacen bodega = new FrmNuevoAlmacen();
            bodega.no_cliente = CmbNoClienteBodegaEnvasado.SelectedValue.ToString();
            bodega.tipo_bodega = "2";
            bodega.ShowDialog();


            ConexionMysql.llenaCombo(ref cmbBodegaEnvasado, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + CmbNoClienteBodegaEnvasado.SelectedValue + "' AND tipo_almacen=2", "id_almacen", "almacen");
            if (Usuario.Bodega_EnvasadoSeleccionada != "0")
            {
                cmbBodegaEnvasado.SelectedValue = Usuario.Bodega_EnvasadoSeleccionada;
            }



        }

        //crea la tabla de  producto envasado no terminado
        private void addTablaProductoAlmacenEnvasadoNoTerminado()
        {
            dtsProductoAlmacenEnvasadoNoTerminado = new DataSet();
            dtsProductoAlmacenEnvasadoNoTerminado.Tables.Add("PRODUCTOALMACENENVASADONOTERMINADO");
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("ID_PRODUCCION_ENVASADO", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("MEDIDA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoAlmacenEnvasadoNoTerminado.DataSource = dtsProductoAlmacenEnvasadoNoTerminado.Tables["PRODUCTOALMACENENVASADONOTERMINADO"];
            DtaProductoAlmacenEnvasadoNoTerminado.Columns[1].Visible = false;
            DtaProductoAlmacenEnvasadoNoTerminado.Columns[7].Visible = false;
            // DtaProductoAlmacenEnvasadoNoTerminado.Columns[13].Visible = false;
        }



        //crea la tabla de  producto envasado
        private void addTablaProductoAlmacenEnvasado()
        {
            dtsProductoAlmacenEnvasado = new DataSet();
            dtsProductoAlmacenEnvasado.Tables.Add("PRODUCTOALMACENENVASADO");
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("ID_PRODUCCION_ENVASADO", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("MEDIDA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("%_ALCOHOLICO_ETIQUETA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoAlmacenEnvasado.DataSource = dtsProductoAlmacenEnvasado.Tables["PRODUCTOALMACENENVASADO"];
            DtaProductoAlmacenEnvasado.Columns[1].Visible = false;
            DtaProductoAlmacenEnvasado.Columns[8].Visible = false;
            DtaProductoAlmacenEnvasado.Columns[13].Visible = false;
        }


        //crea la tabla de  producto envsado salio
        private void addTablaProductoAlmacenEnvasadoSalio()
        {
            dtsProductoAlmacenEnvasadoSalio = new DataSet();
            dtsProductoAlmacenEnvasadoSalio.Tables.Add("PRODUCTOALMACENENVASADOSALIO");
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("FECHA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("ID_ALMACEN_ENVASADO_MOVIMIENTOS", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("ID_ALMACEN", Type.GetType("System.String"));//--- Agregado reciente mente
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("ID_MARCA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("MARCA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("DESTINO", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("ESPECIE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("CLAVE_FQ", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("MEDIDA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("CANTIDAD", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("LITROS", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("%_ALCOHOLICO_ETIQUETA", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"].Columns.Add("MOVIMIENTOS", Type.GetType("System.Byte[]"));
            DtaProductoAlmacenEnvasadoSalio.DataSource = dtsProductoAlmacenEnvasadoSalio.Tables["PRODUCTOALMACENENVASADOSALIO"];
            DtaProductoAlmacenEnvasadoSalio.Columns[1].Visible = false;
            DtaProductoAlmacenEnvasadoSalio.Columns[2].Visible = false;
            DtaProductoAlmacenEnvasadoSalio.Columns[3].Visible = false;
            DtaProductoAlmacenEnvasadoSalio.Columns[4].Visible = false;
            DtaProductoAlmacenEnvasadoSalio.Columns[5].Visible = false;
            DtaProductoAlmacenEnvasadoSalio.Columns[13].Visible = false;
            DtaProductoAlmacenEnvasadoSalio.Columns[18].Visible = false;
        }



        private void addtablaEnvasadoparaAlmacenEnv()
        {
            dtsAlmacen_Envasado = new DataSet();
            dtsAlmacen_Envasado.Tables.Add("ENVASADOPARAGUARDARALMACENENVASADO");
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("NO_LOTE", Type.GetType("System.String"));
            //dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("NO_LOTE_ENVASA", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("ID_ENVASADO_ENTRADA", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("FQ", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("INGREDIENTE", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("ID_COMUN", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("CONTENIDO_BOTELLA", Type.GetType("System.String"));
            // dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("ETIQUETADO_COMO", Type.GetType("System.String"));
            //dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("BOTELLAS_INICIALES", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("ID_MARCA", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("%_VOL_ETIQUETA", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("UNIDAD_MEDIDA", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("BOTELLAS", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("%_ALCOHOLICO", Type.GetType("System.String"));
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            dtaLoteparaAlmacen_Envasado.DataSource = dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"];
            dtaLoteparaAlmacen_Envasado.Columns[1].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[2].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[3].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[4].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[5].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[6].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[7].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[8].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[9].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[10].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[11].Visible = false;
            //dtaLoteparaAlmacen_Envasado.Columns[12].Visible = false;
            dtaLoteparaAlmacen_Envasado.Columns[13].Visible = false;


        }


        private void addTablaHologramasparaAlmacen()
        {
            dtsHologramasparaAlmacen = new DataSet();
            dtsHologramasparaAlmacen.Tables.Add("HOLOGRAMASPARAALMACEN");
            dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"].Columns.Add("INICIO", Type.GetType("System.String"));
            dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"].Columns.Add("FIN", Type.GetType("System.String"));
            dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"].Columns.Add("SERIE", Type.GetType("System.String"));
            dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaHologramasEnvasadoParaALmacen.DataSource = dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"];

        }




        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("Escoge tipo almacen envasado: "+tabControl3.SelectedTab + ":" + tabPage9 + ":" + tabPage10 + ":" + tabPage17);
            if (tabControl3.SelectedTab == tabPage9)
            {
                BanderaAlmacenEnvasado = false;
                BanderaAlmacenEnvasadoSalio = false;
                BanderaAlmacenEnvasadoNoTerminado = true;
                cmbBodegaEnvasado_SelectedIndexChanged(null, null);
            }
            else if (tabControl3.SelectedTab == tabPage10)
            {
                BanderaAlmacenEnvasado = true;
                BanderaAlmacenEnvasadoSalio = false;
                BanderaAlmacenEnvasadoNoTerminado = false;
                cmbBodegaEnvasado_SelectedIndexChanged(null, null);
            }
            else if (tabControl3.SelectedTab == tabPage17)
            {
                BanderaAlmacenEnvasado = false;
                BanderaAlmacenEnvasadoSalio = true;
                BanderaAlmacenEnvasadoNoTerminado = false;
                cmbBodegaEnvasado_SelectedIndexChanged(null, null);
            }
            //MessageBox.Show("Escoge tipo almacen envasado: AE:" + BanderaAlmacenEnvasado + "|AES:" + BanderaAlmacenEnvasadoSalio + "|AENT:" + BanderaAlmacenEnvasadoNoTerminado);

        }

        private void cmbLoteparaAlmacen_Envasado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLoteparaAlmacen_Envasado.DataSource == null)
                {
                    botellasEnvasadoparaAlmacenenvasado = "";
                    no_lote_envasado = "";
                    grado_alcoholico_envasado = "";
                    fqalmacen_envasado = "";
                    clasemezcalAlmacenenvasado = "";
                    categoriamezcalAlmacenenvasado = "";
                    abocanteAlmacenenvasado = "";
                    ingredienteAlmacenenvasado = "";
                    id_plantaAlmacenenvasado = "";
                    id_predioAlmacenenvasado = "";
                    id_comun_almacen_envasado = "";
                    contenidoporbotella = "";
                    marca_envasado = "";
                    grado_alcoholico_etiqueta_envasado = "";
                    unidad_medida = "";
                }
                else
                {
                    DataSet Datos = new DataSet();

                    ConexionMysql.llenaDataset(ref Datos, "SELECT id_comun,fq,no_lote,botellas_existentes,no_lote,grado_alcoholico, grado_alcoholico_etiqueta,clase,categoria,abocante,ingrediente,id_planta,id_predio,unidad_medida,contenido_por_botella,id_marca FROM envasado_entrada  WHERE id_envasado_entrada='" + cmbLoteparaAlmacen_Envasado.SelectedValue + "'");


                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        fqalmacen_envasado = Convert.ToString(row["fq"]);
                        botellasEnvasadoparaAlmacenenvasado = Convert.ToString(row["botellas_existentes"]);
                        no_lote_envasado = Convert.ToString(row["no_lote"]);
                        grado_alcoholico_envasado = Convert.ToString(row["grado_alcoholico"]);
                        clasemezcalAlmacenenvasado = Convert.ToString(row["clase"]);
                        categoriamezcalAlmacenenvasado = Convert.ToString(row["categoria"]);
                        abocanteAlmacenenvasado = Convert.ToString(row["abocante"]);
                        ingredienteAlmacenenvasado = Convert.ToString(row["ingrediente"]);
                        id_plantaAlmacenenvasado = Convert.ToString(row["id_planta"]);
                        id_predioAlmacenenvasado = Convert.ToString(row["id_predio"]);
                        id_comun_almacen_envasado = Convert.ToString(row["id_comun"]);
                        contenidoporbotella = Convert.ToString(row["contenido_por_botella"]);
                        marca_envasado = Convert.ToString(row["id_marca"]);
                        grado_alcoholico_etiqueta_envasado = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        unidad_medida = Convert.ToString(row["unidad_medida"]);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void btnagregarNoLts_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbLoteparaAlmacen_Envasado.SelectedValue == null)
                {
                    MessageBox.Show("No tienes lote de envasado para agregar");
                    return;
                }

                if (txtBotellasparaguardarenvasadoAlmacen.Text == "")
                {
                    MessageBox.Show("No ha introducido un numero de botellas");
                    return;
                }

                if (Convert.ToInt64(botellasEnvasadoparaAlmacenenvasado) < Convert.ToInt64(txtBotellasparaguardarenvasadoAlmacen.Text))
                {
                    MessageBox.Show("Existencia insificiente");
                    return;
                }




                DataRow fila = dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].NewRow();
                fila["NO_LOTE"] = no_lote_envasado;
                fila["ID_ENVASADO_ENTRADA"] = cmbLoteparaAlmacen_Envasado.SelectedValue;
                fila["BOTELLAS"] = txtBotellasparaguardarenvasadoAlmacen.Text;
                fila["%_ALCOHOLICO"] = grado_alcoholico_envasado;
                fila["FQ"] = fqalmacen_envasado;
                fila["CLASE"] = clasemezcalAlmacenenvasado;
                fila["CATEGORIA"] = categoriamezcalAlmacenenvasado;
                fila["ABOCANTE"] = abocanteAlmacenenvasado;
                fila["INGREDIENTE"] = ingredienteAlmacenenvasado;
                fila["ID_PLANTA"] = id_plantaAlmacenenvasado;
                fila["ID_PREDIO"] = id_predioAlmacenenvasado;
                fila["ID_COMUN"] = id_comun_almacen_envasado;
                fila["CONTENIDO_BOTELLA"] = contenidoporbotella;
                fila["UNIDAD_MEDIDA"] = unidad_medida;
                fila["ID_MARCA"] = marca_envasado;
                fila["%_VOL_ETIQUETA"] = grado_alcoholico_etiqueta_envasado;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);

                dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Rows.Add(fila);
                txtBotellasparaguardarenvasadoAlmacen.Text = "";
                txtMarcaEnvasado.Text = "";
                cmbLoteparaAlmacen_Envasado.DataSource = null;


                string envasado = "";
                string coma = "";
                for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
                {
                    envasado += coma + "'" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_ENVASADO_ENTRADA"].Value + "'";
                    coma = ",";
                }


                ConexionMysql.llenaComboAutocomplit(ref cmbLoteparaAlmacen_Envasado, "SELECT  CONCAT(no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' a ',if (grado_alcoholico_etiqueta is null OR grado_alcoholico_etiqueta ='0','0',grado_alcoholico_etiqueta) ,' % vol.')) As envasado, id_envasado_entrada  FROM envasado_entrada  where id_envasado_entrada NOT IN(" + envasado + ") and id_envasadora='" + cmbEnvasadoraAlmacen.SelectedValue + "'  AND botellas_existentes > 0  order by id_envasado_entrada asc", "id_envasado_entrada", "envasado");







                if (dtaLoteparaAlmacen_Envasado.Rows.Count == 1)
                {




                    TxtClaveFqAlmacen.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["FQ"].Value.ToString();
                    TxtNoLoteAlmacen.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["NO_LOTE"].Value.ToString();

                    if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_MARCA"].Value.ToString() != "0" && dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_MARCA"].Value.ToString() != "-" && dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_MARCA"].Value.ToString() != "")
                    {

                        txtTerminado.Text = "SI";
                        cmbMarcaEnvasadoparaAlmacen.Visible = false;
                        txtMarcaEnvasado.Visible = true;
                        chkMaquila.Enabled = false;
                        chkTerminaEnvasadoparaAlmacen.Enabled = false;


                        chkTerminaEnvasadoparaAlmacen.Toggled = false;





                        txtMarcaEnvasado.Text = ConexionMysql.regresaCampoConsulta("select marca from envasado_entrada inner join  marcas  ON SUBSTRING(envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(envasado_entrada.id_marca,7,2)=marcas.cve_marca where envasado_entrada.id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value.ToString() + "';");




                        /*
                                                    txtgradoAlcoholetiqueta.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString();

                                                    txtUnidadMedida.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString();

                                                    txtContenido.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString();


                                                    */

                        /* verifica que el envasado terminado tenga registrado su tipo de etiquetado en el caso de ser jove o joven o blanco*/
                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() == "Blanco o Joven" || dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() == "Joven")
                        {

                            String etiq_como = ConexionMysql.regresaCampoConsulta("Select etiquetado_como FROM envasado_entrada WHERE id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value.ToString() + "';");


                            //MessageBox.Show(etiq_como);

                            if (etiq_como != "")
                            {

                                CmbAlmacenEtiquetadocomo.Enabled = false;
                                CmbAlmacenEtiquetadocomo.Items.Insert(0, etiq_como);
                                CmbAlmacenEtiquetadocomo.SelectedIndex = 0;

                                //CmbAlmacenEtiquetadocomo.Text = (etiq_como);


                            }
                            else
                            {
                                LblAlmacenEtiquetadocomo.Enabled = true;
                                CmbAlmacenEtiquetadocomo.Enabled = true;
                                CmbAlmacenEtiquetadocomo.Items.Insert(0, "---Elije una opcion---");
                                CmbAlmacenEtiquetadocomo.Items.Insert(1, "Blanco");
                                CmbAlmacenEtiquetadocomo.Items.Insert(2, "Joven");
                                CmbAlmacenEtiquetadocomo.SelectedIndex = 0;
                            }




                        }
                        else
                        {
                            //cmbEtiquetadocomo = clase;
                            //cmbEtiquetadocomo.Items.Add(clase);
                            LblAlmacenEtiquetadocomo.Enabled = false;
                            CmbAlmacenEtiquetadocomo.Enabled = false;


                        }



                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString() == "0")
                        {
                            txtgradoAlcoholetiqueta.ReadOnly = false;
                            txtgradoAlcoholetiqueta.Enabled = true;
                        }
                        else
                        {

                            txtgradoAlcoholetiqueta.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString();
                        }



                    }
                    else
                    {

                        txtTerminado.Text = "NO";
                        cmbMarcaEnvasadoparaAlmacen.Visible = true;
                        txtMarcaEnvasado.Visible = false;
                        chkTerminaEnvasadoparaAlmacen.Enabled = true;
                        lbltituloterminaenvasado.Enabled = true;
                        chkTerminaEnvasadoparaAlmacen.Enabled = true;


                        LblAlmacenEtiquetadocomo.Enabled = false;
                        CmbAlmacenEtiquetadocomo.Enabled = false;

                        //chkMaquila.Enabled = true;
                    }



                    /* if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString() == "0")
                     {
                         txtgradoAlcoholetiqueta.ReadOnly = true;
                         txtgradoAlcoholetiqueta.Enabled = false;
                     }
                     else
                     {*/

                    txtgradoAlcoholetiqueta.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString();
                    // }
                    txtUnidadMedida.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString();
                    txtContenido.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString();


                    //txtMarcaEnvasado.Text = "";

                }
                else if (dtaLoteparaAlmacen_Envasado.Rows.Count > 1)
                {//---------- en casado de que se un ensamble de --- 
                    //// ---- aqui hace la comparacion por si sevan a unir los lotes
                    TxtNoLoteAlmacen.Text = "";
                    for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
                    {

                        //TxtClaveFqAlmacen.Text += dtaLoteparaAlmacen_Envasado.Rows[0].Cells["FQ"].Value.ToString()+"";
                        //TxtNoLoteAlmacen.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["NO_LOTE"].Value.ToString();



                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_MARCA"].Value.ToString() != "0")
                        {
                            ///--- entra si el envasado es terminado
                            if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_MARCA"].Value.ToString() == dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_MARCA"].Value.ToString())
                            {
                                txtMarcaEnvasado.Text = ConexionMysql.regresaCampoConsulta("select marca from envasado_entrada inner join  marcas  ON SUBSTRING(envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(envasado_entrada.id_marca,7,2)=marcas.cve_marca where envasado_entrada.id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value.ToString() + "';");


                            }
                            else
                            {
                                MessageBox.Show("No se puede unir este lote las marcas no son iguales....");
                                limpiaAlmacenEnvasado();
                                return;
                            }
                        }//-- fin del if de marcas != 0

                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString() != "0")
                        { //-- si el grado alcoholico es dieferente de 0 entra indicando que es un envasado terminado

                            if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString() == dtaLoteparaAlmacen_Envasado.Rows[x].Cells["%_VOL_ETIQUETA"].Value.ToString())
                            {

                                txtgradoAlcoholetiqueta.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se pueden unir estos lotes, el grado alcoholico de etiqueta no son iguales....");
                                limpiaAlmacenEnvasado();
                                return;
                            }
                        }//-- fin de "%_VOL_ETIQUETA" != 0 

                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() != "0")
                        {
                            if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() != dtaLoteparaAlmacen_Envasado.Rows[x].Cells["CLASE"].Value.ToString())
                            {
                                MessageBox.Show("No se pueden unir estos lotes, la clase no es igual....");

                                limpiaAlmacenEnvasado();

                                return;
                            }
                        }
                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CATEGORIA"].Value.ToString() != "0")
                        {

                            if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CATEGORIA"].Value.ToString() != dtaLoteparaAlmacen_Envasado.Rows[x].Cells["CATEGORIA"].Value.ToString())
                            {

                                MessageBox.Show("No se pueden unir estos lotes, la categoria no es igual....");
                                limpiaAlmacenEnvasado();
                                return;
                            }


                        }

                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString() != "0")
                        {

                            if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString() != dtaLoteparaAlmacen_Envasado.Rows[x].Cells["CONTENIDO_BOTELLA"].Value.ToString())
                            {

                                MessageBox.Show("No se pueden unir estos lotes, la presentacion por botella no es igual....");
                                limpiaAlmacenEnvasado();
                                return;
                            }


                        }
                        if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString() != "0")
                        {

                            if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString() != dtaLoteparaAlmacen_Envasado.Rows[x].Cells["UNIDAD_MEDIDA"].Value.ToString())
                            {

                                MessageBox.Show("No se pueden unir estos lotes, la unidad de medida por botella no es igual....");
                                limpiaAlmacenEnvasado();
                                return;
                            }


                        }


                    }//-- fin del for 
                    //txtMarcaEnvasado.Text = "";






                    LblAlmacenEtiquetadocomo.Enabled = false;
                    CmbAlmacenEtiquetadocomo.Enabled = false;



                }
                else
                {
                    TxtClaveFqAlmacen.Text = "";
                    TxtNoLoteAlmacen.Text = "";
                    txtMarcaEnvasado.Text = "";
                    txtgradoAlcoholetiqueta.Text = "";
                }



                /*
                //reporta las bottelas que puedes envasar
                double litros = 0;
                string medida = CmbMedidaBotella.Text;
                for (int x = 0; x < DtaGranelParaEnvasado.Rows.Count; x++)
                {
                    litros += Math.Round(double.Parse(DtaGranelParaEnvasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                }

                string cadena = calcula_botellas(litros, medida).ToString();
                char delimiter = '.';
                string[] substrings = cadena.Split(delimiter);
                if (substrings.Length == 1)
                {
                    TxtNoBotellas.Text = substrings[0];
                    TxtMerma.Text = "0 %";
                }
                else
                {
                    TxtNoBotellas.Text = substrings[0];
                    if (substrings[1].Length == 1)
                    {
                        TxtMerma.Text = substrings[1] + " %";
                    }
                    else
                    {
                        TxtMerma.Text = substrings[1].Substring(0, 2) + " %";
                    }

                }
                */


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBotellasparaguardarenvasadoAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, txtBotellasparaguardarenvasadoAlmacen.Text);
        }


        private void dtaLoteparaAlmacen_Envasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (dtaLoteparaAlmacen_Envasado.Columns[e.ColumnIndex].Name == "QUITAR")
                {

                    /*
                    TxtNoBotellas.Text = "";
                    TxtMerma.Text = "";*/
                    dtaLoteparaAlmacen_Envasado.Rows.RemoveAt(e.RowIndex);
                    dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].AcceptChanges();
                    cmbLoteparaAlmacen_Envasado.DataSource = null;
                    if (dtaLoteparaAlmacen_Envasado.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
                        {
                            produccion += coma + "'" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_ENVASADO_ENTRADA"].Value + "'";
                            coma = ",";
                        }


                        ConexionMysql.llenaComboAutocomplit(ref cmbLoteparaAlmacen_Envasado, "SELECT  CONCAT(no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' a ',grado_alcoholico_etiqueta ,' % vol.')) As envasado, id_envasado_entrada  FROM envasado_entrada  where id_envasado_entrada NOT IN(" + produccion + ") and id_envasadora='" + cmbEnvasadoraAlmacen.SelectedValue + "'  AND botellas_existentes > 0  order by id_envasado_entrada asc", "id_envasado_entrada", "envasado");


                    }
                    else
                    {
                        ConexionMysql.llenaComboAutocomplit(ref cmbLoteparaAlmacen_Envasado, "SELECT  CONCAT(no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' a ',grado_alcoholico_etiqueta ,' % vol.')) As envasado, id_envasado_entrada   FROM envasado_entrada  where id_envasadora='" + cmbEnvasadoraAlmacen.SelectedValue + "'  AND botellas_existentes > 0  order by id_envasado_entrada asc", "id_envasado_entrada", "envasado");



                        CmbAlmacenEtiquetadocomo.Items.Clear();



                    }

                }


                if (dtaLoteparaAlmacen_Envasado.Rows.Count == 1)
                {




                    TxtClaveFqAlmacen.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["FQ"].Value.ToString();
                    TxtNoLoteAlmacen.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["NO_LOTE"].Value.ToString();
                    if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_MARCA"].Value.ToString() != "0")
                    {
                        // for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
                        //{



                        txtMarcaEnvasado.Text = ConexionMysql.regresaCampoConsulta("select marca from envasado_entrada inner join  marcas  ON SUBSTRING(envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(envasado_entrada.id_marca,7,2)=marcas.cve_marca where envasado_entrada.id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value.ToString() + "';");

                        // txtgradoAlcoholetiqueta.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString();
                        //}
                    }

                    txtgradoAlcoholetiqueta.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_VOL_ETIQUETA"].Value.ToString();
                    txtUnidadMedida.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString();
                    txtContenido.Text = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString();

                    //txtMarcaEnvasado.Text = "";
                }
                else if (dtaLoteparaAlmacen_Envasado.Rows.Count == 0)
                {

                    TxtClaveFqAlmacen.Text = "";
                    TxtNoLoteAlmacen.Text = "";
                    txtMarcaEnvasado.Text = "";
                    txtgradoAlcoholetiqueta.Text = "";
                    txtUnidadMedida.Text = "";
                    txtContenido.Text = "";
                    txtTerminado.Text = "....";


                }
                else
                { ///--- Aplica en el caso de que sea un ensamble
                    //TxtClaveFqAlmacen.Text = "";
                    TxtNoLoteAlmacen.Text = "";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkCambioNoloteparaAlmacen_ToggledChanged()
        {

            if (chkCambioNoloteparaAlmacen.Toggled == true)
            {
                TxtNoLoteAlmacen.ReadOnly = false;
                //
                TxtNoLoteAlmacen.BackColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                TxtNoLoteAlmacen.ReadOnly = true;
                TxtNoLoteAlmacen.BackColor = Color.FromArgb(240, 240, 240);
            }

        }

        private void limpiaAlmacenEnvasado()
        {
            dtsAlmacen_Envasado.Tables["ENVASADOPARAGUARDARALMACENENVASADO"].Rows.Clear();//-- limpia el data gridview
            TxtClaveFqAlmacen.Text = "";
            TxtNoLoteAlmacen.Text = "";
            txtMarcaEnvasado.Text = "";
            txtgradoAlcoholetiqueta.Text = "";
            txtUnidadMedida.Text = "";
            txtContenido.Text = "";
            txtTerminado.Text = "....";
            /*
            txtHologramaInicioAlmacen.Text = "";
            txthologramaFinAlmacen.Text = "";
            txtSerieHologramaAlmacen.Text = "";
            */
            chkTerminaEnvasadoparaAlmacen.Toggled = false;

        }

        private void chkTerminaEnvasadoparaAlmacen_ToggledChanged()
        {
            if (chkTerminaEnvasadoparaAlmacen.Toggled == true)
            {
                cmbMarcaEnvasadoparaAlmacen.Enabled = true;
                TxtClaveFqAlmacen.ReadOnly = false;
                gbxTerminaEnvasadoparaAlmacen.Enabled = true;
                txtgradoAlcoholetiqueta.ReadOnly = false;
                chkMaquila.Enabled = true;
                chkMaquila.Checked = false;
                cmbMarcaEnvasadoparaAlmacen.DataSource = null;
                ConexionMysql.llenaCombo(ref cmbMarcaEnvasadoparaAlmacen, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca  FROM marcas  where no_cliente ='" + CmbNoClienteBodegaEnvasado.SelectedValue + "' ORDER BY cve_marca ASC", "id", "marca");



                /* verifica que el envasado terminado tenga registrado su tipo de etiquetado en el caso de ser jove o joven o blanco*/

                if (dtaLoteparaAlmacen_Envasado.Rows.Count != 0)
                {


                    if (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() == "Blanco o Joven" || dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() == "Joven")
                    {

                        /* String etiq_como = ConexionMysql.regresaCampoConsulta("Select etiquetado_como FROM envasado_entrada WHERE id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value.ToString() + "';");


                         MessageBox.Show(etiq_como);

                         if (etiq_como != "")
                         {

                             CmbAlmacenEtiquetadocomo.Enabled = false;
                             CmbAlmacenEtiquetadocomo.Items.Insert(0, etiq_como);
                             CmbAlmacenEtiquetadocomo.SelectedIndex = 0;

                             //CmbAlmacenEtiquetadocomo.Text = (etiq_como);


                         }
                         else
                         {*/
                        LblAlmacenEtiquetadocomo.Enabled = true;
                        CmbAlmacenEtiquetadocomo.Enabled = true;
                        CmbAlmacenEtiquetadocomo.Items.Insert(0, "---Elije una opcion---");
                        CmbAlmacenEtiquetadocomo.Items.Insert(1, "Blanco");
                        CmbAlmacenEtiquetadocomo.Items.Insert(2, "Joven");
                        CmbAlmacenEtiquetadocomo.SelectedIndex = 0;
                        //}




                    }
                    else
                    {
                        //cmbEtiquetadocomo = clase;
                        //cmbEtiquetadocomo.Items.Add(clase);
                        LblAlmacenEtiquetadocomo.Enabled = false;
                        CmbAlmacenEtiquetadocomo.Enabled = false;


                    }


                }// fin del if (dtaLoteparaAlmacen_Envasado.Rows.Count > 1)



            }
            else
            {

                cmbMarcaEnvasadoparaAlmacen.Enabled = false;
                TxtClaveFqAlmacen.ReadOnly = true;
                gbxTerminaEnvasadoparaAlmacen.Enabled = false;
                txtgradoAlcoholetiqueta.ReadOnly = true;
                chkMaquila.Enabled = false;

                chkMaquila.Checked = false;
                chkOstentaEnvasadoAlmacen.Toggled = false;
                cmbMarcaEnvasadoparaAlmacen.DataSource = null;

                LblAlmacenEtiquetadocomo.Enabled = false;
                CmbAlmacenEtiquetadocomo.Enabled = false;

                CmbAlmacenEtiquetadocomo.Items.Clear();

                /* txtHologramaInicioAlmacen.Text = "";
                 txthologramaFinAlmacen.Text = "";
                 txtSerieHologramaAlmacen.Text = "";
                 */
            }
        }

        private void chkOstentaEnvasadoAlmacen_ToggledChanged()
        {
            if (chkOstentaEnvasadoAlmacen.Toggled == true)
            {
                txtHologramaInicioAlmacen.ReadOnly = true;
                txthologramaFinAlmacen.ReadOnly = true;
                txtSerieHologramaAlmacen.ReadOnly = true;
                btnAgregarHologramasEnvasadoparaAlmacen.Enabled = false;
                txtHologramaInicioAlmacen.Text = "Si ostenta";
                txthologramaFinAlmacen.Text = "Si ostenta";
                txtSerieHologramaAlmacen.Text = "";
                dtsHologramasparaAlmacen.Clear();
            }
            else
            {
                txtHologramaInicioAlmacen.ReadOnly = false;
                txthologramaFinAlmacen.ReadOnly = false;
                txtSerieHologramaAlmacen.ReadOnly = false;
                btnAgregarHologramasEnvasadoparaAlmacen.Enabled = true;
                txtHologramaInicioAlmacen.Text = "";
                txthologramaFinAlmacen.Text = "";
                txtSerieHologramaAlmacen.Text = "";
            }
        }


        private void btnAgregarHologramasEnvasadoparaAlmacen_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHologramaInicioAlmacen.Text == "")
                {
                    MessageBox.Show("Ingresa un inicio de holograma");
                    txtHologramaInicioAlmacen.Focus();
                    return;
                }

                if (txthologramaFinAlmacen.Text == "")
                {
                    MessageBox.Show("Introduce un fin de holograma");
                    txthologramaFinAlmacen.Focus();
                    return;
                }
                if (txtSerieHologramaAlmacen.Text == "")
                {
                    MessageBox.Show("Introduce una serie");
                    txtSerieHologramaAlmacen.Focus();
                    return;
                }

                if (txtHologramaInicioAlmacen.Text == "0")
                {
                    MessageBox.Show("Introduce un valor diferente de 0");
                    txtHologramaInicioAlmacen.Focus();
                    return;
                }
                if (txthologramaFinAlmacen.Text == "0")
                {
                    MessageBox.Show("Introduce un valor diferente de 0");
                    txthologramaFinAlmacen.Focus();
                    return;
                }
                if (cmbMarcaEnvasadoparaAlmacen.SelectedValue == null)
                {
                    MessageBox.Show("No has selecionado una marca ");
                    txthologramaFinAlmacen.Focus();
                    return;
                }

                int holograma_inicio;
                int holograma_fin;

                string no_cliente = cmbMarcaEnvasadoparaAlmacen.SelectedValue.ToString();
                no_cliente = no_cliente.Substring(0, 5);

                string cve_marca = cmbMarcaEnvasadoparaAlmacen.SelectedValue.ToString();
                int lenght = cve_marca.Length;
                int mark = lenght == 7 ? 1 : 2;
                cve_marca = cve_marca.Substring(6, mark);
                //cve_marca = cve_marca.Substring(6, 1);
                



                DataSet Datos = new DataSet();
                //ConexionMysql.llenaDataset(ref Datos, "select holograma_inicio,holograma_fin from envasado_holograma where no_cliente='" + no_cliente + "' and cve_marca='" + cve_marca + "' and serie='" + TxtSerie.Text.ToUpper() + "'");

                ConexionMysql.llenaDataset(ref Datos, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,5) = em.no_cliente and  SUBSTRING(ee.id_marca,7,1)=em.cve_marca  where eh.no_cliente='" + no_cliente + "' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + txtSerieHologramaAlmacen.Text.ToUpper() + "'");



                foreach (DataRow row in Datos.Tables[0].Rows)
                {



                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);


                    string lote = "Tipo de instalacion :  Envasadora" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";


                    if (int.Parse(txtHologramaInicioAlmacen.Text) >= holograma_inicio && int.Parse(txtHologramaInicioAlmacen.Text) <= holograma_fin)
                    {
                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos  para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + txtHologramaInicioAlmacen.Text + " - " + txthologramaFinAlmacen.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(txthologramaFinAlmacen.Text) >= holograma_inicio && int.Parse(txthologramaFinAlmacen.Text) <= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + txtHologramaInicioAlmacen.Text + " - " + txthologramaFinAlmacen.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(txtHologramaInicioAlmacen.Text) <= holograma_inicio && int.Parse(txthologramaFinAlmacen.Text) >= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + txtHologramaInicioAlmacen.Text + " - " + txthologramaFinAlmacen.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                ///// --- BUSCA SI EXISTE  HOLOGRAMAS OCUPADOS DE LA  MARCA EN ALMACEN DE ENVASASO HOLOGRAMAS 
                DataSet Datos3 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos3, "select aeh.holograma_inicio,aeh.holograma_fin, aee.no_lote, em.marca,aee.contenido_por_botella,aee.unidad_medida from almacen_envasado_holograma aeh inner join almacen_envasado_entrada aee on aeh.id_almacen_envasado_entrada = aee.id_almacen_envasado_entrada inner join marcas em on  SUBSTRING(aee.id_marca,1,5) = em.no_cliente and  SUBSTRING(aee.id_marca,7,1)=em.cve_marca  where aeh.no_cliente='" + no_cliente + "' and aeh.cve_marca='" + cve_marca + "' and aeh.serie='" + txtSerieHologramaAlmacen.Text.ToUpper() + "'");


                foreach (DataRow row in Datos3.Tables[0].Rows)
                {



                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);

                    string lote = "Tipo de instalacion :  Almacen  de Envasado" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

                    if (int.Parse(txtHologramaInicioAlmacen.Text) >= holograma_inicio && int.Parse(txtHologramaInicioAlmacen.Text) <= holograma_fin)
                    {
                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos  para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + txtHologramaInicioAlmacen.Text + " - " + txthologramaFinAlmacen.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(txthologramaFinAlmacen.Text) >= holograma_inicio && int.Parse(txthologramaFinAlmacen.Text) <= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + txtHologramaInicioAlmacen.Text + " - " + txthologramaFinAlmacen.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (int.Parse(txtHologramaInicioAlmacen.Text) <= holograma_inicio && int.Parse(txthologramaFinAlmacen.Text) >= holograma_fin)
                    {


                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + txtHologramaInicioAlmacen.Text + " - " + txthologramaFinAlmacen.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                DataSet Datos2 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos2, " select   MAX(ff1) AS ff1 from hologramas_salida where no_cliente='" + no_cliente + "' and marca='" + cve_marca + "' and serie='" + txtSerieHologramaAlmacen.Text.ToUpper() + "' ");

                if (Datos2.Tables[0].Rows.Count > 0)
                {



                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {

                        if (DBNull.Value.Equals(row["ff1"]))
                        {
                            MessageBox.Show("No se ha encontrado registro alguno de hologramas para la marca : " + Environment.NewLine + cmbMarcaEnvasadoparaAlmacen.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        holograma_fin = Convert.ToInt32(row["ff1"]);


                        if (int.Parse(txthologramaFinAlmacen.Text) > holograma_fin)
                        {
                            MessageBox.Show("No puedes introducir este rango ya que el rango final entregado al asociado es " + Environment.NewLine + "Entregado: " + holograma_fin.ToString() + Environment.NewLine + "Introducido: " + txthologramaFinAlmacen.Text);
                            return;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("No se tiene registro de hologramas entregados");
                    return;

                }


                DataRow fila = dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"].NewRow();
                fila["INICIO"] = txtHologramaInicioAlmacen.Text;
                fila["FIN"] = txthologramaFinAlmacen.Text;
                fila["SERIE"] = txtSerieHologramaAlmacen.Text.ToUpper();
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"].Rows.Add(fila);
                txtHologramaInicioAlmacen.Text = "";
                txthologramaFinAlmacen.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtaHologramasEnvasadoParaALmacen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaHologramasEnvasadoParaALmacen.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaHologramasEnvasadoParaALmacen.Rows.RemoveAt(e.RowIndex);
                    dtsHologramasparaAlmacen.Tables["HOLOGRAMASPARAALMACEN"].AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void chkMaquila_CheckedChanged(object sender, EventArgs e)
        {
            no_cliente_maquila = "";

            if (chkMaquila.Checked == true)
            {
                FrmClienteMaquila frm = new FrmClienteMaquila();
                frm.ShowDialog();
                no_cliente_maquila = frm.no_cliente;
                if (no_cliente_maquila == "")
                {
                    chkMaquila.Checked = false;
                    lblNClienteMaquilaAlmacen.Visible = false;
                    lblNClienteMaquilaAlmacen.Visible = false;
                    return;
                }
                ConexionMysql.llenaCombo(ref cmbMarcaEnvasadoparaAlmacen, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca  FROM marcas  where no_cliente ='" + no_cliente_maquila + "'ORDER BY cve_marca ASC", "id", "marca");
                lbltitulomaquila_cliente.Visible = true;
                lblNClienteMaquilaAlmacen.Visible = true;
                lblNClienteMaquilaAlmacen.Text = no_cliente_maquila;
            }
            else
            {
                chkMaquila.Checked = false;
                ConexionMysql.llenaCombo(ref cmbMarcaEnvasadoparaAlmacen, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca  FROM marcas  where no_cliente ='" + CmbNoClienteBodegaEnvasado.SelectedValue + "' ORDER BY cve_marca ASC", "id", "marca");
                lbltitulomaquila_cliente.Visible = false;
                lblNClienteMaquilaAlmacen.Visible = false;
            }
        }



        private void btnMssgAlmacenBotellas_MouseEnter(object sender, EventArgs e)
        {
            int suma_botellas = 0;
            if (DtaHologramasEnvasadoParaALmacen.Rows.Count >= 1)
            {

                for (int x = 0; x < DtaHologramasEnvasadoParaALmacen.Rows.Count; x++)
                {
                    suma_botellas += ((int.Parse(DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["FIN"].Value.ToString()) - int.Parse(DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["INICIO"].Value.ToString())) + 1);
                }

                if (suma_botellas < 0)
                {
                    txtMensajeAlmacenBotellas.Text = "Error en rango de hologramas";
                }
                else
                {
                    txtMensajeAlmacenBotellas.Text = suma_botellas.ToString() + " Botellas";
                }

                txtMensajeAlmacenBotellas.Visible = true;
            }

        }

        private void btnMssgAlmacenBotellas_MouseLeave(object sender, EventArgs e)
        {
            txtMensajeAlmacenBotellas.Visible = false;
        }

        private void txtHologramaInicioAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, txtHologramaInicioAlmacen.Text);
        }

        private void txthologramaFinAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, txthologramaFinAlmacen.Text);
        }


        private void BtnAgregarEnvasadoAlamacen_Click(object sender, EventArgs e)
        {
            if (cmbBodegaEnvasado.Items.Count == 0)
            {
                MessageBox.Show("No tienes un almacen de destino, agrega uno para poder realizar el movimiento");
                return;
            }
            FrmNuevoEnvasado frm = new FrmNuevoEnvasado();
            frm.no_cliente = CmbNoClienteBodegaEnvasado.SelectedValue.ToString();
            frm.id_almacen_envasado = cmbBodegaEnvasado.SelectedValue.ToString();
            frm.tipo_instalacion = "almacen_envasado";

            frm.ShowDialog();
            CmbNoClienteBodegaEnvasado_SelectedIndexChanged(sender, e);
        }


        private void btnTransaccionBodegaEnvasado_Click(object sender, EventArgs e)
        {
            FrmTransaccion frm = new FrmTransaccion();
            frm.no_cliente = CmbNoClienteBodegaEnvasado.SelectedValue.ToString();
            if (cmbBodegaEnvasado.Items.Count == 0)
            {
                MessageBox.Show("No tienes un Almacen de destino, agrega uno para poder realizar el movimiento");
                return;
            }
            frm.id_instalacion = cmbBodegaEnvasado.SelectedValue.ToString();
            frm.tipo_instalacion = "almacen_envasado";
            frm.ShowDialog();
            cmbBodegaEnvasado_SelectedIndexChanged(null, null);

        }
        private void btnAgregarEnvasadoBodega_Click(object sender, EventArgs e)
        {
            if (cmbBodegaEnvasado.SelectedValue == null)
            {
                MessageBox.Show("No ha seleccionado ningun almacen de envasado");
                return;
            }
            if (dtaLoteparaAlmacen_Envasado.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún envasado");
                return;
            }
            if (TxtNoLoteAlmacen.Text == "")
            {
                MessageBox.Show("Debes ingresar un numero de lote");
                TxtNoLoteAlmacen.Focus();
                return;
            }
            /* if (CmbUnidadDeMedida.SelectedValue == null)
             {
                 MessageBox.Show("Debes seleccionar una unidad de medida");
                 return;
             }*/
            /* if (CmbMedidaBotella.SelectedValue == null)
             {
                 MessageBox.Show("Debes seleccionar un contenido por botella");
                 return;
             }*/
            /*if (TxtNoBotellas.Text == "")
            {
                MessageBox.Show("Debes ingresar un numero de botellas");
                TxtNoBotellas.Focus();
                return;
            }*/


            string marcaterminado = ""; ///--- sele asigna el valor del Combobox por si es terminado o no
            string fechaMovimiento = "";
            string fechaEnvasadofin = "";
            string gradoalcoholicoEtiqueta = "";


            string fechaEnvIni = ConexionMysql.regresaCampoConsulta("Select DATE_FORMAT(fecha_envasado_ini,'%Y/%m/%d') as fecha_envasado_ini from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "';");

            string litros_env = ConexionMysql.regresaCampoConsulta("Select litros from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "';");

            string no_loteGranel = ConexionMysql.regresaCampoConsulta("Select no_lote_granel from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "';");


            if (chkTerminaEnvasadoparaAlmacen.Toggled == true)
            {
                //string fechaEnvIni = ConexionMysql.regresaCampoConsulta("Select fecha_envasado_ini from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "';");
                int ResComparacionFechas = DateTime.Compare(Convert.ToDateTime(fechaEnvIni), DtaFechaEnvasadofin.Value);
                if (ResComparacionFechas > 0)
                {
                    MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio del envasado");
                    return;
                }
                else
                {

                    //fechaMovimiento = DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd");
                    fechaEnvasadofin = DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd");


                }

                if (cmbMarcaEnvasadoparaAlmacen.SelectedValue == null)
                {
                    MessageBox.Show("No ha seleccionado ninguna marca");
                    return;
                }
                else
                {

                    //  marcaterminado = ConexionMysql.regresaCampoConsulta("Select id_marca from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_GRANEL_ENTRADA"].Value + "';");
                    marcaterminado = Convert.ToString(cmbMarcaEnvasadoparaAlmacen.SelectedValue);
                    fechaMovimiento = DateTime.Now.ToString("yyyy-MM-dd");





                }

                if (TxtClaveFqAlmacen.Text == "" || TxtClaveFqAlmacen.Text == " ")
                {
                    MessageBox.Show("No ha introducido un FQ");
                    TxtClaveFqAlmacen.Focus();
                    return;
                }
                if (txtgradoAlcoholetiqueta.Text == "" || txtgradoAlcoholetiqueta.Text == "0")
                {
                    MessageBox.Show("No ha introducido un grado alcohólico de la etiqueta");
                    txtgradoAlcoholetiqueta.Focus();
                    return;
                }
                else
                {

                    gradoalcoholicoEtiqueta = txtgradoAlcoholetiqueta.Text;
                }

                if (chkOstentaEnvasadoAlmacen.Toggled == false)
                {
                    if (DtaHologramasEnvasadoParaALmacen.RowCount == 0)
                    {
                        MessageBox.Show("Introduce un rango de hologramas");
                        txtHologramaInicioAlmacen.Focus();
                        return;
                    }
                }







            }
            else
            {
                marcaterminado = ConexionMysql.regresaCampoConsulta("Select id_marca from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "';");
                fechaMovimiento = ConexionMysql.regresaCampoConsulta("Select DATE_FORMAT(fecha_movimiento,'%Y/%m/%d') as fecha_movimiento from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "';");
                fechaEnvasadofin = ConexionMysql.regresaCampoConsulta("Select  DATE_FORMAT(fecha_envasado_fin,'%Y/%m/%d') as fecha_envasado_fin  from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "';");
                gradoalcoholicoEtiqueta = ConexionMysql.regresaCampoConsulta("Select grado_alcoholico_etiqueta from envasado_entrada where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "';");

            }


            if (txtgradoAlcoholetiqueta.Text != "0")
            {
                gradoalcoholicoEtiqueta = txtgradoAlcoholetiqueta.Text;
            }


            if (CmbAlmacenEtiquetadocomo.Text == "---Elije una opcion---")
            {
                MessageBox.Show("Elige un tipo de etiquetado");
                return;

            }


            //  MessageBox.Show(gradoalcoholicoEtiqueta);



            //  ================================================================>>> Confirmacion de datos a ingresar <<<============

            FrmTransaccion tran = new FrmTransaccion();


            string ltspor_restar = Convert.ToString(tran.calcula_botellas(Convert.ToDouble(dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString()), dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString(), dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString()));//double botellas, string medida, string contenido_por_botella

            string tipo = label31.Text;
            string f = CmbNoClienteBodegaEnvasado.Text;
            string o = cmbBodegaEnvasado.Text;
            string p = "";
            string pp = "";
            string p3 = "";
            string comad = "";
            //--->>-Mustra la lista de los DatagredView
            for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
            {
                p += comad + "'" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["NO_LOTE"].Value + " ' \n";
                //pp += comad + "'" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value + " '  \n";
                p3 += comad + "'" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["%_ALCOHOLICO"].Value + " ' \n ";
                comad = "  ";
            }




            string q = "";
            string q1 = "";
            string q2 = "";
            //q = DtaTanquesEnvasado.CurrentRow.Cells[0].Value.ToString();
            string um = "----";
            string cont = "---";
            string a = "----";
            string t = TxtNoLoteAlmacen.Text;
            string c = "----";
            string b = "----";
            string nb = dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString();
            string m = "----";
            string fei = fechaEnvIni;
            string fef = fechaEnvasadofin;


            string tmdo = "";
            if (chkTerminaEnvasadoparaAlmacen.Toggled == true)
            {
                tmdo = "\tSI\t";
                um = txtUnidadMedida.Text;
                cont = txtContenido.Text;
                a = cmbMarcaEnvasadoparaAlmacen.Text;
                t = TxtNoLoteAlmacen.Text;
                c = TxtClaveFqAlmacen.Text;
                b = txtgradoAlcoholetiqueta.Text;

            }
            else
            {
                tmdo = "\t" + txtTerminado.Text + "\t";
                if (txtTerminado.Text == "SI")
                {

                    um = txtUnidadMedida.Text;
                    cont = txtContenido.Text;
                    a = txtMarcaEnvasado.Text;
                    t = TxtNoLoteAlmacen.Text;
                    c = TxtClaveFqAlmacen.Text;
                    b = txtgradoAlcoholetiqueta.Text;

                }
                //---pone en hologramas.. 
                q = "----";
                q1 = "----";
                q2 = "----";

            }


            if (chkTerminaEnvasadoparaAlmacen.Toggled == true)
            {
                
                if (chkOstentaEnvasadoAlmacen.Toggled == true)
                {
                    q = txtHologramaInicioAlmacen.Text;
                    q1 = txthologramaFinAlmacen.Text;
                    q2 = "----";
                }
                else
                {
                    //--->>-Mustra la lista de los DatagredView
                    for (int x = 0; x < DtaHologramasEnvasadoParaALmacen.Rows.Count; x++)
                    {
                        q += comad + "'" + DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["INICIO"].Value + " '  \n";
                        q1 += comad + "'" + DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["FIN"].Value + " '  \n";
                        q2 += comad + "'" + DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["SERIE"].Value + " '  \n";

                    }

                }
            }



            /* DialogResult r = MsgBxGranelenvasado.Show("Cliente: " + f + "\nEnvasadora: " + o + "\n\n--->-Lote Granel-<---" + "\nNo Lote: " + p + "\nLitros: " + pp + " \n% Alcoholico: "
               + p3 + "\n\n--->-Producto " + "  " + tmdo + "  "+"Terminado-<---" + "\nMarca: " + a + "\nNo lote: " + t + "\nClave FQ: " + c + "\nUnidad de medida: " + um + "    Cont: " + cont+ "\n°Alcohólico etiqueta: " + b  + "\nNo de botellas: " + nb + "    Merma: " + m 
               + "\n\n--->-Fecha envasado-<---" + "\nInicio: " + fei + "   Fin: " + fef + "\n\n--->-Hologramas-<---" + "\nInicio: " + q 
               +"\nFin: " + q1+"\nSerie: " + q2 ,"---", "Aceptar","Cancelar");
          */
            
            string dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + tmdo + "!" + a + "!" + t + "!" + c + "!" + um + "!" + cont + "!" + b + "!" + nb + "!" + m + "!" + fei + "!" + fef + "!" + q + "!" + q1 + "!" + q2;

            MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
            msg.Envasadook(dto);
            msg.ShowDialog();
            if (msg.DialogResult == DialogResult.Cancel) { return; }
            else
            {
                ObtenerIdMaximoAlmacenEnvasadoEntrada();
                if (dtaLoteparaAlmacen_Envasado.Rows.Count == 1)// compara si tiene un solo registro el dtaLoteparaAlmacen_Envasado
                {
                    //MessageBox.Show("aCÁ 6 ");
                    int idPlanta_dtaLAE;
                    //dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PLANTA"].Value = (dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PLANTA"].Value.ToString() == "") ? 0 : dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PLANTA"].Value;
                    idPlanta_dtaLAE = int.Parse(dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PLANTA"].Value.ToString());
                    //if (int.Parse(dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PLANTA"].Value.ToString()) == 0 || dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PLANTA"].Value.ToString() == "")
                    if (idPlanta_dtaLAE == 0)
                    {
                        //MessageBox.Show("aCÁ 7");
                        //MessageBox.Show("INSERT INTO  almacen_envasado_entrada(id_almacen_envasado_entrada, id_almacen, id_marca, no_cliente, fecha_movimiento, fecha, fecha_envasado_ini, fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, etiquetado_como, unidad_medida, contenido_por_botella, litros, grado_alcoholico, grado_alcoholico_etiqueta, botellas_iniciales, botellas, botellas_existentes, id_verificador, actualizado) VALUES('" + id_max_almacen_envasado_entrada + "', '" + cmbBodegaEnvasado.SelectedValue + "', '" + marcaterminado + "', '" + CmbNoClienteBodegaEnvasado.SelectedValue + "', '" + fechaMovimiento + "', now(), '" + fechaEnvIni + "', '" + fechaEnvasadofin + "', " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_COMUN"].Value.ToString() + ", '" + no_loteGranel + "', 0, '" + TxtNoLoteAlmacen.Text + "', '" + TxtClaveFqEnvasado.Text + "', '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() + "', '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CATEGORIA"].Value.ToString() + "', '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ABOCANTE"].Value.ToString() + "', '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["INGREDIENTE"].Value.ToString() + "', '" + CmbAlmacenEtiquetadocomo.Text + "', '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString() + "', " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString() + ",if (" + litros_env + " is null OR " + litros_env + " = 0,'0', ROUND(" + ltspor_restar + ", 2)), " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells[" % _ALCOHOLICO"].Value.ToString() + ",'" + gradoalcoholicoEtiqueta + "'," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + Usuario.IdUsuario + ",0");
                        //--- entra si es un ensamble el lote   que proviene de granel --- 
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_entrada(id_almacen_envasado_entrada,id_almacen,id_marca,no_cliente,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_comun,no_lote_granel,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,actualizado) VALUES('" + id_max_almacen_envasado_entrada + "', '" + cmbBodegaEnvasado.SelectedValue + "','" + marcaterminado + "','" + CmbNoClienteBodegaEnvasado.SelectedValue + "','" + fechaMovimiento + "',now(),'" + fechaEnvIni + "','" + fechaEnvasadofin + "'," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",'" + no_loteGranel + "',0,'" + TxtNoLoteAlmacen.Text + "','" + TxtClaveFqEnvasado.Text + "' , '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() + "' , '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CATEGORIA"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ABOCANTE"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["INGREDIENTE"].Value.ToString() + "','" + CmbAlmacenEtiquetadocomo.Text + "','" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString() + "'," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString() + ",if(" + litros_env + " is null OR " + litros_env + "= 0,'0', ROUND(" + ltspor_restar + ",2)), " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_ALCOHOLICO"].Value.ToString() + ",'" + gradoalcoholicoEtiqueta + "'," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + Usuario.IdUsuario + ",0)") == "Error")//--- seagrego fecha movimineto y botellas_iniciales
                        {
                            //MessageBox.Show("aCÁ 8");
                            //MessageBox.Show("voendo qu hace aqui 1");
                            return;
                        }
                        DataSet Datos = new DataSet();

                        ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM envasado_ensamble where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "'");

                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();


                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_ensamble(id_almacen_envasado_ensamble,id_almacen_envasado_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_almacen_envasado_ensamble + "','" + id_max_almacen_envasado_entrada + "' ,'" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "',if(" + litros_env + " is null OR " + litros_env + "= 0,'0', ROUND(" + ltspor_restar + ",2)),'" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")

                            ///  ---- aqui checar sesa columna de LITROS  causa que no la puede encontrar 
                            {
                                //MessageBox.Show("aCÁ 9");
                                return;
                            }
                        }
                    }//-- fin  if  int.Parse(dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PLANTA"].Value.ToString()) == 0
                    else
                    {


                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_entrada (id_almacen_envasado_entrada,id_almacen,id_marca,no_cliente,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_comun,no_lote_granel,id_solicitud,no_lote,id_planta,id_predio,fq,clase,categoria,abocante,ingrediente,etiquetado_como,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas,botellas_existentes,id_verificador,actualizado,holograma_inicio,holograma_fin) VALUES('" + id_max_almacen_envasado_entrada + "','" + cmbBodegaEnvasado.SelectedValue + "', '" + marcaterminado + "','" + CmbNoClienteBodegaEnvasado.SelectedValue + "','" + fechaMovimiento + "',now(),'" + fechaEnvIni + "','" + fechaEnvasadofin + "'," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",'" + no_loteGranel + "',0,'" + TxtNoLoteAlmacen.Text + "' ," + idPlanta_dtaLAE + ",'" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_PREDIO"].Value.ToString() + "','" + TxtClaveFqEnvasado.Text + "' , '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CLASE"].Value.ToString() + "' , '" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CATEGORIA"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ABOCANTE"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["INGREDIENTE"].Value.ToString() + "','" + CmbAlmacenEtiquetadocomo.Text + "','" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["UNIDAD_MEDIDA"].Value.ToString() + "'," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["CONTENIDO_BOTELLA"].Value.ToString() + ",if(" + litros_env + " is null OR " + litros_env + "= 0,'0', ROUND(" + ltspor_restar + ",2)), " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_ALCOHOLICO"].Value.ToString() + "," + gradoalcoholicoEtiqueta + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + Usuario.IdUsuario + ",0,'" + TxtHologramaInicio.Text + "','" + TxtHologramaFin.Text + "')") == "Error")//--- seagrego fecha movimineto y botellas_iniciales
                        {
                            MessageBox.Show("aCÁ 10");
                            //MessageBox.Show("voendo qu hace aqui 2");
                            return;
                        }
                    }///-- fin del else





                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "' and tipo_instalacion='envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_envasado_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }



                    if (ConexionMysql.insUpd_transaccion("UPDATE  envasado_entrada SET litros=if(litros is null OR litros = 0,'0', ROUND(litros - " + ltspor_restar + ",2)),botellas_iniciales=if(botellas_iniciales is null OR botellas_iniciales=0,'0',ROUND(botellas_iniciales- " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + ",2)), botellas=ROUND(botellas - " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + ",2), botellas_existentes=ROUND(botellas_existentes - " + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + ",2),actualizado=0 WHERE id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "'") == "Error")
                    {
                        return;
                    }



                }   ///--- fin del if de dtaLoteparaAlmacen_Envasado.Rows.Count == 1
                
                /* else
                {
                    ///==== ENTRA SI ES UN ENSAMBLE MAS DE UNLOTE

                    string CategoriaMezcal = "";
                    string CategoriaMezcalComparar = "";
                    string claseMezcal = "";
                    string claseMezcalComparar = "";
                    double litros = 0;
                    double grado_alcoholico = 0;
                    double grado_alcoholico_para_suma = 0;
                    string Abocante = "";
                    string Ingrediente = "";
                    string coma = "";

                    for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
                    {
                        if (x > 0)
                        {
                            CategoriaMezcalComparar = CategoriaMezcal;
                            claseMezcalComparar = claseMezcal;
                        }
                        claseMezcal = dtaLoteparaAlmacen_Envasado.Rows[x].Cells["CLASE"].Value.ToString();
                        CategoriaMezcal = dtaLoteparaAlmacen_Envasado.Rows[x].Cells["CATEGORIA"].Value.ToString();
                        Abocante += coma + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ABOCANTE"].Value.ToString();
                        Ingrediente += coma + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["INGREDIENTE"].Value.ToString();
                        coma = "-";

                        //saca la categoria del mezcal
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

                        // saca la clase del mezcal
                        if (claseMezcal == "Reposado")
                        {
                            if (claseMezcalComparar == "Joven")
                            {
                                claseMezcal = claseMezcalComparar;
                            }
                        }
                        else if (claseMezcal == "Añejo")
                        {
                            if (claseMezcalComparar == "Joven")
                            {
                                claseMezcal = claseMezcalComparar;
                            }
                            else if (claseMezcalComparar == "Reposado")
                            {
                                claseMezcal = claseMezcalComparar;
                            }
                        }


                        litros += Math.Round(double.Parse(dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                        grado_alcoholico_para_suma += Math.Round(double.Parse(dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value.ToString()), 2) * Math.Round(double.Parse(dtaLoteparaAlmacen_Envasado.Rows[x].Cells["%_ALCOHOLICO"].Value.ToString()), 2);
                    }

                    grado_alcoholico = grado_alcoholico_para_suma / litros;

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada(id_envasado_entrada,id_envasadora,id_marca,no_cliente,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin,id_solicitud,no_lote,fq,clase,categoria,abocante,ingrediente,unidad_medida,contenido_por_botella,litros,grado_alcoholico,grado_alcoholico_etiqueta,botellas,botellas_iniciales,botellas_existentes,id_verificador,actualizado) VALUES( '" + id_max_envasado_entrada + "','" + cmbBodegaEnvasado.SelectedValue + "','" + CmbMarca.SelectedValue + "','" + CmbNoClienteEnvasado.SelectedValue + "',CASE id_marca WHEN '0' THEN '0000-00-00' WHEN '' THEN '0000-00-00' ELSE now() END" + ",now(),'" + DtaFechaEnvasadoini.Value.ToString("yyyy-MM-dd") + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLoteAlmacen.Text + "','" + TxtClaveFqEnvasado.Text + "' , '" + claseMezcal + "' , '" + CategoriaMezcal + "','" + Abocante + "','" + Ingrediente + "','" + CmbUnidadDeMedida.SelectedValue + "'," + CmbMedidaBotella.SelectedValue + "," + litros + ", " + Math.Round(grado_alcoholico, 2) + "," + (TxtGradoAlcoholicoEtiqueta.Text == "" ? "0" : TxtGradoAlcoholicoEtiqueta.Text) + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + TxtNoBotellas.Text + "," + Usuario.IdUsuario + ",0)") == "Error") //-- Se agrego fecha_movimiento y botellas iniciales
                    {
                        //MessageBox.Show("voendo qu hace aqui 3");
                        return;
                    }


                    for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
                    {
                        if (int.Parse(dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_PLANTA"].Value.ToString()) == 0 && int.Parse(dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_COMUN"].Value.ToString()) == 0)
                        {
                            DataSet Datos = new DataSet();
                            if (RbtnFabrica.Checked == true)
                            {
                                ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            }
                            else
                            {
                                ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                            }

                            foreach (DataRow row in Datos.Tables[0].Rows)
                            {
                                ObtenerIdMaximoEnvasadoEnsamble();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble,id_envasado_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES('" + id_max_envasado_ensamble + "', '" + id_max_envasado_entrada + "','" + row["id_comun"].ToString() + "' ,'" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value.ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble,id_envasado_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,id_verificador) VALUES( '" + id_max_envasado_ensamble + "','" + id_max_envasado_entrada + "' ,'" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_COMUN"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value.ToString() + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["AGAVE_COCCION_KG"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }
                } */
                ///-- FIN DEL ELSE DE ENSAMBL DE VARIOS LOTES 

                // marca la salida del producto y actualiza existencia de granel



                /*  for (int x = 0; x < dtaLoteparaAlmacen_Envasado.Rows.Count; x++)
                  {
                      if (RbtnFabrica.Checked == true)
                      {   ///--- SI EL LOTE PROCEDE DE FABRICA
                          ObtenerIdMaximoGranelSalida();
                          if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_salida(id_granel_salida,id_granel_entrada,id_solicitud,id_envasado_entrada,litros,grado_alcoholico,id_verificador) VALUES('" + id_max_granel_salida + "', '" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "',0,'" + id_max_envasado_entrada + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["%_ALCOHOLICO"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                          {
                              return;
                          }
                          string litros_granel = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  granel_entrada WHERE  id_granel_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                          double existencia = Math.Round(double.Parse(litros_granel), 2) - Math.Round(double.Parse(dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                          if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada SET lts_existentes=" + existencia + ",actualizado=0 WHERE id_granel_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'") == "Error")
                          {
                              return;
                          }
                      }
                      else
                      {
                          //---- SI EL LOTE PROCEDE DEGRANEL ENVASADO

                          ObtenerIdMaximoGranelSalida();
                          if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_salida(id_granel_salida,id_granel_entrada_envasado,id_solicitud,id_envasado_entrada,litros,grado_alcoholico,id_verificador) VALUES( '" + id_max_granel_salida + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "',0,'" + id_max_envasado_entrada + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value + "','" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["%_ALCOHOLICO"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                          {
                              return;
                          }
                          string litros_granel = ConexionMysql.regresaCampoConsulta("SELECT lts_existentes  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                          double existencia = Math.Round(double.Parse(litros_granel), 2) - Math.Round(double.Parse(dtaLoteparaAlmacen_Envasado.Rows[x].Cells["LITROS"].Value.ToString()), 2);
                          ///---- actualiza la los litros existentes en granel de envasado --
                          if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=ROUND(" + existencia + ",2),actualizado=0 WHERE id_granel_entrada_envasado='" + dtaLoteparaAlmacen_Envasado.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'") == "Error")
                          {
                              return;
                          }
                      }

                  }*/


                /////--- marca la salida del envasado ---
                ObtenerIdMaximoEnvasadoSalida();
                if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_salida  (id_envasado_salida, id_envasado_entrada, id_almacen_envasado_entrada, litros, botellas, grado_alcoholico, id_verificador, actualizado) values('" + id_max_envasado_salida + "','" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "','" + id_max_almacen_envasado_entrada + "'," + ltspor_restar + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["BOTELLAS"].Value.ToString() + "," + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["%_ALCOHOLICO"].Value.ToString() + "," + Usuario.IdUsuario + ",0)") == "Error")
                {
                    return;
                }




                // introduce hologramas a el envasado  
                /// --- para el ingreso de hologramas----

                if (chkTerminaEnvasadoparaAlmacen.Toggled == true)
                {

                    if (chkOstentaEnvasadoAlmacen.Toggled == true)
                    {
                        ObtenerIdMaximoAlmacenEntradaHologramas();
                        string no_cliente = cmbMarcaEnvasadoparaAlmacen.SelectedValue.ToString();
                        no_cliente = no_cliente.Substring(0, 4);

                        string cve_marca = cmbMarcaEnvasadoparaAlmacen.SelectedValue.ToString();

                        int lenght = cve_marca.Length;
                        int mark = lenght == 7 ? 1 : 2;
                        cve_marca = cve_marca.Substring(6, mark);
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_almacen_hologramas + "','" + id_max_almacen_envasado_entrada + "','','','" + txtHologramaInicioAlmacen.Text + "' , '" + txthologramaFinAlmacen.Text + "',''," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }

                    }
                    else
                    {
                        for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                        {
                            ObtenerIdMaximoAlmacenEntradaHologramas();

                            string no_cliente = cmbMarcaEnvasadoparaAlmacen.SelectedValue.ToString();
                            no_cliente = no_cliente.Substring(0, 4);

                            string cve_marca = cmbMarcaEnvasadoparaAlmacen.SelectedValue.ToString();
                            cve_marca = cve_marca.Substring(5, 1);

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_almacen_hologramas + "','" + id_max_almacen_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["INICIO"].Value + "' , '" + DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["FIN"].Value + "','" + DtaHologramasEnvasadoParaALmacen.Rows[x].Cells["SERIE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }

                    }
                }
                else
                {

                    DataSet Datos3 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos3, "SELECT    no_cliente, cve_marca, holograma_inicio, holograma_fin,serie FROM envasado_holograma where id_envasado_entrada='" + dtaLoteparaAlmacen_Envasado.Rows[0].Cells["ID_ENVASADO_ENTRADA"].Value + "'");



                    foreach (DataRow row in Datos3.Tables[0].Rows)
                    {


                        ObtenerIdMaximoAlmacenEntradaHologramas();

                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES('" + id_max_almacen_hologramas + "', '" + id_max_almacen_envasado_entrada + "','" + row["no_cliente"].ToString() + "','" + row["cve_marca"].ToString() + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + row["serie"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }



                }

                ConexionMysql.transCompleta();

                /*  if (ConexionMysql.transCompleta2() == "Error")
                   {

                      return;

                   }
                   else
                   {*/
                // limpia_envasado();
                MessageBox.Show("Éxito");
                chkTerminaEnvasadoparaAlmacen.Toggled = false;
                AlmacenEnvasado();
                CmbNoClienteBodegaEnvasado_SelectedIndexChanged(null, null);
                //}
            }/// fin del eslse Del Dialog MODAL
            /// 
        }


        public void AlmacenEnvasado()
        {

            TxtClaveFqAlmacen.Text = "";
            TxtNoLoteAlmacen.Text = "";
            txtMarcaEnvasado.Text = "";
            txtgradoAlcoholetiqueta.Text = "";
            txtUnidadMedida.Text = "";
            txtContenido.Text = "";
            txtTerminado.Text = "....";



        }///- fin de limpia Almacenenvasado --- 

        private void txtBuscaAlmacen_TextChanged(object sender, EventArgs e)
        {
            if (BanderaAlmacenEnvasadoNoTerminado == true)
            {
                funcion_buscar(DtaProductoAlmacenEnvasadoNoTerminado, txtBuscaAlmacen);

            }
            else if (BanderaAlmacenEnvasado == true)
            {

                funcion_buscar(DtaProductoAlmacenEnvasado, txtBuscaAlmacen);

            }
            else if (BanderaAlmacenEnvasadoSalio == true)
            {
                funcion_buscar(DtaProductoAlmacenEnvasadoSalio, txtBuscaAlmacen);

            }
        }

        private void DtaProductoAlmacenEnvasadoNoTerminado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoAlmacenEnvasadoNoTerminado.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimienEnvasadoNoTerminado frm = new FrmMovimienEnvasadoNoTerminado();

                    frm.id_envasado_entrada = DtaProductoAlmacenEnvasadoNoTerminado.Rows[e.RowIndex].Cells["ID_PRODUCCION_ENVASADO"].Value.ToString();
                    frm.botellas_existentes = DtaProductoAlmacenEnvasadoNoTerminado.Rows[e.RowIndex].Cells["BOTELLAS"].Value.ToString();
                    frm.no_lote = DtaProductoAlmacenEnvasadoNoTerminado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.litros_existentes = DtaProductoAlmacenEnvasadoNoTerminado.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.unidad_medida = DtaProductoAlmacenEnvasadoNoTerminado.Rows[e.RowIndex].Cells["MEDIDA"].Value.ToString();
                    frm.presentacion = DtaProductoAlmacenEnvasadoNoTerminado.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.no_cliente = CmbNoClienteBodegaEnvasado.SelectedValue.ToString();
                    frm.tipo_instalacion = "almacen_envasado";
                    frm.ShowDialog();
                    CmbNoClienteBodegaEnvasado_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DtaProductoAlmacenEnvasado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoAlmacenEnvasado.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimienEnvasado frm = new FrmMovimienEnvasado();

                    frm.id_envasado_entrada = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["ID_PRODUCCION_ENVASADO"].Value.ToString();
                    frm.marca = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();
                    frm.no_lote = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.clase = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.categoria = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.unidad_medida = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["MEDIDA"].Value.ToString();
                    frm.contenido_botella = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.botellas = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["BOTELLAS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoAlmacenEnvasado.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.no_cliente = CmbNoClienteBodegaEnvasado.SelectedValue.ToString();
                    frm.tipo_instalacion = "almacen_envasado";
                    frm.ShowDialog();
                    CmbNoClienteBodegaEnvasado_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtaProductoAlmacenEnvasadoSalio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProductoAlmacenEnvasadoSalio.Columns[e.ColumnIndex].Name == "MOVIMIENTOS")
                {
                    FrmMovimientoEnvasadoSalio frm = new FrmMovimientoEnvasadoSalio();
                    frm.id_envasado_movimientos = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["ID_ALMACEN_ENVASADO_MOVIMIENTOS"].Value.ToString();
                    frm.id_marca = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["ID_MARCA"].Value.ToString();
                    frm.id_envasadora = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["ID_ALMACEN"].Value.ToString();
                    frm.id_planta = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["ID_PLANTA"].Value.ToString();
                    frm.id_predio = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["ID_PREDIO"].Value.ToString();
                    frm.marca = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["MARCA"].Value.ToString();
                    frm.no_lote = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["NO_LOTE"].Value.ToString();
                    frm.clase = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["CLASE"].Value.ToString();
                    frm.categoria = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["CATEGORIA"].Value.ToString();
                    frm.fq = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["CLAVE_FQ"].Value.ToString();
                    frm.abocante = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["ABOCANTE"].Value.ToString();
                    frm.ingrediente = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["INGREDIENTE"].Value.ToString();
                    frm.unidad_medida = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["MEDIDA"].Value.ToString();
                    frm.contenido_botella = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString();
                    frm.botellas = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["BOTELLAS"].Value.ToString();
                    frm.grado_alcoholico = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["%_ALCOHOLICO"].Value.ToString();
                    frm.destino = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["DESTINO"].Value.ToString();
                    frm.litros = DtaProductoAlmacenEnvasadoSalio.Rows[e.RowIndex].Cells["LITROS"].Value.ToString();
                    frm.no_cliente = CmbNoClienteBodegaEnvasado.SelectedValue.ToString();
                    frm.tipo_instalacion = "almacen_envasado";
                    frm.ShowDialog();
                    CmbNoClienteBodegaEnvasado_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnIngresoNoFolioGEnvasado_Click(object sender, EventArgs e)
        {
            FrmNoFolioGranel frm = new FrmNoFolioGranel();

            frm.tipo_instalacion = "granel_envasado";
            frm.id_instalacion = CmbEnvasadora.SelectedValue.ToString(); ;
            frm.no_cliente = CmbNoClienteGranelEnvasado.SelectedValue.ToString();
            frm.ShowDialog();

            string noFolioGranelUnico = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM envasadora_encargado where id_envasadora='" + CmbEnvasadora.SelectedValue + "'AND no_cliente='" + CmbNoClienteGranelEnvasado.SelectedValue + "';");

            if (noFolioGranelUnico == "")
            {
                btnIngresoNoFolioGEnvasado.Visible = true;
                lblFolioGranelEnvasado.Text = "-- S/N Folio --";

            }
            else
            {
                btnIngresoNoFolioGEnvasado.Visible = false;
                lblFolioGranelEnvasado.Text = noFolioGranelUnico;
            }

        }

        private void btnIngresarNoFolioGFabrica_Click(object sender, EventArgs e)
        {

            FrmNoFolioGranel frm = new FrmNoFolioGranel();

            frm.tipo_instalacion = "granel_fabrica";
            frm.id_instalacion = CmbFabricaGranelFabrica.SelectedValue.ToString(); ;
            frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
            frm.ShowDialog();

            string noFolioGranelUnico = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM maestro_fabrica  WHERE id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "' AND no_cliente='" + CmbNoClienteGranel.SelectedValue + "';");

            if (noFolioGranelUnico == "")
            {

                btnIngresarNoFolioGFabrica.Visible = true;
                lblFolioGranel.Text = "-- S/N Folio --";

            }
            else
            {
                btnIngresarNoFolioGFabrica.Visible = false;
                lblFolioGranel.Text = noFolioGranelUnico;
            }
        }

        private void btnNewMaestromezcalero_Click(object sender, EventArgs e)
        {

            FrmNewMaestroMezcalero frm = new FrmNewMaestroMezcalero();

            frm.no_cliente = CmbNoCliente.SelectedValue.ToString();
            frm.id_fabrica = CmbFabrica.SelectedValue.ToString();
            frm.id_maestro_mezcalero_actual_prod = id_maestro_mezcalero;
            frm.ShowDialog();

            // TxtMaestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT if(maestro = '' or maestro is null,(SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'),maestro) as maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabrica.SelectedValue + "'");

            TxtMaestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'");

            id_maestro_mezcalero = ConexionMysql.regresaCampoConsulta("SELECT mm.id_maestros_mezcaleros FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'");


        }

        private void btnNewMaestroMEzcaleroFabrica_Click(object sender, EventArgs e)
        {


            FrmNewMaestroMezcalero frm = new FrmNewMaestroMezcalero();

            frm.no_cliente = CmbNoClienteGranel.SelectedValue.ToString();
            frm.id_fabrica = CmbFabricaGranelFabrica.SelectedValue.ToString();
            frm.id_maestro_mezcalero_actual_prod = ConexionMysql.regresaCampoConsulta("SELECT mm.id_maestros_mezcaleros FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'");
            frm.ShowDialog();

            // TxtMestroMezcaleroGranelFabrica.Text = ConexionMysql.regresaCampoConsulta("SELECT if(maestro = '' or maestro is null,(SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'),maestro) as maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'");


            TxtMestroMezcaleroGranelFabrica.Text = ConexionMysql.regresaCampoConsulta("SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'");

            //-- id_maestro_mezcalero = ConexionMysql.regresaCampoConsulta("SELECT mm.id_maestros_mezcaleros FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "'");

        }

        private void TxtNoGuia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida.soloNumeros(e);
        }

        private void TxtNoGuia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (TxtNoGuia.Text == "")
                    {
                        TxtNoGuia.Text = "";
                        TxtNoPredio.Text = "";
                        TxtPredio.Text = "";
                        CmbNoPredio.DataSource = null;
                        // CmbMaguey.Enabled = false;
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                        return;
                    }
                    else

                    if (TxtNoGuia.Text.Substring(0,1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G") 
                    {
                       // MessageBox.Show("con g");
                    DataSet DatosMaguey = new DataSet();
                    ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=1 and  cextracciones.id_extraccion like '" + TxtNoGuia.Text.Trim() + "'");
                    if (DatosMaguey.Tables[0].Rows.Count == 0)
                    {
                        /* + los valores de de status son:
                         * 0 - ya utilizada
                         * 1 - no utilizada
                         */
                        string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=0 and  cextracciones.id_extraccion like '" + TxtNoGuia.Text.Trim() + "'");

                        if (guia_utilizada == "") 
                        { 
                            MessageBox.Show("Guia inexistente");
                        } 
                        else 
                        { 
                            MessageBox.Show("Guia ya utilizada"); 
                        };

                        // MessageBox.Show("Guia inexistente o ya utilizada");
                        TxtNoPredio.Text = "";
                        //TxtNoCliente.Text = "";
                        //TxtNombre.Text = "";
                        TxtPredio.Text = "";
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                        TxtExtraccion.Text = "";
                        // TxtDireccion.Text = "";
                        // dts.Tables["EXTRACCION"].Rows.Clear();
                        return;
                    }
                    TxtNoPredio.Text = DatosMaguey.Tables[0].Rows[0]["id_paraje"].ToString();
                    // TxtNoCliente.Text = DatosMaguey.Tables[0].Rows[0]["id_cliente"].ToString();
                    //TxtNombre.Text = DatosMaguey.Tables[0].Rows[0]["nombrep"].ToString();
                    TxtPredio.Text = DatosMaguey.Tables[0].Rows[0]["paraje"].ToString();
                    DatosMaguey.Tables[0].Rows.Clear();
                    CmbMaguey.DataSource = null;
                    TxtExistencia.Text = "";
                    TxtExtraccion.Text = "";
                    //  ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                    }

                    else
                    {
                        MessageBox.Show("El uso de guías CRM por este método, se ha deshabilitado, úsalas como guía externa");
                        /*DataSet DatosMaguey = new DataSet();
                        ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=1 and  reveca2_cextracciones.id_extraccion =" + TxtNoGuia.Text.Trim() + "");
                        
                        if (DatosMaguey.Tables[0].Rows.Count == 0)
                        {
                            
                            string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=0 and  reveca2_cextracciones.id_extraccion =" + TxtNoGuia.Text.Trim() + "");

                            if (guia_utilizada == "")
                            {
                                MessageBox.Show("Guia inexistente");
                            }
                            else
                            {
                                MessageBox.Show("Guia ya utilizada");
                            };


                            TxtNoPredio.Text = "";
                             TxtPredio.Text = "";
                            CmbMaguey.DataSource = null;
                            TxtExistencia.Text = "";
                            TxtExtraccion.Text = "";

                            return;
                        }
                        TxtNoPredio.Text = DatosMaguey.Tables[0].Rows[0]["id_paraje"].ToString();
                        
                        TxtPredio.Text = DatosMaguey.Tables[0].Rows[0]["paraje"].ToString();
                        DatosMaguey.Tables[0].Rows.Clear();
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                        TxtExtraccion.Text = "";
                        
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                    */
                    }                       

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PanelProduccion_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion

        // Se manda a llamar al form de las mermas
        private void btnMermasHolograma_Click(object sender, EventArgs e)
        {
            frmMermasHologramas mermas = new frmMermasHologramas();
            mermas.cliente = CmbNoCliente.Text;
           
            mermas.ShowDialog();
        }

        private void DtaProduccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PanelEnvasado_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void pnlAlmacen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DtaProductoEnvasado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DtaProductoVidrioEnvasado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlAlmacendeGraneles_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
