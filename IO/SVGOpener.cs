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
         List<Figure> svgFigures = new List<Figure>();
         double width = 0;
         double height = 0;

         XDocument svgFile = XDocument.Load(path);

         foreach (XElement el in svgFile.Root.Elements())
         {
            if (el.Name == "sql")
            {
               width = double.Parse(el.Attribute("width").Value);
               height = double.Parse(el.Attribute("height").Value);
            }
         }

         return svgFigures;
      }
   }
}
