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

public class ManaCrystal : GlobalItem
{
	public static int DigestedManaHeal => 100;

	public static int DigestedManaRegenTime => V2Utils.SensibleTime(0, 0, 2, 30);

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 109;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 200;
		item.AsFood().Size = 0.42;
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
			pred.AddStatus(6, DigestedManaRegenTime, fromDigestingSomething: true);
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
			if (playerPred.ConsumedManaCrystals < 9)
			{
				int manaCrystalsLeftToMax = Math.Min(item.stack, 9 - playerPred.ConsumedManaCrystals);
				playerPred.statManaMax += 20 * manaCrystalsLeftToMax;
				playerPred.statManaMax2 += 20 * manaCrystalsLeftToMax;
				playerPred.ConsumedManaCrystals += manaCrystalsLeftToMax;
			}
			playerPred.statMana += DigestedManaHeal * item.stack;
			if (playerPred.statMana > playerPred.statManaMax2)
			{
				playerPred.statMana = playerPred.statManaMax2;
			}
			ModContent.GetInstance<EatFirstManaCrystal>().TrySetCompletion(playerPred);
			if (playerPred.ConsumedLifeCrystals == 15 && playerPred.ConsumedManaCrystals == 9)
			{
				ModContent.GetInstance<EatMaxLifeAndManaCrystals>().TrySetCompletion(playerPred);
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
		Color manaCrystalsUsedColor = Color.Lerp(Color.DarkBlue, Color.CornflowerBlue, (float)player.ConsumedManaCrystals / 9f);
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Consumables.ManaCrystal", new
		{
			ManaCrystalEatManaHeal = DigestedManaHeal,
			ManaCrystalEatManaRegenLength = ((double)DigestedManaRegenTime / 60.0).CastToDecimalPlaces(2),
			ManaCrystalsUsedColor = Utils.Hex3(manaCrystalsUsedColor * ((float)(int)Main.mouseTextColor / 255f)),
			ManaCrystalsUsed = player.ConsumedManaCrystals,
			ManaCrystalsMax = 9
		});
	}
}
