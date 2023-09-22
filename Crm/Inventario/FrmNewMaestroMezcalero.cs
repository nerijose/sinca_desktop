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
    public partial class FrmNewMaestroMezcalero : Form
    {
        public FrmNewMaestroMezcalero()
        {
            InitializeComponent();
        }



        public string no_cliente;
        public string id_fabrica;
        public string id_maestro_mezcalero_actual_prod;


        private void FrmNewMaestroMezcalero_Load(object sender, EventArgs e)
        {
            lblNocliente.Text = no_cliente;


            lblFabrica.Text = ConexionMysql.regresaCampoConsulta("SELECT fabrica FROM maestro_fabrica where id_fabrica='" + id_fabrica + "'AND no_cliente='" + no_cliente + "';");




        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtMaestro.Text == "")
                {
                    MessageBox.Show("Ingresa el nombre del maestro mezcalero");
                    TxtMaestro.Focus();
                    return;
                }

                string id_max_maestros_mezcaleros = IdMaximo.ObtenerIdMaximoMaestroMezcalero();

                if (ConexionMysql.insUpd_transaccion("UPDATE maestros_mezcaleros SET activo=0, actualizado=0 WHERE id_fabrica='" + id_fabrica + "' AND id_maestros_mezcaleros='" + id_maestro_mezcalero_actual_prod + "' ;") == "Error")
                {
                    return;
                }

                if (ConexionMysql.insUpd_transaccion("INSERT INTO maestros_mezcaleros(id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha, activo,actualizado) VALUES ('" + id_max_maestros_mezcaleros + "','" + TxtMaestro.Text + "','" + id_fabrica + "'," + Usuario.IdUsuario + ",now(),1,0);") == "Error")
                {
                    return;
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

    }
}
