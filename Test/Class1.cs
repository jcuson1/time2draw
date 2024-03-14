using System;
using GUI;
using Geometry;

using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using Point = Geometry.Point;

//= = = = = = = = = Геометрия = = = = = = = = = 
namespace Geometry.Tests // comment
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void PointConstructor_InitializesCoordinatesCorrectly()
        {
            // Arrange
            int x = 5;
            int y = 10;
            
            // Act
            Point point = new Point(x, y);

            // Assert
            Assert.That(x, Is.EqualTo(point.x));
            Assert.That(y, Is.EqualTo(point.y));
        }
    }

    [TestFixture]
    public class FigureTests
    {
        [Test]
        public void SetPoints_SetsPointsCorrectly()
        {
            // Arrange
            Figure figure = new Figure();
            List<Point> points = new List<Point>
            {
                new Point(1, 2),
                new Point(3, 4)
            };

            // Act
            figure.setPoints(points);

            // Assert
            Assert.That(points, Is.EqualTo(figure.points));
        }

        [Test]
        public void SetAngle_SetsAngleCorrectly()
        {
            // Arrange
            Figure figure = new Figure();
            double angle = 45.0;

            // Act
            figure.setAngle(angle);

            // Assert
            Assert.That(angle, Is.EqualTo(figure.angle));
        }
    }


}

//= = = = = = = = = GUI = = = = = = = = = 
namespace GUI.Tests
{
   [TestFixture]
   public class Test
   {
      public void Test1()
      {
        
      }

   }
}

//= = = = = = = = = ЛОГИКА = = = = = = = = = 
namespace Logic.Tests
{
   [TestFixture]
   public class ClickerTests
   {
      //-------------- Кнопка добавить фигуру --------------
      [Test]
      public void OnClick_AddFigureTool_Selected_AddFigureMethodCalled() 
      {
         // Arrange
         var clicker = new Clicker();
         var cords = new Point(10, 10);
         GUIHandler.instance.SelectedTool = Tools.PaintTools.AddFigure;

         // Act
         clicker.OnClick(cords);

         // Assert
         Assert.That(FigureFabric.instance.AddFigureCalled, Is.True);
      }

      //-------------- Кнопка удалить фигуру --------------
      [Test]
      public void OnClick_DeleteFigureTool_Selected_DeleteFigureMethodCalled() 
      {
         // Arrange
         var clicker = new Clicker();
         var cords = new Point(20, 20);
         GUIHandler.instance.SelectedTool = Tools.PaintTools.DeleteFigure;

         // Act
         clicker.OnClick(cords);

         // Assert
         Assert.That(FigureFabric.instance.DeleteFigureCalled, Is.True);
      }

      //-------------- Кнопка масштабировать фигуру --------------
      [Test]
      public void OnClick_StretchFigureTool_Selected_ChangeFigureMethodCalled()
      {
         // Arrange
         var clicker = new Clicker();
         var cords = new Point(30, 30);
         GUIHandler.instance.SelectedTool = Tools.PaintTools.StretchFigure;

         // Act
         clicker.OnClick(cords);

         // Assert
         Assert.That(FigureFabric.instance.ChangeFigureCalled, Is.True);
      }

      //-------------- Кнопка закрасить фигуру --------------    
         [Test]
         public void OnClick_FillColorFigureTool_Selected_ChangeFigureMethodCalled()
         {
            // Arrange
            var clicker = new Clicker();
            var cords = new Point(10, 10);
            GUIHandler.instance.SelectedTool = Tools.PaintTools.FillColorFigure;

            // Act
            clicker.OnClick(cords);

            // Assert
            Assert.That(FigureFabric.instance.ChangeFigureCalled, Is.True);
         }
      //-------------- Кнопка изменить цвет границы фигуры --------------   
         [Test]
         public void OnClick_BorderColorFigureTool_Selected_ChangeFigureMethodCalled()
         {
            // Arrange
            var clicker = new Clicker();
            var cords = new Point(20, 20);
            GUIHandler.instance.SelectedTool = Tools.PaintTools.BorderColorFigure;

            // Act
            clicker.OnClick(cords);

            // Assert
            Assert.That(FigureFabric.instance.ChangeFigureCalled, Is.True);
         }

   }

}