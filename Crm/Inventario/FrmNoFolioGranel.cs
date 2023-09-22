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
    public partial class FrmNoFolioGranel : Form
    {


        public string tipo_instalacion;
        public string id_instalacion;
        public string no_cliente;

        public FrmNoFolioGranel()
        {
            InitializeComponent();


        }



       
        private void txtFolioUnicoGranel_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFolioUnicoGranel.Text == "")
                {
                    MessageBox.Show("ingresa el número de folio de granel");
                    return;
                }


                if (tipo_instalacion == "granel_fabrica")
                {

                    if(ConexionMysql.insUpd_transaccion("UPDATE maestro_fabrica SET folio_unico_granel='"+txtFolioUnicoGranel.Text+"' where id_fabrica='"+id_instalacion+"' and no_cliente='"+no_cliente+"';")=="Error"){
                        return;
                    }


                }
                else if (tipo_instalacion == "granel_envasado")
                {
                    if (ConexionMysql.insUpd_transaccion("UPDATE envasadora_encargado SET folio_unico_granel='" + txtFolioUnicoGranel.Text + "' where id_envasadora='" + id_instalacion + "' and no_cliente='" + no_cliente + "';") == "Error")
                    {

                        return;
                    }



                }


                ConexionMysql.transCompleta();
                MessageBox.Show("Éxito");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmNoFolioGranel_Load(object sender, EventArgs e)
        {

            try
            {

                lblNoCliente.Text = no_cliente;


                if (tipo_instalacion == "granel_fabrica")
                {

                    lblTituloFabrica.Visible = true;
                    lblTituloEnvasadora.Visible = false;

                    //string noFolioGranelUnico = ConexionMysql.regresaCampoConsulta("SELECT folio_unico_granel FROM maestro_fabrica  WHERE id_fabrica='" + CmbFabricaGranelFabrica.SelectedValue + "' AND no_cliente='" + CmbNoClienteGranel.SelectedValue + "';");
                    lblFabrica_Envasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT fabrica FROM maestro_fabrica where id_fabrica='" + id_instalacion + "'AND no_cliente='" + no_cliente + "';");
                }
                else
                {
                    lblTituloEnvasadora.Visible = true;
                    lblTituloFabrica.Visible = false;

                    lblFabrica_Envasadora.Text = ConexionMysql.regresaCampoConsulta("SELECT envasadora FROM envasadora_encargado where id_envasadora='" + id_instalacion + "'AND no_cliente='" + no_cliente + "';");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
