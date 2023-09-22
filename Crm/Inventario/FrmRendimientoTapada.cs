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
    public partial class FrmRendimientoTapada : Form
    {
        public FrmRendimientoTapada()
        {
            InitializeComponent();
        }

        public string id_produccion = "";
        public string tapada = "";
        public string tipo = "";
        public string art = "";
        public string litros_producidos = "";
        public double agave_cocido = 0;
        public string grado_alcoholico = "";
        public string rendimiento_estatus = "";

        public string litros_puntas = "";
        public string grados_puntas = "";
        public string litros_colas = "";
        public string grados_colas = "";

        double rendimiento_real = 0;
        double produccion_a_45 = 0;

        double rendimiento_teorico = 0;
        double kg_art = 0;

        double eficiencia = 0;


        private void FrmRendimientoTapada_Load(object sender, EventArgs e)
        {
            LblTapada.Text = tapada;

            lblCategoria.Text = ObtieneCategoriaMezcal();
            string clase = obtenerclase();

            if (clase == "Destilado con")
            {
                lblClase.Text = clase + " : " + ingredientee();
            }
            else { lblClase.Text = clase; }
           

            if (tipo == "2")
            {
                DataSet Datos = new DataSet();
                ConexionMysql.llenaDataset(ref Datos, "SELECT agave_coccion_kg  FROM produccion_ensamble  WHERE id_produccion_entrada='"+id_produccion+"' ");

                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    agave_cocido += Math.Round(double.Parse(row["agave_coccion_kg"].ToString()), 2);
                        
    
                }

                lblLitros.Text = litros_producidos+ " L.";
                lblgradoalcoholico.Text = grado_alcoholico + "  % Alc. Vol.";
                lblagavecocido.Text = agave_cocido.ToString() + "  Kg.";



            }
            else
            {
                lblLitros.Text = litros_producidos+" L.";
                lblgradoalcoholico.Text = grado_alcoholico + " .% Alc. Vol.";
                lblagavecocido.Text = agave_cocido.ToString() + "  Kg.";
            }

        // saca el rendimeinto real
            produccion_a_45 = ((Math.Round(double.Parse(litros_producidos), 2) * Math.Round(double.Parse(grado_alcoholico), 2)) + (Math.Round(double.Parse(litros_colas), 2) * Math.Round(double.Parse(grados_colas), 2)) + (Math.Round(double.Parse(litros_puntas), 2) * Math.Round(double.Parse(grados_puntas), 2))) / 45;
            rendimiento_real = agave_cocido / produccion_a_45;

            lblrendimientoreal.Text = Math.Round(rendimiento_real, 2).ToString() + "  Kg/L.";


        //rendimiento teorico
        kg_art = (agave_cocido * Math.Round(double.Parse(art), 2))/100;
        rendimiento_teorico = agave_cocido /( kg_art * 1.4404);
        lblrendimeintoteorico.Text = Math.Round(rendimiento_teorico, 2).ToString() + "  Kg/L.";
               

            //calcula eficiencia 
            //eficiencia = (rendimiento_teorico / rendimiento_real) * 100;
            eficiencia = (produccion_a_45 / (kg_art * 1.4404)) * 100;
            lbleficiencia.Text = Math.Round(eficiencia, 2).ToString() + "  %.";



            if (rendimiento_estatus != "0")
            {
                TxtObservaciones.Enabled = false;
                BtnAceptar.Enabled = false;
                BtnCancelar.Enabled = false;
                lblverificadopor.Text = ConexionMysql.regresaCampoConsulta("SELECT verificadores.nombre FROM verificadores INNER JOIN produccion_entrada ON verificadores.id_us=produccion_entrada.id_verifico_rendimiento WHERE produccion_entrada.id_produccion_entrada='" + id_produccion + "'  ");
                TxtObservaciones.Text = ConexionMysql.regresaCampoConsulta("SELECT observaciones_rendimiento FROM   produccion_entrada WHERE id_produccion_entrada='" + id_produccion + "'  ");
           
            }
  
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea aprobar la tapada?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE   produccion_entrada SET rendimiento=1 , observaciones_rendimiento='" + TxtObservaciones.Text + "',id_verifico_rendimiento=" + Usuario.IdUsuario + ", actualizado=0, fecha_rendimiento=NOW() WHERE id_produccion_entrada='" + id_produccion + "' ") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Rendimiento  verificado");
                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Esta seguro que desea cancelar la tapada?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE   produccion_entrada SET rendimiento=2 , observaciones_rendimiento='" + TxtObservaciones.Text + "',id_verifico_rendimiento=" + Usuario.IdUsuario + ", actualizado=0,fecha_rendimiento=NOW() WHERE id_produccion_entrada='" + id_produccion + "' ") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Rendimiento  verificado");
                this.Close();

            }           
        }



        public string ObtieneCategoriaMezcal()
        {
            string CategoriaMezcal = "";
            string CategoriaMezcalComparar = "";
            //string id_produccion = "";
            string id_coccion = "";
            string id_molienda = "";
            string id_fermentacion = "";
            string id_destilacion = "";
            //string destilado_con = "";
            int mancetral = 0;
            int maartesanal = 0;
            int mzkl = 0;

            //for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
            //{

                //id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();

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

              /*  if (CategoriaMezcal == "Mezcal")
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
            */

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

            //}

           /* if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
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
            }*/
            return CategoriaMezcal;
           
        }

        //======================= obtine la clase de mezcal desde la produccion
        public string obtenerclase()
        {
            string claseMezcal = "";
            //string ClaseMezcalComparar = "";

           // string id_produccion = "";

            string destilado_con = "";



/*            if (DtaProduccionParaGuardarAgranel.Rows.Count == 1)
            {

                for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                {

                    id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();*/

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

               // }//-- Fin del for

          /*  }
            else
            {

                for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
                {

                    id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();

                    /* if (x > 0)
                     {
                         ClaseMezcalComparar = claseMezcal;
                     }*/

                   /* DataSet Datos = new DataSet();
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

            }*/


            return claseMezcal;


        }//--- fin de clasemezcal




        public string ingredientee()
        {

            string des_ingrediente = "";
            string ingredientecadena = "";

            int des_con = 0;
            int des_sin = 0;
            string sep = " ";
            string dif_clase = "dif_clase";

           /* for (int x = 0; x < DtaProduccionParaGuardarAgranel.Rows.Count; x++)
            {

                id_produccion = DtaProduccionParaGuardarAgranel.Rows[x].Cells["ID_PRODUCCION"].Value.ToString();
            */
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

               /* if (des_ingrediente != "")
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
            }*/
            return des_ingrediente;

            //Console.WriteLine("es : " + des_ingrediente);
            // MessageBox.Show("es : " + des_ingrediente);
            // return des_ingrediente;

        } //== fin de ingredienteGF


    }
}
