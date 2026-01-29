using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling.PredPlayerGoals.Amateur;
using V2.PlayerHandling.PredPlayerGoals.Beginner;
using V2.Sounds.MuffledSounds;
using V2.Sounds.Vore;

namespace V2.Items.Vanilla.Consumables;

public class LifeCrystal : GlobalItem
{
	public static int DigestedHeal => 25;

	public static int DigestedRegenTime => V2Utils.SensibleTime(0, 0, 35);

	public static float MaxEatenPermaWeightReduction => 0.15f;

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 29;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 400;
		item.AsFood().Size = 0.45;
		PreyItem preyItem = item.AsFood();
		preyItem.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
		PreyItem preyItem2 = item.AsFood();
		preyItem2.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem2.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
		item.AsFood().EdibleOnUse = true;
	}

	public static void UpdateInStomach(Entity prey, Entity pred, bool dead)
	{
		if (dead)
		{
			pred.AddStatus(2, DigestedRegenTime, fromDigestingSomething: true);
		}
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(ref MuffledMiscSounds.Shatter, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		Player playerPred = (Player)(object)((pred is Player) ? pred : null);
		if (playerPred != null)
		{
			if (playerPred.ConsumedLifeCrystals < 15)
			{
				int lifeCrystalsLeftToMax = Math.Min(item.stack, 15 - playerPred.ConsumedLifeCrystals);
				playerPred.statLifeMax += 20 * lifeCrystalsLeftToMax;
				playerPred.statLifeMax2 += 20 * lifeCrystalsLeftToMax;
				playerPred.ConsumedLifeCrystals += lifeCrystalsLeftToMax;
			}
			playerPred.Heal(DigestedHeal * item.stack);
			ModContent.GetInstance<EatFirstLifeCrystal>().TrySetCompletion(playerPred);
			if (playerPred.ConsumedLifeCrystals == 15 && playerPred.ConsumedManaCrystals == 9)
			{
				ModContent.GetInstance<EatMaxLifeAndManaCrystals>().TrySetCompletion(playerPred);
			}
		}
		else
		{
			NPC NPCPred = (NPC)(object)((pred is NPC) ? pred : null);
			if (NPCPred != null)
			{
				NPCPred.life += DigestedHeal * item.stack;
				if (NPCPred.life > NPCPred.lifeMax)
				{
					NPCPred.life = NPCPred.lifeMax;
				}
			}
		}
		return true;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		Player player = Main.LocalPlayer;
		Color lifeCrystalsUsedColor = Color.Lerp(Color.DarkRed, Color.HotPink, (float)player.ConsumedLifeCrystals / 15f);
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Consumables.LifeCrystal", new
		{
			LifeCrystalEatHeal = DigestedHeal,
			LifeCrystalEatRegenLength = ((double)DigestedRegenTime / 60.0).CastToDecimalPlaces(2),
			LifeCrystalsUsedColor = Utils.Hex3(lifeCrystalsUsedColor * ((float)(int)Main.mouseTextColor / 255f)),
			LifeCrystalsUsed = player.ConsumedLifeCrystals,
			MaxLifeCrystalsPermaWeightReduction = MaxEatenPermaWeightReduction.CastToDecimalPlaces(2),
			LifeCrystalsMax = 15
		});
	}
}
