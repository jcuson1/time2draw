using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Collections;
using Geometry;

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

      public void DrawLine(Figure fig)
      {
         m_writer.WriteStartElement("line");
         m_writer.WriteAttributeString("x1", fig.points[0].x.ToString());
         m_writer.WriteAttributeString("y1", fig.points[0].y.ToString());
         m_writer.WriteAttributeString("x2", fig.points[1].x.ToString());
         m_writer.WriteAttributeString("y2", fig.points[1].y.ToString());
         m_writer.WriteAttributeString("style", "stroke:rgb(" + fig.rectFill_R.ToString() + "," + fig.rectFill_G.ToString() + "," + fig.rectFill_B.ToString() + ");stroke-width:" + fig.rectWidth.ToString());
         m_writer.WriteEndElement();
      }

      public void DrawRectangle(Figure fig)
      {
         int startX = fig.points[0].x;
         int startY = fig.points[0].y;
         int endX = fig.points[1].x;
         int endY = fig.points[1].y;
         int cx = startX + (endX - startX) / 2;
         int cy = startY + (endY - startY) / 2;

         m_writer.WriteStartElement("rect");
         m_writer.WriteAttributeString("x", startX.ToString());
         m_writer.WriteAttributeString("y", startY.ToString());
         m_writer.WriteAttributeString("width", (endX - startX).ToString());
         m_writer.WriteAttributeString("height", (endY - startY).ToString());
         m_writer.WriteAttributeString("style",
                                       "fill-opacity:1;fill:rgb(" + fig.fill_R.ToString() + "," + fig.fill_G.ToString() + "," + fig.fill_B.ToString() + ");" +
                                       "stroke:rgb(" + fig.rectFill_R.ToString() + "," + fig.rectFill_G.ToString() + "," + fig.rectFill_B.ToString() + ");" +
                                       "stroke-width:" + fig.rectWidth.ToString());
                                       //"transform:rotate(" + fig.angle.ToString() + " " + cx.ToString() + " " + cy.ToString() + ")");
         m_writer.WriteEndElement();
      }

      public void DrawEllipse(Figure fig)
      {
         int startX = fig.points[0].x;
         int startY = fig.points[0].y;
         int endX = fig.points[1].x;
         int endY = fig.points[1].y;
         int cx = startX + (endX - startX) / 2;
         int cy = startY + (endY - startY) / 2;

         m_writer.WriteStartElement("ellipse");
         m_writer.WriteAttributeString("cx", cx.ToString());
         m_writer.WriteAttributeString("cy", cy.ToString());
         m_writer.WriteAttributeString("rx", ((endX - startX) / 2).ToString());
         m_writer.WriteAttributeString("ry", ((endY - startY) / 2).ToString());
         m_writer.WriteAttributeString("style",
                                       "fill:rgb(" + fig.fill_R.ToString() + "," + fig.fill_G.ToString() + "," + fig.fill_B.ToString() + ");" +
                                       "stroke:rgb(" + fig.rectFill_R.ToString() + "," + fig.rectFill_G.ToString() + "," + fig.rectFill_B.ToString() + ");" +
                                       "stroke-width:" + fig.rectWidth.ToString()); 
                                       //"transform:rotate(" + fig.angle.ToString() + " " + cx.ToString() + " " + cy.ToString() + ")");
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