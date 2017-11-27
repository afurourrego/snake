using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class objeto
    {
        protected int posicionY, posicionX, ancho;

        public objeto()
        {
            ancho = 10;
        }
        public Boolean interseccion(objeto o)
        {
            int diferenciaX = Math.Abs(this.posicionX - o.posicionX);
            int diferenciaY = Math.Abs(this.posicionY - o.posicionY);

            if (diferenciaX >=0 && diferenciaX < ancho && diferenciaY >=0 && diferenciaY < ancho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
