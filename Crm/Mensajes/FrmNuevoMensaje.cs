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

namespace Crm.Mensajes
{
    public partial class FrmNuevoMensaje : Form
    {
        public FrmNuevoMensaje()
        {
            InitializeComponent();
        }

        private void FrmNuevoMensaje_Load(object sender, EventArgs e)
        {
            PanelProduccion.Visible = true;
            PanelGranel.Visible = false;
            PanelEnvasado.Visible = false;
            PanelMensaje.Visible = false;
            ConexionMysql.conecta();
            ConexionMysql.llenaCombo(ref CmbNoClienteProduccion, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
        }
        //------------------------------------==================================\\--------PRODUCCION-----------//==================================----------------------------------
        private void BtnProduccion_Click(object sender, EventArgs e)
        {
            PanelProduccion.Visible = true;
            PanelGranel.Visible = false;
            PanelEnvasado.Visible = false;
            PanelMensaje.Visible = false;
            ConexionMysql.llenaCombo(ref CmbNoClienteProduccion, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
        }

        private void CmbNoClienteProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbFabricaProduccion.DataSource = null;
            CmbTapada.DataSource = null;
            TxtMaestroMezcaleroProduccion.Text = "";
            ConexionMysql.llenaCombo(ref CmbFabricaProduccion, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteProduccion.SelectedValue + "'", "id_fabrica", "fabrica");
        }


        private void CmbFabricaProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFabricaProduccion.SelectedValue != null)
            {
                TxtMaestroMezcaleroProduccion.Text = ConexionMysql.regresaCampoConsulta("SELECT maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabricaProduccion.SelectedValue + "'");
                ConexionMysql.llenaCombo(ref CmbTapada, "SELECT  CONCAT('Tapada : ',tapada,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico) As produccion,id_produccion_entrada   FROM produccion_entrada  where id_fabrica='" + CmbFabricaProduccion.SelectedValue + "' and estatus=5 AND lts_existentes > 0  order by id_produccion_entrada asc", "id_produccion_entrada", "produccion");
            }
          
        }

        private void BtnMensajeProduccion_Click(object sender, EventArgs e)
        {
            if (CmbTapada.SelectedValue == null)
            {
                MessageBox.Show("No tienes tapadas para reportar");
                return;
            }
            if (TxtObservacionesProduccion.Text == "")
            {
                MessageBox.Show("Escribe una observación");
                TxtObservacionesProduccion.Focus();
                return;
            }

            if (ConexionMysql.insUpd_transaccion("INSERT INTO mensajes (id_prod,tipo,mensaje,id_verificador,actualizado) VALUES ('" + CmbTapada.SelectedValue + "','Produccion','"+TxtObservacionesProduccion.Text+"',"+Usuario.IdUsuario+",0)") == "Error")
            {
                return;
            }

            ConexionMysql.transCompleta();
            MessageBox.Show("Gracias por tu mensaje");
            this.Close();
        }
        //------------------------------------==================================\\--------FIN PRODUCCION-----------//==================================----------------------------------


        //------------------------==============================================\\------------GRANEL---------------//======================================------------------------------------------
        private void BtnGranel_Click(object sender, EventArgs e)
        {
            LblEnvasadora.Visible = false;
            CmbEnvasadoraGranel.Visible = false;
            RbtnFabrica.Checked = true;
            PanelProduccion.Visible = false;
            PanelGranel.Visible = true;
            PanelEnvasado.Visible = false;
            PanelMensaje.Visible = false;
            ConexionMysql.llenaCombo(ref CmbNoClienteGranel, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
        }


        private void CmbNoClienteGranel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtMaestroMezcaleroGranel.Text = "";
            TxtResponsableEnvasadoraGranel.Text = "";
            CmbNoLote.DataSource = null;
            if (RbtnFabrica.Checked == true)
            {
                ConexionMysql.llenaCombo(ref CmbFabricaGranel, "SELECT fabrica,id_fabrica FROM maestro_fabrica where no_cliente='" + CmbNoClienteGranel.SelectedValue + "'", "id_fabrica", "fabrica");     
            }
            else
            {
                ConexionMysql.llenaCombo(ref CmbEnvasadoraGranel, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbNoClienteGranel.SelectedValue + "'", "id_envasadora", "envasadora");
            }
        }

