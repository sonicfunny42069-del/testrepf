using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Core.StruggleSystem;

public class ProceduralStruggleChart : StruggleChart
{
	public override List<StruggleChartNote[]> Notes => RandomNoteSpan;

	private List<StruggleChartNote[]> RandomNoteSpan { get; set; }

	private static int MaxRandomNoteSpanLength => 128;

	public override void OnStartup()
	{
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		RandomNoteSpan = new List<StruggleChartNote[]>();
		if (base.ConnectedTracker == null)
		{
			return;
		}
		int notesAdded = 0;
		for (int i = 0; i < MaxRandomNoteSpanLength; i++)
		{
			StruggleChartNote[] noteSet = new StruggleChartNote[5];
			if ((double)Utils.NextFloat(Main.rand, 3f) <= base.DifficultyCoeff)
			{
				List<NoteLane> lanes = new List<NoteLane>
				{
					NoteLane.Up,
					NoteLane.Left,
					NoteLane.Right,
					NoteLane.Down
				};
				NoteLane noteLaneToFill = Utils.NextFromCollection<NoteLane>(Main.rand, lanes);
				noteSet[(int)noteLaneToFill] = new StruggleChartNote(noteLaneToFill);
				notesAdded++;
				lanes.Remove(noteLaneToFill);
				if ((double)Utils.NextFloat(Main.rand, 3f) <= base.DifficultyCoeff - 0.4000000059604645)
				{
					noteLaneToFill = Utils.NextFromCollection<NoteLane>(Main.rand, lanes);
					noteSet[(int)noteLaneToFill] = new StruggleChartNote(noteLaneToFill);
					notesAdded++;
					lanes.Remove(noteLaneToFill);
					if ((double)Utils.NextFloat(Main.rand, 3f) <= base.DifficultyCoeff - 0.800000011920929)
					{
						noteLaneToFill = Utils.NextFromCollection<NoteLane>(Main.rand, lanes);
						noteSet[(int)noteLaneToFill] = new StruggleChartNote(noteLaneToFill);
						notesAdded++;
						lanes.Remove(noteLaneToFill);
						if ((double)Utils.NextFloat(Main.rand, 3f) <= base.DifficultyCoeff - 1.2000000476837158)
						{
							noteLaneToFill = Utils.NextFromCollection<NoteLane>(Main.rand, lanes);
							noteSet[(int)noteLaneToFill] = new StruggleChartNote(noteLaneToFill);
							notesAdded++;
							lanes.Remove(noteLaneToFill);
						}
					}
				}
			}
			RandomNoteSpan.Add(noteSet);
		}
		if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
		{
			string debugText = "New procedural chart of difficulty " + base.DifficultyCoeff + " constructed for " + (base.ForPredator ? "a hungry pred" : "a soon-to-be meal") + " with " + notesAdded + " notes in total.";
			if (Main.netMode == 0)
			{
				Main.NewText((object)debugText, (Color?)Color.PaleVioletRed);
			}
			else if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(debugText), Color.PaleVioletRed, -1);
			}
		}
	}
}
