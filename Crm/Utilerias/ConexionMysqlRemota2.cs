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
    static class ConexionMysqlRemota2
    {

        private static MySqlConnection conexionRemota2;
        //private static MySqlConnection conexion;
        private static MySqlTransaction transaccionglobalRemota2;
        public static string msjError3 = "Error";
        public static string msjAdvertencia = "Advertencia!";
        public static string msjInfo = "Información";
        public static string msjPregunta = "?";
        
        
        //CONEXION TEMPORAL A LA BASE DE DATOS
        public static Boolean conecta()
        {
            try
            {
                conexionRemota2 = new MySqlConnection();

                Clave er = new Clave();
                //string cadenaconex = "Server=localhost;Database=bdEstacionamiento; Uid=root;Pwd=toor;";
               // string cadenaconex = "Database=siig;Data Source=189.220.227.186;User Id=crm_volcanes;Password=MyCRM_Volc_16";
               
                string cadenaconex = er.remota2();
                conexionRemota2.ConnectionString = cadenaconex;
                conexionRemota2.Open();
                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public static Boolean conecta(string server,string nombrebd,string usuario,string pass)
        {
            try
            {
                conexionRemota2 = new MySqlConnection();
                //string cadenaconex = "Server=localhost;Database=bdEstacionamiento; Uid=root;Pwd=toor;";
                string cadenaconex = "Database=" + nombrebd + ";Data Source=" + server + ";User Id=" + usuario + ";Password=" + pass + "";
                conexionRemota2.ConnectionString = cadenaconex;
                conexionRemota2.Open();
                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Boolean cierraConexion()
        {
            try
            {
                conexionRemota2.Close();
                conexionRemota2 = null;
                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cerrar la conexion con la base de datos ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Boolean insUpd(string consultasql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = consultasql;
                comando.CommandType = CommandType.Text;
                comando.Connection = conexionRemota2;
                comando.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar insUpd(..)->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                comando.Connection = conexionRemota2;
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
                MessageBox.Show("Error al ejecutar insUpdImagen(..)->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                comando.Connection = conexionRemota2;
                comando.CommandText = sql;
                //comando.Transaction = transaccionglobal;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(datos,tabla);
                //return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar la consulta llenaDataset(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return dt;
            }
        }

        public static void llenaDataset(ref DataSet datos, string sql)
        {
            try
            {
              
                MySqlCommand comando = new MySqlCommand();
                comando.CommandTimeout=0;
                comando.Connection = conexionRemota2;
                comando.CommandText = sql;
                //comando.Transaction = transaccionglobal;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(datos);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar la consulta llenaDataset(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                comando.Connection = conexionRemota2;
                comando.CommandText = sql;
                //comando.Transaction = transaccionglobal;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (MySqlException ex)
            {
               MessageBox.Show("Error al ejecutar la consulta llenaDataTable(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string regresaCampoConsulta(string sql)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexionRemota2;
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
                MessageBox.Show("Error al ejecutar la consulta regresaCampoConsulta(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public static string insUpd_transaccion(string sql)
        {
            try
            {
                if (transaccionglobalRemota2 == null)
                {
                    transaccionglobalRemota2 = conexionRemota2.BeginTransaction();
                }
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexionRemota2;
                comando.CommandText = sql;
                object obj = comando.ExecuteScalar();
                if (obj == null)
                    return "";
                else
                    return obj.ToString();
            }
            catch (MySqlException ex)
            {
                transaccionglobalRemota2.Rollback();
                transaccionglobalRemota2 = null;
                MessageBox.Show("Error al ejecutar insUpd_transaccion(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        public static void transCompleta()
        {
            try{
                transaccionglobalRemota2.Commit();
                transaccionglobalRemota2= null;
            }
            catch(MySqlException ex){
                MessageBox.Show("Error al ejecutar transCompleta(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void transErronea()
        {
            try
            {
                transaccionglobalRemota2.Rollback();
                transaccionglobalRemota2 = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar transErronea(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                comando.Connection = conexionRemota2;
                comando.CommandText = sql;
                object obj = comando.ExecuteScalar();
                if (obj == null)
                    return "";
                else
                    return obj.ToString();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al ejecutar insUpd_regresavalor(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        public static void llenaCombo(ref ComboBox cmb, string sql, string valuemember, string displaymember)
        {
            DataSet dts = new DataSet();
            try
            {
                MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexionRemota2);
                adaptador.Fill(dts);
                cmb.ValueMember = valuemember;
                cmb.DisplayMember = displaymember;
                cmb.DataSource = dts.Tables[0];
                dts = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al llenar llenaCombo(..) ->" + ex.Message, msjError3, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dts = null;
            }
        }
    }
}
