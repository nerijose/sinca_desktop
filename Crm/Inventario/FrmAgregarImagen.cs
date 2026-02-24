using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using Crm.Utilerias;
using Microsoft.VisualBasic.Devices; // Recuerden agregar la referencia "Microsoft.VisualBasic".

namespace Crm.Inventario
{
    public partial class FrmAgregarImagen : Form
    {
        public static FrmAgregarImagen instance;

        // Declare crop pen for cropping image
        public Pen crpPen = new Pen(Color.White);
        Computer mycomputer = new Computer(); // Así accederemos al "FileSystem".
                                              //declare some variable for crop coordinates
        int crpX, crpY, rectW, rectH;
        public string no_cliente;
        public string texto;
        public int di_solicitud;
        public string tabla;
        public String codigo;
        public FrmAgregarImagen()
        {
            InitializeComponent();
            instance = this;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String carpeta = no_cliente;
                String hora = DateTime.Now.ToString("hhmmss");
                String nombre = no_cliente + di_solicitud + texto + hora + ".jpeg";
                Directory.CreateDirectory(@"C:\xampp\htdocs\doc\img\"+carpeta);
                Cursor = Cursors.Default;
                //Now we will draw the cropped image into pictureBox2
                Bitmap bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(bmp2, pictureBox1.ClientRectangle);

                Bitmap crpImg = new Bitmap(rectW, rectH);

                for (int i = 0; i < rectW; i++)
                {
                    for (int y = 0; y < rectH; y++)
                    {
                        Color pxlclr = bmp2.GetPixel(crpX + i, crpY + y);
                        crpImg.SetPixel(i, y, pxlclr);
                    }
                }

                pictureBox2.Image = (Image)crpImg;
                pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;

                //pictureBox2.Image.Save(@"C:\xx.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                pictureBox2.Image.Save(@"C:/xampp/htdocs/doc/img/"+carpeta+"/"+nombre, System.Drawing.Imaging.ImageFormat.Jpeg);
                //FrmDictamen.instance.tb1.Load(@"C:/xampp/htdocs/doc/img/" + carpeta + "/" + nombre);
                guardar_imagen(nombre, @"C:/xampp/htdocs/doc/img/" + carpeta + "/" + nombre);
                this.Close();
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guardar_imagen(String nombre, String ruta)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca."+ tabla + " SET "+ texto +"='" + nombre + "' WHERE id_solicitud='" + di_solicitud + "' ") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro guardado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //FrmDictamen frm = new FrmDictamen();
                //Thread.Sleep(3000);
                //frm.Cargar_fotos_produccion(di_solicitud,no_cliente);
                mostrar_imagen(ruta);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrar_imagen(String ruta) {
            switch (tabla)
            {
                case "di_inf_fotos_produccion":
                    switch (texto)
                    {
                        case "maestro":
                            FrmDictamen.instance.pMaestro.Load(ruta);
                            break;
                        case "recepcion1":
                            FrmDictamen.instance.pRecepcion1.Load(ruta);
                            break;
                        case "recepcion2":
                            FrmDictamen.instance.pRecepcion2.Load(ruta);
                            break;
                        case "coccion1":
                            FrmDictamen.instance.pCoccion1.Load(ruta);
                            break;
                        case "coccion2":
                            FrmDictamen.instance.pCoccion2.Load(ruta);
                            break;
                        case "molienda1":
                            FrmDictamen.instance.pMolienda1.Load(ruta);
                            break;
                        case "molienda2":
                            FrmDictamen.instance.pMolienda2.Load(ruta);
                            break;
                        case "fermentacion1":
                            FrmDictamen.instance.pFermentacion1.Load(ruta);
                            break;
                        case "fermentacion2":
                            FrmDictamen.instance.pFermentacion2.Load(ruta);
                            break;
                        case "destilacion1":
                            FrmDictamen.instance.pDestilacion1.Load(ruta);
                            break;
                        case "destilacion2":
                            FrmDictamen.instance.pDestilacion2.Load(ruta);
                            break;
                        case "almacen1":
                            FrmDictamen.instance.pAlmacen1.Load(ruta);
                            break;
                        case "almacen2":
                            FrmDictamen.instance.pAlmacen2.Load(ruta);
                            break;
                        case "vista_interior":
                            FrmDictamen.instance.pInterior.Load(ruta);
                            break;
                        case "vista_exterior":
                            FrmDictamen.instance.pExterior.Load(ruta);
                            break;
                        case "maduracion1":
                            FrmDictamen.instance.pMaduracion1.Load(ruta);
                            break;
                        case "maduracion2":
                            FrmDictamen.instance.pMaduracion2.Load(ruta);
                            break;
                        default:
                            MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case "di_inf_fotos_envasado":
                    switch (texto)
                    {
                        case "almacen_granel":
                            FrmDictamen.instance.pProductoEGranel.Load(ruta);
                            break;
                        case "lavado":
                            FrmDictamen.instance.pLavadoBotellas.Load(ruta);
                            break;
                        case "llenado":
                            FrmDictamen.instance.pLlenado.Load(ruta);
                            break;
                        case "taponado":
                            FrmDictamen.instance.pTaponado.Load(ruta);
                            break;
                        case "general_interior":
                            FrmDictamen.instance.pVistaInterior.Load(ruta);
                            break;
                        case "general_exterior":
                            FrmDictamen.instance.pVistaExterior.Load(ruta);
                            break;
                        case "almacen_terminado":
                            FrmDictamen.instance.pAlmacenE.Load(ruta);
                            break;
                        case "marcas":
                            FrmDictamen.instance.pMarcas.Load(ruta);
                            break;
                        case "almacen_insumos":
                            FrmDictamen.instance.pAlmacenInsumos.Load(ruta);
                            break;
                        case "otros":
                            FrmDictamen.instance.pOtrosE.Load(ruta);
                            break;
                        case "linea":
                            FrmDictamen.instance.pLineaE.Load(ruta);
                            break;
                        case "maduracion":
                            FrmDictamen.instance.pMaduracionE.Load(ruta);
                            break;
                        case "granel":
                            FrmDictamen.instance.pGranelE.Load(ruta);
                            break;
                        default:
                            MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case "di_inf_fotos_envasado_bc":
                    switch (texto)
                    {
                        case "almacen_granel":
                            FrmDictamen.instance.pAlmacenB.Load(ruta);
                            break;
                        case "lavado":
                            FrmDictamen.instance.pLavadoB.Load(ruta);
                            break;
                        case "llenado":
                            FrmDictamen.instance.pLlenadoB.Load(ruta);
                            break;
                        case "taponado":
                            FrmDictamen.instance.pTaponadoB.Load(ruta);
                            break;
                        case "linea":
                            FrmDictamen.instance.pEnvasadoB.Load(ruta);
                            break;
                        case "marca":
                            FrmDictamen.instance.pMarcasB.Load(ruta);
                            break;
                        case "almacen_insumos":
                            FrmDictamen.instance.pAlSaborizantesB.Load(ruta);
                            break;
                        case "formulacion":
                            FrmDictamen.instance.pFormulacionB.Load(ruta);
                            break;

                    }
                    break;
                case "di_inf_fotos_almacen":
                    switch (texto)
                    {
                        case "terminado3":
                            FrmDictamen.instance.pTerminado3.Load(ruta);
                            break;
                        case "terminado4":
                            FrmDictamen.instance.pTerminado4.Load(ruta);
                            break;
                        case "terminado1":
                            FrmDictamen.instance.pTerminado1.Load(ruta);
                            break;
                        case "terminado2":
                            FrmDictamen.instance.pTerminado2.Load(ruta);
                            break;
                        case "maduracion3":
                            FrmDictamen.instance.pMaduracion3A.Load(ruta);
                            break;
                        case "maduracion4":
                            FrmDictamen.instance.pMaduracion4A.Load(ruta);
                            break;
                        case "maduracion1":
                            FrmDictamen.instance.pMaduracion1A.Load(ruta);
                            break;
                        case "maduracion2":
                            FrmDictamen.instance.pMaduracion2A.Load(ruta);
                            break;
                        case "carga1":
                            FrmDictamen.instance.pCarga1A.Load(ruta);
                            break;
                        case "carga2":
                            FrmDictamen.instance.pCarga2A.Load(ruta);
                            break;
                        case "carga3":
                            FrmDictamen.instance.pCarga3A.Load(ruta);
                            break;
                        case "carga4":
                            FrmDictamen.instance.pCarga4A.Load(ruta);
                            break;
                        case "recipiente1":
                            FrmDictamen.instance.pRecipientes1A.Load(ruta);
                            break;
                        case "recipiente2":
                            FrmDictamen.instance.pRecipientes2A.Load(ruta);
                            break;
                        case "recipiente3":
                            FrmDictamen.instance.pRecipientes3A.Load(ruta);
                            break;
                        case "recipiente4":
                            FrmDictamen.instance.pRecipientes4A.Load(ruta);
                            break; 
                        case "infraestructura":
                            FrmDictamen.instance.pInfraestructura.Load(ruta);
                            break;
                        case "granel1":
                            FrmDictamen.instance.pGramelA1.Load(ruta);
                            break;
                        case "granel2":
                            FrmDictamen.instance.pGramelA2.Load(ruta);
                            break;
                        case "granel3":
                            FrmDictamen.instance.pGramelA3.Load(ruta);
                            break;
                        case "granel4":
                            FrmDictamen.instance.pGramelA4.Load(ruta);
                            break;
                        case "almacen1":
                            FrmDictamen.instance.pAlmacenA1.Load(ruta);
                            break;
                        case "almacen2":
                            FrmDictamen.instance.pAlmacenA2.Load(ruta);
                            break;
                        case "almacen3":
                            FrmDictamen.instance.pAlmacenA3.Load(ruta);
                            break;
                        case "almacen4":
                            FrmDictamen.instance.pAlmacenA4.Load(ruta);
                            break;
                        default:
                            MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case "di_inf_areas_comunes":
                    switch (texto)
                    {
                        case "laboratorio":
                            FrmDictamen.instance.pLaboratorio.Load(ruta);
                            break;
                        case "sanitarios":
                            FrmDictamen.instance.pSanitarios.Load(ruta);
                            break;
                        case "estacionamiento":
                            FrmDictamen.instance.pEstacionamiento.Load(ruta);
                            break;
                        case "oficinas":
                            FrmDictamen.instance.pOficinas.Load(ruta);
                            break;
                        case "herramientas":
                            FrmDictamen.instance.pHerramientas.Load(ruta);
                            break;
                        case "carga":
                            FrmDictamen.instance.pCarga.Load(ruta);
                            break;
                        case "otros1":
                            FrmDictamen.instance.pOtros1.Load(ruta);
                            break;
                        case "otros2":
                            FrmDictamen.instance.pOtros2.Load(ruta);
                            break;
                        default:
                            MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
           
        }   

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // El siguiente código servirá para que si hacemos un click en Ok con el selector de archivos, el texto del TextBox1 sea el archivo seleccionado.
                ofd1.Filter = "jpg (*.jpg)|*.jpg|png (*.png)|*.png|gif (*.gif)|*.gif";
                var resultado = ofd1.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    textBox1.Text = ofd1.FileName;
                    pictureBox1.ImageLocation = ofd1.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);

                    pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);

                    pictureBox1.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
                    Controls.Add(pictureBox1);

                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningun archivo");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
                crpPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                // set initial x,y co ordinates for crop rectangle
                //this is where we firstly click on image
                crpX = e.X;
                crpY = e.Y;

            }
        }

        private void FrmAgregarImagen_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(no_cliente + "  " + tipo_img + "  " + di_solicitud);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMysql.insUpd_transaccion("UPDATE sinca." + tabla + " SET " + texto + "='' WHERE id_solicitud='" + di_solicitud + "' ") == "Error")
                {
                    return;
                }
                ConexionMysql.transCompleta();
                MessageBox.Show("Registro eliminado con exito", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                eliminar_imagen();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminar_imagen()
        {
            switch (tabla)
            {
                case "di_inf_fotos_produccion":
                    switch (texto)
                    {
                        case "maestro":
                            FrmDictamen.instance.pMaestro.Image = null;
                            Console.WriteLine("maestro");
                            break;
                        case "recepcion1":
                            FrmDictamen.instance.pRecepcion1.Image = null;
                            break;
                        case "recepcion2":
                            FrmDictamen.instance.pRecepcion2.Image = null;
                            break;
                        case "coccion1":
                            FrmDictamen.instance.pCoccion1.Image = null;
                            break;
                        case "coccion2":
                            FrmDictamen.instance.pCoccion2.Image = null;
                            break;
                        case "molienda1":
                            FrmDictamen.instance.pMolienda1.Image = null;
                            break;
                        case "molienda2":
                            FrmDictamen.instance.pMolienda2.Image = null;
                            break;
                        case "fermentacion1":
                            FrmDictamen.instance.pFermentacion1.Image = null;
                            break;
                        case "fermentacion2":
                            FrmDictamen.instance.pFermentacion2.Image = null;
                            break;
                        case "destilacion1":
                            FrmDictamen.instance.pDestilacion1.Image = null;
                            break;
                        case "destilacion2":
                            FrmDictamen.instance.pDestilacion2.Image = null;
                            break;
                        case "almacen1":
                            FrmDictamen.instance.pAlmacen1.Image = null;
                            break;
                        case "almacen2":
                            FrmDictamen.instance.pAlmacen2.Image = null;
                            break;

                        case "vista_interior":
                            FrmDictamen.instance.pInterior.Image = null;
                            break;
                        case "vista_exterior":
                            FrmDictamen.instance.pExterior.Image = null;
                            break;
                        case "maduracion1":
                            FrmDictamen.instance.pMaduracion1.Image = null;
                            break;
                        case "maduracion2":
                            FrmDictamen.instance.pMaduracion2.Image = null;
                            break;
                        default:
                            MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case "di_inf_fotos_envasado":
                    switch (texto)
                    {
                        case "almacen_granel":
                            FrmDictamen.instance.pProductoEGranel.Image = null;
                            break;
                        case "lavado":
                            FrmDictamen.instance.pLavadoBotellas.Image = null;
                            break;
                        case "llenado":
                            FrmDictamen.instance.pLlenado.Image = null;
                            break;
                        case "taponado":
                            FrmDictamen.instance.pTaponado.Image = null;
                            break;
                        case "general_interior":
                            FrmDictamen.instance.pVistaInterior.Image = null;
                            break;
                        case "general_exterior":
                            FrmDictamen.instance.pVistaExterior.Image = null;
                            break;
                        case "almacen_terminado":
                            FrmDictamen.instance.pAlmacenE.Image = null;
                            break;
                        case "marcas":
                            FrmDictamen.instance.pMarcas.Image = null;
                            break;
                        case "almacen_insumos":
                            FrmDictamen.instance.pAlmacenInsumos.Image = null;
                            break;
                        case "otros":
                            FrmDictamen.instance.pOtrosE.Image = null;
                            break;
                        case "linea":
                            FrmDictamen.instance.pLineaE.Image = null;
                            break;
                        case "maduracion":
                            FrmDictamen.instance.pMaduracionE.Image = null;
                            break;
                        case "granel":
                            FrmDictamen.instance.pGranelE.Image = null;
                            break;
                        default:
                            MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                case "di_inf_fotos_envasado_bc":
                    switch (texto)
                    {
                        case "almacen_granel":
                            FrmDictamen.instance.pAlmacenB.Image = null;
                            break;
                        case "lavado":
                            FrmDictamen.instance.pLavadoB.Image = null;
                            break;
                        case "llenado":
                            FrmDictamen.instance.pLlenadoB.Image = null;
                            break;
                        case "taponado":
                            FrmDictamen.instance.pTaponadoB.Image = null;
                            break;
                        case "linea":
                            FrmDictamen.instance.pEnvasadoB.Image = null;
                            break;
                        case "marca":
                            FrmDictamen.instance.pMarcasB.Image = null;
                            break;
                        case "almacen_insumos":
                            FrmDictamen.instance.pAlSaborizantesB.Image = null;
                            break;
                        case "formulacion":
                            FrmDictamen.instance.pFormulacionB.Image = null;
                            break;

                    }
                    break;
                case "di_inf_fotos_almacen":
                    switch (texto)
                    {
                        case "terminado3":
                            FrmDictamen.instance.pTerminado3.Image = null;
                            break;
                        case "terminado4":
                            FrmDictamen.instance.pTerminado4.Image = null;
                            break;
                        case "terminado1":
                            FrmDictamen.instance.pTerminado1.Image = null;
                            break;
                        case "terminado2":
                            FrmDictamen.instance.pTerminado2.Image = null;
                            break;
                        case "maduracion3":
                            FrmDictamen.instance.pMaduracion3A.Image = null;
                            break;
                        case "maduracion4":
                            FrmDictamen.instance.pMaduracion4A.Image = null;
                            break;
                        case "maduracion1":
                            FrmDictamen.instance.pMaduracion1A.Image = null;
                            break;
                        case "maduracion2":
                            FrmDictamen.instance.pMaduracion2A.Image = null;
                            break;
                        case "carga1":
                            FrmDictamen.instance.pCarga1A.Image = null;
                            break;
                        case "carga2":
                            FrmDictamen.instance.pCarga2A.Image = null;
                            break;
                        case "carga3":
                            FrmDictamen.instance.pCarga3A.Image = null;
                            break;
                        case "carga4":
                            FrmDictamen.instance.pCarga4A.Image = null;
                            break;
                        case "recipiente1":
                            FrmDictamen.instance.pRecipientes1A.Image = null;
                            break;
                        case "recipiente2":
                            FrmDictamen.instance.pRecipientes2A.Image = null;
                            break;
                        case "recipiente3":
                            FrmDictamen.instance.pRecipientes3A.Image = null;
                            break;
                        case "recipiente4":
                            FrmDictamen.instance.pRecipientes4A.Image = null;
                            break;
                        case "infraestructura":
                            FrmDictamen.instance.pInfraestructura.Image = null;
                            break;
                        case "granel1":
                            FrmDictamen.instance.pGramelA1.Image = null;
                            break;
                        case "granel2":
                            FrmDictamen.instance.pGramelA2.Image = null;
                            break;
                        case "granel3":
                            FrmDictamen.instance.pGramelA3.Image = null;
                            break;
                        case "granel4":
                            FrmDictamen.instance.pGramelA4.Image = null;
                            break;
                        case "almacen1":
                            FrmDictamen.instance.pAlmacenA1.Image = null;
                            break;
                        case "almacen2":
                            FrmDictamen.instance.pAlmacenA2.Image = null;
                            break;
                        case "almacen3":
                            FrmDictamen.instance.pAlmacenA3.Image = null;
                            break;
                        case "almacen4":
                            FrmDictamen.instance.pAlmacenA4.Image = null;
                            break;

                    }
                    break;
                case "di_inf_areas_comunes":
                    switch (texto)
                    {
                        case "laboratorio":
                            FrmDictamen.instance.pLaboratorio.Image = null;
                            break;
                        case "sanitarios":
                            FrmDictamen.instance.pSanitarios.Image = null;
                            break;
                        case "estacionamiento":
                            FrmDictamen.instance.pEstacionamiento.Image = null;
                            break;
                        case "oficinas":
                            FrmDictamen.instance.pOficinas.Image = null;
                            break;
                        case "herramientas":
                            FrmDictamen.instance.pHerramientas.Image = null;
                            break;
                        case "carga":
                            FrmDictamen.instance.pCarga.Image = null;
                            break;
                        case "otros1":
                            FrmDictamen.instance.pOtros1.Image = null;
                            break;
                        case "otros2":
                            FrmDictamen.instance.pOtros2.Image = null;
                            break;
                        default:
                            MessageBox.Show("Error al eliminar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("Error al mostrar imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }


        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Refresh();
                //set width and height for crop rectangle.
                rectW = e.X - crpX;
                rectH = e.Y - crpY;
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawRectangle(crpPen, crpX, crpY, rectW, rectH);
                g.Dispose();
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Default;
        }


    }

}