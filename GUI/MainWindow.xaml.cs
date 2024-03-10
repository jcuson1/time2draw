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
        readonly Brush brush;
        private int point_index = 0; // чтобы в режиме редактирования мы понимали, какой край линии мы редактируем: 0 - первая точка, 1 - вторая точка
        private Line line_cur = null; // та линия, которую мы редактируем
        readonly String mode;
        private bool mb_press; // проверка на нажатый ЛКМ
        private Point currentPoint = new Point(); // та точка, которую мы кликнули на MouseDown 
        private int cnt = 0; // начальное число отрисованных линий
        readonly int delta = 65; // отсутуп от панели вверху редактора
        public MainWindow()
        {
            InitializeComponent();
            mode = "Рисую линию";
            mb_press = false;
        }

        private void PaintSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mb_press = true;
            if (e.LeftButton == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void PaintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            double marker_x = -1, marker_y = -1;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = null;
                if (line_cur != null) // если зацепились за существующую линию
                {
                    if (point_index == 0) // если зацепились за начало линии
                    {
                        line_cur.X1 = e.GetPosition(this).X; // меняем координаты line_cur на текущие координаты у ЛКМ
                        line_cur.Y1 = e.GetPosition(this).Y - delta;
                        _ = line_cur.X1; // меняем координаты маркера на текущие координаты line_cur
                        _ = line_cur.Y1;
                    }
                    else //зацепились за конец линии
                    {
                        line_cur.X2 = e.GetPosition(this).X; // меняем координаты line_cur на текущие координаты у ЛКМ
                        line_cur.Y2 = e.GetPosition(this).Y - delta;
                        _ = line_cur.X2; // меняем координаты маркера на текущие координаты line_cur
                        _ = line_cur.Y2;
                    }

                }
                else
                    foreach (object obj in paintSurface.Children) // проходим по всем добавленным объектам
                    {
                        line = (Line)obj; //делаем из объекта линию
                        if (line.Name == "line_" + cnt) // пересчитываем уже созданные линии, выбираем имя новой линии
                        {
                            break;
                        }
                        else
                            line = null; // создали новую линию 
                    }

                if (line == null) // если не сущетсвует, создаём новый
                {
                    line = new Line
                    {
                        Stroke = SystemColors.WindowFrameBrush,
                        X1 = currentPoint.X,
                        Y1 = currentPoint.Y - delta,
                        X2 = e.GetPosition(this).X,
                        Y2 = e.GetPosition(this).Y - delta
                    };

                    currentPoint = e.GetPosition(this);
                    line.Name = "line_" + cnt;
                    paintSurface.Children.Add(line);
                }
                else // если существует, изменяем существующий
                {
                    line.X2 = e.GetPosition(this).X;
                    line.Y2 = e.GetPosition(this).Y - delta;
                    paintSurface.InvalidateVisual();
                }
            }
            else
            {

                Line line = null;
                foreach (object obj in paintSurface.Children) // проходим по всем добавленным объектам             
                {

                    line = (Line)obj; //делаем из объекта линию
                    if (Math.Abs(line.X1 - e.GetPosition(this).X) < 5 && (Math.Abs(line.Y1 - e.GetPosition(this).Y - delta) < 5)) //если рядом есть линия
                    {
                        point_index = 0;
                        marker_x = line.X1;
                        marker_y = line.Y1;
                        try
                        {
                            line_cur = line; // запоминаем линию
                        }
                        catch { line = null; continue; }// запоминаем линию
                    }
                    else

                    if (Math.Abs(line.X2 - e.GetPosition(this).X) < 5 && (Math.Abs(line.Y2 - e.GetPosition(this).Y - delta) < 5)) //если рядом есть линия
                    {
                        point_index = 1;
                        marker_x = line.X2;
                        marker_y = line.Y2;
                        try
                        {
                            line_cur = line; // запоминаем линию
                        }
                        catch { line = null; continue; }
                    }
                }
                if (marker_x != -1 | marker_y != -1) // был выбран какой-то маркер
                {
                    System.Windows.Shapes.Rectangle rect;
                    rect = new Rectangle //рисуем маркер-прямоугольник
                    {
                        Stroke = new SolidColorBrush(Colors.Red),
                        Fill = new SolidColorBrush(Colors.Transparent), // прозрачный фон
                        Width = 10,
                        Height = 10
                    }; // добавляется новый прямоугольник
                    Canvas.SetLeft(rect, marker_x); // смещаем по x, чтобы попасть в центр конца линии
                    Canvas.SetTop(rect, marker_y); // смещаем по у, чтобы попасть в центр конца линии
                    paintSurface.Children.Add(rect); // отрисовка
                }
                else
                {
                    foreach (object obj in paintSurface.Children)
                    {
                        try
                        {
                            System.Windows.Shapes.Rectangle rect = (Rectangle)obj;
                            line_cur = line; // запоминаем линию
                            paintSurface.Children.Remove(rect); // если находим маркер rect, то удаляем его
                            paintSurface.InvalidateVisual();
                            break;
                        }
                        catch { }


                    }
                }
            }

        }

        private void PaintSurface_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mb_press = false;
            cnt++;
        }
    }
}
