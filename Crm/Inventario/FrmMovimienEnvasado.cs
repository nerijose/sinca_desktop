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
    public partial class FrmMovimienEnvasado : Form
    {
        public FrmMovimienEnvasado()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();

        public string tipo_instalacion;
        public string id_envasado_entrada;
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
        string id_max_envasado_salida;
        string id_max_envasado_movimientos;

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

        //obtencion de los id para todas las entradas a almacen envasado 
        public void ObtenerIdMaximoAlmacenEnvasadoMovimientos()
        {
            id_max_almacen_envasado_movimientos = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_envasado_movimientos,4)) )   FROM almacen_envasado_movimientos where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_envasado_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_envasado_movimientos = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_envasado_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_envasado_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        private void FrmMovimienEnvasado_Load(object sender, EventArgs e)
        {
            ImgExportacion.Visible = false;
            ImgNacional.Visible = false;
            ImgPromocion.Visible = false;
            ImgReenvasado.Visible = false;
            imgSalida.Visible = false;


            lblObservaciones.Visible = false;
            txtTipoSalida.Visible = false;
            lbltiposalida.Visible = false;
            rchtxtObservaciones.Visible = false;

            if (tipo_instalacion == "almacen_envasado")
            {
                btnReenvasado.Enabled = false;
            }
            else
            {
                btnReenvasado.Enabled = true;
            }

        }

        private void BtnNacional_Click(object sender, EventArgs e)
        {
            ImgExportacion.Visible = false;
            ImgNacional.Visible = true;
            ImgPromocion.Visible = false;
            ImgReenvasado.Visible = false;
            imgSalida.Visible = false;
            LblTitulo.Text = "Nacional";
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

            label1.Enabled = true;
            label5.Enabled = true;
            TxtCajas.Enabled = true;
            TxtBotellasPorCaja.Enabled = true;
            TxtCajas.Text = "";
            TxtBotellasPorCaja.Text = "";

            lblObservaciones.Visible = false;
            txtTipoSalida.Visible = false;
            lbltiposalida.Visible = false;
            rchtxtObservaciones.Visible = false;
        }

        private void BtnExportacion_Click(object sender, EventArgs e)
        {
            ImgExportacion.Visible = true;
            ImgNacional.Visible = false;
            ImgPromocion.Visible = false;
            ImgReenvasado.Visible = false;
            imgSalida.Visible = false;
            LblTitulo.Text = "Exportación";
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

            label1.Enabled = true;
            label5.Enabled = true;
            TxtCajas.Enabled = true;
            TxtBotellasPorCaja.Enabled = true;
            TxtCajas.Text = "";
            TxtBotellasPorCaja.Text = "";

            lblObservaciones.Visible = false;
            txtTipoSalida.Visible = false;
            lbltiposalida.Visible = false;
            rchtxtObservaciones.Visible = false;
        }

        private void BtnPromocion_Click(object sender, EventArgs e)
        {
            ImgExportacion.Visible = false;
            ImgNacional.Visible = false;
            ImgPromocion.Visible = true;
            ImgReenvasado.Visible = false;
            imgSalida.Visible = false;
            LblTitulo.Text = "Promoción";
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

            label1.Enabled = true;
            label5.Enabled = true;
            TxtCajas.Enabled = true;
            TxtBotellasPorCaja.Enabled = true;
            TxtCajas.Text = "";
            TxtBotellasPorCaja.Text = "";

            lblObservaciones.Visible = false;
            txtTipoSalida.Visible = false;
            lbltiposalida.Visible = false;
            rchtxtObservaciones.Visible = false;

        }


        private void btnReenvasado_Click(object sender, EventArgs e)
        {
            ImgExportacion.Visible = false;
            ImgNacional.Visible = false;
            ImgPromocion.Visible = false;
            ImgReenvasado.Visible = true;
            imgSalida.Visible = false;
            LblTitulo.Text = "Reenvasado";
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

            label1.Enabled = false;
            label5.Enabled = false;
            TxtCajas.Enabled = false;
            TxtBotellasPorCaja.Enabled = false;
            TxtCajas.Text = "";
            TxtBotellasPorCaja.Text = "";

            lblObservaciones.Visible = false;
            txtTipoSalida.Visible = false;
            lbltiposalida.Visible = false;
            rchtxtObservaciones.Visible = false;
        }



        private void BtnGuardarSalida_Click_1(object sender, EventArgs e)
        {

            if (LblTitulo.Text == "...")
            {
                MessageBox.Show("Debe selecionar un tipo de destino");
                return;
            }


            if (TxtBotellas.Text == "")
            {
                MessageBox.Show("Debe introducir un numero de botellas");
                return;
            }
            if (LblTitulo.Text != "Reenvasado")
            {
                if (TxtCajas.Text == "")
                {
                    MessageBox.Show("Debe introducir un numero de cajas");
                    return;
                }
                if (TxtBotellasPorCaja.Text == "")
                {
                    MessageBox.Show("Debe introducir un numero de botellas por caja");
                    return;
                }




            } /// -- fin de   if (LblTitulo.Text != "Reenvasado")
            if (LblTitulo.Text == "Promoción")
            {
                if (int.Parse(TxtBotellas.Text) > 30)
                {
                    MessageBox.Show("No puedes sacar mas de 30 botellas para promoción");
                    return;
                }

            }
            if (int.Parse(TxtBotellas.Text) > int.Parse(LblBotellas.Text))
            {
                MessageBox.Show("Botellas insuficientes");
                return;
            }

            if (LblTitulo.Text == "Salida")
            {

                if (txtTipoSalida.Text == "")
                {
                    MessageBox.Show("Debe introducir un tipo de salida.");
                    return;
                }
                if (rchtxtObservaciones.Text == "")
                {
                    MessageBox.Show("el campo de observaciones esta vacio.");
                    return;
                }

            }




            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {

                if (tipo_instalacion == "almacen_envasado")
                {/// ---entra si la instalacion es de almacen envasado
                    /// 
                    if (LblTitulo.Text == "Salida")
                    {
                        ObtenerIdMaximoAlmacenEnvasadoMovimientos();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_movimientos(id_almacen_envasado_movimientos,id_almacen_envasado_entrada,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES('" + id_max_almacen_envasado_movimientos + "', '" + id_envasado_entrada + "','" + no_cliente + "','salida','" + txtTipoSalida.Text + "','" + TxtBotellas.Text + "','" + TxtBotellas.Text + "','" + TxtCajas.Text + "','" + TxtBotellasPorCaja.Text + "',now() , '" + Usuario.IdUsuario + "',0,'" + rchtxtObservaciones.Text + "')") == "Error")
                        {
                            return;
                        }

                    }
                    else
                    {
                        ObtenerIdMaximoAlmacenEnvasadoMovimientos();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_envasado_movimientos(id_almacen_envasado_movimientos,id_almacen_envasado_entrada,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado) VALUES('" + id_max_almacen_envasado_movimientos + "', '" + id_envasado_entrada + "','" + no_cliente + "','salida','" + LblTitulo.Text + "','" + TxtBotellas.Text + "','" + TxtBotellas.Text + "','" + TxtCajas.Text + "','" + TxtBotellasPorCaja.Text + "',now() , '" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }

                    }// -- fin else 
                    if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_entrada SET botellas_existentes=botellas_existentes-" + TxtBotellas.Text + ", actualizado=0 where id_almacen_envasado_entrada='" + id_envasado_entrada + "'") == "Error")
                    {
                        return;
                    }
                }
                else
                {

                    if (LblTitulo.Text == "Salida")
                    {
                        ObtenerIdMaximoEnvasadoMovimientos();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado,observaciones) VALUES('" + id_max_envasado_movimientos + "', '" + id_envasado_entrada + "','" + no_cliente + "','salida','" + txtTipoSalida.Text + "','" + TxtBotellas.Text + "','" + TxtBotellas.Text + "','" + TxtCajas.Text + "','" + TxtBotellasPorCaja.Text + "',now() , '" + Usuario.IdUsuario + "',0,'" + rchtxtObservaciones.Text + "')") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET botellas_existentes=botellas_existentes-" + TxtBotellas.Text + ", actualizado=0 where id_envasado_entrada='" + id_envasado_entrada + "'") == "Error")
                        {
                            return;
                        }

                    }
                    else if (LblTitulo.Text != "Reenvasado")
                    {

                        ObtenerIdMaximoEnvasadoMovimientos();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasado_movimientos(id_envasado_movimientos,id_envasado_entrada,no_cliente,tipo,destino,botellas,botellas_existentes,cajas,botellas_por_cajas,fecha,id_verificador,actualizado) VALUES('" + id_max_envasado_movimientos + "', '" + id_envasado_entrada + "','" + no_cliente + "','salida','" + LblTitulo.Text + "','" + TxtBotellas.Text + "','" + TxtBotellas.Text + "','" + TxtCajas.Text + "','" + TxtBotellasPorCaja.Text + "',now() , '" + Usuario.IdUsuario + "',0)") == "Error")
                        {
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET botellas_existentes=botellas_existentes-" + TxtBotellas.Text + ", actualizado=0 where id_envasado_entrada='" + id_envasado_entrada + "'") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        ///-- obtiene el id del envasado tomando en cuenta que deriva de un movimiento -- 
                        // string id_envasado = ConexionMysql.regresaCampoConsulta("SELECT if (em2.id_env_mov_salio = '' OR em2.id_env_mov_salio IS NULL  ,em2.id_envasado_entrada ,(SELECT em.id_envasado_entrada FROM  envasado_movimientos em WHERE em.id_envasado_movimientos=em2.id_env_mov_salio)) as id_envasado_entrada  FROM  envasado_movimientos em2 WHERE em2.id_envasado_movimientos='" + id_envasado_movimientos + "' ");

                        ///--- obtiene el id del lote de envasado tomando en cuenta que puede proceder de algun lote de envasado no terminado
                        string id_entrada_envasado = ConexionMysql.regresaCampoConsulta("SELECT if (em2.id_envasado_entrada_salio = '' OR em2.id_envasado_entrada_salio IS NULL ,em2.id_envasado_entrada ,(SELECT em.id_envasado_entrada FROM  envasado_entrada em WHERE em.id_envasado_entrada=em2.id_envasado_entrada_salio)) as id_envasado_entrada FROM envasado_entrada em2 WHERE em2.id_envasado_entrada='" + id_envasado_entrada + "' ");


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
                        if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET botellas_existentes=ROUND(botellas_existentes-" + TxtBotellas.Text + ",2), actualizado=0 WHERE id_envasado_entrada='" + id_envasado_entrada + "'") == "Error")
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





                        id_max_envasado_salida = IdMaximo.ObtenerIdMaximoEnvasadoSalida();

                        ///--- registra el movimiento de salida del lote de envasado a reproceso
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO envasado_salida  (id_envasado_salida, id_envasado_entrada,id_granel_entrada_envasado, litros, botellas, grado_alcoholico,tipo_salida, id_verificador, actualizado) values('" + id_max_envasado_salida + "','" + id_entrada_envasado + "','" + id_granel_entrada_envasado + "',ROUND(" + ltspor_restar + ",2)," + TxtBotellas.Text + "," + grado_alcoholico + ",'Reenvasado'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }




                    }

                }/// --- fin del else





                ConexionMysql.transCompleta();

                MessageBox.Show("Éxito");
                this.Close();
            }
        }

        private void TxtBotellas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtBotellasPorCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtCajas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void BtnSalida_Click(object sender, EventArgs e)
        {

            // crecar bien que procede con este --
            ImgExportacion.Visible = false;
            ImgNacional.Visible = false;
            ImgPromocion.Visible = false;
            ImgReenvasado.Visible = false;
            imgSalida.Visible = true;
            LblTitulo.Text = "Salida";
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

            label1.Enabled = true;
            label5.Enabled = true;
            TxtCajas.Enabled = false;
            TxtCajas.Text = "0";
            TxtBotellasPorCaja.Enabled = false;
            TxtBotellasPorCaja.Text = "0";


            lblObservaciones.Visible = true;
            txtTipoSalida.Visible = true;
            lbltiposalida.Visible = true;
            rchtxtObservaciones.Visible = true;




        }







    }
}
