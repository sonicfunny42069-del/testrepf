using System;
using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.NPCs.Vanilla.Jungle;

public class ManEater : GlobalNPC
{
	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 43;
	}

	public override void SetDefaults(NPC entity)
	{
		PreyNPC preyNPC = entity.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnDigestedBy));
	}

	private static void OnDigestedBy(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatTheManEater>().TrySetCompletion(predPlayer);
		}
	}
}
