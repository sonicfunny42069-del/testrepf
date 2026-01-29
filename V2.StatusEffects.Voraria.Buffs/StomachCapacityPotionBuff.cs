using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria.Consumables.Potions;
using V2.PlayerHandling;

namespace V2.StatusEffects.Voraria.Buffs;

public class StomachCapacityPotionBuff : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.StomachCapacityPotionBuff.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.StomachCapacityPotionBuff.Description");

	public override bool RightClick(int buffIndex)
	{
		return false;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = 2;
		tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Buffs.StomachCapacityPotionBuff.Description", (object)new
		{
			StomachCapacityPotionCapacityBonus = StomachCapacityPotion.StomachCapacityBonus.ToPercentage(3)
		});
	}

	public override void Update(Player player, ref int buffIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachCapacityModifier += (float)StomachCapacityPotion.StomachCapacityBonus;
	}
}
