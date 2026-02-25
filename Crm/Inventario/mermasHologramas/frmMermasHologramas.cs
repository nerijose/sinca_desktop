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
using System.IO;

namespace Crm.Inventario.mermasHologramas
{
    public partial class frmMermasHologramas : Form
    {
        DataTable dtFolios = new DataTable();

        public frmMermasHologramas()
        {
            InitializeComponent();
            ConfigurarGrilla();
            AsignarEventos();
        }

        public string cliente = "";
        
        private void ConfigurarGrilla()
        {
            dtFolios.Columns.Add("Folio Inicial", typeof(string));
            dtFolios.Columns.Add("Folio Final", typeof(string));
            dtFolios.Columns.Add("Cantidad", typeof(int));

            dgvFolios.DataSource = dtFolios;
            dgvFolios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFolios.AllowUserToAddRows = false;
            
            // Columna de eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "X";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvFolios.Columns.Add(btnEliminar);
        }

        private void AsignarEventos()
        {
            btnAgregarFi.Click += BtnAgregarFi_Click;
            btnAgregarFf.Click += BtnAgregarFf_Click;
            dgvFolios.CellClick += DgvFolios_CellClick;
            btnAdjuntarArchivo.Click += BtnAdjuntarArchivo_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void frmMermasHologramas_Load(object sender, EventArgs e)
        {
            txtClienteMerma.Text = cliente;
            ConexionMysql.llenaCombo(ref cmbMarcaMerma, "SELECT  CONCAT (no_cliente,'-',cve_marca)  as id ,CONCAT('( ',cve_marca,' )',' - ',marca) as marca FROM marcas  where no_cliente ='" + cliente + "'ORDER BY cve_marca ASC", "id", "marca");
            cmbMotivoMerma.Items.Insert(0, "Código no visible");
            cmbMotivoMerma.Items.Insert(1, "Sin código");
            cmbMotivoMerma.Items.Insert(2, "Se salta folios");
            cmbMotivoMerma.Items.Insert(3, "Desprendimiento de sellos");
        }

        private void BtnAgregarFi_Click(object sender, EventArgs e)
        {
            string fi = txtFolioInicial.Text.Trim();
            if(!string.IsNullOrEmpty(fi))
            {
                AgregarRango(fi, fi);
                txtFolioInicial.Clear();
            }
        }

        private void BtnAgregarFf_Click(object sender, EventArgs e)
        {
            string fi = txtFolioInicial.Text.Trim();
            string ff = txtFolioFinal.Text.Trim();
            
            if (!string.IsNullOrEmpty(fi) && !string.IsNullOrEmpty(ff))
            {
                AgregarRango(fi, ff);
                txtFolioInicial.Clear();
                txtFolioFinal.Clear();
            }
            else
            {
                MessageBox.Show("Debe ingresar Folio Inicial y Folio Final para agregar un rango.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AgregarRango(string inicial, string final)
        {
            // Extraer solo números para verificar rango (asumiendo que los folios pueden tener letras pero su parte final es numérica)
            string numFiStr = new string(inicial.Where(char.IsDigit).ToArray());
            string numFfStr = new string(final.Where(char.IsDigit).ToArray());

            int numFi = 0, numFf = 0;
            int cantidad = 1;

            if (int.TryParse(numFiStr, out numFi) && int.TryParse(numFfStr, out numFf))
            {
                if (numFf >= numFi)
                {
                    cantidad = (numFf - numFi) + 1;
                }
                else
                {
                    MessageBox.Show("El Folio Final no puede ser menor al Folio Inicial.", "Error de Rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            dtFolios.Rows.Add(inicial, final, cantidad);
            ActualizarTotal();
        }

        private void DgvFolios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvFolios.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                dtFolios.Rows.RemoveAt(e.RowIndex);
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            int total = 0;
            foreach (DataRow row in dtFolios.Rows)
            {
                total += Convert.ToInt32(row["Cantidad"]);
            }
            txtTotalMermas.Text = total.ToString();
        }

        private void BtnAdjuntarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Evidencia|*.jpg;*.jpeg;*.png;*.pdf";
                ofd.Title = "Seleccione el archivo de evidencia";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaArchivo.Text = ofd.FileName;
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbMarcaMerma.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Marca.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMotivoMerma.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Motivo de merma.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtFolios.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un folio averiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtRutaArchivo.Text))
            {
                MessageBox.Show("Es obligatorio adjuntar un archivo de evidencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Subir Archivo
                string origenArchivo = txtRutaArchivo.Text;
                string extension = Path.GetExtension(origenArchivo);
                
                string directorioDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Evidencias\Mermas");
                if (!Directory.Exists(directorioDestino))
                {
                    Directory.CreateDirectory(directorioDestino);
                }

                // Generamos un nombre unico para el archivo
                string nombreArchivoDestino = "Merma_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
                string rutaDestinoFinal = Path.Combine(directorioDestino, nombreArchivoDestino);
                string rutaParaBD = @"Evidencias\Mermas\" + nombreArchivoDestino; 

                File.Copy(origenArchivo, rutaDestinoFinal, true);

                // Guardar en BD (Primero encabezado)
                string marca = cmbMarcaMerma.SelectedValue.ToString();
                string motivo = cmbMotivoMerma.SelectedItem.ToString();
                int esMaquila = chkMaquilaMerma.Checked ? 1 : 0;
                string obs = rtxtObservaciones.Text;
                string total = txtTotalMermas.Text;
                string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Asumimos que la tabla mermas_hologramas ya existe (el usuario o migración la crea)
                // Se usa el método que en su caso permite insUpd transaccional, aquí usamos algo estándar:
                string sqlInsertMerma = "INSERT INTO mermas_hologramas (no_cliente, id_marca, motivo, total_mermas, observaciones, es_maquila, ruta_evidencia, fecha_registro, id_usuario) " +
                                        " VALUES ('" + cliente + "', '" + marca + "', '" + motivo + "', '" + total + "', '" + obs + "', " + esMaquila + ", '" + rutaParaBD.Replace("\\","\\\\") + "', '" + fecha + "', '" + Usuario.IdUsuario + "'); " +
                                        " SELECT LAST_INSERT_ID();";

                string idMermaGenerada = ConexionMysql.insUpd_regresavalor(sqlInsertMerma);

                if (string.IsNullOrEmpty(idMermaGenerada) || idMermaGenerada == "Error")
                {
                    MessageBox.Show("Error al registrar la merma en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insertar el detalle de folios
                foreach (DataRow row in dtFolios.Rows)
                {
                    string fInicial = row["Folio Inicial"].ToString();
                    string fFinal = row["Folio Final"].ToString();
                    string cant = row["Cantidad"].ToString();

                    string sqlDetalle = "INSERT INTO mermas_hologramas_folios (id_merma, folio_inicial, folio_final, cantidad) " +
                                        " VALUES ('" + idMermaGenerada + "', '" + fInicial + "', '" + fFinal + "', '" + cant + "')";
                    ConexionMysql.insUpd(sqlDetalle);
                }

                MessageBox.Show("Merma de hologramas registrada con éxito. Archivo de evidencia guardado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar el guardado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
