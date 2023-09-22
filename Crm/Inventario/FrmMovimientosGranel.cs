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
using Crm.functions;

namespace Crm.Inventario
{
    public partial class FrmMovimientosGranel : Form
    {
        public FrmMovimientosGranel()
        {
            InitializeComponent();
        }

        Validacion valida = new Validacion();
        public string id_granel_entrada;
        public string lts_existentes;
        public string grado_alcoholico_existente;
        public string no_cliente;
        public string no_lote;
        public string categoria;
        public string clase;
        public string fq;
        public string id_fabrica;
        public string id_envasadora;
        public string id_almacen;
        public string tipo;
        double grado_alcoholico_diluido;
        string id_max_granel_movimientos;
        string id_max_granel_entrada;
        string id_max_granel_movimientos_envasado;
        string id_max_granel_entrada_envasado;
        string id_max_granel_ensamble;
        string id_max_granel_ensamble_envasado;
        string id_max_mensaje;
        string id_max_fq;
        string id_max_granel_tanque;
        string id_max_granel_tanque_envasado;

        ///---- para almacen de graneles
        string id_max_almacen_granel_movimientos;
        string id_max_almacen_granel_entrada;
        string id_max_almacen_granel_ensamble;
        string id_max_almacen_granel_tanque;

        //obtencion de los id para todos los tanques entrada
        public void ObtenerIdMaximoGranelTanque()
        {
            id_max_granel_tanque = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM granel_tanques where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
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
        }

        //obtencion de los id para todos los tanques_envasado entrada
        public void ObtenerIdMaximoGranelTanqueEnvasado()
        {
            id_max_granel_tanque_envasado = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM granel_tanques_envasado where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
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
        }

