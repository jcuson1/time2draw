using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Geometry;

namespace IO.SVG_Opener
{
    public class SVGOpener
    {
      public SVGOpener() 
      { }

      public List<Figure> ReadSVG(string path)
      {
         char[] delimeters = { ',', '(', ')'};

         List<Figure> svgFigures = new List<Figure>();
         double width = 0;
         double height = 0;

         XDocument svgFile = XDocument.Load(path);

         foreach (XElement el in svgFile.Root.Elements())
         {
            if (el.Name == "rect")
            {
               Rectangle rect = new Rectangle();
               List<Point> points = new List<Point>();
               
               points.Add(new Point(int.Parse(el.Attribute("x").Value),
                                    int.Parse(el.Attribute("y").Value)));
               points.Add(new Point(int.Parse((el.Attribute("x").Value)) + int.Parse((el.Attribute("width").Value)),
                                    int.Parse((el.Attribute("y").Value)) + int.Parse((el.Attribute("height").Value))));
               rect.setPoints(points);
               rect.setRectWidth(int.Parse(el.Attribute("stroke-width").Value));

               string[] FillRGB = el.Attribute("fill").Value.Split(delimeters);

               rect.setFill(byte.Parse(FillRGB[1]),
                            byte.Parse(FillRGB[2]),
                            byte.Parse(FillRGB[3]));

               string[] RectFillRGB = el.Attribute("stroke").Value.Split(delimeters);

               rect.setFill(byte.Parse(RectFillRGB[1]),
                            byte.Parse(RectFillRGB[2]),
                            byte.Parse(RectFillRGB[3]));

               svgFigures.Add(rect);

            }
         }

         return svgFigures;
      }
   }
}
