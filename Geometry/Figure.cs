using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace Geometry
{
    [XmlInclude(typeof(Line)), XmlInclude(typeof(Ellipse)), XmlInclude(typeof(Rectangle))]
    abstract public class Figure : IFigure
    {
        public List<Point> points;  // Точки
        public double angle;        // Угол поворота в градусах
        public byte fill_R, fill_G, fill_B;                     // Цвет заливки
        public byte rectFill_R, rectFill_G, rectFill_B;         // Цвет рамки
        public double rectWidth;                                // Толщина рамки
        public void setPoints(List<Point> Points) { this.points = Points; }
        public void setAngle(double Angle) { this.angle = Angle; }
        public void setRectWidth(double RectWidth) { this.rectWidth = RectWidth; }
        public void setFill(byte R, byte G, byte B)
        {
            fill_R = R; fill_G = G; fill_B = B;
        }
        public void setRectFill(byte R, byte G, byte B)
        {
            rectFill_R = R; rectFill_G = G; rectFill_B = B;
        }
    }
}

