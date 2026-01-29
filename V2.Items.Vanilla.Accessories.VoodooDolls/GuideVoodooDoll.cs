using System;
using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling.PredPlayerGoals.Amateur;

namespace V2.Items.Vanilla.Accessories.VoodooDolls;

public class GuideVoodooDoll : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 267;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 250;
		item.AsFood().Size = 0.25;
		PreyItem preyItem = item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak_GrantVoodooDigestionGoal));
	}

	public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			NPC npc = enumerator.Current;
			if (npc.type == 22)
			{
				item.AsFood().Health = npc.life;
				break;
			}
		}
	}

	public static bool OnBreak_GrantVoodooDigestionGoal(Item item, Entity pred, bool direct)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<DigestWithVoodoo>().TrySetCompletion(predPlayer);
		}
		return true;
	}
}
