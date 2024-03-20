using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Point = Geometry.Point;


namespace Logic
{
   internal class Clicker
   {
      public void OnClick(Point cords) 
      {
            switch (GUIHandler.instance.SelectedTool)
            {

                case Tools.PaintTools.DeleteFigure:
                    FigureFabric.instance.DeleteFigure(cords);
                    break;
                case Tools.PaintTools.StretchFigure:
                    FigureFabric.instance.ChangeFigure(cords);
                    break;
                case Tools.PaintTools.FillColorFigure:
                    FigureFabric.instance.ChangeFigure(cords);
                    break;
                case Tools.PaintTools.BorderColorFigure:
                    FigureFabric.instance.ChangeFigure(cords);
                    break;
            }
      }
   }
}
