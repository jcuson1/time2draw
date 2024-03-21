using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Logic;

namespace GUI
{
    internal class Drawer
    {
      public static List<Figure> Figures = new List<Figure>();
      static int indFigures = -1;

     

      public static void draw(Canvas canvas)
       {

            SolidColorBrush brStroke;
            SolidColorBrush brFill;
            for (int i = indFigures; i < Figures.Count; i++)           
			{
				if (Figures[i] is Geometry.Line)
				{
					var line = (Geometry.Line)Figures[i];
					System.Windows.Shapes.Line ln = new System.Windows.Shapes.Line();
					ln.X1 = line.X1; ln.Y1 = line.Y1;
					ln.X2 = line.X2; ln.Y2 = line.Y2;
					brStroke = new SolidColorBrush(Color.FromRgb(Figures[i].rectFill_R, Figures[i].rectFill_G, Figures[i].rectFill_B));
					ln.Stroke = brStroke;
					ln.StrokeThickness = Figures[i].rectWidth;
					canvas.Children.Add(ln);
				}

				else if (Figures[i] is Geometry.Ellipse)
				{
					var ellipse = (Geometry.Ellipse)Figures[i];
					System.Windows.Shapes.Ellipse el = new System.Windows.Shapes.Ellipse();
					brStroke = new SolidColorBrush(Color.FromRgb(Figures[i].rectFill_R, Figures[i].rectFill_G, Figures[i].rectFill_B));
					brFill = new SolidColorBrush(Color.FromRgb(Figures[i].fill_R, Figures[i].fill_G, Figures[i].fill_B));
					el.Stroke = brStroke;
					el.Fill = brFill;
					Canvas.SetLeft(el, ellipse.getLeft());
					Canvas.SetTop(el, ellipse.getTop());
					el.Width = ellipse.getWidth();
					el.Height = ellipse.getHeight();
					el.StrokeThickness = Figures[i].rectWidth;
					RotateTransform rotateEllipse = new RotateTransform(Figures[i].angle);
					rotateEllipse.CenterX = el.Width / 2;
					rotateEllipse.CenterY = el.Height / 2;
					el.RenderTransform = rotateEllipse;
					canvas.Children.Add(el);
				}
				else if (Figures[i] is Geometry.Rectangle)
				{
					var rect = (Geometry.Rectangle)Figures[i];
					System.Windows.Shapes.Rectangle rec = new System.Windows.Shapes.Rectangle();
					brStroke = new SolidColorBrush(Color.FromRgb(Figures[i].rectFill_R, Figures[i].rectFill_G, Figures[i].rectFill_B));
					brFill = new SolidColorBrush(Color.FromRgb(Figures[i].fill_R, Figures[i].fill_G, Figures[i].fill_B));
					rec.Stroke = brStroke;
					rec.Fill = brFill;
					Canvas.SetLeft(rec, rect.getLeft());
					Canvas.SetTop(rec, rect.getTop());
					rec.Width = rect.getWidth();
					rec.Height = rect.getHeight();
					rec.StrokeThickness = Figures[i].rectWidth;
					RotateTransform rotateEllipse = new RotateTransform(Figures[i].angle);
					rotateEllipse.CenterX = rec.Width / 2;
					rotateEllipse.CenterY = rec.Height / 2;
					rec.RenderTransform = rotateEllipse;
					canvas.Children.Add(rec);
				}
			}
        }
        public static void addFigure(Figure fig, Point p1, Point p2, Canvas canvas)
		{
			if (fig is Geometry.Line)
			{
				Geometry.Line ln = (Geometry.Line)(fig);
				ln.setPoints(p1.x, p1.y, p2.x, p2.y);
				ln.setRectFill(0, 0, 0);
				ln.setRectWidth(GUIHandler.instance.BrushWidth);
				Figures.Add(ln);
			}

			else if (fig is Geometry.Ellipse)
			{
				Geometry.Ellipse el = (Geometry.Ellipse)(fig);
				el.setPoints(new List<Point> { p1, p2 });
				el.setRectFill(0, 0, 0);
				el.setRectWidth(GUIHandler.instance.BrushWidth);
				el.setFill(GUIHandler.instance.SelectedColor.R, GUIHandler.instance.SelectedColor.G, GUIHandler.instance.SelectedColor.B);
				Figures.Add(el);
			}

			else if (fig is Geometry.Rectangle)
			{
				Geometry.Rectangle rect = (Geometry.Rectangle)(fig);
				rect.setPoints(new List<Point> { p1, p2 });
				rect.setRectFill(0, 0, 0);
				rect.setRectWidth(GUIHandler.instance.BrushWidth);
				rect.setFill(GUIHandler.instance.SelectedColor.R, GUIHandler.instance.SelectedColor.G, GUIHandler.instance.SelectedColor.B);
				Figures.Add(rect);
			}

			indFigures++;
			draw(canvas);
		}

		public static void reDraw(Figure fig, Point p1, Point p2, Canvas canvas)
		{
			Figures.RemoveAt(Figures.Count - 1);
			indFigures--;
			canvas.Children.RemoveAt(canvas.Children.Count - 1);
			addFigure(fig, p1, p2, canvas);
		}

	}
}
