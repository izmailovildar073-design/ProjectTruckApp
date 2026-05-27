using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectTruckApp.Drawnings;


namespace ProjectTruckApp
{
    public class FormTests : Form
    {
        private DrawingTruck _truck;
        private int _posX = 50;
        private int _posY = 50;

        public FormTests(DrawingTruck truck)
        {
            _truck = truck;
            this.Text = "Тестирование автомобиля";
            this.Size = new System.Drawing.Size(400, 300);
            this.DoubleBuffered = true;
            SetupUI();
        }

        private void SetupUI()
        {
            Panel canvasPanel = new Panel();
            canvasPanel.Location = new Point(10, 10);
            canvasPanel.Size = new Size(300, 200);
            canvasPanel.BorderStyle = BorderStyle.FixedSingle;
            canvasPanel.BackColor = Color.White;
            canvasPanel.Paint += CanvasPanel_Paint;
            this.Controls.Add(canvasPanel);

            Button btnUp = CreateButton("↑", 320, 10, (s, e) => MoveTruck(0, -10));
            Button btnLeft = CreateButton("←", 320, 50, (s, e) => MoveTruck(-10, 0));
            Button btnRight = CreateButton("→", 350, 50, (s, e) => MoveTruck(10, 0));
            Button btnDown = CreateButton("↓", 320, 90, (s, e) => MoveTruck(0, 10));

            this.Controls.Add(btnUp);
            this.Controls.Add(btnLeft);
            this.Controls.Add(btnRight);
            this.Controls.Add(btnDown);
        }

        private Button CreateButton(string text, int x, int y, EventHandler clickHandler)
        {
            var button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(30, 30);
            button.Click += clickHandler;
            return button;
        }

        private void MoveTruck(int dx, int dy)
        {
            Panel panel = this.Controls[0] as Panel;
            _posX = Math.Max(0, Math.Min(panel.Width - _truck.DrawWidth, _posX + dx));
            _posY = Math.Max(0, Math.Min(panel.Height - _truck.DrawHeight, _posY + dy));

            _truck.StartPosX = _posX;
            _truck.StartPosY = _posY;
            panel.Invalidate();
        }

        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            _truck.DrawTransport(e.Graphics);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormTests
            // 
            this.ClientSize = new System.Drawing.Size(1502, 636);
            this.Name = "FormTests";
            this.Load += new System.EventHandler(this.FormTests_Load);
            this.ResumeLayout(false);

        }

        private void FormTests_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }
    }
}