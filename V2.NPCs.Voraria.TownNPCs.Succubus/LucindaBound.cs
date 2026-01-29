using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Voraria.TownNPCs.Succubus;

public class LucindaBound : ModNPC
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<int, NPCBestiaryDrawModifiers> nPCBestiaryDrawOffset = Sets.NPCBestiaryDrawOffset;
		int type = ((ModNPC)this).Type;
		NPCBestiaryDrawModifiers value = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref value))._002Ector();
		value.Hide = true;
		nPCBestiaryDrawOffset.Add(type, value);
	}

	public override void SetDefaults()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.friendly = true;
		((Entity)((ModNPC)this).NPC).width = 22;
		((Entity)((ModNPC)this).NPC).height = 36;
		((ModNPC)this).NPC.aiStyle = 0;
		((ModNPC)this).NPC.lifeMax = 700;
		((ModNPC)this).NPC.damage = 35;
		((ModNPC)this).NPC.defense = 22;
		((ModNPC)this).NPC.rarity = 4;
		((ModNPC)this).NPC.knockBackResist = 0f;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 1.15;
		((ModNPC)this).NPC.AsPred().WeightGainRatio = 0.125;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 2.2;
		((ModNPC)this).NPC.AsPred().BaseStomachacheMeterCapacity = 155.0;
		((ModNPC)this).NPC.AsPred().DigestionType = EntityDigestionType.Acidic;
		((ModNPC)this).NPC.buffImmune[24] = true;
		((ModNPC)this).NPC.buffImmune[323] = true;
		((ModNPC)this).NPC.buffImmune[67] = true;
		((ModNPC)this).NPC.buffImmune[153] = true;
		((ModNPC)this).NPC.lavaImmune = true;
	}

	public override void ModifyTypeName(ref string typeName)
	{
		typeName = "Bound Succubus";
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (ModContent.GetInstance<V2MasterSystem>().freedSucc)
		{
			return 0f;
		}
		if (!spawnInfo.Player.ZoneUnderworldHeight)
		{
			return 0f;
		}
		if (NPC.AnyNPCs(ModContent.NPCType<LucindaBound>()))
		{
			return 0f;
		}
		return 0.15f;
	}

	public override bool CanChat()
	{
		return true;
	}

	public override string GetChat()
	{
		List<string> possibleLines = new List<string> { "Hey! You! Morsel! Mind lendin' me a hand? Been stuck here since last Tuesday, havin' to munch on imps and the chips off those serpents just to keep my gut quiet.", "Hey there, soon-to-be snack. I know you're not all that busy, so care to help a pred out? My gut and I will be MORE than happy to make it worth your while.", "So WHAT!? The Convocation says I'm out for a bit because the bimbo that one of 'em wanted made good gut fodder!? Dumbasses...hey, lunch! You can tear these tacky tightropes for me, yeah?" };
		return Utils.NextFromCollection<string>(Main.rand, possibleLines);
	}
}
