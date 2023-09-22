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
    public partial class FrmMensajes : Form
    {
        public FrmMensajes()
        {
            InitializeComponent();
        }

        string id_max_mensaje;
        public string id_produccion;
        public string origen = "";


        public void ObtenerIdMaximoMensaje()
        {
            id_max_mensaje = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_mensaje,4)) )   FROM mensajes_registros where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_mensaje == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_mensaje = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_mensaje = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_mensaje) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_mensaje = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_mensaje = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void BtnGuardarMensaje_Click(object sender, EventArgs e)
        {
            if (TxtMensaje.Text == "")
            {
                MessageBox.Show("Desbes ecribir un mensaje");
                TxtMensaje.Focus();
                return;
            }

            ObtenerIdMaximoMensaje();
            if (ConexionMysql.insUpd_transaccion("INSERT INTO mensajes_registros(id_mensaje, id_registro, tipo, mensaje, fecha, id_verificador, actualizado) VALUES ('" + id_max_mensaje + "','" + id_produccion + "','produccion','" + TxtMensaje.Text + "',now()," + Usuario.IdUsuario + ",0)") == "Error")
            {
                return;
            }
            ConexionMysql.transCompleta();

            deleteProduction();//add delete production

            TxtMensaje.Text = "";
            string mensajes = "";
            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT verificadores.nombre,mensajes_registros.mensaje,DATE_FORMAT(mensajes_registros.fecha, '%d/%m/%Y') as fecha from mensajes_registros INNER JOIN verificadores ON mensajes_registros.id_verificador=verificadores.id_us where id_registro='" + id_produccion + "'  ");
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                string nombre = row["nombre"].ToString();
                string mensaje = row["mensaje"].ToString();
                string fecha = row["fecha"].ToString();
                mensajes += System.Environment.NewLine + fecha + "  " + nombre + " :  " + mensaje + System.Environment.NewLine;
            }
            TxtMensajes.Text = mensajes;
            TxtMensajes.SelectionStart = TxtMensajes.Text.Length;
            TxtMensajes.ScrollToCaret();
        }

        private void FrmMensajes_Load(object sender, EventArgs e)
        {
            string mensajes = "";

            validaOrigen();

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT verificadores.nombre,mensajes_registros.mensaje,DATE_FORMAT(mensajes_registros.fecha, '%d/%m/%Y') as fecha from mensajes_registros INNER JOIN verificadores ON mensajes_registros.id_verificador=verificadores.id_us where id_registro='" + id_produccion + "'  and tipo='produccion'  ");
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                string nombre = row["nombre"].ToString();
                string mensaje = row["mensaje"].ToString();
                string fecha = row["fecha"].ToString();
                mensajes += System.Environment.NewLine + fecha + "  " + nombre + " :  " + mensaje + System.Environment.NewLine;
            }
            TxtMensajes.Text = mensajes;
            TxtMensajes.SelectionStart = TxtMensajes.Text.Length;
            TxtMensajes.ScrollToCaret();
        }

        private void validaOrigen()
        {
            if(origen == "produccion")
            {
                chkDeleteProduction.Visible = true;
            }
            else
            {
                chkDeleteProduction.Visible = false;
            }
        }

        private void deleteProduction()
        {
            if (chkDeleteProduction.Checked == true)
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE  produccion_entrada SET  no_cliente= CONCAT(no_cliente, '-del'),id_fabrica= CONCAT(id_fabrica, '-del'),id_maestro_mezcalero= CONCAT(id_maestro_mezcalero,'-del'),actualizado=0 " +
                    "WHERE id_produccion_entrada='" + id_produccion + "' ") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                this.Close();
                MessageBox.Show("¡La producción se quitó con éxito!","ATENCIÓN",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            
        }
    }
}
