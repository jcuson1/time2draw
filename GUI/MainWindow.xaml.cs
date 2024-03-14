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

      public MainWindow()
      {
         InitializeComponent();
         GUIHandler.GetInstance();
      }
      bool firstClick = true;
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
      int countFigure = 0;
      private void paintSurface_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {
         countFigure++;
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
                     p2 = new Point((int)e.GetPosition(paintSurface).X - 1, (int)e.GetPosition(paintSurface).Y - 1);
                     Rotating(p2);
                  
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
            paintSurface.Children.Remove(figure);
            GUI.Drawer.addFigure(x1, x2, selectedType, paintSurface);
            redrawigFlag = true;
         }
         else
         {
            angle = p1.x - p2.x + stangle;
            GUI.Drawer.rotateFigure(x1, x2, angle, selectedType, paintSurface);
         }
      }

      private void rotateButton_Click(object sender, RoutedEventArgs e)
      {
         GUIHandler.instance.RotateFigure();
      }

      private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         p1 = new Point((int)e.GetPosition(paintSurface).X, (int)e.GetPosition(paintSurface).Y);
         if (e.Source is Ellipse)
         {
            figure = (Ellipse)e.Source;
            selectedType = "ellipse";



            //Figure figure = new Figure();
            //figure.angle = ((RotateTransform)shape.RenderTransform).Angle;
            int i = paintSurface.Children.IndexOf(figure);
            var x = Canvas.GetLeft(figure);
            var y = Canvas.GetTop(figure);
            var x1 = x + figure.ActualWidth;
            var y1 = y + figure.ActualHeight;
            List<Point> points = new List<Point>();
            Point p1 = new Point((int)x, (int)y);
            Point p2 = new Point((int)x1, (int)y1);
            points.Add(p1);
            points.Add(p2);
            //figure.setPoints(points);
            //SolidColorBrush cl = (SolidColorBrush)figure.Fill;
            //SolidColorBrush clst = (SolidColorBrush)figure.Stroke;
            //figure.rectWidth = shape.StrokeThickness;

            //figure.fill_R = cl.Color.R;
            //figure.fill_B = cl.Color.B;
            //figure.fill_G = cl.Color.G;
            //figure.rectFill_R = clst.Color.R;
            //figure.rectFill_G = clst.Color.G;
            //figure.rectFill_B = clst.Color.B;
         }
         else if (e.Source is Rectangle)
         {
            figure = (Rectangle)e.Source;
            selectedType = "rectangle";
            int i = paintSurface.Children.IndexOf(figure);
            var x = Canvas.GetLeft(figure);
            var y = Canvas.GetTop(figure);
            var x1 = x + figure.ActualWidth;
            var y1 = y + figure.ActualHeight;
            List<Point> points = new List<Point>();
            Point p1 = new Point((int)x, (int)y);
            Point p2 = new Point((int)x1, (int)y1);
            points.Add(p1);
            points.Add(p2);
         }
         // Затычка
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
   }

}
