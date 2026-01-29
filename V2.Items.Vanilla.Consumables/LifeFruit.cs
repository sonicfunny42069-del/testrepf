using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using V2.Core;
using V2.Sounds.Vore;

namespace V2.Items.Vanilla.Consumables;

public class LifeFruit : GlobalItem
{
	public static int DigestedHeal => 50;

	public static int DigestedRegenTime => V2Utils.SensibleTime(0, 1, 30);

	public static int StomachStrengthBonus => 2;

	public static int AcidStrengthBonus => 2;

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 1291;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 500;
		item.AsFood().Size = 0.34;
		PreyItem preyItem = item.AsFood();
		preyItem.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
		PreyItem preyItem2 = item.AsFood();
		preyItem2.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem2.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
		item.AsFood().EdibleOnUse = true;
		item.AsFood().AlwaysEatenByUse = true;
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
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		Player playerPred = (Player)(object)((pred is Player) ? pred : null);
		if (playerPred != null)
		{
			if (playerPred.ConsumedLifeFruit < 20 && playerPred.ConsumedLifeCrystals == 15)
			{
				int lifeFruitLeftToMax = Math.Min(item.stack, 20 - playerPred.ConsumedLifeFruit);
				playerPred.statLifeMax += 5 * lifeFruitLeftToMax;
				playerPred.statLifeMax2 += 5 * lifeFruitLeftToMax;
				playerPred.ConsumedLifeFruit += lifeFruitLeftToMax;
			}
			playerPred.Heal(DigestedHeal * item.stack);
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
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		Player player = Main.LocalPlayer;
		Color lifeFruitUsedColor = Color.Lerp(Color.DarkGoldenrod, Color.Goldenrod, (float)player.ConsumedLifeFruit / 20f);
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Consumables.LifeFruit", new
		{
			LifeFruitEatHeal = DigestedHeal,
			LifeFruitEatRegenLength = ((double)DigestedRegenTime / 60.0).CastToDecimalPlaces(2),
			LifeFruitHealthBonusColor = Utils.Hex3(Color.Goldenrod),
			LifeFruitStomachStrengthBonus = StomachStrengthBonus,
			LifeFruitAcidStrengthBonus = AcidStrengthBonus,
			LifeFruitUsedColor = Utils.Hex3(lifeFruitUsedColor * ((float)(int)Main.mouseTextColor / 255f)),
			LifeFruitUsed = player.ConsumedLifeFruit,
			LifeFruitMax = 20
		});
	}
}
