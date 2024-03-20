using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	public interface IFigure
	{
		void setPoints(List<Point> points);
		void setAngle(double Angle);
		void setRectWidth(double RectWidth);
		void setRectFill(byte R, byte G, byte B);
	}
}
