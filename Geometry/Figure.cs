using System;
using System.Collections.Generic;
using System.Drawing;

namespace Geometry
{
    public class Point
    {
        public string colorName;      // Имя цвета
        public int r, g, b;           // Значения RGB цвета
        public int x, y;
        public Point(int X, int Y)
        {
            x = X; y = Y;
        }
    }
    public class Figure
    {
        public List<Point> points;  // Точки
        public double angle;        // Угол поворота в градусах
        public string type;         // Тип фигуры (эллипс, прямая, ломанная)
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

