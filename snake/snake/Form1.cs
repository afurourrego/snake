using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        cola cabeza;
        Comida comida;
        int puntaje = 0;
        Graphics g;
        int xDir = 0, yDir = 0;
        int cuadro = 10;
        Boolean ejeX = true, ejeY = true;

        public Form1()
        {
            InitializeComponent();
            cabeza = new cola(10, 10);
            comida = new Comida();
            g = canvas.CreateGraphics();
        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        public void movimiento()
        {
            cabeza.setXY(cabeza.verPosX()+xDir, cabeza.verPosY()+yDir);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            g.Clear(Color.White);
            cabeza.dibujar(g);
            comida.dibujar(g);
            movimiento();
            choqueCuerpo();
            choquePared();
            if(cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();
                puntaje++;
                Puntos.Text = puntaje.ToString();
                timer1.Interval = timer1.Interval - 2;
            }
            
        }

        public void choquePared()
        {
            if(cabeza.verPosX() < 0 || cabeza.verPosX() > 650 || cabeza.verPosY() < 0 || cabeza.verPosY() > 250 )
            {
                finJuego();
            }
        }

        public void finJuego()
        {
            puntaje = 0;
            Puntos.Text = "0";
            ejeX = true;
            ejeY = true;
            xDir = 0;
            yDir = 0;
            cabeza = new cola(10, 10);
            comida = new Comida();
            timer1.Interval = 100;
            MessageBox.Show("[PERDISTE]");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void choqueCuerpo()
        {
            cola temp;
            try
            {
                temp = cabeza.verSiguiente().verSiguiente();
            } catch (Exception err)
            {
                temp = null;
            }
            while(temp != null)
            {
                if(cabeza.interseccion(temp))
                {
                    finJuego();
                } else
                {
                    temp = temp.verSiguiente();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(ejeX)
            {
                if (e.KeyCode == Keys.Up)
                {
                    yDir = -cuadro;
                    xDir = 0;
                    ejeX = false;
                    ejeY = true;
                }

                if(e.KeyCode == Keys.Down)
                {
                    yDir = cuadro;
                    xDir = 0;
                    ejeX = false;
                    ejeY = true;
                }
            }

            if(ejeY)
            {
                if (e.KeyCode == Keys.Left)
                {
                    yDir = 0;
                    xDir = -cuadro;
                    ejeX = true;
                    ejeY = false;
                }

                if (e.KeyCode == Keys.Right)
                {
                    yDir = 0;
                    xDir = cuadro;
                    ejeX = true;
                    ejeY = false;
                }
            }

        }
    }
}
