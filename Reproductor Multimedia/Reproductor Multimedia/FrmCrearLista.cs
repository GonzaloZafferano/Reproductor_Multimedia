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
    public partial class FrmCrearLista : Form
    {
        private ContenidoMultimedia contenidoMultimedia;

        public FrmCrearLista()
        {
            InitializeComponent();
        }

        public FrmCrearLista(ContenidoMultimedia contenidoMultimedia) : this()
        {
            this.contenidoMultimedia = contenidoMultimedia;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCrearLista_Load(object sender, EventArgs e)
        {
            if(this.contenidoMultimedia != null)
            {
                this.Text = $"Menu: Modificacion de lista '{this.contenidoMultimedia.NombreListaMultimedia}'";
            }

            this.AplicarTema();
        }

        private void btnCrearLista_Click(object sender, EventArgs e)
        {
            try
            {    
                ContenidoMultimedia nuevoContenidoMultimedia = new ContenidoMultimedia(txtNombreLista.Text);
            
                if(this.contenidoMultimedia != null)
                {
                    nuevoContenidoMultimedia.ExtenderListaDeArchivosYGuardarCambios(this.contenidoMultimedia.ArchivosEnListaMultimedia);

                    ContenidoMultimedia.AgregarContenidoMultimediaPersonalizadoALista(nuevoContenidoMultimedia);

                    ContenidoMultimedia.EliminarArchivoConContenidoMultimediaPersonalizado(this.contenidoMultimedia);
                }
                else
                {
                    ContenidoMultimedia.AgregarContenidoMultimediaPersonalizadoAListaYGuardar(nuevoContenidoMultimedia);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Aviso: Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
    }
}
