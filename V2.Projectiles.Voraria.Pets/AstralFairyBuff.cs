using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Projectiles.Voraria.Pets;

public class AstralFairyBuff : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Summons.AstralFairy.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Summons.AstralFairy.Description");

	public override void SetStaticDefaults()
	{
		Main.buffNoSave[((ModBuff)this).Type] = true;
		Main.buffNoTimeDisplay[((ModBuff)this).Type] = true;
		Main.vanityPet[((ModBuff)this).Type] = true;
		Main.persistentBuff[((ModBuff)this).Type] = true;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = 2;
		tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Summons.AstralFairy.Description", (object)new { });
	}

	public override void Update(Player player, ref int buffIndex)
	{
		bool unused = false;
		player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<AstralFairy>(), 18000);
	}
}
