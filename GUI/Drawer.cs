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
        static List<Figure> Figures = new List<Figure>();
        static int indFigures = -1;

        public static void draw(Canvas canvas)
        {
            SolidColorBrush brStroke;
            SolidColorBrush brFill;
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
                        brStroke = new SolidColorBrush(Color.FromRgb(Figures[i].rectFill_R, Figures[i].rectFill_G, Figures[i].rectFill_B));
                        ln.Stroke = brStroke;
                        ln.StrokeThickness = Figures[i].rectWidth;
                        //if (canvas.Children.Count > 0)
                        //      if(canvas.Children.Count - countFigure == 1)
                        //         canvas.Children.RemoveAt(canvas.Children.Count - 1);
                        canvas.Children.Add(ln);


                        break;
                    case "ellipse":
                        Ellipse el = new Ellipse();
                        brStroke = new SolidColorBrush(Color.FromRgb(Figures[i].rectFill_R, Figures[i].rectFill_G, Figures[i].rectFill_B));
                        brFill = new SolidColorBrush(Color.FromRgb(Figures[i].fill_R, Figures[i].fill_G, Figures[i].fill_B));
                        el.Stroke = brStroke;
                        el.Fill = brFill;
                        Canvas.SetLeft(el, Math.Min(Figures[i].points[0].x, Figures[i].points[1].x));
                        Canvas.SetTop(el, Math.Min(Figures[i].points[0].y, Figures[i].points[1].y));
                        el.Width = Math.Abs(Figures[i].points[1].x - Figures[i].points[0].x);
                        el.Height = Math.Abs(Figures[i].points[1].y - Figures[i].points[0].y);
                        el.StrokeThickness = Figures[i].rectWidth;
                        RotateTransform rotateEllipse = new RotateTransform(Figures[i].angle);
                        rotateEllipse.CenterX = el.Width / 2;
                        rotateEllipse.CenterY = el.Height / 2;
                        el.RenderTransform = rotateEllipse;
                        canvas.Children.Add(el);
                        break;
                    case "rectangle":
                        Rectangle r = new Rectangle();
                        brStroke = new SolidColorBrush(Color.FromRgb(Figures[i].rectFill_R, Figures[i].rectFill_G, Figures[i].rectFill_B));
                        brFill = new SolidColorBrush(Color.FromRgb(Figures[i].fill_R, Figures[i].fill_G, Figures[i].fill_B));
                        r.Stroke = brStroke;
                        r.Fill = brFill;
                        Canvas.SetLeft(r, Math.Min(Figures[i].points[0].x, Figures[i].points[1].x));
                        Canvas.SetTop(r, Math.Min(Figures[i].points[0].y, Figures[i].points[1].y));
                        r.Width = Math.Abs(Figures[i].points[1].x - Figures[i].points[0].x);
                        r.Height = Math.Abs(Figures[i].points[1].y - Figures[i].points[0].y);
                        r.StrokeThickness = Figures[i].rectWidth;
                        RotateTransform rotateRect = new RotateTransform(Figures[i].angle);
                        rotateRect.CenterX = r.Width / 2;
                        rotateRect.CenterY = r.Height / 2;
                        r.RenderTransform = rotateRect;
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
            fig1.rectWidth = GUIHandler.instance.BrushWidth;
            fig1.setFill(255, 255, 255);
            fig1.setRectFill(0, 0, 0);
            fig1.setAngle(0);
            Figures.Add(fig1);
            indFigures++;
            draw(canvas);
        }

        public static void reDraw(Point p1, Point p2, string selectedType, Canvas canvas)
        {
            canvas.Children.RemoveAt(canvas.Children.Count - 1);
            addFigure(p1, p2, selectedType, canvas);
        }

    }
}
