using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using Entidades;
using XComponent.SliderBar;

namespace Reproductor_Multimedia
{
    public partial class FrmReproductorMultimedia : Form
    {
        private WMPLib.IWMPPlaylist listaMultimediaParaPantallaCompleta;
        private static Tema temaAplicacion;
        private List<int> indicesAleatoriosReproducidos;
        private DataGridViewCheckBoxColumn columnaCheckBox;
        private DataGridViewButtonColumn columnaBotonEliminar;
        private DataGridViewTextBoxColumn columnaTexto;
        private ContenidoMultimedia contenidoPrincipal;
        private Timer temporizadorDePantallaCompleta;
        private Timer temporizador;
        private Random random;
        private string nombreDelContenidoEnReproduccion;
        private string ultimoPatronDeFiltroValido;
        private int indicePrimeraFilaVisible;
        private int indiceFilaSeleccionada;
        private int indiceDelUltimoContenidoMultimediaReproducido;
        private int ultimoValorVolumen;
        private bool estaReproduciendoContenido;
        private bool estaSeteadaReproduccionAutomatica;
        private bool estaSeteadoOrdenAleatorio;
        private bool seStopeoReproduccion;
        private bool estaMuteado;
        private bool estaPantallaCompleta;
        private bool estaFiltroActivo;
        
        public FrmReproductorMultimedia()
        {
            this.InitializeComponent();  

            this.Width = 848;
            this.Height = 835;        

            this.reproductorMultimedia.Width = 794;
            this.reproductorMultimedia.Height = 353;

            ContenidoMultimedia.OnError += this.MensajeErrorHandler;

            this.indicesAleatoriosReproducidos = new List<int>();
            this.contenidoPrincipal = ContenidoMultimedia.ContenidoMultimediaPrincipal;
            this.random = new Random();

            this.temporizador = new Timer();
            this.temporizador.Tick += this.ComportamientoAnteReproduccionHandler;
            this.temporizador.Interval = 250;

            this.ultimoPatronDeFiltroValido = string.Empty;
            this.estaSeteadaReproduccionAutomatica = false;
            this.estaSeteadoOrdenAleatorio = false;
            this.estaPantallaCompleta = false;
            this.estaFiltroActivo = false;
            this.estaMuteado = false;
            this.ultimoValorVolumen = 0;
        }

        public static Tema TemaAplicacion
        {
            get
            {
                return FrmReproductorMultimedia.temaAplicacion;
            }
        }

        private void ReproductorMultimedia_Load(object sender, EventArgs e)
        {
            this.barraDeVolumen.Maximum = 100;

            this.StopearReproduccion();

            this.ResetearIndices();

            this.ActualizarVolumen(25);

            this.CrearColumnasDataGrid();

            this.OrganizarDataGrid();

            this.LeerYAplicarTema();
        }

        /// <summary>
        /// Lee el tema de la aplicacion y lo aplica.
        /// </summary>
        private void LeerYAplicarTema()
        {
            string tema = Properties.Settings.Default.Tema;

            _ = Enum.TryParse(tema, out Tema.TemaAplicacion temaAplicacion);

            FrmReproductorMultimedia.temaAplicacion = new Tema(temaAplicacion);

            this.AplicarTema();
        }

        /// <summary>
        /// Crea las columnas del DataGrid.
        /// </summary>
        private void CrearColumnasDataGrid()
        {
            this.columnaBotonEliminar = new DataGridViewButtonColumn();
            this.columnaBotonEliminar.CellTemplate = new DataGridViewButtonCell();
            this.columnaBotonEliminar.Name = "eliminar";
            this.columnaBotonEliminar.UseColumnTextForButtonValue = true;
            this.columnaBotonEliminar.Text = "-";
            this.columnaBotonEliminar.Width = 25;
            this.columnaBotonEliminar.DisplayIndex = 0;

            this.columnaTexto = new DataGridViewTextBoxColumn();
            this.columnaTexto.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaTexto.Name = "nombre";
            this.columnaTexto.DataPropertyName = "NombreArchivo";
            this.columnaTexto.DisplayIndex = 1;
            this.columnaTexto.Width = 570;

            this.columnaCheckBox = new DataGridViewCheckBoxColumn();
            this.columnaCheckBox.CellTemplate = new DataGridViewCheckBoxCell();
            this.columnaCheckBox.Name = "seleccionados";
            this.columnaCheckBox.DataPropertyName = "EstaSeleccionado";
            this.columnaCheckBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.columnaCheckBox.DisplayIndex = 2;
        }

        /// <summary>
        /// Organiza el datagrid.
        /// </summary>
        private void OrganizarDataGrid()
        {
            this.RefrescarDataSource();

            this.dtgvListaMultimedia.Columns.Clear();

            this.dtgvListaMultimedia.Columns.AddRange(this.columnaTexto, this.columnaBotonEliminar, this.columnaCheckBox);

            if (this.indicePrimeraFilaVisible >= 0 && this.indicePrimeraFilaVisible < this.dtgvListaMultimedia.Rows.Count &&
                this.indiceFilaSeleccionada >= 0 && this.indiceFilaSeleccionada < this.dtgvListaMultimedia.Rows.Count)
            {
                this.dtgvListaMultimedia.FirstDisplayedScrollingRowIndex = this.indicePrimeraFilaVisible;
                this.dtgvListaMultimedia.Rows[indiceFilaSeleccionada].Selected = true;
            }

            this.columnaCheckBox.DisplayIndex = 2;
        }

