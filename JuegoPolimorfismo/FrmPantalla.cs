using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace JuegoPolimorfismo
{
    public partial class FrmPantalla : Form
    {
        Random random;
        List<Barco> Barcos;
        bool mostrarBarcos;
        int ciclos;


        public FrmPantalla()
        {
            InitializeComponent();
            Barco.XMaximo = this.Width;
            Barco.YMaximo = this.Height;
            Barcos = new List<Barco>();
            random = new Random();
            this.timer1.Interval = 20;
            this.timer1.Enabled = true;
            this.mostrarBarcos = true;
        }

        private void FrmPantalla_Click(object sender,  EventArgs e)
        {
            this.ciclos = 3;
            this.verificar(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
        }

        private void verificar(int x, int y)
        {
            Barco barcoTocado = null;
            foreach (Barco item in this.Barcos)
            {
                if (item.validarPunto(x, y) != 0)
                    barcoTocado = item;
            }
            if(barcoTocado != null)
              this.Barcos.Remove(barcoTocado);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //mueve
            foreach (Barco item in Barcos)
            {
                item.mover();
            }
            this.Refresh();
            this.mostrarBarcos = (ciclos >= 0);
            if (ciclos > -2)
                ciclos--;
        }



        private void btnComenzar_Click(object sender, EventArgs e)
        {


            //Crear los barcos
            Barcos.Add(NuevoBarco(true));
            Barcos.Add(NuevoBarco(true));
            Barcos.Add(NuevoBarco(true));
            Barcos.Add(NuevoBarco(true));
            Barcos.Add(NuevoBarco(true));
            Barcos.Add(NuevoBarco(false));
            Barcos.Add(NuevoBarco(false));
            Barcos.Add(NuevoBarco(false));
            Barcos.Add(NuevoBarco(false));
            Barcos.Add(NuevoBarco(false));

            this.btnComenzar.Visible = false;

        }

        private Barco NuevoBarco(bool amigo)
        {
            var largo = random.Next(1, 25);
            var ancho = random.Next(1, 15);

            Barco barco;
            if (amigo)
            {
                barco = new BarcoAmigo(random.Next(0, this.Width - largo - ancho), random.Next(0, this.Height - largo - ancho), largo, ancho);
            }
            else
            {
                barco = new BarcoEnemigo(random.Next(0, this.Width - largo - ancho), random.Next(0, this.Height - largo - ancho), largo, ancho);
            }

            return barco;

        }

        private void FrmPantalla_Paint(object sender, PaintEventArgs e)
        {
            Pen lapizVerde = new Pen(Color.Green, 6);
            Pen lapizRojo = new Pen(Color.Red, 6);

            if (this.mostrarBarcos)
            {
                foreach (Barco item in Barcos)
                {
                    Pen lapiz;
                    if (item is BarcoAmigo)
                        lapiz = lapizVerde;
                    else
                        lapiz = lapizRojo;

                    e.Graphics.DrawRectangle(lapiz, item.PosicionX, item.PosicionY, item.Largo, item.Ancho);
                }
            }
        }
    }
}
