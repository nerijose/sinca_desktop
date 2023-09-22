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
    public partial class FrmClienteMaquila : Form
    {
        public FrmClienteMaquila()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();
        Boolean bandera = false;
        public string no_cliente="";
        private void FrmClienteMaquila_Load(object sender, EventArgs e)
        {
            try
            {
            //llenamos los clientes para el envio de extraccion(quien recibe las extracciones) 
            AutoCompleteStringCollection ListaClientes = new AutoCompleteStringCollection();
            DataSet DatosClientes = new DataSet();
            ConexionMysql.llenaDataset(ref DatosClientes, "select no_cliente from clientes ");
            foreach (DataRow row in DatosClientes.Tables[0].Rows)
            {
                ListaClientes.Add(row[0].ToString());
            }
            TxtNoAsociado.AutoCompleteCustomSource = ListaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNoAsociado_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LblAsociado.Text = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM  clientes  WHERE no_cliente='" + TxtNoAsociado.Text + "'");
                    if (LblAsociado.Text == "")
                    {
                        MessageBox.Show("Numero de asociado no encontrado");
                        LblAsociado.Text = "......";
                        no_cliente = "";
                        bandera = false;
                    }
                    else
                    {
                        bandera = true;
               
                    }
                }
                else
                {
                    LblAsociado.Text = "......";
                    bandera = false;
                    no_cliente = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNoAsociado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida.soloNumeros(e);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bandera==false)
                {
                    MessageBox.Show("No has seleccionado ningun cliente");
                    return;
                }

                no_cliente = TxtNoAsociado.Text;
                MessageBox.Show("Asociado seleccionado");
                this.Close();

  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
