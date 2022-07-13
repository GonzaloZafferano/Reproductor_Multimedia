using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tema
    {
        public enum TemaAplicacion { AzulPrincipal, RojoPrincipal, VerdePrincipal };

        private TemaAplicacion tema;
        private Color colorMouseOver;
        private Color colorMouseDown;
        private Color colorDeLetra;
        private Color colorDeLetraAlternativo;
        private Color colorDeLetraAlSeleccionar;
        private Color colorDeFondoAplicacion;
        private Color colorDeFondoAplicacionAlternativo;
        private Color colorFondoDeControl;
        private Color colorFondoDeControlAlternativo;
        private Color colorSeleccion;
        private Color colorSeleccionAlternativo;
        private Color colorEncabezado;
        private Color colorEncabezadoAlternativo;

        public Color ColorDeLetra { get => this.colorDeLetra; }
        public Color ColorDeFondoAplicacion { get => this.colorDeFondoAplicacion; }
        public Color ColorDeFondoAplicacionAlternativo { get => this.colorDeFondoAplicacionAlternativo; }
        public Color ColorDeFondoDeControl { get => this.colorFondoDeControl; }
        public Color ColorMouseOver { get => this.colorMouseOver; }
        public Color ColorMouseDown { get => this.colorMouseDown; }
        public TemaAplicacion TemaAplicado { get => this.tema; }
        public Color ColorSeleccion { get => colorSeleccion; }
        public Color ColorEncabezado { get => colorEncabezado; }
        public Color ColorDeLetraAlternativo { get => colorDeLetraAlternativo; }
        public Color ColorFondoDeControlAlternativo { get => colorFondoDeControlAlternativo; }
        public Color ColorSeleccionAlternativo { get => colorSeleccionAlternativo; }
        public Color ColorEncabezadoAlternativo { get => colorEncabezadoAlternativo; }
        public Color ColorDeLetraAlSeleccionar { get => colorDeLetraAlSeleccionar; }

        public Tema(TemaAplicacion tema)
        {
            this.tema = tema;

            this.CargarTema();
        }

        private void CargarTema()
        {
            switch (this.TemaAplicado)
            {               
                case TemaAplicacion.AzulPrincipal:
                    this.colorFondoDeControl = Color.SteelBlue;
                    this.colorFondoDeControlAlternativo = Color.White;
                    this.colorDeFondoAplicacion = Color.Lavender;
                    this.colorDeFondoAplicacionAlternativo = Color.White;
                    this.colorDeLetra = Color.White;
                    this.colorDeLetraAlternativo = Color.DarkBlue;
                    this.colorDeLetraAlSeleccionar = Color.White;
                    this.colorMouseDown = Color.LightSteelBlue;
                    this.colorMouseOver = Color.LightSteelBlue;
                    this.colorSeleccion = Color.LightSteelBlue;
                    this.colorSeleccionAlternativo = Color.RoyalBlue;
                    this.colorEncabezado = Color.SteelBlue;
                    this.colorEncabezadoAlternativo = Color.SteelBlue;
                    break;
                case TemaAplicacion.RojoPrincipal:
                    this.colorFondoDeControl = Color.IndianRed;
                    this.colorFondoDeControlAlternativo = Color.White;
                    this.colorDeFondoAplicacion = Color.MistyRose;
                    this.colorDeFondoAplicacionAlternativo = Color.White;
                    this.colorDeLetra = Color.White;
                    this.colorDeLetraAlternativo = Color.DarkRed;
                    this.colorDeLetraAlSeleccionar = Color.White;
                    this.colorMouseDown = Color.LightCoral;
                    this.colorMouseOver = Color.LightCoral;
                    this.colorSeleccion = Color.LightCoral;
                    this.colorSeleccionAlternativo = Color.LightCoral;
                    this.colorEncabezado = Color.DarkRed;
                    this.colorEncabezadoAlternativo = Color.DarkRed;
                    break;
                default:
                    this.colorFondoDeControl = Color.DarkGreen;
                    this.colorFondoDeControlAlternativo = Color.White;
                    this.colorDeFondoAplicacion = Color.PaleGreen;
                    this.colorDeFondoAplicacionAlternativo = Color.White;
                    this.colorDeLetra = Color.White;
                    this.colorDeLetraAlternativo = Color.DarkGreen;
                    this.colorDeLetraAlSeleccionar = Color.White;
                    this.colorMouseDown = Color.YellowGreen;
                    this.colorMouseOver = Color.YellowGreen;
                    this.colorSeleccion = Color.YellowGreen;
                    this.colorSeleccionAlternativo = Color.YellowGreen;
                    this.colorEncabezado = Color.DarkGreen;
                    this.colorEncabezadoAlternativo = Color.DarkGreen;
                    break;
            }
        }
    }
}
