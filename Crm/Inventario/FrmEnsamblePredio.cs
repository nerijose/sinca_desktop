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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Crm.Inventario
{
    public partial class FrmEnsamblePredio : Form
    {
        public FrmEnsamblePredio()
        {
            InitializeComponent();
        }
        public string no_cliente = "0";
        public string id_produccion_existente = "";
        public bool modo_completar_tapada = false;
        string id_predio_agave_sobrante = "";
        string id_plnata_agave_sobrante = "";
        string id_produccion_entrada_sobrante = "";
        string id_agave_sobrante = "";
        string id_predio_comprado = "";
        string predio_comprado = "";
        string predio_sobrante = "";
        string porcen_art_sobrante = "";
        string planta_sobrante = "";
        string seleccionTipoMaguey = "";
        string no_predio = "";

        string no_guia = "";
        Validacion valida = new Validacion();
        DataSet dts;

        string id_maestro_mezcalero = "";



        string id_max_produccion_entrada = "";
        string id_max_agave_sobrante = "";
        string id_max_produccion_ensamble_union = "";
        //string id_max_produccion_agave_sobrante = "";
        //string id_max_ensamble = "";



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




        public void ObtenerIdMaximoProduccionEnsamble()
        {
            id_max_produccion_ensamble_union = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_ensamble_union,4)) )  FROM produccion_ensamble where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_produccion_ensamble_union == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_produccion_ensamble_union = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_produccion_ensamble_union = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_produccion_ensamble_union) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_produccion_ensamble_union = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_produccion_ensamble_union = Usuario.IdUsuario + "-" + suma;
                }
            }
        }



        //public void ObtenerIdMaximoProduccionAgaveSobrante()
        //{
        //    id_max_produccion_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT max(id_produccion_agave_sobrante) max FROM produccion_agave_sobrante where id_ruta=" + Usuario.IdRuta + "");
        //    if (id_max_produccion_agave_sobrante == "")
        //    {
        //        id_max_produccion_agave_sobrante = "1";
        //    }
        //    else
        //    {
        //        int suma = int.Parse(id_max_produccion_agave_sobrante) + 1;
        //        id_max_produccion_agave_sobrante = suma.ToString();
        //    }
        //}


        //public void ObtenerIdMaximoProduccionEnsamble()
        //{
        //    id_max_ensamble = ConexionMysql.regresaCampoConsulta("SELECT max(id_ensamble) max FROM produccion_ensamble where id_ruta=" + Usuario.IdRuta + "");
        //    if (id_max_ensamble == "")
        //    {
        //        id_max_ensamble = "1";
        //    }
        //    else
        //    {
        //        int suma = int.Parse(id_max_ensamble) + 1;
        //        id_max_ensamble = suma.ToString();
        //    }
        //}




        private void FrmEnsamblePredio_Load(object sender, EventArgs e)
        {
            try
            {
                addTablas();
                lblNo_Usuario.Text = no_cliente;
                ConexionMysql.llenaCombo(ref CmbCoccion, "SELECT id_coccion,coccion FROM cat_coccion", "id_coccion", "coccion");
                // ConexionMysql.llenaCombo(ref CmbNoPredio, "SELECT id_paraje FROM paraje where id_cliente='" + no_cliente + "'", "id_paraje", "id_paraje");
                ConexionMysql.llenaCombo(ref CmbFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + no_cliente + "'", "id_fabrica", "fabrica");
                if (Usuario.FabricaSeleccionada != "0")
                {
                    CmbFabrica.SelectedValue = Usuario.FabricaSeleccionada;
                }

                if (modo_completar_tapada && id_produccion_existente != "")
                {
                    // Desactivar campos que no aplican o no deben editarse en modo completar (ej. nombre de tapada, fecha, coccion)
                    TxtTapada.Enabled = false;
                    CmbCoccion.Enabled = false;
                    DataFechaInicioCoccion.Enabled = false;
                    
                    // Ocultar Controles que el usuario pidió no mostrar
                    CmbFabrica.Visible = false;
                    label38.Visible = false;
                    grpConfiguracionFinal.Visible = false;

                    // Opcionalmente: poner el text del form
                    string nombreTapada = ConexionMysql.regresaCampoConsulta("SELECT tapada FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion_existente + "'");
                    TxtTapada.Text = nombreTapada;
                    this.Text = "Completar Maguey/Guía de Tapada: " + nombreTapada;
                    
                    id_maestro_mezcalero = ConexionMysql.regresaCampoConsulta("SELECT id_maestro_mezcalero FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion_existente + "'");
                    
                    string idFabricaTapada = ConexionMysql.regresaCampoConsulta("SELECT id_fabrica FROM produccion_entrada WHERE id_produccion_entrada='" + id_produccion_existente + "'");
                    if (idFabricaTapada != "") {
                        CmbFabrica.SelectedValue = idFabricaTapada;
                    }
                }

                CmbTipoMaguey.Items.Insert(0, "Ingresar Guía AMMA y Antigua");
                CmbTipoMaguey.Items.Insert(1, "Ingresar Guía Externa");
                CmbTipoMaguey.Items.Insert(2, "Maguey Comprado");
                CmbTipoMaguey.Items.Insert(3, "Maguey Sobrante");
                //CmbTipoMaguey.Items.Insert(3, "Guía Externa");
                //ConexionMysql.llenaComboAutocomplit(ref CmbTipoMaguey, "SELECT clave, nombre FROM estados WHERE dom = '1' ", "clave", "nombre");
                AplicarEstilosGroupBox();
                MejorarDataGridView();
                MejorarBotones();
                ConfigurarValidacionesVisuales();
                InicializarToolTips();

                TxtNoGuia.Enabled = false;
                TxtNoPredio.Enabled = false;
                CmbNoPredio.Enabled = false;
                CmbMaguey.Enabled = false;
                TxtExtraccion.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //al seleccuinar numero d epredio carga los maguey y verifica si ya fue usado
        private void CmbNoPredio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbMaguey.DataSource = null;
                TxtPredio.Text = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  paraje  WHERE id_paraje= '" + CmbNoPredio.SelectedValue + "'");
                if (DtaEnsamble.Rows.Count > 0)
                {
                    PlantasNoMostrar();
                }
                else
                {
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (', especie.genespecie,')' ) as Maguey, existenciaplanta.paraje_id paraje_id FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 and existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //al seleccionar maguey carga sus existencias de la planta
        private void CmbMaguey_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TxtExistencia.Text = "";
                TxtExtraccion.Text = "";
                if (CmbMaguey.DataSource != null)
                {


                    
                    Console.WriteLine("seleccionCMbMaguey:" + "Selected item: " + CmbMaguey.SelectedIndex.ToString());

                    DataTable miTabla = (DataTable)CmbMaguey.DataSource;
                    if (miTabla != null && miTabla.Rows.Count > 0)
                    {
                        // La tabla tiene datos
                        Console.WriteLine("La tabla contiene " + miTabla.Rows.Count + " filas.");
                    }
                    else
                    {
                        // La tabla está vacía o es nula
                        Console.WriteLine("La tabla está vacía o es nula.");
                    }
                    /*foreach (DataRow fila in miTabla.Rows)
                    {
                        Console.WriteLine("fila:"+fila.ToString());
                        // Accede a las celdas de la fila como lo harías normalmente
                        // Por ejemplo, si tienes una columna llamada "Nombre"
                        //string id_plantas = fila["id_plantas"].ToString();
                        /*string nombre = fila["Maguey"].ToString();
                        string id_paraje = fila["id_paraje"].ToString();
                        Console.WriteLine("Valor Seleccionado:"+CmbMaguey.SelectedValue);
                        Console.WriteLine(id_paraje);
                    }*/

                    object valorSeleccionado = CmbTipoMaguey.SelectedItem;
                    string valor = valorSeleccionado.ToString();
                    if (valor == "Maguey Comprado" || valor == "Maguey Sobrante")
                    {
                        TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente IN (SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "') UNION " +
                                                                                " SELECT existenciaplantas FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + no_cliente + "'");
                        no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente IN (SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "') UNION " +
                                                                     " SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + no_cliente + "'");
                        id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  reveca2_existenciaplanta inner join reveca2_existenciaplanta_comprada on reveca2_existenciaplanta_comprada.id_planta=reveca2_existenciaplanta.id_plantas WHERE reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' UNION " +
                                                                                " SELECT id_paraje FROM  existenciaplanta inner join existenciaplanta_comprada on existenciaplanta_comprada.id_planta=existenciaplanta.id_plantas WHERE existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                        predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  paraje  WHERE id_paraje='" + id_predio_comprado + "' UNION" +
                                                                                            " SELECT paraje FROM  reveca2_paraje  WHERE id_paraje='" + id_predio_comprado + "'");
                    }
                    else if (valor != "Ingresar Guía Externa")
                    {
                        Console.WriteLine("DOnde no sea guía externa");
                        if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                        {
                            Console.WriteLine("DOnde no sea guía externa con G");
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            id_predio_comprado = "";
                            predio_comprado = "";
                        }
                        else
                        {
                            Console.WriteLine("DOnde no sea guía externa sin G");
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            id_predio_comprado = "";
                            predio_comprado = "";
                        }
                    }
                    TxtExtraccion.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //agrega temporalmente las extracciones en una tabla
        private void BtnAgregarProduccion_Click(object sender, EventArgs e)//BtnAgregarProduccion
        {
            try
            {
                object valorSeleccionado = CmbTipoMaguey.SelectedItem;
                if (valorSeleccionado != null)
                {
                    string valor = valorSeleccionado.ToString();

                    //if (valor == "Maguey Comprado" || valor == "Maguey Sobrante")
                    //if (ChekAgaveSobrante.Checked == true)
                    if (valor == "Maguey Sobrante")
                    {
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
                    }
                    else
                    {


                        //if (ChekMagueyComprado.Checked == false)
                        if (valor != "Maguey Comprado" && valor != "Ingresar Guía Externa")
                        {
                            if (TxtNoGuia.Text == "")
                            {

                                MessageBox.Show("No tiene numero de guia");
                                return;

                            }
                        }

                        if (CmbMaguey.SelectedValue != null)
                        {
                            if (valor != "Ingresar Guía Externa")
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


                    }


                    DataRow fila = dts.Tables["ENSAMBLE"].NewRow();

                    //if (ChekMagueyComprado.Checked == true && ChekAgaveSobrante.Checked == false)
                    if (valor == "Maguey Comprado")
                    {
                        fila["ID_PARAJE"] = id_predio_comprado;
                        fila["PREDIO"] = predio_comprado;
                        
                        if (id_predio_comprado.Substring(0, 1) == "P")
                        {
                            fila["ID_PLANTA"] = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                            fila["NO_GUIA"] = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                        }
                        else
                        {
                            fila["ID_PLANTA"] = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                            fila["NO_GUIA"] = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                        }
                        fila["TIPO"] = 3; // MAGUEY COMPRADO
                        fila["MAGUEY"] = CmbMaguey.Text;
                        fila["ID_PLANTA_COMPRADA"] = CmbMaguey.SelectedValue;
                    }
                    else if (valor == "Maguey Sobrante")
                    {
                        //else if (ChekAgaveSobrante.Checked == true)
                        if (id_predio_agave_sobrante == "")
                        {
                            fila["ID_PARAJE"] = 0;
                            fila["PRODUCCION_SALIO"] = id_produccion_entrada_sobrante;
                        }
                        else
                        {
                            fila["ID_PARAJE"] = id_predio_agave_sobrante;
                            fila["PRODUCCION_SALIO"] = "";
                        }

                        fila["PREDIO"] = predio_sobrante;
                        fila["ID_PLANTA"] = id_plnata_agave_sobrante;
                        fila["TIPO"] = 4;
                        fila["MAGUEY"] = planta_sobrante;
                        fila["NO_GUIA"] = "";
                    }
                    else if (valor == "Ingresar Guía Externa")
                    {
                        
                        fila["ID_PARAJE"] = 0;
                        fila["PRODUCCION_SALIO"] = "";

                        //fila["PREDIO"] = predio_sobrante;
                        fila["PREDIO"] = TxtPredio.Text;
                        //fila["ID_PLANTA"] = id_plnata_agave_sobrante;
                        fila["ID_PLANTA"] = 0;
                        fila["TIPO"] = 4;
                        fila["MAGUEY"] = CmbMaguey.Text;
                        fila["ID_PLANTA_COMPRADA"] = CmbMaguey.SelectedValue;
                        fila["NO_GUIA"] = TxtNoGuia.Text;
                    }
                    else
                    {


                        fila["NO_GUIA"] = TxtNoGuia.Text;

                        fila["ID_PARAJE"] = TxtNoPredio.Text;

                        fila["PREDIO"] = TxtPredio.Text;
                        if (CmbMaguey.SelectedValue == null)
                        {
                            fila["ID_PLANTA"] = 0;
                        }
                        else
                        {
                            fila["ID_PLANTA"] = CmbMaguey.SelectedValue;
                        }

                        fila["TIPO"] = 1;
                        fila["MAGUEY"] = CmbMaguey.Text;

                    }
                    fila["ID_AGAVE_SOBRANTE"] = id_agave_sobrante;
                    fila["%_ART"] = TxtArt.Text;
                    fila["NUMERO_PIÑA"] = TxtExtraccion.Text;
                    fila["MAGUEY_ENTRANTE"] = TxtAgaveEntranteKg.Text;
                    fila["MAGUEY_COCCION"] = TxtAgaveCoccion.Text;

                    fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);

                    string idParaje = fila["ID_PARAJE"].ToString();
                    if (idParaje.Substring(0, 1) == "P")
                    {
                        fila["REGAMMA"] = "si";
                    }
                    else
                    {
                        fila["REGAMMA"] = "no";
                    }

                    dts.Tables["ENSAMBLE"].Rows.Add(fila);
                    CmbMaguey.DataSource = null;
                    PlantasNoMostrar();
                    LimpiarDespuesDeAgregarPlanta();

                    string produccion = "";
                    string coma = "";
                    //if (ChekMagueyComprado.Checked == true)
                    /*if (valor == "Maguey Comprado")
                    {
                        for (int x = 0; x < DtaEnsamble.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaEnsamble.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "'";
                            coma = ",";
                        }


                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')') as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN (" + produccion + ")  and   existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");

                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // crea la tabla
        private void addTablas()
        {
            dts = new DataSet();
            dts.Tables.Add("ENSAMBLE");
            dts.Tables["ENSAMBLE"].Columns.Add("ID_PLANTA", Type.GetType("System.Int32"));
            dts.Tables["ENSAMBLE"].Columns.Add("ID_PARAJE", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("TIPO", Type.GetType("System.Int32"));
            dts.Tables["ENSAMBLE"].Columns.Add("PRODUCCION_SALIO", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("ID_AGAVE_SOBRANTE", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("PREDIO", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("MAGUEY", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("NUMERO_PIÑA", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("MAGUEY_ENTRANTE", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("MAGUEY_COCCION", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("%_ART", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("NO_GUIA", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("ID_PLANTA_COMPRADA", Type.GetType("System.String"));
            dts.Tables["ENSAMBLE"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            dts.Tables["ENSAMBLE"].Columns.Add("REGAMMA", Type.GetType("System.String"));
            DtaEnsamble.DataSource = dts.Tables["ENSAMBLE"];
            /*DtaEnsamble.Columns[0].Visible = false;
            DtaEnsamble.Columns[1].Visible = false;
            DtaEnsamble.Columns[2].Visible = false;
            DtaEnsamble.Columns[3].Visible = false;
            DtaEnsamble.Columns[4].Visible = false;
            DtaEnsamble.Columns[11].Visible = false;
            DtaEnsamble.Columns[12].Visible = false;*/

        }

        ///verifica si ya se uso una planta 
        ///Muestra las plantas compradas
        public void PlantasNoMostrar()
        {
            string plantas = "0";
            string coma = "";
            for (int x = 0; x < DtaEnsamble.Rows.Count; x++)
            {

                //ESTE IF SIRVE CUANDO EL AGAVE ES SOBRANTE NO BLOQUEE LA SPLANTAS DEL MISMO ID
                if (DtaEnsamble.Rows[x].Cells["TIPO"].Value.ToString() != "4")
                {
                    if (DtaEnsamble.Rows[x].Cells["TIPO"].Value.ToString() == "3")
                    {
                        plantas += coma + DtaEnsamble.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value;
                        coma = ",";
                    }
                    else
                    {
                        plantas += coma + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value;
                        coma = ",";
                    }
                }

            }
            object valorSeleccionado = CmbTipoMaguey.SelectedItem;
            if (valorSeleccionado != null)
            {
                string valor = valorSeleccionado.ToString();
                // if (ChekMagueyComprado.Checked == true)
                if (valor == "Maguey Comprado")
                {
                    ConexionMysql.llenaCombo(ref CmbMaguey, 
                        "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta," +
                        " CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey, " +
                        " existenciaplanta.id_paraje id_paraje FROM  existenciaplanta " +
                        " INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun " +
                        " INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas " +
                        " INNER JOIN especie on comun.id_especie=especie.id_especie " +
                        " WHERE  existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN(" + plantas + ")  " +
                        " AND   existenciaplanta_comprada.no_cliente='" + no_cliente + "' " +
                        " AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                }
                else
                {
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey, existenciaplanta.id_paraje id_paraje FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_plantas NOT IN(" + plantas + ")  AND  existenciaplanta.id_paraje='" + (CmbNoPredio.SelectedValue == null ? 0 : CmbNoPredio.SelectedValue) + "' AND edad>=5 and existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                }
                if (CmbMaguey.Items.Count == 0)
                {
                    TxtExistencia.Text = "";
                }
            }
        }

        public void LimpiarDespuesDeAgregarPlanta()
        {
            TxtExtraccion.Text = "";
            TxtAgaveEntranteKg.Text = "";
            TxtAgaveCoccion.Text = "";
            TxtArt.Text = "";
            TxtArt.Enabled = true;
            TxtNoPredio.Text = "";
            TxtPredio.Text = "";
            TxtNoGuia.Text = "";
            CmbMaguey.DataSource = null;
            TxtExistencia.Text = "";
            TxtExtraccion.Text = "";
            TxtNoGuia.Enabled = false;
            TxtExtraccion.Enabled = false;
            CmbMaguey.Enabled = false;
            CmbTipoMaguey.DataSource = null;
            CmbTipoMaguey.Items.Clear();
            CmbTipoMaguey.Items.Insert(0, "Ingresar Guía AMMA y Antigua");
            CmbTipoMaguey.Items.Insert(1, "Ingresar Guía Externa");
            CmbTipoMaguey.Items.Insert(2, "Maguey Comprado");
            CmbTipoMaguey.Items.Insert(3, "Maguey Sobrante");



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

        //elimina extraccion de maguey
        private void DtaEnsamble_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaEnsamble.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaEnsamble.Rows.RemoveAt(e.RowIndex);
                    dts.Tables["ENSAMBLE"].AcceptChanges();
                    CmbMaguey.DataSource = null;

                    if (ChekMagueyComprado.Checked == true)
                    {
                        if (DtaEnsamble.Rows.Count > 0)
                        {
                            PlantasNoMostrar();
                        }
                        else
                        {
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey, existenciaplanta.id_paraje id_paraje  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                        }
                    }
                    else
                    {
                        if (DtaEnsamble.Rows.Count > 0)
                        {
                            PlantasNoMostrar();
                        }
                        else
                        {
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (', especie.genespecie,')' ) as Maguey, existenciaplanta.id_paraje id_paraje FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 and existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //guardar el ensamble
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DtaEnsamble.Rows.Count < 1)
                {
                    MessageBox.Show("No ha agregado ningún maguey a la molienda/ensamble");
                    return;
                }
                if (CmbFabrica.Visible && CmbFabrica.SelectedValue == null)
                {
                    MessageBox.Show("No tienes fabrica disponible para seleccion");
                    return;
                }
                if (TxtTapada.Visible && TxtTapada.Text == "")
                {
                    MessageBox.Show("No ha introduccido el nombre de la tapada");
                    return;
                }
                if (CmbCoccion.Visible && CmbCoccion.SelectedValue == null)
                {
                    MessageBox.Show("No tienes cocciones precargadas, actualiza la base de datos");
                    return;
                }

                DateTime local = DateTime.Now;
                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");

                double art_compuesto = 0;
                double suma_agave_por_art = 0;
                double suma_agave_kg = 0;
                Boolean bandera = false;

                //recorremos la tabla ensamble PARA CALCULAR ART
                for (int x = 0; x < DtaEnsamble.Rows.Count; x++)
                {
                    if (DtaEnsamble.Rows[x].Cells["%_ART"].Value.ToString() != "0")
                    {
                        bandera = true;
                        suma_agave_por_art += Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value.ToString()), 2) * Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["%_ART"].Value.ToString()), 2);
                        suma_agave_kg += Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value.ToString()), 2);
                    }
                    else
                    {
                        bandera = false;
                        break;
                    }
                }

                if (bandera == true)
                {
                    art_compuesto = Math.Round(suma_agave_por_art / suma_agave_kg, 2);
                }

                //================================================================>>> Confirmacion de datos a ingresar <<<============

                string f = lblNo_Usuario.Text;
                string o = CmbFabrica.Text;

                string p = "";
                string pp = "";
                string p3 = "";
                string p4 = "";
                string p5 = "";
                string p6 = "";

                //string produccion = "";
                string coma = "";
                //--->>-Mustra la lista de los DatagredView
                for (int x = 0; x < DtaEnsamble.Rows.Count; x++)
                {
                    // p += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["NO_LOTE"].Value + " ' ";
                    //pp += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["LITROS"].Value + " ' ";
                    //p3 += coma + "'" + DtaProduccionParaGuardarAgranelEnvasado.Rows[x].Cells["%_ALCOHOLICO"].Value + " ' ";



                    p += coma + "'" + DtaEnsamble.Rows[x].Cells["PREDIO"].Value + "'\n";
                    pp += coma + "'" + DtaEnsamble.Rows[x].Cells["MAGUEY"].Value + "'\n";
                    p3 += coma + "'" + DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value + "'\n";
                    p4 += coma + "'" + DtaEnsamble.Rows[x].Cells["MAGUEY_ENTRANTE"].Value + "'\n";
                    p5 += coma + "'" + DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value + "'\n";
                    p6 += coma + "'" + DtaEnsamble.Rows[x].Cells["%_ART"].Value + "'\n";
                    coma = " ";

                }
                string t = TxtTapada.Text;
                string a = CmbCoccion.Text;
                string b = DataFechaInicioCoccion.Text;





                string dto = f + "!" + o + "!" + p + "!" + pp + "!" + p3 + "!" + p4 + "!" + p5 + "!" + p6 + "!" + t + "!" + a + "!" + b;

                MsgBxGranelenvasado msg = new MsgBxGranelenvasado();
                msg.Ensambleok(dto);
                msg.ShowDialog();

                if (msg.DialogResult == DialogResult.Cancel) { return; }
                else
                {


                    id_maestro_mezcalero = ConexionMysql.regresaCampoConsulta("SELECT mm.id_maestros_mezcaleros FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'");






                    ObtenerIdMaximoProduccionEntrada();

                    string p_id_predio = "0";
                    string p_id_planta = "0";
                    string p_no_pinas = "0";
                    string p_agave_kg = "0";
                    string p_agave_coccion = "0";
                    string p_tipo = "2";
                    string p_id_comun = "0";
                    string p_gcrm = "0";
                    string p_no_guia = "0";
                    
                    string cols_extra = "";
                    string vals_extra = "";

                    if (DtaEnsamble.Rows.Count == 1)
                    {
                        p_tipo = "1";
                        p_id_predio = DtaEnsamble.Rows[0].Cells["ID_PARAJE"].Value != null && DtaEnsamble.Rows[0].Cells["ID_PARAJE"].Value.ToString() != "" ? DtaEnsamble.Rows[0].Cells["ID_PARAJE"].Value.ToString() : "0";
                        p_id_planta = DtaEnsamble.Rows[0].Cells["ID_PLANTA"].Value != null && DtaEnsamble.Rows[0].Cells["ID_PLANTA"].Value.ToString() != "" ? DtaEnsamble.Rows[0].Cells["ID_PLANTA"].Value.ToString() : "0";
                        p_no_pinas = DtaEnsamble.Rows[0].Cells["NUMERO_PIÑA"].Value != null && DtaEnsamble.Rows[0].Cells["NUMERO_PIÑA"].Value.ToString() != "" ? DtaEnsamble.Rows[0].Cells["NUMERO_PIÑA"].Value.ToString() : "0";
                        p_agave_kg = DtaEnsamble.Rows[0].Cells["MAGUEY_ENTRANTE"].Value != null && DtaEnsamble.Rows[0].Cells["MAGUEY_ENTRANTE"].Value.ToString() != "" ? DtaEnsamble.Rows[0].Cells["MAGUEY_ENTRANTE"].Value.ToString() : "0";
                        p_agave_coccion = DtaEnsamble.Rows[0].Cells["MAGUEY_COCCION"].Value != null && DtaEnsamble.Rows[0].Cells["MAGUEY_COCCION"].Value.ToString() != "" ? DtaEnsamble.Rows[0].Cells["MAGUEY_COCCION"].Value.ToString() : "0";
                        p_no_guia = DtaEnsamble.Rows[0].Cells["NO_GUIA"].Value != null && DtaEnsamble.Rows[0].Cells["NO_GUIA"].Value.ToString() != "" ? DtaEnsamble.Rows[0].Cells["NO_GUIA"].Value.ToString() : "0";

                        if (DtaEnsamble.Rows[0].Cells["REGAMMA"].Value != null && DtaEnsamble.Rows[0].Cells["REGAMMA"].Value.ToString() != "si" && p_id_predio == "0")
                        {
                            p_id_comun = DtaEnsamble.Rows[0].Cells["ID_PLANTA_COMPRADA"].Value != null && DtaEnsamble.Rows[0].Cells["ID_PLANTA_COMPRADA"].Value.ToString() != "" ? DtaEnsamble.Rows[0].Cells["ID_PLANTA_COMPRADA"].Value.ToString() : "0";
                            p_gcrm = "1";
                            cols_extra = ", id_comun, gcrm";
                            vals_extra = ", '" + p_id_comun + "', '" + p_gcrm + "'";
                        }

                        cols_extra += ", no_guia";
                        vals_extra += ", '" + p_no_guia + "'";
                    }

                    //codigo para guardar una produccion 
                    string sqlEnt = "";
                    if (modo_completar_tapada && id_produccion_existente != "")
                    {
                        // En modo completar, hacemos un UPDATE a la tapada existente. Solo guardaremos los datos modificados.
                        // La lógica para extraer el id correcto de "modo edición" en vez de id_max_produccion_entrada
                        id_max_produccion_entrada = id_produccion_existente;
                        
                        string update_guia_extra = "";
                        if (p_tipo == "1") {
                            update_guia_extra = ", no_guia='" + p_no_guia + "'";
                            if (p_gcrm == "1") {
                                update_guia_extra += ", id_comun='" + p_id_comun + "', gcrm='1'";
                            } else {
                                update_guia_extra += ", gcrm='0'";
                            }
                        }

                        sqlEnt = "UPDATE produccion_entrada SET " +
                                 "id_predio='" + p_id_predio + "', " +
                                 "id_planta='" + p_id_planta + "', " +
                                 "no_pinas_agave=" + p_no_pinas + ", " +
                                 "agave_kg=" + p_agave_kg + ", " +
                                 "agave_coccion_kg=" + p_agave_coccion + ", " +
                                 "tipo=" + p_tipo + 
                                 update_guia_extra + 
                                 " WHERE id_produccion_entrada='" + id_produccion_existente + "'";
                    }
                    else
                    {
                        // Inserción normal de nueva tapada
                        sqlEnt = "INSERT INTO produccion_entrada(id_fabrica,id_maestro_mezcalero,id_produccion_entrada,no_cliente,id_predio,id_planta,tapada,no_pinas_agave,agave_kg,agave_coccion_kg,id_coccion,periodo_coccion_inicio,porcentaje_art,id_verificador,fecha,estatus,tipo" + cols_extra + ") VALUES('" + CmbFabrica.SelectedValue + "', '" + id_maestro_mezcalero + "','" + id_max_produccion_entrada + "','" + no_cliente + "','" + p_id_predio + "','" + p_id_planta + "','" + TxtTapada.Text + "'," + p_no_pinas + "," + p_agave_kg + "," + p_agave_coccion + "," + CmbCoccion.SelectedValue + ",'" + DataFechaInicioCoccion.Value.ToString("yyyy-MM-dd") + "'," + art_compuesto + "," + Usuario.IdUsuario + ",'" + fecha + "',1," + p_tipo + vals_extra + ")";
                    }

                    if (ConexionMysql.insUpd_transaccion(sqlEnt) == "Error")
                    {
                        return;
                    }


                    //recorremos la tabla ensamble 
                    for (int x = 0; x < DtaEnsamble.Rows.Count; x++)
                    {

                        ObtenerIdMaximoProduccionEnsamble();

                        //controla si hay maguey sobrante
                        if (Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_ENTRANTE"].Value.ToString()), 2) > Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value.ToString()), 2))
                        {
                            ObtenerIdMaximoAgaveSobrante();
                            double sobrante = Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_ENTRANTE"].Value.ToString()), 2) - Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value.ToString()), 2);

                            //SI EL SOBRANTE ES DE UNA PRODUCCION QUE NO SE SABE SU PROCEDENCIA
                            if (DtaEnsamble.Rows[x].Cells["PRODUCCION_SALIO"].Value.ToString() == "" && DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value.ToString() != "0")
                            {
                                string resultado = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_agave_sobrante  WHERE no_cliente='" + no_cliente + "'  and id_planta=" + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + "");
                                if (resultado != "")
                                {
                                    //calcula el art si se sabe cuanto tiene los dos agaves sobrantes  para actualizar el agave sobrante 
                                    if (resultado != "0" && Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["%_ART"].Value.ToString()), 2) != 0)
                                    {
                                        string kg_agave_crudo = ConexionMysql.regresaCampoConsulta("SELECT agave_kg FROM  produccion_agave_sobrante  WHERE no_cliente='" + no_cliente + "'  and id_planta=" + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + " ");
                                        double suma = Math.Round(double.Parse(kg_agave_crudo), 2) * Math.Round(double.Parse(resultado), 2);
                                        suma += Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value.ToString()), 2) * Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["%_ART"].Value.ToString()), 2);
                                        double resultado1 = suma / (Math.Round(double.Parse(kg_agave_crudo), 2) + Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value.ToString()), 2));
                                        resultado = Math.Round(resultado1, 2).ToString();
                                    }
                                    else
                                    {
                                        resultado = "0";
                                    }
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET  agave_kg= agave_kg +" + sobrante + ",porcentaje_art=" + resultado + ",actualizado=0 WHERE id_planta=" + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + " and no_cliente='" + no_cliente + "'") == "Error")
                                    {
                                        return;
                                    }
                                }
                                else
                                {

                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_agave_sobrante(id_agave_sobrante,no_cliente,id_planta,agave_kg,porcentaje_art,id_verificador) VALUES('" + id_max_agave_sobrante + "','" + no_cliente + "'," + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + "," + sobrante + "," + DtaEnsamble.Rows[x].Cells["%_ART"].Value + "," + Usuario.IdUsuario + ")") == "Error")
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //busca si el sobrante es de una extraccion no registrada (paeaje,planta)
                                string resultado2 = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_agave_sobrante  WHERE id_agave_sobrante='" + DtaEnsamble.Rows[x].Cells["ID_AGAVE_SOBRANTE"].Value + "'");
                                if (resultado2 == "")
                                {
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_agave_sobrante(id_agave_sobrante,id_ensamble_union,id_produccion_entrada,no_cliente,id_planta,agave_kg,porcentaje_art,id_verificador) VALUES('" + id_max_agave_sobrante + "','" + id_max_produccion_ensamble_union + "','" + id_max_produccion_entrada + "','" + no_cliente + "',0," + sobrante + "," + DtaEnsamble.Rows[x].Cells["%_ART"].Value + "," + Usuario.IdUsuario + ")") == "Error")
                                    {
                                        return;
                                    }
                                }
                            }
                        }



                        // DESCUENTA  SI LA EXTRACION EN  MAGUEY FUE COMPRADO 
                        if (DtaEnsamble.Rows[x].Cells["TIPO"].Value.ToString() == "3")
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value + ",actualizado=0  WHERE id_planta =" + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + " and no_cliente='" + no_cliente + "' AND id_existenciaplanta_comprada='"+DtaEnsamble.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value+"'") == "Error")
                            {
                                return;
                            }
                        }

                        //si la entrada fue de una produccion sobrante
                        else if (DtaEnsamble.Rows[x].Cells["TIPO"].Value.ToString() == "4")
                        {
                            double sobrante = Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_ENTRANTE"].Value.ToString()), 2) - Math.Round(double.Parse(DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value.ToString()), 2);

                            if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET  agave_kg= " + sobrante + ",actualizado=0 WHERE   id_agave_sobrante='" + DtaEnsamble.Rows[x].Cells["ID_AGAVE_SOBRANTE"].Value.ToString() + "'") == "Error")
                            {
                                return;
                            }

                        }

                        //si es produccion normal
                        else
                        {

                            if (DtaEnsamble.Rows[x].Cells["PRODUCCION_SALIO"].Value.ToString() == "" && DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value.ToString() != "0")
                            {

                                if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value + "  WHERE id_plantas =" + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + "") == "Error")
                                {
                                    return;
                                }

                                if (ConexionMysql.insUpd_transaccion("INSERT INTO retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES('" + (DtaEnsamble.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaEnsamble.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + ",'" + no_cliente + "','" + no_cliente + "'," + DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }

                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( '" + (DtaEnsamble.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaEnsamble.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + "," + DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value + ",'" + fecha + "')") == "Error")
                                {
                                    return;
                                }
                            }
                        }


                        /*
                        ObtenerIdMaximoGuiasDesconocidas();
                        string id_comun_crm = cmbEspecieMaguey.SelectedValue.ToString();
                        string tipo_tapadacrm = ConexionMysql.regresaCampoConsulta("SELECT tipo FROM  produccion_entrada  WHERE id_produccion_entrada='" + id_produccion + "' ");
                        if (tipo_tapadacrm == "1")
                        {
                            // id_comun='" + id_comun_crm + "',
                            if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_comun='" + id_comun_crm + "', gcrm='1',no_guia='0',actualizado=0 WHERE id_produccion_entrada='" + id_produccion + "'") == "Error")
                            {
                                return;
                            }

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  guias_desconocidas (id_guia_desconocida,id_produccion_entrada,no_guia,predio,fecha_ingreso, verificador_id, actualizado) VALUES( '" + id_max_guias_desconocidas + "','" + id_produccion + "','" + TxtNoGuia.Text.ToString() + "','" + txtPredioCrm.Text.ToString() + "', NOW(), '" + Usuario.IdUsuario + "',0)") == "Error")
                            {
                                return;
                            }


                        }// fin del if tipo de tapada crm
                        */
                        // "REGAMMA"
                        if (DtaEnsamble.Rows.Count > 1) 
                        {
                            if (DtaEnsamble.Rows[x].Cells["REGAMMA"].Value.ToString() == "si")
                            {
                                //ObtenerIdMaximoProduccionEnsamble();
                                if (ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  produccion_ensamble(" +
                                    "id_produccion_entrada, id_ensamble_union,  id_agave_sobrante,  id_predio,      id_planta,    " +
                                    "no_guia,               no_pinas_agave,     agave_kg,           agave_coccion_kg,   porcentaje_art, " +
                                    "tipo,                  id_verificador) VALUES ( " +
                                    "'" + id_max_produccion_entrada + "','" + id_max_produccion_ensamble_union + "','" + (DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value.ToString() == "0" ? DtaEnsamble.Rows[x].Cells["ID_AGAVE_SOBRANTE"].Value.ToString() : "") + "','" + DtaEnsamble.Rows[x].Cells["ID_PARAJE"].Value + "'," + DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value + ", " +
                                    "'" + DtaEnsamble.Rows[x].Cells["NO_GUIA"].Value.ToString() + "'," + (DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value.ToString() == "" ? "0" : DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value) + "," + DtaEnsamble.Rows[x].Cells["MAGUEY_ENTRANTE"].Value + "," + DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value + "," + DtaEnsamble.Rows[x].Cells["%_ART"].Value + ", " +
                                    "" + DtaEnsamble.Rows[x].Cells["TIPO"].Value + "," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            } else
                            {
                                // GUÍAS EXTERNAS
                                if (ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  produccion_ensamble(" +
                                    "id_produccion_entrada, id_ensamble_union,  id_agave_sobrante,  id_comun,   gcrm,    " +
                                    "no_guia,               no_pinas_agave,     agave_kg,           agave_coccion_kg,   porcentaje_art, " +
                                    "tipo,                  id_verificador) VALUES ( " +
                                    "'" + id_max_produccion_entrada + "','" + id_max_produccion_ensamble_union + "','" + (DtaEnsamble.Rows[x].Cells["ID_PLANTA"].Value.ToString() == "0" ? DtaEnsamble.Rows[x].Cells["ID_AGAVE_SOBRANTE"].Value.ToString() : "") + "','0','1', " +
                                    "'" + DtaEnsamble.Rows[x].Cells["NO_GUIA"].Value.ToString() + "'," + (DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value.ToString() == "" ? "0" : DtaEnsamble.Rows[x].Cells["NUMERO_PIÑA"].Value) + "," + DtaEnsamble.Rows[x].Cells["MAGUEY_ENTRANTE"].Value + "," + DtaEnsamble.Rows[x].Cells["MAGUEY_COCCION"].Value + "," + DtaEnsamble.Rows[x].Cells["%_ART"].Value + ", " +
                                    "" + DtaEnsamble.Rows[x].Cells["TIPO"].Value + "," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                                //ObtenerIdMaximoGuiasDesconocidas();
                                /*if (ConexionMysql.insUpd_transaccion("INSERT INTO  guias_desconocidas (id_guia_desconocida,id_produccion_entrada,no_guia,predio,fecha_ingreso, verificador_id, actualizado) VALUES( '" + id_max_guias_desconocidas + "','" + id_produccion + "','" + TxtNoGuia.Text.ToString() + "','" + txtPredioCrm.Text.ToString() + "', NOW(), '" + Usuario.IdUsuario + "',0)") == "Error")
                                {
                                    return;
                                }*/
                            }
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Ensamble guardado correctamente");
                    this.Close();
                }//--- Fin else
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //------------------------------------- Fin de Boton Guardar el ensamble granel ------------------------------------

        private void TxtExtraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtAgaveEntranteKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtAgaveEntranteKg.Text);
        }

        private void TxtAgaveCoccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtAgaveCoccion.Text);
        }




        //carga el maguey comprado 
        private void ChekMagueyComprado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekMagueyComprado.Checked == true)
            {

                TxtNoGuia.Enabled = false;
                TxtNoPredio.Enabled = false;
                TxtNoGuia.Text = "";
                TxtNoPredio.Text = "";
                CmbNoPredio.Enabled = false;
                CmbMaguey.DataSource = null;
                if (DtaEnsamble.Rows.Count > 0)
                {
                    PlantasNoMostrar();
                }
                else
                {
                    // --  ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    if (chkGuiaExterna.Checked == true) 
                    {
                        string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')') as Maguey, reveca2_existenciaplanta.id_paraje id_paraje FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta =reveca2_existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   reveca2_existenciaplanta_comprada.no_cliente='" + clienteCrm + "' AND reveca2_existenciaplanta.edad>=5 and reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')') as Maguey, existenciaplanta.id_paraje id_paraje FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    }
                }

            }
            else
            {


                TxtNoGuia.Enabled = true;
                TxtNoPredio.Enabled = true;
                CmbMaguey.DataSource = null;
                CmbNoPredio.Enabled = true;
                if (CmbNoPredio.SelectedValue != null)
                {
                    if (DtaEnsamble.Rows.Count > 0)
                    {
                        PlantasNoMostrar();
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey, existenciaplanta.id_paraje id_paraje FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 and existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                    }
                }
            }
        }

        private void ChekAgaveSobrante_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekAgaveSobrante.Checked == true)
            {

                TxtNoGuia.Enabled = false;
                TxtNoPredio.Enabled = false;
                TxtNoGuia.Text = "";
                TxtNoPredio.Text = "";

                CmbNoPredio.Enabled = false;

                CmbMaguey.Enabled = false;
                TxtExtraccion.Enabled = false;

                TxtAgaveEntranteKg.Enabled = false;
                ChekMagueyComprado.Enabled = false;
                FrmAgaveSobrante frm = new FrmAgaveSobrante();

                frm.no_cliente = no_cliente;

                frm.ShowDialog();
                if (frm.agave_kg == "")
                {
                    TxtNoGuia.Enabled = true;
                    TxtNoPredio.Enabled = true;
                    CmbNoPredio.Enabled = true;
                    CmbMaguey.Enabled = true;
                    TxtExtraccion.Enabled = true;
                    TxtAgaveEntranteKg.Enabled = true;
                    ChekAgaveSobrante.Checked = false;
                    ChekMagueyComprado.Enabled = true;
                    TxtAgaveEntranteKg.Text = "";
                    id_predio_agave_sobrante = "";
                    id_plnata_agave_sobrante = "";
                    id_produccion_entrada_sobrante = "";
                    id_agave_sobrante = "";
                    predio_sobrante = "";
                    planta_sobrante = "";
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
                    predio_sobrante = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  paraje  WHERE id_paraje=" + (id_predio_agave_sobrante == "" ? "0" : id_predio_agave_sobrante) + "");
                    planta_sobrante = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM  comun INNER JOIN existenciaplanta ON existenciaplanta.id_comun=comun.id_comun   WHERE existenciaplanta.id_plantas=" + id_plnata_agave_sobrante + "");
                }
            }
            else
            {

                TxtNoGuia.Enabled = true;
                TxtNoPredio.Enabled = true;
                CmbNoPredio.Enabled = true;
                CmbMaguey.Enabled = true;
                TxtExtraccion.Enabled = true;
                TxtAgaveEntranteKg.Enabled = true;
                ChekMagueyComprado.Enabled = true;
                TxtAgaveEntranteKg.Text = "";
                id_predio_agave_sobrante = "";
                id_plnata_agave_sobrante = "";
                id_produccion_entrada_sobrante = "";
                id_agave_sobrante = "";
                predio_sobrante = "";
                planta_sobrante = "";
                porcen_art_sobrante = "";
                TxtArt.Text = "";
                TxtArt.Enabled = true;

            }
        }

        private void TxtArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtArt.Text);
        }

        private void CmbFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFabrica.SelectedValue != null)
            {
                /// -- TxtMaestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabrica.SelectedValue + "'");

                TxtMaestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm where mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "'");
            }

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
                        LimpiarDespuesDeAgregarPlanta();
                        return;
                    }

                    object valorSeleccionado = CmbTipoMaguey.SelectedItem;
                    if (valorSeleccionado != null)
                    {
                        string valor = valorSeleccionado.ToString();
                        if (valor == "Ingresar Guía AMMA y Antigua")
                        {
                            if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                            {
                                DataSet DatosMaguey = new DataSet();
                                ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=1 and  cextracciones.id_extraccion ='" + TxtNoGuia.Text.Trim() + "'");
                                if (DatosMaguey.Tables[0].Rows.Count == 0)
                                {
                                    /* + los valores de de status son:
                                     * 0 - ya utilizada
                                     * 1 - no utilizada
                                     */
                                    string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=0 and  cextracciones.id_extraccion ='" + TxtNoGuia.Text.Trim() + "'");

                                    if (guia_utilizada == "") { MessageBox.Show("Guia inexistente"); } else { MessageBox.Show("Guia ya utilizada"); };

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
                                //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey, existenciaplanta.id_paraje id_paraje FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                            }
                            else
                            {
                                DataSet DatosMaguey = new DataSet();
                                ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=1 and  reveca2_cextracciones.id_extraccion ='" + TxtNoGuia.Text.Trim() + "'");
                                if (DatosMaguey.Tables[0].Rows.Count == 0)
                                {
                                    /* + los valores de de status son:
                                     * 0 - ya utilizada
                                     * 1 - no utilizada
                                     */
                                    string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=0 and  reveca2_cextracciones.id_extraccion ='" + TxtNoGuia.Text.Trim() + "'");

                                    if (guia_utilizada == "") { MessageBox.Show("Guia inexistente"); } else { MessageBox.Show("Guia ya utilizada"); };

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
                                //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey, reveca2_existenciaplanta.id_paraje id_paraje FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");

                            }
                        }
                    }
                    CmbMaguey.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkGuiaAntigua_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void CmbTipoMaguey_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtPredio.ReadOnly = true;
            object valorSeleccionado = CmbTipoMaguey.SelectedItem;
            if (valorSeleccionado != null)
            {
                //MessageBox.Show("Obtener seleccionado: ");
                // Si el elemento es un string, puedes imprimirlo directamente
                string valor = valorSeleccionado.ToString();
                MessageBox.Show("Elemento seleccionado: " + valor);
                if (valor == "Ingresar Guía AMMA y Antigua")
                {
                    TxtNoGuia.Enabled = true;
                    TxtNoGuia.Focus();
                    TxtNoPredio.Enabled = false;
                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";
                    CmbNoPredio.Enabled = false;
                    CmbMaguey.DataSource = null;
                    CmbNoPredio.Enabled = false;
                    TxtAgaveEntranteKg.Enabled = true;
                    TxtPredio.Text = "";
                    CmbMaguey.Enabled = false;
                    TxtExtraccion.Enabled = false;
                    //ChekMagueyComprado.Enabled = false;
                }
                else if (valor == "Ingresar Guía Externa")
                {
                    TxtPredio.Enabled = true;
                    TxtPredio.ReadOnly = false      ;
                    TxtNoGuia.Enabled = true;
                    MessageBox.Show("Pausa");
                    TxtNoGuia.Focus();
                    TxtNoPredio.Enabled = false;
                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";
                    TxtPredio.Text = "";
                    TxtExtraccion.Enabled = true;
                    CmbNoPredio.Enabled = false;
                    CmbMaguey.DataSource = null;
                    CmbMaguey.Enabled = true;
                    CmbNoPredio.Enabled = false;
                    TxtAgaveEntranteKg.Enabled = true;
                    //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT comun.id_comun,CONCAT(comun.nombre, ' (',especie.genespecie,')' ) as Maguey FROM comun INNER JOIN especie on comun.id_especie=especie.id_especie where status = '1' ", "id_comun", "Maguey");
                    ConexionMysql.llenaCombo(ref CmbMaguey, " SELECT id_comun,CONCAT (comun.nombre,' (',especie.genespecie,')') as nombre FROM comun INNER JOIN especie ON especie.id_especie=comun.id_especie WHERE comun.status=1 ORDER BY comun.nombre ASC", "id_comun", "nombre");
                }
                else if (valor == "Maguey Comprado")
                {

                    TxtNoGuia.Enabled = false;
                    TxtNoPredio.Enabled = false;
                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";
                    CmbNoPredio.Enabled = false;
                    CmbMaguey.DataSource = null;
                    TxtAgaveEntranteKg.Enabled = true;
                    if (DtaEnsamble.Rows.Count > 0)
                    {
                        PlantasNoMostrar();
                    }
                    else
                    {
                        // --  ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                        if (chkGuiaExterna.Checked == true)
                        {
                            string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')') as Maguey, reveca2_existenciaplanta.id_paraje id_paraje FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta =reveca2_existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   reveca2_existenciaplanta_comprada.no_cliente='" + clienteCrm + "' AND reveca2_existenciaplanta.edad>=5 and reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                        }
                        else
                        {
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')') as Maguey, existenciaplanta.id_paraje id_paraje FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                        }
                    }
                    CmbMaguey.Enabled = true;
                } 
                else if(valor == "Maguey Sobrante")
                {
                    TxtNoGuia.Enabled = false;
                    TxtNoPredio.Enabled = false;
                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";

                    CmbNoPredio.Enabled = false;

                    CmbMaguey.Enabled = false;
                    TxtExtraccion.Enabled = false;

                    TxtAgaveEntranteKg.Enabled = false;
                    ChekMagueyComprado.Enabled = false;
                    FrmAgaveSobrante frm = new FrmAgaveSobrante();

                    frm.no_cliente = no_cliente;

                    frm.ShowDialog();
                    if (frm.agave_kg == "")
                    {
                        MessageBox.Show("Maguey Sobrante, condición 1: ");
                        TxtNoGuia.Enabled = false;
                        TxtNoPredio.Enabled = false;
                        CmbNoPredio.Enabled = false;
                        CmbMaguey.Enabled = true;
                        TxtExtraccion.Enabled = false;
                        TxtAgaveEntranteKg.Enabled = false;
                        ChekAgaveSobrante.Checked = false;
                        ChekMagueyComprado.Enabled = true;
                        TxtAgaveEntranteKg.Text = "";
                        id_predio_agave_sobrante = "";
                        id_plnata_agave_sobrante = "";
                        id_produccion_entrada_sobrante = "";
                        id_agave_sobrante = "";
                        predio_sobrante = "";
                        planta_sobrante = "";
                        porcen_art_sobrante = "";

                        CmbMaguey.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Maguey Sobrante, condición 2: ");
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
                        predio_sobrante = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  paraje  WHERE id_paraje='" + (id_predio_agave_sobrante == "" ? "0" : id_predio_agave_sobrante) + "'");
                        planta_sobrante = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM  comun INNER JOIN existenciaplanta ON existenciaplanta.id_comun=comun.id_comun   WHERE existenciaplanta.id_plantas=" + id_plnata_agave_sobrante + "");
                    }
                    
                    /*else
                    {

                        TxtNoGuia.Enabled = true;
                        TxtNoPredio.Enabled = true;
                        CmbNoPredio.Enabled = true;
                        CmbMaguey.Enabled = true;
                        TxtExtraccion.Enabled = true;
                        TxtAgaveEntranteKg.Enabled = true;
                        ChekMagueyComprado.Enabled = true;
                        TxtAgaveEntranteKg.Text = "";
                        id_predio_agave_sobrante = "";
                        id_plnata_agave_sobrante = "";
                        id_produccion_entrada_sobrante = "";
                        id_agave_sobrante = "";
                        predio_sobrante = "";
                        planta_sobrante = "";
                        porcen_art_sobrante = "";
                        TxtArt.Text = "";
                        TxtArt.Enabled = true;

                    }*/
                }
                else
                {


                    TxtNoGuia.Enabled = true;
                    TxtNoPredio.Enabled = true;
                    CmbMaguey.DataSource = null;
                    CmbNoPredio.Enabled = true;
                    if (CmbNoPredio.SelectedValue != null)
                    {
                        if (DtaEnsamble.Rows.Count > 0)
                        {
                            PlantasNoMostrar();
                        }
                        else
                        {
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey, existenciaplanta.id_paraje id_paraje FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 and existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                        }
                    }
                }
            }
            //MessageBox.Show(CmbTipoMaguey.SelectedValue.ToString());
            /*try
            {
                TxtExistencia.Text = "";
                TxtExtraccion.Text = "";
                if (CmbMaguey.DataSource != null)
                {
                    if (ChekMagueyComprado.Checked == true)
                    {
                        if (chkGuiaExterna.Checked == true)
                        {
                            string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + clienteCrm + "'");
                            //no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + no_cliente + "'");
                            no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + clienteCrm + "'");

                            //-- id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  reveca2_existenciaplanta inner join reveca2_existenciaplanta_comprada on reveca2_existenciaplanta_comprada.id_planta=reveca2_existenciaplanta.id_plantas WHERE reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                            predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  reveca2_paraje  WHERE id_paraje='" + id_predio_comprado + "'");
                        }
                        else
                        {
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + no_cliente + "'");
                            no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + no_cliente + "'");
                            id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta inner join existenciaplanta_comprada on existenciaplanta_comprada.id_planta=existenciaplanta.id_plantas WHERE existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                            predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  paraje  WHERE id_paraje='" + id_predio_comprado + "'");
                        }
                    }
                    else
                    {
                        if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                        {
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            id_predio_comprado = "";
                            predio_comprado = "";
                        }
                        else
                        {
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            id_predio_comprado = "";
                            predio_comprado = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}



