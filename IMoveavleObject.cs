using ProjectTruckApp.MovementStrategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp.MovementStrategy
{
	public interface IMoveableObject
	{
		ObjectCoordinates ObjectCoordinates { get; }
		int ObjectStep { get; }
		void SetObjectPosition(int x, int y);
		void MoveObject(MovementDirection direction);
		void DrawObject(Graphics graphics);
	}
}