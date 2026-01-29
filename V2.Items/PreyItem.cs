using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals.Starter;

namespace V2.Items;

public class PreyItem : GlobalItem
{
	public delegate void DelegateOnSwallow(Item item, Entity pred);

	public delegate bool DelegateCanUseInStomach(Item item, Player player, Entity pred);

	public delegate void DelegateUseInStomach(Item item, Player player, Entity pred);

	public delegate bool DelegateOnBreak(Item item, Entity pred, bool direct);

	private int _health = -1;

	public int MaxHealth { get; set; } = -1;

	public int Health
	{
		get
		{
			return _health;
		}
		set
		{
			_health = Math.Min(value, MaxHealth);
		}
	}

	public double Size { get; set; }

	public int AcidResistTier { get; set; }

	public string MealSizeTextOverride { get; set; }

	public DelegateOnSwallow OnSwallow { get; set; }

	public int OnSwallowDamage { get; set; }

	public string OnSwallowDeathReason { get; set; }

	public int OnSwallowSoreThroatTime { get; set; }

	public DelegateCanUseInStomach CanUseInStomach { get; set; }

	public DelegateUseInStomach UseInStomach { get; set; }

	public PreyData.DelegateUpdateInStomach UpdateInStomach { get; set; }

	public DelegateOnBreak OnBreak { get; set; }

	public bool EdibleOnUse { get; set; }

	public bool AlwaysEatenByUse { get; set; }

	public override bool InstancePerEntity => true;

	public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
	{
		if (!item.IsAir && MaxHealth != -1)
		{
			if (Health == -1 || Health > MaxHealth)
			{
				Health = MaxHealth;
			}
			if (Health == 0)
			{
				item.TurnToAir(false);
			}
		}
	}

	public override void UpdateInventory(Item item, Player player)
	{
		if (!item.IsAir && MaxHealth != -1)
		{
			if (Health == -1 || Health > MaxHealth)
			{
				Health = MaxHealth;
			}
			if (Health == 0)
			{
				item.TurnToAir(false);
			}
		}
	}

	public override bool CanUseItem(Item item, Player player)
	{
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		if (item.IsAir)
		{
			return false;
		}
		if (((Entity)(object)player).CurrentCaptor() != null)
		{
			if (item.AsFood().CanUseInStomach != null && item.AsFood().CanUseInStomach(item, player, ((Entity)(object)player).CurrentCaptor().Predator))
			{
				item.AsFood().UseInStomach?.Invoke(item, player, ((Entity)(object)player).CurrentCaptor().Predator);
			}
			return false;
		}
		bool gulpOnUseAttempt = item != player.inventory[58] && ((Entity)player).whoAmI == Main.myPlayer && V2.ItemGulpHotkey.Current;
		gulpOnUseAttempt |= item.AsFood().AlwaysEatenByUse;
		bool attemptingToUse = Main.mouseLeft;
		if (!item.autoReuse)
		{
			attemptingToUse &= Main.mouseLeftRelease;
		}
		attemptingToUse &= item == player.HeldItem;
		attemptingToUse &= !player.mouseInterface;
		if (item.AsFood().EdibleOnUse && gulpOnUseAttempt && attemptingToUse)
		{
			Main.mouseLeftRelease = false;
			int origStack = item.stack;
			item.stack = 1;
			if (PredPlayer.CanSwallow(player, (Entity)(object)item))
			{
				if (origStack > 1)
				{
					Item eatenItem = new Item();
					eatenItem.SetDefaults(item.type);
					eatenItem.stack = 1;
					player.ForceDropItem(((Entity)player).Center, ref eatenItem, out var itemDrop);
					PredPlayer.Swallow(player, (Entity)(object)itemDrop);
					item.stack = origStack - 1;
				}
				else
				{
					player.ForceDropItem(((Entity)player).Center, ref item, out var itemDrop2);
					PredPlayer.Swallow(player, (Entity)(object)itemDrop2);
				}
				ModContent.GetInstance<FirstItemEaten>().TrySetCompletion(player);
			}
			else
			{
				item.stack = origStack;
			}
			return false;
		}
		return true;
	}

	public override bool CanStack(Item destination, Item source)
	{
		int i = destination.AsFood().MaxHealth;
		int j = source.AsFood().MaxHealth;
		if (i == -1 && j == -1)
		{
			return true;
		}
		if (i == -1 && j != -1)
		{
			destination.AsFood().MaxHealth = source.AsFood().MaxHealth;
			destination.AsFood().Health = source.AsFood().Health;
			return true;
		}
		int j2 = j;
		if (i != -1 && j2 == -1)
		{
			source.AsFood().MaxHealth = destination.AsFood().MaxHealth;
			source.AsFood().Health = destination.AsFood().Health;
			return true;
		}
		return destination.AsFood().Health == source.AsFood().Health;
	}

