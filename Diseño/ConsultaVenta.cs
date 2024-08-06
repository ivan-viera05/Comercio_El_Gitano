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
    public partial class ConsultaVenta : Form
    {
        NegocioVenta negocioVenta = new NegocioVenta();
        public ConsultaVenta()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaVenta_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = NegocioVenta.LlenarGrid();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int? ventaID = string.IsNullOrEmpty(txtIDVenta.Text) ? (int?)null : Convert.ToInt32(txtIDVenta.Text);
            string dni = string.IsNullOrEmpty(txtDni.Text) ? null : txtDni.Text;
            string isbn = string.IsNullOrEmpty(txtCodigoLibro.Text) ? null : txtCodigoLibro.Text;
            string fechaVenta = string.IsNullOrEmpty(txtFechaCompra.Text) ? null : txtFechaCompra.Text;
            decimal? precioVenta = string.IsNullOrEmpty(txtPrecioVenta.Text) ? (decimal?)null : Convert.ToDecimal(txtPrecioVenta.Text);
            DateTime? startDate = dateTimePickerStart.Value;
            DateTime? endDate = dateTimePickerEnd.Value;

            try
            {
                NegocioVenta negocioVentas = new NegocioVenta();
                dataGridView1.DataSource = negocioVentas.BuscarVentas(ventaID, dni, isbn, fechaVenta, precioVenta, startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultaVenta_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = NegocioVenta.LlenarGrid();
        }

        private void txtFechaCompra_TextChanged(object sender, EventArgs e)
        {
            // Guardar la posición del cursor
            int cursorPosition = txtFechaCompra.SelectionStart;

            // Quitar caracteres no numéricos
            string text = new string(txtFechaCompra.Text.Where(c => char.IsDigit(c)).ToArray());

            // Limitar la longitud del texto a 8 dígitos (ddMMyyyy)
            if (text.Length > 8)
                text = text.Substring(0, 8);

            // Aplicar el formato "dd/MM/yyyy"
            if (text.Length > 2)
                text = text.Insert(2, "/");
            if (text.Length > 5)
                text = text.Insert(5, "/");

            // Asignar el texto formateado al TextBox
            txtFechaCompra.Text = text;

            // Restaurar la posición del cursor
            txtFechaCompra.SelectionStart = cursorPosition;

            // Mover el cursor al final del texto
            txtFechaCompra.SelectionStart = txtFechaCompra.Text.Length;
        }

        private void txtFechaCompra_Leave(object sender, EventArgs e)
        {

            if (!DateTime.TryParseExact(txtFechaCompra.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("La fecha de publicación debe estar en el formato dd/MM/yyyy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y barras
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigoLibro.Clear();
            txtDni.Clear();
            txtFechaCompra.Clear();
            txtIDVenta.Clear();
            txtPrecioVenta.Clear();
           
           
           
            

        }
    }
}
