using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic;
using Point = Geometry.Point;
using Figure = Geometry.Figure;
using System.Security.Cryptography;
using System.Windows.Media.Media3D;
using IO;
using System.Xml.Linq;
using GUI;

namespace Time2Draw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool rotatingFlag = false;
        private bool redrawigFlag = false;
        private Shape figure;
        private Point p1, p2;
        private string selectedType = "line";
        private Point startPos = new Point(0, 0);
        private double startWidth = 0;
        private double startHeight = 0;
        public int FigureIndex;

        public MainWindow()
        {
            InitializeComponent();
            GUIHandler.GetInstance();
        }

        private void lineButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "line";
            GUIHandler.instance.AddLine();
        }

        private void ellipseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "ellipse";
            GUIHandler.instance.AddElips();
        }

        private void rectButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "rectangle";
            GUIHandler.instance.AddRect();
        }

        private void paintSurface_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
         string path = "C:/Users/olgaa/OneDrive/Desktop/nstu/test.svg";
            SaveFile(path);
            /*if (e.Source is Shape)
            {
                Shape shape = (Shape)e.Source;
                Figure figure = new Figure();
                int i = paintSurface.Children.IndexOf(shape);
                paintSurface.Children.Remove(shape);

            }*/
        }
        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            p1 = new Point((int)e.GetPosition(paintSurface).X, (int)e.GetPosition(paintSurface).Y);
            if (EditingToolIsActive())
                DefineFigureTypeAndIndex(e);

            switch (GUIHandler.instance.SelectedTool)
            {
                case Tools.PaintTools.AddRect:
                case Tools.PaintTools.AddLine:
                case Tools.PaintTools.AddCircle:
                case Tools.PaintTools.AddElips:
                case Tools.PaintTools.AddPolygon:
                    redrawigFlag = false;
                    p1 = new Point((int)e.GetPosition(paintSurface).X, (int)e.GetPosition(paintSurface).Y);
                    break;
                case Tools.PaintTools.BorderColorFigure:

                    break;
                case Tools.PaintTools.DeleteFigure:

                    break;
                case Tools.PaintTools.FillColorFigure:

                    break;
                case Tools.PaintTools.RotateFigure:
                    if (figure != null)
                    {
                        rotatingFlag = true;
                        redrawigFlag = false;
                    }
                    break;
                case Tools.PaintTools.StretchFigure:
                    if (figure != null)
                    {
                        startWidth = figure.Width;
                        startHeight = figure.Height;
                    }
                    break;
                case Tools.PaintTools.MovingFigure:
                    if (figure != null)
                    {
                        startPos.x = (int)Canvas.GetLeft(figure);
                        startPos.y = (int)Canvas.GetTop(figure);
                    }
                    break;

                default:
                    break;

            }
        }

        private void paintSurface_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            redrawigFlag = false;
            rotatingFlag = false;
            if (figure != null)
            {
                figure = null;
            }
        }

        private void paintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                switch (GUIHandler.instance.SelectedTool)
                {
                    case Tools.PaintTools.AddRect:
                    case Tools.PaintTools.AddLine:
                    case Tools.PaintTools.AddCircle:
                    case Tools.PaintTools.AddElips:
                    case Tools.PaintTools.AddPolygon:
                        if (!redrawigFlag)
                        {
                            p2 = new Point((int)e.GetPosition(paintSurface).X - 1, (int)e.GetPosition(paintSurface).Y - 1);
                            GUI.Drawer.addFigure(p1, p2, selectedType, paintSurface);
                            redrawigFlag = true;
                        }
                        else
                        {
                            p2 = new Point((int)e.GetPosition(paintSurface).X - 1, (int)e.GetPosition(paintSurface).Y - 1);
                            GUI.Drawer.reDraw(p1, p2, selectedType, paintSurface);
                        }
                        break;
                    case Tools.PaintTools.RotateFigure:
                        if (rotatingFlag)
                        {
                            p2 = new Point((int)e.GetPosition(paintSurface).X - 1, (int)e.GetPosition(paintSurface).Y - 1);
                            Rotating();
                        }
                        break;
                    case Tools.PaintTools.StretchFigure:
                        if (figure != null)
                        {
                            p2 = new Point((int)e.GetPosition(paintSurface).X - 1, (int)e.GetPosition(paintSurface).Y - 1);
                            Stretching();
                        }
                        break;
                    case Tools.PaintTools.MovingFigure:
                        if (figure != null)
                        {
                            p2 = new Point((int)e.GetPosition(paintSurface).X - 1, (int)e.GetPosition(paintSurface).Y - 1);
                            Moving();
                        }
                        break;
                    default:
                        break;


                }

        }

        void Rotating()
        {
            RotateTransform rotateTransform = new RotateTransform();
            if (figure.RenderTransform is RotateTransform)
            {
                rotateTransform = (RotateTransform)figure.RenderTransform;
            }
            else if (figure.LayoutTransform is RotateTransform)
            {
                rotateTransform = (RotateTransform)figure.LayoutTransform;
            }

            //GUI.Drawer.rotateFigure(x1, x2, angle, selectedType, paintSurface);
            rotateTransform.Angle += (p1.x - p2.x) * 0.01;
            figure.RenderTransform = rotateTransform;

            paintSurface.Children[FigureIndex] = figure;
        }
        void Moving()
        {
            Canvas.SetLeft(figure, startPos.x + p2.x - p1.x);
            Canvas.SetTop(figure, startPos.y + p2.y - p1.y);

            paintSurface.Children[FigureIndex] = figure;
        }

        void Stretching()
        {
            if (startWidth + p2.x - p1.x > 0)
                figure.Width = startWidth + p2.x - p1.x;
            if(startHeight + p2.y - p1.y > 0)
                figure.Height = startHeight + p2.y - p1.y;

            paintSurface.Children[FigureIndex] = figure;
        }

        private void rotateButton_Click(object sender, RoutedEventArgs e)
        {
            GUIHandler.instance.RotateFigure();
        }

        private void DefineFigureTypeAndIndex(MouseButtonEventArgs e)
        {
            if (e.Source is Rectangle)
            {
                selectedType = "rectangle";
                figure = (Rectangle)e.Source;
            }

            else if (e.Source is Ellipse)
            {
                selectedType = "ellipse";
                figure = (Ellipse)e.Source;
            }

            FigureIndex = paintSurface.Children.IndexOf(figure);
        }

        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            GUIHandler.instance.MoveFigure();
        }

        private void stretchButton_Click(object sender, RoutedEventArgs e)
        {
            GUIHandler.instance.StretchFigure();
        }

        private bool EditingToolIsActive()
        {
            return (GUIHandler.instance.SelectedTool == Tools.PaintTools.StretchFigure ||
                    GUIHandler.instance.SelectedTool == Tools.PaintTools.RotateFigure ||
                    GUIHandler.instance.SelectedTool == Tools.PaintTools.MovingFigure);
        }

        public void SaveFile(string path)
        {
         Save save = new Save("svg");

         /*int i = 0;
         List<Figure> figures = new List<Figure>();

         foreach (Shape fig in paintSurface.Children)
         {
            figures.Add(new Figure());
            
            List<Point> points = new List<Point>();
            Point point = new Point((int)Canvas.GetTop(paintSurface.Children[i]), (int)Canvas.GetLeft(paintSurface.Children[i]));
            points.Add(point);

            point = new Point((int)Canvas.GetG(paintSurface.Children[i]), (int)Canvas.GetLeft(paintSurface.Children[i]));
            
            points.Add(point);


            if (paintSurface.Children[i] is Line) figures[i].type = "line";
            else if (paintSurface.Children[i] is Rectangle) figures[i].type = "rectangle";
            else if (paintSurface.Children[i] is Ellipse) figures[i].type = "ellipse";


            if (!(paintSurface.Children[i] is Line)) figures[i].setAngle((fig.RenderTransform as RotateTransform).Angle);
            figures[i].setPoints(points);
            figures[i].setRectWidth(fig.StrokeThickness);
            i++;
         }*/

         save.SaveAsSVG(Drawer.Figures, paintSurface.Width, paintSurface.Height, path);
        }

    }
}
