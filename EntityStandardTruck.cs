using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectTruckApp.Entities
{
    public class EntityStandardTruck : EntityTruck
    {
        public EntityStandardTruck(int speed, double weight, Color bodyColor)
            : base(speed, weight, bodyColor, "Грузовик")
        {
        }

        public override EntityTruck Clone()
        {
            return new EntityStandardTruck(Speed, Weight, BodyColor);
        }
    }
}