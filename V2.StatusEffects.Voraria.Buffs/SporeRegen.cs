using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Voraria.Buffs;

public class SporeRegen : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.SporeRegen.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Buffs.SporeRegen.Description");

	public override bool RightClick(int buffIndex)
	{
		return false;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = 2;
		tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Buffs.SporeRegen.Description", (object)new { });
	}

	public override bool ReApply(Player player, int time, int buffIndex)
	{
		player.buffTime[buffIndex] = Math.Min(player.buffTime[buffIndex] + time, 3600);
		return true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.AddHealthRegenEffect(Math.Min((int)Math.Ceiling((float)player.buffTime[buffIndex] / 180f), 10));
	}
}
