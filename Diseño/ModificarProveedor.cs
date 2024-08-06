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
    public partial class ModificarProveedor : Form
    {

        NegocioProveedores negocioProveedores = new NegocioProveedores();
        public ModificarProveedor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {
           dtgv.DataSource= negocioProveedores.LlenarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgv.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dtgv.Rows[rowIndex].Cells[0].Value);

            try
            {
                NegocioProveedores negocioProveedores = new NegocioProveedores();
                negocioProveedores.ModificarProveedor(
                    id,
                    txtName.Text,
                    txtEmail.Text,
                    txtTelefono.Text,
                    txtDireccion.Text                    
                );
                MessageBox.Show("Proveedor modificado correctamente.");
                dtgv.DataSource = negocioProveedores.LlenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgv.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dtgv.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dtgv.CurrentRow.Cells[2].Value.ToString();
            txtTelefono.Text = dtgv.CurrentRow.Cells[3].Value.ToString();
            txtDireccion.Text = dtgv.CurrentRow.Cells[4].Value.ToString();
            
        }
    }
}
