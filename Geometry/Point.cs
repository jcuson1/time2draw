﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	public class Point
	{
		public int x, y;
		public Point(int X, int Y)
		{
			x = X; y = Y;
		}
		public Point()
        {
			x = 0; y = 0; 
        }
	}
}
