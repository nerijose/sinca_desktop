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
    public partial class FrmNuevaEnvasadora : Form
    {
        public FrmNuevaEnvasadora()
        {
            InitializeComponent();
        }

        public string no_cliente;
        string id_max_envasadora;


        //obtencion de los id para todas las fabricas 
        public void ObtenerIdMaximoEnvasadora()
        {
            id_max_envasadora = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasadora,4)) )   FROM envasadora_encargado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasadora == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasadora = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasadora = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasadora) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasadora = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasadora = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void FrmNuevaEnvasadora_Load(object sender, EventArgs e)
        {
            CmbEstado.Items.Insert(0, "CIUDAD DE MÉXICO");
            CmbEstado.Items.Insert(1, "DURANGO");
            CmbEstado.Items.Insert(2, "ESTADO DE MÉXICO");
            CmbEstado.Items.Insert(3, "GUERRERO");
            CmbEstado.Items.Insert(4, "GUANAJUATO");
            CmbEstado.Items.Insert(5, "MICHOACÁN");
            CmbEstado.Items.Insert(6, "OAXACA");
            CmbEstado.Items.Insert(7, "PUEBLA");
            CmbEstado.Items.Insert(8, "SAN LUIS POTOSÍ");
            CmbEstado.Items.Insert(9, "TAMAULIPAS");
            CmbEstado.Items.Insert(10,"ZACATECAS");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            int EnvasadoraExterna = 0;
            if (chkEnvasadoraExterna.Checked == true)
            {
                EnvasadoraExterna = 1;
            }
            else
            {
                EnvasadoraExterna = 0;
            }


            if (TxtEnvasadora.Text == "")
            {
                MessageBox.Show("Ingrese una envasadora");
                TxtEnvasadora.Focus();
                return;
            }
            if (TxtResponsable.Text == "")
            {
                MessageBox.Show("Ingrese un responsable");
                TxtResponsable.Focus();
                return;
            }
            if (CmbEstado.Text == "")
            {
                MessageBox.Show("Debe seleccionar un estado");
                return;
            }


            /*if (txtFolioUnicoGranel.Text == "")
            {
                MessageBox.Show("Ingrese un numero de folio");
                return;
            }*/
            if (txtLocalidad.Text == "")
            {
                MessageBox.Show("Ingrese una localidad");
                return;
            }

            ObtenerIdMaximoEnvasadora();
            //MessageBox.Show(EnvasadoraExterna.ToString()) ;
            //return;
            if (ConexionMysql.insUpd_transaccion("INSERT INTO  envasadora_encargado(no_cliente,encargado,id_envasadora,envasadora,folio_unico_granel,estado,municipio,localidad,envasadora_externa,id_verificador) VALUES('" + no_cliente + "' ,'" + TxtResponsable.Text + "','" + id_max_envasadora + "','" + TxtEnvasadora.Text + "','" + txtFolioUnicoGranel.Text + "','" + CmbEstado.Text + "','" + cmbMunicipio.Text + "','" +txtLocalidad.Text +"'," + EnvasadoraExterna + "," + Usuario.IdUsuario + ")") == "Error")
            {
                return;
            }
            ConexionMysql.transCompleta();
            MessageBox.Show("Envasadora guardada");
            this.Close();
        }

        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clave_estado = ConexionMysql.regresaCampoConsulta("SELECT clave FROM estados where nombre='" + CmbEstado.Text + "'");

            ConexionMysql.llenaComboAutocomplit(ref cmbMunicipio, "SELECT clave,nombre FROM municipios where estado='" + clave_estado + "'", "clave", "nombre");
        }
    }
}