	public override bool CanStackInWorld(Item destination, Item source)
	{
		if (((Entity)(object)destination).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}

	public override void GrabRange(Item item, Player player, ref int grabRange)
	{
		if (((Entity)(object)item).CurrentCaptor() != null)
		{
			grabRange = 0;
		}
	}

	public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
	{
		if (((Entity)(object)item).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}

	public override bool CanPickup(Item item, Player player)
	{
		if (item.IsAir)
		{
			return false;
		}
		if (((Entity)(object)item).CurrentCaptor() != null)
		{
			return false;
		}
		if (item.AsFood().MaxHealth != -1 && item.AsFood().Health == 0)
		{
			return false;
		}
		return true;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		if (item.AsFood().MaxHealth == -1 || item.AsFood().Health == -1)
		{
			return;
		}
		if (item.favorited)
		{
			tooltips.Insert(tooltips.IndexOf(tooltips.FirstOrDefault((TooltipLine x) => x.Name == "FavoriteDesc")) + 1, new TooltipLine((Mod)(object)V2.Instance, "FavoriteNoNoms", "Swallowing from inventory will be blocked, but can still be digested by other means"));
		}
		double healthRemainingRatio = (double)item.AsFood().Health / (double)item.AsFood().MaxHealth;
		Color duraPercentColor = Color.Lerp(Color.White, Color.DarkOliveGreen, (float)(1.0 - healthRemainingRatio));
		V2Utils.FindLastTooltipLineBeforeFlavorText(tooltips, out var finalLine);
		tooltips.Insert(tooltips.IndexOf(finalLine) + 1, new TooltipLine((Mod)(object)V2.Instance, "V2Durability", "Durability left: " + item.AsFood().Health + " / " + item.AsFood().MaxHealth + " ([c/" + Utils.Hex3(duraPercentColor * ((float)(int)Main.mouseTextColor / 255f)) + ":" + healthRemainingRatio.ToPercentage(2) + "])"));
		double size = item.AsFood().Size;
		string sizeDescription = "Barely a light snack";
		if (size >= 0.04 && size < 0.08)
		{
			sizeDescription = "Light snack";
		}
		if (size >= 0.08 && size < 0.14)
		{
			sizeDescription = "Snack";
		}
		if (size >= 0.14 && size < 0.21)
		{
			sizeDescription = "Large snack";
		}
		if (size >= 0.21 && size < 0.3)
		{
			sizeDescription = "Small meal";
		}
		if (size >= 0.3 && size < 0.4)
		{
			sizeDescription = "Somewhat-small meal";
		}
		if (size >= 0.4 && size < 0.52)
		{
			sizeDescription = "Modest meal";
		}
		if (size >= 0.52 && size < 0.65)
		{
			sizeDescription = "Medium meal";
		}
		if (size >= 0.65 && size < 0.82)
		{
			sizeDescription = "Noteworthy meal";
		}
		if (size >= 0.82 && size < 1.0)
		{
			sizeDescription = "Sizable meal";
		}
		if (size >= 1.0 && size < 1.2)
		{
			sizeDescription = "Large meal";
		}
		if (size >= 1.2 && size < 1.5)
		{
			sizeDescription = "Huge meal";
		}
		if (size >= 1.5 && size < 2.0)
		{
			sizeDescription = "Massive meal";
		}
		if (size >= 2.0)
		{
			sizeDescription = "Potentially, a vaguely satisfying meal";
		}
		if (item.AsFood().MealSizeTextOverride != null)
		{
			sizeDescription = item.AsFood().MealSizeTextOverride;
		}
		tooltips.Insert(tooltips.IndexOf(finalLine) + 2, new TooltipLine((Mod)(object)V2.Instance, "V2SizeAsFood", sizeDescription + " (size of " + size + ")"));
		string canBeDigestedBy = Language.GetTextValue("Mods.V2.ItemTooltip.Generic.AcidResistTier." + item.AsFood().AcidResistTier);
		tooltips.Insert(tooltips.IndexOf(finalLine) + 3, new TooltipLine((Mod)(object)V2.Instance, "V2AcidResist", canBeDigestedBy));
		int linePos = 4;
		if (item.AsFood().EdibleOnUse)
		{
			if (item.AsFood().AlwaysEatenByUse)
			{
				tooltips.Insert(tooltips.IndexOf(finalLine) + linePos, new TooltipLine((Mod)(object)V2.Instance, "V2EatenByNormalUse", Language.GetTextValue("Mods.V2.ItemTooltip.Generic.EatenByNormalUse")));
			}
			else
			{
				tooltips.Insert(tooltips.IndexOf(finalLine) + linePos, new TooltipLine((Mod)(object)V2.Instance, "V2EdibleByNormalUse", Language.GetTextValue("Mods.V2.ItemTooltip.Generic.EdibleFromNormalUse")));
			}
			linePos++;
		}
		if (item.AsFood().Health == 0)
		{
			tooltips.Insert(tooltips.IndexOf(finalLine) + linePos, new TooltipLine((Mod)(object)V2.Instance, "V2EdibleByNormalUse", Language.GetTextValue("Mods.V2.ItemTooltip.Generic.Broken")));
			linePos++;
		}
	}

	public override void SaveData(Item item, TagCompound tag)
	{
		tag["VDura"] = Health;
	}

	public override void LoadData(Item item, TagCompound tag)
	{
		Health = tag.GetInt("VDura");
	}
}
