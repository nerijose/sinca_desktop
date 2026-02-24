using Crm.Utilerias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crm.Inventario
{
    public partial class FrmCierreActaDetallado : Form
    {
        public FrmCierreActaDetallado()
        {
            InitializeComponent();
        }

        public string no_cliente;
        public string id_solicitud;
        public int tipo_dictaminacion;
        public int di_solicitud;
        public String codigo;
        string acta = "";
        DataSet dtsDatosGranel, dtsDatosGranelProceso, dtsProduccion, dtsGranelEnvasado, dtsGranelEnvasadoProceso, dtsTerminado, dtsNoTerminado,dtsMaduracion;
        private void FrmCierreActaDetallado_Load(object sender, EventArgs e)
        {
            if (di_solicitud == 0)
            {
                di_solicitud = int.Parse(ConexionMysql.regresaCampoConsulta("Select id FROM sinca.`di_solicitud` WHERE codigo='" + codigo + "'"));
            }
            cargar_generales();

            cargar_granel();
            cargar_granel_proceso();
            cargar_produccion();
            cargar_granel_envasado();
            cargar_no_terminado();
            cargar_terminado();
            cargar_granel_envasado_proceso();
            cargar_maduracion();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cargar_maduracion()
        {
            //SELECT granel_movimientos_envasado.numero_de_contenedores,granel_movimientos_envasado.id_granel_movimientos_envasado,granel_movimientos_envasado.id_granel_entrada_envasado,granel_movimientos_envasado.folio,DATE_FORMAT(granel_movimientos_envasado.fecha, '%d/%m/%Y') as fecha, granel_entrada_envasado.id_envasadora, granel_movimientos_envasado.destino, granel_movimientos_envasado.no_lote,granel_entrada_envasado.fq,granel_entrada_envasado.categoria,granel_entrada_envasado.abocante,granel_entrada_envasado.ingrediente,granel_movimientos_envasado.litros_existentes,granel_movimientos_envasado.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey FROM granel_movimientos_envasado INNER JOIN granel_entrada_envasado ON granel_movimientos_envasado.id_granel_entrada_envasado = granel_entrada_envasado.id_granel_entrada_envasado LEFT JOIN existenciaplanta ON granel_entrada_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun = comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada_envasado.id_comun = comun2.id_comun LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun.nombre FROM granel_ensamble_envasado INNER JOIN existenciaplanta ON granel_ensamble_envasado.id_planta= existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun= comun.id_comun  order by granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc, granel_ensamble_envasado.agave_coccion_kg desc)  TABLA ON granel_movimientos_envasado.id_granel_entrada_envasado = TABLA.id_granel_entrada_envasado  LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.id_planta, granel_ensamble_envasado.id_predio, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun3.nombre FROM granel_ensamble_envasado LEFT JOIN existenciaplanta ON granel_ensamble_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble_envasado.id_comun = comun3.id_comun ORDER BY granel_ensamble_envasado.litros DESC, granel_ensamble_envasado.agave_coccion_kg DESC) AS maguey ON granel_entrada_envasado.id_granel_entrada_envasado = maguey.id_granel_entrada_envasado WHERE granel_movimientos_envasado.litros_existentes > 0 and granel_movimientos_envasado.destino IN('vidrio','barricas') AND granel_entrada_envasado.id_envasadora = '13-1' GROUP BY granel_movimientos_envasado.id_granel_movimientos_envasado
            //SELECT granel_movimientos.numero_de_contenedores,granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_entrada.id_fabrica, granel_movimientos.destino, granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN (   SELECT granel_ensamble.id_granel_entrada, granel_ensamble.id_planta,  granel_ensamble.id_predio, granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun3.nombre  FROM granel_ensamble  LEFT JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble.id_comun = comun3.id_comun ORDER BY granel_ensamble.litros DESC , granel_ensamble.agave_coccion_kg DESC) AS maguey ON granel_entrada.id_granel_entrada = maguey.id_granel_entrada WHERE granel_entrada.id_fabrica= '13-8' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino IN ('vidrio','barricas')  GROUP BY granel_movimientos.id_granel_movimientos
            //SELECT granel_movimientos.numero_de_contenedores,granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_entrada.id_fabrica, granel_movimientos.destino, granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN (   SELECT granel_ensamble.id_granel_entrada, granel_ensamble.id_planta,  granel_ensamble.id_predio, granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun3.nombre  FROM granel_ensamble  LEFT JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble.id_comun = comun3.id_comun ORDER BY granel_ensamble.litros DESC , granel_ensamble.agave_coccion_kg DESC) AS maguey ON granel_entrada.id_granel_entrada = maguey.id_granel_entrada WHERE granel_entrada.id_fabrica= '13-8' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino IN ('vidrio','barricas')  GROUP BY granel_movimientos.id_granel_movimientos
            //UNION ALL SELECT granel_movimientos_envasado.numero_de_contenedores,granel_movimientos_envasado.id_granel_movimientos_envasado,granel_movimientos_envasado.id_granel_entrada_envasado,granel_movimientos_envasado.folio,DATE_FORMAT(granel_movimientos_envasado.fecha, '%d/%m/%Y') as fecha, granel_entrada_envasado.id_envasadora, granel_movimientos_envasado.destino, granel_movimientos_envasado.no_lote,granel_entrada_envasado.fq,granel_entrada_envasado.categoria,granel_entrada_envasado.abocante,granel_entrada_envasado.ingrediente,granel_movimientos_envasado.litros_existentes,granel_movimientos_envasado.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey FROM granel_movimientos_envasado INNER JOIN granel_entrada_envasado ON granel_movimientos_envasado.id_granel_entrada_envasado = granel_entrada_envasado.id_granel_entrada_envasado LEFT JOIN existenciaplanta ON granel_entrada_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun = comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada_envasado.id_comun = comun2.id_comun LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun.nombre FROM granel_ensamble_envasado INNER JOIN existenciaplanta ON granel_ensamble_envasado.id_planta= existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun= comun.id_comun  order by granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc, granel_ensamble_envasado.agave_coccion_kg desc)  TABLA ON granel_movimientos_envasado.id_granel_entrada_envasado = TABLA.id_granel_entrada_envasado  LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.id_planta, granel_ensamble_envasado.id_predio, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun3.nombre FROM granel_ensamble_envasado LEFT JOIN existenciaplanta ON granel_ensamble_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble_envasado.id_comun = comun3.id_comun ORDER BY granel_ensamble_envasado.litros DESC, granel_ensamble_envasado.agave_coccion_kg DESC) AS maguey ON granel_entrada_envasado.id_granel_entrada_envasado = maguey.id_granel_entrada_envasado WHERE granel_movimientos_envasado.litros_existentes > 0 and granel_movimientos_envasado.destino IN('vidrio','barricas') AND granel_entrada_envasado.id_envasadora = '13-1' GROUP BY granel_movimientos_envasado.id_granel_movimientos_envasado
            String fabrica = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=1;");
            String envasadora = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=2;");

            dtsMaduracion = new DataSet();
            dtsMaduracion.Tables.Add("MADURACION");
            dtsMaduracion.Tables["MADURACION"].Columns.Add("FECHA INGRESO", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("LOTE", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("NO. RECIPIENTES", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("TIPO RECIENTES", Type.GetType("System.String"));
            dtsMaduracion.Tables["MADURACION"].Columns.Add("NO. DE FOLIOS", Type.GetType("System.String"));
            dgvMaduracion.DataSource = dtsMaduracion.Tables["MADURACION"];
            // dgvGranel.Columns[1].Visible = false;

            DataSet Datos = new DataSet();
            //ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos.numero_de_contenedores,granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_entrada.id_fabrica, granel_movimientos.destino, granel_entrada.clase, granel_movimientos.numero_de_contenedores,  granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN (   SELECT granel_ensamble.id_granel_entrada, granel_ensamble.id_planta,  granel_ensamble.id_predio, granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun3.nombre  FROM granel_ensamble  LEFT JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble.id_comun = comun3.id_comun ORDER BY granel_ensamble.litros DESC , granel_ensamble.agave_coccion_kg DESC) AS maguey ON granel_entrada.id_granel_entrada = maguey.id_granel_entrada WHERE granel_entrada.id_fabrica= '13-8' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino IN ('vidrio','barricas')  GROUP BY granel_movimientos.id_granel_movimientos UNION ALL SELECT granel_movimientos_envasado.numero_de_contenedores,granel_movimientos_envasado.id_granel_movimientos_envasado,granel_movimientos_envasado.id_granel_entrada_envasado,granel_movimientos_envasado.folio,DATE_FORMAT(granel_movimientos_envasado.fecha, '%d/%m/%Y') as fecha, granel_entrada_envasado.id_envasadora, granel_movimientos_envasado.destino, granel_entrada_envasado.clase, granel_movimientos_envasado.numero_de_contenedores, granel_movimientos_envasado.no_lote,granel_entrada_envasado.fq,granel_entrada_envasado.categoria,granel_entrada_envasado.abocante,granel_entrada_envasado.ingrediente,granel_movimientos_envasado.litros_existentes,granel_movimientos_envasado.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey FROM granel_movimientos_envasado INNER JOIN granel_entrada_envasado ON granel_movimientos_envasado.id_granel_entrada_envasado = granel_entrada_envasado.id_granel_entrada_envasado LEFT JOIN existenciaplanta ON granel_entrada_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun = comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada_envasado.id_comun = comun2.id_comun LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun.nombre FROM granel_ensamble_envasado INNER JOIN existenciaplanta ON granel_ensamble_envasado.id_planta= existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun= comun.id_comun  order by granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc, granel_ensamble_envasado.agave_coccion_kg desc)  TABLA ON granel_movimientos_envasado.id_granel_entrada_envasado = TABLA.id_granel_entrada_envasado  LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.id_planta, granel_ensamble_envasado.id_predio, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun3.nombre FROM granel_ensamble_envasado LEFT JOIN existenciaplanta ON granel_ensamble_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble_envasado.id_comun = comun3.id_comun ORDER BY granel_ensamble_envasado.litros DESC, granel_ensamble_envasado.agave_coccion_kg DESC) AS maguey ON granel_entrada_envasado.id_granel_entrada_envasado = maguey.id_granel_entrada_envasado WHERE granel_movimientos_envasado.litros_existentes > 0 and granel_movimientos_envasado.destino IN('vidrio','barricas') AND granel_entrada_envasado.id_envasadora = '13-1' GROUP BY granel_movimientos_envasado.id_granel_movimientos_envasado");
            ConexionMysql.llenaDataset(ref Datos, "SELECT granel_movimientos.numero_de_contenedores,granel_movimientos.id_granel_movimientos,granel_movimientos.id_granel_entrada,granel_movimientos.folio,DATE_FORMAT(granel_movimientos.fecha, '%d/%m/%Y') as fecha,granel_entrada.id_fabrica, granel_movimientos.destino, granel_entrada.clase, granel_movimientos.numero_de_contenedores,  granel_movimientos.no_lote,granel_entrada.fq,granel_entrada.categoria,granel_entrada.abocante,granel_entrada.ingrediente,granel_movimientos.litros_existentes,granel_movimientos.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey FROM granel_movimientos INNER JOIN granel_entrada ON granel_movimientos.id_granel_entrada=granel_entrada.id_granel_entrada LEFT JOIN existenciaplanta ON granel_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada.id_comun=comun2.id_comun LEFT JOIN   ( SELECT granel_ensamble.id_granel_entrada,granel_ensamble.litros,granel_ensamble.agave_coccion_kg,comun.nombre FROM granel_ensamble INNER JOIN existenciaplanta ON granel_ensamble.id_planta=existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc, granel_ensamble.agave_coccion_kg desc)  TABLA ON granel_movimientos.id_granel_entrada=TABLA.id_granel_entrada  LEFT JOIN (   SELECT granel_ensamble.id_granel_entrada, granel_ensamble.id_planta,  granel_ensamble.id_predio, granel_ensamble.litros, granel_ensamble.agave_coccion_kg, comun3.nombre  FROM granel_ensamble  LEFT JOIN existenciaplanta ON granel_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble.id_comun = comun3.id_comun ORDER BY granel_ensamble.litros DESC , granel_ensamble.agave_coccion_kg DESC) AS maguey ON granel_entrada.id_granel_entrada = maguey.id_granel_entrada WHERE granel_entrada.id_fabrica= '" + fabrica + "' and granel_movimientos.litros_existentes > 0 and granel_movimientos.destino IN ('vidrio','barricas')  GROUP BY granel_movimientos.id_granel_movimientos UNION ALL SELECT granel_movimientos_envasado.numero_de_contenedores,granel_movimientos_envasado.id_granel_movimientos_envasado,granel_movimientos_envasado.id_granel_entrada_envasado,granel_movimientos_envasado.folio,DATE_FORMAT(granel_movimientos_envasado.fecha, '%d/%m/%Y') as fecha, granel_entrada_envasado.id_envasadora, granel_movimientos_envasado.destino, granel_entrada_envasado.clase, granel_movimientos_envasado.numero_de_contenedores, granel_movimientos_envasado.no_lote,granel_entrada_envasado.fq,granel_entrada_envasado.categoria,granel_entrada_envasado.abocante,granel_entrada_envasado.ingrediente,granel_movimientos_envasado.litros_existentes,granel_movimientos_envasado.grado_alcoholico_existente,comun.nombre as maguey,comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey FROM granel_movimientos_envasado INNER JOIN granel_entrada_envasado ON granel_movimientos_envasado.id_granel_entrada_envasado = granel_entrada_envasado.id_granel_entrada_envasado LEFT JOIN existenciaplanta ON granel_entrada_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun = comun.id_comun  LEFT JOIN comun as comun2 ON granel_entrada_envasado.id_comun = comun2.id_comun LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun.nombre FROM granel_ensamble_envasado INNER JOIN existenciaplanta ON granel_ensamble_envasado.id_planta= existenciaplanta.id_plantas  INNER JOIN comun ON existenciaplanta.id_comun= comun.id_comun  order by granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc, granel_ensamble_envasado.agave_coccion_kg desc)  TABLA ON granel_movimientos_envasado.id_granel_entrada_envasado = TABLA.id_granel_entrada_envasado  LEFT JOIN(SELECT granel_ensamble_envasado.id_granel_entrada_envasado, granel_ensamble_envasado.id_planta, granel_ensamble_envasado.id_predio, granel_ensamble_envasado.litros, granel_ensamble_envasado.agave_coccion_kg, comun3.nombre FROM granel_ensamble_envasado LEFT JOIN existenciaplanta ON granel_ensamble_envasado.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR granel_ensamble_envasado.id_comun = comun3.id_comun ORDER BY granel_ensamble_envasado.litros DESC, granel_ensamble_envasado.agave_coccion_kg DESC) AS maguey ON granel_entrada_envasado.id_granel_entrada_envasado = maguey.id_granel_entrada_envasado WHERE granel_movimientos_envasado.litros_existentes > 0 and granel_movimientos_envasado.destino IN('vidrio','barricas') AND granel_entrada_envasado.id_envasadora = '" + envasadora + "' GROUP BY granel_movimientos_envasado.id_granel_movimientos_envasado");
            DataRow fila;
            dtsMaduracion.Tables["MADURACION"].Rows.Clear();
            dgvMaduracion.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvMaduracion.EnableHeadersVisualStyles = false;
            dgvMaduracion.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;
            string fq = "";
            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                fila = dtsMaduracion.Tables["MADURACION"].NewRow();
                fila["FECHA INGRESO"] = Convert.ToString(row["fecha"]);
                fila["LOTE"] = Convert.ToString(row["no_lote"]);
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["VOLUMEN"] = Convert.ToString(row["litros_existentes"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico_existente"]);
                fila["NO. RECIPIENTES"] = Convert.ToString(row["numero_de_contenedores"]);
                fila["TIPO RECIENTES"] = Convert.ToString(row["destino"]).ToUpper();
                fila["NO. DE FOLIOS"] = Convert.ToString(row["folio"]);
                dtsMaduracion.Tables["MADURACION"].Rows.Add(fila);
            }
        }

        private void cargar_terminado()
        {
            String envasadora = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=2;");

            dtsTerminado = new DataSet();
            dtsTerminado.Tables.Add("TERMINADO");
            dtsTerminado.Tables["TERMINADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("LOTE GRANEL", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("LOTE ENVASADO", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("NO. ANALISIS FISICOQUIMICO", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("CONT. NET.", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("NO. CAJAS", Type.GetType("System.String"));
            dtsTerminado.Tables["TERMINADO"].Columns.Add("NO. BOTELLAS", Type.GetType("System.String"));
            dgvTerminado.DataSource = dtsTerminado.Tables["TERMINADO"];
            // dgvGranel.Columns[1].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT marcas.marca,envasado_entrada.id_envasado_entrada,no_lote_granel,envasado_entrada.no_cliente, DATE_FORMAT(envasado_entrada.fecha, '%d/%m/%Y') as fecha , envasado_entrada.no_lote, envasado_entrada.fq, envasado_entrada.clase, envasado_entrada.categoria, envasado_entrada.abocante, envasado_entrada.ingrediente, envasado_entrada.unidad_medida, envasado_entrada.contenido_por_botella, envasado_entrada.litros, envasado_entrada.grado_alcoholico,envasado_entrada.grado_alcoholico_etiqueta, envasado_entrada.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble,  GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_envasado_entrada ASC ) as ensamble_maguey   FROM envasado_entrada  LEFT JOIN existenciaplanta ON envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada,envasado_ensamble.litros,envasado_ensamble.agave_coccion_kg,comun.nombre  FROM envasado_ensamble  INNER JOIN existenciaplanta ON envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by envasado_ensamble.id_envasado_entrada asc, envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc)  TABLA  ON envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada   LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada, envasado_ensamble.id_planta,  envasado_ensamble.id_predio,envasado_ensamble.litros, envasado_ensamble.agave_coccion_kg, comun3.nombre  FROM envasado_ensamble  LEFT JOIN existenciaplanta ON envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR envasado_ensamble.id_comun = comun3.id_comun order by envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc) AS maguey ON envasado_entrada.id_envasado_entrada = maguey.id_envasado_entrada  INNER JOIN marcas ON SUBSTRING(envasado_entrada.id_marca,1,5) =marcas.no_cliente and  SUBSTRING(envasado_entrada.id_marca,7,2)=marcas.cve_marca  WHERE envasado_entrada.id_envasadora='" + envasadora + "' and envasado_entrada.botellas_existentes > 0 GROUP BY envasado_entrada.id_envasado_entrada");
            DataRow fila;
            dtsTerminado.Tables["TERMINADO"].Rows.Clear();
            dgvTerminado.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvTerminado.EnableHeadersVisualStyles = false;
            dgvTerminado.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;
            string fq = "";
            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                if (Convert.ToString(row["fq"]) != "")
                {
                    fq = Convert.ToString(row["fq"]);
                }
                else { fq = "---"; }

                fila = dtsTerminado.Tables["TERMINADO"].NewRow();
                fila["MARCA"] = Convert.ToString(row["marca"]);
                fila["LOTE GRANEL"] = Convert.ToString(row["no_lote_granel"]);
                fila["LOTE ENVASADO"] = Convert.ToString(row["no_lote"]);
                fila["NO. ANALISIS FISICOQUIMICO"] = fq;
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["CONT. NET."] = Convert.ToString(row["contenido_por_botella"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico"]);
                fila["NO. CAJAS"] = "---";
                fila["NO. BOTELLAS"] = Convert.ToString(row["botellas_existentes"]);
                dtsTerminado.Tables["TERMINADO"].Rows.Add(fila);
            }
        }

        private void cargar_no_terminado()
        {
            String envasadora = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=2;");

            dtsNoTerminado = new DataSet();
            dtsNoTerminado.Tables.Add("NO_TERMINADO");
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("MARCA", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("LOTE GRANEL", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("LOTE ENVASADO", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("NO. ANALISIS FISICOQUIMICO", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("CONT. NET.", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("NO. CAJAS", Type.GetType("System.String"));
            dtsNoTerminado.Tables["NO_TERMINADO"].Columns.Add("NO. BOTELLAS", Type.GetType("System.String"));
            dgvNoTerminado.DataSource = dtsNoTerminado.Tables["NO_TERMINADO"];
            // dgvGranel.Columns[1].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT envasado_entrada.id_envasado_entrada,envasado_entrada.no_lote_granel,envasado_entrada.no_cliente, DATE_FORMAT(envasado_entrada.fecha, '%d/%m/%Y') as fecha , envasado_entrada.no_lote, envasado_entrada.fq, envasado_entrada.clase, envasado_entrada.categoria, envasado_entrada.abocante, envasado_entrada.ingrediente, envasado_entrada.unidad_medida, envasado_entrada.contenido_por_botella, envasado_entrada.litros, envasado_entrada.grado_alcoholico, envasado_entrada.botellas_existentes, comun.nombre as maguey, comun2.nombre as maguey_sin, GROUP_CONCAT(DISTINCT maguey.nombre) AS ensamble, GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_envasado_entrada ASC ) as ensamble_maguey   FROM envasado_entrada  LEFT JOIN existenciaplanta ON envasado_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun LEFT JOIN comun as comun2 ON envasado_entrada.id_comun=comun2.id_comun  LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada,envasado_ensamble.litros,envasado_ensamble.agave_coccion_kg,comun.nombre  FROM envasado_ensamble  INNER JOIN existenciaplanta ON envasado_ensamble.id_planta=existenciaplanta.id_plantas   INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun   order by envasado_ensamble.id_envasado_entrada asc, envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc)  TABLA  ON envasado_entrada.id_envasado_entrada=TABLA.id_envasado_entrada   LEFT JOIN  ( SELECT envasado_ensamble.id_envasado_entrada, envasado_ensamble.id_planta,  envasado_ensamble.id_predio,envasado_ensamble.litros, envasado_ensamble.agave_coccion_kg, comun3.nombre  FROM envasado_ensamble  LEFT JOIN existenciaplanta ON envasado_ensamble.id_planta = existenciaplanta.id_plantas LEFT JOIN comun AS comun3 ON existenciaplanta.id_comun = comun3.id_comun  OR envasado_ensamble.id_comun = comun3.id_comun  order by envasado_ensamble.litros desc, envasado_ensamble.agave_coccion_kg desc) AS maguey ON envasado_entrada.id_envasado_entrada = maguey.id_envasado_entrada  WHERE envasado_entrada.id_envasadora='" + envasadora + "' and envasado_entrada.botellas_existentes > 0  and envasado_entrada.id_marca='0' GROUP BY envasado_entrada.id_envasado_entrada");
            DataRow fila;
            dtsNoTerminado.Tables["NO_TERMINADO"].Rows.Clear();
            dgvNoTerminado.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvNoTerminado.EnableHeadersVisualStyles = false;
            dgvNoTerminado.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;
            string fq = "";
            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                if (Convert.ToString(row["fq"]) != "")
                {
                    fq= Convert.ToString(row["fq"]);
                }
                else { fq= "---"; }

                fila = dtsNoTerminado.Tables["NO_TERMINADO"].NewRow();
                fila["MARCA"] ="---";
                fila["LOTE GRANEL"] = Convert.ToString(row["no_lote_granel"]);
                fila["LOTE ENVASADO"] = Convert.ToString(row["no_lote"]);
                fila["NO. ANALISIS FISICOQUIMICO"] = fq;
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["CONT. NET."] = Convert.ToString(row["litros"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico"]);
                fila["NO. CAJAS"] = "---";
                fila["NO. BOTELLAS"] = Convert.ToString(row["contenido_por_botella"]);
                dtsNoTerminado.Tables["NO_TERMINADO"].Rows.Add(fila);
            }
        }

        private void cargar_granel_envasado_proceso()
        {
            dtsGranelEnvasadoProceso = new DataSet();
            dtsGranelEnvasadoProceso.Tables.Add("GRANEL_ENVASADO");
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("NO. TANQUE", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("LOTE", Type.GetType("System.String"));
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("ESPECIE AGAVE", Type.GetType("System.String"));
            //dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("NO. ANALISIS FISICOQUIMICO", Type.GetType("System.String"));
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dgvEnvasadoP.DataSource = dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"];
            // dgvGranel.Columns[1].Visible = false;
             String envasadora = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=2;");

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT    DATE_FORMAT( granel_entrada_envasado.fecha, '%d/%m/%Y') as fecha,   granel_entrada_envasado.no_cliente,   envasadora_encargado.envasadora,    envasadora_encargado.estado,    granel_entrada_envasado.no_lote,     comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  granel_tanques_envasado.tanque) as tanque ,    granel_entrada_envasado.fq,     granel_entrada_envasado.clase,    granel_entrada_envasado.categoria,     granel_entrada_envasado.abocante,     granel_entrada_envasado.ingrediente,  granel_entrada_envasado.lts_entrada,   granel_entrada_envasado.grado_alcoholico_entrada,        granel_entrada_envasado.lts_existentes,      granel_entrada_envasado.grado_alcoholico_existente,    verificadores.nombre as verificador         FROM  granel_entrada_envasado            LEFT JOIN existenciaplanta ON  granel_entrada_envasado.id_planta=existenciaplanta.id_plantas             LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  granel_entrada_envasado.id_comun=comun2.id_comun             INNER JOIN  granel_tanques_envasado ON  granel_entrada_envasado.id_granel_entrada_envasado= granel_tanques_envasado.id_granel_entrada_envasado             inner join envasadora_encargado on granel_entrada_envasado.id_envasadora= envasadora_encargado.id_envasadora              LEFT JOIN                ( SELECT  granel_ensamble_envasado.id_granel_entrada_envasado,               granel_ensamble_envasado.litros,               granel_ensamble_envasado.agave_coccion_kg,              comun.nombre               FROM  granel_ensamble_envasado               INNER JOIN existenciaplanta ON  granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc,  granel_ensamble_envasado.agave_coccion_kg desc) TABLA  ON  granel_entrada_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado                LEFT JOIN  (   SELECT  granel_ensamble_envasado.id_granel_entrada_envasado,comun.nombre FROM  granel_ensamble_envasado INNER JOIN comun ON  granel_ensamble_envasado.id_comun=comun.id_comun  order by  granel_ensamble_envasado.id_granel_entrada_envasado asc  ) TABLA2 ON  granel_entrada_envasado.id_granel_entrada_envasado=TABLA2.id_granel_entrada_envasado                  inner join verificadores on  granel_entrada_envasado.id_verificador= verificadores.id_us     where    granel_entrada_envasado.no_cliente='" + no_cliente + "' AND fq IN ('---',' ---','--',' --','----',' ----')    AND lts_existentes>0  AND granel_entrada_envasado.id_envasadora='" + envasadora + "'    GROUP BY  granel_entrada_envasado.id order by no_cliente");
            DataRow fila;
            dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Rows.Clear();
            dgvEnvasadoP.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvEnvasadoP.EnableHeadersVisualStyles = false;
            dgvEnvasadoP.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;

            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                fila = dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].NewRow();
                fila["NO. TANQUE"] = Convert.ToString(row["tanque"]);
                //fila["ID"] = Convert.ToString(row["id"]);
                fila["LOTE"] = Convert.ToString(row["no_lote"]);

                if (Convert.ToString(row["maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey"]);
                }
                else if (Convert.ToString(row["maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey_sin"]);
                }
                else if (Convert.ToString(row["ensamble_maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey"]);
                }
                else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                }
                //fila["NO. ANALISIS FISICOQUIMICO"] = Convert.ToString(row["fq"]);
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["VOLUMEN"] = Convert.ToString(row["lts_existentes"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico_existente"]);
                dtsGranelEnvasadoProceso.Tables["GRANEL_ENVASADO"].Rows.Add(fila);
            }
        }

        private void btnGranel_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = dtpFechaActa.Value.ToString("yyyy-MM-dd");
                string hora = dtpHoraActa.Value.ToString("HH:mm");

                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET granel='1', texto_granel='" + txtGranel.Text + "'" +" Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_granel();
                pbGranel.Show(); 
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGranelProceso_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET granel_proceso='1', texto_granel_proceso='" + txtGranelProceso.Text + "'" + " Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_granel_proceso();
                pbGranelProceso.Show();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET produccion='1', texto_produccion='" + txtProduccion.Text + "'" + " Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_produccion();
                pbProduccion.Show();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAGranelEnvasado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET granel_envasado='1', texto_granel_envasado='" + txtGEnvasado.Text + "'" + " Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_granel_envasado();
                pbGEnvasado.Show();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEnvasadoProceso_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET granel_envasado_proceso='1', texto_granel_envasado_proceso='" + txtEnvasadoProceso.Text + "'" + " Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_granel_envasado_proceso();
                pbEnvasadoP.Show();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMaduracion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET maduracion='1', texto_maduracion='" + txtMaduracion.Text + "'" + " Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_maduracion();
                pbMaduracion.Show();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTerminado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET producto_terminado='1', texto_terminado='" + txtTerminado.Text + "'" + " Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_terminado();
                pbTerminado.Show();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNoTerminado_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_datos_acta SET producto_no_terminado='1', texto_no_terminado='" + txtNoTerminado.Text + "'" + " Where id='" + acta + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_no_terminado();
                pbNoTerminado.Show();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cargar_granel_envasado()
        {
            dtsGranelEnvasado = new DataSet();
            dtsGranelEnvasado.Tables.Add("GRANEL_ENVASADO");
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("NO. TANQUE", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("LOTE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("ESPECIE AGAVE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("NO. ANALISIS FISICOQUIMICO", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dgvGEnvasado.DataSource = dtsGranelEnvasado.Tables["GRANEL_ENVASADO"];
            // dgvGranel.Columns[1].Visible = false;
           String envasadora = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=2;");

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT    DATE_FORMAT( granel_entrada_envasado.fecha, '%d/%m/%Y') as fecha,   granel_entrada_envasado.no_cliente,   envasadora_encargado.envasadora,    envasadora_encargado.estado,    granel_entrada_envasado.no_lote,     comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada_envasado ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  granel_tanques_envasado.tanque) as tanque ,    granel_entrada_envasado.fq,     granel_entrada_envasado.clase,    granel_entrada_envasado.categoria,     granel_entrada_envasado.abocante,     granel_entrada_envasado.ingrediente,  granel_entrada_envasado.lts_entrada,   granel_entrada_envasado.grado_alcoholico_entrada,        granel_entrada_envasado.lts_existentes,      granel_entrada_envasado.grado_alcoholico_existente,    verificadores.nombre as verificador         FROM  granel_entrada_envasado            LEFT JOIN existenciaplanta ON  granel_entrada_envasado.id_planta=existenciaplanta.id_plantas             LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  granel_entrada_envasado.id_comun=comun2.id_comun             INNER JOIN  granel_tanques_envasado ON  granel_entrada_envasado.id_granel_entrada_envasado= granel_tanques_envasado.id_granel_entrada_envasado             inner join envasadora_encargado on granel_entrada_envasado.id_envasadora= envasadora_encargado.id_envasadora              LEFT JOIN                ( SELECT  granel_ensamble_envasado.id_granel_entrada_envasado,               granel_ensamble_envasado.litros,               granel_ensamble_envasado.agave_coccion_kg,              comun.nombre               FROM  granel_ensamble_envasado               INNER JOIN existenciaplanta ON  granel_ensamble_envasado.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  granel_ensamble_envasado.id_granel_entrada_envasado asc, granel_ensamble_envasado.litros desc,  granel_ensamble_envasado.agave_coccion_kg desc) TABLA  ON  granel_entrada_envasado.id_granel_entrada_envasado=TABLA.id_granel_entrada_envasado                LEFT JOIN  (   SELECT  granel_ensamble_envasado.id_granel_entrada_envasado,comun.nombre FROM  granel_ensamble_envasado INNER JOIN comun ON  granel_ensamble_envasado.id_comun=comun.id_comun  order by  granel_ensamble_envasado.id_granel_entrada_envasado asc  ) TABLA2 ON  granel_entrada_envasado.id_granel_entrada_envasado=TABLA2.id_granel_entrada_envasado                  inner join verificadores on  granel_entrada_envasado.id_verificador= verificadores.id_us     where    granel_entrada_envasado.no_cliente='" + no_cliente + "' AND fq NOT IN ('---',' ---','--',' --','----',' ----')  AND lts_existentes>0    AND granel_entrada_envasado.id_envasadora='" + envasadora + "'    GROUP BY  granel_entrada_envasado.id order by no_cliente");
            DataRow fila;
            dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Rows.Clear();
            dgvGEnvasado.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvGEnvasado.EnableHeadersVisualStyles = false;
            dgvGEnvasado.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;

            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                fila = dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].NewRow();
                fila["NO. TANQUE"] = Convert.ToString(row["tanque"]);
                //fila["ID"] = Convert.ToString(row["id"]);
                fila["LOTE"] = Convert.ToString(row["no_lote"]);

                if (Convert.ToString(row["maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey"]);
                }
                else if (Convert.ToString(row["maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey_sin"]);
                }
                else if (Convert.ToString(row["ensamble_maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey"]);
                }
                else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                }
                fila["NO. ANALISIS FISICOQUIMICO"] = Convert.ToString(row["fq"]);
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["VOLUMEN"] = Convert.ToString(row["lts_existentes"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico_existente"]);
                dtsGranelEnvasado.Tables["GRANEL_ENVASADO"].Rows.Add(fila);
            }
        }

        private void cargar_produccion()
        {
            dtsProduccion = new DataSet();
            dtsProduccion.Tables.Add("PRODUCCION");
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO. PRODUCCION", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("ESPECIE AGAVE", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("NO. DE GUIA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("ETAPA PROCESO", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsProduccion.Tables["PRODUCCION"].Columns.Add("KG", Type.GetType("System.String"));
            dgvProduccion.DataSource = dtsProduccion.Tables["PRODUCCION"];
            // dgvGranel.Columns[1].Visible = false;

            String fabrica = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=1;");

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT produccion_entrada.no_cliente,maestro_fabrica.fabrica,maestro_fabrica.estado,produccion_entrada.tapada,produccion_entrada.id_predio,GROUP_CONCAT(DISTINCT TABLA.id_predio order by TABLA.agave_coccion_kg desc) as id_predio_ensamble,comun.nombre as maguey,GROUP_CONCAT(DISTINCT TABLA.maguey order by TABLA.agave_coccion_kg desc) as ensamble_maguey, produccion_entrada.no_pinas_agave, produccion_entrada.agave_coccion_kg,DATE_FORMAT(produccion_entrada.periodo_coccion_inicio, '%d/%m/%Y') as periodo_coccion_inicio,DATE_FORMAT(produccion_entrada.periodo_coccion_fin, '%d/%m/%Y') as periodo_coccion_fin,  produccion_entrada.porcentaje_art, DATE_FORMAT( produccion_entrada.periodo_molienda_inicio, '%d/%m/%Y') as periodo_molienda_inicio , DATE_FORMAT( produccion_entrada.periodo_molienda_fin, '%d/%m/%Y') as periodo_molienda_fin,DATE_FORMAT( produccion_entrada.periodo_formulacion_inicio, '%d/%m/%Y') as periodo_formulacion_inicio ,   DATE_FORMAT( produccion_entrada.periodo_formulacion_fin, '%d/%m/%Y') as periodo_formulacion_fin   , DATE_FORMAT( produccion_entrada.periodo_destilacion_inicio, '%d/%m/%Y') as periodo_destilacion_inicio    ,DATE_FORMAT( produccion_entrada.periodo_destilacion_fin, '%d/%m/%Y') as periodo_destilacion_fin       ,produccion_entrada.destilaciones_realizadas,produccion_entrada.lts_producidos,produccion_entrada.grado_alcoholico,produccion_entrada.lts_existentes , produccion_entrada.estatus,verificadores.nombre as verificador from  produccion_entrada LEFT JOIN existenciaplanta ON  produccion_entrada.id_planta=existenciaplanta.id_plantas LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun inner join  maestro_fabrica on  produccion_entrada.id_fabrica=  maestro_fabrica.id_fabrica  LEFT JOIN (SELECT   produccion_ensamble.id_produccion_entrada,           comun.nombre as maguey,            produccion_ensamble.agave_coccion_kg,           produccion_ensamble. id_predio           FROM  produccion_ensamble           INNER JOIN existenciaplanta ON  produccion_ensamble.id_planta=existenciaplanta.id_plantas            INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun)TABLA            ON  produccion_entrada.id_produccion_entrada=TABLA.id_produccion_entrada inner join verificadores on  produccion_entrada.id_verificador= verificadores.id_us  where    produccion_entrada.no_cliente='" + no_cliente + "' and  produccion_entrada.id_fabrica='" + fabrica + "' GROUP BY  produccion_entrada.id_produccion_entrada  order by no_cliente");
            DataRow fila;
            dtsProduccion.Tables["PRODUCCION"].Rows.Clear();
            dgvProduccion.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvProduccion.EnableHeadersVisualStyles = false;
            dgvProduccion.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;
            string etapa = "";
            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                fila = dtsProduccion.Tables["PRODUCCION"].NewRow();
                fila["NO. PRODUCCION"] = Convert.ToString(row["tapada"]);

                if (Convert.ToString(row["ensamble_maguey"]) == "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey"]);
                }
                else
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey"]);
                }
                fila["NO. DE GUIA"] = "";
                switch (Convert.ToString(row["estatus"]))
                {
                    case "1":
                        etapa = "COCCIÖN";
                        break;
                    case "2":
                        etapa = "MOLIENDA";
                        break;
                    case "3":
                        etapa = "FORMULACIÓN";
                        break;
                    case "4":
                        etapa = "DESTILACIÓN";
                        break;
                    case "5":
                        etapa = "PRODUCCION";
                        break;
                }
                fila["ETAPA PROCESO"] = etapa;
                fila["CATEGORIA"] = "";
                fila["KG"] = Convert.ToString(row["agave_coccion_kg"]);
                dtsProduccion.Tables["PRODUCCION"].Rows.Add(fila);
            }
        }

        private void cargar_granel_proceso()
        {
            dtsDatosGranelProceso = new DataSet();
            dtsDatosGranelProceso.Tables.Add("GRANEL_PROCESO");
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("NO. TANQUE", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("LOTE", Type.GetType("System.String"));
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("ESPECIE AGAVE", Type.GetType("System.String"));
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("NO. DE GUIA", Type.GetType("System.String"));
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dgvGranelProceso.DataSource = dtsDatosGranelProceso.Tables["GRANEL_PROCESO"];
            // dgvGranel.Columns[1].Visible = false;
            String fabrica = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=1;");
 
            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT  DATE_FORMAT( granel_entrada.fecha, '%d/%m/%Y') as fecha,   granel_entrada.no_cliente,maestro_fabrica.fabrica,maestro_fabrica.estado,    granel_entrada.no_lote,    comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  granel_tanques.tanque) as tanque,    granel_entrada.fq,     granel_entrada.clase,    granel_entrada.categoria,     granel_entrada.abocante,     granel_entrada.ingrediente,    granel_entrada.lts_entrada,   granel_entrada.grado_alcoholico_entrada,    granel_entrada.lts_existentes,      granel_entrada.grado_alcoholico_existente,    verificadores.nombre as verificador       FROM  granel_entrada            LEFT JOIN existenciaplanta ON  granel_entrada.id_planta=existenciaplanta.id_plantas            LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  granel_entrada.id_comun=comun2.id_comun             INNER JOIN  granel_tanques ON  granel_entrada.id_granel_entrada= granel_tanques.id_granel_entrada            inner join maestro_fabrica on granel_entrada.id_fabrica= maestro_fabrica.id_fabrica              LEFT JOIN                ( SELECT  granel_ensamble.id_granel_entrada,               granel_ensamble.litros,               granel_ensamble.agave_coccion_kg,              comun.nombre               FROM  granel_ensamble               INNER JOIN existenciaplanta ON  granel_ensamble.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc,  granel_ensamble.agave_coccion_kg desc) TABLA  ON  granel_entrada.id_granel_entrada=TABLA.id_granel_entrada                LEFT JOIN  (   SELECT  granel_ensamble.id_granel_entrada,comun.nombre FROM  granel_ensamble INNER JOIN comun ON  granel_ensamble.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc  ) TABLA2 ON  granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada                 inner join verificadores on  granel_entrada.id_verificador= verificadores.id_us    where    granel_entrada.no_cliente='" + no_cliente + "' AND granel_entrada.id_fabrica='" + fabrica + "' AND granel_entrada.fq IN ('---',' ---','--',' --','----',' ----') AND lts_existentes>0 GROUP BY  granel_entrada.id order by no_cliente");
            DataRow fila;
            dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Rows.Clear();
            dgvGranelProceso.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvGranelProceso.EnableHeadersVisualStyles = false;
            dgvGranelProceso.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;


            /* dgvGranel.DefaultCellStyle.Font = new Font("Tahoma", 15);
             dgvGranel.DefaultCellStyle.ForeColor = Color.Blue;
             dgvGranel.DefaultCellStyle.BackColor = Color.Beige;
             dgvGranel.DefaultCellStyle.SelectionForeColor = Color.Yellow;
             dgvGranel.DefaultCellStyle.SelectionBackColor = Color.Black;*/

            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                fila = dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].NewRow();
                fila["NO. TANQUE"] = Convert.ToString(row["tanque"]);
                //fila["ID"] = Convert.ToString(row["id"]);
                fila["LOTE"] = Convert.ToString(row["no_lote"]);

                if (Convert.ToString(row["maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey"]);
                }
                else if (Convert.ToString(row["maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey_sin"]);
                }
                else if (Convert.ToString(row["ensamble_maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey"]);
                }
                else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                }
                fila["NO. DE GUIA"] = "";
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["VOLUMEN"] = Convert.ToString(row["lts_existentes"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico_existente"]);
                dtsDatosGranelProceso.Tables["GRANEL_PROCESO"].Rows.Add(fila);
            }
        }

        private void cargar_granel()
        {
            String fabrica = ConexionMysql.regresaCampoConsulta("SELECT rv_instalaciones FROM sinca.`di_instalaciones` i INNER JOIN sinca.di_solicitud_instalacion si ON i.id = si.instalacion WHERE si.solicitud ='" + di_solicitud + "' AND i.tipo=1;");
            dtsDatosGranel = new DataSet();
            dtsDatosGranel.Tables.Add("GRANEL");
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("NO. TANQUE", Type.GetType("System.String"));
            // dtsDatosGranel.Tables["GRANEL"].Columns.Add("ID", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("LOTE", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("ESPECIE AGAVE", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("NO. DE GUIA", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("NO. ANALISIS FISICOQUIMICO", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("CLASE", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("VOLUMEN", Type.GetType("System.String"));
            dtsDatosGranel.Tables["GRANEL"].Columns.Add("% ALC. VOL.", Type.GetType("System.String"));
            dgvGranel.DataSource = dtsDatosGranel.Tables["GRANEL"];
            // dgvGranel.Columns[1].Visible = false;

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT  DATE_FORMAT( granel_entrada.fecha, '%d/%m/%Y') as fecha,   granel_entrada.no_cliente,maestro_fabrica.fabrica,maestro_fabrica.estado,    granel_entrada.no_lote,    comun.nombre as maguey,       comun2.nombre as maguey_sin,        GROUP_CONCAT(DISTINCT TABLA.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey,         GROUP_CONCAT(DISTINCT TABLA2.nombre order by TABLA.id_granel_entrada ASC ) as ensamble_maguey_sin,         GROUP_CONCAT(DISTINCT  granel_tanques.tanque) as tanque,    granel_entrada.fq,     granel_entrada.clase,    granel_entrada.categoria,     granel_entrada.abocante,     granel_entrada.ingrediente,    granel_entrada.lts_entrada,   granel_entrada.grado_alcoholico_entrada,    granel_entrada.lts_existentes,      granel_entrada.grado_alcoholico_existente,    verificadores.nombre as verificador       FROM  granel_entrada            LEFT JOIN existenciaplanta ON  granel_entrada.id_planta=existenciaplanta.id_plantas            LEFT JOIN comun ON existenciaplanta.id_comun=comun.id_comun             LEFT JOIN comun as comun2 ON  granel_entrada.id_comun=comun2.id_comun             INNER JOIN  granel_tanques ON  granel_entrada.id_granel_entrada= granel_tanques.id_granel_entrada            inner join maestro_fabrica on granel_entrada.id_fabrica= maestro_fabrica.id_fabrica              LEFT JOIN                ( SELECT  granel_ensamble.id_granel_entrada,               granel_ensamble.litros,               granel_ensamble.agave_coccion_kg,              comun.nombre               FROM  granel_ensamble               INNER JOIN existenciaplanta ON  granel_ensamble.id_planta=existenciaplanta.id_plantas                INNER JOIN comun ON existenciaplanta.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc, granel_ensamble.litros desc,  granel_ensamble.agave_coccion_kg desc) TABLA  ON  granel_entrada.id_granel_entrada=TABLA.id_granel_entrada                LEFT JOIN  (   SELECT  granel_ensamble.id_granel_entrada,comun.nombre FROM  granel_ensamble INNER JOIN comun ON  granel_ensamble.id_comun=comun.id_comun  order by  granel_ensamble.id_granel_entrada asc  ) TABLA2 ON  granel_entrada.id_granel_entrada=TABLA2.id_granel_entrada                 inner join verificadores on  granel_entrada.id_verificador= verificadores.id_us    where    granel_entrada.no_cliente='" + no_cliente + "' AND granel_entrada.id_fabrica='" + fabrica + "' AND granel_entrada.fq NOT IN ('---',' ---','--',' --','----',' ----') AND lts_existentes > 0  GROUP BY  granel_entrada.id order by no_cliente");
            DataRow fila;
            dtsDatosGranel.Tables["GRANEL"].Rows.Clear();
            dgvGranel.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvGranel.EnableHeadersVisualStyles = false;
            dgvGranel.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;


            /* dgvGranel.DefaultCellStyle.Font = new Font("Tahoma", 15);
             dgvGranel.DefaultCellStyle.ForeColor = Color.Blue;
             dgvGranel.DefaultCellStyle.BackColor = Color.Beige;
             dgvGranel.DefaultCellStyle.SelectionForeColor = Color.Yellow;
             dgvGranel.DefaultCellStyle.SelectionBackColor = Color.Black;*/

            foreach (DataRow row in Datos.Tables[0].Rows)
            {

                fila = dtsDatosGranel.Tables["GRANEL"].NewRow();
                fila["NO. TANQUE"] = Convert.ToString(row["tanque"]);
                //fila["ID"] = Convert.ToString(row["id"]);
                fila["LOTE"] = Convert.ToString(row["no_lote"]);

                if (Convert.ToString(row["maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey"]);
                }
                else if (Convert.ToString(row["maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["maguey_sin"]);
                }
                else if (Convert.ToString(row["ensamble_maguey"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey"]);
                }
                else if (Convert.ToString(row["ensamble_maguey_sin"]) != "")
                {
                    fila["ESPECIE AGAVE"] = Convert.ToString(row["ensamble_maguey_sin"]);
                }
                fila["NO. DE GUIA"] = "";
                fila["NO. ANALISIS FISICOQUIMICO"] = Convert.ToString(row["fq"]);
                fila["CATEGORIA"] = Convert.ToString(row["categoria"]);
                fila["CLASE"] = Convert.ToString(row["clase"]);
                fila["VOLUMEN"] = Convert.ToString(row["lts_existentes"]);
                fila["% ALC. VOL."] = Convert.ToString(row["grado_alcoholico_existente"]);
                dtsDatosGranel.Tables["GRANEL"].Rows.Add(fila);
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = dtpFechaActa.Value.ToString("yyyy-MM-dd");
                string hora = dtpHoraActa.Value.ToString("HH:mm");

                if (ConexionMysql.insUpd_transaccion("UPDATE sinca.di_solicitud SET fecha_cierre='" + fecha + "', hora_cierre='" + hora + "',observaciones_visitado='" + txtTexto.Text + "'" +
                    "Where id='" + di_solicitud + "'") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                cargar_generales();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }         
            
        }

        private void cargar_generales()
        {
            try
            {
                pbGranel.Hide();
                pbGranelProceso.Hide();
                pbProduccion.Hide();
                pbGEnvasado.Hide();
                pbEnvasadoP.Hide();
                pbMaduracion.Hide();
                pbTerminado.Hide();
                pbNoTerminado.Hide();
                //Cargar datos
                DataSet Datos = new DataSet();
                DataSet DatosActa = new DataSet();

                if (id_solicitud == "" || id_solicitud == null || id_solicitud == "0")
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado,s.id_acta,tipo_registro,s.no_control,s.observaciones_visitado,calle,colonia,noexterior,estado,municipio,cp,pais,s.rfc,s.telefonos,s.correos, hora_cierre,DATE_FORMAT(fecha_cierre, '%d/%m/%Y') as fecha_cierre,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,no_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta WHERE s.id='" + di_solicitud + "' LIMIT 1");
                }
                else
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT s.id,guardado,s.id_acta,tipo_registro,s.no_control,s.observaciones_visitado,calle,colonia,noexterior,estado,municipio,cp,pais,s.rfc,s.telefonos,s.correos, hora_cierre,DATE_FORMAT(fecha_cierre, '%d/%m/%Y') as fecha_cierre,solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, id_bp, id_acta, id_informe, testigos, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe,acepta_diligencia,testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2,no_acta FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id=s.id_acta WHERE s.id_solicitud='" + id_solicitud + "' LIMIT 1");
                }
                //Console.WriteLine("SELECT s.id, guardado, solicitud, acepta_diligencia, acepta_visitas, actividades_de, texto, fecha_registro, id_bp, id_acta, id_infome, testigos, fecha_apertura, hora_apertura, inspector_acreditado, credencial_acreditado, inspector_capacitacion, credencial_capacitacion, razon_social, domicilio, no_escrito_comision, responsable, no_informe, acepta_diligencia, testigo1, identificacion1, no_identificacion1, edad1, domicilio1, testigo2, identificacion2, no_identificacion2, edad2, domicilio2 FROM sinca.di_solicitud s LEFT JOIN sinca.di_testigos t ON t.id = s.testigos INNER JOIN sinca.di_datos_acta da ON da.id = s.id_acta WHERE s.id_solicitud = '" + id_solicitud + "' LIMIT 1");
                //MessageBox.Show("" + Datos.Tables[0].Rows.Count);
                if (Datos.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        di_solicitud = Convert.ToInt32(row["id"]);
                        string fecha = Convert.ToString(row["fecha_cierre"]);
                        acta = Convert.ToString(row["id_acta"]);
                        string hora = Convert.ToString(row["hora_cierre"]);

                        txtTexto.Text = Convert.ToString(row["observaciones_visitado"]);

                        if (fecha == "" || hora == "" || fecha == null || hora == null)
                        {
                            dtpFechaActa.Value = DateTime.Now;
                            dtpHoraActa.Value = DateTime.Now;
                            pbGuardado.Hide();
                        }
                        else
                        {
                            dtpFechaActa.Value = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            dtpHoraActa.Value = DateTime.ParseExact(hora, "HH:mm:ss", CultureInfo.InvariantCulture);
                            pbGuardado.Show();
                        }

                        //string acta = ConexionMysql.regresaCampoConsulta("SELECT id_acta FROM sinca.di_solicitud WHERE di_solicitud='" + di_solicitud + "' LIMIT 1");

                        ConexionMysql.llenaDataset(ref DatosActa, "SELECT `produccion`, `granel`, `granel_proceso`, `granel_envasado`, `granel_envasado_proceso`, `maduracion`, `producto_terminado`, `producto_no_terminado`,`texto_produccion`, `texto_granel`, `texto_granel_proceso`, `texto_granel_envasado`, `texto_granel_envasado_proceso`, `texto_maduracion`, `texto_terminado`, `texto_no_terminado` FROM sinca.di_datos_acta WHERE id='" + acta + "' LIMIT 1");
                        Console.WriteLine("SELECT `produccion`, `granel`, `granel_proceso`, `granel_envasado`, `granel_envasado_proceso`, `maduracion`, `producto_terminado`, `producto_no_terminado`,`texto_produccion`, `texto_granel`, `texto_granel_proceso`, `texto_granel_envasado`, `texto_granel_envasado_proceso`, `texto_maduracion`, `texto_terminado`, `texto_no_terminado`  FROM sinca.di_datos_acta WHERE id='" + acta + "' LIMIT 1");
                        foreach (DataRow row2 in DatosActa.Tables[0].Rows)
                        {
                            if (Convert.ToString(row2["produccion"]) == "1") { 
                                pbProduccion.Show();
                                txtProduccion.Text = Convert.ToString(row2["texto_produccion"]);
                            }
                            else{
                                txtProduccion.Text = "LOS PRODUCTOS INDICADOS EN LA TABLA No. 3. SE ENCUENTRAN EN PROCESO POR LO QUE NO SE HA PODIDO CONCLUIR LA EVALUACIÓN DE LA CONFORMIDAD RESPECTIVA DE ACUERDO A LO INDICADO EN EL APARTADO 8 DE LA NOM-070-SCFI-2016.";
                            }
                            if (Convert.ToString(row2["granel_proceso"]) == "1") {
                                txtGranelProceso.Text = Convert.ToString(row2["texto_granel_proceso"]);
                                pbGranelProceso.Show();
                            }
                            else
                            {
                                txtGranelProceso.Text = "LOS PRODUCTOS INDICADOS EN LA TABLA No. 2. SE ENCUENTRAN EN PROCESO POR LO QUE NO SE HA PODIDO CONCLUIR LA EVALUACIÓN DE LA CONFORMIDAD RESPECTIVA DE ACUERDO A LO INDICADO EN EL APARTADO 8 DE LA NOM-070-SCFI-2016.";
                            }
                            if (Convert.ToString(row2["granel"]) == "1") {
                                pbGranel.Show();
                                txtGranel.Text = Convert.ToString(row2["texto_granel"]);
                            }
                            else
                            {
                                txtGranel.Text = "DE CONFORMIDAD CON EL APARTADO 4.1. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EL MAGUEY O AGAVE UTILIZADO EN LA PRODUCCIÓN DE MEZCAL SE ENCUENTRA INSCRITO EN EL REGISTRO DE PREDIOS DE AMMA Y SE CUENTA CON LA GUÍA DE MAGUEY RESPECTIVA, POR LO QUE SE ENCUENTRA MADURO Y PROVIENE DE ENTIDADES FEDERATIVAS, MUNICIPIOS Y REGIONES QUE SEÑALA LA DECLARACIÓN GENERAL DE PROTECCIÓN A LA DENOMINACIÓN DE ORIGEN “MEZCAL”, EN VIGOR.\r\nDE CONFORMIDAD CON LOS APARTADOS 4.2., 4.3., 4.4. Y 4.5. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EL MEZCAL EN SUS DIFERENTES CATEGORÍAS Y CLASES SE ENCUENTRAN EN CUMPLIMIENTO.\r\nDE CONFORMIDAD CON EL APARTADO 8. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EN LA PRODUCCIÓN DE MEZCAL EL PRODUCTOR NO HA ADULTERADO EL PRODUCTO EN NINGUNA DE SUS ETAPAS DE ELABORACIÓN MANTENIENDO LA TRAZABILIDAD Y EL BALANCE DE LOS MATERIALES.";
                            }
                            if (Convert.ToString(row2["granel_envasado"]) == "1") {
                                pbGEnvasado.Show();
                                txtGEnvasado.Text = Convert.ToString(row2["texto_granel_envasado"]);
                            }
                            else
                            {
                                txtGEnvasado.Text = "DE CONFORMIDAD CON EL APARTADO 5 Y 8. DE LA NOM-070 SE CONSTATA OCULARMENTE Y A TRAVÉS DE LOS REGISTROS Y/O BITÁCORAS QUE EL PRODUCTO NO HA SIDO ADULTERADO MANTENIENDO LA TRAZABILIDAD. TODO EL PRODUCTO EN EL ALMACÉN DE GRÁNELES DE LA ENVASADORA SE ENCUENTRA SELLADO. LAS ETIQUETAS DE RESGUARDO DE PRODUCTO NO PRESENTAN SIGNOS DE HABER SIDO VIOLADAS O ALTERADAS.";                           
                            }
                            if (Convert.ToString(row2["granel_envasado_proceso"]) == "1") {
                                pbEnvasadoP.Show();
                                txtEnvasadoProceso.Text = Convert.ToString(row2["texto_granel_envasado_proceso"]);
                            }
                            else
                            {
                                txtEnvasadoProceso.Text = "LOS PRODUCTOS INDICADOS EN LA TABLA No. 5. SE ENCUENTRAN EN PROCESO POR LO QUE NO SE PODIDO CONCLUIR LA EVALUACIÓN DE LA CONFORMIDAD RESPECTIVA DE ACUERDO A LO INDICADO EN EL APARTADO 5 Y 8 DE LA NOM-070-SCFI-2016.";                            
                            }
                            if (Convert.ToString(row2["maduracion"]) == "1") {
                                pbMaduracion.Show();
                                txtMaduracion.Text = Convert.ToString(row2["texto_maduracion"]);
                            }
                            else
                            {
                                txtMaduracion.Text = "LOS PRODUCTOS INDICADOS EN LA TABLA No. 6. SE ENCUENTRAN EN PROCESO POR LO QUE NO SE PODIDO CONCLUIR LA EVALUACIÓN DE LA CONFORMIDAD RESPECTIVA DE ACUERDO A LO INDICADO EN EL APARTADO 5 Y 8 DE LA NOM-070-SCFI-2016.";                            
                            }
                            if (Convert.ToString(row2["producto_terminado"]) == "1") {
                                pbTerminado.Show();
                                txtTerminado.Text = Convert.ToString(row2["texto_terminado"]);
                            }
                            else
                            {
                                txtTerminado.Text = "EL ENVASADOR UTILIZA RECIPIENTES RESISTENTES LOS CUALES PREVIO A SU LLENADO SE LAVAN CON AGUA POTABLE O MEZCAL CON EL FIN DE QUE NO CONTENGAN O GENEREN SUSTANCIAS QUE ALTEREN LAS PROPIEDADES FÍSICAS, QUÍMICAS Y SENSORIALES DEL PRODUCTO.\r\nTODO EL PRODUCTO ENVASADO ESTÁ CONTENIDO EN CAJAS DE CARTÓN DEBIDAMENTE MARCADAS Y ETIQUETADAS. \r\nTODO EL PRODUCTO ENVASADO OSTENTA SELLOS DE CERTIFICACIÓN, LOS CUALES ESTÁN ADHERIDOS A LAS ETIQUETAS SIN RASPADURAS O SIGNOS DE HABER SIDO REUTILIZADOS.\r\nTODO EL PRODUCTO ENVASADO CUMPLE SATISFACTORIAMENTE CON EL MARCADO Y ETIQUETADO EN EL ENVASE. EL CLIENTE EMPLEA ETIQUETAS APROBADAS POR EL ORGANISMO DE CERTIFICACIÓN, LO CUAL HACE CONSTAR EXHIBIENDO EL INFORME NO. _________ DE APROBACIÓN DE LAS ETIQUETAS.\r\nEL ENVASADOR CUENTA CON SISTEMAS DIFERENCIADOS DE ENVASADO Y NO HA ADULTERADO EL PRODUCTO EN NINGUNA DE SUS ETAPAS DE ENVASADO MANTENIENDO LA TRAZABILIDAD Y EL BALANCE DE LOS MATERIALES.\r\nEL ENVASADOR CUENTA CON LAS BITÁCORAS ACTUALIZADAS DEL PRODUCTO TERMINADO DESCRIBIENDO LAS ENTRADAS Y SALIDAS DE PRODUCTO DEL ALMACÉN.\r\nTODO EL PRODUCTO TERMINADO CUENTA CON ANÁLISIS FISICOQUÍMICO EN CUMPLIMIENTO CON EL APARTADO 4.3. DE LA NOM-070.";                         
                            }
                            if (Convert.ToString(row2["producto_no_terminado"]) == "1") {
                                pbNoTerminado.Show();
                                txtNoTerminado.Text = Convert.ToString(row2["texto_no_terminado"]);
                            }
                            else
                            {
                                txtNoTerminado.Text = "LOS PRODUCTOS INDICADOS EN LA TABLA No. 8. SE ENCUENTRAN EN PROCESO POR LO QUE NO SE PODIDO CONCLUIR LA EVALUACIÓN DE LA CONFORMIDAD RESPECTIVA DE ACUERDO A LO INDICADO EN EL APARTADO 5, 6, 7 Y 8 DE LA NOM-070-SCFI-2016.";
                            }     
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void dgvGranel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
