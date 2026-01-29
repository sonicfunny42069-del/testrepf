using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.Sounds.MuffledSounds;
using V2.Sounds.Vore;
using V2.StatusEffects.Voraria.Buffs;

namespace V2.Items.Voraria.Consumables.Potions;

public class StomachacheMeterCapacityPotion : ModItem
{
	public static double StomachacheMeterCapacityBonus => 0.1;

	public static int StomachacheDefenseBonus => 5;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.Potions.StomachacheMeterCapacityPotion");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.Potions.StomachacheMeterCapacityPotion.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.ResearchUnlockCount = 20;
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
		((ModItem)this).Item.buffType = ModContent.BuffType<StomachacheMeterCapacityPotionBuff>();
		((ModItem)this).Item.buffTime = V2Utils.SensibleTime(0, 3);
		((ModItem)this).Item.value = Item.buyPrice(0, 1, 25, 0);
		((ModItem)this).Item.rare = 2;
		((ModItem)this).Item.AsFood().EdibleOnUse = true;
		((ModItem)this).Item.AsFood().AlwaysEatenByUse = true;
		((ModItem)this).Item.AsFood().MaxHealth = 80;
		((ModItem)this).Item.AsFood().Size = 0.15;
		PreyItem preyItem = ((ModItem)this).Item.AsFood();
		preyItem.OnSwallow = (PreyItem.DelegateOnSwallow)Delegate.Combine(preyItem.OnSwallow, new PreyItem.DelegateOnSwallow(OnSwallow));
		PreyItem preyItem2 = ((ModItem)this).Item.AsFood();
		preyItem2.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem2.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
		PreyItem preyItem3 = ((ModItem)this).Item.AsFood();
		preyItem3.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem3.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public static void OnSwallow(Item item, Entity pred)
	{
	}

	public static void UpdateInStomach(Entity prey, Entity pred, bool dead)
	{
		if (dead)
		{
			pred.AddStatus(ModContent.BuffType<StomachacheMeterCapacityPotionBuff>(), V2Utils.SensibleTime(0, 3), fromDigestingSomething: true);
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
		return true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.Potions.StomachacheMeterCapacityPotion", new
		{
			StomachacheMeterCapacityPotionMeterCapacityBonus = StomachacheMeterCapacityBonus.ToPercentage(3),
			StomachacheMeterCapacityPotionUneaseDefenseBonus = StomachacheDefenseBonus
		});
		tooltips.FirstOrDefault((TooltipLine x) => x.Name == "BuffTime").Hide();
	}
}
