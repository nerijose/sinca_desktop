using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crm.Inventario.Dialogs
{
    public partial class MsgBxGranelenvasado : Form //MaterialSkin.Controls.MaterialForm
    {
        public MsgBxGranelenvasado()
        {
            InitializeComponent();
            this.Text = "Verifica que los datos sean correctos";
            /* MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
             skinManager.AddFormToManage(this);
             skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
             skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green400, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Orange400, MaterialSkin.TextShade.WHITE);
              */
            //new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green600, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.Blue500, MaterialSkin.TextShade.WHITE);


        }

        // FrmInventario s = new FrmInventario();
        //  static MsgBxGranelenvasado MsgBox; 
        // static DialogResult result= DialogResult.No;
        //  public static DialogResult Show(string Text,string _lbl1, string Caption, string btnOK, string btnCancel)
        // {





        /* MsgBox = new MsgBxGranelenvasado();
          MsgBox.lblEnvasadora.Text = Text;

          MsgBox.lbl1.Text =_lbl1;
          MsgBox.btnAceptar.Text = btnOK;
         MsgBox.btnCancel.Text = btnCancel;
        
         MsgBox.ShowDialog();
         return result;*/



        //}


        // public static DialogResult Show(string tipo,string Caption, string btnOK, string btnCancel)

        //  {




        // MsgBox.btnAceptar.Text = btnOK;
        // MsgBox.btnCancel.Text = btnCancel;
        //return result;
        //}










        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Yes;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //result = DialogResult.Cancel; MsgBox.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // result = DialogResult.Yes; MsgBox.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //------------------------------Produccion-------------------
        private void pnlMsgproduccion_Click(object sender, EventArgs e)
        {



        }


        public void produccionok(string dto)
        {
            pnlMsggranelfabrica.Visible = false;
            pnlMsggranelenvasado.Visible = false;
            pnlMsgenvasado.Visible = false;
            pnlMsgEnsamble.Visible = false;
           



            // MsgBox.lblEnvasadora.Text = Text;
            string line1 = dto;

            string[] split = line1.Split('!');

            // MessageBox.Show("es "+split[0]);

            lbl1.Text = split[0];
            lbl2.Text = split[1];
            lbl3.Text = split[2];
            lbl4.Text = split[3];
            lbl5.Text = split[4];
            lbl6.Text = split[5];
            lbl7.Text = split[6];
            lbl8.Text = split[7];
            lbl9.Text = split[8];
            lbl10.Text = split[9];
            lbl11.Text = split[10];
            lbl12.Text = split[11];
            lbl13.Text = split[12];

            // DialogResult();



        }//----- Fin produccion---------

        //------------------------------ Granel Fabrica-------------------
        public void granelfabricaok(string dto)
        {
            pnlMsgproduccion.Visible = false;
            pnlMsggranelenvasado.Visible = false;
            pnlMsgenvasado.Visible = false;
            pnlMsgEnsamble.Visible = false;


            // MsgBox.lblEnvasadora.Text = Text;
            string line1 = dto;

            string[] split = line1.Split('!');

            // MessageBox.Show("es "+split[0]);

            lblgf1.Text = split[0];
            lblgf2.Text = split[1];
            lblgf3.Text = split[2];
            lblgf4.Text = split[3];
            lblgf5.Text = split[4];
            lblgf6.Text = split[5];
            lblgf7.Text = split[6];
            lblgf8.Text = split[7];
            lblgf9.Text = split[8];
            lblgf10.Text = split[9];



        }//----- Fin granel fabrica---------



        //------------------------------Granel Envasado-------------------
        public void granelEnvasadook(string dto)
        {
            pnlMsgproduccion.Visible = false;
            pnlMsggranelfabrica.Visible = false;
            pnlMsgenvasado.Visible = false;
            pnlMsgEnsamble.Visible = false;



            // MsgBox.lblEnvasadora.Text = Text;
            string line1 = dto;

            string[] split = line1.Split('!');

            // MessageBox.Show("es "+split[0]);

            lblgEn1.Text = split[0];
            lblgEn2.Text = split[1];
            lblgEn3.Text = split[2];
            lblgEn4.Text = split[3];
            lblgEn5.Text = split[4];
            lblgEn6.Text = split[5];
            lblgEn7.Text = split[6];
            lblgEn8.Text = split[7];
            lblgEn9.Text = split[8];
            lblgEn10.Text = split[9];



        }//-----Fin Granel Envasado---------


        //------------------------------ Envasado-------------------
        public void Envasadook(string dto)
        {
            pnlMsgproduccion.Visible = false;
            pnlMsggranelfabrica.Visible = false;
            pnlMsggranelenvasado.Visible = false;
            pnlMsgEnsamble.Visible = false;


            // MsgBox.lblEnvasadora.Text = Text;
            string line1 = dto;

            string[] split = line1.Split('!');

            // MessageBox.Show("es "+split[0]);

            lblEn1.Text = split[0];
            lblEn2.Text = split[1];
            lblEn3.Text = split[2];
            lblEn4.Text = split[3];
            lblEn5.Text = split[4];
            lblEn6.Text = split[5];
            lblEn7.Text = split[6];
            lblEn8.Text = split[7];
            lblEn9.Text = split[8];
            lblEn10.Text = split[9];
            lblEn11.Text = split[10];
            lblEn12.Text = split[11];
            lblEn13.Text = split[12];
            lblEn14.Text = split[13];
            lblEn15.Text = split[14];
            lblEn16.Text = split[15];
            lblEn17.Text = split[16];
            lblEn18.Text = split[17];
            lblEn19.Text = split[18];



        }//----- Fin Envasado---------




        //------------------------------ Ensamble -------------------
        public void Ensambleok(string dto)
        {
            pnlMsgproduccion.Visible = false;
            pnlMsggranelfabrica.Visible = false;
            pnlMsggranelenvasado.Visible = false;
            pnlMsgenvasado.Visible = false;


            // MsgBox.lblEnvasadora.Text = Text;
            string line1 = dto;

            string[] split = line1.Split('!');

            // MessageBox.Show("es "+split[0]);

            lblEnble1.Text = split[0];
            lblEnble2.Text = split[1];
            lblEnble3.Text = split[2];
            lblEnble4.Text = split[3];
            lblEnble5.Text = split[4];
            lblEnble6.Text = split[5];
            lblEnble7.Text = split[6];
            lblEnble8.Text = split[7];
            lblEnble9.Text = split[8];
            lblEnble10.Text = split[9];
            lblEnble11.Text = split[10];
            
        }//----- Fin Ensamble ---------


        private void pnlMsggranelfabrica_Click(object sender, EventArgs e)
        {

        }





    }
}
