using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Geometry;
using IO;
using Logic;
using Point = Geometry.Point;

namespace GUI
{
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

        private void ellipsseButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "ellipse";
        }

        private void rectButton_Click(object sender, RoutedEventArgs e)
        {
            selectedType = "rectangle";
        }

        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Затычка
            if (firstClick)
            {
                p1 = new Point((int)e.GetPosition(paintSurface).X, (int)e.GetPosition(paintSurface).Y);
                firstClick = false;
            }
            else
            {
                p2 = new Point((int)e.GetPosition(paintSurface).X, (int)e.GetPosition(paintSurface).Y);
                firstClick = true;
                Drawer.addFigure(p1, p2, selectedType, paintSurface);
            }
        }
    }
}
