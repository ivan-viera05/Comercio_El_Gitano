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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            diseño();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
        int posY = 0;
        int posX = 0;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void diseño()
        {
            panelClientes.Visible = true;
            panelLibroSubmenu.Visible = false;
            panelProveedores.Visible = false;
            panelRemito.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelLibroSubmenu.Visible == true)
                panelLibroSubmenu.Visible = false;
            if (panelProveedores.Visible == true)
                panelProveedores.Visible = false;
            if (panelRemito.Visible == true)
                panelRemito.Visible = false;
            if (panelClientes.Visible == true)
                panelClientes.Visible = false;
        }


        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            activeForm.Show();
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new consultaLibros());
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLibroSubmenu);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelClientes);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProveedores);
        }

        private void btnboleta_Click(object sender, EventArgs e)
        {
            showSubMenu(panelRemito);
        }

        private void btnAltas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new AltaLibros());
        }

        private void btnModificaciones_Click(object sender, EventArgs e)
        {

            hideSubMenu();
            openChildForm(new ModificarLibro());
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ConsultaCliente());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Venta());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new BajaCliente());
        }

        private void btnCrearVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarProveedores_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ConsultaProveedor());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ConsultaProveedorLibro());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {

            hideSubMenu();
            openChildForm(new AltaProveedor());
        }

        private void btnModificarProveedores_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new BajaProveedor());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ModificarProveedor());
        }

        private void btnInspeccionarVenta_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ConsultaVenta());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ConsultaProveedorHistorial());
        }

        private void panelLibroSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new ConsultaLibroHistorial());
        }
    }
}
