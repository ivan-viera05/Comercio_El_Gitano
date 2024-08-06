using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class BajaCliente : Form
    {
        private NegocioClientes clientesNegocio = new NegocioClientes();
        public BajaCliente()
        {
            InitializeComponent();
            LoadClientes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellidoCliente.Clear();
            txtMail.Clear();
            txtDireccion.Clear();
            txtDni.Clear();
           
            txtNombreCliente.Clear();
            
            txtTelefonoCliente.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDni.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombreCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellidoCliente.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMail.Text =dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTelefonoCliente.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
         private void LoadClientes()
        {
            dataGridView1.DataSource = clientesNegocio.ObtenerTodosLosClientes();
        }

        private void BajaCliente_Load(object sender, EventArgs e)
        {
          
            
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string dni = txtDni.Text;
            string telefono = txtTelefonoCliente.Text;
            string mail=txtMail.Text;
            string direccion = txtDireccion.Text;
            

            dataGridView1.DataSource = clientesNegocio.BuscarClientes(nombre, apellido, dni, telefono,mail,direccion);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (MessageBox.Show("¿Estás seguro de que quieres eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (clientesNegocio.EliminarCliente(dni))
                    {
                        MessageBox.Show("Cliente eliminado correctamente.");
                        LoadClientes();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
