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

using System.Xml.Linq;

namespace Diseño
{
    public partial class ConsultaCliente : Form
    {
        private NegocioClientes negocioClientes = new NegocioClientes();
        public ConsultaCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string dni = txtDni.Text;
            string telefono = txtTelefonoCliente.Text;
            string email = txtEmail.Text;
            string direccion = txtDireccion.Text;

            dtgv.DataSource = negocioClientes.BuscarClientes(nombre, apellido, dni, telefono, email, direccion);

        }

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = negocioClientes.ObtenerTodosLosClientes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtDni.Clear();
            txtTelefonoCliente.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDni.Text = dtgv.CurrentRow.Cells[0].Value.ToString();
            txtNombreCliente.Text = dtgv.CurrentRow.Cells[1].Value.ToString();
            txtApellidoCliente.Text=dtgv.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dtgv.CurrentRow.Cells[3].Value.ToString();
            txtTelefonoCliente.Text = dtgv.CurrentRow.Cells[4].Value.ToString();
            txtDireccion.Text = dtgv.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
