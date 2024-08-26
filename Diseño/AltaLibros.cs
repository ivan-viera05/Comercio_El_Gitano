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
        private NegocioValidaciones negocio = new NegocioValidaciones();
        private NegocioProveedores proveedorNegocio = new NegocioProveedores();
        private const int MaxCaracteres = 13;
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

            if (string.IsNullOrEmpty(txtIDProveedor.Text) || !int.TryParse(txtIDProveedor.Text, out int proveedorID))
            {
                MessageBox.Show("El campo ID del Proveedor no puede estar vacío y debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el ID del proveedor existe
            if (!proveedorNegocio.VerificarProveedorID(proveedorID))
            {
                MessageBox.Show("El ID del Proveedor no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    proveedorID
                );

                MessageBox.Show("Libro agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el libro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtAutor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacio, y la tecla de retroceso (Backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtAutor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (negocio.ContieneNumeros(txt.Text))
            {
                // Eliminar los números del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"\d", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void txtAutor_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga números.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (!negocio.EsSoloNumeros(txt.Text))
            {
                MessageBox.Show("El campo solo acepta números.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Eliminar los caracteres no numéricos del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar texto que no sean números
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga caracteres no numéricos.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!negocio.EsSoloNumeros(txt.Text))
            {
              txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }

            // Validar que no exceda los 13 caracteres
            if (!negocio.EsLongitudValida(txt.Text, 13))
            {
                MessageBox.Show($"El campo no puede tener más de {13} caracteres.", "Longitud excedida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = txt.Text.Substring(0, 13);
            }

            txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
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

        private void txtFechaPublicacion_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar fechas en un formato incorrecto
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto en un formato incorrecto.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPaginas_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!negocio.EsSoloNumeros(txt.Text))
            {
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }

            // Validar que no exceda los 13 caracteres
            if (!negocio.EsLongitudValida(txt.Text,13))
            {
                MessageBox.Show($"El campo no puede tener más de {13} caracteres.", "Longitud excedida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = txt.Text.Substring(0, 13);
            }

            txt.SelectionStart = txt.Text.Length;
        }

        private void txtPaginas_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar texto que no sean números
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga caracteres no numéricos.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtPaginas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void grbxNuevo_Enter(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!negocio.EsSoloNumeros(txt.Text))
            {
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }

            // Validar que no exceda los 13 caracteres
            if (!negocio.EsLongitudValida(txt.Text, 13))
            {
                MessageBox.Show($"El campo no puede tener más de {13} caracteres.", "Longitud excedida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = txt.Text.Substring(0, 13);
            }

            txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            // Evitar el uso de Ctrl+V para pegar texto que no sean números
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga caracteres no numéricos.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCodigo2_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!negocio.EsSoloNumeros(txt.Text))
            {
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }

            // Validar que no exceda los 13 caracteres
            if (!negocio.EsLongitudValida(txt.Text, 13))
            {
                MessageBox.Show($"El campo no puede tener más de {13} caracteres.", "Longitud excedida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = txt.Text.Substring(0, 13);
            }

            txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
        }

        private void txtCodigo2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCantidadAgregar_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Validar que solo contenga números
            if (!negocio.EsSoloNumeros(txt.Text))
            {
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
            }

            // Validar que no exceda los 13 caracteres
            if (!negocio.EsLongitudValida(txt.Text, MaxCaracteres))
            {
                MessageBox.Show($"El campo no puede tener más de {MaxCaracteres} caracteres.", "Longitud excedida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = txt.Text.Substring(0, MaxCaracteres);
            }

            txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
        }

        private void txtCantidadAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ignorar la tecla
                MessageBox.Show("No se permite pegar texto que contenga caracteres no numéricos.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCantidadAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla
            }
        }

        private void btnCancelarStock_Click(object sender, EventArgs e)
        {
            txtCodigo2.Clear();
            txtCantidadAgregar.Clear();
        }
    }
    }

