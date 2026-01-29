using System.Linq;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Vanilla.Forest;

public class PinkyDigestingNPCBuffs : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override void ResetEffects(NPC npc)
	{
		PreyData pinkyPrey = PredNPC.GetStomachTracker(npc)?.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == -4);
		if (pinkyPrey != null)
		{
			((Entity)(object)npc).AddStatus(146, Pinky.EatenHappyLength, fromDigestingSomething: true);
			if (pinkyPrey.NoHealth)
			{
				((Entity)(object)npc).AddStatus(2, Pinky.DigestedRegenTime, fromDigestingSomething: true);
			}
		}
	}
}
