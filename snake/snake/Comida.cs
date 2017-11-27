using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Comida : objeto
    {
        Bitmap comida = (Bitmap)Image.FromFile(@"C:\Users\Afuro\Desktop\snake\snake\Resources\comida.png", true);

        public Comida()
        {
            this.posicionX = generar(66);
            this.posicionY = generar(26);
        }
        public void dibujar(Graphics g)
        {
            //g.FillRectangle(new SolidBrush(Color.Red), this.posicionX, this.posicionY, this.ancho, this.ancho);
            g.FillRectangle(new TextureBrush(comida), this.posicionX, this.posicionY, this.ancho, this.ancho);
        }
        public void colocar()
        {
            this.posicionX = generar(66);
            this.posicionY = generar(26);
        }
        public int generar(int n)
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            return num;
        }
    }
}
