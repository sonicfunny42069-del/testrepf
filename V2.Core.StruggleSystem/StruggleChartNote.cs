using System;

namespace V2.Core.StruggleSystem;

public class StruggleChartNote
{
	private int _holdLength;

	private double _position;

	public NoteLane Lane { get; private set; }

	public int HoldLength
	{
		get
		{
			return _holdLength;
		}
		private set
		{
			_holdLength = Math.Max(value, 0);
		}
	}

	public double Position
	{
		get
		{
			return _position;
		}
		private set
		{
			_position = Math.Max(value, 0.0);
		}
	}

	public bool Bad { get; private set; }

	public bool Failed { get; set; }

	public bool CorrectlyPressed { get; set; }

	public double PressedPosition { get; set; }

	public int PressAnimTimer { get; set; }

	public StruggleChartNote(NoteLane lane, int holdLength = 0, bool bad = false)
	{
		Lane = lane;
		HoldLength = holdLength;
		Bad = bad;
		Position = 0.0;
		CorrectlyPressed = false;
		PressedPosition = 0.0;
		PressAnimTimer = 0;
	}
}
