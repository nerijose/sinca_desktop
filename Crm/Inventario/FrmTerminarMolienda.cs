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
    public partial class FrmTerminarMolienda : Form
    {
        public FrmTerminarMolienda()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();
        public string id_produccion = "";
        public string fecha_fin_molienda = "";
        public string fecha_inicio_molienda = "";
        public string fecha_inicio_formulacion = "";
        public string art = "";
        private void FrmTerminarMolienda_Load(object sender, EventArgs e)
        {
            if (art != "0")
            {
                TxtArt.Text = art;
                TxtArt.Enabled = false;
            }

            ChekMolienda.Checked = true;
            if (fecha_fin_molienda != "00/00/0000" && fecha_inicio_formulacion=="00/00/0000")
            {
                DateTime fecha_fin = Convert.ToDateTime(fecha_fin_molienda);
                ChekMolienda.Checked = false;
                ChekMolienda.Enabled = false;
                DataTimeFinalMolienda.Value = fecha_fin;
                ChekFormulacion.Checked = true;
                DataTimeFinalMolienda.Enabled = false;
       
            }
            else if (fecha_fin_molienda == "00/00/0000" && fecha_inicio_formulacion != "00/00/0000")
            {
                DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_formulacion);
                DataTimeInicioFormulacion.Value = fecha_inicio;
                ChekFormulacion.Enabled = false;
                DataTimeInicioFormulacion.Enabled = false;
            }
            else
            {
                DataTimeInicioFormulacion.Enabled = false;
              
            }
        }

        private void ChekFormulacion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChekFormulacion.Checked == true)
                {
                    DataTimeInicioFormulacion.Enabled = true;
                }
                else
                {
                    DataTimeInicioFormulacion.Enabled = false;
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

                if (ChekMolienda.Checked == true && ChekFormulacion.Checked == false)
                    {
                        DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_molienda);
                        int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeFinalMolienda.Value);

                        if (ResComparacionFechas > 0)
                        {
                            MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la molienda");
                            return;
                        }
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_molienda_fin='" + DataTimeFinalMolienda.Value.ToString("yyyy-MM-dd") + "',actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }

                    /*==== Es para la insercion de los registros del movimiento que realiza el usuario con este registro */
                       /* if (ConexionMysql.insUpd_transaccion(" INSERT INTO registro_movimientos_produccion(id_lote,bandera,fecha_registro_mov,operacion,actualizado) VALUES ('"+id_produccion+"','MOLIENDA',NOW(),'',0);UPDATE produccion_entrada SET periodo_molienda_fin='" + DataTimeFinalMolienda.Value.ToString("yyyy-MM-dd") + "',actualizado=0  where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }*/



                        ConexionMysql.transCompleta();
                        MessageBox.Show("Molienda finalizada");
                        this.Close();
                     }

                else if (ChekMolienda.Checked == false && ChekFormulacion.Checked == true)
                {
                    DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_molienda);
                    int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeInicioFormulacion.Value);

                    if (ResComparacionFechas > 0)
                    {
                        MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la molienda");
                        return;
                    }
                    if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET  periodo_formulacion_inicio='" + DataTimeInicioFormulacion.Value.ToString("yyyy-MM-dd") + "', estatus=3,actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                    {
                        return;
                    }
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Formulación inicializada");
                    this.Close();
                }

                else if (ChekMolienda.Checked == true && ChekFormulacion.Checked == true)
                {
       
                        DateTime fecha_inicio = Convert.ToDateTime(fecha_inicio_molienda);

                        int ResComparacionFechas = DateTime.Compare(fecha_inicio, DataTimeInicioFormulacion.Value);
                        int ResComparacionFechas2 = DateTime.Compare(fecha_inicio, DataTimeFinalMolienda.Value);

                        if (ResComparacionFechas > 0)
                        {
                            MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la molienda (Inicio formulación)");
                            return;
                        }
                        if (ResComparacionFechas2 > 0)
                        {
                            MessageBox.Show("No puedes seleccionar una fecha anterior a la del inicio de la molienda (Final Molienda)");
                            return;
                        }
     
                        if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_molienda_fin='" + DataTimeFinalMolienda.Value.ToString("yyyy-MM-dd") + "',  periodo_formulacion_inicio='" + DataTimeInicioFormulacion.Value.ToString("yyyy-MM-dd") + "', estatus=3,actualizado=0 where id_produccion_entrada='" + id_produccion + "'") == "Error")
                        {
                            return;
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("Molienda finalizada y Formulacion inicializada");
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

        private void ChekMolienda_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChekMolienda.Checked == true)
                {
                    DataTimeFinalMolienda.Enabled = true;
                }
                else
                {
                    DataTimeFinalMolienda.Enabled = false;
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
    }
}
