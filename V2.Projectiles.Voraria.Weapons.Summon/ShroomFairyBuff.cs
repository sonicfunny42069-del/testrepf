using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Projectiles.Voraria.Weapons.Summon;

public class ShroomFairyBuff : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Summons.ShroomFairy.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Summons.ShroomFairy.Description");

	public override void SetStaticDefaults()
	{
		Main.buffNoSave[((ModBuff)this).Type] = true;
		Main.buffNoTimeDisplay[((ModBuff)this).Type] = true;
		Main.persistentBuff[((ModBuff)this).Type] = true;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = 2;
		tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Summons.ShroomFairy.Description", (object)new { });
	}

	public override void Update(Player player, ref int buffIndex)
	{
		if (player.ownedProjectileCounts[ModContent.ProjectileType<ShroomFairy>()] > 0)
		{
			player.buffTime[buffIndex] = 18000;
			return;
		}
		player.DelBuff(buffIndex);
		buffIndex--;
	}
}
