using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class Tools
   {
      public enum PaintTools 
      { 
         AddLine, 
         AddCircle, 
         AddRect, 
         AddElips, 
         AddPolygon, 
         ChoisingFigure,
         MovingFigure,
         DeleteFigure, 
         StretchFigure, 
         RotateFigure, 
         FillColorFigure, 
         BorderColorFigure, 
         Undo, 
         Redo 
      };
      public enum IOTools 
      { 
         Save, 
         Load 
      };
    }
}
