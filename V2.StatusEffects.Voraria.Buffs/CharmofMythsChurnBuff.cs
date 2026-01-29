using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Items.Vanilla.Accessories;
using V2.PlayerHandling;

namespace V2.StatusEffects.Voraria.Buffs;

public class CharmofMythsChurnBuff : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.CharmofMythsChurnBuff.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.CharmofMythsChurnBuff.Description");

	public override bool RightClick(int buffIndex)
	{
		return false;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = 2;
		tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Buffs.CharmofMythsChurnBuff.Description", (object)new
		{
			CharmofMythsChurnRegen = HealthRegenAndPotionCooldownBand.DigestingHealthRegenFlat
		});
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.AddHealthRegenEffect(HealthRegenAndPotionCooldownBand.DigestingHealthRegenFlat);
		player.pStone = true;
		if (player.HasBuff(21))
		{
			player.buffTime[player.FindBuffIndex(21)]--;
		}
	}
}
