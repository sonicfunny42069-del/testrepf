using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Consumables;

public class DigestionRepairScroll : ModItem
{
	public static double CooldownMax => V2Utils.SensibleTime(0, 24);

	public double Cooldown { get; set; }

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.DigestionRepairScroll");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.DigestionRepairScroll.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.consumable = false;
		((ModItem)this).Item.maxStack = 1;
		((ModItem)this).Item.AsFood().Size = 0.225;
		((ModItem)this).Item.AsFood().MaxHealth = 100;
		((ModItem)this).Item.AsFood().AcidResistTier = 99;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.value = Item.buyPrice(0, 10, 0, 0);
	}

	public override bool CanUseItem(Player player)
	{
		return Cooldown <= 0.0;
	}

	public override void Update(ref float gravity, ref float maxFallSpeed)
	{
		Cooldown -= 1.0;
		if (Cooldown <= 0.0)
		{
			Cooldown = 0.0;
		}
	}

	public override void UpdateInventory(Player player)
	{
		Cooldown -= 1.0;
		if (Cooldown <= 0.0)
		{
			Cooldown = 0.0;
		}
	}

	public override void UseAnimation(Player player)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		Cooldown = CooldownMax;
		for (int i = 0; i < 58; i++)
		{
			Item repairableItem = player.inventory[i];
			if (repairableItem.AsFood().MaxHealth != -1)
			{
				repairableItem.AsFood().Health = repairableItem.AsFood().MaxHealth;
			}
		}
		player.AsFood().SoftenedDigestionDamageTaken = 0.0;
		SoundStyle item = SoundID.Item35;
		((SoundStyle)(ref item)).Pitch = -0.5f;
		((SoundStyle)(ref item)).PitchVariance = 0f;
		SoundEngine.PlaySound(ref item, (Vector2?)((Entity)(object)player).TrueCenter(), (SoundUpdateCallback)null);
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		int minutes = (int)Math.Floor(Cooldown / 60.0);
		int seconds = (int)Math.Ceiling(Cooldown % 60.0);
		string remainingCooldownText = "[c/00FF00:Ready to use]";
		if (minutes > 0)
		{
			remainingCooldownText = ((minutes < 12) ? ("[c/FF7F00:On cooldown for " + minutes + "m" + ((seconds > 0) ? (seconds + "s") : "") + "]") : ("[c/FF0000:On cooldown for " + minutes + "m" + ((seconds > 0) ? (seconds + "s") : "") + "]"));
		}
		else if (seconds > 0)
		{
			remainingCooldownText = "[c/FFFF00:On cooldown for " + seconds + "s]";
		}
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.DigestionRepairScroll", new
		{
			RemainingCooldown = remainingCooldownText
		});
	}
}
