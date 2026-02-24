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

namespace Crm.Inventario
{
    public partial class FrmMovimientosVidrio : Form
    {
        public FrmMovimientosVidrio()
        {
            InitializeComponent();
        }
        Validacion valida = new Validacion();
        public string fecha;
        public string id_granel_movimiento;
        public string id_granel_produccion;
        public string folio;
        public string no_lote;
        public string categoria;
        public string fq;
        public string abocante;
        public string ingrediente;
        public string litros;
        public string grado_alcoholico;
        public string no_cliente;
        public string no_contenedores;
        public string maguey;
        public string tipo;
        string id_max_granel_entrada;
        string id_max_granel_movimientos;
        string id_max_granel_entrada_envasado;
        string id_max_granel_movimientos_envasado;
        string id_max_granel_ensamble;
        string id_max_granel_ensamble_envasado;

        string id_max_granel_tanque;
        string id_max_granel_tanque_envasado;
        DataSet dtsTanques;

        /////------ almacen --- 

        string id_max_almacen_granel_entrada;
        string id_max_almacen_granel_movimientos;
         string id_max_almacen_granel_tanque;
        string id_max_almacen_granel_ensamble;








        //obtencion de los id para todos los tanques entrada
        public void ObtenerIdMaximoGranelTanque()
        {
            id_max_granel_tanque = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM granel_tanques where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_tanque == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_tanque = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_tanque) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_tanque = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        public void ObtenerIdMaximoAlmacenGranelTanque()
        {
            id_max_almacen_granel_tanque = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM almacen_granel_tanques where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_granel_tanque == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_tanque = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_tanque = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_tanque) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_tanque = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_tanque = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todos los tanques_envasado entrada
        public void ObtenerIdMaximoGranelTanqueEnvasado()
        {
            id_max_granel_tanque_envasado = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM granel_tanques_envasado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_tanque_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_tanque_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_tanque_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_tanque_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_tanque_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }





