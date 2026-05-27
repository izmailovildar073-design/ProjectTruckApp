using ProjectTruckApp.MovementStrategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTruckApp.Drawnings;

namespace ProjectTruckApp.MovementStrategy
{
	public class MoveableAdapterTruck : IMoveableObject
	{
		private readonly DrawingTruck _truck;

		public MoveableAdapterTruck(DrawingTruck truck)
		{
			_truck = truck;
		}

		public ObjectCoordinates ObjectCoordinates
		{
			get
			{
				if (_truck == null || _truck.PosX == null || _truck.PosY == null)
					return null;

				return new ObjectCoordinates(_truck.PosX.Value, _truck.PosY.Value,
					_truck.DrawWidth, _truck.DrawHeight);
			}
		}

		public int ObjectStep => _truck != null ? (int)_truck.CarStep : 0;

		public void MoveObject(MovementDirection direction)
		{
			switch (direction)
			{
				case MovementDirection.Left:
					_truck?.MoveLeft();
					break;
				case MovementDirection.Up:
					_truck?.MoveUp();
					break;
				case MovementDirection.Right:
					_truck?.MoveRight();
					break;
				case MovementDirection.Down:
					_truck?.MoveDown();
					break;
			}
		}

		public void SetObjectPosition(int x, int y) => _truck?.SetPosition(x, y);

		public void DrawObject(Graphics graphics) => _truck?.DrawTransport(graphics);
	}
}