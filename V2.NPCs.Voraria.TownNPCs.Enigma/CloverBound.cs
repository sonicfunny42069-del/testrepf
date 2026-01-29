using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Voraria.TownNPCs.Enigma;

public class CloverBound : ModNPC
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
		Sets.ImmuneToRegularBuffs[((ModNPC)this).NPC.type] = true;
	}

	public override void SetDefaults()
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.friendly = true;
		((ModNPC)this).NPC.dontTakeDamageFromHostiles = true;
		((Entity)((ModNPC)this).NPC).width = 8;
		((Entity)((ModNPC)this).NPC).height = 94;
		((ModNPC)this).NPC.aiStyle = 0;
		((ModNPC)this).NPC.lifeMax = 500;
		((ModNPC)this).NPC.damage = 35;
		((ModNPC)this).NPC.defense = 38;
		((ModNPC)this).NPC.rarity = 4;
		((ModNPC)this).NPC.knockBackResist = 0f;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.noGravity = true;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 1.15;
		((ModNPC)this).NPC.AsPred().WeightGainRatio = 0.125;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 2.2;
		((ModNPC)this).NPC.AsPred().BaseStomachacheMeterCapacity = 90.0;
		((ModNPC)this).NPC.AsFood().StruggleEffectiveness = 1;
		((ModNPC)this).NPC.AsPred().DigestionType = EntityDigestionType.Acidic;
	}

	public override void ModifyTypeName(ref string typeName)
	{
		typeName = "Stuck Enigma";
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (ModContent.GetInstance<V2MasterSystem>().freedEnigma)
		{
			return 0f;
		}
		if (!spawnInfo.Player.ZoneRockLayerHeight)
		{
			return 0f;
		}
		if (!spawnInfo.Player.ZoneJungle)
		{
			return 0f;
		}
		if (!Main.hardMode)
		{
			return 0f;
		}
		if (NPC.AnyNPCs(ModContent.NPCType<CloverBound>()))
		{
			return 0f;
		}
		return 0.18f;
	}

	public override void AI()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (((ModNPC)this).NPC.ai[0] == 0f)
		{
			int TileCount = 0;
			bool FoundTile = false;
			Vector2 GoTo = Vector2.Zero;
			while (TileCount < 25 && !FoundTile)
			{
				TileCount++;
				if (Collision.IsWorldPointSolid(((Entity)((ModNPC)this).NPC).Center - new Vector2(0f, (float)(TileCount * 16)), true))
				{
					FoundTile = true;
					GoTo = Utils.ToWorldCoordinates(Utils.ToTileCoordinates(((Entity)((ModNPC)this).NPC).Center - new Vector2(0f, (float)(TileCount * 16))), 8f, 8f);
				}
			}
			if (GoTo == Vector2.Zero)
			{
				((ModNPC)this).NPC.type = 0;
			}
			((Entity)((ModNPC)this).NPC).position = GoTo;
		}
		((ModNPC)this).NPC.ai[0] += 0.1f;
		if (((ModNPC)this).NPC.ai[0] >= 1f)
		{
			((ModNPC)this).NPC.ai[0] = 1f;
			Vector2 val = new Vector2(((Entity)((ModNPC)this).NPC).Center.X, ((Entity)((ModNPC)this).NPC).position.Y - 4f);
			Utils.ToTileCoordinates(val);
			if (!Collision.IsWorldPointSolid(val, true))
			{
				ModContent.GetInstance<V2MasterSystem>().freedEnigma = true;
				((ModNPC)this).NPC.AI_000_TransformBoundNPC(((Entity)Main.CurrentPlayer).whoAmI, ModContent.NPCType<Clover>());
			}
		}
	}

	public override bool CanChat()
	{
		return true;
	}

	public override string GetChat()
	{
		List<string> possibleLines = new List<string> { "Oh, hey! I'm, uh, stuck up here somehow. Don't ask how I did it, just get me down!", "So, how's it... hanging? Get it? ...okay, I won't do any more awful jokes if you get me down!", "...no chat, I'm not going to- OH IM NOT ALONE HERE Hi! Can you... help a gal out here?" };
		return Utils.NextFromCollection<string>(Main.rand, possibleLines);
	}

	public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		boundingBox = new Rectangle((int)((Entity)((ModNPC)this).NPC).Center.X - 16, (int)((Entity)((ModNPC)this).NPC).Center.Y, 32, 40);
	}
}
