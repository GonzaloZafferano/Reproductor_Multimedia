using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Reproductor_Multimedia
{
    public partial class FrmListas : Form
    {
        private List<ContenidoMultimedia> listasMultimediaPersonalizadas;
        private List<Multimedia> archivosMultimedia;
        private ContenidoMultimedia listaMultimediaPersonalizadaSeleccionada;
        private DataGridViewButtonColumn columnaBotonEliminarDeDtgvListas;
        private DataGridViewTextBoxColumn columnaTextoDeDtgvListas;         
        private DataGridViewButtonColumn columnaBotonEliminarDedtgvContenidosDeLista;
        private DataGridViewTextBoxColumn columnaTextoDedtgvContenidosDeLista;
        private int primeraFilaVisibleDeDtgvListas;
        private int indiceFilaSeleccionadaDeDtgvListas;
        private int primeraFilaVisibleDedtgvContenidosDeLista;
        private int indiceFilaSeleccionadaDedtgvContenidosDeLista;

        public ContenidoMultimedia ListaMultimediaPersonalizadaSeleccionada
        {
            get
            {
                return this.listaMultimediaPersonalizadaSeleccionada;
            }
        }

        public FrmListas()
        {
            InitializeComponent();

            this.primeraFilaVisibleDeDtgvListas = 0;
            this.indiceFilaSeleccionadaDeDtgvListas = 0;
            this.primeraFilaVisibleDedtgvContenidosDeLista = 0;
            this.indiceFilaSeleccionadaDedtgvContenidosDeLista = 0;

            this.listasMultimediaPersonalizadas = ContenidoMultimedia.ObtenerArchivosConContenidoMultimediaPersonalizado();
        }

        public FrmListas(List<Multimedia> archivosMultimedia) : this()
        {
            this.archivosMultimedia = archivosMultimedia;
        }

        private void FrmListas_Load(object sender, EventArgs e)
        {
            if(this.archivosMultimedia != null)
            {
                this.lblContenidoAAgregrar.Text = "Seleccione una lista para agregar el contenido:";
                this.btnCargarListaParaReproducir.Visible = false;
            }
            else
            {
                this.lblContenidoAAgregrar.Text = "Listas creadas:";
                this.btnAgregarContenidoEnLista.Visible = false;
            }

            this.CrearColumnasDeDtgvListas();
            this.OrganizarDataGridDeDtgvListas();

            this.CrearColumnasDedtgvContenidosDeLista();

            if (this.listasMultimediaPersonalizadas.Count > 0)
            {
                this.OrganizarDataGridDedtgvContenidosDeLista(this.listasMultimediaPersonalizadas[0]);
                this.listaMultimediaPersonalizadaSeleccionada = this.listasMultimediaPersonalizadas[0];
                this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Text = $"Archivos multimedia dentro de la lista '{this.listasMultimediaPersonalizadas[0].NombreListaMultimedia}'";
            }

            this.AplicarTema();
        }

        /// <summary>
        /// Crea las columnas del DataGrid 'dtgvListas'.
        /// </summary>
        private void CrearColumnasDeDtgvListas()
        {
            this.columnaBotonEliminarDeDtgvListas = new DataGridViewButtonColumn();
            this.columnaBotonEliminarDeDtgvListas.CellTemplate = new DataGridViewButtonCell();
            this.columnaBotonEliminarDeDtgvListas.Name = "eliminar";
            this.columnaBotonEliminarDeDtgvListas.UseColumnTextForButtonValue = true;
            this.columnaBotonEliminarDeDtgvListas.Text = "-";
            this.columnaBotonEliminarDeDtgvListas.Width = 25;
            this.columnaBotonEliminarDeDtgvListas.DisplayIndex = 0;
            this.columnaBotonEliminarDeDtgvListas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.columnaTextoDeDtgvListas = new DataGridViewTextBoxColumn();
            this.columnaTextoDeDtgvListas.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaTextoDeDtgvListas.Name = "nombre";
            this.columnaTextoDeDtgvListas.DataPropertyName = "NombreListaMultimedia";
            this.columnaTextoDeDtgvListas.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.columnaTextoDeDtgvListas.DisplayIndex = 1;
            this.columnaTextoDeDtgvListas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        /// <summary>
        /// Organiza el datagrid 'dtgvListas'.
        /// </summary>
        private void OrganizarDataGridDeDtgvListas()
        {
            this.RefrescarDataSourceDeDtgvListas();

            this.dtgvListas.Columns.Clear();

            this.dtgvListas.Columns.AddRange(this.columnaTextoDeDtgvListas, this.columnaBotonEliminarDeDtgvListas);

            if (this.primeraFilaVisibleDeDtgvListas >= 0 && this.primeraFilaVisibleDeDtgvListas < this.dtgvListas.Rows.Count &&
                this.indiceFilaSeleccionadaDeDtgvListas >= 0 && this.indiceFilaSeleccionadaDeDtgvListas < this.dtgvListas.Rows.Count)
            {
                this.dtgvListas.FirstDisplayedScrollingRowIndex = this.primeraFilaVisibleDeDtgvListas;
                this.dtgvListas.Rows[indiceFilaSeleccionadaDeDtgvListas].Selected = true;
            }
        }

        /// <summary>
        /// Refresca el DataSource del DataGrid 'dtgvListas'.
        /// </summary>
        private void RefrescarDataSourceDeDtgvListas()
        {
            BindingList<ContenidoMultimedia> listasMultimediaPersonalizadas = new BindingList<ContenidoMultimedia>(this.listasMultimediaPersonalizadas);

            this.dtgvListas.DataSource = null;
            this.dtgvListas.DataSource = listasMultimediaPersonalizadas;
        }

        /// <summary>
        /// Crea las columnas del DataGrid 'dtgvContenidosDeLista'.
        /// </summary>
        private void CrearColumnasDedtgvContenidosDeLista()
        {
            this.columnaBotonEliminarDedtgvContenidosDeLista = new DataGridViewButtonColumn();
            this.columnaBotonEliminarDedtgvContenidosDeLista.CellTemplate = new DataGridViewButtonCell();
            this.columnaBotonEliminarDedtgvContenidosDeLista.Name = "eliminar";
            this.columnaBotonEliminarDedtgvContenidosDeLista.UseColumnTextForButtonValue = true;
            this.columnaBotonEliminarDedtgvContenidosDeLista.Text = "-";
            this.columnaBotonEliminarDedtgvContenidosDeLista.Width = 25;
            this.columnaBotonEliminarDedtgvContenidosDeLista.DisplayIndex = 0;

            this.columnaTextoDedtgvContenidosDeLista = new DataGridViewTextBoxColumn();
            this.columnaTextoDedtgvContenidosDeLista.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaTextoDedtgvContenidosDeLista.Name = "nombre";
            this.columnaTextoDedtgvContenidosDeLista.DataPropertyName = "NombreArchivo";
            this.columnaTextoDedtgvContenidosDeLista.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.columnaTextoDedtgvContenidosDeLista.DisplayIndex = 1;
        }

        /// <summary>
        /// Organiza el datagrid 'dtgvContenidosDeLista'.
        /// </summary>
        /// <param name="contenidoMultimedia">Contenido que se utilizara para el DataSource.</param>
        private void OrganizarDataGridDedtgvContenidosDeLista(ContenidoMultimedia contenidoMultimedia)
        {
            this.RefrescarDataSourceDedtgvContenidosDeLista(contenidoMultimedia);

            this.dtgvContenidosDeLista.Columns.Clear();

            this.dtgvContenidosDeLista.Columns.AddRange(this.columnaTextoDedtgvContenidosDeLista, this.columnaBotonEliminarDedtgvContenidosDeLista);

            if (this.primeraFilaVisibleDedtgvContenidosDeLista >= 0 && this.primeraFilaVisibleDedtgvContenidosDeLista < this.dtgvContenidosDeLista.Rows.Count &&
                this.indiceFilaSeleccionadaDedtgvContenidosDeLista >= 0 && this.indiceFilaSeleccionadaDedtgvContenidosDeLista < this.dtgvContenidosDeLista.Rows.Count)
            {
                this.dtgvContenidosDeLista.FirstDisplayedScrollingRowIndex = this.primeraFilaVisibleDedtgvContenidosDeLista;
                this.dtgvContenidosDeLista.Rows[indiceFilaSeleccionadaDedtgvContenidosDeLista].Selected = true;
            }
        }

        /// <summary>
        /// Refresca el DataSource del DataGrid 'dtgvContenidosDeLista'.
        /// </summary>
        private void RefrescarDataSourceDedtgvContenidosDeLista(ContenidoMultimedia contenidoMultimedia)
        {
            this.dtgvContenidosDeLista.DataSource = null;

            if(contenidoMultimedia != null)
            {
                BindingList<Multimedia> archivosMultimedia = new BindingList<Multimedia>(contenidoMultimedia.ArchivosEnListaMultimedia);

                this.dtgvContenidosDeLista.DataSource = archivosMultimedia;

                this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Text = $"Archivos multimedia dentro de la lista '{contenidoMultimedia.NombreListaMultimedia}'";
            }
            else
            {
                this.lblArchivosMultimediaDentroDeLaListaPersonalizada.Text = "Sin archivos multimedia para mostrar";
            }
        }
                
        private void btnCrearNuevaLista_Click(object sender, EventArgs e)
        {
            FrmCrearLista crearLista = new FrmCrearLista();

            if(crearLista.ShowDialog() == DialogResult.OK)
            {
                this.OrganizarDataGridDeDtgvListas();
            }
        }

        private void btnAgregarContenidoEnLista_Click(object sender, EventArgs e)
        {
            if (this.dtgvListas.SelectedRows != null && this.dtgvListas.SelectedRows.Count > 0)
            {
                ContenidoMultimedia contenidoMultimedia = this.dtgvListas.SelectedRows[0].DataBoundItem as ContenidoMultimedia;

                if(contenidoMultimedia != null)
                {
                    try
                    {
                        contenidoMultimedia.ExtenderListaDeArchivosYGuardarCambios(this.archivosMultimedia);

                        this.DialogResult = DialogResult.OK;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso: Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Un momento! Debe seleccionar una lista en donde guardar el contenido.", "Aviso: no ha seleccionado una lista.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvListas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(sender is DataGridView dataGrid &&
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
                e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count && dataGrid.SelectedRows.Count > 0)
            {
                this.listaMultimediaPersonalizadaSeleccionada = dataGrid.SelectedRows[0].DataBoundItem as ContenidoMultimedia;

                this.indiceFilaSeleccionadaDeDtgvListas = e.RowIndex;
                this.primeraFilaVisibleDeDtgvListas = dataGrid.FirstDisplayedScrollingRowIndex;

                if(this.listaMultimediaPersonalizadaSeleccionada != null)
                {
                    if(dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                    {
                        if(e.RowIndex == (dataGrid.Rows.Count -1))
                        {
                            this.indiceFilaSeleccionadaDeDtgvListas--;
                        }

                        if(ContenidoMultimedia.EliminarArchivoConContenidoMultimediaPersonalizado(this.listaMultimediaPersonalizadaSeleccionada))
                        {
                            this.OrganizarDataGridDeDtgvListas();

                            if(this.indiceFilaSeleccionadaDeDtgvListas >= 0 && this.indiceFilaSeleccionadaDeDtgvListas < dataGrid.Rows.Count)
                            {
                                this.listaMultimediaPersonalizadaSeleccionada = dataGrid.Rows[this.indiceFilaSeleccionadaDeDtgvListas].DataBoundItem as ContenidoMultimedia;
                            }
                            else
                            {
                                this.listaMultimediaPersonalizadaSeleccionada = null;
                            }
                        }
                    }
                    this.OrganizarDataGridDedtgvContenidosDeLista(this.listaMultimediaPersonalizadaSeleccionada);
                }
            }
        }

        private void btnBorrarTodosLosArchivosConContenidoMultimediaPersonalizados_Click(object sender, EventArgs e)
        {
            try
            {
                ContenidoMultimedia.EliminarTodosLosArchivosConContenidoMultimediaPersonalizado();

                this.listaMultimediaPersonalizadaSeleccionada = null;

                this.OrganizarDataGridDeDtgvListas();

                this.OrganizarDataGridDedtgvContenidosDeLista(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Error al eliminar archivos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarTodosLosContenidosDeUnArchivoMultimediaPersonalizado_Click(object sender, EventArgs e)
        {
            if(this.dtgvListas.SelectedRows != null && this.dtgvListas.SelectedRows.Count > 0)
            {
                ContenidoMultimedia contenidoMultimedia = this.dtgvListas.SelectedRows[0].DataBoundItem as ContenidoMultimedia;

                if(contenidoMultimedia != null)
                {
                    contenidoMultimedia.ListaMultimedia.VaciarListaDeArchivosYGuardarCambios();

                    this.OrganizarDataGridDedtgvContenidosDeLista(contenidoMultimedia);
                }
            }
        }

        private void dtgvContenidosDeLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGrid &&
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
                e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count && dataGrid.SelectedRows.Count > 0)
            {
                Multimedia archivoMultimedia = dataGrid.SelectedRows[0].DataBoundItem as Multimedia;

                this.indiceFilaSeleccionadaDedtgvContenidosDeLista = e.RowIndex;
                this.primeraFilaVisibleDedtgvContenidosDeLista = dataGrid.FirstDisplayedScrollingRowIndex;

                if (archivoMultimedia != null)
                {
                    if (dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                    {
                        if (e.RowIndex == (dataGrid.Rows.Count - 1))
                        {
                            this.indiceFilaSeleccionadaDedtgvContenidosDeLista--;
                        }

                        if (this.listaMultimediaPersonalizadaSeleccionada != null)
                        {
                            this.listaMultimediaPersonalizadaSeleccionada.ListaMultimedia.EliminarArchivoYGuardarCambios(archivoMultimedia);
                        }

                        this.OrganizarDataGridDedtgvContenidosDeLista(this.listaMultimediaPersonalizadaSeleccionada);
                    }
                }
            }
        }

        private void btnCargarListaParaReproducir_Click(object sender, EventArgs e)
        {
            if(this.dtgvListas.SelectedRows != null && this.dtgvListas.SelectedRows.Count > 0)
            {
                ContenidoMultimedia contenidoMultimedia = this.dtgvListas.SelectedRows[0].DataBoundItem as ContenidoMultimedia;

                if(contenidoMultimedia != null)
                {
                    if(contenidoMultimedia.ArchivosEnListaMultimedia.Count > 0 ||
                       MessageBox.Show("La lista se encuentra vacia, ¿Desea cargarla de todas formas?", "Aviso: Lista vacia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.listaMultimediaPersonalizadaSeleccionada = contenidoMultimedia;

                        this.DialogResult = DialogResult.OK; 
                    }
                }
            }
        }

        /// <summary>
        /// Aplica el tema en la aplicacion.
        /// </summary>
        private void AplicarTema()
        {
            this.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;

            foreach (Control control in this.Controls)
            {
                control.ForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetraAlternativo;

                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
                else if (control is Button boton)
                {                   
                    boton.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorMouseOver;
                    boton.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorMouseOver;
                    boton.ForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetra;                   
                }           
            }

            this.dtgvListas.BackgroundColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
            this.dtgvContenidosDeLista.BackgroundColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;

            this.columnaBotonEliminarDeDtgvListas.FlatStyle = FlatStyle.Flat;
            this.columnaBotonEliminarDeDtgvListas.DefaultCellStyle.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
            this.columnaBotonEliminarDeDtgvListas.DefaultCellStyle.SelectionBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorSeleccion;
            this.columnaBotonEliminarDeDtgvListas.DefaultCellStyle.SelectionForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetraAlSeleccionar;
            this.columnaBotonEliminarDeDtgvListas.DefaultCellStyle.ForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetra;

            this.columnaTextoDeDtgvListas.DefaultCellStyle.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacionAlternativo;
            this.columnaTextoDeDtgvListas.DefaultCellStyle.SelectionBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorSeleccion;
            this.columnaTextoDeDtgvListas.DefaultCellStyle.SelectionForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetraAlSeleccionar;

            this.columnaBotonEliminarDedtgvContenidosDeLista.FlatStyle = FlatStyle.Flat;
            this.columnaBotonEliminarDedtgvContenidosDeLista.DefaultCellStyle.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
            this.columnaBotonEliminarDedtgvContenidosDeLista.DefaultCellStyle.SelectionBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorSeleccion;
            this.columnaBotonEliminarDedtgvContenidosDeLista.DefaultCellStyle.SelectionForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetraAlSeleccionar;
            this.columnaBotonEliminarDedtgvContenidosDeLista.DefaultCellStyle.ForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetra;

            this.columnaTextoDedtgvContenidosDeLista.DefaultCellStyle.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacionAlternativo;
            this.columnaTextoDedtgvContenidosDeLista.DefaultCellStyle.SelectionBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorSeleccion;
            this.columnaTextoDedtgvContenidosDeLista.DefaultCellStyle.SelectionForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetraAlSeleccionar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenombrarLista_Click(object sender, EventArgs e)
        {
            if(this.dtgvListas.SelectedRows != null && this.dtgvListas.SelectedRows.Count > 0)
            {
                ContenidoMultimedia contenidoMultimedia = this.dtgvListas.SelectedRows[0].DataBoundItem as ContenidoMultimedia;

                if(contenidoMultimedia != null)
                {
                    FrmCrearLista renombrarLista = new FrmCrearLista(contenidoMultimedia);
                    if(renombrarLista.ShowDialog() == DialogResult.OK)
                    {
                        this.OrganizarDataGridDeDtgvListas();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un contenido multimedia para renombrar.", "Aviso: No se ha seleccionado contenido.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
