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
    public partial class FrmGranelNuevo : Form
    {
        public FrmGranelNuevo()
        {
            InitializeComponent();
            lbltituloingrediente.Enabled = false;
            TxtIngrediente.Enabled = false;
        }
        #region VARIABLES
        public string no_cliente;
        public string tipo;
        public string id_fabrica = "";
        public string id_envasadora = "";
        public string id_almacen = "";
        string id_max_granel_entrada;
        string id_max_granel_entrada_envasado;
        string id_max_granel_ensamble = "";
        string id_max_granel_ensamble_envasado = "";
        string id_max_granel_tanque = "";
        string id_max_granel_tanque_envasado = "";
        //VARIABALE PARA GUARDAR EL TIPO DE CULTIVO
        string tipoCultivo = "";


        DataSet dtsTanques;
        DataTable DtaMaguey;
        Validacion valida = new Validacion();

        ////--------- Almacen ------------
        string id_max_almacen_granel_entrada;
        string id_max_almacen_granel_ensamble = "";
        string id_max_almacen_granel_tanque = "";
        #endregion

        #region    METODOS OBTENER MAXIMO ID
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


        //obtencion de los id para todas las entradas a granel 
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


        //obtencion de los id para todas las entradas a granel 
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


        //obtencion de los id para todas las ensambles  Almacen granel 
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


        //obtencion de los id para todos los tanques almacen 
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
        #endregion

        private void FrmGranelNuevo_Load(object sender, EventArgs e)
        {
            if (tipo == "fabrica")
            {
                lblAlmacen.Visible = false;
                cmbAlmacen.Visible = false;
                txtAlmacenEncargado.Visible = false;
                CmbFabrica.Visible = true;
                TxtMestroMezcalero.Visible = true;
                CmbEnvasadora.Visible = false;
                TxtResponsableEnvasadora.Visible = false;
                LblEnvasadora.Visible = false;
                LblResponsable.Visible = false;
                ConexionMysql.llenaCombo(ref CmbFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + no_cliente + "'", "id_fabrica", "fabrica");


                if (id_fabrica != "")
                {
                    CmbFabrica.SelectedValue = id_fabrica;
                }


            }
            else if (tipo == "almacen")
            {
                CmbFabrica.Visible = false;
                TxtMestroMezcalero.Visible = false;
                CmbEnvasadora.Visible = false;
                TxtResponsableEnvasadora.Visible = false;
                LblEnvasadora.Visible = false;
                LblResponsable.Visible = false;
                lblAlmacen.Visible = true;
                cmbAlmacen.Visible = true;
                txtAlmacenEncargado.Visible = true;
                //ConexionMysql.llenaCombo(ref CmbFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + no_cliente + "'", "id_fabrica", "fabrica");
                ConexionMysql.llenaCombo(ref cmbAlmacen, "SELECT almacen,id_almacen FROM almacen_encargado where no_cliente='" + no_cliente + "' AND tipo_almacen=1", "id_almacen", "almacen");
                if (id_almacen != "")
                {
                    cmbAlmacen.SelectedValue = id_almacen;
                }


            }
            else
            {
                lblAlmacen.Visible = false;
                cmbAlmacen.Visible = false;
                txtAlmacenEncargado.Visible = false;
                CmbFabrica.Visible = false;
                TxtMestroMezcalero.Visible = false;
                CmbEnvasadora.Visible = true;
                TxtResponsableEnvasadora.Visible = true;
                LblFabrica.Visible = false;
                LblMestro.Visible = false;
                ConexionMysql.llenaCombo(ref CmbEnvasadora, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + no_cliente + "'", "id_envasadora", "envasadora");
                if (id_envasadora != "")
                {
                    CmbEnvasadora.SelectedValue = id_envasadora;
                }

            }


            // ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,nombre FROM comun ", "id_comun", "nombre");

            ConexionMysql.llenaCombo(ref CmbMaguey, " SELECT id_comun,CONCAT (comun.nombre,' (',especie.genespecie,')') as nombre FROM comun INNER JOIN especie ON especie.id_especie=comun.id_especie WHERE comun.status=1 ORDER BY comun.nombre ASC", "id_comun", "nombre");

            addTablaTanques();
            addTablaMaguey();

            CmbCategoria.Items.Insert(0, "---Elije una opcion---");
            CmbCategoria.Items.Insert(1, "Mezcal");
            CmbCategoria.Items.Insert(2, "Mezcal Artesanal");
            CmbCategoria.Items.Insert(3, "Mezcal Ancestral");

            CmbCategoria.SelectedIndex = 0;

            CmbClase.Items.Insert(0, "---Elije una opcion---");
            CmbClase.Items.Insert(1, "Blanco o Joven");
            CmbClase.Items.Insert(2, "Reposado");
            CmbClase.Items.Insert(3, "Añejo");
            CmbClase.Items.Insert(4, "Abocado con");
            CmbClase.Items.Insert(5, "Destilado con");
            CmbClase.Items.Insert(6, "Madurado en vidrio");

            CmbClase.SelectedIndex = 0;

        }

        private void addTablaMaguey()
        {
            DtaMaguey = new DataTable();
            DtaMaguey.Columns.Add("ID_COMUN", Type.GetType("System.String"));
            DtaMaguey.Columns.Add("NOMBRE", Type.GetType("System.String"));
            DtaMaguey.Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaMagueyGuardar.DataSource = DtaMaguey;
            DtaMagueyGuardar.Columns[0].Visible = false;
            DtaMagueyGuardar.Columns[2].Width = 55;
        }

        private void addTablaTanques()
        {
            dtsTanques = new DataSet();
            dtsTanques.Tables.Add("TANQUES");
            dtsTanques.Tables["TANQUES"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanques.Tables["TANQUES"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaTanques.DataSource = dtsTanques.Tables["TANQUES"];
        }


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

        private void BtnAgregarMaguey_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbMaguey.Text == "")
                {
                    MessageBox.Show("No ha seleccionado ningun maguey");
                    return;
                }
                DataRow fila = DtaMaguey.NewRow();

                fila["ID_COMUN"] = CmbMaguey.SelectedValue.ToString();
                fila["NOMBRE"] = CmbMaguey.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                DtaMaguey.Rows.Add(fila);

                string produccion = "";
                string coma = "";
                for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                {
                    produccion += coma + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value;
                    coma = ",";
                }
               // ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,nombre FROM comun WHERE  ID_COMUN NOT IN(" + produccion + ") ", "id_comun", "nombre");

              
                ConexionMysql.llenaCombo(ref CmbMaguey, " SELECT id_comun,CONCAT (comun.nombre,' (',especie.genespecie,')') as nombre FROM comun INNER JOIN especie ON especie.id_especie=comun.id_especie WHERE comun.status=1 and ID_COMUN NOT IN(" + produccion + ") ORDER BY comun.nombre ASC", "id_comun", "nombre");


                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DtaMagueyGuardar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaMagueyGuardar.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaMagueyGuardar.Rows.RemoveAt(e.RowIndex);
                    DtaMaguey.AcceptChanges();
                    CmbMaguey.DataSource = null;
                    if (DtaMagueyGuardar.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                        {
                            produccion += coma + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value;
                            coma = ",";
                        }
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,nombre FROM comun WHERE ID_COMUN NOT IN(" + produccion + ") ", "id_comun", "nombre");
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT id_comun,nombre FROM comun ", "id_comun", "nombre");
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TxtLitros_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitros.Text);
        }

        private void TxtGradoAlcoholico_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoAlcoholico.Text);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (DtaMagueyGuardar.RowCount == 0)
            {
                MessageBox.Show("No ha seleccionado ningun maguey ");
                return;
            }
            if (DtaTanques.RowCount == 0)
            {
                MessageBox.Show("No ha ingresado ningun tanque");
                TxtTanque.Focus();
                return;
            }

            if (TxtLitros.Text == "")
            {
                MessageBox.Show("No ha ingresado litros");
                TxtLitros.Focus();
                return;
            }
            if (TxtLitros.Text == "0")
            {
                MessageBox.Show("Deve ingresar un valor diferente de cero");
                TxtLitros.Focus();
                return;
            }
            if (TxtLitros.Text == ".")
            {
                MessageBox.Show("Deve ingresar un valor real");
                TxtLitros.Focus();
                return;
            }


            if (TxtGradoAlcoholico.Text == "")
            {
                MessageBox.Show("No ha ingresado grado alcohólico");
                TxtGradoAlcoholico.Focus();
                return;
            }
            if (TxtGradoAlcoholico.Text == "0")
            {
                MessageBox.Show("Deve ingresar un valor diferente de cero");
                TxtGradoAlcoholico.Focus();
                return;
            }
            if (TxtGradoAlcoholico.Text == ".")
            {
                MessageBox.Show("Deve ingresar un valor real");
                TxtGradoAlcoholico.Focus();
                return;
            }
            if (TxtNoLote.Text == "")
            {
                MessageBox.Show("Debe ingresar un nomero de lote");
                TxtNoLote.Focus();
                return;
            }
            if (CmbCategoria.Text == "---Elije una opcion---")
            {
                MessageBox.Show("No ha seleccionado categoria");
                return;
            }

            if (CmbClase.Text == "---Elije una opcion---")
            {
                MessageBox.Show("No ha seleccionado clase");
                return;
            }
            if (CmbClase.Text == "Abocado con" || CmbClase.Text == "Destilado con")
            {
                if (TxtIngrediente.Text == "")
                {

                    MessageBox.Show("No ha ingresado un ingrediente");
                    return;
                }
            }
            //TODO: SE AGREGA PARA VALIDAR SI ES UN LOTE QUE ESTABA EN REVECA Y CHEK EL RADIO BUTTON
            if (rdBtnRP.Checked)
            {
                if (DtaMagueyGuardar.Rows.Count == 1)
                {

                    if (chkMagueySilvestre.Checked == false && chkMagueyCultivado.Checked == false)
                {
                    MessageBox.Show("Debes elegir un tipo de cultivo del maguey");
                    return;
                }
                }
            }

            if (rdbLoteAntiguo.Checked)
            {
                
                if (String.IsNullOrEmpty(txtIdLoteReveca.Text))
                {
                    MessageBox.Show("Debes ingresar el identificador que tenía el lote en ReVeCa2");
                    return;
                }
            }
            
           
            // rdbLoteAntiguo nuevo Radio buttón para insertar el id del lote en reveca
            // rdbTrasladoExterior para un lote que proveiene de un traslado de un cliente externo o de otro bando
            string tipo_lote = "";

            if (!rdBtnRP.Checked)
            {
                if (!rdBtnSF.Checked)
                {
                    if (!RdBtnLN.Checked)
                    {
                        if (!rdbLoteAntiguo.Checked)//TODO: SE AGREGA PARA SABER SI ES LOTE ANTIGUO Y ASIGNAR LA CONSTANTE "LA" PARA GUARDARLO EN LA COLUMNA TIPO
                        {
                            if (!rdbTrasladoExterior.Checked)
                            {
                                if (!rdbSeguimientoProducto.Checked)
                                {
                                    MessageBox.Show("Favor de seleccionar tipo de Lote");
                                    return;
                                }
                                else
                                {
                                    tipo_lote = "SEPR";
                                }
                                
                            }
                            else
                            {
                                tipo_lote = "TRCE";
                            }
                        
                        }
                        else
                        {
                            tipo_lote = "LA";
                        }
                    }
                    else { tipo_lote = "LN"; }
                }
                else
                {  tipo_lote = "SF"; }
            }
            else
            {  tipo_lote = "RP"; }


            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {
                if (tipo == "fabrica")
                {
                    if (CmbFabrica.SelectedValue == null)
                    {
                        MessageBox.Show("Ingrese una fabrica");
                        return;
                    }
                    //obtenemos el id maximo de la entrada a granel
                    ObtenerIdMaximoGranelEntrada();
                    if (rdbLoteAntiguo.Checked) 
                    {
                        #region IF PARA GUARDAR CUANDO EL LOTE ES ANTIGUO EN REVECA2
                        if (DtaMagueyGuardar.Rows.Count == 1)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,id_lote_reveca,no_cliente,id_fabrica,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada + "','" + txtIdLoteReveca.Text + "', '" + no_cliente + "','" + CmbFabrica.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    { ///--  para formar un ensamble -- 
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,id_lote_reveca,no_cliente,id_fabrica,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada + "','" + txtIdLoteReveca.Text + "', '" + no_cliente + "','" + CmbFabrica.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                        {
                            return;
                        }

                        for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                        {
                            ObtenerIdMaximoGranelEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_verificador) VALUES( '" + id_max_granel_ensamble + "','" + id_max_granel_entrada + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }

                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGraneTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques(id_tanque,id_granel_entrada,tanque,id_verificador) VALUES( '" + id_max_granel_tanque + "','" + id_max_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();
                        #endregion
                    }//Fin del if para saber si es lote antiguo en reveca2


                    else
                    {// else para saber que es lote diferente de antiguo en reveca2
                        #region ELSE PARA GUARDAR EL LOTE NORMALMENTE y se agrega lo de rp y tipo de cultivo de maguey
                        if (rdBtnRP.Checked)
                        {
                            if (chkMagueyCultivado.Checked == true)
                            {
                                tipoCultivo = "C";
                            }
                            else if (chkMagueySilvestre.Checked == true)
                            {
                                tipoCultivo = "S";
                            }


                            if (DtaMagueyGuardar.Rows.Count == 1)
                            {
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,tipo_cultivo_maguey,fecha_movimiento) VALUES('" + id_max_granel_entrada + "', '" + no_cliente + "','" + CmbFabrica.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "','" + tipoCultivo + "',NOW())") == "Error")
                                {
                                    return;
                                }
                            }
                            else
                            { ///--  para formar un ensamble -- 
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,tipo_cultivo_maguey,fecha_movimiento) VALUES('" + id_max_granel_entrada + "', '" + no_cliente + "','" + CmbFabrica.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "','" + tipoCultivo + "',NOW())") == "Error")
                                {
                                    return;
                                }

                                for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                                {
                                    ObtenerIdMaximoGranelEnsamble();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_verificador) VALUES( '" + id_max_granel_ensamble + "','" + id_max_granel_entrada + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                    {
                                        return;
                                    }
                                }
                            }

                            for (int x = 0; x < DtaTanques.Rows.Count; x++)
                            {
                                ObtenerIdMaximoGraneTanque();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques(id_tanque,id_granel_entrada,tanque,id_verificador) VALUES( '" + id_max_granel_tanque + "','" + id_max_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                            ConexionMysql.transCompleta();
                            MessageBox.Show("Éxito");
                            this.Close();

                        }
                        // PARA GUARDAR NORMAL SIN RP NI LOTE ANTIGUO
                        else { 
                        if (DtaMagueyGuardar.Rows.Count == 1)
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada + "', '" + no_cliente + "','" + CmbFabrica.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        { ///--  para formar un ensamble -- 
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada + "', '" + no_cliente + "','" + CmbFabrica.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                            {
                                return;
                            }

                            for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                            {
                                ObtenerIdMaximoGranelEnsamble();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_verificador) VALUES( '" + id_max_granel_ensamble + "','" + id_max_granel_entrada + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                        }

                        for (int x = 0; x < DtaTanques.Rows.Count; x++)
                        {
                            ObtenerIdMaximoGraneTanque();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques(id_tanque,id_granel_entrada,tanque,id_verificador) VALUES( '" + id_max_granel_tanque + "','" + id_max_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("Éxito");
                        this.Close();
                        }
                        #endregion
                    }//fin del if del else
                }///--- fin del if para fabrica ---

                else if (tipo == "almacen")
                {
                    if (cmbAlmacen.SelectedValue == null)
                    {
                        MessageBox.Show("Ingrese un almacen");
                        return;
                    }
                    //obtenesmos el id maximo de la entrada a granel
                    ObtenerIdMaximoAlmacenGranelEntrada();
                    if (rdbLoteAntiguo.Checked)
                    {
                        #region IF PARA VALIDAR SI SÍ TIENE ID DE LOTE ANTIGUO EN REVECA2
                        if (DtaMagueyGuardar.Rows.Count == 1)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,id_lote_reveca,no_cliente,id_almacen,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,fecha_movimiento,tipo_ingreso) VALUES('" + id_max_almacen_granel_entrada + "','" + txtIdLoteReveca.Text + "','" + no_cliente + "','" + cmbAlmacen.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",NOW(),'" + tipo_lote + "')") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    { ///--  para formar un ensamble -- 
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,id_lote_reveca,no_cliente,id_almacen,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,fecha_movimiento,tipo_ingreso) VALUES('" + id_max_almacen_granel_entrada + "','" + txtIdLoteReveca.Text + "', '" + no_cliente + "','" + cmbAlmacen.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",NOW(),'" + tipo_lote + "')") == "Error")
                        {
                            return;
                        }

                        for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                        {
                            ObtenerIdMaximoAlmacenGranelEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_verificador) VALUES( '" + id_max_almacen_granel_ensamble + "','" + id_max_almacen_granel_entrada + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }

                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoAlmacenGraneTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,id_verificador) VALUES( '" + id_max_almacen_granel_tanque + "','" + id_max_almacen_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();
                        #endregion
                    }// fin del if para saber si es lote antiguo en reveca2

                    else
                    {
                        #region ELSE PARA GUARDAR NORMAL, QUE NO TENGA ID LOTE ANTIGUO
                        if (DtaMagueyGuardar.Rows.Count == 1)
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,fecha_movimiento,tipo_ingreso) VALUES('" + id_max_almacen_granel_entrada + "', '" + no_cliente + "','" + cmbAlmacen.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",NOW(),'" + tipo_lote + "')") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        { ///--  para formar un ensamble -- 
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,fecha_movimiento,tipo_ingreso) VALUES('" + id_max_almacen_granel_entrada + "', '" + no_cliente + "','" + cmbAlmacen.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",NOW(),'" + tipo_lote + "')") == "Error")
                            {
                                return;
                            }

                            for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                            {
                                ObtenerIdMaximoAlmacenGranelEnsamble();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_verificador) VALUES( '" + id_max_almacen_granel_ensamble + "','" + id_max_almacen_granel_entrada + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                        }

                        for (int x = 0; x < DtaTanques.Rows.Count; x++)
                        {
                            ObtenerIdMaximoAlmacenGraneTanque();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,id_verificador) VALUES( '" + id_max_almacen_granel_tanque + "','" + id_max_almacen_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("Éxito");
                        this.Close();
                        #endregion
                    }// fin del if del else
                }///--- fin del if para almacen ---
                //TIPO ENVASADORA
                else
                {
                    if (CmbEnvasadora.SelectedValue == null)
                    {
                        MessageBox.Show("Ingrese una envasadora");
                        return;
                    }
                    //obtenesmos el id maximo de la entrada a granel de envasado
                    ObtenerIdMaximoGranelEntradaEnvasado();

                    if (rdbLoteAntiguo.Checked)//if verificar si está chekeado el radio buton
                    {
                        #region IF PARA VALIDAR SI ESTÁ CHECKEADO EL RADIO BUTON

                        if (DtaMagueyGuardar.Rows.Count == 1)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,id_lote_reveca,no_cliente,id_envasadora,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada_envasado + "','" + txtIdLoteReveca.Text + "', '" + no_cliente + "','" + CmbEnvasadora.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,id_lote_reveca,no_cliente,id_envasadora,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada_envasado + "','" + txtIdLoteReveca.Text + "', '" + no_cliente + "','" + CmbEnvasadora.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                        {
                            return;
                        }
                        for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                        {
                            ObtenerIdMaximoGranelEnsambleEnvasado();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_verificador) VALUES( '" + id_max_granel_ensamble_envasado + "','" + id_max_granel_entrada_envasado + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                    }
                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGranelTanqueEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador) VALUES( '" + id_max_granel_tanque_envasado + "','" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();
                        #endregion
                    }//fin del if para verificar que es lote con id de reveca
                    else
                    {
                        #region ELSE PARA GUARDAR CON RP Y DEMAS
                        // PARA GUARDAR TIPO RP
                        if (rdBtnRP.Checked)
                        {
                            if (chkMagueyCultivado.Checked == true)
                            {
                                tipoCultivo = "C";
                            }
                            else if (chkMagueySilvestre.Checked == true)
                            {
                                tipoCultivo = "S";
                            }
                            if (DtaMagueyGuardar.Rows.Count == 1)
                            {
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,tipo_cultivo_maguey,fecha_movimiento) VALUES('" + id_max_granel_entrada_envasado + "', '" + no_cliente + "','" + CmbEnvasadora.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "','" + tipoCultivo + "',NOW())") == "Error")
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,tipo_cultivo_maguey,fecha_movimiento) VALUES('" + id_max_granel_entrada_envasado + "', '" + no_cliente + "','" + CmbEnvasadora.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "','" + tipoCultivo + "',NOW())") == "Error")
                                {
                                    return;
                                }
                                for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                                {
                                    ObtenerIdMaximoGranelEnsambleEnvasado();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_verificador) VALUES( '" + id_max_granel_ensamble_envasado + "','" + id_max_granel_entrada_envasado + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                    {
                                        return;
                                    }
                                }
                            }
                            for (int x = 0; x < DtaTanques.Rows.Count; x++)
                            {
                                ObtenerIdMaximoGranelTanqueEnvasado();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador) VALUES( '" + id_max_granel_tanque_envasado + "','" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                            ConexionMysql.transCompleta();
                            MessageBox.Show("Éxito");
                            this.Close();

                        }
                        //PARA GUARDAR LO QUE NO SEA RP Y LOTE ANTIGUO
                        else
                        {

                        
                        if (DtaMagueyGuardar.Rows.Count == 1)
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora,fecha,id_comun,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada_envasado + "', '" + no_cliente + "','" + CmbEnvasadora.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "'," + DtaMagueyGuardar.Rows[0].Cells["ID_COMUN"].Value.ToString() + ",0,'" + TxtNoLote.Text + "' ,'" + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora,fecha,id_solicitud,no_lote,fq,clase,categoria,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,id_verificador,tipo_ingreso,fecha_movimiento) VALUES('" + id_max_granel_entrada_envasado + "', '" + no_cliente + "','" + CmbEnvasadora.SelectedValue + "','" + DataFechaInicioGranel.Value.ToString("yyyy-MM-dd") + "',0,'" + TxtNoLote.Text + "' ,' " + TxtFQ.Text + "','" + CmbClase.Text + "','" + CmbCategoria.Text + "','" + TxtIngrediente.Text + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + Usuario.IdUsuario + ",'" + tipo_lote + "',NOW())") == "Error")
                            {
                                return;
                            }
                            for (int x = 0; x < DtaMagueyGuardar.Rows.Count; x++)
                            {
                                ObtenerIdMaximoGranelEnsambleEnvasado();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_verificador) VALUES( '" + id_max_granel_ensamble_envasado + "','" + id_max_granel_entrada_envasado + "' ,'" + DtaMagueyGuardar.Rows[x].Cells["ID_COMUN"].Value.ToString() + "'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                            }
                        }
                        for (int x = 0; x < DtaTanques.Rows.Count; x++)
                        {
                            ObtenerIdMaximoGranelTanqueEnvasado();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador) VALUES( '" + id_max_granel_tanque_envasado + "','" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Usuario.IdUsuario + ")") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("Éxito");
                        this.Close();
                        }
                        #endregion
                    }// FIN DEL ELSE DEL IF DE VALIDACIÓN DE RADIO BUTON
                }
            }

        }

        //private void BtnAgregarMaestroMezcal_Click(object sender, EventArgs e)
        //{
        //    FrmNuevoMaestroFabrica frm = new FrmNuevoMaestroFabrica();
        //    frm.no_cliente = no_cliente;
        //    frm.ShowDialog();
        //    ConexionMysql.llenaCombo(ref CmbFabrica, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + no_cliente + "'", "id_fabrica", "fabrica");
        //}

        private void CmbFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFabrica.SelectedValue != null)
            {
                // TxtMestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabrica.SelectedValue + "'");
                TxtMestroMezcalero.Text = ConexionMysql.regresaCampoConsulta("SELECT mm.n_maestro_mezcalero FROM maestros_mezcaleros mm WHERE mm.activo=1 and mm.id_fabrica='" + CmbFabrica.SelectedValue + "';");


            }
        }

        private void CmbEnvasadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEnvasadora.SelectedValue != null)
            {
                TxtResponsableEnvasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + CmbEnvasadora.SelectedValue + "'");
            }
        }

        private void CmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbClase.Text == "Abocado con" || CmbClase.Text == "Destilado con")
            {
                lbltituloingrediente.Enabled = true;
                TxtIngrediente.Enabled = true;
            }
            else
            {
                TxtIngrediente.Text = "";
                lbltituloingrediente.Enabled = false;
                TxtIngrediente.Enabled = false;
            }
        }



        private void cmbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAlmacen.SelectedValue != null)
            {
                txtAlmacenEncargado.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  almacen_encargado  WHERE id_almacen='" + cmbAlmacen.SelectedValue + "';");



            }
        }

        private void rdBtnRP_CheckedChanged(object sender, EventArgs e)
        {
             if (rdBtnRP.Checked)
           {
               chkMagueySilvestre.Enabled = true;
               chkMagueyCultivado.Enabled = true;
           }
           else
           {
               chkMagueyCultivado.Enabled = false;
               chkMagueySilvestre.Enabled = false;
           }
        }

        private void rdbLoteAntiguo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLoteAntiguo.Checked)
            {
                txtIdLoteReveca.Enabled = true;
            }
            else
            {
                txtIdLoteReveca.Enabled = false;
            }
        }
    }
}
