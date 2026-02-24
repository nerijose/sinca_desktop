using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crm.Inventario;
using Crm.Subida;
using Crm.Utilerias;
using System.Threading;
using Crm.PlanDeTrabajo;
using Crm.ExtraccionAgave;
using Crm.Mensajes;
using Crm.Consultas;
using System.Globalization;
using Crm.Inventario.Obsevaciones;




namespace Crm.Inicio
{
    public partial class FrmPrincipal : Form
    {
        public Boolean BanderaUsuario = false;
        // public Boolean BanderSB = false;
        public FrmPrincipal()
        {

            InitializeComponent();
            //BtnSubida.Enabled = false;
            //BtnExtraccionAgave.Enabled = false;

            Obtener_name_verificador();

            //----------------------------------------------------------- ToolTips---------------
            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            //toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(BtnCambioUsuario, "Cerrar Sesión");
            toolTip1.SetToolTip(BtnCerrar, "Cerrar");
            toolTip1.SetToolTip(BtnMinimizar, "Minimizar");
            //-----------------------------------------------------------Fin tooltips ---------------

        }


        Boolean bandera = false;
        #region Metodos otros
        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            #region
            DialogResult check = MessageBox.Show("¿Seguro de cerrar SInCa?", "Atento aviso!.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {

                // ConnectionState state = connection.State;
                if (ConexionMysql.conecta() == true)///-- verifica si la conexion esta abierta o cerrada 
                {
                    ConexionMysql.cierraConexion();
                }
                /*else
                {
                    connection.Open();
                    return true;
                } */



                this.Close();
                BanderaUsuario = false;

            }
            #endregion
        }

        private void BtnCambioUsuario_Click(object sender, EventArgs e)
        {
            #region
            DialogResult check = MessageBox.Show("¿Cerrar sesión en ReVeCa?", "Atento aviso!.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {
                if (ConexionMysql.conecta() == true)///-- verifica si la conexion esta abierta o cerrada 
                {
                    ConexionMysql.cierraConexion();
                }
                BanderaUsuario = true;
                this.Close();
            }
            #endregion
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            #region

            //this.Location = new Point(0, 0);
            //this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            LblSubiendo.Visible = false;
            Lblcargandobase.Visible = false;
            Progresbar.Visible = false;
            carga.Visible = false;
            Panelcontainer.Visible = false;


            ///--- habilita el boton de administrador al tener el estatus 3 ---
            if (Usuario.Status == "3") { btnAdministrador.Visible = true; }

            else { btnAdministrador.Visible = false; }

            #endregion
        }
        private void BtnExtraccionAgave_Click(object sender, EventArgs e)
        {
            #region
            pictureBox2.Visible = false;
            FrmExtraccionAgave FrmAgave = new FrmExtraccionAgave();
            //FrmAgave.ShowDialog();
            Abrirhija(FrmAgave);
            #endregion
        }


