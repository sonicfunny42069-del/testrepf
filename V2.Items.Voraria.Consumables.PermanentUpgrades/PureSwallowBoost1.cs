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
using V2.Sounds.MuffledSounds;
using V2.Sounds.Vore;

namespace V2.Items.Voraria.Consumables.PermanentUpgrades;

public class PureSwallowBoost1 : ModItem
{
	public static int GLPBonus => 8;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.PermanentUpgrades.PureSwallowBoost1");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.PermanentUpgrades.PureSwallowBoost1.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.ResearchUnlockCount = 1;
		Sets.DrinkParticleColors[((ModItem)this).Type] = (Color[])(object)new Color[3]
		{
			new Color(121, 255, 76),
			new Color(121, 255, 76),
			new Color(50, 191, 38)
		};
	}

	public override void SetDefaults()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		((Entity)((ModItem)this).Item).width = 20;
		((Entity)((ModItem)this).Item).height = 26;
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((ModItem)this).Item.UseSound = SoundID.Item3;
		((ModItem)this).Item.useStyle = 9;
		((ModItem)this).Item.useTurn = true;
		((ModItem)this).Item.useAnimation = 17;
		((ModItem)this).Item.useTime = 17;
		((ModItem)this).Item.consumable = true;
		((ModItem)this).Item.value = Item.sellPrice(0, 1, 0, 0);
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.AsFood().Size = 0.05;
		((ModItem)this).Item.AsFood().MaxHealth = 80;
		((ModItem)this).Item.AsFood().EdibleOnUse = true;
		((ModItem)this).Item.AsFood().OnSwallowDamage = 15;
		((ModItem)this).Item.AsFood().OnSwallowDeathReason = "{0} thought they were taking a shot, not getting one.";
		PreyItem preyItem = ((ModItem)this).Item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public override bool? UseItem(Player player)
	{
		if (!player.AsPred().PermanentUpgradesGained.ContainsKey("PureSwallow1"))
		{
			player.AsPred().PermanentUpgradesGained.Add("PureSwallow1", value: false);
		}
		if (!player.AsPred().PermanentUpgradesGained["PureSwallow1"])
		{
			player.AsPred().PermanentUpgradesGained["PureSwallow1"] = true;
		}
		return true;
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(ref MuffledMiscSounds.Shatter, (Vector2?)pred.TrueCenter(), (SoundUpdateCallback)null);
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		Player playerPred = (Player)(object)((pred is Player) ? pred : null);
		if (playerPred != null)
		{
			if (!playerPred.AsPred().PermanentUpgradesGained.ContainsKey("PureSwallow1"))
			{
				playerPred.AsPred().PermanentUpgradesGained.Add("PureSwallow1", value: false);
			}
			if (!playerPred.AsPred().PermanentUpgradesGained["PureSwallow1"])
			{
				playerPred.AsPred().PermanentUpgradesGained["PureSwallow1"] = true;
			}
		}
		return true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.PermanentUpgrades.PureSwallowBoost1", new
		{
			PureSwallow1GLPBonus = GLPBonus
		});
	}
}
