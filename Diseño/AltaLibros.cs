using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class AltaLibros : Form
    {
        private NegocioLibros negocioLibros = new NegocioLibros();
        public AltaLibros()
        {
            InitializeComponent();
            grbxAgregarStock.Enabled = false;
            grbxNuevo.Enabled = false;
        }

         

        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            grbxNuevo.Enabled = false;
            grbxAgregarStock.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones
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
                MessageBox.Show("El campo Fecha de Publicación no puede estar vacío y debe tener un formato de fecha válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtEditorial.Text))
            {
                MessageBox.Show("El campo Editorial no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("El campo Precio no puede estar vacío y debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPaginas.Text) || !int.TryParse(txtPaginas.Text, out _))
            {
                MessageBox.Show("El campo Páginas no puede estar vacío y debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("El campo Stock no puede estar vacío y debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtIDProveedor.Text) || !int.TryParse(txtIDProveedor.Text, out _))
            {
                MessageBox.Show("El campo ID del Proveedor no puede estar vacío y debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                negocioLibros.AgregarLibro(
                    txtName.Text,
                    txtAutor.Text,
                    txtCodigo.Text,
                    txtFechaPublicacion.Text,
                    txtEditorial.Text,
                    decimal.Parse(txtPrecio.Text),
                    int.Parse(txtPaginas.Text),
                    cbxGenero.SelectedIndex,
                    txtDescripcion.Text,
                    int.Parse(txtStock.Text),
                    int.Parse(txtIDProveedor.Text)  // Nuevo campo
                );
                MessageBox.Show("Se agregó correctamente el libro.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtAutor.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtEditorial.Clear();
            txtPaginas.Clear();
            txtFechaPublicacion.Clear();
            txtName.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cbxGenero.SelectedIndex = -1;
            grbxNuevo.Enabled = false;
        }

        private void btnSumarStock_Click(object sender, EventArgs e)
        {
            try
            {
                negocioLibros.SumarStock(txtCodigo2.Text, int.Parse(txtCantidadAgregar.Text));
                MessageBox.Show("El stock del libro se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaPublicacion_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Solo permitir números y barras
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFechaPublicacion_Leave(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(txtFechaPublicacion.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("La fecha de publicación debe estar en el formato dd/MM/yyyy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtFechaPublicacion_TextChanged(object sender, EventArgs e)
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

        private void cbxGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevoLibro_Click_1(object sender, EventArgs e)
        {
            grbxAgregarStock.Enabled = false;
            grbxNuevo.Enabled = true;
        }

        private void btnAgregarStock_Click_1(object sender, EventArgs e)
        {
            grbxNuevo.Enabled = false;
            grbxAgregarStock.Enabled = true;
        }
    }
    }

