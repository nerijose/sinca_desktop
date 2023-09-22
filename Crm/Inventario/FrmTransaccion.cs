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

namespace Crm.Inventario
{
    public partial class FrmTransaccion : Form
    {
        public FrmTransaccion()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();
        public string no_cliente = "";
        public string id_instalacion = "";
        public string tipo_instalacion = "";
        Boolean bandera;
        string id_max_granel_entrada = "";
        string id_max_granel_entrada_envasado = "";
        string id_max_granel_ensamble = "";
        string id_max_granel_ensamble_envasado = "";
        string id_max_envasado_entrada = "";
        string id_max_granel_tanque = "";
        string id_max_granel_tanque_envasado = "";
        string id_max_transaccion = "";
        string id_max_envasado_ensamble = "";
        string id_max_envasado_holograma = "";
        DataSet dtsTanques;

        ///==== almacen =====
        string id_max_almacen_granel_entrada = "";
        string id_max_almacen_granel_ensamble = "";
        string id_max_almacen_granel_tanque = "";


        ///==== almacen =====
        string id_max_almacen_envasado_entrada = "";
        string id_max_almacen_envasado_ensamble = "";
        string id_max_almacen_envasado_holograma = "";


        //obtencion de los id para todas las entradas a granel fabrica
        public void ObtenerIdMaximoGranelEntradaFabrica()
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

        //obtencion de los id para todas las entradas a almacen granel fabrica
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

        //obtencion de los id para todas las entradas a granel envasadora
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

