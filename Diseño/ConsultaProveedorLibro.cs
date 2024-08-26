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
    public partial class ConsultaProveedorLibro : Form
    {
        private NegocioProveedores NegocioProveedores = new NegocioProveedores();
        private NegocioValidaciones validaciones = new NegocioValidaciones();
        
        public ConsultaProveedorLibro()
        {
            InitializeComponent();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {

            string proveedorIDText = txtCodigoProveedor.Text.Trim();
            string ISBN = txtNombreProveedor.Text.Trim();

            if (string.IsNullOrEmpty(proveedorIDText) && string.IsNullOrEmpty(ISBN))
            {
                // Si ambos campos están vacíos, mostrar todos los proveedores
                dataGridView1.DataSource = NegocioProveedores.LlenarProovedoresLibros();
            }
            else if (!string.IsNullOrEmpty(proveedorIDText) && int.TryParse(proveedorIDText, out int proveedorID))
            {
                // Buscar por ID
                DataTable dt = NegocioProveedores.BuscarProveedorID(proveedorID);
                dataGridView1.DataSource = dt;
            }
            else if (!string.IsNullOrEmpty(ISBN))
            {
                // Buscar por nombre
                DataTable dt = NegocioProveedores.BuscarProveedorISBN(ISBN);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de proveedor o un nombre de proveedor válido.");
            }
        }

        private void ConsultaProveedorLibro_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = NegocioProveedores.LlenarProovedoresLibros();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigoProveedor.Clear();
            txtNombreProveedor.Clear();
        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
                // Eliminar los caracteres no numéricos del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Usar la capa de negocio para validar
            if (!validaciones.EsSoloNumeros(txt.Text))
            {
                 // Eliminar los caracteres no numéricos del texto
                txt.Text = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");
                txt.SelectionStart = txt.Text.Length; // Colocar el cursor al final del texto
            }
        }
    }
}
