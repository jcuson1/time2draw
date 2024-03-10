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

namespace Time2Draw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool firstClick = true;
        Point p1, p2;
        string selectedType = "line";

        private void lineButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "line";

        }

        private void ellipseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "ellipse";

        }

        private void rectButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "rectangle";

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
         p2 = new Point((int)e.GetPosition(paintSurface).X, (int)e.GetPosition(paintSurface).Y);
         GUI.Drawer.addFigure(p1, p2, selectedType, paintSurface, e.LeftButton, countFigure);

      }

      private void paintSurface_MouseMove(object sender, MouseEventArgs e)
      {
         if (e.LeftButton == MouseButtonState.Pressed)
         {
            p2 = new Point((int)e.GetPosition(paintSurface).X - 1, (int)e.GetPosition(paintSurface).Y - 1);
            GUI.Drawer.addFigure(p1, p2, selectedType, paintSurface, e.LeftButton, countFigure);
         }
         else
            return;

      }

      private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         // Затычка
        
         p1 = new Point((int)e.GetPosition(paintSurface).X, (int)e.GetPosition(paintSurface).Y);
         if(e.Source is Shape)
         {  
            Shape shape = (Shape)e.Source;
            Figure figure = new Figure();
            figure.angle = ((RotateTransform)shape.RenderTransform).Angle;
            int i = paintSurface.Children.IndexOf(shape);
            var x = Canvas.GetLeft(shape);
            var y = Canvas.GetTop(shape);
            var x1 = x + shape.ActualWidth;
            var y1 = y + shape.ActualHeight;
            List<Point> points = new List<Point>();
            Point p1 = new Point((int)x, (int )y);
            Point p2 = new Point((int)x1, (int)y1);
            points.Add(p1);
            points.Add(p2);
            figure.setPoints(points);
            SolidColorBrush cl = (SolidColorBrush)shape.Fill;
            SolidColorBrush clst = (SolidColorBrush)shape.Stroke;
            figure.rectWidth = shape.StrokeThickness;
            figure.fill_R = cl.Color.R;
            figure.fill_B = cl.Color.B;
            figure.fill_G = cl.Color.G;
            figure.rectFill_R = clst.Color.R;
            figure.rectFill_G = clst.Color.G;
            figure.rectFill_B = clst.Color.B;
         }
      }
    }

}
