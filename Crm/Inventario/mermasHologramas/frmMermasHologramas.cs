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
namespace Crm.Inventario.mermasHologramas
{
    public partial class frmMermasHologramas : Form
    {
        public frmMermasHologramas()
        {
            InitializeComponent();
            //txtClienteMerma.Text = "";
        }
        public string cliente = "";

        private void frmMermasHologramas_Load(object sender, EventArgs e)
        {
            txtClienteMerma.Text = cliente;
            ConexionMysql.llenaCombo(ref cmbMarcaMerma, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca FROM marcas  where no_cliente ='" + cliente + "'ORDER BY cve_marca ASC", "id", "marca");
            cmbMotivoMerma.Items.Insert(0, "Código no visible");
            cmbMotivoMerma.Items.Insert(1, "Sin código");
            cmbMotivoMerma.Items.Insert(2, "Se salta folios");
            cmbMotivoMerma.Items.Insert(3, "Desprendimiento de sellos");
        }
    }
}
