using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp
{

	/// <summary>
	/// Класс-сущность "Бензовоз"
	/// </summary>
	public class EntityTruck
	{
		public EntityTruck(int speed, double weight, Color bodyColor)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
		}

		public int Speed { get; private set; }
		public double Weight { get; private set; }
		public Color BodyColor { get; private set; }
		public int WheelCount { get; private set; }

		/// <summary>
		/// Шаг перемещения (зависит от скорости и веса)
		/// </summary>
		public double Step => Speed * 100.0 / Weight;

		/// <summary>
		/// Инициализация полей объекта
		/// </summary>
		public void Init(int speed, double weight, Color bodyColor, int wheelCount)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
			WheelCount = wheelCount;
		}
	}
}