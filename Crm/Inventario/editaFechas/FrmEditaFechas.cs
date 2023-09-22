using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Crm.Utilerias;
using Crm.Inventario;

namespace Crm.Inventario.editaFechas
{
    public partial class FrmEditaFechas : Form
    {
        public FrmEditaFechas()
        {
            InitializeComponent();
        }

        public string id_produccion = "";
        public string id_tap = "";

        

        public void llenaCombo()
        {
            #region
            
            FrmInventario inv = new FrmInventario();
            if (id_tap == "Coccion")
            {
                cmbProcesosTapada.Items.Add("Coccion");
            }
            if (id_tap == "Molienda")
            {
                
                cmbProcesosTapada.Items.Add("Coccion");
                cmbProcesosTapada.Items.Add("Molienda");
            }
            if (id_tap == "Formulacion")
            {
                cmbProcesosTapada.Items.Add("Coccion");
                cmbProcesosTapada.Items.Add("Molienda");
                cmbProcesosTapada.Items.Add("Formulacion");
            }
            if (id_tap == "Destilacion")
            {
                cmbProcesosTapada.Items.Add("Coccion");
                cmbProcesosTapada.Items.Add("Molienda");
                cmbProcesosTapada.Items.Add("Formulacion");
                cmbProcesosTapada.Items.Add("Destilacion");
            }
            #endregion
        }

