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
    public partial class FrmCompletarTapda : Form
    {
        public FrmCompletarTapda()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();


        string id_predio_comprado = "";
        string no_guia = "";
        public string no_cliente = "";
        public string id_produccion = "";
        public string tipo_tapada = "";
        string guide2 = "";
        string cliente_envia = "";
        DataTable DtaAgaveCrudoSobrante = new DataTable();
        //DataTable DtaAgaveCrudoSobranteEnEspera = new DataTable();
        string id_actualizar_agave;
        string tabla_actualizacion;
        DataTable TablaCompletar;


        //---r@le-- variables para el id maximo de produccion ensamble        
        string id_max_produccion_entrada = "";
        string id_max_agave_sobrante = "";
        string id_max_produccion_ensamble_union = "";
        string id_max_guias_desconocidas = "";




        private void addTablaCompletarTapada()
        {
            TablaCompletar = new DataTable();
            TablaCompletar.Columns.Add("ID", Type.GetType("System.String"));//--de la produccion
            TablaCompletar.Columns.Add("TIPO", Type.GetType("System.String")); //TIPO 1=PRODUCION ENTRADA TIPO 2= PRODUCION ENSAMBLE
            TablaCompletar.Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            TablaCompletar.Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            TablaCompletar.Columns.Add("PLANTA", Type.GetType("System.String"));
            TablaCompletar.Columns.Add("EXTRACCION", Type.GetType("System.String"));
            TablaCompletar.Columns.Add("NO_GUIA", Type.GetType("System.String"));
            TablaCompletar.Columns.Add("ID_PLANTA_COMPRADA", Type.GetType("System.String"));
            TablaCompletar.Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaAgaveCompletarTapada.DataSource = TablaCompletar;
            DtaAgaveCompletarTapada.Columns[0].Visible = false;
            DtaAgaveCompletarTapada.Columns[1].Visible = false;
            DtaAgaveCompletarTapada.Columns[2].Visible = false;
            DtaAgaveCompletarTapada.Columns[3].Visible = false;
          DtaAgaveCompletarTapada.Columns[6].Visible = false;
            DtaAgaveCompletarTapada.Columns[7].Visible = false;
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

        // OBTENER ID MAXIMO DE GUIAS DESCONOCIDAS
        public void ObtenerIdMaximoGuiasDesconocidas()
        {
            id_max_guias_desconocidas = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_guia_desconocida,4)) )  FROM guias_desconocidas where verificador_id=" + Usuario.IdUsuario + " ");
            if (id_max_guias_desconocidas == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_guias_desconocidas = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_guias_desconocidas = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_guias_desconocidas) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_guias_desconocidas = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_guias_desconocidas = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        private void FrmCompletarTapda_Load(object sender, EventArgs e)
        {

            addTablaCompletarTapada();
            //tabla para agrar los valor del combox 
            DtaAgaveCrudoSobrante.Columns.Add("tipo_id", Type.GetType("System.String"));
            //DtaAgaveCrudoSobranteEnEspera.Columns.Add("tipo_id", Type.GetType("System.String"));
            DtaAgaveCrudoSobrante.Columns.Add("Descripcion", Type.GetType("System.String"));

            CmbMagueyNoRegistrado.DataSource = DtaAgaveCrudoSobrante;
            CmbMagueyNoRegistrado.ValueMember = "tipo_id";
            CmbMagueyNoRegistrado.DisplayMember = "Descripcion";
         

           // ConexionMysql.llenaCombo(ref CmbNoPredio, "SELECT id_paraje FROM paraje where id_cliente='"+no_cliente+"' ", "id_paraje", "id_paraje");
            TxtCampo.Visible = false;
            if (tipo_tapada == "1")
            {
                TxtCampo.Visible = true;
                CmbMagueyNoRegistrado.Enabled = false;
                TxtExtraccion.Text = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_entrada  WHERE id_produccion_entrada='"+id_produccion+"' ");
                TxtCampo.Text = "Especie :Planta no registrada" ;
            }
            else if (tipo_tapada == "2")
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT id_ensamble_union,id_planta,id_agave_sobrante,id_agave_cocido_sobrante,no_pinas_agave,tipo from produccion_ensamble where id_produccion_entrada='" + id_produccion + "' ");
                foreach (DataRow row in Datos.Tables[0].Rows)
                {
                    //carga numero de piña  de produccion normal
                    if (Convert.ToString(row["tipo"]) == "1" && Convert.ToString(row["no_pinas_agave"]) != "0" && Convert.ToString(row["id_planta"]) == "0")
                    {
                        if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                        {
                            DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                            fila["tipo_id"] = "2-" + Convert.ToString(row["id_ensamble_union"]);
                            fila["Descripcion"] = "Planta no registrada";
                            DtaAgaveCrudoSobrante.Rows.Add(fila);
                            CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);                
                        }
                        else
                        {
                            Boolean BanderaRepetidos = false;
                            foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                            { 
                                if (Convert.ToString(resultado["tipo_id"]) == "2-" + Convert.ToString(row["id_ensamble_union"]))
                                {
                                    BanderaRepetidos = true;
                                    break;
                                }
                            }

                            if (BanderaRepetidos == false)
                            {
                                DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                fila["tipo_id"] = "2-" + Convert.ToString(row["id_ensamble_union"]);
                                fila["Descripcion"] = "Planta no registrada";
                                DtaAgaveCrudoSobrante.Rows.Add(fila);
                                CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);
                            }
                        }

                    }
                    //carga numero de piña de agave crudo sobrante
                    else if (Convert.ToString(row["id_agave_sobrante"]) != "")
                    {         
                              DataSet DatosAgaveCrudoSobrante2 = new DataSet();
                               ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante2, "SELECT id_ensamble_union,id_produccion_entrada from produccion_agave_sobrante where id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "' ");
                               foreach (DataRow res2 in DatosAgaveCrudoSobrante2.Tables[0].Rows)
                               {
                                   DataSet DatosAgaveCrudoSobrante3 = new DataSet();
                                   ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante3, "SELECT id_agave_sobrante,no_pinas_agave,tipo from produccion_entrada where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' ");
                                   foreach (DataRow res3 in DatosAgaveCrudoSobrante3.Tables[0].Rows)
                                   {

                                       if (Convert.ToString(res3["no_pinas_agave"]) != "0" && Convert.ToString(res3["tipo"]) == "1")
                                       {
                                           if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                                           {
                                               DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                               fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                               fila["Descripcion"] = "Planta no registrada";
                                               DtaAgaveCrudoSobrante.Rows.Add(fila);
                                               CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);
                                           }
                                           else
                                           {
                                               Boolean BanderaRepetidos = false;
                                               foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                                               {
                                                   if (Convert.ToString(resultado["tipo_id"]) == "1-" + Convert.ToString(res2["id_produccion_entrada"]))
                                                   {
                                                       BanderaRepetidos = true;
                                                       break;
                                                   }
                                               }

                                               if (BanderaRepetidos == false)
                                               {
                                                   DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                                   fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                                   fila["Descripcion"] = "Planta no registrada";
                                                   DtaAgaveCrudoSobrante.Rows.Add(fila);
                                                   CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);
                                               }
                                           }
                                         
                                       }
                                       else if (Convert.ToString(res3["no_pinas_agave"]) == "0" && Convert.ToString(res3["tipo"]) == "2")
                                       {
                                           DataSet DatosAgaveCrudoSobrante4 = new DataSet();
                                           if (Convert.ToString(res2["id_ensamble_union"]) != "")
                                           {
                                               ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT  id_ensamble_union,id_planta,id_agave_sobrante,id_agave_cocido_sobrante,no_pinas_agave,tipo from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "'  and id_ensamble_union='" + Convert.ToString(res2["id_ensamble_union"]) + "' ");

                                                foreach (DataRow res4 in DatosAgaveCrudoSobrante4.Tables[0].Rows)
                                                {
                                                    BuscarNoPinasParaProduccionesIncompletas(Convert.ToString(res4["id_ensamble_union"]), Convert.ToString(res4["id_planta"]), Convert.ToString(res4["id_agave_sobrante"]), Convert.ToString(res4["id_agave_cocido_sobrante"]), Convert.ToString(res4["no_pinas_agave"]), Convert.ToString(res4["tipo"]));
                                                }
                                           }
                                           else
                                           {

                                             ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT id_ensamble_union,id_planta,id_agave_sobrante,id_agave_cocido_sobrante,no_pinas_agave,tipo from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' ");
                                             foreach (DataRow res4 in DatosAgaveCrudoSobrante4.Tables[0].Rows)
                                             {
                                               BuscarNoPinasParaProduccionesIncompletas(Convert.ToString(res4["id_ensamble_union"]), Convert.ToString(res4["id_planta"]), Convert.ToString(res4["id_agave_sobrante"]), Convert.ToString(res4["id_agave_cocido_sobrante"]), Convert.ToString(res4["no_pinas_agave"]), Convert.ToString(res4["tipo"]));
                                             }
                                           }


                                       }
                                    
                                   }
                               }                                 
                    }
                    //carga numero de piña de agave cocido sobrante
                    else if (Convert.ToString(row["id_agave_cocido_sobrante"]) != "")
                    {
                        DataSet DatosAgaveCrudoSobrante2 = new DataSet();
                        ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante2, "SELECT id_ensamble_union,id_produccion_entrada from produccion_agave_cocido_sobrante where id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "' ");
                        foreach (DataRow res2 in DatosAgaveCrudoSobrante2.Tables[0].Rows)
                        {
                            DataSet DatosAgaveCrudoSobrante3 = new DataSet();
                            ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante3, "SELECT id_agave_sobrante,no_pinas_agave,tipo from produccion_entrada where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' ");
                            foreach (DataRow res3 in DatosAgaveCrudoSobrante3.Tables[0].Rows)
                            {

                                if (Convert.ToString(res3["no_pinas_agave"]) != "0" && Convert.ToString(res3["tipo"]) == "1")
                                {
                                    if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                                    {
                                        DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                        fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                        fila["Descripcion"] = "Planta no registrada";
                                        DtaAgaveCrudoSobrante.Rows.Add(fila);
                                        CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        Boolean BanderaRepetidos = false;
                                        foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                                        {
                                            if (Convert.ToString(resultado["tipo_id"]) == "1-" + Convert.ToString(res2["id_produccion_entrada"]))
                                            {
                                                BanderaRepetidos = true;
                                                break;
                                            }
                                        }
                                        if (BanderaRepetidos == false)
                                        {
                                            DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                            fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                            fila["Descripcion"] = "Planta no registrada";
                                            DtaAgaveCrudoSobrante.Rows.Add(fila);
                                            CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);

                                        }
                                    }

                                }
                                else if (Convert.ToString(res3["no_pinas_agave"]) == "0" && Convert.ToString(res3["tipo"]) == "2")
                                {
                                    DataSet DatosAgaveCrudoSobrante4 = new DataSet();
                               
                                    if (Convert.ToString(res2["id_ensamble_union"]) != "")
                                    {
                                        ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT id_ensamble_union,id_planta,id_agave_sobrante,id_agave_cocido_sobrante,no_pinas_agave,tipo from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' and id_ensamble_union='" + Convert.ToString(res2["id_ensamble_union"]) + "' ");
                                    
                                        foreach (DataRow res4 in DatosAgaveCrudoSobrante4.Tables[0].Rows)
                                        {
                                            BuscarNoPinasParaProduccionesIncompletas(Convert.ToString(res4["id_ensamble_union"]), Convert.ToString(res4["id_planta"]), Convert.ToString(res4["id_agave_sobrante"]), Convert.ToString(res4["id_agave_cocido_sobrante"]), Convert.ToString(res4["no_pinas_agave"]), Convert.ToString(res4["tipo"]));                               
                                        }
                                    }
                                    else
                                    {
                                        ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT id_ensamble_union,id_planta,id_agave_sobrante,id_agave_cocido_sobrante,no_pinas_agave,tipo from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' ");
                                        foreach (DataRow res4 in DatosAgaveCrudoSobrante4.Tables[0].Rows)
                                        {
                                            BuscarNoPinasParaProduccionesIncompletas(Convert.ToString(res4["id_ensamble_union"]), Convert.ToString(res4["id_planta"]), Convert.ToString(res4["id_agave_sobrante"]), Convert.ToString(res4["id_agave_cocido_sobrante"]), Convert.ToString(res4["no_pinas_agave"]), Convert.ToString(res4["tipo"]));
                                       
                                        }
                                    }

                                }

                            }
                        }
                    }
                }
            }
            else if (tipo_tapada == "4")
            {

                string id_agave_sobrate;
                string id_produccion_entrada;
                string no_pinas_agave;
                string id_ensamble_union;

                //de que produccion agave sobrante salio
                id_agave_sobrate = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_entrada  WHERE id_produccion_entrada='" + id_produccion + "' ");

                //de que produccion entrada salio el agave sobrante
                id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_agave_sobrante  WHERE id_agave_sobrante='" + id_agave_sobrate + "' ");
                id_ensamble_union = ConexionMysql.regresaCampoConsulta("SELECT id_ensamble_union FROM  produccion_agave_sobrante  WHERE id_agave_sobrante='" + id_agave_sobrate + "' ");
                
                //si hay numero de piñas se sabe de donde salio si no salio de un ensamble
                no_pinas_agave = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_entrada  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                if (no_pinas_agave != "0")
                {

                    DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                    fila["tipo_id"] = "1-" + id_produccion_entrada;
                    fila["Descripcion"] = "Planta no registrada";
                    DtaAgaveCrudoSobrante.Rows.Add(fila);
                    CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);   
                    TxtExtraccion.Text = no_pinas_agave;
                }
                else
                {
                    if (id_ensamble_union != "")
                    {
                        TxtExtraccion.Text = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_ensamble  WHERE id_ensamble_union='" + id_ensamble_union + "' ");
                        DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                        fila["tipo_id"] = "2-" + id_ensamble_union;
                        fila["Descripcion"] = "Planta no registrada";
                        DtaAgaveCrudoSobrante.Rows.Add(fila);
                        CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e); 
                    }
                    else
                    {
                        TxtExtraccion.Text = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_ensamble  WHERE id_produccion_entrada='" + id_produccion_entrada + "' and tipo=1 ");
                        string id_ensamble_union2 = ConexionMysql.regresaCampoConsulta("SELECT id_ensamble_union FROM  produccion_ensamble  WHERE id_produccion_entrada='" + id_produccion_entrada + "' and tipo=1 ");
                       
                        DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                        fila["tipo_id"] = "2-" + id_ensamble_union2;
                        fila["Descripcion"] = "Planta no registrada";
                        DtaAgaveCrudoSobrante.Rows.Add(fila);
                        CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e); 
                    }
                 }
            }


        }


        public void BuscarNoPinasParaProduccionesIncompletas( string id_ensamble_union,string id_planta,string id_agave_sobrante,string id_agave_cocido_sobrante,string no_pinas_agave,string tipo)
        {
            //carga numero de piña  de produccion normal
            if (tipo == "1" && no_pinas_agave != "0" && id_planta == "0")
            {
                if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                {
                    DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                    fila["tipo_id"] = "2-" + id_ensamble_union;
                    fila["Descripcion"] = "Planta no registrada";
                    DtaAgaveCrudoSobrante.Rows.Add(fila);
                    CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                }
                else
                {
                    Boolean BanderaRepetidos = false;
                    foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                    {
                        if (Convert.ToString(resultado["tipo_id"]) == "2-" + id_ensamble_union)
                        {
                            BanderaRepetidos = true;
                            break;
                        }
                    }
                    if (BanderaRepetidos == false)
                    {
                        DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                        fila["tipo_id"] = "2-" + id_ensamble_union;
                        fila["Descripcion"] = "Planta no registrada";
                        DtaAgaveCrudoSobrante.Rows.Add(fila);
                        CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                    }
                }

            }
            //carga numero de piña de agave crudo sobrante
            else if (id_agave_sobrante != "")
            {
                DataSet DatosAgaveCrudoSobrante2 = new DataSet();
                ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante2, "SELECT id_ensamble_union,id_produccion_entrada from produccion_agave_sobrante where id_agave_sobrante='" + id_agave_sobrante + "' ");
                foreach (DataRow res2 in DatosAgaveCrudoSobrante2.Tables[0].Rows)
                {
                    DataSet DatosAgaveCrudoSobrante3 = new DataSet();
                    ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante3, "SELECT id_agave_sobrante,no_pinas_agave,tipo from produccion_entrada where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' ");
                    foreach (DataRow res3 in DatosAgaveCrudoSobrante3.Tables[0].Rows)
                    {

                        if (Convert.ToString(res3["no_pinas_agave"]) != "0" && Convert.ToString(res3["tipo"]) == "1")
                        {
                            if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                            {
                                DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                fila["Descripcion"] = "Planta no registrada";
                                DtaAgaveCrudoSobrante.Rows.Add(fila);
                                CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                            }
                            else
                            {
                                Boolean BanderaRepetidos = false;
                                foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                                {
                                    if (Convert.ToString(resultado["tipo_id"]) == "1-" + Convert.ToString(res2["id_produccion_entrada"]))
                                    {
                                        BanderaRepetidos = true;
                                        break;
                                    }
                                }
                                if (BanderaRepetidos == false)
                                {
                                    DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                    fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                    fila["Descripcion"] = "Planta no registrada";
                                    DtaAgaveCrudoSobrante.Rows.Add(fila);
                                    CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                                }
                            }


                        }
                        else if (Convert.ToString(res3["no_pinas_agave"]) == "0" && Convert.ToString(res3["tipo"]) == "2")
                        {
                            DataSet DatosAgaveCrudoSobrante4 = new DataSet();
                            if (Convert.ToString(res2["id_ensamble_union"]) != "")
                            {
                                ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT id_ensamble_union,no_pinas_agave from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' and tipo=1 and id_ensamble_union='" + Convert.ToString(res2["id_ensamble_union"]) + "' ");
                            }
                            else
                            {
                                ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT id_ensamble_union,no_pinas_agave from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' and tipo=1 ");

                            }
                            foreach (DataRow res4 in DatosAgaveCrudoSobrante4.Tables[0].Rows)
                            {
                                if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                                {
                                    DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                    fila["tipo_id"] = "2-" + Convert.ToString(res4["id_ensamble_union"]);
                                    fila["Descripcion"] = "Planta no registrada";
                                    DtaAgaveCrudoSobrante.Rows.Add(fila);
                                    CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                                }
                                else
                                {
                                    Boolean BanderaRepetidos = false;
                                    foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                                    {
                                        if (Convert.ToString(resultado["tipo_id"]) == "2-" + Convert.ToString(res4["id_ensamble_union"]))
                                        {
                                            BanderaRepetidos = true;
                                            break;
                                        }
                                    }
                                    if (BanderaRepetidos == false)
                                    {
                                        DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                        fila["tipo_id"] = "2-" + Convert.ToString(res4["id_ensamble_union"]);
                                        fila["Descripcion"] = "Planta no registrada";
                                        DtaAgaveCrudoSobrante.Rows.Add(fila);
                                        CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                                    }
                                }

                            }
                        }

                    }
                }
            }
            //carga numero de piña de agave cocido sobrante
            else if (id_agave_cocido_sobrante != "")
            {
                DataSet DatosAgaveCrudoSobrante2 = new DataSet();
                ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante2, "SELECT id_ensamble_union,id_produccion_entrada from produccion_agave_cocido_sobrante where id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "' ");
                foreach (DataRow res2 in DatosAgaveCrudoSobrante2.Tables[0].Rows)
                {
                    DataSet DatosAgaveCrudoSobrante3 = new DataSet();
                    ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante3, "SELECT id_agave_sobrante,no_pinas_agave,tipo from produccion_entrada where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' ");
                    foreach (DataRow res3 in DatosAgaveCrudoSobrante3.Tables[0].Rows)
                    {

                        if (Convert.ToString(res3["no_pinas_agave"]) != "0" && Convert.ToString(res3["tipo"]) == "1")
                        {
                            if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                            {
                                DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                fila["Descripcion"] = "Planta no registrada";
                                DtaAgaveCrudoSobrante.Rows.Add(fila);
                                CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                            }
                            else
                            {
                                Boolean BanderaRepetidos = false;
                                foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                                {
                                    if (Convert.ToString(resultado["tipo_id"]) == "1-" + Convert.ToString(res2["id_produccion_entrada"]))
                                    {
                                        BanderaRepetidos = true;
                                        break;
                                    }
                                }
                                if (BanderaRepetidos == false)
                                {
                                    DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                    fila["tipo_id"] = "1-" + Convert.ToString(res2["id_produccion_entrada"]);
                                    fila["Descripcion"] = "Planta no registrada";
                                    DtaAgaveCrudoSobrante.Rows.Add(fila);
                                    CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);

                                }
                            }


                        }
                        else if (Convert.ToString(res3["no_pinas_agave"]) == "0" && Convert.ToString(res3["tipo"]) == "2")
                        {
                            DataSet DatosAgaveCrudoSobrante4 = new DataSet();

                            if (Convert.ToString(res2["id_ensamble_union"]) != "")
                            {
                                ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT id_ensamble_union,no_pinas_agave from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' and tipo=1 and id_ensamble_union='" + Convert.ToString(res2["id_ensamble_union"]) + "' ");

                            }
                            else
                            {
                                ConexionMysql.llenaDataset(ref DatosAgaveCrudoSobrante4, "SELECT id_ensamble_union,no_pinas_agave from produccion_ensamble where id_produccion_entrada='" + Convert.ToString(res2["id_produccion_entrada"]) + "' and tipo=1 ");

                            }

                            foreach (DataRow res4 in DatosAgaveCrudoSobrante4.Tables[0].Rows)
                            {

                                if (DtaAgaveCrudoSobrante.Rows.Count == 0)
                                {
                                    DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                    fila["tipo_id"] = "2-" + Convert.ToString(res4["id_ensamble_union"]);
                                    fila["Descripcion"] = "Planta no registrada";
                                    DtaAgaveCrudoSobrante.Rows.Add(fila);
                                    CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                                }
                                else
                                {
                                    Boolean BanderaRepetidos = false;
                                    foreach (DataRow resultado in DtaAgaveCrudoSobrante.Rows)
                                    {
                                        if (Convert.ToString(resultado["tipo_id"]) == "2-" + Convert.ToString(res4["id_ensamble_union"]))
                                        {
                                            BanderaRepetidos = true;
                                            break;
                                        }
                                    }
                                    if (BanderaRepetidos == false)
                                    {
                                        DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                                        fila["tipo_id"] = "2-" + Convert.ToString(res4["id_ensamble_union"]);
                                        fila["Descripcion"] = "Planta no registrada";
                                        DtaAgaveCrudoSobrante.Rows.Add(fila);
                                        CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                                    }
                                }
                            }

                        }

                    }
                }


            }
        }

        private void CmbNoPredio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbMaguey.DataSource = null;
                TxtPredioDesconocido.Text = "";
                if (CmbNoPredio.DataSource != null)
                {
                    TxtPredioDesconocido.Text = ConexionMysql.regresaCampoConsulta("SELECT paraje FROM  paraje  WHERE id_paraje=" + CmbNoPredio.SelectedValue + "");

                    if (DtaAgaveCompletarTapada.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";

                        for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + "'";
                            coma = ",";
                        }
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE existenciaplanta.id_plantas not in(" + produccion + ")  AND   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");             
            
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun  INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
               
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
                //String guide = TxtNoGuia.Text;

                if (ChekMagueyComprado.Checked == true)
                {
                    TxtExistencia.Text = "";
                    if (CmbMaguey.DataSource != null)
                    {
                        if (chkGuiaAntigua.Checked == true)
                        {
                            string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + clienteCrm + "' AND existenciaplantas>0; ");

                       // id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + ";");//-- selecciona el predio dependiaendo de la planta seleccionada en el combo..

                       id_predio_comprado  = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  reveca2_existenciaplanta inner join reveca2_existenciaplanta_comprada on reveca2_existenciaplanta_comprada.id_planta=reveca2_existenciaplanta.id_plantas WHERE reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");

                       no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + clienteCrm + "'");
                        }
                        else
                        {
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + no_cliente + "' AND existenciaplantas>0; ");
                            id_predio_comprado = ConexionMysql.regresaCampoConsulta("SELECT id_paraje FROM  existenciaplanta inner join existenciaplanta_comprada on existenciaplanta_comprada.id_planta=existenciaplanta.id_plantas WHERE existenciaplanta_comprada.id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                            no_guia = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "' and no_cliente='" + no_cliente + "'");

                        }
                    }
                }
                else
                {
                    TxtExistencia.Text = "";
                    if (CmbMaguey.DataSource != null)
                    {
                        if (guide2.Substring(0, 1) == "g" || guide2.Substring(0, 1) == "G")
                        {
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                            //id_predio_comprado = "";
                        }
                        else
                        {
                            TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  reveca2_existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                           // id_predio_comprado = "";
                        }
                    }
                       

                    /*
                    if (CmbMaguey.DataSource != null)
                    {
                        TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta  WHERE id_plantas=" + CmbMaguey.SelectedValue + "");
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregarAgaveCocido_Click(object sender, EventArgs e)
        {

            if (ChekMagueyComprado.Checked == false)
            {

                if (TxtNoGuia.Text == "")
                {
                    MessageBox.Show("No has ingresado un numero de guia");
                    return;
                }
                /*else
                {
                    String guide = TxtNoGuia.Text;
                }*/

                if (TxtNoPredio.Text== null)
                {
                    MessageBox.Show("No ha seleccionado un predio");
                    return;
                }
                //}

                if (CmbMaguey.SelectedValue == null)
                {
                    MessageBox.Show("No ha seleccionado un maguey");
                    return;
                }
                
                if(chkGuiaAmma.Checked == true)
                {
                    if (TxtExistencia.Text == "" || TxtExistencia.Text == "0")
                    {
                        MessageBox.Show("No tienes existencia");
                        TxtExistencia.Focus();
                        return;
                    }
                }
                if (TxtExistencia.Text == "" || TxtExistencia.Text == "0")
                {
                    MessageBox.Show("No tienes existencia");
                    TxtExistencia.Focus();
                    return;
                }


                if (TxtExtraccion.Text == "")
                {
                    MessageBox.Show("No tienes no de piñas para asignar");
                    return;
                }

                if (tipo_tapada == "1")
                {
                    DataRow fila = TablaCompletar.NewRow();
                    fila["ID"] = id_produccion;
                    fila["TIPO"] = "1";
                    fila["ID_PLANTA"] = CmbMaguey.SelectedValue;
                    fila["ID_PREDIO"] = TxtNoPredio.Text;
                    fila["PLANTA"] = CmbMaguey.Text;
                    fila["EXTRACCION"] = TxtExtraccion.Text;
                    fila["NO_GUIA"] =TxtNoGuia.Text;
                    fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    TablaCompletar.Rows.Add(fila);

                    //String guide = TxtNoGuia.Text;

                    TxtCampo.Text = "";
                    TxtExtraccion.Text = "";
                    TxtExistencia.Text = "";

                    string produccion = "";
                    string coma = "";

                    for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                    {
                        produccion += coma + "'" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + "'";
                        coma = ",";
                    }

                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";
                    TxtPredioDesconocido.Text = "";

                    if (guide2.Substring(0, 1) == "g" || guide2.Substring(0, 1) == "G")
                    {
                        //MessageBox.Show(TxtNoPredio.Text);              
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE existenciaplanta.id_plantas not in(" + produccion + ")  AND   existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey"); //-- Aqui
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta.id_plantas not in(" + produccion + ")  AND   reveca2_existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  reveca2_existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                    }
                }
                //entra si es tipo tapada 2 y 4
                else
                {
                    string variable;
                    variable = CmbMagueyNoRegistrado.SelectedValue.ToString();
                    tabla_actualizacion = variable.Substring(0, 1);
                    id_actualizar_agave = variable.Substring(2);

                    DataRow fila = TablaCompletar.NewRow();
                    fila["ID"] = id_actualizar_agave;
                    fila["TIPO"] = tabla_actualizacion;
                    fila["ID_PLANTA"] = CmbMaguey.SelectedValue;
                    fila["ID_PREDIO"] = TxtNoPredio.Text;
                    fila["PLANTA"] = CmbMaguey.Text;
                    fila["EXTRACCION"] = TxtExtraccion.Text;
                    fila["NO_GUIA"] =TxtNoGuia.Text;
                    fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    TablaCompletar.Rows.Add(fila);
                    TxtExtraccion.Text = "";
                    TxtExistencia.Text = "";

                    string produccion = "";
                    string coma = "";

                    for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                    {
                        produccion += coma + "'" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + "'";
                        coma = ",";
                    }

                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";
                    TxtPredioDesconocido.Text = "";

                    if (guide2.Substring(0, 1) == "g" || guide2.Substring(0, 1) == "G")
                    {
                                      
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE existenciaplanta.id_plantas not in(" + produccion + ")  AND   existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie')' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta.id_plantas not in(" + produccion + ")  AND   reveca2_existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  reveca2_existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                    }

                    //Asignamos a la  tabla temporal para guardar las plantas no registradas
                    //DataRow fila2 = DtaAgaveCrudoSobranteEnEspera.NewRow();
                    //fila2["tipo_id"] =variable;
                    //DtaAgaveCrudoSobranteEnEspera.Rows.Add(fila2);


                    DataRow[] rows = DtaAgaveCrudoSobrante.Select("tipo_id=" + "'" + variable + "'");
                    DtaAgaveCrudoSobrante.Rows.Remove(rows[0]);
                    CmbMagueyNoRegistrado_SelectedIndexChanged(null, null);
                    //if (rows.Length > 0)
                    //{

                    //    DataRow row = rows[0];

                    //    MessageBox.Show(row["tipo_id"].ToString()) ;
                    //    DtaAgaveCrudoSobrante.Rows.Remove(rows[0]);

                    //}


                    ////DataRow[] foundRows = DtaAgaveCrudoSobrante.Select("tipo_id=" + "'" + variable + "'");

                    ////// Print column 0 of each returned row.
                    ////for (int i = 0; i < foundRows.Length; i++)
                    ////{

                    ////    MessageBox.Show(""+foundRows[i][0]);
                    ////    DtaAgaveCrudoSobrante.Rows.Remove(foundRows[i][0]);
                    ////}

                }

            }//-- Fin if(ChekMagueyComprado.Checked == false)
            else {
                                          
                if (CmbMaguey.SelectedValue == null)
                {
                    MessageBox.Show("No ha seleccionado un maguey");
                    return;
                }
                if (TxtExistencia.Text == "" && TxtExistencia.Text == "0")
                {
                    MessageBox.Show("No tienes existencia");
                    TxtExistencia.Focus();
                    return;
                }

                if (TxtExtraccion.Text == "")
                {
                    MessageBox.Show("No tienes no de piñas para asignar");
                    return;
                }

                int l= Convert.ToInt32(TxtExistencia.Text);

                //-----/--r@le-- entra sien la extraccion no son suficientes las piñas....
                if (Convert.ToInt32(TxtExtraccion.Text) > l)
                {


                    int rsl = Convert.ToInt32(TxtExtraccion.Text) - l;


                DataRow fila = TablaCompletar.NewRow();
                fila["ID"] = id_produccion;
                fila["TIPO"] = "3";
                    if (chkGuiaAntigua.Checked == false)
                    {
                        fila["ID_PLANTA"] = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }
                    else
                    { 
                        fila["ID_PLANTA"] = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }
                fila["ID_PREDIO"] = id_predio_comprado;
                fila["PLANTA"] = CmbMaguey.Text;
                fila["EXTRACCION"] = TxtExistencia.Text;//---/r@le--- toma el valor total de las piñas para realizar la resta
                                                        // fila["NO_GUIA"] = no_guia;
                    if (chkGuiaAntigua.Checked == false)
                    {
                        fila["NO_GUIA"] = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }
                    else
                    {
                        fila["NO_GUIA"] = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }

                //fila["EXTRACCION"] = TxtExtraccion.Text;
                fila["ID_PLANTA_COMPRADA"] = CmbMaguey.SelectedValue;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                TablaCompletar.Rows.Add(fila);

               // TxtCampo.Text = "";
                //TxtExtraccion.Text = "";
                //TxtExistencia.Text = "";
                TxtExtraccion.Text = Convert.ToString(rsl);


                string produccion = "";
                string coma = "";

                for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                {
                    produccion += coma + "'" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "'";
                    coma = ",";
                }

                TxtNoGuia.Text = "";
                TxtNoPredio.Text = "";
                TxtPredioDesconocido.Text = "";

                    ///--- checar para poner en ferencia a el id de la planta comprada
                    if (chkGuiaAntigua.Checked == false)
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE  existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN(" + produccion + ")  AND existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    }
                    else
                    {
                        string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta =reveca2_existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE  reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN(" + produccion + ")  AND reveca2_existenciaplanta_comprada.no_cliente='" + clienteCrm + "' AND reveca2_existenciaplanta.edad>=5 and reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    }
                }//---/ Fin del if que compara el numero de piñas

                else
                {
                    DataRow fila = TablaCompletar.NewRow();
                    fila["ID"] = id_produccion;
                    fila["TIPO"] = "3";

                    if (chkGuiaAntigua.Checked == false)
                    {
                      fila["ID_PLANTA"] = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }
                    else
                    {
                        fila["ID_PLANTA"] = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }

                    fila["ID_PREDIO"] = id_predio_comprado;
                    fila["PLANTA"] = CmbMaguey.Text;
                    fila["EXTRACCION"] = TxtExtraccion.Text;
                    // fila["NO_GUIA"] = no_guia;
                    if (chkGuiaAntigua.Checked == false)
                    {
                        fila["NO_GUIA"] = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }
                    else
                    {
                        fila["NO_GUIA"] = ConexionMysql.regresaCampoConsulta("SELECT no_guia FROM  reveca2_existenciaplanta_comprada  WHERE id_existenciaplanta_comprada='" + CmbMaguey.SelectedValue + "'");
                    }

                    fila["ID_PLANTA_COMPRADA"] = CmbMaguey.SelectedValue;
                    fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                    TablaCompletar.Rows.Add(fila);

                    TxtCampo.Text = "";
                    TxtExtraccion.Text = "";
                    TxtExistencia.Text = "";
                    TxtPredioDesconocido.Text = "";
                    


                    string produccion = "";
                    string coma = "";

                    for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                    {
                        produccion += coma + "'" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "'";
                        coma = ",";
                    }


                    TxtNoGuia.Text = "";
                    TxtNoPredio.Text = "";
                    TxtPredioDesconocido.Text = "";


                    if (chkGuiaAntigua.Checked == false)
                    {
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE  existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN(" + produccion + ")  AND existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    }
                    else
                    {
                        string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta =reveca2_existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE  reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN(" + produccion + ")  AND reveca2_existenciaplanta_comprada.no_cliente='" + clienteCrm + "' AND reveca2_existenciaplanta.edad>=5 and reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    }

                }//---/ Fin del else de la comparacion de piñas
                
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

        private void CmbMagueyNoRegistrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbMagueyNoRegistrado.SelectedValue != null)
                {
                    string variable;
                    variable = CmbMagueyNoRegistrado.SelectedValue.ToString();
                    tabla_actualizacion = variable.Substring(0, 1);
                    id_actualizar_agave = variable.Substring(2);

                    if (tabla_actualizacion == "1") 
                    {
                        TxtExtraccion.Text = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_entrada  WHERE id_produccion_entrada='" + id_actualizar_agave + "'");
                    }
                    else
                    {
                        TxtExtraccion.Text = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_ensamble  WHERE id_ensamble_union='" + id_actualizar_agave + "'");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DtaAgaveCompletarTapada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaAgaveCompletarTapada.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    string id = DtaAgaveCompletarTapada.Rows[e.RowIndex].Cells["TIPO"].Value.ToString() + "-" + DtaAgaveCompletarTapada.Rows[e.RowIndex].Cells["ID"].Value.ToString();  
                    DtaAgaveCompletarTapada.Rows.RemoveAt(e.RowIndex);
                    TablaCompletar.AcceptChanges();

                    //r@le--para maguey comprado...
                    if (ChekMagueyComprado.Checked == false)
                    {


                    if (DtaAgaveCompletarTapada.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";

                        for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + "'";
                            coma = ",";
                        }

                            if (guide2.Substring(0, 1) == "g" || guide2.Substring(0, 1) == "G")
                            {
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años  (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE existenciaplanta.id_plantas not in(" + produccion + ")  AND   existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                            }
                            //ConexionMysql.llenaCombo(ref CmbMaguey, "  SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años  (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE existenciaplanta.id_plantas not in(" + produccion + ")  AND   existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey"); 

                            else
                            {
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años  (',especie.genespecie,')' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta.id_plantas not in(" + produccion + ")  AND   reveca2_existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  reveca2_existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                            }

                    }
                    else
                        {
                            if (guide2.Substring(0, 1) == "g" || guide2.Substring(0, 1) == "G")
                            {
                                //MessageBox.Show("MEZCAL");
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                            }
                            else
                            {
                                //MessageBox.Show("TEUQILA");
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE   reveca2_existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  reveca2_existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                            }

                        //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE   existenciaplanta.id_paraje='" + TxtNoPredio.Text + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");
                        }
                   

                        if (tipo_tapada == "1")
                        {
                            TxtCampo.Visible = true;
                            CmbMagueyNoRegistrado.Enabled = false;
                            TxtExtraccion.Text = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_entrada  WHERE id_produccion_entrada='" + id_produccion + "' ");
                            TxtCampo.Text = "Especie :Planta no registrada";
                        }
                        //entra si e stipo tapada 2 y 4
                        else
                        {
                            DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                            fila["tipo_id"] = id;
                            fila["Descripcion"] = "Planta no registrada";
                            DtaAgaveCrudoSobrante.Rows.Add(fila);
                            CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);
                        }//--Fin el eslse
                    }
                    else
                    {
                        string produccion = "";
                        string coma = "";

                        if (DtaAgaveCompletarTapada.Rows.Count > 0)
                        {
                           
                            for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                            {
                                produccion += coma + "'" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "'";
                                coma = ",";
                            }
                            if (chkGuiaAntigua.Checked == false)
                            {

                             ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE  existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN(" + produccion + ")  AND existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                            }
                            else
                            {
                                string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey  FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta =reveca2_existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE  reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada NOT IN(" + produccion + ")  AND reveca2_existenciaplanta_comprada.no_cliente='" + clienteCrm + "' AND reveca2_existenciaplanta.edad>=5 and reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                            }

                        }
                        else {

                            /*ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun WHERE   existenciaplanta.id_paraje='" + CmbNoPredio.SelectedValue + "' AND edad>=5 AND  existenciaplanta.existenciaplantas > 0", "id_plantas", "Maguey");*/
                            if(chkGuiaAntigua.Checked == false)
                            {
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años  (',especie.genespecie,')' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                            }
                            
                            else
                            {
                                string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años  (',especie.genespecie,')' ) as Maguey  FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta =reveca2_existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta_comprada.no_cliente='" + clienteCrm + "' AND reveca2_existenciaplanta.edad>=5 and reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                            }
                        }

                        if (tipo_tapada == "1")
                        {
                            TxtCampo.Visible = true;
                            CmbMagueyNoRegistrado.Enabled = false;
                            //TxtExistencia.Text = ConexionMysql.regresaCampoConsulta("SELECT existenciaplantas FROM  existenciaplanta_comprada  WHERE id_planta=" + CmbMaguey.SelectedValue + " ");
                            TxtExtraccion.Text = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_entrada  WHERE id_produccion_entrada='" + id_produccion + "' ");
                            TxtCampo.Text = "Especie :Planta no registrada";

                        }

                        //entra si e stipo tapada 2 y 4
                        else
                        {
                            DataRow fila = DtaAgaveCrudoSobrante.NewRow();
                            fila["tipo_id"] = id;
                            fila["Descripcion"] = "Planta no registrada";
                            DtaAgaveCrudoSobrante.Rows.Add(fila);
                            CmbMagueyNoRegistrado_SelectedIndexChanged(sender, e);
                        }
                        


                    }//---else-*

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //-------------/
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(chkGuiaAmma.Checked == true)
            {
                if (DtaAgaveCompletarTapada.RowCount == 0)
                {
                    MessageBox.Show("No ha realizado ninguna asignacion");

                    return;
                }
            //}
            //lo comento para agregar validacion dependiendo de la selección de tipo de guía 04-11-2021
            /*if (DtaAgaveCompletarTapada.RowCount == 0)
            {
                MessageBox.Show("No ha realizado ninguna asignacion");

                return;
            }*/
            
             DialogResult check = MessageBox.Show("¿Guardar cambios?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

             if (check == DialogResult.Cancel) { return; }

             else
             {

                 if (ChekMagueyComprado.Checked == false)
                 {
                    #region

                    /* checar esta parte del codigo en casoa de que sea un ensamble por el tipo de produccion hacer la validacion -- */

                    /* if (DtaAgaveCompletarTapada.Rows.Count > 1)
                     {
                         

                         for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                         {
                             //SI ES TIPO 1 EMPEZAMOS EN LA TABLA PRODUCCION ENTRADA
                             if (DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() == "1" || DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() == "2" || DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() == "3")
                             {
                             //--*Actualiza la produccion de a tipo 1
                             if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET no_pinas_agave=0,tipo=" + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() + ",actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "';") == "Error")
                             {
                                 return;
                             }


                             /*  //==Actualiza existencia planta comprada
                               if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value + ",actualizado=0  WHERE id_planta =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + " and no_cliente='" + no_cliente + "';") == "Error")
                               {
                                   return;
                               }//--Fin planta comprada

                               

                             //
                             //---r@le--- ingresa los registros para hacer una union/ensamble...
                             //
                             ObtenerIdMaximoProduccionEnsamble();

                             if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_ensamble(id_produccion_entrada,id_ensamble_union,id_predio,id_planta,no_guia,no_pinas_agave,tipo,id_verificador,actualizado) VALUES('" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "','" + id_max_produccion_ensamble_union + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value + "," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + ",'" + DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value + "," + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value + "," + Usuario.IdUsuario + ",0)") == "Error")
                             {
                                 return;
                             }


                             //actualiza las plantas
                             if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + "  WHERE id_plantas =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "") == "Error")
                             {
                                 return;
                             }

                             DateTime local = DateTime.Now;
                             string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");
                             if (ConexionMysql.insUpd_transaccion("INSERT INTO retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES( 0," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",'" + no_cliente + "','" + no_cliente + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                             {
                                 return;
                             }
                             if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( 0," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "')") == "Error")
                             {
                                 return;
                             }

                         }//-- fin del for
                             } 


                     }
                     else
                     { */
                    #endregion
                    if (guide2.Substring(0, 1) == "g" || guide2.Substring(0, 1) == "G")
                    { 
                    for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                         {
                             //SI ES TIPO 1 EMPEZAMOS EN LA TABLA PRODUCCION ENTRADA
                             if (DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() == "1")
                             {


                                    //EDITAMOS EL PREDIO Y PLANTA EN PRODUCCION
                                   // MessageBox.Show(Convert.ToString("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",no_guia='" + DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() + "',actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "'"));
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",no_guia='" + DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() + "',actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "'") == "Error")
                                 {
                                        // MessageBox.Show(Convert.ToString("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",no_guia='" + DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() + "',actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "'"));
                                        //MessageBox.Show("xd");
                                        return;
                                 }

                                 string id_agave_sobrante;
                                 string id_agave_cocido_sobrante;

                                 //buscamos si hay agave sobrante crudo
                                 id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                 if (id_agave_sobrante != "")
                                 {
                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }

                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }

                                     string id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_entrada  WHERE id_agave_sobrante='" + id_agave_sobrante + "' ");
                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_produccion_entrada='" + id_produccion_entrada + "'") == "Error")
                                     {
                                         return;
                                     }


                                     id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                     if (id_agave_sobrante != "")
                                     {
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                     }


                                     id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                     if (id_agave_cocido_sobrante != "")
                                     {
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                     }

                                 }


                                 //buscamos si hay agave sobrante cocido
                                 id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                 if (id_agave_cocido_sobrante != "")
                                 {
                                        //here error
                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }
                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }
                                 }

                                 //actualiza las plantas
                                 if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + "  WHERE id_plantas =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "") == "Error")
                                 {
                                     return;
                                 }

                                 DateTime local = DateTime.Now;
                                 string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");
                                 if (ConexionMysql.insUpd_transaccion("INSERT INTO retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES('" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",'" + cliente_envia + "','" + no_cliente + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                                 {
                                     return;
                                 }
                                 if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( '" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "')") == "Error")
                                 {
                                     return;
                                 }

                                    //Se agrega porque no actualizaba el status de las guias en cextracciones
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  cextracciones SET status=0  WHERE id_extraccion ='" + guide2 + "'") == "Error")
                                    {
                                        return;
                                    }
                   
                                }

                             //-------------------------------------------------------------FIN UNA SOLA PLANTA------------------------------------------
                             //SI ES TIPO 2 EMPEZAMOS EN PPRODUCCION ENSAMBLE
                             else
                             {

                                 //EDITAMOS EL PREDIO Y PLANTA EN PRODUCCION ENSAMBLE
                                 if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0 WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "'") == "Error")
                                 {
                                     return;
                                 }

                                 string id_agave_sobrante;
                                 string id_agave_cocido_sobrante;

                                 //buscamos si hay agave sobrante crudo con id ensamble union
                                 id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");

                                 if (id_agave_sobrante != "")
                                 {
                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='',id_ensamble_union='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }

                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }

                                     string id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_entrada  WHERE id_agave_sobrante='" + id_agave_sobrante + "' ");

                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_produccion_entrada='" + id_produccion_entrada + "'") == "Error")
                                     {
                                         return;
                                     }


                                     id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                     if (id_agave_sobrante != "")
                                     {
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                     }


                                     id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                     if (id_agave_cocido_sobrante != "")
                                     {
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }
                                     }

                                 }
                                 //buscamos si hay agave sobrante crudo con id produccion
                                 else
                                 {
                                     string id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_ensamble  WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                     id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");

                                     if (id_agave_sobrante != "")
                                     {
                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='',id_ensamble_union='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }

                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                         {
                                             return;
                                         }

                                         id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_entrada  WHERE id_agave_sobrante='" + id_agave_sobrante + "' ");

                                         if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_produccion_entrada='" + id_produccion_entrada + "'") == "Error")
                                         {
                                             return;
                                         }


                                         id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                         if (id_agave_sobrante != "")
                                         {
                                             if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                             {
                                                 return;
                                             }
                                             if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                             {
                                                 return;
                                             }
                                         }


                                         id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                         if (id_agave_cocido_sobrante != "")
                                         {
                                             if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                             {
                                                 return;
                                             }
                                             if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                             {
                                                 return;
                                             }
                                         }
                                     }


                                 }

                                 //buscamos si hay agave sobrante cocido
                                 id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                 if (id_agave_cocido_sobrante != "")
                                 {
                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='',id_ensamble_union='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }
                                     if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                     {
                                         return;
                                     }
                                 }

                                 //actualiza las plantas
                                 if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + "  WHERE id_plantas =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "") == "Error")
                                 {
                                     return;
                                 }

                                 DateTime local = DateTime.Now;
                                 string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");
                                 if (ConexionMysql.insUpd_transaccion("INSERT INTO retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES( 0," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",'" + cliente_envia + "','" + no_cliente + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                                 {
                                     return;
                                 }
                                 if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( 0," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "')") == "Error")
                                 {
                                     return;
                                 }

                                    //Se agrega porque no actualizaba el status de las guias en cextracciones
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  cextracciones SET status=0  WHERE id_extraccion ='" + guide2 + "'") == "Error")
                                    {
                                        return;
                                    }

                                }//-- fin de produccion tipo 2 

                         } //======== Fin del for
                }// fin de guía nueva amma
                    else
                    {
                        string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                        for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                        {
                            //SI ES TIPO 1 EMPEZAMOS EN LA TABLA PRODUCCION ENTRADA
                            if (DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() == "1")
                            {


                                //EDITAMOS EL PREDIO Y PLANTA EN PRODUCCION
                                if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",no_guia='" + DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() + "',actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "'") == "Error")
                                {
                                    return;
                                }
                                string id_agave_sobrante;
                                string id_agave_cocido_sobrante;

                                //buscamos si hay agave sobrante crudo
                                id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                if (id_agave_sobrante != "")
                                {
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }

                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }

                                    string id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_entrada  WHERE id_agave_sobrante='" + id_agave_sobrante + "' ");
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_produccion_entrada='" + id_produccion_entrada + "'") == "Error")
                                    {
                                        return;
                                    }


                                    id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                    if (id_agave_sobrante != "")
                                    {
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                    }


                                    id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                    if (id_agave_cocido_sobrante != "")
                                    {
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + ",id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                    }

                                }


                                //buscamos si hay agave sobrante cocido
                                id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                if (id_agave_cocido_sobrante != "")
                                {
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + ",id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }
                                }

                                //actualiza las plantas
                                if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + "  WHERE id_plantas =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "") == "Error")
                                {
                                    return;
                                }

                                DateTime local = DateTime.Now;
                                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO reveca2_retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES('" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",'" + no_cliente + "','" + no_cliente + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  reveca2_actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( '" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "')") == "Error")
                                {
                                    return;
                                }


                            }

                            //-------------------------------------------------------------FIN UNA SOLA PLANTA
                            //SI ES TIPO 2 EMPEZAMOS EN PPRODUCCION ENSAMBLE
                            else
                            {

                                //EDITAMOS EL PREDIO Y PLANTA EN PRODUCCION ENSAMBLE
                                if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0 WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "'") == "Error")
                                {
                                    return;
                                }

                                string id_agave_sobrante;
                                string id_agave_cocido_sobrante;

                                //buscamos si hay agave sobrante crudo con id ensamble union
                                id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");

                                if (id_agave_sobrante != "")
                                {
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='',id_ensamble_union='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }

                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }

                                    string id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_entrada  WHERE id_agave_sobrante='" + id_agave_sobrante + "' ");

                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_produccion_entrada='" + id_produccion_entrada + "'") == "Error")
                                    {
                                        return;
                                    }


                                    id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                    if (id_agave_sobrante != "")
                                    {
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                    }


                                    id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                    if (id_agave_cocido_sobrante != "")
                                    {
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + ",id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }
                                    }

                                }
                                //buscamos si hay agave sobrante crudo con id produccion
                                else
                                {
                                    string id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_ensamble  WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                    id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");

                                    if (id_agave_sobrante != "")
                                    {
                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='',id_ensamble_union='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }

                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                        {
                                            return;
                                        }

                                        id_produccion_entrada = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_entrada  WHERE id_agave_sobrante='" + id_agave_sobrante + "' ");

                                        if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_produccion_entrada='" + id_produccion_entrada + "'") == "Error")
                                        {
                                            return;
                                        }


                                        id_agave_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_agave_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                        if (id_agave_sobrante != "")
                                        {
                                            if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_sobrante SET id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                            {
                                                return;
                                            }
                                            if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_sobrante='' WHERE id_agave_sobrante='" + id_agave_sobrante + "'") == "Error")
                                            {
                                                return;
                                            }
                                        }


                                        id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_produccion_entrada='" + id_produccion_entrada + "' ");
                                        if (id_agave_cocido_sobrante != "")
                                        {
                                            if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + ",id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                            {
                                                return;
                                            }
                                            if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                            {
                                                return;
                                            }
                                        }
                                    }


                                }

                                //buscamos si hay agave sobrante cocido
                                id_agave_cocido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_agave_cocido_sobrante FROM  produccion_agave_cocido_sobrante  WHERE id_ensamble_union='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "' ");
                                if (id_agave_cocido_sobrante != "")
                                {
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_agave_cocido_sobrante SET id_predio=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + ",id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_produccion_entrada='',id_ensamble_union='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_ensamble SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",actualizado=0,id_agave_cocido_sobrante='' WHERE id_agave_cocido_sobrante='" + id_agave_cocido_sobrante + "'") == "Error")
                                    {
                                        return;
                                    }
                                }

                                //actualiza las plantas
                                if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + "  WHERE id_plantas =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "") == "Error")
                                {
                                    return;
                                }

                                DateTime local = DateTime.Now;
                                string fecha = local.ToString("yyyy-MM-dd HH:mm:ss");
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO reveca2_retiro_plantas_pendientes (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,fecha,actualizado,direccion_cliente_recibe,id_verificador) VALUES( 0," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",'" + no_cliente + "','" + no_cliente + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "',0,'Mismo productor'," + Usuario.IdUsuario + ")") == "Error")
                                {
                                    return;
                                }
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO  reveca2_actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( 0," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + "," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",'" + fecha + "')") == "Error")
                                {
                                    return;
                                }

                            }//-- fin de produccion tipo 2 

                        }
                    }//fin si usa guia vieja

                // --  }///=== fin de else referente a que no e sun ensamble
            }//--- Fin if del checket Maguey comprado
                 //------------------------------------------------------------------------------------HASTA AQUÍ ES PRODUCCIÓN NORMAL SIN MAGUEY COMPRADO
                 else
                 {
                    //--- Produccion tipo 3

                    if (chkGuiaAntigua.Checked== false)
                    {

                    
                     //--r@le--- si el datagridview tiene mas de dos plantas entra --//
                     if (DtaAgaveCompletarTapada.Rows.Count > 1)
                     {
                         for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                         {

                             //--*Actualiza la produccion de a tipo 3
                             if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET no_pinas_agave=0, tipo=" + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() + ",actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "';") == "Error")
                             {
                                 return;
                             }

                                   // string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                                    //==Actualiza existencia planta comprada
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value + ",actualizado=0  WHERE id_planta =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + " and no_cliente='" + no_cliente + "' AND id_existenciaplanta_comprada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "';") == "Error")
                             {
                                 return;
                             }//--Fin planta comprada



                                    //
                                    //---r@le--- ingresa los registros para hacer una union/ensamble...
                                    //
                                    ObtenerIdMaximoProduccionEnsamble();//This line was missing and that is why the id_assembly was not generated.
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_ensamble(id_produccion_entrada,id_ensamble_union,id_predio,id_planta,no_guia,no_pinas_agave,tipo,id_verificador,actualizado) VALUES('" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "','" + id_max_produccion_ensamble_union + "','" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + ",'" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value + "," + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value + "," + Usuario.IdUsuario + ",0)") == "Error")
                             {
                                 return;
                             }



                         }//-- fin del for

                     }
                     else
                     {
                         for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                         {

                             //EDITAMOS EL PREDIO Y PLANTA EN PRODUCCION ENSAMBLE

                            

                             if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",no_guia='" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "',tipo=" + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() + ",actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "';") == "Error")
                             {
                                 return;
                             }
                                                          
                             //==Actualiza existencia planta comprada
                             if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",actualizado=0  WHERE id_planta =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + " and no_cliente='" + no_cliente + "' AND id_existenciaplanta_comprada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "'") == "Error")
  
                             {
                                 return;
                             }//--Fin planta comprada

                             
                         }//-- fin del for

                     }//-- fin del eslse
                    }
                    else
                    {
                        if (DtaAgaveCompletarTapada.Rows.Count > 1)
                        {
                            for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                            {

                                //--*Actualiza la produccion de a tipo 3
                                if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET no_pinas_agave=0, tipo=" + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() + ",actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "';") == "Error")
                                {
                                    return;
                                }

                                    string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                                    //==Actualiza existencia planta comprada
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value + ",actualizado=0  WHERE id_planta =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + " and no_cliente='" + clienteCrm + "' AND id_existenciaplanta_comprada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "';") == "Error")
                                {
                                    return;
                                }//--Fin planta comprada


                                    //---r@le--- ingresa los registros para hacer una union/ensamble...
                                    ObtenerIdMaximoProduccionEnsamble();//this line was not and that is why the id_assembly was not generated

                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_ensamble(id_produccion_entrada,id_ensamble_union,id_predio,id_planta,no_guia,no_pinas_agave,tipo,id_verificador,actualizado) VALUES('" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "','" + id_max_produccion_ensamble_union + "','" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + ",'" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "'," + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value + "," + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value + "," + Usuario.IdUsuario + ",0)") == "Error")
                                {
                                    return;
                                }

                            }//-- fin del for

                        }
                        else
                        {
                            for (int x = 0; x < DtaAgaveCompletarTapada.Rows.Count; x++)
                            {

                                //EDITAMOS EL PREDIO Y PLANTA EN PRODUCCION ENSAMBLE



                                if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET id_predio='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PREDIO"].Value.ToString() + "',id_planta=" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value.ToString() + ",no_guia='" + (DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString() == "" ? "0" : DtaAgaveCompletarTapada.Rows[x].Cells["NO_GUIA"].Value.ToString()) + "',tipo=" + DtaAgaveCompletarTapada.Rows[x].Cells["TIPO"].Value.ToString() + ",actualizado=0 WHERE id_produccion_entrada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID"].Value.ToString() + "';") == "Error")
                                {
                                    return;
                                }

                                    string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                                    //==Actualiza existencia planta comprada
                                    if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta_comprada SET existenciaplantas=existenciaplantas-" + DtaAgaveCompletarTapada.Rows[x].Cells["EXTRACCION"].Value.ToString() + ",actualizado=0  WHERE id_planta =" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA"].Value + " and no_cliente='" + clienteCrm + "' AND id_existenciaplanta_comprada='" + DtaAgaveCompletarTapada.Rows[x].Cells["ID_PLANTA_COMPRADA"].Value + "'") == "Error")

                                {
                                    return;
                                }//--Fin planta comprada


                            }//-- fin del for

                        }//-- fin del eslse
                    }

                }
                


                 ConexionMysql.transCompleta();
                 MessageBox.Show("Éxito");
                 this.Close();
                 

             }//---> fin else Dialog
              //ConexionMysql.transCompleta();
              //MessageBox.Show("Éxito");
              //this.Close();
            }//fin del if para saber si es guia normal amma

            else
                if (chkGuiaCrm.Checked == true)
            {

                /*
                 1-produccion normal 2-ensamble 3-comprado 4-sobrante 
                 */
                DialogResult check = MessageBox.Show("¿Estás seguro de guardar cambios?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (check == DialogResult.Cancel) 
                { 
                    return; 
                }

                else
                {

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
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Éxito");
                this.Close();
            }
        } //===== Fin de la funcion guardar

        private void ChekMagueyComprado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekMagueyComprado.Checked == true)
            {
                CmbNoPredio.Enabled = false;
                CmbNoPredio.DataSource = null;
                TxtNoPredio.Enabled = false;
                TxtNoGuia.Enabled = false;
                TxtNoPredio.Text = "";
                TxtNoGuia.Text = "";
                TxtPredioDesconocido.Text = "";
                CmbMaguey.DataSource = null;

                if (chkGuiaAntigua.Checked == true)
                {
                    // ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas WHERE   existenciaplanta_comprada.no_cliente='" + CmbNoCliente.SelectedValue + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    string clienteCrm = ConexionMysql.regresaCampoConsulta("SELECT cliente_antiguo FROM clientes WHERE no_cliente ='" + no_cliente + "'");
                    //ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta, CONCAT(comun.nombre,'  ',existenciaplanta.edad,  '  años (', especie.genespecie,')') AS Maguey FROM existenciaplanta INNER JOIN comun ON existenciaplanta.id_comun = comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta = existenciaplanta.id_plantas inner join especie on comun.id_especie=especie.id_especie WHERE  existenciaplanta_comprada.no_cliente = '" + CmbNoCliente.SelectedValue + "' AND existenciaplanta.edad >= 5 AND existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta, CONCAT(comun.nombre,'  ',reveca2_existenciaplanta.edad,  '  años (', especie.genespecie,')') AS Maguey FROM reveca2_existenciaplanta INNER JOIN comun ON reveca2_existenciaplanta.id_comun = comun.id_comun INNER JOIN reveca2_existenciaplanta_comprada ON reveca2_existenciaplanta_comprada.id_planta = reveca2_existenciaplanta.id_plantas inner join especie on comun.id_especie=especie.id_especie WHERE  reveca2_existenciaplanta_comprada.no_cliente = '" + clienteCrm + "' AND reveca2_existenciaplanta.edad >= 5 AND reveca2_existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                }

                else
                {
                                    
                ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta_comprada.id_existenciaplanta_comprada as id_planta,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años  (',especie.genespecie,')' ) as Maguey  FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN existenciaplanta_comprada ON existenciaplanta_comprada.id_planta =existenciaplanta.id_plantas INNER JOIN especie ON comun.id_especie=especie.id_especie WHERE   existenciaplanta_comprada.no_cliente='" + no_cliente + "' AND existenciaplanta.edad>=5 and existenciaplanta_comprada.existenciaplantas > 0 ", "id_planta", "Maguey");
                }
            }
            else
            {
                CmbMaguey.DataSource = null;
                CmbNoPredio.Enabled = true;
                TxtNoPredio.Enabled = true;
                TxtNoGuia.Enabled = true;
                TxtNoPredio.Text = "";
                TxtNoGuia.Text = "";
                //ConexionMysql.llenaCombo(ref CmbNoPredio, "SELECT id_paraje FROM paraje where id_cliente='" + no_cliente + "' ", "id_paraje", "id_paraje");
                /*-- deshabilitado por agregar el campo de numero de guia -- */
               // ConexionMysql.llenaCombo(ref CmbNoPredio, "select p.id_paraje id_paraje from paraje p INNER JOIN existenciaplanta ep ON p.id_paraje=ep.id_paraje where id_cliente='" + no_cliente + "' and ep.existenciaplantas > 0 and ep.edad >4 group by p.id_paraje ", "id_paraje", "id_paraje"); 
            }
        }

        private void TxtNoGuia_KeyPress(object sender, KeyPressEventArgs e)
        {
           // valida.soloNumeros(e);
        }

        private void TxtNoGuia_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (TxtNoGuia.Text == "")
                    {
                       
                        TxtPredioDesconocido.Text = "";
                        TxtExistencia.Text = "";
                        TxtNoPredio.Text = "";
                        TxtPredioDesconocido.Text = "";
                        CmbMaguey.DataSource = null;


                        return;
                    }

                    #region CODIGO COMO ESTABA ANTES DE ACEPTAR GUIAS ANTIGUAS CRM
                    /*
                    DataSet DatosMaguey = new DataSet();
                    ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=1 and  cextracciones.id_extraccion = '" + TxtNoGuia.Text.Trim() + "'");
                    if (DatosMaguey.Tables[0].Rows.Count == 0)
                    {
                        // + los valores de de status son:
                        // * 0 - ya utilizada
                       //  * 1 - no utilizada
                        // 
                        string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT paraje.id_paraje,paraje.paraje,paraje.id_cliente,paraje.nombrep FROM cextracciones  INNER JOIN paraje ON cextracciones.id_paraje=paraje.id_paraje  where cextracciones.status=0 and  cextracciones.id_extraccion = '" + TxtNoGuia.Text.Trim() + "'");

                        if (guia_utilizada == "") { MessageBox.Show("Guia inexistente"); } else { MessageBox.Show("Guia ya utilizada"); };

                        
                        TxtNoPredio.Text = "";
                        TxtPredio.Text = "";
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                        
                        return;
                    }
                    TxtNoPredio.Text = DatosMaguey.Tables[0].Rows[0]["id_paraje"].ToString();
                    TxtPredio.Text = DatosMaguey.Tables[0].Rows[0]["paraje"].ToString();
                    DatosMaguey.Tables[0].Rows.Clear();
                    CmbMaguey.DataSource = null;
                    TxtExistencia.Text = "";
                    ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                   */
                    #endregion

                    else
                    {
                        #region GuiasAMMA
                        if(chkGuiaAmma.Checked == true)
                        {
                                                    
                        guide2 = TxtNoGuia.Text;
                            TxtNoPredio.Enabled = true;
                            CmbMaguey.Enabled = true;
                            TxtExistencia.Enabled = true;
                            ChekMagueyComprado.Enabled = true;
                            chkGuiaAntigua.Enabled = true;
                            TxtPredioDesconocido.Enabled = true;
                            txtPredioCrm.Enabled = false;
                            cmbEspecieMaguey.Enabled = false;
                            BtnAgregarAgaveCocido.Enabled = true;

                            if (TxtNoGuia.Text.Substring(0, 1) == "g" || TxtNoGuia.Text.Substring(0, 1) == "G")
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
                                    TxtPredioDesconocido.Text = "";
                                    CmbMaguey.DataSource = null;
                                    TxtExistencia.Text = "";
                                    //TxtExtraccion.Text = "";
                                    // TxtDireccion.Text = "";
                                    // dts.Tables["EXTRACCION"].Rows.Clear();
                                    return;
                                }
                                TxtNoPredio.Text = DatosMaguey.Tables[0].Rows[0]["id_paraje"].ToString();
                                // TxtNoCliente.Text = DatosMaguey.Tables[0].Rows[0]["id_cliente"].ToString();
                                //TxtNombre.Text = DatosMaguey.Tables[0].Rows[0]["nombrep"].ToString();
                                TxtPredioDesconocido.Text = DatosMaguey.Tables[0].Rows[0]["paraje"].ToString();
                                cliente_envia = DatosMaguey.Tables[0].Rows[0]["id_cliente"].ToString();
                        DatosMaguey.Tables[0].Rows.Clear();
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                       // TxtExtraccion.Text = "";
                        //  ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + TxtNoPredio.Text.Trim() + "' AND edad>=5", "id_plantas", "Maguey");
                    }

                    else
                    {
                        //MessageBox.Show("SIN G");
                        DataSet DatosMaguey = new DataSet();
                        ConexionMysql.llenaDataset(ref DatosMaguey, "SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=1 and  reveca2_cextracciones.id_extraccion =" + TxtNoGuia.Text.Trim() + "");
                        //MessageBox.Show(DatosMaguey.Tables[2].ToString());
                        if (DatosMaguey.Tables[0].Rows.Count == 0)
                        {
                            /* + los valores de de status son:
                             * 0 - ya utilizada
                             * 1 - no utilizada
                             */
                            string guia_utilizada = ConexionMysql.regresaCampoConsulta("SELECT reveca2_paraje.id_paraje,reveca2_paraje.paraje,reveca2_paraje.id_cliente,reveca2_paraje.nombrep FROM reveca2_cextracciones  INNER JOIN reveca2_paraje ON reveca2_cextracciones.id_paraje=reveca2_paraje.id_paraje  where reveca2_cextracciones.status=0 and  reveca2_cextracciones.id_extraccion =" + TxtNoGuia.Text.Trim() + "");

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
                            TxtPredioDesconocido.Text = "";
                            CmbMaguey.DataSource = null;
                            TxtExistencia.Text = "";
                            //TxtExtraccion.Text = "";
                            // TxtDireccion.Text = "";
                            // dts.Tables["EXTRACCION"].Rows.Clear();
                            return;
                        }
                        TxtNoPredio.Text = DatosMaguey.Tables[0].Rows[0]["id_paraje"].ToString();
                        // TxtNoCliente.Text = DatosMaguey.Tables[0].Rows[0]["id_cliente"].ToString();
                        //TxtNombre.Text = DatosMaguey.Tables[0].Rows[0]["nombrep"].ToString();
                        TxtPredioDesconocido.Text = DatosMaguey.Tables[0].Rows[0]["paraje"].ToString();
                        DatosMaguey.Tables[0].Rows.Clear();
                        CmbMaguey.DataSource = null;
                        TxtExistencia.Text = "";
                       // TxtExtraccion.Text = "";
                        //  ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  existenciaplanta INNER JOIN comun  ON existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                        ConexionMysql.llenaCombo(ref CmbMaguey, "SELECT reveca2_existenciaplanta.id_plantas,CONCAT(comun.nombre, '  ', reveca2_existenciaplanta.edad,'  años (',especie.genespecie,')' ) as Maguey      FROM  reveca2_existenciaplanta INNER JOIN comun  ON reveca2_existenciaplanta.id_comun=comun.id_comun INNER JOIN especie on comun.id_especie=especie.id_especie WHERE reveca2_existenciaplanta.id_paraje='" + int.Parse(TxtNoPredio.Text.Trim()) + "' AND edad>=5", "id_plantas", "Maguey");
                    }

                    }//here
                        #endregion FinGuiasAMMA

                        else
                            if(chkGuiaCrm.Checked == true)
                            {

                           
                            
                            string guia_utilizada_crm = ConexionMysql.regresaCampoConsulta("SELECT no_guia, id_produccion_entrada FROM guias_desconocidas where no_guia like '" + TxtNoGuia.Text.Trim() + "'");

                            if (guia_utilizada_crm == "")
                            {
                                //MessageBox.Show("La guía no ha sido ocupada, puedes continuar");
                                TxtNoPredio.Enabled = false;
                                CmbMaguey.Enabled = false;
                                TxtExistencia.Enabled = false;
                                ChekMagueyComprado.Enabled = false;
                                chkGuiaAntigua.Enabled = false;
                                TxtPredioDesconocido.Enabled = false;
                                txtPredioCrm.Enabled = true;
                                cmbEspecieMaguey.Enabled = true;
                                BtnAgregarAgaveCocido.Enabled = false;
                                //DtaAgaveCompletarTapada.Enabled = false;
                                ConexionMysql.llenaCombo(ref cmbEspecieMaguey, " SELECT id_comun,CONCAT (comun.nombre,' (',especie.genespecie,')') as nombre FROM comun INNER JOIN especie ON especie.id_especie=comun.id_especie WHERE comun.status=1 ORDER BY comun.nombre ASC", "id_comun", "nombre");
                                //fila["ID_COMUN"] = CmbMaguey.SelectedValue.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Guia ya utilizada, por favor verifica la información con el responsable");
                            };

                            /*TxtNoPredio.Enabled = false;
                            CmbMaguey.Enabled = false;
                            TxtExistencia.Enabled = false;
                            ChekMagueyComprado.Enabled = false;
                            chkGuiaAntigua.Enabled = false;
                            TxtPredioDesconocido.Enabled = false;
                            txtPredioCrm.Enabled = true;
                            cmbEspecieMaguey.Enabled = true;
                            BtnAgregarAgaveCocido.Enabled = false;
                            //DtaAgaveCompletarTapada.Enabled = false;
                            ConexionMysql.llenaCombo(ref cmbEspecieMaguey, " SELECT id_comun,CONCAT (comun.nombre,' (',especie.genespecie,')') as nombre FROM comun INNER JOIN especie ON especie.id_especie=comun.id_especie WHERE comun.status=1 ORDER BY comun.nombre ASC", "id_comun", "nombre");
                            //fila["ID_COMUN"] = CmbMaguey.SelectedValue.ToString();*/
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
