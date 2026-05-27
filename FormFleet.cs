using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectTruckApp.Drawnings;
using ProjectTruckApp.Storage;

namespace ProjectTruckApp
{
    public class FormFleet : Form
    {
        private MassiveGenericObjects<DrawingTruck> _fleet;
        private int _selectedIndex = -1;
        private const int Columns = 4;
        private const int Rows = 5;
        private const int CellWidth = 150;
        private const int CellHeight = 100;

        public FormFleet()
        {
            _fleet = new MassiveGenericObjects<DrawingTruck>(20);
            this.Text = "Коллекция автомобилей";
            this.Size = new Size(660, 640);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            SetupUI();
        }

        private void SetupUI()
        {
            // Панель для рисования (сетка)
            Panel canvasPanel = new Panel();
            canvasPanel.Name = "CanvasPanel";
            canvasPanel.Location = new Point(12, 12);
            canvasPanel.Size = new Size(Columns * CellWidth + (Columns - 1) * 10 + 4,
                                        Rows * CellHeight + (Rows - 1) * 10 + 4);
            canvasPanel.BorderStyle = BorderStyle.FixedSingle;
            canvasPanel.BackColor = Color.White;
            canvasPanel.Paint += CanvasPanel_Paint;
            canvasPanel.MouseClick += CanvasPanel_MouseClick;
            this.Controls.Add(canvasPanel);

            // Панель кнопок
            Panel buttonPanel = new Panel();
            buttonPanel.Location = new Point(12, canvasPanel.Bottom + 10);
            buttonPanel.Size = new Size(canvasPanel.Width, 50);
            this.Controls.Add(buttonPanel);

            // Кнопки (ровные, одинакового размера)
            int buttonWidth = 120;
            int buttonHeight = 35;
            int buttonSpacing = 10;
            int totalButtonsWidth = 5 * buttonWidth + 4 * buttonSpacing;
            int startX = (canvasPanel.Width - totalButtonsWidth) / 2;

            Button btnAddTruck = CreateButton("Добавить грузовик", startX, 0, buttonWidth, buttonHeight, BtnAddTruck_Click);
            Button btnAddTanker = CreateButton("Добавить бензовоз", startX + buttonWidth + buttonSpacing, 0, buttonWidth, buttonHeight, BtnAddTanker_Click);
            Button btnDelete = CreateButton("Удалить", startX + 2 * (buttonWidth + buttonSpacing), 0, buttonWidth, buttonHeight, BtnDelete_Click);
            Button btnTest = CreateButton("Передать на тесты", startX + 3 * (buttonWidth + buttonSpacing), 0, buttonWidth, buttonHeight, BtnTest_Click);
            Button btnRefresh = CreateButton("Обновить", startX + 4 * (buttonWidth + buttonSpacing), 0, buttonWidth, buttonHeight, BtnRefresh_Click);

            buttonPanel.Controls.Add(btnAddTruck);
            buttonPanel.Controls.Add(btnAddTanker);
            buttonPanel.Controls.Add(btnDelete);
            buttonPanel.Controls.Add(btnTest);
            buttonPanel.Controls.Add(btnRefresh);
        }

        private Button CreateButton(string text, int x, int y, int width, int height, EventHandler clickHandler)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(width, height);
            btn.FlatStyle = FlatStyle.Standard;
            btn.Click += clickHandler;
            return btn;
        }

        private void CanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Panel panel = sender as Panel;

            // Рисуем сетку ячеек
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    int x = col * (CellWidth + 10) + 2;
                    int y = row * (CellHeight + 10) + 2;

                    // Рисуем рамку ячейки
                    Rectangle cellRect = new Rectangle(x, y, CellWidth, CellHeight);
                    g.DrawRectangle(Pens.Black, cellRect);

                    // Если есть объект - рисуем его
                    int index = row * Columns + col;
                    if (index < _fleet.Count)
                    {
                        DrawingTruck truck = _fleet.Get(index);
                        if (truck != null)
                        {
                            // Центрируем грузовик в ячейке
                            int truckX = x + (CellWidth - truck.DrawWidth) / 2;
                            int truckY = y + (CellHeight - truck.DrawHeight) / 2;

                            truck.StartPosX = truckX;
                            truck.StartPosY = truckY;
                            truck.DrawTransport(g);
                        }
                    }
                }
            }
        }

        private void CanvasPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // Определяем индекс ячейки по клику
            int col = (e.X - 2) / (CellWidth + 10);
            int row = (e.Y - 2) / (CellHeight + 10);
            int index = row * Columns + col;

            if (index >= 0 && index < _fleet.Count)
            {
                _selectedIndex = index;
                this.Controls["CanvasPanel"].Invalidate();
            }
        }

        private void BtnAddTruck_Click(object sender, EventArgs e)
        {
            if (_fleet.Count >= Rows * Columns)
            {
                MessageBox.Show("Нет свободных мест!");
                return;
            }

            Random random = new Random();
            Color bodyColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            DrawingStandardTruck truck = new DrawingStandardTruck(
                random.Next(50, 200),
                random.Next(800, 2500),
                bodyColor);

            if (_fleet.Insert(truck, _fleet.Count))
                this.Controls["CanvasPanel"].Invalidate();
        }

        private void BtnAddTanker_Click(object sender, EventArgs e)
        {
            if (_fleet.Count >= Rows * Columns)
            {
                MessageBox.Show("Нет свободных мест!");
                return;
            }

            Random random = new Random();
            Color bodyColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            Color additionalColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            DrawingTankerTruck tanker = new DrawingTankerTruck(
                random.Next(50, 200),
                random.Next(800, 2500),
                bodyColor,
                additionalColor,
                random.Next(0, 2) == 1,
                random.Next(0, 2) == 1,
                random.Next(0, 2) == 1);

            if (_fleet.Insert(tanker, _fleet.Count))
                this.Controls["CanvasPanel"].Invalidate();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedIndex >= 0 && _fleet.Remove(_selectedIndex))
            {
                _selectedIndex = -1;
                this.Controls["CanvasPanel"].Invalidate();
            }
            else
            {
                MessageBox.Show("Выберите автомобиль для удаления (кликните на ячейку)!");
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (_selectedIndex >= 0 && _selectedIndex < _fleet.Count)
            {
                DrawingTruck selectedTruck = _fleet.Get(_selectedIndex);
                if (selectedTruck != null)
                {
                    DrawingTruck truckClone = CloneTruck(selectedTruck);
                    FormTests testForm = new FormTests(truckClone);
                    testForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Выберите автомобиль для тестирования (кликните на ячейку)!");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.Controls["CanvasPanel"].Invalidate();
        }

        private DrawingTruck CloneTruck(DrawingTruck original)
        {
            if (original is DrawingStandardTruck std)
            {
                var entity = std.EntityTruck as Entities.EntityStandardTruck;
                return new DrawingStandardTruck(entity.Speed, entity.Weight, entity.BodyColor);
            }
            else if (original is DrawingTankerTruck tanker)
            {
                var entity = tanker.EntityTruck as Entities.EntityTankerTruck;
                return new DrawingTankerTruck(
                    entity.Speed, entity.Weight, entity.BodyColor,
                    entity.AdditionalColor, entity.HasFuelTank,
                    entity.HasSignalBeacon, entity.HasWheelOrnament);
            }
            return null;
        }
    }
}