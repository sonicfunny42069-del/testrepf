using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Vanilla.Bosses.KingSlime;

public class KingJelloDessert : GlobalNPC
{
	private int _muffledScreechDelay;

	public static int MuffledScreechMinDelay => V2Utils.SensibleTime(0, 0, 5);

	public int MuffledScreechDelay
	{
		get
		{
			return _muffledScreechDelay;
		}
		set
		{
			_muffledScreechDelay = Math.Max(0, value);
		}
	}

	public SlotId MuffledMusic { get; set; }

	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 50;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Other;
		npc.AsFood().DefinedBaseSize = 70.0;
		npc.AsPred().MaxStomachCapacity = 325.0;
		npc.AsPred().BaseStomachacheMeterCapacity = 4000.0;
		npc.AsPred().SmallGulps = null;
		npc.AsPred().SmallGulpThreshold = 3.75;
		npc.AsPred().BigGulps = null;
		npc.AsPred().DigestionType = EntityDigestionType.Other;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().MouthSoundRawOffset = ((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 0f, -40f);
		npc.AsPred().SmallBurps = null;
		npc.AsPred().StandardBurps = null;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsFood().ItemTheftRules = new List<ItemTheftRule>();
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 0.65;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 4.0 * (npc.AsFood().DefinedEffectiveSize / npc.AsFood().DefinedBaseSize);
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 15) * (npc.AsFood().DefinedEffectiveSize / npc.AsFood().DefinedBaseSize);
	}
}
