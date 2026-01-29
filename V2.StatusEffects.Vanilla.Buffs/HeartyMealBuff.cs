using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class HeartyMealBuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(336, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 336;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 336)
		{
			player.AddHealthRegenEffect(3.0);
		}
	}
}
