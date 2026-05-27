using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp.MovementStrategy
{
	public class ObjectCoordinates
	{
		private readonly int _x;
		private readonly int _y;
		private readonly int _width;
		private readonly int _height;

		public int LeftBorder => _x;
		public int TopBorder => _y;
		public int RightBorder => _x + _width;
		public int DownBorder => _y + _height;
		public int ObjectMiddleHorizontal => _x + _width / 2;
		public int ObjectMiddleVertical => _y + _height / 2;

		// Добавляем публичные свойства для доступа к полям
		public int Width => _width;
		public int Height => _height;
		public int X => _x;
		public int Y => _y;

		public ObjectCoordinates(int x, int y, int width, int height)
		{
			_x = x;
			_y = y;
			_width = width;
			_height = height;
		}
	}
}