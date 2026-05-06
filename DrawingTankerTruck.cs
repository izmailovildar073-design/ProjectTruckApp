using ProjectTruckApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTruckApp.Entities;

namespace ProjectTruckApp.Drawnings
{
	public class DrawingTankerTruck : DrawingTruck
	{
		public DrawingTankerTruck(int speed, double weight, Color bodyColor,
			Color additionalColor, bool hasFuelTank, bool hasSignalBeacon, bool hasWheelOrnament)
			: base(140, 70)
		{
			EntityTruck = new EntityTankerTruck(speed, weight, bodyColor,
				additionalColor, hasFuelTank, hasSignalBeacon, hasWheelOrnament);
		}

		public override void DrawTransport(Graphics g)
		{
			if (EntityTruck == null || StartPosX == null || StartPosY == null)
				return;

			var tankerTruck = EntityTruck as EntityTankerTruck;
			if (tankerTruck == null)
				return;

			Pen pen = new Pen(Color.Black, 2);
			Brush additionalBrush = new SolidBrush(tankerTruck.AdditionalColor);

			// Рисуем колеса
			DrawWheels(g, pen, tankerTruck);

			// Рисуем раму
			g.DrawRectangle(pen, StartPosX.Value, StartPosY.Value + 20, 130, 40);
			g.FillRectangle(new SolidBrush(EntityTruck.BodyColor),
				StartPosX.Value, StartPosY.Value + 20, 130, 40);

			// Рисуем кабину
			g.DrawRectangle(pen, StartPosX.Value + 90, StartPosY.Value, 40, 35);
			g.FillRectangle(new SolidBrush(EntityTruck.BodyColor),
				StartPosX.Value + 90, StartPosY.Value, 40, 35);

			// Окна кабины
			Brush windowBrush = new SolidBrush(Color.LightBlue);
			g.FillRectangle(windowBrush, StartPosX.Value + 95, StartPosY.Value + 5, 30, 15);
			g.DrawRectangle(pen, StartPosX.Value + 95, StartPosY.Value + 5, 30, 15);

			// Сигнальный маяк
			if (tankerTruck.HasSignalBeacon)
			{
				g.FillEllipse(new SolidBrush(Color.Red), StartPosX.Value + 100,
					StartPosY.Value - 8, 12, 12);
				g.DrawEllipse(pen, StartPosX.Value + 100, StartPosY.Value - 8, 12, 12);
			}

			// Топливный бак
			if (tankerTruck.HasFuelTank)
			{
				g.DrawEllipse(pen, StartPosX.Value + 5, StartPosY.Value + 15, 70, 30);
				g.FillEllipse(additionalBrush, StartPosX.Value + 5,
					StartPosY.Value + 15, 70, 30);
			}

			pen.Dispose();
			additionalBrush.Dispose();
		}

		private void DrawWheels(Graphics g, Pen pen, EntityTankerTruck tankerTruck)
		{
			int wheelY = StartPosY.Value + 50;
			Brush wheelBrush = Brushes.Black;
			Brush ornamentBrush = new SolidBrush(tankerTruck.AdditionalColor);

			// Заднее колесо
			g.FillEllipse(wheelBrush, StartPosX.Value + 10, wheelY, 20, 20);
			g.DrawEllipse(pen, StartPosX.Value + 10, wheelY, 20, 20);

			if (tankerTruck.HasWheelOrnament)
			{
				DrawWheelOrnament(g, ornamentBrush, StartPosX.Value + 20, wheelY + 10);
			}

			// Переднее колесо
			g.FillEllipse(wheelBrush, StartPosX.Value + 100, wheelY, 20, 20);
			g.DrawEllipse(pen, StartPosX.Value + 100, wheelY, 20, 20);

			if (tankerTruck.HasWheelOrnament)
			{
				DrawWheelOrnament(g, ornamentBrush, StartPosX.Value + 110, wheelY + 10);
			}

			ornamentBrush.Dispose();
		}

		private void DrawWheelOrnament(Graphics g, Brush brush, int centerX, int centerY)
		{
			int size = 6;
			g.FillRectangle(brush, centerX - size / 2, centerY - size / 2, size, size);
			g.DrawLine(Pens.Silver, centerX - 8, centerY, centerX + 8, centerY);
			g.DrawLine(Pens.Silver, centerX, centerY - 8, centerX, centerY + 8);
		}
	}
}