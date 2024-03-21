using GUI;
using Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Test
{
   [Apartment(ApartmentState.STA)]
   [TestFixture]
   public class GUIDrawerTests
   {
      //================ Тесты на добавление линии, эллипса и прямоугольника на полотно =============
      
      // Добавленный на созданный canvas элемент является линией
      // + Проверка логики рисования
      [Test]
      public void AddFigure_AddsLineToCanvasCorrectly()
      {
         // Arrange
         GUIHandler.instance = new GUIHandler(); // Создание экземпляра класса GUIHandler
         GUI.Drawer.Figures.Clear();
         var canvas = new Canvas();
         var figure = new Geometry.Line();
         var p1 = new Geometry.Point(0, 0);
         var p2 = new Geometry.Point(100, 100);

         // Act
         GUI.Drawer.addFigure(figure, p1, p2, canvas);

         // Assert
         Assert.That(1, Is.EqualTo(canvas.Children.Count));
         Assert.That(canvas.Children[0], Is.InstanceOf<System.Windows.Shapes.Line>());
         var drawnLine = (System.Windows.Shapes.Line)canvas.Children[0];
      }


      // Удалили и восстановили фигуру: на canvas должна быть одна фигура эллипс
      [Test]
      public void ReDraw_RemovesLastFigureAndAddsNewFigureToCanvas()
      {
         // Arrange
         GUIHandler.instance = new GUIHandler(); 
         GUI.Drawer.Figures.Clear();
         var canvas = new Canvas();
         var initialP1 = new Geometry.Point(0, 0);
         var initialP2 = new Geometry.Point(100, 100);
         var newFigure = new Geometry.Ellipse();

         // Act
         GUI.Drawer.reDraw(newFigure, initialP1, initialP2, canvas);

         // Assert
         Assert.That(1, Is.EqualTo(canvas.Children.Count));
         Assert.That(canvas.Children[0], Is.InstanceOf<System.Windows.Shapes.Ellipse>());
      }

      [Test]
      public void AddRectangleFigure_AddsRectangleToCanvasCorrectly()
      {
         // Arrange
         GUIHandler.instance = new GUIHandler(); 
         Drawer.Figures.Clear();
         var canvas = new Canvas();
         var figure = new Geometry.Rectangle();
         var p1 = new Geometry.Point(0, 0);
         var p2 = new Geometry.Point(100, 100);
         GUIHandler.instance.SelectedRectColor = System.Drawing.Color.Yellow;
         GUIHandler.instance.BrushWidth = 2;
         GUIHandler.instance.SelectedColor = System.Drawing.Color.Bisque;

         // Act
         Drawer.addFigure(figure, p1, p2, canvas);

         // Assert
         Assert.That(1, Is.EqualTo(canvas.Children.Count));
         Assert.That(canvas.Children[0], Is.InstanceOf<System.Windows.Shapes.Rectangle>());
         var drawnRect = (System.Windows.Shapes.Rectangle)canvas.Children[0];

         Assert.That(100, Is.EqualTo(drawnRect.Width));
         Assert.That(100, Is.EqualTo(drawnRect.Height));
         Assert.That(2, Is.EqualTo(drawnRect.StrokeThickness));
      }


   }
}
