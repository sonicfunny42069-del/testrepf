using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Vanilla.TownNPCs.Zoologist;

public class Zoologist : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 633;
	}

	public override void SetDefaults(NPC npc)
	{
		npc.AsV2NPC().Gender = EntityGender.Female;
	}
}
