using System.Collections.Generic;

namespace V2.Core.StruggleSystem;

public static class StruggleChartLoader
{
	internal static List<StruggleChart> StruggleCharts { get; set; }

	public static void Load()
	{
		StruggleCharts = new List<StruggleChart> { StruggleChart.Default };
	}

	public static void Unload()
	{
		StruggleCharts = null;
	}
}
