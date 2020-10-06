using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public FrmPantalla()
        {
            InitializeComponent();
            Barco.XMaximo = this.Width;
            Barco.YMaximo = this.Height;
            Barcos = new List<Barco>();
            random = new Random();
            this.timer1.Interval = 20;
            this.timer1.Enabled = true;
        }

        private void FrmPantalla_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hacer");            
        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            //mueve
            foreach (Barco item in Barcos)
            {
                item.mover();
            }
        }

        public void MostrarBarcos()
        {
            
        }


        private void btnComenzar_Click(object sender, EventArgs e)
        {

            
            //Crear los barcos
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());
            Barcos.Add(NuevoBarco());

            this.btnComenzar.Visible = false;

        }

        private Barco NuevoBarco()
        {
            var largo = random.Next(1, 5);
            var ancho = random.Next(1, 5);

            return new Barco(random.Next(0, this.Width - largo - ancho), random.Next(0, this.Height - largo - ancho), largo, ancho);

        }
    }
}
