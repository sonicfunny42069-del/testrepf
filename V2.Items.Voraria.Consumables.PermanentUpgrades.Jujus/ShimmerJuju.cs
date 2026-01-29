using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.Items.Voraria.Consumables.PermanentUpgrades.Jujus;

public class ShimmerJuju : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.PermanentUpgrades.Jujus.ShimmerJuju");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.PermanentUpgrades.Jujus.ShimmerJuju.Short");

	public static int AllBonus => 4;

	public static int PermAllBonus => 1;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		((ModItem)this).Item.ResearchUnlockCount = 1;
		DrawAnimationVertical anim = new DrawAnimationVertical(8, 2, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((Entity)((ModItem)this).Item).width = 32;
		((Entity)((ModItem)this).Item).height = 32;
		((ModItem)this).Item.maxStack = 1;
		((ModItem)this).Item.value = Item.sellPrice(0, 3, 0, 0);
		((ModItem)this).Item.rare = 7;
		((ModItem)this).Item.AsFood().Size = 0.5;
		((ModItem)this).Item.AsFood().MaxHealth = 150;
		((ModItem)this).Item.AsFood().EdibleOnUse = true;
		PreyItem preyItem = ((ModItem)this).Item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public override void PostUpdate()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		Lighting.AddLight(((Entity)((ModItem)this).Item).Center, new Vector3(200f, 80f, 255f) * 0.005f);
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.AsPred().GLP.Extra += AllBonus;
		player.AsPred().TUM.Extra += AllBonus;
		player.AsPred().ACI.Extra += AllBonus;
		player.AsPred().ABS.Extra += AllBonus;
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		Player playerPred = (Player)(object)((pred is Player) ? pred : null);
		if (playerPred != null)
		{
			if (!playerPred.AsPred().PermanentUpgradesGained.ContainsKey("ShimmerJuju"))
			{
				playerPred.AsPred().PermanentUpgradesGained.Add("ShimmerJuju", value: false);
			}
			if (!playerPred.AsPred().PermanentUpgradesGained["ShimmerJuju"])
			{
				playerPred.AsPred().PermanentUpgradesGained["ShimmerJuju"] = true;
			}
		}
		return true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.PermanentUpgrades.Jujus.ShimmerJuju", new
		{
			All = AllBonus,
			PermAll = PermAllBonus
		});
	}
}
