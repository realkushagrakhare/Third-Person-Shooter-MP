using UnityEngine;

namespace Lean.Touch
{
	// This script allows you to select LeanSelectable components while a finger is down
	public class LeanPressSelect : LeanSelect
	{
		[Tooltip("Ignore fingers with StartedOverGui?")]
		public bool IgnoreGuiFingers = true;
		
		protected virtual void OnEnable()
		{
			// Hook events
			LeanTouch.OnFingerDown += FingerDown;
			LeanTouch.OnFingerUp   += FingerUp;
		}
		
		protected virtual void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerDown -= FingerDown;
			LeanTouch.OnFingerUp   -= FingerUp;
		}
		
		private void FingerDown(LeanFinger finger)
		{
			// Ignore this finger?
			if (IgnoreGuiFingers == true && finger.StartedOverGui == true)
			{
				return;
			}

			if (CurrentSelectable != null && CurrentSelectable.SelectingFinger != null)
			{
				return;
			}

			// Try and select
			Select(finger);
		}

		private void FingerUp(LeanFinger finger)
		{
			if (CurrentSelectable != null)
			{
				if (CurrentSelectable.SelectingFinger == finger || CurrentSelectable.SelectingFinger == null)
				{
					Deselect();
				}
			}
		}
	}
}