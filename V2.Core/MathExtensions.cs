using System;

namespace V2.Core;

public static class MathExtensions
{
	public static double CastToDecimalPlaces(this double doubleToCast, int decimalPlaces)
	{
		return Math.Round(doubleToCast * Math.Pow(10.0, decimalPlaces)) / Math.Pow(10.0, decimalPlaces);
	}

	public static float CastToDecimalPlaces(this float floatToCast, int decimalPlaces)
	{
		return (float)(Math.Round((double)floatToCast * Math.Pow(10.0, decimalPlaces)) / Math.Pow(10.0, decimalPlaces));
	}

	public static string ToPercentage(this double doubleToConvert, int maxDecimalPlaces = 0)
	{
		return (doubleToConvert * 100.0).CastToDecimalPlaces(maxDecimalPlaces) + "%";
	}

	public static string ToPercentage(this float floatToConvert, int maxDecimalPlaces = 0)
	{
		return (floatToConvert * 100f).CastToDecimalPlaces(maxDecimalPlaces) + "%";
	}
}