        public void ObtenerIdMaximoEnvasadoHolograma()
        {
            id_max_envasado_holograma = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_holograma,4)) ) FROM envasado_holograma where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasado_holograma == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_holograma = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasado_holograma = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasado_holograma) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_holograma = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasado_holograma = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel envasadora
        public void ObtenerIdMaximoEnvasado()
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

        //obtencion de los id para todos los ensambles  granel  fabrica
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


        //obtencion de los id para todos los ensambles  almacen granel 
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


        //obtencion de los id para todos los ensambles  granel  envasadora
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



        //obtencion de los id para todos los ensambles  granel  envasadora
        public void ObtenerIdMaximoEnsambleEnvasado()
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



        //obtencion de los id para todos los tanques granel fabrica
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


        //obtencion de los id para todos los tanques almacen granel 
        public void ObtenerIdMaximoAlmacenGraneTanque()
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

        //obtencion de los id para todos los tanques granel envasadora
        public void ObtenerIdMaximoGraneTanqueEnvasado()
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
        //obtencion de los id para todas las transacciones
        public void ObtenerIdMaximoTransacciones()
        {
            id_max_transaccion = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_transaccion,4)) )   FROM transacciones where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_transaccion == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_transaccion = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_transaccion = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_transaccion) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_transaccion = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_transaccion = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        ///==================== - para almacen de envasado - ====

        //obtencion de los id para todas las entradas a granel envasadora
        public void ObtenerIdMaximoAlmacenEnsambleEnvasado()
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



        public void ObtenerIdMaximoAlmacenEnvasadoHolograma()
        {
            id_max_almacen_envasado_holograma = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_envasado_holograma,4)) ) FROM almacen_envasado_holograma where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_envasado_holograma == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_holograma = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_envasado_holograma = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_envasado_holograma) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_holograma = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_envasado_holograma = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel envasadora
        public void ObtenerIdMaximoAlmacenEnvasado()
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

        //crea la tabla tanques
        private void addTablaTanques()
        {
            dtsTanques = new DataSet();
            dtsTanques.Tables.Add("TANQUES");
            dtsTanques.Tables["TANQUES"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanques.Tables["TANQUES"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaTanques.DataSource = dtsTanques.Tables["TANQUES"];
        }

        //carga el inicio del formulario
        private void FrmTraslado_Load(object sender, EventArgs e)
        {
            try
            {
                TxtNoClienteEnvia.Focus();
                if (tipo_instalacion != "envasado" && tipo_instalacion != "almacen_envasado")
                {
                    addTablaTanques();
                    CmbTipoInstalacion.Items.Insert(0, "---Elije una opcion---");
                    CmbTipoInstalacion.Items.Insert(1, "Fabrica");
                    CmbTipoInstalacion.Items.Insert(2, "Envasadora");
                    CmbTipoInstalacion.Items.Insert(3, "Almacen de Granel");
                    // CmbTipoInstalacion.Items.Insert(3, "Almacen de Envasado");
                    CmbTipoInstalacion.SelectedIndex = 0;


                    lblBotellas.Visible = false;
                    txtNBotellas.Visible = false;


                    TxtNoLitrosExtraccion.ReadOnly = false;
                    TxtNoLitrosExtraccion.BackColor = Color.FromArgb(255, 255, 255);





                }
                else
                {
                    TxtTanque.Enabled = false;
                    BtnAgregarTanque.Enabled = false;
                    DtaTanques.Enabled = false;
                    //CmbTipoInstalacion.Enabled = false;
                    TxtNoTransaccion.Enabled = false;
                    lblBotellas.Visible = true;
                    txtNBotellas.Visible = true;

                    TxtNoLitrosExtraccion.ReadOnly = true;
                    TxtNoLitrosExtraccion.BackColor = Color.FromArgb(240, 240, 240);

                    addTablaTanques();
                    CmbTipoInstalacion.Items.Insert(0, "---Elije una opcion---");
                    CmbTipoInstalacion.Items.Insert(1, "Envasadora");
                    CmbTipoInstalacion.Items.Insert(2, "Almacen de Envasado");
                    CmbTipoInstalacion.SelectedIndex = 0;
                }


                //llenamos los clientes para el envio de transacion(quien envia las transacciones) 
                AutoCompleteStringCollection ListaClientes = new AutoCompleteStringCollection();
                DataSet DatosClientes = new DataSet();
                ConexionMysql.llenaDataset(ref DatosClientes, "select no_cliente from clientes ");
                foreach (DataRow row in DatosClientes.Tables[0].Rows)
                {
                    ListaClientes.Add(row[0].ToString());
                }
                TxtNoClienteEnvia.AutoCompleteCustomSource = ListaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //al presionar en numero de cliente carga y valida la seleccion
        private void TxtNoClienteEnvia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LbLNombreCliente.Text = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM  clientes  WHERE no_cliente='" + TxtNoClienteEnvia.Text + "'");
                    if (LbLNombreCliente.Text == "")
                    {
                        MessageBox.Show("Numero de cliente no encontrado");
                        LbLNombreCliente.Text = ".....";
                        bandera = false;
                        CmbInstalacion.DataSource = null;
                        CmbTipoInstalacion.DataSource = null;
                        CmbLote.DataSource = null;
                    }
                    else
                    {
                        bandera = true;

                        /* if (tipo_instalacion == "envasado")
                         {
                             CmbInstalacion.DataSource = null;
                             ConexionMysql.llenaCombo(ref CmbInstalacion, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + TxtNoClienteEnvia.Text + "'", "id_envasadora", "envasadora");
                         }*/

                    }
                }
                else
                {
                    LbLNombreCliente.Text = "......";
                    bandera = false;
                    CmbInstalacion.DataSource = null;
                    CmbTipoInstalacion.DataSource = null;
                    CmbLote.DataSource = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //al seleccionar si es fabrica o envasado de donde saldra el producto
        private void CmbTipoInstalacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbTipoInstalacion.Text == "---Elije una opcion---")
            {

                CmbInstalacion.DataSource = null;
                CmbLote.DataSource = null;


            }
            else if (CmbTipoInstalacion.Text == "Fabrica")
            {
                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente");
                    return;
                }
                CmbInstalacion.DataSource = null;
                ConexionMysql.llenaCombo(ref CmbInstalacion, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + TxtNoClienteEnvia.Text + "'", "id_fabrica", "fabrica");
            }
            else if (CmbTipoInstalacion.Text == "Almacen de Granel")
            {
                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente");
                    return;
                }

                CmbInstalacion.DataSource = null;
                ConexionMysql.llenaCombo(ref CmbInstalacion, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + TxtNoClienteEnvia.Text + "' AND tipo_almacen=1", "id_almacen", "almacen");
            }
            else if (CmbTipoInstalacion.Text == "Almacen de Envasado")
            {
                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente  ");
                    return;
                }
                CmbInstalacion.DataSource = null;
                ConexionMysql.llenaCombo(ref CmbInstalacion, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + TxtNoClienteEnvia.Text + "' AND tipo_almacen=2", "id_almacen", "almacen");


            }
            else
            {
                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente  ");
                    return;
                }
                CmbInstalacion.DataSource = null;
                ConexionMysql.llenaCombo(ref CmbInstalacion, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + TxtNoClienteEnvia.Text + "'", "id_envasadora", "envasadora");


            }
        }

        //al seleccionar la fabrica o envasado carga los lotes correspondientes 
        private void CmbInstalacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tipo_instalacion == "granelfabrica" || tipo_instalacion == "granelenvasado")
            {
                if (CmbTipoInstalacion.Text == "Fabrica")
                {
                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + CmbInstalacion.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");
                    }
                }
                else if (CmbTipoInstalacion.Text == "Almacen de Granel")
                {
                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen='" + CmbInstalacion.SelectedValue + "'  AND lts_existentes > 0  order by id_almacen_granel_entrada asc", "id_almacen_granel_entrada", "produccion");
                    }
                }
                else
                {
                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='" + CmbInstalacion.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");
                    }
                }
            }
            else if (tipo_instalacion == "almacenG")
            { //// ---- para unidad de almacen de graneles
                if (CmbTipoInstalacion.Text == "Almacen de Granel")
                {
                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen='" + CmbInstalacion.SelectedValue + "'  AND lts_existentes > 0  order by id_almacen_granel_entrada asc", "id_almacen_granel_entrada", "produccion");
                    }
                }
                else if (CmbTipoInstalacion.Text == "Fabrica")
                {
                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + CmbInstalacion.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada asc", "id_granel_entrada", "produccion");
                    }
                }
                else if (tipo_instalacion == "envasado" || tipo_instalacion == "almacen_envasado")
                {
                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='" + CmbInstalacion.SelectedValue + "'  AND lts_existentes > 0  order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");
                    }
                }
                // }

            }
            else if (tipo_instalacion == "almacen_envasado")
            {
                //// --- para unidad de almacen de envasado ----- 

                if (CmbTipoInstalacion.Text == "Envasadora")
                {


                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' ',grado_alcoholico) ) As produccion,id_envasado_entrada   FROM envasado_entrada  where id_envasadora='" + CmbInstalacion.SelectedValue + "'  AND botellas_existentes > 0  order by id_envasado_entrada asc", "id_envasado_entrada", "produccion");
                    }
                }
                else if (CmbTipoInstalacion.Text == "Almacen de Envasado")
                {


                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' ',grado_alcoholico) ) As produccion,id_almacen_envasado_entrada   FROM almacen_envasado_entrada  where id_almacen='" + CmbInstalacion.SelectedValue + "'  AND botellas_existentes > 0  order by id_almacen_envasado_entrada asc", "id_almacen_envasado_entrada", "produccion");
                    }
                }
            }
            else
            {
                ///-- entra solo si es envasadora----
                if (CmbTipoInstalacion.Text == "Envasadora")
                {


                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' ',grado_alcoholico) ) As produccion,id_envasado_entrada   FROM envasado_entrada  where id_envasadora='" + CmbInstalacion.SelectedValue + "'  AND botellas_existentes > 0  order by id_envasado_entrada asc", "id_envasado_entrada", "produccion");
                    }
                }
                else if (CmbTipoInstalacion.Text == "Almacen de Envasado")
                {


                    if (CmbInstalacion.SelectedValue != null)
                    {
                        CmbLote.DataSource = null;
                        ConexionMysql.llenaCombo(ref CmbLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Botellas : ',botellas_existentes,'   ','Presentación : ',CONCAT(contenido_por_botella, ' ', unidad_medida,' ',grado_alcoholico) ) As produccion,id_almacen_envasado_entrada   FROM almacen_envasado_entrada  where id_almacen='" + CmbInstalacion.SelectedValue + "'  AND botellas_existentes > 0  order by id_almacen_envasado_entrada asc", "id_almacen_envasado_entrada", "produccion");
                    }

                }
            }
        }

        //boton para guardar la transaccion
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (CmbTipoInstalacion.Text == "---Elije una opcion---")
            {
                MessageBox.Show("No has seleccionado un tipo de instalación");
                return;
            }


            //guarda cuando es una transaccion a granel fabrica 
            if (tipo_instalacion == "granelfabrica")
            {
                if (bandera == false)
                {
                    MessageBox.Show("No has seleccionado un cliente");
                    TxtNoClienteEnvia.Focus();
                    return;
                }
                if (CmbLote.Items.Count == 0)
                {
                    MessageBox.Show("No tienes un lote para la transacción");
                    return;
                }
                if (TxtNoLitrosExtraccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de litros para la extraccion");
                    TxtNoLitrosExtraccion.Focus();
                    return;
                }
                if (TxtNoTransaccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de transacción");
                    TxtNoTransaccion.Focus();
                    return;
                }
                if (TxtNoLote.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de lote");
                    TxtNoLote.Focus();
                    return;
                }

                if (DtaTanques.RowCount == 0)
                {
                    MessageBox.Show("No haz ingresado un tanque");
                    TxtTanque.Focus();
                    return;
                }

                /*
                 * tipo de operaciónn es la variable que almacenará: sitio o documental
                 * si el radio de Documental no esta seleccionado y el radio de sitio tampoco, entonces
                 * mostrará un MessageBox "Favor de seleccionar tipo de cobro."
                 * 
                 * Si el radio Documental esta seleccionado (else) entonces tipo_operacion tomara el valor de "documental"
                 * si el radio Documental no esta seleccionado y radio Sitio esta seleccionado, entonces
                 * tipo_operacion tomara el valor de "sitio"
                 */
                String tipo_transaccion;

                if (!rdbDocumental.Checked)
                {
                    if (!rdbSitio.Checked)
                    {
                        MessageBox.Show("Favor de seleccionar tipo de transacción");
                        return;
                    }
                    else
                    {
                        tipo_transaccion = "sitio";
                    }
                }
                else
                {
                    tipo_transaccion = "documental";
                }

                //guarda en granel de fabrica
                if (CmbTipoInstalacion.Text == "Fabrica")
                {
                    ObtenerIdMaximoGranelEntradaFabrica();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada where id_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_granel_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada, id_granel_entrada_recibe,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_granel_entrada + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    /*del lote seleccionado en el combo busca en la tabla granel_ensamble, posteriormente si encuentra registros recorre e inserta en granel_ensamble esto para que el nuevo registro ingresado de la transaccion si tuviera ensamble tenga trazabilidad de ensamble.*/
                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble where id_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble + "', '" + id_max_granel_entrada + "','" + row["id_granel_entrada_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    /*Inserta en 1 o N tanques*/
                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGraneTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques(id_tanque,id_granel_entrada,tanque,id_verificador,actualizado) VALUES('" + id_max_granel_tanque + "', '" + id_max_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='granel_fabrica'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_fabrica','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }




                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();

                }// si no eligio fabrica, entonces eligió envasadora, (granel_fabrica)
                 // guarda en granel envasadora LA TRANSACCION
                 //LO COMENTO PORQUE APLICA EL MISMO CASO QUE EN GRANEL DE ENVASADO
                #region OLD ORIGINAL
                /*else
                {
                    ObtenerIdMaximoGranelEntradaFabrica();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada_envasado, id_granel_entrada_recibe,  no_traslado, id_verificador, actualizado, tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_granel_entrada + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_envasado_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble + "', '" + id_max_granel_entrada + "','" + row["id_granel_entrada_envasado_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
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



                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='granel_envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_fabrica','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }




                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }*/
                #endregion

                else if (CmbTipoInstalacion.Text == "Envasadora")
                {
                    ObtenerIdMaximoGranelEntradaFabrica();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada_envasado, id_granel_entrada_recibe,  no_traslado, id_verificador, actualizado, tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_granel_entrada + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_envasado_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble + "', '" + id_max_granel_entrada + "','" + row["id_granel_entrada_envasado_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
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

                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='granel_envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_fabrica','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }

                else if (CmbTipoInstalacion.Text == "Almacen de Granel")
                {
                    ObtenerIdMaximoGranelEntradaFabrica();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM almacen_granel_entrada where id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  almacen_granel_entrada SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada_recibe, id_almacen_granel_entrada, no_traslado, id_verificador, actualizado, tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + id_max_granel_entrada + "','" + CmbLote.SelectedValue + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM almacen_granel_ensamble where id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble, id_granel_entrada, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble + "', '" + id_max_granel_entrada + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
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

                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='almacen_granel'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_fabrica','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }
            }


            // **** tipo **** transaccion desde granel _envasado 
            //guarda cuando es una transaccion a granel envasado 
            else if (tipo_instalacion == "granelenvasado")
            {
                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente");
                    TxtNoClienteEnvia.Focus();
                    return;
                }
                if (CmbLote.Items.Count == 0)
                {
                    MessageBox.Show("No tienes un lote para la transacción");
                    return;
                }
                if (TxtNoLitrosExtraccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de litros para la extraccion");
                    TxtNoLitrosExtraccion.Focus();
                    return;
                }
                if (TxtNoTransaccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de transacción");
                    TxtNoTransaccion.Focus();
                    return;
                }
                if (TxtNoLote.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de lote");
                    TxtNoLote.Focus();
                    return;
                }
                if (DtaTanques.RowCount == 0)
                {
                    MessageBox.Show("No haz ingresado un tanque");
                    TxtTanque.Focus();
                    return;
                }


                String tipo_transaccion;

                if (!rdbDocumental.Checked)
                {
                    if (!rdbSitio.Checked)
                    {
                        MessageBox.Show("Favor de seleccionar tipo de cobro");
                        return;
                    }
                    else
                    {
                        tipo_transaccion = "sitio";
                    }
                }
                else
                {
                    tipo_transaccion = "documental";
                }

                //origen de granel de fabrica
                if (CmbTipoInstalacion.Text == "Fabrica")
                {
                    ObtenerIdMaximoGranelEntradaEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada where id_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_granel_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada, id_granel_entrada_envasado_recibe,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_granel_entrada_envasado + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble where id_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble, id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble_envasado + "', '" + id_max_granel_entrada_envasado + "','" + row["id_granel_entrada_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGraneTanqueEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador,actualizado) VALUES('" + id_max_granel_tanque_envasado + "', '" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='granel_fabrica'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada_envasado + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }



                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }
                // guarda en granel envasadora LA TRANSACCION
                //SE CAMBIA ESTE METODO PARA PODER HACER QUE SE RECIBAN TRASLADOS DE ALMACENES, ESTE COMENTADO SERÁ EL ORIGINAL
                #region OLD
                /*else
                {
                    ObtenerIdMaximoGranelEntradaEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_granel_entrada_envasado + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_envasado_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble_envasado + "', '" + id_max_granel_entrada_envasado + "','" + row["id_granel_entrada_envasado_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGraneTanqueEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador,actualizado) VALUES('" + id_max_granel_tanque_envasado + "', '" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }*/
                #endregion

                // origen de granel de envasado
                else if (CmbTipoInstalacion.Text == "Envasadora")
                {
                    ObtenerIdMaximoGranelEntradaEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_granel_entrada_envasado + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_envasado_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble_envasado + "', '" + id_max_granel_entrada_envasado + "','" + row["id_granel_entrada_envasado_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGraneTanqueEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador,actualizado) VALUES('" + id_max_granel_tanque_envasado + "', '" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }
                //origen de almacen de granel fabrica
                else if (CmbTipoInstalacion.Text == "Almacen de Granel")
                {
                    ObtenerIdMaximoGranelEntradaEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM almacen_granel_entrada where id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_granel_entrada_envasado + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  almacen_granel_entrada SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada_envasado_recibe, id_almacen_granel_entrada,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + id_max_granel_entrada_envasado + "','" + CmbLote.SelectedValue + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }
                    // guarda los datos por si el lote es ensamblado
                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM almacen_granel_ensamble where id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoGranelEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_granel_ensamble_envasado + "', '" + id_max_granel_entrada_envasado + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGraneTanqueEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador,actualizado) VALUES('" + id_max_granel_tanque_envasado + "', '" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }//fin el if alamcen como origen

            } /// fin del if de envasadora
            else if (tipo_instalacion == "almacenG")
            {
                ////-----  si el tipo de instalacion es igual a 'almacenG' entra en este if para generar
                ////---- la transaccion de un almacen de graneles 

                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente aaaaaaaaa");
                    TxtNoClienteEnvia.Focus();
                    return;
                }
                if (CmbLote.Items.Count == 0)
                {
                    MessageBox.Show("No tienes un lote para la transacción");
                    return;
                }
                if (TxtNoLitrosExtraccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de litros para la extraccion");
                    TxtNoLitrosExtraccion.Focus();
                    return;
                }
                if (TxtNoTransaccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de transacción");
                    TxtNoTransaccion.Focus();
                    return;
                }
                if (TxtNoLote.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de lote");
                    TxtNoLote.Focus();
                    return;
                }

                if (TxtNoLitrosExtraccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de litros para la extraccion");
                    TxtNoLitrosExtraccion.Focus();
                    return;
                }
                if (DtaTanques.RowCount == 0)
                {
                    MessageBox.Show("No haz ingresado un tanque");
                    TxtTanque.Focus();
                    return;
                }


                String tipo_transaccion;

                if (!rdbDocumental.Checked)
                {
                    if (!rdbSitio.Checked)
                    {
                        MessageBox.Show("Favor de seleccionar tipo de cobro");
                        return;
                    }
                    else
                    {
                        tipo_transaccion = "sitio";
                    }
                }
                else
                {
                    tipo_transaccion = "documental";
                }


                //guarda en granel de fabrica
                if (CmbTipoInstalacion.Text == "Fabrica")
                {

                    ///----  se selecciona el lote de granel de fabrica  y se ingresa en el almacen de graneles 
                    ObtenerIdMaximoAlmacenGranelEntrada();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada where id_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_almacen_granel_entrada + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2),actualizado=0 WHERE id_granel_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada, id_almacen_granel_entrada_recibe,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_almacen_granel_entrada + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble where id_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoAlmacenGranelEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_almacen_granel_ensamble + "', '" + id_max_almacen_granel_entrada + "','" + row["id_granel_entrada_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoAlmacenGraneTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,id_verificador,actualizado) VALUES('" + id_max_almacen_granel_tanque + "', '" + id_max_almacen_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }



                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='granel_fabrica'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_fabrica','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }



                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }///--- Fin de fabrica para almacen

                else if (CmbTipoInstalacion.Text == "Almacen de Granel")
                {

                    ///=--- para almacen  de almacen 
                    ObtenerIdMaximoAlmacenGranelEntrada();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM almacen_granel_entrada where id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_almacen_granel_entrada + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  almacen_granel_entrada SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2), actualizado=0 WHERE id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_almacen_granel_entrada, id_almacen_granel_entrada_recibe,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_almacen_granel_entrada + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_almacen_granel_entrada_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM almacen_granel_ensamble where id_almacen_granel_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoAlmacenGranelEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_almacen_granel_ensamble + "', '" + id_max_almacen_granel_entrada + "','" + row["id_almacen_granel_entrada_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoAlmacenGraneTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,id_verificador,actualizado) VALUES('" + id_max_almacen_granel_tanque + "', '" + id_max_almacen_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='almacen_granel'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_granel','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }



                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }///--------- fin de almacen de granel 
                // guarda en granel envasadora LA TRANSACCION
                else
                {
                    ////=====--- entra aqui cunado el se elige la envasadora y obtiene los lotes de granel para ingresarlo al almacen---
                    ObtenerIdMaximoAlmacenGranelEntrada();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT  id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente,lts_existentes,grado_alcoholico_existente,id_verificador,actualizado FROM granel_entrada_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES( '" + id_max_almacen_granel_entrada + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["id_comun"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico_existente"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE  granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes - " + TxtNoLitrosExtraccion.Text + ",2), actualizado=0 WHERE id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_granel_entrada_envasado, id_almacen_granel_entrada_recibe,  no_traslado, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_almacen_granel_entrada + "','" + TxtNoTransaccion.Text + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT  id_granel_entrada_envasado_salio,id_comun,id_predio,id_planta,agave_coccion_kg,litros,grado_alcoholico FROM granel_ensamble_envasado where id_granel_entrada_envasado='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoAlmacenGranelEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble (id_almacen_granel_ensamble,id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_almacen_granel_ensamble + "', '" + id_max_almacen_granel_entrada + "','" + row["id_granel_entrada_envasado_salio"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["grado_alcoholico"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoAlmacenGraneTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,id_verificador,actualizado) VALUES('" + id_max_almacen_granel_tanque + "', '" + id_max_almacen_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='granel_envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_granel','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                   









                    ConexionMysql.transCompleta();
                    MessageBox.Show("Transacción exitosa");
                    this.Close();
                }
            }
            // **** tipo **** transaccion desde envasado
            //guarda transaccion envasado
            else if (tipo_instalacion == "envasado")
            {
                /////---- se aplica al almacen de envasado

                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente");
                    TxtNoClienteEnvia.Focus();
                    return;
                }
                if (CmbLote.Items.Count == 0)
                {
                    MessageBox.Show("No tienes un lote para la transacción");
                    return;
                }
                if (txtNBotellas.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de botella para la extraccion");
                    txtNBotellas.Focus();
                    return;
                }


                if (TxtNoLitrosExtraccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de litros para la extraccion");
                    TxtNoLitrosExtraccion.Focus();
                    return;
                }

                if (TxtNoLote.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de lote");
                    TxtNoLote.Focus();
                    return;
                }

                String tipo_transaccion = "noaplica";

                if (!rdbDocumental.Checked)
                {
                    if (!rdbSitio.Checked)
                    {
                        MessageBox.Show("Favor de seleccionar tipo de cobro");
                        return;
                    }
                    else
                    {
                        tipo_transaccion = "sitio";
                    }
                }
                else
                {
                    tipo_transaccion = "documental";
                }




                if (CmbTipoInstalacion.Text == "Envasadora")
                {

                    ObtenerIdMaximoEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT   id_marca,DATE_FORMAT(fecha_envasado_ini, '%Y/%m/%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin, '%Y/%m/%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud,  id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,  botellas_existentes, holograma_inicio, holograma_fin FROM envasado_entrada where id_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada(id_envasado_entrada, id_marca, no_cliente, id_envasadora, fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales, botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador, actualizado) VALUES ( '" + id_max_envasado_entrada + "','" + row["id_marca"].ToString() + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["fecha_envasado_ini"].ToString() + "','" + row["fecha_envasado_fin"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" +row["etiquetado_como"].ToString() +"','" + row["unidad_medida"].ToString() + "','" + row["contenido_por_botella"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico"].ToString() + "','" + row["grado_alcoholico_etiqueta"].ToString() + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        //// el if el el campo de botellas iniciales es para checar el detalle con las botellas iniciales hay registros que son null y en 0. en el primero no registra nada y en el segundo genera un valor con signo (-) 
                        if (ConexionMysql.insUpd_transaccion("UPDATE  envasado_entrada SET litros=if(litros is null OR litros = 0,'0', ROUND(litros - " + TxtNoLitrosExtraccion.Text + ",2)),botellas_iniciales=if(botellas_iniciales is null OR botellas_iniciales=0,'0',ROUND(botellas_iniciales- " + txtNBotellas.Text + ",2)), botellas=ROUND(botellas - " + txtNBotellas.Text + ",2), botellas_existentes=ROUND(botellas_existentes - " + txtNBotellas.Text + ",2),actualizado=0 WHERE id_envasado_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_envasado_entrada, id_envasado_entrada_recibe, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_envasado_entrada + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT    id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado FROM envasado_ensamble where id_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_envasado_ensamble + "', '" + id_max_envasado_entrada + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet Datos3 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos3, "SELECT   no_cliente , cve_marca, holograma_inicio, holograma_fin,serie FROM envasado_holograma where id_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos3.Tables[0].Rows)
                    {
                        ObtenerIdMaximoEnvasadoHolograma();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES('" + id_max_envasado_holograma + "', '" + id_max_envasado_entrada + "','" + row["no_cliente"].ToString() + "','" + row["cve_marca"].ToString() + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + row["serie"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Traslado exitoso");
                    this.Close();
                }///---- fin if de envasadora
                else if (CmbTipoInstalacion.Text == "Almacen de Envasado")
                {

                    ObtenerIdMaximoEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT   id_marca,DATE_FORMAT(fecha_envasado_ini, '%Y/%m/%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin, '%Y/%m/%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud,  id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como, unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,  botellas_existentes, holograma_inicio, holograma_fin FROM almacen_envasado_entrada where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'");

                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_entrada(id_envasado_entrada, id_marca, no_cliente, id_envasadora, fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como, unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales, botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador, actualizado) VALUES ( '" + id_max_envasado_entrada + "','" + row["id_marca"].ToString() + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["fecha_envasado_ini"].ToString() + "','" + row["fecha_envasado_fin"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" +row["etiquetado_como"].ToString()+ "','" + row["unidad_medida"].ToString() + "','" + row["contenido_por_botella"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico"].ToString() + "','" + row["grado_alcoholico_etiqueta"].ToString() + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        //// el if el el campo de botellas iniciales es para checar el detalle con las botellas iniciales hay registros que son null y en 0. en el primero no registra nada y en el segundo genera un valor con signo (-) 
                        if (ConexionMysql.insUpd_transaccion("UPDATE  almacen_envasado_entrada SET litros=if(litros is null OR litros = 0,'0', ROUND(litros - " + TxtNoLitrosExtraccion.Text + ",2)),botellas_iniciales=if(botellas_iniciales is null OR botellas_iniciales=0,'0',ROUND(botellas_iniciales- " + txtNBotellas.Text + ",2)), botellas=ROUND(botellas - " + txtNBotellas.Text + ",2), botellas_existentes=ROUND(botellas_existentes - " + txtNBotellas.Text + ",2),actualizado=0 WHERE id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_almacen_envasado_entrada, id_envasado_entrada_recibe, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_envasado_entrada + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT    id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado FROM almacen_envasado_ensamble where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_ensamble(id_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_envasado_ensamble + "', '" + id_max_envasado_entrada + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet Datos3 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos3, "SELECT    no_cliente, cve_marca, holograma_inicio, holograma_fin,serie FROM almacen_envasado_holograma where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos3.Tables[0].Rows)
                    {
                        ObtenerIdMaximoEnvasadoHolograma();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma, id_envasado_entrada, no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES('" + id_max_envasado_holograma + "', '" + id_max_envasado_entrada + "','" + row["no_cliente"].ToString() + "','" + row["cve_marca"].ToString() + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + row["serie"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='almacen_envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_envasado_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }








                    ConexionMysql.transCompleta();
                    MessageBox.Show("Traslado exitoso");
                    this.Close();

                }



            }
            else if (tipo_instalacion == "almacen_envasado")
            {
                /////---- se aplica solo envasado a envasado

                if (bandera == false)
                {
                    MessageBox.Show("No haz seleccionado un cliente");
                    TxtNoClienteEnvia.Focus();
                    return;
                }
                if (CmbLote.Items.Count == 0)
                {
                    MessageBox.Show("No tienes un lote para la transacción");
                    return;
                }
                if (txtNBotellas.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de botella para la extraccion");
                    txtNBotellas.Focus();
                    return;
                }


                if (TxtNoLitrosExtraccion.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de litros para la extraccion");
                    TxtNoLitrosExtraccion.Focus();
                    return;
                }

                if (TxtNoLote.Text == "")
                {
                    MessageBox.Show("No haz introducido un numero de lote");
                    TxtNoLote.Focus();
                    return;
                }

                String tipo_transaccion = "noaplica";

                if (!rdbDocumental.Checked)
                {
                    if (!rdbSitio.Checked)
                    {
                        MessageBox.Show("Favor de seleccionar tipo de cobro");
                        return;
                    }
                    else
                    {
                        tipo_transaccion = "sitio";
                    }
                }
                else
                {
                    tipo_transaccion = "documental";
                }




                if (CmbTipoInstalacion.Text == "Envasadora")
                {

                    ObtenerIdMaximoAlmacenEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT   id_marca,DATE_FORMAT(fecha_envasado_ini, '%Y/%m/%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin, '%Y/%m/%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud,  id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,  botellas_existentes, holograma_inicio, holograma_fin FROM envasado_entrada where id_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_entrada(id_almacen_envasado_entrada, id_marca, no_cliente, id_almacen, fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales, botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador, actualizado) VALUES ( '" + id_max_almacen_envasado_entrada + "','" + row["id_marca"].ToString() + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["fecha_envasado_ini"].ToString() + "','" + row["fecha_envasado_fin"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" + row["etiquetado_como"].ToString()+"','" + row["unidad_medida"].ToString() + "','" + row["contenido_por_botella"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico"].ToString() + "','" + row["grado_alcoholico_etiqueta"].ToString() + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        //// el if el el campo de botellas iniciales es para checar el detalle con las botellas iniciales hay registros que son null y en 0. en el primero no registra nada y en el segundo genera un valor con signo (-) 
                        if (ConexionMysql.insUpd_transaccion("UPDATE  envasado_entrada SET litros=if(litros is null OR litros = 0,'0', ROUND(litros - " + TxtNoLitrosExtraccion.Text + ",2)),botellas_iniciales=if(botellas_iniciales is null OR botellas_iniciales=0,'0',ROUND(botellas_iniciales- " + txtNBotellas.Text + ",2)), botellas=ROUND(botellas - " + txtNBotellas.Text + ",2), botellas_existentes=ROUND(botellas_existentes - " + txtNBotellas.Text + ",2),actualizado=0 WHERE id_envasado_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_envasado_entrada, id_almacen_envasado_recibe, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_almacen_envasado_entrada + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT    id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado FROM envasado_ensamble where id_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoAlmacenEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_ensamble(id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_almacen_envasado_ensamble + "', '" + id_max_almacen_envasado_entrada + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet Datos3 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos3, "SELECT    no_cliente,cve_marca, holograma_inicio, holograma_fin,serie FROM envasado_holograma where id_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos3.Tables[0].Rows)
                    {
                        ObtenerIdMaximoEnvasadoHolograma();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente, cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES('" + id_max_almacen_envasado_holograma + "', '" + id_max_almacen_envasado_entrada + "','" + row["no_cliente"].ToString() + "','" + row["cve_marca"].ToString() + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + row["serie"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_envasado_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }




                    ConexionMysql.transCompleta();
                    MessageBox.Show("Traslado exitoso");
                    this.Close();
                }///---- fin if de envasadora
                else if (CmbTipoInstalacion.Text == "Almacen de Envasado")
                {

                    ObtenerIdMaximoAlmacenEnvasado();
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT   id_marca,DATE_FORMAT(fecha_envasado_ini, '%Y/%m/%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin, '%Y/%m/%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud,  id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como, unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,  botellas_existentes, holograma_inicio, holograma_fin FROM almacen_envasado_entrada where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'");

                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_entrada(id_almacen_envasado_entrada, id_marca, no_cliente, id_almacen, fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como, unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales, botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador, actualizado) VALUES ( '" + id_max_almacen_envasado_entrada + "','" + row["id_marca"].ToString() + "' ,'" + no_cliente + "','" + id_instalacion + "',now(),'" + row["fecha_envasado_ini"].ToString() + "','" + row["fecha_envasado_fin"].ToString() + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_solicitud"].ToString() + "','" + TxtNoLote.Text + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "' ,'" + row["fq"].ToString() + "','" + row["clase"].ToString() + "','" + row["categoria"].ToString() + "','" + row["abocante"].ToString() + "','" + row["ingrediente"].ToString() + "','" +row["etiquetado_como"].ToString() +"','" + row["unidad_medida"].ToString() + "','" + row["contenido_por_botella"].ToString() + "','" + TxtNoLitrosExtraccion.Text + "','" + row["grado_alcoholico"].ToString() + "','" + row["grado_alcoholico_etiqueta"].ToString() + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + txtNBotellas.Text + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        //// el if el el campo de botellas iniciales es para checar el detalle con las botellas iniciales hay registros que son null y en 0. en el primero no registra nada y en el segundo genera un valor con signo (-) 
                        if (ConexionMysql.insUpd_transaccion("UPDATE  almacen_envasado_entrada SET litros=if(litros is null OR litros = 0,'0', ROUND(litros - " + TxtNoLitrosExtraccion.Text + ",2)),botellas_iniciales=if(botellas_iniciales is null OR botellas_iniciales=0,'0',ROUND(botellas_iniciales- " + txtNBotellas.Text + ",2)), botellas=ROUND(botellas - " + txtNBotellas.Text + ",2), botellas_existentes=ROUND(botellas_existentes - " + txtNBotellas.Text + ",2),actualizado=0 WHERE id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoTransacciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  transacciones(id_transaccion, id_almacen_envasado_entrada, id_almacen_envasado_recibe, id_verificador, actualizado,tipo_transaccion) VALUES( '" + id_max_transaccion + "' ,'" + CmbLote.SelectedValue + "','" + id_max_almacen_envasado_entrada + "','" + Usuario.IdUsuario + "',0,'" + tipo_transaccion + "')") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet Datos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos2, "SELECT    id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado FROM almacen_envasado_ensamble where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos2.Tables[0].Rows)
                    {
                        ObtenerIdMaximoAlmacenEnsambleEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_ensamble(id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES('" + id_max_almacen_envasado_ensamble + "', '" + id_max_almacen_envasado_entrada + "','" + row["id_comun"].ToString() + "','" + row["no_lote_granel"].ToString() + "','" + row["id_planta"].ToString() + "','" + row["id_predio"].ToString() + "','" + row["litros"].ToString() + "','" + row["agave_coccion_kg"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet Datos3 = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos3, "SELECT    no_cliente,cve_marca, holograma_inicio, holograma_fin,serie FROM almacen_envasado_holograma where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "'");
                    foreach (DataRow row in Datos3.Tables[0].Rows)
                    {
                        ObtenerIdMaximoAlmacenEnvasadoHolograma();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente, cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES('" + id_max_almacen_envasado_holograma + "', '" + id_max_almacen_envasado_entrada + "','" + row["no_cliente"].ToString() + "','" + row["cve_marca"].ToString() + "','" + row["holograma_inicio"].ToString() + "','" + row["holograma_fin"].ToString() + "','" + row["serie"].ToString() + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }




                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + CmbLote.SelectedValue + "' and tipo_instalacion='almacen_envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_envasado_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }


                    ConexionMysql.transCompleta();
                    MessageBox.Show("Traslado exitoso");
                    this.Close();

                }


            }
        }


        //agregar tanques a la tabla
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

        //elimina tanques  que no san necesarios de la tabla
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

        private void TxtNoLitrosExtraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtNoLitrosExtraccion.Text);
        }

        private void txtNBotellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, txtNBotellas.Text);
        }

        private void txtNBotellas_TextChanged(object sender, EventArgs e)
        {
            string Umedida = "";
            string cporbotella = "";
            string totalBotellasActuales = "";
            if (txtNBotellas.Text != "")
            {
                if (CmbTipoInstalacion.Text == "Envasadora")
                {
                    Umedida = ConexionMysql.regresaCampoConsulta("SELECT unidad_medida from envasado_entrada where id_envasado_entrada='" + CmbLote.SelectedValue + "' ");
                    cporbotella = ConexionMysql.regresaCampoConsulta("SELECT contenido_por_botella from envasado_entrada where id_envasado_entrada='" + CmbLote.SelectedValue + "' ");
                    totalBotellasActuales = ConexionMysql.regresaCampoConsulta("SELECT botellas_existentes from envasado_entrada where id_envasado_entrada='" + CmbLote.SelectedValue + "' ");

                }
                else if (CmbTipoInstalacion.Text == "Almacen de Envasado")
                {
                    Umedida = ConexionMysql.regresaCampoConsulta("SELECT unidad_medida from almacen_envasado_entrada where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "' ");
                    cporbotella = ConexionMysql.regresaCampoConsulta("SELECT contenido_por_botella from almacen_envasado_entrada where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "' ");
                    totalBotellasActuales = ConexionMysql.regresaCampoConsulta("SELECT botellas_existentes from almacen_envasado_entrada where id_almacen_envasado_entrada='" + CmbLote.SelectedValue + "' ");


                }




                if (Convert.ToDouble(txtNBotellas.Text) > Convert.ToDouble(totalBotellasActuales))
                {
                    MessageBox.Show("No cuanta con botellas suficientes para realizar el traslado");
                    txtNBotellas.Text = "";
                    return;
                }
                double ltsparaextraccion = calcula_botellas(Convert.ToDouble(txtNBotellas.Text), Umedida, cporbotella);
                TxtNoLitrosExtraccion.Text = Convert.ToString(ltsparaextraccion);

            }
            else { TxtNoLitrosExtraccion.Text = ""; }
        }

        public double calcula_botellas(double botellas, string medida, string contenido_por_botella)
        {///---- Calcula los litros de acuerdo al numero de botellas y su medida
            try
            {

                double conversion = 0;
                double lts = 0;

                if (medida == "Mililitros")
                {
                    conversion = Math.Round(double.Parse(contenido_por_botella), 2) / 1000;
                    lts = botellas * conversion;

                }
                else if (medida == "Litros")
                {
                    conversion = Math.Round(double.Parse(contenido_por_botella), 2);
                    lts = botellas * conversion;

                }
                else if (medida == "Centilitro")
                {
                    conversion = Math.Round(double.Parse(contenido_por_botella), 2) / 100;
                    lts = botellas * conversion;
                }

                return lts;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }

        private void CmbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipo_instalacion != "envasado" && tipo_instalacion != "almacen_envasado")
            {
                TxtNoLitrosExtraccion.Text = "";
                TxtNoTransaccion.Text = "";
                TxtNoLote.Text = "";
                TxtTanque.Text = "";
                dtsTanques.Tables["TANQUES"].Clear();


            }
            else
            {
                txtNBotellas.Text = "";
                TxtNoLitrosExtraccion.Text = "";
                TxtNoTransaccion.Text = "";
                TxtNoLote.Text = "";
                TxtTanque.Text = "";
                dtsTanques.Tables["TANQUES"].Clear();
            }

        }

    }
}
