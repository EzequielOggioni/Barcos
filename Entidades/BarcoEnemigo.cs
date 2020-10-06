using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BarcoEnemigo :Barco
    {
        public BarcoEnemigo(int posicionInicialX, int posicionInicialY, int largo, int ancho) : base(posicionInicialX, posicionInicialY, largo, ancho)
        {

            

        }

        public override int validarPunto(int x, int y)
        {
            if(base.validarPunto(x-5,y) + base.validarPunto(x + 5, y) + base.validarPunto(x , y-5) + base.validarPunto(x , y+5) > 0){ 
                    this.velocidadX = this.velocidadX * -1;
                    this.velocidadY = this.velocidadY * -1;
            }

            return  (base.validarPunto(x, y) ==0)?0:10;

        }


    }
}
