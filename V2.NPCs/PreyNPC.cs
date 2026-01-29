using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.Items;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.PlayerHandling.PredPlayerGoals.Starter;
using V2.Sounds.MuffledSounds;
using V2.StatusEffects.Voraria.Debuffs;

namespace V2.NPCs;

public class PreyNPC : GlobalNPC
{
	public delegate void DelegatePreyAI(NPC npc, Entity pred);

	public delegate void DelegateOnSwallowedBy(NPC npc, Entity pred);

	public delegate void DelegateOnKilledByDigestion(NPC npc, Entity pred);

	public SoundStyle? DigestingHitSound;

	public SoundStyle? DigestedDeathSound;

	public bool CannotBeEatenDueToShenanigans { get; set; }

	public int EatenSafetyFrames { get; set; }

	public bool Digested { get; set; }

	public DelegatePreyAI SpecialPreyAI { get; set; }

	public double DefinedBaseSize { get; set; }

	public double DefinedEffectiveSize { get; set; }

	public bool TastySweet { get; set; }

	public bool TastySpicy { get; set; }

	public bool TastySour { get; set; }

	public bool TastyMeaty { get; set; }

	public bool TastyBitter { get; set; }

	public bool TastyFruity { get; set; }

	public DelegateOnSwallowedBy OnSwallowedBy { get; set; }

	public int STR { get; set; }

	public int StruggleEffectiveness { get; set; }

	public StatModifier StruggleStrengthModifier { get; set; }

