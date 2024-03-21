using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using System.IO;
using System.Collections;
using Geometry;

namespace IO.SVG_Parser
{
   public class SVGRenderer //: IRenderContext
   {
      public bool Absolute { get { return true; } }
      public double Width { get; private set; }
      public double Height { get; private set; }

      private XmlTextWriter Writer { get { return m_writer; } }

      private XmlTextWriter m_writer;

      public SVGRenderer(double width, double height, string path)
      {
         //SVGDocument = new MemoryStream();
         m_writer = new XmlTextWriter(Path.Combine(path), Encoding.UTF8);
         m_writer.Formatting = Formatting.Indented;
         this.Width = (int)width;
         this.Height = (int)height;
      }

      public void Begin()
      {
         Writer.WriteStartDocument();
         //Writer.WriteComment(" Generator: " + (IO.ApplicationInfo.FullName != null ? IO.ApplicationInfo.FullName : "") + ", cdlibrary.dll " + cdlibraryVersion + " ");
         Writer.WriteDocType("svg", "-//W3C//DTD SVG 1.1//EN", "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", null);
         Writer.WriteStartElement("svg", "http://www.w3.org/2000/svg");
         Writer.WriteAttributeString("version", "1.1");
         Writer.WriteAttributeString("width", this.Width.ToString());
         Writer.WriteAttributeString("height", this.Height.ToString());
         //Writer.WriteAttributeString("viewBox", "0 0 1000 1000");
      }

      public void End()
      {
         Writer.WriteEndDocument();
         Writer.Flush();
      }

      public void WriteLine(Line line)
      {
         m_writer.WriteStartElement("line");
         m_writer.WriteAttributeString("x1", line.X1.ToString());
         m_writer.WriteAttributeString("y1", line.Y1.ToString());
         m_writer.WriteAttributeString("x2", line.X2.ToString());
         m_writer.WriteAttributeString("y2", line.Y2.ToString());
         m_writer.WriteAttributeString("style", "stroke:rgb(" + line.rectFill_R.ToString() + "," + line.rectFill_G.ToString() + "," + line.rectFill_B.ToString() + ");stroke-width:" + line.rectWidth.ToString());
         m_writer.WriteEndElement();
      }

      public void WriteRectangle(Rectangle rect)
      {
         m_writer.WriteStartElement("rect");
         m_writer.WriteAttributeString("x", rect.getLeft().ToString());
         m_writer.WriteAttributeString("y", rect.getTop().ToString());
         m_writer.WriteAttributeString("width", rect.getWidth().ToString());
         m_writer.WriteAttributeString("height",rect.getHeight().ToString());
         m_writer.WriteAttributeString("fill-opacity", "1");
         m_writer.WriteAttributeString("fill", "rgb(" + rect.fill_R.ToString() + "," + rect.fill_G.ToString() + "," + rect.fill_B.ToString() + ")");
         m_writer.WriteAttributeString("stroke", "rgb(" + rect.rectFill_R.ToString() + "," + rect.rectFill_G.ToString() + "," + rect.rectFill_B.ToString() + ")");
         m_writer.WriteAttributeString("stroke-width", rect.rectWidth.ToString());
         if (rect.angle != 0)
            m_writer.WriteAttributeString("transform", "rotate(" + rect.angle.ToString() + "," + 
                                                                   ((int)rect.getLeft() + (int)rect.getWidth()/2).ToString() + "," +
                                                                   ((int)rect.getTop() + (int)rect.getHeight() / 2).ToString() + ")");                   
             
         m_writer.WriteEndElement();
      }

      public void WriteEllipse(Ellipse el)
      {
         m_writer.WriteStartElement("ellipse");
         m_writer.WriteAttributeString("cx", ((int)el.getLeft() + (int)el.getWidth() / 2).ToString());
         m_writer.WriteAttributeString("cy", ((int)el.getTop() + (int)el.getHeight() / 2).ToString());
         m_writer.WriteAttributeString("rx", ((int)el.getWidth()/2).ToString());
         m_writer.WriteAttributeString("ry", ((int)el.getHeight() / 2).ToString());
         m_writer.WriteAttributeString("fill-opacity", "1");
         m_writer.WriteAttributeString("fill", "rgb(" + el.fill_R.ToString() + "," + el.fill_G.ToString() + "," + el.fill_B.ToString() + ")");
         m_writer.WriteAttributeString("stroke", "rgb(" + el.rectFill_R.ToString() + "," + el.rectFill_G.ToString() + "," + el.rectFill_B.ToString() + ")");
         m_writer.WriteAttributeString("stroke-width", el.rectWidth.ToString());
         if(el.angle != 0)
            m_writer.WriteAttributeString("transform", "rotate(" + el.angle.ToString() + "," + 
                                                                   ((int)el.getLeft() + (int)el.getWidth() / 2).ToString() + "," + 
                                                                   ((int)el.getTop() + (int)el.getHeight() / 2).ToString() + ")");
 
         m_writer.WriteEndElement();
      }

      public void ReadSVG(string path)
      {
         List<Figure> svgFigures = new List<Figure>();

         XDocument svgFile = XDocument.Load(path);

         foreach(XElement fig in svgFile.Root.Elements())
         {
            
         }
      }
   }
}