using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Debuffs;

public class BurningDebuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(67, (GlobalBuff)(object)this);
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 67)
		{
			player.burned = true;
			player.moveSpeed *= 0.5f;
			player.AddHealthRegenEffect(-30.0);
		}
	}
}