        //obtencion de los id para todas las entradas a granel 
        public void ObtenerIdMaximoGranelEntrada()
        {
            id_max_granel_entrada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_entrada,4)) )   FROM granel_entrada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_entrada = Usuario.IdUsuario + "-1";
                } 
            }
            else
            {
                int suma = int.Parse(id_max_granel_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        public void ObtenerIdMaximoAlmacenGranelEntrada()
        {
            id_max_almacen_granel_entrada = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_granel_entrada,4)) )   FROM almacen_granel_entrada where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_granel_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }


        //obtencion de los id para todas las entradas a granel  envasado
        public void ObtenerIdMaximoGranelEntradaEnvasado()
        {
            id_max_granel_entrada_envasado = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_entrada_envasado,4)) )   FROM granel_entrada_envasado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_entrada_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_entrada_envasado = Usuario.IdUsuario + "-1";
                } 
            }
            else
            {
                int suma = int.Parse(id_max_granel_entrada_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_entrada_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }



        //obtencion de los id para todas las entradas a granel movimientos
        public void ObtenerIdMaximoGranelMovimientos()
        {
            id_max_granel_movimientos = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_movimientos,4)) )   FROM granel_movimientos where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_movimientos = Usuario.IdUsuario + "-1";
                } 
            }
            else
            {
                int suma = int.Parse(id_max_granel_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        public void ObtenerIdMaximoAlmacenGranelMovimientos()
        {
            id_max_almacen_granel_movimientos = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_granel_movimientos,4)) )   FROM almacen_granel_movimientos where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_granel_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_movimientos = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }
        }



        //obtencion de los id para todas las entradas a granel movimientos envasado
        public void ObtenerIdMaximoGranelMovimientosEnvasado()
        {
            id_max_granel_movimientos_envasado = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_movimientos_envasado,4)) )   FROM granel_movimientos_envasado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_movimientos_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_movimientos_envasado = Usuario.IdUsuario + "-1";
                } 
            }
            else
            {
                int suma = int.Parse(id_max_granel_movimientos_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_movimientos_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

         public void ObtenerIdMaximoGranelEnsamble()
        {
            id_max_granel_ensamble = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_ensamble,4)) )   FROM granel_ensamble where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_ensamble = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_ensamble = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        public void ObtenerIdMaximoAlmacenGranelEnsamble()
        {
            id_max_almacen_granel_ensamble = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_granel_ensamble,4)) )   FROM almacen_granel_ensamble where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_granel_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_ensamble = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_ensamble = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        public void ObtenerIdMaximoGranelEnsambleEnvasado()
        {
            id_max_granel_ensamble_envasado = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_granel_ensamble,4)) )   FROM granel_ensamble_envasado where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_granel_ensamble_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_ensamble_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_ensamble_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_ensamble_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void FrmMovimientosVidrio_Load(object sender, EventArgs e)
        {

              string timevidrio = "";


            addTablaTanques();
            string clase;
            DateTime fechaHoy = DateTime.Now;
            string fecha_salida = fechaHoy.ToString("d");
            lblNoLote.Text = no_lote;
            LblFechaIngreso.Text = fecha;
            LblFechaSalida.Text = fecha_salida;
            LblEspecie.Text = maguey;
            //calcula los meses y los años entre dos fechas
            DateTime fi = DateTime.Parse(fecha);
            DateTime ft = DateTime.Parse(fecha_salida);
            int AntMeses = 0, AntAños = 0;
            int DiasFI = fi.Day, MesFI = fi.Month, AñoFI = fi.Year;
            int DiasFT = ft.Day, MesFT = ft.Month, AñoFT = ft.Year;
            if (DiasFT < DiasFI)
            {
                DiasFT += 30;
                MesFT -= 1;
            }
            if (MesFT < MesFI)
            {
                MesFT += 12;
                AñoFT -= 1;
            }
            // calcula meses de antiguedad
            AntMeses = MesFT - MesFI;
            // calcula años antiguedad
            AntAños = AñoFT - AñoFI;

            if (AntAños >= 1)
            {
                clase = "Madurado en vidrio";
                timevidrio = Convert.ToString(AntAños)+" Año(s)";
            }

            else
            {
                clase = "Joven";
                timevidrio = Convert.ToString(AntMeses)+ " Meses";
            }

            LblClase.Text = clase;
            LblCategoria.Text = categoria;
            LblFolio.Text = folio;
            LblFq.Text = fq;
            LblIngrediente.Text = ingrediente;
            LblTimevidrio.Text = timevidrio;
            LblLitros.Text = litros;
            LblGradoAlcoholico.Text = grado_alcoholico;
            LblContenedores.Text = no_contenedores;
        }

        //esta funciones para agregar la imagen a las tablas
        public static byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
            return Ret;
        }


        // crear tabla de produccion  para guardar el registro agranel
        private void addTablaTanques()
        {
            dtsTanques = new DataSet();
            dtsTanques.Tables.Add("TANQUES");
            dtsTanques.Tables["TANQUES"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanques.Tables["TANQUES"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaTanques.DataSource = dtsTanques.Tables["TANQUES"];
        }

        //guarda el lote madurado en vidri a granel
        private void BtnGuardarVidrioAGranel_Click(object sender, EventArgs e)
        {
            if (TxtLitros.Text == "")
            {
                MessageBox.Show("Debe ingresar litros");
                return;
            }
            if (TxtLitros.Text == ".")
            {
                MessageBox.Show("Debe introducir una cantidad de litros real");
                return;
            }
            if (TxtGradoAlcoholico.Text == ".")
            {
                MessageBox.Show("Debe introducir un grado alcoholico real ");
                return;
            }
            if (TxtNoLote.Text == "")
            {
                MessageBox.Show("Debe introducir un numero de lote");
                return;
            }
            if (double.Parse(TxtLitros.Text) > double.Parse(litros))
            {
                MessageBox.Show("Litros insuficientes");
                return;
            }
            if (DtaTanques.Rows.Count == 0)
            {
                MessageBox.Show("No ha introduccido ningun tanque");
                return;
            }

            if ( txtNVidrio.Text == "")
            {
                MessageBox.Show("Debe introducir un numero de tanques en vidrio a liberar");
                return;
            }

            DialogResult check = MessageBox.Show("Verifica que los datos sean correctos", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {
                
                string id_comun = "";
                string id_planta = "";
                string id_predio = "";
                string id_fabrica = "";
                string id_almacen = "";
                string id_envasadora = "";
                string litros2 = "";
                string agave_coccion_kg = "";
                DataSet Datos = new DataSet();

                if (tipo == "fabrica")
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT id_fabrica,id_comun,id_planta,id_predio,agave_coccion_kg FROM granel_entrada  WHERE id_granel_entrada='" + id_granel_produccion + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        id_fabrica = Convert.ToString(row["id_fabrica"]);
                        id_comun = Convert.ToString(row["id_comun"]);
                        id_planta = Convert.ToString(row["id_planta"]);
                        id_predio = Convert.ToString(row["id_predio"]);
                        agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    }
                    ObtenerIdMaximoGranelEntrada();
                    
                    if (id_planta != "0")
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica,fecha,no_lote,fq,id_planta,agave_coccion_kg,id_predio,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador,actualizado) VALUES( '" + id_max_granel_entrada + "','" + no_cliente + "','" + id_fabrica + "',now(),'" + TxtNoLote.Text + "','" + fq + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + LblClase.Text + "' , '" + categoria + "','" + abocante + "','" + ingrediente + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",NOW()," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("4");
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada(id_granel_entrada,no_cliente,id_fabrica,fecha,no_lote,fq,id_comun,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador,actualizado) VALUES('" + id_max_granel_entrada + "', '" + no_cliente + "','" + id_fabrica + "',now(),'" + TxtNoLote.Text + "','" + fq + "'," + id_comun + ",'" + LblClase.Text + "' , '" + categoria + "','" + abocante + "','" + ingrediente + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",NOW()," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                        DataSet Datos2 = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos2, "SELECT id_comun,id_planta,id_predio,litros,agave_coccion_kg FROM granel_ensamble  WHERE id_granel_entrada='" + id_granel_produccion + "'");
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {
                            id_comun = Convert.ToString(row["id_comun"]);
                            id_planta = Convert.ToString(row["id_planta"]);
                            id_predio = (Convert.ToString(row["id_predio"]) == "") ? "0": Convert.ToString(row["id_predio"]);
                            litros2 = Convert.ToString(row["litros"]);
                            agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                             ObtenerIdMaximoGranelEnsamble();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,actualizado) VALUES('"+id_max_granel_ensamble+"','"+ id_max_granel_entrada + "'," + id_comun + "," + id_planta + "," + id_predio + "," + litros2 + "," + agave_coccion_kg + ",0 )") == "Error")
                            {
                                return;
                            }
                        }
                    }
                    ObtenerIdMaximoGranelMovimientos();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_movimientos(id_granel_movimientos,id_granel_entrada,id_gran_mov_salio,tipo,destino,litros,grado_alcoholico,fecha,fecha_movimiento,actualizado,id_verificador) VALUES('" + id_max_granel_movimientos + "', '" + id_max_granel_entrada + "','" + id_granel_movimiento + "','entrada','granel-vidrio' , " + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",now(),now(), 0," + Usuario.IdUsuario + ")") == "Error")
                    {
                        return;
                    }

                    if (ConexionMysql.insUpd_transaccion("UPDATE granel_movimientos SET litros_existentes=ROUND(litros_existentes-" + TxtLitros.Text + ",2), numero_de_contenedores=ROUND(numero_de_contenedores-" + txtNVidrio.Text + ",2), actualizado=0 where id_granel_movimientos='" + id_granel_movimiento + "' ") == "Error")
                    {
                        return;
                    }

                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGranelTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques(id_tanque,id_granel_entrada,tanque,actualizado,id_verificador) VALUES( '" + id_max_granel_tanque + "','" + id_max_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "',0," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }

                    
                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + id_granel_produccion + "' and tipo_instalacion='granel_fabrica'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_fabrica','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    } 


                    ConexionMysql.transCompleta();
                    MessageBox.Show("Liberacion realizada con exito");
                    this.Close();
                } /// ==== fin de granel fabrica ====
                else if (tipo == "almacen")
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT id_almacen,id_comun,id_planta,id_predio,agave_coccion_kg FROM almacen_granel_entrada  WHERE id_almacen_granel_entrada='" + id_granel_produccion + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        id_almacen = Convert.ToString(row["id_almacen"]);
                        id_comun = Convert.ToString(row["id_comun"]);
                        id_planta = Convert.ToString(row["id_planta"]);
                        id_predio = Convert.ToString(row["id_predio"]);
                        agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    }
                    ObtenerIdMaximoAlmacenGranelEntrada();
                    if (id_planta != "0")
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen,fecha,no_lote,fq,id_planta,agave_coccion_kg,id_predio,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador,actualizado) VALUES( '" + id_max_almacen_granel_entrada + "','" + no_cliente + "','" + id_almacen + "',now(),'" + TxtNoLote.Text + "','" + fq + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + LblClase.Text + "' , '" + categoria + "','" + abocante + "','" + ingrediente + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",NOW()," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente,id_almacen,fecha,no_lote,fq,id_comun,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador,actualizado) VALUES('" + id_max_almacen_granel_entrada + "', '" + no_cliente + "','" + id_almacen + "',now(),'" + TxtNoLote.Text + "','" + fq + "'," + id_comun + ",'" + LblClase.Text + "' , '" + categoria + "','" + abocante + "','" + ingrediente + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",NOW()," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                        DataSet Datos2 = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos2, "SELECT id_comun,id_planta,id_predio,litros,agave_coccion_kg FROM almacen_granel_ensamble  WHERE id_almacen_granel_entrada='" + id_granel_produccion + "'");
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {
                            id_comun = Convert.ToString(row["id_comun"]);
                            id_planta = Convert.ToString(row["id_planta"]);
                            id_predio = Convert.ToString(row["id_predio"]);
                            litros2 = Convert.ToString(row["litros"]);
                            agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                            
                            ObtenerIdMaximoAlmacenGranelEnsamble();

                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_planta,id_predio,litros,agave_coccion_kg,actualizado) VALUES('" + id_max_almacen_granel_ensamble + "','" + id_max_almacen_granel_entrada + "'," + id_comun + "," + id_planta + "," + id_predio + "," + litros2 + "," + agave_coccion_kg + ",0 )") == "Error")
                            {
                                return;
                            }
                        }
                    }
                    ObtenerIdMaximoAlmacenGranelMovimientos();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_movimientos(id_almacen_granel_movimientos,id_almacen_granel_entrada,id_almacen_gran_mov_salio,tipo,destino,litros,grado_alcoholico,fecha,fecha_movimiento,actualizado,id_verificador) VALUES('" + id_max_almacen_granel_movimientos + "', '" + id_max_almacen_granel_entrada + "','" + id_granel_movimiento + "','entrada','granel-vidrio' , " + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",now(),NOW(), 0," + Usuario.IdUsuario + ")") == "Error")
                    {
                        return;
                    }

                    if (ConexionMysql.insUpd_transaccion("UPDATE almacen_granel_movimientos SET litros_existentes=ROUND(litros_existentes-" + TxtLitros.Text + ",2), numero_de_contenedores=ROUND(numero_de_contenedores-" + txtNVidrio.Text + ",2), actualizado=0 where id_almacen_granel_movimientos='" + id_granel_movimiento + "' ") == "Error")
                    {
                        return;
                    }

                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoAlmacenGranelTanque();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,actualizado,id_verificador) VALUES( '" + id_max_almacen_granel_tanque + "','" + id_max_almacen_granel_entrada + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "',0," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }


                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + id_granel_produccion + "' and tipo_instalacion='almacen_granel'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'almacen_granel','" + row["id_produccion_entrada"].ToString() + "','" + id_max_almacen_granel_entrada + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }



                    ConexionMysql.transCompleta();
                    MessageBox.Show("Liberacion realizada con exito");
                    this.Close();
                } /// ==== fin de almacen granel ====
                else
                {
                    ConexionMysql.llenaDataset(ref Datos, "SELECT id_envasadora,id_comun,id_planta,id_predio,agave_coccion_kg FROM granel_entrada_envasado  WHERE id_granel_entrada_envasado='" + id_granel_produccion + "'");
                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        id_envasadora = Convert.ToString(row["id_envasadora"]);
                        id_comun = Convert.ToString(row["id_comun"]);
                        id_planta = Convert.ToString(row["id_planta"]);
                        id_predio = Convert.ToString(row["id_predio"]);
                        agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    }
                    ObtenerIdMaximoGranelEntradaEnvasado();
                    if (id_planta != "0")
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora,fecha,no_lote,fq,id_planta,agave_coccion_kg,id_predio,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador,actualizado) VALUES( '" + id_max_granel_entrada_envasado + "','" + no_cliente + "','" + id_envasadora + "',now(),'" + TxtNoLote.Text + "','" + fq + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + LblClase.Text + "' , '" + categoria + "','" + abocante + "','" + ingrediente + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",NOW()," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente,id_envasadora,fecha,no_lote,fq,id_comun,clase,categoria,abocante,ingrediente,lts_entrada,grado_alcoholico_entrada,lts_existentes,grado_alcoholico_existente,fecha_movimiento,id_verificador,actualizado) VALUES('" + id_max_granel_entrada_envasado + "', '" + no_cliente + "','" + id_envasadora + "',now(),'" + TxtNoLote.Text + "','" + fq + "'," + id_comun + ",'" + LblClase.Text + "' , '" + categoria + "','" + abocante + "','" + ingrediente + "'," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + "," + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",NOW()," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                        DataSet Datos2 = new DataSet();
                        ConexionMysql.llenaDataset(ref Datos2, "SELECT id_comun,id_planta,id_predio,litros,agave_coccion_kg FROM granel_ensamble_envasado  WHERE id_granel_entrada_envasado='" + id_granel_produccion + "'");
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {
                            id_comun = Convert.ToString(row["id_comun"]);
                            id_planta = Convert.ToString(row["id_planta"]);
                            id_predio = Convert.ToString(row["id_predio"]);
                            litros2 = Convert.ToString(row["litros"]);
                            agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);

                            ObtenerIdMaximoGranelEnsambleEnvasado();
                            if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_planta,id_predio,litros,agave_coccion_kg,actualizado) VALUES('" + id_max_granel_ensamble_envasado + "','" + id_max_granel_entrada_envasado + "'," + id_comun + "," + id_planta + "," + id_predio + "," + litros2 + "," + agave_coccion_kg + ",0 )") == "Error")
                            {
                                return;
                            }
                        }
                    }
                    ObtenerIdMaximoGranelMovimientosEnvasado();
                    if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_movimientos_envasado(id_granel_movimientos_envasado,id_granel_entrada_envasado,id_gran_mov_salio,tipo,destino,litros,grado_alcoholico,fecha,fecha_movimiento,actualizado,id_verificador) VALUES('" + id_max_granel_movimientos_envasado + "', '" + id_max_granel_entrada_envasado + "','" + id_granel_movimiento + "','entrada','granel-vidrio' , " + TxtLitros.Text + "," + TxtGradoAlcoholico.Text + ",now(),NOW(), 0," + Usuario.IdUsuario + ")") == "Error")
                    {
                        return;
                    }

                    if (ConexionMysql.insUpd_transaccion("UPDATE granel_movimientos_envasado SET litros_existentes=ROUND(litros_existentes-" + TxtLitros.Text + ",2), numero_de_contenedores=ROUND(numero_de_contenedores-" + txtNVidrio.Text + ",2),actualizado=0 where id_granel_movimientos_envasado='" + id_granel_movimiento + "' ") == "Error")
                    {
                        return;
                    }

                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        ObtenerIdMaximoGranelTanqueEnvasado();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,actualizado,id_verificador) VALUES( '" + id_max_granel_tanque_envasado + "','" + id_max_granel_entrada_envasado + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "',0," + Usuario.IdUsuario + ")") == "Error")
                        {
                            return;
                        }
                    }

                    DataSet ids = new DataSet();
                    ConexionMysql.llenaDataset(ref ids, "Select id_produccion_entrada From ids_producciones where id_lote='" + id_granel_produccion + "' and tipo_instalacion='granel_envasado'");

                    foreach (DataRow row in ids.Tables[0].Rows)
                    {
                        ///--- inserta el id de la produccion---
                        string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('" + ids_producciones + "', 'granel_envasado','" + row["id_produccion_entrada"].ToString() + "','" + id_max_granel_entrada_envasado + "'," + Usuario.IdUsuario + ",0)") == "Error")
                        {
                            return;
                        }
                    }




                    ConexionMysql.transCompleta();
                    MessageBox.Show("Liberacion realizada con exito");
                    this.Close();
                }

            }

           
        }

        private void TxtLitros_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitros.Text);
        }

        private void TxtGradoAlcoholico_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoAlcoholico.Text);
        }


        //boton para agregar tanque
        private void BtnAgregarTanque_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtTanque.Text == "")
                {
                    MessageBox.Show("No ha introducido un nombre de tanque");
                    return;
                }
                DataRow fila = dtsTanques.Tables["TANQUES"].NewRow();
                fila["TANQUE"] = TxtTanque.Text;
                fila["QUITAR"] = ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                dtsTanques.Tables["TANQUES"].Rows.Add(fila);
                TxtTanque.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //quita los tanques agregados
        private void DtaTanques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaTanques.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaTanques.Rows.RemoveAt(e.RowIndex);
                    dtsTanques.Tables["TANQUES"].AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNVidrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, txtNVidrio.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
