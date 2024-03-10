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
      public Tools.PaintTools SelectedTool;

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
      public void AddFigure()
      {
         SelectedTool = Tools.PaintTools.AddFigure;
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
