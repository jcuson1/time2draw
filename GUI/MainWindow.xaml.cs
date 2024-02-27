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
using Geometry;
using IO;
using Logic;

namespace GUI
{ 
    public partial class MainWindow : Window
    {
        Brush brush;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickCanvas(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activateRectangle = (Rectangle)e.OriginalSource;
                mainCanvas.Children.Remove(activateRectangle);
            }
            else
            {
                brush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Rectangle rectangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Fill = brush,
                    StrokeThickness = 3,
                    Stroke = Brushes.Red
                };


                Canvas.SetLeft(rectangle, Mouse.GetPosition(mainCanvas).X - 25);
                Canvas.SetTop(rectangle, Mouse.GetPosition(mainCanvas).Y - 25);

                mainCanvas.Children.Add(rectangle);
            }
        }
    }
}
