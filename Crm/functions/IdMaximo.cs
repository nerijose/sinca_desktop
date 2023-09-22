using Crm.Utilerias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.functions
{
    class IdMaximo
    {



        public static string ObtenerIdMaximoEnvasadoSalida()
        {

            string id_max_envasado_salida;

            id_max_envasado_salida = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_salida,4)) )   FROM envasado_salida where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasado_salida == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_salida = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasado_salida = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasado_salida) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_salida = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasado_salida = Usuario.IdUsuario + "-" + suma;
                }
            }

            return id_max_envasado_salida;
        }

        public static string ObtenerIdMaximoMaestroMezcalero()
        {

            string id_max_maestro_mezcalero;

            id_max_maestro_mezcalero = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_maestros_mezcaleros,4)) )   FROM maestros_mezcaleros where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_maestro_mezcalero == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_maestro_mezcalero = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_maestro_mezcalero = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_maestro_mezcalero) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_maestro_mezcalero = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_maestro_mezcalero = Usuario.IdUsuario + "-" + suma;
                }
            }

            return id_max_maestro_mezcalero; ;
        }






        //obtencion de los id para todas las entradas a almacen envasado 
        public static string ObtenerIdMaximoEnvasadoMovimientos()
        {
            string id_max_envasado_movimientos;
            id_max_envasado_movimientos = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_envasado_movimientos,4)) )   FROM envasado_movimientos where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_envasado_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_envasado_movimientos = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_envasado_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_envasado_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_envasado_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }


            return id_max_envasado_movimientos;
        }



        //obtencion de los id para todas las entradas a almacen envasado 
        public static string ObtenerIdMaximoAlmacenEnvasadoMovimientos()
        {
            string id_max_almacen_envasado_movimientos;
            id_max_almacen_envasado_movimientos = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_almacen_envasado_movimientos,4)) )   FROM almacen_envasado_movimientos where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_almacen_envasado_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_envasado_movimientos = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_envasado_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_envasado_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_envasado_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }

            return id_max_almacen_envasado_movimientos;
        }



        //obtencion de los id para los id_produccion 
        public static string ObtenerIdMaximoIdsProducciones()
        {
            string id_max_id_producciones;
            id_max_id_producciones = ConexionMysql.regresaCampoConsulta("SELECT max(abs(SUBSTRING(id_producciones,4)) )   FROM ids_producciones where id_verificador=" + Usuario.IdUsuario + " ");
            if (id_max_id_producciones == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_id_producciones = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_id_producciones = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_id_producciones) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_id_producciones = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_id_producciones = Usuario.IdUsuario + "-" + suma;
                }
            }

            return id_max_id_producciones;
        }




        public static string ObtenerIdMaximoGraneTanque()
        {
            string id_max_granel_tanque;
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


            return id_max_granel_tanque;
        }



        public static string ObtenerIdMaximoGranelTanqueEnvasado()
        {
            string id_max_granel_tanque_envasado;
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
            return id_max_granel_tanque_envasado;
        }


        public static string ObtenerIdMaximoAlmacenGranelTanque()
        {
            string id_max_almacen_granel_tanque;
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

            return id_max_almacen_granel_tanque;
        }




    }
}
