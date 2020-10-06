using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BarcoAmigo :Barco
    {
        public BarcoAmigo(int posicionInicialX, int posicionInicialY, int largo, int ancho):base(posicionInicialX, posicionInicialY, largo, ancho)
        {

        }

        public override int validarPunto(int x, int y)
        {
            return (base.validarPunto(x, y) == 0) ? 0 : -100;

        }
    }
}
