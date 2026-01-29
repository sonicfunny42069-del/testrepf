using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria;
using V2.PlayerHandling.PredPlayerGoals.Skilled;

namespace V2.NPCs.Voraria.Sky;

public class ObserverRed : ModNPC
{
	public override void SetStaticDefaults()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		Main.npcFrameCount[((ModNPC)this).NPC.type] = 3;
		NPCBestiaryDrawModifiers val = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref val))._002Ector();
		val.CustomTexturePath = "V2/NPCs/Voraria/Sky/ObserverRed";
		val.Position = new Vector2(0f, 8f);
		NPCBestiaryDrawModifiers drawModifiers = val;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).Type, drawModifiers);
	}

	public override void SetDefaults()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		((Entity)((ModNPC)this).NPC).width = 100;
		((Entity)((ModNPC)this).NPC).height = 100;
		((ModNPC)this).NPC.aiStyle = -1;
		((ModNPC)this).NPC.damage = 0;
		((ModNPC)this).NPC.defense = 42;
		((ModNPC)this).NPC.lifeMax = 250;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.DeathSound = SoundID.NPCDeath63;
		((ModNPC)this).NPC.value = 2500f;
		((ModNPC)this).NPC.noGravity = true;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 10.0;
		PreyNPC preyNPC = ((ModNPC)this).NPC.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnDigestedBy_GrantObserverGoal));
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		bestiaryEntry.Info.AddRange((IEnumerable<IBestiaryInfoElement>)(object)new IBestiaryInfoElement[3]
		{
			(IBestiaryInfoElement)Times.NightTime,
			(IBestiaryInfoElement)Biomes.Sky,
			(IBestiaryInfoElement)new FlavorTextBestiaryInfoElement("Mods.V2.Bestiary.Sky.Observer")
		});
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (!spawnInfo.Sky)
		{
			return 0f;
		}
		return 0.03f;
	}

	public override bool CanHitPlayer(Player target, ref int cooldownSlot)
	{
		return false;
	}

	public void boing(NPC Observer, Entity Victim)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (Observer != null && Victim != null)
		{
			float num = ((Vector2)(ref ((Entity)Observer).velocity)).Length();
			float Velocity2 = ((Vector2)(ref Victim.velocity)).Length();
			float CombinedSpeed = Math.Min((num + Velocity2) * 2f, 3f);
			Vector2 Direction = Utils.DirectionTo(((Entity)Observer).Center, Victim.Center);
			((Entity)Observer).velocity = Direction * (0f - CombinedSpeed);
			Victim.velocity = Direction * CombinedSpeed * 1.5f;
		}
	}

	public override void AI()
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.TargetClosest(false);
		if (((ModNPC)this).NPC.HasValidTarget)
		{
			Player target = Main.player[((ModNPC)this).NPC.target];
			if (target != null)
			{
				Vector2 direction = Utils.DirectionTo(((Entity)((ModNPC)this).NPC).Center, ((Entity)target).Center);
				((Vector2)(ref direction)).Normalize();
				NPC nPC = ((ModNPC)this).NPC;
				((Entity)nPC).velocity = ((Entity)nPC).velocity + direction / 50f;
			}
		}
		Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
		Rectangle hitbox;
		while (enumerator.MoveNext())
		{
			NPC npc = enumerator.Current;
			if (((ModNPC)this).NPC != npc && ((Entity)(object)npc).CurrentCaptor() == null && !npc.AsV2NPC().IsTileEntity)
			{
				hitbox = ((Entity)((ModNPC)this).NPC).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)npc).Hitbox))
				{
					boing(((ModNPC)this).NPC, (Entity)(object)npc);
				}
			}
		}
		Enumerator<Player> enumerator2 = Main.ActivePlayers.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			Player plr = enumerator2.Current;
			if (((Entity)(object)plr).CurrentCaptor() == null)
			{
				hitbox = ((Entity)((ModNPC)this).NPC).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)plr).Hitbox))
				{
					boing(((ModNPC)this).NPC, (Entity)(object)plr);
				}
			}
		}
	}

	public override void PostAI()
	{
		((ModNPC)this).NPC.rotation = Math.Clamp(((Entity)((ModNPC)this).NPC).velocity.X * 0.035f, -0.5f, 0.5f);
	}

	public override void FindFrame(int frameHeight)
	{
		int framerate = 5;
		NPC nPC = ((ModNPC)this).NPC;
		nPC.frameCounter += 1.0;
		if (((ModNPC)this).NPC.frameCounter >= (double)framerate)
		{
			((ModNPC)this).NPC.frameCounter = 0.0;
			((ModNPC)this).NPC.frame.Y += 114;
			if (((ModNPC)this).NPC.frame.Y >= 342)
			{
				((ModNPC)this).NPC.frame.Y = 0;
			}
		}
	}

	public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		Rectangle sourceRect = default(Rectangle);
		((Rectangle)(ref sourceRect))._002Ector(0, ((ModNPC)this).NPC.frame.Y, 100, 114);
		Texture2D sprite = ModContent.Request<Texture2D>("V2/NPCs/Voraria/Sky/ObserverBody", (AssetRequestMode)2).Value;
		spriteBatch.Draw(sprite, ((Entity)((ModNPC)this).NPC).position - Main.screenPosition, (Rectangle?)sourceRect, drawColor, ((ModNPC)this).NPC.rotation, new Vector2(0f, 0f), 1f, (SpriteEffects)0, 0f);
		Rectangle sourceRect2 = default(Rectangle);
		((Rectangle)(ref sourceRect2))._002Ector(0, 0, 20, 20);
		Texture2D sprite2 = ModContent.Request<Texture2D>("V2/NPCs/Voraria/Sky/ObserverEye", (AssetRequestMode)2).Value;
		Vector2 EyeDirection = Vector2.Zero;
		if (((ModNPC)this).NPC.HasValidTarget)
		{
			EyeDirection = Utils.DirectionTo(((Entity)((ModNPC)this).NPC).Center, ((Entity)Main.player[((ModNPC)this).NPC.target]).Center) * 20f;
		}
		spriteBatch.Draw(sprite2, ((Entity)((ModNPC)this).NPC).Center - Main.screenPosition + EyeDirection, (Rectangle?)sourceRect2, drawColor, 0f, new Vector2(10f, 10f), 1f, (SpriteEffects)0, 0f);
		return false;
	}

	public override void HitEffect(HitInfo hit)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode != 2 && ((ModNPC)this).NPC.life <= 0)
		{
			int Gore1 = ((ModType)this).Mod.Find<ModGore>("Gore_Observer").Type;
			int Gore2 = ((ModType)this).Mod.Find<ModGore>("Gore_ObserverRed").Type;
			for (int i = 0; i < 10; i++)
			{
				Gore.NewGore(((Entity)((ModNPC)this).NPC).GetSource_Death((string)null), ((Entity)((ModNPC)this).NPC).Center, new Vector2((float)Main.rand.Next(-60, 61) / 10f, (float)Main.rand.Next(-70, 61) / 10f), Gore1, 1f);
			}
			Gore.NewGore(((Entity)((ModNPC)this).NPC).GetSource_Death((string)null), ((Entity)((ModNPC)this).NPC).Center + new Vector2(0f, 30f), new Vector2(0f, 1.5f), Gore2, 1f);
		}
	}

	public static void OnDigestedBy_GrantObserverGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatObserver>().TrySetCompletion(predPlayer);
		}
	}

	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0031: Expected O, but got Unknown
		//IL_0031: Expected O, but got Unknown
		((NPCLoot)(ref npcLoot)).Add((IItemDropRule)(object)new V2CommonDropRules.DifficultyScalingDrop((IItemDropRule)new CommonDrop(ModContent.ItemType<ObserverPupil>(), 1, 1, 1, 1), (IItemDropRule)new CommonDrop(ModContent.ItemType<ObserverPupil>(), 1, 1, 1, 1), (IItemDropRule)new CommonDrop(ModContent.ItemType<ObserverPupil>(), 1, 1, 1, 1)));
	}
}