        private void CmbFabricaGranel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFabricaGranel.SelectedValue != null)
            {
                CmbNoLote.DataSource = null;
                TxtMaestroMezcaleroGranel.Text = ConexionMysql.regresaCampoConsulta("SELECT maestro FROM  maestro_fabrica  WHERE id_fabrica='" + CmbFabricaGranel.SelectedValue + "'");
                ConexionMysql.llenaCombo(ref CmbNoLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + CmbFabricaGranel.SelectedValue + "'  AND lts_existentes > 0  order by id asc", "id_granel_entrada", "produccion");
            }
        }

        private void CmbEnvasadoraGranel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEnvasadoraGranel.SelectedValue != null)
            {
                CmbNoLote.DataSource =null;
                TxtResponsableEnvasadoraGranel.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + CmbEnvasadoraGranel.SelectedValue + "'");
                ConexionMysql.llenaCombo(ref CmbNoLote, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='" + CmbEnvasadoraGranel.SelectedValue + "'  AND lts_existentes > 0 order by id_granel_entrada_envasado asc", "id_granel_entrada_envasado", "produccion");

            }
        }


        private void BtnMensajeGranel_Click(object sender, EventArgs e)
        {
            if (CmbNoLote.SelectedValue == null)
            {
                MessageBox.Show("No tienes lotes para reportar");
                return;
            }
            if (TxtObservacionGranel.Text == "")
            {
                MessageBox.Show("Escribe una observación");
                TxtObservacionGranel.Focus();
                return;
            }

            if (RbtnFabrica.Checked == true)
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO mensajes (id_prod,tipo,mensaje,id_verificador,actualizado) VALUES ('" + CmbNoLote.SelectedValue + "','Granel Fabrica','" + TxtObservacionGranel.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                {
                    return;
                }
            }
            else
            {
                if (ConexionMysql.insUpd_transaccion("INSERT INTO mensajes (id_prod,tipo,mensaje,id_verificador,actualizado) VALUES ('" + CmbNoLote.SelectedValue + "','Granel Envasado','" + TxtObservacionGranel.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                {
                    return;
                }
            }
            ConexionMysql.transCompleta();
            MessageBox.Show("Gracias por tu mensaje");
            this.Close();

        }




        private void RbtnFabrica_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnFabrica.Checked == true)
            {
                LblEnvasadora.Visible = false;
                CmbEnvasadoraGranel.Visible = false;
                LblResponsable.Visible = false;
                TxtResponsableEnvasadoraGranel.Visible = false;
                LblFabrica.Visible = true;
                CmbFabricaGranel.Visible = true;
                LblMaestro.Visible = true;
                TxtMaestroMezcaleroGranel.Visible = true;
                CmbNoClienteGranel_SelectedIndexChanged(sender, e);
            }
            else
            {
                LblEnvasadora.Visible = true;
                CmbEnvasadoraGranel.Visible = true;
                LblResponsable.Visible = true;
                TxtResponsableEnvasadoraGranel.Visible = true;
                LblFabrica.Visible = false;
                CmbFabricaGranel.Visible = false;
                LblMaestro.Visible = false;
                TxtMaestroMezcaleroGranel.Visible = false;
                CmbNoClienteGranel_SelectedIndexChanged(sender, e);
            }
        }

        private void RbtnEnvasadora_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnFabrica.Checked == true)
            {
                LblEnvasadora.Visible = false;
                CmbEnvasadoraGranel.Visible = false;
                LblResponsable.Visible = false;
                TxtResponsableEnvasadoraGranel.Visible = false;

                LblFabrica.Visible = true;
                CmbFabricaGranel.Visible = true;
                LblMaestro.Visible = true;
                TxtMaestroMezcaleroGranel.Visible = true;
            }
            else
            {
                LblEnvasadora.Visible = true;
                CmbEnvasadoraGranel.Visible = true;
                LblResponsable.Visible = true;
                TxtResponsableEnvasadoraGranel.Visible = true;

                LblFabrica.Visible = false;
                CmbFabricaGranel.Visible = false;
                LblMaestro.Visible = false;
                TxtMaestroMezcaleroGranel.Visible = false;
            }
        }
        //------------------------==============================================\\------------FIN GRANEL---------------//======================================------------------------------------------




        //----------------------================================================\\-------ENVASADO-------------//=============================================-------------------------------------------
        private void BtnEnvasado_Click(object sender, EventArgs e)
        {
            PanelProduccion.Visible = false;
            PanelGranel.Visible = false;
            PanelEnvasado.Visible = true;
            PanelMensaje.Visible = false;
            ConexionMysql.llenaCombo(ref CmbClienteEnvasado, "SELECT no_cliente FROM rutas_clientes", "no_cliente", "no_cliente");
        }


        private void CmbClienteEnvasado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEnvasadora.DataSource = null;
            CmbNoLoteEnvasado.DataSource = null;
            TxtResponsableEnvasado.Text = "";
            ConexionMysql.llenaCombo(ref CmbEnvasadora, "SELECT envasadora,id_envasadora FROM envasadora_encargado where no_cliente='" + CmbClienteEnvasado.SelectedValue + "'", "id_envasadora", "envasadora");
        }


        private void CmbEnvasadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEnvasadora.SelectedValue != null)
            {
                CmbNoLoteEnvasado.DataSource = null;
                TxtResponsableEnvasado.Text = ConexionMysql.regresaCampoConsulta("SELECT encargado FROM  envasadora_encargado  WHERE id_envasadora='" + CmbEnvasadora.SelectedValue + "'");
                ConexionMysql.llenaCombo(ref CmbNoLoteEnvasado, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Bottelas : ',botellas_existentes,'   ','Grado alcoholico : ',grado_alcoholico) As produccion,id_envasado_entrada   FROM envasado_entrada  where id_envasadora='" + CmbEnvasadora.SelectedValue + "'  AND botellas_existentes > 0 order by id asc", "id_envasado_entrada", "produccion");

            }
        }


        private void BtnMensajeEnvasado_Click(object sender, EventArgs e)
        {
            if (CmbNoLoteEnvasado.SelectedValue == null)
            {
                MessageBox.Show("No tienes lotes para reportar");
                return;
            }
            if (TxtMensajeEnvasado.Text == "")
            {
                MessageBox.Show("Escribe una observación");
                TxtMensajeEnvasado.Focus();
                return;
            }


            if (ConexionMysql.insUpd_transaccion("INSERT INTO mensajes (id_prod,tipo,mensaje,id_verificador,actualizado) VALUES ('" + CmbNoLoteEnvasado.SelectedValue + "','Envasado','" + TxtMensajeEnvasado.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
                {
                    return;
                }
     
            ConexionMysql.transCompleta();
            MessageBox.Show("Gracias por tu mensaje");
            this.Close();
        } 
    //----------------------================================================\\-------FIN ENVASADO-------------//=============================================-------------------------------------------


        //----------------------------============================================\\---------MENSAJE---------------//============================================---------------------------------------
        private void BtnMensaje_Click(object sender, EventArgs e)
        {
            PanelProduccion.Visible = false;
            PanelGranel.Visible = false;
            PanelEnvasado.Visible = false;
            PanelMensaje.Visible = true;
        }

        private void BtnMensajeSolo_Click(object sender, EventArgs e)
        {
            if (TxtMensaje.Text == "")
            {
                MessageBox.Show("Escribe una observación");
                TxtMensaje.Focus();
                return;
            }


            if (ConexionMysql.insUpd_transaccion("INSERT INTO mensajes (id_prod,tipo,mensaje,id_verificador,actualizado) VALUES (0,'Mensaje','" + TxtMensaje.Text + "'," + Usuario.IdUsuario + ",0)") == "Error")
            {
                return;
            }

            ConexionMysql.transCompleta();
            MessageBox.Show("Gracias por tu mensaje");
            this.Close();
        } 
 //----------------------------============================================\\---------FIN MENSAJE---------------//============================================---------------------------------------
    


  

 










 
    }
}
