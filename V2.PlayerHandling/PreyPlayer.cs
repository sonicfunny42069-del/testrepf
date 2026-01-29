using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;
using V2.Items;
using V2.NPCs;
using V2.Projectiles;
using V2.StatusEffects.Voraria.Debuffs;

namespace V2.PlayerHandling;

public class PreyPlayer : ModPlayer
{
	public (int _swallowCount, int _gurgleCount) _timesEaten;

	public StatModifier TakenDigestionDamageModifier;

	public StatModifier SoftenedDigestionDamageModifier;

	public StatModifier SoftenedWearoffRateModifier;

	public bool Digested { get; set; }

	public int TotalTimesSwallowed
	{
		get
		{
			return _timesEaten._swallowCount;
		}
		set
		{
			_timesEaten._swallowCount = value;
		}
	}

	public int TotalTimesDigested
	{
		get
		{
			return _timesEaten._gurgleCount;
		}
		set
		{
			_timesEaten._gurgleCount = value;
		}
	}

	public double SoftenedDigestionDamageTaken { get; set; }

	public int SoftenedWearoffDelay { get; set; }

	public static int SoftenedWearoffMaxDelay => V2Utils.SensibleTime(0, 0, 2, 30);

	public int SoftenedStacks => Math.Min(Softened.MaxStacks, (int)Math.Floor(SoftenedDigestionDamageTaken / ((double)((ModPlayer)this).Player.statLifeMax * Softened.MaxHealthDigestedForOneStack)));

	public bool PredScanner { get; set; }

	public bool PerfectMeal { get; set; }

	public bool GuttedGaze { get; set; }

	public Entity GuttedGazePred { get; set; }

	public PredStat STR { get; set; }

	public StatModifier StruggleStrengthModifier { get; set; }

