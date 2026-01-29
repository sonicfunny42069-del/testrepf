using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.NPCs;

namespace V2.StatusEffects.Voraria.Debuffs;

public class TastySpicy : ModBuff
{
	public override string Texture => "V2/StatusEffects/Voraria/Debuffs/DebuffPlaceholder";

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Debuffs.TastySpicy.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Debuffs.TastySpicy.Description");

	public override void SetStaticDefaults()
	{
		Main.debuff[((ModBuff)this).Type] = true;
		Sets.NurseCannotRemoveDebuff[((ModBuff)this).Type] = true;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		rare = -13;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.AsFood().TastySpicy = true;
	}
}
