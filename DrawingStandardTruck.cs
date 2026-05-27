using System.Drawing;
using ProjectTruckApp.Entities;
using ProjectTruckApp.Drawnings;

namespace ProjectTruckApp.Drawnings
{
    public class DrawingStandardTruck : DrawingTruck
    {
        public DrawingStandardTruck(int speed, double weight, Color bodyColor)
            : base(100, 50) // Размеры обычной машины (меньше чем у бензовоза)
        {
            EntityTruck = new EntityStandardTruck(speed, weight, bodyColor);
        }

        public override void DrawTransport(Graphics g)
        {
            if (EntityTruck == null || StartPosX == null || StartPosY == null)
                return;

            int x = StartPosX.Value;
            int y = StartPosY.Value;

            Pen pen = new Pen(Color.Black, 2);

            // Кабина
            g.DrawRectangle(pen, x + 60, y, 40, 40);
            g.FillRectangle(new SolidBrush(EntityTruck.BodyColor), x + 60, y, 40, 40);

            // Окно
            g.FillRectangle(Brushes.LightBlue, x + 65, y + 5, 30, 15);
            g.DrawRectangle(pen, x + 65, y + 5, 30, 15);

            // Кузов
            g.DrawRectangle(pen, x, y + 10, 60, 30);
            g.FillRectangle(new SolidBrush(Color.Gray), x, y + 10, 60, 30);

            // Колеса
            g.FillEllipse(Brushes.Black, x + 10, y + 35, 18, 18);
            g.DrawEllipse(pen, x + 10, y + 35, 18, 18);
            g.FillEllipse(Brushes.Black, x + 75, y + 35, 18, 18);
            g.DrawEllipse(pen, x + 75, y + 35, 18, 18);

            pen.Dispose();
        }
    }
}