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
    public partial class DatoMagueyGuiaAntigua : Form
    {
        public DatoMagueyGuiaAntigua()
        {
            InitializeComponent();
        }

        public string idTapada;

        string nombreMaguey = "";

        public void ObtenerMaguey()
        {
            nombreMaguey = ConexionMysql.regresaCampoConsulta("SELECT comun.nombre AS maguey FROM produccion_entrada LEFT JOIN reveca2_paraje ON produccion_entrada.id_predio = reveca2_paraje.id_paraje LEFT JOIN reveca2_existenciaplanta ON produccion_entrada.id_planta = reveca2_existenciaplanta.id_plantas LEFT JOIN comun ON reveca2_existenciaplanta.id_comun = comun.id_comun INNER JOIN cat_coccion ON produccion_entrada.id_coccion = cat_coccion.id_coccion LEFT JOIN (SELECT  produccion_ensamble.id_produccion_entrada, reveca2_paraje.paraje, comun.nombre AS maguey, produccion_ensamble.no_pinas_agave, produccion_ensamble.agave_kg, produccion_ensamble.agave_coccion_kg, produccion_ensamble.porcentaje_art FROM produccion_ensamble LEFT JOIN reveca2_paraje ON reveca2_paraje.id_paraje = produccion_ensamble.id_predio INNER JOIN reveca2_existenciaplanta ON produccion_ensamble.id_planta = reveca2_existenciaplanta.id_plantas INNER JOIN comun ON reveca2_existenciaplanta.id_comun = comun.id_comun) TABLA ON produccion_entrada.id_produccion_entrada = TABLA.id_produccion_entrada WHERE produccion_entrada.id_produccion_entrada = '" + idTapada + "'");
            txtDatoMagueyAntiguo.Text = nombreMaguey;
        }
    }
}
