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

namespace Time2Draw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool redrawigFlag = false;
        bool rotatingFlag = false;
        Shape figure;
        public int FigureIndex;


        public MainWindow()
        {
            InitializeComponent();
            GUIHandler.GetInstance();
        }
        Point p1, p2;
        string selectedType = "line";

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
            if (e.Source is Shape)
            {
                Shape shape = (Shape)e.Source;
                Figure figure = new Figure();
                int i = paintSurface.Children.IndexOf(shape);
                paintSurface.Children.Remove(shape);

            }
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
                            Rotating(p2);
                        }
                        break;
                    case Tools.PaintTools.StretchFigure:

                        break;
                    default:
                        break;


                }

        }

       void Rotating(Point p2)
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
            var stangle = rotateTransform.Angle;
            var x = Canvas.GetLeft(figure);
            var y = Canvas.GetTop(figure);
            Point x1 = new Point((int)x, (int)y);
            Point x2 = new Point((int)(x + figure.ActualWidth), (int)(y + figure.ActualHeight));
            double angle;
            if (!redrawigFlag)
            {
                //paintSurface.Children.Remove(figure);
                //GUI.Drawer.addFigure(x1, x2, selectedType, paintSurface);
                redrawigFlag = true;
            }
            else
            {
                angle = p1.x - p2.x + stangle;
                //GUI.Drawer.rotateFigure(x1, x2, angle, selectedType, paintSurface);
                rotateTransform.Angle += p1.x - p2.x;
                figure.RenderTransform = rotateTransform;
            }

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

        private bool EditingToolIsActive()
        {
            return (GUIHandler.instance.SelectedTool == Tools.PaintTools.StretchFigure ||
                    GUIHandler.instance.SelectedTool == Tools.PaintTools.RotateFigure ||
                    GUIHandler.instance.SelectedTool == Tools.PaintTools.MovingFigure);
        }
    }

}
