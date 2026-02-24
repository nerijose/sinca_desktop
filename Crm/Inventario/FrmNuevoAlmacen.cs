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
    public partial class FrmNuevoAlmacen : Form
    {
        public FrmNuevoAlmacen()
        {
            InitializeComponent();
        }


        public string no_cliente;
        string id_max_almacen;
       public string tipo_bodega;


        //obtencion de los id para todas las fabricas 
        public void ObtenerIdMaximoBodega()
        {
            id_max_almacen = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen,4)) )   FROM almacen_encargado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void FrmNuevaAlmacen_Load(object sender, EventArgs e)
        {
            /* CmbEstado.Items.Insert(0, "CIUDAD DE MÉXICO");
             CmbEstado.Items.Insert(1, "DURANGO");
             CmbEstado.Items.Insert(2, "ESTADO DE MÉXICO");
             CmbEstado.Items.Insert(3, "GUERRERO");
             CmbEstado.Items.Insert(4, "GUANAJUATO");
             CmbEstado.Items.Insert(5, "MICHOACÁN");
             CmbEstado.Items.Insert(6, "OAXACA");
             CmbEstado.Items.Insert(7, "PUEBLA");
             CmbEstado.Items.Insert(8, "SAN LUIS POTOSÍ");
             CmbEstado.Items.Insert(9, "TAMAULIPAS");
             CmbEstado.Items.Insert(10, "ZACATECAS");*/

            //ConexionMysql.llenaCombo(ref CmbEstado, "SELECT clave, nombre FROM estados", "clave", "nombre");
            ConexionMysql.llenaComboAutocomplit(ref CmbEstado, "SELECT clave, nombre FROM estados WHERE dom = '1' ", "clave", "nombre");

        }
        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConexionMysql.llenaComboAutocomplit(ref cmbMunicipio, "SELECT clave,nombre FROM municipios where estado='" + CmbEstado.SelectedValue + "'", "clave", "nombre");

        }
          


        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (txtNuevaBodega.Text == "")
            {
                MessageBox.Show("Ingrese una Almacen");
                txtNuevaBodega.Focus();
                return;
            }
            if (txtResponsableBodega.Text == "")
            {
                MessageBox.Show("Ingrese un responsable");
                txtResponsableBodega.Focus();
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


            ObtenerIdMaximoBodega();
            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_encargado(no_cliente,encargado,id_almacen,almacen,folio_unico_granel,estado,municipio,localidad,id_verificador,tipo_almacen) VALUES('" + no_cliente + "' ,'" + txtResponsableBodega.Text + "','" + id_max_almacen + "','" + txtNuevaBodega.Text + "','" + txtFolioUnicoGranel.Text + "','" + CmbEstado.Text + "','" + cmbMunicipio.Text + "','" + txtLocalidad.Text + "'," + Usuario.IdUsuario + "," + tipo_bodega + ")") == "Error")
            {
                return;
            }
            ConexionMysql.transCompleta();
            MessageBox.Show("Bodega guardada con exito");
            this.Close();
        }

       
         



    }
}
