using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Negocio.NegocioVenta;



namespace Diseño
{
    public partial class Venta2 : Form
    {
        private List<DataGridViewRow> libros;
        private decimal subtotal;
        private decimal descuento;
        private decimal total;
        private NegocioClientes clienteNegocio;
        private NegocioVenta ventaNegocio;
        private DataTable ventaData;
        private Image logo;

        public Venta2(List<DataGridViewRow> libros, decimal subtotal, decimal descuento, decimal total, DataTable ventaData)
        {
            InitializeComponent();
            clienteNegocio = new NegocioClientes();
            ventaNegocio = new NegocioVenta();
            this.libros = libros;
            this.subtotal = subtotal;
            this.descuento = descuento;
            this.total = total;
            this.ventaData = ventaData;
            lblDescuento.Text = Convert.ToString(descuento);
            lblSubtotal.Text = Convert.ToString(subtotal);
            lblTotal.Text = Convert.ToString(total);
            string logoPath = "C:\\POO\\Tp-Individuales\\ComercioElGitano\\Diseño\\Resources\\logo.PNG"; // Ruta relativa correcta
            logo = Image.FromFile(logoPath);
        }

        private void btnAgregarTabla_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefonoCliente.Text;
            string direccion = txtDireccion.Text;

            // Conversión de DataGridViewRows a LibroVenta
            List<LibroVenta> librosVenta = new List<LibroVenta>();
            foreach (var row in libros)
            {
                var libro = new LibroVenta
                {
                    ISBN = row.Cells[1].Value.ToString(),
                    Cantidad = int.Parse(row.Cells[3].Value.ToString()),
                    PrecioVenta = decimal.Parse(row.Cells[2].Value.ToString())
                };
                librosVenta.Add(libro);
            }

            clienteNegocio.GuardarCliente(dni, nombre, apellido, email, telefono, direccion);
            ventaNegocio.ProcesarVenta(dni, librosVenta);

            MessageBox.Show("Cliente y ventas agregados/actualizados exitosamente.");

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };
            printPreviewDialog.ShowDialog();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 0;
            if (logo != null)
            {
                graphics.DrawImage(logo, startX, startY, 100, 50); // Ajusta el tamaño según sea necesario
                offset += 60; // Ajusta el espacio según sea necesario
            }

            graphics.DrawString("El Gitano", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Dirección de la Tienda: Mazzini 1431", font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Teléfono: 11-5989-1620", font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 20;

            graphics.DrawString("Ticket de Compra", fontBold, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("--------------------------------------------------", font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;

            // Datos del Cliente
            graphics.DrawString("DNI: " + txtDni.Text, font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Nombre: " + txtNombreCliente.Text, font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Apellido: " + txtApellidoCliente.Text, font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Email: " + txtEmail.Text, font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Teléfono: " + txtTelefonoCliente.Text, font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Dirección: " + txtDireccion.Text, font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 20;

            graphics.DrawString("--------------------------------------------------", font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString("Descripción        Cantidad        Precio", fontBold, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;

            // Detalles de la Compra
            foreach (DataRow row in ventaData.Rows)
            {
                string descripcion = row["Titulo"].ToString();
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                decimal precio = Convert.ToDecimal(row["Precio"]);

                graphics.DrawString($"{descripcion.PadRight(20)} {cantidad.ToString().PadRight(10)} {precio:C}", font, Brushes.Black, startX, startY + offset);
                offset += (int)fontHeight + 5;
            }

            offset += (int)fontHeight;
            graphics.DrawString("--------------------------------------------------", font, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;

            graphics.DrawString($"Subtotal: {subtotal:C}", fontBold, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString($"Descuento: {descuento}%", fontBold, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 5;
            graphics.DrawString($"Total: {total:C}", fontBold, Brushes.Black, startX, startY + offset);
            offset += (int)fontHeight + 20;

            graphics.DrawString("¡Gracias por su compra!", fontBold, Brushes.Black, startX, startY + offset);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Venta2_Load(object sender, EventArgs e)
        {

        }
    }
}