        /// <summary>
        /// Refresca el DataSource del DataGridView
        /// </summary>
        private void RefrescarDataSource()
        {
            if(this.estaFiltroActivo)
            {
                this.AplicarFiltro(this.ultimoPatronDeFiltroValido, true);
            }

            BindingList<Multimedia> listaMultimedia = new BindingList<Multimedia>(this.contenidoPrincipal.ArchivosEnListaMultimedia);

            this.dtgvListaMultimedia.DataSource = null;
            this.dtgvListaMultimedia.DataSource = listaMultimedia;
        }

        /// <summary>
        /// Muestra un mensaje de error.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        private void MensajeErrorHandler(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso: Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {  
            if(string.IsNullOrEmpty(this.txtBuscador.Text))
            {
                this.QuitarFiltro();               
            }
            else if(!this.AplicarFiltro(this.txtBuscador.Text, false))
            {
                MessageBox.Show($"No se han encontrado coincidencias con '{this.txtBuscador.Text}'","Aviso: No se encontraron coincidencias.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.ResetearVariablesEIndicesYReOrganizarDataGrid();
            }
        }

        /// <summary>
        /// Setea el color del control 'btnBuscar'
        /// </summary>
        private void SetearColorDeBtnBuscar()
        {
            if (this.estaFiltroActivo)
            {
                this.btnBuscar.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                this.btnBuscar.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                this.btnBuscar.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
            }
            else
            {
                this.btnBuscar.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                this.btnBuscar.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                this.btnBuscar.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
            }
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            this.QuitarFiltro();
        }

        /// <summary>
        /// Aplica un filtro en la lista de contenidos.
        /// </summary>
        /// <param name="patron">Patron para el filtro.</param>
        /// <param name="mostrarListaVacia">True para mostrar la lista vacia sin coincidencias de todos modos, caso contrario False.</param>
        /// <returns>True si encontro coincidencias y aplico el filtro, caso contrario False.</returns>
        private bool AplicarFiltro(string patron, bool mostrarListaVacia)
        {
            ContenidoMultimedia contenidoAuxiliar;
            bool retorno = false;

            if (!string.IsNullOrWhiteSpace(patron))
            {
                contenidoAuxiliar = ContenidoMultimedia.ContenidoMultimediaPrincipal.FiltrarLista(patron);

                if (contenidoAuxiliar != null && ((contenidoAuxiliar.ArchivosEnListaMultimedia.Count > 0) ||
                    (contenidoAuxiliar.ArchivosEnListaMultimedia.Count == 0 && mostrarListaVacia)))
                {
                    this.contenidoPrincipal = contenidoAuxiliar;
                    this.ultimoPatronDeFiltroValido = patron;
                    this.estaFiltroActivo = true;

                    retorno = true;
                }
            }

            this.SetearColorDeBtnBuscar();

            return retorno;
        }

        /// <summary>
        /// Quita el filtro aplicado.
        /// </summary>
        private void QuitarFiltro()
        {
            this.txtBuscador.Text = string.Empty;
            this.ultimoPatronDeFiltroValido = string.Empty;

            if(this.estaFiltroActivo)
            {
                this.estaFiltroActivo = false;

                this.contenidoPrincipal = ContenidoMultimedia.ContenidoMultimediaPrincipal;

                this.SetearColorDeBtnBuscar();

                this.ResetearVariablesEIndicesYReOrganizarDataGrid();
            }
        }

