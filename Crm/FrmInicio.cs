using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Crm.Utilerias;
using Crm.Inicio;
using System.Globalization;
namespace Crm
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();

        }

        string contraseniaAleatoria = string.Empty;
        private void CleanUserPass()
        {
            txtUsuario.Text = "";
            txtContra.Text = "";


        }


        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }


        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Check_Login() == true)
                {

                    if (txtUsuario.Text == "USUARIO" || txtContra.Text =="CONTRASEÑA") 
                    {

                        MessageBox.Show("has dejado campos vacios");

                        return;
                    
                    
                    }

                    DataSet datos = new DataSet();
                    //string cadena = ConexionMysql.regresaCampoConsulta("CALL FIND_USUARIOLOGUEADO('"+txtUsuario.Text.Trim()+"');");
                    ConexionMysql.llenaDataset(ref datos, "SELECT * FROM verificadores WHERE login='" + txtUsuario.Text.Trim() + "' and status != 0 ;");

                    if (datos.Tables.Count == 0)
                        return;

                    if (datos.Tables[0].Rows.Count == 0)
                        return;

                    Usuario.IdUsuario = datos.Tables[0].Rows[0]["id_us"].ToString();
                    Usuario.NombreUsuario = datos.Tables[0].Rows[0]["nombre"].ToString();



                    datos.Tables[0].Rows.Clear();

                    //-- selecciona el estatus del usuario
                    Usuario.Status = Convert.ToString(ConexionMysql.regresaCampoConsulta("SELECT status FROM verificadores WHERE id_us='" + Usuario.IdUsuario + "' and status != 0 "));
                    
                    CleanUserPass();
                    txtContra_Leave(sender, e);
                    txtUsuario_Leave(sender,e);


                    ConexionMysql.cierraConexion();
                    this.Visible = false;

                    FrmPrincipal MenuPrincipal = new FrmPrincipal();
                    MenuPrincipal.ShowDialog();

                    if (MenuPrincipal.BanderaUsuario == true)
                    {
                        this.Show();
                        ConexionMysql.conecta();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (Nuevos_Usuarios() == true)
                {
                    MessageBox.Show("Intente nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                                       
                    CleanUserPass();
                    txtContra_Leave(sender, e);
                    txtUsuario_Leave(sender, e);

                    MessageBox.Show("Datos incorrectos\nIntente Nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActualizaVerificadores();
                    txtUsuario.Focus();
                }
            }//END TRY
            catch (Exception ex)
            {
                MessageBox.Show("Error en el login " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//END CATCH
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            ConexionMysql.conecta();
     
            this.KeyPreview = true;
           
        }

        public Boolean Check_Login()
        {
            try
            {
                string contra = GetMD5(txtContra.Text.Trim());
                string respuesta = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM verificadores WHERE login='" + txtUsuario.Text.Trim() + "' AND password='" + contra + "' ");
                //changePass();
                if (respuesta != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el CHECH_LOGIN" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public Boolean Nuevos_Usuarios()
        {
            try
            {
                ConexionMysqlRemota2.conecta();
                string id_max_local = ConexionMysql.regresaCampoConsulta("SELECT max(id_us) AS id_v FROM verificadores");
                if (id_max_local == "")
                {
                    id_max_local = "0";
                }
                string sep = "";
                string values = "";
                string sql_ins = "INSERT INTO verificadores (id_us, nombre, dpto, login, password, cve_us, status) VALUES";
                DataSet NuevosUsuarios = new DataSet();
                ConexionMysqlRemota2.llenaDataset(ref NuevosUsuarios, "select * from verificadores where id_us>" + id_max_local + "");
                if (NuevosUsuarios.Tables[0].Rows.Count == 0)
                {
                    return false;
                }
                foreach (DataRow row in NuevosUsuarios.Tables[0].Rows)
                {
                    string id_us = Convert.ToString(row["id_us"]);
                    string nombre = Convert.ToString(row["nombre"]);
                    string dpto = Convert.ToString(row["dpto"]);
                    string login = Convert.ToString(row["login"]);
                    string password = Convert.ToString(row["password"]);
                    string cve_us = Convert.ToString(row["cve_us"]);
                    string status = Convert.ToString(row["status"]);

                    values += sep + "(" + id_us + ",'" + nombre + "','" + dpto + "','" + login + "','" + password + "','" + cve_us + "','" + status + "')";
                    sep = ",";
                }
                sql_ins += values + ";";
                if (ConexionMysql.insUpd_transaccion(sql_ins) == "Error")
                    return false;
                ConexionMysql.transCompleta();
                ConexionMysqlRemota2.cierraConexion();
                return true;
            }
            catch (Exception ex)
            {
                ConexionMysqlRemota2.cierraConexion();
                MessageBox.Show("Error en cargar nuevos usuarios.." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void FrmInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                BtnIniciar_Click(sender, e);
            }
        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }

        public Boolean ActualizaVerificadores()
        {
            /*este metodo tambien esta al momento de actualizar la información. pero aqui sirve por si se actulizo la contraseña, al momento de ingresar los nuevos datos y se mande un mensaje*/
            try
            {
                Console.WriteLine("actualiza verificadores si no esta correcto el password");
                string sep = "";
                string values = "";
                string sql = "INSERT INTO verificadores (id_us, nombre, dpto, login, password, cve_us, status,actualizado) VALUES";
                Boolean bandera_insert = false;
                Boolean bandera_update = false;
                DataSet datos = new DataSet();

                ConexionMysqlRemota2.llenaDataset(ref datos, "SELECT id_us, nombre, dpto, login, password, cve_us, status,actualizado from verificadores ");

               
                if (datos.Tables[0].Rows.Count == 0)
                {
                    return true;
                }
                foreach (DataRow row in datos.Tables[0].Rows) // itera los registros de la consulta remota de verificadores
                {
                    string id = ConexionMysql.regresaCampoConsulta("select id_us from verificadores where id_us='" + Convert.ToString(row["id_us"]) + "'");

                    if (id != "") // si encontro una conincidencia del id entonces solo debe de actualizar los datos
                    {
                        if (Convert.ToString(row["actualizado"]) == "0") // if campo actualizado en bd remota es actualizado=0
                        {
                            bandera_update = true;
                            //id_us, nombre, dpto, login, password, cve_us, status
                            if (ConexionMysql.insUpd_transaccion("UPDATE verificadores SET nombre='" + Convert.ToString(row["nombre"]) + "', dpto='" + Convert.ToString(row["dpto"]) + "', login='" + Convert.ToString(row["login"]) + "', password='" + Convert.ToString(row["password"]) + "', cve_us='" + Convert.ToString(row["cve_us"]) + "', status='" + Convert.ToString(row["status"]) + "' WHERE id_us='" + Convert.ToString(row["id_us"]) + "' ") == "Error")
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

                        values += sep + "('" + id_us + "','" + nombre + "','" + dpto + "','" + login + "','" + password + "','" + cve_us + "','" + status + "',1)";
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

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "USUARIO"){

                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;

            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text==""){
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DarkSeaGreen;


            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {

            if (txtContra.Text == "CONTRASEÑA")
            {

                txtContra.Text = "";
                txtContra.ForeColor = Color.White;
                txtContra.UseSystemPasswordChar = true;


            }

        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DarkSeaGreen;
                txtContra.UseSystemPasswordChar = false;



            }

        }

      //TODO: metodo para generar contraseñas de manera aleatoria
        public void generateNewPass()
        {
            Random rndm = new Random();
            string simbolos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@!*";
            int longitud = simbolos.Length;
            char letra;
            int longitudContrasenia = 10;
            //string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = simbolos[rndm.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
                
            }
            //La contraseña es: r%CAdeZ07l
        }

        public void changePass()
        {
            // TODO: VALIDAR SI HAN PASADO 36 horas SIN DESCARGA PARA QUE NO PUEDA ENTRAR Y CAMBIAR LA CONTRASEÑA
            #region METODO ANTES DE VALIDARLO MÁS
            /*
            string pass = GetMD5(txtContra.Text.Trim());
            string nombreUser = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM verificadores WHERE login='" + txtUsuario.Text.Trim() + "' AND password='" + pass + "' ");

            string feUltimaDes = ConexionMysql.regresaCampoConsulta("select date_format(Fecha, '%d/%m/%Y %H:%i') as fechaUltimaDescarga FROM fecha_ultima_descarga");
            DateTime fechaUD = Convert.ToDateTime(feUltimaDes);
            DateTime fechaActual = DateTime.Now;
            TimeSpan difFechas = fechaActual - fechaUD;
            Double horas = difFechas.TotalHours;
            generateNewPass();
            string passnew = GetMD5(contraseniaAleatoria);//contraseniaAleatoria;

            if (horas > 36)
            {
                ConexionMysql.insUpd_transaccion(" UPDATE verificadores SET password = '" + passnew + "' WHERE nombre like '" + nombreUser + "' ");
                ConexionMysql.transCompleta();
                MessageBox.Show("Tu contraseña ha sido cambiada");
                this.Close();
            }*/
            #endregion

            
            string pass = GetMD5(txtContra.Text.Trim());
            string nombreUser = ConexionMysql.regresaCampoConsulta("SELECT nombre FROM verificadores WHERE login='" + txtUsuario.Text.Trim() + "' AND password='" + pass + "' ");

            string feUltimaDes = ConexionMysql.regresaCampoConsulta("select date_format(Fecha, '%d/%m/%Y %H:%i') as fechaUltimaDescarga FROM fecha_ultima_descarga");
            DateTime fechaUD = Convert.ToDateTime(feUltimaDes);
            DateTime fechaActual = DateTime.Now;
            int dia = Convert.ToInt32(fechaUD.DayOfWeek);
            TimeSpan difFechas = fechaActual - fechaUD;
            Double horas = difFechas.TotalHours;

            if (dia > 5)
            {
                if (horas > 48)
                {
                    generateNewPass();
                    string passnew = GetMD5(contraseniaAleatoria);//contraseniaAleatoria;
                    ConexionMysql.insUpd_transaccion(" UPDATE verificadores SET password = '" + passnew + "' WHERE nombre like '" + nombreUser + "' ");
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Tu contraseña ha sido cambiada");
                    this.Close();
                }

            }
            else
                if (dia <= 5)
            {
                if (horas > 35)
                {
                    generateNewPass();
                    string passnew = GetMD5(contraseniaAleatoria);//contraseniaAleatoria;
                    ConexionMysql.insUpd_transaccion(" UPDATE verificadores SET password = '" + passnew + "' WHERE nombre like '" + nombreUser + "' ");
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Tu contraseña ha sido cambiada");
                    this.Close();
                }

            }
        }
    }

}