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
    public partial class FrmTerminarDestilacion : Form
    {
        public FrmTerminarDestilacion()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();
        public string id_produccion = "";
        public string fecha_inicio_destilacion = "";
        public string tapada = "";
        public string art = "";
        public string no_cliente = "";
        string id_max_produccion_ensamble_union = "";
        string id_max_puntas_colas = "";
        private void FrmTerminarDestilacion_Load(object sender, EventArgs e)
        {


            lblGradocolas.Enabled = false;
            lblGradopuntas.Enabled = false;
            lblLtscolas.Enabled = false;
            lblLtspunta.Enabled = false;

            TxtLitrosColas.Enabled = false;
            TxtLitrosPuntas.Enabled = false;
            TxtGradoColas.Enabled = false;
            TxtGradoPuntas.Enabled = false;

            lbltituloDestilado.Enabled = false;
            rtbIngredienteDestilado.Enabled = false;


            if (art != "0")
            {
                TxtArt.Text = art;
                TxtArt.Enabled = false;
            }
            TxtTapada.Enabled = false;
            ChekUltimaTapada.Visible = false;

            string id = ConexionMysql.regresaCampoConsulta("SELECT max(id)  FROM  produccion_entrada  WHERE id_proc_entr_sal='" + id_produccion + "'");
            if (id != "")
            {
                id = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada  FROM  produccion_entrada  WHERE id=" + id + "");
            }
          
            if (id!="")
           {
               ChekSegundaTapada.Checked = true;
               ChekSegundaTapada.Visible = false;
               ChekUltimaTapada.Visible = true;
               string tapada = ConexionMysql.regresaCampoConsulta("SELECT tapada  FROM  produccion_entrada  WHERE id_produccion_entrada='" + id + "'");
               MessageBox.Show("Esta tapada fue dividida tu ultimo numero de tapada fue : " + tapada);

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




        public void ObtenerIdMaximoPuntasColas()
        {
            id_max_puntas_colas = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_produccion_puntas_colas,4)) )  FROM produccion_puntas_colas where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_puntas_colas == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_puntas_colas = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_puntas_colas = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_puntas_colas) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_puntas_colas = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_puntas_colas = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (TxtArt.Text == ".")
                {              
                    MessageBox.Show("Introduce un valor ART real");
                    TxtArt.Focus();
                    return;
                }
                if (TxtArt.Text == "")
                {
                    TxtArt.Text = "0";
                }
                if (art == "0")
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET porcentaje_art=" + TxtArt.Text + ",actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                    {
                        return;
                    }
                }

                // si esta Checkeado Destilado con agrega ingrediente
                if (chkDestiladocon.Checked == true)
                {

                    if (rtbIngredienteDestilado.Text == "")
                    {

                        MessageBox.Show("Debes escribir un ingrediente......");
                        return;

                    }


                }
                else {

                    rtbIngredienteDestilado.Text = "";
                
                }


                //si esta chekeado puntas y colas verifica
        
                   /* if (TxtLitrosPuntas.Text == ".")
                    {
                        MessageBox.Show("Introduce litros de puntas real");
                        TxtLitrosPuntas.Focus();
                        return;
                    }*/
                    if (TxtLitrosPuntas.Text == "")
                    {
                        TxtLitrosPuntas.Text = "0";
                    }

                   /* if (TxtGradoPuntas.Text == ".")
                    {
                        MessageBox.Show("Introduce grado alcoholico de puntas real");
                        TxtLitrosPuntas.Focus();
                        return;
                    }*/
                    if (TxtGradoPuntas.Text == "")
                    {
                        TxtGradoPuntas.Text = "0";
                    }

                   /* if (TxtLitrosColas.Text == ".")
                    {
                        MessageBox.Show("Introduce litros de colas real");
                        TxtLitrosColas.Focus();
                        return;
                    }*/


                    if (TxtLitrosColas.Text == "")
                    {
                        TxtLitrosColas.Text = "0";
                    }

                    /*if (TxtGradoColas.Text == ".")
                    {
                        MessageBox.Show("Introduce grado alcoholico de colas real");
                        TxtGradoColas.Focus();
                        return;
                    }*/
                    if (TxtGradoColas.Text == "")
                    {
                        TxtGradoColas.Text = "0";
                    }
                

              
                if(ChekSegundaTapada.Checked==false)
                {  /// --- cuando la producion no se divide en destilacion  entra aqui --- 
                    DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_destilacion);

                    int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeFinalDestilacion.Value);

                    if (ResComparacionFechas > 0)
                    {
                        MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la destilación");
                        return;
                    }
                    if(TxtDestilaciones.Text=="")
                    {
                        MessageBox.Show("Introduce el numero de destilaciones realizadas");
                        TxtDestilaciones.Focus();
                        return;
                    }
                    if (TxtLtsProducidos.Text == "")
                    {
                        MessageBox.Show("Porfavor introduce los litros producidos");
                        TxtLtsProducidos.Focus();
                        return;
                    }
                    if (TxtGradoAlcoholico.Text == "")
                    {
                        MessageBox.Show("Porfavor introduce el grado alcohólico");
                        TxtGradoAlcoholico.Focus();
                        return;
                    }
                    if (TxtLtsProducidos.Text == ".")
                    {
                        MessageBox.Show("Porfavor introduce valores reales ejemplo (00.00)");
                        TxtLtsProducidos.Focus();
                        return;
                    }
                    if (TxtGradoAlcoholico.Text == ".")
                    {
                        MessageBox.Show("Porfavor introduce valores reales ejemplo (00.00)");
                        TxtGradoAlcoholico.Focus();
                        return;
                    }

                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_destilacion_fin='" + DataTimeFinalDestilacion.Value.ToString("yyyy-MM-dd") + "', lts_producidos='" + TxtLtsProducidos.Text + "',lts_existentes='" + TxtLtsProducidos.Text + "',grado_alcoholico='" + TxtGradoAlcoholico.Text + "',destilaciones_realizadas='" + TxtDestilaciones.Text + "',estatus=5,litros_puntas=" +TxtLitrosPuntas.Text + ", grados_puntas=" + TxtGradoPuntas.Text + ",litros_colas=" + TxtLitrosColas.Text + ",grados_colas=" +TxtGradoColas.Text + ",destilado_con='"+rtbIngredienteDestilado.Text+"',actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                    {
                        return;
                    }


                    //si es true el chek de  las colas y puntas  actulizar inventario o agregar nuevo     
                    if (chekpuntascolas.Checked == true)
                    {
                        string litros_puntas = ConexionMysql.regresaCampoConsulta("select litros from produccion_puntas_colas where tipo='puntas' and no_cliente='" + no_cliente + "'");
                        if (litros_puntas == "")
                        {
                            ObtenerIdMaximoPuntasColas();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_puntas_colas (id_produccion_puntas_colas,no_cliente,tipo,litros,grado_alcoholico,id_verificador) VALUES('"+id_max_puntas_colas+"','" + no_cliente + "','puntas'," + TxtLitrosPuntas.Text + "," + TxtGradoPuntas.Text + ","+Usuario.IdUsuario+")") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            string grado_puntas = ConexionMysql.regresaCampoConsulta("select grado_alcoholico from produccion_puntas_colas where tipo='puntas' and no_cliente='" + no_cliente + "'");
                            double suma =Math.Round(double.Parse(TxtLitrosPuntas.Text), 2) * Math.Round(double.Parse(TxtGradoPuntas.Text),2);
                            suma += Math.Round(double.Parse(litros_puntas), 2) * Math.Round(double.Parse(grado_puntas), 2);
                            double nuevo_grado_puntas = suma / (Math.Round(double.Parse(TxtLitrosPuntas.Text), 2) + Math.Round(double.Parse(litros_puntas), 2));
                            nuevo_grado_puntas = Math.Round(nuevo_grado_puntas, 2);
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_puntas_colas SET litros=litros+" + TxtLitrosPuntas.Text + ",grado_alcoholico=" + nuevo_grado_puntas + ",actualizado=0 WHERE no_cliente='" + no_cliente + "' and tipo='puntas' ") == "Error")
                            {
                                return;
                            }
                        }

                        string litros_colas = ConexionMysql.regresaCampoConsulta("select litros from produccion_puntas_colas where tipo='colas' and no_cliente='" + no_cliente + "'");
                        if (litros_colas == "")
                        {
                            ObtenerIdMaximoPuntasColas();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_puntas_colas (id_produccion_puntas_colas,no_cliente,tipo,litros,grado_alcoholico,id_verificador) VALUES('"+id_max_puntas_colas+"','" + no_cliente + "','colas'," + TxtLitrosColas.Text + "," + TxtGradoColas.Text + ","+Usuario.IdUsuario+")") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            string grado_colas = ConexionMysql.regresaCampoConsulta("select grado_alcoholico from produccion_puntas_colas where tipo='colas' and no_cliente='" + no_cliente + "'");
                            double suma = Math.Round(double.Parse(TxtLitrosColas.Text), 2) * Math.Round(double.Parse(TxtGradoColas.Text), 2);
                            suma += Math.Round(double.Parse(litros_colas), 2) * Math.Round(double.Parse(grado_colas), 2);
                            double nuevo_grado_colas = suma / (Math.Round(double.Parse(TxtLitrosColas.Text), 2) + Math.Round(double.Parse(litros_colas), 2));
                            nuevo_grado_colas=Math.Round(nuevo_grado_colas,2);
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_puntas_colas SET litros=litros+" + TxtLitrosColas.Text + ",grado_alcoholico=" + nuevo_grado_colas + ",actualizado=0 WHERE no_cliente='"+no_cliente+"' and tipo='colas' ") == "Error")
                            {
                                return;
                            }
                        }
                    } ///--- fin del if de puntas Colas  ---- 

                   ConexionMysql.transCompleta();
                   MessageBox.Show("Producción realizada con éxito");
                   this.Close();
                }/// ---- fin del check de segunda tapada ---- 
                else 
                {
                    /// --- cuando la producion se divide en destilacion  entra aqui --- 
                    

                    DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_destilacion);
                    //MessageBox.Show("fecha uno " + fecha_inicio);

                   // MessageBox.Show("fecha dos " + DataTimeFinalDestilacion.Value);
                    int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeFinalDestilacion.Value);

                    //MessageBox.Show("fecha dos " + ResComparacionFechas);

                    
                    if (ResComparacionFechas > 0)
                    {
                        MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la destilación");
                        return;
                    }
                    if (TxtDestilaciones.Text == "")
                    {
                        MessageBox.Show("Introduce el numero de destilaciones realizadas");
                        TxtDestilaciones.Focus();
                        return;
                    }
                    if (TxtTapada.Text == "")
                    {
                        MessageBox.Show("Introduce valor complementario de la tapada");
                        TxtTapada.Focus();
                        return;
                    }
                    if (TxtLtsProducidos.Text == "")
                    {
                        MessageBox.Show("Porfavor introduce los litros producidos");
                        TxtLtsProducidos.Focus();
                        return;
                    }
                    if (TxtGradoAlcoholico.Text == "")
                    {
                        MessageBox.Show("Porfavor introduce el grado alcohólico");
                        TxtGradoAlcoholico.Focus();
                        return;
                    }
                    if (TxtLtsProducidos.Text == ".")
                    {
                        MessageBox.Show("Porfavor introduce valores reales ejemplo (00.00)");
                        TxtLtsProducidos.Focus();
                        return;
                    }
                    if (TxtGradoAlcoholico.Text == ".")
                    {
                        MessageBox.Show("Porfavor introduce valores reales ejemplo (00.00)");
                        TxtGradoAlcoholico.Focus();
                        return;
                    }

                    if (ChekUltimaTapada.Checked == true)
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET  periodo_destilacion_fin='" + DataTimeFinalDestilacion.Value.ToString("yyyy-MM-dd") +"',destilado_con='"+rtbIngredienteDestilado.Text+"',actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET estatus=5,actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }
                    }

 
                    string no_cliente = "";
                    string id_fabrica = "";
                    string id_maestro_mezcalero = "";
                    string id_predio = "";
                    string id_planta = "";
                    string tapada = LblTpada.Text+TxtTapada.Text;
                    string no_pinas_agave = "";
                    string agave_kg = "";
                    string agave_coccion_kg = "";
                    string id_coccion = "";
                    string periodo_coccion_inicio = "";
                    string periodo_coccion_fin = "";
                    string porcentaje_art = "";
                    string id_molienda = "";
                    string periodo_molienda_inicio = "";
                    string periodo_molienda_fin = "";
                    string periodo_formulacion_inicio = "";
                    string id_fermentacion = "";
                    string periodo_formulacion_fin = "";
                    string volumen_mosto = "";
                    string periodo_destilacion_inicio = "";
                    string id_destilacion = "";
                    string tipo = "";
                    string fecha = "";
                    string id_agave_sobrante = "";
                    string id_agave_cocido_sobrante = "";
                    string no_guia = "";
                    string id_verificador = "";


                     

                              
                    /*  DialogResult check = MessageBox.Show("Requiere poner fecha de finalizacion en los porcesos anteriores para dividir la tapada!", "", MessageBoxButtons.OKCancel, 
                         MessageBoxIcon.Warning);

                     if (check == DialogResult.Cancel) { return; }

                     else
                     { }*/

                  
                    DataSet Datos = new DataSet();
                    ConexionMysql.llenaDataset(ref Datos, "SELECT id_fabrica,id_maestro_mezcalero,id_agave_sobrante,no_cliente,id_predio,id_planta,no_guia,tapada,no_pinas_agave,agave_kg,agave_coccion_kg,id_coccion,periodo_coccion_inicio,periodo_coccion_fin,porcentaje_art,id_molienda,periodo_molienda_inicio,periodo_molienda_fin,periodo_formulacion_inicio,id_fermentacion,periodo_formulacion_fin,volumen_mosto,periodo_destilacion_inicio,id_destilacion,fecha,tipo FROM produccion_entrada  WHERE id_produccion_entrada='" + id_produccion + "'");

                   
                    
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                       id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                       id_fabrica = Convert.ToString(row["id_fabrica"]);
                       id_maestro_mezcalero = Convert.ToString(row["id_maestro_mezcalero"]);
                       no_cliente = Convert.ToString(row["no_cliente"]);
                       id_predio = Convert.ToString(row["id_predio"]);
                       id_planta = Convert.ToString(row["id_planta"]);
                       no_guia = Convert.ToString(row["no_guia"]);
                       no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                       agave_kg = Convert.ToString(row["agave_kg"]);
                       agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                       id_coccion = Convert.ToString(row["id_coccion"]);
                       //perido_coccion_inicio = Convert.ToString(row["periodo_coccion_inicio"]);
                       periodo_coccion_inicio = Convert.ToDateTime(row["periodo_coccion_inicio"]).ToString("yyyy-MM-dd");
                       //perido_coccion_fin = Convert.ToString(row["periodo_coccion_fin"]);
                       periodo_coccion_fin = Convert.ToDateTime(row["periodo_coccion_fin"]).ToString("yyyy-MM-dd");
                       porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                       id_molienda = Convert.ToString(row["id_molienda"]);
                       //periodo_molienda_inicio = Convert.ToString(row["periodo_molienda_inicio"]);
                       periodo_molienda_inicio = Convert.ToDateTime(row["periodo_molienda_inicio"]).ToString("yyyy-MM-dd");
                       //periodo_molienda_fin = Convert.ToString(row["periodo_molienda_fin"]);
                       periodo_molienda_fin = Convert.ToDateTime(row["periodo_molienda_fin"]).ToString("yyyy-MM-dd");
                      //periodo_formulacion_inicio = Convert.ToString(row["periodo_formulacion_inicio"]);
                       periodo_formulacion_inicio = Convert.ToDateTime(row["periodo_formulacion_inicio"]).ToString("yyyy-MM-dd");
                       id_fermentacion = Convert.ToString(row["id_fermentacion"]);
                       //periodo_formulacion_fin = Convert.ToString(row["periodo_formulacion_fin"]);
                       periodo_formulacion_fin = Convert.ToDateTime(row["periodo_formulacion_fin"]).ToString("yyyy-MM-dd");
                       volumen_mosto = Convert.ToString(row["volumen_mosto"]);
                       //periodo_destilacion_inicio = Convert.ToString(row["periodo_destilacion_inicio"]);
                       periodo_destilacion_inicio = Convert.ToDateTime(row["periodo_destilacion_inicio"]).ToString("yyyy-MM-dd");
                       id_destilacion = Convert.ToString(row["id_destilacion"]);
                       tipo = Convert.ToString(row["tipo"]);
                       //fecha = Convert.ToString(row["fecha"]);
                       fecha = Convert.ToDateTime(row["fecha"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }



                    

              

                    string id_max_produccion_entrada = "";
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
                    }


                    if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_entrada(id_fabrica,id_maestro_mezcalero,id_produccion_entrada,id_proc_entr_sal,id_agave_sobrante,no_cliente,id_predio,id_planta,no_guia,tapada,no_pinas_agave,agave_kg,agave_coccion_kg,id_coccion,periodo_coccion_inicio,periodo_coccion_fin,porcentaje_art,id_molienda,periodo_molienda_inicio,periodo_molienda_fin,periodo_formulacion_inicio,id_fermentacion,periodo_formulacion_fin,volumen_mosto,periodo_destilacion_inicio,id_destilacion,periodo_destilacion_fin,destilaciones_realizadas,lts_producidos,grado_alcoholico,lts_existentes,litros_puntas,grados_puntas,litros_colas,grados_colas,destilado_con,id_verificador,fecha,estatus,tipo) VALUES ('" + id_fabrica + "','" + id_maestro_mezcalero + "','" + id_max_produccion_entrada + "','" + id_produccion + "','" + id_agave_sobrante + "','" + no_cliente + "','" + id_predio + "','" + id_planta + "','" +no_guia +"','" + tapada + "','" + no_pinas_agave + "','" + agave_kg + "','" + agave_coccion_kg + "','" + id_coccion + "','" + periodo_coccion_inicio + "','" + periodo_coccion_fin + "','" + porcentaje_art + "','" + id_molienda + "','" + periodo_molienda_inicio + "','" + periodo_molienda_fin + "','" + periodo_formulacion_inicio + "','" + id_fermentacion + "','" + periodo_formulacion_fin + "','" + volumen_mosto + "','" + periodo_destilacion_inicio + "','" + id_destilacion + "','" + DataTimeFinalDestilacion.Value.ToString("yyyy-MM-dd") + "','" + TxtDestilaciones.Text + "','" + TxtLtsProducidos.Text + "','" + TxtGradoAlcoholico.Text + "','" + TxtLtsProducidos.Text + "'," + TxtLitrosPuntas.Text + "," + TxtGradoPuntas.Text + "," + TxtLitrosColas.Text + "," + TxtGradoColas.Text + ",'" + rtbIngredienteDestilado.Text + "','" + Usuario.IdUsuario + "','" + fecha + "',5,'" + tipo + "')") == "Error")
                    {
                        return;
                    }


                    //si es true el chek de  las colas y puntas  actulizar inventario o agregar nuevo     
                    if (chekpuntascolas.Checked == true)
                    {
                        string litros_puntas = ConexionMysql.regresaCampoConsulta("select litros from produccion_puntas_colas where tipo='puntas' and no_cliente='" + no_cliente + "'");
                        if (litros_puntas == "")
                        {
                            ObtenerIdMaximoPuntasColas();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_puntas_colas (id_produccion_puntas_colas,no_cliente,tipo,litros,grado_alcoholico,id_verificador) VALUES('"+id_max_puntas_colas+"','" + no_cliente + "','puntas'," + TxtLitrosPuntas.Text + "," + TxtGradoPuntas.Text + ","+Usuario.IdUsuario+")") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            string grado_puntas = ConexionMysql.regresaCampoConsulta("select grado_alcoholico from produccion_puntas_colas where tipo='puntas' and no_cliente='" + no_cliente + "'");
                            double suma = Math.Round(double.Parse(TxtLitrosPuntas.Text), 2) * Math.Round(double.Parse(TxtGradoPuntas.Text), 2);
                            suma += Math.Round(double.Parse(litros_puntas), 2) * Math.Round(double.Parse(grado_puntas), 2);
                            double nuevo_grado_puntas = suma / (Math.Round(double.Parse(TxtLitrosPuntas.Text), 2) + Math.Round(double.Parse(litros_puntas), 2));
                            nuevo_grado_puntas = Math.Round(nuevo_grado_puntas, 2);
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_puntas_colas SET litros=litros+" + TxtLitrosPuntas.Text + ",grado_alcoholico=" + nuevo_grado_puntas + ",actualizado=0 WHERE no_cliente='" + no_cliente + "' and tipo='puntas' ") == "Error")
                            {
                                return;
                            }
                        }

                        string litros_colas = ConexionMysql.regresaCampoConsulta("select litros from produccion_puntas_colas where tipo='colas' and no_cliente='" + no_cliente + "'");
                        if (litros_colas == "")
                        {
                            ObtenerIdMaximoPuntasColas();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO produccion_puntas_colas (id_produccion_puntas_colas,no_cliente,tipo,litros,grado_alcoholico,id_verificador) VALUES('"+id_max_puntas_colas+"','" + no_cliente + "','colas'," + TxtLitrosColas.Text + "," + TxtGradoColas.Text + ","+Usuario.IdUsuario+")") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            string grado_colas = ConexionMysql.regresaCampoConsulta("select grado_alcoholico from produccion_puntas_colas where tipo='colas' and no_cliente='" + no_cliente + "'");
                            double suma = Math.Round(double.Parse(TxtLitrosColas.Text), 2) * Math.Round(double.Parse(TxtGradoColas.Text), 2);
                            suma += Math.Round(double.Parse(litros_colas), 2) * Math.Round(double.Parse(grado_colas), 2);
                            double nuevo_grado_colas = suma / (Math.Round(double.Parse(TxtLitrosColas.Text), 2) + Math.Round(double.Parse(litros_colas), 2));
                            nuevo_grado_colas = Math.Round(nuevo_grado_colas, 2);
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_puntas_colas SET litros=litros+" + TxtLitrosColas.Text + ",grado_alcoholico=" + nuevo_grado_colas + ",actualizado=0 WHERE no_cliente='" + no_cliente + "' and tipo='colas' ") == "Error")
                            {
                                return;
                            }
                        }
                    }


                    if (tipo != "2")
                    {

                        ConexionMysql.transCompleta();
                        MessageBox.Show("Producción realizada con éxito");
                        this.Close();
                    }
                    else
                    {

                        
                        string id = ConexionMysql.regresaCampoConsulta("SELECT max(id) as id FROM  produccion_entrada");
                        id = ConexionMysql.regresaCampoConsulta("SELECT id_produccion_entrada as id FROM  produccion_entrada where id="+id+"");
                        DataSet Dato = new DataSet();
                        ConexionMysql.llenaDataset(ref Dato, "SELECT id_agave_sobrante,id_agave_cocido_sobrante,id_predio,id_planta,no_pinas_agave,agave_kg,agave_coccion_kg,porcentaje_art,tipo FROM produccion_ensamble  WHERE id_produccion_entrada='" + id_produccion + "'");
                        foreach (DataRow row in Dato.Tables[0].Rows)
                        {
                            id_agave_cocido_sobrante = Convert.ToString(row["id_agave_cocido_sobrante"]);
                            id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                            id_planta = Convert.ToString(row["id_planta"]);
                            id_predio = Convert.ToString(row["id_predio"]);
                            no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                            agave_kg = Convert.ToString(row["agave_kg"]);
                            agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                            porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                            tipo = Convert.ToString(row["tipo"]);

                            ObtenerIdMaximoProduccionEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  produccion_ensamble(id_ensamble_union,id_produccion_entrada,id_agave_sobrante,id_agave_cocido_sobrante,id_predio,id_planta,no_pinas_agave,agave_kg,agave_coccion_kg,porcentaje_art,tipo,id_verificador) VALUES('"+id_max_produccion_ensamble_union+"','" + id + "','"+id_agave_sobrante+"','"+id_agave_cocido_sobrante+"','" + id_predio + "'," + id_planta + "," + no_pinas_agave + "," + agave_kg + "," + agave_coccion_kg + "," + porcentaje_art + "," + tipo + ","+Usuario.IdUsuario+" )") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("Producción realizada con éxito");
                        this.Close();
                    }

                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void ChekSegundaTapada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChekSegundaTapada.Checked == true)
                {

                    //---- Valida que las fechas finales de los procesos anteriores de destilacion no sean = 00/00/0000 para la divicion de la tapada
                    DataSet Datosp = new DataSet();  
                    ConexionMysql.llenaDataset(ref Datosp, "SELECT DATE_FORMAT(produccion_entrada.periodo_coccion_fin, '%d/%m/%Y') as periodo_coccion_fin,periodo_molienda_inicio,DATE_FORMAT(produccion_entrada.periodo_molienda_fin, '%d/%m/%Y') as periodo_molienda_fin ,DATE_FORMAT(produccion_entrada.periodo_formulacion_fin, '%d/%m/%Y') as periodo_formulacion_fin FROM produccion_entrada  WHERE id_produccion_entrada='" + id_produccion + "'");


                    string f_coccion = "";
                    string f_molienda = "";
                    string f_formulacion = "";
                    foreach (DataRow rows in Datosp.Tables[0].Rows)
                    {

                        f_coccion = Convert.ToString(rows["periodo_coccion_fin"]);
                        f_molienda = Convert.ToString(rows["periodo_molienda_fin"]);
                        f_formulacion = Convert.ToString(rows["periodo_formulacion_fin"]);


                    }

                    if (f_coccion == "00/00/0000" || f_molienda == "00/00/0000" || f_formulacion == "00/00/0000")
                    {
                        MessageBox.Show("Requiere poner fecha de finalizacion en los porcesos anteriores para dividir la tapada!");
                        return;
                    }
                    else
                    {

                        LblTpada.Text = tapada + "-";
                        TxtTapada.Enabled = true;

                    }

                }
                else
                {
                    LblTpada.Text = "...................";
                    TxtTapada.Text = "";
                    TxtTapada.Enabled = false;
  
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

        private void TxtDestilaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void chekpuntascolas_CheckedChanged(object sender, EventArgs e)
        {
            if (chekpuntascolas.Checked == true)
            {
                TxtLitrosColas.Enabled = true;
                TxtLitrosPuntas.Enabled = true;
                TxtGradoColas.Enabled = true;
                TxtGradoPuntas.Enabled = true;

                lblGradocolas.Enabled = true;
                lblGradopuntas.Enabled = true;
                lblLtscolas.Enabled = true;
                lblLtspunta.Enabled = true;
                 

            }
            else
            {
                lblGradocolas.Enabled = false;
                lblGradopuntas.Enabled = false;
                lblLtscolas.Enabled = false;
                lblLtspunta.Enabled = false;


                TxtLitrosColas.Enabled = false;
                TxtLitrosPuntas.Enabled = false;
                TxtGradoColas.Enabled = false;
                TxtGradoPuntas.Enabled = false;

                TxtLitrosColas.Text = "";
                TxtLitrosPuntas.Text = "";
                TxtGradoColas.Text = "";
                TxtGradoPuntas.Text = "";
            }
        }

        private void TxtLitrosPuntas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosPuntas.Text);
        }

        private void TxtGradoPuntas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoPuntas.Text);
        }

        private void TxtLitrosColas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosColas.Text);
        }

        private void TxtGradoColas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoColas.Text);
        }

        private void chkDestiladocon_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDestiladocon.Checked == true)
            {
                lbltituloDestilado.Enabled = true;
                rtbIngredienteDestilado.Enabled = true;

            }
            else
            {
                lbltituloDestilado.Enabled = false;
                rtbIngredienteDestilado.Enabled = false;
            }

        }

    }
}
