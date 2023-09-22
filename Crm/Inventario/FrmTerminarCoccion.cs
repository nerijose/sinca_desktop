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
    public partial class FrmTerminarCoccion : Form
    {

        public FrmTerminarCoccion()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();
        public string id_produccion = "";
        public string fecha_fin_coccion = "";
        public string fecha_inicio_coccion = "";
        public string fecha_inicio_molienda = "";
        public string tapada = "";
        public string art = "";
        public string tipo_produccion = "";
        public string no_cliente = "";
        string agave_coccido = "";
        string art_agave_coccido = "";
        string agave_coccido_sobrante = "";
        string art_agave_coccido_sobrante = "";
        string   id_predio_agave_coccido_sobrante = "";
        string id_planta_agave_coccido_sobrante = "";
        string id_agave_sobrante = "";
        string id_max_agave_sobrante_cocido;
        string id_max_produccion_ensamble_union;
        
        DataSet dtsAgaveCocido;
        DataSet dtsAgaveCocidoSobrante;





        public void ObtenerIdMaximoAgaveSobranteCocido()
        {
            id_max_agave_sobrante_cocido = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_agave_cocido_sobrante,4)) )  FROM produccion_agave_cocido_sobrante where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_agave_sobrante_cocido == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_agave_sobrante_cocido = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_agave_sobrante_cocido = Usuario.IdUsuario + "-1";
                } 
            }
            else
            {
                int suma = int.Parse(id_max_agave_sobrante_cocido) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_agave_sobrante_cocido = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_agave_sobrante_cocido = Usuario.IdUsuario + "-" + suma;
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

        private void FrmTerminarCoccion_Load(object sender, EventArgs e)
        {
            addTablaAgaveCocido();
            addTablaAgaveCocidoSobrante();

            if (tipo_produccion == "2")
            {
                ConexionMysql.llenaCombo(ref CmbAgaveCocido, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_coccion_kg ) As produccion, id_produccion_entrada ,id_ensamble  FROM produccion_ensamble  left join existenciaplanta on produccion_ensamble.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun   where id_produccion_entrada='" + id_produccion + "' ", "id_ensamble", "produccion");         
            }
            else
            {
                ConexionMysql.llenaCombo(ref CmbAgaveCocido, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_coccion_kg ) As produccion, id_produccion_entrada   FROM produccion_entrada  left join existenciaplanta on produccion_entrada.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun  where id_produccion_entrada='" + id_produccion + "' ", "id_produccion_entrada", "produccion");
            }

            ConexionMysql.llenaCombo(ref CmbAgaveCocidoSobrante, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_cocido_kg ) As produccion,id_agave_cocido_sobrante   FROM produccion_agave_cocido_sobrante  left join existenciaplanta on produccion_agave_cocido_sobrante.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun  where produccion_agave_cocido_sobrante.no_cliente='" + no_cliente + "'", "id_agave_cocido_sobrante", "produccion");
           

            ChekCoccion.Checked = true;

            if (tapada != "")
            {
                TxtTapada.Text = tapada;
                TxtTapada.Enabled = false;
            }

            if (art != "0")
            {
                TxtArt.Text = art;
                TxtArt.Enabled = false;
            }

            if (fecha_fin_coccion != "00/00/0000" && fecha_inicio_molienda=="00/00/0000" ) 
            {
                DateTime fecha_fin = Convert.ToDateTime(fecha_fin_coccion);
                DataTimeFinalCoccion.Value = fecha_fin;
                ChekMolienda.Checked = true;
                DataTimeFinalCoccion.Enabled = false;
                ChekCoccion.Checked = false;
                ChekCoccion.Enabled = false;
                ConexionMysql.llenaCombo(ref CmbMolienda, "SELECT id_molienda,molienda FROM cat_molienda", "id_molienda", "molienda");
            }

            else if (fecha_fin_coccion == "00/00/0000" && fecha_inicio_molienda != "00/00/0000")
            {
                DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_molienda);
                DataTimeInicioMolienda.Value = fecha_inicio;
                DataTimeInicioMolienda.Enabled = false;
                ChekMolienda.Enabled = false;
                CmbMolienda.Enabled = false;             
            }
            else
            {
                DataTimeInicioMolienda.Enabled = false;
                CmbMolienda.Enabled = false;
            }     
        }

        //al marcar chekbox determina que poner disponible 
        private void ChekMolienda_Click(object sender, EventArgs e)
        {
            try
            {
                if(ChekMolienda.Checked==true)
                {
                    if(fecha_fin_coccion == "00/00/0000")
                    {
                        MessageBox.Show("No puedes iniciar la molienda sin haber concluido la cocción", "Alerta!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DataTimeInicioMolienda.Enabled = false;
                        CmbMolienda.Enabled = false;
                        CmbMolienda.DataSource = null;
                        ChekMolienda.Checked = false;
                    }
                    else
                    {
                        DataTimeInicioMolienda.Enabled = true;
                        CmbMolienda.Enabled = true;
                        ConexionMysql.llenaCombo(ref CmbMolienda, "SELECT id_molienda,molienda FROM cat_molienda", "id_molienda", "molienda");
                    }

                }
                else
                {
                    DataTimeInicioMolienda.Enabled = false;
                    CmbMolienda.Enabled = false;
                    CmbMolienda.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //guarda la terminacion de coccion o inicia molienda sea cual se el caso
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtArt.Text == ".")
                {
                    MessageBox.Show("Introduce un valor ART real");
                    return;
                }
                if (TxtArt.Text == "")
                {
                    TxtArt.Text = "0";
                }

            

                //si hay agave para disminuir molienda
                if (DtaAgaveCocido.RowCount > 0)
                {
                    string id_predio = "";
                    string id_planta = "";
                    string id = "";
                    string maguey = "";
                    double maguey_sobrante = 0;
                    string id_ensamble_union = "";



                    if (tipo_produccion == "2")
                    {
                        for (int x = 0; x < DtaAgaveCocido.Rows.Count; x++)
                        {
                            id_predio = ConexionMysql.regresaCampoConsulta("SELECT id_predio FROM  produccion_ensamble WHERE id_ensamble=" + DtaAgaveCocido.Rows[x].Cells["ID"].Value + "");
                            id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_ensamble WHERE id_ensamble=" + DtaAgaveCocido.Rows[x].Cells["ID"].Value + "");
                            maguey =ConexionMysql.regresaCampoConsulta("SELECT agave_coccion_kg FROM  produccion_ensamble WHERE id_ensamble=" + DtaAgaveCocido.Rows[x].Cells["ID"].Value + "");
                            id = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada FROM  produccion_ensamble WHERE id_ensamble=" + DtaAgaveCocido.Rows[x].Cells["ID"].Value + "");
                            id_ensamble_union = ConexionMysql.regresaCampoConsulta("SELECT id_ensamble_union FROM  produccion_ensamble WHERE id_ensamble=" + DtaAgaveCocido.Rows[x].Cells["ID"].Value + "");

                            maguey_sobrante = Math.Round(double.Parse(maguey), 2) - Math.Round(double.Parse(DtaAgaveCocido.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value.ToString()), 2);

                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_ensamble SET agave_coccion_kg=" + DtaAgaveCocido.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value + ", actualizado=0  where id_ensamble=" + DtaAgaveCocido.Rows[x].Cells["ID"].Value + "") == "Error")
                            {
                                return;
                            }
                            if (maguey_sobrante != 0)
                            {                         
                                string planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_agave_cocido_sobrante WHERE id_planta=" + id_planta +" and no_cliente='"+no_cliente+"'");
                                string union = ConexionMysql.regresaCampoConsulta("SELECT id_ensamble_union FROM  produccion_agave_cocido_sobrante WHERE id_ensamble_union='" + id_ensamble_union + "' and no_cliente='" + no_cliente + "'");
                                //valida si ya existe agave sobrante ccido de esta planta o de una union 
                                if (planta != "" )
                                {
                                    if( planta!="0")
                                    {
                                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_cocido_sobrante  SET agave_cocido_kg=agave_cocido_kg + " + maguey_sobrante + ", actualizado=0 WHERE id_planta=" + id_planta + " and no_cliente='" + no_cliente + "' ") == "Error")
                                      {
                                        return;
                                      }
                                    }
                                    else if (union != "")
                                    {
                                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_cocido_sobrante  SET agave_cocido_kg=agave_cocido_kg + " + maguey_sobrante + ", actualizado=0 WHERE id_ensamble_union='" + id_ensamble_union + "' and no_cliente='" + no_cliente + "' ") == "Error")
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        ObtenerIdMaximoAgaveSobranteCocido();
                                        if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_agave_cocido_sobrante (id_agave_cocido_sobrante,id_ensamble_union,id_produccion_entrada,no_cliente,id_predio,id_planta,agave_cocido_kg,porcentaje_art,id_verificador) VALUES ( '" + id_max_agave_sobrante_cocido + "','" + (id_planta == "0" ? id_ensamble_union : "") + "','" + (id_planta == "0" ? id : "") + "','" + no_cliente + "','" + id_predio + "'," + id_planta + "," + maguey_sobrante + "," + DtaAgaveCocido.Rows[x].Cells["ART"].Value + ","+Usuario.IdUsuario+")") == "Error")
                                        {
                                            return;
                                        }

                                    }
                                }
                                else if (union != "")
                                {
                                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_cocido_sobrante  SET agave_cocido_kg=agave_cocido_kg + " + maguey_sobrante + ", actualizado=0 WHERE id_ensamble_union='" + id_ensamble_union + "' and no_cliente='" + no_cliente + "' ") == "Error")
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    ObtenerIdMaximoAgaveSobranteCocido();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_agave_cocido_sobrante (id_agave_cocido_sobrante,id_ensamble_union,id_produccion_entrada,no_cliente,id_predio,id_planta,agave_cocido_kg,porcentaje_art,id_verificador) VALUES ( '" + id_max_agave_sobrante_cocido + "','" + (id_planta == "0" ? id_ensamble_union : "") + "','" + (id_planta == "0" ? id : "") + "','" + no_cliente + "','" + id_predio + "'," + id_planta + "," + maguey_sobrante + "," + DtaAgaveCocido.Rows[x].Cells["ART"].Value + ","+Usuario.IdUsuario+")") == "Error")
                                    {
                                        return;
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        id_predio = ConexionMysql.regresaCampoConsulta("SELECT id_predio FROM  produccion_entrada WHERE id_produccion_entrada='" + DtaAgaveCocido.Rows[0].Cells["ID"].Value + "'");
                        id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada WHERE id_produccion_entrada='" + DtaAgaveCocido.Rows[0].Cells["ID"].Value + "'");
                        maguey = ConexionMysql.regresaCampoConsulta("SELECT agave_coccion_kg FROM  produccion_entrada WHERE id_produccion_entrada='" + DtaAgaveCocido.Rows[0].Cells["ID"].Value + "'");    
                        maguey_sobrante = Math.Round(double.Parse(maguey), 2) - Math.Round(double.Parse(DtaAgaveCocido.Rows[0].Cells["KG_MAGUEY_COCIDO"].Value.ToString()), 2);

                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET agave_coccion_kg=" + DtaAgaveCocido.Rows[0].Cells["KG_MAGUEY_COCIDO"].Value + " , actualizado=0 where id_produccion_entrada='" + DtaAgaveCocido.Rows[0].Cells["ID"].Value + "'") == "Error")
                        {
                            return;
                        }
                        if (maguey_sobrante != 0)
                        {
                            //valida si el agave sobrante cocido ya existe

                            string planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_agave_cocido_sobrante WHERE id_planta=" + id_planta + " and no_cliente='" + no_cliente + "'");
                            if (planta != "" )
                            {
                                if (planta != "0")
                                {
                                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_cocido_sobrante  SET agave_cocido_kg=agave_cocido_kg + " + maguey_sobrante + " , actualizado=0 WHERE id_planta=" + id_planta + " and no_cliente='" + no_cliente + "' ") == "Error")
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    ObtenerIdMaximoAgaveSobranteCocido();
                                    if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_agave_cocido_sobrante ( id_agave_cocido_sobrante,id_produccion_entrada,no_cliente,id_predio,id_planta,agave_cocido_kg,porcentaje_art,id_verificador) VALUES ( '" + id_max_agave_sobrante_cocido + "','" + (id_planta == "0" ? DtaAgaveCocido.Rows[0].Cells["ID"].Value : "") + "','" + no_cliente + "','" + id_predio + "'," + id_planta + "," + maguey_sobrante + "," + DtaAgaveCocido.Rows[0].Cells["ART"].Value + ","+Usuario.IdUsuario+")") == "Error")
                                    {
                                        return;
                                    }

                                }
                            }
                            else
                            {
                                ObtenerIdMaximoAgaveSobranteCocido();
                                if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_agave_cocido_sobrante ( id_agave_cocido_sobrante,id_produccion_entrada,no_cliente,id_predio,id_planta,agave_cocido_kg,porcentaje_art,id_verificador) VALUES ( '" + id_max_agave_sobrante_cocido + "','" + (id_planta == "0" ? DtaAgaveCocido.Rows[0].Cells["ID"].Value : "") + "','" + no_cliente + "','" + id_predio + "'," + id_planta + "," + maguey_sobrante + "," + DtaAgaveCocido.Rows[0].Cells["ART"].Value + ","+Usuario.IdUsuario+")") == "Error")
                                {
                                    return;
                                }

                            }
                        }
                    }


                }

                //si seleccione agave sobrante para agregar 
                if (DtaAgaveCocidoSobrante.RowCount > 0)
                {
                    if (tipo_produccion != "2")
                    {
                        string id_predio = ConexionMysql.regresaCampoConsulta("SELECT id_predio FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");
                        string id_planta = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");
                        string no_pinas_agave = ConexionMysql.regresaCampoConsulta("SELECT no_pinas_agave FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");
                        string agave_kg = ConexionMysql.regresaCampoConsulta("SELECT agave_kg FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");
                        string agave_coccion_kg = ConexionMysql.regresaCampoConsulta("SELECT agave_coccion_kg FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");
                        string art_nuevo = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");
                        string id = ConexionMysql.regresaCampoConsulta("SELECT id_agave_sobrante FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");


                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET id_agave_sobrante='',id_predio=0,id_planta=0,no_pinas_agave=0,agave_kg=0,agave_coccion_kg=0,porcentaje_art=0,tipo=2,actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }
                        ObtenerIdMaximoProduccionEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_ensamble (id_ensamble_union,id_produccion_entrada,id_agave_sobrante,id_predio,id_planta,no_pinas_agave,agave_kg,agave_coccion_kg,porcentaje_art,tipo,id_verificador) VALUES ('"+id_max_produccion_ensamble_union+"','" + id_produccion + "','"+id+"','" + id_predio + "'," + id_planta + "," + no_pinas_agave + "," + agave_kg + "," + agave_coccion_kg + "," + art_nuevo + "," + tipo_produccion + ","+Usuario.IdUsuario+") ") == "Error")
                        {
                            return;
                        }
                    }

                    for (int x = 0; x < DtaAgaveCocidoSobrante.Rows.Count; x++)
                    {
                       
                      if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_cocido_sobrante SET agave_cocido_kg=agave_cocido_kg-" + DtaAgaveCocidoSobrante.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value + ",actualizado=0  where id_agave_cocido_sobrante='" + DtaAgaveCocidoSobrante.Rows[x].Cells["ID"].Value + "'") == "Error")
                      {
                        return;
                      }
                      ObtenerIdMaximoProduccionEnsamble();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_ensamble (id_ensamble_union,id_produccion_entrada,id_agave_cocido_sobrante,id_predio,id_planta,no_pinas_agave,agave_kg,agave_coccion_kg,porcentaje_art,tipo,id_verificador) VALUES ('"+id_max_produccion_ensamble_union+"','" + id_produccion + "','" +( DtaAgaveCocidoSobrante.Rows[x].Cells["ID_PLANTA"].Value.ToString()=="0" ?  DtaAgaveCocidoSobrante.Rows[x].Cells["ID"].Value.ToString() : "" )+"','" + DtaAgaveCocidoSobrante.Rows[x].Cells["ID_PREDIO"].Value + "'," + DtaAgaveCocidoSobrante.Rows[x].Cells["ID_PLANTA"].Value + ",0,0," + DtaAgaveCocidoSobrante.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value + "," + TxtArt.Text + ",5,"+Usuario.IdUsuario+") ") == "Error")
                       {
                       return;
                      }
 
                  }
                }



                if(ChekMolienda.Checked==false && ChekCoccion.Checked==true)
                {
                        DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_coccion);
                        int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeFinalCoccion.Value);
                        if (ResComparacionFechas > 0)
                        {
                            MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la cocción");
                            return;
                        }

                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_coccion_fin='" + DataTimeFinalCoccion.Value.ToString("yyyy-MM-dd") + "',porcentaje_art=" + TxtArt.Text + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_ensamble SET porcentaje_art=" + TxtArt.Text + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "' ") == "Error")
                        {
                            return;
                        } 
                        ConexionMysql.transCompleta();
                        MessageBox.Show("Cocción finalizada");
                        this.Close();             
                }
                else if (ChekMolienda.Checked == true && ChekCoccion.Checked == false)
                {
                       if (CmbMolienda.SelectedValue == null)
                       {
                        MessageBox.Show("No tienes moliendas precargadas, actualiza la base de datos");
                        return;
                       }
                           DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_coccion);
                           int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeInicioMolienda.Value);

                           if (ResComparacionFechas > 0)
                           {
                               MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la cocción");
                               return;
                           }
                           if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET  periodo_molienda_inicio='" + DataTimeInicioMolienda.Value.ToString("yyyy-MM-dd") + "',id_molienda=" + CmbMolienda.SelectedValue + ", estatus=2,porcentaje_art=" + TxtArt.Text + " ,actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                           {
                               return;
                           }
                           if (ConexionMysql.insUpd_transaccion("UPDATE produccion_ensamble SET porcentaje_art=" + TxtArt.Text + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "' ") == "Error")
                           {
                               return;
                           } 
                           ConexionMysql.transCompleta();
                           MessageBox.Show("Molienda inicializada");
                           this.Close(); 
                }
                else if (ChekMolienda.Checked == true && ChekCoccion.Checked == true)
                {
                    if (CmbMolienda.SelectedValue == null)
                    {
                        MessageBox.Show("No tienes moliendas precargadas, actualiza la base de datos");
                        return;
                    }
                    DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_coccion);
                    int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeInicioMolienda.Value);

                    if (ResComparacionFechas > 0)
                    {
                        MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la cocción");
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_coccion_fin='" + DataTimeFinalCoccion.Value.ToString("yyyy-MM-dd") + "',  periodo_molienda_inicio='" + DataTimeInicioMolienda.Value.ToString("yyyy-MM-dd") + "',id_molienda=" + CmbMolienda.SelectedValue + ", estatus=2,porcentaje_art=" + TxtArt.Text + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                    {
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_ensamble SET porcentaje_art=" + TxtArt.Text + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "' ") == "Error")
                    {
                        return;
                    } 
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Cocción finalizada y Molienda inicializada");
                    this.Close();   
                }
                else
                {
                    MessageBox.Show("Debe ingresar fechas"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }         
        }

        //chek para activar o desactivar el fin de la coccion
        private void ChekCoccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChekCoccion.Checked == true)
                {
                    DataTimeFinalCoccion.Enabled = true;
                }
                else
                {
                    DataTimeFinalCoccion.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //al seleccionar un agave cocido de la produccion carga los kilos
        private void CmbAgaveCocido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbAgaveCocido.DataSource==null)
            {
                agave_coccido = "";
                art_agave_coccido = "";
            }
            else
            {
                if (tipo_produccion == "2")
                {
                    agave_coccido = ConexionMysql.regresaCampoConsulta("SELECT agave_coccion_kg FROM  produccion_ensamble WHERE id_ensamble="+CmbAgaveCocido.SelectedValue+"");
                    art_agave_coccido = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_ensamble WHERE id_ensamble=" + CmbAgaveCocido.SelectedValue + "");
                }
                else
                {
                    agave_coccido = ConexionMysql.regresaCampoConsulta("SELECT agave_coccion_kg FROM  produccion_entrada WHERE id_produccion_entrada='" + CmbAgaveCocido.SelectedValue + "'");
                    art_agave_coccido = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_entrada WHERE id_produccion_entrada='" + CmbAgaveCocido.SelectedValue + "'");
                }
            }
        }

        // crea la tabla de agave cocido
        private void addTablaAgaveCocido()
        {
            dtsAgaveCocido = new DataSet();
            dtsAgaveCocido.Tables.Add("AGAVECOCIDO");
            dtsAgaveCocido.Tables["AGAVECOCIDO"].Columns.Add("ID", Type.GetType("System.String"));
            dtsAgaveCocido.Tables["AGAVECOCIDO"].Columns.Add("TIPO", Type.GetType("System.String"));
            dtsAgaveCocido.Tables["AGAVECOCIDO"].Columns.Add("KG_MAGUEY_COCIDO", Type.GetType("System.String"));
            dtsAgaveCocido.Tables["AGAVECOCIDO"].Columns.Add("ART", Type.GetType("System.String"));
            dtsAgaveCocido.Tables["AGAVECOCIDO"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaAgaveCocido.DataSource = dtsAgaveCocido.Tables["AGAVECOCIDO"];
            DtaAgaveCocido.Columns[0].Visible = false;
            DtaAgaveCocido.Columns[1].Visible = false;
        }
        // agrega agave codido a la tabla 
        private void BtnAgregarAgaveCocido_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbAgaveCocido.SelectedValue == null)
                {
                    MessageBox.Show("No tienes kg de maguey");
                    return;
                }
                if (TxtKgAgaveCocido.Text == "")
                {
                    MessageBox.Show("No ha introducido kg");
                    TxtKgAgaveCocido.Focus();
                    return;
                }
                if (int.Parse(TxtKgAgaveCocido.Text) == 0)
                {
                    MessageBox.Show("Introduce un valor mayor que cero");
                    TxtKgAgaveCocido.Focus();
                    return;
                }

                if (Math.Round(double.Parse(agave_coccido), 2) < Math.Round(double.Parse(TxtKgAgaveCocido.Text), 2))
                {
                    TxtKgAgaveCocido.Focus();
                    MessageBox.Show("Existencia insificiente");
                    return;
                }

                DataRow fila = dtsAgaveCocido.Tables["AGAVECOCIDO"].NewRow();
                fila["ID"] = CmbAgaveCocido.SelectedValue;
                fila["TIPO"] = tipo_produccion;
                fila["KG_MAGUEY_COCIDO"] = TxtKgAgaveCocido.Text;
                fila["ART"] = art_agave_coccido;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsAgaveCocido.Tables["AGAVECOCIDO"].Rows.Add(fila);
                TxtKgAgaveCocido.Text = "";
                CmbAgaveCocido.DataSource = null;

                string produccion = "";
                string coma = "";

                for (int x = 0; x < DtaAgaveCocido.Rows.Count; x++)
                {
                    produccion += coma + DtaAgaveCocido.Rows[x].Cells["ID"].Value;
                    coma = ",";
                }

                if (tipo_produccion == "2")
                {
                    ConexionMysql.llenaCombo(ref CmbAgaveCocido, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_coccion_kg ) As produccion, id_produccion_entrada ,id_ensamble  FROM produccion_ensamble  left join existenciaplanta on produccion_ensamble.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun   where  id_ensamble NOT IN(" + produccion + ") and  id_produccion_entrada='" + id_produccion + "'", "id_ensamble", "produccion");
                }
                else
                {
                    CmbAgaveCocido.DataSource = null;
                }

                //calcula el art compuesto 
                art_agave();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }


        //calcula el art del agave cocido 
        public void art_agave()
        {
            Boolean bandera = true;
            double suma_agave_por_art=0;
            double suma_agave_kg=0;
            double art_compuesto = 0;

            if (art !="0")
            {
               
                TxtArt.Text = art;
            }
            else
            {
                
                TxtArt.Text = "";
            }

            //si no selecione nada de agave cocido 
            if (DtaAgaveCocido.Rows.Count == 0)
            {
                string  kg_agave="";
                if (tipo_produccion == "2")
                {
                    if (art != "0")
                    {
                        kg_agave = ConexionMysql.regresaCampoConsulta("SELECT sum(agave_coccion_kg) FROM  produccion_ensamble WHERE id_produccion_entrada='" + id_produccion + "'");
                        bandera = true;
                        suma_agave_por_art += Math.Round(double.Parse(kg_agave), 2) * Math.Round(double.Parse(art), 2);
                        suma_agave_kg += Math.Round(double.Parse(kg_agave), 2);
                    }
                    else
                    {
                        bandera = false;
                    }
                }
                else
                {
                    if (art != "0")
                    {
                        kg_agave = ConexionMysql.regresaCampoConsulta("SELECT agave_coccion_kg FROM  produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'");
                        bandera = true;
                        suma_agave_por_art += Math.Round(double.Parse(kg_agave), 2) * Math.Round(double.Parse(art), 2);
                        suma_agave_kg += Math.Round(double.Parse(kg_agave), 2);
                    }
                    else
                    {
                        bandera = false;
                    }
  
                }
               
            }


            //si el tipo de produccion es dos y si hay agave que aun no agregas a la tabla de agavecocido
            if (tipo_produccion == "2")
            {

                string produccion = "";
                string coma = "";

                if (DtaAgaveCocido.Rows.Count != 0)
                {
                  
                for (int y = 0; y < DtaAgaveCocido.Rows.Count; y++)
                {
                    produccion += coma + DtaAgaveCocido.Rows[y].Cells["ID"].Value;
                    coma = ",";
                }

                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT agave_coccion_kg,porcentaje_art FROM  produccion_ensamble WHERE id_ensamble NOT IN (" + produccion + ")  and id_produccion_entrada='" + id_produccion + "' ");

                foreach (DataRow row in Datos.Tables[0].Rows)
                {
                    string kg_agave = Convert.ToString(row["agave_coccion_kg"]);
                    string art_porcen = Convert.ToString(row["porcentaje_art"]);
                    if (art_porcen == "0")
                    {
                        bandera = false;
                        break;
                    }
                    bandera = true;
                    suma_agave_por_art += Math.Round(double.Parse(kg_agave), 2) * Math.Round(double.Parse(art_porcen), 2);
                    suma_agave_kg += Math.Round(double.Parse(kg_agave), 2);
                }
                }

            }


       

            //recorremos la tabla agave cocido PARA CALCULAR ART
            for (int x = 0; x < DtaAgaveCocido.Rows.Count; x++)
            {
                if (bandera == false)
                {
                    break;
                }
                      if (DtaAgaveCocido.Rows[x].Cells["ART"].Value.ToString() != "0")
                      {
                          bandera = true;
                          suma_agave_por_art += Math.Round(double.Parse(DtaAgaveCocido.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value.ToString()), 2) * Math.Round(double.Parse(DtaAgaveCocido.Rows[x].Cells["ART"].Value.ToString()), 2);
                          suma_agave_kg += Math.Round(double.Parse(DtaAgaveCocido.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value.ToString()), 2);
                      }
                      else
                      {
                          TxtArt.Enabled = true;
                          TxtArt.Text = "";
                          bandera = false;
                          break;
                      }
               
                }



            //recorremos la tabla agave cocido sobrante  PARA CALCULAR ART
 
                for (int x = 0; x < DtaAgaveCocidoSobrante.Rows.Count; x++)
                {
                    if (bandera == false)
                    {
                        break;
                    }

                    if (DtaAgaveCocidoSobrante.Rows[x].Cells["ART"].Value.ToString() != "0")
                    {
                        bandera = true;
                        suma_agave_por_art += Math.Round(double.Parse(DtaAgaveCocidoSobrante.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value.ToString()), 2) * Math.Round(double.Parse(DtaAgaveCocidoSobrante.Rows[x].Cells["ART"].Value.ToString()), 2);
                        suma_agave_kg += Math.Round(double.Parse(DtaAgaveCocidoSobrante.Rows[x].Cells["KG_MAGUEY_COCIDO"].Value.ToString()), 2);
                    }
                    else
                    {
                        TxtArt.Enabled = true;
                        TxtArt.Text = "";
                        bandera = false;
                        break;
                    }
                }
            


            if (bandera == true)
            {
                art_compuesto = Math.Round(suma_agave_por_art / suma_agave_kg, 2);
                TxtArt.Enabled = false;
                TxtArt.Text = art_compuesto.ToString();
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


        //QUITA AGAVE COCIDO
        private void DtaAgaveCocido_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaAgaveCocido.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaAgaveCocido.Rows.RemoveAt(e.RowIndex);
                    dtsAgaveCocido.Tables["AGAVECOCIDO"].AcceptChanges();
                    CmbAgaveCocido.DataSource = null;

                    if (DtaAgaveCocido.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaAgaveCocido.Rows.Count; x++)
                        {
                            produccion += coma + DtaAgaveCocido.Rows[x].Cells["ID"].Value;
                            coma = ",";
                        }
                        if (tipo_produccion == "2")
                        {
                            ConexionMysql.llenaCombo(ref CmbAgaveCocido, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_coccion_kg ) As produccion, id_produccion_entrada ,id_ensamble  FROM produccion_ensamble  left join existenciaplanta on produccion_ensamble.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun   where  id_ensamble NOT IN(" + produccion + ") and  id_produccion_entrada='" + id_produccion + "'", "id_ensamble", "produccion");
                        }
                        else
                        {
                            CmbAgaveCocido.DataSource = null;
                        }
                    }
                    else
                    {
                        if (tipo_produccion == "2")
                        {
                            ConexionMysql.llenaCombo(ref CmbAgaveCocido, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_coccion_kg ) As produccion, id_produccion_entrada ,id_ensamble  FROM produccion_ensamble  left join existenciaplanta on produccion_ensamble.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun   where id_produccion_entrada='" + id_produccion + "'", "id_ensamble", "produccion");
                        }
                        else
                        {
                            ConexionMysql.llenaCombo(ref CmbAgaveCocido, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_coccion_kg ) As produccion, id_produccion_entrada   FROM produccion_entrada  left join existenciaplanta on produccion_entrada.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun  where id_produccion_entrada='" + id_produccion + "'", "id_produccion_entrada", "produccion");
                        }
                    }
                    //calcula el art compuesto 
                    art_agave();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // crea la tabla de agave cocido sobrante
        private void addTablaAgaveCocidoSobrante()
        {
            dtsAgaveCocidoSobrante = new DataSet();
            dtsAgaveCocidoSobrante.Tables.Add("AGAVECOCIDOSOBRANTE");
            dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Columns.Add("ID", Type.GetType("System.String"));
            dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Columns.Add("ID_MAGUEY_SOBRANTE", Type.GetType("System.String"));
            dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Columns.Add("KG_MAGUEY_COCIDO", Type.GetType("System.String"));
            dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Columns.Add("ART", Type.GetType("System.String"));
            dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaAgaveCocidoSobrante.DataSource = dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"];
            DtaAgaveCocidoSobrante.Columns[0].Visible = false;
            DtaAgaveCocidoSobrante.Columns[1].Visible = false;
            DtaAgaveCocidoSobrante.Columns[2].Visible = false;
            DtaAgaveCocidoSobrante.Columns[3].Visible = false;
        }

    
       // agrega agave cocido a la tabla 
        private void BtnAgregarAgaveCocidoSobrante_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (CmbAgaveCocidoSobrante.SelectedValue == null)
                {
                    MessageBox.Show("No tienes kg de maguey");
                    return;
                }
                
                if (TxtKgAgaveCocidoSobrante.Text == "")
                {
                    MessageBox.Show("No ha introducido kg");
                    TxtKgAgaveCocidoSobrante.Focus();
                    return;
                }
                
                if (TxtKgAgaveCocidoSobrante.Text == "0")
                {
                    MessageBox.Show("Introduce un valor mayor que cero");
                    TxtKgAgaveCocidoSobrante.Focus();
                    return;
                }
                
                if (Math.Round(double.Parse(agave_coccido_sobrante), 2) < Math.Round(double.Parse(TxtKgAgaveCocidoSobrante.Text), 2))
                {
                    TxtKgAgaveCocidoSobrante.Focus();
                    MessageBox.Show("Existencia insificiente");
                    return;
                }
                DataRow fila = dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].NewRow();
                fila["ID"] = CmbAgaveCocidoSobrante.SelectedValue;
                fila["ID_MAGUEY_SOBRANTE"] = id_agave_sobrante;
                fila["ID_PREDIO"] = id_predio_agave_coccido_sobrante;
                fila["ID_PLANTA"] = id_planta_agave_coccido_sobrante;
                fila["KG_MAGUEY_COCIDO"] = TxtKgAgaveCocidoSobrante.Text;
                fila["ART"] = art_agave_coccido_sobrante;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].Rows.Add(fila);
                TxtKgAgaveCocidoSobrante.Text = "";
                CmbAgaveCocidoSobrante.DataSource = null;
                string produccion = "";
                string coma = "";
                for (int x = 0; x < DtaAgaveCocidoSobrante.Rows.Count; x++)
                {

                    produccion += coma + "'"+ DtaAgaveCocidoSobrante.Rows[x].Cells["ID"].Value + "'";
                    coma = ",";
                }
                ConexionMysql.llenaCombo(ref CmbAgaveCocidoSobrante, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_cocido_kg ) As produccion,id_agave_cocido_sobrante   FROM produccion_agave_cocido_sobrante  left join existenciaplanta on produccion_agave_cocido_sobrante.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun  where produccion_agave_cocido_sobrante.id_agave_cocido_sobrante NOT IN(" + produccion + ") and   produccion_agave_cocido_sobrante.no_cliente='" + no_cliente + "'", "id_agave_cocido_sobrante", "produccion");
                 //calcula el art compuesto
                 art_agave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        //al selecionar agave cocido sobrante carga los kg 
        private void CmbAgaveCocidoSobrante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbAgaveCocidoSobrante.DataSource == null)
            {
                agave_coccido_sobrante = "";
                art_agave_coccido_sobrante = "";
                id_predio_agave_coccido_sobrante = "";
                id_planta_agave_coccido_sobrante = "";
                id_agave_sobrante = "";
            }
            else
            {
               agave_coccido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT agave_cocido_kg FROM  produccion_agave_cocido_sobrante WHERE id_agave_cocido_sobrante='" + CmbAgaveCocidoSobrante.SelectedValue + "'");
               id_predio_agave_coccido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_predio FROM  produccion_agave_cocido_sobrante WHERE id_agave_cocido_sobrante='" + CmbAgaveCocidoSobrante.SelectedValue + "'");
               id_planta_agave_coccido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT id_planta FROM  produccion_agave_cocido_sobrante WHERE id_agave_cocido_sobrante='" + CmbAgaveCocidoSobrante.SelectedValue + "'");
               art_agave_coccido_sobrante = ConexionMysql.regresaCampoConsulta("SELECT porcentaje_art FROM  produccion_agave_cocido_sobrante WHERE id_agave_cocido_sobrante='" + CmbAgaveCocidoSobrante.SelectedValue + "'");
           }
        }

        //quitra maguey cocido sobrante
        private void DtaAgaveCocidoSobrante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaAgaveCocidoSobrante.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaAgaveCocidoSobrante.Rows.RemoveAt(e.RowIndex);
                    dtsAgaveCocidoSobrante.Tables["AGAVECOCIDOSOBRANTE"].AcceptChanges();
                    CmbAgaveCocidoSobrante.DataSource = null;

                    if (DtaAgaveCocidoSobrante.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        for (int x = 0; x < DtaAgaveCocidoSobrante.Rows.Count; x++)
                        {
                            produccion += coma + "'" + DtaAgaveCocidoSobrante.Rows[x].Cells["ID"].Value + "'";
                                          
                            coma = ",";
                        }
                        ConexionMysql.llenaCombo(ref CmbAgaveCocidoSobrante, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_cocido_kg ) As produccion,id_agave_cocido_sobrante   FROM produccion_agave_cocido_sobrante  left join existenciaplanta on produccion_agave_cocido_sobrante.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun  where produccion_agave_cocido_sobrante.id_agave_cocido_sobrante NOT IN(" + produccion + ") and   produccion_agave_cocido_sobrante.no_cliente='" + no_cliente + "'", "id_agave_cocido_sobrante", "produccion");
                   
                    }
                    else
                    {
                        ConexionMysql.llenaCombo(ref CmbAgaveCocidoSobrante, "SELECT CONCAT('Especie : ',if(comun.nombre is null , 'Planta no registrada ', comun.nombre),'     Kg : ',agave_cocido_kg ) As produccion,id_agave_cocido_sobrante   FROM produccion_agave_cocido_sobrante  left join existenciaplanta on produccion_agave_cocido_sobrante.id_planta=existenciaplanta.id_plantas  left join comun on existenciaplanta.id_comun=comun.id_comun  where produccion_agave_cocido_sobrante.no_cliente='" + no_cliente + "'", "id_agave_cocido_sobrante", "produccion");
                    }
                    //calcula el art compuesto 
                    art_agave();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtArt.Text);
        }

        private void TxtKgAgaveCocidoSobrante_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtKgAgaveCocidoSobrante.Text);
        }

        private void TxtKgAgaveCocido_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtKgAgaveCocido.Text);
        }
        



    }
}
