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
    public partial class Venta : Form
    {

        private NegocioLibros negocioLibros;
        private DataTable dtgvLibrosDataTable;
        private NegocioValidaciones validaciones = new NegocioValidaciones();
        private NegocioLibros LibrosNegocio = new NegocioLibros();
        
        public Venta()
        {

            InitializeComponent();
            negocioLibros = new NegocioLibros();
            dtgvLibrosDataTable = new DataTable();


        }
        public class ProductoVenta
        {
            public string ISBN { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioVenta { get; set; }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string isbn = txtCodigoLibro.Text;

            // Obtener datos del libro
            DataTable bookData = negocioLibros.GetBookByISBN(isbn);

            // Verificar si se encontró el libro
            if (bookData.Rows.Count > 0)
            {
                // Obtener los datos del libro
                DataRow row = bookData.Rows[0];
                string titulo = row["Titulo"].ToString();
                decimal precio = Convert.ToDecimal(row["Precio"]);
                int stock = Convert.ToInt32(row["Stock"]);

                // Verificar si el libro ya está en el DataGridView
                bool libroEncontrado = false;
                foreach (DataGridViewRow dgvRow in dtgvLibros.Rows)
                {
                    if (dgvRow.Cells[1].Value != null && dgvRow.Cells[1].Value.ToString() == isbn)
                    {
                        // Libro encontrado, actualizar cantidad y verificar stock
                        int cantidadActual = Convert.ToInt32(dgvRow.Cells[3].Value);
                        if (cantidadActual + 1 <= stock)
                        {
                            dgvRow.Cells[3].Value = cantidadActual + 1;
                            dgvRow.Cells[2].Value = precio * (cantidadActual + 1);
                        }
                        else
                        {
                            MessageBox.Show("No hay suficiente stock para agregar otra unidad de este libro.");
                        }
                        libroEncontrado = true;
                        break;
                    }
                }

                // Si el libro no está en el DataGridView, agregar una nueva fila
                if (!libroEncontrado)
                {
                    if (stock > 0)
                    {
                        // Crear una nueva fila en el DataGridView
                        DataGridViewRow dgvRow = new DataGridViewRow();
                        dgvRow.CreateCells(dtgvLibros);

                        // Asignar valores a las celdas
                        dgvRow.Cells[0].Value = titulo;
                        dgvRow.Cells[1].Value = isbn;
                        dgvRow.Cells[2].Value = precio;
                        dgvRow.Cells[3].Value = 1; // Cantidad inicial

                        // Aplicar estilos a las celdas
                        foreach (DataGridViewCell cell in dgvRow.Cells)
                        {
                            cell.Style.ForeColor = Color.Black;
                            cell.Style.BackColor = Color.White;
                        }

                        // Agregar la fila al DataGridView
                        dtgvLibros.Rows.Add(dgvRow);
                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente stock para este libro.");
                    }
                }

                // Actualizar el subtotal
                ActualizarSubtotal();
            }
            else
            {
                MessageBox.Show("Libro no encontrado.");
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> libros = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dtgvLibros.Rows)
            {
                if (!row.IsNewRow)
                {
                    libros.Add(row);
                }
            }

            decimal subtotal = decimal.Parse(lblSubtotal.Text, System.Globalization.NumberStyles.Currency);
            decimal descuento;
            decimal.TryParse(txtDescuento.Text, out descuento);
            decimal total = decimal.Parse(lblTotal.Text, System.Globalization.NumberStyles.Currency);
            NegocioLibros libroNegocio = new NegocioLibros();
            // Actualizar el stock en la base de datos
            foreach (DataGridViewRow row in libros)
            {
                string isbn = row.Cells[1].Value.ToString();
                int cantidadComprada = Convert.ToInt32(row.Cells[3].Value);
                libroNegocio.RestarStock(isbn, cantidadComprada);
            }

            // Crear un DataTable con los datos de la venta
            DataTable ventaData = new DataTable();
            ventaData.Columns.Add("Titulo");
            ventaData.Columns.Add("Cantidad");
            ventaData.Columns.Add("Precio");

            foreach (var row in libros)
            {
                DataRow ventaRow = ventaData.NewRow();
                ventaRow["Titulo"] = row.Cells[0].Value.ToString();
                ventaRow["Cantidad"] = Convert.ToInt32(row.Cells[3].Value);
                ventaRow["Precio"] = Convert.ToDecimal(row.Cells[2].Value);
                ventaData.Rows.Add(ventaRow);
            }

            Venta2 formImprimir = new Venta2(libros, subtotal, descuento, total, ventaData);
            formImprimir.Show();
        }
    

        private void Venta_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }
        private void ActualizarSubtotal()
        {
            decimal subtotal = 0m;

            foreach (DataGridViewRow dgvRow in dtgvLibros.Rows)
            {
                if (dgvRow.Cells[2].Value != null)
                {
                    subtotal += Convert.ToDecimal(dgvRow.Cells[2].Value);
                }
            }

            lblSubtotal.Text = subtotal.ToString("C"); // Formato de moneda
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal subtotal = decimal.Parse(lblSubtotal.Text, System.Globalization.NumberStyles.Currency);
            decimal descuento = 0m;

            if (decimal.TryParse(txtDescuento.Text, out descuento) && descuento >= 0 && descuento <= 100)
            {
                decimal total = subtotal - (subtotal * (descuento / 100));
                lblTotal.Text = total.ToString("C"); // Formato de moneda
            }
            else
            {
                MessageBox.Show("Ingrese un descuento válido (0-100).");
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtCodigoLibro_TextChanged(object sender, EventArgs e)
        {
            string codigo = txtCodigoLibro.Text.Trim();

            // Validar que solo contenga caracteres numéricos y hasta 13 caracteres
            
            if (!validaciones.ValidarNumerosYLongitud(codigo, 13))
            {
                MessageBox.Show("El campo codigo solo puede contener hasta 13 caracteres numéricos.", "Validación de Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Limitar la longitud del texto a 13 caracteres
                if (codigo.Length > 13)
                {
                   txtCodigoLibro.Text = codigo.Substring(0,13);
                   txtCodigoLibro.SelectionStart = txtCodigoLibro.Text.Length; // Para colocar el cursor al final del texto
                }
            }
        }

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {
            string codigo = txtCodigoLibro.Text.Trim();

            // Validar que solo contenga caracteres numéricos y hasta 13 caracteres

            if (!validaciones.ValidarNumerosYLongitud(codigo, 13))
            {
                MessageBox.Show("El campo codigo solo puede contener hasta 13 caracteres numéricos.", "Validación de Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Limitar la longitud del texto a 13 caracteres
                if (codigo.Length > 13)
                {
                    txtCodigoLibro.Text = codigo.Substring(0, 13);
                    txtCodigoLibro.SelectionStart = txtCodigoLibro.Text.Length; // Para colocar el cursor al final del texto
                }
            }
        }

        private void txtCantidadEliminar_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
                MessageBox.Show("El campo solo acepta números.", "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Eliminar los caracteres no numéricos del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            string isbn = txtISBN.Text;
            int cantidadAEliminar;

            // Verificar si la cantidad a eliminar es un número válido
            if (!int.TryParse(txtCantidadEliminar.Text, out cantidadAEliminar) || cantidadAEliminar <= 0)
            {
                MessageBox.Show("Por favor ingrese una cantidad válida para eliminar.");
                return;
            }

            // Verificar si el ISBN ingresado está en el DataGridView
            bool libroEncontrado = false;
            foreach (DataGridViewRow dgvRow in dtgvLibros.Rows)
            {
                if (dgvRow.Cells[1].Value != null && dgvRow.Cells[1].Value.ToString() == isbn)
                {
                    // Verificar la cantidad actual
                    int cantidadActual = Convert.ToInt32(dgvRow.Cells[3].Value);

                    if (cantidadActual >= cantidadAEliminar)
                    {
                        // Actualizar la cantidad y el precio
                        dgvRow.Cells[3].Value = cantidadActual - cantidadAEliminar;
                        decimal precioUnitario = Convert.ToDecimal(dgvRow.Cells[2].Value) / cantidadActual;
                        dgvRow.Cells[2].Value = precioUnitario * (cantidadActual - cantidadAEliminar);

                        // Eliminar la fila si la cantidad llega a 0
                        if ((cantidadActual - cantidadAEliminar) == 0)
                        {
                            dtgvLibros.Rows.Remove(dgvRow);
                        }

                        libroEncontrado = true;
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar más de la cantidad actual.");
                    }

                    break;
                }
            }

            if (libroEncontrado)
            {
                MessageBox.Show("Cantidad eliminada de la lista.");
                // Limpiar los TextBox              
                txtISBN.Clear();
                txtCantidadEliminar.Clear();

                // Actualizar el subtotal
                ActualizarSubtotal();
            }
            else
            {
                MessageBox.Show("Libro no encontrado en la lista.");
            }
        }
    }
}
