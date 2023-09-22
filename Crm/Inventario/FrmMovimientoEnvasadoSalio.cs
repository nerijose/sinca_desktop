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
    public partial class FrmMovimientoEnvasadoSalio : Form
    {
        public FrmMovimientoEnvasadoSalio()
        {

            InitializeComponent();
        }
        Validacion valida = new Validacion();
        // Funtions fn = new Funtions();
        public string tipo_instalacion;
        public string id_envasado_movimientos;
        public string id_marca;
        public string id_envasadora;
        public string id_planta;
        public string id_predio;
        public string marca;
        public string no_lote;
        public string categoria;
        public string fq;
        public string abocante;
        public string ingrediente;
        public string clase;
        public string unidad_medida;
        public string contenido_botella;
        public string botellas;
        public string no_cliente;
        public string grado_alcoholico;
        public string destino;
        public string litros;
        string id_max_envasado_movimientos;
        string id_max_envasado_entrada;

        string id_max_envasado_salida;

        string id_max_almacen_envasado_movimientos;

        //obtencion de los id para todas las entradas a envasado 
        public void ObtenerIdMaximoEnvasadoMovimientos()
        {
            id_max_envasado_movimientos = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_movimientos,4)) )   FROM envasado_movimientos where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasado_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasado_movimientos = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasado_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasado_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


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


        private void FrmMovimientoEnvasadoSalio_Load(object sender, EventArgs e)
        {
            //CmbTipo.Text = "---Elije una opcion---";
            //(CmbIngreso.Text = "---Elije una opcion---";
            CmbMarca.Visible = false;
            CmbUnidadDeMedida.Visible = false;
            CmbMedidaBotella.Visible = false;

            if (tipo_instalacion == "almacen_envasado")
            {
                CmbTipo.Items.Insert(0, "---Elije una opcion---");
                CmbTipo.Items.Insert(1, "Cambio");
                CmbTipo.SelectedIndex = 0;

            }
            else
            {
                CmbTipo.Items.Insert(0, "---Elije una opcion---");
                CmbTipo.Items.Insert(1, "Cambio");
                CmbTipo.Items.Insert(2, "Reenvasado");
                CmbTipo.SelectedIndex = 0;

            }





            LblMarca.Text = marca;
            LblNoLote.Text = no_lote;
            LblFq.Text = fq;
            LblPresentacion.Text = contenido_botella + " " + unidad_medida;
            LblClase.Text = clase;
            LblCategoria.Text = categoria;
            LblAbocante.Text = abocante;
            LblIngrediente.Text = ingrediente;
            LblBotellas.Text = botellas;
            LblGradoAlcoholico.Text = grado_alcoholico;
            LblDesttino.Text = destino;




        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (CmbTipo.Text == "---Elije una opcion---")
            {
                MessageBox.Show("Debe seleccionar un tipo de movimiento");
                return;
            }
            if (CmbIngreso.Text == "---Elije una opcion---")
            {
                MessageBox.Show("Debe seleccionar un tipo de ingreso");
                return;
            }
            /* if (CmbTipo.Text == null)
             {
                 MessageBox.Show("Debe seleccionar un tipo de salida");
                 return;
             }
             if (CmbIngreso.Text == null)
             {
                 MessageBox.Show("Debe seleccionar un tipo de ingreso");
                 return;
             }*/
            if (TxtBotellas.Text == "")
            {
                MessageBox.Show("Debe introducir el numero de botellas a cambiar");
                return;
            }


            if (Convert.ToInt64(TxtBotellas.Text) > Convert.ToInt64(botellas))
            {
                MessageBox.Show("Existencia insuficiente");
                return;
            }


            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {


                if (tipo_instalacion == "almacen_envasado")
                {

                    id_max_almacen_envasado_movimientos = IdMaximo.ObtenerIdMaximoAlmacenEnvasadoMovimientos();

                }
                else
                {

                    ObtenerIdMaximoEnvasadoEntrada();
                    ObtenerIdMaximoEnvasadoMovimientos();
                }


                if (CmbTipo.Text == "Reenvasado" && CmbIngreso.Text == "Granel de Envasado") // --(CmbTipo.Text == "Reproceso" && CmbIngreso.Text == "Almacen")
                {

                    // --  if (botellas == TxtBotellas.Text)
                    // --  {

                    /// --- Entra el el if si cumple la condicion de ser el total de botellas

                    ///-- obtiene el id del envasado tomando en cuenta que deriva de un movimiento -- 
                    string id_envasado = ConexionMysql.regresaCampoConsulta("SELECT if (em2.id_env_mov_salio = '' OR em2.id_env_mov_salio IS NULL  ,em2.id_envasado_entrada ,(SELECT em.id_envasado_entrada FROM  envasado_movimientos em WHERE em.id_envasado_movimientos=em2.id_env_mov_salio)) as id_envasado_entrada  FROM  envasado_movimientos em2 WHERE em2.id_envasado_movimientos='" + id_envasado_movimientos + "' ");

                    ///--- obtiene el id del lote de envasado tomando en cuenta que puede proceder de algun lote de envasado no terminado
                    string id_entrada_envasado = ConexionMysql.regresaCampoConsulta("SELECT if (em2.id_envasado_entrada_salio = '' OR em2.id_envasado_entrada_salio IS NULL ,em2.id_envasado_entrada ,(SELECT em.id_envasado_entrada FROM  envasado_entrada em WHERE em.id_envasado_entrada=em2.id_envasado_entrada_salio)) as id_envasado_entrada FROM envasado_entrada em2 WHERE em2.id_envasado_entrada='" + id_envasado + "' ");


                    ///--- obtiene el ide del lote de granel envasado para y verificar que no se aungresado con boton verde
                    string id_granel_entrada_envasado = ConexionMysql.regresaCampoConsulta("SELECT id_granel_entrada_envasado FROM granel_salida where id_envasado_entrada='" + id_entrada_envasado + "' ");


                    if (id_granel_entrada_envasado == "")
                    {
                        // --- Entra si no encuentra registro de salida en granel
                        MessageBox.Show("El lote de envasado no cuenta con registro en granel de envasado, verificar el tipo de ingreso a la unidad de envasado. " + Environment.NewLine + "Comunicate con la unidad de verificación para más informacion.", "¡¡ATENCION!!");
                        return;

                    }

                    /* if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,id_env_mov_salio,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES ('" + id_max_envasado_movimientos + "','" + id_max_envasado_entrada + "','" + id_envasado_movimientos + "','" + no_cliente + "','entrada','reproceso'," + TxtBotellas.Text + "," + TxtBotellas.Text + ",0,0,now()," + Usuario.IdUsuario + ",0,'" + TxtObservacionesReproceso.Text + "')") == "Error")
                         {


                         return;
                         }*/

                    ///-- actualiza el numero de botellas en la existencia del lote de envasado
                    if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos SET botellas_existentes=botellas_existentes-" + TxtBotellas.Text + ", actualizado=0 WHERE id_envasado_movimientos='" + id_envasado_movimientos + "'") == "Error")
                    {


                        return;
                    }

                    ////--- calcula los litros que se van a reprocesar del envasado del envasado -- 

                    double calcula_ltspor_restar = Funtions.calcula_lts_botellas(Convert.ToDouble(TxtBotellas.Text), unidad_medida, contenido_botella);
                    string ltspor_restar = Convert.ToString(calcula_ltspor_restar);


                    ///--- actualiza los litros del granel de envasado -- 
                    if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes+" + ltspor_restar + ",2), actualizado=0 WHERE id_granel_entrada_envasado='" + id_granel_entrada_envasado + "'") == "Error")
                    {


                        return;
                    }






                    ObtenerIdMaximoEnvasadoSalida();

                    ///--- registra el movimiento de salida del lote de envasado a reproceso
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_salida  (id_envasado_salida, id_envasado_entrada,id_granel_entrada_envasado,id_envasado_mov_salida, litros, botellas, grado_alcoholico,tipo_salida,observaciones, id_verificador, actualizado) values('" + id_max_envasado_salida + "','" + id_entrada_envasado + "','" + id_granel_entrada_envasado + "','" + id_envasado_movimientos + "',ROUND(" + ltspor_restar + ",2)," + TxtBotellas.Text + "," + grado_alcoholico + ",'Reenvasado','" + TxtObservacionesReproceso.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                    {
                        return;
                    }



                    //--  }
                    // --  else
                    // --  {

                    /*
                if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_entrada (id_envasado_entrada,id_marca,no_cliente,fecha,no_lote,id_planta,id_predio,fq,clase,categoria,abocante,ingrediente,unidad_medida,contenido_por_botella,litros,grado_alcoholico,botellas_iniciales,botellas,botellas_existentes,id_verificador,actualizado) VALUES ('" + id_max_envasado_entrada + "','" + id_marca + "','" + no_cliente + "',now(),'" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + unidad_medida + "','" + contenido_botella + "','" + litros + "','" + grado_alcoholico + "','" + TxtBotellas.Text + "','" + TxtBotellas.Text + "','" + TxtBotellas.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                    {
                           return;
                    }
                if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos SET botellas_existentes=botellas_existentes-" + TxtBotellas.Text + ", actualizado=0 WHERE id_envasado_movimientos='" + id_envasado_movimientos + "'") == "Error")
                    {
                    return;
                    }

                if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,id_env_mov_salio,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES ('" + id_max_envasado_movimientos + "','" + id_max_envasado_entrada + "','" + id_envasado_movimientos + "','" + no_cliente + "','entrada','reproceso'," + TxtBotellas.Text + "," + TxtBotellas.Text + ",0,0,now()," + Usuario.IdUsuario + ",0,'" + TxtObservacionesReproceso.Text + "')") == "Error")
                    {
                    return;
                    }
                    */

                    // -- }
                }//--- Fin IF reproceso && Almacen

                //else if (CmbTipo.Text == "Reproceso" && CmbIngreso.Text != "Almacen")
                //{
                //    if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos SET botellas_existentes=botellas_existentes-" + TxtBotellas.Text + " WHERE id_envasado_movimientos=" + id_envasado_movimientos + "") == "Error")
                //    {
                //        return;
                //    }
                //    if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_movimientos(id_env_mov_salio,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES (" + id_envasado_movimientos + ",'" + no_cliente + "','cambio','" + (CmbIngreso.Text == "Nacional" ? "Nacional" : "Exportacion") + "'," + TxtBotellas.Text + "," + TxtBotellas.Text + ",0,0,now()," + Usuario.IdUsuario + ",0,'" + TxtObservacionesReproceso.Text + "')") == "Error")
                //    {
                //        return;
                //    }
                //}
                else if (CmbTipo.Text == "Cambio" && CmbIngreso.Text != "Total")
                {
                    if (tipo_instalacion == "almacen_envasado")
                    {
                        if (botellas == TxtBotellas.Text)
                        {
                            ///--- entra si el total de botellas es igual al total a cambiar 

                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_movimientos SET tipo='cambio',destino='" + CmbIngreso.Text + "', actualizado=0 WHERE id_almacen_envasado_movimientos='" + id_envasado_movimientos + "'") == "Error")
                            {
                                return;
                            }


                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_movimientos SET botellas_existentes=ROUND(botellas_existentes-" + TxtBotellas.Text + ",2),actualizado=0 WHERE id_almacen_envasado_movimientos='" + id_envasado_movimientos + "'") == "Error")
                            {
                                return;
                            }
                            string id_envasado = ConexionMysql.regresaCampoConsulta("SELECT id_almacen_envasado_entrada FROM  almacen_envasado_movimientos WHERE id_almacen_envasado_movimientos='" + id_envasado_movimientos + "' ");

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO almacen_envasado_movimientos(id_almacen_envasado_movimientos,id_almacen_envasado_entrada,id_almacen_env_mov_salio,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES ('" + id_max_almacen_envasado_movimientos + "','" + id_envasado + "','" + id_envasado_movimientos + "','" + no_cliente + "','cambio','" + CmbIngreso.Text + "'," + TxtBotellas.Text + "," + TxtBotellas.Text + ",0,0,now()," + Usuario.IdUsuario + ",0,'" + TxtObservacionesReproceso.Text + "')") == "Error")
                            {
                                return;
                            }
                        }///fin del else --

                    }
                    else
                    {
                        if (botellas == TxtBotellas.Text)
                        {
                            ///--- entra si el total de botellas es igual al total a cambiar 

                            // MessageBox.Show("probando ando.. " + id_envasado_movimientos);

                            if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos SET tipo='cambio',destino='" + CmbIngreso.Text + "', actualizado=0 WHERE id_envasado_movimientos='" + id_envasado_movimientos + "'") == "Error")
                            {
                                return;
                            }


                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos SET botellas_existentes=ROUND(botellas_existentes-" + TxtBotellas.Text + ",2),actualizado=0 WHERE id_envasado_movimientos='" + id_envasado_movimientos + "'") == "Error")
                            {
                                return;
                            }
                            string id_envasado = ConexionMysql.regresaCampoConsulta("SELECT id_envasado_entrada FROM  envasado_movimientos WHERE id_envasado_movimientos='" + id_envasado_movimientos + "' ");

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,id_env_mov_salio,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES ('" + id_max_envasado_movimientos + "','" + id_envasado + "','" + id_envasado_movimientos + "','" + no_cliente + "','cambio','" + CmbIngreso.Text + "'," + TxtBotellas.Text + "," + TxtBotellas.Text + ",0,0,now()," + Usuario.IdUsuario + ",0,'" + TxtObservacionesReproceso.Text + "')") == "Error")
                            {
                                return;
                            }
                        }///fin del else --

                    }// -- fin del else tipo de instalacion


                }// --- Fin del else if de CAMBIO

                else
                {  //-- Ingresa el tipo de cambio total.
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_entrada (id_envasado_entrada,id_marca,no_cliente,id_envasadora,fecha,no_lote,id_planta,id_predio,fq,clase,categoria,abocante,ingrediente,unidad_medida,contenido_por_botella,litros,grado_alcoholico,botellas,botellas_existentes,id_verificador,actualizado) VALUES ('" + id_max_envasado_entrada + "','" + CmbMarca.SelectedValue + "','" + no_cliente + "','" + id_envasadora + "',now(),'" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + CmbUnidadDeMedida.SelectedValue + "','" + CmbMedidaBotella.SelectedValue + "','" + litros + "','" + grado_alcoholico + "','" + TxtBotellas.Text + "','" + TxtBotellas.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                    {

                        return;

                    }
                    if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos set botellas_existentes=botellas_existentes-" + TxtBotellas.Text + ",actualizado=0 WHERE id_envasado_movimientos='" + id_envasado_movimientos + "' ") == "Error")
                    {
                        return;
                    }
                    /*if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,id_env_mov_salio,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES ('" + id_max_envasado_movimientos + "','" + id_envasado + "','" + id_envasado_movimientos + "','" + no_cliente + "','cambio','" + (CmbIngreso.Text == "Nacional" ? "Nacional" : "Exportacion") + "'," + TxtBotellas.Text + "," + TxtBotellas.Text + ",0,0,now()," + Usuario.IdUsuario + ",0,'" + TxtObservacionesReproceso.Text + "')") == "Error")
                    {
                        return;
                    }*/

                    if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,id_env_mov_salio,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES ('" + id_max_envasado_movimientos + "','" + id_max_envasado_entrada + "','" + id_envasado_movimientos + "','" + no_cliente + "','entrada','cambio " + CmbIngreso.Text + "'," + TxtBotellas.Text + "," + TxtBotellas.Text + ",0,0,now()," + Usuario.IdUsuario + ",0,'" + TxtObservacionesReproceso.Text + "')") == "Error")
                    {


                        return;
                    }


                }//-- FIN else



                ConexionMysql.transCompleta();

                MessageBox.Show("Éxito");
                this.Close();

            }
        }//------------------------- Fin Btnguardar ---------------------------------

        private void TxtBotellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            CmbMarca.Visible = false;
            CmbUnidadDeMedida.Visible = false;
            CmbMedidaBotella.Visible = false;

            CmbIngreso.Items.Clear();
            if (CmbTipo.Text == "Reenvasado")
            {
                //CmbIngreso.Items.Insert(0, "---Elije una opcion---");
                CmbIngreso.Items.Insert(0, "Granel de Envasado");
                CmbIngreso.SelectedIndex = 0;
            }
            else
            {
                CmbIngreso.Items.Insert(0, "---Elije una opcion---");
                //CmbIngreso.Items.Insert(1, "Total");
                CmbIngreso.Items.Insert(1, "Nacional");
                CmbIngreso.Items.Insert(2, "Exportacion");
                CmbIngreso.Items.Insert(3, "Promocion");
                //CmbIngreso.Items.Insert(3, "Tercerias");
                //CmbIngreso.Items.Insert(3, "---Elije una opcion---");
                CmbIngreso.SelectedIndex = 0;

            }
        }

        private void CmbIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbMarca.Visible = false;
            CmbUnidadDeMedida.Visible = false;
            CmbMedidaBotella.Visible = false;
            if (CmbIngreso.Text == "Total")
            {
                CmbMarca.Visible = true;
                CmbUnidadDeMedida.Visible = true;
                CmbMedidaBotella.Visible = true;
                CmbMarca.DataSource = null;

                //ConexionMysql.llenaCombo(ref CmbMarca, "SELECT id,marca FROM marcas  where no_cliente ='" + no_cliente + "'", "id", "marca");
                ConexionMysql.llenaCombo(ref CmbMarca, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id,marca FROM marcas  where no_cliente ='" + no_cliente + "'", "id", "marca");



                ConexionMysql.llenaCombo(ref CmbUnidadDeMedida, "SELECT   distinct medida FROM cat_presentacion", "medida", "medida");

                //ConexionMysql.llenaCombo(ref CmbUnidadDeMedida, "SELECT  distinct medida FROM cat_presentacion", "medida", "medida");

            }


        }

        private void CmbUnidadDeMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbMedidaBotella.DataSource = null;
            ConexionMysql.llenaCombo(ref CmbMedidaBotella, "SELECT cantidad FROM cat_presentacion  where medida ='" + CmbUnidadDeMedida.SelectedValue + "'", "cantidad", "cantidad");
        }

        private void CmbMedidaBotella_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbMedidaBotella.Text != "")
            {
                string medida = CmbMedidaBotella.Text;
                string cadena = calcula_botellas(Math.Round(double.Parse(litros), 2), medida).ToString();
                char delimiter = '.';
                string[] substrings = cadena.Split(delimiter);
                if (substrings.Length == 1)
                {
                    TxtBotellas.Text = substrings[0];
                    //TxtMerma.Text = "0 %";
                }
                else
                {
                    TxtBotellas.Text = substrings[0];
                    if (substrings[1].Length == 1)
                    {
                        //TxtMerma.Text = substrings[1] + " %";
                    }
                    else
                    {
                        //TxtMerma.Text = substrings[1].Substring(0, 2) + " %";
                    }
                }
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



        /* public double calcula_lts_botellas(double botellas, string medida, string contenido_por_botella)
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
             }*/








    }
}
