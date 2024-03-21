using System;
using GUI;
using Geometry;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using Point = Geometry.Point;

//= = = = = = = = = Геометрия = = = = = = = = = =
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

        [Test]
        public void PointConstructor_InitializesCoordinatesCorrectlyMinus()
        {
            // Arrange
            int x = -5;
            int y = -10;

            // Act
            Point point = new Point(x, y);

            // Assert
            Assert.That(x, Is.EqualTo(point.x));
            Assert.That(y, Is.EqualTo(point.y));
        }

        [Test]
        public void PointConstructor_InitializesCoordinatesCorrectlyNull()
        {
            // Arrange
            int x = 0;
            int y = 0;

            // Act
            Point point = new Point(x, y);

            // Assert
            Assert.That(x, Is.EqualTo(point.x));
            Assert.That(y, Is.EqualTo(point.y));
        }

        [Test]
        public void PointConstructor_InitializesCoordinatesCorrectlyPlusMinus()
        {
            // Arrange
            int x = 1;
            int y = -1;

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
      public class ConcreteFigure : Figure
      {
      }

      [Test]
        public void SetPoints_SetsPointsCorrectly()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
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
            ConcreteFigure figure = new ConcreteFigure();
            double angle = 45.0;

            // Act
            figure.setAngle(angle);

            // Assert
            Assert.That(angle, Is.EqualTo(figure.angle));
        }

        [Test]
        public void SetAngle_SetsAngleCorrectly2()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            double angle = 363.0;

            // Act
            figure.setAngle(angle);

            // Assert
            Assert.That(363, Is.EqualTo(figure.angle));
        }
        [Test]
        public void SetAngle_SetsAngleCorrectlyMinus()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            double angle = -363.0;

            // Act
            figure.setAngle(angle);

            // Assert
            Assert.That(-363, Is.EqualTo(figure.angle));
        }
        [Test]
        public void SetAngle_SetsAngleCorrectlyNull()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            double angle = 0;

            // Act
            figure.setAngle(angle);

            // Assert
            Assert.That(0, Is.EqualTo(figure.angle));
        }
        [Test]
        public void SetW_SetsWCorrectlyMinus()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            double RectWidth = -10;

            // Act
            figure.setRectWidth(RectWidth);

            // Assert
            Assert.That(-10, Is.EqualTo(figure.rectWidth));
        }
        [Test]
        public void SetW_SetsWCorrectlyMinusDouble()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            double RectWidth = -10.23523;

            // Act
            figure.setRectWidth(RectWidth);

            // Assert
            Assert.That(-10.23523, Is.EqualTo(figure.rectWidth));
        }
        [Test]
        public void SetW_SetsWCorrectly()
        {

            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            //Figure figure = new Figure();
            double RectWidth = 1000000000;

            // Act
            figure.setRectWidth(RectWidth);

            // Assert
            Assert.That(1000000000, Is.EqualTo(figure.rectWidth));
        }
        [Test]
        public void SetW_SetsWCorrectlyNull()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            double RectWidth = 0;

            // Act
            figure.setRectWidth(RectWidth);

            // Assert
            Assert.That(0, Is.EqualTo(figure.rectWidth));
        }

        [Test]
        public void Set_Fill()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            byte R = 0;
            byte G = 0;
            byte B = 0;

            // Act
            figure.setFill(R, G, B);

            // Assert
            Assert.That(0, Is.EqualTo(figure.fill_R));
            Assert.That(0, Is.EqualTo(figure.fill_G));
            Assert.That(0, Is.EqualTo(figure.fill_B));
        }
        [Test]
        public void Set_Fill2()
        {
            // Arrange
            ConcreteFigure figure = new ConcreteFigure();
            byte R = 100;
            byte G = 20;
            byte B = 255;

            // Act
            figure.setFill(R, G, B);

            // Assert
            Assert.That(100, Is.EqualTo(figure.fill_R));
            Assert.That(20, Is.EqualTo(figure.fill_G));
            Assert.That(255, Is.EqualTo(figure.fill_B));
        }
    }


}
