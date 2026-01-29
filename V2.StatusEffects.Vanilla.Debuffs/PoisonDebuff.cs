using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Debuffs;

public class PoisonDebuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(20, (GlobalBuff)(object)this);
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 20)
		{
			player.poisoned = true;
			player.AddHealthRegenEffect(-2.0, natural: true);
		}
	}
}
