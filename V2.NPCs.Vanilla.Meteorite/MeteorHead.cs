using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.NPCs.Vanilla.Meteorite;

public class MeteorHead : GlobalNPC
{
	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 23;
	}

	public override void SetStaticDefaults()
	{
	}

	public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
	{
	}
}
