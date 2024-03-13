using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class GUIHandler:iGUIHandler
   {
      public static GUIHandler instance;
      public Tools.PaintTools SelectedTool = Tools.PaintTools.AddLine;

      public static GUIHandler GetInstance()
      {
         if (instance == null)
            instance = new GUIHandler();
         return instance;
      }


      public void Save()
      {
       
      }
      public void Load() 
      {
    
      }
      public void Undo()
      {
         SelectedTool = Tools.PaintTools.Undo;
      }
      public void Redo() 
      {
         SelectedTool = Tools.PaintTools.Redo;
      }
      public void AddLine()
      {
         SelectedTool = Tools.PaintTools.AddLine;
      }
      public void AddCircle()
      {
         SelectedTool = Tools.PaintTools.AddCircle;
      }
      public void AddRect()
      {
         SelectedTool = Tools.PaintTools.AddRect;
      }
      public void AddElips()
      {
         SelectedTool = Tools.PaintTools.AddElips;
      }
      public void AddPolygon()
      {
         SelectedTool = Tools.PaintTools.AddPolygon;
      }
      public void StretchFigure()
      {
         SelectedTool = Tools.PaintTools.StretchFigure;
      }
      public void RotateFigure() 
      {
         SelectedTool = Tools.PaintTools.RotateFigure;
      }
      public void FillColorFigure() 
      {
         SelectedTool = Tools.PaintTools.FillColorFigure;
      }
      public void BorderColorFigure()
      {
         SelectedTool = Tools.PaintTools.BorderColorFigure;
      }
      public void DeleteFigure() 
      {
         SelectedTool = Tools.PaintTools.DeleteFigure;
      }
      public void FigureInfoPanel() 
      { 

      }

   }
}
