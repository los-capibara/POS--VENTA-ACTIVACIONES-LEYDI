using System;

namespace POS__VENTA_ACTIVACIONES_LEYDI.CAPANEGOCIO
{
    partial class FrmProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProducto));
            this.groupBoxi = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.labelProveedor = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.nudCantidadStock = new System.Windows.Forms.NumericUpDown();
            this.nudPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.labelVenta = new System.Windows.Forms.Label();
            this.nudPrecioCompra = new System.Windows.Forms.NumericUpDown();
            this.labelCompra = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.labelCodigoP = new System.Windows.Forms.Label();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.labelBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.txtBuscarPor = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxi
            // 
            this.groupBoxi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBoxi.Controls.Add(this.btnLimpiar);
            this.groupBoxi.Controls.Add(this.btnActualizar);
            this.groupBoxi.Controls.Add(this.btnEliminar);
            this.groupBoxi.Controls.Add(this.btnNuevo);
            this.groupBoxi.Controls.Add(this.btnEditar);
            this.groupBoxi.Controls.Add(this.btnGuardar);
            this.groupBoxi.Controls.Add(this.cmbEstado);
            this.groupBoxi.Controls.Add(this.labelEstado);
            this.groupBoxi.Controls.Add(this.cmbProveedor);
            this.groupBoxi.Controls.Add(this.labelProveedor);
            this.groupBoxi.Controls.Add(this.labelStock);
            this.groupBoxi.Controls.Add(this.nudCantidadStock);
            this.groupBoxi.Controls.Add(this.nudPrecioVenta);
            this.groupBoxi.Controls.Add(this.labelVenta);
            this.groupBoxi.Controls.Add(this.nudPrecioCompra);
            this.groupBoxi.Controls.Add(this.labelCompra);
            this.groupBoxi.Controls.Add(this.txtDescripcion);
            this.groupBoxi.Controls.Add(this.labelDescripcion);
            this.groupBoxi.Controls.Add(this.cmbCategoria);
            this.groupBoxi.Controls.Add(this.labelCategoria);
            this.groupBoxi.Controls.Add(this.txtNombreProducto);
            this.groupBoxi.Controls.Add(this.labelNombre);
            this.groupBoxi.Controls.Add(this.txtCodigoProducto);
            this.groupBoxi.Controls.Add(this.labelCodigoP);
            this.groupBoxi.Location = new System.Drawing.Point(58, 69);
            this.groupBoxi.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxi.Name = "groupBoxi";
            this.groupBoxi.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxi.Size = new System.Drawing.Size(1238, 323);
            this.groupBoxi.TabIndex = 0;
            this.groupBoxi.TabStop = false;
            this.groupBoxi.Text = "INFORMACION DEL PRODUCTO";
            this.groupBoxi.Enter += new System.EventHandler(this.groupBoxi_Enter);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1069, 123);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(123, 40);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnActualizar.Location = new System.Drawing.Point(1069, 225);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(123, 40);
            this.btnActualizar.TabIndex = 22;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminar.Location = new System.Drawing.Point(1069, 276);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(123, 40);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(1069, 21);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(123, 40);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(1069, 74);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(123, 40);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardar.Location = new System.Drawing.Point(1069, 175);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(123, 40);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "DISPONIBLE",
            "AGOTADO",
            "DESCONTINUADO"});
            this.cmbEstado.Location = new System.Drawing.Point(726, 283);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(244, 27);
            this.cmbEstado.TabIndex = 17;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(581, 286);
            this.labelEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(66, 20);
            this.labelEstado.TabIndex = 16;
            this.labelEstado.Text = "ESTADO";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Items.AddRange(new object[] {
            "Distribuidora Central",
            "Importadora Tech",
            "Accesorios Plus"});
            this.cmbProveedor.Location = new System.Drawing.Point(778, 229);
            this.cmbProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(165, 27);
            this.cmbProveedor.TabIndex = 15;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged);
            // 
            // labelProveedor
            // 
            this.labelProveedor.AutoSize = true;
            this.labelProveedor.Location = new System.Drawing.Point(578, 233);
            this.labelProveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProveedor.Name = "labelProveedor";
            this.labelProveedor.Size = new System.Drawing.Size(97, 20);
            this.labelProveedor.TabIndex = 14;
            this.labelProveedor.Text = "PROVEEDOR";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(569, 175);
            this.labelStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(162, 20);
            this.labelStock.TabIndex = 13;
            this.labelStock.Text = "CANTIDAD EN STOCK";
            // 
            // nudCantidadStock
            // 
            this.nudCantidadStock.Location = new System.Drawing.Point(779, 171);
            this.nudCantidadStock.Margin = new System.Windows.Forms.Padding(4);
            this.nudCantidadStock.Name = "nudCantidadStock";
            this.nudCantidadStock.Size = new System.Drawing.Size(165, 27);
            this.nudCantidadStock.TabIndex = 12;
            this.nudCantidadStock.ValueChanged += new System.EventHandler(this.nudCantidadStock_ValueChanged);
            // 
            // nudPrecioVenta
            // 
            this.nudPrecioVenta.Location = new System.Drawing.Point(779, 102);
            this.nudPrecioVenta.Margin = new System.Windows.Forms.Padding(4);
            this.nudPrecioVenta.Name = "nudPrecioVenta";
            this.nudPrecioVenta.Size = new System.Drawing.Size(165, 27);
            this.nudPrecioVenta.TabIndex = 11;
            this.nudPrecioVenta.ValueChanged += new System.EventHandler(this.nudPrecioVenta_ValueChanged);
            // 
            // labelVenta
            // 
            this.labelVenta.AutoSize = true;
            this.labelVenta.Location = new System.Drawing.Point(578, 111);
            this.labelVenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVenta.Name = "labelVenta";
            this.labelVenta.Size = new System.Drawing.Size(137, 20);
            this.labelVenta.TabIndex = 10;
            this.labelVenta.Text = "PRECIO DE VENTA";
            // 
            // nudPrecioCompra
            // 
            this.nudPrecioCompra.Location = new System.Drawing.Point(779, 40);
            this.nudPrecioCompra.Margin = new System.Windows.Forms.Padding(4);
            this.nudPrecioCompra.Name = "nudPrecioCompra";
            this.nudPrecioCompra.Size = new System.Drawing.Size(165, 27);
            this.nudPrecioCompra.TabIndex = 9;
            this.nudPrecioCompra.ValueChanged += new System.EventHandler(this.nudPrecioCompra_ValueChanged);
            // 
            // labelCompra
            // 
            this.labelCompra.AutoSize = true;
            this.labelCompra.Location = new System.Drawing.Point(578, 46);
            this.labelCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompra.Name = "labelCompra";
            this.labelCompra.Size = new System.Drawing.Size(152, 20);
            this.labelCompra.TabIndex = 8;
            this.labelCompra.Text = "PRECIO DE COMPRA";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(135, 233);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(303, 33);
            this.txtDescripcion.TabIndex = 7;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(8, 242);
            this.labelDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(106, 20);
            this.labelDescripcion.TabIndex = 6;
            this.labelDescripcion.Text = "DESCRIPCION";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Accesorios",
            "Recargas",
            "Telefonos",
            "Respuestos",
            "Servicios"});
            this.cmbCategoria.Location = new System.Drawing.Point(135, 171);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(314, 27);
            this.cmbCategoria.TabIndex = 5;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Location = new System.Drawing.Point(8, 171);
            this.labelCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(93, 20);
            this.labelCategoria.TabIndex = 4;
            this.labelCategoria.Text = "CATEGORIA";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(248, 102);
            this.txtNombreProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(200, 27);
            this.txtNombreProducto.TabIndex = 3;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(8, 111);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(189, 20);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "NOMBRE DEL PRODUCTO";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(248, 42);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(191, 27);
            this.txtCodigoProducto.TabIndex = 1;
            // 
            // labelCodigoP
            // 
            this.labelCodigoP.AutoSize = true;
            this.labelCodigoP.Location = new System.Drawing.Point(8, 46);
            this.labelCodigoP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCodigoP.Name = "labelCodigoP";
            this.labelCodigoP.Size = new System.Drawing.Size(182, 20);
            this.labelCodigoP.TabIndex = 0;
            this.labelCodigoP.Text = "CODIGO DEL PRODUCTO";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(58, 556);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(186, 34);
            this.btnCargarImagen.TabIndex = 2;
            this.btnCargarImagen.Text = "CARGAR IMAGEN";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // labelBuscar
            // 
            this.labelBuscar.AutoSize = true;
            this.labelBuscar.Location = new System.Drawing.Point(120, 431);
            this.labelBuscar.Name = "labelBuscar";
            this.labelBuscar.Size = new System.Drawing.Size(72, 20);
            this.labelBuscar.TabIndex = 23;
            this.labelBuscar.Text = "BUSCAR:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(224, 428);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(479, 27);
            this.txtBuscar.TabIndex = 24;
            // 
            // txtBuscarPor
            // 
            this.txtBuscarPor.Location = new System.Drawing.Point(1381, 470);
            this.txtBuscarPor.Name = "txtBuscarPor";
            this.txtBuscarPor.Size = new System.Drawing.Size(122, 27);
            this.txtBuscarPor.TabIndex = 26;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(733, 428);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(126, 40);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(270, 474);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(707, 164);
            this.dgvProductos.TabIndex = 31;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "GESTION DE PRODUCTOS -TIENDA ACTIVACIONES LEYDI";
            // 
            // FrmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 646);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscarPor);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.labelBuscar);
            this.Controls.Add(this.groupBoxi);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProductos";
            this.Load += new System.EventHandler(this.FrmProducto_Load);
            this.groupBoxi.ResumeLayout(false);
            this.groupBoxi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void nudPrecioCompra_ValueChanged(object sender, EventArgs e)
        {
            // Delegar a la implementación existente
            NudPrecioCompra_ValueChanged(sender, e);
        }
            
        #endregion

        private System.Windows.Forms.GroupBox groupBoxi;
        private System.Windows.Forms.Label labelCodigoP;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelCompra;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Label labelVenta;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label labelBuscar;
        private System.Windows.Forms.TextBox txtBuscarPor;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCantidadStock;
        private System.Windows.Forms.NumericUpDown nudPrecioVenta;
        private System.Windows.Forms.NumericUpDown nudPrecioCompra;
    }
}