using Crm.Utilerias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crm.Inventario.Obsevaciones
{
    public partial class Observaciones : Form
    {
        public Observaciones()
        {
            InitializeComponent();
        }

        string id_max_observaciones;
        public string id_produccion = "";

        private void button1_Click(object sender, EventArgs e)
        {
            observaciones();
           
        }

        private void Observaciones_Load(object sender, EventArgs e)
        {
            string mensajes = "";

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT verificadores.nombre,observaciones.observaciones,DATE_FORMAT(observaciones.fecha, '%d/%m/%Y') as fecha from observaciones INNER JOIN verificadores ON observaciones.id_verificador=verificadores.id_us where id_movimiento='" + id_produccion + " ' ");
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                string nombre = row["nombre"].ToString();
                string mensaje = row["observaciones"].ToString();
                string fecha = row["fecha"].ToString();
                mensajes += System.Environment.NewLine + fecha + "  " + nombre + " :  " + mensaje + System.Environment.NewLine;
            }
            rtxObservacones.Text = mensajes;
            rtxObservacones.SelectionStart = rtxObservacones.Text.Length;
            rtxObservacones.ScrollToCaret();
        }


        public void ObtenerIdMaximoMensaje()
        {
            id_max_observaciones = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_observaciones,4)) )   FROM observaciones where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_observaciones == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_observaciones = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_observaciones = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_observaciones) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_observaciones = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_observaciones = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        public void observaciones() {

            if (txtObservacion.Text == "")
            {
                MessageBox.Show("Desbes ecribir un mensaje");
                txtObservacion.Focus();
                return;
            }
            ObtenerIdMaximoMensaje();
            if (ConexionMysql.insUpd_transaccion("INSERT INTO observaciones(id_observaciones,observaciones,  id_verificador, fecha,id_movimiento,actualizado) VALUES ('" + id_max_observaciones + "','" + txtObservacion.Text + "'," + Usuario.IdUsuario + ",now(),'" + id_produccion + "'" + ",0)") == "Error")
            {

                MessageBox.Show("INSERT INTO observaciones(id_observaciones,observaciones,  id_verificador, fecha,id_movimiento,actualizado) VALUES ('" + id_max_observaciones + "','" + txtObservacion.Text + "'," + Usuario.IdUsuario + ",now(),'" + id_produccion + "'" + ",0) == Error");

                return;
            }
            ConexionMysql.transCompleta();
            txtObservacion.Text = "";
            string mensajes = "";
            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT verificadores.nombre,observaciones.observaciones,DATE_FORMAT(observaciones.fecha, '%d/%m/%Y') as fecha from observaciones INNER JOIN verificadores ON observaciones.id_verificador=verificadores.id_us where id_movimiento='" + id_produccion + "'  ");



            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                string nombre = row["nombre"].ToString();
                string mensaje = row["observaciones"].ToString();
                string fecha = row["fecha"].ToString();
                mensajes += System.Environment.NewLine + fecha + "  " + nombre + " :  " + mensaje + System.Environment.NewLine;
            }
            rtxObservacones.Text = mensajes;
            rtxObservacones.SelectionStart = rtxObservacones.Text.Length;
            rtxObservacones.ScrollToCaret();
        
        }

    }
}
