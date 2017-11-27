using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class cola : objeto
    {
        cola siguiente;
        Bitmap snake = (Bitmap)Image.FromFile(@"C:\Users\Afuro\Desktop\snake\snake\Resources\snake.png", true);

        public cola(int posicionX, int posicionY)
        {
            this.posicionX = posicionX;
            this.posicionY = posicionY;
            siguiente = null;
        }

        public void dibujar (Graphics g)
        {
            if(siguiente != null)
            {
                siguiente.dibujar(g);
            }
            //g.FillRectangle(new SolidBrush(Color.Blue), this.posicionX, this.posicionY, this.ancho, this.ancho);
            g.FillRectangle(new TextureBrush(snake), this.posicionX, this.posicionY, this.ancho, this.ancho);
        }

        public void setXY (int posicionX, int posicionY)
        {
            if(siguiente != null)
            {
                siguiente.setXY(this.posicionX, this.posicionY);
            }
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }

        public void meter()
        {
            if(siguiente == null)
            {
                siguiente = new cola(this.posicionX, this.posicionY);
            }
            else
            {
                siguiente.meter();
            }
        }

        public int verPosX()
        {
            return this.posicionX;
        }

        public int verPosY()
        {
            return this.posicionY;
        }

        public cola verSiguiente()
        {
            return siguiente;
        }
    }
}