	public double StruggleStrength
	{
		get
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			double baseStruggleStrength = 1.5;
			baseStruggleStrength += 0.3 * (double)STR.Total;
			StatModifier struggleStrengthModifier = StruggleStrengthModifier;
			return ((StatModifier)(ref struggleStrengthModifier)).ApplyTo((float)baseStruggleStrength);
		}
	}

	public override void Initialize()
	{
		STR = new PredStat();
		Digested = false;
		SoftenedDigestionDamageTaken = 0.0;
		SoftenedWearoffDelay = 0;
	}

	public override void OnEnterWorld()
	{
		Digested = false;
		SoftenedDigestionDamageTaken = 0.0;
		SoftenedWearoffDelay = 0;
	}

	public override void ResetEffects()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		Digested = false;
		StruggleStrengthModifier = StatModifier.Default;
		TakenDigestionDamageModifier = StatModifier.Default;
		if (!((ModPlayer)this).Player.HasBuff(ModContent.BuffType<Softened>()))
		{
			((ModPlayer)this).Player.AddBuff(ModContent.BuffType<Softened>(), 3, true, false);
		}
		SoftenedDigestionDamageModifier = StatModifier.Default;
		SoftenedWearoffRateModifier = StatModifier.Default;
		if (SoftenedWearoffDelay > 0)
		{
			SoftenedWearoffDelay--;
		}
		PredScanner = false;
		PerfectMeal = false;
		GuttedGaze = false;
	}

	public override void UpdateDead()
	{
		SoftenedDigestionDamageTaken = 0.0;
		SoftenedWearoffDelay = 0;
	}

	public override void ModifyScreenPosition()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode != 2 && ((Entity)((ModPlayer)this).Player).whoAmI == Main.myPlayer && GuttedGaze)
		{
			if (GuttedGazePred != null && GuttedGazePred.active)
			{
				Main.screenPosition = GuttedGazePred.Center - new Vector2((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2));
			}
			if (V2.RespawnAfterDigestionHotkey.JustPressed)
			{
				((ModPlayer)this).Player.respawnTimer = 0;
			}
			else
			{
				((ModPlayer)this).Player.respawnTimer = 888;
			}
		}
	}

	public override void PreUpdateMovement()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)((ModPlayer)this).Player).wet)
		{
			SoftenedWearoffRateModifier *= 2f;
		}
		if (SoftenedWearoffDelay <= 0 && SoftenedDigestionDamageTaken > 0.0)
		{
			SoftenedDigestionDamageTaken -= ((StatModifier)(ref SoftenedWearoffRateModifier)).ApplyTo(5f / 12f);
			if (SoftenedDigestionDamageTaken < 0.0)
			{
				SoftenedDigestionDamageTaken = 0.0;
			}
		}
	}

	public override void PostUpdateBuffs()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		Player player = ((ModPlayer)this).Player;
		player.statDefense *= (float)(1.0 - Softened.DefenseReductionPerStack * (double)SoftenedStacks);
		PreyPlayer preyPlayer = ((ModPlayer)this).Player.AsFood();
		preyPlayer.TakenDigestionDamageModifier *= (float)(1.0 + (double)(Softened.DigestionDamageIncreasePerStack * (float)SoftenedStacks));
	}

	public override void PostItemCheck()
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode == 2 || ((Entity)((ModPlayer)this).Player).whoAmI != Main.myPlayer || !V2.FeedHotkey.JustPressed)
		{
			return;
		}
		if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
		{
			Main.NewText("Attempting to force-feed " + ((ModPlayer)this).Player.name + " to nearby predators...", byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
		if (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null)
		{
			if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
			{
				Main.NewText("Force-feed attempt failed; " + ((ModPlayer)this).Player.name + " is already busy being food.", byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			return;
		}
		string predType = "none";
		int predIndex = -1;
		Vector2 playerLocation = ((ModPlayer)this).Player.MountedCenter;
		Vector2 cursorLocation = Main.MouseWorld;
		double maxDistanceFromPlayer = V2Utils.TileCountAsPixelCount(4.25);
		double maxDistanceFromCursor = 2000.0;
		for (int npcIndex = 0; npcIndex < Main.maxNPCs; npcIndex++)
		{
			NPC potentialPred = Main.npc[npcIndex];
			if (!((Entity)potentialPred).active || ((Entity)(object)potentialPred).CurrentCaptor() != null)
			{
				continue;
			}
			switch (ModContent.GetInstance<V2ServerConfig>().GenderBlacklist)
			{
			case "No Male":
				if (potentialPred.AsV2NPC().Gender == EntityGender.Male)
				{
					continue;
				}
				break;
			case "No Female":
				if (potentialPred.AsV2NPC().Gender == EntityGender.Female)
				{
					continue;
				}
				break;
			case "No M or F...but why?":
				if (potentialPred.AsV2NPC().Gender != EntityGender.Other)
				{
					continue;
				}
				break;
			}
			if (potentialPred.AsPred().CanBeForceFed(potentialPred) && !((double)((Entity)potentialPred).Distance(playerLocation) >= maxDistanceFromPlayer) && (double)((Entity)potentialPred).Distance(cursorLocation) < maxDistanceFromCursor)
			{
				predIndex = npcIndex;
				predType = "NPC";
				maxDistanceFromCursor = ((Entity)potentialPred).Distance(cursorLocation);
			}
		}
		for (int playerIndex = 0; playerIndex < 255; playerIndex++)
		{
			Player potentialPred2 = Main.player[playerIndex];
			if (!((Entity)potentialPred2).active || potentialPred2.dead || ((Entity)potentialPred2).whoAmI == ((Entity)((ModPlayer)this).Player).whoAmI || ((Entity)(object)potentialPred2).CurrentCaptor() != null)
			{
				continue;
			}
			switch (ModContent.GetInstance<V2ServerConfig>().GenderBlacklist)
			{
			case "No Male":
				if (potentialPred2.Male)
				{
					continue;
				}
				break;
			case "No Female":
				if (!potentialPred2.Male)
				{
					continue;
				}
				break;
			case "No M or F...but why?":
				continue;
			}
			if (!((double)((Entity)potentialPred2).Distance(playerLocation) >= maxDistanceFromPlayer) && (double)((Entity)potentialPred2).Distance(cursorLocation) < maxDistanceFromCursor)
			{
				predIndex = playerIndex;
				predType = "player";
				maxDistanceFromCursor = ((Entity)potentialPred2).Distance(cursorLocation);
			}
		}
		for (int projectileIndex = 0; projectileIndex < Main.maxProjectiles; projectileIndex++)
		{
			Projectile potentialPred3 = Main.projectile[projectileIndex];
			if (!((Entity)potentialPred3).active || ((Entity)(object)potentialPred3).CurrentCaptor() != null)
			{
				continue;
			}
			switch (ModContent.GetInstance<V2ServerConfig>().GenderBlacklist)
			{
			case "No Male":
				if (potentialPred3.AsV2Proj().Gender == EntityGender.Male)
				{
					continue;
				}
				break;
			case "No Female":
				if (potentialPred3.AsV2Proj().Gender == EntityGender.Female)
				{
					continue;
				}
				break;
			case "No M or F...but why?":
				if (potentialPred3.AsV2Proj().Gender != EntityGender.Other)
				{
					continue;
				}
				break;
			}
			if (!((double)((Entity)potentialPred3).Distance(playerLocation) >= maxDistanceFromPlayer) && (double)((Entity)potentialPred3).Distance(cursorLocation) < maxDistanceFromCursor)
			{
				predIndex = projectileIndex;
				predType = "projectile";
				maxDistanceFromCursor = ((Entity)potentialPred3).Distance(cursorLocation);
			}
		}
		if (predType != "none" && predIndex != -1)
		{
			if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
			{
				Main.NewText("Pred found! Pred type: " + predType + ". Pred index: " + predIndex + ".\nCramming " + ((ModPlayer)this).Player.name + " into the chosen stomach...", byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			string foodFor = "";
			switch (predType)
			{
			case "NPC":
			{
				NPC predNPC = Main.npc[predIndex];
				if (!PredNPC.CanSwallow(predNPC, (Entity)(object)((ModPlayer)this).Player))
				{
					return;
				}
				PredNPC.Swallow(predNPC, (Entity)(object)((ModPlayer)this).Player);
				predNPC.AsPred().OnForceFed(predNPC, ((ModPlayer)this).Player);
				foodFor = predNPC.FullName;
				break;
			}
			case "player":
			{
				Player predPlayer = Main.player[predIndex];
				if (!PredPlayer.CanSwallow(predPlayer, (Entity)(object)((ModPlayer)this).Player))
				{
					return;
				}
				PredPlayer.Swallow(predPlayer, (Entity)(object)((ModPlayer)this).Player);
				foodFor = predPlayer.name;
				break;
			}
			case "projectile":
			{
				Projectile predProjectile = Main.projectile[predIndex];
				if (!PredProjectile.CanSwallow(predProjectile, (Entity)(object)((ModPlayer)this).Player))
				{
					return;
				}
				PredProjectile.Swallow(predProjectile, (Entity)(object)((ModPlayer)this).Player);
				predProjectile.AsPred().OnForceFed(predProjectile, ((ModPlayer)this).Player);
				foodFor = predProjectile.Name;
				break;
			}
			}
			if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
			{
				string debugText = "Force-feed action successful; " + ((ModPlayer)this).Player.name + " is now food for " + foodFor + ".";
				if (Main.netMode == 0)
				{
					Main.NewText((object)debugText, (Color?)Color.PaleVioletRed);
				}
				else if (Main.netMode == 2)
				{
					ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(debugText), Color.PaleVioletRed, -1);
				}
			}
		}
		else if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
		{
			string debugText2 = "Force-feed action failed; there are no suitable preds nearby to turn " + ((ModPlayer)this).Player.name + " into a snack for.";
			if (Main.netMode == 0)
			{
				Main.NewText((object)debugText2, (Color?)Color.PaleVioletRed);
			}
			else if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(debugText2), Color.PaleVioletRed, -1);
			}
		}
	}

	public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null || ((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}

	public override bool CanBeHitByProjectile(Projectile proj)
	{
		if (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}

	public override void NaturalLifeRegen(ref float regen)
	{
		if (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null)
		{
			((ModPlayer)this).Player.lifeRegen = 0;
			((ModPlayer)this).Player.lifeRegenTime = 0f;
			((ModPlayer)this).Player.lifeRegenCount = 0;
			regen = 0f;
		}
	}

	public bool TakeDigestionDamage(Entity pred, double digestionDamage)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		int trueDigestionDamage = Main.DamageVar((float)digestionDamage, ((ModPlayer)this).Player.luck);
		for (int i = 0; i < 10; i++)
		{
			Item churnableEquip = ((ModPlayer)this).Player.armor[i];
			if (!churnableEquip.IsAir && churnableEquip.AsFood().MaxHealth != -1 && churnableEquip.AsFood().Health > 0)
			{
				churnableEquip.TakeDigestionDamage(pred, trueDigestionDamage, direct: false, ((Entity)((ModPlayer)this).Player).whoAmI);
			}
		}
		if (ModContent.GetInstance<V2ServerConfig>().DefenseInDigestionCalcs)
		{
			trueDigestionDamage -= DefenseStat.op_Implicit(((ModPlayer)this).Player.statDefense);
		}
		trueDigestionDamage = (int)Math.Round((float)trueDigestionDamage * (1f - ((ModPlayer)this).Player.endurance));
		trueDigestionDamage = (int)Math.Round(((StatModifier)(ref TakenDigestionDamageModifier)).ApplyTo((float)trueDigestionDamage));
		if (trueDigestionDamage < 1)
		{
			trueDigestionDamage = 1;
		}
		SoftenedDigestionDamageTaken += ((StatModifier)(ref SoftenedDigestionDamageModifier)).ApplyTo((float)trueDigestionDamage);
		SoftenedWearoffDelay = SoftenedWearoffMaxDelay;
		Player player = ((ModPlayer)this).Player;
		player.statLife -= trueDigestionDamage;
		switch (Main.netMode)
		{
		case 0:
			if (ModContent.GetInstance<V2ClientConfig>().ShowChurnDamageNumbers)
			{
				CombatText obj = Main.combatText[CombatText.NewText(((Entity)((ModPlayer)this).Player).Hitbox, Color.DarkGreen, trueDigestionDamage, false, true)];
				obj.position.X = pred.Center.X + (float)(pred.direction * 28);
				obj.position.Y = ((Entity)((ModPlayer)this).Player).Center.Y + (float)((Entity)((ModPlayer)this).Player).height / 5f;
				obj.velocity.X = (float)pred.direction * 2.5f;
				obj.velocity.Y = -4f;
			}
			break;
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)6);
			((BinaryWriter)(object)packet).Write(((Entity)((ModPlayer)this).Player).whoAmI);
			((BinaryWriter)(object)packet).Write(trueDigestionDamage);
			((BinaryWriter)(object)packet).Write(pred.Center.X + (float)(pred.direction * 28));
			((BinaryWriter)(object)packet).Write(((Entity)((ModPlayer)this).Player).Center.Y + (float)((Entity)((ModPlayer)this).Player).height / 5f);
			((BinaryWriter)(object)packet).Write((float)pred.direction * 2.5f);
			((BinaryWriter)(object)packet).Write(-4f);
			packet.Send(-1, -1);
			break;
		}
		}
		SoundStyle val = (((ModPlayer)this).Player.Male ? PreyPlayerDigestionSounds.PlayerDigestingMale : PreyPlayerDigestionSounds.PlayerDigestingFemale);
		SoundEngine.PlaySound(ref val, (Vector2?)pred.position, (SoundUpdateCallback)null);
		if (((ModPlayer)this).Player.statLife <= 0)
		{
			Digested = true;
			TotalTimesDigested++;
			NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
			if (predNPC != null)
			{
				((ModPlayer)this).Player.KillMe(PlayerDeathReason.ByCustomReason(PredNPC.GetDigestedPlayerDeathReason(predNPC, ((ModPlayer)this).Player)), (double)trueDigestionDamage, 0, false);
			}
			else
			{
				Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
				if (predPlayer != null)
				{
					((ModPlayer)this).Player.KillMe(PlayerDeathReason.ByCustomReason(PredPlayer.GetDigestedPlayerDeathReason(predPlayer, ((ModPlayer)this).Player)), (double)trueDigestionDamage, 0, false);
				}
				else
				{
					Projectile predProjectile = (Projectile)(object)((pred is Projectile) ? pred : null);
					if (predProjectile != null)
					{
						((ModPlayer)this).Player.KillMe(PlayerDeathReason.ByCustomReason(PredProjectile.GetDigestedPlayerDeathReason(predProjectile, ((ModPlayer)this).Player)), (double)trueDigestionDamage, 0, false);
					}
					else
					{
						((ModPlayer)this).Player.KillMe(PlayerDeathReason.ByCustomReason(((ModPlayer)this).Player.name + " was digested."), (double)trueDigestionDamage, 0, false);
					}
				}
			}
			if (Main.netMode != 2 && ((Entity)((ModPlayer)this).Player).whoAmI == Main.myPlayer && ModContent.GetInstance<V2ClientConfig>().TheGutSlutVisionOMatic)
			{
				GuttedGaze = true;
				GuttedGazePred = pred;
			}
			return true;
		}
		return false;
	}

	public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
	{
		if (Digested)
		{
			playSound = false;
			genGore = false;
		}
		if (damageSource.SourceOtherIndex == 1 && TotalTimesDigested >= 20)
		{
			damageSource.SourceCustomReason = Language.GetTextValueWith(Utils.NextFromList<string>(Main.rand, new string[3] { "Mods.V2.Death.DrownedPlayer.GutSlut.1", "Mods.V2.Death.DrownedPlayer.GutSlut.2", "Mods.V2.Death.DrownedPlayer.GutSlut.3" }), (object)new
			{
				Player = ((ModPlayer)this).Player.name
			});
		}
		if (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null && !Digested)
		{
			((Entity)(object)((ModPlayer)this).Player).CurrentCaptor().Prey.RemoveAll((PreyData x) => x.Type == PreyType.Player && x.Instance.whoAmI == ((Entity)((ModPlayer)this).Player).whoAmI);
		}
		return true;
	}

	public override void HideDrawLayers(PlayerDrawSet drawInfo)
	{
		foreach (PlayerDrawLayer drawLayer in PlayerDrawLayerLoader.Layers)
		{
			if (!Main.gameMenu && (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null || Digested))
			{
				drawLayer.Hide();
			}
		}
	}

	public override void SaveData(TagCompound tag)
	{
	}

	public override void LoadData(TagCompound tag)
	{
	}
}
