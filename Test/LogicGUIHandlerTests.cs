using Geometry;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Logic.Tests
{
   public class LogicGUIHandlerTests
   {
      [TestFixture]

      public class GUIHandlerTests
      {
         // Проверка на значения по умолчанию для scaleValue
         [Test]
         public void DefaultScaleIsOne()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Assert
            Assert.That(1, Is.EqualTo(handler.scaleValue));
         }

         // Проверка на значения по умолчанию для BrushWidth
         [Test]
         public void DefaultBrushWidthIsOne()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Assert
            Assert.That(1, Is.EqualTo(handler.BrushWidth));
         }

         // Проверка на значения по умолчанию для цвета
         [Test]
         public void DefaultColorIsWhite()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            Color color = Color.White;
            // Assert
            Assert.That(color, Is.EqualTo(handler.SelectedColor));
         }

         //====================Проверка всех кнопок=====================
         // Метод Undo устанавливает свойство SelectedTool в значение Undo, аналогично для последующих
         [Test]
         public void Undo_SetsSelectedToolToUndo()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.Undo();
            // Assert
            Assert.That(Tools.PaintTools.Undo, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void Redo_SetsSelectedToolToRedo()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.Redo();
            // Assert
            Assert.That(Tools.PaintTools.Redo, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void AddLine_SetsSelectedToolToAddLine()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.AddLine();
            // Assert
            Assert.That(Tools.PaintTools.AddLine, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void AddRect_SetsSelectedToolToRedo()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.AddRect();
            // Assert
            Assert.That(Tools.PaintTools.AddRect, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void AddElips_SetsSelectedToolToElips()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.AddElips();
            // Assert
            Assert.That(Tools.PaintTools.AddElips, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void AddPolygon_SetsSelectedToolToAddPolygon()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.AddPolygon();
            // Assert
            Assert.That(Tools.PaintTools.AddPolygon, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void StretchFigure_SetsSelectedToolToStretchFigure()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.StretchFigure();
            // Assert
            Assert.That(Tools.PaintTools.StretchFigure, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void RotateFigure_SetsSelectedToolToRotateFigure()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.RotateFigure();
            // Assert
            Assert.That(Tools.PaintTools.RotateFigure, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void FillColorFigure_SetsSelectedToolToFillColorFigure()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.FillColorFigure();
            // Assert
            Assert.That(Tools.PaintTools.FillColorFigure, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void DeleteFigure_SetsSelectedToolToDeleteFigure()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.DeleteFigure();
            // Assert
            Assert.That(Tools.PaintTools.DeleteFigure, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void MoveFigure_SetsSelectedToolToMoveFigure()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            // Act
            handler.MoveFigure();
            // Assert
            Assert.That(Tools.PaintTools.MovingFigure, Is.EqualTo(handler.SelectedTool));
         }

         [Test]
         public void ChangeBrushWidth_SetsSelectedToolToChangeBrushWidth()
         {
            // Arrange
            GUIHandler handler = new GUIHandler();
            double BrushWidth = new GUIHandler().BrushWidth;
            // Act
            double width = 1.0d;
            handler.ChangeBrushWidth((int)width);
            // Assert
            Assert.That(BrushWidth, Is.EqualTo(width));
         }
      }
   }
}
