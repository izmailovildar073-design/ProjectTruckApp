using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectTruckApp.Drawnings
{
	public abstract class DrawingTruck
	{
        public EntityTruck EntityTruck { get; protected set; }
        public int? StartPosX { get; set; }
        public int? StartPosY { get; set; }
        public readonly int _drawWidth;
        public readonly int _drawHeight;

		protected DrawingTruck(int drawWidth, int drawHeight)
		{
			_drawWidth = drawWidth;
			_drawHeight = drawHeight;
			StartPosX = null;
			StartPosY = null;
		}

		public DrawingTruck(int speed, double weight, Color bodyColor)
		{
			_drawWidth = 130;
			_drawHeight = 45;
			StartPosX = null;
			StartPosY = null;
		}

		public void SetPosition(int x, int y)
		{
			StartPosX = x;
			StartPosY = y;
		}

		public void MoveLeft()
		{
			if (EntityTruck == null || StartPosX == null) return;
			StartPosX -= (int)EntityTruck.Step;
		}

		public void MoveRight()
		{
			if (EntityTruck == null || StartPosX == null) return;
			StartPosX += (int)EntityTruck.Step;
		}

		public void MoveUp()
		{
			if (EntityTruck == null || StartPosY == null) return;
			StartPosY -= (int)EntityTruck.Step;
		}

		public void MoveDown()
		{
			if (EntityTruck == null || StartPosY == null) return;
			StartPosY += (int)EntityTruck.Step;
		}

		public virtual void DrawTransport(Graphics g)
		{
			if (EntityTruck == null || StartPosX == null || StartPosY == null)
				return;

			Pen pen = new Pen(Color.Black, 2);

			// Кабина
			g.FillRectangle(new SolidBrush(EntityTruck.BodyColor),
				StartPosX.Value, StartPosY.Value, 35, 40);

			// Бак
			g.FillEllipse(new SolidBrush(Color.Silver),
				StartPosX.Value + 40, StartPosY.Value + 15, 45, 22);
			g.DrawEllipse(pen, StartPosX.Value + 40, StartPosY.Value + 15, 45, 22);

			// Рама
			g.DrawRectangle(pen, StartPosX.Value, StartPosY.Value + 10, _drawWidth, _drawHeight - 10);

			// Колеса
			g.FillEllipse(Brushes.Black, StartPosX.Value + 5, StartPosY.Value + 45, 18, 18);
			g.FillEllipse(Brushes.Black, StartPosX.Value + 105, StartPosY.Value + 45, 18, 18);

			pen.Dispose();
		}

		// Публичные свойства для доступа
		public int? PosX => StartPosX;
		public int? PosY => StartPosY;
		public double? CarStep => EntityTruck?.Step;
		public int DrawWidth => _drawWidth;
		public int DrawHeight => _drawHeight;
		public int DrawingTruckWidth => _drawWidth;
		public int DrawingTruckHeight => _drawHeight;
		public double TruckStep => EntityTruck?.Step ?? 0;
	}
}