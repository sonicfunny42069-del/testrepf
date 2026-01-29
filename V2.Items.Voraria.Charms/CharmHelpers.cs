using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Charms;

public static class CharmHelpers
{
	public static List<int> ImplementedCharms
	{
		get
		{
			int num = 5;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<int> span = CollectionsMarshal.AsSpan(list);
			int num2 = 0;
			span[num2] = ModContent.ItemType<CharmBetterDigestion>();
			num2++;
			span[num2] = ModContent.ItemType<CharmFatass>();
			num2++;
			span[num2] = ModContent.ItemType<CharmLessStomachWeight>();
			num2++;
			span[num2] = ModContent.ItemType<CharmPreyItemTheft>();
			num2++;
			span[num2] = ModContent.ItemType<CharmRegenFromAbsorption>();
			num2++;
			return list;
		}
	}

	public static int MaxCharms => 3;

	public static CharmGlobalItem AsCharm(this Item item)
	{
		return item.GetGlobalItem<CharmGlobalItem>();
	}
}