        //>>>>>>>>>>>>>>>>>>>>>>>>>---Boton subida---<<<<<<<<<<<<<<
        private void BtnSubida_Click(object sender, EventArgs e)
        {
            #region
            DialogResult check = MessageBox.Show("¿Seguro de subir informacion al servidor?", "Atento aviso!.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) { return; }
            else
            {
                try
                {
                    Panelcontainer.Visible = false;
                    pictureBox2.Visible = true;
                    // BanderSB = true;
                    //FrmSubida frm = new FrmSubida();
                    //frm.ShowDialog();
                    carga.Visible = true;
                    ConexionMysqlRemota2.conecta();
                    string activado = ConexionMysqlRemota2.regresaCampoConsulta("SELECT activado FROM rv_carga_descarga_libre");
                    string fecha = ConexionMysqlRemota2.regresaCampoConsulta("SELECT now()");
                   
                    //TODO: consulta de información para saber si puede el usuario subir información
                    string UserNames = Usuario.NombreUsuario;
                     string permisoPersonalSubida = ConexionMysqlRemota2.regresaCampoConsulta("SELECT subida FROM verificadores where nombre = '" + UserNames + "'");
                     ConexionMysqlRemota2.cierraConexion();

                     if (permisoPersonalSubida == "0")
                     {
                         MessageBox.Show("Lo sentimos, no tienes permiso para subir información\nComunícate con tu jefe directo para solicitar el desbloqueo");
                         return;
                     }

                     else { 
                    if (activado == "0")
                    {
                        DateTime local = Convert.ToDateTime(fecha);
                        int hour = local.Hour;
                        int minute = local.Minute;

                        if (hour >= 18 && hour <= 23 && minute <= 59)
                        {
                           //ConexionMysql.insUpd_transaccion("UPDATE su_ba SET Estado=1");// linea agregada para Actualizar el estado del log --2020
                            this.Progresbar.Value = 0;
                            this.Progresbar.Increment(0);
                            LblSubiendo.Visible = true;
                            Progresbar.Visible = true;
                            carga.Visible = true;
                            //este metodo ejecuta el trabajo del backgroundworker funciones en segundo plano
                            backgroundWorker_Subida.RunWorkerAsync();
                        }
                        else
                        {
                            MessageBox.Show("Fuera de horario, intentalo en un horario de 6:00 pm a 11:59 pm");
                            carga.Visible = false;
                        }
                    }
                    else
                    {
                       // ConexionMysql.insUpd_transaccion("UPDATE su_ba SET Estado=1"); // linea agregada para Actualizar el estado del log --2020
                        this.Progresbar.Value = 0;
                        this.Progresbar.Increment(0);
                        LblSubiendo.Visible = true;
                        Progresbar.Visible = true;
                        carga.Visible = true;
                        //este metodo ejecuta el trabajo del backgroundworker funciones en segundo plano
                        backgroundWorker_Subida.RunWorkerAsync();
                    }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Lblcargandobase.Visible = false;
                    Progresbar.Visible = false;
                    carga.Visible = false;
                }
            }//-- fin del else que pertenece al  DialogResult 
            #endregion
        }

        #endregion
        //>>>>>>>>>>>>>>>>>>>----- Boton Actualizar----<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        private void actualizaReVeCa()
        {
            #region
            DialogResult check = MessageBox.Show("¿Seguro de actualizar la informacion?", "Atento aviso!.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) {
                string UserName = Usuario.NombreUsuario;
                MessageBox.Show(UserName);
                return; }
            else
            {
                //Panelcontainer.Visible = false;
                //pictureBox2.Visible = true;

                try
                {

                    carga.Visible = true;
                    ConexionMysqlRemota2.conecta();
                    string activado = ConexionMysqlRemota2.regresaCampoConsulta("SELECT activado FROM rv_carga_descarga_libre");
                    //consulta de información para saber si puede el usuario descargar información
                   /* string permisoPersonalBajada = ConexionMysqlRemota2.regresaCampoConsulta("SELECT bajada FROM verificadores where");
                    string UserName = Usuario.NombreUsuario;*/
                    string fecha = ConexionMysqlRemota2.regresaCampoConsulta("SELECT now()");

                    ConexionMysqlRemota2.cierraConexion();


                    /* @adnto 0 significa q esta cerrado el canal
                 si esta cerrado el canal quiere decir que no esta en horario permitido, 
                 pero si se abre desde la página web, entonces no importará el horario*/
                    /*if (permisoPersonalBajada == "0")
                    {
                        MessageBox.Show("Lo sentimos, no tienes permiso para descargar información\nComunícate con tu jefe directo para solicitar el desbloqueo");
                        return;
                    }
                    else
                    { */
                    if (activado == "0")
                    {
                        DateTime local = Convert.ToDateTime(fecha);
                        int hour = local.Hour;
                        int minute = local.Minute;

                        if (hour >= 5 && hour <= 8)
                        {

                            /*@adnto se verifica el status activado primero.
                       aquí entrará cuando a lo mejor el canal haya quedado cerrado 
                       pero si este dentro del horario permitido entonces se dejará descargar
                       MessageBox.Show("dentro del horario ");*/

                            //this.timer1.Start();
                            this.Progresbar.Value = 0;
                            this.Progresbar.Increment(0);
                            Lblcargandobase.Visible = true;
                            Progresbar.Visible = true;
                            carga.Visible = true;
                            //este metodo ejecuta el trabajo del backgroundworker funciones en segundo plano
                            backgroundWorker.RunWorkerAsync();
                        }
                        else
                        {
                            MessageBox.Show("Fuera de horario, intentalo de 5:00 am a 09:00 am");
                            carga.Visible = false;
                        }
                    }
                    else
                    {
                        /* @adnto si esta abierto el canal se podrá
                    * realizar la descarga, no importando la hora, se podría sintetizar en un if con un or */
                        //MessageBox.Show(" else, activado!=0 \n canal abierto descargando ... ");
                        this.Progresbar.Value = 0;
                        this.Progresbar.Increment(0);
                        Lblcargandobase.Visible = true;
                        Progresbar.Visible = true;
                        carga.Visible = true;
                        //este metodo ejecuta el trabajo del backgroundworker funciones en segundo plano
                        backgroundWorker.RunWorkerAsync();
                    }
                    //}//fin else de permiso personal de descarga 2021
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Lblcargandobase.Visible = false;
                    Progresbar.Visible = false;
                    carga.Visible = false;
                }


            }//--- fin del else de  DialogResult
            #endregion
        } //-- fin de actualizaReVeCa



        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            #region comentarios
            //---r@le---- en proceso...........
            /* if (Veri_movimientos.produccion != true)
             {

                 Panelcontainer.Visible = false;
                 pictureBox2.Visible = true;//---img del logo

                 actualizaReVeCa();

             }
             else { 
            
                 DialogResult check = MessageBox.Show("Se encontraron registros que requieren ser subidos al servidos antes de actualizar!\n\n ¿ Subir la informacion?", "Atento aviso!.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                 if (check == DialogResult.Cancel) { return; }
                 else
                 {
                     Panelcontainer.Visible = false;
                     pictureBox2.Visible = true;
                     BtnSubida_Click(sender, e);

                     //if (Veri_movimientos.produccion == false) { BtnActualizar_Click(sender, e); }
                
                 }

            
             }*/
            #endregion

            #region Codigo
            DialogResult check = MessageBox.Show("¿Seguro de actualizar la informacion?", "Atento aviso!.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (check == DialogResult.Cancel) {               
                return; }

            else
            {
                //INICIO DE VERIFICACIÓN DE DESCARGA(SI SE PUEDE O NO) -----2020
                ConexionMysql.conecta();
                string edo = ConexionMysql.regresaCampoConsulta("Select Estado from su_ba");
                
                if (edo == "0")
                {
                    MessageBox.Show("Ya realizaste movimientos, necesitas subir informción antes de descargar");
                    //return;
                }
                else //Aqui finaliza la verificación y entra el procedimiento normal que existía.----2020
                

                    Panelcontainer.Visible = false;
                    pictureBox2.Visible = true;
                    // BanderSB = false;
                    try
                    {
                        carga.Visible = true;
                        ConexionMysqlRemota2.conecta();
                        string activado = ConexionMysqlRemota2.regresaCampoConsulta("SELECT activado FROM rv_carga_descarga_libre");
                        string fecha = ConexionMysqlRemota2.regresaCampoConsulta("SELECT now()");
                    //TODO: consulta de información para saber si puede el usuario descargar información de forma personalizada
                    string UserName = Usuario.NombreUsuario;
                    string permisoPersonalBajada = ConexionMysqlRemota2.regresaCampoConsulta("SELECT bajada FROM verificadores where nombre = '" + UserName + "'");
                    
                    ConexionMysqlRemota2.cierraConexion();

                    if (permisoPersonalBajada == "0")
                    {
                        MessageBox.Show("Lo sentimos, no tienes permiso para descargar información\nComunícate con tu jefe directo para solicitar el desbloqueo");
                        return;
                    }
                    else { 
                                  

                        /* @adnto 0 significa q esta cerrado el canal
                     si esta cerrado el canal quiere decir que no esta en horario permitido, 
                     pero si se abre desde la página web, entonces no importará el horario*/

                        if (activado == "0")
                        {
                            DateTime local = Convert.ToDateTime(fecha);
                            int hour = local.Hour;
                            int minute = local.Minute;

                            if (hour >= 5 && hour <= 8)
                            {

                                /*@adnto se verifica el status activado primero.
                           aquí entrará cuando a lo mejor el canal haya quedado cerrado 
                           pero si este dentro del horario permitido entonces se dejará descargar
                           MessageBox.Show("dentro del horario ");*/

                                //this.timer1.Start();
                                this.Progresbar.Value = 0;
                                this.Progresbar.Increment(0);
                                Lblcargandobase.Visible = true;
                                Progresbar.Visible = true;
                                carga.Visible = true;
                                //este metodo ejecuta el trabajo del backgroundworker funciones en segundo plano
                                backgroundWorker.RunWorkerAsync();

                            }
                            else
                            {
                                MessageBox.Show("Fuera de horario, intentalo de 5:00 am a 09:00 am");
                                carga.Visible = false;
                            }
                        }
                        else
                        {
                            /* @adnto si esta abierto el canal se podrá
                        * realizar la descarga, no importando la hora, se podría sintetizar en un if con un or */
                            //MessageBox.Show(" else, activado!=0 \n canal abierto descargando ... ");
                            this.Progresbar.Value = 0;
                            this.Progresbar.Increment(0);
                            Lblcargandobase.Visible = true;
                            Progresbar.Visible = true;
                            carga.Visible = true;
                            //este metodo ejecuta el trabajo del backgroundworker funciones en segundo plano
                            backgroundWorker.RunWorkerAsync();

                        }
                   }
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Lblcargandobase.Visible = false;
                        Progresbar.Visible = false;
                        carga.Visible = false;
                    }
                
            }//--- fin del else de  DialogResult

            #endregion

        }
        

        
        #region MEtodos para Actualizar info modificada por el ADMIN(SUBIR)
        // actualiza guias de extracion viejo metodo 2022 se hace cambio
        public Boolean ActualizarNuevasGuiasDeExtraccionViejoMetodo()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM cextracciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values_guias = "";
                string sql_ins_guias = "INSERT INTO cextracciones (id_extraccion,id_paraje,status,fecha) VALUES";
                DataSet GuiasExtraccion = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref GuiasExtraccion, "SELECT id_extraccion,id_paraje,status,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha FROM cextracciones where id>" + id_max_local + "");
                if (GuiasExtraccion.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in GuiasExtraccion.Tables[0].Rows)
                {
                    string id_extraccion = Convert.ToString(row["id_extraccion"]);
                    string id_paraje = Convert.ToString(row["id_paraje"]);
                    string status = Convert.ToString(row["status"]);
                    string fecha = Convert.ToString(row["fecha"]);
                    values_guias += sep + "('" + id_extraccion + "','" + id_paraje + "'," + status + ",'" + fecha + "')";
                    sep = ",";
                }
                sql_ins_guias += values_guias + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins_guias) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        // Nuevo metodo que permite hacer update
        public Boolean ActualizarNuevasGuiasDeExtraccion()
        {
            try
            {
               /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM cextracciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }*/
                string sep = "";
                string values_guias = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins_guias = "INSERT INTO cextracciones (id_extraccion,id_paraje,status,fecha) VALUES";
                DataSet GuiasExtraccion = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref GuiasExtraccion, "SELECT id_extraccion,id_paraje,status,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, actualizado FROM cextracciones");
                if (GuiasExtraccion.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in GuiasExtraccion.Tables[0].Rows)
                {
                                        
                    string guia = ConexionMysql.regresaCampoConsulta("SELECT id_extraccion from cextracciones where id_extraccion='" + Convert.ToString(row["id_extraccion"]) + "'");
                    if (guia != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE cextracciones SET  status= '" + Convert.ToString(row["status"]) + "'," +
                                "id_paraje='" + Convert.ToString(row["id_paraje"]) + "'" +
                                " WHERE id_extraccion='" + Convert.ToString(row["id_extraccion"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_extraccion = Convert.ToString(row["id_extraccion"]);
                        string id_paraje = Convert.ToString(row["id_paraje"]);
                        string status = Convert.ToString(row["status"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        values_guias += sep + "('" + id_extraccion + "','" + id_paraje + "'," + status + ",'" + fecha + "')";
                        sep = ",";
                    }

                    
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql_ins_guias += values_guias + ";";
                    if (ConexionMysql.insUpd_transaccion(sql_ins_guias) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean ActualizarNuevasGuiasDeExtraccionAntiguas()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_extraccion) AS id_max FROM reveca2_cextracciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values_guias = "";
                string sql_ins_guias = "INSERT INTO reveca2_cextracciones (id_extraccion,id_paraje,status,fecha) VALUES";
                DataSet GuiasExtraccion = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref GuiasExtraccion, "SELECT id_extraccion,id_paraje,status,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha FROM crm_cextracciones where id_extraccion>" + id_max_local + "");
                if (GuiasExtraccion.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in GuiasExtraccion.Tables[0].Rows)
                {
                    string id_extraccion = Convert.ToString(row["id_extraccion"]);
                    string id_paraje = Convert.ToString(row["id_paraje"]);
                    string status = Convert.ToString(row["status"]);
                    string fecha = Convert.ToString(row["fecha"]);
                    values_guias += sep + "('" + id_extraccion + "','" + id_paraje + "'," + status + ",'" + fecha + "')";
                    sep = ",";
                }
                sql_ins_guias += values_guias + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins_guias) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        // actualiza existencia plantas
        public Boolean ActualizarExistenciaPlantas()
        {
            try
            {
                
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins_plantas = "INSERT INTO existenciaplanta (id_plantas,id_comun,id_paraje,edad,cantidadini,existenciaplantas,regmaguey) VALUES";
                DataSet NuevasPlantas = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref NuevasPlantas, "SELECT  id_plantas,id_comun,id_paraje,edad,cantidadini,existenciaplantas,regmaguey FROM existenciaplanta where id_plantas>" + id_max_local + "");
                ConexionMysqlRemota2.llenaDataset(ref NuevasPlantas, "SELECT  id_plantas,id_comun,id_paraje,if (edad='' or edad is null,0,edad) as edad,cantidadini,existenciaplantas,regmaguey FROM existenciaplanta");
                if (NuevasPlantas.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in NuevasPlantas.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select id_plantas from existenciaplanta where id_plantas=" + Convert.ToString(row["id_plantas"]));

                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {

                        //MessageBox.Show("UPDATE existenciaplanta SET id_comun=" + Convert.ToString(row["id_comun"]) + ", edad='" + Convert.ToString(row["edad"]) + "', existenciaplantas=" + Convert.ToString(row["existenciaplantas"]) + " WHERE id_plantas=" + Convert.ToString(row["id_plantas"]));
                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta SET id_comun=" + Convert.ToString(row["id_comun"]) + ", edad='" + Convert.ToString(row["edad"]) + "', existenciaplantas=" + Convert.ToString(row["existenciaplantas"]) + " WHERE id_plantas=" + Convert.ToString(row["id_plantas"])) == "Error")
                            return false;


                    }
                    else
                    {

                        bandera_insert = true;
                        string id_plantas = Convert.ToString(row["id_plantas"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_paraje = Convert.ToString(row["id_paraje"]);
                        string edad = Convert.ToString(row["edad"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string regmaguey = Convert.ToString(row["regmaguey"]);

                        values += sep + "(" + id_plantas + "," + id_comun + ",'" + id_paraje + "','" + edad + "'," + cantidadini + "," + existenciaplantas + ",'" + regmaguey + "')";
                        sep = ",";
                    }
                }


                sql_ins_plantas += values + ";";
                /* if (ConexionMysql.insUpd_transaccion(sql_ins_plantas) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/

                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins_plantas) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean ActualizarExistenciaPlantasAntiguas()
        {
            try
            {

                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins_plantas = "INSERT INTO reveca2_existenciaplanta (id_plantas,id_comun,id_paraje,edad,cantidadini,existenciaplantas,regmaguey) VALUES";
                DataSet NuevasPlantas = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref NuevasPlantas, "SELECT  id_plantas,id_comun,id_paraje,edad,cantidadini,existenciaplantas,regmaguey FROM existenciaplanta where id_plantas>" + id_max_local + "");
                ConexionMysqlRemota2.llenaDataset(ref NuevasPlantas, "SELECT  id_plantas,id_comun,id_paraje,if (edad='' or edad is null,0,edad) as edad,cantidadini,existenciaplantas,regmaguey FROM crm_existenciaplanta");
                if (NuevasPlantas.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in NuevasPlantas.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select id_plantas from reveca2_existenciaplanta where id_plantas=" + Convert.ToString(row["id_plantas"]));

                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {

                        //MessageBox.Show("UPDATE existenciaplanta SET id_comun=" + Convert.ToString(row["id_comun"]) + ", edad='" + Convert.ToString(row["edad"]) + "', existenciaplantas=" + Convert.ToString(row["existenciaplantas"]) + " WHERE id_plantas=" + Convert.ToString(row["id_plantas"]));
                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE reveca2_existenciaplanta SET id_comun=" + Convert.ToString(row["id_comun"]) + ", edad='" + Convert.ToString(row["edad"]) + "', existenciaplantas=" + Convert.ToString(row["existenciaplantas"]) + " WHERE id_plantas=" + Convert.ToString(row["id_plantas"])) == "Error")
                            return false;


                    }
                    else
                    {

                        bandera_insert = true;
                        string id_plantas = Convert.ToString(row["id_plantas"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_paraje = Convert.ToString(row["id_paraje"]);
                        string edad = Convert.ToString(row["edad"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string regmaguey = Convert.ToString(row["regmaguey"]);

                        values += sep + "(" + id_plantas + "," + id_comun + ",'" + id_paraje + "','" + edad + "'," + cantidadini + "," + existenciaplantas + ",'" + regmaguey + "')";
                        sep = ",";
                    }
                }


                sql_ins_plantas += values + ";";
                /* if (ConexionMysql.insUpd_transaccion(sql_ins_plantas) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/

                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins_plantas) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        // actualiza especie d emaguey comun
        public Boolean ActualizarEspecieDeMaguey()
        {
            try
            {
                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_comun) AS id_max FROM comun");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins_comun = "INSERT INTO comun (id_comun,id_especie,nombre,status) VALUES";
                DataSet Datos = new DataSet();
                // ConexionMysqlRemota.llenaDataset(ref Datos, "SELECT  id_comun,id_especie,nombre,status FROM comun where id_comun>" + id_max_local + "");
                ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT  id_comun,id_especie,nombre,estatus FROM comun");
                if (Datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in Datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_comun FROM comun where id_comun=" + Convert.ToString(row["id_comun"]));

                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {

                        //MessageBox.Show("UPDATE existenciaplanta SET id_comun=" + Convert.ToString(row["id_comun"]) + ", edad='" + Convert.ToString(row["edad"]) + "', existenciaplantas=" + Convert.ToString(row["existenciaplantas"]) + " WHERE id_plantas=" + Convert.ToString(row["id_plantas"]));
                        bandera_update = true;

                        if (ConexionMysql.insUpd_transaccion("UPDATE comun SET id_comun=" + Convert.ToString(row["id_comun"]) + ", id_especie='" + Convert.ToString(row["id_especie"]) + "', nombre='" + Convert.ToString(row["nombre"]) + "', status='" + Convert.ToString(row["estatus"]) + "' WHERE id_comun=" + Convert.ToString(row["id_comun"])) == "Error")
                            return false;


                    }
                    else
                    {

                        bandera_insert = true;



                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_especie = Convert.ToString(row["id_especie"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string status = Convert.ToString(row["estatus"]);

                        values += sep + "(" + id_comun + "," + id_especie + ",'" + nombre + "','" + status + "')";
                        sep = ",";

                    }

                }
                sql_ins_comun += values + ";";
                /*if (ConexionMysql.insUpd_transaccion(sql_ins_comun) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }*/
                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql_ins_comun) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        public Boolean ActualizarEspecieTabla()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_especie) AS id_max FROM especie");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins_comun = "INSERT INTO especie (id_especie, genespecie, variante) VALUES";
                DataSet Datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref Datos, "SELECT  id_especie, genespecie, variante FROM especie where id_especie>" + id_max_local + "");
                if (Datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in Datos.Tables[0].Rows)
                {

                    string id_especie = Convert.ToString(row["id_especie"]);
                    string id_genespecie = Convert.ToString(row["genespecie"]);
                    string variante = Convert.ToString(row["variante"]);
                    //faltan las comillas en id_genespecie según
                    values += sep + "(" + id_especie + ",'" + id_genespecie + "','" + variante + "')";
                    sep = ",";
                }
                sql_ins_comun += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins_comun) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// actualiza los parajes
        public Boolean ActualizarParajes()
        {
            try
            {
                /*string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM paraje");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }*/
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO paraje (id_paraje,id_cliente,paraje,nombrep) VALUES";
                DataSet NuevosParajes = new DataSet();
                //ConexionMysqlRemota2.llenaDataset(ref NuevosParajes, "SELECT  id_paraje,id_cliente,paraje,nombrep,actualizado FROM paraje where id > " + id_max_local + " ");
                ConexionMysqlRemota2.llenaDataset(ref NuevosParajes, "SELECT  id_paraje,id_cliente,paraje,nombrep,actualizado FROM paraje");
                if (NuevosParajes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                //New metod to do it updates or insertes with actualizado 0
                foreach (DataRow row in NuevosParajes.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("SELECT id_paraje from paraje where id_paraje='" + Convert.ToString(row["id_paraje"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE paraje SET  id_cliente= '" + Convert.ToString(row["id_cliente"]) + "'," +
                                "paraje='" + Convert.ToString(row["paraje"]) + "',nombrep='" + Convert.ToString(row["nombrep"]) + "'" +
                                " WHERE id_paraje='" + Convert.ToString(row["id_paraje"]) + "' ") == "Error")
                                return false;
                        }
                    }

                    else
                    {
                        bandera_insert = true;
                        string id_paraje = Convert.ToString(row["id_paraje"]);
                        string id_cliente = Convert.ToString(row["id_cliente"]);
                        string paraje = Convert.ToString(row["paraje"]);
                        string nombre = Convert.ToString(row["nombrep"]);
                        values += sep + "('" + id_paraje + "','" + id_cliente + "','" + paraje + "','" + nombre + "')";
                        sep = ",";
                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql_ins += values + ";";

                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
                #region SIN HACER UPDATE

                /*foreach (DataRow row in NuevosParajes.Tables[0].Rows)
                {

                    string id_paraje = Convert.ToString(row["id_paraje"]);
                    string id_cliente = Convert.ToString(row["id_cliente"]);
                    string paraje = Convert.ToString(row["paraje"]);
                    string nombre = Convert.ToString(row["nombrep"]);
                    values += sep + "('" + id_paraje + "','" + id_cliente + "','" + paraje + "','" + nombre + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/
                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        public Boolean ActualizarParajesAntiguos()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_paraje) AS id_max FROM reveca2_paraje");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO reveca2_paraje (id_paraje,id_cliente,paraje,nombrep) VALUES";
                DataSet NuevosParajes = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosParajes, "SELECT  id_paraje,id_cliente,paraje,nombrep FROM crm_paraje where id_paraje > " + id_max_local + " ");
                if (NuevosParajes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosParajes.Tables[0].Rows)
                {

                    string id_paraje = Convert.ToString(row["id_paraje"]);
                    string id_cliente = Convert.ToString(row["id_cliente"]);
                    string paraje = Convert.ToString(row["paraje"]);
                    string nombre = Convert.ToString(row["nombrep"]);
                    values += sep + "('" + id_paraje + "','" + id_cliente + "','" + paraje + "','" + nombre + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// actualiza los clientes viejo
        public Boolean ActualizaClientesViejo()
        {
            try
            {
                /*@adnto aquí considero que el máximo sea diferente al cliente 9999*/

                /* string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(no_cliente) AS id_max FROM clientes where no_cliente!=9999");
                 if (id_max_local == "")
                 {
                     id_max_local = "0";
                 }*/
                //string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT no_cliente FROM clientes where no_cliente!=9999");



                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO clientes (no_cliente,asociado,nombre,cp,cliente_antiguo) VALUES";
                Boolean bandera_insert = false;//Se agrega
                Boolean bandera_update = false;//Se agrega
                DataSet NuevosClientes = new DataSet();
                /*@adnto aquí considero que actualice los clientes mayores al máximo (de la consulta de arriba) y excluyendo al 9999*/
                /*r@lew sea modifico para que agrege el codigo postal del cliente desde la tabla domicilio*/
                //ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT clientes.no_cliente as no_cliente,clientes.nombre as nombre, domicilio.cp as cp FROM clientes inner join domicilio on clientes.no_cliente=domicilio.no_cliente where clientes.no_cliente>" + id_max_local + " and domicilio.estatus=1 and clientes.no_cliente != 9999 order by clientes.no_cliente asc;");

                //-- esta valida por el ide del consulta de id maximo---ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT no_cliente,nombre,cp FROM clientes where no_cliente>" + id_max_local + " and no_cliente != 9999");
                ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT no_cliente,asociado,nombre,cp,registro_crm FROM clientes where no_cliente != 'C9999'");
                //LINEA ORIGINAL ANTES DE QUE ACTUALICE CAMBIOS DE FORMA AUTOMÁTICA
                //ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT no_cliente,asociado,nombre,cp,registro_crm FROM clientes where no_cliente != 'C9999'");

                /*-----/ r@le----- la consulta de abajo se puede descomentar y la de arriba comentar para poder traer desde la base de datos el codigo postal de todos los cleintes */
                /*SELECT clientes.no_cliente,clientes.nombre,domicilio.cp FROM clientes inner join domicilio on clientes.no_cliente=domicilio.no_cliente where clientes.no_cliente>" + id_max_local + " and domicilio.estatus=1 and clientes.no_cliente != 9999*/
                if (NuevosClientes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosClientes.Tables[0].Rows)
                {

                    string id_cliente = ConexionMysql.regresaCampoConsulta("SELECT no_cliente FROM clientes where no_cliente ='" + Convert.ToString(row["no_cliente"]) + "' and no_cliente!= 'C9999'");

                    if (id_cliente == "") //-- si no encuientra coincidencia entra e incerta los datos
                    {
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string asociado = Convert.ToString(row["asociado"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string cp = Convert.ToString(row["cp"]);
                        string cliente_antiguo = Convert.ToString(row["registro_crm"]);

                        values += sep + "('" + no_cliente + "','" + asociado + "','" + nombre + "','" + cp + "','" + cliente_antiguo + "')";
                        sep = ",";



                    }
                    /* else{
                         values = "0";
                     }*/
                    // else { return true; }


                }


                if (values != "")// ---  Si encuentra el valorque no es vacio entra e inserta los nuevos valores...
                {
                    sql_ins += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//---- fin de actualiza clientes viejo

        //actualiza clientes nuevo 2022 para que pueda hacer updates
        public Boolean ActualizaClientes()
        {
            try
            {
                
                string sep = "";
                string values = "";//moises
                string sql_ins = "INSERT INTO clientes (no_cliente,asociado,nombre,cp,cliente_antiguo,rfc,tipo_persona,magueyero,mezcalero,envasador,comercializador,comercializador_bc) VALUES";
                Boolean bandera_insert = false;//Se agrega
                Boolean bandera_update = false;//Se agrega
                DataSet NuevosClientes = new DataSet();
                
                //-- esta valida por el ide del consulta de id maximo---ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT no_cliente,nombre,cp FROM clientes where no_cliente>" + id_max_local + " and no_cliente != 9999");
                ConexionMysqlRemota2.llenaDataset(ref NuevosClientes, "SELECT no_cliente,asociado,nombre,cp,actualizado,registro_crm,rfc,tipo_persona,magueyero,mezcalero,envasador,comercializador,comercializador_bc FROM clientes where no_cliente != 'C9999'");

                /*-----/ r@le----- la consulta de abajo se puede descomentar y la de arriba comentar para poder traer desde la base de datos el codigo postal de todos los cleintes */
                /*SELECT clientes.no_cliente,clientes.nombre,domicilio.cp FROM clientes inner join domicilio on clientes.no_cliente=domicilio.no_cliente where clientes.no_cliente>" + id_max_local + " and domicilio.estatus=1 and clientes.no_cliente != 9999*/
                if (NuevosClientes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosClientes.Tables[0].Rows)
                {

                    string id_cliente = ConexionMysql.regresaCampoConsulta("SELECT no_cliente FROM clientes where no_cliente ='" + Convert.ToString(row["no_cliente"]) + "' and no_cliente!= 'C9999'");
                    if (id_cliente != "")
                    {

                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE clientes SET asociado='" + Convert.ToString(row["asociado"]) + "',nombre='" + Convert.ToString(row["nombre"]) + "'," +
                                "cp='" + Convert.ToString(row["cp"]) + "',cliente_antiguo='" + Convert.ToString(row["registro_crm"]) + "' WHERE no_cliente='" + Convert.ToString(row["no_cliente"]) + "' ") == "Error")
                                return false;
                        }
                        
                    }
                    else
                    {
                        bandera_insert = true;
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string asociado = Convert.ToString(row["asociado"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string cp = Convert.ToString(row["cp"]);
                        string cliente_antiguo = Convert.ToString(row["registro_crm"]);
                        string rfc = Convert.ToString(row["rfc"]);
                        string tipo_persona = Convert.ToString(row["tipo_persona"]);
                        string magueyero = Convert.ToString(row["magueyero"]); 
                        string mezcalero = Convert.ToString(row["mezcalero"]); 
                        string envasador = Convert.ToString(row["envasador"]);
                        string comercializador = Convert.ToString(row["comercializador"]);
                        string comercializador_bc = Convert.ToString(row["comercializador_bc"]);

                        values += sep + "('" + no_cliente + "','" + asociado + "','" + nombre + "','" + cp + "','" + cliente_antiguo + "','" + rfc + "','" + tipo_persona + "','" + magueyero + "','" + mezcalero + "','" + envasador + "','" + comercializador + "','" + comercializador_bc + "')";
                        sep = ",";
                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql_ins += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }// fin actualiza cliente nuevo

        public Boolean ActualizaVerificadores()
        {
            try
            {
                Console.WriteLine("actualiza verificadores si no esta correcto el password");
                string sep = "";
                string values = "";
                string sql = "INSERT INTO verificadores (id_us, nombre, dpto, login, password, cve_us, status,actualizado,credencial,titulo) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                
                //cve_cred_2025
                int anioActual = DateTime.Now.Year;
                string creda="cve_cred_"+Convert.ToString(anioActual);

                //ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_entrada, no_cliente, id_fabrica, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha , id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado from rv_granel_entrada ");

                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT v.id_us, v.nombre, v.dpto, v.login, v.password, v.cve_us, v.status,v.actualizado,p." + creda + " as credencial, p.titulo from verificadores v LEFT JOIN crm_personal p ON p.id_inspector=v.id_us");

                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows) // itera los registros de la consulta remota de verificadores
                {
                    
                    string id = ConexionMysql.regresaCampoConsulta("select id_us from verificadores where id_us='" + Convert.ToString(row["id_us"]) + "'");
                    //string id = ConexionMysql.regresaCampoConsulta("select  id_granel_entrada from  granel_entrada where id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'");
                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {
                        if (Convert.ToString(row["actualizado"]) == "0") // if campo actualizado en bd remota es actualizado=0
                        {
                            bandera_update = true;
                            Console.WriteLine("UPDATE verificadores SET nombre='" + Convert.ToString(row["nombre"]) + "', dpto='" + Convert.ToString(row["dpto"]) + "', login='" + Convert.ToString(row["login"]) + "', password='" + Convert.ToString(row["password"]) + "', cve_us='" + Convert.ToString(row["cve_us"]) + "', status='" + Convert.ToString(row["status"]) + "', credencial='" + Convert.ToString(row["credencial"]) + "' WHERE id_us='" + Convert.ToString(row["id_us"]) + "' ");

                            //id_us, nombre, dpto, login, password, cve_us, status
                            if (ConexionMysql.insUpd_transaccion("UPDATE verificadores SET nombre='" + Convert.ToString(row["nombre"]) + "', dpto='" + Convert.ToString(row["dpto"]) + "', login='" + Convert.ToString(row["login"]) + "', password='" + Convert.ToString(row["password"]) + "', cve_us='" + Convert.ToString(row["cve_us"]) + "', status='" + Convert.ToString(row["status"]) + "', credencial='" + Convert.ToString(row["credencial"]) + "', titulo='" + Convert.ToString(row["titulo"]) + "' WHERE id_us='" + Convert.ToString(row["id_us"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else // si fuera "", o sea q no encontro id q coincidiera tendrá q insertar el registro nuevo. 
                    {
                        //id_us, nombre, dpto, login, password, cve_us, status
                        bandera_insert = true;
                        string id_us = Convert.ToString(row["id_us"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string dpto = Convert.ToString(row["dpto"]);
                        string login = Convert.ToString(row["login"]);
                        string password = Convert.ToString(row["password"]);
                        string cve_us = Convert.ToString(row["cve_us"]);
                        string status = Convert.ToString(row["status"]);
                        string credencial = Convert.ToString(row["credencial"]);
                        string titulo = Convert.ToString(row["titulo"]);

                        values += sep + "('" + id_us + "','" + nombre + "','" + dpto + "','" + login + "','" + password + "','" + cve_us + "','" + status + "',1,'" + credencial + "', '" + titulo + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    // para insertar valores
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            /*
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_entrada (id_granel_entrada, no_cliente, id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_entrada, no_cliente, id_fabrica, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha , id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente, id_verificador, actualizado from rv_granel_entrada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_entrada from  granel_entrada where id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada   SET   no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',lts_entrada='" + Convert.ToString(row["lts_entrada"]) + "',grado_alcoholico_entrada='" + Convert.ToString(row["grado_alcoholico_entrada"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "'   WHERE id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_granel_entrada + "','" + no_cliente + "','" + id_fabrica + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
             
             */
        }//--- fin actualiza verificadores


        /// actualiza las marcas viejo
        public Boolean ActualizaMarcasViejo()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM marcas");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO marcas (id,no_cliente,cve_marca,marca,serie,sinc,label) VALUES";
                DataSet NuevasMarcas = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevasMarcas, "SELECT id,no_cliente,cve_marca,marca,serie,sinc,label FROM marcas where id >" + id_max_local + "");
                if (NuevasMarcas.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevasMarcas.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string no_cliente = Convert.ToString(row["no_cliente"]);
                    string cve_marca = Convert.ToString(row["cve_marca"]);
                    string marca = Convert.ToString(row["marca"]);
                    string serie = Convert.ToString(row["serie"]);
                    string sinc = Convert.ToString(row["sinc"]);
                    string label = Convert.ToString(row["label"]);
                    values += sep + "(" + id + ",'" + no_cliente + "','" + cve_marca + "','" + marca + "','" + serie + "','" + sinc + "','" + label + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }// fin actualiza marcas viejo

        // actualiza marcas nuevo
        public Boolean ActualizaMarcas()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM marcas");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                // BUSCAR MARCAS SIN LETRA Y ACTUALIZARLAS
                DataSet MarcasSin = new DataSet();
                ConexionMysql.llenaDataset(ref MarcasSin, "SELECT id,no_cliente,cve_marca,marca,serie FROM marcas WHERE cve_marca = '' ");
                foreach (DataRow row in MarcasSin.Tables[0].Rows)
                {
                    string cve_marca = ConexionMysqlRemota2.regresaCampoConsulta("SELECT cve_marca from marcas where no_cliente='" + Convert.ToString(row["no_cliente"]) + "' AND marca='" + Convert.ToString(row["marca"]) + "' ");
                    if(cve_marca != "")
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE marcas SET cve_marca='" + Convert.ToString(cve_marca) + "' WHERE id='" + Convert.ToString(row["id"]) + "' ") == "Error")
                            return false;
                        ConexionMysql.transCompleta();

                    }
                }
                // */
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO marcas (id,no_cliente,cve_marca,marca,serie,sinc,label) VALUES";
                DataSet NuevasMarcas = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevasMarcas, "SELECT id,no_cliente,cve_marca,marca,serie,sinc,label,actualizado FROM marcas ");
                if (NuevasMarcas.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevasMarcas.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("SELECT id from marcas where id='" + Convert.ToString(row["id"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE marcas SET  no_cliente= '" + Convert.ToString(row["no_cliente"]) + "'," +
                                "cve_marca='" + Convert.ToString(row["cve_marca"]) + "',marca='" + Convert.ToString(row["marca"]).Replace("'", " ") + "'," +
                                "serie='" + Convert.ToString(row["serie"]) + "',sinc='" + Convert.ToString(row["sinc"]) + "'," +
                                "label='" + Convert.ToString(row["label"]) + "' WHERE id='" + Convert.ToString(row["id"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        bandera_insert = true;
                        string idm = Convert.ToString(row["id"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cve_marca = Convert.ToString(row["cve_marca"]);
                        string marca = Convert.ToString(row["marca"]);
                        string serie = Convert.ToString(row["serie"]);
                        string sinc = Convert.ToString(row["sinc"]);
                        string label = Convert.ToString(row["label"]);
                        values += sep + "(" + idm + ",'" + no_cliente + "','" + cve_marca + "','" + marca + "','" + serie + "','" + sinc + "','" + label + "')";
                        sep = ",";

                    }

                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql_ins += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }// fin actualiza marcas nuevo

        //actualizacion de estatus guias y existencias de plantas
        public Boolean ActualizaEstatusGuiasYExistenciaPlantas()
        {
            try
            {
                DataSet HistorialExtracciones = new DataSet();
                ///--- seleciona las extracciones que estan en crmreg --
                ConexionMysqlRemota2.llenaDataset(ref HistorialExtracciones, "SELECT no_guia,id_plantas,extraccion, DATE_FORMAT(fecha_realizo, '%Y-%m-%d %H:%i:%s') as fecha  FROM historial_extraccion_verificadores");
                if (HistorialExtracciones.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in HistorialExtracciones.Tables[0].Rows)
                {
                    string no_guia = Convert.ToString(row["no_guia"]);
                    string id_planta = Convert.ToString(row["id_plantas"]);
                    string extraccion = Convert.ToString(row["extraccion"]);
                    string fecha = Convert.ToString(row["fecha"]);

                    /// --- selecciona las extracciones del la base de datos local reveca2 -- 
                    string res = ConexionMysql.regresaCampoConsulta("SELECT * FROM actualizacion_extracciones where no_guia like '" + no_guia + "' and id_plantas=" + id_planta + " and fecha='" + fecha + "' ");
                    //// si no encientra el regiatro de la esxtraccion entra aqui e ingresa los valores nuevos
                    if (res == "")
                    {
                        //--- actualiza la tabla de actualizacion_extracciones 
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( '" + no_guia + "'," + id_planta + "," + extraccion + ",'" + fecha + "')") == "Error")
                            return false;
                        ///-- En el casso de que la extraccion sea con guia entra ene el if <if (no_guia != 0)> y actualiza el estatus de la guia
                        if (no_guia != "0")
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE  cextracciones SET status=0  WHERE id_extraccion = '" + no_guia + "'") == "Error")
                                return false;
                        }
                        /// --- actualiza la cantidad de piñas en la existencia de la planta
                        if (ConexionMysql.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + extraccion + "  WHERE id_plantas =" + id_planta + "") == "Error")
                            return false;

                        ConexionMysql.transCompleta();
                    } // -- fin de if(res=="")              
                }// -- fin del for      
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean ActualizaEstatusGuiasYExistenciaPlantasAntiguas()
        {
            try
            {
                DataSet HistorialExtracciones = new DataSet();
                ///--- seleciona las extracciones que estan en crmreg --
                ConexionMysqlRemota2.llenaDataset(ref HistorialExtracciones, "SELECT no_guia,id_plantas,extraccion, DATE_FORMAT(fecha_realizo, '%Y-%m-%d %H:%i:%s') as fecha  FROM crm_historial_extraccion_verificadores");
                if (HistorialExtracciones.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in HistorialExtracciones.Tables[0].Rows)
                {
                    string no_guia = Convert.ToString(row["no_guia"]);
                    string id_planta = Convert.ToString(row["id_plantas"]);
                    string extraccion = Convert.ToString(row["extraccion"]);
                    string fecha = Convert.ToString(row["fecha"]);

                    /// --- selecciona las extracciones del la base de datos local reveca2 -- 
                    string res = ConexionMysql.regresaCampoConsulta("SELECT * FROM reveca2_actualizacion_extracciones where no_guia like '" + no_guia + "' and id_plantas=" + id_planta + " and fecha='" + fecha + "' ");
                    //// si no encientra el regiatro de la esxtraccion entra aqui e ingresa los valores nuevos
                    if (res == "")
                    {
                        //--- actualiza la tabla de actualizacion_extracciones 
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO  reveca2_actualizacion_extracciones (no_guia,id_plantas,extraccion,fecha) VALUES( '" + no_guia + "'," + id_planta + "," + extraccion + ",'" + fecha + "')") == "Error")
                            return false;
                        ///-- En el casso de que la extraccion sea con guia entra ene el if <if (no_guia != 0)> y actualiza el estatus de la guia
                        if (no_guia != "0")
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_cextracciones SET status=0  WHERE id_extraccion = '" + no_guia + "'") == "Error")
                                return false;
                        }
                        /// --- actualiza la cantidad de piñas en la existencia de la planta
                        if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_existenciaplanta SET existenciaplantas=existenciaplantas-" + extraccion + "  WHERE id_plantas =" + id_planta + "") == "Error")
                            return false;

                        ConexionMysql.transCompleta();
                    } // -- fin de if(res=="")              
                }// -- fin del for      
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        /// actualiza los años sumados
        public Boolean ActualizaAnios()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM anios_sumados");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO anios_sumados (id,id_plantas,anios) VALUES";
                DataSet NuevosAnios = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosAnios, "SELECT id,id_plantas,anios FROM anios_sumados where id>" + id_max_local + "");
                if (NuevosAnios.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosAnios.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string id_plantas = Convert.ToString(row["id_plantas"]);
                    string anios = Convert.ToString(row["anios"]);

                    values += sep + "(" + id + "," + id_plantas + "," + anios + ")";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean ActualizaAniosAntiguos()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM reveca2_anios_sumados");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO reveca2_anios_sumados (id,id_plantas,anios) VALUES";
                DataSet NuevosAnios = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosAnios, "SELECT id,id_plantas,anios FROM crm_anios_sumados where id>" + id_max_local + "");
                if (NuevosAnios.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosAnios.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string id_plantas = Convert.ToString(row["id_plantas"]);
                    string anios = Convert.ToString(row["anios"]);

                    values += sep + "(" + id + "," + id_plantas + "," + anios + ")";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //actualiza edades del de maguey
        public Boolean ActualizaEdadesPlantas()
        {
            try
            {
                DataSet AniosSumados = new DataSet();
                ConexionMysql.llenaDataset(ref AniosSumados, "SELECT * FROM  anios_sumados where estatus=0");
                if (AniosSumados.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in AniosSumados.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta SET edad=edad+" + row["anios"] + " where id_plantas=" + row["id_plantas"] + "") == "Error")
                            return false;

                        if (ConexionMysql.insUpd_transaccion("UPDATE anios_sumados SET estatus=1 where id=" + row["id"] + "") == "Error")
                            return false;

                        ConexionMysql.transCompleta();
                    }

                }

                DataSet AniosSumadosRemotos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref AniosSumadosRemotos, "SELECT * FROM  anios_sumados");
                if (AniosSumadosRemotos.Tables[0].Rows.Count != 0)
                {
                    //int f = AniosSumadosRemotos.Tables[0].Rows.Count;

                    // MessageBox.Show("" + f);
                    foreach (DataRow row1 in AniosSumadosRemotos.Tables[0].Rows)
                    {

                        DataSet AniosSumados2 = new DataSet();
                        ConexionMysql.llenaDataset(ref AniosSumados2, "SELECT * FROM  anios_sumados where id=" + row1["id"] + "  and estatus=1 and anios!=" + row1["anios"] + " ");


                        if (AniosSumados2.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow row2 in AniosSumados2.Tables[0].Rows)
                            {
                                if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta SET edad=edad+1 where id_plantas=" + row2["id_plantas"] + "") == "Error")
                                    return false;

                                if (ConexionMysql.insUpd_transaccion("UPDATE anios_sumados SET anios=" + row1["anios"] + " where id=" + row2["id"] + "") == "Error")
                                    return false;

                                ConexionMysql.transCompleta();

                            }

                        }


                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean ActualizaEdadesPlantasAntiguos()
        {
            try
            {
                DataSet AniosSumados = new DataSet();
                ConexionMysql.llenaDataset(ref AniosSumados, "SELECT * FROM  reveca2_anios_sumados where estatus=0");
                if (AniosSumados.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in AniosSumados.Tables[0].Rows)
                    {
                        if (ConexionMysql.insUpd_transaccion("UPDATE reveca2_existenciaplanta SET edad=edad+" + row["anios"] + " where id_plantas=" + row["id_plantas"] + "") == "Error")
                            return false;

                        if (ConexionMysql.insUpd_transaccion("UPDATE reveca2_anios_sumados SET estatus=1 where id=" + row["id"] + "") == "Error")
                            return false;

                        ConexionMysql.transCompleta();
                    }

                }

                DataSet AniosSumadosRemotos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref AniosSumadosRemotos, "SELECT * FROM  crm_anios_sumados");
                if (AniosSumadosRemotos.Tables[0].Rows.Count != 0)
                {
                    //int f = AniosSumadosRemotos.Tables[0].Rows.Count;

                    // MessageBox.Show("" + f);
                    foreach (DataRow row1 in AniosSumadosRemotos.Tables[0].Rows)
                    {

                        DataSet AniosSumados2 = new DataSet();
                        ConexionMysql.llenaDataset(ref AniosSumados2, "SELECT * FROM  reveca2_anios_sumados where id=" + row1["id"] + "  and estatus=1 and anios!=" + row1["anios"] + " ");


                        if (AniosSumados2.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow row2 in AniosSumados2.Tables[0].Rows)
                            {
                                if (ConexionMysql.insUpd_transaccion("UPDATE reveca2_existenciaplanta SET edad=edad+1 where id_plantas=" + row2["id_plantas"] + "") == "Error")
                                    return false;

                                if (ConexionMysql.insUpd_transaccion("UPDATE reveca2_anios_sumados SET anios=" + row1["anios"] + " where id=" + row2["id"] + "") == "Error")
                                    return false;

                                ConexionMysql.transCompleta();

                            }

                        }


                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// actualiza Tipos de instalaciones
        public Boolean ActualizaTiposInstalacion()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM tipos_instalaciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO tipos_instalaciones (id,descripcion) VALUES";
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,descripcion FROM tipos_instalaciones where id>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string descripcion = Convert.ToString(row["descripcion"]);

                    values += sep + "(" + id + ",'" + descripcion + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// actualiza instalaciones 
        public Boolean ActualizaInstalacion()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM instalaciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO instalaciones (id,tipo,alias,calle,colonia,responsable,municipio,noexterior,nointerior,cp,referencia,telefono,granel,maduracion,producto_terminado,correo,rv_instalaciones) VALUES";
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,tipo,alias,calle,colonia,responsable,municipio,noexterior,nointerior,cp,referencia,telefono,granel,maduracion,producto_terminado,correo,rv_instalaciones FROM instalaciones where id>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string tipo = Convert.ToString(row["tipo"]);
                    string alias = Convert.ToString(row["alias"]);
                    string calle = Convert.ToString(row["calle"]);
                    string colonia = Convert.ToString(row["colonia"]);
                    string responsable = Convert.ToString(row["responsable"]);
                    string municipio = Convert.ToString(row["municipio"]);
                    string noexterior = Convert.ToString(row["noexterior"]);
                    string nointerior = Convert.ToString(row["nointerior"]);
                    string cp = Convert.ToString(row["cp"]);
                    string telefono = Convert.ToString(row["telefono"]);
                    string referencia = Convert.ToString(row["referencia"]);
                    string granel = Convert.ToString(row["granel"]);
                    string maduracion = Convert.ToString(row["maduracion"]);
                    string producto_terminado = Convert.ToString(row["producto_terminado"]);
                    string correo = Convert.ToString(row["correo"]);
                    string rv_instalaciones = Convert.ToString(row["rv_instalaciones"]);
                    values += sep + "(" + id + "," + tipo + ",'" + alias + "','" + calle + "','" + colonia + "','" + responsable + "','" + municipio + "','" + noexterior + "','" + nointerior + "','" + cp + "','" + referencia + "','" + telefono + "','" + granel + "','" + maduracion + "','" + calle+ "','" + correo + "','" + rv_instalaciones + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// actualiza la relacion clientes instalaciones
        public Boolean ActualizaClientesInstalaciones()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta(" select count(*) from clientes_instalaciones");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO clientes_instalaciones (cliente,instalacion) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "CALL INSTALACIONES_CLIENTES('" + id_max_local + "')");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string cliente = Convert.ToString(row["cliente"]);
                    string instalacion = Convert.ToString(row["instalacion"]);

                    values += sep + "('" + cliente + "'," + instalacion + ")";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        public Boolean ActualizaEstados()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(clave) AS id_max FROM estados");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql_ins = "INSERT INTO estados (clave,nombre,codigo,dom,ubica,actualizado) VALUES";
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT clave, nombre, codigo, dom, ubica, actualizado FROM estados ");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("SELECT clave from estados where clave='" + Convert.ToString(row["clave"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {

                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE estados SET " +
                                "clave='" + Convert.ToString(row["clave"]) + "', nombre='" + Convert.ToString(row["nombre"]) +
                                "',codigo='" + Convert.ToString(row["codigo"]) + "'," + "dom='" + Convert.ToString(row["dom"]) + 
                                "',ubica='" + Convert.ToString(row["ubica"]) + "'," + "actualizado='" + Convert.ToString(row["actualizado"]) + 
                                "' WHERE clave='" + Convert.ToString(row["clave"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        // nombre,codigo,dom,ubica,actualizado
                        bandera_insert = true;
                        string clave = Convert.ToString(row["clave"]);
                        string nombre = Convert.ToString(row["nombre"]);
                        string codigo = Convert.ToString(row["codigo"]);
                        string dom = Convert.ToString(row["dom"]);
                        string ubica = Convert.ToString(row["ubica"]);
                        string actualizado = Convert.ToString(row["actualizado"]);
                        values += sep + "(" + clave + ",'" + nombre + "','" + codigo + "','" + dom + "','" + ubica + "','" + actualizado + "')";
                        sep = ",";

                    }

                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql_ins += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }// fin actualiza estados

        /// actualiza los municipio
        public Boolean ActualizaMunicipios()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM municipios");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO municipios (id,clave,estado,nombre) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,clave,estado,nombre FROM municipios where id>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string clave = Convert.ToString(row["clave"]);
                    string estado = Convert.ToString(row["estado"]);
                    string nombre = Convert.ToString(row["nombre"]);

                    values += sep + "(" + id + "," + clave + "," + estado + ",'" + nombre + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// actualiza localidades
        public Boolean ActualizaLocalidades()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM localidades");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO localidades (id,MunicipioID,localidad) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,MunicipioID,localidad FROM localidades where id>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string MunicipioID = Convert.ToString(row["MunicipioID"]);
                    string localidad = Convert.ToString(row["localidad"]);


                    values += sep + "(" + id + "," + MunicipioID + ",'" + localidad + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        /// actualiza ruta_verificador
        public Boolean ActualizaRutaVerificador()
        {
            try
            {
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_ruta_verificador,id_ruta,id_personal,fecha_inicio,fecha_fin FROM r_rutas_verificadores where id_personal=" + Usuario.IdUsuario + " and estado=1");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {

                    string id = Convert.ToString(row["id_ruta_verificador"]);
                    string id_ruta = Convert.ToString(row["id_ruta"]);
                    string id_personal = Convert.ToString(row["id_personal"]);
                    DateTime fecha_inicio = Convert.ToDateTime(Convert.ToString(row["fecha_inicio"]));
                    DateTime fecha_fin = Convert.ToDateTime(Convert.ToString(row["fecha_fin"]));


                    DataSet NuevosDatos2 = new DataSet();
                    ConexionMysql.llenaDataset(ref NuevosDatos2, "SELECT id_ruta_verificador,id_ruta,id_personal,fecha_inicio,fecha_fin FROM rutas_verificadores");
                    if (NuevosDatos2.Tables[0].Rows.Count == 0)
                    {
                        if (ConexionMysql.insUpd_transaccion("INSERT INTO rutas_verificadores(id_ruta_verificador,id_ruta,id_personal,fecha_inicio,fecha_fin) VALUES (" + id + "," + id_ruta + "," + id_personal + ",'" + fecha_inicio.ToString("yyyy-MM-dd") + "','" + fecha_fin.ToString("yyyy-MM-dd") + "')") == "Error")
                            return false;
                        ConexionMysql.transCompleta();
                    }
                    else
                    {
                        string resultado = ConexionMysql.regresaCampoConsulta("SELECT id_ruta_verificador FROM rutas_verificadores where id_ruta_verificador=" + id + "");
                        if (resultado == "")
                        {
                            if (ConexionMysql.insUpd_transaccion("UPDATE rutas_verificadores SET id_ruta_verificador=" + id + ",id_ruta=" + id_ruta + ",id_personal=" + id_personal + ",fecha_inicio='" + fecha_inicio.ToString("yyyy-MM-dd") + "',fecha_fin='" + fecha_fin.ToString("yyyy-MM-dd") + "'") == "Error")
                                return false;
                            ConexionMysql.transCompleta();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// actualiza ruta_clientes que clientes tiene la ruta
        public Boolean ActualizaRutaClientes()
        {
            try
            {
                string id_ruta_valor = ConexionMysql.regresaCampoConsulta("SELECT id_ruta FROM rutas_verificadores");
                if (id_ruta_valor == "")
                {
                    id_ruta_valor = "0";
                }

                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO rutas_clientes(id_ruta_cliente,id_ruta,no_cliente,dia,id_instalacion) VALUES ";

                ConexionMysql.insUpd("DELETE FROM rutas_clientes");

                //datos remotos
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT * FROM r_rutas_clientes where id_ruta=" + id_ruta_valor + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_ruta_cliente"]);
                    string id_ruta = Convert.ToString(row["id_ruta"]);
                    string no_cliente = Convert.ToString(row["no_cliente"]);
                    string dia = Convert.ToString(row["dia"]);
                    string id_instalacion = Convert.ToString(row["id_instalacion"]);

                    values += sep + "(" + id + "," + id_ruta + ",'" + no_cliente + "','" + dia + "','" + id_instalacion + "')";
                    sep = ",";
                }

                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// actualiza ruta_zonas actualiza las zonas que tiene la ruta
        public Boolean ActualizaRutaZona()
        {
            try
            {
                string id_ruta_valor = ConexionMysql.regresaCampoConsulta("SELECT id_ruta FROM rutas_clientes");
                if (id_ruta_valor == "")
                {
                    id_ruta_valor = "0";
                }

                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO rutas_zonas(id_ruta_zona,id_ruta,id_localidad) VALUES ";

                ConexionMysql.insUpd("DELETE FROM rutas_zonas");

                //datos remotos
                DataSet NuevosDatos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT * FROM r_rutas_zonas where id_ruta=" + id_ruta_valor + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_ruta_zona"]);
                    string id_ruta = Convert.ToString(row["id_ruta"]);
                    string id_localidad = Convert.ToString(row["id_localidad"]);


                    values += sep + "(" + id + "," + id_ruta + "," + id_localidad + ")";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// agrega nuevos datos al catalogo de coccion
        public Boolean ActualizaCatCoccion()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_coccion) AS id_max FROM cat_coccion");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO cat_coccion (id_coccion,coccion) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_coccion,coccion FROM cat_coccion where id_coccion>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_coccion"]);
                    string coccion = Convert.ToString(row["coccion"]);

                    values += sep + "(" + id + ",'" + coccion + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// agrega nuevos datos al catalogo de molienda
        public Boolean ActualizaCatMolienda()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_molienda) AS id_max FROM cat_molienda");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO cat_molienda (id_molienda,molienda) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_molienda,molienda FROM cat_molienda where id_molienda>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_molienda"]);
                    string molienda = Convert.ToString(row["molienda"]);

                    values += sep + "(" + id + ",'" + molienda + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        /// agrega nuevos datos al catalogo de fermentacion
        public Boolean ActualizaCatFermentacion()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_fermentacion) AS id_max FROM cat_fermentacion");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO cat_fermentacion (id_fermentacion,fermentacion) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_fermentacion,fermentacion FROM cat_fermentacion where id_fermentacion>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_fermentacion"]);
                    string fermentacion = Convert.ToString(row["fermentacion"]);

                    values += sep + "(" + id + ",'" + fermentacion + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// agrega nuevos datos al catalogo de destilacion
        public Boolean ActualizaCatDestilacion()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_destilacion) AS id_max FROM cat_destilacion");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO cat_destilacion (id_destilacion,destilacion) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_destilacion,destilacion FROM cat_destilacion where id_destilacion>" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_destilacion"]);
                    string destilacion = Convert.ToString(row["destilacion"]);

                    values += sep + "(" + id + ",'" + destilacion + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        /// actuliza relacion cp estado
        public Boolean ActualizaRelacionCpEstado()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id) AS id_max FROM relacion_cp_estado");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO relacion_cp_estado (id,clave_estado,cp) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id,estado,cp FROM asentamientos where id >" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id"]);
                    string clave_estado = Convert.ToString(row["estado"]);
                    string cp = Convert.ToString(row["cp"]);

                    values += sep + "(" + id + "," + clave_estado + ",'" + cp + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// actuliza relacion cp estado
        public Boolean ActualizaCatPresentacion()
        {
            try
            {
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_presentacion) AS id_max FROM cat_presentacion");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO cat_presentacion (id_presentacion,cantidad, medida) VALUES";
                DataSet NuevosDatos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref NuevosDatos, "SELECT id_presentacion,cantidad, medida FROM cat_presentacion where id_presentacion >" + id_max_local + "");
                if (NuevosDatos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in NuevosDatos.Tables[0].Rows)
                {
                    string id = Convert.ToString(row["id_presentacion"]);
                    string cantidad = Convert.ToString(row["cantidad"]);
                    string medida = Convert.ToString(row["medida"]);

                    values += sep + "(" + id + "," + cantidad + ",'" + medida + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion



        //--------------------------------------------------------------->>>>>FIN sube informacion modificada por el admin<<<<--------------------------------------------------------------


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>>>>>>>>>>>Baja informacion<<<<<<<<<<<<~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        #region MetodosParaBajar o Descargar información normal
        //--- baja  los id producciones
        public Boolean BajaIdsProduccion()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO ids_producciones (id_producciones, tipo_instalacion, id_produccion_entrada, id_lote, id_verificador,actualizado) VALUES";

                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_producciones, tipo_instalacion, id_produccion_entrada, id_lote, id_verificador, actualizado from rv_ids_producciones WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_producciones from  ids_producciones where id_producciones='" + Convert.ToString(row["id_producciones"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;


                        values_update += sep_update + "'" + Convert.ToString(row["id_producciones"]) + "'";
                        sep_update = ",";

                        if (ConexionMysql.insUpd_transaccion("UPDATE  ids_producciones SET  id_producciones ='" + Convert.ToString(row["id_producciones"]) + "', tipo_instalacion ='" + Convert.ToString(row["tipo_instalacion"]) + "', id_produccion_entrada ='" + Convert.ToString(row["id_produccion_entrada"]) + "', id_lote ='" + Convert.ToString(row["id_lote"]) + "', id_verificador ='" + Convert.ToString(row["id_verificador"]) + "' WHERE id_producciones='" + Convert.ToString(row["id_producciones"]) + "'") == "Error")
                            return false;

                    }
                    else
                    {

                        bandera_insert = true;

                        string id_producciones = Convert.ToString(row["id_producciones"]);
                        string tipo_instalacion = Convert.ToString(row["tipo_instalacion"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_lote = Convert.ToString(row["id_lote"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_producciones + "','" + tipo_instalacion + "','" + id_produccion_entrada + "','" + id_lote + "','" + id_verificador + "',1)";
                        sep = ",";




                    }

                }

                sql += values + ";";



                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else
                {

                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //Baja la tabla envasado entrada
        public Boolean BajaAlmacenEnvasadoEntrada()
        {
            try
            {
                string sep = "";
                string values = "";


                string sql = "INSERT INTO almacen_envasado_entrada (id_almacen_envasado_entrada,id_almacen_envasado_entrada_salio, id_marca, no_cliente, id_almacen,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso,actualizado) VALUES";

                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_entrada,id_almacen_envasado_entrada_salio,id_marca, no_cliente, id_almacen,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado_ini,'%Y-%m-%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin,'%Y-%m-%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso,actualizado from rv_almacen_envasado_entrada");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_entrada from  almacen_envasado_entrada where id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "'");
                    if (id != "")
                    {///-- Entra si encuentra coinsidencias y actualiza...

                        if (Convert.ToString(row["actualizado"]) == "0")
                        {

                            bandera_update = true;

                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_entrada SET  id_marca='" + Convert.ToString(row["id_marca"]) + "',fq='" + Convert.ToString(row["fq"]) + "', fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',etiquetado_como='" + Convert.ToString(row["etiquetado_como"]) + "', litros='" + Convert.ToString(row["litros"]) + "',botellas_iniciales='" + Convert.ToString(row["botellas_iniciales"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "' WHERE id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        /// -- Si no encuentra coincidencia entra y hace un insert...

                        bandera_insert = true;
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_almacen_envasado_entrada_salio = Convert.ToString(row["id_almacen_envasado_entrada_salio"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_envasado_ini = Convert.ToString(row["fecha_envasado_ini"]);
                        string fecha_envasado_fin = Convert.ToString(row["fecha_envasado_fin"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string etiquetado_como = Convert.ToString(row["etiquetado_como"]);
                        string unidad_medida = Convert.ToString(row["unidad_medida"]);
                        string contenido_por_botella = Convert.ToString(row["contenido_por_botella"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string grado_alcoholico_etiqueta = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        string botellas_iniciales = Convert.ToString(row["botellas_iniciales"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);

                        ///-- genera la cadena de los insert---
                        values += sep + "('" + id_almacen_envasado_entrada + "','" + id_almacen_envasado_entrada_salio + "','" + id_marca + "','" + no_cliente + "','"
                            + id_almacen + "','" + fecha_movimiento + "','" + fecha + "','" + fecha_envasado_ini + "','" + fecha_envasado_fin + "','" + id_comun + "','"
                            + no_lote_granel + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','"
                            + categoria + "','" + abocante + "','" + ingrediente + "','" + etiquetado_como + "','" + unidad_medida + "','" + contenido_por_botella + "','"
                            + litros + "','" + grado_alcoholico + "','" + grado_alcoholico_etiqueta + "','" + botellas_iniciales + "','" + botellas + "','"
                            + botellas_existentes + "','" + holograma_inicio + "','" + holograma_fin + "','" + id_verificador + "','" + tipo_ingreso + "',1)";
                        sep = ",";


                    }
                }

                ///-- establese la cadena de los insert
               // sql += values + ";";
                // MessageBox.Show(values);
                //GENERAR UN TXT CON LA INFORMACION ALAMECENADA EN LA VARIABLE
                //  System.IO.File.WriteAllText("C:\\xd\\ErroresReVeCa2.txt", values);

                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();

                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else 
                {

                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        // MessageBox.Show(sql.ToString());
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//-- fin Suvidaalmacenenvasado
         // TODO: METODOS QUE DESCARGAN LOS LOTES VERIFICADOS POR LA UV EN CAMPO, GRANEL DE FÁBRIC, ENVASADORA Y ENVASADO.
        #region METODOS DE DESCARGAR LOTES VERIFICADOS
        // TODO: METODO PARA QUE SE DESCARGUE LAS INFORMAIÓN DEL SIIG DE VERIFICACION PARTE GRANEL FÁBRICA
        public Boolean BajaVerificacionGF()
        {
            try
            {
                string sep = "";
                string values = "";
                string sqlinsert = "INSERT INTO checked_lotes_gf (id_checked_lotegf, id_pkGF, id_granel_entrada, no_cliente, id_fabrica, no_lote, fecha_ultima_verificacion, checked, verificador_id, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datosiig = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datosiig, "SELECT id_checked_lotegf,id_pkGF,id_granel_entrada,no_cliente,id_fabrica," +
                    "no_lote,date_format(fecha_ultima_verificacion,'%Y-%m-%d'),checked,verificador_id,actualizado FROM rv_checked_lotes_gf");
                
                if (datosiig.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datosiig.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("SELECT id_checked_lotegf from  checked_lotes_gf where id_checked_lotegf='" + Convert.ToString(row["id_checked_lotegf"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                           // MessageBox.Show(Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]));
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE checked_lotes_gf SET  id_checked_lotegf= '" + Convert.ToString(row["id_checked_lotegf"]) + "'," +
                                "id_pkGF='" + Convert.ToString(row["id_pkGF"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'," +
                                "no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "'," +
                                "no_lote='" + Convert.ToString(row["no_lote"]) + "',fecha_ultima_verificacion='" + Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]) + "'," +
                                "checked='" + Convert.ToString(row["checked"]) + "' WHERE id_checked_lotegf='" + Convert.ToString(row["id_checked_lotegf"]) + "' ") == "Error")
                                return false;
                        }
                        
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_checked_lotegf = Convert.ToString(row["id_checked_lotegf"]);
                        string id_pkGF = Convert.ToString(row["id_pkGF"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string fecha_ultima_verificacion = Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]);
                        string checkeado = Convert.ToString(row["checked"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);
                        //actualizado
                       // MessageBox.Show(fecha_ultima_verificacion);

                        values += sep + "('" + id_checked_lotegf + "','" + id_pkGF + "','" + id_granel_entrada + "','" + no_cliente + "','" + id_fabrica + "','" + no_lote + "','" + fecha_ultima_verificacion + "','" + checkeado + "','" + verificador_id + "',1)";
                        sep = ",";

                        }
                    }

                    if (bandera_insert == false && bandera_update == true)
                    {
                        ConexionMysql.transCompleta();
                        return true;
                    }
                    else if (bandera_insert == false && bandera_update == false)
                    {
                        return true;
                    }
                    else
                    {
                        sqlinsert += values + ";";
                        if (ConexionMysql.insUpd_transaccion(sqlinsert) == "Error")
                            return false;

                        ConexionMysql.transCompleta();
                        return true;
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //TODO: METODO DE GRANEL DE ENVASADO DESCARGA DE INFORMACIÓN
        public Boolean BajaVerificacionGE()
        {
            try
            {
                string sep = "";
                string values = "";
                string sqlinsert = "INSERT INTO checked_lotes_ge (id_checked_lotege,id_pkGE,id_granel_entrada_envasado,no_cliente,id_envasadora,no_lote,fecha_ultima_verificacion,checked,verificador_id,actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datosiig = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datosiig, "SELECT id_checked_lotege, id_pkGE, id_granel_entrada_envasado, no_cliente, id_envasadora, no_lote, " +
                    "date_format(fecha_ultima_verificacion,'%Y-%m-%d'), checked, verificador_id, actualizado FROM rv_checked_lotes_ge");

                if (datosiig.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datosiig.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("SELECT id_checked_lotege from checked_lotes_ge where id_checked_lotege='" + Convert.ToString(row["id_checked_lotege"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {

                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE checked_lotes_ge SET id_checked_lotege= '" + Convert.ToString(row["id_checked_lotege"]) + "'," +
                                "id_pkGE='" + Convert.ToString(row["id_pkGE"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "'," +
                                "no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "'," +
                                "no_lote='" + Convert.ToString(row["no_lote"]) + "',fecha_ultima_verificacion='" + Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]) + "'," +
                                "checked='" + Convert.ToString(row["checked"]) + "' WHERE id_checked_lotege='" + Convert.ToString(row["id_checked_lotege"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_checked_lotege = Convert.ToString(row["id_checked_lotege"]);
                        string id_pkGE = Convert.ToString(row["id_pkGE"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string fecha_ultima_verificacion = Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]);
                        string checkeado = Convert.ToString(row["checked"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);

                        values += sep + "('" + id_checked_lotege + "','" + id_pkGE + "','" + id_granel_entrada_envasado + "','" + no_cliente + "','" + id_envasadora + "','" + no_lote + "','" + fecha_ultima_verificacion + "','" + checkeado + "','" + verificador_id + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sqlinsert += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sqlinsert) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //TODO: METODO DE ENVASADO DESCARGA DE INFORMACIÓN
        public Boolean BajaVerificacionEN()
        {
            try
            {
                string sep = "";
                string values = "";
                string sqlinsert = "INSERT INTO checked_lotes_en(id_checked_loteEN, id_pkEN, id_envasado_entrada, no_cliente, marca, id_marca, id_envasadora, no_lote, fecha_ultima_verificacion, checked, verificador_id, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datosiig = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datosiig, "SELECT id_checked_loteEN,id_pkEN,id_envasado_entrada,no_cliente,marca,id_marca,id_envasadora,no_lote," +
                                "date_format(fecha_ultima_verificacion,'%Y-%m-%d'),checked,verificador_id,actualizado FROM rv_checked_lotes_en");

                if (datosiig.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datosiig.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("SELECT id_checked_loteEN from checked_lotes_en where id_checked_loteEN='" + Convert.ToString(row["id_checked_loteEN"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {

                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE checked_lotes_en SET id_checked_loteEN= '" + Convert.ToString(row["id_checked_loteEN"]) + "'," +
                                "id_pkEN='" + Convert.ToString(row["id_pkEN"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "'," +
                                "no_cliente='" + Convert.ToString(row["no_cliente"]) + "',marca='" + Convert.ToString(row["marca"]) + "',id_marca='" + Convert.ToString(row["id_marca"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "'," +
                                "no_lote='" + Convert.ToString(row["no_lote"]) + "',fecha_ultima_verificacion='" + Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]) + "'," +
                                "checked='" + Convert.ToString(row["checked"]) + "' WHERE id_checked_loteEN='" + Convert.ToString(row["id_checked_loteEN"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_checked_loteEN = Convert.ToString(row["id_checked_loteEN"]);
                        string id_pkEN = Convert.ToString(row["id_pkEN"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string marca = Convert.ToString(row["marca"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string fecha_ultima_verificacion = Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]);
                        string checkeado = Convert.ToString(row["checked"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);
                        values += sep + "('" + id_checked_loteEN + "','" + id_pkEN + "','" + id_envasado_entrada + "','" + no_cliente + "','" + marca + "','" + id_marca + "','" + id_envasadora + "','" + no_lote + "','" + fecha_ultima_verificacion + "','" + checkeado + "','" + verificador_id + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sqlinsert += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sqlinsert) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        #endregion

        //TODO: METODO QUE VA A DESCARGAR COMO ANDAN LAS GUIAS EXTERNAS PARA TODOS LOS VERIS
        public Boolean DescargaGuiasExternas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sqlinsert = "INSERT INTO guias_desconocidas (id_guia_desconocida,id_produccion_entrada,no_guia,predio,fecha_ingreso,verificador_id,actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datosamma = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datosamma, "SELECT id_guia_desconocida,id_produccion_entrada,no_guia,predio," +
                    "date_format(fecha_ingreso,'%Y-%m-%d') as fecha_ingreso,verificador_id,actualizado FROM rv_guias_externas");

                if (datosamma.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datosamma.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("SELECT id_guia_desconocida from guias_desconocidas where id_guia_desconocida='" + Convert.ToString(row["id_guia_desconocida"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            // MessageBox.Show(Convert.ToString(row["date_format(fecha_ultima_verificacion,'%Y-%m-%d')"]));
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE guias_desconocidas SET  id_guia_desconocida= '" + Convert.ToString(row["id_guia_desconocida"]) + "'," +
                                "id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "',no_guia='" + Convert.ToString(row["no_guia"]) + "'," +
                                "predio='" + Convert.ToString(row["predio"]) + "',fecha_ingreso='" + Convert.ToString(row["fecha_ingreso"]) + "'," +
                                "verificador_id='" + Convert.ToString(row["verificador_id"]) + "' WHERE id_guia_desconocida='" + Convert.ToString(row["id_guia_desconocida"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_guia_desconocida = Convert.ToString(row["id_guia_desconocida"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string predio = Convert.ToString(row["predio"]);
                        string fecha_ingreso = Convert.ToString(row["fecha_ingreso"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);
                        //actualizado
                        // MessageBox.Show(fecha_ultima_verificacion);

                        values += sep + "('" + id_guia_desconocida + "','" + id_produccion_entrada + "','" + no_guia + "','" + predio + "','" + fecha_ingreso + "','" + verificador_id + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sqlinsert += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sqlinsert) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //sube la tabla almacen envasado ensamble
        public Boolean BajaAlmacenEnvasadoEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql_actua = "";
                string sql = "INSERT INTO almacen_envasado_ensamble (id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador,actualizado) VALUES";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;

                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador,actualizado from rv_almacen_envasado_ensamble");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_ensamble from  almacen_envasado_ensamble where id_almacen_envasado_ensamble='" + Convert.ToString(row["id_almacen_envasado_ensamble"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_ensamble SET  id_almacen_envasado_entrada= '" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',litros='" + Convert.ToString(row["litros"]) + "'   WHERE id_almacen_envasado_ensamble='" + Convert.ToString(row["id_almacen_envasado_ensamble"]) + "' ") == "Error")
                            {
                                sql_actua = "UPDATE almacen_envasado_ensamble SET  id_almacen_envasado_entrada= '" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',litros='" + Convert.ToString(row["litros"]) + "'   WHERE id_almacen_envasado_ensamble='" + Convert.ToString(row["id_almacen_envasado_ensamble"]) + "'; ";
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show(id + " : Entra INSERT.");
                        bandera_insert = true;
                        string id_almacen_envasado_ensamble = Convert.ToString(row["id_almacen_envasado_ensamble"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_envasado_ensamble + "','" + id_almacen_envasado_entrada + "','" + id_comun + "','" + no_lote_granel + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";


                    }

                }



                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();
                    MessageBox.Show(sql_actua);
                    return true;
                }
                else
                {
                    if (bandera_update == false && bandera_insert == true) { 
                        sql += values + ";";

                        if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                            return false;
                        ConexionMysql.transCompleta();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen envasado Movimientos
        public Boolean BajaAlmacenEnvasadoMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";

                string sql = "INSERT INTO almacen_envasado_movimientos (id_almacen_envasado_movimientos, id_almacen_envasado_entrada, id_almacen_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, fecha, id_verificador, actualizado, observaciones) VALUES";

                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_movimientos, id_almacen_envasado_entrada, id_almacen_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, id_verificador, observaciones,actualizado from rv_almacen_envasado_movimientos");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_movimientos from  almacen_envasado_movimientos where id_almacen_envasado_movimientos='" + Convert.ToString(row["id_almacen_envasado_movimientos"]) + "'");
                    if (id != "")
                    {

                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;

                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_movimientos SET  tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',cajas='" + Convert.ToString(row["cajas"]) + "',botellas_por_cajas='" + Convert.ToString(row["botellas_por_cajas"]) + "' WHERE id_almacen_envasado_movimientos='" + Convert.ToString(row["id_almacen_envasado_movimientos"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen_envasado_movimientos = Convert.ToString(row["id_almacen_envasado_movimientos"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_almacen_env_mov_salio = Convert.ToString(row["id_almacen_env_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string destino = Convert.ToString(row["destino"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string cajas = Convert.ToString(row["cajas"]);
                        string botellas_por_cajas = Convert.ToString(row["botellas_por_cajas"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        values += sep + "('" + id_almacen_envasado_movimientos + "','" + id_almacen_envasado_entrada + "','" + id_almacen_env_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + botellas + "','" + botellas_existentes + "','" + cajas + "','" + botellas_por_cajas + "','" + fecha + "','" + id_verificador + "',1,'" + observaciones + "')";
                        sep = ",";


                    }
                }
                sql += values + ";";



                if (bandera_update == true && bandera_insert == false)
                {

                    ConexionMysql.transCompleta();
                    return true;
                }
                else
                {
                    if (bandera_update == false && bandera_insert == true)
                    {
                        if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                            return false;
                        ConexionMysql.transCompleta();
                        return true;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla  almacen encargado
        public Boolean BajaAlmacenEncargado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_encargado (id_almacen, no_cliente, almacen, encargado,folio_unico_granel,estado,municipio,localidad, id_verificador,tipo_almacen, actualizado) VALUES";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen, no_cliente, almacen, encargado,folio_unico_granel,estado,municipio,localidad, id_verificador,tipo_almacen,actualizado  from rv_almacen_encargado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen from  almacen_encargado where id_almacen='" + Convert.ToString(row["id_almacen"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_encargado SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',almacen='" + Convert.ToString(row["almacen"]) + "',encargado='" + Convert.ToString(row["encargado"]) + "',folio_unico_granel='" + Convert.ToString(row["folio_unico_granel"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "',tipo_almacen='" + Convert.ToString(row["tipo_almacen"]) + "'  WHERE id_almacen='" + Convert.ToString(row["id_almacen"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string almacen = Convert.ToString(row["almacen"]);
                        string encargado = Convert.ToString(row["encargado"]);
                        string folio_unico_granel = Convert.ToString(row["folio_unico_granel"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_almacen = Convert.ToString(row["tipo_almacen"]);
                        values += sep + "('" + id_almacen + "','" + no_cliente + "','" + almacen + "','" + encargado + "','" + folio_unico_granel + "','" + estado + "','" + municipio + "','" + localidad + "'," + id_verificador + ",'" + tipo_almacen + "',1)";
                        sep = ",";
                    }
                }
                sql += values + ";";

                if (bandera_update == true && bandera_insert == false)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen_envasado_hologramas
        public Boolean BajaAlmacenEnvasadoHologramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_envasado_holograma (id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca,holograma_inicio, holograma_fin,serie,tipo_instalacion,id_verificador, actualizado, cliente_crm) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie,tipo_instalacion, id_verificador,actualizado,cliente_crm from rv_almacen_envasado_holograma");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_envasado_holograma from  almacen_envasado_holograma where id_almacen_envasado_holograma='" + Convert.ToString(row["id_almacen_envasado_holograma"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_envasado_holograma SET  id_almacen_envasado_entrada= '" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',cve_marca='" + Convert.ToString(row["cve_marca"]) + "',holograma_inicio='" + Convert.ToString(row["holograma_inicio"]) + "',holograma_fin='" + Convert.ToString(row["holograma_fin"]) + "',serie='" + Convert.ToString(row["serie"]) + "',tipo_instalacion='" + Convert.ToString(row["tipo_instalacion"]) + "',cliente_crm='" + Convert.ToString(row["cliente_crm"]) + "'   WHERE id_almacen_envasado_holograma='" + Convert.ToString(row["id_almacen_envasado_holograma"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen_envasado_holograma = Convert.ToString(row["id_almacen_envasado_holograma"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cve_marca = Convert.ToString(row["cve_marca"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string serie = Convert.ToString(row["serie"]);
                        string tipo_instalacion = Convert.ToString(row["tipo_instalacion"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string cliente_crm = Convert.ToString(row["cliente_crm"]);
                        values += sep + "('" + id_almacen_envasado_holograma + "','" + id_almacen_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + holograma_inicio + "','" + holograma_fin + "','" + serie + "','" + tipo_instalacion + "','" + id_verificador + "',1,'" + cliente_crm + "')";
                        sep = ",";


                    }
                }


                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen granel ensamble
        public Boolean BajaAlmacenGranelEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_ensamble (id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES";

                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from rv_almacen_granel_ensamble");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_granel_ensamble from  almacen_granel_ensamble where id_almacen_granel_ensamble='" + Convert.ToString(row["id_almacen_granel_ensamble"]) + "'");
                    if (id != "")
                    {

                        if (Convert.ToString(row["actualizado"]) == "0")
                        {

                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_granel_ensamble SET  id_comun='" + Convert.ToString(row["id_comun"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_almacen_granel_ensamble='" + Convert.ToString(row["id_almacen_granel_ensamble"]) + "' ") == "Error")
                                return false;

                        }

                    }
                    else
                    {
                        bandera_insert = true;

                        string id_almacen_granel_ensamble = Convert.ToString(row["id_almacen_granel_ensamble"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_almacen_granel_entrada_salio = Convert.ToString(row["id_almacen_granel_entrada_salio"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_ensamble + "','" + id_almacen_granel_entrada + "','" + id_almacen_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";

                    }

                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen_granel_entrada
        public Boolean BajaAlmacenGranelEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_entrada (id_almacen_granel_entrada, id_lote_reveca,no_cliente, id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,fecha_movimiento, id_verificador, actualizado) VALUES";
                string update = "UPDATE almacen_granel_entrada SET actualizado=1 WHERE id_almacen_granel_entrada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_entrada, id_lote_reveca, no_cliente, id_almacen,  DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_almacen_granel_entrada");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    /* @adnto en el foreach recorre los resultados de todos aquellos registros de la tabla local granel_entrada
                     * que el campo actualizado tenga=0 en cada iteración obtiene obtiene el id del registro
                     * consulta el id en la tabla del servidor, si existe ese id  */

                string id = ConexionMysql.regresaCampoConsulta("select id_almacen_granel_entrada from  almacen_granel_entrada where id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "'");
                    if (id != "")
                    {
                        /* @adnto si trae algó la cadena de id, quiere decir q el id existe en el servidor
                         * entonces quiere decir q tendrá q actualizar se en el servidor */
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;

                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_granel_entrada   SET   id_lote_reveca='" + Convert.ToString(row["id_lote_reveca"]) + "' ,no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_almacen='" + Convert.ToString(row["id_almacen"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',lts_entrada='" + Convert.ToString(row["lts_entrada"]) + "',grado_alcoholico_entrada='" + Convert.ToString(row["grado_alcoholico_entrada"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "'   WHERE id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "' ") == "Error")
                                return false;
                        }


                    }
                    else
                    {
                        /* @dnto si no encuentra coincidencia con algún id entonces tendrá q hacer una insercción   */
                        bandera_insert = true;

                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_lote_reveca = Convert.ToString(row["id_lote_reveca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string tipo_producto = Convert.ToString(row["tipo_ingreso"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_entrada + "','" + id_lote_reveca + "','" + no_cliente + "','" + id_almacen + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + tipo_producto + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }


                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


        }



        //Baja la tabla almacen_granel_movimientos
        public Boolean BajaAlmacenGranelMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos, id_almacen_granel_entrada, id_almacen_granel_entrada_sal, id_almacen_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, fecha,fecha_movimiento, id_verificador, actualizado) VALUES";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_movimientos, id_almacen_granel_entrada, id_almacen_granel_entrada_sal, id_almacen_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_almacen_granel_movimientos");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_almacen_granel_movimientos from  almacen_granel_movimientos where id_almacen_granel_movimientos='" + Convert.ToString(row["id_almacen_granel_movimientos"]) + "'");
                    if (id != "")
                    {
                        /*@adnto si existe el id quiere decir que ya existe el registro por lo tanto lo que se debe de hacer es solamente actualizar en el servidor (UPDATE) */


                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;

                            if (ConexionMysql.insUpd_transaccion("UPDATE almacen_granel_movimientos SET id_almacen_granel_entrada_sal='" + Convert.ToString(row["id_almacen_granel_entrada_sal"]) + "', id_almacen_gran_mov_salio='" + Convert.ToString(row["id_almacen_gran_mov_salio"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "', no_lote='" + Convert.ToString(row["no_lote"]) + "', folio='" + Convert.ToString(row["folio"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',merma_litros='" + Convert.ToString(row["merma_litros"]) + "',numero_de_contenedores_iniciales='" + Convert.ToString(row["numero_de_contenedores_iniciales"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',salida_externa='" + Convert.ToString(row["salida_externa"]) + "',razon_social_externa='" + Convert.ToString(row["razon_social_externa"]) + "',bebidasCon='"+ Convert.ToString(row["bebidasCon"]) + "',destinobBebidasCon='" + Convert.ToString(row["destinobBebidasCon"]) + "',fecha= '" + Convert.ToString(row["fecha"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "' WHERE id_almacen_granel_movimientos='" + Convert.ToString(row["id_almacen_granel_movimientos"]) + "' ") == "Error")
                                return false;

                        }
                    }
                    else
                    {
                        /*@adnto cuando no encuentra el id quiere decir q no existe ese registro y q debera ser tomado como nuevo e insertarlo en el servidor. */
                        bandera_insert = true;
                        string id_almacen_granel_movimientos = Convert.ToString(row["id_almacen_granel_movimientos"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_almacen_granel_entrada_sal = Convert.ToString(row["id_almacen_granel_entrada_sal"]);
                        string id_almacen_gran_mov_salio = Convert.ToString(row["id_almacen_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string tipo_cobro = Convert.ToString(row["tipo_cobro"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_anteriores = Convert.ToString(row["lts_anteriores"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string salida_externa = Convert.ToString(row["salida_externa"]);
                        string razon_social_externa = Convert.ToString(row["razon_social_externa"]);
                        string bebidasCon = Convert.ToString(row["bebidasCon"]);
                        string destinobBebidasCon = Convert.ToString(row["destinobBebidasCon"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_movimientos + "','" + id_almacen_granel_entrada + "','" + id_almacen_granel_entrada_sal + "','" + id_almacen_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + tipo_cobro + "','" + observaciones + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + salida_externa + "','" + razon_social_externa + "','"+ bebidasCon +"','"+ destinobBebidasCon +"','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";



                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }



        //sube la tabla almacen granel tanque 
        public Boolean BajaAlmacenGranelTanque()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                string sql = "INSERT INTO almacen_granel_tanques (id_tanque, id_almacen_granel_entrada, tanque, id_verificador, actualizado) VALUES";

                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_tanque, id_almacen_granel_entrada, tanque, id_verificador, actualizado from rv_almacen_granel_tanques");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_tanque from  almacen_granel_tanques where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");
                    if (id != "")
                    {

                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_tanques SET  tanque='" + Convert.ToString(row["tanque"]) + "'   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        bandera_insert = true;



                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_tanque + "','" + id_almacen_granel_entrada + "','" + tanque + "','" + id_verificador + "',1)";
                        sep = ",";

                    }

                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        public Boolean BajaAlmacenGranelSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO almacen_granel_salida (id_almacen_granel_salida, id_almacen_granel_entrada, id_solicitud,id_granel_entrada, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador) VALUES";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_almacen_granel_salida, id_almacen_granel_entrada, id_solicitud,id_granel_entrada, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado from rv_almacen_granel_salida");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_almacen_granel_salida from  almacen_granel_salida where id_granel_salida='" + Convert.ToString(row["id_almacen_granel_salida"]) + "'");
                    if (id != "")
                    {

                        if (Convert.ToString(row["actualizado"]) == "0")
                        {

                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_salida SET  id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico=  '" + Convert.ToString(row["grado_alcoholico"]) + "'     WHERE id_almacen_granel_salida='" + Convert.ToString(row["id_almacen_granel_salida"]) + "' ") == "Error")
                                return false;

                        }

                    }
                    else
                    {
                        bandera_insert = true;


                        string id_almacen_granel_salida = Convert.ToString(row["id_almacen_granel_salida"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        //REVISAR PORQUE AQUI ENVÍA EL VALOR "1" A LA COLUMNA ACTUALIZADO PERO EN EL INSERT(QUERY) NO AGREGA ESA COLUMNA
                        values += sep + "('" + id_almacen_granel_salida + "','" + id_almacen_granel_entrada + "','" + id_solicitud + "','" + id_granel_entrada + "','" + id_granel_entrada_envasado + "','" + id_envasado_entrada + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1)";
                        sep = ",";
                        values_update += sep_update + "'" + id_almacen_granel_salida + "'";
                        sep_update = ",";

                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //baja la tabla maestros_mezcaleros
        public Boolean BajaMaestroMezcalero()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql = "INSERT INTO maestros_mezcaleros (id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha, activo, actualizado) VALUES";

                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, activo, actualizado from rv_maestros_mezcaleros");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_maestros_mezcaleros from  maestros_mezcaleros where id_maestros_mezcaleros='" + Convert.ToString(row["id_maestros_mezcaleros"]) + "'");
                    if (id != "")
                    {

                        if (Convert.ToString(row["actualizado"]) == "0")
                        {

                            bandera_update = true;

                            if (ConexionMysql.insUpd_transaccion("UPDATE  maestros_mezcaleros SET  n_maestro_mezcalero='" + Convert.ToString(row["n_maestro_mezcalero"]) + "' ,id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "', activo='" + Convert.ToString(row["activo"]) + "'   WHERE id_maestros_mezcaleros='" + Convert.ToString(row["id_maestros_mezcaleros"]) + "'") == "Error")
                                return false;
                        }

                    }
                    else
                    {

                        bandera_insert = true;
                        string id_maestros_mezcaleros = Convert.ToString(row["id_maestros_mezcaleros"]);
                        string n_maestro_mezcalero = Convert.ToString(row["n_maestro_mezcalero"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string activo = Convert.ToString(row["activo"]);
                        values += sep + "('" + id_maestros_mezcaleros + "','" + n_maestro_mezcalero + "','" + id_fabrica + "','" + id_verificador + "','" + fecha + "','" + activo + "',1)";
                        sep = ",";

                    }
                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        public Boolean BajaEnvasadoSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO envasado_salida (id_envasado_salida, id_envasado_entrada, id_almacen_envasado_entrada, id_granel_entrada_envasado, id_envasado_mov_salida, litros, botellas, grado_alcoholico, tipo_salida, observaciones, id_verificador, fecha, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_salida, id_envasado_entrada, id_almacen_envasado_entrada, id_granel_entrada_envasado, id_envasado_mov_salida, litros, botellas, grado_alcoholico, tipo_salida, observaciones, id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, actualizado from rv_envasado_salida");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_salida from  envasado_salida where id_envasado_salida='" + Convert.ToString(row["id_envasado_salida"]) + "'");
                    if (id != "")
                    {


                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;

                            if (ConexionMysql.insUpd_transaccion("UPDATE  envasado_salida SET  id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "' ,id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "', id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', id_envasado_mov_salida='" + Convert.ToString(row["id_envasado_mov_salida"]) + "', litros='" + Convert.ToString(row["litros"]) + "', botellas='" + Convert.ToString(row["botellas"]) + "', grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "', tipo_salida='" + Convert.ToString(row["tipo_salida"]) + "', observaciones='" + Convert.ToString(row["observaciones"]) + "'   WHERE id_envasado_salida='" + Convert.ToString(row["id_envasado_salida"]) + "'") == "Error")
                                return false;
                        }

                    }
                    else
                    {

                        bandera_insert = true;

                        string id_envasado_salida = Convert.ToString(row["id_envasado_salida"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_envasado_mov_salida = Convert.ToString(row["id_envasado_mov_salida"]);
                        string litros = Convert.ToString(row["litros"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string tipo_salida = Convert.ToString(row["tipo_salida"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);

                        values += sep + "('" + id_envasado_salida + "','" + id_envasado_entrada + "','" + id_almacen_envasado_entrada + "','" + id_granel_entrada_envasado + "','" + id_envasado_mov_salida + "','" + litros + "','" + botellas + "','" + grado_alcoholico + "','" + tipo_salida + "','" + observaciones + "','" + id_verificador + "','" + fecha + "',1)";
                        sep = ",";


                    }

                }
                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        public Boolean BajaMensajesRegistros()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO mensajes_registros (id_mensaje, id_registro, tipo, mensaje, fecha, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_mensaje, id_registro, tipo, mensaje, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_verificador, actualizado from rv_mensajes_registros ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_mensaje from  mensajes_registros where id_mensaje='" + Convert.ToString(row["id_mensaje"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE mensajes_registros SET mensaje='" + Convert.ToString(row["mensaje"]) + "', id_verificador='" + Convert.ToString(row["id_verificador"]) + "' WHERE id_mensaje='" + Convert.ToString(row["id_mensaje"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_mensaje = Convert.ToString(row["id_mensaje"]);
                        string id_registro = Convert.ToString(row["id_registro"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string mensaje = Convert.ToString(row["mensaje"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_mensaje + "','" + id_registro + "','" + tipo + "','" + mensaje + "','" + fecha + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        public Boolean BajaFqHistorial()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO fq_historial (id_fq, id_produccion, tipo, fq, litros, grado_alcoholico, observacion, id_verificador, actualizado, fecha) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_fq, id_produccion, tipo, fq, litros, grado_alcoholico, observacion, id_verificador, actualizado,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha  from rv_fq_historial ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_fq from  fq_historial where id_fq='" + Convert.ToString(row["id_fq"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE fq_historial SET fq='" + Convert.ToString(row["fq"]) + "', id_produccion='" + Convert.ToString(row["id_produccion"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "', litros='" + Convert.ToString(row["litros"]) + "' WHERE id_fq='" + Convert.ToString(row["id_fq"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {

                        bandera_insert = true;
                        string id_fq = Convert.ToString(row["id_fq"]);
                        string id_produccion = Convert.ToString(row["id_produccion"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string fq = Convert.ToString(row["fq"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string observacion = Convert.ToString(row["observacion"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);


                        values += sep + "('" + id_fq + "','" + id_produccion + "','" + tipo + "','" + fq + "','" + litros + "','" + grado_alcoholico + "','" + observacion + "','" + id_verificador + "',1,'" + fecha + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //baja las salidas de los hologramas entregados
        public Boolean BajaSalidaHolgramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO hologramas_salida (id_salidas, no_cliente, marca, serie,edo, fi1, ff1, se1, cliente_crm) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_salidas, no_cliente, marca, serie,edo, fi1, ff1, se1,actualizado, cliente_crm from h_salidas ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_salidas from  hologramas_salida where id_salidas='" + Convert.ToString(row["id_salidas"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE hologramas_salida SET fi1='" + Convert.ToString(row["fi1"]) + "', ff1='" + Convert.ToString(row["ff1"]) + "',se1='" + Convert.ToString(row["se1"]) + "',cliente_crm='" + Convert.ToString(row["cliente_crm"]) + "'  WHERE id_salidas='" + Convert.ToString(row["id_salidas"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_salidas = Convert.ToString(row["id_salidas"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string marca = Convert.ToString(row["marca"]);
                        string serie = Convert.ToString(row["serie"]);
                        string edo = Convert.ToString(row["edo"]);
                        string fi1 = Convert.ToString(row["fi1"]);
                        string ff1 = Convert.ToString(row["ff1"]);
                        string se1 = Convert.ToString(row["se1"]);
                        string cliente_crm = Convert.ToString(row["cliente_crm"]);

                        values += sep + "('" + id_salidas + "','" + no_cliente + "','" + marca + "','" + serie + "','" + edo + "','" + fi1 + "','" + ff1 + "','" + se1 + "', '" + cliente_crm + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //baja transaciones
        public Boolean BajaTransacciones()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO transacciones (id_transaccion, id_granel_entrada, id_granel_entrada_recibe, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe, id_envasado_entrada, id_envasado_entrada_recibe, no_traslado, id_verificador, actualizado, tipo_transaccion) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_transaccion, id_granel_entrada, id_granel_entrada_recibe, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe, id_envasado_entrada, id_envasado_entrada_recibe, no_traslado, id_verificador, actualizado, tipo_transaccion from rv_transacciones ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_transaccion from  transacciones where id_transaccion='" + Convert.ToString(row["id_transaccion"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE transacciones SET    no_traslado='" + Convert.ToString(row["no_traslado"]) + "', id_envasado_entrada_recibe='" + Convert.ToString(row["id_envasado_entrada_recibe"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',id_granel_entrada_envasado_recibe='" + Convert.ToString(row["id_granel_entrada_envasado_recibe"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "',id_granel_entrada_recibe='" + Convert.ToString(row["id_granel_entrada_recibe"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',actualizado=1, " + "tipo_transaccion='" + Convert.ToString(row["tipo_transaccion"]) + "' WHERE id_transaccion='" + Convert.ToString(row["id_transaccion"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_transaccion = Convert.ToString(row["id_transaccion"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_recibe = Convert.ToString(row["id_granel_entrada_recibe"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_envasado_recibe = Convert.ToString(row["id_granel_entrada_envasado_recibe"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_envasado_entrada_recibe = Convert.ToString(row["id_envasado_entrada_recibe"]);
                        string no_traslado = Convert.ToString(row["no_traslado"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_transaccion = Convert.ToString(row["tipo_transaccion"]);

                        values += sep + "('" + id_transaccion + "','" + id_granel_entrada + "','" + id_granel_entrada_recibe + "','" + id_granel_entrada_envasado + "','" + id_granel_entrada_envasado_recibe + "','" + id_envasado_entrada + "','" + id_envasado_entrada_recibe + "','" + no_traslado + "','" + id_verificador + "',1, '" + tipo_transaccion + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actauliza  los valores de la tabla envasao entrada
        public Boolean BajaEnvasadoEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_entrada (id_envasado_entrada,id_envasado_entrada_salio, id_marca, no_cliente, id_envasadora,tipo_destino,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,verificador_termina,tipo_ingreso,actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_entrada,id_envasado_entrada_salio, id_marca, no_cliente, id_envasadora,tipo_destino,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado,'%Y-%m-%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin,'%Y-%m-%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales, botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,verificador_termina,tipo_ingreso,actualizado from rv_envasado_entrada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_entrada from  envasado_entrada where id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE envasado_entrada SET id_envasado_entrada_salio='" + Convert.ToString(row["id_envasado_entrada_salio"]) + "',id_marca='" + Convert.ToString(row["id_marca"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',fecha_envasado_ini='" + Convert.ToString(row["fecha_envasado_ini"]) + "',fecha_envasado_fin='" + Convert.ToString(row["fecha_envasado_fin"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "',tipo_destino='" + Convert.ToString(row["tipo_destino"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',etiquetado_como='" + Convert.ToString(row["etiquetado_como"]) + "',unidad_medida='" + Convert.ToString(row["unidad_medida"]) + "',contenido_por_botella='" + Convert.ToString(row["contenido_por_botella"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',grado_alcoholico_etiqueta='" + Convert.ToString(row["grado_alcoholico_etiqueta"]) + "',botellas_iniciales='" + Convert.ToString(row["botellas_iniciales"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',holograma_inicio='" + Convert.ToString(row["holograma_inicio"]) + "',holograma_fin='" + Convert.ToString(row["holograma_fin"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',verificador_termina='" + Convert.ToString(row["verificador_termina"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',actualizado=1  WHERE id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_envasado_entrada_salio = Convert.ToString(row["id_envasado_entrada_salio"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string tipo_destino = Convert.ToString(row["tipo_destino"]);// se agrega 2021
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);//-- se agreg0
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_envasado_ini = Convert.ToString(row["fecha_envasado_ini"]);
                        string fecha_envasado_fin = Convert.ToString(row["fecha_envasado_fin"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string etiquetado_como = Convert.ToString(row["etiquetado_como"]);
                        string unidad_medida = Convert.ToString(row["unidad_medida"]);
                        string contenido_por_botella = Convert.ToString(row["contenido_por_botella"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string grado_alcoholico_etiqueta = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        string botellas_iniciales = Convert.ToString(row["botellas_iniciales"]);//-- se agego
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string verificador_termina = Convert.ToString(row["verificador_termina"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);

                        values += sep + "('" + id_envasado_entrada + "','" + id_envasado_entrada_salio + "','" + id_marca + "','" + no_cliente + "','" + id_envasadora + "','" + tipo_destino + "','" + fecha_movimiento + "','" + fecha + "','" + fecha_envasado_ini + "','" + fecha_envasado_fin + "','" + id_comun + "','" + no_lote_granel + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + etiquetado_como + "','" + unidad_medida + "','" + contenido_por_botella + "','" + litros + "','" + grado_alcoholico + "','" + grado_alcoholico_etiqueta + "','" + botellas_iniciales + "','" + botellas + "','" + botellas_existentes + "','" + holograma_inicio + "','" + holograma_fin + "','" + id_verificador + "','"+ verificador_termina + "','" + tipo_ingreso + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//--- Fin de BajaEnvasadoEntrada



        //actualiza los valores d ela tabla envasado movimientos
        public Boolean BajaEnvasadoMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_movimientos (id_envasado_movimientos, id_envasado_entrada, id_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, fecha, id_verificador, actualizado, observaciones) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_movimientos, id_envasado_entrada, id_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas,  DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, id_verificador, actualizado, observaciones from rv_envasado_movimientos ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_movimientos from  envasado_movimientos where id_envasado_movimientos='" + Convert.ToString(row["id_envasado_movimientos"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE envasado_movimientos SET  id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',id_env_mov_salio='" + Convert.ToString(row["id_env_mov_salio"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_solicitud='" + Convert.ToString(row["id_solicitud"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',cajas='" + Convert.ToString(row["cajas"]) + "',botellas_por_cajas='" + Convert.ToString(row["botellas_por_cajas"]) + "',actualizado=1,observaciones='" + Convert.ToString(row["observaciones"]) + "' WHERE id_envasado_movimientos ='" + Convert.ToString(row["id_envasado_movimientos"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_movimientos = Convert.ToString(row["id_envasado_movimientos"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_env_mov_salio = Convert.ToString(row["id_env_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string destino = Convert.ToString(row["destino"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string cajas = Convert.ToString(row["cajas"]);
                        string botellas_por_cajas = Convert.ToString(row["botellas_por_cajas"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        values += sep + "('" + id_envasado_movimientos + "','" + id_envasado_entrada + "','" + id_env_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + botellas + "','" + botellas_existentes + "','" + cajas + "','" + botellas_por_cajas + "','" + fecha + "','" + id_verificador + "',1,'" + observaciones + "')";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores d ela tabla envasado encargado
        public Boolean BajaEnvasadoEncargado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasadora_encargado (id_envasadora, no_cliente, envasadora, encargado,estado,municipio,localidad,envasadora_externa, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasadora, no_cliente, envasadora, encargado, estado,municipio,localidad,envasadora_externa,id_verificador, actualizado from rv_envasadora_encargado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasadora from  envasadora_encargado where id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE envasadora_encargado SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',envasadora='" + Convert.ToString(row["envasadora"]) + "',encargado='" + Convert.ToString(row["encargado"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "',envasadora_externa='" + Convert.ToString(row["envasadora_externa"]) + "'  WHERE id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string envasadora = Convert.ToString(row["envasadora"]);
                        string encargado = Convert.ToString(row["encargado"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string envasadora_externa = Convert.ToString(row["envasadora_externa"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_envasadora + "','" + no_cliente + "','" + envasadora + "','" + encargado + "','" + estado + "','" + municipio + "','" + localidad + "','" + envasadora_externa + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de existencia_planta comprada
        public Boolean BajaExistenciaPlantaComprada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO existenciaplanta_comprada (id_existenciaplanta_comprada,no_guia, id_planta, no_cliente, cantidadini, existenciaplantas, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_existenciaplanta_comprada,no_guia, id_planta, no_cliente, cantidadini, existenciaplantas, id_verificador, actualizado from rv_existenciaplanta_comprada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_existenciaplanta_comprada from  existenciaplanta_comprada where id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE existenciaplanta_comprada SET  no_guia='" + Convert.ToString(row["no_guia"]) + "' ,id_planta='" + Convert.ToString(row["id_planta"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', cantidadini='" + Convert.ToString(row["cantidadini"]) + "',existenciaplantas='" + Convert.ToString(row["existenciaplantas"]) + "' WHERE id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_existenciaplanta_comprada = Convert.ToString(row["id_existenciaplanta_comprada"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_existenciaplanta_comprada + "','" + no_guia + "','" + id_planta + "','" + no_cliente + "','" + cantidadini + "','" + existenciaplantas + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean BajaExistenciaPlantaCompradaAntiguo()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO reveca2_existenciaplanta_comprada (id_existenciaplanta_comprada,no_guia, id_planta, no_cliente, cantidadini, existenciaplantas, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_existenciaplanta_comprada,no_guia, id_planta, no_cliente, cantidadini, existenciaplantas, id_verificador, actualizado from crm_existenciaplanta_comprada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_existenciaplanta_comprada from  reveca2_existenciaplanta_comprada where id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE reveca2_existenciaplanta_comprada SET  no_guia='" + Convert.ToString(row["no_guia"]) + "' ,id_planta='" + Convert.ToString(row["id_planta"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', cantidadini='" + Convert.ToString(row["cantidadini"]) + "',existenciaplantas='" + Convert.ToString(row["existenciaplantas"]) + "' WHERE id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_existenciaplanta_comprada = Convert.ToString(row["id_existenciaplanta_comprada"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_existenciaplanta_comprada + "','" + no_guia + "','" + id_planta + "','" + no_cliente + "','" + cantidadini + "','" + existenciaplantas + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //actualiza los valores de granel_ensamble 
        public Boolean BajaGranelEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_ensamble (id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from rv_granel_ensamble ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_ensamble from  granel_ensamble where id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_ensamble SET id_granel_entrada ='" + Convert.ToString(row["id_granel_entrada"]) + "', id_comun='" + Convert.ToString(row["id_comun"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_ensamble = Convert.ToString(row["id_granel_ensamble"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_salio = Convert.ToString(row["id_granel_entrada_salio"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_granel_ensamble + "','" + id_granel_entrada + "','" + id_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_ensamble_envasado
        public Boolean BajaGranelEnsambleEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_ensamble_envasado (id_granel_ensamble, id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_ensamble, id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from rv_granel_ensamble_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_ensamble from  granel_ensamble_envasado where id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_ensamble_envasado SET  id_granel_entrada_envasado ='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', id_comun='" + Convert.ToString(row["id_comun"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_granel_ensamble='" + Convert.ToString(row["id_granel_ensamble"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_ensamble = Convert.ToString(row["id_granel_ensamble"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_salio = Convert.ToString(row["id_granel_entrada_envasado_salio"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_granel_ensamble + "','" + id_granel_entrada + "','" + id_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        ///////////////////////////////////////////////////////////////2020//////////////////////////////////////////////////////////////////////////////////////////////////

        //actualiza los valores de granel_entrada
        public Boolean BajaGranelEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_entrada (id_granel_entrada,id_lote_reveca, no_cliente, id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey,actualizado) VALUES";

                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_entrada, id_lote_reveca, no_cliente, id_fabrica, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha , id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') AS fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey, actualizado from rv_granel_entrada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_entrada from  granel_entrada where id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada   SET   id_lote_reveca='" + Convert.ToString(row["id_lote_reveca"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',lts_entrada='" + Convert.ToString(row["lts_entrada"]) + "',grado_alcoholico_entrada='" + Convert.ToString(row["grado_alcoholico_entrada"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',tipo_cultivo_maguey='" + Convert.ToString(row["tipo_cultivo_maguey"]) + "'   WHERE id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_lote_reveca = Convert.ToString(row["id_lote_reveca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);
                        string tipo_cultivo_maguey = Convert.ToString(row["tipo_cultivo_maguey"]);

                        values += sep + "('" + id_granel_entrada + "','" + id_lote_reveca + "','" + no_cliente + "','" + id_fabrica + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + fecha_movimiento + "','" + id_verificador + "','" + tipo_ingreso + "','" + tipo_cultivo_maguey + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_entrada_envasado
        public Boolean BajaGranelEntradaEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_entrada_envasado (id_granel_entrada_envasado, id_lote_reveca, no_cliente, id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_entrada_envasado, id_lote_reveca, no_cliente, id_envasadora, DATE_FORMAT(fecha,'%Y-%m-%d') as fecha , id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') AS fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey, actualizado from rv_granel_entrada_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_entrada_envasado from  granel_entrada_envasado where id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada_envasado   SET   id_lote_reveca='" + Convert.ToString(row["id_lote_reveca"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote='" + Convert.ToString(row["no_lote"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "',categoria='" + Convert.ToString(row["categoria"]) + "',abocante='" + Convert.ToString(row["abocante"]) + "',ingrediente='" + Convert.ToString(row["ingrediente"]) + "',lts_entrada='" + Convert.ToString(row["lts_entrada"]) + "',grado_alcoholico_entrada='" + Convert.ToString(row["grado_alcoholico_entrada"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',tipo_cultivo_maguey='" + Convert.ToString(row["tipo_cultivo_maguey"]) + "'  WHERE id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_lote_reveca = Convert.ToString(row["id_lote_reveca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);
                        string tipo_cultivo_maguey = Convert.ToString(row["tipo_cultivo_maguey"]);

                        values += sep + "('" + id_granel_entrada + "','" + id_lote_reveca + "','" + no_cliente + "','" + id_envasadora + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + fecha_movimiento + "','" + id_verificador + "','" + tipo_ingreso + "','" + tipo_cultivo_maguey + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_movimientos
        public Boolean BajaGranelMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_movimientos (id_granel_movimientos, id_granel_entrada, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, fecha,fecha_movimiento, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_movimientos, id_granel_entrada, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_granel_movimientos ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_movimientos from  granel_movimientos where id_granel_movimientos='" + Convert.ToString(row["id_granel_movimientos"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_movimientos SET id_granel_entrada_sal='" + Convert.ToString(row["id_granel_entrada_sal"]) + "', id_gran_mov_salio='" + Convert.ToString(row["id_gran_mov_salio"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "', no_lote='" + Convert.ToString(row["no_lote"]) + "', folio='" + Convert.ToString(row["folio"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',merma_litros='" + Convert.ToString(row["merma_litros"]) + "',numero_de_contenedores_iniciales='" + Convert.ToString(row["numero_de_contenedores_iniciales"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',salida_externa='" + Convert.ToString(row["salida_externa"]) + "',razon_social_externa='" + Convert.ToString(row["razon_social_externa"]) + "',bebidasCon='"+ Convert.ToString(row["bebidasCon"]) + "',destinobBebidasCon='" + Convert.ToString(row["destinobBebidasCon"]) + "',fecha= '" + Convert.ToString(row["fecha"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "'WHERE id_granel_movimientos='" + Convert.ToString(row["id_granel_movimientos"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_movimientos = Convert.ToString(row["id_granel_movimientos"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_sal = Convert.ToString(row["id_granel_entrada_sal"]);
                        string id_gran_mov_salio = Convert.ToString(row["id_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string salida_externa = Convert.ToString(row["salida_externa"]);
                        string razon_social_externa = Convert.ToString(row["razon_social_externa"]);
                        string bebidasCon = Convert.ToString(row["bebidasCon"]);
                        string destinobBebidasCon = Convert.ToString(row["destinobBebidasCon"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_granel_movimientos + "','" + id_granel_entrada + "','" + id_granel_entrada_sal + "','" + id_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + salida_externa + "','" + razon_social_externa + "','" + bebidasCon + "','" + destinobBebidasCon + "','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores de granel_movimientos_envasado
        public Boolean BajaGranelMovimientosEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado, id_granel_entrada_envasado, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, fecha,fecha_movimiento, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_movimientos_envasado, id_granel_entrada_envasado, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico,lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from rv_granel_movimientos_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_movimientos_envasado from  granel_movimientos_envasado where id_granel_movimientos_envasado='" + Convert.ToString(row["id_granel_movimientos_envasado"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;

                            ///--- en proceso
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_movimientos_envasado SET  id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', id_granel_entrada_sal='" + Convert.ToString(row["id_granel_entrada_sal"]) + "', id_gran_mov_salio='" + Convert.ToString(row["id_gran_mov_salio"]) + "', no_cliente='" + Convert.ToString(row["no_cliente"]) + "', tipo='" + Convert.ToString(row["tipo"]) + "', destino='" + Convert.ToString(row["destino"]) + "', no_lote='" + Convert.ToString(row["no_lote"]) + "', folio='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',merma_litros='" + Convert.ToString(row["merma_litros"]) + "', numero_de_contenedores_iniciales='" + Convert.ToString(row["numero_de_contenedores_iniciales"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',salida_externa='" + Convert.ToString(row["salida_externa"]) + "',razon_social_externa='" + Convert.ToString(row["razon_social_externa"]) + "',bebidasCon='" + Convert.ToString(row["bebidasCon"]) + "',destinobBebidasCon='"+ Convert.ToString(row["destinobBebidasCon"]) +"',fecha= '" + Convert.ToString(row["fecha"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "'     WHERE id_granel_movimientos_envasado='" + Convert.ToString(row["id_granel_movimientos_envasado"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_movimientos = Convert.ToString(row["id_granel_movimientos_envasado"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_sal = Convert.ToString(row["id_granel_entrada_sal"]);
                        string id_gran_mov_salio = Convert.ToString(row["id_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_anteriores = Convert.ToString(row["lts_anteriores"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string salida_externa = Convert.ToString(row["salida_externa"]);
                        string razon_social_externa = Convert.ToString(row["razon_social_externa"]);
                        string bebidasCon = Convert.ToString(row["bebidasCon"]);
                        string destinobBebidasCon = Convert.ToString(row["destinobBebidasCon"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        //aqui estaba mal porque invirtió los valores que se descargan de la BD global, lts anteriores-->lts existentes
                        values += sep + "('" + id_granel_movimientos + "','" + id_granel_entrada + "','" + id_granel_entrada_sal + "','" + id_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + salida_externa + "','" + razon_social_externa + "','"+ bebidasCon +"','"+ destinobBebidasCon +"','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    // MessageBox.Show(sql);
                    //Clipboard.SetText(sql);
                    //System.IO.File.WriteAllText("C:\\xd\\ErroresReVeCa2.txt", sql);
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //actualiza los valores de granel_salida
        public Boolean BajaGranelSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_salida (id_granel_salida, id_granel_entrada, id_solicitud, id_granel_entrada_envasado,id_almacen_granel_entrada, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_granel_salida, id_granel_entrada, id_solicitud, id_granel_entrada_envasado, id_almacen_granel_entrada, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado from rv_granel_salida ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_granel_salida from  granel_salida where id_granel_salida='" + Convert.ToString(row["id_granel_salida"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_salida SET  id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "',id_almacen_granel_entrada= '" + Convert.ToString(row["id_almacen_granel_entrada"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico=  '" + Convert.ToString(row["grado_alcoholico"]) + "'     WHERE id_granel_salida='" + Convert.ToString(row["id_granel_salida"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_salida = Convert.ToString(row["id_granel_salida"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_granel_salida + "','" + id_granel_entrada + "','" + id_solicitud + "','" + id_granel_entrada_envasado + "','" + id_almacen_granel_entrada + "','" + id_envasado_entrada + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1)";
                        sep = ",";


                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de granel_tanques
        public Boolean BajaGranelTanque()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_tanques (id_tanque, id_granel_entrada, tanque, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_tanque, id_granel_entrada, tanque, id_verificador, actualizado from rv_granel_tanques ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_tanque from  granel_tanques where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_tanques SET  id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "', tanque='" + Convert.ToString(row["tanque"]) + "'   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_tanque + "','" + id_granel_entrada + "','" + tanque + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //actualiza los valores de granel_tanques_envasado
        public Boolean BajaGranelTanqueEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO granel_tanques_envasado (id_tanque, id_granel_entrada_envasado, tanque, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_tanque, id_granel_entrada_envasado, tanque, id_verificador, actualizado from rv_granel_tanques_envasado ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_tanque from  granel_tanques_envasado where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE granel_tanques_envasado SET id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', tanque='" + Convert.ToString(row["tanque"]) + "'   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_tanque + "','" + id_granel_entrada + "','" + tanque + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //actualiza los valores de maestro fabrica
        public Boolean BajaMaestroFabrica()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO maestro_fabrica (id_fabrica, no_cliente, fabrica,maestro,folio_unico_granel,estado,municipio,localidad,id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_fabrica, no_cliente, fabrica, maestro,folio_unico_granel,estado,municipio,localidad,id_verificador, actualizado from rv_maestro_fabrica ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_fabrica from  maestro_fabrica where id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE maestro_fabrica SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',fabrica='" + Convert.ToString(row["fabrica"]) + "',maestro='" + Convert.ToString(row["maestro"]) + "',folio_unico_granel='" + Convert.ToString(row["folio_unico_granel"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "'   WHERE id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string fabrica = Convert.ToString(row["fabrica"]);
                        string maestro = Convert.ToString(row["maestro"]);
                        string folio_unico_granel = Convert.ToString(row["folio_unico_granel"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_fabrica + "','" + no_cliente + "','" + fabrica + "','" + maestro + "','" + folio_unico_granel + "','" + estado + "','" + municipio + "','" + localidad + "','" + id_verificador + "',1)";
                        sep = ",";
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores de agave cocido sobrante
        public Boolean BajaAgaveCocidoSobrante()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_agave_cocido_sobrante (id_agave_cocido_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_predio, id_planta, agave_cocido_kg, porcentaje_art, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_agave_cocido_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_predio, id_planta, agave_cocido_kg, porcentaje_art, id_verificador, actualizado from rv_produccion_agave_cocido_sobrante ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_agave_cocido_sobrante from  produccion_agave_cocido_sobrante where id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_cocido_sobrante SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',agave_cocido_kg='" + Convert.ToString(row["agave_cocido_kg"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "'   WHERE id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;


                        string id_agave_cocido_sobrante = Convert.ToString(row["id_agave_cocido_sobrante"]);
                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_cocido_kg = Convert.ToString(row["agave_cocido_kg"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_agave_cocido_sobrante + "','" + id_ensamble_union + "','" + id_produccion_entrada + "','" + no_cliente + "','" + id_predio + "','" + id_planta + "','" + agave_cocido_kg + "','" + porcentaje_art + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores de agave sobrante
        public Boolean BajaAgaveSobrante()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_agave_sobrante (id_agave_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_planta, agave_kg, porcentaje_art, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_agave_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_planta, agave_kg, porcentaje_art, id_verificador, actualizado from rv_produccion_agave_sobrante ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_agave_sobrante from  produccion_agave_sobrante where id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_agave_sobrante SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',agave_kg='" + Convert.ToString(row["agave_kg"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "'   WHERE id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;


                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);

                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_agave_sobrante + "','" + id_ensamble_union + "','" + id_produccion_entrada + "','" + no_cliente + "','" + id_planta + "','" + agave_kg + "','" + porcentaje_art + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores produccion ensamble
        public Boolean BajaProduccionEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_ensamble ( id_ensamble_union, id_produccion_entrada, id_agave_sobrante, id_agave_cocido_sobrante, id_predio, id_planta,no_guia, no_pinas_agave, agave_kg, agave_coccion_kg, porcentaje_art, tipo, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_ensamble_union, id_produccion_entrada, id_agave_sobrante, id_agave_cocido_sobrante, id_predio, id_planta,no_guia, no_pinas_agave, agave_kg, agave_coccion_kg, porcentaje_art, tipo, id_verificador, actualizado from rv_produccion_ensamble ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_ensamble_union from  produccion_ensamble where id_ensamble_union='" + Convert.ToString(row["id_ensamble_union"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_ensamble SET  id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "',id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',no_guia='" + Convert.ToString(row["no_guia"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "'   WHERE id_ensamble_union='" + Convert.ToString(row["id_ensamble_union"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string id_agave_cocido_sobrante = Convert.ToString(row["id_agave_cocido_sobrante"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);

                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);

                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_ensamble_union + "','" + id_produccion_entrada + "','" + id_agave_sobrante + "','" + id_agave_cocido_sobrante + "','" + id_predio + "','" + id_planta + "','" + no_guia + "','" + no_pinas_agave + "','" + agave_kg + "','" + agave_coccion_kg + "','" + porcentaje_art + "','" + tipo + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores produccion entrada
        public Boolean BajaProduccionEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_entrada (id_produccion_entrada, id_proc_entr_sal, id_agave_sobrante, no_cliente, id_fabrica,id_maestro_mezcalero, id_predio, id_planta,id_comun,no_guia,gcrm,tapada, no_pinas_agave, agave_kg, agave_coccion_kg, id_coccion, periodo_coccion_inicio, periodo_coccion_fin, porcentaje_art, id_molienda, periodo_molienda_inicio, periodo_molienda_fin, periodo_formulacion_inicio, id_fermentacion, periodo_formulacion_fin, volumen_mosto, periodo_destilacion_inicio, id_destilacion, periodo_destilacion_fin, destilaciones_realizadas, lts_producidos, grado_alcoholico, lts_existentes, litros_puntas, grados_puntas, litros_colas, grados_colas,destilado_con,id_verificador, fecha, estatus, tipo, rendimiento,fecha_rendimiento, observaciones_rendimiento, id_verifico_rendimiento, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_produccion_entrada, id_proc_entr_sal, id_agave_sobrante, no_cliente, id_fabrica,id_maestro_mezcalero, id_predio, id_planta,id_comun,no_guia,gcrm,tapada, no_pinas_agave, agave_kg, agave_coccion_kg, id_coccion,  DATE_FORMAT(periodo_coccion_inicio,'%Y-%m-%d') as periodo_coccion_inicio,  DATE_FORMAT(periodo_coccion_fin,'%Y-%m-%d') as periodo_coccion_fin, porcentaje_art, id_molienda,DATE_FORMAT(periodo_molienda_inicio,'%Y-%m-%d') as periodo_molienda_inicio  , DATE_FORMAT(periodo_molienda_fin,'%Y-%m-%d') as periodo_molienda_fin ,  DATE_FORMAT(periodo_formulacion_inicio,'%Y-%m-%d') as periodo_formulacion_inicio, id_fermentacion,  DATE_FORMAT(periodo_formulacion_fin,'%Y-%m-%d') as periodo_formulacion_fin, volumen_mosto,  DATE_FORMAT(periodo_destilacion_inicio,'%Y-%m-%d') as periodo_destilacion_inicio, id_destilacion,  DATE_FORMAT(periodo_destilacion_fin,'%Y-%m-%d') as periodo_destilacion_fin, destilaciones_realizadas, lts_producidos, grado_alcoholico, lts_existentes, litros_puntas, grados_puntas, litros_colas, grados_colas,destilado_con,id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, estatus, tipo, rendimiento,DATE_FORMAT(fecha_rendimiento,'%Y-%m-%d') as fecha_rendimiento, observaciones_rendimiento, id_verifico_rendimiento, actualizado from rv_produccion_entrada ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_produccion_entrada from  produccion_entrada where id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_entrada SET id_proc_entr_sal= '" + Convert.ToString(row["id_proc_entr_sal"]) + "',id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "',id_maestro_mezcalero='" + Convert.ToString(row["id_maestro_mezcalero"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_guia='" + Convert.ToString(row["no_guia"]) + "',gcrm='" + Convert.ToString(row["gcrm"]) + "',tapada='" + Convert.ToString(row["tapada"]) + "',no_pinas_agave='" + Convert.ToString(row["no_pinas_agave"]) + "',agave_kg='" + Convert.ToString(row["agave_kg"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_coccion='" + Convert.ToString(row["id_coccion"]) + "',periodo_coccion_inicio='" + Convert.ToString(row["periodo_coccion_inicio"]) + "',periodo_coccion_fin='" + Convert.ToString(row["periodo_coccion_fin"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_molienda='" + Convert.ToString(row["id_molienda"]) + "',periodo_molienda_inicio='" + Convert.ToString(row["periodo_molienda_inicio"]) + "',periodo_molienda_fin='" + Convert.ToString(row["periodo_molienda_fin"]) + "',periodo_formulacion_inicio='" + Convert.ToString(row["periodo_formulacion_inicio"]) + "',id_fermentacion='" + Convert.ToString(row["id_fermentacion"]) + "',periodo_formulacion_fin='" + Convert.ToString(row["periodo_formulacion_fin"]) + "',volumen_mosto='" + Convert.ToString(row["volumen_mosto"]) + "',periodo_destilacion_inicio='" + Convert.ToString(row["periodo_destilacion_inicio"]) + "',id_destilacion='" + Convert.ToString(row["id_destilacion"]) + "',periodo_destilacion_fin='" + Convert.ToString(row["periodo_destilacion_fin"]) + "',destilaciones_realizadas='" + Convert.ToString(row["destilaciones_realizadas"]) + "',lts_producidos='" + Convert.ToString(row["lts_producidos"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',litros_puntas='" + Convert.ToString(row["litros_puntas"]) + "',grados_puntas='" + Convert.ToString(row["grados_puntas"]) + "',litros_colas='" + Convert.ToString(row["litros_colas"]) + "',grados_colas='" + Convert.ToString(row["grados_colas"]) + "',destilado_con='" + Convert.ToString(row["destilado_con"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',estatus='" + Convert.ToString(row["estatus"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',rendimiento='" + Convert.ToString(row["rendimiento"]) + "',fecha_rendimiento='" + Convert.ToString(row["fecha_rendimiento"]) + "',observaciones_rendimiento='" + Convert.ToString(row["observaciones_rendimiento"]) + "',id_verifico_rendimiento='" + Convert.ToString(row["id_verifico_rendimiento"]) + "'    WHERE id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_proc_entr_sal = Convert.ToString(row["id_proc_entr_sal"]);
                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string id_maestro_mezcalero = Convert.ToString(row["id_maestro_mezcalero"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        //Falta el row [] en el no_guia, asi como está toma ese valor por default como asignado a la variable y asi los mete a los campos
                        //deberia ser asi: string no_guia = Convert.ToString(row["no_guia"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string gcrm = Convert.ToString(row["gcrm"]);
                        string tapada = Convert.ToString(row["tapada"]);
                        string no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_coccion = Convert.ToString(row["id_coccion"]);
                        string periodo_coccion_inicio = Convert.ToString(row["periodo_coccion_inicio"]);
                        string periodo_coccion_fin = Convert.ToString(row["periodo_coccion_fin"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_molienda = Convert.ToString(row["id_molienda"]);
                        string periodo_molienda_inicio = Convert.ToString(row["periodo_molienda_inicio"]);
                        string periodo_molienda_fin = Convert.ToString(row["periodo_molienda_fin"]);
                        string periodo_formulacion_inicio = Convert.ToString(row["periodo_formulacion_inicio"]);
                        string id_fermentacion = Convert.ToString(row["id_fermentacion"]);
                        string periodo_formulacion_fin = Convert.ToString(row["periodo_formulacion_fin"]);
                        string volumen_mosto = Convert.ToString(row["volumen_mosto"]);
                        string periodo_destilacion_inicio = Convert.ToString(row["periodo_destilacion_inicio"]);
                        string id_destilacion = Convert.ToString(row["id_destilacion"]);
                        string periodo_destilacion_fin = Convert.ToString(row["periodo_destilacion_fin"]);
                        string destilaciones_realizadas = Convert.ToString(row["destilaciones_realizadas"]);
                        string lts_producidos = Convert.ToString(row["lts_producidos"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string litros_puntas = Convert.ToString(row["litros_puntas"]);
                        string grados_puntas = Convert.ToString(row["grados_puntas"]);
                        string litros_colas = Convert.ToString(row["litros_colas"]);
                        string grados_colas = Convert.ToString(row["grados_colas"]);
                        string destilado_con = Convert.ToString(row["destilado_con"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string estatus = Convert.ToString(row["estatus"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string rendimiento = Convert.ToString(row["rendimiento"]);
                        string fecha_rendimiento = Convert.ToString(row["fecha_rendimiento"]);
                        string observaciones_rendimiento = Convert.ToString(row["observaciones_rendimiento"]);
                        string id_verifico_rendimiento = Convert.ToString(row["id_verifico_rendimiento"]);


                        values += sep + "('" + id_produccion_entrada + "','" + id_proc_entr_sal + "','" + id_agave_sobrante + "','" + no_cliente + "','" + id_fabrica + "','" + id_maestro_mezcalero + "','" + id_predio + "','" + id_planta + "','" + id_comun + "','" + no_guia + "','" + gcrm + "','" + tapada + "','" + no_pinas_agave + "','" + agave_kg + "','" + agave_coccion_kg + "','" + id_coccion + "','" + periodo_coccion_inicio + "','" + periodo_coccion_fin + "','" + porcentaje_art + "','" + id_molienda + "','" + periodo_molienda_inicio + "','" + periodo_molienda_fin + "','" + periodo_formulacion_inicio + "','" + id_fermentacion + "','" + periodo_formulacion_fin + "','" + volumen_mosto + "','" + periodo_destilacion_inicio + "','" + id_destilacion + "','" + periodo_destilacion_fin + "','" + destilaciones_realizadas + "','" + lts_producidos + "','" + grado_alcoholico + "','" + lts_existentes + "','" + litros_puntas + "','" + grados_puntas + "','" + litros_colas + "','" + grados_colas + "','" + destilado_con + "','" + id_verificador + "','" + fecha + "','" + estatus + "','" + tipo + "','" + rendimiento + "','" + fecha_rendimiento + "','" + observaciones_rendimiento + "','" + id_verifico_rendimiento + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores produccion entrada
        public Boolean BajaProduccionPuntasColas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_puntas_colas (id_produccion_puntas_colas, no_cliente, tipo, litros, grado_alcoholico, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_produccion_puntas_colas, no_cliente, tipo, litros, grado_alcoholico, id_verificador, actualizado from rv_produccion_puntas_colas ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_produccion_puntas_colas from  produccion_puntas_colas where id_produccion_puntas_colas='" + Convert.ToString(row["id_produccion_puntas_colas"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_puntas_colas SET  no_cliente= '" + Convert.ToString(row["no_cliente"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "'   WHERE id_produccion_puntas_colas='" + Convert.ToString(row["id_produccion_puntas_colas"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_produccion_puntas_colas = Convert.ToString(row["id_produccion_puntas_colas"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_produccion_puntas_colas + "','" + no_cliente + "','" + tipo + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores produccion entrada
        public Boolean BajaProduccionSalida()
        {
            try
            {
                ConexionMysql.insUpd_transaccion("UPDATE su_ba SET Estado=1");// linea agregada para Actualizar el estado del log --2020
                string sep = "";
                string values = "";
                string sql = "INSERT INTO produccion_salida (id_produccion_salida, id_produccion_entrada, id_solicitud, id_granel_entrada, litros, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_produccion_salida, id_produccion_entrada, id_solicitud, id_granel_entrada, litros, id_verificador, actualizado from rv_produccion_salida ");

                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_produccion_salida from  produccion_salida where id_produccion_salida='" + Convert.ToString(row["id_produccion_salida"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE produccion_salida SET  id_produccion_entrada= '" + Convert.ToString(row["id_produccion_entrada"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "',litros='" + Convert.ToString(row["litros"]) + "'   WHERE id_produccion_salida='" + Convert.ToString(row["id_produccion_salida"]) + "' ") == "Error")
                                return false;
                        }
                      ConexionMysql.insUpd_transaccion("UPDATE su_ba SET Estado=1");// linea agregada para Actualizar el estado del log --2020
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_produccion_salida = Convert.ToString(row["id_produccion_salida"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string litros = Convert.ToString(row["litros"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_produccion_salida + "','" + id_produccion_entrada + "','" + id_solicitud + "','" + id_granel_entrada + "','" + litros + "','" + id_verificador + "',1)";
                        sep = ",";
                        ConexionMysql.insUpd_transaccion("UPDATE su_ba SET Estado=1");// linea agregada para Actualizar el estado del log --2020
                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //actualiza los valores envasado ensamble
        public Boolean BajaEnvasadoEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_ensamble (id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado from rv_envasado_ensamble ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_ensamble from  envasado_ensamble where id_envasado_ensamble='" + Convert.ToString(row["id_envasado_ensamble"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE envasado_ensamble SET  id_envasado_entrada= '" + Convert.ToString(row["id_envasado_entrada"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_lote_granel='" + Convert.ToString(row["no_lote_granel"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',litros='" + Convert.ToString(row["litros"]) + "' WHERE id_envasado_ensamble='" + Convert.ToString(row["id_envasado_ensamble"]) + "' ") == "Error")
                                return false;
                        }
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_ensamble = Convert.ToString(row["id_envasado_ensamble"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_envasado_ensamble + "','" + id_envasado_entrada + "','" + id_comun + "','" + no_lote_granel + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + agave_coccion_kg + "','" + id_verificador + "',1)";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //actualiza los valores envasado holopgramas
        public Boolean BajaEnvasadoHologramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sql = "INSERT INTO envasado_holograma (id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, actualizado, cliente_crm) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie,id_verificador, actualizado, cliente_crm from rv_envasado_holograma ");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysql.regresaCampoConsulta("select  id_envasado_holograma from  envasado_holograma where id_envasado_holograma='" + Convert.ToString(row["id_envasado_holograma"]) + "'");
                    if (id != "")
                    {
                        if (Convert.ToString(row["actualizado"]) == "0")
                        {
                            bandera_update = true;
                            if (ConexionMysql.insUpd_transaccion("UPDATE envasado_holograma SET  id_envasado_entrada= '" + Convert.ToString(row["id_envasado_entrada"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',cve_marca='" + Convert.ToString(row["cve_marca"]) + "',holograma_inicio='" + Convert.ToString(row["holograma_inicio"]) + "',holograma_fin='" + Convert.ToString(row["holograma_fin"]) + "',serie='" + Convert.ToString(row["serie"]) + "',cliente_crm='" + Convert.ToString(row["cliente_crm"]) + "'   WHERE id_envasado_holograma='" + Convert.ToString(row["id_envasado_holograma"]) + "' ") == "Error")
                                return false;
                        }

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_holograma = Convert.ToString(row["id_envasado_holograma"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cve_marca = Convert.ToString(row["cve_marca"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string serie = Convert.ToString(row["serie"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string cliente_crm = Convert.ToString(row["cliente_crm"]);

                        values += sep + "('" + id_envasado_holograma + "','" + id_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + holograma_inicio + "','" + holograma_fin + "','" + serie + "','" + id_verificador + "',1,'" + cliente_crm + "')";
                        sep = ",";

                    }
                }

                if (bandera_insert == false && bandera_update == true)
                {
                    ConexionMysql.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    sql += values + ";";
                    if (ConexionMysql.insUpd_transaccion(sql) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        // baja informacion
        public Boolean BajaDeInformacion()
        {
            try
            {
               ConexionMysql.insUpd_transaccion("UPDATE su_ba SET Estado=1");// linea agregada para Actualizar el estado del log para que pueda volver a subir  --2020
                if (ConexionMysqlRemota2.insUpd_transaccion("INSERT INTO rv_subida_bajada (id_verificador, tipo, fecha) VALUES(" + Usuario.IdUsuario + ",'Bajada de informacion',now()) ") == "Error")
                {
                    return false;
                }

                if (ConexionMysql.insUpd_transaccion("INSERT INTO subida_bajada (id_verificador, tipo, fecha) VALUES(" + Usuario.IdUsuario + ",'Bajada de informacion',now()) ") == "Error")
                {
                    return false;
                }
                
                ConexionMysqlRemota2.transCompleta();
                ConexionMysql.transCompleta();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion
        //--->>>>>-Fin baja informacion

        //----->>>-esta funcion es donde se trabaja la funcion en segundo plano
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Porcentajes del Progreso de descarga
            try
            {
                bandera = false;
                //reporta el progreso a una barra de carga 
                backgroundWorker.ReportProgress(0);

                ConexionMysql.conecta();//--ReVeCa
               // ConexionMysqlRemota.conecta();//--crmreg
                ConexionMysqlRemota2.conecta();//--siig

                //ConexionMysql.insUpd_transaccion("UPDATE fecha_ultima_descarga SET Fecha = now()");

                backgroundWorker.ReportProgress(1);


                if (BajaMensajesRegistros() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(2);

                if (BajaFqHistorial() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(3);


                if (BajaSalidaHolgramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker.ReportProgress(4);

                if (ActualizarNuevasGuiasDeExtraccion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(5);

                if (ActualizarEspecieTabla() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // TODO: SE MANDA A LLAMAR AL METODO DE DESCARGA DE LOS LOTES DE GRANEL DE FÁBRICA VERIFICADOS

                backgroundWorker.ReportProgress(6);

                if (BajaVerificacionGF() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                backgroundWorker.ReportProgress(7);

                if (ActualizarExistenciaPlantas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // TODO: SE MANDA A LLAMAR AL METODO DE DESCARGA DE LOS LOTES DE GRANEL DE ENVASADO VERIFICADOS

                backgroundWorker.ReportProgress(8);

                if (BajaVerificacionGE() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // TODO: SE MANDA A LLAMAR AL METODO DE DESCARGA DE LOS LOTES DE ENVASADO VERIFICADOS
                backgroundWorker.ReportProgress(9);

                if (BajaVerificacionEN() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker.ReportProgress(10);

                if (ActualizarParajes() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // ESTE HAY QUE DESHABILITAR
                //backgroundWorker.ReportProgress(11);

                /*if (ActualizarExistenciaPlantasAntiguas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                backgroundWorker.ReportProgress(12);

                if (ActualizaClientes() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /*backgroundWorker.ReportProgress(13);

                if (ActualizarNuevasGuiasDeExtraccionAntiguas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                backgroundWorker.ReportProgress(15);

                if (ActualizaVerificadores() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //backgroundWorker.ReportProgress(16);

                /* if (ActualizarParajesAntiguos() == false)
                 {
                     MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }*/


                backgroundWorker.ReportProgress(17);

                if (ActualizaMarcas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(18);

                if (ActualizaEstatusGuiasYExistenciaPlantas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // ESTE HAY QUE DESHABILITAR
                /*backgroundWorker.ReportProgress(19);

                if (ActualizaEstatusGuiasYExistenciaPlantasAntiguas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/


                backgroundWorker.ReportProgress(20);

                if (ActualizaCatPresentacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //manda a llamar al nuevo metodo que va a descargar la información de guias externas 2021
                backgroundWorker.ReportProgress(21);

                if (DescargaGuiasExternas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                backgroundWorker.ReportProgress(22);

                if (ActualizarEspecieDeMaguey() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(24);

                if (ActualizaAnios() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /*backgroundWorker.ReportProgress(25);

                if (ActualizaAniosAntiguos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                backgroundWorker.ReportProgress(26);

                if (ActualizaEdadesPlantas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // ESTE HAY QUE DESHABILITAR
                /*backgroundWorker.ReportProgress(27);

                if (ActualizaEdadesPlantasAntiguos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                backgroundWorker.ReportProgress(28);


               /* if (ActualizaTiposInstalacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(30);*/

                if (ActualizaInstalacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(32);

                if (ActualizaClientesInstalaciones() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(34);


                if (ActualizaEstados() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(35);

                if (ActualizaMunicipios() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker.ReportProgress(37);
                if (BajaEnvasadoEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker.ReportProgress(39);
                if (BajaEnvasadoHologramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                backgroundWorker.ReportProgress(42);
                if (BajaAlmacenEnvasadoEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(44);
                if (BajaAlmacenEnvasadoEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(46);
                if (BajaAlmacenEnvasadoMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(49);
                if (BajaAlmacenEncargado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(52);
                if (BajaAlmacenEnvasadoHologramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(54);
                if (BajaAlmacenGranelEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(58);
                if (BajaAlmacenGranelEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(60);
                if (BajaAlmacenGranelMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(61);
                if (BajaAlmacenGranelTanque() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(62);
                if (BajaAlmacenGranelSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(64);
                if (BajaMaestroMezcalero() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(66);
                if (BajaEnvasadoSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                /*backgroundWorker.ReportProgress(67);
                if (BajaExistenciaPlantaCompradaAntiguo() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                backgroundWorker.ReportProgress(68);
                if (BajaTransacciones() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                backgroundWorker.ReportProgress(69);
                if (BajaIdsProduccion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker.ReportProgress(70);
                if (ActualizaLocalidades() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(71);

                if (ActualizaRelacionCpEstado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               /* backgroundWorker.ReportProgress(72);


                if (ActualizaRutaVerificador() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                backgroundWorker.ReportProgress(73);

                if (ActualizaCatMolienda() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               /* backgroundWorker.ReportProgress(74);

                if (ActualizaRutaClientes() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                /*backgroundWorker.ReportProgress(75);


                if (ActualizaRutaZona() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
                backgroundWorker.ReportProgress(76);

                if (ActualizaCatCoccion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(77);


                if (ActualizaCatFermentacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(78);


                if (ActualizaCatDestilacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(79);

                if (BajaEnvasadoEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(80);
                if (BajaEnvasadoMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(81);
                if (BajaEnvasadoEncargado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(82);
                if (BajaExistenciaPlantaComprada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(83);
                if (BajaGranelEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(84);
                if (BajaGranelEnsambleEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(85);
                if (BajaGranelEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(86);
                if (BajaGranelEntradaEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(87);
                if (BajaGranelMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(88);

                if (BajaGranelMovimientosEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(89);
                if (BajaGranelSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(90);
                if (BajaGranelTanque() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(91);
                if (BajaGranelTanqueEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(92);
                if (BajaMaestroFabrica() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(93);
                if (BajaAgaveCocidoSobrante() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(94);
                if (BajaAgaveSobrante() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(95);
                if (BajaProduccionEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(96);
                if (BajaProduccionEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(97);
                if (BajaProduccionPuntasColas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker.ReportProgress(98);
                if (BajaProduccionSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker.ReportProgress(99);
                if (BajaDeInformacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker.ReportProgress(100);

                bandera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }
        //----->>>-Fin de esta funcion donde se trabaja la funcion en segundo plano

        //esta funcion es cuando termina todo el trabajo de la funcion en segundo plano 
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region
            if (bandera == true)
            {
                MessageBox.Show("Base de datos actualizada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Lblcargandobase.Visible = false;
                Progresbar.Visible = false;
                carga.Visible = false;
            }
            else
            {
                Lblcargandobase.Visible = false;
                Progresbar.Visible = false;
                carga.Visible = false;
            }
            ConexionMysql.cierraConexion();
            //ConexionMysqlRemota.cierraConexion();
            ConexionMysqlRemota2.cierraConexion();
            #endregion
        }

        //esta funcion sirve cuando tiene una barra de carga, va marcando el avance de lo que se esta haciendo
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progresbar.Value = e.ProgressPercentage;
        }


        private void BtnPlanDeTrabajo_Click(object sender, EventArgs e)
        {
            #region
            pictureBox2.Visible = false;
            FrmPlanDeTrabajo FrmPlanTrabajo = new FrmPlanDeTrabajo();
            //FrmPlanTrabajo.ShowDialog();

            Abrirhija(new FrmPlanDeTrabajo());
            #endregion
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            /*FrmInventario Frm = new FrmInventario();
            Frm.ShowDialog();*/

            Abrirhija(new FrmInventario());
        }



        /////////////////////////////////////////////////////////////////////////////////|--<<subida de informacion>>--| ////////////////////////////////////////////////////////////////////////////////////////////
        
            #region Metodos subida de información por veris


        public Boolean SubidaMensajesRegistro()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_mensajes_registros (id_mensaje, id_registro, tipo, mensaje, fecha, id_verificador, actualizado, fecha_subio) VALUES";
                string update = "UPDATE mensajes_registros SET actualizado=1 WHERE id_mensaje IN( ";

                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_mensaje, id_registro, tipo, mensaje,  DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_verificador from mensajes_registros WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id_mensaje = Convert.ToString(row["id_mensaje"]);
                    string id_registro = Convert.ToString(row["id_registro"]);
                    string tipo = Convert.ToString(row["tipo"]);
                    string mensaje = Convert.ToString(row["mensaje"]);
                    string fecha = Convert.ToString(row["fecha"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_mensaje + "','" + id_registro + "','" + tipo + "','" + mensaje + "','" + fecha + "','" + id_verificador + "',1,now())";
                    sep = ",";

                    values_update += sep_update + "'" + id_mensaje + "'";
                    sep_update = ",";
                }

                sql += values + ";";
                update += values_update + ");";
                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        public Boolean SubidaFqHistorial()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_fq_historial (id_fq, id_produccion, tipo, fq, litros, grado_alcoholico, observacion, id_verificador, actualizado, fecha, fecha_subio) VALUES";
                string update = "UPDATE fq_historial SET actualizado=1 WHERE id_fq IN( ";

                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_fq, id_produccion, tipo, fq, litros, grado_alcoholico, observacion, id_verificador,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha from fq_historial WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id_fq = Convert.ToString(row["id_fq"]);
                    string id_produccion = Convert.ToString(row["id_produccion"]);
                    string tipo = Convert.ToString(row["tipo"]);
                    string fq = Convert.ToString(row["fq"]);
                    string litros = Convert.ToString(row["litros"]);
                    string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                    string observacion = Convert.ToString(row["observacion"]);
                    string fecha = Convert.ToString(row["fecha"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_fq + "','" + id_produccion + "','" + tipo + "','" + fq + "','" + litros + "','" + grado_alcoholico + "','" + observacion + "','" + id_verificador + "',1,'" + fecha + "',now())";
                    sep = ",";

                    values_update += sep_update + "'" + id_fq + "'";
                    sep_update = ",";
                }

                sql += values + ";";
                update += values_update + ");";
                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        //TODO: SUBIR LOS LOTES VERIFICADOS EN GRANEL DE FÁBRICA
        public Boolean SubidaVerificacionGF()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_checked_lotes_gf (id_checked_lotegf, id_pkGF, id_granel_entrada, no_cliente, id_fabrica, " +
                    "no_lote, fecha_ultima_verificacion, checked, verificador_id, actualizado,fecha_subio) VALUES";
                string update = "UPDATE checked_lotes_gf SET actualizado=1 WHERE id_checked_lotegf IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datosLocal = new DataSet();
                ConexionMysql.llenaDataset(ref datosLocal, "SELECT id_checked_lotegf,id_pkGF,id_granel_entrada,no_cliente," +
                    "id_fabrica,no_lote,DATE_FORMAT(fecha_ultima_verificacion, '%Y-%m-%d') AS fecha_ultima_verificacion,checked," +
                    "verificador_id,actualizado FROM checked_lotes_gf WHERE actualizado = 0");
                if (datosLocal.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datosLocal.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_checked_lotegf from rv_checked_lotes_gf where id_checked_lotegf='" + Convert.ToString(row["id_checked_lotegf"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_checked_lotegf"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_checked_lotes_gf SET  id_checked_lotegf= '" + Convert.ToString(row["id_checked_lotegf"]) + "'," +
                                "id_pkGF='" + Convert.ToString(row["id_pkGF"]) + "',id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'," +
                                "no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "'," +
                                "no_lote='" + Convert.ToString(row["no_lote"]) + "',fecha_ultima_verificacion='" + Convert.ToString(row["fecha_ultima_verificacion"]) + "'," +
                                "checked='" + Convert.ToString(row["checked"]) + "',verificador_id='" + Convert.ToString(row["verificador_id"]) + "',actualizado=0   WHERE id_checked_lotegf='" + Convert.ToString(row["id_checked_lotegf"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;

                        string id_checked_lotegf = Convert.ToString(row["id_checked_lotegf"]);
                        string id_pkGF = Convert.ToString(row["id_pkGF"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string fecha_ultima_verificacion = Convert.ToString(row["fecha_ultima_verificacion"]);
                        string checkeado = Convert.ToString(row["checked"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);


                        values += sep + "('" + id_checked_lotegf + "','" + id_pkGF + "','" + id_granel_entrada + "','" + no_cliente + "','" + id_fabrica + "','" + no_lote + "','" + fecha_ultima_verificacion + "','" + checkeado + "','" + verificador_id + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_checked_lotegf + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //TODO: METODO QUE SUBE LA INFO DE LOTES CHEKEADOS POR LOS VERIS EN GRANEL DE ENVASADO
        public Boolean SubidaVerificacionGE()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_checked_lotes_ge(id_checked_lotege,id_pkGE,id_granel_entrada_envasado,no_cliente,id_envasadora,no_lote," +
                                "fecha_ultima_verificacion,checked,verificador_id,actualizado,fecha_subio) VALUES";
                string update = "UPDATE checked_lotes_ge SET actualizado=1 WHERE id_checked_lotege IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datosLocal = new DataSet();
                ConexionMysql.llenaDataset(ref datosLocal, "SELECT id_checked_lotege, id_pkGE, id_granel_entrada_envasado, no_cliente, id_envasadora, no_lote," +
                                                           "date_format(fecha_ultima_verificacion, '%Y-%m-%d') AS fecha_ultima_verificacion, checked, verificador_id, " +
                                                           "actualizado FROM checked_lotes_ge WHERE actualizado = 0");
                if (datosLocal.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datosLocal.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_checked_lotege from rv_checked_lotes_ge where id_checked_lotege='" + Convert.ToString(row["id_checked_lotege"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_checked_lotege"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_checked_lotes_ge SET id_checked_lotege= '" + Convert.ToString(row["id_checked_lotege"]) + "'," +
                                "id_pkGE='" + Convert.ToString(row["id_pkGE"]) + "',id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "'," +
                                "no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "'," +
                                "no_lote='" + Convert.ToString(row["no_lote"]) + "',fecha_ultima_verificacion='" + Convert.ToString(row["fecha_ultima_verificacion"]) + "'," +
                                "checked='" + Convert.ToString(row["checked"]) + "',verificador_id='" + Convert.ToString(row["verificador_id"]) + "',actualizado=0   WHERE id_checked_lotege='" + Convert.ToString(row["id_checked_lotege"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;

                        string id_checked_lotege = Convert.ToString(row["id_checked_lotege"]);
                        string id_pkGE = Convert.ToString(row["id_pkGE"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string fecha_ultima_verificacion = Convert.ToString(row["fecha_ultima_verificacion"]);
                        string checkeado = Convert.ToString(row["checked"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);


                        values += sep + "('" + id_checked_lotege + "','" + id_pkGE + "','" + id_granel_entrada_envasado + "','" + no_cliente + "','" + id_envasadora + "','" + no_lote + "','" + fecha_ultima_verificacion + "','" + checkeado + "','" + verificador_id + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_checked_lotege + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        // TODO: METODO QUE SUBE LA INFO DE LOTES CHEKEADOS POR LOS VERIS EN ENVASADO
        public Boolean SubidaVerificacionEN()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_checked_lotes_en(id_checked_loteEN,id_pkEN,id_envasado_entrada,no_cliente,marca,id_marca,id_envasadora,no_lote," +
                                "fecha_ultima_verificacion,checked,verificador_id,actualizado,fecha_subio) VALUES";
                string update = "UPDATE checked_lotes_en SET actualizado=1 WHERE id_checked_loteEN IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datosLocal = new DataSet();
                ConexionMysql.llenaDataset(ref datosLocal, "SELECT id_checked_loteEN,id_pkEN,id_envasado_entrada,no_cliente,marca,id_marca,id_envasadora,no_lote," +
                                                           "date_format(fecha_ultima_verificacion, '%Y-%m-%d') AS fecha_ultima_verificacion, checked, verificador_id, " +
                                                           "actualizado FROM checked_lotes_en WHERE actualizado = 0");
                if (datosLocal.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datosLocal.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_checked_loteEN from rv_checked_lotes_en where id_checked_loteEN='" + Convert.ToString(row["id_checked_loteEN"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_checked_loteEN"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_checked_lotes_en SET id_checked_loteEN= '" + Convert.ToString(row["id_checked_loteEN"]) + "'," +
                                "id_pkEN='" + Convert.ToString(row["id_pkEN"]) + "',id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "'," +
                                "no_cliente='" + Convert.ToString(row["no_cliente"]) + "',marca='" + Convert.ToString(row["marca"]) + "',id_marca='" + Convert.ToString(row["id_marca"]) + "',id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "'," +
                                "no_lote='" + Convert.ToString(row["no_lote"]) + "',fecha_ultima_verificacion='" + Convert.ToString(row["fecha_ultima_verificacion"]) + "'," +
                                "checked='" + Convert.ToString(row["checked"]) + "',verificador_id='" + Convert.ToString(row["verificador_id"]) + "',actualizado=0 WHERE id_checked_loteEN='" + Convert.ToString(row["id_checked_loteEN"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;

                        string id_checked_loteEN = Convert.ToString(row["id_checked_loteEN"]);
                        string id_pkEN = Convert.ToString(row["id_pkEN"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string marca = Convert.ToString(row["marca"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string fecha_ultima_verificacion = Convert.ToString(row["fecha_ultima_verificacion"]);
                        string checkeado = Convert.ToString(row["checked"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);

                        values += sep + "('" + id_checked_loteEN + "','" + id_pkEN + "','" + id_envasado_entrada + "','" + no_cliente + "','" + marca + "','" + id_marca + "','" + id_envasadora + "','" + no_lote + "','" + fecha_ultima_verificacion + "','" + checkeado + "','" + verificador_id + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_checked_loteEN + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //METODO QUE VA A SUBIR LOS DATOS DE LAS TAPADAS QUE SE GUARDAN CON GUIA EXTERNA

        public Boolean SubidaGuiaExternas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_guias_externas(id_guia_desconocida,id_produccion_entrada,no_guia,predio,fecha_ingreso,verificador_id,fecha_subio,actualizado) VALUES";
                string update = "UPDATE guias_desconocidas SET actualizado=1 WHERE id_guia_desconocida IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datosLocal = new DataSet();
                ConexionMysql.llenaDataset(ref datosLocal, "SELECT id_guia_desconocida, id_produccion_entrada, no_guia, predio, date_format(fecha_ingreso, '%Y-%m-%d') AS fecha_ingreso, verificador_id, actualizado FROM guias_desconocidas WHERE actualizado = 0");
                if (datosLocal.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datosLocal.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("SELECT id_guia_desconocida from rv_guias_externas where id_guia_desconocida='" + Convert.ToString(row["id_guia_desconocida"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_guia_desconocida"]) + "'";
                        sep_update = ",";

                        
                        
                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_guias_externas SET id_produccion_entrada= '"+ Convert.ToString(row["id_produccion_entrada"]) + "',no_guia='" + Convert.ToString(row["no_guia"]) + "'," +
                                "predio='" + Convert.ToString(row["predio"]) + "',fecha_ingreso='" + Convert.ToString(row["fecha_ingreso"]) + "',verificador_id='" + Convert.ToString(row["verificador_id"]) + "',actualizado=0 WHERE id_guia_desconocida='" + Convert.ToString(row["id_guia_desconocida"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;

                        string id_guia_desconocida = Convert.ToString(row["id_guia_desconocida"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string predio = Convert.ToString(row["predio"]);
                        string fecha_ingreso = Convert.ToString(row["fecha_ingreso"]);
                        string verificador_id = Convert.ToString(row["verificador_id"]);
                        

                        values += sep + "('" + id_guia_desconocida + "','" + id_produccion_entrada + "','" + no_guia + "','" + predio + "','" + fecha_ingreso + "','" + verificador_id + "',now(),1)";
                        sep = ",";

                        values_update += sep_update + "'" + id_guia_desconocida + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //sube la tabla transacciones
        public Boolean SubidaTransacciones()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_transacciones (id_transaccion, id_granel_entrada, id_granel_entrada_recibe, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe, id_envasado_entrada, id_envasado_entrada_recibe, no_traslado, id_verificador, actualizado, tipo_transaccion,fecha_subio) VALUES";
                string update = "UPDATE transacciones SET actualizado=1 WHERE id_transaccion IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                /// ===== selecciona los datos que tienen actualizado 0 en la base local
                ConexionMysql.llenaDataset(ref datos, "SELECT id_transaccion, id_granel_entrada, id_granel_entrada_recibe, id_granel_entrada_envasado, id_granel_entrada_envasado_recibe, id_envasado_entrada, id_envasado_entrada_recibe, no_traslado, id_verificador,tipo_transaccion from transacciones WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    // ==== selecciona los id que coinsidan con el de la base de datos del siig ===--
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_transaccion from  rv_transacciones where id_transaccion='" + Convert.ToString(row["id_transaccion"]) + "'");
                    /// === -- si hay id que coinsidan entra al if y ejecuta la actualizacion del registro
                    if (id != "")
                    {
                        // ---- activa la bandera de actualizacion..-- 
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_transaccion"]) + "'";
                        sep_update = ",";
                    }
                    else
                    {
                        ///---- si no en cuentra coincidencia realiza el insert del id 
                        bandera_insert = true;
                        string id_transaccion = Convert.ToString(row["id_transaccion"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_recibe = Convert.ToString(row["id_granel_entrada_recibe"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_envasado_recibe = Convert.ToString(row["id_granel_entrada_envasado_recibe"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_envasado_entrada_recibe = Convert.ToString(row["id_envasado_entrada_recibe"]);
                        string no_traslado = Convert.ToString(row["no_traslado"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_transaccion = Convert.ToString(row["tipo_transaccion"]);

                        values += sep + "('" + id_transaccion + "','" + id_granel_entrada + "','" + id_granel_entrada_recibe + "','" + id_granel_entrada_envasado + "','" + id_granel_entrada_envasado_recibe + "','" + id_envasado_entrada + "','" + id_envasado_entrada_recibe + "','" + no_traslado + "','" + id_verificador + "',1,'" + tipo_transaccion + "', now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_transaccion + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean SubidaExtraccionesPlantasGuiasAntiguas()
        {
            try
            {
                //ConexionMysqlRemota2.conecta();
                DataSet RetiroPlantasPendientes = new DataSet();
                /// -- selecciona las extracciones que realizo el verificador con estado actualizado = 0 en la base de datos local
                //string userAnterior = ConexionMysql.regresaCampoConsulta("SELECT us_antiguo FROM verificadores where id_us = " + Usuario.IdUsuario + "");
                ConexionMysql.llenaDataset(ref RetiroPlantasPendientes, "SELECT * FROM reveca2_retiro_plantas_pendientes  WHERE actualizado=0");
                //and id_verificador = " + Usuario.IdUsuario + "
                if (RetiroPlantasPendientes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in RetiroPlantasPendientes.Tables[0].Rows)
                {
                    string extraccion = Convert.ToString(row["extraccion"]);
                    string id_planta = Convert.ToString(row["id_plantas"]);
                    string no_guia = Convert.ToString(row["no_guia"]);
                    string no_cliente_envia = Convert.ToString(row["no_cliente_envia"]);
                    string no_cliente_recibe = Convert.ToString(row["no_cliente_recibe"]);
                    string direccion_cliente_recibe = Convert.ToString(row["direccion_cliente_recibe"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);
                    DateTime fecha = Convert.ToDateTime(Convert.ToString(row["fecha"]));

                    ///-- actualiza la extraccion en la tabla existenciaplanta en la base de datos crmreg
                    if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE  crm_existenciaplanta SET existenciaplantas=existenciaplantas-" + extraccion + "  WHERE id_plantas =" + id_planta + "") == "Error")
                        return false;

                    ///-- ingresa en la tabla de historial extracciones los datos de acuerdo a los movimientos que realizo el verificador
                    if (ConexionMysqlRemota2.insUpd_transaccion("INSERT INTO crm_historial_extraccion_verificadores (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,direccion_cliente_recibe,fecha_subio,fecha_realizo,id_verificador) VALUES( '" + no_guia + "'," + id_planta + ",'" + no_cliente_envia + "','" + no_cliente_recibe + "'," + extraccion + ",'" + direccion_cliente_recibe + "',now(),'" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Usuario.IdUsuario + ")") == "Error")
                        return false;

                    ///-- cambia el estado de actualizado para que sea 1
                    ///and id_verificador=" + Usuario.IdUsuario + "
                    if (ConexionMysql.insUpd_transaccion("UPDATE  reveca2_retiro_plantas_pendientes SET actualizado=1  WHERE id_plantas =" + id_planta + "") == "Error")
                        return false;
                }
                ConexionMysql.transCompleta();
                ConexionMysqlRemota2.transCompleta();
                //ConexionMysqlRemota.cierraConexion();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        public Boolean SubidaExtraccionesPlantasGuias()
        {
            try
            {
                //ConexionMysqlRemota2.conecta();
                DataSet RetiroPlantasPendientes = new DataSet();
                /// -- selecciona las extracciones que realizo el verificador con estado actualizado = 0 en la base de datos local
                ConexionMysql.llenaDataset(ref RetiroPlantasPendientes, "SELECT * FROM retiro_plantas_pendientes  WHERE actualizado=0 and id_verificador=" + Usuario.IdUsuario + "");
                if (RetiroPlantasPendientes.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in RetiroPlantasPendientes.Tables[0].Rows)
                {
                    string extraccion = Convert.ToString(row["extraccion"]);
                    string id_planta = Convert.ToString(row["id_plantas"]);
                    string no_guia = Convert.ToString(row["no_guia"]);
                    string no_cliente_envia = Convert.ToString(row["no_cliente_envia"]);
                    string no_cliente_recibe = Convert.ToString(row["no_cliente_recibe"]);
                    string direccion_cliente_recibe = Convert.ToString(row["direccion_cliente_recibe"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);
                    DateTime fecha = Convert.ToDateTime(Convert.ToString(row["fecha"]));

                    ///-- actualiza la extraccion en la tabla existenciaplanta en la base de datos crmreg
                    if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE  existenciaplanta SET existenciaplantas=existenciaplantas-" + extraccion + "  WHERE id_plantas =" + id_planta + "") == "Error")
                        return false;

                    ///-- ingresa en la tabla de historial extracciones los datos de acuerdo a los movimientos que realizo el verificador
                    if (ConexionMysqlRemota2.insUpd_transaccion("INSERT INTO historial_extraccion_verificadores (no_guia,id_plantas,no_cliente_envia,no_cliente_recibe,extraccion,direccion_cliente_recibe,fecha_subio,fecha_realizo,id_verificador) VALUES( '" + no_guia + "'," + id_planta + ",'" + no_cliente_envia + "','" + no_cliente_recibe + "'," + extraccion + ",'" + direccion_cliente_recibe + "',now(),'" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Usuario.IdUsuario + ")") == "Error")
                        return false;

                    ///-- cambia el estado de actualizado para que sea 1
                    if (ConexionMysql.insUpd_transaccion("UPDATE  retiro_plantas_pendientes SET actualizado=1  WHERE id_plantas =" + id_planta + " and id_verificador=" + Usuario.IdUsuario + "") == "Error")
                        return false;
                }
                ConexionMysql.transCompleta();
                ConexionMysqlRemota2.transCompleta();
                //ConexionMysqlRemota.cierraConexion();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //sube la tabla envasado ensamble
        public Boolean SubidaEnvasadoEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_envasado_ensamble (id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE envasado_ensamble SET actualizado=1 WHERE id_envasado_ensamble IN( ";

                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_envasado_ensamble, id_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador from envasado_ensamble WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id_envasado_ensamble = Convert.ToString(row["id_envasado_ensamble"]);
                    string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                    string id_comun = Convert.ToString(row["id_comun"]);
                    string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                    string id_planta = Convert.ToString(row["id_planta"]);
                    string id_predio = Convert.ToString(row["id_predio"]);
                    string litros = Convert.ToString(row["litros"]);
                    string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_envasado_ensamble + "','" + id_envasado_entrada + "','" + id_comun + "','" + no_lote_granel + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + agave_coccion_kg + "','" + id_verificador + "',1,now())";
                    sep = ",";

                    values_update += sep_update + "'" + id_envasado_ensamble + "'";
                    sep_update = ",";


                }

                sql += values + ";";
                update += values_update + ");";
                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla envasado entrada
        public Boolean SubidaEnvasadoEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_envasado_entrada (id_envasado_entrada,id_envasado_entrada_salio, id_marca, no_cliente, id_envasadora,tipo_destino,fecha_movimiento,fecha,fecha_envasado,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,verificador_termina,tipo_ingreso,actualizado,fecha_subio) VALUES";
                string update = "UPDATE envasado_entrada SET actualizado=1 WHERE id_envasado_entrada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_envasado_entrada,id_envasado_entrada_salio,id_marca, no_cliente, id_envasadora,tipo_destino,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado_ini,'%Y-%m-%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin,'%Y-%m-%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,verificador_termina,tipo_ingreso from envasado_entrada WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_envasado_entrada from  rv_envasado_entrada where id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_envasado_entrada"]) + "'";
                        sep_update = ",";



                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_envasado_entrada SET  id_marca='" + Convert.ToString(row["id_marca"]) + "',fq='" + Convert.ToString(row["fq"]) + "',tipo_destino='" + Convert.ToString(row["tipo_destino"]) + "', fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',etiquetado_como='" + Convert.ToString(row["etiquetado_como"]) + "',litros='" + Convert.ToString(row["litros"]) + "',botellas_iniciales='" + Convert.ToString(row["botellas_iniciales"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',verificador_termina='"+ Convert.ToString(row["verificador_termina"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',actualizado=0 WHERE id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_envasado_entrada_salio = Convert.ToString(row["id_envasado_entrada_salio"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string tipo_destino = Convert.ToString(row["tipo_destino"]);// se agrega 2021
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]); //--se agrego
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_envasado_ini = Convert.ToString(row["fecha_envasado_ini"]);
                        string fecha_envasado_fin = Convert.ToString(row["fecha_envasado_fin"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string etiquetado_como = Convert.ToString(row["etiquetado_como"]);
                        string unidad_medida = Convert.ToString(row["unidad_medida"]);
                        string contenido_por_botella = Convert.ToString(row["contenido_por_botella"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string grado_alcoholico_etiqueta = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        string botellas_iniciales = Convert.ToString(row["botellas_iniciales"]);//-- se agrego al igual que a los insert 
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string verificador_termina = Convert.ToString(row["verificador_termina"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);

                        values += sep + "('" + id_envasado_entrada + "','" + id_envasado_entrada_salio + "','" + id_marca + "','" + no_cliente + "','" + id_envasadora + "','" + tipo_destino + "','" + fecha_movimiento + "','" + fecha + "','" + fecha_envasado_ini + "','" + fecha_envasado_fin + "','" + id_comun + "','" + no_lote_granel + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + etiquetado_como + "','" + unidad_medida + "','" + contenido_por_botella + "','" + litros + "','" + grado_alcoholico + "','" + grado_alcoholico_etiqueta + "','" + botellas_iniciales + "','" + botellas + "','" + botellas_existentes + "','" + holograma_inicio + "','" + holograma_fin + "','" + id_verificador + "','"+ verificador_termina + "','" + tipo_ingreso + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_envasado_entrada + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//-- fin Suvidaenvasado

        //sube la tabla envasado Movimientos
        public Boolean SubidaEnvasadoMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_envasado_movimientos (id_envasado_movimientos, id_envasado_entrada, id_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, fecha, id_verificador, actualizado, observaciones,fecha_subio) VALUES";
                string update = "UPDATE envasado_movimientos SET actualizado=1 WHERE id_envasado_movimientos IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_envasado_movimientos, id_envasado_entrada, id_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, id_verificador, observaciones from envasado_movimientos WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_envasado_movimientos from  rv_envasado_movimientos where id_envasado_movimientos='" + Convert.ToString(row["id_envasado_movimientos"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_envasado_movimientos"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_envasado_movimientos SET  tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',cajas='" + Convert.ToString(row["cajas"]) + "',botellas_por_cajas='" + Convert.ToString(row["botellas_por_cajas"]) + "',actualizado=0 WHERE id_envasado_movimientos='" + Convert.ToString(row["id_envasado_movimientos"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasado_movimientos = Convert.ToString(row["id_envasado_movimientos"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_env_mov_salio = Convert.ToString(row["id_env_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string destino = Convert.ToString(row["destino"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string cajas = Convert.ToString(row["cajas"]);
                        string botellas_por_cajas = Convert.ToString(row["botellas_por_cajas"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        values += sep + "('" + id_envasado_movimientos + "','" + id_envasado_entrada + "','" + id_env_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + botellas + "','" + botellas_existentes + "','" + cajas + "','" + botellas_por_cajas + "','" + fecha + "','" + id_verificador + "',1,'" + observaciones + "',now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_envasado_movimientos + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla envasado encargado
        public Boolean SubidaEnvasadoEncargado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_envasadora_encargado (id_envasadora, no_cliente, envasadora, encargado,estado, municipio,localidad,envasadora_externa,id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE envasadora_encargado SET actualizado=1 WHERE id_envasadora IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_envasadora, no_cliente, envasadora, encargado,estado,municipio,localidad,envasadora_externa, id_verificador, actualizado from envasadora_encargado WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_envasadora from  rv_envasadora_encargado where id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_envasadora"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_envasadora_encargado SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',envasadora='" + Convert.ToString(row["envasadora"]) + "',encargado='" + Convert.ToString(row["encargado"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "',envasadora_externa='" + Convert.ToString(row["envasadora_externa"]) + "'  WHERE id_envasadora='" + Convert.ToString(row["id_envasadora"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string envasadora = Convert.ToString(row["envasadora"]);
                        string encargado = Convert.ToString(row["encargado"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string envasadora_externa = Convert.ToString(row["envasadora_externa"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_envasadora + "','" + no_cliente + "','" + envasadora + "','" + encargado + "','" + estado + "','" + municipio + "','" + localidad + "','" + envasadora_externa + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_envasadora + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla existenciaplanta_comprada
        public Boolean SubidaExistenciaPlantaComprada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_existenciaplanta_comprada (id_existenciaplanta_comprada,no_guia,id_planta, no_cliente, cantidadini, existenciaplantas,id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE existenciaplanta_comprada SET actualizado=1 WHERE id_existenciaplanta_comprada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_existenciaplanta_comprada,no_guia,id_planta, no_cliente, cantidadini, existenciaplantas,id_verificador, actualizado from existenciaplanta_comprada WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_existenciaplanta_comprada from  rv_existenciaplanta_comprada where id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_existenciaplanta_comprada SET  no_guia='" + Convert.ToString(row["no_guia"]) + "', existenciaplantas='" + Convert.ToString(row["existenciaplantas"]) + "' WHERE id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_existenciaplanta_comprada = Convert.ToString(row["id_existenciaplanta_comprada"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_existenciaplanta_comprada + "','" + no_guia + "','" + id_planta + "','" + no_cliente + "','" + cantidadini + "','" + existenciaplantas + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_existenciaplanta_comprada + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public Boolean SubidaExistenciaPlantaCompradaAntiguo()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO crm_existenciaplanta_comprada (id_existenciaplanta_comprada,no_guia,id_planta, no_cliente, cantidadini, existenciaplantas,id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE reveca2_existenciaplanta_comprada SET actualizado=1 WHERE id_existenciaplanta_comprada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_existenciaplanta_comprada,no_guia,id_planta, no_cliente, cantidadini, existenciaplantas,id_verificador, actualizado from reveca2_existenciaplanta_comprada WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_existenciaplanta_comprada from  crm_existenciaplanta_comprada where id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE crm_existenciaplanta_comprada SET  no_guia='" + Convert.ToString(row["no_guia"]) + "', existenciaplantas='" + Convert.ToString(row["existenciaplantas"]) + "' WHERE id_existenciaplanta_comprada='" + Convert.ToString(row["id_existenciaplanta_comprada"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_existenciaplanta_comprada = Convert.ToString(row["id_existenciaplanta_comprada"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string cantidadini = Convert.ToString(row["cantidadini"]);
                        string existenciaplantas = Convert.ToString(row["existenciaplantas"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_existenciaplanta_comprada + "','" + no_guia + "','" + id_planta + "','" + no_cliente + "','" + cantidadini + "','" + existenciaplantas + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_existenciaplanta_comprada + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla folios
        public Boolean SubidaFolios()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_folios ( id_folio,folio, actualizado,fecha_subio) VALUES";
                string update = "UPDATE folios SET actualizado=1 WHERE id_folio IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_folio,folio, actualizado from folios WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id_folio = Convert.ToString(row["id_folio"]);
                    string folio = Convert.ToString(row["folio"]);

                    values += sep + "('" + id_folio + "','" + folio + "',1,now())";
                    sep = ",";

                    values_update += sep_update + "'" + id_folio + "'";
                    sep_update = ",";
                }
                sql += values + ";";
                update += values_update + ");";

                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla granel ensamble
        public Boolean SubidaGranelEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_granel_ensamble (id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_ensamble SET actualizado=1 WHERE id_granel_ensamble IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_granel_ensamble, id_granel_entrada, id_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from granel_ensamble WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id_granel_ensamble = Convert.ToString(row["id_granel_ensamble"]);
                    string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                    string id_granel_entrada_salio = Convert.ToString(row["id_granel_entrada_salio"]);
                    string id_comun = Convert.ToString(row["id_comun"]);
                    string id_planta = Convert.ToString(row["id_planta"]);
                    string id_predio = Convert.ToString(row["id_predio"]);
                    string litros = Convert.ToString(row["litros"]);
                    string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                    string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_granel_ensamble + "','" + id_granel_entrada + "','" + id_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1,now())";
                    sep = ",";

                    values_update += sep_update + "'" + id_granel_ensamble + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla granel ensamble envasado
        public Boolean SubidaGranelEnsambleEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_granel_ensamble_envasado (id_granel_ensamble, id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_ensamble_envasado SET actualizado=1 WHERE id_granel_ensamble IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_granel_ensamble, id_granel_entrada_envasado, id_granel_entrada_envasado_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from granel_ensamble_envasado WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;

                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id_granel_ensamble = Convert.ToString(row["id_granel_ensamble"]);
                    string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                    string id_granel_entrada_salio = Convert.ToString(row["id_granel_entrada_envasado_salio"]);
                    string id_comun = Convert.ToString(row["id_comun"]);
                    string id_planta = Convert.ToString(row["id_planta"]);
                    string id_predio = Convert.ToString(row["id_predio"]);
                    string litros = Convert.ToString(row["litros"]);
                    string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                    string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_granel_ensamble + "','" + id_granel_entrada + "','" + id_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1,now())";
                    sep = ",";
                    values_update += sep_update + "'" + id_granel_ensamble + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla granel_entrada
        public Boolean SubidaGranelEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_granel_entrada (id_granel_entrada, id_lote_reveca, no_cliente, id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_entrada SET actualizado=1 WHERE id_granel_entrada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_granel_entrada, id_lote_reveca, no_cliente, id_fabrica,  DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey, actualizado from granel_entrada WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    /* @adnto en el foreach recorre los resultados de todos aquellos registros de la tabla local granel_entrada
                     * que el campo actualizado tenga=0 en cada iteración obtiene obtiene el id del registro
                     * consulta el id en la tabla del servidor, si existe ese id  */

                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_granel_entrada from  rv_granel_entrada where id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "'");
                    if (id != "")
                    {
                        /* @adnto si trae algó la cadena de id, quiere decir q el id existe en el servidor
                         * entonces quiere decir q tendrá q actualizar se en el servidor */

                        bandera_update = true;
                        values_update += sep_update + "'" + Convert.ToString(row["id_granel_entrada"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_granel_entrada SET no_lote ='" + Convert.ToString(row["no_lote"]) + "', fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "', categoria='" + Convert.ToString(row["categoria"]) + "', ingrediente='" + Convert.ToString(row["ingrediente"]) + "', lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',tipo_cultivo_maguey='" + Convert.ToString(row["tipo_cultivo_maguey"]) + "',actualizado=0   WHERE id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "' ") == "Error")
                            return false;

                        /*
                         * if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_granel_entrada SET   lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',actualizado=0   WHERE id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "' ") == "Error")
                            return false;
                         */
                    }
                    else
                    {
                        /* @dnto si no encuentra coincidencia con algún id entonces tendrá q hacer una insercción   */
                        bandera_insert = true;

                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_lote_reveca = Convert.ToString(row["id_lote_reveca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);
                        string tipo_cultivo_maguey = Convert.ToString(row["tipo_cultivo_maguey"]);

                        values += sep + "('" + id_granel_entrada + "','" + id_lote_reveca + "','" + no_cliente + "','" + id_fabrica + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + fecha_movimiento + "','" + id_verificador + "','" + tipo_ingreso + "','" + tipo_cultivo_maguey + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_granel_entrada + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";

                if (bandera_update == true && bandera_insert == false)
                {
                    /* @adnto si sube correctamente la información a los registros con estatus actualizado=0, los modifica a actualizado=1
                     * indicando que ya no se deberán subir hasta q se modifique actualizado=0 a 1*/
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


        }



        //sube la tabla granel_entrada_envasado
        public Boolean SubidaGranelEntradaEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_granel_entrada_envasado (id_granel_entrada_envasado, id_lote_reveca, no_cliente, id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_entrada_envasado SET actualizado=1 WHERE id_granel_entrada_envasado IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_granel_entrada_envasado, id_lote_reveca, no_cliente, id_envasadora,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador,tipo_ingreso,tipo_cultivo_maguey,actualizado from granel_entrada_envasado WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_granel_entrada_envasado from  rv_granel_entrada_envasado where id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_granel_entrada_envasado"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_granel_entrada_envasado SET  no_lote ='" + Convert.ToString(row["no_lote"]) + "', fq='" + Convert.ToString(row["fq"]) + "', clase='" + Convert.ToString(row["clase"]) + "', categoria='" + Convert.ToString(row["categoria"]) + "', ingrediente='" + Convert.ToString(row["ingrediente"]) + "',  lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',tipo_cultivo_maguey='" + Convert.ToString(row["tipo_cultivo_maguey"]) + "',actualizado=0   WHERE id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_lote_reveca = Convert.ToString(row["id_lote_reveca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_envasadora = Convert.ToString(row["id_envasadora"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);
                        string tipo_cultivo_maguey = Convert.ToString(row["tipo_cultivo_maguey"]);

                        values += sep + "('" + id_granel_entrada + "','" + id_lote_reveca + "','" + no_cliente + "','" + id_envasadora + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + fecha_movimiento + "','" + id_verificador + "','" + tipo_ingreso + "','" + tipo_cultivo_maguey + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_granel_entrada + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";



                if (bandera_update == true && bandera_insert == false)
                {

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {



                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();



                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;



                    ConexionMysql.transCompleta();



                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        ////  agregar el campo lts_anteriores a el granel de envasado y almacen funciones ---



        //sube la tabla granel_movimientos
        public Boolean SubidaGranelMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_granel_movimientos (id_granel_movimientos, id_granel_entrada, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico, lts_anteriores,litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, fecha,fecha_movimiento, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_movimientos SET actualizado=1 WHERE id_granel_movimientos IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_granel_movimientos, id_granel_entrada, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico, litros_existentes, grado_alcoholico_existente,lts_anteriores, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from granel_movimientos WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_granel_movimientos from  rv_granel_movimientos where id_granel_movimientos='" + Convert.ToString(row["id_granel_movimientos"]) + "'");
                    if (id != "")
                    {
                        /*@adnto si existe el id quiere decir que ya existe el registro por lo tanto lo que se debe de hacer es solamente actualizar en el servidor (UPDATE) */
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_granel_movimientos"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_granel_movimientos  SET litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "', tipo_cobro ='" + Convert.ToString(row["tipo_cobro"]) + "',lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "', observaciones='" + Convert.ToString(row["observaciones"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "', actualizado=0   WHERE id_granel_movimientos='" + Convert.ToString(row["id_granel_movimientos"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        /*@adnto cuando no encuentra el id quiere decir q no existe ese registro y q debera ser tomado como nuevo e insertarlo en el servidor. */
                        bandera_insert = true;
                        string id_granel_movimientos = Convert.ToString(row["id_granel_movimientos"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string id_granel_entrada_sal = Convert.ToString(row["id_granel_entrada_sal"]);
                        string id_gran_mov_salio = Convert.ToString(row["id_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string tipo_cobro = Convert.ToString(row["tipo_cobro"]);
                        string lts_anteriores = Convert.ToString(row["lts_anteriores"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string salida_externa = Convert.ToString(row["salida_externa"]);
                        string razon_social_externa = Convert.ToString(row["razon_social_externa"]);
                        string bebidasCon = Convert.ToString(row["bebidasCon"]);
                        string destinobBebidasCon = Convert.ToString(row["destinobBebidasCon"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_granel_movimientos + "','" + id_granel_entrada + "','" + id_granel_entrada_sal + "','" + id_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + tipo_cobro + "','" + observaciones + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + salida_externa + "','" + razon_social_externa + "','" + bebidasCon + "','" + destinobBebidasCon + "','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_granel_movimientos + "'";
                        sep_update = ",";
                        /*id, id_granel_movimientos, id_granel_entrada, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, observaciones, no_lote, folio, litros, grado_alcoholico, litros_existentes, grado_alcoholico_existente, merma_litros, numero_de_contenedores, fecha, id_verificador, actualizado*/
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }



        //sube la tabla granel_movimientos_envasado
        public Boolean SubidaGranelMovimientosEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_granel_movimientos_envasado (id_granel_movimientos_envasado, id_granel_entrada_envasado, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico, lts_anteriores, litros_existentes, grado_alcoholico_existente, merma_litros, numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, fecha,fecha_movimiento, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_movimientos_envasado SET actualizado=1 WHERE id_granel_movimientos_envasado IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_granel_movimientos_envasado, id_granel_entrada_envasado, id_granel_entrada_sal, id_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, no_lote, folio, litros, grado_alcoholico, lts_anteriores,litros_existentes, grado_alcoholico_existente, merma_litros, numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from granel_movimientos_envasado WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_granel_movimientos_envasado from  rv_granel_movimientos_envasado where id_granel_movimientos_envasado='" + Convert.ToString(row["id_granel_movimientos_envasado"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_granel_movimientos_envasado"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_granel_movimientos_envasado  SET  lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "',  numero_de_contenedores ='" + Convert.ToString(row["numero_de_contenedores"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',actualizado=0   WHERE id_granel_movimientos_envasado='" + Convert.ToString(row["id_granel_movimientos_envasado"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_granel_movimientos = Convert.ToString(row["id_granel_movimientos_envasado"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_granel_entrada_sal = Convert.ToString(row["id_granel_entrada_sal"]);
                        string id_gran_mov_salio = Convert.ToString(row["id_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_anteriores = Convert.ToString(row["lts_anteriores"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string salida_externa = Convert.ToString(row["salida_externa"]);
                        string razon_social_externa = Convert.ToString(row["razon_social_externa"]);
                        string bebidasCon = Convert.ToString(row["bebidasCon"]);
                        string destinobBebidasCon = Convert.ToString(row["destinobBebidasCon"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);


                        values += sep + "('" + id_granel_movimientos + "','" + id_granel_entrada + "','" + id_granel_entrada_sal + "','" + id_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + salida_externa + "','" + razon_social_externa + "','"+ bebidasCon + "','" + destinobBebidasCon + "','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_granel_movimientos + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla granel salida
        public Boolean SubidaGranelSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_granel_salida (id_granel_salida, id_granel_entrada, id_solicitud, id_granel_entrada_envasado, id_almacen_granel_entrada, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_salida SET actualizado=1 WHERE id_granel_salida IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_granel_salida, id_granel_entrada, id_solicitud, id_granel_entrada_envasado, id_almacen_granel_entrada, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado from granel_salida WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id_granel_salida = Convert.ToString(row["id_granel_salida"]);
                    string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                    string id_solicitud = Convert.ToString(row["id_solicitud"]);
                    string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                    string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                    string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                    string litros = Convert.ToString(row["litros"]);
                    string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_granel_salida + "','" + id_granel_entrada + "','" + id_solicitud + "','" + id_granel_entrada_envasado + "','" + id_almacen_granel_entrada + "','" + id_envasado_entrada + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1,now())";
                    sep = ",";
                    values_update += sep_update + "'" + id_granel_salida + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla granel tanque
        public Boolean SubidaGranelTanque()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql = "INSERT INTO rv_granel_tanques (id_tanque, id_granel_entrada, tanque, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_tanques SET actualizado=1 WHERE id_tanque IN(";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_tanque, id_granel_entrada, tanque, id_verificador, actualizado from granel_tanques WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {


                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_tanque from  rv_granel_tanques where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");
                    if (id != "")
                    {
                        //if (Convert.ToString(row["actualizado"]) == "0")
                        //{

                        values_update += sep_update + "'" + Convert.ToString(row["id_tanque"]) + "'";
                        sep_update = ",";

                        bandera_update = true;
                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_granel_tanques SET  id_granel_entrada='" + Convert.ToString(row["id_granel_entrada"]) + "', tanque='" + Convert.ToString(row["tanque"]) + "',actualizado=0   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                            return false;
                        //}
                    }
                    else
                    {


                        bandera_insert = true;
                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_tanque + "','" + id_granel_entrada + "','" + tanque + "'," + id_verificador + ",1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_tanque + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";



                /* if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                     return false;
                 ConexionMysqlRemota2.transCompleta();

                 if (ConexionMysql.insUpd_transaccion(update) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true; */
                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;

                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla granel tanque
        public Boolean SubidaGranelTanqueEnvasado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql = "INSERT INTO rv_granel_tanques_envasado (id_tanque, id_granel_entrada_envasado, tanque, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE granel_tanques_envasado SET actualizado=1 WHERE id_tanque IN(";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_tanque, id_granel_entrada_envasado, tanque, id_verificador, actualizado from granel_tanques_envasado WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {

                    return true;

                }

                int r = 0;
                foreach (DataRow row in datos.Tables[0].Rows)
                {


                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_tanque from  rv_granel_tanques_envasado where id_tanque='" + Convert.ToString(row["id_tanque"]) + "'");

                    if (id != "")
                    {
                        //if (Convert.ToString(row["actualizado"]) == "0")
                        //{


                        values_update += sep_update + "'" + Convert.ToString(row["id_tanque"]) + "'";
                        sep_update = ",";
                        bandera_update = true;

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_granel_tanques_envasado SET  id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', tanque='" + Convert.ToString(row["tanque"]) + "',actualizado=0   WHERE id_tanque='" + Convert.ToString(row["id_tanque"]) + "' ") == "Error")
                            return false;

                    }
                    else
                    {
                        bandera_insert = true;
                        string id_tanque = Convert.ToString(row["id_tanque"]);
                        string id_granel_entrada = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string tanque = Convert.ToString(row["tanque"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);



                        values += sep + "('" + id_tanque + "','" + id_granel_entrada + "','" + tanque + "'," + id_verificador + ",1,now())";


                        sep = ",";

                        values_update += sep_update + "'" + id_tanque + "'";
                        sep_update = ",";
                    }

                    r++;
                }

                sql += values + ";";
                update += values_update + ");";


                /* if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                     return false;
                 ConexionMysqlRemota2.transCompleta();

                 if (ConexionMysql.insUpd_transaccion(update) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/
                if (bandera_update == true && bandera_insert == false)
                {


                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {



                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla fabrica-maestro
        public Boolean SubidaFabricaMaestro()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql = "INSERT INTO rv_maestro_fabrica (id_fabrica, no_cliente, fabrica, maestro,folio_unico_granel,estado,municipio,localidad,id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE maestro_fabrica SET actualizado=1 WHERE id_fabrica IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_fabrica, no_cliente, fabrica, maestro,folio_unico_granel,estado,municipio,localidad,id_verificador, actualizado from maestro_fabrica WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_fabrica from  rv_maestro_fabrica where id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "'");
                    if (id != "")
                    {
                        /*if (Convert.ToString(row["actualizado"]) == "0")
                        {*/
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_fabrica"]) + "'";
                        sep_update = ",";




                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_maestro_fabrica SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',fabrica='" + Convert.ToString(row["fabrica"]) + "',maestro='" + Convert.ToString(row["maestro"]) + "',folio_unico_granel='" + Convert.ToString(row["folio_unico_granel"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "', actualizado=0    WHERE id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "'") == "Error")
                            return false;
                        //}
                    }
                    else
                    {

                        bandera_insert = true;
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string fabrica = Convert.ToString(row["fabrica"]);
                        string maestro = Convert.ToString(row["maestro"]);
                        string folio_unico_granel = Convert.ToString(row["folio_unico_granel"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_fabrica + "','" + no_cliente + "','" + fabrica + "','" + maestro + "','" + folio_unico_granel + "','" + estado + "','" + municipio + "','" + localidad + "','" + id_verificador + "',1,now())";
                        sep = ",";
                        values_update += sep_update + "'" + id_fabrica + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";

                /* if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                     return false;
                 ConexionMysqlRemota2.transCompleta();

                 if (ConexionMysql.insUpd_transaccion(update) == "Error")
                     return false;
                 ConexionMysql.transCompleta();
                 return true;*/

                /*
                             if (bandera_insert == false && bandera_update == true)
                             {
                                 ConexionMysql.transCompleta();
                                 ConexionMysqlRemota2.transCompleta();
                                 return true;
                             }
                             else if (bandera_insert == false && bandera_update == false)
                             {
                                 return true;
                             }
                             else
                             {
                                 sql += values + ";";
                                 if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                                     return false;
                                 ConexionMysqlRemota2.transCompleta();
                                 return true;
                             }*/


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }





        //sube la tabla agave_cocido_sobrante
        public Boolean SubidaAgaveCocidoSobrante()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_produccion_agave_cocido_sobrante (id_agave_cocido_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_predio, id_planta, agave_cocido_kg, porcentaje_art, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE produccion_agave_cocido_sobrante SET actualizado=1 WHERE id_agave_cocido_sobrante IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_agave_cocido_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_predio, id_planta, agave_cocido_kg, porcentaje_art, id_verificador, actualizado from produccion_agave_cocido_sobrante WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_agave_cocido_sobrante from  rv_produccion_agave_cocido_sobrante where id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_produccion_agave_cocido_sobrante  SET agave_cocido_kg='" + Convert.ToString(row["agave_cocido_kg"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "',actualizado=0   WHERE id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_agave_cocido_sobrante = Convert.ToString(row["id_agave_cocido_sobrante"]);
                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_cocido_kg = Convert.ToString(row["agave_cocido_kg"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_agave_cocido_sobrante + "','" + id_ensamble_union + "','" + id_produccion_entrada + "','" + no_cliente + "','" + id_predio + "','" + id_planta + "','" + agave_cocido_kg + "','" + porcentaje_art + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_agave_cocido_sobrante + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla agave sobrante
        public Boolean SubidaAgaveSobrante()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_produccion_agave_sobrante (id_agave_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_planta, agave_kg, porcentaje_art, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE produccion_agave_sobrante SET actualizado=1 WHERE id_agave_sobrante IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_agave_sobrante, id_ensamble_union, id_produccion_entrada, no_cliente, id_planta, agave_kg, porcentaje_art, id_verificador, actualizado from produccion_agave_sobrante WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_agave_sobrante from  rv_produccion_agave_sobrante where id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_agave_sobrante"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_produccion_agave_sobrante  SET agave_kg='" + Convert.ToString(row["agave_kg"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "',actualizado=0   WHERE id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);

                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_agave_sobrante + "','" + id_ensamble_union + "','" + id_produccion_entrada + "','" + no_cliente + "','" + id_planta + "','" + agave_kg + "','" + porcentaje_art + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_agave_sobrante + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla produccion ensamble
        public Boolean SubidaProduccionEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_produccion_ensamble (id_ensamble_union, id_produccion_entrada, id_agave_sobrante, id_agave_cocido_sobrante, id_predio, id_planta,no_guia, no_pinas_agave, agave_kg, agave_coccion_kg, porcentaje_art, tipo, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE produccion_ensamble SET actualizado=1 WHERE id_ensamble_union IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_ensamble_union, id_produccion_entrada, id_agave_sobrante, id_agave_cocido_sobrante, id_predio, id_planta,no_guia, no_pinas_agave, agave_kg, agave_coccion_kg, porcentaje_art, tipo, id_verificador, actualizado from produccion_ensamble WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_ensamble_union from  rv_produccion_ensamble where id_ensamble_union='" + Convert.ToString(row["id_ensamble_union"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_ensamble_union"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_produccion_ensamble  SET id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "',id_agave_cocido_sobrante='" + Convert.ToString(row["id_agave_cocido_sobrante"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',no_guia='" + Convert.ToString(row["no_guia"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',actualizado=0   WHERE id_ensamble_union='" + Convert.ToString(row["id_ensamble_union"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;

                        string id_ensamble_union = Convert.ToString(row["id_ensamble_union"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string id_agave_cocido_sobrante = Convert.ToString(row["id_agave_cocido_sobrante"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);

                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);

                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        values += sep + "('" + id_ensamble_union + "','" + id_produccion_entrada + "','" + id_agave_sobrante + "','" + id_agave_cocido_sobrante + "','" + id_predio + "','" + id_planta + "','" + no_guia + "','" + no_pinas_agave + "','" + agave_kg + "','" + agave_coccion_kg + "','" + porcentaje_art + "','" + tipo + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_agave_sobrante + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla produccion_entrada
        public Boolean SubidaProduccionEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_produccion_entrada (id_produccion_entrada, id_proc_entr_sal, id_agave_sobrante, no_cliente, id_fabrica,id_maestro_mezcalero, id_predio, id_planta,id_comun,no_guia,gcrm,tapada, no_pinas_agave, agave_kg, agave_coccion_kg, id_coccion, periodo_coccion_inicio, periodo_coccion_fin, porcentaje_art, id_molienda, periodo_molienda_inicio, periodo_molienda_fin, periodo_formulacion_inicio, id_fermentacion, periodo_formulacion_fin, volumen_mosto, periodo_destilacion_inicio, id_destilacion, periodo_destilacion_fin, destilaciones_realizadas, lts_producidos, grado_alcoholico, lts_existentes, litros_puntas, grados_puntas, litros_colas, grados_colas,destilado_con, id_verificador, fecha, estatus, tipo, rendimiento,fecha_rendimiento, observaciones_rendimiento, id_verifico_rendimiento, actualizado,fecha_subio) VALUES";
                string update = "UPDATE produccion_entrada SET actualizado=1 WHERE id_produccion_entrada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_produccion_entrada, id_proc_entr_sal, id_agave_sobrante, no_cliente, id_fabrica,id_maestro_mezcalero, id_predio, id_planta,id_comun,no_guia,gcrm,tapada, no_pinas_agave, agave_kg, agave_coccion_kg, id_coccion,  DATE_FORMAT(periodo_coccion_inicio,'%Y-%m-%d') as periodo_coccion_inicio,  DATE_FORMAT(periodo_coccion_fin,'%Y-%m-%d') as periodo_coccion_fin, porcentaje_art, id_molienda,DATE_FORMAT(periodo_molienda_inicio,'%Y-%m-%d') as periodo_molienda_inicio  , DATE_FORMAT(periodo_molienda_fin,'%Y-%m-%d') as periodo_molienda_fin ,  DATE_FORMAT(periodo_formulacion_inicio,'%Y-%m-%d') as periodo_formulacion_inicio, id_fermentacion,  DATE_FORMAT(periodo_formulacion_fin,'%Y-%m-%d') as periodo_formulacion_fin, volumen_mosto,  DATE_FORMAT(periodo_destilacion_inicio,'%Y-%m-%d') as periodo_destilacion_inicio, id_destilacion,  DATE_FORMAT(periodo_destilacion_fin,'%Y-%m-%d') as periodo_destilacion_fin, destilaciones_realizadas, lts_producidos, grado_alcoholico, lts_existentes, litros_puntas, grados_puntas, litros_colas, grados_colas,destilado_con,id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, estatus, tipo, rendimiento,DATE_FORMAT(fecha_rendimiento,'%Y-%m-%d') as fecha_rendimiento, observaciones_rendimiento, id_verifico_rendimiento, actualizado from produccion_entrada WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_produccion_entrada from  rv_produccion_entrada where id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_produccion_entrada"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_produccion_entrada  SET  id_proc_entr_sal= '" + Convert.ToString(row["id_proc_entr_sal"]) + "',id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "',id_maestro_mezcalero='" + Convert.ToString(row["id_maestro_mezcalero"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',id_comun='" + Convert.ToString(row["id_comun"]) + "',no_guia='" + Convert.ToString(row["no_guia"]) + "',gcrm='" + Convert.ToString(row["gcrm"]) + "',tapada='" + Convert.ToString(row["tapada"]) + "',no_pinas_agave='" + Convert.ToString(row["no_pinas_agave"]) + "',agave_kg='" + Convert.ToString(row["agave_kg"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_coccion='" + Convert.ToString(row["id_coccion"]) + "',periodo_coccion_inicio='" + Convert.ToString(row["periodo_coccion_inicio"]) + "',periodo_coccion_fin='" + Convert.ToString(row["periodo_coccion_fin"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_molienda='" + Convert.ToString(row["id_molienda"]) + "',periodo_molienda_inicio='" + Convert.ToString(row["periodo_molienda_inicio"]) + "',periodo_molienda_fin='" + Convert.ToString(row["periodo_molienda_fin"]) + "',periodo_formulacion_inicio='" + Convert.ToString(row["periodo_formulacion_inicio"]) + "',id_fermentacion='" + Convert.ToString(row["id_fermentacion"]) + "',periodo_formulacion_fin='" + Convert.ToString(row["periodo_formulacion_fin"]) + "',volumen_mosto='" + Convert.ToString(row["volumen_mosto"]) + "',periodo_destilacion_inicio='" + Convert.ToString(row["periodo_destilacion_inicio"]) + "',id_destilacion='" + Convert.ToString(row["id_destilacion"]) + "',periodo_destilacion_fin='" + Convert.ToString(row["periodo_destilacion_fin"]) + "',destilaciones_realizadas='" + Convert.ToString(row["destilaciones_realizadas"]) + "',lts_producidos='" + Convert.ToString(row["lts_producidos"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',litros_puntas='" + Convert.ToString(row["litros_puntas"]) + "',grados_puntas='" + Convert.ToString(row["grados_puntas"]) + "',litros_colas='" + Convert.ToString(row["litros_colas"]) + "',grados_colas='" + Convert.ToString(row["grados_colas"]) + "',destilado_con='" + Convert.ToString(row["destilado_con"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',estatus='" + Convert.ToString(row["estatus"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',rendimiento='" + Convert.ToString(row["rendimiento"]) + "',fecha_rendimiento='" + Convert.ToString(row["fecha_rendimiento"]) + "',observaciones_rendimiento='" + Convert.ToString(row["observaciones_rendimiento"]) + "',id_verifico_rendimiento='" + Convert.ToString(row["id_verifico_rendimiento"]) + "',actualizado=0   WHERE id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) + "' ") == "Error")
                            return false;

                        // MessageBox.Show( "Subiendo : "+ "-UPDATE rv_produccion_entrada  SET  id_proc_entr_sal= '" + Convert.ToString(row["id_proc_entr_sal"]) + "',id_agave_sobrante='" + Convert.ToString(row["id_agave_sobrante"]) + "',no_cliente='" + Convert.ToString(row["no_cliente"]) + "',id_fabrica='" + Convert.ToString(row["id_fabrica"]) + "',id_predio='" + Convert.ToString(row["id_predio"]) + "',id_planta='" + Convert.ToString(row["id_planta"]) + "',tapada='" + Convert.ToString(row["tapada"]) + "',no_pinas_agave='" + Convert.ToString(row["no_pinas_agave"]) + "',agave_kg='" + Convert.ToString(row["agave_kg"]) + "',agave_coccion_kg='" + Convert.ToString(row["agave_coccion_kg"]) + "',id_coccion='" + Convert.ToString(row["id_coccion"]) + "',periodo_coccion_inicio='" + Convert.ToString(row["periodo_coccion_inicio"]) + "',periodo_coccion_fin='" + Convert.ToString(row["periodo_coccion_fin"]) + "',porcentaje_art='" + Convert.ToString(row["porcentaje_art"]) + "',id_molienda='" + Convert.ToString(row["id_molienda"]) + "',periodo_molienda_inicio='" + Convert.ToString(row["periodo_molienda_inicio"]) + "',periodo_molienda_fin='" + Convert.ToString(row["periodo_molienda_fin"]) + "',periodo_formulacion_inicio='" + Convert.ToString(row["periodo_formulacion_inicio"]) + "',id_fermentacion='" + Convert.ToString(row["id_fermentacion"]) + "',periodo_formulacion_fin='" + Convert.ToString(row["periodo_formulacion_fin"]) + "',volumen_mosto='" + Convert.ToString(row["volumen_mosto"]) + "',periodo_destilacion_inicio='" + Convert.ToString(row["periodo_destilacion_inicio"]) + "',id_destilacion='" + Convert.ToString(row["id_destilacion"]) + "',periodo_destilacion_fin='" + Convert.ToString(row["periodo_destilacion_fin"]) + "',destilaciones_realizadas='" + Convert.ToString(row["destilaciones_realizadas"]) + "',lts_producidos='" + Convert.ToString(row["lts_producidos"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',litros_puntas='" + Convert.ToString(row["litros_puntas"]) + "',grados_puntas='" + Convert.ToString(row["grados_puntas"]) + "',litros_colas='" + Convert.ToString(row["litros_colas"]) + "',grados_colas='" + Convert.ToString(row["grados_colas"]) + "',destilado_con='" + Convert.ToString(row["destilado_con"]) + "',id_verificador='" + Convert.ToString(row["id_verificador"]) + "',fecha='" + Convert.ToString(row["fecha"]) + "',estatus='" + Convert.ToString(row["estatus"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',rendimiento='" + Convert.ToString(row["rendimiento"]) + "',fecha_rendimiento='" + Convert.ToString(row["fecha_rendimiento"]) + "',observaciones_rendimiento='" + Convert.ToString(row["observaciones_rendimiento"]) + "',id_verifico_rendimiento='" + Convert.ToString(row["id_verifico_rendimiento"]) + "',actualizado=0   WHERE id_produccion_entrada='" + Convert.ToString(row["id_produccion_entrada"]) );
                    }
                    else
                    {
                        bandera_insert = true;



                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_proc_entr_sal = Convert.ToString(row["id_proc_entr_sal"]);
                        string id_agave_sobrante = Convert.ToString(row["id_agave_sobrante"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string id_maestro_mezcalero = Convert.ToString(row["id_maestro_mezcalero"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_guia = Convert.ToString(row["no_guia"]);
                        string gcrm = Convert.ToString(row["gcrm"]);
                        string tapada = Convert.ToString(row["tapada"]);
                        string no_pinas_agave = Convert.ToString(row["no_pinas_agave"]);
                        string agave_kg = Convert.ToString(row["agave_kg"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_coccion = Convert.ToString(row["id_coccion"]);
                        string periodo_coccion_inicio = Convert.ToString(row["periodo_coccion_inicio"]);
                        string periodo_coccion_fin = Convert.ToString(row["periodo_coccion_fin"]);
                        string porcentaje_art = Convert.ToString(row["porcentaje_art"]);
                        string id_molienda = Convert.ToString(row["id_molienda"]);
                        string periodo_molienda_inicio = Convert.ToString(row["periodo_molienda_inicio"]);
                        string periodo_molienda_fin = Convert.ToString(row["periodo_molienda_fin"]);
                        string periodo_formulacion_inicio = Convert.ToString(row["periodo_formulacion_inicio"]);
                        string id_fermentacion = Convert.ToString(row["id_fermentacion"]);
                        string periodo_formulacion_fin = Convert.ToString(row["periodo_formulacion_fin"]);
                        string volumen_mosto = Convert.ToString(row["volumen_mosto"]);
                        string periodo_destilacion_inicio = Convert.ToString(row["periodo_destilacion_inicio"]);
                        string id_destilacion = Convert.ToString(row["id_destilacion"]);
                        string periodo_destilacion_fin = Convert.ToString(row["periodo_destilacion_fin"]);
                        string destilaciones_realizadas = Convert.ToString(row["destilaciones_realizadas"]);
                        string lts_producidos = Convert.ToString(row["lts_producidos"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string litros_puntas = Convert.ToString(row["litros_puntas"]);
                        string grados_puntas = Convert.ToString(row["grados_puntas"]);
                        string litros_colas = Convert.ToString(row["litros_colas"]);
                        string grados_colas = Convert.ToString(row["grados_colas"]);
                        string destilado_con = Convert.ToString(row["destilado_con"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string estatus = Convert.ToString(row["estatus"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string rendimiento = Convert.ToString(row["rendimiento"]);
                        string fecha_rendimiento = Convert.ToString(row["fecha_rendimiento"]);
                        string observaciones_rendimiento = Convert.ToString(row["observaciones_rendimiento"]);
                        string id_verifico_rendimiento = Convert.ToString(row["id_verifico_rendimiento"]);


                        values += sep + "('" + id_produccion_entrada + "','" + id_proc_entr_sal + "','" + id_agave_sobrante + "','" + no_cliente + "','" + id_fabrica + "','" + id_maestro_mezcalero + "','" + id_predio + "','" + id_planta + "','" + id_comun + "','" + no_guia + "','" + gcrm + "','" + tapada + "','" + no_pinas_agave + "','" + agave_kg + "','" + agave_coccion_kg + "','" + id_coccion + "','" + periodo_coccion_inicio + "','" + periodo_coccion_fin + "','" + porcentaje_art + "','" + id_molienda + "','" + periodo_molienda_inicio + "','" + periodo_molienda_fin + "','" + periodo_formulacion_inicio + "','" + id_fermentacion + "','" + periodo_formulacion_fin + "','" + volumen_mosto + "','" + periodo_destilacion_inicio + "','" + id_destilacion + "','" + periodo_destilacion_fin + "','" + destilaciones_realizadas + "','" + lts_producidos + "','" + grado_alcoholico + "','" + lts_existentes + "','" + litros_puntas + "','" + grados_puntas + "','" + litros_colas + "','" + grados_colas + "','" + destilado_con + "','" + id_verificador + "','" + fecha + "','" + estatus + "','" + tipo + "','" + rendimiento + "','" + fecha_rendimiento + "','" + observaciones_rendimiento + "','" + id_verifico_rendimiento + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_produccion_entrada + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //sube la tabla produccion_puntas_colas
        public Boolean SubidaProduccionPuntasColas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_produccion_puntas_colas (id_produccion_puntas_colas, no_cliente, tipo, litros, grado_alcoholico, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE produccion_puntas_colas SET actualizado=1 WHERE id_produccion_puntas_colas IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_produccion_puntas_colas, no_cliente, tipo, litros, grado_alcoholico, id_verificador, actualizado from produccion_puntas_colas WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_produccion_puntas_colas from  rv_produccion_puntas_colas where id_produccion_puntas_colas='" + Convert.ToString(row["id_produccion_puntas_colas"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_produccion_puntas_colas"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_produccion_puntas_colas  SET  no_cliente= '" + Convert.ToString(row["no_cliente"]) + "',tipo='" + Convert.ToString(row["tipo"]) + "',litros='" + Convert.ToString(row["litros"]) + "',grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "',actualizado=0   WHERE id_produccion_puntas_colas='" + Convert.ToString(row["id_produccion_puntas_colas"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;


                        string id_produccion_puntas_colas = Convert.ToString(row["id_produccion_puntas_colas"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_produccion_puntas_colas + "','" + no_cliente + "','" + tipo + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_produccion_puntas_colas + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //sube la tabla ProduccionSalida
        public Boolean SubidaProduccionSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_produccion_salida (id_produccion_salida, id_produccion_entrada, id_solicitud, id_granel_entrada, litros, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE produccion_salida SET actualizado=1 WHERE id_produccion_salida IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_produccion_salida, id_produccion_entrada, id_solicitud, id_granel_entrada, litros, id_verificador, actualizado from produccion_salida WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id_produccion_salida = Convert.ToString(row["id_produccion_salida"]);
                    string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                    string id_solicitud = Convert.ToString(row["id_solicitud"]);
                    string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                    string litros = Convert.ToString(row["litros"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);
                    values += sep + "('" + id_produccion_salida + "','" + id_produccion_entrada + "','" + id_solicitud + "','" + id_granel_entrada + "','" + litros + "','" + id_verificador + "',1,now())";
                    sep = ",";
                    values_update += sep_update + "'" + id_produccion_salida + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //sube la tabla mensajes
        public Boolean SubidaMensajes()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_mensajes  (id_prod, tipo, mensaje, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE mensajes SET actualizado=1 WHERE id IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id, id_prod, tipo, mensaje, id_verificador, actualizado from mensajes WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = Convert.ToString(row["id"]);
                    string id_prod = Convert.ToString(row["id_prod"]);
                    string tipo = Convert.ToString(row["tipo"]);
                    string mensaje = Convert.ToString(row["mensaje"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);
                    values += sep + "('" + id_prod + "','" + tipo + "','" + mensaje + "','" + id_verificador + "',1,now())";

                    sep = ",";
                    values_update += sep_update + "'" + id + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla envasado_hologramas
        public Boolean SubidaEnvasadoHologramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_envasado_holograma (id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca,holograma_inicio, holograma_fin,serie,id_verificador, actualizado, fecha_subio, cliente_crm) VALUES";
                string update = "UPDATE envasado_holograma SET actualizado=1 WHERE id_envasado_holograma IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_envasado_holograma, id_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie, id_verificador, cliente_crm from envasado_holograma WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id_envasado_holograma = Convert.ToString(row["id_envasado_holograma"]);
                    string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                    string no_cliente = Convert.ToString(row["no_cliente"]);
                    string cve_marca = Convert.ToString(row["cve_marca"]);
                    string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                    string holograma_fin = Convert.ToString(row["holograma_fin"]);
                    string serie = Convert.ToString(row["serie"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);
                    string cliente_crm = Convert.ToString(row["cliente_crm"]);
                    values += sep + "('" + id_envasado_holograma + "','" + id_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + holograma_inicio + "','" + holograma_fin + "','" + serie + "','" + id_verificador + "',1,now(),'" + cliente_crm + "')";
                    sep = ",";

                    values_update += sep_update + "'" + id_envasado_holograma + "'";
                    sep_update = ",";
                }
                sql += values + ";";
                update += values_update + ");";

                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                {
                    return false;
                }
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                { return false; }
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //sube la tabla envasado entrada
        public Boolean SubidaAlmacenEnvasadoEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_envasado_entrada (id_almacen_envasado_entrada,id_almacen_envasado_entrada_salio, id_marca, no_cliente, id_almacen,fecha_movimiento,fecha,fecha_envasado_ini,fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso,actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_envasado_entrada SET actualizado=1 WHERE id_almacen_envasado_entrada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_envasado_entrada,id_almacen_envasado_entrada_salio,id_marca, no_cliente, id_almacen,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento,DATE_FORMAT(fecha,'%Y-%m-%d') as fecha,DATE_FORMAT(fecha_envasado_ini,'%Y-%m-%d') as fecha_envasado_ini,DATE_FORMAT(fecha_envasado_fin,'%Y-%m-%d') as fecha_envasado_fin, id_comun, no_lote_granel, id_solicitud, no_lote, id_planta, id_predio, fq, clase, categoria, abocante, ingrediente,etiquetado_como,unidad_medida, contenido_por_botella, litros, grado_alcoholico,grado_alcoholico_etiqueta,botellas_iniciales,botellas, botellas_existentes, holograma_inicio, holograma_fin, id_verificador,tipo_ingreso from almacen_envasado_entrada WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_almacen_envasado_entrada from  rv_almacen_envasado_entrada where id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "'");
                    if (id != "")
                    {///-- Entra si encuentra coinsidencias y actualiza...
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_almacen_envasado_entrada SET  id_marca='" + Convert.ToString(row["id_marca"]) + "',fq='" + Convert.ToString(row["fq"]) + "', fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "', etiquetado_como='" + Convert.ToString(row["etiquetado_como"]) + "',litros='" + Convert.ToString(row["litros"]) + "',botellas_iniciales='" + Convert.ToString(row["botellas_iniciales"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',tipo_ingreso='" + Convert.ToString(row["tipo_ingreso"]) + "',actualizado=0 WHERE id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        /// -- Si no encuentra coincidencia entra y hace un insert...

                        bandera_insert = true;
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_almacen_envasado_entrada_salio = Convert.ToString(row["id_almacen_envasado_entrada_salio"]);
                        string id_marca = Convert.ToString(row["id_marca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_envasado_ini = Convert.ToString(row["fecha_envasado_ini"]);
                        string fecha_envasado_fin = Convert.ToString(row["fecha_envasado_fin"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string etiquetado_como = Convert.ToString(row["etiquetado_como"]);
                        string unidad_medida = Convert.ToString(row["unidad_medida"]);
                        string contenido_por_botella = Convert.ToString(row["contenido_por_botella"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string grado_alcoholico_etiqueta = Convert.ToString(row["grado_alcoholico_etiqueta"]);
                        string botellas_iniciales = Convert.ToString(row["botellas_iniciales"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                        string holograma_fin = Convert.ToString(row["holograma_fin"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_ingreso = Convert.ToString(row["tipo_ingreso"]);
                        ///-- genera la cadena de los insert---
                        values += sep + "('" + id_almacen_envasado_entrada + "','" + id_almacen_envasado_entrada_salio + "','" + id_marca + "','" + no_cliente + "','" + id_almacen + "','" + fecha_movimiento + "','" + fecha + "','" + fecha_envasado_ini + "','" + fecha_envasado_fin + "','" + id_comun + "','" + no_lote_granel + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + etiquetado_como + "','" + unidad_medida + "','" + contenido_por_botella + "','" + litros + "','" + grado_alcoholico + "','" + grado_alcoholico_etiqueta + "','" + botellas_iniciales + "','" + botellas + "','" + botellas_existentes + "','" + holograma_inicio + "','" + holograma_fin + "','" + id_verificador + "','" + tipo_ingreso + "',1,now())";
                        sep = ",";

                        /// --  genera la cadena para hacer los update -- 
                        values_update += sep_update + "'" + id_almacen_envasado_entrada + "'";
                        sep_update = ",";
                    }
                }

                ///-- establese la cadena de los insert
                sql += values + ";";
                //-- establece la cadena de update para cambio de actualizado a 1 en el localhost
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }//-- fin Suvidaalmacenenvasado




        //sube la tabla almacen envasado ensamble
        public Boolean SubidaAlmacenEnvasadoEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_envasado_ensamble (id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_envasado_ensamble SET actualizado=1 WHERE id_almacen_envasado_ensamble IN( ";

                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_envasado_ensamble, id_almacen_envasado_entrada, id_comun, no_lote_granel, id_planta, id_predio, litros, agave_coccion_kg, id_verificador from almacen_envasado_ensamble WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }

                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id_almacen_envasado_ensamble = Convert.ToString(row["id_almacen_envasado_ensamble"]);
                    string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                    string id_comun = Convert.ToString(row["id_comun"]);
                    string no_lote_granel = Convert.ToString(row["no_lote_granel"]);
                    string id_planta = Convert.ToString(row["id_planta"]);
                    string id_predio = Convert.ToString(row["id_predio"]);
                    string litros = Convert.ToString(row["litros"]);
                    string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_almacen_envasado_ensamble + "','" + id_almacen_envasado_entrada + "','" + id_comun + "','" + no_lote_granel + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + agave_coccion_kg + "','" + id_verificador + "',1,now())";
                    sep = ",";

                    values_update += sep_update + "'" + id_almacen_envasado_ensamble + "'";
                    sep_update = ",";


                }

                sql += values + ";";
                update += values_update + ");";
                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen envasado Movimientos
        public Boolean SubidaAlmacenEnvasadoMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_envasado_movimientos (id_almacen_envasado_movimientos, id_almacen_envasado_entrada, id_almacen_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, fecha, id_verificador, actualizado, observaciones,fecha_subio) VALUES";
                string update = "UPDATE almacen_envasado_movimientos SET actualizado=1 WHERE id_almacen_envasado_movimientos IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_envasado_movimientos, id_almacen_envasado_entrada, id_almacen_env_mov_salio, no_cliente, id_solicitud, tipo, destino, botellas, botellas_existentes, cajas, botellas_por_cajas, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, id_verificador, observaciones from almacen_envasado_movimientos WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_almacen_envasado_movimientos from  rv_almacen_envasado_movimientos where id_almacen_envasado_movimientos='" + Convert.ToString(row["id_almacen_envasado_movimientos"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_almacen_envasado_movimientos"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_almacen_envasado_movimientos SET  tipo='" + Convert.ToString(row["tipo"]) + "',destino='" + Convert.ToString(row["destino"]) + "',botellas='" + Convert.ToString(row["botellas"]) + "',botellas_existentes='" + Convert.ToString(row["botellas_existentes"]) + "',cajas='" + Convert.ToString(row["cajas"]) + "',botellas_por_cajas='" + Convert.ToString(row["botellas_por_cajas"]) + "',actualizado=0 WHERE id_almacen_envasado_movimientos='" + Convert.ToString(row["id_almacen_envasado_movimientos"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen_envasado_movimientos = Convert.ToString(row["id_almacen_envasado_movimientos"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_almacen_env_mov_salio = Convert.ToString(row["id_almacen_env_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string destino = Convert.ToString(row["destino"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string botellas_existentes = Convert.ToString(row["botellas_existentes"]);
                        string cajas = Convert.ToString(row["cajas"]);
                        string botellas_por_cajas = Convert.ToString(row["botellas_por_cajas"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        values += sep + "('" + id_almacen_envasado_movimientos + "','" + id_almacen_envasado_entrada + "','" + id_almacen_env_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + botellas + "','" + botellas_existentes + "','" + cajas + "','" + botellas_por_cajas + "','" + fecha + "','" + id_verificador + "',1,'" + observaciones + "',now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_almacen_envasado_movimientos + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla  almacen encargado
        public Boolean SubidaAlmacenEncargado()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_encargado (id_almacen, no_cliente, almacen, encargado,folio_unico_granel,estado,municipio,localidad, id_verificador,tipo_almacen, actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_encargado SET actualizado=1 WHERE id_almacen IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen, no_cliente, almacen, encargado,folio_unico_granel,estado,municipio,localidad, id_verificador,tipo_almacen  from almacen_encargado WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_almacen from  rv_almacen_encargado where id_almacen='" + Convert.ToString(row["id_almacen"]) + "'");
                    if (id != "")
                    {
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_almacen"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_almacen_encargado SET  no_cliente='" + Convert.ToString(row["no_cliente"]) + "',almacen='" + Convert.ToString(row["almacen"]) + "',encargado='" + Convert.ToString(row["encargado"]) + "',folio_unico_granel='" + Convert.ToString(row["folio_unico_granel"]) + "',estado='" + Convert.ToString(row["estado"]) + "',municipio='" + Convert.ToString(row["municipio"]) + "',localidad='" + Convert.ToString(row["localidad"]) + "',tipo_almacen='" + Convert.ToString(row["tipo_almacen"]) + "', actualizado=0  WHERE id_almacen='" + Convert.ToString(row["id_almacen"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        bandera_insert = true;
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string almacen = Convert.ToString(row["almacen"]);
                        string encargado = Convert.ToString(row["encargado"]);
                        string folio_unico_granel = Convert.ToString(row["folio_unico_granel"]);
                        string estado = Convert.ToString(row["estado"]);
                        string municipio = Convert.ToString(row["municipio"]);
                        string localidad = Convert.ToString(row["localidad"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string tipo_almacen = Convert.ToString(row["tipo_almacen"]);




                        values += sep + "('" + id_almacen + "','" + no_cliente + "','" + almacen + "','" + encargado + "','" + folio_unico_granel + "','" + estado + "','" + municipio + "','" + localidad + "','" + id_verificador + "','" + tipo_almacen + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_almacen + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen_envasado_hologramas
        public Boolean SubidaAlmacenEnvasadoHologramas()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_envasado_holograma (id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca,holograma_inicio, holograma_fin,serie,tipo_instalacion,id_verificador, actualizado, fecha_subio, cliente_crm) VALUES";
                string update = "UPDATE almacen_envasado_holograma SET actualizado=1 WHERE id_almacen_envasado_holograma IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_envasado_holograma, id_almacen_envasado_entrada,no_cliente,cve_marca, holograma_inicio, holograma_fin,serie,tipo_instalacion, id_verificador, cliente_crm from almacen_envasado_holograma  WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id_almacen_envasado_holograma = Convert.ToString(row["id_almacen_envasado_holograma"]);
                    string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                    string no_cliente = Convert.ToString(row["no_cliente"]);
                    string cve_marca = Convert.ToString(row["cve_marca"]);
                    string holograma_inicio = Convert.ToString(row["holograma_inicio"]);
                    string holograma_fin = Convert.ToString(row["holograma_fin"]);
                    string serie = Convert.ToString(row["serie"]);
                    string tipo_instalacion = Convert.ToString(row["tipo_instalacion"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);
                    string cliente_crm = Convert.ToString(row["cliente_crm"]);

                    values += sep + "('" + id_almacen_envasado_holograma + "','" + id_almacen_envasado_entrada + "','" + no_cliente + "','" + cve_marca + "','" + holograma_inicio + "','" + holograma_fin + "','" + serie + "','" + tipo_instalacion + "','" + id_verificador + "',1,now(),'" + cliente_crm + "')";
                    sep = ",";

                    values_update += sep_update + "'" + id_almacen_envasado_holograma + "'";
                    sep_update = ",";
                }
                sql += values + ";";
                update += values_update + ");";

                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                {
                    return false;
                }
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                { return false; }
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }




        //sube la tabla almacen granel ensamble
        public Boolean SubidaAlmacenGranelEnsamble()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_granel_ensamble (id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_granel_ensamble SET actualizado=1 WHERE id_almacen_granel_ensamble IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_granel_ensamble, id_almacen_granel_entrada, id_almacen_granel_entrada_salio, id_comun, id_planta, id_predio, litros, grado_alcoholico, agave_coccion_kg, id_verificador, actualizado from almacen_granel_ensamble WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id_almacen_granel_ensamble = Convert.ToString(row["id_almacen_granel_ensamble"]);
                    string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                    string id_almacen_granel_entrada_salio = Convert.ToString(row["id_almacen_granel_entrada_salio"]);
                    string id_comun = Convert.ToString(row["id_comun"]);
                    string id_planta = Convert.ToString(row["id_planta"]);
                    string id_predio = Convert.ToString(row["id_predio"]);
                    string litros = Convert.ToString(row["litros"]);
                    string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                    string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_almacen_granel_ensamble + "','" + id_almacen_granel_entrada + "','" + id_almacen_granel_entrada_salio + "','" + id_comun + "','" + id_planta + "','" + id_predio + "','" + litros + "','" + grado_alcoholico + "','" + agave_coccion_kg + "','" + id_verificador + "',1,now())";
                    sep = ",";

                    values_update += sep_update + "'" + id_almacen_granel_ensamble + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        //sube la tabla almacen_granel_entrada
        public Boolean SubidaAlmacenGranelEntrada()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_granel_entrada (id_almacen_granel_entrada, id_lote_reveca, no_cliente, id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,fecha_movimiento, id_verificador,actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_granel_entrada SET actualizado=1 WHERE id_almacen_granel_entrada IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_granel_entrada, id_lote_reveca, no_cliente, id_almacen,  DATE_FORMAT(fecha,'%Y-%m-%d') as fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,tipo_ingreso,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador,actualizado from almacen_granel_entrada WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    /* @adnto en el foreach recorre los resultados de todos aquellos registros de la tabla local granel_entrada
                     * que el campo actualizado tenga=0 en cada iteración obtiene obtiene el id del registro
                     * consulta el id en la tabla del servidor, si existe ese id  */

                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_almacen_granel_entrada from  rv_almacen_granel_entrada where id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "'");
                    if (id != "")
                    {
                        /* @adnto si trae algó la cadena de id, quiere decir q el id existe en el servidor
                         * entonces quiere decir q tendrá q actualizar se en el servidor */

                        bandera_update = true;
                        values_update += sep_update + "'" + Convert.ToString(row["id_almacen_granel_entrada"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_almacen_granel_entrada SET fq='" + Convert.ToString(row["fq"]) + "',clase='" + Convert.ToString(row["clase"]) + "', categoria='" + Convert.ToString(row["categoria"]) + "', ingrediente='" + Convert.ToString(row["ingrediente"]) + "', lts_existentes='" + Convert.ToString(row["lts_existentes"]) + "',grado_alcoholico_existente='" + Convert.ToString(row["grado_alcoholico_existente"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "',actualizado=0   WHERE id_almacen_granel_entrada='" + Convert.ToString(row["id_almacen_granel_entrada"]) + "' ") == "Error")
                            return false;


                    }
                    else
                    {
                        /* @dnto si no encuentra coincidencia con algún id entonces tendrá q hacer una insercción   */
                        bandera_insert = true;

                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_lote_reveca = Convert.ToString(row["id_lote_reveca"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_almacen = Convert.ToString(row["id_almacen"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string id_comun = Convert.ToString(row["id_comun"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string id_planta = Convert.ToString(row["id_planta"]);
                        string agave_coccion_kg = Convert.ToString(row["agave_coccion_kg"]);
                        string id_predio = Convert.ToString(row["id_predio"]);
                        string fq = Convert.ToString(row["fq"]);
                        string clase = Convert.ToString(row["clase"]);
                        string categoria = Convert.ToString(row["categoria"]);
                        string abocante = Convert.ToString(row["abocante"]);
                        string ingrediente = Convert.ToString(row["ingrediente"]);
                        string lts_entrada = Convert.ToString(row["lts_entrada"]);
                        string grado_alcoholico_entrada = Convert.ToString(row["grado_alcoholico_entrada"]);
                        string lts_existentes = Convert.ToString(row["lts_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string tipo_producto = Convert.ToString(row["tipo_ingreso"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);




                        values += sep + "('" + id_almacen_granel_entrada + "','" + id_lote_reveca + "','" + no_cliente + "','" + id_almacen + "','" + fecha + "','" + id_comun + "','" + id_solicitud + "','" + no_lote + "','" + id_planta + "','" + agave_coccion_kg + "','" + id_predio + "','" + fq + "','" + clase + "','" + categoria + "','" + abocante + "','" + ingrediente + "','" + lts_entrada + "','" + grado_alcoholico_entrada + "','" + lts_existentes + "','" + grado_alcoholico_existente + "','" + tipo_producto + "','" + fecha_movimiento + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_almacen_granel_entrada + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";

                if (bandera_update == true && bandera_insert == false)
                {
                    /* @adnto si sube correctamente la información a los registros con estatus actualizado=0, los modifica a actualizado=1
                     * indicando que ya no se deberán subir hasta q se modifique actualizado=0 a 1*/
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


        }



        //sube la tabla almacen_granel_movimientos
        public Boolean SubidaAlmacenGranelMovimientos()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_granel_movimientos (id_almacen_granel_movimientos, id_almacen_granel_entrada, id_almacen_granel_entrada_sal, id_almacen_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico,lts_anteriores,litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, fecha,fecha_movimiento, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_granel_movimientos SET actualizado=1 WHERE id_almacen_granel_movimientos IN( ";
                Boolean bandera_update = false;
                Boolean bandera_insert = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_granel_movimientos, id_almacen_granel_entrada, id_almacen_granel_entrada_sal, id_almacen_gran_mov_salio, no_cliente, id_solicitud, tipo, destino, tipo_cobro, observaciones, no_lote, folio, litros, grado_alcoholico,lts_anteriores,litros_existentes, grado_alcoholico_existente, merma_litros,numero_de_contenedores_iniciales, numero_de_contenedores, salida_externa, razon_social_externa,bebidasCon,destinobBebidasCon, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha,DATE_FORMAT(fecha_movimiento,'%Y-%m-%d') as fecha_movimiento, id_verificador, actualizado from almacen_granel_movimientos WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select id_almacen_granel_movimientos from  rv_almacen_granel_movimientos where id_almacen_granel_movimientos='" + Convert.ToString(row["id_almacen_granel_movimientos"]) + "'");
                    if (id != "")
                    {
                        /*@adnto si existe el id quiere decir que ya existe el registro por lo tanto lo que se debe de hacer es solamente actualizar en el servidor (UPDATE) */
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_almacen_granel_movimientos"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_almacen_granel_movimientos  SET lts_anteriores='" + Convert.ToString(row["lts_anteriores"]) + "',litros_existentes='" + Convert.ToString(row["litros_existentes"]) + "', tipo_cobro ='" + Convert.ToString(row["tipo_cobro"]) + "', observaciones='" + Convert.ToString(row["observaciones"]) + "',numero_de_contenedores='" + Convert.ToString(row["numero_de_contenedores"]) + "',fecha_movimiento='" + Convert.ToString(row["fecha_movimiento"]) + "', actualizado=0   WHERE id_almacen_granel_movimientos='" + Convert.ToString(row["id_almacen_granel_movimientos"]) + "' ") == "Error")
                            return false;
                    }
                    else
                    {
                        /*@adnto cuando no encuentra el id quiere decir q no existe ese registro y q debera ser tomado como nuevo e insertarlo en el servidor. */
                        bandera_insert = true;
                        string id_almacen_granel_movimientos = Convert.ToString(row["id_almacen_granel_movimientos"]);
                        string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                        string id_almacen_granel_entrada_sal = Convert.ToString(row["id_almacen_granel_entrada_sal"]);
                        string id_almacen_gran_mov_salio = Convert.ToString(row["id_almacen_gran_mov_salio"]);
                        string no_cliente = Convert.ToString(row["no_cliente"]);
                        string id_solicitud = Convert.ToString(row["id_solicitud"]);
                        string tipo = Convert.ToString(row["tipo"]);
                        string destino = Convert.ToString(row["destino"]);
                        string tipo_cobro = Convert.ToString(row["tipo_cobro"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string no_lote = Convert.ToString(row["no_lote"]);
                        string folio = Convert.ToString(row["folio"]);
                        string litros = Convert.ToString(row["litros"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string lts_anteriores = Convert.ToString(row["lts_anteriores"]);
                        string litros_existentes = Convert.ToString(row["litros_existentes"]);
                        string grado_alcoholico_existente = Convert.ToString(row["grado_alcoholico_existente"]);
                        string merma_litros = Convert.ToString(row["merma_litros"]);
                        string numero_de_contenedores_iniciales = Convert.ToString(row["numero_de_contenedores_iniciales"]);
                        string numero_de_contenedores = Convert.ToString(row["numero_de_contenedores"]);
                        string salida_externa = Convert.ToString(row["salida_externa"]);
                        string razon_social_externa = Convert.ToString(row["razon_social_externa"]);
                        string bebidasCon = Convert.ToString(row["bebidasCon"]);
                        string destinobBebidasCon = Convert.ToString(row["destinobBebidasCon"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string fecha_movimiento = Convert.ToString(row["fecha_movimiento"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_almacen_granel_movimientos + "','" + id_almacen_granel_entrada + "','" + id_almacen_granel_entrada_sal + "','" + id_almacen_gran_mov_salio + "','" + no_cliente + "','" + id_solicitud + "','" + tipo + "','" + destino + "','" + tipo_cobro + "','" + observaciones + "','" + no_lote + "','" + folio + "','" + litros + "','" + grado_alcoholico + "','" + lts_anteriores + "','" + litros_existentes + "','" + grado_alcoholico_existente + "','" + merma_litros + "','" + numero_de_contenedores_iniciales + "','" + numero_de_contenedores + "','" + salida_externa + "','" + razon_social_externa + "','" + bebidasCon + "','" + destinobBebidasCon + "','" + fecha + "','" + fecha_movimiento + "','" + id_verificador + "',1,now())";
                        sep = ",";

                        values_update += sep_update + "'" + id_almacen_granel_movimientos + "'";

                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }



        //sube la tabla almacen granel tanque 
        public Boolean SubidaAlmacenGranelTanque()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_granel_tanques (id_tanque, id_almacen_granel_entrada, tanque, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_granel_tanques SET actualizado=1 WHERE id_tanque IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_tanque, id_almacen_granel_entrada, tanque, id_verificador, actualizado from almacen_granel_tanques WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {





                    string id_tanque = Convert.ToString(row["id_tanque"]);
                    string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                    string tanque = Convert.ToString(row["tanque"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_tanque + "','" + id_almacen_granel_entrada + "','" + tanque + "','" + id_verificador + "',1,now())";
                    sep = ",";
                    values_update += sep_update + "'" + id_tanque + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        public Boolean SubidaAlmacenGranelSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_almacen_granel_salida (id_almacen_granel_salida, id_almacen_granel_entrada, id_solicitud,id_granel_entrada, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE almacen_granel_salida SET actualizado=1 WHERE almacen_granel_salida IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_almacen_granel_salida, id_almacen_granel_entrada, id_solicitud,id_granel_entrada, id_granel_entrada_envasado, id_envasado_entrada, litros, grado_alcoholico, id_verificador, actualizado from almacen_granel_salida WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id_almacen_granel_salida = Convert.ToString(row["id_almacen_granel_salida"]);
                    string id_almacen_granel_entrada = Convert.ToString(row["id_almacen_granel_entrada"]);
                    string id_solicitud = Convert.ToString(row["id_solicitud"]);
                    string id_granel_entrada = Convert.ToString(row["id_granel_entrada"]);
                    string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                    string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                    string litros = Convert.ToString(row["litros"]);
                    string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                    string id_verificador = Convert.ToString(row["id_verificador"]);

                    values += sep + "('" + id_almacen_granel_salida + "','" + id_almacen_granel_entrada + "','" + id_solicitud + "','" + id_granel_entrada + "','" + id_granel_entrada_envasado + "','" + id_envasado_entrada + "','" + litros + "','" + grado_alcoholico + "','" + id_verificador + "',0,now())";
                    sep = ",";
                    values_update += sep_update + "'" + id_almacen_granel_salida + "'";
                    sep_update = ",";

                }
                sql += values + ";";
                update += values_update + ");";


                if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        //sube la tabla maestros_mezcaleros
        public Boolean SubidaMaestroMezcalero()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string sql = "INSERT INTO rv_maestros_mezcaleros (id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, fecha, activo, actualizado,fecha_subio) VALUES";
                string update = "UPDATE maestros_mezcaleros SET actualizado=1 WHERE id_maestros_mezcaleros IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_maestros_mezcaleros, n_maestro_mezcalero, id_fabrica, id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, activo, actualizado from maestros_mezcaleros WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_maestros_mezcaleros from  rv_maestros_mezcaleros where id_maestros_mezcaleros='" + Convert.ToString(row["id_maestros_mezcaleros"]) + "'");
                    if (id != "")
                    {
                        /* if (Convert.ToString(row["actualizado"]) == "0")
                         {*/
                        bandera_update = true;

                        values_update += sep_update + "'" + Convert.ToString(row["id_maestros_mezcaleros"]) + "'";
                        sep_update = ",";




                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE  rv_maestros_mezcaleros SET  activo='" + Convert.ToString(row["activo"]) + "', actualizado=0    WHERE id_maestros_mezcaleros='" + Convert.ToString(row["id_maestros_mezcaleros"]) + "'") == "Error")
                            return false;
                        //}
                    }
                    else
                    {

                        bandera_insert = true;
                        string id_maestros_mezcaleros = Convert.ToString(row["id_maestros_mezcaleros"]);
                        string n_maestro_mezcalero = Convert.ToString(row["n_maestro_mezcalero"]);
                        string id_fabrica = Convert.ToString(row["id_fabrica"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);
                        string activo = Convert.ToString(row["activo"]);
                        values += sep + "('" + id_maestros_mezcaleros + "','" + n_maestro_mezcalero + "','" + id_fabrica + "','" + id_verificador + "','" + fecha + "','" + activo + "',1,now())";
                        sep = ",";
                        values_update += sep_update + "'" + id_maestros_mezcaleros + "'";
                        sep_update = ",";
                    }
                }
                sql += values + ";";
                update += values_update + ");";


                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



        public Boolean SubidaEnvasadoSalida()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                string values_update = "";
                string sql = "INSERT INTO rv_envasado_salida (id_envasado_salida, id_envasado_entrada, id_almacen_envasado_entrada, id_granel_entrada_envasado, id_envasado_mov_salida, litros, botellas, grado_alcoholico, tipo_salida, observaciones, id_verificador, fecha, actualizado,fecha_subio) VALUES";
                string update = "UPDATE envasado_salida SET actualizado=1 WHERE id_envasado_salida IN( ";
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_envasado_salida, id_envasado_entrada, id_almacen_envasado_entrada, id_granel_entrada_envasado, id_envasado_mov_salida, litros, botellas, grado_alcoholico, tipo_salida, observaciones, id_verificador, DATE_FORMAT(fecha,'%Y-%m-%d %H:%i:%s') as fecha, actualizado from envasado_salida WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_envasado_salida from  rv_envasado_salida where id_envasado_salida='" + Convert.ToString(row["id_envasado_salida"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;


                        values_update += sep_update + "'" + Convert.ToString(row["id_envasado_salida"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE  envasado_salida SET  id_envasado_entrada='" + Convert.ToString(row["id_envasado_entrada"]) + "' ,id_almacen_envasado_entrada='" + Convert.ToString(row["id_almacen_envasado_entrada"]) + "', id_granel_entrada_envasado='" + Convert.ToString(row["id_granel_entrada_envasado"]) + "', id_envasado_mov_salida='" + Convert.ToString(row["id_envasado_mov_salida"]) + "', litros='" + Convert.ToString(row["litros"]) + "', botellas='" + Convert.ToString(row["botellas"]) + "', grado_alcoholico='" + Convert.ToString(row["grado_alcoholico"]) + "', tipo_salida='" + Convert.ToString(row["tipo_salida"]) + "', observaciones='" + Convert.ToString(row["observaciones"]) + "'   WHERE id_envasado_salida='" + Convert.ToString(row["id_envasado_salida"]) + "'") == "Error")
                            return false;

                    }
                    else
                    {

                        bandera_insert = true;




                        string id_envasado_salida = Convert.ToString(row["id_envasado_salida"]);
                        string id_envasado_entrada = Convert.ToString(row["id_envasado_entrada"]);
                        string id_almacen_envasado_entrada = Convert.ToString(row["id_almacen_envasado_entrada"]);
                        string id_granel_entrada_envasado = Convert.ToString(row["id_granel_entrada_envasado"]);
                        string id_envasado_mov_salida = Convert.ToString(row["id_envasado_mov_salida"]);
                        string litros = Convert.ToString(row["litros"]);
                        string botellas = Convert.ToString(row["botellas"]);
                        string grado_alcoholico = Convert.ToString(row["grado_alcoholico"]);
                        string tipo_salida = Convert.ToString(row["tipo_salida"]);
                        string observaciones = Convert.ToString(row["observaciones"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);
                        string fecha = Convert.ToString(row["fecha"]);

                        values += sep + "('" + id_envasado_salida + "','" + id_envasado_entrada + "','" + id_almacen_envasado_entrada + "','" + id_granel_entrada_envasado + "','" + id_envasado_mov_salida + "','" + litros + "','" + botellas + "','" + grado_alcoholico + "','" + tipo_salida + "','" + observaciones + "','" + id_verificador + "','" + fecha + "',1,now())";
                        sep = ",";
                        values_update += sep_update + "'" + id_envasado_salida + "'";
                        sep_update = ",";

                    }
                }
                sql += values + ";";
                update += values_update + ");";


                /*if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                    return false;
                ConexionMysqlRemota2.transCompleta();

                if (ConexionMysql.insUpd_transaccion(update) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                return true;*/
                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        /// Subida de los ids de producciones

        public Boolean SubidaIdsProduccion()
        {
            try
            {
                string sep = "";
                string values = "";
                string sep_update = "";
                string values_update = "";
                string sql = "INSERT INTO rv_ids_producciones (id_producciones, tipo_instalacion, id_produccion_entrada, id_lote, id_verificador, actualizado,fecha_subio) VALUES";
                string update = "UPDATE ids_producciones SET actualizado=1 WHERE id_producciones IN( ";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();
                ConexionMysql.llenaDataset(ref datos, "SELECT id_producciones, tipo_instalacion, id_produccion_entrada, id_lote, id_verificador, actualizado from ids_producciones WHERE actualizado=0");
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows)
                {

                    string id = ConexionMysqlRemota2.regresaCampoConsulta("select  id_producciones from  rv_ids_producciones where id_producciones='" + Convert.ToString(row["id_producciones"]) + "'");
                    if (id != "")
                    {

                        bandera_update = true;


                        values_update += sep_update + "'" + Convert.ToString(row["id_producciones"]) + "'";
                        sep_update = ",";

                        if (ConexionMysqlRemota2.insUpd_transaccion("UPDATE rv_ids_producciones SET  id_producciones ='" + Convert.ToString(row["id_producciones"]) + "', tipo_instalacion ='" + Convert.ToString(row["tipo_instalacion"]) + "', id_produccion_entrada ='" + Convert.ToString(row["id_produccion_entrada"]) + "', id_lote ='" + Convert.ToString(row["id_lote"]) + "', id_verificador =" + Convert.ToString(row["id_verificador"]) + " WHERE id_producciones='" + Convert.ToString(row["id_producciones"]) + "'") == "Error")
                            return false;

                    }
                    else
                    {

                        bandera_insert = true;

                        string id_producciones = Convert.ToString(row["id_producciones"]);
                        string tipo_instalacion = Convert.ToString(row["tipo_instalacion"]);
                        string id_produccion_entrada = Convert.ToString(row["id_produccion_entrada"]);
                        string id_lote = Convert.ToString(row["id_lote"]);
                        string id_verificador = Convert.ToString(row["id_verificador"]);

                        values += sep + "('" + id_producciones + "','" + tipo_instalacion + "','" + id_produccion_entrada + "','" + id_lote + "'," + id_verificador + ",0,now())";
                        sep = ",";


                        values_update += sep_update + "'" + id_producciones + "'";
                        sep_update = ",";

                    }

                }

                sql += values + ";";
                update += values_update + ");";



                if (bandera_update == true && bandera_insert == false)
                {
                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    ConexionMysqlRemota2.transCompleta();
                    return true;
                }
                else if (bandera_insert == false && bandera_update == false)
                {
                    return true;
                }
                else
                {
                    if (ConexionMysqlRemota2.insUpd_transaccion(sql) == "Error")
                        return false;
                    ConexionMysqlRemota2.transCompleta();

                    if (ConexionMysql.insUpd_transaccion(update) == "Error")
                        return false;
                    ConexionMysql.transCompleta();
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        // marca cuando subio informacion 
        public Boolean SubidaDeInformacion()
        {
            try
            {
                ConexionMysql.insUpd_transaccion("UPDATE su_ba SET Estado=1");// linea agregada para Actualizar el estado del log --2020
                if (ConexionMysqlRemota2.insUpd_transaccion("INSERT INTO rv_subida_bajada (id_verificador, tipo, fecha) VALUES(" + Usuario.IdUsuario + ",'Subida de informacion',now()) ") == "Error")
                {
                    return false;
                }

                if (ConexionMysql.insUpd_transaccion("INSERT INTO subida_bajada (id_verificador, tipo, fecha) VALUES(" + Usuario.IdUsuario + ",'Subida de informacion',now()) ") == "Error")
                {
                    return false;
                }

                ConexionMysqlRemota2.transCompleta();

                ConexionMysql.transCompleta();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion

        //esta funcion es donde se trabaja la funcion en segundo plano
        //@adnto esta función es la q llama a las demás funciones para ir subiendo poco a poco
        private void backgroundWorker_Subida_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Porcentajes de subida
            try
            {
                bandera = false;
                //reporta el progreso a una barra de carga 
                backgroundWorker_Subida.ReportProgress(0);

                ConexionMysql.conecta();
                ConexionMysqlRemota2.conecta();
                
                backgroundWorker_Subida.ReportProgress(5);


                if (SubidaEnvasadoEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(6);
                if (SubidaTransacciones() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //TODO: MANDAR A LLAMAR AL METODO DE SUBIDA LOTES VERIFICADOS GRANEL DE FÁBRICA
                backgroundWorker_Subida.ReportProgress(7);
                if (SubidaVerificacionGF() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // TODO: MANDAR A LLAMAR AL METODO DE SUBIDA LOTES VERIFICADOS GRANEL DE ENVASADO
                backgroundWorker_Subida.ReportProgress(8);
                if (SubidaVerificacionGE() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // TODO: MANDAR A LLAMAR AL METODO DE SUBIDA LOTES VERIFICADOS DE ENVASADO
                backgroundWorker_Subida.ReportProgress(9);
                if (SubidaVerificacionEN() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(10);

                if (SubidaMensajesRegistro() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(11);

                if (SubidaFqHistorial() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(12);

                if (SubidaEnvasadoEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(12);

                if (SubidaEnvasadoMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // METODO QUE VA A SUBIR LOS DATOS DE LAS GUIAS EXTERNAS
                backgroundWorker_Subida.ReportProgress(14);

                if (SubidaGuiaExternas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(17);

                if (SubidaEnvasadoEncargado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // DATOS ANTIGUOS 13/09/2021
                backgroundWorker_Subida.ReportProgress(18);

                if (SubidaExistenciaPlantaCompradaAntiguo() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(19);

                if (SubidaExistenciaPlantaComprada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(20);

                if (SubidaFolios() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(21);

                if (SubidaGranelEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(22);

                if (SubidaGranelEnsambleEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(23);

                if (SubidaGranelEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(24);
                if (SubidaGranelEntradaEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(25);
                if (SubidaGranelMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(26);
                if (SubidaGranelMovimientosEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(27);
                if (SubidaGranelSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(28);
                if (SubidaGranelTanque() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(32);
                if (SubidaGranelTanqueEnvasado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(36);
                if (SubidaFabricaMaestro() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(40);
                if (SubidaAgaveCocidoSobrante() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(45);
                if (SubidaAgaveSobrante() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(50);
                if (SubidaProduccionEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(55);
                if (SubidaProduccionEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(60);
                if (SubidaProduccionPuntasColas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                backgroundWorker_Subida.ReportProgress(62);
                if (SubidaAlmacenEnvasadoEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(64);
                if (SubidaAlmacenEnvasadoEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(66);
                if (SubidaAlmacenEnvasadoMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(69);
                if (SubidaAlmacenEncargado() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(72);
                if (SubidaAlmacenEnvasadoHologramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(74);
                if (SubidaAlmacenGranelEnsamble() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(76);
                if (SubidaAlmacenGranelEntrada() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(78);
                if (SubidaAlmacenGranelMovimientos() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(80);
                if (SubidaAlmacenGranelTanque() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(82);
                if (SubidaAlmacenGranelSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(84);
                if (SubidaMaestroMezcalero() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(86);
                if (SubidaEnvasadoSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                backgroundWorker_Subida.ReportProgress(87);
                if (SubidaIdsProduccion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                backgroundWorker_Subida.ReportProgress(88);
                if (SubidaProduccionSalida() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(89);
                if (SubidaMensajes() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(90);
                if (SubidaExtraccionesPlantasGuias() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //DATOS ANTIGUOS 13/09/2021
                backgroundWorker_Subida.ReportProgress(91);
                if (SubidaExtraccionesPlantasGuiasAntiguas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker_Subida.ReportProgress(95);
                if (SubidaEnvasadoHologramas() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                backgroundWorker_Subida.ReportProgress(98);
                if (SubidaDeInformacion() == false)
                {
                    MessageBox.Show("Error al actualizar la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }




                backgroundWorker_Subida.ReportProgress(100);
                Veri_movimientos.produccion = false;
                bandera = true;

                // if (Veri_movimientos.produccion == false) { BtnActualizar_Click(sender, e); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConexionMysql.msjInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }
                     
        //esta funcion sirve cuando tiene una barra de carga, va marcando el avance de lo que se esta haciendo
        private void backgroundWorker_Subida_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progresbar.Value = e.ProgressPercentage;
        }


        //esta funcion es cuando termina todo el trabajo de la funcion en segundo plano 
        private void backgroundWorker_Subida_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region
            if (bandera == true)
            {
                string ahora = ConexionMysqlRemota2.regresaCampoConsulta("select NOW() ");
                MessageBox.Show("Base de datos actualizada \n " + ahora, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LblSubiendo.Visible = false;
                Progresbar.Visible = false;
                carga.Visible = false;
            }
            else
            {
                LblSubiendo.Visible = false;
                Progresbar.Visible = false;
                carga.Visible = false;
            }
            ConexionMysql.cierraConexion();
            ConexionMysqlRemota2.cierraConexion();
            #endregion
        }

        /////////////////////////////////////////////////////////////////////////////////|--<<Fin subida de informacion>>--| ////////////////////////////////////////////////////////////////////////////////////////////

        #region Otras cosas y metodos

        private void BtnMensajes_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            FrmNuevoMensaje frm = new FrmNuevoMensaje();
            // frm.ShowDialog();
            Abrirhija(frm);
        }



        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            FrmConsultas frm = new FrmConsultas();
            //frm.ShowDialog();
            Abrirhija(frm);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            FrmConsultasNuevas frm = new FrmConsultasNuevas();
            //frm.ShowDialog();
            Abrirhija(frm);
        }



        //=====================================================================================================================================
        //--Remplaza El contenido dentro de un container-----
        public void Abrirhija(object formhija)
        {
            pictureBox2.Visible = false;
            if (this.Panelcontainer.Controls.Count > 0)
                this.Panelcontainer.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panelcontainer.Controls.Add(fh);
            this.Panelcontainer.Tag = fh;
            Panelcontainer.Visible = true;
            Panelcontainer.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            fh.Show();
        }
        //=======================================================================================================================================


        private void label6_Click(object sender, EventArgs e)
        {

            Panelcontainer.Visible = false;
            pictureBox2.Visible = true;


        }

        private void label2_Click(object sender, EventArgs e)
        {
            Panelcontainer.Visible = false;
            pictureBox2.Visible = true;
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            Observaciones d = new Observaciones();
            d.Show();

        }


        //====================================================================================
        //-->>Obtiene el nombre del verificador
        public string Obtener_name_verificador()
        {
            string line1 = Usuario.NombreUsuario;
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            //TextInfo myTI = new CultureInfo.CurrentCulture.TextInfo;

            string[] split = line1.Split(' ');

            if (split.Length > 1)
            {
                line1 = split[0] + ' ' + split[1];
            }
            else
            {
                line1 = split[0];
            }



            line1 = myTI.ToLower(line1);
            line1 = myTI.ToTitleCase(line1);

            return lblNameUser.Text = line1;
        }

        //--Fin de Obtener_name_verificador
        //==============================================================================

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (menu_lateral.Width == 250)
            {
                menu_lateral.Width = 52;
                label6.Visible = true;
                pictureBox1.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
                pictureBox3.Visible = false;

            }
            else
            {

                menu_lateral.Width = 250;
                label6.Visible = false;
                pictureBox1.Visible = false;
                pictureBox5.Visible = false;
                pictureBox4.Visible = true;
                pictureBox3.Visible = true;

            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            /*if (menu_lateral.Width == 250)
            {
                menu_lateral.Width = 52;
                label6.Visible = true;
                pictureBox1.Visible = true;
                pictureBox1.Visible = false;
            }
            else
            {

                menu_lateral.Width = 250;
                label6.Visible = false;
                pictureBox1.Visible = false;
                pictureBox5.Visible = false;
                 pictureBox1.Visible = true;
            
            }*/

            pictureBox4_Click(sender, e);



        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        { ///-- este boton llamara al form que pertenece al administrador para mejor contol de reveca

            Administrador.FrmAdministrador admin = new Administrador.FrmAdministrador();
            admin.Show();


        }

        #endregion

        private void btnDictaminacion_Click(object sender, EventArgs e)
        {
            FrmSolicitudes_instalacion frm = new FrmSolicitudes_instalacion();
            frm.ShowDialog();
        }
    }
}



