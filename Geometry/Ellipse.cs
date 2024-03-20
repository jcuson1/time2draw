using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Ellipse : Figure
    {
        public double getLeft() { return Math.Min(points[0].x, points[1].x); }
        public double getTop()  { return Math.Min(points[0].y, points[1].y); }
        public double getWidth() { return Math.Abs(points[1].x - points[0].x); }
        public double getHeight() { return Math.Abs(points[1].y - points[0].y); }
        public void setAngle(double Angle) { this.angle = Angle; }
        public void setRectWidth(double RectWidth) { this.rectWidth = RectWidth; }
        public void setRectFill(byte R, byte G, byte B)
        {
            rectFill_R = R; rectFill_G = G; rectFill_B = B;
        }
    }
}
