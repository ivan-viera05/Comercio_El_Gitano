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
    public partial class AltaProveedor : Form
    {
        NegocioProveedores negocioProveedores = new NegocioProveedores();
        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreProveedor.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefonoProveedor.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            bool success = negocioProveedores.InsertarProveedor(nombre, email, telefono, direccion);
            if (success)
            {
                MessageBox.Show("Proveedor agregado exitosamente.");
                
            }
            else
            {
                MessageBox.Show("Error al agregar el proveedor.");
            }
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = negocioProveedores.LlenarGrid();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDireccion.Clear();
            txtEmail.Clear();
            txtNombreProveedor.Clear();
            txtTelefonoProveedor.Clear();
        }
    }
}
