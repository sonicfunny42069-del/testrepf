using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class DryadsWardBuff : GlobalBuff
{
	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(165, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 165;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (type == 165)
		{
			player.dryadWard = true;
			player.AddHealthRegenEffect(DryadBlessingHealthPerSecond, natural: true);
			player.statDefense += DryadBlessingDefenseBoost((Entity)(object)player);
			player.thorns += DryadBlessingDamageReflectionBoost((Entity)(object)player);
		}
	}

	public static double DryadBlessingHealthPerSecond(Entity blessedEntity)
	{
		double healthRegenPerSecond = 4.0;
		if (NPC.combatBookWasUsed)
		{
			healthRegenPerSecond += 1.0;
		}
		return healthRegenPerSecond;
	}

	public static int DryadBlessingDefenseBoost(Entity blessedEntity)
	{
		int defense = 6;
		if (NPC.combatBookWasUsed)
		{
			defense += 6;
		}
		return defense;
	}

	public static float DryadBlessingDamageReflectionBoost(Entity blessedEntity)
	{
		float thorns = 0.8f;
		if (NPC.combatBookWasUsed)
		{
			thorns += 0.7f;
		}
		return thorns;
	}
}
