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
    public partial class BajaProveedor : Form
    {
        private NegocioProveedores negocioProveedores = new NegocioProveedores();
        public BajaProveedor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {

            string proveedorIDText = txtProveedorID.Text.Trim();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombreProveedor.Clear();
            txtProveedorID.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string proveedorID = dataGridView1.CurrentRow.Cells["ProveedorID"].Value.ToString();
                bool isActive = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["ActivoCheckBox"].Value);

                // Cambiar el estado
                isActive = !isActive;

                // Actualizar el estado en la base de datos
                if (negocioProveedores.ActualizarEstadoProveedor(proveedorID, isActive))
                {
                    // Reflejar el cambio en el DataGridView
                    dataGridView1.CurrentRow.Cells["ActivoCheckBox"].Value = isActive;
                    MessageBox.Show("Estado del proveedor actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el estado del proveedor.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor primero.");
            }

        }
       
        private void ConfigurarDataGridView()
        {

            if (dataGridView1.Columns["Activo"] != null)
            {
                // Ocultar la columna original "Activo"
                dataGridView1.Columns["Activo"].Visible = false;

                // Crear y agregar la columna de checkbox
                DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
                chkColumn.Name = "ActivoCheckBox";
                chkColumn.HeaderText = "Activo";
                chkColumn.DataPropertyName = "Activo";
                dataGridView1.Columns.Add(chkColumn);

                // Llenar el checkbox según el valor de la columna original
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isActive = row.Cells["Activo"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Activo"].Value);
                    row.Cells["ActivoCheckBox"].Value = isActive;
                }
            }
        }
      
        private void ActualizarEstadoProveedor(string proveedorID, bool isActive)
        {
            try
            {
                if (negocioProveedores.ActualizarEstadoProveedor(proveedorID, isActive))
                {
                    MessageBox.Show("Estado del proveedor actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el estado del proveedor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void BajaProveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = negocioProveedores.LlenarGrid();
            ConfigurarDataGridView();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ActivoCheckBox"].Index && e.RowIndex >= 0)
            {
                bool isActive = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["ActivoCheckBox"].Value);
                string proveedorID = dataGridView1.Rows[e.RowIndex].Cells["ProveedorID"].Value.ToString();
                ActualizarEstadoProveedor(proveedorID, isActive);
            }
            txtNombreProveedor.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtProveedorID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica si la columna actual es la columna "Activo"
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ActivoCheckBox")
            {
                // Obtén el valor de la columna "Activo"
                bool isActive = Convert.ToBoolean(e.Value);

                // Cambia el color de fondo de la fila según el valor
                if (!isActive)
                {
                    // Cambiar el color de fondo a gris para filas inactivas
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    // Restaurar el color de fondo si el proveedor está activo
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }

        }
    }
}