        //obtencion de los id para todos los tanques de almacen  entrada
        public void ObtenerIdMaximoAlmacenGranelTanque()
        {
            id_max_almacen_granel_tanque = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_tanque,4)) )   FROM almacen_granel_tanques where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
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
        }

        //obtencion de los id para todas las entradas a granel
        public void ObtenerIdMaximoGranelEntrada()
        {
            id_max_granel_entrada = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_granel_entrada,4)) )   FROM granel_entrada where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_granel_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel movimientos
        public void ObtenerIdMaximoGranelMovimientos()
        {
            id_max_granel_movimientos = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_granel_movimientos,4)) )   FROM granel_movimientos where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_granel_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_movimientos = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a Almacen granel
        public void ObtenerIdMaximoAlmacenGranelEntrada()
        {
            id_max_almacen_granel_entrada = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_almacen_granel_entrada,4)) )   FROM almacen_granel_entrada where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_almacen_granel_entrada == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_entrada = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_entrada = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_entrada) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_entrada = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_entrada = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel  envasados
        public void ObtenerIdMaximoGranelEntradaEnvasado()
        {
            id_max_granel_entrada_envasado = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_granel_entrada_envasado,4)) )   FROM granel_entrada_envasado where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_granel_entrada_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_entrada_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_entrada_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_entrada_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_entrada_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel movimientos envasados
        public void ObtenerIdMaximoGranelMovimientosEnvasado()
        {
            id_max_granel_movimientos_envasado = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_granel_movimientos_envasado,4)) )   FROM granel_movimientos_envasado where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_granel_movimientos_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_movimientos_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_movimientos_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_movimientos_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_movimientos_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a almacen granel movimientos
        public void ObtenerIdMaximoAlmacenGranelMovimientos()
        {
            id_max_almacen_granel_movimientos = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_almacen_granel_movimientos,4)) )   FROM almacen_granel_movimientos where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_almacen_granel_movimientos == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_movimientos = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_movimientos = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_movimientos) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_movimientos = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_movimientos = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel
        public void ObtenerIdMaximoGranelEnsamble()
        {
            id_max_granel_ensamble = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_granel_ensamble,4)) )   FROM granel_ensamble where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_granel_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_ensamble = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_ensamble = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a granel ensamble  envasado
        public void ObtenerIdMaximoGranelEnsambleEnvasado()
        {
            id_max_granel_ensamble_envasado = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_granel_ensamble,4)) )   FROM granel_ensamble_envasado where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_granel_ensamble_envasado == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble_envasado = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_granel_ensamble_envasado = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_granel_ensamble_envasado) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_granel_ensamble_envasado = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_granel_ensamble_envasado = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las entradas a almacen granel ensamble
        public void ObtenerIdMaximoAlmacenGranelEnsamble()
        {
            id_max_almacen_granel_ensamble = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_almacen_granel_ensamble,4)) )   FROM almacen_granel_ensamble where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_almacen_granel_ensamble == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_ensamble = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_almacen_granel_ensamble = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_almacen_granel_ensamble) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_almacen_granel_ensamble = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_almacen_granel_ensamble = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todos los mensajes
        public void ObtenerIdMaximoMensaje()
        {
            id_max_mensaje = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_mensaje,4)) )   FROM mensajes_registros where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_mensaje == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    //-- Esta funcion genera el id de mensaje cuando el valor del id_ususario es de 1 a 9
                    id_max_mensaje = "0" + Usuario.IdUsuario + "-1";
                }
                else
                { //-- Esta funcion genera el id de mensaje cuando el valor del id_ususario es de 10 en adelante
                    id_max_mensaje = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_mensaje) + 1;
                if (Usuario.IdUsuario.Length == 1)
                { //-- Esta funcion genera el id de mensaje cuando el valor del id_ususario es de 1 a 9  y ya tiene registros
                    id_max_mensaje = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                { //-- Esta funcion genera el id de mensaje cuando el valor del id_ususario es de 10 en adelante  y ya tiene registros
                    id_max_mensaje = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        //obtencion de los id para todas las ediciones de fq
        public void ObtenerIdMaximoFq()
        {
            id_max_fq = ConexionMysql.regresaCampoConsulta(
                "SELECT max(abs(SUBSTRING(id_fq,4)) )   FROM fq_historial where id_verificador="
                    + Usuario.IdUsuario
                    + " "
            );
            if (id_max_fq == "")
            {
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_fq = "0" + Usuario.IdUsuario + "-1";
                }
                else
                {
                    id_max_fq = Usuario.IdUsuario + "-1";
                }
            }
            else
            {
                int suma = int.Parse(id_max_fq) + 1;
                if (Usuario.IdUsuario.Length == 1)
                {
                    id_max_fq = "0" + Usuario.IdUsuario + "-" + suma;
                }
                else
                {
                    id_max_fq = Usuario.IdUsuario + "-" + suma;
                }
            }
        }

        private void FrmMovimientosGranel_Load(object sender, EventArgs e)
        {
            CmbTipoDilucion.Items.Insert(0, "Agua");
            CmbTipoDilucion.Items.Insert(1, "Puntas");
            CmbTipoDilucion.Items.Insert(2, "Colas");
            lblNoloteDilucion.Text = no_lote;

            TxtLitrosDilucion.Enabled = false;
            TxtGradoAlcoholico.Enabled = false;
            PanelMuestreo.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelUnion.Visible = false;
            PanelSalida.Visible = false;
            PanelMensajes.Visible = false;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;
            if (tipo == "fabrica")
            {
                BtnTridestilacion.Enabled = true;
            }
            /*else if (tipo == "almacen")
            {
                BtnTridestilacion.Enabled = true;
            }*/
        }

        //agrega una dilucion a producto agranel
        private void BtnGuardarDilucion_Click(object sender, EventArgs e)
        {
            grado_alcoholico_diluido = 0;
            try
            {
                if (CmbTipoDilucion.Text == "Agua")
                {
                    if (TxtLitrosDilucion.Text == "")
                    {
                        MessageBox.Show("Favor de introducir litros de agua");
                        return;
                    }
                    if (TxtLitrosDilucion.Text == "0")
                    {
                        MessageBox.Show("Favor de introducir un valor diferente de 0");
                        return;
                    }
                    if (TxtLitrosDilucion.Text == ".")
                    {
                        MessageBox.Show("Favor de introducir un valor real");
                        return;
                    }

                    grado_alcoholico_diluido =
                        (
                            Math.Round(double.Parse(grado_alcoholico_existente), 2)
                            * Math.Round(double.Parse(lts_existentes), 2)
                        )
                        / (
                            Math.Round(double.Parse(lts_existentes), 2)
                            + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                        );

                    DialogResult check = MessageBox.Show(
                        "Verifica que los datos sean correctos",
                        "",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning
                    );

                    if (check == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        if (tipo == "fabrica")
                        {
                            ObtenerIdMaximoGranelMovimientos();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos(id_granel_movimientos,id_granel_entrada,tipo,destino,litros,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                        + id_max_granel_movimientos
                                        + "','"
                                        + id_granel_entrada
                                        + "','entrada','dilucion_agua',"
                                        + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        + ","
                                        + lts_existentes
                                        + ",now(),NOW(),0,"
                                        + Usuario.IdUsuario
                                        + ") "
                                ) == "Error"
                            )
                            {
                                return;
                            }

                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET lts_existentes="
                                        + (
                                            Math.Round(double.Parse(lts_existentes), 2)
                                            + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        )
                                        + ", grado_alcoholico_existente="
                                        + Math.Round(grado_alcoholico_diluido, 2)
                                        + ",actualizado=0  WHERE id_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///===== para almacen--
                            ObtenerIdMaximoAlmacenGranelMovimientos();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO almacen_granel_movimientos(id_almacen_granel_movimientos,id_almacen_granel_entrada,tipo,destino,litros,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                        + id_max_almacen_granel_movimientos
                                        + "','"
                                        + id_granel_entrada
                                        + "','entrada','dilucion_agua',"
                                        + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        + ","
                                        + lts_existentes
                                        + ",now(),NOW(),0,"
                                        + Usuario.IdUsuario
                                        + ") "
                                ) == "Error"
                            )
                            {
                                return;
                            }

                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET lts_existentes="
                                        + (
                                            Math.Round(double.Parse(lts_existentes), 2)
                                            + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        )
                                        + ", grado_alcoholico_existente="
                                        + Math.Round(grado_alcoholico_diluido, 2)
                                        + ",actualizado=0  WHERE id_almacen_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            ObtenerIdMaximoGranelMovimientosEnvasado();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos_envasado(id_granel_movimientos_envasado,id_granel_entrada_envasado,tipo,destino,litros,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                        + id_max_granel_movimientos_envasado
                                        + "','"
                                        + id_granel_entrada
                                        + "','entrada','dilucion_agua',"
                                        + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        + ","
                                        + lts_existentes
                                        + ",now(),NOW(),0,"
                                        + Usuario.IdUsuario
                                        + ") "
                                ) == "Error"
                            )
                            {
                                return;
                            }

                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada_envasado SET lts_existentes="
                                        + (
                                            Math.Round(double.Parse(lts_existentes), 2)
                                            + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        )
                                        + ", grado_alcoholico_existente="
                                        + Math.Round(grado_alcoholico_diluido, 2)
                                        + ",actualizado=0  WHERE id_granel_entrada_envasado= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }

                        ConexionMysql.transCompleta();
                        MessageBox.Show("Dilución realizada con éxito");
                        this.Close();
                    }
                    ///--- fin del DialogMessageBox
                }
                ///--- fin del if dilucion de agua ---
                else if (CmbTipoDilucion.Text == "Puntas" || CmbTipoDilucion.Text == "Colas")
                {
                    if (TxtLitrosDilucion.Text == "")
                    {
                        MessageBox.Show("Favor de introducir litros");
                        return;
                    }
                    if (TxtLitrosDilucion.Text == "0")
                    {
                        MessageBox.Show("Favor de introducir un valor diferente de 0");
                        return;
                    }
                    if (TxtLitrosDilucion.Text == ".")
                    {
                        MessageBox.Show("Favor de introducir un valor real");
                        return;
                    }

                    if (TxtGradoAlcoholico.Text == "")
                    {
                        MessageBox.Show("Favor de introducir el grado alcoholico");
                        return;
                    }
                    if (TxtGradoAlcoholico.Text == "0")
                    {
                        MessageBox.Show("No cuentas con puntas/colas para dilución");
                        return;
                    }
                    if (TxtGradoAlcoholico.Text == ".")
                    {
                        MessageBox.Show("Favor de introducir un valor real");
                        return;
                    }

                    if (
                        Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                        > Math.Round(double.Parse(LblLitrosExistentes.Text), 2)
                    )
                    {
                        MessageBox.Show("Litros insuficientes");
                        TxtLitrosDilucion.Focus();
                        return;
                    }

                    double litros =
                        Math.Round(double.Parse(lts_existentes), 2)
                        + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2);
                    double grado_alcoholico_para_suma =
                        (
                            Math.Round(double.Parse(grado_alcoholico_existente), 2)
                            * Math.Round(double.Parse(lts_existentes), 2)
                        )
                        + (
                            Math.Round(double.Parse(TxtGradoAlcoholico.Text), 2)
                            * Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                        );
                    grado_alcoholico_diluido = grado_alcoholico_para_suma / litros;

                    DialogResult check = MessageBox.Show(
                        "Verifica que los datos sean correctos",
                        "",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning
                    );

                    if (check == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        if (tipo == "fabrica")
                        {
                            ObtenerIdMaximoGranelMovimientos();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos(id_granel_movimientos,id_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                        + id_max_granel_movimientos
                                        + "','"
                                        + id_granel_entrada
                                        + "','entrada','"
                                        + (
                                            CmbTipoDilucion.Text == "Puntas"
                                                ? "dilucion_puntas"
                                                : "dilucion_colas"
                                        )
                                        + "',"
                                        + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        + ","
                                        + Math.Round(double.Parse(TxtGradoAlcoholico.Text), 2)
                                        + ","
                                        + lts_existentes
                                        + ",now(),NOW(),0,"
                                        + Usuario.IdUsuario
                                        + ") "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///===== para almacen--
                            ObtenerIdMaximoGranelMovimientos();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO almacen_granel_movimientos(id_almacen_granel_movimientos,id_almacen_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                        + id_max_almacen_granel_movimientos
                                        + "','"
                                        + id_granel_entrada
                                        + "','entrada','"
                                        + (
                                            CmbTipoDilucion.Text == "Puntas"
                                                ? "dilucion_puntas"
                                                : "dilucion_colas"
                                        )
                                        + "',"
                                        + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        + ","
                                        + Math.Round(double.Parse(TxtGradoAlcoholico.Text), 2)
                                        + ","
                                        + lts_existentes
                                        + ",now(),NOW(),0,"
                                        + Usuario.IdUsuario
                                        + ") "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            ObtenerIdMaximoGranelMovimientosEnvasado();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos_envasado(id_granel_movimientos_envasado,id_granel_entrada_envasado,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                        + id_max_granel_movimientos_envasado
                                        + "','"
                                        + id_granel_entrada
                                        + "','entrada','"
                                        + (
                                            CmbTipoDilucion.Text == "Puntas"
                                                ? "dilucion_puntas"
                                                : "dilucion_colas"
                                        )
                                        + "',"
                                        + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        + ","
                                        + Math.Round(double.Parse(TxtGradoAlcoholico.Text), 2)
                                        + ","
                                        + lts_existentes
                                        + ",now(),NOW(),0,"
                                        + Usuario.IdUsuario
                                        + ") "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }

                        double resultado;
                        ///--- actualiza lts puntas y colas
                        if (CmbTipoDilucion.Text == "Puntas")
                        {
                            string litros_puntas = ConexionMysql.regresaCampoConsulta(
                                "SELECT litros  FROM produccion_puntas_colas where no_cliente='"
                                    + no_cliente
                                    + "' and tipo='puntas' "
                            );
                            resultado =
                                Math.Round(double.Parse(litros_puntas), 2)
                                - Math.Round(double.Parse(TxtLitrosDilucion.Text), 2);
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE produccion_puntas_colas SET litros="
                                        + Math.Round(resultado, 2)
                                        + ",actualizado=0  WHERE  no_cliente ='"
                                        + no_cliente
                                        + "' and tipo='puntas'"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                            if (resultado == 0)
                            {
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "UPDATE produccion_puntas_colas SET grado_alcoholico=0,actualizado=0  WHERE  no_cliente ='"
                                            + no_cliente
                                            + "' and tipo='puntas'"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            string litros_colas = ConexionMysql.regresaCampoConsulta(
                                "SELECT litros  FROM produccion_puntas_colas where no_cliente='"
                                    + no_cliente
                                    + "' and tipo='colas' "
                            );
                            resultado =
                                Math.Round(double.Parse(litros_colas), 2)
                                - Math.Round(double.Parse(TxtLitrosDilucion.Text), 2);
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE produccion_puntas_colas SET litros="
                                        + Math.Round(resultado, 2)
                                        + ",actualizado=0  WHERE  no_cliente ='"
                                        + no_cliente
                                        + "' and tipo='colas'"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                            if (resultado == 0)
                            {
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "UPDATE produccion_puntas_colas SET grado_alcoholico=0,actualizado=0  WHERE  no_cliente ='"
                                            + no_cliente
                                            + "' and tipo='colas'"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }
                        ///--- Fin de actualiza lts puntas y colas

                        if (tipo == "fabrica")
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET lts_existentes="
                                        + (
                                            Math.Round(double.Parse(lts_existentes), 2)
                                            + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        )
                                        + ", grado_alcoholico_existente="
                                        + Math.Round(grado_alcoholico_diluido, 2)
                                        + ",actualizado=0  WHERE id_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///===== para almacen--

                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET lts_existentes="
                                        + (
                                            Math.Round(double.Parse(lts_existentes), 2)
                                            + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        )
                                        + ", grado_alcoholico_existente="
                                        + Math.Round(grado_alcoholico_diluido, 2)
                                        + ",actualizado=0  WHERE id_almacen_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada_envasado SET lts_existentes="
                                        + (
                                            Math.Round(double.Parse(lts_existentes), 2)
                                            + Math.Round(double.Parse(TxtLitrosDilucion.Text), 2)
                                        )
                                        + ", grado_alcoholico_existente="
                                        + Math.Round(grado_alcoholico_diluido, 2)
                                        + ",actualizado=0  WHERE id_granel_entrada_envasado= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }

                        ConexionMysql.transCompleta();
                        MessageBox.Show("Dilución realizada con éxito");
                        this.Close();
                    }
                } //-----------fin Del DialogMessageBox ----
                else
                {
                    MessageBox.Show("Selecciona una opción válida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TxtLtsAgua_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosDilucion.Text);
        }

        //al presionar muestreo genera los folios dependiendo el verificador
        private void BtnMuestreo_Click(object sender, EventArgs e)
        {
            PanelMuestreo.Visible = true;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelSalida.Visible = false;
            PanelUnion.Visible = false;
            PanelMensajes.Visible = false;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;

            lblNoloteMuestreo.Text = no_lote;

            string estado = ConexionMysql.regresaCampoConsulta(
                "SELECT estados.codigo from estados inner join relacion_cp_estado on  estados.clave=relacion_cp_estado.clave_estado inner join clientes on relacion_cp_estado.cp=clientes.cp  where clientes.no_cliente='"
                    + no_cliente
                    + "'"
            );
            string Folio = ConexionMysql.regresaCampoConsulta(
                "SELECT max(id_folio) FROM  folios   "
            );

            if (Folio == "")
            {
                Folio = "1";
                TxtFolioMuestreo.Text = Usuario.IdUsuario + "00000" + Folio + "LB" + estado;
            }
            else
            {
                int NuevoFolio = 0;
                string cero = "";
                NuevoFolio = int.Parse(Folio) + 1;
                if (NuevoFolio.ToString().Length == 1)
                {
                    cero = "00000";
                }
                else if (NuevoFolio.ToString().Length == 2)
                {
                    cero = "0000";
                }
                else if (NuevoFolio.ToString().Length == 3)
                {
                    cero = "000";
                }
                else if (NuevoFolio.ToString().Length == 4)
                {
                    cero = "00";
                }
                else if (NuevoFolio.ToString().Length == 5)
                {
                    cero = "0";
                }
                TxtFolioMuestreo.Text = Usuario.IdUsuario + cero + NuevoFolio + "LB" + estado;
            }
        }

        //al precionar dilucion
        private void BtnDilucion_Click(object sender, EventArgs e)
        {
            TxtLitrosDilucion.Text = "";
            CmbTipoDilucion.DataSource = null;
            CmbTipoDilucion.Items.Clear();
            CmbTipoDilucion.Items.Insert(0, "Agua");
            CmbTipoDilucion.Items.Insert(1, "Puntas");
            CmbTipoDilucion.Items.Insert(2, "Colas");
            TxtLitrosDilucion.Enabled = false;
            TxtGradoAlcoholico.Enabled = false;
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = true;
            PanelVidrio.Visible = false;
            PanelBarrica.Visible = false;
            PanelSalida.Visible = false;
            PanelUnion.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelMensajes.Visible = false;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;
            lblNoloteDilucion.Text = no_lote;
        }

        //al seleccionar el tipo de dilucion oculta ciertos campos
        private void CmbTipoDilucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTipoDilucion.Text == "Agua")
            {
                TxtLitrosDilucion.Enabled = true;
                TxtGradoAlcoholico.Enabled = false;
                LblLitrosExistentes.Text = ".........";
                TxtGradoAlcoholico.Text = "";
            }
            else if (CmbTipoDilucion.Text == "Puntas")
            {
                TxtLitrosDilucion.Enabled = true;
                TxtGradoAlcoholico.Text = ConexionMysql.regresaCampoConsulta(
                    "SELECT grado_alcoholico from produccion_puntas_colas  where tipo='puntas' and  no_cliente='"
                        + no_cliente
                        + "'"
                );
                LblLitrosExistentes.Text = ConexionMysql.regresaCampoConsulta(
                    "SELECT litros from produccion_puntas_colas  where tipo='puntas' and  no_cliente='"
                        + no_cliente
                        + "'"
                );
            }
            else if (CmbTipoDilucion.Text == "Colas")
            {
                TxtLitrosDilucion.Enabled = true;
                TxtGradoAlcoholico.Text = ConexionMysql.regresaCampoConsulta(
                    "SELECT grado_alcoholico from produccion_puntas_colas  where tipo='colas' and  no_cliente='"
                        + no_cliente
                        + "'"
                );
                LblLitrosExistentes.Text = ConexionMysql.regresaCampoConsulta(
                    "SELECT litros from produccion_puntas_colas  where tipo='colas' and  no_cliente='"
                        + no_cliente
                        + "'"
                );
            }
        }

        private void BtnBarrica_Click(object sender, EventArgs e)
        {
            ChekCambiarLote.Checked = false;
            TxtLoteBarrica.ReadOnly = true;
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelVidrio.Visible = false;
            PanelBarrica.Visible = true;
            PanelTridestilacion.Visible = false;
            PanelSalida.Visible = false;
            PanelUnion.Visible = false;
            PanelMensajes.Visible = false;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;
            TxtLoteBarrica.Text = no_lote;

            string estado = ConexionMysql.regresaCampoConsulta(
                "SELECT estados.codigo from estados inner join relacion_cp_estado on  estados.clave=relacion_cp_estado.clave_estado inner join clientes on relacion_cp_estado.cp=clientes.cp  where clientes.no_cliente='"
                    + no_cliente
                    + "'"
            );
            string Folio = ConexionMysql.regresaCampoConsulta("SELECT max(id_folio) FROM  folios ");

            if (Folio == "")
            {
                Folio = "1";
                TxtFolioBarrica.Text = Usuario.IdUsuario + "00000" + Folio + "BR" + estado;
            }
            else
            {
                int NuevoFolio = 0;
                string cero = "";
                NuevoFolio = int.Parse(Folio) + 1;
                if (NuevoFolio.ToString().Length == 1)
                {
                    cero = "00000";
                }
                else if (NuevoFolio.ToString().Length == 2)
                {
                    cero = "0000";
                }
                else if (NuevoFolio.ToString().Length == 3)
                {
                    cero = "000";
                }
                else if (NuevoFolio.ToString().Length == 4)
                {
                    cero = "00";
                }
                else if (NuevoFolio.ToString().Length == 5)
                {
                    cero = "0";
                }
                TxtFolioBarrica.Text = Usuario.IdUsuario + cero + NuevoFolio + "BR" + estado;
            }
        }

        //guardar el muestreo de una produccion agranel
        private void BtnGuardarMuestreo_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtLitrosMuestrear.Text == "")
                {
                    MessageBox.Show("Favor de introducir litros a muestrear");
                    return;
                }
                if (TxtFolioMuestreo.Text == "")
                {
                    MessageBox.Show("Error no se genero el numero de folio vuelve a intentarlo");
                    return;
                }

                if (
                    Math.Round(double.Parse(lts_existentes), 2) < int.Parse(TxtLitrosMuestrear.Text)
                )
                {
                    MessageBox.Show("Litros insuficientes para muestrear");
                    return;
                }

                if (
                    ConexionMysql.insUpd_transaccion(
                        "INSERT INTO folios(folio,actualizado) values ('"
                            + TxtFolioMuestreo.Text
                            + "',0) "
                    ) == "Error"
                )
                {
                    return;
                }

                if (tipo == "fabrica")
                {
                    ObtenerIdMaximoGranelMovimientos();
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "INSERT INTO granel_movimientos(id_granel_movimientos,id_granel_entrada,id_solicitud,tipo,destino,folio,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                + id_max_granel_movimientos
                                + "','"
                                + id_granel_entrada
                                + "',0,'salida','muestreo','"
                                + TxtFolioMuestreo.Text
                                + "',"
                                + TxtLitrosMuestrear.Text
                                + ","
                                + grado_alcoholico_existente
                                + ","
                                + lts_existentes
                                + ",now(),NOW(),0,"
                                + Usuario.IdUsuario
                                + ") "
                        ) == "Error"
                    )
                    {
                        return;
                    }

                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE granel_entrada SET lts_existentes="
                                + (
                                    Math.Round(double.Parse(lts_existentes), 2)
                                    - int.Parse(TxtLitrosMuestrear.Text)
                                )
                                + ",actualizado=0 WHERE id_granel_entrada= '"
                                + id_granel_entrada
                                + "' "
                        ) == "Error"
                    )
                    {
                        return;
                    }
                }
                else if (tipo == "almacen")
                {
                    ///--- para lamacen

                    ObtenerIdMaximoAlmacenGranelMovimientos();
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "INSERT INTO almacen_granel_movimientos(id_almacen_granel_movimientos,id_almacen_granel_entrada,id_solicitud,tipo,destino,folio,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                + id_max_almacen_granel_movimientos
                                + "','"
                                + id_granel_entrada
                                + "',0,'salida','muestreo','"
                                + TxtFolioMuestreo.Text
                                + "',"
                                + TxtLitrosMuestrear.Text
                                + ","
                                + grado_alcoholico_existente
                                + ","
                                + lts_existentes
                                + ",now(),NOW(),0,"
                                + Usuario.IdUsuario
                                + ") "
                        ) == "Error"
                    )
                    {
                        return;
                    }

                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE almacen_granel_entrada SET lts_existentes="
                                + (
                                    Math.Round(double.Parse(lts_existentes), 2)
                                    - int.Parse(TxtLitrosMuestrear.Text)
                                )
                                + ",actualizado=0 WHERE id_almacen_granel_entrada= '"
                                + id_granel_entrada
                                + "' "
                        ) == "Error"
                    )
                    {
                        return;
                    }
                }
                else
                {
                    ObtenerIdMaximoGranelMovimientosEnvasado();
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "INSERT INTO granel_movimientos_envasado(id_granel_movimientos_envasado,id_granel_entrada_envasado,id_solicitud,tipo,destino,folio,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,actualizado,id_verificador) values ('"
                                + id_max_granel_movimientos_envasado
                                + "','"
                                + id_granel_entrada
                                + "',0,'salida','muestreo','"
                                + TxtFolioMuestreo.Text
                                + "',"
                                + TxtLitrosMuestrear.Text
                                + ","
                                + grado_alcoholico_existente
                                + ","
                                + lts_existentes
                                + ",now(),NOW(),0,"
                                + Usuario.IdUsuario
                                + ") "
                        ) == "Error"
                    )
                    {
                        return;
                    }

                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE granel_entrada_envasado SET lts_existentes="
                                + (
                                    Math.Round(double.Parse(lts_existentes), 2)
                                    - int.Parse(TxtLitrosMuestrear.Text)
                                )
                                + ",actualizado=0 WHERE id_granel_entrada_envasado= '"
                                + id_granel_entrada
                                + "' "
                        ) == "Error"
                    )
                    {
                        return;
                    }
                }

                ConexionMysql.transCompleta();
                MessageBox.Show("Muestreo realizado con éxito");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TxtLitrosMuestrear_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.soloNumeros(e);
        }

        private void TxtlitrosBarrica_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtlitrosBarrica.Text);
        }

        private void TxtNumeroDeBarricas_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtNumeroDeBarricas.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////guardamos en barricas ///////////////////////////////////////////////////////////
        private void BtnGuardarBarrica_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtlitrosBarrica.Text == "")
                {
                    MessageBox.Show("Favor de introducir litros para barrica");
                    TxtlitrosBarrica.Focus();
                    return;
                }
                if (TxtlitrosBarrica.Text == ".")
                {
                    MessageBox.Show("Favor de introducir litros reales");
                    TxtlitrosBarrica.Focus();
                    return;
                }
                if (TxtFolioBarrica.Text == "")
                {
                    MessageBox.Show("Error no se genero el numero de folio vuelve a intentarlo");
                    return;
                }
                if (
                    Math.Round(double.Parse(lts_existentes), 2)
                    < Math.Round(double.Parse(TxtlitrosBarrica.Text), 2)
                )
                {
                    MessageBox.Show("Litros insuficientes para ingresar a barrica");
                    return;
                }
                if (
                    Math.Round(double.Parse(lts_existentes), 2)
                        > Math.Round(double.Parse(TxtlitrosBarrica.Text), 2)
                    && no_lote == TxtLoteBarrica.Text
                )
                {
                    MessageBox.Show("Debe agregar un nuevo numero de lote");
                    return;
                }

                if (TxtNumeroDeBarricas.Text == "")
                {
                    MessageBox.Show("Debe ingresar un numero de barricas");
                    TxtNumeroDeBarricas.Focus();
                    return;
                }

                if (TxtNumeroDeBarricas.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un numero de barricas diferente de 0");
                    TxtNumeroDeBarricas.Focus();
                    return;
                }

                if (TxtNumeroDeBarricas.Text == ".")
                {
                    MessageBox.Show("Debe ingresar un numero de barricas real");
                    TxtNumeroDeBarricas.Focus();
                    return;
                }

                DialogResult check = MessageBox.Show(
                    "Verifica que los datos sean correctos",
                    "",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (check == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "INSERT INTO folios(folio,actualizado) values ('"
                                + TxtFolioBarrica.Text
                                + "',0) "
                        ) == "Error"
                    )
                    {
                        return;
                    }

                    if (tipo == "fabrica")
                    {
                        ObtenerIdMaximoGranelMovimientos();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos(id_granel_movimientos,id_granel_entrada,no_cliente,id_solicitud,tipo,destino,no_lote,folio,litros,grado_alcoholico,numero_de_contenedores_iniciales,numero_de_contenedores,lts_anteriores,fecha,fecha_movimiento,actualizado,litros_existentes,grado_alcoholico_existente,id_verificador) values ('"
                                    + id_max_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','"
                                    + no_cliente
                                    + "',0,'salida','barricas','"
                                    + TxtLoteBarrica.Text
                                    + "','"
                                    + TxtFolioBarrica.Text
                                    + "',"
                                    + TxtlitrosBarrica.Text
                                    + ","
                                    + grado_alcoholico_existente
                                    + ","
                                    + TxtNumeroDeBarricas.Text
                                    + ","
                                    + TxtNumeroDeBarricas.Text
                                    + ","
                                    + lts_existentes
                                    + ",'"
                                    + DataIngresoBarrica.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                    + "',NOW(),0,'"
                                    + TxtlitrosBarrica.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + Usuario.IdUsuario
                                    + ") "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada SET lts_existentes=ROUND(lts_existentes - "
                                    + TxtlitrosBarrica.Text
                                    + ",2),actualizado=0  WHERE id_granel_entrada= '"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else if (tipo == "almacen")
                    {
                        ///---- para almacen

                        ObtenerIdMaximoAlmacenGranelMovimientos();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO almacen_granel_movimientos(id_almacen_granel_movimientos,id_almacen_granel_entrada,no_cliente,id_solicitud,tipo,destino,no_lote,folio,litros,grado_alcoholico,numero_de_contenedores_iniciales,numero_de_contenedores,lts_anteriores,fecha,fecha_movimiento,actualizado,litros_existentes,grado_alcoholico_existente,id_verificador) values ('"
                                    + id_max_almacen_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','"
                                    + no_cliente
                                    + "',0,'salida','barricas','"
                                    + TxtLoteBarrica.Text
                                    + "','"
                                    + TxtFolioBarrica.Text
                                    + "',"
                                    + TxtlitrosBarrica.Text
                                    + ","
                                    + grado_alcoholico_existente
                                    + ","
                                    + TxtNumeroDeBarricas.Text
                                    + ","
                                    + TxtNumeroDeBarricas.Text
                                    + ","
                                    + lts_existentes
                                    + ",'"
                                    + DataIngresoBarrica.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                    + "',NOW(),0,'"
                                    + TxtlitrosBarrica.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + Usuario.IdUsuario
                                    + ") "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE almacen_granel_entrada SET lts_existentes=ROUND(lts_existentes - "
                                    + TxtlitrosBarrica.Text
                                    + ",2),actualizado=0  WHERE id_almacen_granel_entrada= '"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else
                    {
                        ObtenerIdMaximoGranelMovimientosEnvasado();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos_envasado(id_granel_movimientos_envasado,id_granel_entrada_envasado,no_cliente,id_solicitud,tipo,destino,no_lote,folio,litros,grado_alcoholico,numero_de_contenedores_iniciales,numero_de_contenedores,lts_anteriores,fecha,fecha_movimiento,actualizado,litros_existentes,grado_alcoholico_existente,id_verificador) values ('"
                                    + id_max_granel_movimientos_envasado
                                    + "','"
                                    + id_granel_entrada
                                    + "','"
                                    + no_cliente
                                    + "',0,'salida','barricas','"
                                    + TxtLoteBarrica.Text
                                    + "','"
                                    + TxtFolioBarrica.Text
                                    + "',"
                                    + TxtlitrosBarrica.Text
                                    + ","
                                    + grado_alcoholico_existente
                                    + ","
                                    + TxtNumeroDeBarricas.Text
                                    + ","
                                    + TxtNumeroDeBarricas.Text
                                    + ","
                                    + lts_existentes
                                    + ",'"
                                    + DataIngresoBarrica.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                    + "',NOW(),0,'"
                                    + TxtlitrosBarrica.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + Usuario.IdUsuario
                                    + ") "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes - "
                                    + TxtlitrosBarrica.Text
                                    + ",2),actualizado=0  WHERE id_granel_entrada_envasado= '"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();

                    MessageBox.Show("Ingreso a barrica realizado con éxito");
                    this.Close();
                } //----------- Fin del DialogMessageBox  --Aceptar-------------
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ChekCanbiarLote_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekCambiarLote.Checked == true)
            {
                TxtLoteBarrica.ReadOnly = false;
            }
            else
            {
                TxtLoteBarrica.ReadOnly = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////guardamos en vidrio//////////////////////////////////////////////////////////////////////



        private void BtnVidrio_Click(object sender, EventArgs e)
        {
            ChekCambiarLoteVidrio.Checked = false;
            TxtNoLoteVidrio.ReadOnly = true;
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = true;
            PanelSalida.Visible = false;
            PanelUnion.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelMensajes.Visible = false;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;
            TxtNoLoteVidrio.Text = no_lote;

            string estado = ConexionMysql.regresaCampoConsulta(
                "SELECT estados.codigo from estados inner join relacion_cp_estado on  estados.clave=relacion_cp_estado.clave_estado inner join clientes on relacion_cp_estado.cp=clientes.cp  where clientes.no_cliente='"
                    + no_cliente
                    + "'"
            );
            string Folio = ConexionMysql.regresaCampoConsulta("SELECT max(id_folio) FROM  folios ");

            if (Folio == "")
            {
                Folio = "1";
                TxtFolioVidrio.Text = Usuario.IdUsuario + "00000" + Folio + "VR" + estado;
            }
            else
            {
                int NuevoFolio = 0;
                string cero = "";
                NuevoFolio = int.Parse(Folio) + 1;
                if (NuevoFolio.ToString().Length == 1)
                {
                    cero = "00000";
                }
                else if (NuevoFolio.ToString().Length == 2)
                {
                    cero = "0000";
                }
                else if (NuevoFolio.ToString().Length == 3)
                {
                    cero = "000";
                }
                else if (NuevoFolio.ToString().Length == 4)
                {
                    cero = "00";
                }
                else if (NuevoFolio.ToString().Length == 5)
                {
                    cero = "0";
                }
                TxtFolioVidrio.Text = Usuario.IdUsuario + cero + NuevoFolio + "VR" + estado;
            }
        }

        private void ChekCambiarLoteVidrio_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekCambiarLoteVidrio.Checked == true)
            {
                TxtNoLoteVidrio.ReadOnly = false;
            }
            else
            {
                TxtNoLoteVidrio.ReadOnly = true;
            }
        }

        private void TxtNumeroDeContenedoresVidrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtNumeroDeContenedoresVidrio.Text);
        }

        private void BtnGuardarVidrio_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtLitrosVidrio.Text == "")
                {
                    MessageBox.Show("Favor de introducir litros");
                    return;
                }
                if (TxtLitrosVidrio.Text == ".")
                {
                    MessageBox.Show("Favor de introducir litros reales");
                    return;
                }
                if (TxtFolioVidrio.Text == "")
                {
                    MessageBox.Show("Error no se genero el numero de folio vuelve a intentarlo");
                    return;
                }
                if (
                    Math.Round(double.Parse(lts_existentes), 2)
                    < Math.Round(double.Parse(TxtLitrosVidrio.Text), 2)
                )
                {
                    MessageBox.Show("Litros insuficientes para ingresar a vidrio");
                    return;
                }
                if (
                    Math.Round(double.Parse(lts_existentes), 2)
                        > Math.Round(double.Parse(TxtLitrosVidrio.Text), 2)
                    && no_lote == TxtNoLoteVidrio.Text
                )
                {
                    MessageBox.Show("Debe agregar un nuevo numero de lote");
                    return;
                }

                if (TxtNumeroDeContenedoresVidrio.Text == "")
                {
                    MessageBox.Show("Debe ingresar un numero de contenedores");
                    TxtNumeroDeContenedoresVidrio.Focus();
                    return;
                }

                if (TxtNumeroDeContenedoresVidrio.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un numero de contenedores diferente de 0");
                    TxtNumeroDeContenedoresVidrio.Focus();
                    return;
                }

                if (TxtNumeroDeContenedoresVidrio.Text == ".")
                {
                    MessageBox.Show("Debe ingresar un numero de contenedores real");
                    TxtNumeroDeContenedoresVidrio.Focus();
                    return;
                }

                DialogResult check = MessageBox.Show(
                    "Verifica que los datos sean correctos",
                    "",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (check == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "INSERT INTO folios(folio,actualizado) values ('"
                                + TxtFolioVidrio.Text
                                + "',0) "
                        ) == "Error"
                    )
                    {
                        return;
                    }

                    if (tipo == "fabrica")
                    {
                        ObtenerIdMaximoGranelMovimientos();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos(id_granel_movimientos,id_granel_entrada,no_cliente,id_solicitud,tipo,destino,no_lote,folio,litros,grado_alcoholico,numero_de_contenedores_iniciales,numero_de_contenedores,lts_anteriores,fecha,fecha_movimiento,actualizado,litros_existentes,grado_alcoholico_existente,id_verificador) values ('"
                                    + id_max_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','"
                                    + no_cliente
                                    + "',0,'salida','vidrio','"
                                    + TxtNoLoteVidrio.Text
                                    + "','"
                                    + TxtFolioVidrio.Text
                                    + "','"
                                    + TxtLitrosVidrio.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + TxtNumeroDeContenedoresVidrio.Text
                                    + ","
                                    + TxtNumeroDeContenedoresVidrio.Text
                                    + ","
                                    + lts_existentes
                                    + ",'"
                                    + DataIngresoVidrio.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                    + "',NOW(),0,'"
                                    + TxtLitrosVidrio.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + Usuario.IdUsuario
                                    + ") "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada SET lts_existentes=ROUND(lts_existentes - "
                                    + TxtLitrosVidrio.Text
                                    + ",2),actualizado=0  WHERE id_granel_entrada= '"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else if (tipo == "almacen")
                    {
                        ///--- para almacen
                        ObtenerIdMaximoAlmacenGranelMovimientos();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO almacen_granel_movimientos(id_almacen_granel_movimientos,id_almacen_granel_entrada,no_cliente,id_solicitud,tipo,destino,no_lote,folio,litros,grado_alcoholico,numero_de_contenedores_iniciales,numero_de_contenedores,lts_anteriores,fecha,fecha_movimiento,actualizado,litros_existentes,grado_alcoholico_existente,id_verificador) values ('"
                                    + id_max_almacen_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','"
                                    + no_cliente
                                    + "',0,'salida','vidrio','"
                                    + TxtNoLoteVidrio.Text
                                    + "','"
                                    + TxtFolioVidrio.Text
                                    + "','"
                                    + TxtLitrosVidrio.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + TxtNumeroDeContenedoresVidrio.Text
                                    + ","
                                    + TxtNumeroDeContenedoresVidrio.Text
                                    + ","
                                    + lts_existentes
                                    + ",'"
                                    + DataIngresoVidrio.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                    + "',NOW(),0,'"
                                    + TxtLitrosVidrio.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + Usuario.IdUsuario
                                    + ") "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE almacen_granel_entrada SET lts_existentes=ROUND(lts_existentes - "
                                    + TxtLitrosVidrio.Text
                                    + ",2),actualizado=0  WHERE id_almacen_granel_entrada= '"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else
                    {
                        ObtenerIdMaximoGranelMovimientosEnvasado();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos_envasado(id_granel_movimientos_envasado,id_granel_entrada_envasado,no_cliente,id_solicitud,tipo,destino,no_lote,folio,litros,grado_alcoholico,numero_de_contenedores_iniciales,numero_de_contenedores,lts_anteriores,fecha,fecha_movimiento,actualizado,litros_existentes,grado_alcoholico_existente,id_verificador) values ('"
                                    + id_max_granel_movimientos_envasado
                                    + "','"
                                    + id_granel_entrada
                                    + "','"
                                    + no_cliente
                                    + "',0,'salida','vidrio','"
                                    + TxtNoLoteVidrio.Text
                                    + "','"
                                    + TxtFolioVidrio.Text
                                    + "','"
                                    + TxtLitrosVidrio.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + TxtNumeroDeContenedoresVidrio.Text
                                    + ","
                                    + TxtNumeroDeContenedoresVidrio.Text
                                    + ","
                                    + lts_existentes
                                    + ",'"
                                    + DataIngresoVidrio.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                    + "',NOW(),0,'"
                                    + TxtLitrosVidrio.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + Usuario.IdUsuario
                                    + ") "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada_envasado SET lts_existentes=ROUND(lts_existentes - "
                                    + TxtLitrosVidrio.Text
                                    + ",2),actualizado=0  WHERE id_granel_entrada_envasado= '"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Ingreso maduracion a vidrio realizado éxito");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TxtLitrosVidrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosVidrio.Text);
        }

        /////////////////////////////////////////////////////////////////--<<<tridestilacion>>>--////////////////////////// //////////////////
        private void BtnTridestilacion_Click(object sender, EventArgs e)
        {
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelSalida.Visible = false;
            PanelUnion.Visible = false;
            PanelMensajes.Visible = false;
            PanelTridestilacion.Visible = true;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;

            lblNoloteDestilacionAdicional.Text = no_lote;

            CmbNoDestilacion.Items.Insert(0, "---Elije una opción---");
            CmbNoDestilacion.Items.Insert(1, "Segunda destilacion");
            CmbNoDestilacion.Items.Insert(2, "Tercera destilacion");
            CmbNoDestilacion.Items.Insert(3, "Cuarta destilacion");
            CmbNoDestilacion.Items.Insert(4, "Quinta destilacion");
            CmbNoDestilacion.SelectedIndex = 0;
        }

        private void chBxDestiladoCon_CheckedChanged(object sender, EventArgs e)
        {
            //si esta checkedado hace esto
            if (chBxDestiladoCon.Checked)
            {
                richTextIngredienteTridestilacion.Enabled = true;
                label13.Enabled = true;
            }
            else
            {
                richTextIngredienteTridestilacion.Enabled = false;
                label13.Enabled = false;
                richTextIngredienteTridestilacion.Text = "";
            }
        }

        private void BtnInformacionTridestilacion_MouseHover(object sender, EventArgs e)
        {
            TxtMensajeTridestilacion.Visible = true;
            //TxtMensajeTridestilacion.Text("hola \n como estas?");
            //TxtMensajeTridestilacion.Text="Proceso Normal: NO se Cobra\nAjuste de Parametros por no pasar análisis FQ: SI se Cobra";
            //label47.Text = "<b>Proceso Normal:</b> NO se Cobra\n<b>Ajuste de Parametros</b> por no pasar análisis FQ: SI se Cobra";
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            label50.Visible = true;
            label51.Visible = true;
            label52.Visible = true;
        }

        private void BtnInformacionTridestilacion_MouseLeave(object sender, EventArgs e)
        {
            TxtMensajeTridestilacion.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            label49.Visible = false;
            label50.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
        }

        //=========================== TRIDESTILACION ======================================
        private void BtnGuardarTridestilacion_Click(object sender, EventArgs e)
        {
            // Te encargo kevin que termines este boton de tridestilacion :p


            //if (ConexionMysql.insUpd_transaccion("UPDATE granel_entrada SET   abocante='" + TxtAbocante.Text + "' ,ingrediente='" + TxtIngrediente.Text + "',lts_existentes='" + TxtLitrosTridestilacion.Text + "',grado_alcoholico_existente='"+TxtGradoAlcoholicoTridestilacion.Text+"'actualizado=0  WHERE id_granel_entrada= '" + id_granel_entrada + "' ") == "Error")
            //{
            //    return;
            //}
            //ConexionMysql.transCompleta();
            //MessageBox.Show("Éxito");
            //this.Close();
            try
            {
                if (TxtLitrosTridestilacion.Text == "")
                {
                    MessageBox.Show("Favor de introducir litros resultantes");
                    return;
                }

                if (CmbNoDestilacion.Text == "---Elije una opción---")
                {
                    MessageBox.Show("Favor de seleccionar un numero de destilación");
                    return;
                }

                if (TxtGradoTridestilacion.Text == "")
                {
                    MessageBox.Show("Favor de introducir grados resultantes");
                    return;
                }
                String tipo_cobro;

                if (!rdBtnNormal.Checked)
                {
                    if (!rdBtnAjuste.Checked)
                    {
                        MessageBox.Show("Favor de seleccionar tipo de cobro");
                        return;
                    }
                    else
                    {
                        tipo_cobro = "ajuste";
                    }
                }
                else
                {
                    tipo_cobro = "normal";
                }

                DialogResult check = MessageBox.Show(
                    "Verifica que los datos sean correctos",
                    "",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (check == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    if (tipo == "fabrica")
                    {
                        ObtenerIdMaximoGranelMovimientos();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos (id_granel_movimientos,id_granel_entrada,id_solicitud, tipo, destino, tipo_cobro, observaciones, litros, grado_alcoholico,no_lote,folio,litros_existentes, grado_alcoholico_existente,lts_anteriores, fecha,fecha_movimiento, id_verificador, actualizado) VALUES ('"
                                    + id_max_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "',0,'salida','"
                                    + CmbNoDestilacion.Text
                                    + "','"
                                    + tipo_cobro
                                    + "','"
                                    + richTextMotivoTridestilacion.Text
                                    + "','"
                                    + lts_existentes
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "','','','"
                                    + TxtLitrosTridestilacion.Text
                                    + "','"
                                    + TxtGradoTridestilacion.Text
                                    + "',"
                                    + lts_existentes
                                    + ",'"
                                    + DataFechaTridestilacionFin.Value.ToString(
                                        "yyyy-MM-dd HH:mm:ss"
                                    )
                                    + "',NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0) "
                            ) == "Error"
                        )
                        {
                            return;
                        }

                        if (chBxDestiladoCon.Checked)
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET clase='Destilado con', ingrediente='"
                                        + richTextIngredienteTridestilacion.Text
                                        + "', lts_existentes='"
                                        + TxtLitrosTridestilacion.Text
                                        + "', grado_alcoholico_existente='"
                                        + TxtGradoTridestilacion.Text
                                        + "', actualizado=0  WHERE id_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET lts_existentes='"
                                        + TxtLitrosTridestilacion.Text
                                        + "', grado_alcoholico_existente='"
                                        + TxtGradoTridestilacion.Text
                                        + "', actualizado=0  WHERE id_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }
                    else if (tipo == "almacen")
                    {
                        ///--para almacen
                        ObtenerIdMaximoAlmacenGranelMovimientos();
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos,id_almacen_granel_entrada,id_solicitud, tipo, destino, tipo_cobro, observaciones, litros, grado_alcoholico,no_lote,folio,litros_existentes, grado_alcoholico_existente,lts_anteriores,fecha,fecha_movimiento, id_verificador, actualizado) VALUES ('"
                                    + id_max_almacen_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "',0,'salida','"
                                    + CmbNoDestilacion.Text
                                    + "','"
                                    + tipo_cobro
                                    + "','"
                                    + richTextMotivoTridestilacion.Text
                                    + "','"
                                    + lts_existentes
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "','','','"
                                    + TxtLitrosTridestilacion.Text
                                    + "','"
                                    + TxtGradoTridestilacion.Text
                                    + "',"
                                    + lts_existentes
                                    + ",'"
                                    + DataFechaTridestilacionFin.Value.ToString(
                                        "yyyy-MM-dd HH:mm:ss"
                                    )
                                    + "',NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0) "
                            ) == "Error"
                        )
                        {
                            return;
                        }

                        if (chBxDestiladoCon.Checked)
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET clase='Destilado con', ingrediente='"
                                        + richTextIngredienteTridestilacion.Text
                                        + "', lts_existentes='"
                                        + TxtLitrosTridestilacion.Text
                                        + "', grado_alcoholico_existente='"
                                        + TxtGradoTridestilacion.Text
                                        + "', actualizado=0  WHERE id_almacen_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET lts_existentes='"
                                        + TxtLitrosTridestilacion.Text
                                        + "', grado_alcoholico_existente='"
                                        + TxtGradoTridestilacion.Text
                                        + "', actualizado=0  WHERE id_almacen_granel_entrada= '"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }

                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();
                    //Console.Write("idgranel_entrada: " + id_granel_entrada);
                    // MessageBox.Show("idgranelentrada: " + id_granel_entrada);
                } //------- Fin del Dialog messageBox
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /////////////////////////////////////////////////////////////////--<<<Fin tridestilacion>>>--////////////////////////// //////////////////



        /////////////////////////////////////////////////////////////////////--<<< Union >>>--////////////////////////////////////////////////////


        //variables para controlar movimientos de union-divicion
        string litros;
        double litros_suma;
        string grado_alcoholico;
        double grado_alcoholico_nuevo;
        string id_planta;
        string id_predio;
        string agave_coccion_kg;
        string no_lote_union;
        string id_comun;
        string clase_union;
        string categoria_union;
        string abocante;
        string ingrediente;
        string CategoriaMezcalComparar = "";
        string claseMezcalComparar = "";
        string CategoriaMezcal = "";
        string claseMezcal = "";

        //----------------- para la clase y categoria -------------
        int mzkl = 0;
        int maartesanal = 0;
        int mancetral = 0;
        int des_con = 0;
        int abocado_con = 0;
        int boj = 0;
        int madurado_vidrio = 0;
        int reposado = 0;
        int Añejo = 0;
        int s_klss = 0;

        string TxtIngredienteEnvasadoDB = "";
        string ingredientecadena = "";
        string sep = "";

        //-----------------=================-------------
        DataTable dtaProduccionParaDividirAgranel;
        DataTable dtsTanques;
        Boolean BanderaUnion = true;

        //al presionar union
        private void BtnUnion_Click(object sender, EventArgs e)
        {
            addTablaTanques();
            addTablaProduccionParaDividirAgranel();
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelSalida.Visible = false;
            PanelUnion.Visible = true;
            panelAbocante.Visible = false;
            LblUnion.Visible = true;
            PanelMensajes.Visible = false;
            LblExtraccion.Visible = false;
            PanelFq.Visible = false;

            lblNoloteUnion.Text = no_lote;

            if (tipo == "fabrica")
            {
                ConexionMysql.llenaComboAutocomplit(
                    ref CmbLotesGranel,
                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='"
                        + id_fabrica
                        + "'  AND id_granel_entrada!='"
                        + id_granel_entrada
                        + "' and  lts_existentes > 0  order by id",
                    "id_granel_entrada",
                    "produccion"
                );
                /* ConexionMysql.llenaCombo(ref CmbLotesGranel, "SELECT  CONCAT('No Lote : ',no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='" + id_fabrica + "'  AND id_granel_entrada!='" + id_granel_entrada + "' and  lts_existentes > 0  order by id", "id_granel_entrada", "produccion");*/
            }
            else if (tipo == "almacen")
            {
                ConexionMysql.llenaComboAutocomplit(
                    ref CmbLotesGranel,
                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen='"
                        + id_almacen
                        + "'  AND id_almacen_granel_entrada!='"
                        + id_granel_entrada
                        + "' and  lts_existentes > 0  order by id",
                    "id_almacen_granel_entrada",
                    "produccion"
                );
            }
            else
            {
                ConexionMysql.llenaComboAutocomplit(
                    ref CmbLotesGranel,
                    "SELECT  CONCAT( no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='"
                        + id_envasadora
                        + "'  AND id_granel_entrada_envasado!='"
                        + id_granel_entrada
                        + "' and  lts_existentes > 0  order by id",
                    "id_granel_entrada_envasado",
                    "produccion"
                );
            }
        }

        private void addTablaTanques()
        {
            dtsTanques = new DataTable();
            dtsTanques.Columns.Add("TANQUE", Type.GetType("System.String"));
            dtsTanques.Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaTanques.DataSource = dtsTanques;
        }

        // crear tabla de produccion  para guardar el registro agranel union
        private void addTablaProduccionParaDividirAgranel()
        {
            dtaProduccionParaDividirAgranel = new DataTable();
            dtaProduccionParaDividirAgranel.Columns.Add("NO_LOTE", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add("ID_GRANEL", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add("ID_COMUN", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add("ID_PLANTA", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add("ID_PREDIO", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add(
                "AGAVE_COCCION_KG",
                Type.GetType("System.String")
            );
            dtaProduccionParaDividirAgranel.Columns.Add("ABOCANTE", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add(
                "INGREDIENTE",
                Type.GetType("System.String")
            );
            dtaProduccionParaDividirAgranel.Columns.Add("CLASE", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add("CATEGORIA", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add("LITROS", Type.GetType("System.String"));
            dtaProduccionParaDividirAgranel.Columns.Add(
                "%_ALCOHOLICO",
                Type.GetType("System.String")
            );
            dtaProduccionParaDividirAgranel.Columns.Add("QUITAR", Type.GetType("System.Byte[]"));
            DtaProduccionParaDividirAgranel.DataSource = dtaProduccionParaDividirAgranel;
            DtaProduccionParaDividirAgranel.Columns[1].Visible = false;
            DtaProduccionParaDividirAgranel.Columns[2].Visible = false;
            DtaProduccionParaDividirAgranel.Columns[3].Visible = false;
            DtaProduccionParaDividirAgranel.Columns[4].Visible = false;
            DtaProduccionParaDividirAgranel.Columns[5].Visible = false;
            DtaProduccionParaDividirAgranel.Columns[6].Visible = false;
        }

        //al selecionar unj lote carga datos
        private void CmbLotesGranel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbLotesGranel.DataSource == null)
                {
                    litros = "";
                    grado_alcoholico = "";
                    id_planta = "";
                    id_predio = "";
                    agave_coccion_kg = "";
                    no_lote_union = "";
                    id_comun = "";
                    clase_union = "";
                    categoria_union = "";
                    abocante = "";
                    ingrediente = "";
                }
                else
                {
                    DataSet Datos = new DataSet();
                    if (tipo == "fabrica")
                    {
                        ConexionMysql.llenaDataset(
                            ref Datos,
                            "SELECT lts_existentes,grado_alcoholico_existente,id_planta,id_predio,agave_coccion_kg,no_lote,id_comun,clase,categoria,abocante,ingrediente  FROM granel_entrada  WHERE id_granel_entrada='"
                                + CmbLotesGranel.SelectedValue
                                + "'"
                        );
                    }
                    else if (tipo == "almacen")
                    {
                        ///-- para almacen
                        ConexionMysql.llenaDataset(
                            ref Datos,
                            "SELECT lts_existentes,grado_alcoholico_existente,id_planta,id_predio,agave_coccion_kg,no_lote,id_comun,clase,categoria,abocante,ingrediente  FROM almacen_granel_entrada  WHERE id_almacen_granel_entrada='"
                                + CmbLotesGranel.SelectedValue
                                + "'"
                        );
                    }
                    else
                    {
                        ConexionMysql.llenaDataset(
                            ref Datos,
                            "SELECT lts_existentes,grado_alcoholico_existente,id_planta,id_predio,agave_coccion_kg,no_lote,id_comun,clase,categoria,abocante,ingrediente  FROM granel_entrada_envasado  WHERE id_granel_entrada_envasado='"
                                + CmbLotesGranel.SelectedValue
                                + "'"
                        );
                    }

                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        litros = row["lts_existentes"].ToString();
                        grado_alcoholico = row["grado_alcoholico_existente"].ToString();
                        id_planta = row["id_planta"].ToString();
                        id_predio = row["id_predio"].ToString();
                        agave_coccion_kg = row["agave_coccion_kg"].ToString();
                        no_lote_union = row["no_lote"].ToString();
                        id_comun = row["id_comun"].ToString();
                        clase_union = row["clase"].ToString();
                        categoria_union = row["categoria"].ToString();
                        abocante = row["abocante"].ToString();
                        ingrediente = row["ingrediente"].ToString();
                    }

                    if (BanderaUnion == true)
                    {
                        if (tipo == "fabrica")
                        {
                            TxtNoLote.Text = ConexionMysql.regresaCampoConsulta(
                                "SELECT no_lote FROM  granel_entrada  WHERE id_granel_entrada='"
                                    + id_granel_entrada
                                    + "'"
                            );
                        }
                        else if(tipo == "almacen")
                        {
                            TxtNoLote.Text = ConexionMysql.regresaCampoConsulta(
                                "SELECT no_lote FROM  almacen_granel_entrada  WHERE id_almacen_granel_entrada='"
                                    + id_granel_entrada
                                    + "'"
                            );
                        }
                        else if (tipo == "envasadora")
                        {
                            TxtNoLote.Text = ConexionMysql.regresaCampoConsulta(
                                "SELECT no_lote FROM  granel_entrada_envasado  WHERE id_granel_entrada_envasado='"
                                    + id_granel_entrada
                                    + "'"
                            );
                        }

                        TxtNoLote.Enabled = false;
                        BtnAgregarTanque.Enabled = false;
                        TxtTanque.Text = "";
                        TxtTanque.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        //valida solo puntos y numeros
        private void TxtLitros_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitros.Text);
        }

        //agregar los selecionado
        private void BtnAgregarLotesAgranel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbLotesGranel.SelectedValue == null)
                {
                    MessageBox.Show("No tienes lotes para agregar");
                    return;
                }
                if (TxtLitros.Text == "")
                {
                    MessageBox.Show("No ha introducido litros");
                    TxtLitros.Focus();
                    return;
                }
                if (TxtLitros.Text == ".")
                {
                    MessageBox.Show("Agrege un valor real de litros");
                    TxtLitros.Focus();
                    return;
                }
                if (TxtLitros.Text == "0")
                {
                    MessageBox.Show("Agrege un valor diferente de cero");
                    TxtLitros.Focus();
                    return;
                }
                if (
                    Math.Round(double.Parse(litros), 2)
                    < Math.Round(double.Parse(TxtLitros.Text), 2)
                )
                {
                    MessageBox.Show("Existencia insuficiente");
                    return;
                }
                DataRow fila = dtaProduccionParaDividirAgranel.NewRow();
                fila["NO_LOTE"] = no_lote_union;
                fila["ID_GRANEL"] = CmbLotesGranel.SelectedValue;
                fila["CLASE"] = clase_union;
                fila["CATEGORIA"] = categoria_union;
                fila["ID_COMUN"] = id_comun;
                ;
                fila["ID_PLANTA"] = id_planta;
                fila["ID_PREDIO"] = id_predio;
                fila["AGAVE_COCCION_KG"] = agave_coccion_kg;
                fila["ABOCANTE"] = abocante;
                fila["INGREDIENTE"] = ingrediente;
                fila["LITROS"] = TxtLitros.Text;
                fila["%_ALCOHOLICO"] = grado_alcoholico;
                fila["QUITAR"] = ConvertImageToByteArray(
                    Properties.Resources.delete,
                    System.Drawing.Imaging.ImageFormat.Png
                );
                dtaProduccionParaDividirAgranel.Rows.Add(fila);
                TxtLitros.Text = "";
                CmbLotesGranel.DataSource = null;

                string produccion = "";
                string coma = "";
                if (BanderaUnion == true)
                {
                    produccion = "'" + id_granel_entrada + "',";
                }
                for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                {
                    produccion +=
                        coma
                        + "'"
                        + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL"].Value
                        + "'";
                    coma = ",";
                }
                if (tipo == "fabrica")
                {
                    ConexionMysql.llenaComboAutocomplit(
                        ref CmbLotesGranel,
                        "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN  ("
                            + produccion
                            + ") and id_fabrica='"
                            + id_fabrica
                            + "'  AND lts_existentes > 0  order by id",
                        "id_granel_entrada",
                        "produccion"
                    );
                }
                else if (tipo == "almacen")
                {
                    ///--- tipo almacen
                    ConexionMysql.llenaComboAutocomplit(
                        ref CmbLotesGranel,
                        "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen_granel_entrada NOT IN  ("
                            + produccion
                            + ") and id_almacen='"
                            + id_almacen
                            + "'  AND lts_existentes > 0  order by id",
                        "id_almacen_granel_entrada",
                        "produccion"
                    );
                }
                else
                {
                    ConexionMysql.llenaComboAutocomplit(
                        ref CmbLotesGranel,
                        "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado  FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN  ("
                            + produccion
                            + ") and id_envasadora='"
                            + id_envasadora
                            + "'  AND lts_existentes > 0  order by id",
                        "id_granel_entrada_envasado",
                        "produccion"
                    );
                }

                //if ( dtaProduccionParaDividirAgranel.Rows.Count > 1){
                gfe_catClass();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        //esta funciones ´para agregar la imagen a las tablas
        public static byte[] ConvertImageToByteArray(
            System.Drawing.Image imageToConvert,
            System.Drawing.Imaging.ImageFormat formatOfImage
        )
        {
            byte[] Ret;
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return Ret;
        }

        //QUITRA LOTES AGRANEL
        private void DtaProduccionParaDividirAgranel_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaProduccionParaDividirAgranel.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaProduccionParaDividirAgranel.Rows.RemoveAt(e.RowIndex);
                    dtaProduccionParaDividirAgranel.AcceptChanges();
                    CmbLotesGranel.DataSource = null;
                    if (DtaProduccionParaDividirAgranel.Rows.Count > 0)
                    {
                        string produccion = "";
                        string coma = "";
                        if (BanderaUnion == true)
                        {
                            produccion = "'" + id_granel_entrada + "',";
                        }
                        for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                        {
                            produccion +=
                                coma
                                + "'"
                                + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL"].Value
                                + "'";
                            coma = ",";
                        }
                        if (tipo == "fabrica")
                        {
                            ConexionMysql.llenaComboAutocomplit(
                                ref CmbLotesGranel,
                                "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN  ("
                                    + produccion
                                    + ") and id_fabrica='"
                                    + id_fabrica
                                    + "'  AND lts_existentes > 0  order by id",
                                "id_granel_entrada",
                                "produccion"
                            );
                        }
                        else if (tipo == "almacen")
                        {
                            ///---- para almacen
                            ConexionMysql.llenaComboAutocomplit(
                                ref CmbLotesGranel,
                                "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen_granel_entrada NOT IN  ("
                                    + produccion
                                    + ") and id_almacen='"
                                    + id_fabrica
                                    + "'  AND lts_existentes > 0  order by id",
                                "id_almacen_granel_entrada",
                                "produccion"
                            );
                        }
                        else
                        {
                            ConexionMysql.llenaComboAutocomplit(
                                ref CmbLotesGranel,
                                "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN  ("
                                    + produccion
                                    + ") and id_envasadora='"
                                    + id_envasadora
                                    + "'  AND lts_existentes > 0  order by id",
                                "id_granel_entrada_envasado",
                                "produccion"
                            );
                        }
                    }
                    else
                    {
                        ///--- si es una sola produccion entra

                        if (BanderaUnion == true)
                        {
                            if (tipo == "fabrica")
                            {
                                ConexionMysql.llenaComboAutocomplit(
                                    ref CmbLotesGranel,
                                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='"
                                        + id_fabrica
                                        + "'  AND id_granel_entrada!='"
                                        + id_granel_entrada
                                        + "' and  lts_existentes > 0  order by id",
                                    "id_granel_entrada",
                                    "produccion"
                                );
                            }
                            else if (tipo == "almacen")
                            {
                                ///--- para almacen
                                ConexionMysql.llenaComboAutocomplit(
                                    ref CmbLotesGranel,
                                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen='"
                                        + id_fabrica
                                        + "'  AND id_almacen_granel_entrada!='"
                                        + id_granel_entrada
                                        + "' and  lts_existentes > 0  order by id",
                                    "id_almacen_granel_entrada",
                                    "produccion"
                                );
                            }
                            else
                            {
                                ConexionMysql.llenaComboAutocomplit(
                                    ref CmbLotesGranel,
                                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='"
                                        + id_envasadora
                                        + "'  AND id_granel_entrada_envasado!='"
                                        + id_granel_entrada
                                        + "' and  lts_existentes > 0  order by id",
                                    "id_granel_entrada_envasado",
                                    "produccion"
                                );
                            }
                        }
                        else
                        {
                            if (tipo == "fabrica")
                            {
                                ConexionMysql.llenaComboAutocomplit(
                                    ref CmbLotesGranel,
                                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where  id_fabrica='"
                                        + id_fabrica
                                        + "'  AND lts_existentes > 0  order by id",
                                    "id_granel_entrada",
                                    "produccion"
                                );
                            }
                            if (tipo == "almacen")
                            {
                                /// para almacen
                                ConexionMysql.llenaComboAutocomplit(
                                    ref CmbLotesGranel,
                                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where  id_almacen='"
                                        + id_fabrica
                                        + "'  AND lts_existentes > 0  order by id",
                                    "id_almacen_granel_entrada",
                                    "produccion"
                                );
                            }
                            else
                            {
                                ConexionMysql.llenaComboAutocomplit(
                                    ref CmbLotesGranel,
                                    "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where  id_envasadora='"
                                        + id_envasadora
                                        + "'  AND lts_existentes > 0  order by id",
                                    "id_granel_entrada_envasado",
                                    "produccion"
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //controla el cambi d eunion o extracion
        private void BtnCambio_Click(object sender, EventArgs e)
        {
            if (BanderaUnion == true)
            {
                dtaProduccionParaDividirAgranel.Clear();
                BanderaUnion = false;
                LblExtraccion.Visible = true;
                LblUnion.Visible = false;
                TxtNoLote.Text = "";
                TxtNoLote.Enabled = true;
                BtnAgregarTanque.Enabled = true;
                TxtTanque.Text = "";
                TxtTanque.Enabled = true;
                if (DtaProduccionParaDividirAgranel.Rows.Count > 0)
                {
                    string produccion = "";
                    string coma = "";
                    for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                    {
                        produccion +=
                            coma
                            + "'"
                            + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL"].Value
                            + "'";
                        coma = ",";
                    }

                    if (tipo == "fabrica")
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN  ("
                                + produccion
                                + ") and id_fabrica='"
                                + id_fabrica
                                + "'  AND lts_existentes > 0  order by id",
                            "id_granel_entrada",
                            "produccion"
                        );
                    }
                    else if (tipo == "almacen")
                    {
                        ////---- para almacen
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen_granel_entrada NOT IN  ("
                                + produccion
                                + ") and id_almacen='"
                                + id_almacen
                                + "'  AND lts_existentes > 0  order by id",
                            "id_almacen_granel_entrada",
                            "produccion"
                        );
                    }
                    else
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN  ("
                                + produccion
                                + ") and id_envasadora='"
                                + id_envasadora
                                + "'  AND lts_existentes > 0  order by id",
                            "id_granel_entrada_envasado",
                            "produccion"
                        );
                    }
                }
                else
                {
                    if (tipo == "fabrica")
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='"
                                + id_fabrica
                                + "'  AND   lts_existentes > 0  order by id",
                            "id_granel_entrada",
                            "produccion"
                        );
                    }
                    else if (tipo == "almacen")
                    {
                        /// ---- para almacen
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen='"
                                + id_almacen
                                + "'  AND   lts_existentes > 0  order by id",
                            "id_almacen_granel_entrada",
                            "produccion"
                        );
                    }
                    else
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT(no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='"
                                + id_envasadora
                                + "'  AND   lts_existentes > 0  order by id",
                            "id_granel_entrada_envasado",
                            "produccion"
                        );
                    }
                }
            }
            ///-- fin de BanderaUnion
            else
            {
                dtaProduccionParaDividirAgranel.Clear();
                BanderaUnion = true;
                LblExtraccion.Visible = false;
                LblUnion.Visible = true;
                if (tipo == "fabrica")
                {
                    TxtNoLote.Text = ConexionMysql.regresaCampoConsulta(
                        "SELECT no_lote FROM  granel_entrada  WHERE id_granel_entrada='"
                            + id_granel_entrada
                            + "'"
                    );
                }
                else if (tipo == "almacen")
                {
                    ///=== para almacen
                    ///
                    TxtNoLote.Text = ConexionMysql.regresaCampoConsulta(
                        "SELECT no_lote FROM  almacen_granel_entrada  WHERE id_almacen_granel_entrada='"
                            + id_granel_entrada
                            + "'"
                    );
                }
                else
                {
                    TxtNoLote.Text = ConexionMysql.regresaCampoConsulta(
                        "SELECT no_lote FROM  granel_entrada_envasado  WHERE id_granel_entrada_envasado='"
                            + id_granel_entrada
                            + "'"
                    );
                }

                TxtNoLote.Enabled = false;
                BtnAgregarTanque.Enabled = false;
                TxtTanque.Text = "";
                TxtTanque.Enabled = false;
                if (DtaProduccionParaDividirAgranel.Rows.Count > 0)
                {
                    string produccion = "";
                    string coma = "";
                    if (BanderaUnion == true)
                    {
                        produccion = "'" + id_granel_entrada + "',";
                    }
                    for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                    {
                        produccion +=
                            coma
                            + "'"
                            + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL"].Value
                            + "'";
                        coma = ",";
                    }
                    if (tipo == "fabrica")
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT( no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_granel_entrada NOT IN  ("
                                + produccion
                                + ") and id_fabrica='"
                                + id_fabrica
                                + "'  AND lts_existentes > 0  order by id",
                            "id_granel_entrada",
                            "produccion"
                        );
                    }
                    else if (tipo == "almacen")
                    {
                        ///----  para almacen
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT( no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen_granel_entrada NOT IN  ("
                                + produccion
                                + ") and id_almacen='"
                                + id_almacen
                                + "'  AND lts_existentes > 0  order by id",
                            "id_almacen_granel_entrada",
                            "produccion"
                        );
                    }
                    else
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT( no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_granel_entrada_envasado NOT IN  ("
                                + produccion
                                + ") and id_envasadora='"
                                + id_envasadora
                                + "'  AND lts_existentes > 0  order by id",
                            "id_granel_entrada_envasado",
                            "produccion"
                        );
                    }
                }
                else
                {
                    if (tipo == "fabrica")
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT( no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada   FROM granel_entrada  where id_fabrica='"
                                + id_fabrica
                                + "'  AND id_granel_entrada!='"
                                + id_granel_entrada
                                + "' and  lts_existentes > 0  order by id",
                            "id_granel_entrada",
                            "produccion"
                        );
                    }
                    else if (tipo == "almacen")
                    {
                        ///--- para almacen

                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT( no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_almacen_granel_entrada   FROM almacen_granel_entrada  where id_almacen='"
                                + id_almacen
                                + "'  AND id_almacen_granel_entrada!='"
                                + id_granel_entrada
                                + "' and  lts_existentes > 0  order by id",
                            "id_almacen_granel_entrada",
                            "produccion"
                        );
                    }
                    else
                    {
                        ConexionMysql.llenaComboAutocomplit(
                            ref CmbLotesGranel,
                            "SELECT  CONCAT( no_lote,'   ','Litros : ',lts_existentes,'   ','Grado alcoholico : ',grado_alcoholico_existente) As produccion,id_granel_entrada_envasado   FROM granel_entrada_envasado  where id_envasadora='"
                                + id_envasadora
                                + "'  AND id_granel_entrada_envasado!='"
                                + id_granel_entrada
                                + "' and  lts_existentes > 0  order by id",
                            "id_granel_entrada_envasado",
                            "produccion"
                        );
                    }
                }
            }
        }

        //agrega tanques
        private void BtnAgregarTanque_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtTanque.Text == "")
                {
                    MessageBox.Show("No ha introducido un nombre de tanque");
                    return;
                }
                DataRow fila = dtsTanques.NewRow();
                fila["TANQUE"] = TxtTanque.Text;
                fila["QUITAR"] = ConvertImageToByteArray(
                    Properties.Resources.delete,
                    System.Drawing.Imaging.ImageFormat.Png
                );
                dtsTanques.Rows.Add(fila);
                TxtTanque.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        //quita tanques
        private void DtaTanques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                if (DtaTanques.Columns[e.ColumnIndex].Name == "QUITAR")
                {
                    DtaTanques.Rows.RemoveAt(e.RowIndex);
                    dtsTanques.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Aviso Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// guarda el la nueva union o lote agranel
        private void BtnGuardarGranel_Click(object sender, EventArgs e)
        {
            if (DtaProduccionParaDividirAgranel.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un lote a granel");
                TxtLitros.Focus();
                return;
            }
            if (TxtNoLote.Text == "")
            {
                MessageBox.Show("Debe ingresar un numero lote");
                TxtNoLote.Focus();
                return;
            }
            if (BanderaUnion == false)
            {
                if (DtaTanques.RowCount == 0)
                {
                    MessageBox.Show("Debe ingresar un tanque");
                    TxtTanque.Focus();
                    return;
                }
            }

            DialogResult check = MessageBox.Show(
                "Verifica que los datos sean correctos",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (check == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                ///agregar mas litros a un lote agranel ya existente
                if (BanderaUnion == true)
                {
                    DataSet Datos = new DataSet();
                    if (tipo == "fabrica")
                    {
                        ConexionMysql.llenaDataset(
                            ref Datos,
                            "SELECT lts_existentes,grado_alcoholico_existente,id_planta,id_predio,agave_coccion_kg,id_comun,clase,categoria,abocante,ingrediente  FROM granel_entrada  WHERE id_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        );

                        DataSet ids = new DataSet();
                        ConexionMysql.llenaDataset(
                            ref ids,
                            "Select id_produccion_entrada From ids_producciones where id_lote='"
                                + DtaProduccionParaDividirAgranel.Rows[0].Cells["ID_GRANEL"].Value
                                + "' and tipo_instalacion='granel_fabrica'"
                        );

                        foreach (DataRow row in ids.Tables[0].Rows)
                        {
                            MessageBox.Show("-- " + row["id_produccion_entrada"].ToString());
                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('"
                                        + ids_producciones
                                        + "', 'granel_fabrica','"
                                        + row["id_produccion_entrada"].ToString()
                                        + "','"
                                        + id_granel_entrada
                                        + "',"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }
                    else if (tipo == "almacen")
                    {
                        //-- para almacen
                        ConexionMysql.llenaDataset(
                            ref Datos,
                            "SELECT lts_existentes,grado_alcoholico_existente,id_planta,id_predio,agave_coccion_kg,id_comun,clase,categoria,abocante,ingrediente  FROM almacen_granel_entrada  WHERE id_almacen_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        );

                        DataSet ids = new DataSet();
                        ConexionMysql.llenaDataset(
                            ref ids,
                            "Select id_produccion_entrada From ids_producciones where id_lote='"
                                + DtaProduccionParaDividirAgranel.Rows[0].Cells["ID_GRANEL"].Value
                                + "' and tipo_instalacion='almacen_granel'"
                        );

                        foreach (DataRow row in ids.Tables[0].Rows)
                        {
                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('"
                                        + ids_producciones
                                        + "', 'almacen_granel','"
                                        + row["id_produccion_entrada"].ToString()
                                        + "','"
                                        + id_granel_entrada
                                        + "',"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        ConexionMysql.llenaDataset(
                            ref Datos,
                            "SELECT lts_existentes,grado_alcoholico_existente,id_planta,id_predio,agave_coccion_kg,id_comun,clase,categoria,abocante,ingrediente  FROM granel_entrada_envasado  WHERE id_granel_entrada_envasado='"
                                + id_granel_entrada
                                + "'"
                        );

                        DataSet ids = new DataSet();
                        ConexionMysql.llenaDataset(
                            ref ids,
                            "Select id_produccion_entrada From ids_producciones where id_lote='"
                                + DtaProduccionParaDividirAgranel.Rows[0].Cells["ID_GRANEL"].Value
                                + "' and tipo_instalacion='granel_envasado'"
                        );

                        foreach (DataRow row in ids.Tables[0].Rows)
                        {
                            ///--- inserta el id de la produccion---
                            string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('"
                                        + ids_producciones
                                        + "', 'granel_envasado','"
                                        + row["id_produccion_entrada"].ToString()
                                        + "','"
                                        + id_granel_entrada
                                        + "',"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }

                    foreach (DataRow row in Datos.Tables[0].Rows)
                    {
                        litros = row["lts_existentes"].ToString();
                        grado_alcoholico = row["grado_alcoholico_existente"].ToString();
                        id_planta = row["id_planta"].ToString();
                        id_predio = row["id_predio"].ToString();
                        agave_coccion_kg = row["agave_coccion_kg"].ToString();
                        id_comun = row["id_comun"].ToString();
                        clase_union = row["clase"].ToString();
                        categoria_union = row["categoria"].ToString();
                        abocante = row["abocante"].ToString();
                        ingrediente = row["ingrediente"].ToString();
                    }
                    if (id_planta != "0" || id_comun != "0")
                    {
                        /// --- si no es un ensamble entra aqui
                        if (tipo == "fabrica")
                        {
                            ObtenerIdMaximoGranelEnsamble();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_ensamble (id_granel_ensamble,id_granel_entrada,id_granel_entrada_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                        + id_max_granel_ensamble
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + id_comun
                                        + "','"
                                        + id_planta
                                        + "','"
                                        + id_predio
                                        + "','"
                                        + litros
                                        + "','"
                                        + grado_alcoholico
                                        + "','"
                                        + agave_coccion_kg
                                        + "',0,"
                                        + Usuario.IdUsuario
                                        + ")"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET id_comun=0,id_planta=0,id_predio=0,agave_coccion_kg=0,actualizado=0 WHERE id_granel_entrada='"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            /// --- para lamacen
                            ObtenerIdMaximoAlmacenGranelEnsamble();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO almacen_granel_ensamble (id_almacen_granel_ensamble,id_almacen_granel_entrada,id_almacen_granel_entrada_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                        + id_max_almacen_granel_ensamble
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + id_comun
                                        + "','"
                                        + id_planta
                                        + "','"
                                        + id_predio
                                        + "','"
                                        + litros
                                        + "','"
                                        + grado_alcoholico
                                        + "','"
                                        + agave_coccion_kg
                                        + "',0,"
                                        + Usuario.IdUsuario
                                        + ")"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET id_comun=0,id_planta=0,id_predio=0,agave_coccion_kg=0,actualizado=0 WHERE id_almacen_granel_entrada='"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            ObtenerIdMaximoGranelEnsambleEnvasado();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_ensamble_envasado (id_granel_ensamble,id_granel_entrada_envasado,id_granel_entrada_envasado_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                        + id_max_granel_ensamble_envasado
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + id_comun
                                        + "','"
                                        + id_planta
                                        + "','"
                                        + id_predio
                                        + "','"
                                        + litros
                                        + "','"
                                        + grado_alcoholico
                                        + "','"
                                        + agave_coccion_kg
                                        + "',0,"
                                        + Usuario.IdUsuario
                                        + ")"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada_envasado SET id_comun=0,id_planta=0,id_predio=0,agave_coccion_kg=0,actualizado=0 WHERE id_granel_entrada_envasado='"
                                        + id_granel_entrada
                                        + "' "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }
                    for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                    {
                        ///-- si es un ensable entra aqui--

                        if (
                            DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                "ID_COMUN"
                            ].Value.ToString() != "0"
                            || DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                "ID_PLANTA"
                            ].Value.ToString() != "0"
                        )
                        {
                            ///---- si el lote contiene  especie en la parte de graneles entrada entra aqui  para convertirlo en ensamble --
                            if (tipo == "fabrica")
                            {
                                ObtenerIdMaximoGranelEnsamble();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO granel_ensamble (id_granel_ensamble,id_granel_entrada,id_granel_entrada_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                            + id_max_granel_ensamble
                                            + "','"
                                            + id_granel_entrada
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_GRANEL"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_COMUN"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_PLANTA"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_PREDIO"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "LITROS"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "%_ALCOHOLICO"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "AGAVE_COCCION_KG"
                                            ].Value.ToString()
                                            + "',0,"
                                            + Usuario.IdUsuario
                                            + ")"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                            else if (tipo == "almacen")
                            {
                                /// --- para almacen --

                                ObtenerIdMaximoAlmacenGranelEnsamble();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO almacen_granel_ensamble (id_almacen_granel_ensamble,id_almacen_granel_entrada,id_almacen_granel_entrada_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                            + id_max_almacen_granel_ensamble
                                            + "','"
                                            + id_granel_entrada
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_GRANEL"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_COMUN"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_PLANTA"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_PREDIO"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "LITROS"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "%_ALCOHOLICO"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "AGAVE_COCCION_KG"
                                            ].Value.ToString()
                                            + "',0,"
                                            + Usuario.IdUsuario
                                            + ")"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                            else
                            {
                                ObtenerIdMaximoGranelEnsambleEnvasado();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO granel_ensamble_envasado (id_granel_ensamble,id_granel_entrada_envasado,id_granel_entrada_envasado_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                            + id_max_granel_ensamble_envasado
                                            + "','"
                                            + id_granel_entrada
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_GRANEL"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_COMUN"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_PLANTA"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "ID_PREDIO"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "LITROS"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "%_ALCOHOLICO"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                "AGAVE_COCCION_KG"
                                            ].Value.ToString()
                                            + "',0,"
                                            + Usuario.IdUsuario
                                            + ")"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ///---- si el comun y la plnata son  = 0 entra  aqui para insertar los ensambles
                            DataSet Datos2 = new DataSet();
                            if (tipo == "fabrica")
                            {
                                ConexionMysql.llenaDataset(
                                    ref Datos2,
                                    "SELECT litros,grado_alcoholico,id_planta,id_predio,agave_coccion_kg,id_comun  FROM granel_ensamble  WHERE id_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "'"
                                );
                            }
                            else if (tipo == "almacen")
                            {
                                ///-- para almacen

                                ConexionMysql.llenaDataset(
                                    ref Datos2,
                                    "SELECT litros,grado_alcoholico,id_planta,id_predio,agave_coccion_kg,id_comun  FROM almacen_granel_ensamble  WHERE id_almacen_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "'"
                                );
                            }
                            else
                            {
                                ConexionMysql.llenaDataset(
                                    ref Datos2,
                                    "SELECT litros,grado_alcoholico,id_planta,id_predio,agave_coccion_kg,id_comun  FROM granel_ensamble_envasado  WHERE id_granel_entrada_envasado='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "'"
                                );
                            }
                            foreach (DataRow row in Datos2.Tables[0].Rows)
                            {
                                id_planta = row["id_planta"].ToString();
                                id_predio = row["id_predio"].ToString();
                                id_comun = row["id_comun"].ToString();

                                if (tipo == "fabrica")
                                {
                                    ObtenerIdMaximoGranelEnsamble();
                                    if (
                                        ConexionMysql.insUpd_transaccion(
                                            "INSERT INTO granel_ensamble (id_granel_ensamble,id_granel_entrada,id_granel_entrada_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                                + id_max_granel_ensamble
                                                + "','"
                                                + id_granel_entrada
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "ID_GRANEL"
                                                ].Value.ToString()
                                                + "','"
                                                + id_comun
                                                + "','"
                                                + id_planta
                                                + "','"
                                                + id_predio
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "LITROS"
                                                ].Value.ToString()
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "%_ALCOHOLICO"
                                                ].Value.ToString()
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "AGAVE_COCCION_KG"
                                                ].Value.ToString()
                                                + "',0,"
                                                + Usuario.IdUsuario
                                                + ")"
                                        ) == "Error"
                                    )
                                    {
                                        return;
                                    }
                                }
                                else if (tipo == "almacen")
                                {
                                    /// --- para almacen

                                    ObtenerIdMaximoAlmacenGranelEnsamble();
                                    if (
                                        ConexionMysql.insUpd_transaccion(
                                            "INSERT INTO almacen_granel_ensamble (id_almacen_granel_ensamble,id_almacen_granel_entrada,id_almacen_granel_entrada_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                                + id_max_almacen_granel_ensamble
                                                + "','"
                                                + id_granel_entrada
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "ID_GRANEL"
                                                ].Value.ToString()
                                                + "','"
                                                + id_comun
                                                + "','"
                                                + id_planta
                                                + "','"
                                                + id_predio
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "LITROS"
                                                ].Value.ToString()
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "%_ALCOHOLICO"
                                                ].Value.ToString()
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "AGAVE_COCCION_KG"
                                                ].Value.ToString()
                                                + "',0,"
                                                + Usuario.IdUsuario
                                                + ")"
                                        ) == "Error"
                                    )
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    ObtenerIdMaximoGranelEnsambleEnvasado();
                                    if (
                                        ConexionMysql.insUpd_transaccion(
                                            "INSERT INTO granel_ensamble_envasado (id_granel_ensamble,id_granel_entrada_envasado,id_granel_entrada_envasado_salio,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,actualizado,id_verificador) VALUES ('"
                                                + id_max_granel_ensamble_envasado
                                                + "','"
                                                + id_granel_entrada
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "ID_GRANEL"
                                                ].Value.ToString()
                                                + "','"
                                                + id_comun
                                                + "','"
                                                + id_planta
                                                + "','"
                                                + id_predio
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "LITROS"
                                                ].Value.ToString()
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "%_ALCOHOLICO"
                                                ].Value.ToString()
                                                + "','"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "AGAVE_COCCION_KG"
                                                ].Value.ToString()
                                                + "',0,"
                                                + Usuario.IdUsuario
                                                + ")"
                                        ) == "Error"
                                    )
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                        /// --- fin del if y else para ingresar las uniones

                        if (tipo == "fabrica")
                        {
                            //DISMINULLE ESXITENCIA DE LITROS
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET  lts_existentes=ROUND(lts_existentes-"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value
                                        + ",2), actualizado=0  WHERE id_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "'"
                                ) == "Error"
                            )
                            {
                                return;
                            }

                            //marca el movimiento
                            ObtenerIdMaximoGranelMovimientos();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos (id_granel_movimientos,id_granel_entrada,id_granel_entrada_sal,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                        + id_max_granel_movimientos
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "','entrada','union','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value.ToString()
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "%_ALCOHOLICO"
                                        ].Value.ToString()
                                        + "',"
                                        + lts_existentes
                                        + ",now(),now(),"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///--- para almacen --
                            //DISMINULLE ESXITENCIA DE LITROS
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET  lts_existentes=ROUND(lts_existentes-"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value
                                        + ",2), actualizado=0  WHERE id_almacen_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "'"
                                ) == "Error"
                            )
                            {
                                return;
                            }

                            //marca el movimiento
                            ObtenerIdMaximoAlmacenGranelMovimientos();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos,id_almacen_granel_entrada,id_almacen_granel_entrada_sal,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                        + id_max_almacen_granel_movimientos
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "','entrada','union','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value.ToString()
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "%_ALCOHOLICO"
                                        ].Value.ToString()
                                        + "',"
                                        + lts_existentes
                                        + ",now(),now(),"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            //DISMINULLE EXISTENCIA DE LITROS
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada_envasado SET  lts_existentes=ROUND(lts_existentes-"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value
                                        + ",2), actualizado=0  WHERE id_granel_entrada_envasado='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "'"
                                ) == "Error"
                            )
                            {
                                return;
                            }

                            //marca el movimiento
                            ObtenerIdMaximoGranelMovimientosEnvasado();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado,id_granel_entrada_envasado,id_granel_entrada_sal,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                        + id_max_granel_movimientos_envasado
                                        + "','"
                                        + id_granel_entrada
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "','entrada','union','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value.ToString()
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "%_ALCOHOLICO"
                                        ].Value.ToString()
                                        + "',"
                                        + lts_existentes
                                        + ",now(),now(),"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }

                        litros_suma += Math.Round(
                            double.Parse(
                                DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                    "LITROS"
                                ].Value.ToString()
                            ),
                            2
                        );
                        grado_alcoholico_nuevo +=
                            Math.Round(
                                double.Parse(
                                    DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "LITROS"
                                    ].Value.ToString()
                                ),
                                2
                            )
                            * Math.Round(
                                double.Parse(
                                    DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "%_ALCOHOLICO"
                                    ].Value.ToString()
                                ),
                                2
                            );

                        CategoriaMezcal = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                            "CATEGORIA"
                        ].Value.ToString();
                        claseMezcal = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                            "CLASE"
                        ].Value.ToString();
                        //saca categoria


                        if (CategoriaMezcal == "Mezcal")
                        {
                            mzkl++;
                        }
                        else if (CategoriaMezcal == "Mezcal Artesanal")
                        {
                            maartesanal++;
                        }
                        else if (CategoriaMezcal == "Mezcal Ancestral")
                        {
                            mancetral++;
                        }

                        if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven")
                        {
                            boj++;
                        }
                        else if (claseMezcal == "Madurado en vidrio")
                        {
                            madurado_vidrio++;
                        }
                        else if (claseMezcal == "Reposado")
                        {
                            reposado++;
                        }
                        else if (claseMezcal == "Añejo")
                        {
                            Añejo++;
                        }
                        else if (claseMezcal == "Abocado con")
                        {
                            abocado_con++;
                        }
                        else if (claseMezcal == "Destilado con")
                        {
                            des_con++;
                        }
                    }
                    ///====FIn del for --- -

                    int[] cadclase =
                    {
                        boj,
                        madurado_vidrio,
                        reposado,
                        Añejo,
                        abocado_con,
                        des_con
                    };

                    for (int g = 0; g < cadclase.Length; g++)
                    {
                        if (cadclase[g] > 0)
                        {
                            s_klss++;
                        }
                    }

                    if (s_klss > 1)
                    {
                        claseMezcal = "Cls_dif";
                    }
                    else if (s_klss == 1)
                    {
                        if (cadclase[0] > 0)
                        {
                            claseMezcal = "Blanco o Joven";
                        }
                        else if (cadclase[1] > 0)
                        {
                            claseMezcal = "Madurado en vidrio";
                        }
                        else if (cadclase[2] > 0)
                        {
                            claseMezcal = "Reposado";
                        }
                        else if (cadclase[3] > 0)
                        {
                            claseMezcal = "Añejo";
                        }
                        else if (cadclase[4] > 0)
                        {
                            claseMezcal = "Abocado con";
                        }
                        else if (cadclase[5] > 0)
                        {
                            claseMezcal = "Destilado con";
                        }
                    }

                    if (
                        clase_union == "Banco o Joven"
                        || clase_union == "Joven" && claseMezcal == "Blanco o Joven"
                    )
                    {
                        claseMezcal = "Blanco o Joven";
                    }
                    else if (clase_union != claseMezcal)
                    {
                        MessageBox.Show(
                            "No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!",
                            "¡¡Atento aviso!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    if (claseMezcal == "Cls_dif")
                    {
                        MessageBox.Show(
                            "No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!",
                            "¡¡Atento aviso!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    if (categoria_union != CategoriaMezcal)
                    {
                        MessageBox.Show(
                            "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                            "¡¡Atento aviso!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    //========= Mezcal categoria

                    if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
                    {
                        MessageBox.Show(
                            "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                            "¡¡Atento aviso!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                        //CategoriaMezcal = "dif_categoria";
                    }
                    else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
                    {
                        MessageBox.Show(
                            "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                            "¡¡Atento aviso!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;

                        //CategoriaMezcal = "dif_categoria";
                    }
                    else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
                    {
                        MessageBox.Show(
                            "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                            "¡¡Atento aviso!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                        // CategoriaMezcal = "dif_categoria";
                    }
                    else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
                    {
                        MessageBox.Show(
                            "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                            "¡¡Atento aviso!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                        // CategoriaMezcal = "dif_categoria";
                    }
                    else if (maartesanal > 0 && mancetral == 0 && mzkl == 0)
                    {
                        CategoriaMezcal = "Mezcal Artesanal";
                    }
                    else if (maartesanal == 0 && mancetral == 0 && mzkl > 0)
                    {
                        CategoriaMezcal = "Mezcal";
                    }
                    else if (maartesanal == 0 && mancetral > 0 && mzkl == 0)
                    {
                        CategoriaMezcal = "Mezcal Ancestral";
                    }

                    ///====================== -- INGREDIENTES -- ===================
                    ///entra si la clase es abocado con  o destilado con ---

                    if (claseMezcal == "Abocado con" || claseMezcal == "Destilado con")
                    {
                        for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                        {
                            ingredientecadena = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                "INGREDIENTE"
                            ].Value.ToString();

                            TxtIngredienteEnvasadoDB += sep + " " + ingredientecadena;
                            sep = ",";
                        } ////---- fin del for

                        TxtIngredienteEnvasadoDB += " , " + ingrediente;
                    }

                    litros_suma += Math.Round(double.Parse(litros), 2);
                    grado_alcoholico_nuevo +=
                        Math.Round(double.Parse(litros), 2)
                        * Math.Round(double.Parse(grado_alcoholico), 2);

                    double grado_alcoholico_final = grado_alcoholico_nuevo / litros_suma;

                    if (tipo == "fabrica")
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada SET lts_existentes="
                                    + litros_suma
                                    + ",grado_alcoholico_existente="
                                    + Math.Round(grado_alcoholico_final, 2)
                                    + ",clase='"
                                    + claseMezcal
                                    + "',categoria='"
                                    + CategoriaMezcal
                                    + "', ingrediente ='"
                                    + TxtIngredienteEnvasadoDB
                                    + "',actualizado=0 WHERE id_granel_entrada='"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else if (tipo == "almacen")
                    {
                        ///--- para almacen ---
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE almacen_granel_entrada SET lts_existentes="
                                    + litros_suma
                                    + ",grado_alcoholico_existente="
                                    + Math.Round(grado_alcoholico_final, 2)
                                    + ",clase='"
                                    + claseMezcal
                                    + "',categoria='"
                                    + CategoriaMezcal
                                    + "', ingrediente ='"
                                    + TxtIngredienteEnvasadoDB
                                    + "',actualizado=0 WHERE id_almacen_granel_entrada='"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada_envasado SET lts_existentes="
                                    + litros_suma
                                    + ",grado_alcoholico_existente="
                                    + Math.Round(grado_alcoholico_final, 2)
                                    + ",clase='"
                                    + claseMezcal
                                    + "',categoria='"
                                    + CategoriaMezcal
                                    + "', ingrediente ='"
                                    + TxtIngredienteEnvasadoDB
                                    + "',actualizado=0 WHERE id_granel_entrada_envasado='"
                                    + id_granel_entrada
                                    + "' "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();
                } //--- fin de la union-------------
                //extracciones de diferentes lotes agranel para formar uno nuevo
                else
                {
                    double litros = 0;
                    double grado_alcoholico = 0;
                    double grado_alcoholico_para_suma = 0;

                    for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                    {
                        litros += Math.Round(
                            double.Parse(
                                DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                    "LITROS"
                                ].Value.ToString()
                            ),
                            2
                        );
                        grado_alcoholico_para_suma +=
                            Math.Round(
                                double.Parse(
                                    DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "LITROS"
                                    ].Value.ToString()
                                ),
                                2
                            )
                            * Math.Round(
                                double.Parse(
                                    DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "%_ALCOHOLICO"
                                    ].Value.ToString()
                                ),
                                2
                            );
                    }
                    grado_alcoholico = grado_alcoholico_para_suma / litros;

                    //obtenesmos el id maximo de la entrada a granel fabrica
                    ObtenerIdMaximoGranelEntrada();

                    //obtenesmos el id maximo de la entrada a almacen de granel
                    ObtenerIdMaximoAlmacenGranelEntrada();

                    //obtenesmos el id maximo de la entrada a granel envasado
                    ObtenerIdMaximoGranelEntradaEnvasado();

                    if (DtaProduccionParaDividirAgranel.Rows.Count == 1)
                    {
                        /// si en le datagridview se encuentra menos de un lote entra


                        DataSet Datos = new DataSet();
                        if (tipo == "fabrica")
                        {
                            ConexionMysql.llenaDataset(
                                ref Datos,
                                "SELECT  no_cliente, id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente FROM granel_entrada where id_granel_entrada='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );

                            DataSet ids = new DataSet();
                            ConexionMysql.llenaDataset(
                                ref ids,
                                "Select id_produccion_entrada From ids_producciones where id_lote='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "' and tipo_instalacion='granel_fabrica'"
                            );

                            foreach (DataRow row in ids.Tables[0].Rows)
                            {
                                ///--- inserta el id de la produccion---
                                string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('"
                                            + ids_producciones
                                            + "', 'granel_fabrica','"
                                            + row["id_produccion_entrada"].ToString()
                                            + "','"
                                            + id_max_granel_entrada
                                            + "',"
                                            + Usuario.IdUsuario
                                            + ",0)"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///--para almacen
                            ConexionMysql.llenaDataset(
                                ref Datos,
                                "SELECT  no_cliente, id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente FROM almacen_granel_entrada where id_almacen_granel_entrada='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );

                            DataSet ids = new DataSet();
                            ConexionMysql.llenaDataset(
                                ref ids,
                                "Select id_produccion_entrada From ids_producciones where id_lote='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "' and tipo_instalacion='almacen_granel'"
                            );

                            foreach (DataRow row in ids.Tables[0].Rows)
                            {
                                ///--- inserta el id de la produccion---
                                string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('"
                                            + ids_producciones
                                            + "', 'almacen_granel','"
                                            + row["id_produccion_entrada"].ToString()
                                            + "','"
                                            + id_max_almacen_granel_entrada
                                            + "',"
                                            + Usuario.IdUsuario
                                            + ",0)"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ConexionMysql.llenaDataset(
                                ref Datos,
                                "SELECT  no_cliente, id_envasadora, fecha, id_comun,id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente FROM granel_entrada_envasado where id_granel_entrada_envasado='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );

                            DataSet ids = new DataSet();
                            ConexionMysql.llenaDataset(
                                ref ids,
                                "Select id_produccion_entrada From ids_producciones where id_lote='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "' and tipo_instalacion='granel_envasado'"
                            );

                            foreach (DataRow row in ids.Tables[0].Rows)
                            {
                                ///--- inserta el id de la produccion---
                                string ids_producciones = IdMaximo.ObtenerIdMaximoIdsProducciones();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO ids_producciones(id_producciones, tipo_instalacion, id_produccion_entrada, id_lote,id_verificador,actualizado) VALUES('"
                                            + ids_producciones
                                            + "', 'granel_envasado','"
                                            + row["id_produccion_entrada"].ToString()
                                            + "','"
                                            + id_max_granel_entrada_envasado
                                            + "',"
                                            + Usuario.IdUsuario
                                            + ",0)"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }
                        foreach (DataRow row in Datos.Tables[0].Rows)
                        {
                            if (tipo == "fabrica")
                            {
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO  granel_entrada(id_granel_entrada,no_cliente, id_fabrica, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '"
                                            + id_max_granel_entrada
                                            + "' ,'"
                                            + row["no_cliente"].ToString()
                                            + "','"
                                            + row["id_fabrica"].ToString()
                                            + "',now(),'"
                                            + row["id_comun"].ToString()
                                            + "','"
                                            + row["id_solicitud"].ToString()
                                            + "','"
                                            + TxtNoLote.Text
                                            + "','"
                                            + row["id_planta"].ToString()
                                            + "','"
                                            + row["agave_coccion_kg"].ToString()
                                            + "','"
                                            + row["id_predio"].ToString()
                                            + "' ,'"
                                            + row["fq"].ToString()
                                            + "','"
                                            + row["clase"].ToString()
                                            + "','"
                                            + row["categoria"].ToString()
                                            + "','"
                                            + row["abocante"].ToString()
                                            + "','"
                                            + row["ingrediente"].ToString()
                                            + "','"
                                            + litros
                                            + "','"
                                            + Math.Round(grado_alcoholico, 2)
                                            + "','"
                                            + litros
                                            + "','"
                                            + Math.Round(grado_alcoholico, 2)
                                            + "',now(),'"
                                            + Usuario.IdUsuario
                                            + "',0)"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                            else if (tipo == "almacen")
                            {
                                ///---- para almacen
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,no_cliente, id_almacen, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '"
                                            + id_max_almacen_granel_entrada
                                            + "' ,'"
                                            + row["no_cliente"].ToString()
                                            + "','"
                                            + row["id_almacen"].ToString()
                                            + "',now(),'"
                                            + row["id_comun"].ToString()
                                            + "','"
                                            + row["id_solicitud"].ToString()
                                            + "','"
                                            + TxtNoLote.Text
                                            + "','"
                                            + row["id_planta"].ToString()
                                            + "','"
                                            + row["agave_coccion_kg"].ToString()
                                            + "','"
                                            + row["id_predio"].ToString()
                                            + "' ,'"
                                            + row["fq"].ToString()
                                            + "','"
                                            + row["clase"].ToString()
                                            + "','"
                                            + row["categoria"].ToString()
                                            + "','"
                                            + row["abocante"].ToString()
                                            + "','"
                                            + row["ingrediente"].ToString()
                                            + "','"
                                            + litros
                                            + "','"
                                            + Math.Round(grado_alcoholico, 2)
                                            + "','"
                                            + litros
                                            + "','"
                                            + Math.Round(grado_alcoholico, 2)
                                            + "',now(),'"
                                            + Usuario.IdUsuario
                                            + "',0)"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,no_cliente, id_envasadora, fecha, id_comun, id_solicitud, no_lote, id_planta, agave_coccion_kg, id_predio, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '"
                                            + id_max_granel_entrada_envasado
                                            + "' ,'"
                                            + row["no_cliente"].ToString()
                                            + "','"
                                            + row["id_envasadora"].ToString()
                                            + "',now(),'"
                                            + row["id_comun"].ToString()
                                            + "','"
                                            + row["id_solicitud"].ToString()
                                            + "','"
                                            + TxtNoLote.Text
                                            + "','"
                                            + row["id_planta"].ToString()
                                            + "','"
                                            + row["agave_coccion_kg"].ToString()
                                            + "','"
                                            + row["id_predio"].ToString()
                                            + "' ,'"
                                            + row["fq"].ToString()
                                            + "','"
                                            + row["clase"].ToString()
                                            + "','"
                                            + row["categoria"].ToString()
                                            + "','"
                                            + row["abocante"].ToString()
                                            + "','"
                                            + row["ingrediente"].ToString()
                                            + "','"
                                            + litros
                                            + "','"
                                            + Math.Round(grado_alcoholico, 2)
                                            + "','"
                                            + litros
                                            + "','"
                                            + Math.Round(grado_alcoholico, 2)
                                            + "',now(),'"
                                            + Usuario.IdUsuario
                                            + "',0)"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }

                        DataSet Datos2 = new DataSet();
                        if (tipo == "fabrica")
                        {
                            ConexionMysql.llenaDataset(
                                ref Datos2,
                                "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );
                        }
                        else if (tipo == "almacen")
                        {
                            ///--- para almacen ---
                            ConexionMysql.llenaDataset(
                                ref Datos2,
                                "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM almacen_granel_ensamble where id_almacen_granel_entrada='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );
                        }
                        else
                        {
                            ConexionMysql.llenaDataset(
                                ref Datos2,
                                "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble_envasado where id_granel_entrada_envasado='"
                                    + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );
                        }
                        foreach (DataRow row in Datos2.Tables[0].Rows)
                        {
                            if (tipo == "fabrica")
                            {
                                ObtenerIdMaximoGranelEnsamble();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                            + id_max_granel_ensamble
                                            + "','"
                                            + id_max_granel_entrada
                                            + "' ,'"
                                            + row["id_comun"].ToString()
                                            + "','"
                                            + row["id_planta"].ToString()
                                            + "','"
                                            + row["id_predio"].ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                                "LITROS"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                                "%_ALCOHOLICO"
                                            ].Value.ToString()
                                            + "','"
                                            + row["agave_coccion_kg"].ToString()
                                            + "',"
                                            + Usuario.IdUsuario
                                            + ")"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                            else if (tipo == "almacen")
                            {
                                /// ---- para almacen
                                ObtenerIdMaximoAlmacenGranelEnsamble();

                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                            + id_max_almacen_granel_ensamble
                                            + "','"
                                            + id_max_almacen_granel_entrada
                                            + "' ,'"
                                            + row["id_comun"].ToString()
                                            + "','"
                                            + row["id_planta"].ToString()
                                            + "','"
                                            + row["id_predio"].ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                                "LITROS"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                                "%_ALCOHOLICO"
                                            ].Value.ToString()
                                            + "','"
                                            + row["agave_coccion_kg"].ToString()
                                            + "',"
                                            + Usuario.IdUsuario
                                            + ")"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                            else
                            {
                                ObtenerIdMaximoGranelEnsambleEnvasado();
                                if (
                                    ConexionMysql.insUpd_transaccion(
                                        "INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                            + id_max_granel_ensamble_envasado
                                            + "','"
                                            + id_max_granel_entrada_envasado
                                            + "' ,'"
                                            + row["id_comun"].ToString()
                                            + "','"
                                            + row["id_planta"].ToString()
                                            + "','"
                                            + row["id_predio"].ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                                "LITROS"
                                            ].Value.ToString()
                                            + "','"
                                            + DtaProduccionParaDividirAgranel.Rows[0].Cells[
                                                "%_ALCOHOLICO"
                                            ].Value.ToString()
                                            + "','"
                                            + row["agave_coccion_kg"].ToString()
                                            + "',"
                                            + Usuario.IdUsuario
                                            + ")"
                                    ) == "Error"
                                )
                                {
                                    return;
                                }
                            }
                        }
                    }
                    ///--- fin para un solo lote
                    else
                    {
                        ///---- si el datagridview contiene mas de una fila entra

                        string CategoriaMezcalComparar = "";
                        string claseMezcalComparar = "";
                        string CategoriaMezcal = "";
                        string claseMezcal = "";
                        for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                        {
                            CategoriaMezcal = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                "CATEGORIA"
                            ].Value.ToString();
                            claseMezcal = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                "CLASE"
                            ].Value.ToString();

                            //saca categoria
                            /* if (CategoriaMezcalComparar != "")
                             {
                                 if (CategoriaMezcal == "Mezcal Artesanal")
                                 {
                                     if (CategoriaMezcalComparar == "Mezcal")
                                     {
                                         CategoriaMezcal = CategoriaMezcalComparar;
                                     }
                                 }
                                 else if (CategoriaMezcal == "Mezcal Ancestral")
                                 {
                                     if (CategoriaMezcalComparar == "Mezcal")
                                     {
                                         CategoriaMezcal = CategoriaMezcalComparar;
                                     }
                                     else if (CategoriaMezcalComparar == "Mezcal Artesanal")
                                     {
                                         CategoriaMezcal = CategoriaMezcalComparar;
                                     }
                                 }
                             }
                             CategoriaMezcalComparar = CategoriaMezcal;
                             //saca clase
                             if (claseMezcalComparar != "")
                             {
                                 if (claseMezcal == "Reposado")
                                 {
                                     if (claseMezcalComparar == "Joven")
                                     {
                                         claseMezcal = claseMezcalComparar;
                                     }
                                 }
                                 else if (claseMezcal == "Añejo")
                                 {
                                     if (claseMezcalComparar == "Joven")
                                     {
                                         claseMezcal = claseMezcalComparar;
                                     }
                                     else if (claseMezcalComparar == "Reposado")
                                     {
                                         claseMezcal = claseMezcalComparar;
                                     }
                                 }
                             }
                             claseMezcalComparar = claseMezcal;
                         }*/

                            if (CategoriaMezcal == "Mezcal")
                            {
                                mzkl++;
                            }
                            else if (CategoriaMezcal == "Mezcal Artesanal")
                            {
                                maartesanal++;
                            }
                            else if (CategoriaMezcal == "Mezcal Ancestral")
                            {
                                mancetral++;
                            }

                            if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven")
                            {
                                boj++;
                            }
                            else if (claseMezcal == "Madurado en vidrio")
                            {
                                madurado_vidrio++;
                            }
                            else if (claseMezcal == "Reposado")
                            {
                                reposado++;
                            }
                            else if (claseMezcal == "Añejo")
                            {
                                Añejo++;
                            }
                            else if (claseMezcal == "Abocado con")
                            {
                                abocado_con++;
                            }
                            else if (claseMezcal == "Destilado con")
                            {
                                des_con++;
                            }
                        } //====FIn del for --- -

                        int[] cadclase =
                        {
                            boj,
                            madurado_vidrio,
                            reposado,
                            Añejo,
                            abocado_con,
                            des_con
                        };

                        //MessageBox.Show("es : " + cadclase);


                        for (int g = 0; g < cadclase.Length; g++)
                        {
                            if (cadclase[g] > 0)
                            {
                                s_klss++;
                                // if (cadclase[1] != 0) { }
                            }
                        }

                        //MessageBox.Show(" esto representa : " + s_klss);
                        //MessageBox.Show(" esto representa : " + klss);


                        if (s_klss > 1)
                        {
                            claseMezcal = "Cls_dif";
                        }
                        else if (s_klss == 1)
                        {
                            if (cadclase[0] > 0)
                            {
                                claseMezcal = "Blanco o Joven";
                            }
                            else if (cadclase[1] > 0)
                            {
                                claseMezcal = "Madurado en vidrio";
                            }
                            else if (cadclase[2] > 0)
                            {
                                claseMezcal = "Reposado";
                            }
                            else if (cadclase[3] > 0)
                            {
                                claseMezcal = "Añejo";
                            }
                            else if (cadclase[4] > 0)
                            {
                                claseMezcal = "Abocado con";
                            }
                            else if (cadclase[5] > 0)
                            {
                                claseMezcal = "Destilado con";
                            }
                        }

                        /* MessageBox.Show("categoria : " + clase_union + " -- " + claseMezcal);


                         if (clase_union == "Banco o Joven" || clase_union == "Joven" && claseMezcal == "Blanco o Joven")
                     {
                         MessageBox.Show("prueba de b o j "+ claseMezcal);
                         claseMezcal = "Blanco o Joven";

                     }
                     else  if (clase_union != claseMezcal)
                     {
                         MessageBox.Show("No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                     }*/

                        if (claseMezcal == "Cls_dif")
                        {
                            MessageBox.Show(
                                "No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!",
                                "¡¡Atento aviso!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        //========= Mezcal categoria

                        if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
                        {
                            MessageBox.Show(
                                "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                                "¡¡Atento aviso!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                            //CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
                        {
                            MessageBox.Show(
                                "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                                "¡¡Atento aviso!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;

                            //CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
                        {
                            MessageBox.Show(
                                "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                                "¡¡Atento aviso!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                            // CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
                        {
                            MessageBox.Show(
                                "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                                "¡¡Atento aviso!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                            // CategoriaMezcal = "dif_categoria";
                        }
                        else if (maartesanal > 0 && mancetral == 0 && mzkl == 0)
                        {
                            CategoriaMezcal = "Mezcal Artesanal";
                        }
                        else if (maartesanal == 0 && mancetral == 0 && mzkl > 0)
                        {
                            CategoriaMezcal = "Mezcal";
                        }
                        else if (maartesanal == 0 && mancetral > 0 && mzkl == 0)
                        {
                            CategoriaMezcal = "Mezcal Ancestral";
                        }

                        /*if (categoria_union != CategoriaMezcal)
                        {
                            MessageBox.Show("No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!", "¡¡Atento aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        */



                        ///====================== -- INGREDIENTES -- ===================
                        ///entra si la clase es abocado con  o destilado con ---

                        if (claseMezcal == "Abocado con" || claseMezcal == "Destilado con")
                        {
                            for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                            {
                                //   if (tipo == "fabrica") {
                                //    ingredientecadena = ConexionMysql.regresaCampoConsulta("SELECT ingrediente  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                                //}
                                //else {
                                ingredientecadena = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                    "INGREDIENTE"
                                ].Value.ToString();

                                //   ingredientecadena = ConexionMysql.regresaCampoConsulta("SELECT ingrediente  FROM  granel_entrada WHERE  id_granel_entrada_envasado='" + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                                // }




                                //if (des_ingrediente != "")
                                //{
                                //des_con++;

                                TxtIngredienteEnvasadoDB += sep + " " + ingredientecadena;
                                sep = ",";

                                //}
                            }

                            //--TxtIngredienteEnvasadoDB = ingrediente;
                        }

                        if (tipo == "fabrica")
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  granel_entrada(id_granel_entrada,id_fabrica,no_cliente, fecha, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '"
                                        + id_max_granel_entrada
                                        + "' ,'"
                                        + id_fabrica
                                        + "','"
                                        + no_cliente
                                        + "' ,now(),0,'"
                                        + TxtNoLote.Text
                                        + "','','"
                                        + claseMezcal
                                        + "','"
                                        + CategoriaMezcal
                                        + "','' ,'"
                                        + TxtIngredienteEnvasadoDB
                                        + "','"
                                        + litros
                                        + "','"
                                        + Math.Round(grado_alcoholico, 2)
                                        + "','"
                                        + litros
                                        + "','"
                                        + Math.Round(grado_alcoholico, 2)
                                        + "',NOW(),'"
                                        + Usuario.IdUsuario
                                        + "',0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        if (tipo == "almacen")
                        {
                            ////---- para almacen
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  almacen_granel_entrada(id_almacen_granel_entrada,id_almacen,no_cliente, fecha, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '"
                                        + id_max_almacen_granel_entrada
                                        + "' ,'"
                                        + id_almacen
                                        + "','"
                                        + no_cliente
                                        + "' ,now(),0,'"
                                        + TxtNoLote.Text
                                        + "','','"
                                        + claseMezcal
                                        + "','"
                                        + CategoriaMezcal
                                        + "','' ,'"
                                        + TxtIngredienteEnvasadoDB
                                        + "','"
                                        + litros
                                        + "','"
                                        + Math.Round(grado_alcoholico, 2)
                                        + "','"
                                        + litros
                                        + "','"
                                        + Math.Round(grado_alcoholico, 2)
                                        + "',NOW(),'"
                                        + Usuario.IdUsuario
                                        + "',0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  granel_entrada_envasado(id_granel_entrada_envasado,id_envasadora,no_cliente, fecha, id_solicitud, no_lote, fq, clase, categoria, abocante, ingrediente, lts_entrada, grado_alcoholico_entrada, lts_existentes, grado_alcoholico_existente,fecha_movimiento, id_verificador, actualizado) VALUES( '"
                                        + id_max_granel_entrada_envasado
                                        + "' ,'"
                                        + id_envasadora
                                        + "','"
                                        + no_cliente
                                        + "' ,now(),0,'"
                                        + TxtNoLote.Text
                                        + "','','"
                                        + claseMezcal
                                        + "','"
                                        + CategoriaMezcal
                                        + "','' ,'"
                                        + TxtIngredienteEnvasadoDB
                                        + "','"
                                        + litros
                                        + "','"
                                        + Math.Round(grado_alcoholico, 2)
                                        + "','"
                                        + litros
                                        + "','"
                                        + Math.Round(grado_alcoholico, 2)
                                        + "',NOW(),'"
                                        + Usuario.IdUsuario
                                        + "',0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }

                        for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                        {
                            DataSet Datos = new DataSet();
                            if (tipo == "fabrica")
                            {
                                ConexionMysql.llenaDataset(
                                    ref Datos,
                                    "SELECT  id_planta,id_comun,id_predio,agave_coccion_kg FROM granel_entrada where id_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value
                                        + "'"
                                );
                            }
                            else if (tipo == "almacen")
                            {
                                ////-- para almacen
                                ConexionMysql.llenaDataset(
                                    ref Datos,
                                    "SELECT  id_planta,id_comun,id_predio,agave_coccion_kg FROM almacen_granel_entrada where id_almacen_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value
                                        + "'"
                                );
                            }
                            else
                            {
                                ConexionMysql.llenaDataset(
                                    ref Datos,
                                    "SELECT  id_planta,id_comun,id_predio,agave_coccion_kg FROM granel_entrada_envasado where id_granel_entrada_envasado='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value
                                        + "'"
                                );
                            }

                            foreach (DataRow row in Datos.Tables[0].Rows)
                            {
                                if (
                                    row["id_planta"].ToString() == "0"
                                    && row["id_comun"].ToString() == "0"
                                )
                                {
                                    DataSet Datos2 = new DataSet();
                                    if (tipo == "fabrica")
                                    {
                                        ConexionMysql.llenaDataset(
                                            ref Datos2,
                                            "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble where id_granel_entrada='"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "ID_GRANEL"
                                                ].Value
                                                + "'"
                                        );
                                    }
                                    else if (tipo == "almacen")
                                    {
                                        ///----- para almacen --
                                        ConexionMysql.llenaDataset(
                                            ref Datos2,
                                            "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM almacen_granel_ensamble where id_almacen_granel_entrada='"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "ID_GRANEL"
                                                ].Value
                                                + "'"
                                        );
                                    }
                                    else
                                    {
                                        ConexionMysql.llenaDataset(
                                            ref Datos2,
                                            "SELECT  id_comun,id_predio,id_planta,agave_coccion_kg FROM granel_ensamble_envasado where id_granel_entrada_envasado='"
                                                + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                    "ID_GRANEL"
                                                ].Value
                                                + "'"
                                        );
                                    }

                                    foreach (DataRow row2 in Datos2.Tables[0].Rows)
                                    {
                                        if (tipo == "fabrica")
                                        {
                                            ObtenerIdMaximoGranelEnsamble();
                                            if (
                                                ConexionMysql.insUpd_transaccion(
                                                    "INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                                        + id_max_granel_ensamble
                                                        + "','"
                                                        + id_max_granel_entrada
                                                        + "' ,'"
                                                        + row2["id_comun"].ToString()
                                                        + "','"
                                                        + row2["id_planta"].ToString()
                                                        + "','"
                                                        + row2["id_predio"].ToString()
                                                        + "','"
                                                        + DtaProduccionParaDividirAgranel.Rows[
                                                            x
                                                        ].Cells["LITROS"].Value.ToString()
                                                        + "','"
                                                        + DtaProduccionParaDividirAgranel.Rows[
                                                            x
                                                        ].Cells["%_ALCOHOLICO"].Value.ToString()
                                                        + "','"
                                                        + row2["agave_coccion_kg"].ToString()
                                                        + "',"
                                                        + Usuario.IdUsuario
                                                        + ")"
                                                ) == "Error"
                                            )
                                            {
                                                return;
                                            }
                                        }
                                        if (tipo == "almacen")
                                        {
                                            ///--- para almacen --
                                            ObtenerIdMaximoAlmacenGranelEnsamble();
                                            if (
                                                ConexionMysql.insUpd_transaccion(
                                                    "INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                                        + id_max_almacen_granel_ensamble
                                                        + "','"
                                                        + id_max_almacen_granel_entrada
                                                        + "' ,'"
                                                        + row2["id_comun"].ToString()
                                                        + "','"
                                                        + row2["id_planta"].ToString()
                                                        + "','"
                                                        + row2["id_predio"].ToString()
                                                        + "','"
                                                        + DtaProduccionParaDividirAgranel.Rows[
                                                            x
                                                        ].Cells["LITROS"].Value.ToString()
                                                        + "','"
                                                        + DtaProduccionParaDividirAgranel.Rows[
                                                            x
                                                        ].Cells["%_ALCOHOLICO"].Value.ToString()
                                                        + "','"
                                                        + row2["agave_coccion_kg"].ToString()
                                                        + "',"
                                                        + Usuario.IdUsuario
                                                        + ")"
                                                ) == "Error"
                                            )
                                            {
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            ObtenerIdMaximoGranelEnsambleEnvasado();
                                            if (
                                                ConexionMysql.insUpd_transaccion(
                                                    "INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                                        + id_max_granel_ensamble_envasado
                                                        + "','"
                                                        + id_max_granel_entrada_envasado
                                                        + "' ,'"
                                                        + row2["id_comun"].ToString()
                                                        + "','"
                                                        + row2["id_planta"].ToString()
                                                        + "','"
                                                        + row2["id_predio"].ToString()
                                                        + "','"
                                                        + DtaProduccionParaDividirAgranel.Rows[
                                                            x
                                                        ].Cells["LITROS"].Value.ToString()
                                                        + "','"
                                                        + DtaProduccionParaDividirAgranel.Rows[
                                                            x
                                                        ].Cells["%_ALCOHOLICO"].Value.ToString()
                                                        + "','"
                                                        + row2["agave_coccion_kg"].ToString()
                                                        + "',"
                                                        + Usuario.IdUsuario
                                                        + ")"
                                                ) == "Error"
                                            )
                                            {
                                                return;
                                            }
                                        }
                                    }
                                    ///--- fin del foreach
                                }
                                else
                                {
                                    ///------- si la planta y el comun es igual a 0  entra ---
                                    if (tipo == "fabrica")
                                    {
                                        ObtenerIdMaximoGranelEnsamble();
                                        if (
                                            ConexionMysql.insUpd_transaccion(
                                                "INSERT INTO  granel_ensamble(id_granel_ensamble,id_granel_entrada,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                                    + id_max_granel_ensamble
                                                    + "','"
                                                    + id_max_granel_entrada
                                                    + "' ,'"
                                                    + row["id_comun"].ToString()
                                                    + "','"
                                                    + row["id_planta"].ToString()
                                                    + "','"
                                                    + row["id_predio"].ToString()
                                                    + "','"
                                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                        "LITROS"
                                                    ].Value.ToString()
                                                    + "','"
                                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                        "%_ALCOHOLICO"
                                                    ].Value.ToString()
                                                    + "','"
                                                    + row["agave_coccion_kg"].ToString()
                                                    + "',"
                                                    + Usuario.IdUsuario
                                                    + ")"
                                            ) == "Error"
                                        )
                                        {
                                            return;
                                        }
                                    }
                                    if (tipo == "almacen")
                                    {
                                        ///---- para almacen ---
                                        ObtenerIdMaximoAlmacenGranelEnsamble();
                                        if (
                                            ConexionMysql.insUpd_transaccion(
                                                "INSERT INTO  almacen_granel_ensamble(id_almacen_granel_ensamble,id_almacen_granel_entrada,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                                    + id_max_almacen_granel_ensamble
                                                    + "','"
                                                    + id_max_almacen_granel_entrada
                                                    + "' ,'"
                                                    + row["id_comun"].ToString()
                                                    + "','"
                                                    + row["id_planta"].ToString()
                                                    + "','"
                                                    + row["id_predio"].ToString()
                                                    + "','"
                                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                        "LITROS"
                                                    ].Value.ToString()
                                                    + "','"
                                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                        "%_ALCOHOLICO"
                                                    ].Value.ToString()
                                                    + "','"
                                                    + row["agave_coccion_kg"].ToString()
                                                    + "',"
                                                    + Usuario.IdUsuario
                                                    + ")"
                                            ) == "Error"
                                        )
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        ObtenerIdMaximoGranelEnsambleEnvasado();
                                        if (
                                            ConexionMysql.insUpd_transaccion(
                                                "INSERT INTO  granel_ensamble_envasado(id_granel_ensamble,id_granel_entrada_envasado,id_comun,id_planta,id_predio,litros,grado_alcoholico,agave_coccion_kg,id_verificador) VALUES( '"
                                                    + id_max_granel_ensamble_envasado
                                                    + "','"
                                                    + id_max_granel_entrada_envasado
                                                    + "' ,'"
                                                    + row["id_comun"].ToString()
                                                    + "','"
                                                    + row["id_planta"].ToString()
                                                    + "','"
                                                    + row["id_predio"].ToString()
                                                    + "','"
                                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                        "LITROS"
                                                    ].Value.ToString()
                                                    + "','"
                                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                                        "%_ALCOHOLICO"
                                                    ].Value.ToString()
                                                    + "','"
                                                    + row["agave_coccion_kg"].ToString()
                                                    + "',"
                                                    + Usuario.IdUsuario
                                                    + ")"
                                            ) == "Error"
                                        )
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ///.-- fin del mas de un lote

                    ////marca la salida del producto y actualiza existencia de granel fabrica
                    for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
                    {
                        string litros_granel;

                        if (tipo == "fabrica")
                        {
                            //marca el movimiento
                            ObtenerIdMaximoGranelMovimientos();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos (id_granel_movimientos,id_granel_entrada,id_granel_entrada_sal,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                        + id_max_granel_movimientos
                                        + "','"
                                        + id_max_granel_entrada
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "','entrada','extraccion','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value.ToString()
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "%_ALCOHOLICO"
                                        ].Value.ToString()
                                        + "',"
                                        + lts_existentes
                                        + ",now(),NOW(),"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                            litros_granel = ConexionMysql.regresaCampoConsulta(
                                "SELECT lts_existentes  FROM  granel_entrada WHERE  id_granel_entrada='"
                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );
                        }
                        else if (tipo == "almacen")
                        {
                            //marca el movimiento
                            ///---- para lamacen --

                            ObtenerIdMaximoAlmacenGranelMovimientos();

                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos,id_almacen_granel_entrada,id_almacen_granel_entrada_sal,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                        + id_max_almacen_granel_movimientos
                                        + "','"
                                        + id_max_almacen_granel_entrada
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "','entrada','extraccion','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value.ToString()
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "%_ALCOHOLICO"
                                        ].Value.ToString()
                                        + "',"
                                        + lts_existentes
                                        + ",now(),NOW(),"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                            litros_granel = ConexionMysql.regresaCampoConsulta(
                                "SELECT lts_existentes  FROM  almacen_granel_entrada WHERE  id_almacen_granel_entrada='"
                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );
                        }
                        else
                        {
                            //marcar el movimiento envasado
                            ObtenerIdMaximoGranelMovimientosEnvasado();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado,id_granel_entrada_envasado,id_granel_entrada_sal,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                        + id_max_granel_movimientos_envasado
                                        + "','"
                                        + id_max_granel_entrada_envasado
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value.ToString()
                                        + "','entrada','extraccion','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "LITROS"
                                        ].Value.ToString()
                                        + "','"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "%_ALCOHOLICO"
                                        ].Value.ToString()
                                        + "',"
                                        + lts_existentes
                                        + ",now(),NOW(),"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }

                            litros_granel = ConexionMysql.regresaCampoConsulta(
                                "SELECT lts_existentes  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='"
                                    + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "ID_GRANEL"
                                    ].Value
                                    + "'"
                            );
                        }

                        double existencia =
                            Math.Round(double.Parse(litros_granel), 2)
                            - Math.Round(
                                double.Parse(
                                    DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                        "LITROS"
                                    ].Value.ToString()
                                ),
                                2
                            );
                        if (tipo == "fabrica")
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE  granel_entrada SET lts_existentes="
                                        + existencia
                                        + ",actualizado=0 WHERE id_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value
                                        + "'"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///--- para almacen---


                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE  almacen_granel_entrada SET lts_existentes="
                                        + existencia
                                        + ",actualizado=0 WHERE id_almacen_granel_entrada='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value
                                        + "'"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE  granel_entrada_envasado SET lts_existentes="
                                        + existencia
                                        + ",actualizado=0 WHERE id_granel_entrada_envasado='"
                                        + DtaProduccionParaDividirAgranel.Rows[x].Cells[
                                            "ID_GRANEL"
                                        ].Value
                                        + "'"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }

                    for (int x = 0; x < DtaTanques.Rows.Count; x++)
                    {
                        if (tipo == "fabrica")
                        {
                            ObtenerIdMaximoGranelTanque();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  granel_tanques(id_tanque,id_granel_entrada,tanque,id_verificador,actualizado) VALUES( '"
                                        + id_max_granel_tanque
                                        + "','"
                                        + id_max_granel_entrada
                                        + "','"
                                        + DtaTanques.Rows[x].Cells["TANQUE"].Value
                                        + "',"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        if (tipo == "almacen")
                        {
                            ////---- para almacen ---
                            ObtenerIdMaximoAlmacenGranelTanque();

                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  almacen_granel_tanques(id_tanque,id_almacen_granel_entrada,tanque,id_verificador,actualizado) VALUES( '"
                                        + id_max_almacen_granel_tanque
                                        + "','"
                                        + id_max_almacen_granel_entrada
                                        + "','"
                                        + DtaTanques.Rows[x].Cells["TANQUE"].Value
                                        + "',"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            ObtenerIdMaximoGranelTanqueEnvasado();
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "INSERT INTO  granel_tanques_envasado(id_tanque,id_granel_entrada_envasado,tanque,id_verificador,actualizado) VALUES( '"
                                        + id_max_granel_tanque_envasado
                                        + "','"
                                        + id_max_granel_entrada_envasado
                                        + "','"
                                        + DtaTanques.Rows[x].Cells["TANQUE"].Value
                                        + "',"
                                        + Usuario.IdUsuario
                                        + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }
                    ConexionMysql.transCompleta();
                    MessageBox.Show("Éxito");
                    this.Close();
                }
            } //------ Fin DialogMessageBox----------
        }

        ///--- fin de union y extraccion
        ///


        //---- Categoria y clase ---
        public void gfe_catClass()
        {
            string CategoriaMezcal = "";
            string claseMezcal = "";

            int mzkl = 0;
            int maartesanal = 0;
            int mancetral = 0;

            int des_con = 0;
            int abocado_con = 0;
            int boj = 0;
            int madurado_vidrio = 0;
            int reposado = 0;
            int Añejo = 0;
            string clac_union = "";
            string cat_union = "";

            int s_klss = 0;
            for (int x = 0; x < DtaProduccionParaDividirAgranel.Rows.Count; x++)
            {
                /*CategoriaMezcal = ConexionMysql.regresaCampoConsulta("SELECT categoria  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");
                claseMezcal = ConexionMysql.regresaCampoConsulta("SELECT clase  FROM  granel_entrada WHERE  id_granel_entrada='" + DtaProduccionParaDividirAgranel.Rows[x].Cells["ID_GRANEL_ENTRADA"].Value + "'");*/


                if (BanderaUnion == true)
                {
                    // DataSet Datos = new DataSet();
                    if (tipo == "fabrica")
                    {
                        // ConexionMysql.llenaDataset(ref Datos, "SELECT clase,categoria  FROM granel_entrada  WHERE id_granel_entrada='" + id_granel_entrada + "'");

                        cat_union = ConexionMysql.regresaCampoConsulta(
                            "SELECT categoria  FROM  granel_entrada WHERE  id_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        );

                        clac_union = ConexionMysql.regresaCampoConsulta(
                            "SELECT clase  FROM  granel_entrada WHERE  id_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        );
                    }
                    else if (tipo == "almacen")
                    {
                        ///---para almacen

                        cat_union = ConexionMysql.regresaCampoConsulta(
                            "SELECT categoria  FROM  almacen_granel_entrada WHERE  id_almacen_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        );

                        clac_union = ConexionMysql.regresaCampoConsulta(
                            "SELECT clase  FROM  almacen_granel_entrada WHERE  id_almacen_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        );
                    }
                    else
                    {
                        // ConexionMysql.llenaDataset(ref Datos, "SELECT lts_existentes,grado_alcoholico_existente,id_planta,id_predio,agave_coccion_kg,id_comun,clase,categoria,abocante,ingrediente  FROM granel_entrada_envasado  WHERE id_granel_entrada_envasado='" + id_granel_entrada + "'");

                        cat_union = ConexionMysql.regresaCampoConsulta(
                            "SELECT categoria  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='"
                                + id_granel_entrada
                                + "'"
                        );

                        clac_union = ConexionMysql.regresaCampoConsulta(
                            "SELECT clase  FROM  granel_entrada_envasado WHERE  id_granel_entrada_envasado='"
                                + id_granel_entrada
                                + "'"
                        );
                    }
                }

                CategoriaMezcal = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                    "CATEGORIA"
                ].Value.ToString();
                claseMezcal = DtaProduccionParaDividirAgranel.Rows[x].Cells[
                    "CLASE"
                ].Value.ToString();

                ///MessageBox.Show("la categoria es : " + CategoriaMezcal + " --- " + claseMezcal);

                // MessageBox.Show("la categoria es del lote selecionado en granel : " + cat_union + " --- " + clac_union);


                if (CategoriaMezcal == "Mezcal")
                {
                    mzkl++;
                }
                else if (CategoriaMezcal == "Mezcal Artesanal")
                {
                    maartesanal++;
                }
                else if (CategoriaMezcal == "Mezcal Ancestral")
                {
                    mancetral++;
                }

                if (claseMezcal == "Joven" || claseMezcal == "Blanco o Joven")
                {
                    boj++;
                }
                else if (claseMezcal == "Madurado en vidrio")
                {
                    madurado_vidrio++;
                }
                else if (claseMezcal == "Reposado")
                {
                    reposado++;
                }
                else if (claseMezcal == "Añejo")
                {
                    Añejo++;
                }
                else if (claseMezcal == "Abocado con")
                {
                    abocado_con++;
                }
                else if (claseMezcal == "Destilado con")
                {
                    des_con++;
                }
            } //====FIn del for --- -

            int[] cadclase = { boj, madurado_vidrio, reposado, Añejo, abocado_con, des_con };

            //MessageBox.Show("es : " + cadclase);


            for (int g = 0; g < cadclase.Length; g++)
            {
                if (cadclase[g] > 0)
                {
                    s_klss++;
                    // if (cadclase[1] != 0) { }
                }
            }

            //MessageBox.Show(" esto representa : " + s_klss);
            //MessageBox.Show(" esto representa : " + klss);


            if (s_klss > 1)
            {
                claseMezcal = "Cls_dif";
            }
            else if (s_klss == 1)
            {
                if (cadclase[0] > 0)
                {
                    claseMezcal = "Blanco o Joven";
                }
                else if (cadclase[1] > 0)
                {
                    claseMezcal = "Madurado en vidrio";
                }
                else if (cadclase[2] > 0)
                {
                    claseMezcal = "Reposado";
                }
                else if (cadclase[3] > 0)
                {
                    claseMezcal = "Añejo";
                }
                else if (cadclase[4] > 0)
                {
                    claseMezcal = "Abocado con";
                }
                else if (cadclase[5] > 0)
                {
                    claseMezcal = "Destilado con";
                }
            }

            if (BanderaUnion == true)
            {
                if (
                    clac_union == "Banco o Joven"
                    || clac_union == "Joven" && claseMezcal == "Blanco o Joven"
                )
                {
                    // MessageBox.Show("prueba de b o j " + claseMezcal);
                    claseMezcal = "Blanco o Joven";
                }
                else if (clac_union != claseMezcal)
                {
                    //MessageBox.Show("categoria : " + clac_union + " -- " + claseMezcal);

                    MessageBox.Show(
                        "No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!",
                        "¡¡Atento aviso!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    dtaProduccionParaDividirAgranel.Rows.Clear();
                    return;
                }
            }

            if (claseMezcal == "Cls_dif")
            {
                MessageBox.Show(
                    "No se puede realizar la mezcla entre lotes de diferentes clases,\n Comunicate con la Unidad de Verificación para mayor informacion!!",
                    "¡¡Atento aviso!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                dtaProduccionParaDividirAgranel.Rows.Clear();
                return;
            }

            if (BanderaUnion == true)
            {
                //MessageBox.Show("categoria : " + cat_union + " -- " + CategoriaMezcal);

                if (cat_union != CategoriaMezcal)
                {
                    MessageBox.Show(
                        "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                        "¡¡Atento aviso!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    dtaProduccionParaDividirAgranel.Rows.Clear();
                    return;
                }
            }

            //========= Mezcal categoria

            if (maartesanal > 0 && mancetral > 0 && mzkl > 0)
            {
                MessageBox.Show(
                    "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                    "¡¡Atento aviso!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                dtaProduccionParaDividirAgranel.Rows.Clear();
                return;
                //CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal > 0 && mancetral > 0 && mzkl == 0)
            {
                MessageBox.Show(
                    "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                    "¡¡Atento aviso!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                dtaProduccionParaDividirAgranel.Rows.Clear();

                return;

                //CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal > 0 && mancetral == 0 && mzkl > 0)
            {
                MessageBox.Show(
                    "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                    "¡¡Atento aviso!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                dtaProduccionParaDividirAgranel.Rows.Clear();
                return;
                // CategoriaMezcal = "dif_categoria";
            }
            else if (maartesanal == 0 && mancetral > 0 && mzkl > 0)
            {
                MessageBox.Show(
                    "No se puede realizar la mezcla entre lotes de diferente Categoria. \n Comunicate con la Unidad de Verificación para mayor informacion!!",
                    "¡¡Atento aviso!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                dtaProduccionParaDividirAgranel.Rows.Clear();
                return;
                // CategoriaMezcal = "dif_categoria";
            }
        } // == fin de  gfe_catClass()

        ///////////////////////////////////////////////////////////////////////////////////////////////////// SALIDA ////////////////////////////////////////////////////



        private void BtnSalida_Click(object sender, EventArgs e)
        {
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelUnion.Visible = false;
            PanelSalida.Visible = true;
            PanelMensajes.Visible = false;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;

            LblLoteSalida.Text = no_lote;
            LblLitrosSalida.Text = lts_existentes;
            LblGradoAlcoholicoSalida.Text = grado_alcoholico_existente;
            LblCategoriaSalida.Text = categoria;
            LblClaseSalida.Text = clase;
        }

        private void TxtLitrosSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosSalida.Text);
        }

        private void BtnSalidaGranel_Click(object sender, EventArgs e)
        {
            if (TxtLitrosSalida.Text == "")
            {
                MessageBox.Show("No ha introducido litros");
                TxtLitrosSalida.Focus();
                return;
            }
            if (TxtLitrosSalida.Text == ".")
            {
                MessageBox.Show("Agrege un valor real de litros");
                TxtLitrosSalida.Focus();
                return;
            }
            if (TxtLitrosSalida.Text == "0")
            {
                MessageBox.Show("Agrege un valor diferente de cero");
                TxtLitrosSalida.Focus();
                return;
            }
            if (
                Math.Round(double.Parse(LblLitrosSalida.Text), 2)
                < Math.Round(double.Parse(TxtLitrosSalida.Text), 2)
            )
            {
                MessageBox.Show("Existencia insuficiente");
                return;
            }

            DialogResult check = MessageBox.Show(
                "Verifica que los datos sean correctos",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (check == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (tipo == "fabrica")
                {
                    //DISMINULLE ESXITENCIA DE LITROS
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE granel_entrada SET  lts_existentes=ROUND(lts_existentes,2)-"
                                + Math.Round(double.Parse(TxtLitrosSalida.Text), 2)
                                + ", actualizado=0  WHERE id_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        ) == "Error"
                    )
                    {
                        return;
                    }
                    //marca el movimiento
                    ObtenerIdMaximoGranelMovimientos();
                    if (chbTrasladoClientExt.Checked == true && chbBedidasCon.Checked == true) //verificar si esta check el radio buton de salida tipo traslado a cliente externo
                    //el valor 1 en salida_externa y en bebidas con, siginfica que "sí"
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos (id_granel_movimientos,id_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,salida_externa,razon_social_externa,bebidasCon,destinobBebidasCon,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtRazonSocialExterna.Text
                                    + "',1," +
                                    "'"+ txtDestinoBebidaMzcl.Text +"'" +
                                    ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    } // fin if validar check radio
                    
                    else if (chbTrasladoClientExt.Checked == true || chbBedidasCon.Checked == true)//Validate if one of the two outputs is active
                    {
                        if (chbTrasladoClientExt.Checked == true) { //Enter if you are an external client
                            if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos (id_granel_movimientos,id_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,salida_externa,razon_social_externa,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtRazonSocialExterna.Text
                                    + "',now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                            {
                                return;
                            }
                        }
                        else //if not then it is drink with mezcal
                        {
                            if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos (id_granel_movimientos,id_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,bebidasCon,destinobBebidasCon,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1," +
                                    "'" + txtDestinoBebidaMzcl.Text + "'" +
                                    ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                            {
                                return;
                            }
                        }
                    }

                    else // if there are no conditional outputs, normal save
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos (id_granel_movimientos,id_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                }
                else if (tipo == "almacen")
                {
                    //DISMINULLE ESXITENCIA DE LITROS
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE almacen_granel_entrada SET  lts_existentes=ROUND(lts_existentes,2)-"
                                + Math.Round(double.Parse(TxtLitrosSalida.Text), 2)
                                + ", actualizado=0  WHERE id_almacen_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        ) == "Error"
                    )
                    {
                        return;
                    }
                    //marca el movimiento
                    ObtenerIdMaximoAlmacenGranelMovimientos();
                    if (chbTrasladoClientExt.Checked == true && chbBedidasCon.Checked == true) //verificar si esta chek el radio buton de salida tipo traslado a cliente externo
                    //el valor 1 en salida_externa siginfica que "sí"
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos,id_almacen_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,salida_externa,razon_social_externa,bebidasCon,destinobBebidasCon,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_almacen_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtRazonSocialExterna.Text
                                    + "',1," 
                                    +"'" + txtDestinoBebidaMzcl.Text + "'"
                                    + ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else if (chbTrasladoClientExt.Checked == true || chbBedidasCon.Checked == true)//Validate if one of the two outputs is active
                    {
                        if (chbTrasladoClientExt.Checked == true)
                        {
                            if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos,id_almacen_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,salida_externa,razon_social_externa,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_almacen_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtRazonSocialExterna.Text
                                    + "'"
                                    + ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }

                        }
                        else
                        {
                            if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos,id_almacen_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,bebidasCon,destinobBebidasCon,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_almacen_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtDestinoBebidaMzcl.Text
                                    + "'"
                                    + ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }

                    else // if there are no conditional outputs, normal save
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO almacen_granel_movimientos (id_almacen_granel_movimientos,id_almacen_granel_entrada,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_almacen_granel_movimientos
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                }
                else //GRANEL ENTRADA ENVASADO
                {
                    //DISMINULLE ESXITENCIA DE LITROS
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE granel_entrada_envasado SET  lts_existentes=ROUND(lts_existentes,2)-"
                                + Math.Round(double.Parse(TxtLitrosSalida.Text), 2)
                                + ", actualizado=0  WHERE id_granel_entrada_envasado='"
                                + id_granel_entrada
                                + "'"
                        ) == "Error"
                    )
                    {
                        return;
                    }
                    //marca el movimiento
                    ObtenerIdMaximoGranelMovimientosEnvasado();
                    if (chbTrasladoClientExt.Checked == true && chbBedidasCon.Checked == true) //verificar si esta chek el radio buton de salida tipo traslado a cliente externo
                    //el valor 1 en salida_externa siginfica que "sí"
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado,id_granel_entrada_envasado,tipo,destino,litros,grado_alcoholico,lts_anteriores,salida_externa,razon_social_externa,bebidasCon,destinobBebidasCon,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos_envasado
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtRazonSocialExterna.Text
                                    + "',1,'"
                                    +txtDestinoBebidaMzcl.Text+"'," 
                                    + "now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else if (chbTrasladoClientExt.Checked == true || chbBedidasCon.Checked == true)
                    {
                        if (chbTrasladoClientExt.Checked == true)
                        {
                            if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado,id_granel_entrada_envasado,tipo,destino,litros,grado_alcoholico,lts_anteriores,salida_externa,razon_social_externa,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos_envasado + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtRazonSocialExterna.Text
                                    + "',now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado,id_granel_entrada_envasado,tipo,destino,litros,grado_alcoholico,lts_anteriores,bebidasCon,destinobBebidasCon,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos_envasado + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",1,'"
                                    + txtDestinoBebidaMzcl.Text
                                    + "',now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                            {
                                return;
                            }
                        }
                    }

                    else
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "INSERT INTO granel_movimientos_envasado (id_granel_movimientos_envasado,id_granel_entrada_envasado,tipo,destino,litros,grado_alcoholico,lts_anteriores,fecha,fecha_movimiento,id_verificador,actualizado) VALUES ('"
                                    + id_max_granel_movimientos_envasado
                                    + "','"
                                    + id_granel_entrada
                                    + "','salida','"
                                    + TxtDescripcionSalida.Text
                                    + "','"
                                    + TxtLitrosSalida.Text
                                    + "','"
                                    + grado_alcoholico_existente
                                    + "',"
                                    + lts_existentes
                                    + ",now(),NOW(),"
                                    + Usuario.IdUsuario
                                    + ",0)"
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                }

                ConexionMysql.transCompleta();
                MessageBox.Show("Éxito");
                this.Close();
            } //------ Fin DialogMessagebox -----------------
        }

        private void label33_Click(object sender, EventArgs e) { }

        private void TxtNoLote_TextChanged(object sender, EventArgs e) { }

        private void PanelUnion_Paint(object sender, PaintEventArgs e) { }

        /////////////////////////////////////////////////////////////////////// editar fq ////////////////////////////////////////////////////////////////

        private void TxtLitrosEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosEditar.Text);
        }

        private void TxtGradoAlcoholicoEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoAlcoholicoEditar.Text);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelUnion.Visible = false;
            PanelSalida.Visible = false;
            PanelMensajes.Visible = false;
            PanelFq.Visible = true;
            panelAbocante.Visible = false;

            lblNoloteFQ.Text = no_lote;

            CmbSeleccion.Items.Clear();
            CmbSeleccion.Items.Insert(0, "Reemplazar");
            CmbSeleccion.Items.Insert(1, "Agregar");

            TxtLitrosEditar.Text = lts_existentes;
            TxtGradoAlcoholicoEditar.Text = grado_alcoholico_existente;
        }

        private void BtnEditarFq_Click(object sender, EventArgs e)
        {
            if (CmbSeleccion.Text == "")
            {
                MessageBox.Show("Seleccione el tipo de FQ");
                return;
            }
            if (TxtFqEditar.Text == "")
            {
                MessageBox.Show("Introduce FQ");
                TxtFqEditar.Focus();
                return;
            }
            if (TxtGradoAlcoholicoEditar.Text == "")
            {
                MessageBox.Show("Introduce grado alcohólico");
                TxtGradoAlcoholicoEditar.Focus();
                return;
            }
            if (TxtObservaciones.Text == "")
            {
                MessageBox.Show("Ingresa una observación");
                TxtObservaciones.Focus();
                return;
            }

            DialogResult check = MessageBox.Show(
                "Verifica que los datos sean correctos",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (check == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (fq.Trim() == "")
                {
                    if (tipo == "fabrica")
                    {
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada SET fq='"
                                    + TxtFqEditar.Text
                                    + "', grado_alcoholico_existente='"
                                    + TxtGradoAlcoholicoEditar.Text
                                    + "',actualizado=0 WHERE id_granel_entrada='"
                                    + id_granel_entrada
                                    + "'  "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else if (tipo == "almacen")
                    {
                        ///---- para almacen

                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE almacen_granel_entrada SET fq='"
                                    + TxtFqEditar.Text
                                    + "', grado_alcoholico_existente='"
                                    + TxtGradoAlcoholicoEditar.Text
                                    + "',actualizado=0 WHERE id_almacen_granel_entrada='"
                                    + id_granel_entrada
                                    + "'  "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                    else
                    {
                        /// --- Envasado granel --
                        if (
                            ConexionMysql.insUpd_transaccion(
                                "UPDATE granel_entrada_envasado SET fq='"
                                    + TxtFqEditar.Text
                                    + "',grado_alcoholico_existente='"
                                    + TxtGradoAlcoholicoEditar.Text
                                    + "',actualizado=0 WHERE id_granel_entrada_envasado='"
                                    + id_granel_entrada
                                    + "'  "
                            ) == "Error"
                        )
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (CmbSeleccion.Text == "Reemplazar")
                    {
                        if (tipo == "fabrica")
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET fq='"
                                        + TxtFqEditar.Text
                                        + "',grado_alcoholico_existente='"
                                        + TxtGradoAlcoholicoEditar.Text
                                        + "', actualizado=0 WHERE id_granel_entrada='"
                                        + id_granel_entrada
                                        + "'  "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///---- para almacen --
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET fq='"
                                        + TxtFqEditar.Text
                                        + "',grado_alcoholico_existente='"
                                        + TxtGradoAlcoholicoEditar.Text
                                        + "', actualizado=0 WHERE id_almacen_granel_entrada='"
                                        + id_granel_entrada
                                        + "'  "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            /// --- Envasado granel --
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada_envasado SET fq='"
                                        + TxtFqEditar.Text
                                        + "',grado_alcoholico_existente='"
                                        + TxtGradoAlcoholicoEditar.Text
                                        + "',actualizado=0 WHERE id_granel_entrada_envasado='"
                                        + id_granel_entrada
                                        + "'  "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        string nuevofq = fq + ", " + TxtFqEditar.Text;
                        if (tipo == "fabrica")
                        {
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada SET fq='"
                                        + nuevofq
                                        + "',grado_alcoholico_existente='"
                                        + TxtGradoAlcoholicoEditar.Text
                                        + "',actualizado=0 WHERE id_granel_entrada='"
                                        + id_granel_entrada
                                        + "'  "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else if (tipo == "almacen")
                        {
                            ///---- para almacen --
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE almacen_granel_entrada SET fq='"
                                        + nuevofq
                                        + "',grado_alcoholico_existente='"
                                        + TxtGradoAlcoholicoEditar.Text
                                        + "',actualizado=0 WHERE almacen_id_granel_entrada='"
                                        + id_granel_entrada
                                        + "'  "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                        else
                        {
                            /// --- Envasado granel --
                            if (
                                ConexionMysql.insUpd_transaccion(
                                    "UPDATE granel_entrada_envasado SET fq='"
                                        + nuevofq
                                        + "',grado_alcoholico_existente='"
                                        + TxtGradoAlcoholicoEditar.Text
                                        + "',actualizado=0 WHERE id_granel_entrada_envasado='"
                                        + id_granel_entrada
                                        + "'  "
                                ) == "Error"
                            )
                            {
                                return;
                            }
                        }
                    }
                }

                ObtenerIdMaximoFq();
                if (
                    ConexionMysql.insUpd_transaccion(
                        "INSERT INTO fq_historial(id_fq, id_produccion, tipo,fq, litros, grado_alcoholico, observacion, id_verificador, actualizado,fecha) VALUES ('"
                            + id_max_fq
                            + "','"
                            + id_granel_entrada
                            + "','"
                            + (tipo == "fabrica" ? "granel_fabrica" : "granel_envasado")
                            + "','"
                            + TxtFqEditar.Text
                            + "','"
                            + TxtLitrosEditar.Text
                            + "','"
                            + TxtGradoAlcoholicoEditar.Text
                            + "','"
                            + TxtObservaciones.Text
                            + "',"
                            + Usuario.IdUsuario
                            + ",0,now())"
                    ) == "Error"
                )
                {
                    return;
                }

                ConexionMysql.transCompleta();
                MessageBox.Show("Edición exitosa");
                this.Close();
            }
            ///----- Fin --------
        }

        //////////////////////////////////////////////////////////////////// mensajes /////////////////////////////////////////////////////////////////


        private void BtnMensajes_Click(object sender, EventArgs e)
        {
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelUnion.Visible = false;
            PanelSalida.Visible = false;
            PanelMensajes.Visible = true;
            PanelFq.Visible = false;
            panelAbocante.Visible = false;

            lblNoloteMensaje.Text = no_lote;

            string mensajes = "";
            string variable = "";

            if (tipo == "fabrica")
            {
                variable = "granel_fabrica";
            }
            if (tipo == "almacen")
            {
                variable = "almacen_granel";
            }
            else
            {
                variable = "granel_envasado";
            }
            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(
                ref Datos,
                "SELECT verificadores.nombre,mensajes_registros.mensaje,DATE_FORMAT(mensajes_registros.fecha, '%d/%m/%Y') as fecha from mensajes_registros INNER JOIN verificadores ON mensajes_registros.id_verificador=verificadores.id_us where id_registro='"
                    + id_granel_entrada
                    + "'  and tipo='"
                    + variable
                    + "'  "
            );
            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                string nombre = row["nombre"].ToString();
                string mensaje = row["mensaje"].ToString();
                string fecha = row["fecha"].ToString();
                mensajes +=
                    System.Environment.NewLine
                    + fecha
                    + "  "
                    + nombre
                    + " :  "
                    + mensaje
                    + System.Environment.NewLine;
            }
            TxtMensajes.Text = mensajes;
            TxtMensajes.SelectionStart = TxtMensajes.Text.Length;
            TxtMensajes.ScrollToCaret();
        }

        private void BtnGuardarMensaje_Click(object sender, EventArgs e)
        {
            string tipo_instalacion = "";

            if (TxtMensaje.Text == "")
            {
                MessageBox.Show("Desbes ecribir un mensaje");
                TxtMensaje.Focus();
                return;
            }

            if (tipo == "fabrica")
            {
                tipo_instalacion = "granel_fabrica";
            }
            else if (tipo == "envasado")
            {
                tipo_instalacion = "granel_envasado";
            }
            else
            {
                tipo_instalacion = "almacen_granel";
            }

            ObtenerIdMaximoMensaje();
            // if (ConexionMysql.insUpd_transaccion("INSERT INTO mensajes_registros(id_mensaje, id_registro, tipo, mensaje, fecha, id_verificador, actualizado) VALUES ('" + id_max_mensaje + "','" + id_granel_entrada + "','" + (tipo == "fabrica" ? "granel_fabrica" : "granel_envasado") + "','" + TxtMensaje.Text + "',now()," + Usuario.IdUsuario + ",0)") == "Error")
            if (
                ConexionMysql.insUpd_transaccion(
                    "INSERT INTO mensajes_registros(id_mensaje, id_registro, tipo, mensaje, fecha, id_verificador, actualizado) VALUES ('"
                        + id_max_mensaje
                        + "','"
                        + id_granel_entrada
                        + "','"
                        + tipo_instalacion
                        + "','"
                        + TxtMensaje.Text
                        + "',now(),"
                        + Usuario.IdUsuario
                        + ",0)"
                ) == "Error"
            )
            {
                return;
            }
            ConexionMysql.transCompleta();
            TxtMensaje.Text = "";
            string mensajes = "";

            DataSet Datos = new DataSet();
            ConexionMysql.llenaDataset(
                ref Datos,
                "SELECT verificadores.nombre,mensajes_registros.mensaje,DATE_FORMAT(mensajes_registros.fecha, '%d/%m/%Y') as fecha from mensajes_registros INNER JOIN verificadores ON mensajes_registros.id_verificador=verificadores.id_us where id_registro='"
                    + id_granel_entrada
                    + "' AND tipo='"
                    + tipo_instalacion
                    + "'"
            );

            foreach (DataRow row in Datos.Tables[0].Rows)
            {
                string nombre = row["nombre"].ToString();
                string mensaje = row["mensaje"].ToString();
                string fecha = row["fecha"].ToString();
                mensajes +=
                    System.Environment.NewLine
                    + fecha
                    + "  "
                    + nombre
                    + " :  "
                    + mensaje
                    + System.Environment.NewLine;
            }
            TxtMensajes.Text = mensajes;
            TxtMensajes.SelectionStart = TxtMensajes.Text.Length;
            TxtMensajes.ScrollToCaret();
        } ////////////////////////////////////////////////////////////////////--<<< Fin de mensajes >>>--/////////////////////////////////////////////////////////////////

        private void btnAbocante_Click(object sender, EventArgs e)
        {
            PanelMuestreo.Visible = false;
            PanelDilucion.Visible = false;
            PanelBarrica.Visible = false;
            PanelVidrio.Visible = false;
            PanelTridestilacion.Visible = false;
            PanelUnion.Visible = false;
            PanelSalida.Visible = false;
            PanelMensajes.Visible = false;
            PanelFq.Visible = false;
            panelAbocante.Visible = true;

            lblNoloteAbocante.Text = no_lote;
        }

        private void btnGuArdaAbocante_Click(object sender, EventArgs e)
        {
            if (rtbIngredienteAbocado.Text == "")
            {
                MessageBox.Show("Desbes ecribir un ingrediente...");
                rtbIngredienteAbocado.Focus();
                return;
            }

            DialogResult check = MessageBox.Show(
                "Verifica que los datos sean correctos",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (check == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (tipo == "fabrica")
                {
                    //actualiza el lote a la clase abocado con--
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE granel_entrada SET  clase='Abocado con', ingrediente='"
                                + rtbIngredienteAbocado.Text
                                + "', actualizado=0 WHERE id_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        ) == "Error"
                    )
                    {
                        MessageBox.Show("A ocurrido un error al realizar el movimiento :( ..");
                        return;
                    }
                }
                else if (tipo == "almacen")
                {
                    //actualiza el lote a la clase abocado con--
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE almacen_granel_entrada SET  clase='Abocado con', ingrediente='"
                                + rtbIngredienteAbocado.Text
                                + "', actualizado=0 WHERE id_almacen_granel_entrada='"
                                + id_granel_entrada
                                + "'"
                        ) == "Error"
                    )
                    {
                        MessageBox.Show("A ocurrido un error al realizar el movimiento :( ..");
                        return;
                    }
                }
                else
                {
                    //actualiza el lote a la clase abocado con--
                    if (
                        ConexionMysql.insUpd_transaccion(
                            "UPDATE granel_entrada_envasado SET  clase='Abocado con', ingrediente='"
                                + rtbIngredienteAbocado.Text
                                + "', actualizado=0   WHERE id_granel_entrada_envasado='"
                                + id_granel_entrada
                                + "'"
                        ) == "Error"
                    )
                    {
                        MessageBox.Show("A ocurrido un error al realizar el movimiento :( ..");
                        return;
                    }
                }
            }

            ConexionMysql.transCompleta();

            MessageBox.Show("Edición exitosa");
            this.Close();
        }

        private void txtNodeDestilacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, txtNodeDestilacion.Text);
        }

        private void TxtGradoTridestilacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtGradoTridestilacion.Text);
        }

        private void TxtLitrosTridestilacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            valida.numeroPunto(e, TxtLitrosTridestilacion.Text);
        }
    }
}
