using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crm.Utilerias
{
    class Validacion
    {

        private Boolean space = true;
        public void Login(KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !(char.IsNumber(e.KeyChar)) && e.KeyChar != '\b')
            {
                e.Handled = true;

            }

        }//FINAL DE LA CLASE QUE VALIDA EL LOGIN

        public void soloLetras(KeyPressEventArgs e) {

            //MessageBox.Show("space "+space);
        if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && !(e.KeyChar == ' ' && space == false))
            {

                e.Handled = true;

            }//VALDA SOLO LETRAS
            else {

                space = false;
            }
         
           if (e.KeyChar == ' ')
                {
                    space = true;
                }
        }//SOLO PERMITE INTRODUCIR LETRAS

///////////////////////////////////////LETRAS Y NUMEROS, CON ESPACIOS/////////////////////////////////////////////////////
        public void LetraNumSpace(KeyPressEventArgs e)
        {

            //MessageBox.Show("space "+space);
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && !(char.IsNumber(e.KeyChar)) && !(e.KeyChar == ' ' && space == false))
            {

                e.Handled = true;

            }//VALDA SOLO LETRAS
            else
            {

                space = false;
            }

            if (e.KeyChar == ' ')
            {
                space = true;
            }
        }//PERMITE NUMEROS , LETRAS Y ESPACIOS

////////////////////////////////////SOLO NUMEROS/////////////////////////////////////////////////

        public void soloNumeros(KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }      
        }//FIN DE VALIDACION DE SOLO NUMEROS

////////////////////////////////NUMEROS,LETRAS,ESPACIOS Y "-"
        public void NumLetSpaceSign(KeyPressEventArgs e)
        {
            //MessageBox.Show("space "+space);
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && !(char.IsNumber(e.KeyChar)) && e.KeyChar != '-' && !(e.KeyChar == ' ' && space == false))
            {
             e.Handled = true;
            }//VALDA SOLO LETRAS
            else
            {
             space = false;
            }
            if (e.KeyChar == ' ')
            {
             space = true;
            }
        } 


        public void aceptaNumero(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void mascaraFolios(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            { 
                if(e.KeyChar !='\b')
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar != '0')
                    e.Handled = true;
            }
        }//FIN MASCARA DE FOLIOS

        public void validaCondiciones(KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && !(char.IsNumber(e.KeyChar)) && !(e.KeyChar == ' '

            && space == false) && e.KeyChar != '(' && e.KeyChar != '/' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != ')')
            {

                e.Handled = true;

            }//VALDA SOLO LETRAS
            else
            {

                space = false;
            }

            if (e.KeyChar == ' ')
            {
                space = true;
            }
        }//PERMITE NUMEROS , LETRAS Y ESPACIOS

        public void numeroPunto(KeyPressEventArgs e, string texto)
        {
            if (texto.Contains("."))
            {
                if (e.KeyChar == 46)
                {
                    e.Handled = true;
                }

                if (e.KeyChar != '\b')
                {
                    char[] caracter = new char[1];
                    caracter[0] = '.';
                    if ((texto.Length - 3) == texto.LastIndexOfAny(caracter))
                    {
                        e.Handled = true;
                    }
                }    
            }


            if (!char.IsNumber(e.KeyChar))
            {
                if (e.KeyChar != '\b')
                {
                    if (e.KeyChar != 46)
                    {
                        e.Handled = true;
                    }
                }

            }
            //else
            //{
            //    if (e.KeyChar != '0')
            //        e.Handled = true;
            //}
        }

    }//FIN DE LA CLASE
}//FIN DEL NAME-SPACE
