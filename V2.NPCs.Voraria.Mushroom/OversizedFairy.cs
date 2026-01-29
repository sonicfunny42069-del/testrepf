using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.Projectiles.Voraria.Weapons.Summon;
using V2.Sounds.Vore;

namespace V2.NPCs.Voraria.Mushroom;

public class OversizedFairy : ModNPC
{
	public override string Texture => "V2/NPCs/Voraria/Mushroom/FATFUCK";

	public override void SetStaticDefaults()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		NPCBestiaryDrawModifiers val = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref val))._002Ector();
		val.CustomTexturePath = "V2/NPCs/Voraria/Mushroom/FATFUCK";
		val.Position = new Vector2(-8f, 8f);
		NPCBestiaryDrawModifiers drawModifiers = val;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).Type, drawModifiers);
	}

	public override void SetDefaults()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.friendly = true;
		((ModNPC)this).NPC.dontTakeDamageFromHostiles = true;
		((Entity)((ModNPC)this).NPC).width = 154;
		((Entity)((ModNPC)this).NPC).height = 66;
		((ModNPC)this).NPC.aiStyle = -1;
		((ModNPC)this).NPC.damage = 0;
		((ModNPC)this).NPC.defense = 45;
		((ModNPC)this).NPC.lifeMax = 14000;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.DeathSound = SoundID.NPCDeath1;
		((ModNPC)this).NPC.value = 37500f;
		((ModNPC)this).NPC.knockBackResist = 0f;
		((ModNPC)this).NPC.noGravity = true;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 50.5;
		((ModNPC)this).NPC.AsPred().WeightGainRatio = 0.0;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 25.0;
		((ModNPC)this).NPC.AsPred().BaseStomachacheMeterCapacity = 1750.0;
		((ModNPC)this).NPC.AsPred().DigestionType = EntityDigestionType.Acidic;
		((ModNPC)this).NPC.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		((ModNPC)this).NPC.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		((ModNPC)this).NPC.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		((ModNPC)this).NPC.AsPred().GetVisualBellySize = GetVisualBellySize;
		((ModNPC)this).NPC.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		((ModNPC)this).NPC.AsPred().CanBeForceFed = CanFatassFairyBeForceFed;
		((ModNPC)this).NPC.AsPred().SmallBurps = Burps.Humanoid.Small;
		((ModNPC)this).NPC.AsPred().SmallBurpThreshold = 0.35;
		((ModNPC)this).NPC.AsPred().StandardBurps = Burps.Humanoid.Standard;
		((ModNPC)this).NPC.AsPred().SmallGulps = Gulps.Short;
		((ModNPC)this).NPC.AsPred().SmallGulpThreshold = 0.35;
		((ModNPC)this).NPC.AsPred().BigGulps = Gulps.Standard;
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (spawnInfo.SpawnTileType != 70)
		{
			return 0f;
		}
		return 0.015f;
	}

	public override void OnSpawn(IEntitySource source)
	{
		((Entity)((ModNPC)this).NPC).direction = Utils.ToDirectionInt(Utils.NextBool(Main.rand));
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		bestiaryEntry.Info.AddRange((IEnumerable<IBestiaryInfoElement>)(object)new IBestiaryInfoElement[2]
		{
			(IBestiaryInfoElement)Biomes.UndergroundMushroom,
			(IBestiaryInfoElement)new FlavorTextBestiaryInfoElement("Mods.V2.Bestiary.Mushroom.OversizedFairy")
		});
	}

	public static bool CanFatassFairyBeForceFed(NPC npc)
	{
		return true;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return ShroomFairyStuff.DigestDamage * 2.0;
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return ShroomFairyStuff.DigestRate;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return ShroomFairyStuff.AbsorbRate * 12.0;
	}

	public override bool CanHitPlayer(Player target, ref int cooldownSlot)
	{
		return false;
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return 0;
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return 0;
	}

	public override void AI()
	{
		((Entity)((ModNPC)this).NPC).velocity.X *= 0.9f;
		((Entity)((ModNPC)this).NPC).velocity.Y = Math.Min(((Entity)((ModNPC)this).NPC).velocity.Y + 0.3f, 10f);
		FatFuckMethods.OnUpdate(((ModNPC)this).NPC);
		FatFuckMethods.PushPlayers(((ModNPC)this).NPC);
	}

	public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		Rectangle sourceRect = default(Rectangle);
		((Rectangle)(ref sourceRect))._002Ector(0, 0, 170, 82);
		Texture2D sprite = ModContent.Request<Texture2D>("V2/NPCs/Voraria/Mushroom/FATFUCK", (AssetRequestMode)2).Value;
		spriteBatch.Draw(sprite, ((Entity)((ModNPC)this).NPC).position - Main.screenPosition - new Vector2(8f, 16f), (Rectangle?)sourceRect, drawColor, ((ModNPC)this).NPC.rotation, new Vector2(0f, 0f), 1f, (SpriteEffects)0, 0f);
		return false;
	}
}
