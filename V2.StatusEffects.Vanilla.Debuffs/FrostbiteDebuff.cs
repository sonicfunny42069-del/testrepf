using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Debuffs;

public class FrostbiteDebuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(324, (GlobalBuff)(object)this);
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 324)
		{
			player.onFrostBurn2 = true;
			player.AddHealthRegenEffect(-25.0);
		}
	}
}
