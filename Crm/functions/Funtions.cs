using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crm.functions
{
    class Funtions
    {
        public  static double calcula_lts_botellas(double botellas, string medida, string contenido_por_botella)
        {///---- Calcula los litros de acuerdo al numero de botellas y su medida
            try
            {

                double conversion = 0;
                double lts = 0;

                if (medida == "Mililitros")
                {
                    conversion = Math.Round(double.Parse(contenido_por_botella), 2) / 1000;
                    lts = botellas * conversion;

                }
                else if (medida == "Litros")
                {
                    conversion = Math.Round(double.Parse(contenido_por_botella), 2);
                    lts = botellas * conversion;

                }
                else if (medida == "Centilitro")
                {
                    conversion = Math.Round(double.Parse(contenido_por_botella), 2) / 100;
                    lts = botellas * conversion;
                }

                return lts;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
        }







    }
}
