using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Debuffs;

public class StarvingDebuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(334, (GlobalBuff)(object)this);
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 334)
		{
			player.starving = true;
			player.AddHealthRegenEffect(StarvingHealthPerSecond, natural: true);
		}
	}

	public static double StarvingHealthPerSecond(Player player)
	{
		double num2 = 60.0 * (double)player.statLifeMax2 / 3000.0;
		if (num2 < 2.0)
		{
			num2 = 2.0;
		}
		return 0.0 - num2;
	}
}
