
namespace Reproductor_Multimedia
{
    partial class FrmReproductorMultimedia
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReproductorMultimedia));
            this.btnImportarContenido = new System.Windows.Forms.Button();
            this.dtgvListaMultimedia = new System.Windows.Forms.DataGridView();
            this.btnLimpiarLista = new System.Windows.Forms.Button();
            this.lblContenidoActual = new System.Windows.Forms.Label();
            this.lblReproduccionActual = new System.Windows.Forms.Label();
            this.lblReproduccionFaltante = new System.Windows.Forms.Label();
            this.btnAgregarALista = new System.Windows.Forms.Button();
            this.btnMostrarListas = new System.Windows.Forms.Button();
            this.reproductorMultimedia = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnTemaVerde = new System.Windows.Forms.Button();
            this.btnTemaRojo = new System.Windows.Forms.Button();
            this.btnTemaAzul = new System.Windows.Forms.Button();
            this.barraDeReproduccionDeContenido = new XComponent.SliderBar.MACTrackBar();
            this.barraDeVolumen = new XComponent.SliderBar.MACTrackBar();
            this.cBoxSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnQuitarFiltro = new System.Windows.Forms.Button();
            this.btnPantallaCompleta = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.PictureBox();
            this.btnMute = new System.Windows.Forms.PictureBox();
            this.btnComenzarAutomaticamenteProximoContenido = new System.Windows.Forms.Button();
            this.btnOrdenAleatorio = new System.Windows.Forms.Button();
            this.btnRetrasar = new System.Windows.Forms.Button();
            this.btnAdelantar = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.lblVolumen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListaMultimedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reproductorMultimedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMute)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarContenido
            // 
            this.btnImportarContenido.BackColor = System.Drawing.Color.Transparent;
            this.btnImportarContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportarContenido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportarContenido.FlatAppearance.BorderSize = 0;
            this.btnImportarContenido.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnImportarContenido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnImportarContenido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnImportarContenido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportarContenido.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarContenido.Location = new System.Drawing.Point(706, 560);
            this.btnImportarContenido.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportarContenido.Name = "btnImportarContenido";
            this.btnImportarContenido.Size = new System.Drawing.Size(109, 44);
            this.btnImportarContenido.TabIndex = 1;
            this.btnImportarContenido.TabStop = false;
            this.btnImportarContenido.Text = "Importar";
            this.btnImportarContenido.UseVisualStyleBackColor = false;
            this.btnImportarContenido.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // dtgvListaMultimedia
            // 
            this.dtgvListaMultimedia.AllowUserToAddRows = false;
            this.dtgvListaMultimedia.AllowUserToDeleteRows = false;
            this.dtgvListaMultimedia.AllowUserToResizeColumns = false;
            this.dtgvListaMultimedia.AllowUserToResizeRows = false;
            this.dtgvListaMultimedia.BackgroundColor = System.Drawing.Color.White;
            this.dtgvListaMultimedia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvListaMultimedia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgvListaMultimedia.ColumnHeadersHeight = 29;
            this.dtgvListaMultimedia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgvListaMultimedia.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvListaMultimedia.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvListaMultimedia.GridColor = System.Drawing.Color.White;
            this.dtgvListaMultimedia.Location = new System.Drawing.Point(12, 560);
            this.dtgvListaMultimedia.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvListaMultimedia.MultiSelect = false;
            this.dtgvListaMultimedia.Name = "dtgvListaMultimedia";
            this.dtgvListaMultimedia.ReadOnly = true;
            this.dtgvListaMultimedia.RowHeadersVisible = false;
            this.dtgvListaMultimedia.RowHeadersWidth = 51;
            this.dtgvListaMultimedia.RowTemplate.Height = 24;
            this.dtgvListaMultimedia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgvListaMultimedia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvListaMultimedia.Size = new System.Drawing.Size(662, 194);
            this.dtgvListaMultimedia.TabIndex = 2;
            this.dtgvListaMultimedia.TabStop = false;
            this.dtgvListaMultimedia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListaMultimedia_CellClick);
            this.dtgvListaMultimedia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListaMultimedia_CellContentClick);
            this.dtgvListaMultimedia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListaMultimedia_CellDoubleClick);
            // 
            // btnLimpiarLista
            // 
            this.btnLimpiarLista.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarLista.FlatAppearance.BorderSize = 0;
            this.btnLimpiarLista.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLimpiarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarLista.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarLista.Location = new System.Drawing.Point(706, 618);
            this.btnLimpiarLista.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarLista.Name = "btnLimpiarLista";
            this.btnLimpiarLista.Size = new System.Drawing.Size(109, 44);
            this.btnLimpiarLista.TabIndex = 3;
            this.btnLimpiarLista.TabStop = false;
            this.btnLimpiarLista.Text = "Limpiar";
            this.btnLimpiarLista.UseVisualStyleBackColor = false;
            this.btnLimpiarLista.Click += new System.EventHandler(this.btnLimpiarLista_Click);
            // 
            // lblContenidoActual
            // 
            this.lblContenidoActual.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenidoActual.Location = new System.Drawing.Point(136, 384);
            this.lblContenidoActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContenidoActual.Name = "lblContenidoActual";
            this.lblContenidoActual.Size = new System.Drawing.Size(552, 39);
            this.lblContenidoActual.TabIndex = 4;
            this.lblContenidoActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContenidoActual.TextChanged += new System.EventHandler(this.lblContenidoActual_TextChanged);
            // 
            // lblReproduccionActual
            // 
            this.lblReproduccionActual.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReproduccionActual.Location = new System.Drawing.Point(9, 385);
            this.lblReproduccionActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReproduccionActual.Name = "lblReproduccionActual";
            this.lblReproduccionActual.Size = new System.Drawing.Size(123, 37);
            this.lblReproduccionActual.TabIndex = 5;
            this.lblReproduccionActual.Text = "-";
            this.lblReproduccionActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReproduccionFaltante
            // 
            this.lblReproduccionFaltante.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReproduccionFaltante.Location = new System.Drawing.Point(693, 385);
            this.lblReproduccionFaltante.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReproduccionFaltante.Name = "lblReproduccionFaltante";
            this.lblReproduccionFaltante.Size = new System.Drawing.Size(122, 37);
            this.lblReproduccionFaltante.TabIndex = 6;
            this.lblReproduccionFaltante.Text = "-";
            this.lblReproduccionFaltante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAgregarALista
            // 
            this.btnAgregarALista.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarALista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarALista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarALista.FlatAppearance.BorderSize = 0;
            this.btnAgregarALista.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarALista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarALista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarALista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarALista.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarALista.Location = new System.Drawing.Point(706, 728);
            this.btnAgregarALista.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarALista.Name = "btnAgregarALista";
            this.btnAgregarALista.Size = new System.Drawing.Size(109, 58);
            this.btnAgregarALista.TabIndex = 12;
            this.btnAgregarALista.TabStop = false;
            this.btnAgregarALista.Text = "Agregar a Listas";
            this.btnAgregarALista.UseVisualStyleBackColor = false;
            this.btnAgregarALista.Click += new System.EventHandler(this.btnAgregarALista_Click);
            // 
            // btnMostrarListas
            // 
            this.btnMostrarListas.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarListas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMostrarListas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarListas.FlatAppearance.BorderSize = 0;
            this.btnMostrarListas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMostrarListas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMostrarListas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMostrarListas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarListas.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarListas.Location = new System.Drawing.Point(706, 675);
            this.btnMostrarListas.Margin = new System.Windows.Forms.Padding(2);
            this.btnMostrarListas.Name = "btnMostrarListas";
            this.btnMostrarListas.Size = new System.Drawing.Size(109, 39);
            this.btnMostrarListas.TabIndex = 13;
            this.btnMostrarListas.TabStop = false;
            this.btnMostrarListas.Text = "Listas";
            this.btnMostrarListas.UseVisualStyleBackColor = false;
            this.btnMostrarListas.Click += new System.EventHandler(this.btnMostrarListas_Click);
            // 
            // reproductorMultimedia
            // 
            this.reproductorMultimedia.Enabled = true;
            this.reproductorMultimedia.Location = new System.Drawing.Point(19, 19);
            this.reproductorMultimedia.Margin = new System.Windows.Forms.Padding(2);
            this.reproductorMultimedia.Name = "reproductorMultimedia";
            this.reproductorMultimedia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("reproductorMultimedia.OcxState")));
            this.reproductorMultimedia.Size = new System.Drawing.Size(797, 306);
            this.reproductorMultimedia.TabIndex = 22;
            this.reproductorMultimedia.TabStop = false;
            this.reproductorMultimedia.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.reproductor_PlayStateChange);
            // 
            // btnTemaVerde
            // 
            this.btnTemaVerde.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTemaVerde.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemaVerde.FlatAppearance.BorderSize = 0;
            this.btnTemaVerde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemaVerde.Location = new System.Drawing.Point(784, 440);
            this.btnTemaVerde.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemaVerde.Name = "btnTemaVerde";
            this.btnTemaVerde.Size = new System.Drawing.Size(32, 32);
            this.btnTemaVerde.TabIndex = 25;
            this.btnTemaVerde.TabStop = false;
            this.btnTemaVerde.UseVisualStyleBackColor = false;
            this.btnTemaVerde.Click += new System.EventHandler(this.CambiarTema_Click);
            // 
            // btnTemaRojo
            // 
            this.btnTemaRojo.BackColor = System.Drawing.Color.IndianRed;
            this.btnTemaRojo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemaRojo.FlatAppearance.BorderSize = 0;
            this.btnTemaRojo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemaRojo.Location = new System.Drawing.Point(784, 477);
            this.btnTemaRojo.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemaRojo.Name = "btnTemaRojo";
            this.btnTemaRojo.Size = new System.Drawing.Size(32, 32);
            this.btnTemaRojo.TabIndex = 26;
            this.btnTemaRojo.TabStop = false;
            this.btnTemaRojo.UseVisualStyleBackColor = false;
            this.btnTemaRojo.Click += new System.EventHandler(this.CambiarTema_Click);
            // 
            // btnTemaAzul
            // 
            this.btnTemaAzul.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTemaAzul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemaAzul.FlatAppearance.BorderSize = 0;
            this.btnTemaAzul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemaAzul.Location = new System.Drawing.Point(784, 514);
            this.btnTemaAzul.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemaAzul.Name = "btnTemaAzul";
            this.btnTemaAzul.Size = new System.Drawing.Size(32, 32);
            this.btnTemaAzul.TabIndex = 27;
            this.btnTemaAzul.TabStop = false;
            this.btnTemaAzul.UseVisualStyleBackColor = false;
            this.btnTemaAzul.Click += new System.EventHandler(this.CambiarTema_Click);
            // 
            // barraDeReproduccionDeContenido
            // 
            this.barraDeReproduccionDeContenido.BackColor = System.Drawing.Color.Transparent;
            this.barraDeReproduccionDeContenido.BorderColor = System.Drawing.Color.Transparent;
            this.barraDeReproduccionDeContenido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.barraDeReproduccionDeContenido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraDeReproduccionDeContenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.barraDeReproduccionDeContenido.IndentHeight = 6;
            this.barraDeReproduccionDeContenido.Location = new System.Drawing.Point(9, 442);
            this.barraDeReproduccionDeContenido.Margin = new System.Windows.Forms.Padding(2);
            this.barraDeReproduccionDeContenido.Maximum = 10;
            this.barraDeReproduccionDeContenido.Minimum = 0;
            this.barraDeReproduccionDeContenido.Name = "barraDeReproduccionDeContenido";
            this.barraDeReproduccionDeContenido.Size = new System.Drawing.Size(664, 28);
            this.barraDeReproduccionDeContenido.TabIndex = 29;
            this.barraDeReproduccionDeContenido.TabStop = false;
            this.barraDeReproduccionDeContenido.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.barraDeReproduccionDeContenido.TickColor = System.Drawing.Color.Transparent;
            this.barraDeReproduccionDeContenido.TickHeight = 4;
            this.barraDeReproduccionDeContenido.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barraDeReproduccionDeContenido.TrackerColor = System.Drawing.Color.Firebrick;
            this.barraDeReproduccionDeContenido.TrackerSize = new System.Drawing.Size(16, 16);
            this.barraDeReproduccionDeContenido.TrackLineColor = System.Drawing.Color.IndianRed;
            this.barraDeReproduccionDeContenido.TrackLineHeight = 5;
            this.barraDeReproduccionDeContenido.TrackLineSelectedColor = System.Drawing.Color.LawnGreen;
            this.barraDeReproduccionDeContenido.Value = 0;
            this.barraDeReproduccionDeContenido.Scroll += new System.EventHandler(this.barraReproduccionContenido_Scroll);
            // 
            // barraDeVolumen
            // 
            this.barraDeVolumen.BackColor = System.Drawing.Color.Transparent;
            this.barraDeVolumen.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.barraDeVolumen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.barraDeVolumen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraDeVolumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.barraDeVolumen.IndentHeight = 6;
            this.barraDeVolumen.Location = new System.Drawing.Point(697, 431);
            this.barraDeVolumen.Margin = new System.Windows.Forms.Padding(2);
            this.barraDeVolumen.Maximum = 10;
            this.barraDeVolumen.Minimum = 0;
            this.barraDeVolumen.Name = "barraDeVolumen";
            this.barraDeVolumen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.barraDeVolumen.Size = new System.Drawing.Size(28, 115);
            this.barraDeVolumen.TabIndex = 30;
            this.barraDeVolumen.TabStop = false;
            this.barraDeVolumen.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.barraDeVolumen.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.barraDeVolumen.TickHeight = 4;
            this.barraDeVolumen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barraDeVolumen.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.barraDeVolumen.TrackerSize = new System.Drawing.Size(16, 16);
            this.barraDeVolumen.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.barraDeVolumen.TrackLineHeight = 5;
            this.barraDeVolumen.TrackLineSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.barraDeVolumen.Value = 0;
            this.barraDeVolumen.Scroll += new System.EventHandler(this.barraDeVolumen_Scroll);
            // 
            // cBoxSeleccionarTodo
            // 
            this.cBoxSeleccionarTodo.AutoSize = true;
            this.cBoxSeleccionarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cBoxSeleccionarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBoxSeleccionarTodo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxSeleccionarTodo.Location = new System.Drawing.Point(516, 763);
            this.cBoxSeleccionarTodo.Name = "cBoxSeleccionarTodo";
            this.cBoxSeleccionarTodo.Size = new System.Drawing.Size(158, 23);
            this.cBoxSeleccionarTodo.TabIndex = 32;
            this.cBoxSeleccionarTodo.Text = "Seleccionar Todo";
            this.cBoxSeleccionarTodo.UseVisualStyleBackColor = true;
            this.cBoxSeleccionarTodo.CheckedChanged += new System.EventHandler(this.cBoxSeleccionarTodo_CheckedChanged);
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(40, 761);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(422, 26);
            this.txtBuscador.TabIndex = 33;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::Reproductor_Multimedia.Properties.Resources.Lupa0;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(468, 759);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 28);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitarFiltro.BackgroundImage = global::Reproductor_Multimedia.Properties.Resources.X0;
            this.btnQuitarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFiltro.FlatAppearance.BorderSize = 0;
            this.btnQuitarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFiltro.Location = new System.Drawing.Point(12, 763);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(22, 22);
            this.btnQuitarFiltro.TabIndex = 35;
            this.btnQuitarFiltro.UseVisualStyleBackColor = false;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.btnQuitarFiltro_Click);
            // 
            // btnPantallaCompleta
            // 
            this.btnPantallaCompleta.BackColor = System.Drawing.Color.Transparent;
            this.btnPantallaCompleta.BackgroundImage = global::Reproductor_Multimedia.Properties.Resources.FullScreen0;
            this.btnPantallaCompleta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPantallaCompleta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPantallaCompleta.FlatAppearance.BorderSize = 0;
            this.btnPantallaCompleta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPantallaCompleta.ForeColor = System.Drawing.Color.White;
            this.btnPantallaCompleta.Location = new System.Drawing.Point(406, 490);
            this.btnPantallaCompleta.Margin = new System.Windows.Forms.Padding(2);
            this.btnPantallaCompleta.Name = "btnPantallaCompleta";
            this.btnPantallaCompleta.Size = new System.Drawing.Size(56, 52);
            this.btnPantallaCompleta.TabIndex = 31;
            this.btnPantallaCompleta.UseVisualStyleBackColor = false;
            this.btnPantallaCompleta.Click += new System.EventHandler(this.btnPantallaCompleta_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.BackColor = System.Drawing.Color.White;
            this.btnPlayPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayPause.Image")));
            this.btnPlayPause.Location = new System.Drawing.Point(271, 490);
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(56, 52);
            this.btnPlayPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPlayPause.TabIndex = 24;
            this.btnPlayPause.TabStop = false;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.White;
            this.btnMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMute.Image = global::Reproductor_Multimedia.Properties.Resources.Mute1;
            this.btnMute.InitialImage = null;
            this.btnMute.Location = new System.Drawing.Point(617, 490);
            this.btnMute.Margin = new System.Windows.Forms.Padding(2);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(56, 52);
            this.btnMute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMute.TabIndex = 23;
            this.btnMute.TabStop = false;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnComenzarAutomaticamenteProximoContenido
            // 
            this.btnComenzarAutomaticamenteProximoContenido.BackColor = System.Drawing.Color.Transparent;
            this.btnComenzarAutomaticamenteProximoContenido.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnComenzarAutomaticamenteProximoContenido.BackgroundImage")));
            this.btnComenzarAutomaticamenteProximoContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnComenzarAutomaticamenteProximoContenido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.BorderSize = 0;
            this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnComenzarAutomaticamenteProximoContenido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComenzarAutomaticamenteProximoContenido.Location = new System.Drawing.Point(76, 490);
            this.btnComenzarAutomaticamenteProximoContenido.Margin = new System.Windows.Forms.Padding(2);
            this.btnComenzarAutomaticamenteProximoContenido.Name = "btnComenzarAutomaticamenteProximoContenido";
            this.btnComenzarAutomaticamenteProximoContenido.Size = new System.Drawing.Size(56, 52);
            this.btnComenzarAutomaticamenteProximoContenido.TabIndex = 20;
            this.btnComenzarAutomaticamenteProximoContenido.TabStop = false;
            this.btnComenzarAutomaticamenteProximoContenido.UseVisualStyleBackColor = false;
            this.btnComenzarAutomaticamenteProximoContenido.Click += new System.EventHandler(this.btnComenzarAutomaticamenteProximoContenido_Click);
            // 
            // btnOrdenAleatorio
            // 
            this.btnOrdenAleatorio.BackColor = System.Drawing.Color.Transparent;
            this.btnOrdenAleatorio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOrdenAleatorio.BackgroundImage")));
            this.btnOrdenAleatorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrdenAleatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenAleatorio.FlatAppearance.BorderSize = 0;
            this.btnOrdenAleatorio.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOrdenAleatorio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOrdenAleatorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOrdenAleatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenAleatorio.Location = new System.Drawing.Point(12, 490);
            this.btnOrdenAleatorio.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrdenAleatorio.Name = "btnOrdenAleatorio";
            this.btnOrdenAleatorio.Size = new System.Drawing.Size(56, 52);
            this.btnOrdenAleatorio.TabIndex = 19;
            this.btnOrdenAleatorio.TabStop = false;
            this.btnOrdenAleatorio.UseVisualStyleBackColor = false;
            this.btnOrdenAleatorio.Click += new System.EventHandler(this.btnOrdenAleatorio_Click);
            // 
            // btnRetrasar
            // 
            this.btnRetrasar.BackColor = System.Drawing.Color.Transparent;
            this.btnRetrasar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRetrasar.BackgroundImage")));
            this.btnRetrasar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRetrasar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetrasar.FlatAppearance.BorderSize = 0;
            this.btnRetrasar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRetrasar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRetrasar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRetrasar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetrasar.Location = new System.Drawing.Point(485, 490);
            this.btnRetrasar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRetrasar.Name = "btnRetrasar";
            this.btnRetrasar.Size = new System.Drawing.Size(56, 52);
            this.btnRetrasar.TabIndex = 18;
            this.btnRetrasar.TabStop = false;
            this.btnRetrasar.UseVisualStyleBackColor = false;
            this.btnRetrasar.Click += new System.EventHandler(this.btnRetrasar_Click);
            // 
            // btnAdelantar
            // 
            this.btnAdelantar.BackColor = System.Drawing.Color.Transparent;
            this.btnAdelantar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdelantar.BackgroundImage")));
            this.btnAdelantar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdelantar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdelantar.FlatAppearance.BorderSize = 0;
            this.btnAdelantar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAdelantar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdelantar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdelantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdelantar.Location = new System.Drawing.Point(546, 490);
            this.btnAdelantar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdelantar.Name = "btnAdelantar";
            this.btnAdelantar.Size = new System.Drawing.Size(56, 52);
            this.btnAdelantar.TabIndex = 17;
            this.btnAdelantar.TabStop = false;
            this.btnAdelantar.UseVisualStyleBackColor = false;
            this.btnAdelantar.Click += new System.EventHandler(this.btnAdelantar_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(211, 490);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 52);
            this.btnStop.TabIndex = 11;
            this.btnStop.TabStop = false;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.BackgroundImage")));
            this.btnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Location = new System.Drawing.Point(331, 490);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(56, 52);
            this.btnSiguiente.TabIndex = 10;
            this.btnSiguiente.TabStop = false;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.Transparent;
            this.btnAnterior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnterior.BackgroundImage")));
            this.btnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Location = new System.Drawing.Point(151, 490);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(56, 52);
            this.btnAnterior.TabIndex = 9;
            this.btnAnterior.TabStop = false;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // lblVolumen
            // 
            this.lblVolumen.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumen.Location = new System.Drawing.Point(730, 516);
            this.lblVolumen.Name = "lblVolumen";
            this.lblVolumen.Size = new System.Drawing.Size(38, 30);
            this.lblVolumen.TabIndex = 36;
            this.lblVolumen.Text = "0";
            this.lblVolumen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmReproductorMultimedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 838);
            this.Controls.Add(this.lblVolumen);
            this.Controls.Add(this.btnQuitarFiltro);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.cBoxSeleccionarTodo);
            this.Controls.Add(this.btnPantallaCompleta);
            this.Controls.Add(this.barraDeVolumen);
            this.Controls.Add(this.barraDeReproduccionDeContenido);
            this.Controls.Add(this.btnTemaAzul);
            this.Controls.Add(this.btnTemaRojo);
            this.Controls.Add(this.btnTemaVerde);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.reproductorMultimedia);
            this.Controls.Add(this.btnComenzarAutomaticamenteProximoContenido);
            this.Controls.Add(this.btnOrdenAleatorio);
            this.Controls.Add(this.btnRetrasar);
            this.Controls.Add(this.btnAdelantar);
            this.Controls.Add(this.btnMostrarListas);
            this.Controls.Add(this.btnAgregarALista);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.lblReproduccionFaltante);
            this.Controls.Add(this.lblReproduccionActual);
            this.Controls.Add(this.lblContenidoActual);
            this.Controls.Add(this.btnLimpiarLista);
            this.Controls.Add(this.btnImportarContenido);
            this.Controls.Add(this.dtgvListaMultimedia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmReproductorMultimedia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reproductor Multimedia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReproductorMultimedia_FormClosing);
            this.Load += new System.EventHandler(this.ReproductorMultimedia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListaMultimedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reproductorMultimedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImportarContenido;
        private System.Windows.Forms.DataGridView dtgvListaMultimedia;
        private System.Windows.Forms.Button btnLimpiarLista;
        private System.Windows.Forms.Label lblContenidoActual;
        private System.Windows.Forms.Label lblReproduccionActual;
        private System.Windows.Forms.Label lblReproduccionFaltante;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnAgregarALista;
        private System.Windows.Forms.Button btnMostrarListas;
        private System.Windows.Forms.Button btnAdelantar;
        private System.Windows.Forms.Button btnRetrasar;
        private System.Windows.Forms.Button btnOrdenAleatorio;
        private System.Windows.Forms.Button btnComenzarAutomaticamenteProximoContenido;
        private AxWMPLib.AxWindowsMediaPlayer reproductorMultimedia;
        private System.Windows.Forms.PictureBox btnMute;
        private System.Windows.Forms.PictureBox btnPlayPause;
        private System.Windows.Forms.Button btnTemaVerde;
        private System.Windows.Forms.Button btnTemaRojo;
        private System.Windows.Forms.Button btnTemaAzul;
        private XComponent.SliderBar.MACTrackBar barraDeReproduccionDeContenido;
        private XComponent.SliderBar.MACTrackBar barraDeVolumen;
        private System.Windows.Forms.Button btnPantallaCompleta;
        private System.Windows.Forms.CheckBox cBoxSeleccionarTodo;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnQuitarFiltro;
        private System.Windows.Forms.Label lblVolumen;
    }
}

