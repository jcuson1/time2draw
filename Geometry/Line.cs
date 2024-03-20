using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Line : Figure
    {
        public int X1, X2, Y1, Y2;

        public void setPoints(int x1, int y1, int x2, int y2)
        {
            this.points = new List<Point> { new Point(x1, y1), new Point(x2, y2) };
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        public void setAngle(double Angle) { this.angle = Angle; }
        public void setRectWidth(double RectWidth) { this.rectWidth = RectWidth; }
        public void setRectFill(byte R, byte G, byte B)
        {
            rectFill_R = R; rectFill_G = G; rectFill_B = B;
        }
    }
}
