namespace Diseño
{
    partial class AltaLibros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbxAgregarStock = new System.Windows.Forms.GroupBox();
            this.btnCancelarStock = new System.Windows.Forms.Button();
            this.btnSumarStock = new System.Windows.Forms.Button();
            this.txtCodigo2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantidadAgregar = new System.Windows.Forms.TextBox();
            this.grbxNuevo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIDProveedor = new System.Windows.Forms.TextBox();
            this.stock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPaginas = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaPublicacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxGenero = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnNuevoLibro = new System.Windows.Forms.Button();
            this.btnAgregarStock = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grbxAgregarStock.SuspendLayout();
            this.grbxNuevo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 44);
            this.panel1.TabIndex = 41;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::Diseño.Properties.Resources.Icono_cerrar_FN;
            this.btnClose.Location = new System.Drawing.Point(633, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grbxAgregarStock
            // 
            this.grbxAgregarStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbxAgregarStock.Controls.Add(this.btnCancelarStock);
            this.grbxAgregarStock.Controls.Add(this.btnSumarStock);
            this.grbxAgregarStock.Controls.Add(this.txtCodigo2);
            this.grbxAgregarStock.Controls.Add(this.label13);
            this.grbxAgregarStock.Controls.Add(this.label8);
            this.grbxAgregarStock.Controls.Add(this.txtCantidadAgregar);
            this.grbxAgregarStock.ForeColor = System.Drawing.Color.White;
            this.grbxAgregarStock.Location = new System.Drawing.Point(12, 287);
            this.grbxAgregarStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxAgregarStock.Name = "grbxAgregarStock";
            this.grbxAgregarStock.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxAgregarStock.Size = new System.Drawing.Size(659, 95);
            this.grbxAgregarStock.TabIndex = 45;
            this.grbxAgregarStock.TabStop = false;
            this.grbxAgregarStock.Text = "Agrega Stock";
            // 
            // btnCancelarStock
            // 
            this.btnCancelarStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelarStock.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarStock.Location = new System.Drawing.Point(492, 30);
            this.btnCancelarStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarStock.Name = "btnCancelarStock";
            this.btnCancelarStock.Size = new System.Drawing.Size(87, 31);
            this.btnCancelarStock.TabIndex = 39;
            this.btnCancelarStock.Text = "Cancelar";
            this.btnCancelarStock.UseVisualStyleBackColor = false;
            this.btnCancelarStock.Click += new System.EventHandler(this.btnCancelarStock_Click);
            // 
            // btnSumarStock
            // 
            this.btnSumarStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSumarStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSumarStock.ForeColor = System.Drawing.Color.Black;
            this.btnSumarStock.Location = new System.Drawing.Point(388, 30);
            this.btnSumarStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSumarStock.Name = "btnSumarStock";
            this.btnSumarStock.Size = new System.Drawing.Size(87, 31);
            this.btnSumarStock.TabIndex = 38;
            this.btnSumarStock.Text = "Agregar";
            this.btnSumarStock.UseVisualStyleBackColor = false;
            // 
            // txtCodigo2
            // 
            this.txtCodigo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo2.Location = new System.Drawing.Point(13, 39);
            this.txtCodigo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo2.Name = "txtCodigo2";
            this.txtCodigo2.Size = new System.Drawing.Size(123, 22);
            this.txtCodigo2.TabIndex = 38;
            this.txtCodigo2.TextChanged += new System.EventHandler(this.txtCodigo2_TextChanged);
            this.txtCodigo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo2_KeyPress);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 16);
            this.label13.TabIndex = 39;
            this.label13.Text = "Codigo";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(175, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Cantidad a agregar";
            // 
            // txtCantidadAgregar
            // 
            this.txtCantidadAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadAgregar.Location = new System.Drawing.Point(176, 39);
            this.txtCantidadAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantidadAgregar.Name = "txtCantidadAgregar";
            this.txtCantidadAgregar.Size = new System.Drawing.Size(151, 22);
            this.txtCantidadAgregar.TabIndex = 33;
            this.txtCantidadAgregar.TextChanged += new System.EventHandler(this.txtCantidadAgregar_TextChanged);
            this.txtCantidadAgregar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidadAgregar_KeyDown);
            this.txtCantidadAgregar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadAgregar_KeyPress);
            // 
            // grbxNuevo
            // 
            this.grbxNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbxNuevo.Controls.Add(this.label10);
            this.grbxNuevo.Controls.Add(this.txtIDProveedor);
            this.grbxNuevo.Controls.Add(this.stock);
            this.grbxNuevo.Controls.Add(this.txtStock);
            this.grbxNuevo.Controls.Add(this.label14);
            this.grbxNuevo.Controls.Add(this.txtPaginas);
            this.grbxNuevo.Controls.Add(this.btnCancelar);
            this.grbxNuevo.Controls.Add(this.btnAgregar);
            this.grbxNuevo.Controls.Add(this.label9);
            this.grbxNuevo.Controls.Add(this.txtDescripcion);
            this.grbxNuevo.Controls.Add(this.label7);
            this.grbxNuevo.Controls.Add(this.txtPrecio);
            this.grbxNuevo.Controls.Add(this.label6);
            this.grbxNuevo.Controls.Add(this.txtFechaPublicacion);
            this.grbxNuevo.Controls.Add(this.label5);
            this.grbxNuevo.Controls.Add(this.txtEditorial);
            this.grbxNuevo.Controls.Add(this.label4);
            this.grbxNuevo.Controls.Add(this.txtAutor);
            this.grbxNuevo.Controls.Add(this.txtName);
            this.grbxNuevo.Controls.Add(this.label2);
            this.grbxNuevo.Controls.Add(this.label3);
            this.grbxNuevo.Controls.Add(this.cbxGenero);
            this.grbxNuevo.Controls.Add(this.label1);
            this.grbxNuevo.Controls.Add(this.txtCodigo);
            this.grbxNuevo.ForeColor = System.Drawing.Color.White;
            this.grbxNuevo.Location = new System.Drawing.Point(12, 83);
            this.grbxNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxNuevo.Name = "grbxNuevo";
            this.grbxNuevo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbxNuevo.Size = new System.Drawing.Size(659, 184);
            this.grbxNuevo.TabIndex = 44;
            this.grbxNuevo.TabStop = false;
            this.grbxNuevo.Text = "Nuevo Libro";
            this.grbxNuevo.Enter += new System.EventHandler(this.grbxNuevo_Enter);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(540, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "ID Proveedor";
            // 
            // txtIDProveedor
            // 
            this.txtIDProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDProveedor.Location = new System.Drawing.Point(544, 90);
            this.txtIDProveedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDProveedor.Name = "txtIDProveedor";
            this.txtIDProveedor.Size = new System.Drawing.Size(103, 22);
            this.txtIDProveedor.TabIndex = 42;
            // 
            // stock
            // 
            this.stock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stock.AutoSize = true;
            this.stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stock.ForeColor = System.Drawing.Color.White;
            this.stock.Location = new System.Drawing.Point(263, 117);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(51, 20);
            this.stock.TabIndex = 41;
            this.stock.Text = "Stock";
            // 
            // txtStock
            // 
            this.txtStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStock.Location = new System.Drawing.Point(267, 135);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(130, 22);
            this.txtStock.TabIndex = 40;
            this.txtStock.TextChanged += new System.EventHandler(this.txtStock_TextChanged);
            this.txtStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStock_KeyDown);
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(462, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 39;
            this.label14.Text = "Paginas";
            // 
            // txtPaginas
            // 
            this.txtPaginas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaginas.Location = new System.Drawing.Point(463, 90);
            this.txtPaginas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaginas.Name = "txtPaginas";
            this.txtPaginas.Size = new System.Drawing.Size(68, 22);
            this.txtPaginas.TabIndex = 38;
            this.txtPaginas.TextChanged += new System.EventHandler(this.txtPaginas_TextChanged);
            this.txtPaginas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaginas_KeyDown);
            this.txtPaginas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaginas_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(550, 126);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 31);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(446, 126);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(87, 31);
            this.btnAgregar.TabIndex = 31;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(16, 135);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(234, 22);
            this.txtDescripcion.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(490, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecio.Location = new System.Drawing.Point(492, 41);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(145, 22);
            this.txtPrecio.TabIndex = 31;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyDown);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(298, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fecha Publicacion";
            // 
            // txtFechaPublicacion
            // 
            this.txtFechaPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaPublicacion.Location = new System.Drawing.Point(300, 90);
            this.txtFechaPublicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFechaPublicacion.Name = "txtFechaPublicacion";
            this.txtFechaPublicacion.Size = new System.Drawing.Size(149, 22);
            this.txtFechaPublicacion.TabIndex = 29;
            this.txtFechaPublicacion.TextChanged += new System.EventHandler(this.txtFechaPublicacion_TextChanged_1);
            this.txtFechaPublicacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaPublicacion_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Editorial";
            // 
            // txtEditorial
            // 
            this.txtEditorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditorial.Location = new System.Drawing.Point(13, 90);
            this.txtEditorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.Size = new System.Drawing.Size(123, 22);
            this.txtEditorial.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(348, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Autor";
            // 
            // txtAutor
            // 
            this.txtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutor.Location = new System.Drawing.Point(348, 41);
            this.txtAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(127, 22);
            this.txtAutor.TabIndex = 25;
            this.txtAutor.TextChanged += new System.EventHandler(this.txtAutor_TextChanged);
            this.txtAutor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAutor_KeyDown);
            this.txtAutor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutor_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(154, 41);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(172, 22);
            this.txtName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(150, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nombre Del Libro";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(150, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Genero ";
            // 
            // cbxGenero
            // 
            this.cbxGenero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGenero.FormattingEnabled = true;
            this.cbxGenero.Items.AddRange(new object[] {
            "Accion",
            "Policial",
            "Ciencia Ficcion",
            "Romantico",
            "Novela",
            "Cuento",
            "Relato",
            "Biografia",
            "Autobiografia",
            "Cronica",
            "Memorias",
            "Alta fantasía",
            "Fantasía urbana",
            "Fantasía épica",
            "Novela de aventuras",
            "Terror psicológico",
            "Terror psicológico",
            "Literatura infantil",
            "Comedia",
            "Drama"});
            this.cbxGenero.Location = new System.Drawing.Point(154, 90);
            this.cbxGenero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxGenero.Name = "cbxGenero";
            this.cbxGenero.Size = new System.Drawing.Size(121, 24);
            this.cbxGenero.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Location = new System.Drawing.Point(13, 41);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(123, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // btnNuevoLibro
            // 
            this.btnNuevoLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNuevoLibro.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoLibro.Location = new System.Drawing.Point(87, 48);
            this.btnNuevoLibro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevoLibro.Name = "btnNuevoLibro";
            this.btnNuevoLibro.Size = new System.Drawing.Size(87, 31);
            this.btnNuevoLibro.TabIndex = 42;
            this.btnNuevoLibro.Text = "NUEVO";
            this.btnNuevoLibro.UseVisualStyleBackColor = false;
            this.btnNuevoLibro.Click += new System.EventHandler(this.btnNuevoLibro_Click_1);
            // 
            // btnAgregarStock
            // 
            this.btnAgregarStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarStock.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarStock.Location = new System.Drawing.Point(182, 48);
            this.btnAgregarStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarStock.Name = "btnAgregarStock";
            this.btnAgregarStock.Size = new System.Drawing.Size(155, 31);
            this.btnAgregarStock.TabIndex = 43;
            this.btnAgregarStock.Text = "AGREGA STOCK";
            this.btnAgregarStock.UseVisualStyleBackColor = false;
            this.btnAgregarStock.Click += new System.EventHandler(this.btnAgregarStock_Click_1);
            // 
            // AltaLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(683, 427);
            this.Controls.Add(this.grbxAgregarStock);
            this.Controls.Add(this.grbxNuevo);
            this.Controls.Add(this.btnNuevoLibro);
            this.Controls.Add(this.btnAgregarStock);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AltaLibros";
            this.Text = "AltaLibros";
            this.panel1.ResumeLayout(false);
            this.grbxAgregarStock.ResumeLayout(false);
            this.grbxAgregarStock.PerformLayout();
            this.grbxNuevo.ResumeLayout(false);
            this.grbxNuevo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbxAgregarStock;
        private System.Windows.Forms.Button btnCancelarStock;
        private System.Windows.Forms.Button btnSumarStock;
        private System.Windows.Forms.TextBox txtCodigo2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidadAgregar;
        private System.Windows.Forms.GroupBox grbxNuevo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIDProveedor;
        private System.Windows.Forms.Label stock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPaginas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaPublicacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxGenero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnNuevoLibro;
        private System.Windows.Forms.Button btnAgregarStock;
    }
}