using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Barco
    {
        private static int xMaximo;
        private static int yMaximo;
        static Random random;

        private int posicionX;
        private int posicionY;
        private int largo;
        private int ancho;
        protected int velocidadX;
        protected int velocidadY;

        #region Propiedades

        #region propiedad estatica
        public static int XMaximo
        {
            get { return xMaximo; }
            set { xMaximo = value; }
        }

        public static int YMaximo
        {
            get { return yMaximo; }
            set { yMaximo = value; }
        }

        #endregion

        public int Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }
        public int Largo
        {
            get { return largo; }
            set { largo = value; }
        }

        public int PosicionY
        {
            get { return posicionY; }
            set { posicionY = value; }
        }

        public int PosicionX
        {
            get { return posicionX; }
            set { posicionX = value; }
        }

        public int PosicionXFin
        {
            get
            {
                return this.posicionX + this.largo;
            }
        }
        public int PosicionYFin
        {
            get
            {
                return this.posicionY + this.ancho;
            }
        }

        #endregion

        #region Ctor

        static Barco()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        private Barco()
        {
            this.velocidadX = random.Next(-1, 1);
            this.velocidadY = random.Next(-1, 1);
            if (this.velocidadX == 0 && this.velocidadY == 0)
                this.velocidadX = 1;

        }

        public Barco(int posicionInicialX, int posicionInicialY, int largo, int ancho) : this()
        {

            this.posicionX = posicionInicialX;
            this.posicionY = posicionInicialY;

            if (Math.Abs(this.velocidadY) > Math.Abs(this.velocidadX))
            {
                this.Ancho = largo > ancho ? largo : ancho;
                this.Largo = largo > ancho ? ancho : largo;
            }
            else
            {
                this.Largo = largo > ancho ? largo : ancho;
                this.Ancho = largo > ancho ? ancho : largo;
            }

        }

        #endregion


        public virtual void mover()
        {
            if(this.velocidadX != 0)
            {
                if((this.posicionX == 1 && this.velocidadX == -1 ) || (this.PosicionXFin == Barco.XMaximo -1 && this.velocidadX == 1))
                {
                    //Cambia el sentido del barco
                    this.velocidadX = this.velocidadX * -1;
                }
                //incrementa o decrementa la posicion del barco
                this.posicionX += this.velocidadX;
            }

            if (this.velocidadY != 0)
            {

                if ((this.posicionY == 1 && this.velocidadY == -1) || (this.PosicionYFin == Barco.yMaximo - 1 && this.velocidadY == 1))
                {
                    //Cambia el sentido del barco
                    this.velocidadY = this.velocidadY * -1;
                }
                //incrementa o decrementa la posicion del barco                
                this.posicionY += this.velocidadY;
            }

        }

        /// <summary>
        /// retorna 0 si no se encuentra el punto en el barco
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual int  validarPunto(int x, int y)
        {
            if (x>= posicionX && x <= PosicionXFin && y >= this.posicionY && y <= this.PosicionYFin)
                return 1;

            return 0;

        }

    }
}
