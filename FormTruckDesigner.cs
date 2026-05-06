using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp
{
	partial class FormTruck
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.pictureBoxField = new System.Windows.Forms.PictureBox();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.buttonCheckBorders = new System.Windows.Forms.Button();
			this.buttonUp = new System.Windows.Forms.Button();
			this.buttonDown = new System.Windows.Forms.Button();
			this.buttonLeft = new System.Windows.Forms.Button();
			this.buttonRight = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxField
			// 
			this.pictureBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxField.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxField.Name = "pictureBoxField";
			this.pictureBoxField.Size = new System.Drawing.Size(900, 550);
			this.pictureBoxField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxField.TabIndex = 0;
			this.pictureBoxField.TabStop = false;
			// 
			// buttonCreate
			// 
			this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCreate.Location = new System.Drawing.Point(12, 500);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(100, 30);
			this.buttonCreate.TabIndex = 1;
			this.buttonCreate.Text = "Создать";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// buttonCheckBorders
			// 
			this.buttonCheckBorders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCheckBorders.Location = new System.Drawing.Point(12, 12);
			this.buttonCheckBorders.Name = "buttonCheckBorders";
			this.buttonCheckBorders.Size = new System.Drawing.Size(130, 30);
			this.buttonCheckBorders.TabIndex = 2;
			this.buttonCheckBorders.Text = "Проверка границ";
			this.buttonCheckBorders.UseVisualStyleBackColor = true;
			this.buttonCheckBorders.Click += new System.EventHandler(this.buttonCheckBorders_Click);
			// 
			// buttonUp
			// 
			this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUp.Location = new System.Drawing.Point(820, 450);
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.Size = new System.Drawing.Size(30, 30);
			this.buttonUp.TabIndex = 3;
			this.buttonUp.Text = "↑";
			this.buttonUp.UseVisualStyleBackColor = true;
			this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
			// 
			// buttonDown
			// 
			this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDown.Location = new System.Drawing.Point(820, 510);
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.Size = new System.Drawing.Size(30, 30);
			this.buttonDown.TabIndex = 4;
			this.buttonDown.Text = "↓";
			this.buttonDown.UseVisualStyleBackColor = true;
			this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
			// 
			// buttonLeft
			// 
			this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLeft.Location = new System.Drawing.Point(760, 510);
			this.buttonLeft.Name = "buttonLeft";
			this.buttonLeft.Size = new System.Drawing.Size(30, 30);
			this.buttonLeft.TabIndex = 5;
			this.buttonLeft.Text = "←";
			this.buttonLeft.UseVisualStyleBackColor = true;
			this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
			// 
			// buttonRight
			// 
			this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRight.Location = new System.Drawing.Point(880, 510);
			this.buttonRight.Name = "buttonRight";
			this.buttonRight.Size = new System.Drawing.Size(30, 30);
			this.buttonRight.TabIndex = 6;
			this.buttonRight.Text = "→";
			this.buttonRight.UseVisualStyleBackColor = true;
			this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
			// 
			// FormTruck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 550);
			this.Controls.Add(this.buttonRight);
			this.Controls.Add(this.buttonLeft);
			this.Controls.Add(this.buttonDown);
			this.Controls.Add(this.buttonUp);
			this.Controls.Add(this.buttonCheckBorders);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.pictureBoxField);
			this.Name = "FormTruck";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Бензовоз - Трекинг";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).EndInit();
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.PictureBox pictureBoxField;
		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.Button buttonCheckBorders;
		private System.Windows.Forms.Button buttonUp;
		private System.Windows.Forms.Button buttonDown;
		private System.Windows.Forms.Button buttonLeft;
		private System.Windows.Forms.Button buttonRight;
		private System.Windows.Forms.ComboBox comboBoxPointOfDestination;
		private System.Windows.Forms.Button buttonMovementStep;
	}
}