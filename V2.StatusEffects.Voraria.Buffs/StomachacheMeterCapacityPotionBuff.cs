using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria.Consumables.Potions;
using V2.PlayerHandling;

namespace V2.StatusEffects.Voraria.Buffs;

public class StomachacheMeterCapacityPotionBuff : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.StomachacheMeterCapacityPotionBuff.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.StomachacheMeterCapacityPotionBuff.Description");

	public override bool RightClick(int buffIndex)
	{
		return false;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = 8;
		tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Buffs.StomachacheMeterCapacityPotionBuff.Description", (object)new
		{
			StomachacheMeterCapacityPotionMeterCapacityBonus = StomachacheMeterCapacityPotion.StomachacheMeterCapacityBonus.ToPercentage(3),
			StomachacheMeterCapacityPotionUneaseDefenseBonus = StomachacheMeterCapacityPotion.StomachacheDefenseBonus
		});
	}

	public override void Update(Player player, ref int buffIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachacheMeterCapacityModifier += (float)StomachacheMeterCapacityPotion.StomachacheMeterCapacityBonus;
		player.AsPred().StomachacheDefense.Base += StomachacheMeterCapacityPotion.StomachacheDefenseBonus;
	}
}
