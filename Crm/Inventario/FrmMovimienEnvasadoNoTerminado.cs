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
    public partial class FrmMovimienEnvasadoNoTerminado : Form
    {
        public FrmMovimienEnvasadoNoTerminado()
        {
            InitializeComponent();
        }


        public string tipo_instalacion;

        public string id_envasado_entrada;
        public string no_cliente;
        public string no_lote;
        public string botellas_existentes;
        public string litros_existentes;
        public string unidad_medida;
        public string presentacion;
        public string grado_alcoholico;
        public string clase;
        public string fq;
        string no_cliente_maquila;
        string id_max_envasado_entrada;
        DataSet dtsHologramas;
        string id_max_hologramas;
        string id_max_envasado_ensamble;
        Validacion valida = new Validacion();

        ///============= Almacen de envasado ==================////
        ///
        string id_max_almacen_envasado_entrada;
        string id_max_almacen_hologramas;
        string id_max_almacen_envasado_ensamble;
        string id_max_envasado_salida;



        private void FrmMovimienEnvasadoNoTerminado_Load(object sender, EventArgs e)
        {
            ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca FROM marcas  where no_cliente ='" + no_cliente + "' ORDER BY cve_marca ASC", "id", "marca");
            addTablaHologramas();
            txtNoLoteEnvasado.Enabled = false;
            txtNoLoteEnvasado.Text = no_lote;

            btnTerminarEnvasado_Click(sender, e);


            if (tipo_instalacion == "almacen_envasado")
            {
                btnReenvasado.Enabled = false;
            }
            else
            {
                btnReenvasado.Enabled = true;
            }

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

        //// ==========================   Almacen de envasado     ==========================================///

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




        //crea tabla hologramas
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
                ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca  FROM marcas  where no_cliente ='" + no_cliente_maquila + "'ORDER BY cve_marca ASC", "id", "marca");
                LblCliente.Visible = true;
                LblMaquilaCliente.Visible = true;
                LblMaquilaCliente.Text = no_cliente_maquila;
            }
            else
            {
                ChekMaquila.Checked = false; ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca  FROM marcas  where no_cliente ='" + no_cliente + "'ORDER BY cve_marca ASC", "id", "marca");
                LblCliente.Visible = false;
                LblMaquilaCliente.Visible = false;
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

                int holograma_inicio;
                int holograma_fin;
                int holograma_fin_amma;
                string no_cliente = CmbMarca.SelectedValue.ToString();
                no_cliente = no_cliente.Substring(0, 5);
                string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes where no_cliente = '" + no_cliente + "'");

                string cve_marca = CmbMarca.SelectedValue.ToString();
                int lenght = cve_marca.Length;
                int mark = lenght == 7 ? 1 : 2;
                cve_marca = cve_marca.Substring(6, mark);
                //cve_marca = cve_marca.Substring(6, 1);

                DataSet Datos = new DataSet();
                DataSet Datos1 = new DataSet();
                DataSet Datos3 = new DataSet();
                DataSet Datos2 = new DataSet();
                DataSet Datos4 = new DataSet();
                DataSet Datos5 = new DataSet();
                DataSet Datos6 = new DataSet();
                #region FUNCION ORIGINAL
                /*
                //ConexionMysql.llenaDataset(ref Datos, "select holograma_inicio,holograma_fin from envasado_holograma where no_cliente='" + no_cliente + "' and cve_marca='" + cve_marca + "' and serie='" + TxtSerie.Text.ToUpper() + "'");
                ConexionMysql.llenaDataset(ref Datos, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,4) = em.no_cliente and  SUBSTRING(ee.id_marca,6,1)=em.cve_marca  where eh.no_cliente='" + no_cliente + "' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "'");
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);

                    //--- string lote = "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

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
                        // MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos" + Environment.NewLine + lote + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text);

                        MessageBox.Show("No puedes introducir este rango ya que has utilizado algunos para : " + Environment.NewLine + Environment.NewLine + lote + Environment.NewLine + Environment.NewLine + "Utilizados: " + holograma_inicio.ToString() + " - " + holograma_fin.ToString() + Environment.NewLine + "Introducidos: " + TxtHologramaInicio.Text + " - " + TxtHologramaFin.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                ///// --- BUSCA SI EXISTE  HOLOGRAMAS OCUPADOS DE LA  MARCA EN ALMACEN DE ENVASASO HOLOGRAMAS 
                DataSet Datos3 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos3, "select aeh.holograma_inicio,aeh.holograma_fin, aee.no_lote, em.marca,aee.contenido_por_botella,aee.unidad_medida from almacen_envasado_holograma aeh inner join almacen_envasado_entrada aee on aeh.id_almacen_envasado_entrada = aee.id_almacen_envasado_entrada inner join marcas em on  SUBSTRING(aee.id_marca,1,4) = em.no_cliente and  SUBSTRING(aee.id_marca,6,1)=em.cve_marca  where aeh.no_cliente='" + no_cliente + "' and aeh.cve_marca='" + cve_marca + "' and aeh.serie='" + TxtSerie.Text.ToUpper() + "'");

                foreach (DataRow row in Datos3.Tables[0].Rows)
                {



                    holograma_inicio = Convert.ToInt32(row["holograma_inicio"]);
                    holograma_fin = Convert.ToInt32(row["holograma_fin"]);

                    string lote = "Tipo de instalacion :  Almacen  de Envasado" + Environment.NewLine + "Lote : " + Convert.ToString(row["no_lote"]) + Environment.NewLine + "Marca : " + Convert.ToString(row["marca"]) + Environment.NewLine + " Presentacion : " + Convert.ToString(row["contenido_por_botella"]) + " " + Convert.ToString(row["unidad_medida"]) + ".";

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

                DataSet Datos2 = new DataSet();
                ConexionMysql.llenaDataset(ref Datos2, " select   MAX(ff1) AS ff1 from hologramas_salida where no_cliente='" + no_cliente + "' and marca='" + cve_marca + "' and serie='" + TxtSerie.Text + "' ");

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

                if (chkHologramasAnteriores.Checked == true)
                {
                    //MessageBox.Show("");
                    //string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes where no_cliente = '" + no_cliente + "'");
                    ConexionMysql.llenaDataset(ref Datos, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from reveca2.envasado_holograma eh inner join reveca2.envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join reveca2.marcas em on  SUBSTRING(ee.id_marca,1,4) = em.no_cliente and  SUBSTRING(ee.id_marca,6,1)=em.cve_marca where eh.no_cliente='" + clienteCrm + "' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "'");
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
                    ConexionMysql.llenaDataset(ref Datos1, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,5) = em.no_cliente and  SUBSTRING(ee.id_marca,7,1)=em.cve_marca where eh.no_cliente='" + no_cliente + "' AND eh.cliente_crm='" + clienteCrm + "'and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "'");
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
                                            MessageBox.Show("No se ah encontrado registro alguno de hologramas para la marca : " + Environment.NewLine + CmbMarca.Text, "¡¡AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return;
                                        }

                                        holograma_fin_amma = Convert.ToInt32(row2["ff1a"]);
                                        MessageBox.Show(holograma_fin_amma.ToString());
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

                    ConexionMysql.llenaDataset(ref Datos, "select eh.holograma_inicio,eh.holograma_fin, ee.no_lote, em.marca,ee.contenido_por_botella,ee.unidad_medida from envasado_holograma eh inner join envasado_entrada ee on eh.id_envasado_entrada = ee.id_envasado_entrada inner join marcas em on  SUBSTRING(ee.id_marca,1,5) = em.no_cliente and  SUBSTRING(ee.id_marca,7,1)=em.cve_marca  where eh.no_cliente='" + no_cliente + "' AND eh.cliente_crm='' and eh.cve_marca='" + cve_marca + "' and eh.serie='" + TxtSerie.Text.ToUpper() + "'");
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
                }// FIN DE HOLOGRAMAS NUEVOS AMMA



                DataRow fila = dtsHologramas.Tables["HOLOGRAMAS"].NewRow();
                fila["INICIO"] = TxtHologramaInicio.Text;
                fila["FIN"] = TxtHologramaFin.Text;
                fila["SERIE"] = TxtSerie.Text.ToUpper();
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsHologramas.Tables["HOLOGRAMAS"].Rows.Add(fila);
                TxtHologramaInicio.Text = "";
                TxtHologramaFin.Text = "";

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
            int totalBotellas = Convert.ToInt32(TxtBotellas.Text);
            if (totalBotellas != suma_botellas)
            {
                msj = true;
            }
            return msj;

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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int botellas = Convert.ToInt32(botellas_existentes);
            double litros = Math.Round(double.Parse(litros_existentes), 2);
            

            if (CmbMarca.SelectedValue == null)
            {
                MessageBox.Show("No ha seleccionado ninguna marca");
                return;
            }
            if (TxtClaveFqEnvasado.Text == "")
            {
                MessageBox.Show("No ha introducido un FQ");
                return;
            }
            if (TxtBotellas.Text == "")
            {
                MessageBox.Show("Introduce Botellas a extraer");
                TxtBotellas.Focus();
                return;
            }
            if (TxtBotellas.Text == "0")
            {
                MessageBox.Show("Introduce numero de botellas diferente de cero");
                TxtBotellas.Focus();
                return;
            }
            if (Convert.ToInt32(TxtBotellas.Text) > botellas)
            {
                MessageBox.Show("Botellas insuficientes");
                TxtBotellas.Focus();
                return;
            }

            if (TxtGradoAlcoholicoEtiqueta.Text == "" || TxtGradoAlcoholicoEtiqueta.Text == "0")
            {
                MessageBox.Show("No ha introducido un grado alcohólico de la etiqueta");
                TxtGradoAlcoholicoEtiqueta.Focus();
                return;
            }

            if (clase == "Blanco o Joven" || clase == "Joven")
            {
               
                if (cmbEtiquetadocomo.Text == "---Elije una opcion---")
                {

                    MessageBox.Show("Elige una opcion de etiquetado");
                    return;

                }

            }

            if (DtaHologramas.RowCount == 0)
            {
                MessageBox.Show("Introduce un rango de hologramas");
                return;
            }

            Boolean ms = validaRangoBotellas();
            if (ms == true)
            {
                MessageBox.Show("Los hologramas ingresados no coinciden con el número de botellas");
                return;
            }


            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }

            else
            {



                if (Convert.ToInt32(TxtBotellas.Text) == botellas)
                {
                    if (tipo_instalacion == "almacen_envasado")
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_entrada SET fecha_movimiento=now(),no_lote='" + txtNoLoteEnvasado.Text + "', id_marca='" + CmbMarca.SelectedValue + "',fecha_envasado_fin='" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "', fq='" + TxtClaveFqEnvasado.Text + "',etiquetado_como='" + cmbEtiquetadocomo.Text + "',grado_alcoholico_etiqueta=" + TxtGradoAlcoholicoEtiqueta.Text + ",actualizado=0 where id_almacen_envasado_entrada='" + id_envasado_entrada + "' ") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET fecha_movimiento=now(),no_lote='" + txtNoLoteEnvasado.Text + "', id_marca='" + CmbMarca.SelectedValue + "',fecha_envasado_fin='" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "', fq='" + TxtClaveFqEnvasado.Text + "',etiquetado_como='"+cmbEtiquetadocomo.Text+"',grado_alcoholico_etiqueta=" + TxtGradoAlcoholicoEtiqueta.Text + ",verificador_termina = '" + Usuario.IdUsuario + "',actualizado=0 where id_envasado_entrada='" + id_envasado_entrada + "' ") == "Error")
                        {
                            return;
                        }
                    }//--- fin else




                }
                else
                {
                    double conversion = 0;
                    double litros_utilizados = 0;
                    if (unidad_medida == "Mililitros")
                    {
                        conversion = Math.Round(double.Parse(presentacion), 2) / 1000;
                    }
                    else if (unidad_medida == "Centilitro")
                    {
                        conversion = Math.Round(double.Parse(presentacion), 2) / 100;
                    }
                    else
                    {
                        conversion = Math.Round(double.Parse(presentacion), 2);
                    }


                    litros_utilizados = Convert.ToInt32(TxtBotellas.Text) * conversion;

                    DataSet Datos = new DataSet();

                    if (tipo_instalacion == "almacen_envasado")
                    {
                        ///----  para almacen de envasado

                        ConexionMysql.llenaDataset(ref Datos, "SELECT  id_marca, no_cliente, id_almacen, DATE_FORMAT(fecha, '%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado_ini, '%Y-%m-%d') as  fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin, '%Y-%m-%d') as  fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,unidad_medida, contenido_por_botella, litros, grado_alcoholico, botellas, botellas_existentes from almacen_envasado_entrada where id_almacen_envasado_entrada='" + id_envasado_entrada + "' ");

                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            ObtenerIdMaximoAlmacenEnvasadoEntrada();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO almacen_envasado_entrada (id_almacen_envasado_entrada,id_almacen_envasado_entrada_salio,id_marca, no_cliente, id_almacen,fecha_movimiento, fecha, fecha_envasado_ini, fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente, etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta, botellas, botellas_existentes,id_verificador,actualizado) VALUES ('" + id_max_almacen_envasado_entrada + "','" + id_envasado_entrada + "','" + CmbMarca.SelectedValue + "','" + Convert.ToString(row["no_cliente"]) + "','" + Convert.ToString(row["id_almacen"]) + "',now()" + ",now(),'" + Convert.ToString(row["fecha_envasado_ini"]) + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "','" + Convert.ToString(row["id_comun"]) + "','" + Convert.ToString(row["no_lote_granel"]) + "','" + Convert.ToString(row["id_solicitud"]) + "','" + txtNoLoteEnvasado.Text + "','" + Convert.ToString(row["id_planta"]) + "','" + Convert.ToString(row["id_predio"]) + "','" + TxtClaveFqEnvasado.Text + "','" + Convert.ToString(row["clase"]) + "','" + Convert.ToString(row["categoria"]) + "','" + Convert.ToString(row["abocante"]) + "','" + Convert.ToString(row["ingrediente"]) + "','" + cmbEtiquetadocomo.Text + "','" + Convert.ToString(row["unidad_medida"]) + "','" + Convert.ToString(row["contenido_por_botella"]) + "'," + litros_utilizados + ",'" + Convert.ToString(row["grado_alcoholico"]) + "'," + TxtGradoAlcoholicoEtiqueta.Text + ",'" + TxtBotellas.Text + "','" + TxtBotellas.Text + "'," + Usuario.IdUsuario + ",0) ") == "Error")
                            //-- Convert.ToString(row["fecha_envasado_fin"]) | Convert.ToString(row["fecha"])
                            {
                                return;
                            }
                        }

                        double litros_sobran = Math.Round(litros, 2) - Math.Round(litros_utilizados, 2);
                        int botellas_sobran = botellas - Convert.ToInt32(TxtBotellas.Text);

                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_entrada SET litros='" + Math.Round(litros_sobran, 2) + "', botellas=" + botellas_sobran + ",botellas_existentes=" + botellas_sobran + ",actualizado=0 where id_almacen_envasado_entrada='" + id_envasado_entrada + "' ") == "Error")
                        {
                            return;
                        }


                        DataSet Datos2 = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos2, "SELECT   id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg from almacen_envasado_ensamble where id_almacen_envasado_entrada='" + id_envasado_entrada + "' ");
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {
                            ObtenerIdMaximoAlmacenEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO almacen_envasado_ensamble ( id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES ('" + id_max_almacen_envasado_ensamble + "','" + id_max_almacen_envasado_entrada + "','" + Convert.ToString(row["id_comun"]) + "','" + Convert.ToString(row["no_lote_granel"]) + "','" + Convert.ToString(row["id_planta"]) + "','" + Convert.ToString(row["id_predio"]) + "','" + Convert.ToString(row["litros"]) + "','" + Convert.ToString(row["agave_coccion_kg"]) + "'," + Usuario.IdUsuario + ",0) ") == "Error")
                            {
                                return;
                            }
                        }



                        DataSet ids = new DataSet();
                        ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + id_envasado_entrada + "' and tipo_instalacion='almacen_envasado'");

                        foreach (DataRow row in ids.Tables[0].Rows)
                        {
                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_envasado_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                            {
                                return;
                            }
                        }

                    }///---fin del if 
                    else
                    {

                        ///--- para envasado-------
                        ConexionMysql.llenaDataset(ref Datos, "SELECT  id_marca, no_cliente, id_envasadora, DATE_FORMAT(fecha, '%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado_ini, '%Y-%m-%d') as  fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin, '%Y-%m-%d') as  fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,unidad_medida, contenido_por_botella, litros, grado_alcoholico, botellas, botellas_existentes from envasado_entrada where id_envasado_entrada='" + id_envasado_entrada + "' ");

                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            ObtenerIdMaximoEnvasadoEntrada();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_entrada (id_envasado_entrada,id_envasado_entrada_salio,id_marca, no_cliente, id_envasadora,fecha_movimiento, fecha, fecha_envasado_ini, fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta, botellas, botellas_existentes,id_verificador,verificador_termina,actualizado) VALUES ('" + id_max_envasado_entrada + "','" + id_envasado_entrada + "','" + CmbMarca.SelectedValue + "','" + Convert.ToString(row["no_cliente"]) + "','" + Convert.ToString(row["id_envasadora"]) + "',now()" + ",now(),'" + Convert.ToString(row["fecha_envasado_ini"]) + "','" + DtaFechaEnvasadofin.Value.ToString("yyyy-MM-dd") + "','" + Convert.ToString(row["id_comun"]) + "','" + Convert.ToString(row["no_lote_granel"]) + "','" + Convert.ToString(row["id_solicitud"]) + "','" + txtNoLoteEnvasado.Text + "','" + Convert.ToString(row["id_planta"]) + "','" + Convert.ToString(row["id_predio"]) + "','" + TxtClaveFqEnvasado.Text + "','" + Convert.ToString(row["clase"]) + "','" + Convert.ToString(row["categoria"]) + "','" + Convert.ToString(row["abocante"]) + "','" + Convert.ToString(row["ingrediente"]) + "','" + cmbEtiquetadocomo.Text + "','" + Convert.ToString(row["unidad_medida"]) + "','" + Convert.ToString(row["contenido_por_botella"]) + "'," + litros_utilizados + ",'" + Convert.ToString(row["grado_alcoholico"]) + "'," + TxtGradoAlcoholicoEtiqueta.Text + ",'" + TxtBotellas.Text + "','" + TxtBotellas.Text + "'," + Usuario.IdUsuario + "," + Usuario.IdUsuario + ",0) ") == "Error")
                            //-- Convert.ToString(row["fecha_envasado_fin"]) | Convert.ToString(row["fecha"])
                            {
                                return;
                            }
                        }

                        double litros_sobran = Math.Round(litros, 2) - Math.Round(litros_utilizados, 2);
                        int botellas_sobran = botellas - Convert.ToInt32(TxtBotellas.Text);

                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET litros='" + Math.Round(litros_sobran, 2) + "', botellas=" + botellas_sobran + ",botellas_existentes=" + botellas_sobran + ",actualizado=0 where id_envasado_entrada='" + id_envasado_entrada + "' ") == "Error")
                        {
                            return;
                        }


                        DataSet Datos2 = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos2, "SELECT   id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg from envasado_ensamble where id_envasado_entrada='" + id_envasado_entrada + "' ");
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {
                            ObtenerIdMaximoEnvasadoEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_ensamble ( id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES ('" + id_max_envasado_ensamble + "','" + id_max_envasado_entrada + "','" + Convert.ToString(row["id_comun"]) + "','" + Convert.ToString(row["no_lote_granel"]) + "','" + Convert.ToString(row["id_planta"]) + "','" + Convert.ToString(row["id_predio"]) + "','" + Convert.ToString(row["litros"]) + "','" + Convert.ToString(row["agave_coccion_kg"]) + "'," + Usuario.IdUsuario + ",0) ") == "Error")
                            {
                                return;
                            }
                        }



                        DataSet ids = new DataSet();
                        ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + id_envasado_entrada + "' and tipo_instalacion='envasado'");

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

                    


                }///--- fin else




                // introduce hologramas a el envasado
                for (int x = 0; x < DtaHologramas.Rows.Count; x++)
                {


                    string no_cliente = CmbMarca.SelectedValue.ToString();
                    no_cliente = no_cliente.Substring(0, 5);

                    string cve_marca = CmbMarca.SelectedValue.ToString();
                    int lenght = cve_marca.Length;
                    int mark = lenght == 7 ? 1 : 2;
                    cve_marca = cve_marca.Substring(6, mark);
                    //cve_marca = cve_marca.Substring(6, 1);


                    if (tipo_instalacion == "almacen_envasado")
                    {

                        ///---para almacen --- 
                        ObtenerIdMaximoAlmacenEntradaHologramas();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_holograma(id_almacen_envasado_holograma,id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_almacen_hologramas + "','" + (id_max_almacen_envasado_entrada == null ? id_envasado_entrada : id_max_almacen_envasado_entrada) + "','" + no_cliente + "','" + cve_marca + "','" + DtaHologramas.Rows[x].Cells["INICIO"].Value + "' , '" + DtaHologramas.Rows[x].Cells["FIN"].Value + "','" + DtaHologramas.Rows[x].Cells["SERIE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {

                        /// ---para envasado
                        ObtenerIdMaximoEntradaHologramas();

                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_holograma(id_envasado_holograma,id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado) VALUES( '" + id_max_hologramas + "','" + (id_max_envasado_entrada == null ? id_envasado_entrada : id_max_envasado_entrada) + "','" + no_cliente + "','" + cve_marca + "','" + DtaHologramas.Rows[x].Cells["INICIO"].Value + "' , '" + DtaHologramas.Rows[x].Cells["FIN"].Value + "','" + DtaHologramas.Rows[x].Cells["SERIE"].Value + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }///--- fin del else -- 

                }///--- fin  del for hologramas -- 



                ConexionMysql.transCompleta();
                MessageBox.Show("Éxito");
                cmbEtiquetadocomo.Items.Clear();
                this.Close();
            }
        }//--------------------------- FIN Btnguardar --------------

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

        private void TxtBotellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }


        private void TxtGradoAlcoholicoEtiqueta_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoAlcoholicoEtiqueta.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chbNuevoNoLoteEnvasado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNuevoNoLoteEnvasado.Checked == true)
            {
                txtNoLoteEnvasado.Enabled = true;

            }
            else
            {

                txtNoLoteEnvasado.Enabled = false;
            }

        }

        private void btnReenvasado_Click(object sender, EventArgs e)
        {
            pnlReenvasado.Visible = true;
            pnlSalida.Visible = false;
            pnlTerminarEnvasado.Visible = false;
            lblNoLote.Text = no_lote;
            txtNoBotellasReenvasado.Text = "";
            TxtObservacionesReproceso.Text = "";

            cmbEtiquetadocomo.Items.Clear();

            // lblTituloPanelReenvasado.Text = "Reenvasado";

        }



        private void btnTerminarEnvasado_Click(object sender, EventArgs e)
        {
            pnlReenvasado.Visible = false;
            pnlSalida.Visible = false;
            pnlTerminarEnvasado.Visible = true;

            ChekMaquila.Checked = false;
            chbNuevoNoLoteEnvasado.Checked = false;
            TxtHologramaInicio.Text = "";
            TxtHologramaFin.Text = "";
            TxtSerie.Text = "";
            dtsHologramas.Tables["HOLOGRAMAS"].Clear();
            TxtGradoAlcoholicoEtiqueta.Text = "";
            TxtBotellas.Text = "";
            TxtClaveFqEnvasado.Text = fq;
            

            

            if (clase == "Blanco o Joven" || clase == "Joven")
            {

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





        }

        private void btnGuardarReenvasado_Click(object sender, EventArgs e)
        {


            if (Convert.ToInt32(txtNoBotellasReenvasado.Text) > Convert.ToInt32(botellas_existentes))
            {
                MessageBox.Show("Botellas insuficientes");
                txtNoBotellasReenvasado.Focus();
                return;
            }


            if (TxtObservacionesReproceso.Text == "")
            {
                MessageBox.Show("No se a ingresado observacion alguna para el movimiento de reenvasado");
                TxtObservacionesReproceso.Focus();
                return;
            }


            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }

            else
            {
                //string id_entrada_envasado_1 = ConexionMysql.regresaCampoConsulta("SELECT if (em2.id_envasado_entrada_salio = '' OR em2.id_envasado_entrada_salio IS NULL ,em2.id_envasado_entrada ,(SELECT em.id_envasado_entrada FROM  envasado_entrada em WHERE em.id_envasado_entrada=em2.id_envasado_entrada_salio)) as id_envasado_entrada FROM envasado_entrada em2 WHERE em2.id_envasado_entrada='" + id_envasado_entrada + "' ");


                ///--- obtiene el ide del lote de granel envasado para y verificar que no se aungresado con boton verde
                string id_granel_entrada_envasado = ConexionMysql.regresaCampoConsulta("SELECT id_granel_entrada_envasado FROM granel_salida where id_envasado_entrada='" + id_envasado_entrada + "' ");

                if (id_granel_entrada_envasado == "")
                {
                    // --- Entra si no encuentra registro de salida en granel
                    MessageBox.Show("El lote de envasado no cuenta con registro en granel de envasado, verificar el tipo de ingreso a la unidad de envasado. " + Environment.NewLine + "Comunicate con la unidad de verificación para más informacion.", "¡¡ATENCION!!");
                    return;

                }

                ///-- actualiza el numero de botellas en la existencia del lote de envasado
                if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET botellas_existentes=ROUND(botellas_existentes-" + txtNoBotellasReenvasado.Text + ",2), actualizado=0 WHERE id_envasado_entrada='" + id_envasado_entrada + "'") == "Error")
                {


                    return;
                }

                ////--- calcula los litros que se van a reprocesar del envasado del envasado -- 

                double calcula_ltspor_restar = Funtions.calcula_lts_botellas(Convert.ToDouble(txtNoBotellasReenvasado.Text), unidad_medida, presentacion);
                string ltspor_restar = Convert.ToString(calcula_ltspor_restar);


                ///--- actualiza los litros del granel de envasado -- 
                if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes+" + ltspor_restar + ",2), actualizado=0 WHERE id_granel_entrada_envasado='" + id_granel_entrada_envasado + "'") == "Error")
                {


                    return;
                }





                id_max_envasado_salida = IdMaximo.ObtenerIdMaximoEnvasadoSalida();

                ///--- registra el movimiento de salida del lote de envasado a reproceso
                if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_salida  (id_envasado_salida, id_envasado_entrada,id_granel_entrada_envasado, litros, botellas, grado_alcoholico,tipo_salida,observaciones, id_verificador, actualizado) values('" + id_max_envasado_salida + "','" + id_envasado_entrada + "','" + id_granel_entrada_envasado + "',ROUND(" + ltspor_restar + ",2)," + txtNoBotellasReenvasado.Text + "," + grado_alcoholico + ",'Reenvasado','" + TxtObservacionesReproceso.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                {
                    return;
                }





            }



            ConexionMysql.transCompleta();
            MessageBox.Show("Éxito");
            this.Close();
        }

        private void txtNoBotellasReenvasado_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void BtnSalida_Click(object sender, EventArgs e)
        {
            pnlReenvasado.Visible = false;
            pnlTerminarEnvasado.Visible = false;
            pnlSalida.Visible = true;

            lblNoLoteSalida.Text = no_lote;
            txtNoBotellasSalida.Text = "";
            txtTipoSalida.Text = "";
            rchtxtObservaciones.Text = "";


            cmbEtiquetadocomo.Items.Clear();
        }

        private void btnGuardarSalida_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToInt32(txtNoBotellasSalida.Text) > Convert.ToInt32(botellas_existentes))
                {
                    MessageBox.Show("Botellas insuficientes");
                    txtNoBotellasSalida.Focus();
                    return;
                }

                if (txtNoBotellasSalida.Text == "")
                {
                    MessageBox.Show("ingrese un numero de botellas");
                    txtNoBotellasSalida.Focus();
                    return;
                }
                if (txtTipoSalida.Text == "")
                {
                    MessageBox.Show("ingrese el motivo de la salida");
                    txtTipoSalida.Focus();
                    return;
                }

                if (rchtxtObservaciones.Text == "")
                {
                    MessageBox.Show("ingrese el motivo de la salida");
                    txtTipoSalida.Focus();
                    return;
                } 



                DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (check == DialogResult.Cancel) { return; }

                else
                {


                    if (tipo_instalacion == "almacen_envasado")
                    {


                        string id_max_envasado_movimientos = IdMaximo.ObtenerIdMaximoAlmacenEnvasadoMovimientos();

                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_movimientos(id_almacen_envasado_movimientos,id_almacen_envasado_entrada,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES('" + id_max_envasado_movimientos + "', '" + id_envasado_entrada + "','" + no_cliente + "','salida','" + txtTipoSalida.Text + "','" + txtNoBotellasSalida.Text + "','" + txtNoBotellasSalida.Text + "',0,0,now() , '" + Usuario.IdUsuario + "',0,'" + rchtxtObservaciones.Text + "')") == "Error")
                        {
                            return;
                        }

                        if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_entrada SET botellas_existentes=botellas_existentes-" + txtNoBotellasSalida.Text + ", actualizado=0 where id_almacen_envasado_entrada='" + id_envasado_entrada + "'") == "Error")
                        {
                            return;
                        }




                    }
                    else
                    {
                        string id_max_envasado_movimientos = IdMaximo.ObtenerIdMaximoEnvasadoMovimientos();


                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES('" + id_max_envasado_movimientos + "', '" + id_envasado_entrada + "','" + no_cliente + "','salida','" + txtTipoSalida.Text + "','" + txtNoBotellasSalida.Text + "','" + txtNoBotellasSalida.Text + "',0,0,now() , '" + Usuario.IdUsuario + "',0,'" + rchtxtObservaciones.Text + "')") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET botellas_existentes=botellas_existentes-" + txtNoBotellasSalida.Text + ", actualizado=0 where id_envasado_entrada='" + id_envasado_entrada + "'") == "Error")
                        {
                            return;
                        }
                    }//--- fin del else tipo de instalacion




                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtNoBotellasSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

    }
}
