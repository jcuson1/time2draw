using System;
using System.Collections.Generic;
using System.Drawing;

namespace Geometry
{
	public class Point
	{
		public int x, y;
		public Point(int X, int Y)
		{
			x = X; y = Y;
		}
	}

	interface IFigure
	{
		void setPoints(List<Point> Points);
		void setAngle(double Angle);
		void setFill(Color Fill);
		void setRectFill(Color RectFill);
		void setRectWidth(double RectWidth);
	}
	public class Figure : IFigure
	{
		public List<Point> points;  // Точки
		public double angle;        // (0; 2pi] - угол поворота
		public string type;         // Тип фигуры (эллипс, прямая, ломанная)
		public Color fill;          // Цвет заливки
		public Color rectFill;      // Цвет рамки
		public double rectWidth;    // Толщина рамки
		void IFigure.setPoints(List<Point> Points) { this.points = Points; }
		void IFigure.setAngle(double Angle) { this.angle = Angle; }
		void IFigure.setFill(Color Fill) { this.fill = Fill; }
		void IFigure.setRectFill(Color RectFill) { this.rectFill = RectFill; }
		void IFigure.setRectWidth(double RectWidth) { this.rectWidth = RectWidth; }
	}

}