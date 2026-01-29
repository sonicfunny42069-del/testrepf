using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Debuffs;

public class ElectrifiedDebuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(144, (GlobalBuff)(object)this);
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type != 144)
		{
			return;
		}
		player.electrified = true;
		player.AddHealthRegenEffect(delegate(Player val)
		{
			double num = 4.0;
			if (((Entity)val).wet)
			{
				num *= 10.0;
			}
			if (((Vector2)(ref ((Entity)val).velocity)).Length() >= 1f)
			{
				num *= 4.0;
			}
			return -4.0;
		});
	}
}
