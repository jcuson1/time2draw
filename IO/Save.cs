using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.SVG_Saver;
using Geometry;
using System.Xml;
using System.Drawing;


namespace IO
{
   public class Save
   {
      public string type;

      public Save(string type)
      {
         this.type = type;
      }

      public List<Figure> figuers = new List<Figure>();

      public void SaveAsSVG(List<Figure> figure, double w, double h, string path)
      {
         SVGRenderer parser = new SVGRenderer(w, h, path);

         parser.Begin();

         foreach (Figure fig in figure)
         {
            switch (fig)
            {
               case "line":
                  parser.DrawLine(fig);
                  break;
               case "rectangle":
                  parser.DrawRectangle(fig);
                  break;
               case "ellipse":
                  parser.DrawEllipse(fig);
                  break;
            }
         }

         parser.End();
      }

   }
}
