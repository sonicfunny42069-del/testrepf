using System;
using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.Items.Voraria.Charms;

public class CharmGlobalItem : GlobalItem
{
	public bool IsCharm { get; set; }

	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return CharmHelpers.ImplementedCharms.Contains(entity.type);
	}

	public override void SetDefaults(Item item)
	{
		item.AsCharm().IsCharm = true;
		GeneralItem generalItem = item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateCharm));
	}

	public static void UpdateCharm(Item item, Player player, bool visual)
	{
		ModContent.GetInstance<EquipCharm>().TrySetCompletion(player);
	}
}
