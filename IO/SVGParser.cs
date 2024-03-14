using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Collections;

namespace IO.SVG_Saver
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
         this.Width = width;
         this.Height = height;
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
      }

      public void End()
      {
         Writer.WriteEndDocument();
         Writer.Flush();
      }

      public void StartSection(object tag)
      {
         // Do nothing.
      }

      public void DrawLine(Point start, Point end, double thickness)
      {
         m_writer.WriteStartElement("line");
         m_writer.WriteAttributeString("x1", start.X.ToString());
         m_writer.WriteAttributeString("y1", start.Y.ToString());
         m_writer.WriteAttributeString("x2", end.X.ToString());
         m_writer.WriteAttributeString("y2", end.Y.ToString());
         m_writer.WriteAttributeString("style", "stroke:rgb(0,0,0);stroke-linecap:square;stroke-width:" + thickness.ToString());
         m_writer.WriteEndElement();
      }

      public void DrawRectangle(Point start, Point end, double thickness)
      {
         m_writer.WriteStartElement("rect");
         m_writer.WriteAttributeString("x", start.X.ToString());
         m_writer.WriteAttributeString("y", start.Y.ToString());
         m_writer.WriteAttributeString("width", (end.X - start.X).ToString());
         m_writer.WriteAttributeString("height", (end.Y - start.Y).ToString());
         m_writer.WriteAttributeString("style", "fill:rgb(255, 255, 255);fill-opacity:1;stroke:rgb(0,0,0);stroke-width:" + thickness.ToString());
         m_writer.WriteEndElement();
      }

      public void DrawEllipse(Point start, Point end, double thickness)
      {
         m_writer.WriteStartElement("ellipse");
         m_writer.WriteAttributeString("cx", (start.X + (end.X - start.X)/2).ToString());
         m_writer.WriteAttributeString("cy", (start.Y + (end.Y - start.Y)/2).ToString());
         m_writer.WriteAttributeString("rx", ((end.X - start.X) / 2).ToString());
         m_writer.WriteAttributeString("ry", ((end.Y - start.Y) / 2).ToString());
         m_writer.WriteAttributeString("style", String.Format("fill-opacity:1;fill:rgb(255,255,255);stroke:rgb(0,0,0);stroke-width:" + thickness.ToString()));
         m_writer.WriteEndElement();
      }

      /*public void DrawPath(Point start, IList<IPathCommand> commands, double thickness, bool fill = false)
      {
         string data = "M " + start.X.ToString() + "," + start.Y.ToString();
         Point last = new Point(0, 0);
         foreach (IPathCommand pathCommand in commands)
         {
            data += " " + pathCommand.Shorthand(start, last);
            last = new Point(pathCommand.End.X, pathCommand.End.Y);
         }

         string fillOpacity = ((fill ? 255f : 0f) / 255f).ToString();

         m_writer.WriteStartElement("path");
         m_writer.WriteAttributeString("d", data);
         m_writer.WriteAttributeString("style", "fill-opacity:" + fillOpacity + ";fill:rgb(0,0,0);stroke:rgb(0,0,0);stroke-width:" + thickness.ToString());
         m_writer.WriteEndElement();
      }*/
   }
}