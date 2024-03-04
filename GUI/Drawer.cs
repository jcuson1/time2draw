using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUI
{
	internal class Drawer
	{
		static List<Figure> Figures = new List<Figure>();
		static int indFigures = -1;

		public static void draw(Canvas canvas)
		{
			SolidColorBrush br;
			for (int i = indFigures; i < Figures.Count; i++)
			{
				switch (Figures[i].type)
				{
					case "line":
						Line ln = new Line();
						ln.X1 = Figures[i].points[0].x;
						ln.Y1 = Figures[i].points[0].y;
						ln.X2 = Figures[i].points[1].x;
						ln.Y2 = Figures[i].points[1].y;
						br = new SolidColorBrush(Color.FromRgb(0, 0, 0));
						ln.Stroke = br;
						ln.StrokeThickness = Figures[i].rectWidth;
						canvas.Children.Add(ln);
						break;
					case "ellipse":
						Ellipse el = new Ellipse();
						br = new SolidColorBrush(Color.FromRgb(0, 0, 0));
						el.Stroke = br;
						Canvas.SetLeft(el, Math.Min(Figures[i].points[0].x, Figures[i].points[1].x));
						Canvas.SetTop(el, Math.Min(Figures[i].points[0].y, Figures[i].points[1].y));
						el.Width = Math.Abs(Figures[i].points[1].x - Figures[i].points[0].x);
						el.Height = Math.Abs(Figures[i].points[1].y - Figures[i].points[0].y);
						el.StrokeThickness = Figures[i].rectWidth;
						canvas.Children.Add(el);
						break;
					case "rectangle":
						Rectangle r = new Rectangle();
						br = new SolidColorBrush(Color.FromRgb(0, 0, 0));
						r.Stroke = br;
						Canvas.SetLeft(r, Math.Min(Figures[i].points[0].x, Figures[i].points[1].x));
						Canvas.SetTop(r, Math.Min(Figures[i].points[0].y, Figures[i].points[1].y));
						r.Width = Math.Abs(Figures[i].points[1].x - Figures[i].points[0].x);
						r.Height = Math.Abs(Figures[i].points[1].y - Figures[i].points[0].y);
						r.StrokeThickness = Figures[i].rectWidth;
						canvas.Children.Add(r);
						break;
				}
			}
		}
		public static void addFigure(Point p1, Point p2, string selectedType, Canvas canvas)
		{
			Figure fig1 = new Figure();
			fig1.type = selectedType;
			fig1.points = new List<Point>() { p1, p2 };
			fig1.rectWidth = 2.0;
			Figures.Add(fig1);
			indFigures++;
			draw(canvas);
		}

	}
}
