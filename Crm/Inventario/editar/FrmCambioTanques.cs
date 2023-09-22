using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crm.Inventario.editar
{
    public partial class FrmCambioTanques : Form
    {
        public FrmCambioTanques()
        {
            InitializeComponent();
        }
        public string no_lote, no_cliente, tipo, id_lote = "";

        string id_new_name, name_table, campo_id_granelF, campo_idtanque = "";

        DataSet dtsTanques;

        private void FrmCambioTanques_Load(object sender, EventArgs e)
        {
            addTablaTanques();
            BtnCambioNombre.Visible = false;


            if (tipo == "fabrica")
            {

                this.Text = no_cliente + "Granel Fabrica Cambio de tanque";
                name_table = "granel_tanques";   campo_id_granelF = "id_granel_entrada";

                // campo_idtanque = "id_tanque";
                // id_granel_entrada;


            }
            else if (tipo == "g_envasado")
            {
                this.Text = "Granel Envasado Cambio de tanque";
                name_table = "granel_tanques_envasado"; campo_id_granelF = "id_granel_entrada_envasado";

            }
            else if (tipo == "almacen")
            {
                this.Text = "Almacen Cambio de tanque";
                name_table = "almacen_granel_tanques"; campo_id_granelF = "id_almacen_granel_entrada";
            }


            lblNoLoteActual.Text = no_lote;


            DataSet Datos = new DataSet();
            Utilerias.ConexionMysql.llenaDataset(ref Datos, "SELECT id_tanque," + campo_id_granelF + " as id_granel_entrada,tanque, id_verificador FROM " + name_table + " WHERE " + campo_id_granelF + "='" + id_lote + "'");

            DataRow fila;
            dtsTanques.Tables["TANQUES"].Rows.Clear();
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                fila = dtsTanques.Tables["TANQUES"].NewRow();
                fila["ID_TANQUE"] = Convert.ToString(row["id_tanque"]);
                fila["ID_GRANEL"] = Convert.ToString(row["id_granel_entrada"]);
                fila["TANQUE"] = Convert.ToString(row["tanque"]);
                fila["QUITAR"] = FrmInventario.ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                fila["BORRO"] = "0";
                dtsTanques.Tables["TANQUES"].Rows.Add(fila);
            }


        }


        private void addTablaTanques()
        {
            dtsTanques = new DataSet();
            dtsTanques.Tables.Add("TANQUES");
            dtsTanques.Tables["TANQUES"].Columns.Add("ID_TANQUE", Type.GetType("System.String"));
            dtsTanques.Tables["TANQUES"].Columns.Add("ID_GRANEL", Type.GetType("System.String"));
            dtsTanques.Tables["TANQUES"].Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanques.Tables["TANQUES"].Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            dtsTanques.Tables["TANQUES"].Columns.Add("BORRO", Type.GetType("System.String"));
            DtaTanques.DataSource = dtsTanques.Tables["TANQUES"];
            DtaTanques.Columns[0].Visible = false;
            DtaTanques.Columns[1].Visible = false;
            DtaTanques.Columns[4].Visible = false;


        }



        private void DtaTanques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaTanques.Columns[e.ColumnIndex].Name == "QUITAR")
                {


                    if (Convert.ToString(DtaTanques.Rows[e.RowIndex].Cells[0].Value) == "")
                    {

                        // DtaTanques.Rows().Visible = true;

                        DtaTanques.Rows.RemoveAt(e.RowIndex);
                        dtsTanques.Tables["TANQUES"].AcceptChanges();
                        ///--- el for recorre el datagridview y corrovora que tengan el valor de 1 en la columna Borro y los oculta 
                        for (int x = 0; x < DtaTanques.Rows.Count; x++)
                        {
                            if (Convert.ToString(DtaTanques.Rows[x].Cells[4].Value) == "1")
                            {
                                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DtaTanques.DataSource];
                                currencyManager1.SuspendBinding();
                                DtaTanques.Rows[x].Visible = false;
                                currencyManager1.ResumeBinding();

                            }
                        }///--- fin del for

                    }
                    else
                    {




                        DtaTanques.Rows[e.RowIndex].Cells[4].Value = "1";

                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DtaTanques.DataSource];
                        currencyManager1.SuspendBinding();
                        DtaTanques.Rows[e.RowIndex].Visible = false;
                        currencyManager1.ResumeBinding();
                        //int fila = this.DtaTanques.CurrentRow.Index;


                    }


                }
                else if (DtaTanques.Columns[e.ColumnIndex].Name == "TANQUE")
                {

                    DialogResult check = MessageBox.Show("¿¡Cambiar nombre del tanque!?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (check == DialogResult.Cancel) { return; }
                    else
                    {
                        // MessageBox.Show("el nombre del tanque es : "+DtaTanques.CurrentCell.Value.ToString());

                        TxtTanque.Text = DtaTanques.CurrentCell.Value.ToString();
                        BtnCambioNombre.Visible = true;
                        BtnGuardar.Visible = false;

                        id_new_name = DtaTanques.CurrentRow.Index.ToString(); //--obtiene el valor de la fila 

                        if (Convert.ToString(DtaTanques.Rows[e.RowIndex].Cells[0].Value) != "")
                        {
                            DtaTanques.Rows[e.RowIndex].Cells[4].Value = "2";
                        }


                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            try
            {

                int s = 0;
                for (int x = 0; x < DtaTanques.Rows.Count; x++)
                {
                    if (Convert.ToString(DtaTanques.Rows[x].Cells[4].Value) == "1")
                    {
                        s++;
                    }
                }

                if (s == DtaTanques.Rows.Count)
                {
                    MessageBox.Show("El valor esta vacio, No se puede quedar sin No de tanque");

                    return;
                }


                for (int x = 0; x < DtaTanques.Rows.Count; x++)
                {
                    if (Convert.ToString(DtaTanques.Rows[x].Cells[4].Value) == "1")
                    {

                        if (Utilerias.ConexionMysql.insUpd_transaccion("UPDATE "+name_table+" SET "+campo_id_granelF+"='" + DtaTanques.Rows[x].Cells["ID_GRANEL"].Value + "-borro', actualizado=0 WHERE id_tanque='" + DtaTanques.Rows[x].Cells["ID_TANQUE"].Value + "';") == "Error")
                            return;

                    } if (Convert.ToString(DtaTanques.Rows[x].Cells[4].Value) == "2")
                    {

                        if (Utilerias.ConexionMysql.insUpd_transaccion("UPDATE " + name_table + " SET tanque='" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "', actualizado=0 WHERE id_tanque='" + DtaTanques.Rows[x].Cells["ID_TANQUE"].Value + "';") == "Error")
                            return;

                    }
                    else if (Convert.ToString(DtaTanques.Rows[x].Cells[0].Value) == "" && Convert.ToString(DtaTanques.Rows[x].Cells[4].Value) == "0")
                    {

                        string id_max_granel_tanque = "";
                        if (tipo == "fabrica")
                        {
                            id_max_granel_tanque = functions.IdMaximo.ObtenerIdMaximoGraneTanque();
                                }
                        else if (tipo == "g_envasado")
                        {
                            id_max_granel_tanque = functions.IdMaximo.ObtenerIdMaximoGranelTanqueEnvasado();

                        }
                        else if (tipo == "almacen")
                        {
                            id_max_granel_tanque = functions.IdMaximo.ObtenerIdMaximoAlmacenGranelTanque();
                        }


                        if (Utilerias.ConexionMysql.insUpd_transaccion("INSERT INTO "+name_table+"(id_tanque, " + campo_id_granelF + ", tanque, id_verificador, actualizado) VALUES('" + id_max_granel_tanque + "','" + id_lote + "','" + DtaTanques.Rows[x].Cells["TANQUE"].Value + "'," + Utilerias.Usuario.IdUsuario + ",0);") == "Error")
                            return;





                    }
                }//-- fin del for --
                Utilerias.ConexionMysql.transCompleta();
                MessageBox.Show("Exito");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }



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
                fila["QUITAR"] = FrmInventario.ConvertImageToByteArray(Properties.Resources.delete, System.Drawing.Imaging.ImageFormat.Png);
                fila["BORRO"] = "0";
                dtsTanques.Tables["TANQUES"].Rows.Add(fila);
                TxtTanque.Text = "";
                ///--- el for recorre el datagridview y corrovora que tengan el valor de 1 en la columna Borro y los oculta 
                for (int x = 0; x < DtaTanques.Rows.Count; x++)
                {
                    if (Convert.ToString(DtaTanques.Rows[x].Cells[4].Value) == "1")
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DtaTanques.DataSource];
                        currencyManager1.SuspendBinding();
                        DtaTanques.Rows[x].Visible = false; ///-- oculta una fila
                        currencyManager1.ResumeBinding();

                    }

                }/// --- fin del for
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCambioNombre_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (e.RowIndex < 0)
                    return;*/
                // DtaTanques.CurrentCell(2).Value = TxtTanque.Text;
                /* for (int x = 0; x < DtaTanques.Rows.Count; x++)
                 {
                     if (Convert.ToString(DtaTanques.Rows[x].Cells[4].Value) == "1")
                     {
                         CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[DtaTanques.DataSource];
                         currencyManager1.SuspendBinding();
                         DtaTanques.Rows[x].Visible = false; /// -- oculta una fila
                         currencyManager1.ResumeBinding();

                     }

               

                 }*/
                // --- fin del for
                //DtaTanques.Rows[Convert.ToInt32(id_new_name)].Cells[4].Value = "2";


                DtaTanques.Rows[Convert.ToInt32(id_new_name)].Cells[2].Value = TxtTanque.Text;
                // DtaTanques.Rows[Convert.ToInt32(id_new_name)].Cells[4].Value = "2";

                BtnCambioNombre.Visible = false;
                BtnGuardar.Visible = true;

                TxtTanque.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


    }
}
