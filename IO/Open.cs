using Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IO
{
    public class Open
    {
        public List<Figure> OpenFigures(string path)
        {
            var serializar = new XmlSerializer(typeof(List<Figure>));
            TextReader textReader = new StreamReader(path);
            List<Figure> openedFigures = new List<Figure>();
            openedFigures = (List<Figure>)serializar.Deserialize(textReader);
            textReader.Close();
            return openedFigures;
        }
    }
}
