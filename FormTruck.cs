using ProjectTruckApp;
using ProjectTruckApp.Drawnings;
using ProjectTruckApp.MovementStrategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTruckApp
{
	public partial class FormTruck : Form
	{
		private CanvasForTruck _canvas;
		private DirectionType _checkBordersState;
		private BaseTemplateMovement _templateMovement;

		public FormTruck()
		{
			InitializeComponent();

			// Инициализируем canvas с размерами pictureBox
			_canvas = new CanvasForTruck(pictureBoxField.Width, pictureBoxField.Height);
			_checkBordersState = DirectionType.None;
			_templateMovement = null;
		}

		private void Draw()
		{
			if (_canvas != null)
			{
				Bitmap bmp = _canvas.DrawCanvas();
				if (bmp != null)
					pictureBoxField.Image = bmp;
			}
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			CreateObject("DrawingTruck");
		}

		private void buttonCreateTanker_Click(object sender, EventArgs e)
		{
			CreateObject("DrawingTankerTruck");
		}

		private void CreateObject(string type)
		{
			// Проверяем что canvas инициализирован
			if (_canvas == null)
			{
				MessageBox.Show("Canvas не инициализирован!");
				return;
			}

			Random random = new Random();
			DrawingTruck drawingTruck = null;

			try
			{
				switch (type)
				{
					case "DrawingTruck":
						drawingTruck = new DrawingTruck(
							random.Next(50, 200),
							random.Next(800, 2500),
							Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
						break;

					case "DrawingTankerTruck":
						drawingTruck = new DrawingTankerTruck(
							random.Next(50, 200),
							random.Next(800, 2500),
							Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
							Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
							random.Next(0, 2) == 1,  // HasFuelTank
							random.Next(0, 2) == 1,  // HasSignalBeacon
							random.Next(0, 2) == 1); // HasWheelOrnament
						break;

					default:
						return;
				}

				if (_canvas.InsertTruck(drawingTruck))
				{
					_canvas.SetTruckPosition(random.Next(10, 50), random.Next(10, 50));

					// Включаем comboBox если он есть
					if (comboBoxPointOfDestination != null)
					{
						comboBoxPointOfDestination.Enabled = true;
						comboBoxPointOfDestination.SelectedIndex = -1;
					}

					Draw();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при создании объекта: " + ex.Message);
			}
		}

		private void buttonMove_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			string name = button != null ? button.Name : string.Empty;
			DirectionType direction = DirectionType.None;

			switch (name)
			{
				case "buttonUp": direction = DirectionType.Up; break;
				case "buttonDown": direction = DirectionType.Down; break;
				case "buttonLeft": direction = DirectionType.Left; break;
				case "buttonRight": direction = DirectionType.Right; break;
			}

			if (_canvas != null && _canvas.MoveTransport(direction))
			{
				Draw();
			}
		}

		private void buttonCheckBorders_Click(object sender, EventArgs e)
		{
			if (_canvas == null) return;

			Random random = new Random();
			switch (_checkBordersState)
			{
				case DirectionType.None:
				case DirectionType.Down:
					_canvas.SetTruckPosition(random.Next(10, 50) - 1000, random.Next(10, 50));
					_checkBordersState = DirectionType.Left;
					break;
				case DirectionType.Left:
					_canvas.SetTruckPosition(random.Next(10, 50), random.Next(10, 50) - 1000);
					_checkBordersState = DirectionType.Up;
					break;
				case DirectionType.Up:
					_canvas.SetTruckPosition(random.Next(10, 50) + pictureBoxField.Width, random.Next(10, 50));
					_checkBordersState = DirectionType.Right;
					break;
				case DirectionType.Right:
					_canvas.SetTruckPosition(random.Next(10, 50), random.Next(10, 50) + pictureBoxField.Height);
					_checkBordersState = DirectionType.Down;
					break;
			}
			Draw();
		}

		private void comboBoxPointOfDestination_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_canvas == null || comboBoxPointOfDestination == null)
				return;

			if (_canvas.DrawingTruck == null)
				return;

			switch (comboBoxPointOfDestination.SelectedIndex)
			{
				case 0:
					_templateMovement = new MoveToCenter();
					break;
				case 1:
					_templateMovement = new MoveToRightDownBorder();
					break;
				default:
					return;
			}

			if (_templateMovement != null)
			{
				_templateMovement.SetData(
					new MoveableAdapterTruck(_canvas.DrawingTruck),
					pictureBoxField.Width,
					pictureBoxField.Height);
				comboBoxPointOfDestination.Enabled = false;
			}
		}

		private void buttonMovementStep_Click(object sender, EventArgs e)
		{
			if (_templateMovement == null)
				return;

			_templateMovement.MakeStep();

			if (_templateMovement.IsFinishReached)
			{
				if (comboBoxPointOfDestination != null)
				{
					comboBoxPointOfDestination.Enabled = true;
					comboBoxPointOfDestination.SelectedIndex = -1;
				}
			}

			Draw();
		}
	}
}