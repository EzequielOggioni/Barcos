using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoPolimorfismo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.LButton:
                    this.pibTails.Left--;
                    this.pibTails.Left--;
                    validarMoneda(this.pibTails);
                    break;
                case Keys.RButton:
                    this.pibTails.Left++;
                    this.pibTails.Left++;
                    validarMoneda(this.pibTails);
                    break;
                case Keys.Left:
                    this.pibTails.Left--;
                    this.pibTails.Left--;
                    validarMoneda(this.pibTails);
                    break;
                case Keys.Up:
                    this.pibTails.Top--;
                    this.pibTails.Top--;
                    validarMoneda(this.pibTails);
                    break;
                case Keys.Right:
                    this.pibTails.Left++;
                    this.pibTails.Left++;
                    validarMoneda(this.pibTails);
                    break;
                case Keys.Down:
                    this.pibTails.Top++;
                    this.pibTails.Top++;
                    validarMoneda(this.pibTails);
                    break;
                case Keys.A:
                    this.pibSonic.Left--;
                    this.pibSonic.Left--;
                    validarMoneda(this.pibSonic);
                    break;
                case Keys.D:
                    this.pibSonic.Left++;
                    this.pibSonic.Left++;
                    validarMoneda(this.pibSonic);
                    break;
                case Keys.S:
                    this.pibSonic.Top++;
                    this.pibSonic.Top++;
                    validarMoneda(this.pibSonic);
                    break;
                case Keys.W:
                    this.pibSonic.Top--;
                    this.pibSonic.Top--;
                    validarMoneda(this.pibSonic);
                    break;

            }

            
        }

        private void validarMoneda(PictureBox jugador)
        {
            foreach (Control valor in this.Controls)
            {
                if (valor is PictureBox && valor != jugador)
                {
                    PictureBox item = (PictureBox)valor;
                    if ((item.Top < jugador.Top && item.Top + item.Height > jugador.Top) ||
                        ((item.Top < jugador.Top + jugador.Height) && (item.Top + item.Height > jugador.Top + jugador.Height)))
                    {
                        if ((item.Left < jugador.Left && item.Left + item.Width > jugador.Left) || 
                            (item.Left < jugador.Left + jugador.Width && item.Left + item.Width > jugador.Left + jugador.Width))
                        {
                            ((PictureBox)item).Visible = false;
                        }

                    }

                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pibTails.ImageLocation = "moneda.jpg";
        }
    }
}
