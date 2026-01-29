using System.Collections.Generic;

namespace V2.NPCs;

public static class NPCChatHelper
{
	public static void AddHumanoidPredMessages(this List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.HumanoidPred.1", "Mods.V2.Death.DigestedPlayer.HumanoidPred.2", "Mods.V2.Death.DigestedPlayer.HumanoidPred.3", "Mods.V2.Death.DigestedPlayer.HumanoidPred.4", "Mods.V2.Death.DigestedPlayer.HumanoidPred.5" });
	}
}
