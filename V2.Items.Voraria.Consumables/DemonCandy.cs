using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Voraria.Underworld.HellHarpy;
using V2.Sounds.Vore;
using V2.StatusEffects.Voraria.Buffs;

namespace V2.Items.Voraria.Consumables;

public class DemonCandy : ModItem
{
	public static int DigestedRegenTime => V2Utils.SensibleTime(0, 5);

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.DemonCandy");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.DemonCandy");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 20;
	}

	public override void PostUpdate()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode != 1 && ((Entity)((ModItem)this).Item).position.Y > (float)(Main.UnderworldLayer * 16 + 200) && Utils.NextBool(Main.rand, 600) && !NPC.AnyNPCs(ModContent.NPCType<HellHarpy>()))
		{
			NPC.NewNPCDirect(((Entity)((ModItem)this).Item).GetSource_FromAI((string)null), (int)((Entity)((ModItem)this).Item).Center.X, (int)((Entity)((ModItem)this).Item).Center.Y + 800, ModContent.NPCType<HellHarpy>(), 0, 0f, 0f, 0f, 0f, 255).netUpdate = true;
		}
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.consumable = true;
		((Entity)((ModItem)this).Item).width = 32;
		((Entity)((ModItem)this).Item).height = 32;
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((ModItem)this).Item.value = Item.buyPrice(0, 0, 50, 0);
		((ModItem)this).Item.rare = 4;
		((ModItem)this).Item.AsFood().MaxHealth = 500;
		((ModItem)this).Item.AsFood().Size = 1.0;
		((ModItem)this).Item.AsFood().EdibleOnUse = true;
		PreyItem preyItem = ((ModItem)this).Item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		((pred is Player) ? pred : null)?.AddStatus(ModContent.BuffType<DemonCandyRegen>(), DigestedRegenTime, fromDigestingSomething: true);
		return true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.DemonCandy", new
		{
			Regen = 8
		});
	}
}
