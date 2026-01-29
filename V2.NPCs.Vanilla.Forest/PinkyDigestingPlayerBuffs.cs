using System.Linq;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.NPCs.Vanilla.Forest;

public class PinkyDigestingPlayerBuffs : ModPlayer
{
	public override void PreUpdateBuffs()
	{
		PreyData pinkyPrey = ((ModPlayer)this).Player.AsPred().StomachTracker?.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == -4);
		if (pinkyPrey != null)
		{
			((Entity)(object)((ModPlayer)this).Player).AddStatus(146, Pinky.EatenHappyLength, fromDigestingSomething: true);
			if (pinkyPrey.NoHealth)
			{
				((Entity)(object)((ModPlayer)this).Player).AddStatus(2, Pinky.DigestedRegenTime, fromDigestingSomething: true);
			}
		}
	}
}
