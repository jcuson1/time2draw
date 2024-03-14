using System;

using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using Point = Geometry.Point;

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