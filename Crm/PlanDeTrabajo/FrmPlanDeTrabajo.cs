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

namespace Crm.PlanDeTrabajo
{
    public partial class FrmPlanDeTrabajo : Form
    {
        public FrmPlanDeTrabajo()
        {
            InitializeComponent();
        }
        DataSet dts;
        List<string> Lunes = new List<string>();
        List<string> Martes = new List<string>();
        List<string> Miercoles = new List<string>();
        List<string> Jueves = new List<string>();
        List<string> Viernes = new List<string>();


        private void addTablas()
        {
            dts = new DataSet();
            dts.Tables.Add("HORARIO");
            dts.Tables["HORARIO"].Columns.Add("Lunes", Type.GetType("System.String"));
            dts.Tables["HORARIO"].Columns.Add("Martes", Type.GetType("System.String"));
            dts.Tables["HORARIO"].Columns.Add("Miercoles", Type.GetType("System.String"));
            dts.Tables["HORARIO"].Columns.Add("Jueves", Type.GetType("System.String"));
            dts.Tables["HORARIO"].Columns.Add("Viernes", Type.GetType("System.String"));
            DtaHorario.DataSource = dts.Tables["HORARIO"];
            //DtaHorario.Columns[0].Visible = false;
            //DtaExtraccion.Columns[1].Visible = false;
            //DtaExtraccion.Columns[2].Visible = false;
        }

        private void FrmPlanDeTrabajo_Load(object sender, EventArgs e)
        {
            ConexionMysql.conecta();
            addTablas();
          
            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(ref Datos, "SELECT * FROM rutas_clientes");
            if (Datos.Tables[0].Rows.Count == 0)
            {
                return;
            }

            DataRow fila;

            foreach (DataRow row in Datos.Tables[0].Rows)
            {                 
             switch (Convert.ToString(row["dia"]))
                {
                   case "Lunes":
                    Lunes.Add(Convert.ToString(row["no_cliente"]));
                     break;

                    case "Martes":
                        Martes.Add(Convert.ToString(row["no_cliente"]));
                        break;

                    case "Miercoles":
                        Miercoles.Add(Convert.ToString(row["no_cliente"]));
                        break;

                    case "Jueves":
                        Jueves.Add(Convert.ToString(row["no_cliente"]));
                        break;

                    case "Viernes":
                        Viernes.Add(Convert.ToString(row["no_cliente"]));
                        break;

                    //case "Viernes":
                    //    fila = dts.Tables["HORARIO"].NewRow();
                    //    fila["Viernes"] = Convert.ToString(row["no_cliente"]);
                    //    dts.Tables["HORARIO"].Rows.Add(fila);
                    //    break;

                }
            }

            int[] arreglo = { Lunes.Count, Martes.Count, Miercoles.Count, Jueves.Count, Viernes.Count };

            int NumeroMayor = arreglo[0];

            for (int x=1;x<arreglo.Length; x++)
            {
                if (arreglo[x] > NumeroMayor)
                {
                    NumeroMayor = arreglo[x];
                  
                } 
            
            }



            for (int x = 0; x < NumeroMayor; x++)
            {//for recorrer la lista
                fila = dts.Tables["HORARIO"].NewRow();
                if (Lunes.Count>x)
                {
                      fila["Lunes"] = Lunes[x];
                }
                else
                {
                    fila["Lunes"] ="";
                }
                if (Martes.Count > x)
                {
                    fila["Martes"] = Martes[x];   
                }
                else{
                    fila["Martes"] = "";
                }
                if (Miercoles.Count>x)
                {
                    fila["Miercoles"] = Miercoles[x];
                }
                else
                {
                    fila["Miercoles"] = "";
                }

                if (Jueves.Count > x)
                {
                    fila["Jueves"] = Jueves[x];
                }
                else
                {
                    fila["Jueves"] ="";
                }

                if
                (Viernes.Count > x)
                {
                   fila["Viernes"] = Viernes[x];
                }
                else
                {
                   fila["Viernes"] = "";
                }             
                dts.Tables["HORARIO"].Rows.Add(fila);
            }//for recorrer lista






        }

        private void FrmPlanDeTrabajo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConexionMysql.cierraConexion();
        }
    }
}
