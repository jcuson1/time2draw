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
            switch(fig.type)
            {
               case "line":
                  parser.DrawLine(new System.Drawing.Point(fig.points[0].x, fig.points[0].y), new System.Drawing.Point(fig.points[1].x, fig.points[1].y), fig.rectWidth);
                  break;
               case "rectangle":
                  parser.DrawRectangle(new System.Drawing.Point(fig.points[0].x, fig.points[0].y), new System.Drawing.Point(fig.points[1].x, fig.points[1].y), fig.rectWidth);
                  break;
               case "ellipse":
                  parser.DrawEllipse(new System.Drawing.Point(fig.points[0].x, fig.points[0].y), new System.Drawing.Point(fig.points[1].x, fig.points[1].y), fig.rectWidth);
                  break;
            }
         }

         parser.End();
      }

    }
}
