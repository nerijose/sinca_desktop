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

namespace Crm.Inventario.editar
{
    public partial class FrmCambioNombre : Form
    {


        public FrmCambioNombre()
        {
            InitializeComponent();

        }
        public string no_lote_actual, id_lote, tipo = "";

        string id_new_name, name_table, campo_id_granelF =  "";
        private void FrmCambioNombre_Load(object sender, EventArgs e)
        {

            if (tipo == "fabrica")
            {
                this.Text = "Granel Fabrica";
                name_table = "granel_entrada"; campo_id_granelF = "id_granel_entrada";

            }
            else if (tipo == "g_envasado")
             { this.Text = "Granel Envasado";
             name_table = "granel_entrada_envasado"; campo_id_granelF = "id_granel_entrada_envasado";
             }

            else if (tipo == "almacen")
            {
                this.Text = "Almacen Cambio de tanque";
                name_table = "almacen_granel_entrada"; campo_id_granelF = "id_almacen_granel_entrada";               
            }

            lblNoLoteActual.Text = no_lote_actual;


            




        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNuevoNoLote.Text == "")
            {

                MessageBox.Show("El campo 'Nuevo No de Lote' esta vacío ");
                return;

            }


            try
            {


                DialogResult check = MessageBox.Show("¿¡Seguro de guardar los cambios!?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (check == DialogResult.Cancel) { return; }
                else
                {
                   

                    if (ConexionMysql.insUpd_transaccion("UPDATE "+name_table+" SET no_lote ='" + txtNuevoNoLote.Text + "', actualizado=0 where "+campo_id_granelF+"='" + id_lote + "'") == "Error")
                    {
                        return;
                    }





                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();



                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
