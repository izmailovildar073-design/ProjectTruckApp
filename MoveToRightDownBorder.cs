using ProjectTruckApp.MovementStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp.MovementStrategy
{
	public class MoveToRightDownBorder : BaseTemplateMovement
	{
		protected override bool IsTargetDestination()
		{
			ObjectCoordinates objParams = GetObjectCoordinates();
			if (objParams == null)
			{
				return false;
			}

			int? step = GetStep();
			if (!step.HasValue)
			{
				return false;
			}

			int targetX = FieldWidth - objParams.Width;
			int targetY = FieldHeight - objParams.Height;

			return Math.Abs(objParams.LeftBorder - targetX) <= step.Value &&
				   Math.Abs(objParams.TopBorder - targetY) <= step.Value;
		}

		protected override void MoveToTarget()
		{
			ObjectCoordinates objParams = GetObjectCoordinates();
			if (objParams == null)
			{
				return;
			}

			int? step = GetStep();
			if (!step.HasValue)
			{
				return;
			}

			int targetX = FieldWidth - objParams.Width;
			int targetY = FieldHeight - objParams.Height;

			int diffX = objParams.LeftBorder - targetX;
			if (Math.Abs(diffX) > step.Value)
			{
				if (diffX > 0)
				{
					MoveLeft();
				}
				else
				{
					MoveRight();
				}
			}

			int diffY = objParams.TopBorder - targetY;
			if (Math.Abs(diffY) > step.Value)
			{
				if (diffY > 0)
				{
					MoveUp();
				}
				else
				{
					MoveDown();
				}
			}
		}
	}
}