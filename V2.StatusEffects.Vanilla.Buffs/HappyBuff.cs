using Terraria;
using Terraria.ModLoader;

namespace V2.StatusEffects.Vanilla.Buffs;

public class HappyBuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[146] = false;
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 146;
	}
}
