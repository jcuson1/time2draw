using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   internal interface iGUIHandler
   {
      void Save();
      void Load();
      void Undo();
      void Redo();
      void AddLine();
      void AddRect();
      void AddElips();
      void AddPolygon();
      void AddCircle();
      void StretchFigure();
      void RotateFigure();
      void FillColorFigure();
      void BorderColorFigure();
      void DeleteFigure();
      void FigureInfoPanel();
   }
}
