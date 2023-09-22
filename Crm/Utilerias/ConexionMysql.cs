using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using clvdb;

namespace Crm.Utilerias
{
    static class ConexionMysql
    {

        private static MySqlConnection conexion;
        //private static MySqlConnection conexion;
        private static MySqlTransaction transaccionglobal;
        public static string msjError = "Error";
        public static string msjAdvertencia = "Advertencia!";
        public static string msjInfo = "Información";
        public static string msjPregunta = "?";
           
        //CONEXION TEMPORAL A LA BASE DE DATOS
        public static Boolean conecta()
        {
            try
            {



                conexion = new MySqlConnection();

                Clave er = new Clave();

                //string cadenaconex = "Server=localhost;Database=bdEstacionamiento; Uid=root;Pwd=toor;";
                //string cadenaconex = "Database=reveca;Data Source=localhost;User Id=root;Password=MyCRMSql15";
                //MyCRMSql15
                //reveca3

                string cadenaconex = er.rvkpass();
                conexion.ConnectionString = cadenaconex;
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public static Boolean conecta(string server,string nombrebd,string usuario,string pass)
        {
            try
            {
                conexion = new MySqlConnection();
                //string cadenaconex = "Server=localhost;Database=bdEstacionamiento; Uid=root;Pwd=toor;";
                string cadenaconex = "Database=" + nombrebd + ";Data Source=" + server + ";User Id=" + usuario + ";Password=" + pass + "";
                conexion.ConnectionString = cadenaconex;
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Boolean cierraConexion()
        {
            try
            {
                conexion.Close();
                conexion = null;
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cerrar la conexion con la base de datos ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Boolean insUpd(string consultasql)
        {//-- puede utilizarse para ejecutar multiples operaciones en la base de datos--
        
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = consultasql;
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar insUpd(..)->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Boolean insUpdImagen(string nombreProc, string nombreParametros, string valorParametros, string nombreParametroImagen, string nombreParametroImagen2, byte[] imagen, byte[] imagen2)
        {
            // este proc se utiliza para una imagen ,en parametros solo manda el de una imagen
            //try
            //{
            //    string[] nombreParametro = nombreParametros.Split(',');
            //    string[] valorParametro = valorParametros.Split(',');
            //    MySqlCommand comando = new MySqlCommand();
            //    comando.Connection = conexion;
            //    comando.CommandText = nombreProc;
            //    comando.CommandType = CommandType.StoredProcedure;
            //    //comando.CommandText = nombreProc;
            //    for (int x = 0; x <= nombreParametro.Length - 1; x++)
            //    {
            //        comando.Parameters.AddWithValue(nombreParametro[x], valorParametro[x]);
            //    }
            //    //comando.Parameters.Add(nombreParametroImagen,SqlDbType.Image).Value = imagen;
            //    comando.Parameters.AddWithValue(nombreParametroImagen, imagen);

            //    comando.ExecuteNonQuery();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al ejecutar insUpdImagen(..)->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            try
            {
                string[] nombreParametro = nombreParametros.Split(',');
                string[] valorParametro = valorParametros.Split(',');
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandText = nombreProc;
                comando.CommandType = CommandType.StoredProcedure;
                //comando.CommandText = nombreProc;
                for (int x = 0; x <= nombreParametro.Length - 1; x++)
                {
                    comando.Parameters.AddWithValue(nombreParametro[x], valorParametro[x]);
                }
                //comando.Parameters.Add(nombreParametroImagen,SqlDbType.Image).Value = imagen;
                comando.Parameters.AddWithValue(nombreParametroImagen, imagen);
                comando.Parameters.AddWithValue(nombreParametroImagen2, imagen2);

                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar insUpdImagen(..)->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //public static Boolean insUpdImagen(string nombreProc, string nombreParametros, string valorParametros)
        //{
        //    try
        //    {
        //        string[] nombreParametro = nombreParametros.Split(',');
        //        string[] valorParametro = valorParametros.Split(',');
        //        MySqlCommand comando = new MySqlCommand();
        //        comando.Connection = conexion;
        //        comando.CommandText = nombreProc;
        //        comando.CommandType = CommandType.StoredProcedure;
        //        //comando.CommandText = nombreProc;
        //        for (int x = 0; x <= nombreParametro.Length - 1; x++)
        //        {
        //            comando.Parameters.AddWithValue(nombreParametro[x], valorParametro[x]);
        //        }
        //        //comando.Parameters.Add(nombreParametroImagen,SqlDbType.Image).Value = imagen;
        //        comando.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al ejecutar insUpdImagen(..)->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        public static void llenaDataset(ref DataSet datos, string sql, string tabla)
        {
            //DataSet dt = new DataSet();
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                //Se agrega para que el tiempo de ejecucion de consulta no afecte al mostrar datos, el valor por default sin la linea es de 30 segundos, 0 significa sin limite de tiempo
                comando.CommandTimeout = 100000;
                comando.CommandText = sql;
                //comando.Transaction = transaccionglobal;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(datos,tabla);
                //return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar la consulta llenaDataset(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return dt;
            }
        }

        public static void llenaDataset(ref DataSet datos, string sql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                //Se agrega para que el tiempo de ejecucion de consulta no afecte al mostrar datos, el valor por default sin la linea es de 30 segundos, 0 significa sin limite de tiempo
                comando.CommandTimeout = 100000;
                comando.CommandText = sql;
                //MessageBox.Show(sql);
                //comando.Transaction = transaccionglobal;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(datos);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar la consulta llenaDataset(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public static DataSet llenaDataset(DataSet dts,string sql, string nombretabla = "Tabla")
        //{
        //    try
        //    {
        //        MySqlCommand comando = new MySqlCommand();
        //        comando.Connection = conexion;
        //        comando.CommandText = sql;
        //        //comando.Transaction = transaccionglobal;
        //        MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
        //        adaptador.Fill(dts, nombretabla);
        //        return dts;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Error al ejecutar la consulta llenaDataset_sql(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return dts;
        //    }
        //}

        public static void llenaDataTable(ref DataTable tabla,string sql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandText = sql;
                //comando.Transaction = transaccionglobal;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (MySqlException ex)
            {
               MessageBox.Show("Error al ejecutar la consulta llenaDataTable(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string regresaCampoConsulta(string sql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandText = sql;
                object obj = comando.ExecuteScalar();
                if (obj == null)
                {
                    return "";
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar la consulta regresaCampoConsulta(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public static string insUpd_transaccion(string sql)
        {
            try   
            {
                //MessageBox.Show(sql);
                if (transaccionglobal == null)
                {
                    transaccionglobal = conexion.BeginTransaction();
                }
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandText = sql;
                //MessageBox.Show(sql);
                object obj = comando.ExecuteScalar();
                if (obj == null)
                    return "";
                else
                    return obj.ToString();
            }
            catch (MySqlException ex)
            {
                transaccionglobal.Rollback();
                transaccionglobal = null;
                MessageBox.Show("Error al ejecutar insUpd_transaccion(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        public static void transCompleta()
        {
            try
            {
                transaccionglobal.Commit();
                transaccionglobal = null;
            }
            catch(MySqlException ex){
                transaccionglobal.Rollback();
                transaccionglobal = null;
                MessageBox.Show("Error al ejecutar transCompleta(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*finally
            {
                //conexion.Close();
                cierraConexion();
            }*/
        }


        public static string transCompleta2()
        {
            try
            {
                transaccionglobal.Commit();
                transaccionglobal = null;
                return "Ok";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar transCompleta(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                transaccionglobal.Rollback();
                transaccionglobal = null;
                return "Error";
            }
            /*finally
            {
                //conexion.Close();
                cierraConexion();
            }*/
        }

        public static void transErronea()
        {
            try
            {
                transaccionglobal.Rollback();
                transaccionglobal = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar transErronea(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void cualquiera()
        //{
        //    try{

        //    }
        //    catch(MySqlException ex){
        //        throw new Exception(ex.Message,ex.InnerException);
        //    }
        //}

        public static string insUpd_regresavalor(string sql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandText = sql;
                object obj = comando.ExecuteScalar();
                if (obj == null)
                    return "";
                else
                    return obj.ToString();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar insUpd_regresavalor(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        public static void llenaCombo(ref ComboBox cmb, string sql, string valuemember, string displaymember)
        {
            DataSet dts = new DataSet();
            try
            {

                
                MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexion);
                adaptador.Fill(dts);
                cmb.ValueMember = valuemember;
                cmb.DisplayMember = displaymember;
                cmb.DataSource = dts.Tables[0];
                dts = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al llenar llenaCombo(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dts = null;
            }
        }
        public static void llenaComboAutocomplit(ref ComboBox cmb, string sql, string valuemember, string displaymember)
        {

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
               
            //AutoCompleteStringCollection ListaLotes = new AutoCompleteStringCollection();
            //DataSet dts = new DataSet();
           DataTable dts = new DataTable();
            try
            {
                
                MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexion);
                adaptador.Fill(dts);
                //cmb.ValueMember = valuemember;
               // cmb.DisplayMember = displaymember;
                //cmb.DataSource = dts.Tables[0];
                //dts = null;
                
          
                foreach (DataRow row in dts.Rows)
                {
                   
                    stringCol.Add(Convert.ToString(row[displaymember]));
                   // stringCol.Add(Convert.ToString(row[valuemember]));

                 //   stringCol.Add(row[0].ToString());
          
                }
                 
             
                              
              
                cmb.DisplayMember = displaymember;
                cmb.ValueMember = valuemember;
                cmb.DataSource = dts;

              
               // cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                /*  
                 estos valires se agregaron al control desde propiedades en el diseño
                 * AutoCompleteSource.CustomSource;
                 * AutoCompleteSource.AllSystemSources;
                para evitarnos problemillas
                 
                 */
                //cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
               //cmb.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
               cmb.AutoCompleteCustomSource = stringCol; //--Contiene los datos de el autocompletar


               //dts = null;
               //stringCol = null;
                //return stringCol;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al llenar llenaCombo(..) ->" + ex.Message, msjError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dts = null;
                stringCol = null;
            }
            
        }

      

    }
}
