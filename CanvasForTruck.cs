using ProjectTruckApp;
using ProjectTruckApp.Drawnings;
using ProjectTruckApp.MovementStrategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp
{
	public class CanvasForTruck
	{
		private DrawingTruck _drawingTruck;
		private int _canvasWidth;
		private int _canvasHeight;
		private bool _isInitialized;

		public CanvasForTruck(int width, int height)
		{
			_canvasWidth = width;
			_canvasHeight = height;
			_isInitialized = true;
		}

		public DrawingTruck DrawingTruck => _drawingTruck;

		public bool InsertTruck(DrawingTruck truck)
		{
			if (!_isInitialized)
				return false;

			if (truck.DrawWidth > _canvasWidth || truck.DrawHeight > _canvasHeight)
				return false;

			_drawingTruck = truck;
			return true;
		}

		public void SetTruckPosition(int x, int y)
		{
			if (!_isInitialized || _drawingTruck == null)
				return;

			int maxX = _canvasWidth - _drawingTruck.DrawWidth;
			int maxY = _canvasHeight - _drawingTruck.DrawHeight;

			int clampedX = x < 0 ? 0 : (x > maxX ? maxX : x);
			int clampedY = y < 0 ? 0 : (y > maxY ? maxY : y);

			_drawingTruck.SetPosition(clampedX, clampedY);
		}

		public bool MoveTransport(DirectionType direction)
		{
			if (!_isInitialized || _drawingTruck == null ||
				_drawingTruck.PosX == null || _drawingTruck.PosY == null ||
				_drawingTruck.CarStep == null)
			{
				return false;
			}

			int step = (int)_drawingTruck.CarStep.Value;
			int maxX = _canvasWidth - _drawingTruck.DrawWidth;
			int maxY = _canvasHeight - _drawingTruck.DrawHeight;

			switch (direction)
			{
				case DirectionType.Left:
					if (_drawingTruck.PosX.Value - step >= 0)
					{
						_drawingTruck.MoveLeft();
						return true;
					}
					break;
				case DirectionType.Up:
					if (_drawingTruck.PosY.Value - step >= 0)
					{
						_drawingTruck.MoveUp();
						return true;
					}
					break;
				case DirectionType.Right:
					if (_drawingTruck.PosX.Value + step <= maxX)
					{
						_drawingTruck.MoveRight();
						return true;
					}
					break;
				case DirectionType.Down:
					if (_drawingTruck.PosY.Value + step <= maxY)
					{
						_drawingTruck.MoveDown();
						return true;
					}
					break;
			}
			return false;
		}

		public Bitmap DrawCanvas()
		{
			if (!_isInitialized)
				return null;

			Bitmap bmp = new Bitmap(_canvasWidth, _canvasHeight);
			Graphics graphics = Graphics.FromImage(bmp);
			graphics.Clear(Color.White);
			if (_drawingTruck != null)
				_drawingTruck.DrawTransport(graphics);
			graphics.Dispose();
			return bmp;
		}
	}
}