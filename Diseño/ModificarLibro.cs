using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Diseño
{
    public partial class ModificarLibro : Form
    {
        private NegocioLibros negocioLibros = new NegocioLibros();
        public ModificarLibro()
        {
            InitializeComponent();
            dtgv.DataSource = negocioLibros.LlenarGrid();
        }

       


       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ModificarLibro_Load(object sender, EventArgs e)
        {

        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgv.CurrentRow.Cells[3].Value.ToString();
            txtName.Text = dtgv.CurrentRow.Cells[1].Value.ToString();
            txtAutor.Text = dtgv.CurrentRow.Cells[2].Value.ToString();
            txtFechaPublicacion.Text = dtgv.CurrentRow.Cells[4].Value.ToString();
            txtEditorial.Text = dtgv.CurrentRow.Cells[5].Value.ToString();
            txtPrecio.Text = dtgv.CurrentRow.Cells[6].Value.ToString();
            txtPaginas.Text = dtgv.CurrentRow.Cells[7].Value.ToString();
            cbxGenero.Text = dtgv.CurrentRow.Cells[8].Value.ToString();
            txtDescripcion.Text = dtgv.CurrentRow.Cells[9].Value.ToString();
            txtStock.Text = dtgv.CurrentRow.Cells[10].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtAutor.Clear();
            txtCodigo.Clear();
            txtFechaPublicacion.Clear();
            txtEditorial.Clear();
            txtPrecio.Clear();
            txtPaginas.Clear();
            cbxGenero.SelectedIndex = -1;
            txtName.Clear();
            txtStock.Clear();
            txtDescripcion.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       

        private void btnModificar_Click_1(object sender, EventArgs e)
        {

            // Validar que se haya seleccionado una fila en el DataGridView
            if (dtgv.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar un libro para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el ID del libro seleccionado
            int rowIndex = dtgv.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dtgv.Rows[rowIndex].Cells[0].Value);

            // Validaciones de los campos
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("El campo Nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtAutor.Text))
            {
                MessageBox.Show("El campo Autor no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("El campo ISBN no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtFechaPublicacion.Text) || !DateTime.TryParseExact(txtFechaPublicacion.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("El campo Fecha de Publicación debe tener un formato de fecha válido (dd/MM/yyyy).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtEditorial.Text))
            {
                MessageBox.Show("El campo Editorial no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("El campo Precio debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPaginas.Text) || !int.TryParse(txtPaginas.Text, out _))
            {
                MessageBox.Show("El campo Páginas debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbxGenero.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Género.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("El campo Descripción no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtStock.Text) || !int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("El campo Stock debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Llamar al método de modificación
                negocioLibros.ModificarLibro(
                    id,
                    txtName.Text,
                    txtAutor.Text,
                    txtCodigo.Text,
                    txtFechaPublicacion.Text,
                    txtEditorial.Text,
                    Convert.ToDecimal(txtPrecio.Text),
                    Convert.ToInt32(txtPaginas.Text),
                    cbxGenero.SelectedItem?.ToString(), // Manejar nulos
                    txtDescripcion.Text,
                    Convert.ToInt32(txtStock.Text)
                );
                MessageBox.Show("Se modificó correctamente el libro.");
                // Actualizar el DataGridView
                dtgv.DataSource = negocioLibros.LlenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFechaPublicacion_TextChanged_1(object sender, EventArgs e)
        {
            // Guardar la posición del cursor
            int cursorPosition = txtFechaPublicacion.SelectionStart;

            // Quitar caracteres no numéricos
            string text = new string(txtFechaPublicacion.Text.Where(c => char.IsDigit(c)).ToArray());

            // Limitar la longitud del texto a 8 dígitos (ddMMyyyy)
            if (text.Length > 8)
                text = text.Substring(0, 8);

            // Aplicar el formato "dd/MM/yyyy"
            if (text.Length > 2)
                text = text.Insert(2, "/");
            if (text.Length > 5)
                text = text.Insert(5, "/");

            // Asignar el texto formateado al TextBox
            txtFechaPublicacion.Text = text;

            // Restaurar la posición del cursor
            txtFechaPublicacion.SelectionStart = cursorPosition;

            // Mover el cursor al final del texto
            txtFechaPublicacion.SelectionStart = txtFechaPublicacion.Text.Length;
        }

        private void txtFechaPublicacion_Leave_1(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(txtFechaPublicacion.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("La fecha de publicación debe estar en el formato dd/MM/yyyy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtFechaPublicacion_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y barras
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            txtAutor.Clear();
            txtFechaPublicacion.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtDescripcion.Clear();
            txtEditorial.Clear();
            txtName.Clear();
            txtPaginas.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            cbxGenero.SelectedIndex = -1;
        }
    }
}
