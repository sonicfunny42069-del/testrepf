using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Debuffs;

public class SuffocationDebuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(68, (GlobalBuff)(object)this);
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 68)
		{
			player.suffocating = true;
			player.AddHealthRegenEffect(-20.0);
		}
	}
}
