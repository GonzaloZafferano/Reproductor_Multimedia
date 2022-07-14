
namespace Reproductor_Multimedia
{
    partial class FrmListas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListas));
            this.dtgvListas = new System.Windows.Forms.DataGridView();
            this.btnAgregarContenidoEnLista = new System.Windows.Forms.Button();
            this.dtgvContenidosDeLista = new System.Windows.Forms.DataGridView();
            this.btnCrearNuevaLista = new System.Windows.Forms.Button();
            this.lblContenidoAAgregrar = new System.Windows.Forms.Label();
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados = new System.Windows.Forms.Button();
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado = new System.Windows.Forms.Button();
            this.btnCargarListaParaReproducir = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada = new System.Windows.Forms.Label();
            this.btnRenombrarLista = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvContenidosDeLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvListas
            // 
            this.dtgvListas.AllowUserToAddRows = false;
            this.dtgvListas.AllowUserToDeleteRows = false;
            this.dtgvListas.AllowUserToResizeColumns = false;
            this.dtgvListas.AllowUserToResizeRows = false;
            this.dtgvListas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvListas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgvListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListas.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvListas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvListas.Location = new System.Drawing.Point(9, 51);
            this.dtgvListas.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvListas.MultiSelect = false;
            this.dtgvListas.Name = "dtgvListas";
            this.dtgvListas.ReadOnly = true;
            this.dtgvListas.RowHeadersVisible = false;
            this.dtgvListas.RowHeadersWidth = 51;
            this.dtgvListas.RowTemplate.Height = 24;
            this.dtgvListas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgvListas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvListas.Size = new System.Drawing.Size(574, 162);
            this.dtgvListas.TabIndex = 0;
            this.dtgvListas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvListas_CellClick);
            // 
            // btnAgregarContenidoEnLista
            // 
            this.btnAgregarContenidoEnLista.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarContenidoEnLista.Location = new System.Drawing.Point(436, 222);
            this.btnAgregarContenidoEnLista.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarContenidoEnLista.Name = "btnAgregarContenidoEnLista";
            this.btnAgregarContenidoEnLista.Size = new System.Drawing.Size(146, 63);
            this.btnAgregarContenidoEnLista.TabIndex = 2;
            this.btnAgregarContenidoEnLista.Text = "Agregar en Lista seleccionada";
            this.btnAgregarContenidoEnLista.UseVisualStyleBackColor = true;
            this.btnAgregarContenidoEnLista.Click += new System.EventHandler(this.btnAgregarContenidoEnLista_Click);
            // 
            // dtgvContenidosDeLista
            // 
            this.dtgvContenidosDeLista.AllowUserToAddRows = false;
            this.dtgvContenidosDeLista.AllowUserToDeleteRows = false;
            this.dtgvContenidosDeLista.AllowUserToResizeColumns = false;
            this.dtgvContenidosDeLista.AllowUserToResizeRows = false;
            this.dtgvContenidosDeLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvContenidosDeLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgvContenidosDeLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvContenidosDeLista.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvContenidosDeLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvContenidosDeLista.Location = new System.Drawing.Point(9, 332);
            this.dtgvContenidosDeLista.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvContenidosDeLista.MultiSelect = false;
            this.dtgvContenidosDeLista.Name = "dtgvContenidosDeLista";
            this.dtgvContenidosDeLista.ReadOnly = true;
            this.dtgvContenidosDeLista.RowHeadersVisible = false;
            this.dtgvContenidosDeLista.RowHeadersWidth = 51;
            this.dtgvContenidosDeLista.RowTemplate.Height = 24;
            this.dtgvContenidosDeLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvContenidosDeLista.Size = new System.Drawing.Size(574, 249);
            this.dtgvContenidosDeLista.TabIndex = 3;
            this.dtgvContenidosDeLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvContenidosDeLista_CellClick);
            // 
            // btnCrearNuevaLista
            // 
            this.btnCrearNuevaLista.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearNuevaLista.Location = new System.Drawing.Point(151, 221);
            this.btnCrearNuevaLista.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrearNuevaLista.Name = "btnCrearNuevaLista";
            this.btnCrearNuevaLista.Size = new System.Drawing.Size(127, 63);
            this.btnCrearNuevaLista.TabIndex = 4;
            this.btnCrearNuevaLista.Text = "Crear Lista";
            this.btnCrearNuevaLista.UseVisualStyleBackColor = true;
            this.btnCrearNuevaLista.Click += new System.EventHandler(this.btnCrearNuevaLista_Click);
            // 
            // lblContenidoAAgregrar
            // 
            this.lblContenidoAAgregrar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenidoAAgregrar.Location = new System.Drawing.Point(9, 7);
            this.lblContenidoAAgregrar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContenidoAAgregrar.Name = "lblContenidoAAgregrar";
            this.lblContenidoAAgregrar.Size = new System.Drawing.Size(574, 41);
            this.lblContenidoAAgregrar.TabIndex = 5;
            this.lblContenidoAAgregrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados
            // 
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.Location = new System.Drawing.Point(9, 222);
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.Margin = new System.Windows.Forms.Padding(2);
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.Name = "btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados";
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.Size = new System.Drawing.Size(127, 63);
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.TabIndex = 7;
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.Text = "Borrar todas las Listas";
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.UseVisualStyleBackColor = true;
            this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados.Click += new System.EventHandler(this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados_Click);
            // 
            // btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado
            // 
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.Location = new System.Drawing.Point(442, 587);
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.Margin = new System.Windows.Forms.Padding(2);
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.Name = "btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado";
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.Size = new System.Drawing.Size(140, 35);
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.TabIndex = 8;
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.Text = "Vaciar Lista";
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.UseVisualStyleBackColor = true;
            this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado.Click += new System.EventHandler(this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado_Click);
            // 
            // btnCargarListaParaReproducir
            // 
            this.btnCargarListaParaReproducir.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarListaParaReproducir.Location = new System.Drawing.Point(442, 222);
            this.btnCargarListaParaReproducir.Margin = new System.Windows.Forms.Padding(2);
            this.btnCargarListaParaReproducir.Name = "btnCargarListaParaReproducir";
            this.btnCargarListaParaReproducir.Size = new System.Drawing.Size(139, 63);
            this.btnCargarListaParaReproducir.TabIndex = 9;
            this.btnCargarListaParaReproducir.Text = "Cargar Lista";
            this.btnCargarListaParaReproducir.UseVisualStyleBackColor = true;
            this.btnCargarListaParaReproducir.Click += new System.EventHandler(this.btnCargarListaParaReproducir_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(9, 585);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(103, 38);
            this.btnAtras.TabIndex = 10;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblArchivosMultimediaDentroDeLaListaPersonalizada
            // 
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Location = new System.Drawing.Point(9, 295);
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Name = "lblArchivosMultimediaDentroDeLaListaPersonalizada";
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Size = new System.Drawing.Size(574, 34);
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.TabIndex = 12;
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Text = "Sin archivos multimedia para mostrar";
            this.lblArchivosMultimediaDentroDeLaListaPersonalizada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRenombrarLista
            // 
            this.btnRenombrarLista.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenombrarLista.Location = new System.Drawing.Point(296, 221);
            this.btnRenombrarLista.Margin = new System.Windows.Forms.Padding(2);
            this.btnRenombrarLista.Name = "btnRenombrarLista";
            this.btnRenombrarLista.Size = new System.Drawing.Size(127, 63);
            this.btnRenombrarLista.TabIndex = 13;
            this.btnRenombrarLista.Text = "Renombrar";
            this.btnRenombrarLista.UseVisualStyleBackColor = true;
            this.btnRenombrarLista.Click += new System.EventHandler(this.btnRenombrarLista_Click);
            // 
            // FrmListas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 633);
            this.Controls.Add(this.btnRenombrarLista);
            this.Controls.Add(this.lblArchivosMultimediaDentroDeLaListaPersonalizada);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnCargarListaParaReproducir);
            this.Controls.Add(this.btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado);
            this.Controls.Add(this.btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados);
            this.Controls.Add(this.lblContenidoAAgregrar);
            this.Controls.Add(this.btnCrearNuevaLista);
            this.Controls.Add(this.dtgvContenidosDeLista);
            this.Controls.Add(this.btnAgregarContenidoEnLista);
            this.Controls.Add(this.dtgvListas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmListas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mis Listas";
            this.Load += new System.EventHandler(this.FrmListas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvContenidosDeLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvListas;
        private System.Windows.Forms.Button btnAgregarContenidoEnLista;
        private System.Windows.Forms.DataGridView dtgvContenidosDeLista;
        private System.Windows.Forms.Button btnCrearNuevaLista;
        private System.Windows.Forms.Label lblContenidoAAgregrar;
        private System.Windows.Forms.Button btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados;
        private System.Windows.Forms.Button btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado;
        private System.Windows.Forms.Button btnCargarListaParaReproducir;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblArchivosMultimediaDentroDeLaListaPersonalizada;
        private System.Windows.Forms.Button btnRenombrarLista;
    }
}