using ProjectTruckApp.MovementStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTruckApp.MovementStrategy
{
	public class MoveToCenter : BaseTemplateMovement
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

			return Math.Abs(objParams.ObjectMiddleHorizontal - FieldWidth / 2) <= step.Value &&
				   Math.Abs(objParams.ObjectMiddleVertical - FieldHeight / 2) <= step.Value;
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

			int diffX = objParams.ObjectMiddleHorizontal - FieldWidth / 2;
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

			int diffY = objParams.ObjectMiddleVertical - FieldHeight / 2;
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