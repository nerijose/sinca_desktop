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
    public partial class FrmTerminarFormulacion : Form
    {
        public FrmTerminarFormulacion()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();
        public string id_produccion = "";
        public string fecha_fin_formulacion = "";
        public string fecha_inicio_formulacion = "";
        public string fecha_inicio_destilacion = "";
        public string volumen = "";
        public string fermentacion = "";
        public string art = "";

        private void FrmTerminarFormulacion_Load(object sender, EventArgs e)
        {
            if (art != "0")
            {
                TxtArt.Text = art;
                TxtArt.Enabled = false;
            }
            ChekFermentacion.Checked = true;

            if (fecha_fin_formulacion != "00/00/0000" && fecha_inicio_destilacion=="00/00/0000")
            {
                DateTime fecha_fin = Convert.ToDateTime(fecha_fin_formulacion);
                DataTimeFinalFormulacion.Value = fecha_fin;
                DataTimeFinalFormulacion.Enabled = false;
                TxtVolumen.Text = volumen;
                TxtVolumen.Enabled = false;                          
                CmbFermentacion.Enabled = false;
                CmbFermentacion.Text = fermentacion;
                ChekFermentacion.Checked = false;
                ChekFermentacion.Enabled = false;
                ChekDestilacion.Checked = true;
                ConexionMysql.llenaCombo(ref CmbTipoDestilacion, "SELECT id_destilacion,destilacion FROM cat_destilacion where destilacion not like '%borro-%'", "id_destilacion", "destilacion");
            }
            else if (fecha_fin_formulacion == "00/00/0000" && fecha_inicio_destilacion != "00/00/0000")
            {
                DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_destilacion);
                DataTimeInicioDestilacion.Value = fecha_inicio;
                DataTimeInicioDestilacion.Enabled = false;
                CmbTipoDestilacion.Enabled = false;
                ChekDestilacion.Checked = false;
                ChekDestilacion.Enabled = false;
                if (fermentacion == "")
                {
                    CmbFermentacion.Enabled = true;
                    ConexionMysql.llenaCombo(ref CmbFermentacion, "SELECT id_fermentacion,fermentacion FROM cat_fermentacion", "id_fermentacion", "fermentacion");
                }
                else
                {
                    CmbFermentacion.Enabled = false;
                    CmbFermentacion.Text = fermentacion;
                }
            }
            else
            {
                CmbTipoDestilacion.Enabled = false;
                DataTimeInicioDestilacion.Enabled = false;
                ConexionMysql.llenaCombo(ref CmbFermentacion, "SELECT id_fermentacion,fermentacion FROM cat_fermentacion", "id_fermentacion", "fermentacion");
            }
        }

        private void TxtVolumen_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtVolumen.Text);
        }

        private void ChekDestilacion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChekDestilacion.Checked == true)
                {
                    DataTimeInicioDestilacion.Enabled = true;
                    CmbTipoDestilacion.Enabled = true;
                    ConexionMysql.llenaCombo(ref CmbTipoDestilacion, "SELECT id_destilacion,destilacion FROM cat_destilacion where destilacion not like '%borro-%'", "id_destilacion", "destilacion");
                }
                else
                {
                    DataTimeInicioDestilacion.Enabled = false;
                    CmbTipoDestilacion.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

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
                if (art == "0")
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET porcentaje_art=" + TxtArt.Text + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                    {
                        return;
                    }
                }
                if (ChekFermentacion.Checked==true &&  ChekDestilacion.Checked == false)
                {         
                        DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_formulacion);
                        int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeFinalFormulacion.Value);

                        if (ResComparacionFechas > 0)
                        {
                            MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la formulación");
                            return;
                        }
                        if (fecha_inicio_destilacion == "00/00/0000")
                        {
                            if (CmbFermentacion.SelectedValue == null)
                            {
                                MessageBox.Show("No tienes tipos de fermentación precargadas, actualiza la base de datos");
                                return;
                            }
                            if (TxtVolumen.Text == "")
                            {
                                MessageBox.Show("Introduce el volumen total");
                                return;
                            }
                            if (TxtVolumen.Text == ".")
                            {
                                MessageBox.Show("Introduce una cantidad real");
                                return;
                            }

                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_formulacion_fin='" + DataTimeFinalFormulacion.Value.ToString("yyyy-MM-dd") + "',volumen_mosto='" + TxtVolumen.Text + "',id_fermentacion=" + CmbFermentacion.SelectedValue + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (TxtVolumen.Text == "")
                            {
                                MessageBox.Show("Introduce el volumen total");
                                return;
                            }
                            if (TxtVolumen.Text == ".")
                            {
                                MessageBox.Show("Introduce una cantidad real");
                                return;
                            }

                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_formulacion_fin='" + DataTimeFinalFormulacion.Value.ToString("yyyy-MM-dd") + "',volumen_mosto='" + TxtVolumen.Text + "',actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                            {
                                return;
                            }

                        }

                        ConexionMysql.transCompleta();
                        MessageBox.Show("Formulación finalizada");
                        this.Close();
              
                }
                else if (ChekFermentacion.Checked == false && ChekDestilacion.Checked == true)
                {
                       if (fecha_fin_formulacion == "00/00/0000")
                       {
                        if (CmbFermentacion.SelectedValue == null)
                        {
                            MessageBox.Show("No tienes tipos de fermentación precargadas, actualiza la base de datos");
                            return;
                        }

                       }
                        if (CmbTipoDestilacion.SelectedValue == null)
                        {
                            MessageBox.Show("No tienes tipos de destilación precargadas, actualiza la base de datos");
                            return;
                        }
                        if (fecha_fin_formulacion == "00/00/0000")
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET  periodo_destilacion_inicio='" + DataTimeInicioDestilacion.Value.ToString("yyyy-MM-dd") + "', estatus=4, id_destilacion=" + CmbTipoDestilacion.SelectedValue + ",id_fermentacion=" + CmbFermentacion.SelectedValue + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                            {
                                return;
                            }

                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET  periodo_destilacion_inicio='" + DataTimeInicioDestilacion.Value.ToString("yyyy-MM-dd") + "', estatus=4, id_destilacion=" + CmbTipoDestilacion.SelectedValue + ",actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }


                        ConexionMysql.transCompleta();
                        MessageBox.Show("Destilación inicializada");
                        this.Close();
                   }
                else if (ChekFermentacion.Checked == true && ChekDestilacion.Checked == true)
                    {
                        DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_formulacion);
                        int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeFinalFormulacion.Value);

                        int ResComparacionFechas2 = DateTime.Compare(fecha_inicio, DataTimeInicioDestilacion.Value);

                        if (ResComparacionFechas > 0)
                        {
                            MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la formulación(Formulación)");
                            return;
                        }
                        if (ResComparacionFechas2 > 0)
                        {
                            MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la formulación(Destilación)");
                            return;
                        }
                        if (CmbFermentacion.SelectedValue == null)
                        {
                            MessageBox.Show("No tienes tipos de fermentación precargadas, actualiza la base de datos");
                            return;
                        }

                        if (TxtVolumen.Text == "")
                        {
                            MessageBox.Show("Introduce el volumen total");
                            return;
                        }

                        if (TxtVolumen.Text == ".")
                        {
                            MessageBox.Show("Introduce una cantidad real");
                            return;
                        }
                        if (CmbTipoDestilacion.SelectedValue == null)
                        {
                            MessageBox.Show("No tienes tipos de destilación precargadas, actualiza la base de datos");
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_formulacion_fin='" + DataTimeFinalFormulacion.Value.ToString("yyyy-MM-dd") + "',  periodo_destilacion_inicio='" + DataTimeInicioDestilacion.Value.ToString("yyyy-MM-dd") + "', estatus=4,volumen_mosto='" + TxtVolumen.Text + "',id_fermentacion="+CmbFermentacion.SelectedValue+", id_destilacion="+CmbTipoDestilacion.SelectedValue+",actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("Formulación finalizada y Destilación inicializada");
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

        private void CmbMontera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChekFermentacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChekFermentacion.Checked == true)
                {
                    DataTimeFinalFormulacion.Enabled = true;
                    CmbFermentacion.Enabled = true;
                    TxtVolumen.Enabled = true;
                    if (fermentacion == "")
                    {
                        ConexionMysql.llenaCombo(ref CmbFermentacion, "SELECT id_fermentacion,fermentacion FROM cat_fermentacion", "id_fermentacion", "fermentacion");
                    }
                    else
                    {
                        CmbFermentacion.Enabled = false;
                    }
                }
                else
                {
                    DataTimeFinalFormulacion.Enabled = false;
                    CmbFermentacion.Enabled = true;
                    TxtVolumen.Enabled = false;
                    if (fermentacion == "")
                    {
                        ConexionMysql.llenaCombo(ref CmbFermentacion, "SELECT id_fermentacion,fermentacion FROM cat_fermentacion", "id_fermentacion", "fermentacion");
                    }
                    else
                    {
                        CmbFermentacion.Enabled = false;
                    }

                    
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      



    }
}
