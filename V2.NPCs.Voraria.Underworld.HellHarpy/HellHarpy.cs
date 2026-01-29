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
using V2.Items.Voraria.Consumables;
using V2.Sounds.Vore;

namespace V2.NPCs.Voraria.Underworld.HellHarpy;

public class HellHarpy : ModNPC
{
	public override void SetStaticDefaults()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		NPCBestiaryDrawModifiers val = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref val))._002Ector();
		val.CustomTexturePath = "V2/NPCs/Voraria/Underworld/HellHarpy/HellHarpy";
		val.Position = new Vector2(0f, 22f);
		NPCBestiaryDrawModifiers drawModifiers = val;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).Type, drawModifiers);
	}

	public override void SetDefaults()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		((Entity)((ModNPC)this).NPC).width = 48;
		((Entity)((ModNPC)this).NPC).height = 100;
		((ModNPC)this).NPC.aiStyle = -1;
		((ModNPC)this).NPC.damage = 30;
		((ModNPC)this).NPC.defense = 15;
		((ModNPC)this).NPC.lifeMax = 6000;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.DeathSound = SoundID.NPCDeath1;
		((ModNPC)this).NPC.value = 37500f;
		((ModNPC)this).NPC.noGravity = true;
		((ModNPC)this).NPC.noTileCollide = true;
		((ModNPC)this).NPC.knockBackResist = 0f;
		((ModNPC)this).NPC.behindTiles = true;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 19.5;
		((ModNPC)this).NPC.AsPred().WeightGainRatio = 0.111;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 11.0;
		((ModNPC)this).NPC.AsPred().BaseStomachacheMeterCapacity = 775.0;
		((ModNPC)this).NPC.AsPred().DigestionType = EntityDigestionType.Acidic;
		((ModNPC)this).NPC.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		((ModNPC)this).NPC.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		((ModNPC)this).NPC.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		((ModNPC)this).NPC.AsPred().GetVisualBellySize = GetVisualBellySize;
		((ModNPC)this).NPC.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		((ModNPC)this).NPC.AsPred().CanBeForceFed = CanHellHarpyBeForceFed;
		((ModNPC)this).NPC.AsPred().SmallBurps = Burps.Humanoid.Small;
		((ModNPC)this).NPC.AsPred().SmallBurpThreshold = 0.35;
		((ModNPC)this).NPC.AsPred().StandardBurps = Burps.Humanoid.Standard;
		((ModNPC)this).NPC.AsPred().SmallGulps = Gulps.Short;
		((ModNPC)this).NPC.AsPred().SmallGulpThreshold = 0.35;
		((ModNPC)this).NPC.AsPred().BigGulps = Gulps.Standard;
	}

	public override void OnSpawn(IEntitySource source)
	{
		((Entity)((ModNPC)this).NPC).velocity.Y = -7f;
		((ModNPC)this).NPC.ai[1] = -100f;
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		bestiaryEntry.Info.AddRange((IEnumerable<IBestiaryInfoElement>)(object)new IBestiaryInfoElement[2]
		{
			(IBestiaryInfoElement)Biomes.TheUnderworld,
			(IBestiaryInfoElement)new FlavorTextBestiaryInfoElement("Mods.V2.Bestiary.Underworld.HellHarpy")
		});
	}

	public static bool CanHellHarpyBeForceFed(NPC npc)
	{
		return true;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 33.0;
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 1.5;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 0, 15);
	}

	public override bool CanHitPlayer(Player target, ref int cooldownSlot)
	{
		return false;
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(2.75 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 7);
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return Math.Min((int)Math.Floor(2.0 * Math.Sqrt(npc.AsPred().ExtraWeight)), 3);
	}

	public Entity FindClosestTarget()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		Vector2 center = ((Entity)((ModNPC)this).NPC).Center;
		float num = float.MaxValue;
		Entity target = null;
		bool FoundCandy = false;
		Enumerator<Item> enumerator = Main.ActiveItems.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Item item = enumerator.Current;
			if (((Entity)item).active && item.type == ModContent.ItemType<DemonCandy>() && ((Entity)(object)item).CurrentCaptor() == null)
			{
				float num3 = Vector2.DistanceSquared(center, ((Entity)item).Center);
				if (num3 < num)
				{
					num = num3;
					target = (Entity)(object)item;
					FoundCandy = true;
				}
			}
		}
		if (!FoundCandy)
		{
			Enumerator<Player> enumerator2 = Main.ActivePlayers.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				Player plr = enumerator2.Current;
				if (((Entity)plr).active && !plr.dead && !plr.ghost && ((Entity)(object)plr).CurrentCaptor() == null)
				{
					float num4 = Vector2.DistanceSquared(center, ((Entity)plr).Center);
					if (num4 < num)
					{
						num = num4;
						target = (Entity)(object)plr;
					}
				}
			}
			Enumerator<NPC> enumerator3 = Main.ActiveNPCs.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				NPC npc = enumerator3.Current;
				if (((Entity)npc).active && npc.type != 25 && ((Entity)(object)npc).CurrentCaptor() == null && npc != ((ModNPC)this).NPC && npc.AsFood().DefinedEffectiveSize < 7.0 && PreyData.GetPreySize((Entity)(object)npc) < ((ModNPC)this).NPC.AsPred().MaxStomachCapacity - PredNPC.GetCurrentBellyWeight(((ModNPC)this).NPC) && !npc.AsFood().CannotBeEatenDueToShenanigans)
				{
					float num5 = Vector2.DistanceSquared(center, ((Entity)npc).Center);
					if (num5 < num)
					{
						num = num5;
						target = (Entity)(object)npc;
					}
				}
			}
		}
		return target;
	}

	public override void AI()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		Entity Target = FindClosestTarget();
		((ModNPC)this).NPC.ai[0] += 1f;
		if (((ModNPC)this).NPC.ai[0] >= 100f)
		{
			((ModNPC)this).NPC.ai[0] = 40f;
		}
		if (((ModNPC)this).NPC.ai[2] >= 5f)
		{
			((ModNPC)this).NPC.ai[2] += 1f;
		}
		if (((ModNPC)this).NPC.ai[2] >= 30f)
		{
			((ModNPC)this).NPC.ai[2] = 0f;
		}
		if (Target != null && Target.Distance(((Entity)((ModNPC)this).NPC).Center) < 1000f)
		{
			if (((ModNPC)this).NPC.ai[1] > 0f)
			{
				((ModNPC)this).NPC.ai[1] = -100f;
			}
			if (Target is Player)
			{
				((ModNPC)this).NPC.ai[1] -= 1f;
				if (((ModNPC)this).NPC.ai[1] <= (float)(Main.expertMode ? (-240) : (-290)))
				{
					((ModNPC)this).NPC.frame.X = 46;
				}
				else if (((ModNPC)this).NPC.ai[1] > -90f)
				{
					((ModNPC)this).NPC.frame.X = 92;
				}
				else if (((ModNPC)this).NPC.ai[1] > -100f)
				{
					((ModNPC)this).NPC.frame.X = 46;
				}
				else
				{
					((ModNPC)this).NPC.frame.X = 0;
				}
				if (((ModNPC)this).NPC.ai[1] <= (float)(Main.expertMode ? (-250) : (-300)) && Main.netMode != 1)
				{
					((ModNPC)this).NPC.ai[1] = -70f;
					Vector2 Velocity = Target.DirectionFrom(((Entity)((ModNPC)this).NPC).Center - new Vector2(19f, 55f));
					Velocity *= 9f;
					Projectile.NewProjectileDirect(((Entity)((ModNPC)this).NPC).GetSource_FromAI((string)null), ((Entity)((ModNPC)this).NPC).Center - new Vector2(19f, 55f), Velocity, 258, ((ModNPC)this).NPC.damage, 0f, -1, 0f, 0f, 0f);
				}
			}
			else
			{
				((ModNPC)this).NPC.frame.X = 0;
			}
			int TargetDirection = 0;
			TargetDirection = ((Target.Center.X >= ((Entity)((ModNPC)this).NPC).Center.X) ? 1 : (-1));
			((Entity)((ModNPC)this).NPC).velocity.X = Math.Clamp(((Entity)((ModNPC)this).NPC).velocity.X + 0.07f * (float)TargetDirection, -4.5f, 4.5f);
			((Entity)((ModNPC)this).NPC).velocity.Y = Math.Clamp(((Entity)((ModNPC)this).NPC).velocity.Y + 0.05f * (1f + (float)GetVisualBellySize(((ModNPC)this).NPC) / 10f), -7f, 4f);
			if (((ModNPC)this).NPC.ai[0] >= 40f && ((Entity)((ModNPC)this).NPC).Center.Y > Target.Center.Y + 45f && ((ModNPC)this).NPC.ai[0] >= (float)(40 - GetVisualBellySize(((ModNPC)this).NPC) * 3))
			{
				((ModNPC)this).NPC.ai[0] = 0f;
				((ModNPC)this).NPC.ai[2] = 5f;
				((Entity)((ModNPC)this).NPC).velocity.Y = Math.Clamp(((Entity)((ModNPC)this).NPC).velocity.Y - 4f, -5f, 4f);
			}
			Rectangle MouthHitbox = default(Rectangle);
			((Rectangle)(ref MouthHitbox))._002Ector((int)((Entity)((ModNPC)this).NPC).Center.X - 30, (int)((Entity)((ModNPC)this).NPC).Center.Y - 85, 60, 60);
			if (((Rectangle)(ref MouthHitbox)).Intersects(Target.Hitbox))
			{
				PredNPC.Swallow(((ModNPC)this).NPC, Target);
			}
		}
		else
		{
			if (((ModNPC)this).NPC.ai[1] <= 0f)
			{
				((ModNPC)this).NPC.ai[1] = ((Entity)((ModNPC)this).NPC).Center.Y;
			}
			((ModNPC)this).NPC.frame.X = 0;
			((Entity)((ModNPC)this).NPC).velocity.X = Math.Clamp(((Entity)((ModNPC)this).NPC).velocity.X * 0.9f, -4.5f, 4.5f);
			((Entity)((ModNPC)this).NPC).velocity.Y = Math.Clamp(((Entity)((ModNPC)this).NPC).velocity.Y + 0.05f * (1f + (float)GetVisualBellySize(((ModNPC)this).NPC) / 10f), -7f, 4f);
			if (((Entity)((ModNPC)this).NPC).Center.Y > ((ModNPC)this).NPC.ai[1] && ((ModNPC)this).NPC.ai[0] >= (float)(40 - GetVisualBellySize(((ModNPC)this).NPC) * 3))
			{
				((ModNPC)this).NPC.ai[0] = 0f;
				((ModNPC)this).NPC.ai[2] = 5f;
				((Entity)((ModNPC)this).NPC).velocity.Y = Math.Clamp(((Entity)((ModNPC)this).NPC).velocity.Y - 4f, -5f, 4f);
			}
		}
	}

	public override void FindFrame(int frameHeight)
	{
		int framerate = 5;
		NPC nPC = ((ModNPC)this).NPC;
		nPC.frameCounter += 1.0;
		if (((ModNPC)this).NPC.frameCounter >= (double)framerate)
		{
			((ModNPC)this).NPC.frameCounter = 0.0;
			((ModNPC)this).NPC.frame.Y += 98;
			if (((ModNPC)this).NPC.frame.Y >= 196)
			{
				((ModNPC)this).NPC.frame.Y = 0;
			}
			if (((ModNPC)this).NPC.ai[2] >= 1f)
			{
				int Frame = (int)Math.Floor(((ModNPC)this).NPC.ai[2] / 5f);
				((ModNPC)this).NPC.frame.Y = 98 + 98 * Frame;
			}
		}
	}

	public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		Rectangle sourceRectWings = default(Rectangle);
		((Rectangle)(ref sourceRectWings))._002Ector(0, ((ModNPC)this).NPC.frame.Y, 218, 98);
		Texture2D spriteWings = ModContent.Request<Texture2D>("V2/NPCs/Voraria/Underworld/HellHarpy/HellHarpyWings", (AssetRequestMode)2).Value;
		spriteBatch.Draw(spriteWings, ((Entity)((ModNPC)this).NPC).Center - Main.screenPosition - new Vector2(109f, 86f), (Rectangle?)sourceRectWings, drawColor, ((ModNPC)this).NPC.rotation, new Vector2(0f, 0f), 1f, (SpriteEffects)0, 0f);
		Rectangle sourceRectBody = default(Rectangle);
		((Rectangle)(ref sourceRectBody))._002Ector(82 * GetVisualBellySize(((ModNPC)this).NPC), 100 * GetVisualWeightStage(((ModNPC)this).NPC), 82, 100);
		Texture2D spriteBody = ModContent.Request<Texture2D>("V2/NPCs/Voraria/Underworld/HellHarpy/HellHarpyBody", (AssetRequestMode)2).Value;
		spriteBatch.Draw(spriteBody, ((Entity)((ModNPC)this).NPC).Center - Main.screenPosition - new Vector2(41f, 50f), (Rectangle?)sourceRectBody, drawColor, ((ModNPC)this).NPC.rotation, new Vector2(0f, 0f), 1f, (SpriteEffects)0, 0f);
		Rectangle sourceRectHead = default(Rectangle);
		((Rectangle)(ref sourceRectHead))._002Ector(0, ((ModNPC)this).NPC.frame.X, 38, 46);
		Texture2D spriteHead = ModContent.Request<Texture2D>("V2/NPCs/Voraria/Underworld/HellHarpy/HellHarpyHead", (AssetRequestMode)2).Value;
		spriteBatch.Draw(spriteHead, ((Entity)((ModNPC)this).NPC).Center - Main.screenPosition - new Vector2(19f, 88f), (Rectangle?)sourceRectHead, drawColor, ((ModNPC)this).NPC.rotation, new Vector2(0f, 0f), 1f, (SpriteEffects)0, 0f);
		return false;
	}

	public override void HitEffect(HitInfo hit)
	{
		if (Main.netMode != 2)
		{
			_ = ((ModNPC)this).NPC.life;
			_ = 0;
		}
	}
}
