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
    public partial class FrmNuevoMaestroFabrica : Form
    {
        public FrmNuevoMaestroFabrica()
        {
            InitializeComponent();
        }
        public string no_cliente;
        string id_max_fabrica;


        //obtencion de los id para todas las fabricas 
        public void ObtenerIdMaximoFabrica()
        {
            id_max_fabrica = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_fabrica,4)) )   FROM maestro_fabrica where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_fabrica == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_fabrica = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_fabrica = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_fabrica) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_fabrica = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_fabrica = Usuario.IdUsuario + "-" + suma;
                }
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (TxtFabrica.Text == "")
                {
                    MessageBox.Show("Ingrese una fabrica");
                    TxtFabrica.Focus();
                    return;
                }

                if (TxtMaestro.Text == "")
                {
                    MessageBox.Show("Ingrese un maestro mezcalero");
                    return;
                }

                if (CmbEstado.Text == "")
                {
                    MessageBox.Show("Debe seleccionar un estado");
                    return;
                }

                /* if (txtFolioUnicoGranel.Text == "")
                 {
                     MessageBox.Show("Ingrese un numero de folio");
                     return;
                 }*/
                if (txtLocalidad.Text == "")
                {
                    MessageBox.Show("Ingrese una localidad");
                    return;
                }

                ObtenerIdMaximoFabrica();
                if (ConexionMysql.insUpd_transaccion("INSERT INTO  maestro_fabrica(no_cliente,id_fabrica,fabrica,folio_unico_granel,estado,municipio,localidad,id_verificador) VALUES('" + no_cliente + "' ,'" + id_max_fabrica + "','" + TxtFabrica.Text + "','" + txtFolioUnicoGranel.Text + "','" + CmbEstado.Text + "','" + cmbMunicipio.Text + "','" + txtLocalidad.Text + "'," + Usuario.IdUsuario + ")") == "Error")
                {
                    return;
                }

                string id_max_maestro_mezcalero = IdMaximo.ObtenerIdMaximoMaestroMezcalero();

                if (ConexionMysql.insUpd_transaccion("INSERT INTO  maestros_mezcaleros(id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha,activo,actualizado) VALUES('" + id_max_maestro_mezcalero + "' ,'" + TxtMaestro.Text + "','" + id_max_fabrica + "'," + Usuario.IdUsuario + ",now(),1,0)") == "Error")
                {
                    return;
                }


                ConexionMysql.transCompleta();
                MessageBox.Show("Fabrica guardada");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void FrmNuevoMaestroFabrica_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Insert(0, "DURANGO");
            CmbEstado.Items.Insert(1, "GUERRERO");
            CmbEstado.Items.Insert(2, "GUANAJUATO");
            CmbEstado.Items.Insert(3, "MICHOACÁN");
            CmbEstado.Items.Insert(4, "OAXACA");
            CmbEstado.Items.Insert(5, "PUEBLA");
            CmbEstado.Items.Insert(6, "SAN LUIS POTOSÍ");
            CmbEstado.Items.Insert(7, "TAMAULIPAS");
            CmbEstado.Items.Insert(8, "ZACATECAS");
            /*
            CmbEstado.Items.Insert(0, "--Selecciona un estado -- ");
            CmbEstado.Items.Insert(10, "DURANGO");
            CmbEstado.Items.Insert(12, "GUERRERO");
            CmbEstado.Items.Insert(11, "GUANAJUATO");
            CmbEstado.Items.Insert(16, "MICHOACÁN");
            CmbEstado.Items.Insert(20, "OAXACA");
            CmbEstado.Items.Insert(21, "PUEBLA");
            CmbEstado.Items.Insert(20, "SAN LUIS POTOSÍ");
            CmbEstado.Items.Insert(28, "TAMAULIPAS");
            CmbEstado.Items.Insert(32, "ZACATECAS");*/
        }

        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            string clave_estado = ConexionMysql.regresaCampoConsulta("SELECT clave FROM estados where nombre='" + CmbEstado.Text + "'");

            ConexionMysql.llenaComboAutocomplit(ref cmbMunicipio, "SELECT clave,nombre FROM municipios where estado='" + clave_estado + "'", "clave", "nombre");
        }
    }
}