        private void cmbProcesosTapada_SelectedValueChanged(object sender, EventArgs e)
        {
            #region Consulta de fechas para llenado de DataTimePicker
            try
            {
                string etapaTapada = cmbProcesosTapada.SelectedItem.ToString();
                if (etapaTapada == "Coccion")
                {
                    dtpFF.Enabled = true;
                    lblMsjFechaFin.Visible = false;
                    lblFinicio.Text = "Fecha inicio de: " + etapaTapada;
                    lblFfin.Text = "Fecha final de: " + etapaTapada;
                    string FiCo = ConexionMysql.regresaCampoConsulta("select date_format(periodo_coccion_inicio, '%d/%m/%Y') as fechaIC FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    string FfCo = ConexionMysql.regresaCampoConsulta("select date_format(periodo_coccion_fin, '%d/%m/%Y') as fechaFC FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    dtpFI.Value = Convert.ToDateTime(FiCo);
                    if (FfCo == "00/00/0000")
                    {
                       // MessageBox.Show("Aún no hay una fecha final asignada, \n hazlo en el modulo correspondiente", "Atención");
                        lblMsjFechaFin.Visible = true;
                        lblMsjFechaFin.Text = "No se puede editar";
                        dtpFF.Enabled = false;
                    }
                    else
                        dtpFF.Value = Convert.ToDateTime(FfCo);

                }
                else if (etapaTapada == "Molienda")
                {
                    if (dtpFF.Enabled == false)
                    {
                        dtpFF.Enabled = true;
                    }
                    lblFinicio.Text = "Fecha inicio de: " + etapaTapada;
                    lblFfin.Text = "Fecha final de: " + etapaTapada;
                    string FiMo = ConexionMysql.regresaCampoConsulta("select date_format(periodo_molienda_inicio, '%d/%m/%Y') as fechaIM FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    string FfMo = ConexionMysql.regresaCampoConsulta("select date_format(periodo_molienda_fin, '%d/%m/%Y') as fechaFM FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    dtpFI.Value = Convert.ToDateTime(FiMo);
                    if (FfMo == "00/00/0000")
                    {
                        //MessageBox.Show("Aún no hay una fecha final asignada, \n hazlo en el modulo correspondiente", "Atención");
                        lblMsjFechaFin.Text = "No se puede editar";
                        dtpFF.Enabled = false;
                    }
                    else
                        dtpFF.Value = Convert.ToDateTime(FfMo);
                }
                else if (etapaTapada == "Formulacion")
                {
                    if (dtpFF.Enabled == false)
                    {
                        dtpFF.Enabled = true;
                    }
                    lblFinicio.Text = "Fecha inicio de: " + etapaTapada;
                    lblFfin.Text = "Fecha final de: " + etapaTapada;
                    string FiFo = ConexionMysql.regresaCampoConsulta("select date_format(periodo_formulacion_inicio, '%d/%m/%Y') as fechaIF FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    string FfFo = ConexionMysql.regresaCampoConsulta("select date_format(periodo_formulacion_fin, '%d/%m/%Y') as fechaFF FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    dtpFI.Value = Convert.ToDateTime(FiFo);
                    if (FfFo == "00/00/0000")
                    {
                       // MessageBox.Show("Aún no hay una fecha final asignada, \n hazlo en el modulo correspondiente", "Atención");
                        lblMsjFechaFin.Text = "No se puede editar";
                        dtpFF.Enabled = false;
                    }
                    else
                        dtpFF.Value = Convert.ToDateTime(FfFo);
                }
                else if (etapaTapada == "Destilacion")
                {
                    if (dtpFF.Enabled == false)
                    {
                        dtpFF.Enabled = true;
                    }
                    lblFinicio.Text = "Fecha inicio de: " + etapaTapada;
                    lblFfin.Text = "Fecha final de: " + etapaTapada;
                    string FiDe = ConexionMysql.regresaCampoConsulta("select date_format(periodo_destilacion_inicio, '%d/%m/%Y') as fechaID FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    string FfDe = ConexionMysql.regresaCampoConsulta("select date_format(periodo_destilacion_fin, '%d/%m/%Y') as fechaFD FROM produccion_entrada where id_produccion_entrada like" + "'" + id_produccion + "'");
                    dtpFI.Value = Convert.ToDateTime(FiDe);
                    if (FfDe == "00/00/0000")
                    {
                        // MessageBox.Show("Aún no hay una fecha final asignada, \n hazlo en el modulo correspondiente", "Atención");
                        lblMsjFechaFin.Text = "No se puede editar";
                        dtpFF.Enabled = false;
                    }
                    else
                        dtpFF.Value = Convert.ToDateTime(FfDe);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void btnNuevaFecha_Click(object sender, EventArgs e)
        {
            try
            {
                string etapaProduccion = cmbProcesosTapada.SelectedItem.ToString();
                switch (etapaProduccion)
                {
                    case "Coccion":
                        if (dtpFF.Enabled == true)
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_coccion_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                                "periodo_coccion_fin= '" + dtpFF.Value.ToString("yyyy-MM-dd") + "',actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_coccion_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                            "actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("La fecha fue cambiada exitosamente");
                        this.Close();
                        break;
                        
                        
                    case "Molienda":
                        if (dtpFF.Enabled == true)
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_molienda_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                                "periodo_molienda_fin= '" + dtpFF.Value.ToString("yyyy-MM-dd") + "',actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_molienda_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                            "actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("La fecha fue cambiada exitosamente");
                        this.Close();
                        break;

                    case "Formulacion":
                        if (dtpFF.Enabled == true)
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_formulacion_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                                "periodo_formulacion_fin= '" + dtpFF.Value.ToString("yyyy-MM-dd") + "',actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_formulacion_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                            "actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("La fecha fue cambiada exitosamente");
                        this.Close();
                        break;

                    case "Destilacion":
                        if (dtpFF.Enabled == true)
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_destilacion_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                                "periodo_destilacion_fin= '" + dtpFF.Value.ToString("yyyy-MM-dd") + "',actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET periodo_destilacion_inicio = '" + dtpFI.Value.ToString("yyyy-MM-dd") + "'," +
                            "actualizado= 0 where id_produccion_entrada = '" + id_produccion + "'") == "Error")
                            {
                                return;
                            }
                        }
                        ConexionMysql.transCompleta();
                        MessageBox.Show("La fecha fue cambiada exitosamente");
                        this.Close();
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
