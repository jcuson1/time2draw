﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.SVG_Saver;
using Geometry;
using System.Xml.Serialization;
using System.IO;

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
            if (fig is Line)
            {
               parser.WriteLine(fig as Line);
            }
            else if (fig is Rectangle) 
            {
               parser.WriteRectangle(fig as Rectangle);
            }
            else if (fig is Ellipse)
            {
               parser.WriteEllipse(fig as Ellipse);
            }
         }

         parser.End();
      }
        
        public void SaveAsT2D(List<Figure> figure, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, figure);
                xml = stringWriter.ToString();
            }
            File.WriteAllText(path, xml, Encoding.Default);
        }
   }
}
