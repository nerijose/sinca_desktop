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
using MySql.Data.MySqlClient;




namespace Crm.Inventario
{
    public partial class FrmExtraccionAgaveDos : Form
    {
        Validacion valida = new Validacion();
        DataSet dts;
        public FrmExtraccionAgaveDos()
        {
            InitializeComponent();
        }

        public string no_cliente = "";
        string id_max_planta_comprada;
        string id_max_planta_compradaCRM;




        //obtencion de los id para todas las entradas a granel 
        public void ObtenerIdMaximoPantaComprada()
        {
            id_max_planta_comprada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_existenciaplanta_comprada,4)) )   FROM existenciaplanta_comprada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_planta_comprada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_planta_comprada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_planta_comprada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_planta_comprada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_planta_comprada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_planta_comprada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        // para que guarde también en plantas compradas viejas
        public void ObtenerIdMaximoPantaCompradaCRM()
        {
            id_max_planta_compradaCRM = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_existenciaplanta_comprada,4)) )   FROM reveca2_existenciaplanta_comprada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_planta_compradaCRM == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_planta_compradaCRM = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_planta_compradaCRM = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_planta_compradaCRM) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_planta_compradaCRM = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_planta_compradaCRM = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        private void addTablas()
        {
            dts = new DataSet();
            dts.Tables.Add("EXTRACCION");
            dts.Tables["EXTRACCION"].Columns.Add("ID_PLANTA", Type.GetType("System.Int32"));
            dts.Tables["EXTRACCION"].Columns.Add("MAGUEY", Type.GetType("System.String"));
            dts.Tables["EXTRACCION"].Columns.Add("EXTRACCIÓN", Type.GetType("System.String"));
            dts.Tables["EXTRACCION"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaExtraccion.DataSource = dts.Tables["EXTRACCION"];
            DtaExtraccion.Columns[0].Visible = false;
            //DtaExtraccion.Columns[1].Visible = false;
            //DtaExtraccion.Columns[2].Visible = false;
        }

        private void FrmExtraccionAgave_Load(object sender, EventArgs e)
        {
            try
            {
                // creamos la tabla
                addTablas();

                //llenamos los numeros de guia para buscar 
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "select id_extraccion from cextracciones where status=1");
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    lista.Add(row[0].ToString());
                }
                TxtNoGuia.AutoCompleteCustomSource = lista;


                //llenamos los clientes para el envio de extraccion(quien recibe las extracciones) 
                //AutoCompleteStringCollection ListaClientes = new AutoCompleteStringCollection();
                //DataSet DatosClientes = new DataSet();
                //ConexionMysql.llenaDataset(ref DatosClientes, "select no_cliente from clientes ");
                //foreach (DataRow row in DatosClientes.Tables[0].Rows)
                //{
                //    ListaClientes.Add(row[0].ToString());
                //}
                //TxtNoClienteRecibe.AutoCompleteCustomSource = ListaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //connecting to database
            //MySqlConnection con = new MySqlConnection();
            //con.ConnectionString = "Database=reveca;Data Source=localhost;User Id=root;Password=";
            //con.Open();

            ////get values from database
            //string query = "select * from actualizacion_extracciones";
            //MySqlCommand cmd= new MySqlCommand(query, con);
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //DataSet Ds = new DataSet();
            //da.Fill(Ds);


            ////create object for AutoCompleteStringCollection
            //AutoCompleteStringCollection list= new AutoCompleteStringCollection();

            ////fetch the values and add to list object
            //foreach (DataRow row in Ds.Tables[0].Rows)
            //{
            //list.Add(row[0].ToString());
            //}

            ////adding list to your text element
            //TxtNoGuia.AutoCompleteCustomSource = list;

        }

        //apresionar enter carga los datos del maguey ya que key press no funciona por el autocomplete
        private void TxtNoGuia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G") 
                    { 
                        DataSet DatosMaguey = new DataSet();
                    ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=1 and  cextracciones.id_extraccion = '" + TxtNoGuia.Text.Trim() + "'");
                    if (DatosMaguey.Tables[0].Rows.Count == 0)
                    {
                        /* + los valores de de status son:
                         * 0 - ya utilizada
                         * 1 - no utilizada
                         */
                        string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=0 and  cextracciones.id_extraccion = '" + TxtNoGuia.Text.Trim() + "'");

                        if (guia_utilizada == "") { MessageBox.Show("Guia inexistente"); } else { MessageBox.Show("Guia ya utilizada"); };

                        // MessageBox.Show("Guia inexistente o ya utilizada");
                        TxtNoPredio.Text = "";
                        TxtNoCliente.Text = "";
                        TxtNombre.Text = "";
                        TxtParaje.Text = "";
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                        TxtExtraccion.Text = "";
                        TxtDireccion.Text = "";
                        dts.Tables["EXTRACCION"].Rows.Clear();
                        return;
                    }
                    TxtNoPredio.Text = DatosMaguey.Tables[0].Rows[0]["id_paraje"].ToString();
                    TxtNoCliente.Text = DatosMaguey.Tables[0].Rows[0]["id_cliente"].ToString();
                    TxtNombre.Text = DatosMaguey.Tables[0].Rows[0]["nombrep"].ToString();
                    TxtParaje.Text = DatosMaguey.Tables[0].Rows[0]["paraje"].ToString();
                    DatosMaguey.Tables[0].Rows.Clear();
                    CmbMaguey.DataSource = null;
                    TxtExistencia.Text = "";
                    TxtExtraccion.Text = "";
                    //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                    }

                    else
                    {
                        DataSet DatosMaguey = new DataSet();
                        ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=1 and  reveca2_cextracciones.id_extraccion = '" + TxtNoGuia.Text.Trim() + "'");
                        if (DatosMaguey.Tables[0].Rows.Count == 0)
                        {
                            /* + los valores de de status son:
                             * 0 - ya utilizada
                             * 1 - no utilizada
                             */
                            string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=0 and  reveca2_cextracciones.id_extraccion = '" + TxtNoGuia.Text.Trim() + "'");

                            if (guia_utilizada == "") { MessageBox.Show("Guia inexistente"); } else { MessageBox.Show("Guia ya utilizada"); };

                            // MessageBox.Show("Guia inexistente o ya utilizada");
                            TxtNoPredio.Text = "";
                            TxtNoCliente.Text = "";
                            TxtNombre.Text = "";
                            TxtParaje.Text = "";
                            CmbMaguey.DataSource = null;
                            TxtExistencia.Text = "";
                            TxtExtraccion.Text = "";
                            TxtDireccion.Text = "";
                            dts.Tables["EXTRACCION"].Rows.Clear();
                            return;
                        }
                        TxtNoPredio.Text = DatosMaguey.Tables[0].Rows[0]["id_paraje"].ToString();
                        TxtNoCliente.Text = DatosMaguey.Tables[0].Rows[0]["id_cliente"].ToString();
                        TxtNombre.Text = DatosMaguey.Tables[0].Rows[0]["nombrep"].ToString();
                        TxtParaje.Text = DatosMaguey.Tables[0].Rows[0]["paraje"].ToString();
                        DatosMaguey.Tables[0].Rows.Clear();
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                        TxtExtraccion.Text = "";
                        //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbMaguey_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbMaguey.DataSource != null)
                {
                    if(TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                    { 
                    TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta  WHERE id_plantas='" + CmbMaguey.SelectedValue + "'");
                    }
                    else
                    {
                        TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta  WHERE id_plantas='" + CmbMaguey.SelectedValue + "'");
                    }
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

        private void BtnExtraccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbMaguey.SelectedValue == null)
                {
                    MessageBox.Show("No existe maguey para extracción");
                    return;
                }

                if (TxtExistencia.Text == "" || TxtExistencia.Text == "0")
                {
                    MessageBox.Show("No hay existencia de maguey");
                    return;
                }

                if (TxtExtraccion.Text == "" || TxtExtraccion.Text == "0")
                {
                    MessageBox.Show("No ha ingresado su extracción");
                    return;
                }

                int existencia = int.Parse(TxtExistencia.Text);
                int extraccion = int.Parse(TxtExtraccion.Text);

                if (existencia < extraccion)
                {
                    MessageBox.Show("Existencia insificiente");
                    return;
                }

                string plantas = "";
                string coma = "";

                DataRow fila = dts.Tables["EXTRACCION"].NewRow();
                fila["ID_PLANTA"] = CmbMaguey.SelectedValue;
                fila["MAGUEY"] = CmbMaguey.Text;
                fila["EXTRACCIÓN"] = TxtExtraccion.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dts.Tables["EXTRACCION"].Rows.Add(fila);

                for (int x = 0; x < DtaExtraccion.Rows.Count; x++)
                {
                    plantas += coma + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value;
                    coma = ",";
                }
                CmbMaguey.DataSource = null;
                //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE  existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G") 
                { 
                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE  existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                }
                else
                {
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun WHERE  reveca2_existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  reveca2_existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                }

                if (CmbMaguey.Items.Count == 0)
                {
                    TxtExistencia.Text = "";
                }
                TxtExtraccion.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNoGuia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida.soloNumeros(e);
        }

        private void TxtExtraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TxtNoGuia.Text = "";
            TxtNoPredio.Text = "";
            TxtNoCliente.Text = "";
            TxtNombre.Text = "";
            TxtParaje.Text = "";
            CmbMaguey.DataSource = null;
            TxtExistencia.Text = "";
            TxtExtraccion.Text = "";
            TxtDireccion.Text = "";
            dts.Tables["EXTRACCION"].Rows.Clear();

        }



        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtNoGuia.Text == "")
            {
                MessageBox.Show("Ingrese una guia de extracción");
                return;
            }

            if (TxtNoCliente.Text == "")
            {
                MessageBox.Show("No hay numero de cliente");
                return;
            }

            if (DtaExtraccion.Rows.Count == 0)
            {
                MessageBox.Show("No ha realizado ninguna extracción");
                return;
            }

            if (TxtDireccion.Text == "")
            {
                MessageBox.Show("Debe introducir una dirección de entrega");
                return;
            }


            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {


                /* recorre los registros de la tabla que se van insertando al selecciona un maguey de cierta especie y de cierta edad.*/
                for (int x = 0; x < DtaExtraccion.Rows.Count; x++)
                {   

                        ObtenerIdMaximoPantaComprada();
                        ObtenerIdMaximoPantaCompradaCRM();

                    if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                    { 
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  existenciaplanta_comprada (id_existenciaplanta_comprada,no_guia,id_planta,no_cliente,cantidadini,existenciaplantas,id_verificador) VALUES('" + id_max_planta_comprada + "','" +TxtNoGuia.Text +"'," + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + ",'" + no_cliente + "'," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + "," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + "," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                        //-- }

                        /*Hace las siguientes consultas si hay o no coincidencias en existencia planta comprada: */

                       // string clienteEnvia = ConexionMysql.regresaCampoConsulta("SELECT p.id_cliente FROM cextracciones as g inner join paraje as p on p.id_paraje = g.id_paraje where g.id_extraccion = '" + TxtNoGuia.Text +"'");

                    /* inserta en retiro_plantas pendientes indistintamente siempre q haya o no haya coincidencias en existencia planta comprada*/
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES( '" + TxtNoGuia.Text + "'," + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + ",'" + TxtNoCliente.Text + "','" + no_cliente + "'," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + ",now(),0,'" + TxtDireccion.Text + "'," + Usuario.IdUsuario + ")") == "Error")
                        return;
                    /*se actualiza la tabla existenciaplanta en el campo existenciaplantas se resta la cantidad de plantas que se extrajeron de esa planta donde coincida el planta*/
                    if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + "  WHERE id_plantas =" + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + "") == "Error")
                        return;
                    /*cuando ya se utilizó esa guia se actualiza su estado de 1 a 0 en la tabla cextracciones*/
                    if (ConexionMysql.insUpd_transaccion("UPDATE  cextracciones SET status=0  WHERE id_extraccion ='" + TxtNoGuia.Text + "'") == "Error")
                        return;
                    /* aqui inserta en la tabla pero no inserta en fecha, no se por que */
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion) VALUES( '" + TxtNoGuia.Text + "'," + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + "," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + ")") == "Error")
                        return;
                    }

                    else
                    {

                        string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  reveca2_existenciaplanta_comprada (id_existenciaplanta_comprada,no_guia,id_planta,no_cliente,cantidadini,existenciaplantas,id_verificador) VALUES('" + id_max_planta_compradaCRM + "','" + TxtNoGuia.Text + "'," + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + ",'" + clienteCrm + "'," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + "," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + "," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                        //-- }

                        /*Hace las siguientes consultas si hay o no coincidencias en existencia planta comprada: */

                        /* inserta en retiro_plantas pendientes indistintamente siempre q haya o no haya coincidencias en existencia planta comprada*/
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO reveca2_retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES( '" + TxtNoGuia.Text + "'," + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + ",'" + TxtNoCliente.Text + "','" + no_cliente + "'," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + ",now(),0,'" + TxtDireccion.Text + "'," + Usuario.IdUsuario + ")") == "Error")
                            return;
                        /*se actualiza la tabla existenciaplanta en el campo existenciaplantas se resta la cantidad de plantas que se extrajeron de esa planta donde coincida el planta*/
                        if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + "  WHERE id_plantas =" + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + "") == "Error")
                            return;
                        /*cuando ya se utilizó esa guia se actualiza su estado de 1 a 0 en la tabla cextracciones*/
                        if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_cextracciones SET status=0  WHERE id_extraccion ='" + TxtNoGuia.Text + "'") == "Error")
                            return;
                        /* aqui inserta en la tabla pero no inserta en fecha, no se por que */
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  reveca2_actualizacion_extracciones (no_guia,id_plantas,extraccion) VALUES( '" + TxtNoGuia.Text + "'," + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value + "," + DtaExtraccion.Rows[x].Cells["EXTRACCIÓN"].Value + ")") == "Error")
                            return;
                    }
                }// fin for

                ConexionMysql.transCompleta();
                MessageBox.Show("Extracción realizada correctamente", ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNoGuia.Text = "";
                TxtNoPredio.Text = "";
                TxtNoCliente.Text = "";
                TxtNombre.Text = "";
                TxtParaje.Text = "";
                CmbMaguey.DataSource = null;
                TxtExistencia.Text = "";
                TxtExtraccion.Text = "";
                TxtDireccion.Text = "";
                dts.Tables["EXTRACCION"].Rows.Clear();
            }/// ===== fin del Dialog
        }


        private void DtaExtraccion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaExtraccion.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaExtraccion.Rows.RemoveAt(e.RowIndex);
                    dts.Tables["EXTRACCION"].AcceptChanges();
                    string plantas = "";
                    string coma = "";

                    if (e.RowIndex > 0)
                    {
                        for (int x = 0; x < DtaExtraccion.Rows.Count; x++)
                        {
                            plantas += coma + DtaExtraccion.Rows[x].Cells["ID_PLANTA"].Value;
                            coma = ",";
                        }
                        CmbMaguey.DataSource = null;
                        if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                        {
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE  existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                        }
                        else
                        {
                           // MessageBox.Show(plantas);
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun WHERE  reveca2_existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  reveca2_existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                        }
                            //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE  existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                    }
                    else
                    {
                        CmbMaguey.DataSource = null;

                        //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE  existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                        if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
                        {

                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE  existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                            //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE  existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                        }
                        else
                        {
                            //MessageBox.Show(plantas);+
                            ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun WHERE  reveca2_existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                            //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun WHERE  reveca2_existenciaplanta.id_plantas NOT IN(" + plantas + ")   AND  reveca2_existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }









    }
}
