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

namespace Crm.Inventario
{
    public partial class FrmVerificarSolicitud : Form
    {
        public FrmVerificarSolicitud()
        {
            InitializeComponent();
        }

        public string no_cliente;
        int id_solicitud;
        public int tipo_dictaminacion;
        public int di_solicitud;
        public String codigo;
        public int caso;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {  
                String productor = "0";
                String envasador = "0";
                String comercializador = "0";
                String parcial = "0";
                if (cbFabrica.Checked) productor = "1";
                if (cbEnvasadora.Checked) envasador = "1";
                if (cbAlmacen.Checked) comercializador = "1";
                if (cbParcial.Checked) parcial = "1";

               // id_solicitud = int.Parse(ConexionMysql.regresaCampoConsulta("Select id_solicitud FROM sinca.di_solicitud WHERE di_solicitud='" + di_solicitud + "'"));

                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.sol_ocui SET parcial='" + parcial + "'  WHERE id_solicitud='" + id_solicitud + "'") == "Error")
                {
                    return;
                }

                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET productor='" + productor + "', envasador='" + envasador + "', comercializador='" + comercializador + "', parcial='" + parcial + "'  WHERE id='" + di_solicitud + "'") == "Error")
                {
                    return;
                }
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                ConexionMysql.transCompleta();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void FrmVerificarSolicitud_Load(object sender, EventArgs e)
        {
            try
            {
                id_solicitud = int.Parse(ConexionMysql.regresaCampoConsulta("Select id_solicitud FROM sinca.di_solicitud WHERE id='" + di_solicitud + "'"));           
                String productor = ConexionMysql.regresaCampoConsulta("Select productor FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String envasador = ConexionMysql.regresaCampoConsulta("Select envasador FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String comercializador = ConexionMysql.regresaCampoConsulta("Select comercializador FROM sinca.`di_solicitud` WHERE id='" + di_solicitud + "'");
                String parcial = ConexionMysql.regresaCampoConsulta("Select parcial FROM sinca.`sol_ocui` WHERE id_solicitud='" + id_solicitud + "'");

                if (productor =="1") cbFabrica.Checked = true;
                if (envasador == "1") cbEnvasadora.Checked = true;
                if (comercializador == "1") cbAlmacen.Checked = true;
                if (parcial == "1") cbParcial.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
