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
    public partial class ConsultaProveedor : Form
    {
        private NegocioProveedores negocioProveedores = new NegocioProveedores();

        public ConsultaProveedor()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigoProveedor.Clear();
            txtNombreProveedor.Clear();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {

            string proveedorIDText = txtCodigoProveedor.Text.Trim();
            string nombre = txtNombreProveedor.Text.Trim();

            if (string.IsNullOrEmpty(proveedorIDText) && string.IsNullOrEmpty(nombre))
            {
                // Si ambos campos están vacíos, mostrar todos los proveedores
                dataGridView1.DataSource = negocioProveedores.LlenarGrid();
            }
            else if (!string.IsNullOrEmpty(proveedorIDText) && int.TryParse(proveedorIDText, out int proveedorID))
            {
                // Buscar por ID
                DataTable dt = negocioProveedores.ObtenerProveedorPorID(proveedorID);
                dataGridView1.DataSource = dt;
            }
            else if (!string.IsNullOrEmpty(nombre))
            {
                // Buscar por nombre
                DataTable dt = negocioProveedores.ObtenerProveedorPorNombre(nombre);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de proveedor o un nombre de proveedor válido.");
            }

        }

        private void ConsultaProveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = negocioProveedores.LlenarGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
