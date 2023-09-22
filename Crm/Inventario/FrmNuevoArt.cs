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
    public partial class FrmNuevoArt : Form
    {
        public FrmNuevoArt()
        {
            InitializeComponent();
        }

        Validacion valida = new Validacion();
        public string id;

        private void FrmNuevoArt_Load(object sender, EventArgs e)
        {

        }

        private void TxtArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e,TxtArt.Text);
        }

        private void BtnGuardarGranel_Click(object sender, EventArgs e)
        {
            if(TxtArt.Text=="")
            {
                MessageBox.Show("Debe introducir un %art");
                TxtArt.Focus();
                return;
            }
            if(TxtArt.Text=="0")
            {
                MessageBox.Show("Debe introducir un %art diferente de 0");
                TxtArt.Focus();
                return;
            }
           if(TxtArt.Text==".")
            {
                MessageBox.Show("Debe introducir un %art real");
                TxtArt.Focus();
                return;
            }

               if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET porcentaje_art=" + TxtArt.Text + ",actualizado=0 WHERE id_produccion_entrada='" + id + "' ") == "Error")
                   {
                       return;
                   }
                      
                ConexionMysql.transCompleta();
                MessageBox.Show("Éxito");
                this.Close();
        }
    }
}
