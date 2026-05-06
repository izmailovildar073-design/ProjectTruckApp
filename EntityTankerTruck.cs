using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp.Entities
{
    public class EntityTankerTruck : EntityTruck
    {
        public Color AdditionalColor { get; private set; }
        public bool HasFuelTank { get; private set; }
        public bool HasSignalBeacon { get; private set; }
        public bool HasWheelOrnament { get; private set; }

        public EntityTankerTruck(
            int speed, 
            double weight, 
            Color bodyColor,
            Color additionalColor, 
            bool hasFuelTank, 
            bool hasSignalBeacon, 
            bool hasWheelOrnament)
            : base(speed, weight, bodyColor)
        {
            AdditionalColor = additionalColor;
            HasFuelTank = hasFuelTank;
            HasSignalBeacon = hasSignalBeacon;
            HasWheelOrnament = hasWheelOrnament;
        }
    }
}