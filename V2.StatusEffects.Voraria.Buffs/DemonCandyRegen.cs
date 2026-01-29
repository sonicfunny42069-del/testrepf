using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Voraria.Buffs;

public class DemonCandyRegen : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.DemonCandyRegen.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.DemonCandyRegen.Description");

	public override bool RightClick(int buffIndex)
	{
		return false;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = 2;
		tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Buffs.DemonCandyRegen.Description", (object)new { });
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.AddHealthRegenEffect(3.0);
		player.AsPred().specialManaRegenCount += 8.0;
	}
}
