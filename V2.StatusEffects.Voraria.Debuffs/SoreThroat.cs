using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.StatusEffects.Voraria.Debuffs;

public class SoreThroat : ModBuff
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Debuffs.SoreThroat.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Debuffs.SoreThroat.Description");

	public override void SetStaticDefaults()
	{
		Main.debuff[((ModBuff)this).Type] = true;
		Sets.NurseCannotRemoveDebuff[((ModBuff)this).Type] = true;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = -11;
	}
}