        /// <summary>
        /// Resetea los indices y reorganiza el datagrid.
        /// Si hay contenido en reproduccion, resetea los mismos y comienza nuevamente a reproducir la lista presente en el datagrid.
        /// </summary>
        private void ResetearVariablesEIndicesYReOrganizarDataGrid()
        {
            this.ResetearIndices();
            this.OrganizarDataGrid();

            if(this.estaReproduciendoContenido)
            {
                this.ResetearVariablesYReproducirContenidoSeleccionadoEnElDataGrid();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.StopearReproduccion();
        }

        /// <summary>
        /// Stopea la reproduccion y resetea variables y controles.
        /// </summary>
        private void StopearReproduccion()
        {
            this.reproductorMultimedia.Ctlcontrols.stop();

            this.nombreDelContenidoEnReproduccion = "-";

            this.seStopeoReproduccion = true;
            this.estaReproduciendoContenido = false;
            this.barraDeReproduccionDeContenido.Enabled = false;

            this.btnPlayPause.Image = Properties.Resources.Play1;

            this.ResetearVariables();
        }

        /// <summary>
        /// Resetea variables.
        /// </summary>
        private void ResetearVariables()
        {
            this.indicesAleatoriosReproducidos.Clear();

            this.lblContenidoActual.Text = "-";
            this.lblReproduccionFaltante.Text = "00:00";
            this.SetearLabelDeReproduccionActual("00:00", "00:00");
        }

        /// <summary>
        /// Resetea los indices.
        /// </summary>
        private void ResetearIndices()
        {
            this.indiceDelUltimoContenidoMultimediaReproducido = -1;
            this.indicePrimeraFilaVisible = 0;
            this.indiceFilaSeleccionada = 0;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog obtenerArchivos = new OpenFileDialog();

            obtenerArchivos.Title = "Seleccione uno o varios archivos";
            obtenerArchivos.CheckPathExists = true;
            obtenerArchivos.CheckFileExists = true;
            obtenerArchivos.Multiselect = true;
            obtenerArchivos.Filter = "Archivos Multimedia | *.mp3; *.mp4";

            if(obtenerArchivos.ShowDialog() == DialogResult.OK)
            {
                string[] rutasAbsolutasSeleccionadas = obtenerArchivos.FileNames;

                try
                {
                    ContenidoMultimedia.ContenidoMultimediaPrincipal.ExtenderListaDeArchivosYGuardarCambios(rutasAbsolutasSeleccionadas);
                }
                catch(Exception ex)
                {
                    this.MensajeErrorHandler(ex.Message);
                }

                this.OrganizarDataGrid();
            }
        }

        private void btnLimpiarLista_Click(object sender, EventArgs e)
        {
            bool eliminoElementos = false;

            if(ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia.Count > 0)
            {
                for (int i = ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia.Count - 1; i >= 0; i--)
                {
                    if(ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia[i].EstaSeleccionado)
                    {
                        if (i < this.indiceDelUltimoContenidoMultimediaReproducido)
                        {
                            this.indiceDelUltimoContenidoMultimediaReproducido--;
                        }             

                        if (this.reproductorMultimedia.currentMedia != null &&
                           this.reproductorMultimedia.currentMedia.sourceURL == ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia[i].RutaAbsolutaDelArchivo)
                        {
                            this.StopearReproduccion();
                        }

                        ContenidoMultimedia.ContenidoMultimediaPrincipal.ListaMultimedia.EliminarArchivo(ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia[i]);
                        
                        eliminoElementos = true;
                    }
                }

                if(eliminoElementos)
                {
                    ContenidoMultimedia.ContenidoMultimediaPrincipal.ListaMultimedia.GuardarCambiosEnListaDeArchivos();
                    this.cBoxSeleccionarTodo.Checked = false;

                    this.OrganizarDataGrid();
                }
                else
                {
                    MessageBox.Show("Un momento! Debe seleccionar elementos para eliminarlos.", "Aviso: No se han podido eliminar elementos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Un momento! La lista esta vacia, no hay elementos para eliminar.", "Aviso: No hay elementos para eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvListaMultimedia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(sender is DataGridView dataGrid  && 
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
                e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count &&
                dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {            
                Multimedia contenidoMultimedia = dataGrid.Rows[e.RowIndex].DataBoundItem as Multimedia;

                if(contenidoMultimedia != null)
                {
                    ContenidoMultimedia.ContenidoMultimediaPrincipal.ListaMultimedia.EliminarArchivoYGuardarCambios(contenidoMultimedia);

                    this.indiceFilaSeleccionada = (dataGrid.Rows.Count - 1) == e.RowIndex ? e.RowIndex -1 : e.RowIndex;                       
               
                    this.indicePrimeraFilaVisible = dataGrid.FirstDisplayedScrollingRowIndex;

                    if (e.RowIndex < this.indiceDelUltimoContenidoMultimediaReproducido)
                    {
                        this.indiceDelUltimoContenidoMultimediaReproducido--;
                    }         

                    if (this.reproductorMultimedia.currentMedia != null &&
                       this.reproductorMultimedia.currentMedia.sourceURL == contenidoMultimedia.RutaAbsolutaDelArchivo)
                    {
                        this.StopearReproduccion();
                    }

                    this.OrganizarDataGrid();
                }                
            }
        }

        private void dtgvListaMultimedia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGrid &&
               e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
               e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count &&
               dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                Multimedia contenidoMultimedia = dataGrid.Rows[e.RowIndex].DataBoundItem as Multimedia;

                if (contenidoMultimedia != null)
                {                  
                    contenidoMultimedia.EstaSeleccionado = !contenidoMultimedia.EstaSeleccionado;

                    this.indiceFilaSeleccionada = e.RowIndex;
                   
                    this.indicePrimeraFilaVisible = dataGrid.FirstDisplayedScrollingRowIndex;

                    this.OrganizarDataGrid();
                }
            }
        }

        private void dtgvListaMultimedia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(sender is DataGridView dataGrid && 
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
                e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count &&
                dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                this.ResetearVariablesYReproducirContenidoSeleccionadoEnElDataGrid();
            }
        }

        /// <summary>
        /// Resetea las variables, reproduce el contenido que este seleccionado en el datagrid,
        /// y agrega el contenido a la lista de 'indicesAleatoriosReproducidos' si es que esta seteado el orden aleatorio.
        /// </summary>
        private void ResetearVariablesYReproducirContenidoSeleccionadoEnElDataGrid()
        {
            this.ResetearVariables();

            this.ReproducirContenidoSeleccionadoEnElDataGrid();

            if (this.estaSeteadoOrdenAleatorio)
            {
                this.indicesAleatoriosReproducidos.Add(this.indiceDelUltimoContenidoMultimediaReproducido);
            }
        }

        /// <summary>
        /// Reproduce el contenido seleccionado en el datagrid.
        /// </summary>
        private void ReproducirContenidoSeleccionadoEnElDataGrid()
        {
            if (this.dtgvListaMultimedia.SelectedRows != null && this.dtgvListaMultimedia.SelectedRows.Count > 0)
            {
                Multimedia contenidoMultimedia = this.dtgvListaMultimedia.SelectedRows[0].DataBoundItem as Multimedia;

                if (contenidoMultimedia != null)
                {
                    this.nombreDelContenidoEnReproduccion = contenidoMultimedia.NombreArchivo;

                    this.SetearURLYReproducirContenidoInmediatamente(contenidoMultimedia.RutaAbsolutaDelArchivo);

                    this.indiceDelUltimoContenidoMultimediaReproducido = this.dtgvListaMultimedia.SelectedRows[0].Index;
                }
            }
        }

        /// <summary>
        /// Reproduce el contenido que se encuentra en la ruta recibida por parametro.
        /// </summary>
        /// <param name="rutaAbsolutaDelArchivo">Ruta completa del archivo.</param>
        private void SetearURLYReproducirContenidoInmediatamente(string rutaAbsolutaDelArchivo)
        {
            this.reproductorMultimedia.URL = rutaAbsolutaDelArchivo;

            this.PausarOReproducirContenido(true);
        }

        /// <summary>
        /// Reproduce o pausa el contenido, segun el parametro recibido.
        /// </summary>
        /// <param name="reproducirContenido">True para reproducir, false para pausar.</param>
        private void PausarOReproducirContenido(bool reproducirContenido)
        {          
            if(reproducirContenido)
            {
                this.reproductorMultimedia.Ctlcontrols.play();            
            }
            else
            {
                this.reproductorMultimedia.Ctlcontrols.pause(); 
            }

            this.seStopeoReproduccion = !reproducirContenido;
            this.estaReproduciendoContenido = reproducirContenido;

            this.IniciarODetenerTemporizador(reproducirContenido);
            this.SetearImagenDelControlbtnPlayPause();
        }

        /// <summary>
        /// Inicia o detiene el temporizador.
        /// </summary>
        /// <param name="iniciarTemporizador">True para iniciar el temporizador, false para detenerlo.</param>
        private void IniciarODetenerTemporizador(bool iniciarTemporizador)
        {
            if(iniciarTemporizador)
            {
                this.temporizador.Start();
            }
            else
            {
               this.temporizador.Stop();
            }
        }

        /// <summary>
        /// Determina el comportamiento que se desarrollara ante el estado de reproduccion de contenido.
        /// </summary>
        /// <param name="sender">Objeto que invoca al evento.</param>
        /// <param name="e">Objeto que contiene informacion del evento.</param>
        private void ComportamientoAnteReproduccionHandler(object sender, EventArgs e)
        {
            if(this.estaReproduciendoContenido)
            {
                this.ActualizarDatosDeReproduccion();
            }
            else if(!this.seStopeoReproduccion && this.estaSeteadaReproduccionAutomatica)
            {
                this.ReproducirContenidoMultimedia();            
            }
        }

        /// <summary>
        /// Reproduce contenido multimedia.
        /// </summary>
        private void ReproducirContenidoMultimedia()
        {
            if (this.estaSeteadoOrdenAleatorio)
            {
                this.ReproducirProximoContenidoAleatorio();
            }
            else
            {
                this.ReproducirProximoContenidoNoAleatorio();
            }
        }

        /// <summary>
        /// Actualiza los Labels y barra de reproduccion, acorde a la reproduccion actual.
        /// </summary>
        private void ActualizarDatosDeReproduccion()
        {
            if(this.reproductorMultimedia.currentMedia != null)
            {
                string avanceActualString = this.ObtenerCadenaConMinutosYSegundos((int)(this.reproductorMultimedia.currentMedia.duration - this.reproductorMultimedia.Ctlcontrols.currentPosition));

                this.lblReproduccionFaltante.Text = $"{avanceActualString}";

                this.SetearLabelDeReproduccionActual(this.reproductorMultimedia.Ctlcontrols.currentPositionString, this.reproductorMultimedia.currentMedia.durationString);

                if (this.reproductorMultimedia.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    this.barraDeReproduccionDeContenido.Value = (int)this.reproductorMultimedia.Ctlcontrols.currentPosition;
                }
            }
        }

        /// <summary>
        /// Obtiene una cadena con el formato de minutos y segundos (mm:ss).
        /// </summary>
        /// <param name="segundosTotales">Cantidad de segundos totales</param>
        /// <returns>Una cadena con el formato de minutos y segundos (mm:ss).</returns>
        private string ObtenerCadenaConMinutosYSegundos(int segundosTotales)
        {
            int minutos = segundosTotales / 60;
            int segundos = segundosTotales - (minutos * 60);

            string minutosString = minutos > 9 ? minutos.ToString() : "0" + minutos.ToString();
            string segundosString = segundos > 9 ? segundos.ToString() : "0" + segundos.ToString();

            return $"{minutosString}:{segundosString}";
        }

        /// <summary>
        /// Setea el label de reproduccion actual.
        /// </summary>
        /// <param name="avanceActualDeLaReproduccion">Avance actual de la reproduccion.</param>
        /// <param name="duracionTotalDelContenido">Duracion total del contenido.</param>
        private void SetearLabelDeReproduccionActual(string avanceActualDeLaReproduccion, string duracionTotalDelContenido)
        {
            this.lblReproduccionActual.Text = $"{avanceActualDeLaReproduccion}-{duracionTotalDelContenido}";
        }

        private void barraReproduccionContenido_Scroll(object sender, EventArgs e)
        {
            this.reproductorMultimedia.Ctlcontrols.currentPosition = this.barraDeReproduccionDeContenido.Value;
            this.ActualizarDatosDeReproduccion();
        }

        private void btnAdelantar_Click(object sender, EventArgs e)
        {
            this.reproductorMultimedia.Ctlcontrols.currentPosition += 5;
        }

        private void btnRetrasar_Click(object sender, EventArgs e)
        {
            this.reproductorMultimedia.Ctlcontrols.currentPosition -= 5;
        }

        private void reproductor_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (this.reproductorMultimedia.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                this.barraDeReproduccionDeContenido.Enabled = true;
                this.barraDeReproduccionDeContenido.Maximum = (int)this.reproductorMultimedia.Ctlcontrols.currentItem.duration;

                this.lblContenidoActual.Text = $"'{this.nombreDelContenidoEnReproduccion}'";
            }
            else if (this.reproductorMultimedia.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.estaReproduciendoContenido = false;

                this.barraDeReproduccionDeContenido.Enabled = false;
                this.barraDeReproduccionDeContenido.Value = 0;

                this.SetearLabelDeReproduccionActual(this.reproductorMultimedia.currentMedia.durationString, this.reproductorMultimedia.currentMedia.durationString);
              
                this.SetearImagenDelControlbtnPlayPause();
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (this.reproductorMultimedia.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                this.PausarOReproducirContenido(false);
            }
            else if (this.reproductorMultimedia.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                this.PausarOReproducirContenido(true);
            }
            else
            {
                this.ReproducirContenidoSeleccionadoEnElDataGrid();
            }
            this.SetearImagenDelControlbtnPlayPause();
        }

        /// <summary>
        /// Setea la imagen del control 'btnPlayPause'.
        /// </summary>
        private void SetearImagenDelControlbtnPlayPause()
        {
            this.btnPlayPause.Image = this.estaReproduciendoContenido ? Properties.Resources.Pause1 : Properties.Resources.Play1;
        }

        private void btnAgregarALista_Click(object sender, EventArgs e)
        {
            if(ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia.Count > 0)
            {
                List<Multimedia> listaParaAgregar = new List<Multimedia>();

                for(int i = 0; i < ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia.Count; i++)
                {
                    if(ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia[i].EstaSeleccionado)
                    {
                        listaParaAgregar.Add(ContenidoMultimedia.ContenidoMultimediaPrincipal.ArchivosEnListaMultimedia[i]);
                    }
                }

                if(listaParaAgregar.Count > 0)
                {
                    FrmListas mostrarMisListas = new FrmListas(listaParaAgregar);
                    mostrarMisListas.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Un momento! Debe seleccionar elementos para agregar a las listas.", "Aviso: No hay elementos seleccionados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            else
            {
                MessageBox.Show("Un momento! La lista esta vacia, no hay elementos para agregar a las listas.", "Aviso: No hay elementos para agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarListas_Click(object sender, EventArgs e)
        {
            FrmListas mostrarListas = new FrmListas();

            if(mostrarListas.ShowDialog() == DialogResult.OK && mostrarListas.ListaMultimediaPersonalizadaSeleccionada != null)
            {
                ContenidoMultimedia.ContenidoMultimediaPrincipal.ListaMultimedia.VaciarListaDeArchivos();

                this.StopearReproduccion();
                this.ResetearIndices();

                ContenidoMultimedia.ContenidoMultimediaPrincipal.ExtenderListaDeArchivosYGuardarCambios(mostrarListas.ListaMultimediaPersonalizadaSeleccionada.RutasAbsolutasDeArchivosMultimediaEnContenidoMultimediaPersonalizado);               

                this.OrganizarDataGrid();

                this.ReproducirContenidoMultimedia();
            }
        }

        private void btnComenzarAutomaticamenteProximoContenido_Click(object sender, EventArgs e)
        {
            this.estaSeteadaReproduccionAutomatica = !this.estaSeteadaReproduccionAutomatica;

            this.SetearColorDebtnComenzarAutomaticamenteProximoContenido();
        }

        /// <summary>
        /// Setea el color del control 'btnComenzarAutomaticamenteProximoContenido'.
        /// </summary>
        private void SetearColorDebtnComenzarAutomaticamenteProximoContenido()
        {
            if (this.estaSeteadaReproduccionAutomatica)
            {
                this.btnComenzarAutomaticamenteProximoContenido.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
            }
            else
            {
                this.btnComenzarAutomaticamenteProximoContenido.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                this.btnComenzarAutomaticamenteProximoContenido.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
            }
        }

        private void btnOrdenAleatorio_Click(object sender, EventArgs e)
        {
            this.estaSeteadoOrdenAleatorio = !this.estaSeteadoOrdenAleatorio;
            this.indicesAleatoriosReproducidos.Clear();

            this.SetearColorDebtnOrdenAleatorio();
        }

        /// <summary>
        /// Setea el color del control 'btnOrdenAleatorio'.
        /// </summary>
        private void SetearColorDebtnOrdenAleatorio()
        {
            if (this.estaSeteadoOrdenAleatorio)
            {
                this.btnOrdenAleatorio.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                this.btnOrdenAleatorio.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                this.btnOrdenAleatorio.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
            }
            else
            {
                this.btnOrdenAleatorio.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                this.btnOrdenAleatorio.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                this.btnOrdenAleatorio.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.estaSeteadoOrdenAleatorio)
            {
                this.ReproducirProximoContenidoAleatorio();
            }
            else
            {
                this.ReproducirProximoContenidoNoAleatorio();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.ReproducirContenidoPrevio();
        }

        /// <summary>
        /// Reproduce el proximo contenido de forma aleatoria.
        /// </summary>
        private void ReproducirProximoContenidoAleatorio()
        {
            if (this.contenidoPrincipal.ArchivosEnListaMultimedia.Count > 0 && this.dtgvListaMultimedia.Rows.Count > 0)
            {
                if (this.indicesAleatoriosReproducidos.Count == this.contenidoPrincipal.ArchivosEnListaMultimedia.Count)
                {
                    this.indicesAleatoriosReproducidos.Clear();
                }

                int indiceAReproducir = random.Next(0, this.contenidoPrincipal.ArchivosEnListaMultimedia.Count);

                if (indicesAleatoriosReproducidos.Contains(indiceAReproducir))
                {
                    this.ReproducirProximoContenidoAleatorio();
                }
                else if(indiceAReproducir < this.dtgvListaMultimedia.Rows.Count)
                {
                    this.indicesAleatoriosReproducidos.Add(indiceAReproducir);
              
                    Multimedia multimedia = this.contenidoPrincipal.ArchivosEnListaMultimedia[indiceAReproducir];

                    if(multimedia != null)
                    {
                        this.dtgvListaMultimedia.Rows[indiceAReproducir].Selected = true;

                        this.nombreDelContenidoEnReproduccion = multimedia.NombreArchivo;

                        this.indiceDelUltimoContenidoMultimediaReproducido = indiceAReproducir;

                        this.SetearURLYReproducirContenidoInmediatamente(multimedia.RutaAbsolutaDelArchivo);
                    }
                }
            }
        }

        /// <summary>
        /// Reproduce el proximo contenido disponible.
        /// </summary>
        private void ReproducirProximoContenidoNoAleatorio()
        {
            if (this.contenidoPrincipal.ArchivosEnListaMultimedia.Count > 0 && this.dtgvListaMultimedia.Rows.Count > 0)
            {
                this.indiceDelUltimoContenidoMultimediaReproducido++;

                if (this.indiceDelUltimoContenidoMultimediaReproducido >= this.contenidoPrincipal.ArchivosEnListaMultimedia.Count ||
                    this.indiceDelUltimoContenidoMultimediaReproducido >= this.dtgvListaMultimedia.Rows.Count ||
                    this.indiceDelUltimoContenidoMultimediaReproducido < 0)
                {
                    this.indiceDelUltimoContenidoMultimediaReproducido = 0;
                }

                Multimedia multimedia = this.contenidoPrincipal.ArchivosEnListaMultimedia[this.indiceDelUltimoContenidoMultimediaReproducido];

                if(multimedia != null)
                {
                    this.dtgvListaMultimedia.Rows[this.indiceDelUltimoContenidoMultimediaReproducido].Selected = true;
                    
                    this.nombreDelContenidoEnReproduccion = multimedia.NombreArchivo;

                    this.SetearURLYReproducirContenidoInmediatamente(multimedia.RutaAbsolutaDelArchivo);            
                }
            }
        }

        /// <summary>
        /// Reproduce el contenido anterior al seleccionado, con orden inverso.
        /// </summary>
        private void ReproducirContenidoPrevio()
        {
            if (this.contenidoPrincipal.ArchivosEnListaMultimedia.Count > 0 && this.dtgvListaMultimedia.Rows.Count > 0)
            {
                this.indiceDelUltimoContenidoMultimediaReproducido--;

                if (this.indiceDelUltimoContenidoMultimediaReproducido >= this.contenidoPrincipal.ArchivosEnListaMultimedia.Count ||
                    this.indiceDelUltimoContenidoMultimediaReproducido >= this.dtgvListaMultimedia.Rows.Count ||
                    this.indiceDelUltimoContenidoMultimediaReproducido < 0)
                {
                    this.indiceDelUltimoContenidoMultimediaReproducido = this.contenidoPrincipal.ArchivosEnListaMultimedia.Count-1;
                }

                Multimedia multimedia = this.contenidoPrincipal.ArchivosEnListaMultimedia[this.indiceDelUltimoContenidoMultimediaReproducido];

                if(multimedia != null)
                {
                    this.dtgvListaMultimedia.Rows[this.indiceDelUltimoContenidoMultimediaReproducido].Selected = true;

                    this.nombreDelContenidoEnReproduccion = multimedia.NombreArchivo;

                    this.SetearURLYReproducirContenidoInmediatamente(multimedia.RutaAbsolutaDelArchivo);
                }
            }
        } 

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (!this.estaMuteado)
            {
                this.ActualizarVolumen(0);
            }
            else
            {               
                this.ActualizarVolumen(this.ultimoValorVolumen);
            }

            this.estaMuteado = !this.estaMuteado;
            this.btnMute.Image = !this.estaMuteado? Properties.Resources.Mute1 : Properties.Resources.Sound0;
        }

        private void barraDeVolumen_Scroll(object sender, EventArgs e)
        {
            this.ActualizarVolumen();
        }

        /// <summary>
        /// Actualiza el volumen del reproductor (0-100). 
        /// Si no recibe ningun valor (opcional), se actualiza con el valor que contenga el control 'barraDeVolumen'.
        /// </summary>
        /// <param name="valor">Valor con el que se actualizara el volumen del reproductor.</param>
        private void ActualizarVolumen(int valor = -1)
        {
            if (valor >= 0 && valor <= 100)
            {
                this.ultimoValorVolumen = this.barraDeVolumen.Value;
                this.barraDeVolumen.Value = valor;
            }

            this.reproductorMultimedia.settings.volume = this.barraDeVolumen.Value;
            this.lblVolumen.Text = this.barraDeVolumen.Value.ToString();
        }

        private void btnPantallaCompleta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.reproductorMultimedia.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    this.listaMultimediaParaPantallaCompleta = this.reproductorMultimedia.playlistCollection.newPlaylist(this.contenidoPrincipal.NombreListaMultimedia);

                    WMPLib.IWMPMedia itemMultimedia;

                    for (int i = 0; i < this.contenidoPrincipal.ArchivosEnListaMultimedia.Count; i++)
                    {
                        itemMultimedia = this.reproductorMultimedia.newMedia(this.contenidoPrincipal.ArchivosEnListaMultimedia[i].RutaAbsolutaDelArchivo);

                        this.listaMultimediaParaPantallaCompleta.appendItem(itemMultimedia);
                    }

                    double posicionActual = this.reproductorMultimedia.Ctlcontrols.currentPosition;

                    this.reproductorMultimedia.currentPlaylist = this.listaMultimediaParaPantallaCompleta;
                     
                    if(this.indiceDelUltimoContenidoMultimediaReproducido < 0 || this.indiceDelUltimoContenidoMultimediaReproducido >= this.reproductorMultimedia.currentPlaylist.count)
                    {
                        this.indiceDelUltimoContenidoMultimediaReproducido = 0;
                    }
                    
                    this.reproductorMultimedia.Ctlcontrols.playItem(this.reproductorMultimedia.currentPlaylist.Item[this.indiceDelUltimoContenidoMultimediaReproducido]);

                    this.reproductorMultimedia.Ctlcontrols.currentPosition = posicionActual;

                    this.temporizadorDePantallaCompleta = new Timer();

                    this.temporizadorDePantallaCompleta.Tick += this.EvaluarEstadoDePantallaCompleta;

                    this.temporizadorDePantallaCompleta.Interval = 250;

                    this.temporizadorDePantallaCompleta.Start();                    
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El modo 'Pantalla Completa' solo esta disponible cuando se esta reproduciendo contenido.", "Aviso: Error al intentar usar pantalla completa.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evalua el estado de Pantalla Completa.
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento.</param>
        /// <param name="e">Objeto con informacion del evento.</param>
        private void EvaluarEstadoDePantallaCompleta(object sender, EventArgs e)
        {
            if (this.reproductorMultimedia.playState == WMPLib.WMPPlayState.wmppsPlaying && !this.estaPantallaCompleta)
            {
                this.reproductorMultimedia.uiMode = "full";
                this.reproductorMultimedia.Ctlenabled = true;
                this.reproductorMultimedia.fullScreen = true;
                this.estaPantallaCompleta = true;
            }
            else if (!this.reproductorMultimedia.fullScreen && this.estaPantallaCompleta)
            {
                this.temporizadorDePantallaCompleta.Tick -= this.EvaluarEstadoDePantallaCompleta;

                this.estaPantallaCompleta = false;
                this.reproductorMultimedia.Ctlenabled = false;
                this.reproductorMultimedia.uiMode = "none";

                this.temporizadorDePantallaCompleta.Stop();
                this.temporizadorDePantallaCompleta.Dispose();

                this.indiceDelUltimoContenidoMultimediaReproducido = this.ObtenerIndiceDeContenidoMultimediaReproducidoEnPantallaCompleta(out double posicionActualDeReproduccion);

                if (this.indiceDelUltimoContenidoMultimediaReproducido >= 0 &&
                   this.indiceDelUltimoContenidoMultimediaReproducido < this.dtgvListaMultimedia.Rows.Count)
                {
                    this.dtgvListaMultimedia.Rows[this.indiceDelUltimoContenidoMultimediaReproducido].Selected = true;

                    this.ResetearVariablesYReproducirContenidoSeleccionadoEnElDataGrid();

                    this.reproductorMultimedia.Ctlcontrols.currentPosition = posicionActualDeReproduccion;

                    this.listaMultimediaParaPantallaCompleta = null;
                }
            }
        }

        /// <summary>
        /// Obtiene el indice del contenido multimedia que se esta reproduciendo en pantalla completa.
        /// </summary>
        /// <param name="posicionDeReproduccionActual">Posicion actual del contenido en reproduccion.</param>
        /// <returns>El indice del contenido multimedia que se esta reproduciendo en pantalla completa y su posicion actual.
        /// Si no lo encuentra, retorna 0 en el indice y en la posicion actual.</returns>
        private int ObtenerIndiceDeContenidoMultimediaReproducidoEnPantallaCompleta(out double posicionDeReproduccionActual)
        {
            posicionDeReproduccionActual = 0;

            if (this.listaMultimediaParaPantallaCompleta != null)
            {
                for (int i = 0; i < this.listaMultimediaParaPantallaCompleta.count; i++)
                {
                    if (this.reproductorMultimedia.currentMedia.isIdentical[this.listaMultimediaParaPantallaCompleta.Item[i]])
                    {
                        posicionDeReproduccionActual = this.reproductorMultimedia.Ctlcontrols.currentPosition;

                        return i;
                    }
                }
            }
            return 0;
        }

        private void lblContenidoActual_TextChanged(object sender, EventArgs e)
        {
            if (this.lblContenidoActual.Text.Length > 42)
            {
                this.lblContenidoActual.Font = new Font(this.lblContenidoActual.Font.Name, 10, this.lblContenidoActual.Font.Style);
            }
            else if (this.lblContenidoActual.Text.Length > 34)
            {
                this.lblContenidoActual.Font = new Font(this.lblContenidoActual.Font.Name, 12, this.lblContenidoActual.Font.Style);
            }
            else
            {
                this.lblContenidoActual.Font = new Font(this.lblContenidoActual.Font.Name, 14, this.lblContenidoActual.Font.Style);
            }
        }

        private void CambiarTema_Click(object sender, EventArgs e)
        {
            if(Object.ReferenceEquals(sender, this.btnTemaAzul))
            {
                FrmReproductorMultimedia.temaAplicacion = new Tema(Tema.TemaAplicacion.AzulPrincipal);
            }
            else if (Object.ReferenceEquals(sender, this.btnTemaRojo))
            {
                FrmReproductorMultimedia.temaAplicacion = new Tema(Tema.TemaAplicacion.RojoPrincipal);
            }
            else
            {
                FrmReproductorMultimedia.temaAplicacion = new Tema(Tema.TemaAplicacion.VerdePrincipal);
            }

            Properties.Settings.Default.Tema = FrmReproductorMultimedia.TemaAplicacion.TemaAplicado.ToString();
            Properties.Settings.Default.Save();

            this.AplicarTema();
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

                if(control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
                else if (control is Button boton)
                {
                    if(Object.ReferenceEquals(control, this.btnAgregarALista) ||
                       Object.ReferenceEquals(control, this.btnMostrarListas) ||
                       Object.ReferenceEquals(control, this.btnLimpiarLista) ||
                       Object.ReferenceEquals(control, this.btnImportarContenido))
                    {
                        boton.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                        boton.FlatStyle = FlatStyle.Flat;
                        boton.FlatAppearance.BorderSize = 0;
                        boton.FlatAppearance.MouseDownBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorMouseOver;
                        boton.FlatAppearance.MouseOverBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorMouseOver;
                        boton.ForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetra;                        
                    }
                    else if (!Object.ReferenceEquals(control, this.btnTemaAzul) &&
                             !Object.ReferenceEquals(control, this.btnTemaRojo) &&
                             !Object.ReferenceEquals(control, this.btnTemaVerde) &&
                             !Object.ReferenceEquals(control, this.btnOrdenAleatorio) &&
                             !Object.ReferenceEquals(control, this.btnComenzarAutomaticamenteProximoContenido) &&
                             !Object.ReferenceEquals(control, this.btnBuscar))   
                    {
                        control.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                    }
                }
                else if(control is PictureBox imagen)
                {
                    imagen.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;
                }
                else if (control is MACTrackBar barra)
                {
                    barra.TrackLineColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetra;
                    barra.TrackerColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                    barra.TrackLineSelectedColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
                }
            }

            this.dtgvListaMultimedia.BackgroundColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacion;

            this.columnaBotonEliminar.FlatStyle = FlatStyle.Flat;
            this.columnaBotonEliminar.DataGridView.BorderStyle = BorderStyle.None;
            this.columnaBotonEliminar.DefaultCellStyle.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoDeControl;
            this.columnaBotonEliminar.DefaultCellStyle.SelectionBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorSeleccion;
            this.columnaBotonEliminar.DefaultCellStyle.SelectionForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetraAlSeleccionar;
            this.columnaBotonEliminar.DefaultCellStyle.ForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetra;

            this.columnaTexto.DefaultCellStyle.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacionAlternativo;
            this.columnaTexto.DefaultCellStyle.SelectionBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorSeleccion;
            this.columnaTexto.DefaultCellStyle.SelectionForeColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeLetraAlSeleccionar;

            this.columnaCheckBox.DefaultCellStyle.BackColor = FrmReproductorMultimedia.TemaAplicacion.ColorDeFondoAplicacionAlternativo;
            this.columnaCheckBox.DefaultCellStyle.SelectionBackColor = FrmReproductorMultimedia.TemaAplicacion.ColorSeleccion;

            this.SetearColorDeBtnBuscar();
            this.SetearColorDebtnOrdenAleatorio();
            this.SetearColorDebtnComenzarAutomaticamenteProximoContenido();
        }

        private void cBoxSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.contenidoPrincipal.ArchivosEnListaMultimedia.Count > 0)
            {
                foreach (Multimedia archivoMultimedia in this.contenidoPrincipal.ArchivosEnListaMultimedia)
                {
                    archivoMultimedia.EstaSeleccionado = this.cBoxSeleccionarTodo.Checked;
                }

                this.indicePrimeraFilaVisible = this.dtgvListaMultimedia.FirstDisplayedScrollingRowIndex;

                if (this.dtgvListaMultimedia.SelectedRows != null && this.dtgvListaMultimedia.SelectedRows.Count > 0)
                {
                    this.indiceFilaSeleccionada = this.dtgvListaMultimedia.SelectedRows[0].Index;
                }

                this.OrganizarDataGrid();
            }
            else if (this.cBoxSeleccionarTodo.Checked)
            {
                MessageBox.Show("Un momento! La lista esta vacia, no hay elementos para seleccionar.", "Aviso: No hay elementos para seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.cBoxSeleccionarTodo.Checked = !this.cBoxSeleccionarTodo.Checked;
            }
        }

        private void ReproductorMultimedia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la aplicacion?", "Aviso: Cerrar aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }

            if (!e.Cancel)
            {
                ContenidoMultimedia.OnError -= this.MensajeErrorHandler;
                this.temporizador.Tick -= this.ComportamientoAnteReproduccionHandler;
                this.temporizador.Stop();
                this.temporizador.Dispose();

                if(this.temporizadorDePantallaCompleta != null)
                {
                    this.temporizadorDePantallaCompleta.Stop();
                    this.temporizadorDePantallaCompleta.Dispose();
                }
            }
        }
    }
}
