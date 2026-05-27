using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectTruckApp
{
	public abstract class EntityTruck
	{
		public EntityTruck(int speed, double weight, Color bodyColor, string v)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
		}

        protected EntityTruck(int speed, double weight, Color bodyColor)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
        }

        // Добавьте этот метод!
        public abstract EntityTruck Clone();

        public int Speed { get; private set; }
		public double Weight { get; private set; }
		public Color BodyColor { get; private set; }
		public int WheelCount { get; private set; }
		public double Step => Speed * 100.0 / Weight;
		public void Init(int speed, double weight, Color bodyColor, int wheelCount)
		{
			Speed = speed;
			Weight = weight;
			BodyColor = bodyColor;
			WheelCount = wheelCount;
		}
	}
}