	public double StruggleStrength
	{
		get
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			double baseStruggleStrength = 1.5;
			baseStruggleStrength += 0.3 * (double)STR;
			StatModifier struggleStrengthModifier = StruggleStrengthModifier;
			return ((StatModifier)(ref struggleStrengthModifier)).ApplyTo((float)baseStruggleStrength);
		}
	}

	public DelegateOnKilledByDigestion OnDigestedBy { get; set; }

	public bool CanChatAsPrey { get; set; }

	public StatModifier TakenDigestionDamageModifier { get; set; }

	public double SoftenedDigestionDamageTaken { get; set; }

	public StatModifier SoftenedDigestionDamageModifier { get; set; }

	public int SoftenedWearoffDelay { get; set; }

	public static int SoftenedWearoffMaxDelay => V2Utils.SensibleTime(0, 0, 2, 30);

	public StatModifier SoftenedWearoffRateModifier { get; set; }

	public override bool InstancePerEntity => true;

	public static Dictionary<SoundStyle, SoundStyle> DigestingHitSoundDatabase { get; set; } = new Dictionary<SoundStyle, SoundStyle>
	{
		{
			SoundID.NPCHit1,
			MuffledNPCSounds.NPCHit1
		},
		{
			SoundID.NPCHit2,
			MuffledNPCSounds.NPCHit2
		},
		{
			SoundID.NPCHit3,
			MuffledNPCSounds.NPCHit3
		},
		{
			SoundID.NPCHit4,
			MuffledNPCSounds.NPCHit4
		}
	};

	public static Dictionary<SoundStyle, SoundStyle> DigestedDeathSoundDatabase { get; set; } = new Dictionary<SoundStyle, SoundStyle>
	{
		{
			SoundID.NPCDeath1,
			MuffledNPCSounds.NPCDeath1
		},
		{
			SoundID.NPCDeath2,
			MuffledNPCSounds.NPCDeath2
		}
	};

	public static double LeftoversHealthModifier => 0.9;

	public List<ItemTheftRule> ItemTheftRules { get; set; }

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return true;
	}

	public PreyNPC()
	{
		SpecialPreyAI = null;
		DefinedBaseSize = 0.0;
		STR = 0;
		StruggleEffectiveness = 5;
		OnDigestedBy = null;
		CanChatAsPrey = false;
		DigestingHitSound = null;
		DigestedDeathSound = null;
	}

	public override void SetDefaults(NPC npc)
	{
		if (!Sets.ProjectileNPC[npc.type])
		{
			PreyNPC preyNPC = npc.AsFood();
			preyNPC.OnDigestedBy = (DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new DelegateOnKilledByDigestion(OnKilledByDigestion_GrantLivePreyGoal));
		}
		PreyNPC preyNPC2 = npc.AsFood();
		preyNPC2.OnDigestedBy = (DelegateOnKilledByDigestion)Delegate.Combine(preyNPC2.OnDigestedBy, new DelegateOnKilledByDigestion(HandlePreyItemTheft));
	}

	public override void ResetEffects(NPC npc)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		npc.AsFood().Digested = false;
		npc.AsFood().STR = (int)((double)npc.lifeMax / 40.0) + (int)((double)npc.damage / 25.0) + (int)(npc.AsFood().DefinedBaseSize / 25.0);
		npc.AsFood().StruggleStrengthModifier = StatModifier.Default;
		npc.AsFood().TakenDigestionDamageModifier = StatModifier.Default;
		if (npc.AsFood().EatenSafetyFrames > 0)
		{
			npc.AsFood().EatenSafetyFrames--;
		}
		if (!npc.HasBuff(ModContent.BuffType<Softened>()))
		{
			npc.AddBuff(ModContent.BuffType<Softened>(), 3, false);
		}
		npc.AsFood().SoftenedDigestionDamageModifier = StatModifier.Default;
		npc.AsFood().SoftenedWearoffRateModifier = StatModifier.Default;
		if (npc.AsFood().SoftenedWearoffDelay > 0)
		{
			npc.AsFood().SoftenedWearoffDelay--;
		}
		else if (npc.AsFood().SoftenedDigestionDamageTaken > 0.0)
		{
			PreyNPC preyNPC = npc.AsFood();
			double softenedDigestionDamageTaken = preyNPC.SoftenedDigestionDamageTaken;
			StatModifier softenedWearoffRateModifier = npc.AsFood().SoftenedWearoffRateModifier;
			preyNPC.SoftenedDigestionDamageTaken = softenedDigestionDamageTaken - (double)((StatModifier)(ref softenedWearoffRateModifier)).ApplyTo(5f / 12f);
		}
		npc.AsFood().TastySweet = false;
		npc.AsFood().TastySpicy = false;
		npc.AsFood().TastySour = false;
		npc.AsFood().TastyMeaty = false;
		npc.AsFood().TastyBitter = false;
		npc.AsFood().TastyFruity = false;
		npc.AsFood().DefinedEffectiveSize = npc.AsFood().DefinedBaseSize;
		DetermineDigestingSounds(npc);
	}

	public static void DetermineDigestingSounds(NPC npc)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle? hitSound = npc.HitSound;
		if (hitSound.HasValue && DigestingHitSoundDatabase.ContainsKey(npc.HitSound.Value))
		{
			npc.AsFood().DigestingHitSound = DigestingHitSoundDatabase[npc.HitSound.Value];
		}
		hitSound = npc.DeathSound;
		if (hitSound.HasValue && DigestedDeathSoundDatabase.ContainsKey(npc.DeathSound.Value))
		{
			npc.AsFood().DigestedDeathSound = DigestedDeathSoundDatabase[npc.DeathSound.Value];
		}
	}

	public override bool CanHitNPC(NPC npc, NPC target)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null || ((Entity)(object)target).CurrentCaptor() != null || npc.AsFood().EatenSafetyFrames > 0 || target.AsFood().EatenSafetyFrames > 0)
		{
			return false;
		}
		return true;
	}

	public override bool CanHitPlayer(NPC npc, Player target, ref int cooldownSlot)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null || npc.AsFood().EatenSafetyFrames > 0)
		{
			return false;
		}
		return true;
	}

	public override bool? CanBeHitByItem(NPC npc, Player player, Item item)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		return null;
	}

	public override bool? CanBeHitByProjectile(NPC npc, Projectile projectile)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		return null;
	}

	public override bool? CanBeCaughtBy(NPC npc, Item item, Player player)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		return null;
	}

	public override void ModifyHoverBoundingBox(NPC npc, ref Rectangle boundingBox)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			boundingBox = Rectangle.Empty;
		}
	}

	public override void ModifyHitNPC(NPC npc, NPC target, ref HitModifiers modifiers)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (target.type == ModContent.NPCType<Lucinda>() && PredNPC.CanSwallow(target, (Entity)(object)npc))
		{
			ref StatModifier finalDamage = ref modifiers.FinalDamage;
			finalDamage *= 0f;
			modifiers.Knockback.Base = 0f;
			((HitModifiers)(ref modifiers)).DisableCrit();
		}
	}

	public override void OnHitNPC(NPC npc, NPC target, HitInfo hit)
	{
		if (target.type == ModContent.NPCType<Lucinda>())
		{
			PredNPC.Swallow(target, (Entity)(object)npc);
		}
	}

	public override bool? CanChat(NPC npc)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return npc.AsFood().CanChatAsPrey;
		}
		return null;
	}

	public override bool? DrawHealthBar(NPC npc, byte hbPosition, ref float scale, ref Vector2 position)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		return null;
	}

	public static bool TakeDigestionDamage(NPC npc, Entity pred, double digestionDamage, bool voodoo = true)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		if (npc.life <= 0)
		{
			return true;
		}
		if (npc.realLife != -1 && npc.realLife != ((Entity)npc).whoAmI)
		{
			return false;
		}
		int num2;
		if (!voodoo)
		{
			float num = (float)digestionDamage;
			Player playerPred = (Player)(object)((pred is Player) ? pred : null);
			num2 = Main.DamageVar(num, (playerPred != null) ? (0f - playerPred.luck) : 0f);
		}
		else
		{
			num2 = (int)Math.Round(digestionDamage);
		}
		int trueDigestionDamage = num2;
		if (ModContent.GetInstance<V2ServerConfig>().DefenseInDigestionCalcs && !voodoo)
		{
			trueDigestionDamage -= npc.defense;
		}
		if (trueDigestionDamage < 1)
		{
			trueDigestionDamage = 1;
		}
		StatModifier val = npc.AsFood().TakenDigestionDamageModifier;
		trueDigestionDamage = (int)Math.Floor(((StatModifier)(ref val)).ApplyTo((float)trueDigestionDamage));
		PreyNPC preyNPC = npc.AsFood();
		double softenedDigestionDamageTaken = preyNPC.SoftenedDigestionDamageTaken;
		val = npc.AsFood().SoftenedDigestionDamageModifier;
		preyNPC.SoftenedDigestionDamageTaken = softenedDigestionDamageTaken + (double)((StatModifier)(ref val)).ApplyTo((float)trueDigestionDamage);
		npc.AsFood().SoftenedWearoffDelay = SoftenedWearoffMaxDelay;
		npc.life -= trueDigestionDamage;
		switch (Main.netMode)
		{
		case 0:
			if (ModContent.GetInstance<V2ClientConfig>().ShowChurnDamageNumbers)
			{
				CombatText obj = Main.combatText[CombatText.NewText(((Entity)npc).Hitbox, npc.friendly ? Color.DarkGreen : Color.LimeGreen, trueDigestionDamage, false, true)];
				obj.position.X = ((Entity)(voodoo ? ((object)npc) : ((object)pred))).Center.X + (float)(((Entity)(voodoo ? ((object)npc) : ((object)pred))).direction * 28);
				obj.position.Y = ((Entity)npc).Center.Y + (float)((Entity)npc).height / 5f;
				obj.velocity.X = (float)((Entity)(voodoo ? ((object)npc) : ((object)pred))).direction * 2.5f;
				obj.velocity.Y = -4f;
			}
			break;
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)5);
			((BinaryWriter)(object)packet).Write(((Entity)npc).whoAmI);
			((BinaryWriter)(object)packet).Write(trueDigestionDamage);
			((BinaryWriter)(object)packet).Write(((Entity)(voodoo ? ((object)npc) : ((object)pred))).Center.X + (float)(((Entity)(voodoo ? ((object)npc) : ((object)pred))).direction * 28));
			((BinaryWriter)(object)packet).Write(((Entity)npc).Center.Y + (float)((Entity)npc).height / 5f);
			((BinaryWriter)(object)packet).Write((float)((Entity)(voodoo ? ((object)npc) : ((object)pred))).direction * 2.5f);
			((BinaryWriter)(object)packet).Write(-4f);
			packet.Send(-1, -1);
			break;
		}
		}
		if (npc.life <= 0)
		{
			npc.life = 0;
			npc.checkDead();
			NetMessage.TrySendData(23, -1, -1, (NetworkText)null, ((Entity)npc).whoAmI, 0f, 0f, 0f, 0, 0, 0);
			return true;
		}
		npc.netUpdate = true;
		return false;
	}

	public static double GetCurrentTotalWeight(NPC npc)
	{
		double preySize = PreyData.GetPreySize((Entity)(object)npc);
		double bellyWeight = PredNPC.GetCurrentBellyWeight(npc);
		return preySize + bellyWeight;
	}

	public override bool CheckActive(NPC npc)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}

	public static void OnKilledByDigestion_GrantLivePreyGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<FirstLivePrey>().TrySetCompletion(predPlayer);
		}
	}

	public static void HandlePreyItemTheft(NPC npc, Entity pred)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		if (!npc.CanItemsBeThievedBy(pred) || npc.AsFood().ItemTheftRules == null || npc.AsFood().ItemTheftRules.Count <= 0)
		{
			return;
		}
		foreach (ItemTheftRule rule in npc.AsFood().ItemTheftRules)
		{
			double ruleChance = rule.ItemChance(npc, pred);
			if (!(pred is Player))
			{
				ruleChance /= 10.0;
			}
			if (Main.rand.NextDouble() >= ruleChance)
			{
				continue;
			}
			Vector2 mouthOffset = Vector2.Zero;
			Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
			if (predPlayer != null)
			{
				((Vector2)(ref mouthOffset))._002Ector((float)((Entity)predPlayer).direction * 8f, -14f);
			}
			else
			{
				NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
				if (predNPC != null)
				{
					mouthOffset = PredNPC.MouthSoundOffset(predNPC);
				}
			}
			int itemType = rule.ItemType(npc, pred);
			int itemAmount = rule.ItemAmount(npc, pred);
			int belchedUpLeftovers = CommonCode.DropItem(pred.TrueCenter() + mouthOffset, ((Entity)npc).GetSource_Loot("V2: Digestion Kill Item Theft"), itemType, itemAmount);
			Item belchedUpItem = Main.item[belchedUpLeftovers];
			belchedUpItem.AsFood().Health = (int)Math.Round(LeftoversHealthModifier * (double)belchedUpItem.AsFood().MaxHealth);
			((Entity)belchedUpItem).position = ((Entity)belchedUpItem).position + Utils.RotatedByRandom(new Vector2(Utils.NextFloat(Main.rand, 1f), 0f), (double)MathHelper.ToRadians(360f));
			((Entity)belchedUpItem).velocity = new Vector2((float)pred.direction * 10f, -2.5f);
			((Entity)belchedUpItem).velocity = ((Entity)belchedUpItem).velocity * Utils.NextFloat(Main.rand, 0.98f, 1.02f);
			((Entity)belchedUpItem).velocity = Utils.RotatedByRandom(((Entity)belchedUpItem).velocity, (double)MathHelper.ToRadians(12f));
			belchedUpItem.noGrabDelay = 100;
			NetMessage.SendData(21, -1, -1, (NetworkText)null, belchedUpLeftovers, 1f, 0f, 0f, 0, 0, 0);
		}
	}
}
